using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x0200006C RID: 108
	public struct CameraSetup
	{
		// Token: 0x06000C4B RID: 3147 RVA: 0x0003F704 File Offset: 0x0003D904
		internal CameraSetup(ViewDesc viewDesc)
		{
			this = default(CameraSetup);
			this.Position = viewDesc.Position;
			this.Rotation = viewDesc.Rotation;
			this.FieldOfView = viewDesc.FieldOfView;
			this.ZNear = viewDesc.ZNear;
			this.ZFar = viewDesc.ZFar;
			this.Aspect = viewDesc.Aspect;
			this.Ortho = viewDesc.Ortho;
			this.OrthoSize = viewDesc.OrthoSize;
			this.Viewer = null;
			this.ViewModel.FieldOfView = viewDesc.VMFieldOfView;
			this.ViewModel.ZNear = viewDesc.VMZNear;
			this.ViewModel.ZFar = viewDesc.VMZFar;
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x0003F7B4 File Offset: 0x0003D9B4
		internal void ToViewDesc(ref ViewDesc viewDesc)
		{
			viewDesc.Position = this.Position;
			viewDesc.Rotation = this.Rotation;
			viewDesc.FieldOfView = this.FieldOfView;
			viewDesc.ZNear = this.ZNear;
			viewDesc.ZFar = this.ZFar;
			viewDesc.Aspect = this.Aspect;
			viewDesc.Ortho = this.Ortho;
			viewDesc.OrthoSize = this.OrthoSize;
			Entity viewer = this.Viewer;
			viewDesc.EyeEntity = ((viewer != null) ? viewer.GetEntityIntPtr() : ((IntPtr)0));
			viewDesc.VMFieldOfView = this.ViewModel.FieldOfView;
			viewDesc.VMZNear = this.ViewModel.ZNear;
			viewDesc.VMZFar = this.ViewModel.ZFar;
		}

		// Token: 0x04000193 RID: 403
		public Vector3 Position;

		// Token: 0x04000194 RID: 404
		public Rotation Rotation;

		// Token: 0x04000195 RID: 405
		public float FieldOfView;

		// Token: 0x04000196 RID: 406
		public Entity Viewer;

		// Token: 0x04000197 RID: 407
		public float ZNear;

		// Token: 0x04000198 RID: 408
		public float ZFar;

		// Token: 0x04000199 RID: 409
		public float Aspect;

		// Token: 0x0400019A RID: 410
		public bool Ortho;

		// Token: 0x0400019B RID: 411
		public float OrthoSize;

		// Token: 0x0400019C RID: 412
		public CameraSetup.ViewModelSetup ViewModel;

		// Token: 0x020001F8 RID: 504
		public struct ViewModelSetup
		{
			// Token: 0x04001082 RID: 4226
			public float FieldOfView;

			// Token: 0x04001083 RID: 4227
			public float ZNear;

			// Token: 0x04001084 RID: 4228
			public float ZFar;
		}
	}
}
