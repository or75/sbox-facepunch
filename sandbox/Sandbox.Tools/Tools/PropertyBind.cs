using System;
using System.Reflection;

namespace Tools
{
	// Token: 0x020000D5 RID: 213
	public class PropertyBind : DataBind
	{
		// Token: 0x060017BD RID: 6077 RVA: 0x0005B93C File Offset: 0x00059B3C
		public PropertyBind(object targetObject, PropertyInfo property)
		{
			this.Target = targetObject;
			this.Property = property;
		}

		// Token: 0x060017BE RID: 6078 RVA: 0x0005B952 File Offset: 0x00059B52
		public override object GetValue()
		{
			return this.Property.GetValue(this.Target);
		}

		// Token: 0x060017BF RID: 6079 RVA: 0x0005B965 File Offset: 0x00059B65
		public override Type GetTargetType()
		{
			return this.Property.PropertyType;
		}

		// Token: 0x060017C0 RID: 6080 RVA: 0x0005B972 File Offset: 0x00059B72
		public override bool IsWritable()
		{
			return this.Property.SetMethod != null;
		}

		// Token: 0x060017C1 RID: 6081 RVA: 0x0005B985 File Offset: 0x00059B85
		protected override void SetDataValue(object value)
		{
			if (this.Property.SetMethod == null)
			{
				return;
			}
			this.Property.SetValue(this.Target, value);
		}

		// Token: 0x040004DF RID: 1247
		public object Target;

		// Token: 0x040004E0 RID: 1248
		public PropertyInfo Property;
	}
}
