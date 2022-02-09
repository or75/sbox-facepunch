using System;

namespace Sandbox.Internal
{
	/// <summary>
	/// Sometimes with CodeGen we want reflection to be able to get the original initial value
	/// of a property (which is set with {get;set;} = initialvalue;). For this reason sometimes
	/// we'll drop this attribute on that property.
	/// </summary>
	// Token: 0x0200006C RID: 108
	public sealed class DefaultValueAttribute : Attribute
	{
		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x000216BA File Offset: 0x0001F8BA
		// (set) Token: 0x060004AE RID: 1198 RVA: 0x000216C2 File Offset: 0x0001F8C2
		public object Value { get; internal set; }

		// Token: 0x060004AF RID: 1199 RVA: 0x000216CB File Offset: 0x0001F8CB
		public DefaultValueAttribute(object value)
		{
			this.Value = value;
		}
	}
}
