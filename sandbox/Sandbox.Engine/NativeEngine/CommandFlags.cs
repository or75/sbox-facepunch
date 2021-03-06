using System;

namespace NativeEngine
{
	// Token: 0x0200021E RID: 542
	[Flags]
	internal enum CommandFlags : long
	{
		// Token: 0x04000E0B RID: 3595
		FCVAR_NONE = 0L,
		// Token: 0x04000E0C RID: 3596
		FCVAR_UNREGISTERED = 1L,
		// Token: 0x04000E0D RID: 3597
		FCVAR_DEVELOPMENTONLY = 2L,
		// Token: 0x04000E0E RID: 3598
		FCVAR_GAMEDLL = 4L,
		// Token: 0x04000E0F RID: 3599
		FCVAR_CLIENTDLL = 8L,
		// Token: 0x04000E10 RID: 3600
		FCVAR_HIDDEN = 16L,
		// Token: 0x04000E11 RID: 3601
		FCVAR_PROTECTED = 32L,
		// Token: 0x04000E12 RID: 3602
		FCVAR_SPONLY = 64L,
		// Token: 0x04000E13 RID: 3603
		FCVAR_ARCHIVE = 128L,
		// Token: 0x04000E14 RID: 3604
		FCVAR_NOTIFY = 256L,
		// Token: 0x04000E15 RID: 3605
		FCVAR_USERINFO = 512L,
		// Token: 0x04000E16 RID: 3606
		FCVAR_PRINTABLEONLY = 1024L,
		// Token: 0x04000E17 RID: 3607
		FCVAR_UNLOGGED = 2048L,
		// Token: 0x04000E18 RID: 3608
		FCVAR_NEVER_AS_STRING = 4096L,
		// Token: 0x04000E19 RID: 3609
		FCVAR_REPLICATED = 8192L,
		// Token: 0x04000E1A RID: 3610
		FCVAR_CHEAT = 16384L,
		// Token: 0x04000E1B RID: 3611
		FCVAR_SS = 32768L,
		// Token: 0x04000E1C RID: 3612
		FCVAR_DEMO = 65536L,
		// Token: 0x04000E1D RID: 3613
		FCVAR_DONTRECORD = 131072L,
		// Token: 0x04000E1E RID: 3614
		FCVAR_SS_ADDED = 262144L,
		// Token: 0x04000E1F RID: 3615
		FCVAR_RELEASE = 524288L,
		// Token: 0x04000E20 RID: 3616
		FCVAR_NOT_CONNECTED = 4194304L,
		// Token: 0x04000E21 RID: 3617
		FCVAR_ACCESSIBLE_FROM_THREADS = 33554432L,
		// Token: 0x04000E22 RID: 3618
		FCVAR_LINKED_CONCOMMAND = 67108864L,
		// Token: 0x04000E23 RID: 3619
		FCVAR_VCONSOLE_FUZZY_MATCHING = 134217728L,
		// Token: 0x04000E24 RID: 3620
		FCVAR_SERVER_CAN_EXECUTE = 268435456L,
		// Token: 0x04000E25 RID: 3621
		FCVAR_CLIENT_CAN_EXECUTE = 268435456L,
		// Token: 0x04000E26 RID: 3622
		FCVAR_SERVER_CANNOT_QUERY = 536870912L,
		// Token: 0x04000E27 RID: 3623
		FCVAR_VCONSOLE_SET_FOCUS = 1073741824L,
		// Token: 0x04000E28 RID: 3624
		FCVAR_CLIENTCMD_CAN_EXECUTE = 2147483648L,
		// Token: 0x04000E29 RID: 3625
		FCVAR_EXECUTE_PER_TICK = 4294967296L,
		// Token: 0x04000E2A RID: 3626
		FCVAR_DO_NOT_SNAPSHOT = 8589934592L,
		// Token: 0x04000E2B RID: 3627
		FCVAR_MENU = 17179869184L,
		// Token: 0x04000E2C RID: 3628
		FCVAR_MANAGED = 34359738368L
	}
}
