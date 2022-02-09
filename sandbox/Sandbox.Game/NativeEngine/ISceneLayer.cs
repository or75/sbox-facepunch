using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000052 RID: 82
	internal struct ISceneLayer
	{
		// Token: 0x06000B36 RID: 2870 RVA: 0x0003B9BF File Offset: 0x00039BBF
		public static implicit operator IntPtr(ISceneLayer value)
		{
			return value.self;
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x0003B9C8 File Offset: 0x00039BC8
		public static implicit operator ISceneLayer(IntPtr value)
		{
			return new ISceneLayer
			{
				self = value
			};
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x0003B9E6 File Offset: 0x00039BE6
		public static bool operator ==(ISceneLayer c1, ISceneLayer c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x0003B9F9 File Offset: 0x00039BF9
		public static bool operator !=(ISceneLayer c1, ISceneLayer c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x0003BA0C File Offset: 0x00039C0C
		public override bool Equals(object obj)
		{
			if (obj is ISceneLayer)
			{
				ISceneLayer c = (ISceneLayer)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x0003BA36 File Offset: 0x00039C36
		internal ISceneLayer(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x0003BA40 File Offset: 0x00039C40
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
			defaultInterpolatedStringHandler.AppendLiteral("ISceneLayer ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000B3D RID: 2877 RVA: 0x0003BA7C File Offset: 0x00039C7C
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000B3E RID: 2878 RVA: 0x0003BA8E File Offset: 0x00039C8E
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x0003BA99 File Offset: 0x00039C99
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x0003BAAC File Offset: 0x00039CAC
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("ISceneLayer was null when calling " + n);
			}
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x0003BAC7 File Offset: 0x00039CC7
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x0003BAD4 File Offset: 0x00039CD4
		internal readonly void SetObjectMatchID(string nTok)
		{
			this.NullCheck("SetObjectMatchID");
			method iscene_SetObjectMatchID = ISceneLayer.__N.IScene_SetObjectMatchID;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nTok), iscene_SetObjectMatchID);
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x0003BB04 File Offset: 0x00039D04
		internal readonly string GetDebugName()
		{
			this.NullCheck("GetDebugName");
			method iscene_GetDebugName = ISceneLayer.__N.IScene_GetDebugName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, iscene_GetDebugName));
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x0003BB34 File Offset: 0x00039D34
		internal unsafe readonly void SetClearColor(Vector4 vecColor, int nRenderTargetIndex)
		{
			this.NullCheck("SetClearColor");
			method iscene_SetClearColor = ISceneLayer.__N.IScene_SetClearColor;
			calli(System.Void(System.IntPtr,Vector4*,System.Int32), this.self, &vecColor, nRenderTargetIndex, iscene_SetClearColor);
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x0003BB64 File Offset: 0x00039D64
		internal readonly ITexture GetTextureValue(string nTokenID, ITexture nDefaultValue)
		{
			this.NullCheck("GetTextureValue");
			method iscene_GetTextureValue = ISceneLayer.__N.IScene_GetTextureValue;
			return calli(System.IntPtr(System.IntPtr,System.UInt32,System.IntPtr), this.self, StringToken.FindOrCreate(nTokenID), nDefaultValue, iscene_GetTextureValue);
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x0003BBA0 File Offset: 0x00039DA0
		internal readonly ITexture GetTextureValue(string nTokenID)
		{
			this.NullCheck("GetTextureValue");
			method iscene_f = ISceneLayer.__N.IScene_f2;
			return calli(System.IntPtr(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nTokenID), iscene_f);
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x0003BBD8 File Offset: 0x00039DD8
		internal readonly RenderTargetDesc GetRenderTargetDesc()
		{
			this.NullCheck("GetRenderTargetDesc");
			method iscene_GetRenderTargetDesc = ISceneLayer.__N.IScene_GetRenderTargetDesc;
			return calli(NativeEngine.RenderTargetDesc(System.IntPtr), this.self, iscene_GetRenderTargetDesc);
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000B48 RID: 2888 RVA: 0x0003BC02 File Offset: 0x00039E02
		// (set) Token: 0x06000B49 RID: 2889 RVA: 0x0003BC20 File Offset: 0x00039E20
		internal SceneLayerType LayerEnum
		{
			get
			{
				this.NullCheck("LayerEnum");
				return (SceneLayerType)ISceneLayer.__N.Get__IScene_LayerEnum(this.self);
			}
			set
			{
				this.NullCheck("LayerEnum");
				ISceneLayer.__N.Set__IScene_LayerEnum(this.self, (long)value);
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000B4A RID: 2890 RVA: 0x0003BC3F File Offset: 0x00039E3F
		// (set) Token: 0x06000B4B RID: 2891 RVA: 0x0003BC5C File Offset: 0x00039E5C
		internal RenderViewport m_viewport
		{
			get
			{
				this.NullCheck("m_viewport");
				return ISceneLayer.__N.Get__IScene_m_viewport(this.self);
			}
			set
			{
				this.NullCheck("m_viewport");
				ISceneLayer.__N.Set__IScene_m_viewport(this.self, value);
			}
		}

		// Token: 0x040000C0 RID: 192
		internal IntPtr self;

		// Token: 0x020001D7 RID: 471
		internal static class __N
		{
			// Token: 0x04001009 RID: 4105
			internal static method IScene_SetObjectMatchID;

			// Token: 0x0400100A RID: 4106
			internal static method IScene_GetDebugName;

			// Token: 0x0400100B RID: 4107
			internal static method IScene_SetClearColor;

			// Token: 0x0400100C RID: 4108
			internal static method IScene_GetTextureValue;

			// Token: 0x0400100D RID: 4109
			internal static method IScene_f2;

			// Token: 0x0400100E RID: 4110
			internal static method IScene_GetRenderTargetDesc;

			// Token: 0x0400100F RID: 4111
			internal static ISceneLayer.__N._Get__IScene_LayerEnum Get__IScene_LayerEnum;

			// Token: 0x04001010 RID: 4112
			internal static ISceneLayer.__N._Set__IScene_LayerEnum Set__IScene_LayerEnum;

			// Token: 0x04001011 RID: 4113
			internal static ISceneLayer.__N._Get__IScene_m_viewport Get__IScene_m_viewport;

			// Token: 0x04001012 RID: 4114
			internal static ISceneLayer.__N._Set__IScene_m_viewport Set__IScene_m_viewport;

			// Token: 0x020002FD RID: 765
			// (Invoke) Token: 0x060020F0 RID: 8432
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate long _Get__IScene_LayerEnum(IntPtr self);

			// Token: 0x020002FE RID: 766
			// (Invoke) Token: 0x060020F4 RID: 8436
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__IScene_LayerEnum(IntPtr self, long val);

			// Token: 0x020002FF RID: 767
			// (Invoke) Token: 0x060020F8 RID: 8440
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate RenderViewport _Get__IScene_m_viewport(IntPtr self);

			// Token: 0x02000300 RID: 768
			// (Invoke) Token: 0x060020FC RID: 8444
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__IScene_m_viewport(IntPtr self, RenderViewport val);
		}
	}
}
