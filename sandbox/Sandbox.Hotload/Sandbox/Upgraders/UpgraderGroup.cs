using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Sandbox.Upgraders
{
	/// <summary>
	/// Used to organize <see cref="T:Sandbox.Hotload.IInstanceUpgrader" />s into groups that update
	/// in a particular order. Use <see cref="T:Sandbox.Upgraders.UpgraderGroupAttribute" /> to specify which group an
	/// upgrader should be added to.
	/// </summary>
	// Token: 0x02000024 RID: 36
	public abstract class UpgraderGroup : Hotload.IInstanceUpgrader
	{
		// Token: 0x060000ED RID: 237 RVA: 0x000063D4 File Offset: 0x000045D4
		private static void AssertIsUpgraderGroupType(Type type, Type usedByType)
		{
			if (!typeof(UpgraderGroup).IsAssignableFrom(type))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 3);
				defaultInterpolatedStringHandler.AppendLiteral("Type ");
				defaultInterpolatedStringHandler.AppendFormatted(type.FullName);
				defaultInterpolatedStringHandler.AppendLiteral(" was used in an ");
				defaultInterpolatedStringHandler.AppendFormatted("UpgraderGroupAttribute");
				defaultInterpolatedStringHandler.AppendLiteral(" by ");
				defaultInterpolatedStringHandler.AppendFormatted(usedByType.FullName);
				defaultInterpolatedStringHandler.AppendLiteral(", ");
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear() + "but does not extend UpgraderGroup.");
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000646C File Offset: 0x0000466C
		internal static Type GetUpgraderGroupType(Type upgraderType)
		{
			UpgraderGroupAttribute attrib = upgraderType.GetCustomAttribute(true);
			if (attrib == null)
			{
				return null;
			}
			UpgraderGroup.AssertIsUpgraderGroupType(attrib.UpgraderGroupType, upgraderType);
			return attrib.UpgraderGroupType;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00006498 File Offset: 0x00004698
		private static Type[] GetUpgraderGroupPath(Type upgraderType)
		{
			List<Type> groupPath = new List<Type>();
			for (;;)
			{
				upgraderType = UpgraderGroup.GetUpgraderGroupType(upgraderType);
				if (upgraderType == null)
				{
					goto IL_7D;
				}
				if (groupPath.Contains(upgraderType))
				{
					break;
				}
				groupPath.Add(upgraderType);
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Found a loop in ");
			defaultInterpolatedStringHandler.AppendFormatted("UpgraderGroupAttribute");
			defaultInterpolatedStringHandler.AppendLiteral("s involving ");
			defaultInterpolatedStringHandler.AppendFormatted(upgraderType.FullName);
			defaultInterpolatedStringHandler.AppendLiteral(".");
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			IL_7D:
			groupPath.Reverse();
			return groupPath.ToArray();
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00006530 File Offset: 0x00004730
		public void AddUpgrader(Hotload.IInstanceUpgrader upgrader)
		{
			if (upgrader == null)
			{
				throw new ArgumentNullException("upgrader");
			}
			Type[] groupPath = UpgraderGroup.GetUpgraderGroupPath(upgrader.GetType());
			if (groupPath.Length == 0)
			{
				this.AddUpgraderHere(upgrader);
				return;
			}
			int thisIndex = Array.IndexOf<Type>(groupPath, base.GetType());
			if (thisIndex == -1)
			{
				string str = "Attempted to add an upgrader of type ";
				string fullName = upgrader.GetType().FullName;
				string str2 = " ";
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 2);
				defaultInterpolatedStringHandler.AppendLiteral("to a group of type ");
				defaultInterpolatedStringHandler.AppendFormatted(base.GetType().FullName);
				defaultInterpolatedStringHandler.AppendLiteral(", violating its ");
				defaultInterpolatedStringHandler.AppendFormatted("UpgraderGroupAttribute");
				defaultInterpolatedStringHandler.AppendLiteral(".");
				throw new Exception(str + fullName + str2 + defaultInterpolatedStringHandler.ToStringAndClear());
			}
			this.AddUpgrader(upgrader, groupPath, thisIndex + 1);
		}

		/// <summary>
		/// Works out which child group to add the given upgrader to, or whether to add it to this group.
		/// </summary>
		// Token: 0x060000F1 RID: 241 RVA: 0x000065F4 File Offset: 0x000047F4
		protected void AddUpgrader(Hotload.IInstanceUpgrader upgrader, Type[] groupPath, int groupPathIndex)
		{
			if (groupPathIndex >= groupPath.Length)
			{
				this.AddUpgraderHere(upgrader);
				return;
			}
			Type childGroupType = groupPath[groupPathIndex];
			UpgraderGroup matchingGroup = null;
			foreach (Hotload.IInstanceUpgrader instanceUpgrader in this.ChildUpgraders)
			{
				if (instanceUpgrader.GetType() == childGroupType)
				{
					UpgraderGroup group = instanceUpgrader as UpgraderGroup;
					if (group != null)
					{
						if (matchingGroup != null)
						{
							throw new Exception(string.Concat(new string[]
							{
								"Attempted to add an upgrader of type ",
								upgrader.GetType().FullName,
								" to a group of type ",
								groupPath.Last<Type>().FullName,
								", but multiple instances of that group type exist."
							}));
						}
						matchingGroup = group;
					}
				}
			}
			if (matchingGroup == null)
			{
				throw new Exception(string.Concat(new string[]
				{
					"Attempted to add an upgrader of type ",
					upgrader.GetType().FullName,
					" to a group of type ",
					groupPath.Last<Type>().FullName,
					", but such a group hasn't been added yet."
				}));
			}
			matchingGroup.AddUpgrader(upgrader, groupPath, groupPathIndex + 1);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000670C File Offset: 0x0000490C
		private void AddUpgraderHere(Hotload.IInstanceUpgrader upgrader)
		{
			this.UpgraderCache.Clear();
			this.UpgraderOrderDirty = true;
			this.ChildUpgraders.Add(upgrader);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000672C File Offset: 0x0000492C
		private static void ThrowImpossibleOrdering(Type a, Type b)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(66, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Unable to find a valid ordering between instance upgraders ");
			defaultInterpolatedStringHandler.AppendFormatted(a.FullName);
			defaultInterpolatedStringHandler.AppendLiteral(" and ");
			defaultInterpolatedStringHandler.AppendFormatted(b.FullName);
			defaultInterpolatedStringHandler.AppendLiteral(". ");
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear() + "Please check their AttemptBeforeAttributes and AttemptAfterAttributes, and the GroupOrder value for each of their UpgraderGroupAttributes.");
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00006798 File Offset: 0x00004998
		private void SortUpgraders()
		{
			if (!this.UpgraderOrderDirty)
			{
				return;
			}
			this.UpgraderOrderDirty = false;
			UpgraderGroup.SortInfo[] sortInfos = this.ChildUpgraders.Select((Hotload.IInstanceUpgrader x, int i) => new UpgraderGroup.SortInfo(x, i)).ToArray<UpgraderGroup.SortInfo>();
			SortingHelper sortingHelper = new SortingHelper(this.ChildUpgraders.Count);
			Func<Type, IEnumerable<UpgraderGroup.SortInfo>> <>9__1;
			Func<Type, IEnumerable<UpgraderGroup.SortInfo>> <>9__3;
			foreach (UpgraderGroup.SortInfo sortInfo in sortInfos)
			{
				IEnumerable<Type> attemptBefore = sortInfo.AttemptBefore;
				Func<Type, IEnumerable<UpgraderGroup.SortInfo>> selector;
				if ((selector = <>9__1) == null)
				{
					selector = (<>9__1 = (Type x) => sortInfos.Where((UpgraderGroup.SortInfo y) => y.Type == x));
				}
				foreach (UpgraderGroup.SortInfo otherInfo in attemptBefore.SelectMany(selector))
				{
					sortingHelper.AddConstraint(sortInfo.Index, otherInfo.Index);
				}
				IEnumerable<Type> attemptAfter = sortInfo.AttemptAfter;
				Func<Type, IEnumerable<UpgraderGroup.SortInfo>> selector2;
				if ((selector2 = <>9__3) == null)
				{
					selector2 = (<>9__3 = (Type x) => sortInfos.Where((UpgraderGroup.SortInfo y) => y.Type == x));
				}
				foreach (UpgraderGroup.SortInfo otherInfo2 in attemptAfter.SelectMany(selector2))
				{
					sortingHelper.AddConstraint(otherInfo2.Index, sortInfo.Index);
				}
				GroupOrder groupOrder = sortInfo.GroupOrder;
				if (groupOrder != GroupOrder.First)
				{
					if (groupOrder == GroupOrder.Last)
					{
						sortingHelper.AddLast(sortInfo.Index);
					}
				}
				else
				{
					sortingHelper.AddFirst(sortInfo.Index);
				}
			}
			SortingHelper.SortConstraint invalidConstraint;
			if (sortingHelper.Sort(this.ChildUpgraderOrder, out invalidConstraint))
			{
				return;
			}
			if (invalidConstraint.IsZero)
			{
				throw new Exception("Unable to find a valid ordering for upgraders added to " + base.GetType().FullName + ".");
			}
			UpgraderGroup.ThrowImpossibleOrdering(sortInfos[invalidConstraint.EarlierIndex].Type, sortInfos[invalidConstraint.LaterIndex].Type);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x000069B8 File Offset: 0x00004BB8
		internal void SetUpgradersForType(Type type, params Hotload.IInstanceUpgrader[] upgraders)
		{
			if (!this.UpgraderCache.TryAdd(type, upgraders))
			{
				this.UpgraderCache[type] = upgraders;
			}
		}

		/// <summary>
		/// Returns a flat array of upgraders that can process the given type, in
		/// order of precedence. This array won't contain <see cref="T:Sandbox.Upgraders.UpgraderGroup" />s,
		/// but it will contain upgraders found within those groups.
		/// </summary>
		/// <param name="type">Type to find upgraders for.</param>
		// Token: 0x060000F6 RID: 246 RVA: 0x000069D8 File Offset: 0x00004BD8
		internal Hotload.IInstanceUpgrader[] GetUpgradersForType(Type type)
		{
			Hotload.IInstanceUpgrader[] cached;
			if (this.UpgraderCache.TryGetValue(type, out cached))
			{
				return cached;
			}
			this.SortUpgraders();
			List<Hotload.IInstanceUpgrader> upgraders = null;
			foreach (int upgraderIndex in this.ChildUpgraderOrder)
			{
				Hotload.IInstanceUpgrader upgrader = this.ChildUpgraders[upgraderIndex];
				if (upgrader.ShouldProcessType(type))
				{
					if (upgraders == null)
					{
						upgraders = new List<Hotload.IInstanceUpgrader>();
					}
					UpgraderGroup childGroup = upgrader as UpgraderGroup;
					if (childGroup != null)
					{
						upgraders.AddRange(childGroup.GetUpgradersForType(type));
					}
					else
					{
						upgraders.Add(upgrader);
					}
				}
			}
			if (this.UpgraderCache.TryGetValue(type, out cached))
			{
				return cached;
			}
			if (upgraders != null)
			{
				cached = upgraders.ToArray();
				this.UpgraderCache.Add(type, cached);
				return cached;
			}
			return Array.Empty<Hotload.IInstanceUpgrader>();
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x00006AB4 File Offset: 0x00004CB4
		// (set) Token: 0x060000F8 RID: 248 RVA: 0x00006ABC File Offset: 0x00004CBC
		public bool IsInitialized { get; private set; }

		// Token: 0x060000F9 RID: 249 RVA: 0x00006AC5 File Offset: 0x00004CC5
		public void Initialize(Hotload hotload)
		{
			this.IsInitialized = true;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00006AD0 File Offset: 0x00004CD0
		public void HotloadStart()
		{
			this.SortUpgraders();
			foreach (int upgraderIndex in this.ChildUpgraderOrder)
			{
				this.ChildUpgraders[upgraderIndex].HotloadStart();
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00006B34 File Offset: 0x00004D34
		public void HotloadComplete()
		{
			this.SortUpgraders();
			foreach (int upgraderIndex in this.ChildUpgraderOrder)
			{
				this.ChildUpgraders[upgraderIndex].HotloadComplete();
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00006B98 File Offset: 0x00004D98
		public void ClearCache()
		{
			this.SortUpgraders();
			foreach (int upgraderIndex in this.ChildUpgraderOrder)
			{
				this.ChildUpgraders[upgraderIndex].ClearCache();
			}
			this.UpgraderCache.Clear();
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00006C08 File Offset: 0x00004E08
		public virtual bool ShouldProcessType(Type type)
		{
			return this.GetUpgradersForType(type).Length != 0;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00006C18 File Offset: 0x00004E18
		public bool TryCreateNewInstance(object oldInstance, object context, out object newInstance)
		{
			Hotload.IInstanceUpgrader[] upgradersForType = this.GetUpgradersForType(oldInstance.GetType());
			for (int i = 0; i < upgradersForType.Length; i++)
			{
				if (upgradersForType[i].TryCreateNewInstance(oldInstance, context, out newInstance))
				{
					return true;
				}
			}
			newInstance = null;
			return false;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00006C54 File Offset: 0x00004E54
		public bool TryUpgradeInstance(object oldInstance, object newInstance)
		{
			Hotload.IInstanceUpgrader[] upgradersForType = this.GetUpgradersForType(oldInstance.GetType());
			for (int i = 0; i < upgradersForType.Length; i++)
			{
				if (upgradersForType[i].TryUpgradeInstance(oldInstance, newInstance))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// A list of <see cref="T:Sandbox.Hotload.IInstanceUpgrader" />s added to this group, where this group is their immediate parent.
		/// </summary>
		// Token: 0x04000048 RID: 72
		private readonly List<Hotload.IInstanceUpgrader> ChildUpgraders = new List<Hotload.IInstanceUpgrader>();

		/// <summary>
		/// Indices into <see cref="F:Sandbox.Upgraders.UpgraderGroup.ChildUpgraders" />, sorted by <see cref="M:Sandbox.Upgraders.UpgraderGroup.SortUpgraders" />.
		/// </summary>
		// Token: 0x04000049 RID: 73
		private readonly List<int> ChildUpgraderOrder = new List<int>();

		/// <summary>
		/// For each <see cref="T:System.Type" />, caches which <see cref="T:Sandbox.Hotload.IInstanceUpgrader" />s should attempt to process
		/// instances of that type, as given by <see cref="M:Sandbox.Hotload.IInstanceUpgrader.ShouldProcessType(System.Type)" />.
		/// </summary>
		// Token: 0x0400004A RID: 74
		private readonly Dictionary<Type, Hotload.IInstanceUpgrader[]> UpgraderCache = new Dictionary<Type, Hotload.IInstanceUpgrader[]>();

		/// <summary>
		/// Should <see cref="F:Sandbox.Upgraders.UpgraderGroup.ChildUpgraders" /> be sorted?
		/// </summary>
		// Token: 0x0400004B RID: 75
		private bool UpgraderOrderDirty;

		// Token: 0x02000044 RID: 68
		private struct SortInfo : IEquatable<UpgraderGroup.SortInfo>
		{
			// Token: 0x1700002C RID: 44
			// (get) Token: 0x0600018B RID: 395 RVA: 0x00007AF1 File Offset: 0x00005CF1
			public GroupOrder GroupOrder
			{
				get
				{
					UpgraderGroupAttribute customAttribute = this.Type.GetCustomAttribute<UpgraderGroupAttribute>();
					if (customAttribute == null)
					{
						return GroupOrder.Default;
					}
					return customAttribute.GroupOrder;
				}
			}

			// Token: 0x1700002D RID: 45
			// (get) Token: 0x0600018C RID: 396 RVA: 0x00007B0C File Offset: 0x00005D0C
			public IEnumerable<Type> AttemptBefore
			{
				get
				{
					AttemptBeforeAttribute customAttribute = this.Type.GetCustomAttribute<AttemptBeforeAttribute>();
					IEnumerable<Type> enumerable = ((customAttribute != null) ? customAttribute.InstanceUpgraderTypes : null);
					return enumerable ?? Enumerable.Empty<Type>();
				}
			}

			// Token: 0x1700002E RID: 46
			// (get) Token: 0x0600018D RID: 397 RVA: 0x00007B3C File Offset: 0x00005D3C
			public IEnumerable<Type> AttemptAfter
			{
				get
				{
					AttemptAfterAttribute customAttribute = this.Type.GetCustomAttribute<AttemptAfterAttribute>();
					IEnumerable<Type> enumerable = ((customAttribute != null) ? customAttribute.InstanceUpgraderTypes : null);
					return enumerable ?? Enumerable.Empty<Type>();
				}
			}

			// Token: 0x0600018E RID: 398 RVA: 0x00007B6B File Offset: 0x00005D6B
			public SortInfo(Hotload.IInstanceUpgrader upgrader, int index)
			{
				this.Index = index;
				this.Type = upgrader.GetType();
			}

			// Token: 0x0600018F RID: 399 RVA: 0x00007B80 File Offset: 0x00005D80
			public bool Equals(UpgraderGroup.SortInfo other)
			{
				return this.Index == other.Index;
			}

			// Token: 0x06000190 RID: 400 RVA: 0x00007B90 File Offset: 0x00005D90
			public override bool Equals(object obj)
			{
				if (obj is UpgraderGroup.SortInfo)
				{
					UpgraderGroup.SortInfo other = (UpgraderGroup.SortInfo)obj;
					return this.Equals(other);
				}
				return false;
			}

			// Token: 0x06000191 RID: 401 RVA: 0x00007BB5 File Offset: 0x00005DB5
			public override int GetHashCode()
			{
				return this.Index;
			}

			// Token: 0x0400009E RID: 158
			public readonly int Index;

			// Token: 0x0400009F RID: 159
			public readonly Type Type;
		}
	}
}
