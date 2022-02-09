using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace OpenVR
{
	// Token: 0x02000012 RID: 18
	internal struct IVRInput
	{
		// Token: 0x0600013A RID: 314 RVA: 0x000227B4 File Offset: 0x000209B4
		public static implicit operator IntPtr(IVRInput value)
		{
			return value.self;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x000227BC File Offset: 0x000209BC
		public static implicit operator IVRInput(IntPtr value)
		{
			return new IVRInput
			{
				self = value
			};
		}

		// Token: 0x0600013C RID: 316 RVA: 0x000227DA File Offset: 0x000209DA
		public static bool operator ==(IVRInput c1, IVRInput c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x000227ED File Offset: 0x000209ED
		public static bool operator !=(IVRInput c1, IVRInput c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00022800 File Offset: 0x00020A00
		public override bool Equals(object obj)
		{
			if (obj is IVRInput)
			{
				IVRInput c = (IVRInput)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0002282A File Offset: 0x00020A2A
		internal IVRInput(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00022834 File Offset: 0x00020A34
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
			defaultInterpolatedStringHandler.AppendLiteral("IVRInput ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000141 RID: 321 RVA: 0x00022870 File Offset: 0x00020A70
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000142 RID: 322 RVA: 0x00022882 File Offset: 0x00020A82
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0002288D File Offset: 0x00020A8D
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x000228A0 File Offset: 0x00020AA0
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("IVRInput was null when calling " + n);
			}
		}

		// Token: 0x06000145 RID: 325 RVA: 0x000228BB File Offset: 0x00020ABB
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000146 RID: 326 RVA: 0x000228C8 File Offset: 0x00020AC8
		internal readonly VRInputError GetInputSourceHandle(string inputSourcePath, out ulong handle)
		{
			this.NullCheck("GetInputSourceHandle");
			method vr_IVRInp_GetInputSourceHandle = IVRInput.__N.vr_IVRInp_GetInputSourceHandle;
			return calli(System.Int64(System.IntPtr,System.IntPtr,System.UInt64& modreq(System.Runtime.InteropServices.OutAttribute)), this.self, Interop.GetPointer(inputSourcePath), ref handle, vr_IVRInp_GetInputSourceHandle);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x000228FC File Offset: 0x00020AFC
		internal readonly VRInputError GetOriginTrackedDeviceInfo(ulong origin, out InputOriginInfo originInfo, uint originInfoSize)
		{
			this.NullCheck("GetOriginTrackedDeviceInfo");
			method vr_IVRInp_GetOriginTrackedDeviceInfo = IVRInput.__N.vr_IVRInp_GetOriginTrackedDeviceInfo;
			return calli(System.Int64(System.IntPtr,System.UInt64,OpenVR.InputOriginInfo& modreq(System.Runtime.InteropServices.OutAttribute),System.UInt32), this.self, origin, ref originInfo, originInfoSize, vr_IVRInp_GetOriginTrackedDeviceInfo);
		}

		// Token: 0x04000012 RID: 18
		internal IntPtr self;

		// Token: 0x0200019D RID: 413
		internal static class __N
		{
			// Token: 0x040007F9 RID: 2041
			internal static method vr_IVRInp_GetInputSourceHandle;

			// Token: 0x040007FA RID: 2042
			internal static method vr_IVRInp_GetOriginTrackedDeviceInfo;
		}
	}
}
