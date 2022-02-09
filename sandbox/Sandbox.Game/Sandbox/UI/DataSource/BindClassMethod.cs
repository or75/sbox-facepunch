using System;

namespace Sandbox.UI.DataSource
{
	/// <summary>
	/// Bind a panel property to a method
	/// </summary>
	// Token: 0x02000158 RID: 344
	internal class BindClassMethod : BaseDataSource
	{
		// Token: 0x060019BD RID: 6589 RVA: 0x0006C0ED File Offset: 0x0006A2ED
		public BindClassMethod(string property, Func<bool> targetproperty)
			: base(property)
		{
			this.TargetMethod = targetproperty;
			base.DebugName = property;
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x060019BE RID: 6590 RVA: 0x0006C104 File Offset: 0x0006A304
		// (set) Token: 0x060019BF RID: 6591 RVA: 0x0006C13C File Offset: 0x0006A33C
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

		// Token: 0x060019C0 RID: 6592 RVA: 0x0006C140 File Offset: 0x0006A340
		protected override void SetValue(Panel source, object val)
		{
			if (val is bool)
			{
				bool b = (bool)val;
				source.SetClass(base.PropertyName, b);
			}
			string s = val as string;
			if (s != null)
			{
				source.SetClass(base.PropertyName, s.ToBool());
			}
		}

		/// <summary>
		/// The target object to find the property
		/// </summary>
		// Token: 0x0400072A RID: 1834
		public object Target;

		/// <summary>
		/// Method to get the value
		/// </summary>
		// Token: 0x0400072B RID: 1835
		public Func<bool> TargetMethod;
	}
}
