using System;

namespace Sandbox.Internal
{
	/// <summary>
	/// We want access to the comments. This gives us that. Don't add this manually, we'll automatically convert your
	/// comments into this.
	/// </summary>
	// Token: 0x0200006D RID: 109
	[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
	public sealed class DescriptionAttribute : Attribute
	{
		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060004B0 RID: 1200 RVA: 0x000216DA File Offset: 0x0001F8DA
		// (set) Token: 0x060004B1 RID: 1201 RVA: 0x000216E2 File Offset: 0x0001F8E2
		public string Value { get; internal set; }

		// Token: 0x060004B2 RID: 1202 RVA: 0x000216EB File Offset: 0x0001F8EB
		public DescriptionAttribute(string value)
		{
			this.Value = value;
		}
	}
}
