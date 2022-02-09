using System;

namespace Sandbox.Engine
{
	// Token: 0x020002F8 RID: 760
	internal static class ServerContext
	{
		/// <summary>
		/// The addon ident of the current gamemode
		/// </summary>
		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06001434 RID: 5172 RVA: 0x0002B226 File Offset: 0x00029426
		// (set) Token: 0x06001435 RID: 5173 RVA: 0x0002B22D File Offset: 0x0002942D
		public static string GamemodeIdent { get; internal set; }

		/// <summary>
		/// The addon ident of the current map
		/// </summary>
		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x06001436 RID: 5174 RVA: 0x0002B235 File Offset: 0x00029435
		// (set) Token: 0x06001437 RID: 5175 RVA: 0x0002B23C File Offset: 0x0002943C
		public static string MapIdent { get; internal set; }
	}
}
