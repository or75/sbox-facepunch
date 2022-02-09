using System;

namespace NativeEngine
{
	// Token: 0x02000014 RID: 20
	internal struct ViewDesc
	{
		// Token: 0x04000014 RID: 20
		public Vector3 Position;

		// Token: 0x04000015 RID: 21
		public Rotation Rotation;

		// Token: 0x04000016 RID: 22
		public float FieldOfView;

		// Token: 0x04000017 RID: 23
		public float VMFieldOfView;

		// Token: 0x04000018 RID: 24
		public float VMZNear;

		// Token: 0x04000019 RID: 25
		public float VMZFar;

		// Token: 0x0400001A RID: 26
		public float ZNear;

		// Token: 0x0400001B RID: 27
		public float ZFar;

		// Token: 0x0400001C RID: 28
		public float Aspect;

		// Token: 0x0400001D RID: 29
		public IntPtr EyeEntity;

		// Token: 0x0400001E RID: 30
		public int X;

		// Token: 0x0400001F RID: 31
		public int Y;

		// Token: 0x04000020 RID: 32
		public int Width;

		// Token: 0x04000021 RID: 33
		public int Height;

		// Token: 0x04000022 RID: 34
		public float DoFFocusPoint;

		// Token: 0x04000023 RID: 35
		public float DoFSize;

		// Token: 0x04000024 RID: 36
		public float MotionBlurScale;

		// Token: 0x04000025 RID: 37
		public bool Ortho;

		// Token: 0x04000026 RID: 38
		public float OrthoSize;
	}
}
