using System;

namespace Sandbox.UI.DataSource
{
	/// <summary>
	/// Bind a panel property to a method
	/// </summary>
	// Token: 0x02000159 RID: 345
	internal class BindMethod : BaseDataSource
	{
		// Token: 0x060019C1 RID: 6593 RVA: 0x0006C185 File Offset: 0x0006A385
		public BindMethod(string property, Func<object> targetproperty)
			: base(property)
		{
			this.TargetMethod = targetproperty;
			base.DebugName = property;
		}

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x060019C2 RID: 6594 RVA: 0x0006C19C File Offset: 0x0006A39C
		// (set) Token: 0x060019C3 RID: 6595 RVA: 0x0006C1D0 File Offset: 0x0006A3D0
		public override object Value
		{
			get
			{
				object result;
				try
				{
					result = this.TargetMethod();
				}
				catch (Exception)
				{
					result = null;
				}
				return result;
			}
			set
			{
			}
		}

		/// <summary>
		/// The target object to find the property
		/// </summary>
		// Token: 0x0400072C RID: 1836
		public object Target;

		/// <summary>
		/// Method to get the value
		/// </summary>
		// Token: 0x0400072D RID: 1837
		public Func<object> TargetMethod;
	}
}
