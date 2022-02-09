using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x020001AE RID: 430
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamDatagramGameCoordinatorServerLogin
	{
		// Token: 0x06000A45 RID: 2629 RVA: 0x0000EEE5 File Offset: 0x0000D0E5
		internal string AppDataUTF8()
		{
			return Encoding.UTF8.GetString(this.AppData, 0, Array.IndexOf<byte>(this.AppData, 0));
		}

		// Token: 0x04000D32 RID: 3378
		internal NetIdentity Dentity;

		// Token: 0x04000D33 RID: 3379
		internal SteamDatagramHostedAddress Outing;

		// Token: 0x04000D34 RID: 3380
		internal AppId AppID;

		// Token: 0x04000D35 RID: 3381
		internal uint Time;

		// Token: 0x04000D36 RID: 3382
		internal int CbAppData;

		// Token: 0x04000D37 RID: 3383
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048)]
		internal byte[] AppData;
	}
}
