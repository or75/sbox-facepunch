using System;
using System.Collections.Generic;
using System.Text;

namespace Hammer
{
	/// <summary>
	/// Base attribute which allows adding FGD metadata to classes.
	/// </summary>
	// Token: 0x020001FA RID: 506
	[AttributeUsage(AttributeTargets.Class)]
	public abstract class MetaDataAttribute : Attribute
	{
		// Token: 0x06000CEA RID: 3306 RVA: 0x00016086 File Offset: 0x00014286
		public virtual void AddMetaData(StringBuilder sb)
		{
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x00016088 File Offset: 0x00014288
		public virtual void AddHeader(StringBuilder sb)
		{
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x0001608A File Offset: 0x0001428A
		public virtual void AddBody(StringBuilder sb)
		{
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x0001608C File Offset: 0x0001428C
		public virtual void AddTags(List<string> tags)
		{
		}
	}
}
