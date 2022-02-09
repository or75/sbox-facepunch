using System;
using System.Linq;

namespace Sandbox
{
	/// <summary>
	/// Allows you to specify a string property as a resource type. This will
	/// give the property a resource finder. Type should be the file extension, ie "vmdl"
	/// </summary>
	// Token: 0x020002AB RID: 683
	public class ResourceTypeAttribute : FGDTypeAttribute
	{
		// Token: 0x06001152 RID: 4434 RVA: 0x00022A40 File Offset: 0x00020C40
		public ResourceTypeAttribute(string type)
			: base("string", "AssetBrowse", type)
		{
			if (this.nativeTypes.Contains(type))
			{
				this.Type = "resource:" + type;
				this.Editor = "";
			}
		}

		// Token: 0x0400138C RID: 5004
		private string[] nativeTypes = new string[] { "vmdl", "vtex", "vmat", "vpcf", "vpost", "vsnap" };
	}
}
