using System;

namespace Sandbox
{
	// Token: 0x0200006D RID: 109
	public static class CurrentView
	{
		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000C4D RID: 3149 RVA: 0x0003F86D File Offset: 0x0003DA6D
		// (set) Token: 0x06000C4E RID: 3150 RVA: 0x0003F874 File Offset: 0x0003DA74
		public static Vector3 Position { get; internal set; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000C4F RID: 3151 RVA: 0x0003F87C File Offset: 0x0003DA7C
		// (set) Token: 0x06000C50 RID: 3152 RVA: 0x0003F883 File Offset: 0x0003DA83
		public static Rotation Rotation { get; internal set; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000C51 RID: 3153 RVA: 0x0003F88B File Offset: 0x0003DA8B
		// (set) Token: 0x06000C52 RID: 3154 RVA: 0x0003F892 File Offset: 0x0003DA92
		public static Entity Viewer { get; internal set; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000C53 RID: 3155 RVA: 0x0003F89A File Offset: 0x0003DA9A
		// (set) Token: 0x06000C54 RID: 3156 RVA: 0x0003F8A1 File Offset: 0x0003DAA1
		public static float FieldOfView { get; internal set; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000C55 RID: 3157 RVA: 0x0003F8A9 File Offset: 0x0003DAA9
		// (set) Token: 0x06000C56 RID: 3158 RVA: 0x0003F8B0 File Offset: 0x0003DAB0
		public static float OrthoSize { get; internal set; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000C57 RID: 3159 RVA: 0x0003F8B8 File Offset: 0x0003DAB8
		// (set) Token: 0x06000C58 RID: 3160 RVA: 0x0003F8BF File Offset: 0x0003DABF
		public static bool IsOrtho { get; internal set; }
	}
}
