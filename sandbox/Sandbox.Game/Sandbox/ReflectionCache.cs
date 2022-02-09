using System;
using System.Collections.Generic;
using System.Reflection;

namespace Sandbox
{
	/// <summary>
	/// This cache might be fucking stupid
	/// </summary>
	// Token: 0x02000102 RID: 258
	internal class ReflectionCache
	{
		// Token: 0x06001503 RID: 5379 RVA: 0x00053BF3 File Offset: 0x00051DF3
		public ReflectionCache(Type type)
		{
			this.OwnerType = type;
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06001504 RID: 5380 RVA: 0x00053C04 File Offset: 0x00051E04
		public MethodInfo[] AllMethods
		{
			get
			{
				if (this._allMethods != null)
				{
					return this._allMethods;
				}
				List<MethodInfo> all = new List<MethodInfo>();
				ReflectionCache.GetAllMethods(this.OwnerType, all, null);
				this._allMethods = all.ToArray();
				return this._allMethods;
			}
		}

		/// <summary>
		/// Get all methods in this type, including private ones, including repeats
		/// </summary>
		// Token: 0x06001505 RID: 5381 RVA: 0x00053C48 File Offset: 0x00051E48
		internal static void GetAllMethods(Type type, List<MethodInfo> list, HashSet<string> names = null)
		{
			if (names == null)
			{
				names = new HashSet<string>();
			}
			foreach (MethodInfo method in type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
			{
				string name = method.Name;
				if (!names.Contains(name))
				{
					list.Add(method);
					names.Add(name);
				}
			}
			if (type.BaseType != null)
			{
				ReflectionCache.GetAllMethods(type.BaseType, list, names);
			}
		}

		// Token: 0x06001506 RID: 5382 RVA: 0x00053CB4 File Offset: 0x00051EB4
		public static ReflectionCache Get(Type type)
		{
			ReflectionCache val;
			if (ReflectionCache.Index.TryGetValue(type, out val))
			{
				return val;
			}
			val = new ReflectionCache(type);
			ReflectionCache.Index[type] = val;
			return val;
		}

		// Token: 0x06001507 RID: 5383 RVA: 0x00053CE6 File Offset: 0x00051EE6
		[Event.HotloadAttribute]
		internal static void OnHotload()
		{
			ReflectionCache.Index.Clear();
		}

		// Token: 0x040004E6 RID: 1254
		[Hotload.SkipAttribute]
		private static Dictionary<Type, ReflectionCache> Index = new Dictionary<Type, ReflectionCache>();

		// Token: 0x040004E7 RID: 1255
		private Type OwnerType;

		// Token: 0x040004E8 RID: 1256
		private MethodInfo[] _allMethods;
	}
}
