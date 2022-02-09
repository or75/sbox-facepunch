using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Sandbox.Internal
{
	// Token: 0x02000002 RID: 2
	public class ReflectionSystem
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		internal bool IsOurAssembly(Assembly asm)
		{
			return this.Assemblies.Contains(asm);
		}

		/// <summary>
		/// Add an assembly which can be removed and hotloaded
		/// </summary>
		// Token: 0x06000002 RID: 2 RVA: 0x00002060 File Offset: 0x00000260
		internal void AddDynamicAssembly(Assembly old_assembly, Assembly new_assembly)
		{
			if (old_assembly != null)
			{
				this.log.Info(FormattableStringFactory.Create("Removing: {0}", new object[] { old_assembly }));
			}
			if (new_assembly != null)
			{
				this.log.Info(FormattableStringFactory.Create("Adding: {0}", new object[] { new_assembly }));
			}
			this.RemoveAssembly(old_assembly);
			this.AddAssembly(new_assembly);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020CC File Offset: 0x000002CC
		private void AddAssembly(Assembly new_assembly)
		{
			if (new_assembly == null)
			{
				return;
			}
			this.Assemblies.Add(new_assembly);
			foreach (Type type in new_assembly.GetTypes())
			{
				if (!type.IsNotPublic)
				{
					foreach (Attribute attr in type.GetCustomAttributes())
					{
						MethodInfo register = attr.GetType().GetMethod("RegisterType", BindingFlags.Static | BindingFlags.Public);
						this.InvokeWithExceptionCatching(register, null, new object[] { type, attr });
					}
					this.Types.Add(type);
					this.AddMembers(type);
				}
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002190 File Offset: 0x00000390
		private void AddMembers(Type type)
		{
			foreach (MemberInfo member in type.GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy))
			{
				if (this.IsOurAssembly(member.DeclaringType.Assembly))
				{
					Attribute[] allAttributes = member.GetCustomAttributes().ToArray<Attribute>();
					if (allAttributes.Length != 0)
					{
						MethodInfo methodInfo = member as MethodInfo;
						if (methodInfo != null && methodInfo.IsStatic)
						{
							foreach (Attribute attr in allAttributes)
							{
								MethodInfo register = attr.GetType().GetMethod("RegisterMethod", BindingFlags.Static | BindingFlags.Public);
								this.InvokeWithExceptionCatching(register, null, new object[] { methodInfo, attr });
							}
							this.StaticMethods.Add(methodInfo);
						}
						PropertyInfo propertyInfo = member as PropertyInfo;
						if (propertyInfo != null)
						{
							MethodInfo getMethod = propertyInfo.GetMethod;
							if (getMethod != null && getMethod.IsStatic)
							{
								MethodInfo setMethod = propertyInfo.SetMethod;
								if (setMethod != null && setMethod.IsStatic)
								{
									foreach (Attribute attr2 in allAttributes)
									{
										MethodInfo register2 = attr2.GetType().GetMethod("RegisterProperty", BindingFlags.Static | BindingFlags.Public);
										this.InvokeWithExceptionCatching(register2, null, new object[] { propertyInfo, attr2 });
									}
									this.StaticProperties.Add(propertyInfo);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000022E8 File Offset: 0x000004E8
		private void RemoveAssembly(Assembly old_assembly)
		{
			if (old_assembly == null)
			{
				return;
			}
			this.Assemblies.Remove(old_assembly);
			int typesRemoved = 0;
			IEnumerable<Type> types = this.Types;
			Func<Type, bool> <>9__2;
			Func<Type, bool> predicate;
			if ((predicate = <>9__2) == null)
			{
				predicate = (<>9__2 = (Type x) => x.Assembly == old_assembly);
			}
			foreach (Type type in types.Where(predicate).ToArray<Type>())
			{
				typesRemoved++;
				this.Types.Remove(type);
				foreach (Attribute attr in type.GetCustomAttributes())
				{
					MethodInfo unreg = attr.GetType().GetMethod("UnregisterType", BindingFlags.Static | BindingFlags.Public);
					this.InvokeWithExceptionCatching(unreg, null, new object[] { type, attr });
				}
			}
			foreach (MethodInfo methodInfo in this.StaticMethods)
			{
				foreach (Attribute attr2 in methodInfo.GetCustomAttributes())
				{
					MethodInfo register = attr2.GetType().GetMethod("UnregisterMethod", BindingFlags.Static | BindingFlags.Public);
					this.InvokeWithExceptionCatching(register, null, new object[] { methodInfo, attr2 });
				}
			}
			int staticsRemoved = this.StaticMethods.RemoveAll((MethodInfo x) => x.DeclaringType.Assembly == old_assembly);
			foreach (PropertyInfo propertyInfo in this.StaticProperties)
			{
				foreach (Attribute attr3 in propertyInfo.GetCustomAttributes())
				{
					MethodInfo register2 = attr3.GetType().GetMethod("UnregisterProperty", BindingFlags.Static | BindingFlags.Public);
					this.InvokeWithExceptionCatching(register2, null, new object[] { propertyInfo, attr3 });
				}
			}
			staticsRemoved = this.StaticProperties.RemoveAll((PropertyInfo x) => x.DeclaringType.Assembly == old_assembly);
			this.log.Info(FormattableStringFactory.Create("Removed {0} static properties", new object[] { staticsRemoved }));
		}

		/// <summary>
		/// Add an assembly which isn't going to change ( ie Sandbox.Game )
		/// </summary>
		// Token: 0x06000006 RID: 6 RVA: 0x00002598 File Offset: 0x00000798
		internal void AddStaticAssembly(Assembly assembly)
		{
			this.log.Info(FormattableStringFactory.Create("Adding Static: {0}", new object[] { assembly }));
			this.AddAssembly(assembly);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000025C0 File Offset: 0x000007C0
		public IEnumerable<MethodInfo> FindMethodsWithAttribute<T>() where T : Attribute
		{
			return this.StaticMethods.Where((MethodInfo x) => x.GetCustomAttributes<T>().Count<T>() > 0);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000025EC File Offset: 0x000007EC
		private object InvokeWithExceptionCatching(MethodInfo methodInfo, object self, object[] args)
		{
			object result;
			try
			{
				result = ((methodInfo != null) ? methodInfo.Invoke(self, args) : null);
			}
			catch (TargetInvocationException ex)
			{
				this.log.Warning(ex.InnerException, ex.InnerException.Message);
				result = null;
			}
			catch (Exception ex2)
			{
				this.log.Warning(ex2, ex2.Message);
				result = null;
			}
			return result;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002660 File Offset: 0x00000860
		private bool AssemblyCheck(Assembly a)
		{
			return a.GetName().Name.StartsWith("Dynamic.");
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002677 File Offset: 0x00000877
		private bool TypeCheck(Type t)
		{
			return this.AssemblyCheck(t.Assembly);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002688 File Offset: 0x00000888
		private bool PropertyCheck(PropertyInfo p)
		{
			string assemblyName = p.DeclaringType.Assembly.GetName().Name;
			if (p.DeclaringType.Assembly.GetName().Name.StartsWith("Dynamic."))
			{
				return true;
			}
			if (!assemblyName.StartsWith("Sandbox."))
			{
				return false;
			}
			MethodInfo getMethod = p.GetGetMethod();
			if (getMethod != null && !getMethod.IsPublic)
			{
				return false;
			}
			MethodInfo setMethod = p.GetSetMethod();
			return setMethod == null || setMethod.IsPublic;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000270A File Offset: 0x0000090A
		public PropertyInfo[] GetProperties(object obj, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
		{
			return (from x in obj.GetType().GetProperties(flags)
				where this.PropertyCheck(x)
				select x).ToArray<PropertyInfo>();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002730 File Offset: 0x00000930
		public ReflectionSystem(Logger log)
		{
			this.log = log;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002781 File Offset: 0x00000981
		internal void Shutdown()
		{
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002783 File Offset: 0x00000983
		internal T CreateType<T>(Type type, object[] constructorParams)
		{
			return (T)((object)Activator.CreateInstance(type, constructorParams));
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002791 File Offset: 0x00000991
		[return: TupleElementNames(new string[] { "attribute", "type" })]
		public IEnumerable<ValueTuple<Attribute, Type>> FindTypesWithAttribute<TType, TAttr>() where TAttr : Attribute
		{
			foreach (Type type in this.Types)
			{
				foreach (TAttr attr in type.GetCustomAttributes<TAttr>())
				{
					yield return new ValueTuple<Attribute, Type>(attr, type);
				}
				IEnumerator<TAttr> enumerator2 = null;
				type = null;
			}
			List<Type>.Enumerator enumerator = default(List<Type>.Enumerator);
			yield break;
			yield break;
		}

		// Token: 0x04000001 RID: 1
		internal List<Assembly> Assemblies = new List<Assembly>();

		// Token: 0x04000002 RID: 2
		internal List<Assembly> StaticAssemblies = new List<Assembly>();

		// Token: 0x04000003 RID: 3
		internal List<MethodInfo> StaticMethods = new List<MethodInfo>();

		// Token: 0x04000004 RID: 4
		internal List<PropertyInfo> StaticProperties = new List<PropertyInfo>();

		// Token: 0x04000005 RID: 5
		internal List<Type> Types = new List<Type>();

		// Token: 0x04000006 RID: 6
		private Logger log;
	}
}
