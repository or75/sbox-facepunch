using System;

namespace NativeEngine
{
	// Token: 0x02000063 RID: 99
	internal struct TraceResult
	{
		// Token: 0x04000159 RID: 345
		public Vector3 StartPos;

		// Token: 0x0400015A RID: 346
		public Vector3 EndPos;

		// Token: 0x0400015B RID: 347
		public Vector3 Normal;

		// Token: 0x0400015C RID: 348
		public float Fraction;

		// Token: 0x0400015D RID: 349
		public uint Entity;

		// Token: 0x0400015E RID: 350
		public byte StartedInSolid;

		// Token: 0x0400015F RID: 351
		public int PhysicsBodyHandle;

		// Token: 0x04000160 RID: 352
		public int PhysicsShapeHandle;

		// Token: 0x04000161 RID: 353
		public int Hitbox;

		// Token: 0x04000162 RID: 354
		public int SurfaceProperty;

		// Token: 0x04000163 RID: 355
		public int Bone;

		// Token: 0x04000164 RID: 356
		public int TriangleIndex;
	}
}
