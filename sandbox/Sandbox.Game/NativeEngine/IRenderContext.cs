using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000022 RID: 34
	internal struct IRenderContext
	{
		// Token: 0x0600037B RID: 891 RVA: 0x00027EB0 File Offset: 0x000260B0
		public static implicit operator IntPtr(IRenderContext value)
		{
			return value.self;
		}

		// Token: 0x0600037C RID: 892 RVA: 0x00027EB8 File Offset: 0x000260B8
		public static implicit operator IRenderContext(IntPtr value)
		{
			return new IRenderContext
			{
				self = value
			};
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00027ED6 File Offset: 0x000260D6
		public static bool operator ==(IRenderContext c1, IRenderContext c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x00027EE9 File Offset: 0x000260E9
		public static bool operator !=(IRenderContext c1, IRenderContext c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600037F RID: 895 RVA: 0x00027EFC File Offset: 0x000260FC
		public override bool Equals(object obj)
		{
			if (obj is IRenderContext)
			{
				IRenderContext c = (IRenderContext)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000380 RID: 896 RVA: 0x00027F26 File Offset: 0x00026126
		internal IRenderContext(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000381 RID: 897 RVA: 0x00027F30 File Offset: 0x00026130
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
			defaultInterpolatedStringHandler.AppendLiteral("IRenderContext ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000382 RID: 898 RVA: 0x00027F6C File Offset: 0x0002616C
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000383 RID: 899 RVA: 0x00027F7E File Offset: 0x0002617E
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00027F89 File Offset: 0x00026189
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000385 RID: 901 RVA: 0x00027F9C File Offset: 0x0002619C
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("IRenderContext was null when calling " + n);
			}
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00027FB7 File Offset: 0x000261B7
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00027FC4 File Offset: 0x000261C4
		internal readonly void Draw(RenderPrimitiveType type, int nFirstVertex, int nVertexCount)
		{
			this.NullCheck("Draw");
			method irende_Draw = IRenderContext.__N.IRende_Draw;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32,System.Int32), this.self, (long)type, nFirstVertex, nVertexCount, irende_Draw);
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00027FF4 File Offset: 0x000261F4
		internal readonly void DrawInstanced(RenderPrimitiveType type, int nFirstVertex, int nVertexCountPerInstance, int nInstanceCount)
		{
			this.NullCheck("DrawInstanced");
			method irende_DrawInstanced = IRenderContext.__N.IRende_DrawInstanced;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32,System.Int32,System.Int32), this.self, (long)type, nFirstVertex, nVertexCountPerInstance, nInstanceCount, irende_DrawInstanced);
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00028024 File Offset: 0x00026224
		internal readonly void DrawIndexed(RenderPrimitiveType type, int nFirstIndex, int nIndexCount, int nMaxVertexCount, int nBaseVertex)
		{
			this.NullCheck("DrawIndexed");
			method irende_DrawIndexed = IRenderContext.__N.IRende_DrawIndexed;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32,System.Int32,System.Int32,System.Int32), this.self, (long)type, nFirstIndex, nIndexCount, nMaxVertexCount, nBaseVertex, irende_DrawIndexed);
		}

		// Token: 0x0600038A RID: 906 RVA: 0x00028058 File Offset: 0x00026258
		internal readonly void DrawIndexedInstanced(RenderPrimitiveType type, int nFirstIndex, int nIndexCountPerInstance, int nInstanceCount, int nMaxVertexCount, int nBaseVertex)
		{
			this.NullCheck("DrawIndexedInstanced");
			method irende_DrawIndexedInstanced = IRenderContext.__N.IRende_DrawIndexedInstanced;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), this.self, (long)type, nFirstIndex, nIndexCountPerInstance, nInstanceCount, nMaxVertexCount, nBaseVertex, irende_DrawIndexedInstanced);
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0002808C File Offset: 0x0002628C
		internal readonly void ResetMaterialStateHint()
		{
			this.NullCheck("ResetMaterialStateHint");
			method irende_ResetMaterialStateHint = IRenderContext.__N.IRende_ResetMaterialStateHint;
			calli(System.Void(System.IntPtr), this.self, irende_ResetMaterialStateHint);
		}

		// Token: 0x0600038C RID: 908 RVA: 0x000280B8 File Offset: 0x000262B8
		internal unsafe readonly bool BindVertexBuffer(int nSlot, DynamicVertexBufferHandle hVertexBuffer, int nOffset, int nStride, int nMaxVertexCount)
		{
			this.NullCheck("BindVertexBuffer");
			method irende_BindVertexBuffer = IRenderContext.__N.IRende_BindVertexBuffer;
			return calli(System.Int32(System.IntPtr,System.Int32,NativeEngine.DynamicVertexBufferHandle*,System.Int32,System.Int32,System.Int32), this.self, nSlot, &hVertexBuffer, nOffset, nStride, nMaxVertexCount, irende_BindVertexBuffer) > 0;
		}

		// Token: 0x0600038D RID: 909 RVA: 0x000280F0 File Offset: 0x000262F0
		internal unsafe readonly void BindTexture(int nTextureIndex, HRenderTexture hTexture, RenderTextureDimension nBindType, RenderShaderType nTargetPipelineStage, RenderColorSpace nColorSpace, RenderTextureDetail nRequiredMipSize)
		{
			this.NullCheck("BindTexture");
			method irende_BindTexture = IRenderContext.__N.IRende_BindTexture;
			calli(System.Void(System.IntPtr,System.Int32,NativeEngine.HRenderTexture*,System.Int64,System.Int64,System.Int64,System.Int64), this.self, nTextureIndex, &hTexture, (long)nBindType, (long)nTargetPipelineStage, (ulong)nColorSpace, (long)nRequiredMipSize, irende_BindTexture);
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0002812C File Offset: 0x0002632C
		internal readonly void SetSamplerStatePS(int nSamplerIndex, FilterMode eFilterMode, TextureAddressMode eUWrapMode, TextureAddressMode eVWrapMode, TextureAddressMode eWWrapMode, ComparisonMode eTextureComparisonMode)
		{
			this.NullCheck("SetSamplerStatePS");
			method irende_SetSamplerStatePS = IRenderContext.__N.IRende_SetSamplerStatePS;
			calli(System.Void(System.IntPtr,System.Int32,System.Int64,System.Int64,System.Int64,System.Int64,System.Int64), this.self, nSamplerIndex, (long)eFilterMode, (long)eUWrapMode, (long)eVWrapMode, (long)eWWrapMode, (ulong)eTextureComparisonMode, irende_SetSamplerStatePS);
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00028164 File Offset: 0x00026364
		internal unsafe readonly void SetScissorRect(NativeRect rect)
		{
			this.NullCheck("SetScissorRect");
			method irende_SetScissorRect = IRenderContext.__N.IRende_SetScissorRect;
			calli(System.Void(System.IntPtr,NativeRect*), this.self, &rect, irende_SetScissorRect);
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00028194 File Offset: 0x00026394
		internal readonly CRenderAttributes GetAttributesPtrForModify()
		{
			this.NullCheck("GetAttributesPtrForModify");
			method irende_GetAttributesPtrForModify = IRenderContext.__N.IRende_GetAttributesPtrForModify;
			return calli(System.IntPtr(System.IntPtr), this.self, irende_GetAttributesPtrForModify);
		}

		// Token: 0x06000391 RID: 913 RVA: 0x000281C4 File Offset: 0x000263C4
		internal readonly void FlipHandedness(bool bFlip)
		{
			this.NullCheck("FlipHandedness");
			method irende_FlipHandedness = IRenderContext.__N.IRende_FlipHandedness;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bFlip ? 1 : 0, irende_FlipHandedness);
		}

		// Token: 0x06000392 RID: 914 RVA: 0x000281F8 File Offset: 0x000263F8
		internal readonly void SetBlendMode(BlendMode eBlendMode)
		{
			this.NullCheck("SetBlendMode");
			method irende_SetBlendMode = IRenderContext.__N.IRende_SetBlendMode;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)eBlendMode, irende_SetBlendMode);
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00028224 File Offset: 0x00026424
		internal readonly void DispatchComputeShader(int nThreadCountX, int nThreadCountY, int nThreadCountZ)
		{
			this.NullCheck("DispatchComputeShader");
			method irende_DispatchComputeShader = IRenderContext.__N.IRende_DispatchComputeShader;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32,System.Int32), this.self, nThreadCountX, nThreadCountY, nThreadCountZ, irende_DispatchComputeShader);
		}

		// Token: 0x040000A0 RID: 160
		internal IntPtr self;

		// Token: 0x020001A7 RID: 423
		internal static class __N
		{
			// Token: 0x040009CE RID: 2510
			internal static method IRende_Draw;

			// Token: 0x040009CF RID: 2511
			internal static method IRende_DrawInstanced;

			// Token: 0x040009D0 RID: 2512
			internal static method IRende_DrawIndexed;

			// Token: 0x040009D1 RID: 2513
			internal static method IRende_DrawIndexedInstanced;

			// Token: 0x040009D2 RID: 2514
			internal static method IRende_ResetMaterialStateHint;

			// Token: 0x040009D3 RID: 2515
			internal static method IRende_BindVertexBuffer;

			// Token: 0x040009D4 RID: 2516
			internal static method IRende_BindTexture;

			// Token: 0x040009D5 RID: 2517
			internal static method IRende_SetSamplerStatePS;

			// Token: 0x040009D6 RID: 2518
			internal static method IRende_SetScissorRect;

			// Token: 0x040009D7 RID: 2519
			internal static method IRende_GetAttributesPtrForModify;

			// Token: 0x040009D8 RID: 2520
			internal static method IRende_FlipHandedness;

			// Token: 0x040009D9 RID: 2521
			internal static method IRende_SetBlendMode;

			// Token: 0x040009DA RID: 2522
			internal static method IRende_DispatchComputeShader;
		}
	}
}
