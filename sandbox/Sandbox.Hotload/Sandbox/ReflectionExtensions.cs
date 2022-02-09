using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Mono.Cecil;

namespace Sandbox
{
	// Token: 0x02000005 RID: 5
	internal static class ReflectionExtensions
	{
		// Token: 0x06000032 RID: 50 RVA: 0x00003675 File Offset: 0x00001875
		public static string ToSimpleString(this Type type)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendType(type);
			return stringBuilder.ToString();
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003688 File Offset: 0x00001888
		private static void AppendType(this StringBuilder sb, Type type)
		{
			if (type.IsGenericMethodParameter || type.IsGenericTypeParameter)
			{
				return;
			}
			if (type.IsArray)
			{
				sb.AppendType(type.GetElementType());
				sb.Append("[");
				for (int i = 1; i < type.GetArrayRank(); i++)
				{
					sb.Append(",");
				}
				sb.Append("]");
				return;
			}
			if (type.IsByRef)
			{
				sb.Append("ref ");
				sb.AppendType(type.GetElementType());
				return;
			}
			if (type.IsPointer)
			{
				sb.AppendType(type.GetElementType());
				sb.Append("*");
				return;
			}
			if (type.IsNested)
			{
				sb.AppendType(type.DeclaringType);
				sb.Append(".");
			}
			else if (type.Namespace != null)
			{
				sb.Append(type.Namespace);
				sb.Append(".");
			}
			if (type.IsGenericType)
			{
				int quoteIndex = type.Name.IndexOf('`');
				sb.Append((quoteIndex == -1) ? type.Name : type.Name.Substring(0, type.Name.IndexOf('`')));
				sb.Append("<");
				bool first = true;
				foreach (Type arg in type.GetGenericArguments())
				{
					if (first)
					{
						first = false;
					}
					else
					{
						sb.Append(", ");
					}
					sb.AppendType(arg);
				}
				sb.Append(">");
				return;
			}
			sb.Append(type.Name);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000381C File Offset: 0x00001A1C
		private static string GetAssemblyFullName(this IMetadataScope scope)
		{
			MetadataScopeType metadataScopeType = scope.MetadataScopeType;
			if (metadataScopeType == MetadataScopeType.AssemblyNameReference)
			{
				return ((AssemblyNameReference)scope).FullName;
			}
			if (metadataScopeType != MetadataScopeType.ModuleDefinition)
			{
				throw new NotImplementedException();
			}
			return ((ModuleDefinition)scope).Assembly.FullName;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000385B File Offset: 0x00001A5B
		public static Type ResolveType(this Module module, TypeReference typeRef)
		{
			return Assembly.Load(new AssemblyName(typeRef.Scope.GetAssemblyFullName())).GetType(typeRef.FullName, true, false);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000387F File Offset: 0x00001A7F
		public static FieldInfo ResolveField(this Module module, FieldReference fieldRef)
		{
			return module.ResolveType(fieldRef.DeclaringType).GetField(fieldRef.Name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000389C File Offset: 0x00001A9C
		public static MethodBase ResolveMethod(this Module module, MethodReference methodRef)
		{
			Type declaringType = module.ResolveType(methodRef.DeclaringType);
			Type[] types = new Type[methodRef.Parameters.Count];
			for (int i = 0; i < methodRef.Parameters.Count; i++)
			{
				types[i] = module.ResolveType(methodRef.Parameters[i].ParameterType);
			}
			if (methodRef.Name == ".ctor")
			{
				return declaringType.GetTypeInfo().GetConstructor(types);
			}
			return declaringType.GetTypeInfo().GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).FirstOrDefault(delegate(MethodInfo x)
			{
				if (x.Name != methodRef.Name)
				{
					return false;
				}
				ParameterInfo[] parameters = x.GetParameters();
				if (parameters.Length != types.Length)
				{
					return false;
				}
				for (int j = 0; j < parameters.Length; j++)
				{
					if (parameters[j].ParameterType != types[j])
					{
						return false;
					}
				}
				return true;
			});
		}
	}
}
