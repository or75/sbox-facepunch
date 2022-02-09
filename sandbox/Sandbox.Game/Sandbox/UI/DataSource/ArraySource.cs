using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Sandbox.UI.DataSource
{
	/// <summary>
	/// Bind a panel property to an object property ([Target].[TargetProperty])
	/// </summary>
	// Token: 0x02000156 RID: 342
	public class ArraySource : BaseDataSource
	{
		// Token: 0x060019B0 RID: 6576 RVA: 0x0006BEE8 File Offset: 0x0006A0E8
		public ArraySource(string property, object target, int targetIndex)
			: base(property)
		{
			this.Target = target;
			this.TargetIndex = targetIndex;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("#");
			defaultInterpolatedStringHandler.AppendFormatted<int>(targetIndex);
			base.DebugName = defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x060019B1 RID: 6577 RVA: 0x0006BF34 File Offset: 0x0006A134
		// (set) Token: 0x060019B2 RID: 6578 RVA: 0x0006BF7C File Offset: 0x0006A17C
		public override object Value
		{
			get
			{
				IList list = this.Target as IList;
				if (list == null)
				{
					return null;
				}
				if (this.TargetIndex < 0)
				{
					return null;
				}
				if (this.TargetIndex >= list.Count)
				{
					return null;
				}
				return list[this.TargetIndex];
			}
			set
			{
				IList list = this.Target as IList;
				if (list != null)
				{
					list[this.TargetIndex] = value;
				}
			}
		}

		/// <summary>
		/// The target object to find the property
		/// </summary>
		// Token: 0x04000723 RID: 1827
		public object Target;

		/// <summary>
		/// Target index
		/// </summary>
		// Token: 0x04000724 RID: 1828
		public int TargetIndex;
	}
}
