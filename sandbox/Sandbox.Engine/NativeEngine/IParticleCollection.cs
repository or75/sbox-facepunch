using System;
using System.Runtime.CompilerServices;

namespace NativeEngine
{
	// Token: 0x02000241 RID: 577
	internal struct IParticleCollection
	{
		// Token: 0x06000ECD RID: 3789 RVA: 0x0001A3DA File Offset: 0x000185DA
		public static implicit operator IntPtr(IParticleCollection value)
		{
			return value.self;
		}

		// Token: 0x06000ECE RID: 3790 RVA: 0x0001A3E4 File Offset: 0x000185E4
		public static implicit operator IParticleCollection(IntPtr value)
		{
			return new IParticleCollection
			{
				self = value
			};
		}

		// Token: 0x06000ECF RID: 3791 RVA: 0x0001A402 File Offset: 0x00018602
		public static bool operator ==(IParticleCollection c1, IParticleCollection c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000ED0 RID: 3792 RVA: 0x0001A415 File Offset: 0x00018615
		public static bool operator !=(IParticleCollection c1, IParticleCollection c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000ED1 RID: 3793 RVA: 0x0001A428 File Offset: 0x00018628
		public override bool Equals(object obj)
		{
			if (obj is IParticleCollection)
			{
				IParticleCollection c = (IParticleCollection)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000ED2 RID: 3794 RVA: 0x0001A452 File Offset: 0x00018652
		internal IParticleCollection(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000ED3 RID: 3795 RVA: 0x0001A45C File Offset: 0x0001865C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
			defaultInterpolatedStringHandler.AppendLiteral("IParticleCollection ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x06000ED4 RID: 3796 RVA: 0x0001A498 File Offset: 0x00018698
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06000ED5 RID: 3797 RVA: 0x0001A4AA File Offset: 0x000186AA
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000ED6 RID: 3798 RVA: 0x0001A4B5 File Offset: 0x000186B5
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000ED7 RID: 3799 RVA: 0x0001A4C8 File Offset: 0x000186C8
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("IParticleCollection was null when calling " + n);
			}
		}

		// Token: 0x06000ED8 RID: 3800 RVA: 0x0001A4E3 File Offset: 0x000186E3
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000ED9 RID: 3801 RVA: 0x0001A4F0 File Offset: 0x000186F0
		internal readonly void SetRenderingEnabled(bool enabled)
		{
			this.NullCheck("SetRenderingEnabled");
			method iprtcl_SetRenderingEnabled = IParticleCollection.__N.IPrtcl_SetRenderingEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, iprtcl_SetRenderingEnabled);
		}

		// Token: 0x06000EDA RID: 3802 RVA: 0x0001A524 File Offset: 0x00018724
		internal readonly bool GetRenderingEnabled()
		{
			this.NullCheck("GetRenderingEnabled");
			method iprtcl_GetRenderingEnabled = IParticleCollection.__N.IPrtcl_GetRenderingEnabled;
			return calli(System.Int32(System.IntPtr), this.self, iprtcl_GetRenderingEnabled) > 0;
		}

		// Token: 0x06000EDB RID: 3803 RVA: 0x0001A554 File Offset: 0x00018754
		internal readonly bool IsControlPointSet(int iPoint)
		{
			this.NullCheck("IsControlPointSet");
			method iprtcl_IsControlPointSet = IParticleCollection.__N.IPrtcl_IsControlPointSet;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, iPoint, iprtcl_IsControlPointSet) > 0;
		}

		// Token: 0x06000EDC RID: 3804 RVA: 0x0001A584 File Offset: 0x00018784
		internal readonly Vector3 GetControlPointPosition(int iPoint)
		{
			this.NullCheck("GetControlPointPosition");
			method iprtcl_GetControlPointPosition = IParticleCollection.__N.IPrtcl_GetControlPointPosition;
			return calli(Vector3(System.IntPtr,System.Int32), this.self, iPoint, iprtcl_GetControlPointPosition);
		}

		// Token: 0x04000E47 RID: 3655
		internal IntPtr self;

		// Token: 0x020003A6 RID: 934
		internal static class __N
		{
			// Token: 0x04001896 RID: 6294
			internal static method IPrtcl_SetRenderingEnabled;

			// Token: 0x04001897 RID: 6295
			internal static method IPrtcl_GetRenderingEnabled;

			// Token: 0x04001898 RID: 6296
			internal static method IPrtcl_IsControlPointSet;

			// Token: 0x04001899 RID: 6297
			internal static method IPrtcl_GetControlPointPosition;
		}
	}
}
