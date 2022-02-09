using System;

namespace Sandbox
{
	/// <summary>
	/// Combined with [Net], this will invoke a method clientside when the property changes. 
	/// If no name is provided, we will try to call On[PropertyName]Changed.
	/// </summary>
	// Token: 0x0200003C RID: 60
	[AttributeUsage(AttributeTargets.Property)]
	public class ChangeAttribute : Attribute
	{
		// Token: 0x06000300 RID: 768 RVA: 0x0000BB85 File Offset: 0x00009D85
		public ChangeAttribute(string name = null)
		{
			this.Name = name;
		}

		// Token: 0x040000AB RID: 171
		public string Name;
	}
}
