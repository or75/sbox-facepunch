using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Sandbox
{
	/// <summary>
	/// Allows the registration/creation of classes by name, in a generic way.
	/// Also remembers class by assembly name, so we can gracefully handle hotloading.
	/// </summary>
	// Token: 0x0200006A RID: 106
	public static class Library
	{
		/// <summary>
		/// Called on all loaded assemblies to gather classes with ClassLibrary attributes
		/// </summary>
		// Token: 0x06000C33 RID: 3123 RVA: 0x0003EC64 File Offset: 0x0003CE64
		internal static void AddAssembly(Assembly assembly, Type[] types = null)
		{
			if (types == null)
			{
				types = assembly.GetTypes();
			}
			List<LibraryAttribute> allAttributes = Library.AllAttributes;
			lock (allAttributes)
			{
				foreach (Type type in types)
				{
					Library.ProcessType(type, assembly);
					foreach (FieldInfo member in type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
					{
						Library.ProcessField(type, member);
					}
					foreach (MemberInfo member2 in type.GetMembers())
					{
						LibraryAttribute att = member2.GetCustomAttribute(false);
						if (att != null)
						{
							att.InitializeMember(member2, type, assembly);
							if (att.Assembly != null)
							{
								Library.AllAttributes.Add(att);
							}
							else
							{
								Library.log.Warning("LibraryAttribute.InitializeMember was called but attr.Assembly was null!");
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Process this type, add it to the library if it has the right tags
		/// </summary>
		// Token: 0x06000C34 RID: 3124 RVA: 0x0003ED64 File Offset: 0x0003CF64
		private static void ProcessType(Type type, Assembly assembly)
		{
			bool found = false;
			foreach (LibraryAttribute attr in type.GetCustomAttributes(false))
			{
				found = true;
				Library.EnrollType(type, assembly, attr);
			}
			if (!found && Library.ShouldAutomaticallyEnrollType(type))
			{
				Library.EnrollType(type, assembly, new LibraryAttribute());
			}
		}

		/// <summary>
		/// Should this class be automatically added to the class library, even if it isn't tagged with an attribute
		/// </summary>
		// Token: 0x06000C35 RID: 3125 RVA: 0x0003EDD0 File Offset: 0x0003CFD0
		private static void EnrollType(Type type, Assembly assembly, LibraryAttribute attr)
		{
			attr.InitializeClass(type, assembly);
			Library.AllAttributes.RemoveAll((LibraryAttribute x) => x.Name == attr.Name);
			Library.AllAttributes.Add(attr);
			Library.ClassDict[attr.Identifier] = attr;
			Library.TypeDict[type] = attr;
		}

		/// <summary>
		/// Should this class be automatically added to the class library, even if it isn't tagged with an attribute
		/// </summary>
		// Token: 0x06000C36 RID: 3126 RVA: 0x0003EE4A File Offset: 0x0003D04A
		private static bool ShouldAutomaticallyEnrollType(Type type)
		{
			return type.IsAssignableTo(typeof(LibraryClass));
		}

		// Token: 0x06000C37 RID: 3127 RVA: 0x0003EE64 File Offset: 0x0003D064
		private static void ProcessField(Type type, FieldInfo field)
		{
			if (field.IsStatic && field.FieldType.IsAssignableTo(typeof(IRuntimeAsset)))
			{
				IRuntimeAsset runtimeAsset = field.GetValue(null) as IRuntimeAsset;
				if (runtimeAsset != null)
				{
					runtimeAsset.StaticRuntimeInit(type.FullName + "." + field.Name);
				}
			}
		}

		/// <summary>
		/// Called when an assembly is being removed
		/// </summary>
		// Token: 0x06000C38 RID: 3128 RVA: 0x0003EEBC File Offset: 0x0003D0BC
		internal static void RemoveAssembly(Assembly assembly)
		{
			if (assembly == null)
			{
				return;
			}
			List<LibraryAttribute> allAttributes = Library.AllAttributes;
			lock (allAttributes)
			{
				int removeCount = 0;
				IEnumerable<LibraryAttribute> allAttributes2 = Library.AllAttributes;
				Func<LibraryAttribute, bool> <>9__0;
				Func<LibraryAttribute, bool> predicate;
				if ((predicate = <>9__0) == null)
				{
					predicate = (<>9__0 = (LibraryAttribute x) => x.Assembly == assembly);
				}
				foreach (LibraryAttribute a in allAttributes2.Where(predicate).ToArray<LibraryAttribute>())
				{
					LibraryAttribute libraryAttribute;
					Library.ClassDict.Remove(a.Identifier, out libraryAttribute);
					Library.AllAttributes.Remove(a);
					if (a.Class != null)
					{
						Library.TypeDict.Remove(a.Class, out libraryAttribute);
					}
					removeCount++;
				}
			}
		}

		/// <summary>
		/// Create a class by name. Will return null if class is wrong type or not found.
		/// </summary>
		// Token: 0x06000C39 RID: 3129 RVA: 0x0003EFA8 File Offset: 0x0003D1A8
		public static T Create<T>(string name = null, bool complainOnMissing = true)
		{
			if (name == null)
			{
				name = typeof(T).FullName;
			}
			List<LibraryAttribute> allAttributes = Library.AllAttributes;
			LibraryAttribute attr;
			lock (allAttributes)
			{
				attr = Library.AllAttributes.Find((LibraryAttribute x) => x.IsNamed(name) && typeof(T).IsAssignableFrom(x.Class));
				if (attr == null)
				{
					if (complainOnMissing)
					{
						Library.log.Error(FormattableStringFactory.Create("Tried to find class named {0}", new object[] { name }));
					}
					return default(T);
				}
			}
			return attr.Create<T>();
		}

		/// <summary>
		/// Create a class by identifier. Will return null if class is wrong type or not found.
		/// </summary>
		// Token: 0x06000C3A RID: 3130 RVA: 0x0003F064 File Offset: 0x0003D264
		public static T TryCreate<T>(int ident)
		{
			LibraryAttribute attr;
			T result;
			if (!Library.ClassDict.TryGetValue(ident, out attr))
			{
				result = default(T);
				return result;
			}
			if (attr.TypeInfo.AsType() != typeof(T) && !attr.TypeInfo.IsSubclassOf(typeof(T)) && !typeof(T).IsAssignableFrom(attr.TypeInfo))
			{
				Library.log.Error(FormattableStringFactory.Create("Tried to create {0} from stored class {1} named {2}", new object[]
				{
					typeof(T),
					attr.Class,
					attr.Name
				}));
				result = default(T);
				return result;
			}
			try
			{
				result = (T)((object)Activator.CreateInstance(attr.Class));
			}
			catch (MissingMethodException e)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Couldn't create \"");
				defaultInterpolatedStringHandler.AppendFormatted<Type>(attr.Class);
				defaultInterpolatedStringHandler.AppendLiteral("\"");
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear(), e);
			}
			return result;
		}

		/// <summary>
		/// Create a class by type. Will return null if class is wrong type or not found.
		/// </summary>
		// Token: 0x06000C3B RID: 3131 RVA: 0x0003F17C File Offset: 0x0003D37C
		public static T Create<T>(Type t)
		{
			LibraryAttribute attr = Library.GetAttribute(t);
			T result;
			if (attr == null || !typeof(T).IsAssignableFrom(attr.Class))
			{
				Library.log.Error(FormattableStringFactory.Create("Tried to find class {0}", new object[] { t }));
				result = default(T);
				return result;
			}
			if (attr.TypeInfo.AsType() != typeof(T) && !attr.TypeInfo.IsSubclassOf(typeof(T)) && !typeof(T).IsAssignableFrom(attr.TypeInfo))
			{
				Library.log.Error(FormattableStringFactory.Create("Tried to create {0} from stored class {1} type {2}", new object[]
				{
					typeof(T),
					attr.Class,
					t
				}));
				result = default(T);
				return result;
			}
			try
			{
				result = (T)((object)Activator.CreateInstance(attr.Class));
			}
			catch (MissingMethodException e)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Couldn't create \"");
				defaultInterpolatedStringHandler.AppendFormatted<Type>(t);
				defaultInterpolatedStringHandler.AppendLiteral("\"");
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear(), e);
			}
			return result;
		}

		/// <summary>
		/// Returns all class registrations.
		/// </summary>
		// Token: 0x06000C3C RID: 3132 RVA: 0x0003F2B8 File Offset: 0x0003D4B8
		public static IEnumerable<LibraryAttribute> GetAll()
		{
			List<LibraryAttribute> allAttributes = Library.AllAttributes;
			IEnumerable<LibraryAttribute> result;
			lock (allAttributes)
			{
				result = Library.AllAttributes.ToList<LibraryAttribute>();
			}
			return result;
		}

		/// <summary>
		/// Get all types that are derived from type
		/// </summary>
		// Token: 0x06000C3D RID: 3133 RVA: 0x0003F300 File Offset: 0x0003D500
		public static IEnumerable<Type> GetAll<T>()
		{
			List<LibraryAttribute> allAttributes = Library.AllAttributes;
			IEnumerable<Type> result;
			lock (allAttributes)
			{
				result = (from x in Library.AllAttributes
					where typeof(T).IsAssignableFrom(x.Class)
					select x.Class).ToList<Type>();
			}
			return result;
		}

		/// <summary>
		/// Find an attribute from a name
		/// </summary>
		// Token: 0x06000C3E RID: 3134 RVA: 0x0003F390 File Offset: 0x0003D590
		public static LibraryAttribute GetAttribute(string name)
		{
			List<LibraryAttribute> allAttributes = Library.AllAttributes;
			LibraryAttribute result;
			lock (allAttributes)
			{
				LibraryAttribute attr = Library.AllAttributes.Find((LibraryAttribute x) => x.IsNamed(name));
				if (attr == null)
				{
					result = null;
				}
				else
				{
					result = attr;
				}
			}
			return result;
		}

		/// <summary>
		/// Get all library attributes that are attached to type
		/// </summary>
		// Token: 0x06000C3F RID: 3135 RVA: 0x0003F3FC File Offset: 0x0003D5FC
		public static IEnumerable<LibraryAttribute> GetAllAttributes<T>()
		{
			List<LibraryAttribute> allAttributes = Library.AllAttributes;
			IEnumerable<LibraryAttribute> result;
			lock (allAttributes)
			{
				result = Library.AllAttributes.Where((LibraryAttribute x) => typeof(T).IsAssignableFrom(x.Class)).ToList<LibraryAttribute>();
			}
			return result;
		}

		/// <summary>
		/// Get custom attributes that are derived from type
		/// </summary>
		// Token: 0x06000C40 RID: 3136 RVA: 0x0003F468 File Offset: 0x0003D668
		public static IEnumerable<T> GetAttributes<T>() where T : LibraryAttribute
		{
			List<LibraryAttribute> allAttributes = Library.AllAttributes;
			IEnumerable<T> result;
			lock (allAttributes)
			{
				result = Library.AllAttributes.Where((LibraryAttribute x) => typeof(T).IsAssignableFrom(x.GetType())).Cast<T>().ToList<T>();
			}
			return result;
		}

		/// <summary>
		/// Given the name and base type, return the type (or null if it doesn't exist)
		/// </summary>
		// Token: 0x06000C41 RID: 3137 RVA: 0x0003F4D8 File Offset: 0x0003D6D8
		public static Type Get<T>(string name)
		{
			List<LibraryAttribute> allAttributes = Library.AllAttributes;
			Type result;
			lock (allAttributes)
			{
				LibraryAttribute attr = Library.AllAttributes.Find((LibraryAttribute x) => x.IsNamed(name) && typeof(T).IsAssignableFrom(x.Class));
				if (attr == null)
				{
					result = null;
				}
				else
				{
					result = attr.Class;
				}
			}
			return result;
		}

		/// <summary>
		/// Returns true if this type exists
		/// </summary>
		// Token: 0x06000C42 RID: 3138 RVA: 0x0003F548 File Offset: 0x0003D748
		public static bool Exists<T>(string name)
		{
			return Library.Get<T>(name) != null;
		}

		/// <summary>
		/// Returns all class registrations.
		/// </summary>
		// Token: 0x06000C43 RID: 3139 RVA: 0x0003F558 File Offset: 0x0003D758
		public static LibraryAttribute GetAttribute(Type t)
		{
			LibraryAttribute libraryAttribute;
			if (Library.TypeDict.TryGetValue(t, out libraryAttribute))
			{
				return libraryAttribute;
			}
			return null;
		}

		/// <summary>
		/// Returns the Type associated with given library name, or null.
		/// </summary>
		// Token: 0x06000C44 RID: 3140 RVA: 0x0003F578 File Offset: 0x0003D778
		public static Type GetType(string name)
		{
			List<LibraryAttribute> allAttributes = Library.AllAttributes;
			Type result;
			lock (allAttributes)
			{
				LibraryAttribute attr = Library.AllAttributes.Find((LibraryAttribute x) => x.IsNamed(name));
				result = ((attr != null) ? attr.Class : null);
			}
			return result;
		}

		// Token: 0x0400018E RID: 398
		private static Logger log = Logging.GetLogger(null);

		// Token: 0x0400018F RID: 399
		private static readonly List<LibraryAttribute> AllAttributes = new List<LibraryAttribute>();

		// Token: 0x04000190 RID: 400
		private static readonly ConcurrentDictionary<int, LibraryAttribute> ClassDict = new ConcurrentDictionary<int, LibraryAttribute>();

		// Token: 0x04000191 RID: 401
		private static readonly ConcurrentDictionary<Type, LibraryAttribute> TypeDict = new ConcurrentDictionary<Type, LibraryAttribute>();
	}
}
