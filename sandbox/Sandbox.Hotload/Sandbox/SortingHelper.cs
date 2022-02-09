using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox
{
	/// <summary>
	/// Generate an ordering based on a set of first-most and last-most items, and
	/// individual constraints between pairs of items. All first-most items will be
	/// ordered before all last-most items, and any other items will be put in the
	/// middle unless forced to be elsewhere by a constraint.
	/// </summary>
	// Token: 0x0200000E RID: 14
	internal class SortingHelper
	{
		// Token: 0x06000077 RID: 119 RVA: 0x00004307 File Offset: 0x00002507
		public SortingHelper(int itemCount)
		{
			this._itemCount = itemCount;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00004337 File Offset: 0x00002537
		public void AddConstraint(int earlierIndex, int laterIndex)
		{
			this._initialConstraints.Add(new SortingHelper.SortConstraint(earlierIndex, laterIndex));
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000434C File Offset: 0x0000254C
		public void AddFirst(int earlierIndex)
		{
			this._first.Add(earlierIndex);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000435B File Offset: 0x0000255B
		public void AddLast(int laterIndex)
		{
			this._last.Add(laterIndex);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000436C File Offset: 0x0000256C
		public bool Sort(List<int> result, out SortingHelper.SortConstraint invalidConstraint)
		{
			SortingHelper.<>c__DisplayClass9_0 CS$<>8__locals1 = new SortingHelper.<>c__DisplayClass9_0();
			CS$<>8__locals1.<>4__this = this;
			HashSet<int> middle = new HashSet<int>();
			for (int index = 0; index < this._itemCount; index++)
			{
				if (!this._first.Contains(index) && !this._last.Contains(index))
				{
					middle.Add(index);
				}
			}
			CS$<>8__locals1.allConstraints = new HashSet<SortingHelper.SortConstraint>();
			CS$<>8__locals1.newConstraints = new Queue<SortingHelper.SortConstraint>();
			CS$<>8__locals1.beforeDict = new Dictionary<int, HashSet<int>>();
			CS$<>8__locals1.afterDict = new Dictionary<int, HashSet<int>>();
			foreach (int earlierIndex in this._first)
			{
				foreach (int laterIndex in this._last)
				{
					if (!CS$<>8__locals1.<Sort>g__AddWorkingConstraint|0(earlierIndex, laterIndex, out invalidConstraint))
					{
						return false;
					}
				}
			}
			SortingHelper.SortConstraint nextConstraint;
			while (CS$<>8__locals1.newConstraints.TryDequeue(out nextConstraint))
			{
				HashSet<int> before;
				if (CS$<>8__locals1.beforeDict.TryGetValue(nextConstraint.LaterIndex, out before))
				{
					foreach (int laterIndex2 in before)
					{
						if (!CS$<>8__locals1.<Sort>g__AddWorkingConstraint|0(nextConstraint.EarlierIndex, laterIndex2, out invalidConstraint))
						{
							return false;
						}
					}
				}
				HashSet<int> after;
				if (CS$<>8__locals1.afterDict.TryGetValue(nextConstraint.EarlierIndex, out after))
				{
					using (HashSet<int>.Enumerator enumerator = after.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							int earlierIndex2 = enumerator.Current;
							if (!CS$<>8__locals1.<Sort>g__AddWorkingConstraint|0(earlierIndex2, nextConstraint.LaterIndex, out invalidConstraint))
							{
								return false;
							}
						}
						continue;
					}
					break;
				}
			}
			foreach (int middleIndex in middle)
			{
				HashSet<int> before2;
				bool flag;
				if (CS$<>8__locals1.beforeDict.TryGetValue(middleIndex, out before2))
				{
					IEnumerable<int> source = before2;
					Func<int, bool> predicate;
					if ((predicate = CS$<>8__locals1.<>9__1) == null)
					{
						predicate = (CS$<>8__locals1.<>9__1 = (int x) => CS$<>8__locals1.<>4__this._first.Contains(x));
					}
					flag = source.Any(predicate);
				}
				else
				{
					flag = false;
				}
				HashSet<int> after2;
				bool flag2;
				if (CS$<>8__locals1.afterDict.TryGetValue(middleIndex, out after2))
				{
					IEnumerable<int> source2 = after2;
					Func<int, bool> predicate2;
					if ((predicate2 = CS$<>8__locals1.<>9__2) == null)
					{
						predicate2 = (CS$<>8__locals1.<>9__2 = (int x) => CS$<>8__locals1.<>4__this._last.Contains(x));
					}
					flag2 = source2.Any(predicate2);
				}
				else
				{
					flag2 = false;
				}
				bool isAfterAnyLast = flag2;
				if (!flag)
				{
					foreach (int earlierIndex3 in this._first)
					{
						CS$<>8__locals1.<Sort>g__AddWorkingConstraint|0(earlierIndex3, middleIndex, out invalidConstraint);
					}
				}
				if (!isAfterAnyLast)
				{
					foreach (int laterIndex3 in this._last)
					{
						CS$<>8__locals1.<Sort>g__AddWorkingConstraint|0(middleIndex, laterIndex3, out invalidConstraint);
					}
				}
			}
			Queue<int> earliestRemaining = new Queue<int>();
			for (int index2 = 0; index2 < this._itemCount; index2++)
			{
				if (!CS$<>8__locals1.afterDict.ContainsKey(index2))
				{
					earliestRemaining.Enqueue(index2);
				}
			}
			result.Clear();
			int nextIndex;
			while (earliestRemaining.TryDequeue(out nextIndex))
			{
				result.Add(nextIndex);
				HashSet<int> laterIndices;
				IEnumerable<int> enumerable;
				if (!CS$<>8__locals1.beforeDict.TryGetValue(nextIndex, out laterIndices))
				{
					enumerable = Enumerable.Empty<int>();
				}
				else
				{
					IEnumerable<int> enumerable2 = laterIndices;
					enumerable = enumerable2;
				}
				using (IEnumerator<int> enumerator3 = enumerable.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						int laterIndex4 = enumerator3.Current;
						HashSet<int> hashSet = CS$<>8__locals1.afterDict[laterIndex4];
						hashSet.Remove(nextIndex);
						if (hashSet.Count == 0)
						{
							earliestRemaining.Enqueue(laterIndex4);
						}
					}
					continue;
				}
				break;
			}
			invalidConstraint = default(SortingHelper.SortConstraint);
			return result.Count == this._itemCount;
		}

		// Token: 0x04000029 RID: 41
		private readonly int _itemCount;

		// Token: 0x0400002A RID: 42
		private readonly HashSet<SortingHelper.SortConstraint> _initialConstraints = new HashSet<SortingHelper.SortConstraint>();

		// Token: 0x0400002B RID: 43
		private readonly HashSet<int> _first = new HashSet<int>();

		// Token: 0x0400002C RID: 44
		private readonly HashSet<int> _last = new HashSet<int>();

		// Token: 0x0200003F RID: 63
		public struct SortConstraint : IEquatable<SortingHelper.SortConstraint>
		{
			// Token: 0x17000028 RID: 40
			// (get) Token: 0x06000172 RID: 370 RVA: 0x0000763A File Offset: 0x0000583A
			public bool IsZero
			{
				get
				{
					return this.EarlierIndex == 0 && this.LaterIndex == 0;
				}
			}

			// Token: 0x17000029 RID: 41
			// (get) Token: 0x06000173 RID: 371 RVA: 0x0000764F File Offset: 0x0000584F
			public SortingHelper.SortConstraint Complement
			{
				get
				{
					return new SortingHelper.SortConstraint(this.LaterIndex, this.EarlierIndex);
				}
			}

			// Token: 0x06000174 RID: 372 RVA: 0x00007662 File Offset: 0x00005862
			public SortConstraint(int earlierIndex, int laterIndex)
			{
				this.EarlierIndex = earlierIndex;
				this.LaterIndex = laterIndex;
				this._hashCode = (this.EarlierIndex * 397) ^ this.LaterIndex;
			}

			// Token: 0x06000175 RID: 373 RVA: 0x0000768B File Offset: 0x0000588B
			public bool Equals(SortingHelper.SortConstraint other)
			{
				return this.EarlierIndex == other.EarlierIndex && this.LaterIndex == other.LaterIndex;
			}

			// Token: 0x06000176 RID: 374 RVA: 0x000076AC File Offset: 0x000058AC
			public override bool Equals(object obj)
			{
				if (obj is SortingHelper.SortConstraint)
				{
					SortingHelper.SortConstraint other = (SortingHelper.SortConstraint)obj;
					return this.Equals(other);
				}
				return false;
			}

			// Token: 0x06000177 RID: 375 RVA: 0x000076D1 File Offset: 0x000058D1
			public override int GetHashCode()
			{
				return this._hashCode;
			}

			// Token: 0x04000080 RID: 128
			public readonly int EarlierIndex;

			// Token: 0x04000081 RID: 129
			public readonly int LaterIndex;

			// Token: 0x04000082 RID: 130
			private readonly int _hashCode;
		}
	}
}
