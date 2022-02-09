using System;

namespace Hammer
{
	/// <summary>
	/// A way to hide properties from parent classes in the FGD.
	/// </summary>
	// Token: 0x020001FD RID: 509
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class SkipPropertyAttribute : Attribute
	{
		/// <param name="internal_name">The internal/fgd name to skip. Usually all lowecase and with underscores (_) instead of spaces.</param>
		// Token: 0x06000CF3 RID: 3315 RVA: 0x000160AA File Offset: 0x000142AA
		public SkipPropertyAttribute(string internal_name)
		{
			this.PropertyName = internal_name;
		}

		// Token: 0x04000DCB RID: 3531
		internal string PropertyName;
	}
}
