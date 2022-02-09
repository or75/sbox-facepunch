using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200003E RID: 62
	internal static class ServerEngine
	{
		// Token: 0x0600093C RID: 2364 RVA: 0x00036974 File Offset: 0x00034B74
		internal static void ChangeLevel(string map, string landmark)
		{
			method engine_ChangeLevel = ServerEngine.__N.engine_ChangeLevel;
			calli(System.Void(System.IntPtr,System.IntPtr), Interop.GetPointer(map), Interop.GetPointer(landmark), engine_ChangeLevel);
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x00036999 File Offset: 0x00034B99
		internal static bool IsDedicatedServer()
		{
			return calli(System.Int32(), ServerEngine.__N.engine_IsDedicatedServer) > 0;
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x000369A8 File Offset: 0x00034BA8
		internal static bool IsServerLocalOnly()
		{
			return calli(System.Int32(), ServerEngine.__N.engine_IsServerLocalOnly) > 0;
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x000369B8 File Offset: 0x00034BB8
		internal static void ServerCommand(string cmd)
		{
			method engine_ServerCommand = ServerEngine.__N.engine_ServerCommand;
			calli(System.Void(System.IntPtr), Interop.GetPointer(cmd), engine_ServerCommand);
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x000369D8 File Offset: 0x00034BD8
		internal static void ClientCommand(int index, string format, string arg)
		{
			method engine_ClientCommand = ServerEngine.__N.engine_ClientCommand;
			calli(System.Void(System.Int32,System.IntPtr,System.IntPtr), index, Interop.GetPointer(format), Interop.GetPointer(arg), engine_ClientCommand);
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x00036A00 File Offset: 0x00034C00
		internal static void ClientPrintf(int index, string command)
		{
			method engine_ClientPrintf = ServerEngine.__N.engine_ClientPrintf;
			calli(System.Void(System.Int32,System.IntPtr), index, Interop.GetPointer(command), engine_ClientPrintf);
		}

		// Token: 0x020001C3 RID: 451
		internal static class __N
		{
			// Token: 0x04000E63 RID: 3683
			internal static method engine_ChangeLevel;

			// Token: 0x04000E64 RID: 3684
			internal static method engine_IsDedicatedServer;

			// Token: 0x04000E65 RID: 3685
			internal static method engine_IsServerLocalOnly;

			// Token: 0x04000E66 RID: 3686
			internal static method engine_ServerCommand;

			// Token: 0x04000E67 RID: 3687
			internal static method engine_ClientCommand;

			// Token: 0x04000E68 RID: 3688
			internal static method engine_ClientPrintf;
		}
	}
}
