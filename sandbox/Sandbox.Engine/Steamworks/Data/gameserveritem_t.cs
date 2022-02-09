using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x0200019D RID: 413
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct gameserveritem_t
	{
		// Token: 0x060009EC RID: 2540
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_gameserveritem_t_Construct")]
		internal static extern void InternalConstruct(ref gameserveritem_t self);

		// Token: 0x060009ED RID: 2541
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_gameserveritem_t_GetName")]
		internal static extern Utf8StringPointer InternalGetName(ref gameserveritem_t self);

		// Token: 0x060009EE RID: 2542
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_gameserveritem_t_SetName")]
		internal static extern void InternalSetName(ref gameserveritem_t self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pName);

		// Token: 0x060009EF RID: 2543 RVA: 0x0000EBB2 File Offset: 0x0000CDB2
		internal string GameDirUTF8()
		{
			return Encoding.UTF8.GetString(this.GameDir, 0, Array.IndexOf<byte>(this.GameDir, 0));
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x0000EBD1 File Offset: 0x0000CDD1
		internal string MapUTF8()
		{
			return Encoding.UTF8.GetString(this.Map, 0, Array.IndexOf<byte>(this.Map, 0));
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x0000EBF0 File Offset: 0x0000CDF0
		internal string GameDescriptionUTF8()
		{
			return Encoding.UTF8.GetString(this.GameDescription, 0, Array.IndexOf<byte>(this.GameDescription, 0));
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x0000EC0F File Offset: 0x0000CE0F
		internal string ServerNameUTF8()
		{
			return Encoding.UTF8.GetString(this.ServerName, 0, Array.IndexOf<byte>(this.ServerName, 0));
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x0000EC2E File Offset: 0x0000CE2E
		internal string GameTagsUTF8()
		{
			return Encoding.UTF8.GetString(this.GameTags, 0, Array.IndexOf<byte>(this.GameTags, 0));
		}

		// Token: 0x04000CD9 RID: 3289
		internal servernetadr_t NetAdr;

		// Token: 0x04000CDA RID: 3290
		internal int Ping;

		// Token: 0x04000CDB RID: 3291
		[MarshalAs(UnmanagedType.I1)]
		internal bool HadSuccessfulResponse;

		// Token: 0x04000CDC RID: 3292
		[MarshalAs(UnmanagedType.I1)]
		internal bool DoNotRefresh;

		// Token: 0x04000CDD RID: 3293
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		internal byte[] GameDir;

		// Token: 0x04000CDE RID: 3294
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		internal byte[] Map;

		// Token: 0x04000CDF RID: 3295
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		internal byte[] GameDescription;

		// Token: 0x04000CE0 RID: 3296
		internal uint AppID;

		// Token: 0x04000CE1 RID: 3297
		internal int Players;

		// Token: 0x04000CE2 RID: 3298
		internal int MaxPlayers;

		// Token: 0x04000CE3 RID: 3299
		internal int BotPlayers;

		// Token: 0x04000CE4 RID: 3300
		[MarshalAs(UnmanagedType.I1)]
		internal bool Password;

		// Token: 0x04000CE5 RID: 3301
		[MarshalAs(UnmanagedType.I1)]
		internal bool Secure;

		// Token: 0x04000CE6 RID: 3302
		internal uint TimeLastPlayed;

		// Token: 0x04000CE7 RID: 3303
		internal int ServerVersion;

		// Token: 0x04000CE8 RID: 3304
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		internal byte[] ServerName;

		// Token: 0x04000CE9 RID: 3305
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		internal byte[] GameTags;

		// Token: 0x04000CEA RID: 3306
		internal ulong SteamID;
	}
}
