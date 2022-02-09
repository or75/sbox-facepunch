using System;
using Sandbox;

namespace NativeGlue
{
	// Token: 0x0200000B RID: 11
	internal static class ConVar
	{
		// Token: 0x06000023 RID: 35 RVA: 0x00002A40 File Offset: 0x00000C40
		internal static void AddConCommand(string name, string help, long flags)
		{
			method glue_ConVar_AddConCommand = ConVar.__N.Glue_ConVar_AddConCommand;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int64), Interop.GetPointer(name), Interop.GetPointer(help), flags, glue_ConVar_AddConCommand);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002A68 File Offset: 0x00000C68
		internal static void AddConVar(string name, string value, string help, long flags)
		{
			method glue_ConVar_AddConVar = ConVar.__N.Glue_ConVar_AddConVar;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr,System.Int64), Interop.GetPointer(name), Interop.GetPointer(value), Interop.GetPointer(help), flags, glue_ConVar_AddConVar);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002A94 File Offset: 0x00000C94
		internal static void RemoveConvar(string name, long flags)
		{
			method glue_ConVar_RemoveConvar = ConVar.__N.Glue_ConVar_RemoveConvar;
			calli(System.Void(System.IntPtr,System.Int64), Interop.GetPointer(name), flags, glue_ConVar_RemoveConvar);
		}

		// Token: 0x02000196 RID: 406
		internal static class __N
		{
			// Token: 0x040007C9 RID: 1993
			internal static method Glue_ConVar_AddConCommand;

			// Token: 0x040007CA RID: 1994
			internal static method Glue_ConVar_AddConVar;

			// Token: 0x040007CB RID: 1995
			internal static method Glue_ConVar_RemoveConvar;
		}
	}
}
