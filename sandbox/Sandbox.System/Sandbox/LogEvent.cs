using System;
using System.ComponentModel;

namespace Sandbox
{
	// Token: 0x0200004C RID: 76
	public struct LogEvent
	{
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000373 RID: 883 RVA: 0x0000D6F5 File Offset: 0x0000B8F5
		// (set) Token: 0x06000374 RID: 884 RVA: 0x0000D6FD File Offset: 0x0000B8FD
		[DisplayName("Log Level")]
		[Category("Meta Data")]
		[ReadOnly(true)]
		public LogLevel Level { readonly get; set; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000375 RID: 885 RVA: 0x0000D706 File Offset: 0x0000B906
		// (set) Token: 0x06000376 RID: 886 RVA: 0x0000D70E File Offset: 0x0000B90E
		[Category("Meta Data")]
		[ReadOnly(true)]
		public string Logger { readonly get; set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000377 RID: 887 RVA: 0x0000D717 File Offset: 0x0000B917
		// (set) Token: 0x06000378 RID: 888 RVA: 0x0000D71F File Offset: 0x0000B91F
		[ReadOnly(true)]
		public string Message { readonly get; set; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000379 RID: 889 RVA: 0x0000D728 File Offset: 0x0000B928
		// (set) Token: 0x0600037A RID: 890 RVA: 0x0000D730 File Offset: 0x0000B930
		[ReadOnly(true)]
		public string HtmlMessage { readonly get; set; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600037B RID: 891 RVA: 0x0000D739 File Offset: 0x0000B939
		// (set) Token: 0x0600037C RID: 892 RVA: 0x0000D741 File Offset: 0x0000B941
		[DisplayName("Stack Trace")]
		[ReadOnly(true)]
		[Editor("StackTrace", "Panel")]
		[Category("Stack Trace")]
		public string Stack { readonly get; set; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600037D RID: 893 RVA: 0x0000D74A File Offset: 0x0000B94A
		// (set) Token: 0x0600037E RID: 894 RVA: 0x0000D752 File Offset: 0x0000B952
		[Category("Meta Data")]
		[ReadOnly(true)]
		public DateTime Time { readonly get; set; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600037F RID: 895 RVA: 0x0000D75B File Offset: 0x0000B95B
		// (set) Token: 0x06000380 RID: 896 RVA: 0x0000D763 File Offset: 0x0000B963
		[ReadOnly(true)]
		public object[] Arguments { readonly get; set; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000381 RID: 897 RVA: 0x0000D76C File Offset: 0x0000B96C
		// (set) Token: 0x06000382 RID: 898 RVA: 0x0000D774 File Offset: 0x0000B974
		[ReadOnly(true)]
		public int Repeats { readonly get; set; }
	}
}
