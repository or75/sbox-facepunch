using System;
using System.Reflection;

namespace Sandbox
{
	// Token: 0x0200006E RID: 110
	public static class Global
	{
		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06001273 RID: 4723 RVA: 0x00050726 File Offset: 0x0004E926
		// (set) Token: 0x06001274 RID: 4724 RVA: 0x0005072D File Offset: 0x0004E92D
		internal static Assembly Assembly { get; set; }

		/// <summary>
		/// The manager of our hotload
		/// </summary>
		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06001275 RID: 4725 RVA: 0x00050735 File Offset: 0x0004E935
		// (set) Token: 0x06001276 RID: 4726 RVA: 0x0005073C File Offset: 0x0004E93C
		internal static HotloadManager HotloadManager { get; set; }
	}
}
