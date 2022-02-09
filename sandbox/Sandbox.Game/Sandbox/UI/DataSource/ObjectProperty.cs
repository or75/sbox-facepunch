using System;
using System.Collections;
using System.Reflection;

namespace Sandbox.UI.DataSource
{
	/// <summary>
	/// Bind a panel property to an object property ([Target].[TargetProperty])
	/// </summary>
	// Token: 0x0200015A RID: 346
	internal class ObjectProperty : BaseDataSource
	{
		// Token: 0x060019C4 RID: 6596 RVA: 0x0006C1D2 File Offset: 0x0006A3D2
		public ObjectProperty(string property, object target, string targetmembername)
			: base(property)
		{
			this.Target = target;
			this.TargetProperty = targetmembername;
			base.DebugName = targetmembername;
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x060019C5 RID: 6597 RVA: 0x0006C1F0 File Offset: 0x0006A3F0
		// (set) Token: 0x060019C6 RID: 6598 RVA: 0x0006C203 File Offset: 0x0006A403
		public override object Value
		{
			get
			{
				return ObjectProperty.GetPropertyValue(this.Target, this.TargetProperty);
			}
			set
			{
				ObjectProperty.SetPropertyValue(this.Target, this.TargetProperty, value, ref this.Hash);
			}
		}

		// Token: 0x060019C7 RID: 6599 RVA: 0x0006C220 File Offset: 0x0006A420
		public static object GetPropertyValue(object src, string propName)
		{
			if (src == null)
			{
				return null;
			}
			if (propName == null)
			{
				return null;
			}
			if (propName == "this")
			{
				return src;
			}
			IDictionary dict = src as IDictionary;
			if (dict != null)
			{
				try
				{
					return dict[propName];
				}
				catch (Exception)
				{
					return null;
				}
			}
			if (propName.Contains("."))
			{
				string[] temp = propName.Split(new char[] { '.' }, 2);
				return ObjectProperty.GetPropertyValue(ObjectProperty.GetPropertyValue(src, temp[0]), temp[1]);
			}
			object result;
			try
			{
				PropertyInfo prop = src.GetType().GetProperty(propName);
				result = ((prop != null) ? prop.GetValue(src, null) : null);
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060019C8 RID: 6600 RVA: 0x0006C2D8 File Offset: 0x0006A4D8
		public static void SetPropertyValue(object src, string propName, object value, ref int Hash)
		{
			if (src == null)
			{
				return;
			}
			if (propName == null)
			{
				return;
			}
			IDictionary dict = src as IDictionary;
			if (dict != null)
			{
				try
				{
					dict[propName] = value;
				}
				catch (Exception)
				{
					return;
				}
			}
			if (propName.Contains("."))
			{
				string[] temp = propName.Split(new char[] { '.' }, 2);
				ObjectProperty.SetPropertyValue(ObjectProperty.GetPropertyValue(src, temp[0]), temp[1], value, ref Hash);
				return;
			}
			PropertyInfo prop = src.GetType().GetProperty(propName);
			if (prop == null)
			{
				return;
			}
			Hash = value.GetHashCode();
			if (prop.PropertyType == value.GetType())
			{
				prop.SetValue(src, value);
				return;
			}
			prop.SetValue(src, Convert.ToString(value).ToType(prop.PropertyType));
		}

		/// <summary>
		/// The target object to find the property
		/// </summary>
		// Token: 0x0400072E RID: 1838
		public object Target;

		/// <summary>
		/// Target source, ie "PlayerName"
		/// </summary>
		// Token: 0x0400072F RID: 1839
		public string TargetProperty;
	}
}
