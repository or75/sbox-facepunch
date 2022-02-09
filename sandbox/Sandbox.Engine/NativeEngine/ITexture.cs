using System;
using System.Runtime.CompilerServices;

namespace NativeEngine
{
	// Token: 0x0200022A RID: 554
	internal struct ITexture
	{
		// Token: 0x06000E10 RID: 3600 RVA: 0x00018D58 File Offset: 0x00016F58
		public static implicit operator IntPtr(ITexture value)
		{
			return value.self;
		}

		// Token: 0x06000E11 RID: 3601 RVA: 0x00018D60 File Offset: 0x00016F60
		public static implicit operator ITexture(IntPtr value)
		{
			return new ITexture
			{
				self = value
			};
		}

		// Token: 0x06000E12 RID: 3602 RVA: 0x00018D7E File Offset: 0x00016F7E
		public static bool operator ==(ITexture c1, ITexture c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000E13 RID: 3603 RVA: 0x00018D91 File Offset: 0x00016F91
		public static bool operator !=(ITexture c1, ITexture c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000E14 RID: 3604 RVA: 0x00018DA4 File Offset: 0x00016FA4
		public override bool Equals(object obj)
		{
			if (obj is ITexture)
			{
				ITexture c = (ITexture)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000E15 RID: 3605 RVA: 0x00018DCE File Offset: 0x00016FCE
		internal ITexture(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000E16 RID: 3606 RVA: 0x00018DD8 File Offset: 0x00016FD8
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
			defaultInterpolatedStringHandler.AppendLiteral("ITexture ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x06000E17 RID: 3607 RVA: 0x00018E14 File Offset: 0x00017014
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x06000E18 RID: 3608 RVA: 0x00018E26 File Offset: 0x00017026
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000E19 RID: 3609 RVA: 0x00018E31 File Offset: 0x00017031
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000E1A RID: 3610 RVA: 0x00018E44 File Offset: 0x00017044
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("ITexture was null when calling " + n);
			}
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x00018E5F File Offset: 0x0001705F
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000E1C RID: 3612 RVA: 0x00018E6C File Offset: 0x0001706C
		internal readonly void DestroyStrongHandle()
		{
			this.NullCheck("DestroyStrongHandle");
			method ctextr_DestroyStrongHandle = ITexture.__N.CTextr_DestroyStrongHandle;
			calli(System.Void(System.IntPtr), this.self, ctextr_DestroyStrongHandle);
		}

		// Token: 0x06000E1D RID: 3613 RVA: 0x00018E98 File Offset: 0x00017098
		internal readonly bool IsStrongHandleValid()
		{
			this.NullCheck("IsStrongHandleValid");
			method ctextr_IsStrongHandleValid = ITexture.__N.CTextr_IsStrongHandleValid;
			return calli(System.Int32(System.IntPtr), this.self, ctextr_IsStrongHandleValid) > 0;
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x00018EC8 File Offset: 0x000170C8
		internal readonly bool IsStrongHandleLoaded()
		{
			this.NullCheck("IsStrongHandleLoaded");
			method ctextr_IsStrongHandleLoaded = ITexture.__N.CTextr_IsStrongHandleLoaded;
			return calli(System.Int32(System.IntPtr), this.self, ctextr_IsStrongHandleLoaded) > 0;
		}

		// Token: 0x06000E1F RID: 3615 RVA: 0x00018EF8 File Offset: 0x000170F8
		internal readonly ITexture CopyStrongHandle()
		{
			this.NullCheck("CopyStrongHandle");
			method ctextr_CopyStrongHandle = ITexture.__N.CTextr_CopyStrongHandle;
			return calli(System.IntPtr(System.IntPtr), this.self, ctextr_CopyStrongHandle);
		}

		// Token: 0x06000E20 RID: 3616 RVA: 0x00018F28 File Offset: 0x00017128
		internal readonly IntPtr GetBindingPtr()
		{
			this.NullCheck("GetBindingPtr");
			method ctextr_GetBindingPtr = ITexture.__N.CTextr_GetBindingPtr;
			return calli(System.IntPtr(System.IntPtr), this.self, ctextr_GetBindingPtr);
		}

		// Token: 0x04000E41 RID: 3649
		internal IntPtr self;

		// Token: 0x0200038F RID: 911
		internal static class __N
		{
			// Token: 0x04001821 RID: 6177
			internal static method CTextr_DestroyStrongHandle;

			// Token: 0x04001822 RID: 6178
			internal static method CTextr_IsStrongHandleValid;

			// Token: 0x04001823 RID: 6179
			internal static method CTextr_IsStrongHandleLoaded;

			// Token: 0x04001824 RID: 6180
			internal static method CTextr_CopyStrongHandle;

			// Token: 0x04001825 RID: 6181
			internal static method CTextr_GetBindingPtr;
		}
	}
}
