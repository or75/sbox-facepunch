using System;
using System.Collections.Generic;

namespace Hammer
{
	/// <summary>
	/// Base attribute which allows adding FGD metadata to properties.
	/// </summary>
	// Token: 0x020001FB RID: 507
	[AttributeUsage(AttributeTargets.Property)]
	public abstract class FieldMetaDataAttribute : Attribute
	{
		// Token: 0x06000CEF RID: 3311 RVA: 0x00016096 File Offset: 0x00014296
		public virtual void AddMetaData(Dictionary<string, string> meta_data)
		{
		}

		// Token: 0x06000CF0 RID: 3312 RVA: 0x00016098 File Offset: 0x00014298
		[Obsolete("You must use AddMetaData( Dictionary<string,string> ) now")]
		public virtual void AddMetaData(List<string> meta_data)
		{
		}
	}
}
