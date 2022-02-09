using System;
using Sandbox.Internal.Globals;

namespace Sandbox.Internal
{
	// Token: 0x02000176 RID: 374
	public static class GlobalGameNamespace
	{
		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06001B95 RID: 7061 RVA: 0x0006F041 File Offset: 0x0006D241
		public static DebugOverlay DebugOverlay { get; } = new DebugOverlay();

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x06001B96 RID: 7062 RVA: 0x0006F048 File Offset: 0x0006D248
		public static Global Global { get; } = new Global();

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06001B97 RID: 7063 RVA: 0x0006F04F File Offset: 0x0006D24F
		// (set) Token: 0x06001B98 RID: 7064 RVA: 0x0006F056 File Offset: 0x0006D256
		public static Logger Log { get; internal set; } = new Logger("Generic");

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x06001B99 RID: 7065 RVA: 0x0006F05E File Offset: 0x0006D25E
		// (set) Token: 0x06001B9A RID: 7066 RVA: 0x0006F065 File Offset: 0x0006D265
		public static PostProcessSystem PostProcess { get; internal set; }

		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x06001B9B RID: 7067 RVA: 0x0006F06D File Offset: 0x0006D26D
		// (set) Token: 0x06001B9C RID: 7068 RVA: 0x0006F074 File Offset: 0x0006D274
		public static ReflectionSystem Reflection { get; internal set; }

		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x06001B9D RID: 7069 RVA: 0x0006F07C File Offset: 0x0006D27C
		// (set) Token: 0x06001B9E RID: 7070 RVA: 0x0006F083 File Offset: 0x0006D283
		public static CookieContainer Cookie { get; internal set; }
	}
}
