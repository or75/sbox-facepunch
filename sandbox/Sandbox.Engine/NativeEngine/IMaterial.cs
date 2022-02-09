using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200023F RID: 575
	internal struct IMaterial
	{
		// Token: 0x06000EA3 RID: 3747 RVA: 0x00019E46 File Offset: 0x00018046
		public static implicit operator IntPtr(IMaterial value)
		{
			return value.self;
		}

		// Token: 0x06000EA4 RID: 3748 RVA: 0x00019E50 File Offset: 0x00018050
		public static implicit operator IMaterial(IntPtr value)
		{
			return new IMaterial
			{
				self = value
			};
		}

		// Token: 0x06000EA5 RID: 3749 RVA: 0x00019E6E File Offset: 0x0001806E
		public static bool operator ==(IMaterial c1, IMaterial c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000EA6 RID: 3750 RVA: 0x00019E81 File Offset: 0x00018081
		public static bool operator !=(IMaterial c1, IMaterial c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000EA7 RID: 3751 RVA: 0x00019E94 File Offset: 0x00018094
		public override bool Equals(object obj)
		{
			if (obj is IMaterial)
			{
				IMaterial c = (IMaterial)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000EA8 RID: 3752 RVA: 0x00019EBE File Offset: 0x000180BE
		internal IMaterial(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000EA9 RID: 3753 RVA: 0x00019EC8 File Offset: 0x000180C8
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
			defaultInterpolatedStringHandler.AppendLiteral("IMaterial ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x06000EAA RID: 3754 RVA: 0x00019F04 File Offset: 0x00018104
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x06000EAB RID: 3755 RVA: 0x00019F16 File Offset: 0x00018116
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000EAC RID: 3756 RVA: 0x00019F21 File Offset: 0x00018121
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000EAD RID: 3757 RVA: 0x00019F34 File Offset: 0x00018134
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("IMaterial was null when calling " + n);
			}
		}

		// Token: 0x06000EAE RID: 3758 RVA: 0x00019F4F File Offset: 0x0001814F
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000EAF RID: 3759 RVA: 0x00019F5C File Offset: 0x0001815C
		internal readonly void DestroyStrongHandle()
		{
			this.NullCheck("DestroyStrongHandle");
			method imterl_DestroyStrongHandle = IMaterial.__N.IMterl_DestroyStrongHandle;
			calli(System.Void(System.IntPtr), this.self, imterl_DestroyStrongHandle);
		}

		// Token: 0x06000EB0 RID: 3760 RVA: 0x00019F88 File Offset: 0x00018188
		internal readonly bool IsStrongHandleValid()
		{
			this.NullCheck("IsStrongHandleValid");
			method imterl_IsStrongHandleValid = IMaterial.__N.IMterl_IsStrongHandleValid;
			return calli(System.Int32(System.IntPtr), this.self, imterl_IsStrongHandleValid) > 0;
		}

		// Token: 0x06000EB1 RID: 3761 RVA: 0x00019FB8 File Offset: 0x000181B8
		internal readonly bool IsStrongHandleLoaded()
		{
			this.NullCheck("IsStrongHandleLoaded");
			method imterl_IsStrongHandleLoaded = IMaterial.__N.IMterl_IsStrongHandleLoaded;
			return calli(System.Int32(System.IntPtr), this.self, imterl_IsStrongHandleLoaded) > 0;
		}

		// Token: 0x06000EB2 RID: 3762 RVA: 0x00019FE8 File Offset: 0x000181E8
		internal readonly IMaterial CopyStrongHandle()
		{
			this.NullCheck("CopyStrongHandle");
			method imterl_CopyStrongHandle = IMaterial.__N.IMterl_CopyStrongHandle;
			return calli(System.IntPtr(System.IntPtr), this.self, imterl_CopyStrongHandle);
		}

		// Token: 0x06000EB3 RID: 3763 RVA: 0x0001A018 File Offset: 0x00018218
		internal readonly IntPtr GetBindingPtr()
		{
			this.NullCheck("GetBindingPtr");
			method imterl_GetBindingPtr = IMaterial.__N.IMterl_GetBindingPtr;
			return calli(System.IntPtr(System.IntPtr), this.self, imterl_GetBindingPtr);
		}

		// Token: 0x06000EB4 RID: 3764 RVA: 0x0001A044 File Offset: 0x00018244
		internal readonly string GetName()
		{
			this.NullCheck("GetName");
			method imterl_GetName = IMaterial.__N.IMterl_GetName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, imterl_GetName));
		}

		// Token: 0x06000EB5 RID: 3765 RVA: 0x0001A074 File Offset: 0x00018274
		internal readonly string GetNameWithMod()
		{
			this.NullCheck("GetNameWithMod");
			method imterl_GetNameWithMod = IMaterial.__N.IMterl_GetNameWithMod;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, imterl_GetNameWithMod));
		}

		// Token: 0x06000EB6 RID: 3766 RVA: 0x0001A0A4 File Offset: 0x000182A4
		internal readonly ulong GetSimilarityKey()
		{
			this.NullCheck("GetSimilarityKey");
			method imterl_GetSimilarityKey = IMaterial.__N.IMterl_GetSimilarityKey;
			return calli(System.UInt64(System.IntPtr), this.self, imterl_GetSimilarityKey);
		}

		// Token: 0x06000EB7 RID: 3767 RVA: 0x0001A0D0 File Offset: 0x000182D0
		internal readonly bool IsLoaded()
		{
			this.NullCheck("IsLoaded");
			method imterl_IsLoaded = IMaterial.__N.IMterl_IsLoaded;
			return calli(System.Int32(System.IntPtr), this.self, imterl_IsLoaded) > 0;
		}

		// Token: 0x06000EB8 RID: 3768 RVA: 0x0001A100 File Offset: 0x00018300
		internal readonly bool OverrideTextureParamWithScopeGuard(string pParamName, ITexture hNewTex)
		{
			this.NullCheck("OverrideTextureParamWithScopeGuard");
			method imterl_OverrideTextureParamWithScopeGuard = IMaterial.__N.IMterl_OverrideTextureParamWithScopeGuard;
			return calli(System.Int32(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pParamName), hNewTex, imterl_OverrideTextureParamWithScopeGuard) > 0;
		}

		// Token: 0x06000EB9 RID: 3769 RVA: 0x0001A13C File Offset: 0x0001833C
		internal readonly void SetParamTexture(string none, ITexture value)
		{
			this.NullCheck("SetParamTexture");
			method imterl_SetParamTexture = IMaterial.__N.IMterl_SetParamTexture;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(none), value, imterl_SetParamTexture);
		}

		// Token: 0x04000E45 RID: 3653
		internal IntPtr self;

		// Token: 0x020003A4 RID: 932
		internal static class __N
		{
			// Token: 0x04001884 RID: 6276
			internal static method IMterl_DestroyStrongHandle;

			// Token: 0x04001885 RID: 6277
			internal static method IMterl_IsStrongHandleValid;

			// Token: 0x04001886 RID: 6278
			internal static method IMterl_IsStrongHandleLoaded;

			// Token: 0x04001887 RID: 6279
			internal static method IMterl_CopyStrongHandle;

			// Token: 0x04001888 RID: 6280
			internal static method IMterl_GetBindingPtr;

			// Token: 0x04001889 RID: 6281
			internal static method IMterl_GetName;

			// Token: 0x0400188A RID: 6282
			internal static method IMterl_GetNameWithMod;

			// Token: 0x0400188B RID: 6283
			internal static method IMterl_GetSimilarityKey;

			// Token: 0x0400188C RID: 6284
			internal static method IMterl_IsLoaded;

			// Token: 0x0400188D RID: 6285
			internal static method IMterl_OverrideTextureParamWithScopeGuard;

			// Token: 0x0400188E RID: 6286
			internal static method IMterl_SetParamTexture;
		}
	}
}
