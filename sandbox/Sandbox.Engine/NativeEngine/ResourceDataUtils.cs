using System;
using System.Runtime.CompilerServices;

namespace NativeEngine
{
	// Token: 0x02000243 RID: 579
	internal struct ResourceDataUtils
	{
		// Token: 0x06000EEC RID: 3820 RVA: 0x0001A761 File Offset: 0x00018961
		public static implicit operator IntPtr(ResourceDataUtils value)
		{
			return value.self;
		}

		// Token: 0x06000EED RID: 3821 RVA: 0x0001A76C File Offset: 0x0001896C
		public static implicit operator ResourceDataUtils(IntPtr value)
		{
			return new ResourceDataUtils
			{
				self = value
			};
		}

		// Token: 0x06000EEE RID: 3822 RVA: 0x0001A78A File Offset: 0x0001898A
		public static bool operator ==(ResourceDataUtils c1, ResourceDataUtils c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000EEF RID: 3823 RVA: 0x0001A79D File Offset: 0x0001899D
		public static bool operator !=(ResourceDataUtils c1, ResourceDataUtils c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000EF0 RID: 3824 RVA: 0x0001A7B0 File Offset: 0x000189B0
		public override bool Equals(object obj)
		{
			if (obj is ResourceDataUtils)
			{
				ResourceDataUtils c = (ResourceDataUtils)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000EF1 RID: 3825 RVA: 0x0001A7DA File Offset: 0x000189DA
		internal ResourceDataUtils(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000EF2 RID: 3826 RVA: 0x0001A7E4 File Offset: 0x000189E4
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
			defaultInterpolatedStringHandler.AppendLiteral("ResourceDataUtils ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x06000EF3 RID: 3827 RVA: 0x0001A820 File Offset: 0x00018A20
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x06000EF4 RID: 3828 RVA: 0x0001A832 File Offset: 0x00018A32
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000EF5 RID: 3829 RVA: 0x0001A83D File Offset: 0x00018A3D
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000EF6 RID: 3830 RVA: 0x0001A850 File Offset: 0x00018A50
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("ResourceDataUtils was null when calling " + n);
			}
		}

		// Token: 0x06000EF7 RID: 3831 RVA: 0x0001A86B File Offset: 0x00018A6B
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000EF8 RID: 3832 RVA: 0x0001A878 File Offset: 0x00018A78
		internal readonly void SetDataRegistrationFailed()
		{
			this.NullCheck("SetDataRegistrationFailed");
			method irdreg_SetDataRegistrationFailed = ResourceDataUtils.__N.IRDReg_SetDataRegistrationFailed;
			calli(System.Void(System.IntPtr), this.self, irdreg_SetDataRegistrationFailed);
		}

		// Token: 0x06000EF9 RID: 3833 RVA: 0x0001A8A4 File Offset: 0x00018AA4
		internal readonly bool IsReloading()
		{
			this.NullCheck("IsReloading");
			method irdreg_IsReloading = ResourceDataUtils.__N.IRDReg_IsReloading;
			return calli(System.Int32(System.IntPtr), this.self, irdreg_IsReloading) > 0;
		}

		// Token: 0x06000EFA RID: 3834 RVA: 0x0001A8D4 File Offset: 0x00018AD4
		internal readonly void SetFinalResourceData(IntPtr pPtr)
		{
			this.NullCheck("SetFinalResourceData");
			method irdreg_SetFinalResourceData = ResourceDataUtils.__N.IRDReg_SetFinalResourceData;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, pPtr, irdreg_SetFinalResourceData);
		}

		// Token: 0x06000EFB RID: 3835 RVA: 0x0001A900 File Offset: 0x00018B00
		internal readonly bool GetDataRegistrationFailed()
		{
			this.NullCheck("GetDataRegistrationFailed");
			method irdreg_GetDataRegistrationFailed = ResourceDataUtils.__N.IRDReg_GetDataRegistrationFailed;
			return calli(System.Int32(System.IntPtr), this.self, irdreg_GetDataRegistrationFailed) > 0;
		}

		// Token: 0x06000EFC RID: 3836 RVA: 0x0001A930 File Offset: 0x00018B30
		internal readonly IntPtr GetFinalResourceData()
		{
			this.NullCheck("GetFinalResourceData");
			method irdreg_GetFinalResourceData = ResourceDataUtils.__N.IRDReg_GetFinalResourceData;
			return calli(System.IntPtr(System.IntPtr), this.self, irdreg_GetFinalResourceData);
		}

		// Token: 0x06000EFD RID: 3837 RVA: 0x0001A95C File Offset: 0x00018B5C
		internal readonly long GetResultBufferSize()
		{
			this.NullCheck("GetResultBufferSize");
			method irdreg_GetResultBufferSize = ResourceDataUtils.__N.IRDReg_GetResultBufferSize;
			return calli(System.Int64(System.IntPtr), this.self, irdreg_GetResultBufferSize);
		}

		// Token: 0x04000E49 RID: 3657
		internal IntPtr self;

		// Token: 0x020003A8 RID: 936
		internal static class __N
		{
			// Token: 0x0400189D RID: 6301
			internal static method IRDReg_SetDataRegistrationFailed;

			// Token: 0x0400189E RID: 6302
			internal static method IRDReg_IsReloading;

			// Token: 0x0400189F RID: 6303
			internal static method IRDReg_SetFinalResourceData;

			// Token: 0x040018A0 RID: 6304
			internal static method IRDReg_GetDataRegistrationFailed;

			// Token: 0x040018A1 RID: 6305
			internal static method IRDReg_GetFinalResourceData;

			// Token: 0x040018A2 RID: 6306
			internal static method IRDReg_GetResultBufferSize;
		}
	}
}
