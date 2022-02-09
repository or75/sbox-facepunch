using System;
using System.Reflection;

namespace Sandbox.UI.DataSource
{
	/// <summary>
	/// Bind a panel property to an object's property
	/// </summary>
	// Token: 0x0200015B RID: 347
	public class Property : BaseDataSource
	{
		// Token: 0x060019C9 RID: 6601 RVA: 0x0006C3A0 File Offset: 0x0006A5A0
		public Property(string property, object target, PropertyInfo targetproperty)
			: base(property)
		{
			this.Target = target;
			this.TargetProperty = targetproperty;
			base.DebugName = targetproperty.Name;
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x060019CA RID: 6602 RVA: 0x0006C3C4 File Offset: 0x0006A5C4
		// (set) Token: 0x060019CB RID: 6603 RVA: 0x0006C404 File Offset: 0x0006A604
		public override object Value
		{
			get
			{
				object result;
				try
				{
					PropertyInfo targetProperty = this.TargetProperty;
					result = ((targetProperty != null) ? targetProperty.GetValue(this.Target) : null);
				}
				catch (Exception)
				{
					result = null;
				}
				return result;
			}
			set
			{
				if (value.GetType() == this.TargetProperty.PropertyType)
				{
					PropertyInfo targetProperty = this.TargetProperty;
					if (targetProperty == null)
					{
						return;
					}
					targetProperty.SetValue(this.Target, value);
					return;
				}
				else if (this.TargetProperty.PropertyType.IsEnum)
				{
					string stringValue = value as string;
					object result;
					if (stringValue != null && Enum.TryParse(this.TargetProperty.PropertyType, stringValue, true, out result))
					{
						PropertyInfo targetProperty2 = this.TargetProperty;
						if (targetProperty2 == null)
						{
							return;
						}
						targetProperty2.SetValue(this.Target, result);
						return;
					}
					else
					{
						PropertyInfo targetProperty3 = this.TargetProperty;
						if (targetProperty3 == null)
						{
							return;
						}
						targetProperty3.SetValue(this.Target, Enum.ToObject(this.TargetProperty.PropertyType, this.Value));
						return;
					}
				}
				else
				{
					object converted = Convert.ChangeType(value, this.TargetProperty.PropertyType);
					PropertyInfo targetProperty4 = this.TargetProperty;
					if (targetProperty4 == null)
					{
						return;
					}
					targetProperty4.SetValue(this.Target, converted);
					return;
				}
			}
		}

		/// <summary>
		/// The target object to find the property
		/// </summary>
		// Token: 0x04000730 RID: 1840
		public object Target;

		/// <summary>
		/// Target source, ie "PlayerName"
		/// </summary>
		// Token: 0x04000731 RID: 1841
		public PropertyInfo TargetProperty;
	}
}
