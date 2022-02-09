using System;
using System.Collections.Generic;

namespace Sandbox.UI
{
	// Token: 0x02000137 RID: 311
	[Hotload.SkipAttribute]
	public sealed class ShadowList : List<Shadow>
	{
		// Token: 0x06001886 RID: 6278 RVA: 0x000644B5 File Offset: 0x000626B5
		public void AddFrom(ShadowList other)
		{
			if (!other.IsNone && other.Count == 0)
			{
				return;
			}
			base.Clear();
			if (other.IsNone)
			{
				return;
			}
			base.AddRange(other);
		}

		// Token: 0x06001887 RID: 6279 RVA: 0x000644E0 File Offset: 0x000626E0
		public void SetFromLerp(ShadowList a, ShadowList b, float lerp)
		{
			if (a == b)
			{
				throw new Exception();
			}
			int incomingCount = Math.Max(a.Count, b.Count);
			if (base.Count != incomingCount)
			{
				base.Clear();
				for (int i = 0; i < incomingCount; i++)
				{
					base.Add(default(Shadow));
				}
			}
			for (int j = 0; j < incomingCount; j++)
			{
				Shadow shadow_a = a.Get(j);
				Shadow shadow_b = b.Get(j);
				base[j] = shadow_a.LerpTo(shadow_b, lerp);
			}
		}

		// Token: 0x06001888 RID: 6280 RVA: 0x00064564 File Offset: 0x00062764
		private Shadow Get(int i)
		{
			if (i >= base.Count)
			{
				return default(Shadow);
			}
			return base[i];
		}

		// Token: 0x06001889 RID: 6281 RVA: 0x0006458B File Offset: 0x0006278B
		internal ShadowList MakeCopy()
		{
			ShadowList shadowList = new ShadowList();
			shadowList.IsNone = this.IsNone;
			shadowList.AddRange(this);
			return shadowList;
		}

		// Token: 0x0600188A RID: 6282 RVA: 0x000645A8 File Offset: 0x000627A8
		public override int GetHashCode()
		{
			int code = 0;
			foreach (Shadow e in this)
			{
				code = HashCode.Combine<int, Shadow>(code, e);
			}
			return code;
		}

		// Token: 0x04000678 RID: 1656
		public bool IsNone;
	}
}
