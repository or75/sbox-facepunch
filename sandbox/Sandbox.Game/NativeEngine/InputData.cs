using System;

namespace NativeEngine
{
	// Token: 0x02000019 RID: 25
	internal struct InputData
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600016C RID: 364 RVA: 0x00022ECC File Offset: 0x000210CC
		// (set) Token: 0x0600016D RID: 365 RVA: 0x00022ED4 File Offset: 0x000210D4
		public float FrameTime { readonly get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600016E RID: 366 RVA: 0x00022EDD File Offset: 0x000210DD
		// (set) Token: 0x0600016F RID: 367 RVA: 0x00022EE5 File Offset: 0x000210E5
		public byte IsPaused { readonly get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000170 RID: 368 RVA: 0x00022EEE File Offset: 0x000210EE
		// (set) Token: 0x06000171 RID: 369 RVA: 0x00022EF6 File Offset: 0x000210F6
		public Vector2 AnalogLook { readonly get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000172 RID: 370 RVA: 0x00022EFF File Offset: 0x000210FF
		// (set) Token: 0x06000173 RID: 371 RVA: 0x00022F07 File Offset: 0x00021107
		public Vector3 AnalogMove { readonly get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000174 RID: 372 RVA: 0x00022F10 File Offset: 0x00021110
		// (set) Token: 0x06000175 RID: 373 RVA: 0x00022F18 File Offset: 0x00021118
		public Vector2 Mouse { readonly get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000176 RID: 374 RVA: 0x00022F21 File Offset: 0x00021121
		// (set) Token: 0x06000177 RID: 375 RVA: 0x00022F29 File Offset: 0x00021129
		public int MouseWheel { readonly get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000178 RID: 376 RVA: 0x00022F32 File Offset: 0x00021132
		// (set) Token: 0x06000179 RID: 377 RVA: 0x00022F3A File Offset: 0x0002113A
		public ulong Buttons { readonly get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600017A RID: 378 RVA: 0x00022F43 File Offset: 0x00021143
		// (set) Token: 0x0600017B RID: 379 RVA: 0x00022F4B File Offset: 0x0002114B
		public Angles ViewAng { readonly get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600017C RID: 380 RVA: 0x00022F54 File Offset: 0x00021154
		// (set) Token: 0x0600017D RID: 381 RVA: 0x00022F5C File Offset: 0x0002115C
		public Vector3 ViewPos { readonly get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600017E RID: 382 RVA: 0x00022F65 File Offset: 0x00021165
		// (set) Token: 0x0600017F RID: 383 RVA: 0x00022F6D File Offset: 0x0002116D
		public Vector3 Move { readonly get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000180 RID: 384 RVA: 0x00022F76 File Offset: 0x00021176
		// (set) Token: 0x06000181 RID: 385 RVA: 0x00022F7E File Offset: 0x0002117E
		public Vector3 CursorAim { readonly get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000182 RID: 386 RVA: 0x00022F87 File Offset: 0x00021187
		// (set) Token: 0x06000183 RID: 387 RVA: 0x00022F8F File Offset: 0x0002118F
		public Vector3 CursorOrigin { readonly get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000184 RID: 388 RVA: 0x00022F98 File Offset: 0x00021198
		// (set) Token: 0x06000185 RID: 389 RVA: 0x00022FA0 File Offset: 0x000211A0
		public int SelectionIndex { readonly get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000186 RID: 390 RVA: 0x00022FA9 File Offset: 0x000211A9
		// (set) Token: 0x06000187 RID: 391 RVA: 0x00022FB1 File Offset: 0x000211B1
		public int SelectionSubIndex { readonly get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000188 RID: 392 RVA: 0x00022FBA File Offset: 0x000211BA
		// (set) Token: 0x06000189 RID: 393 RVA: 0x00022FC2 File Offset: 0x000211C2
		public byte IsController { readonly get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600018A RID: 394 RVA: 0x00022FCB File Offset: 0x000211CB
		// (set) Token: 0x0600018B RID: 395 RVA: 0x00022FD3 File Offset: 0x000211D3
		public Vector2 AnalogActionMove { readonly get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600018C RID: 396 RVA: 0x00022FDC File Offset: 0x000211DC
		// (set) Token: 0x0600018D RID: 397 RVA: 0x00022FE4 File Offset: 0x000211E4
		public Vector2 AnalogActionLook { readonly get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600018E RID: 398 RVA: 0x00022FED File Offset: 0x000211ED
		// (set) Token: 0x0600018F RID: 399 RVA: 0x00022FF5 File Offset: 0x000211F5
		public Vector2 AnalogActionTrigger { readonly get; set; }
	}
}
