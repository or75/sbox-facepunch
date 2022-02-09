using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000053 RID: 83
	internal struct ISceneView
	{
		// Token: 0x06000B4C RID: 2892 RVA: 0x0003BC7A File Offset: 0x00039E7A
		public static implicit operator IntPtr(ISceneView value)
		{
			return value.self;
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x0003BC84 File Offset: 0x00039E84
		public static implicit operator ISceneView(IntPtr value)
		{
			return new ISceneView
			{
				self = value
			};
		}

		// Token: 0x06000B4E RID: 2894 RVA: 0x0003BCA2 File Offset: 0x00039EA2
		public static bool operator ==(ISceneView c1, ISceneView c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x0003BCB5 File Offset: 0x00039EB5
		public static bool operator !=(ISceneView c1, ISceneView c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x0003BCC8 File Offset: 0x00039EC8
		public override bool Equals(object obj)
		{
			if (obj is ISceneView)
			{
				ISceneView c = (ISceneView)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x0003BCF2 File Offset: 0x00039EF2
		internal ISceneView(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x0003BCFC File Offset: 0x00039EFC
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
			defaultInterpolatedStringHandler.AppendLiteral("ISceneView ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000B53 RID: 2899 RVA: 0x0003BD38 File Offset: 0x00039F38
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000B54 RID: 2900 RVA: 0x0003BD4A File Offset: 0x00039F4A
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000B55 RID: 2901 RVA: 0x0003BD55 File Offset: 0x00039F55
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000B56 RID: 2902 RVA: 0x0003BD68 File Offset: 0x00039F68
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("ISceneView was null when calling " + n);
			}
		}

		// Token: 0x06000B57 RID: 2903 RVA: 0x0003BD83 File Offset: 0x00039F83
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000B58 RID: 2904 RVA: 0x0003BD90 File Offset: 0x00039F90
		internal readonly RenderViewport GetMainViewport()
		{
			this.NullCheck("GetMainViewport");
			method iscene_GetMainViewport = ISceneView.__N.IScene_GetMainViewport;
			return calli(NativeEngine.RenderViewport(System.IntPtr), this.self, iscene_GetMainViewport);
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x0003BDBC File Offset: 0x00039FBC
		internal readonly IntPtr GetSwapChain()
		{
			this.NullCheck("GetSwapChain");
			method iscene_GetSwapChain = ISceneView.__N.IScene_GetSwapChain;
			return calli(System.IntPtr(System.IntPtr), this.self, iscene_GetSwapChain);
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x0003BDE8 File Offset: 0x00039FE8
		internal readonly void AddDependentView(ISceneView pView, int nSlot)
		{
			this.NullCheck("AddDependentView");
			method iscene_AddDependentView = ISceneView.__N.IScene_AddDependentView;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, pView, nSlot, iscene_AddDependentView);
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x0003BE1C File Offset: 0x0003A01C
		internal readonly CRenderAttributes GetRenderAttributesPtr()
		{
			this.NullCheck("GetRenderAttributesPtr");
			method iscene_GetRenderAttributesPtr = ISceneView.__N.IScene_GetRenderAttributesPtr;
			return calli(System.IntPtr(System.IntPtr), this.self, iscene_GetRenderAttributesPtr);
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x0003BE4C File Offset: 0x0003A04C
		internal unsafe readonly ISceneLayer AddRenderLayer(string pszDebugName, RenderViewport viewport, string eShaderMode, ISceneLayer pAddBefore)
		{
			this.NullCheck("AddRenderLayer");
			method iscene_AddRenderLayer = ISceneView.__N.IScene_AddRenderLayer;
			return calli(System.IntPtr(System.IntPtr,System.IntPtr,NativeEngine.RenderViewport*,System.UInt32,System.IntPtr), this.self, Interop.GetPointer(pszDebugName), &viewport, StringToken.FindOrCreate(eShaderMode), pAddBefore, iscene_AddRenderLayer);
		}

		// Token: 0x06000B5D RID: 2909 RVA: 0x0003BE94 File Offset: 0x0003A094
		internal readonly void SetDefaultLayerObjectRequiredFlags(ESceneObjectFlags nFlags)
		{
			this.NullCheck("SetDefaultLayerObjectRequiredFlags");
			method iscene_SetDefaultLayerObjectRequiredFlags = ISceneView.__N.IScene_SetDefaultLayerObjectRequiredFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, nFlags, iscene_SetDefaultLayerObjectRequiredFlags);
		}

		// Token: 0x06000B5E RID: 2910 RVA: 0x0003BEC0 File Offset: 0x0003A0C0
		internal readonly void SetDefaultLayerObjectExcludedFlags(ESceneObjectFlags nFlags)
		{
			this.NullCheck("SetDefaultLayerObjectExcludedFlags");
			method iscene_SetDefaultLayerObjectExcludedFlags = ISceneView.__N.IScene_SetDefaultLayerObjectExcludedFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, nFlags, iscene_SetDefaultLayerObjectExcludedFlags);
		}

		// Token: 0x06000B5F RID: 2911 RVA: 0x0003BEEC File Offset: 0x0003A0EC
		internal readonly ESceneObjectFlags GetDefaultLayerObjectRequiredFlags()
		{
			this.NullCheck("GetDefaultLayerObjectRequiredFlags");
			method iscene_GetDefaultLayerObjectRequiredFlags = ISceneView.__N.IScene_GetDefaultLayerObjectRequiredFlags;
			return calli(System.Int64(System.IntPtr), this.self, iscene_GetDefaultLayerObjectRequiredFlags);
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x0003BF18 File Offset: 0x0003A118
		internal readonly ESceneObjectFlags GetDefaultLayerObjectExcludedFlags()
		{
			this.NullCheck("GetDefaultLayerObjectExcludedFlags");
			method iscene_GetDefaultLayerObjectExcludedFlags = ISceneView.__N.IScene_GetDefaultLayerObjectExcludedFlags;
			return calli(System.Int64(System.IntPtr), this.self, iscene_GetDefaultLayerObjectExcludedFlags);
		}

		// Token: 0x040000C1 RID: 193
		internal IntPtr self;

		// Token: 0x020001D8 RID: 472
		internal static class __N
		{
			// Token: 0x04001013 RID: 4115
			internal static method IScene_GetMainViewport;

			// Token: 0x04001014 RID: 4116
			internal static method IScene_GetSwapChain;

			// Token: 0x04001015 RID: 4117
			internal static method IScene_AddDependentView;

			// Token: 0x04001016 RID: 4118
			internal static method IScene_GetRenderAttributesPtr;

			// Token: 0x04001017 RID: 4119
			internal static method IScene_AddRenderLayer;

			// Token: 0x04001018 RID: 4120
			internal static method IScene_SetDefaultLayerObjectRequiredFlags;

			// Token: 0x04001019 RID: 4121
			internal static method IScene_SetDefaultLayerObjectExcludedFlags;

			// Token: 0x0400101A RID: 4122
			internal static method IScene_GetDefaultLayerObjectRequiredFlags;

			// Token: 0x0400101B RID: 4123
			internal static method IScene_GetDefaultLayerObjectExcludedFlags;
		}
	}
}
