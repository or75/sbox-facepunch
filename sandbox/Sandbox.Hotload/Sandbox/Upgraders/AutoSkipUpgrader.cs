using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sandbox.Upgraders
{
	/// <summary>
	/// Instance upgrader that will try to automatically find types are definitely skippable. This upgrader isn't
	/// added automatically, you can enable it by calling <see cref="M:Sandbox.Hotload.AddUpgrader(Sandbox.Hotload.IInstanceUpgrader)" />.
	/// </summary>
	/// <remarks>
	/// <para>
	/// We attempt this almost last (just before <see cref="T:Sandbox.Upgraders.DefaultUpgrader" />) so that any upgraders
	/// that handle specific types will be chosen first, and therefore stop those types from being skipped.
	/// Adds any skippable types it finds to a cache, and forces <see cref="F:Sandbox.Upgraders.AutoSkipUpgrader.SkipUpgrader" /> to process them.
	/// </para>
	/// <para>
	/// This performs an under-approximation, but you can use <see cref="T:Sandbox.Hotload.SkipAttribute" /> to mark any types it
	/// misses that you know are safe to skip.
	/// </para>
	/// </remarks>
	// Token: 0x0200001E RID: 30
	[DisableAutoCreation]
	[UpgraderGroup(typeof(RootUpgraderGroup), GroupOrder.Last)]
	[AttemptBefore(new Type[] { typeof(DefaultUpgrader) })]
	public class AutoSkipUpgrader : Hotload.InstanceUpgrader
	{
		/// <summary>
		/// The set of types that have been determined to be safe to skip.
		/// </summary>
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000DC RID: 220 RVA: 0x0000617A File Offset: 0x0000437A
		public IEnumerable<Type> SkippedTypes
		{
			get
			{
				return this.SkippedTypeList.OrderBy((Type x) => x.ToString());
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000061A6 File Offset: 0x000043A6
		protected override void OnInitialize()
		{
			this.RootUpgraderGroup = base.GetUpgrader<RootUpgraderGroup>();
			this.ReferenceTypeUpgraderGroup = base.GetUpgrader<ReferenceTypeUpgraderGroup>();
			this.SkipUpgrader = base.GetUpgrader<SkipUpgrader>();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000061CC File Offset: 0x000043CC
		protected override void OnHotloadStart()
		{
			this.SkippedTypeList.Clear();
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000061D9 File Offset: 0x000043D9
		protected override void OnClearCache()
		{
			this.AllFieldsSkippableCache.Clear();
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x000061E8 File Offset: 0x000043E8
		private bool AllFieldsSkippable(Type type)
		{
			if (type.IsPrimitive)
			{
				return true;
			}
			if (type.IsPointer)
			{
				return true;
			}
			bool cached;
			if (this.AllFieldsSkippableCache.TryGetValue(type, out cached))
			{
				return cached;
			}
			this.AllFieldsSkippableCache.Add(type, false);
			if (base.GetNewType(type) != type)
			{
				return false;
			}
			Hotload.IInstanceUpgrader firstUpgrader = this.ReferenceTypeUpgraderGroup.GetUpgradersForType(type).FirstOrDefault((Hotload.IInstanceUpgrader x) => !(x is CachedUpgrader));
			if (firstUpgrader != null)
			{
				return firstUpgrader is SkipUpgrader && (this.AllFieldsSkippableCache[type] = true);
			}
			if (type.BaseType != null && !this.AllFieldsSkippable(type.BaseType))
			{
				return false;
			}
			foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				if (!(fieldInfo.DeclaringType != type) && fieldInfo.GetCustomAttribute<Hotload.SkipAttribute>() == null)
				{
					if (!fieldInfo.FieldType.IsValueType && !fieldInfo.FieldType.IsSealed)
					{
						return false;
					}
					if (!this.AllFieldsSkippable(fieldInfo.FieldType))
					{
						return false;
					}
				}
			}
			this.SkippedTypeList.Add(type);
			this.RootUpgraderGroup.SetUpgradersForType(type, new Hotload.IInstanceUpgrader[] { this.SkipUpgrader });
			return this.AllFieldsSkippableCache[type] = true;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00006345 File Offset: 0x00004545
		public override bool ShouldProcessType(Type type)
		{
			return this.AllFieldsSkippable(type);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000634E File Offset: 0x0000454E
		protected override bool OnTryCreateNewInstance(object oldInstance, object context, out object newInstance)
		{
			newInstance = oldInstance;
			return true;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00006354 File Offset: 0x00004554
		protected override bool OnTryUpgradeInstance(object oldInstance, object newInstance, bool createdElsewhere)
		{
			return true;
		}

		// Token: 0x0400003B RID: 59
		internal readonly Dictionary<Type, bool> AllFieldsSkippableCache = new Dictionary<Type, bool>();

		// Token: 0x0400003C RID: 60
		private RootUpgraderGroup RootUpgraderGroup;

		// Token: 0x0400003D RID: 61
		private ReferenceTypeUpgraderGroup ReferenceTypeUpgraderGroup;

		// Token: 0x0400003E RID: 62
		private SkipUpgrader SkipUpgrader;

		// Token: 0x0400003F RID: 63
		private readonly List<Type> SkippedTypeList = new List<Type>();
	}
}
