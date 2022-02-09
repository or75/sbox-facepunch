using System;
using System.Runtime.CompilerServices;

namespace NativeEngine
{
	// Token: 0x02000228 RID: 552
	internal struct IMesh
	{
		// Token: 0x06000DEC RID: 3564 RVA: 0x000188FD File Offset: 0x00016AFD
		public static implicit operator IntPtr(IMesh value)
		{
			return value.self;
		}

		// Token: 0x06000DED RID: 3565 RVA: 0x00018908 File Offset: 0x00016B08
		public static implicit operator IMesh(IntPtr value)
		{
			return new IMesh
			{
				self = value
			};
		}

		// Token: 0x06000DEE RID: 3566 RVA: 0x00018926 File Offset: 0x00016B26
		public static bool operator ==(IMesh c1, IMesh c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000DEF RID: 3567 RVA: 0x00018939 File Offset: 0x00016B39
		public static bool operator !=(IMesh c1, IMesh c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000DF0 RID: 3568 RVA: 0x0001894C File Offset: 0x00016B4C
		public override bool Equals(object obj)
		{
			if (obj is IMesh)
			{
				IMesh c = (IMesh)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000DF1 RID: 3569 RVA: 0x00018976 File Offset: 0x00016B76
		internal IMesh(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000DF2 RID: 3570 RVA: 0x00018980 File Offset: 0x00016B80
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
			defaultInterpolatedStringHandler.AppendLiteral("IMesh ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x06000DF3 RID: 3571 RVA: 0x000189BB File Offset: 0x00016BBB
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x06000DF4 RID: 3572 RVA: 0x000189CD File Offset: 0x00016BCD
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000DF5 RID: 3573 RVA: 0x000189D8 File Offset: 0x00016BD8
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000DF6 RID: 3574 RVA: 0x000189EB File Offset: 0x00016BEB
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("IMesh was null when calling " + n);
			}
		}

		// Token: 0x06000DF7 RID: 3575 RVA: 0x00018A06 File Offset: 0x00016C06
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000DF8 RID: 3576 RVA: 0x00018A14 File Offset: 0x00016C14
		internal readonly void DestroyStrongHandle()
		{
			this.NullCheck("DestroyStrongHandle");
			method crende_DestroyStrongHandle = IMesh.__N.CRende_DestroyStrongHandle;
			calli(System.Void(System.IntPtr), this.self, crende_DestroyStrongHandle);
		}

		// Token: 0x06000DF9 RID: 3577 RVA: 0x00018A40 File Offset: 0x00016C40
		internal readonly bool IsStrongHandleValid()
		{
			this.NullCheck("IsStrongHandleValid");
			method crende_IsStrongHandleValid = IMesh.__N.CRende_IsStrongHandleValid;
			return calli(System.Int32(System.IntPtr), this.self, crende_IsStrongHandleValid) > 0;
		}

		// Token: 0x06000DFA RID: 3578 RVA: 0x00018A70 File Offset: 0x00016C70
		internal readonly bool IsStrongHandleLoaded()
		{
			this.NullCheck("IsStrongHandleLoaded");
			method crende_IsStrongHandleLoaded = IMesh.__N.CRende_IsStrongHandleLoaded;
			return calli(System.Int32(System.IntPtr), this.self, crende_IsStrongHandleLoaded) > 0;
		}

		// Token: 0x06000DFB RID: 3579 RVA: 0x00018AA0 File Offset: 0x00016CA0
		internal readonly IMesh CopyStrongHandle()
		{
			this.NullCheck("CopyStrongHandle");
			method crende_CopyStrongHandle = IMesh.__N.CRende_CopyStrongHandle;
			return calli(System.IntPtr(System.IntPtr), this.self, crende_CopyStrongHandle);
		}

		// Token: 0x06000DFC RID: 3580 RVA: 0x00018AD0 File Offset: 0x00016CD0
		internal readonly IntPtr GetBindingPtr()
		{
			this.NullCheck("GetBindingPtr");
			method crende_GetBindingPtr = IMesh.__N.CRende_GetBindingPtr;
			return calli(System.IntPtr(System.IntPtr), this.self, crende_GetBindingPtr);
		}

		// Token: 0x04000E3F RID: 3647
		internal IntPtr self;

		// Token: 0x0200038D RID: 909
		internal static class __N
		{
			// Token: 0x04001815 RID: 6165
			internal static method CRende_DestroyStrongHandle;

			// Token: 0x04001816 RID: 6166
			internal static method CRende_IsStrongHandleValid;

			// Token: 0x04001817 RID: 6167
			internal static method CRende_IsStrongHandleLoaded;

			// Token: 0x04001818 RID: 6168
			internal static method CRende_CopyStrongHandle;

			// Token: 0x04001819 RID: 6169
			internal static method CRende_GetBindingPtr;
		}
	}
}
