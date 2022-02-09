using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NativeEngine;
using NativeGlue;
using Sandbox;

namespace Managed.SandboxEngine
{
	// Token: 0x020001EE RID: 494
	internal static class NativeInterop
	{
		// Token: 0x06000C88 RID: 3208 RVA: 0x000125A8 File Offset: 0x000107A8
		private unsafe static void CheckStructSizes(int* struct_sizes)
		{
			string errors = "";
			int i = 0;
			if (234 != struct_sizes[i++])
			{
				errors += "Struct size header not found\n";
			}
			if (sizeof(BBox) != struct_sizes[i++])
			{
				string str = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(BBox));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tBBox \n");
				errors = str + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (4 != struct_sizes[i++])
			{
				string str2 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(4);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.ButtonCode \n");
				errors = str2 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(Color32) != struct_sizes[i++])
			{
				string str3 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(Color32));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tColor32 \n");
				errors = str3 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(Color24) != struct_sizes[i++])
			{
				string str4 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(Color24));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tColor24 \n");
				errors = str4 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (4 != struct_sizes[i++])
			{
				string str5 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(4);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.ColorFormat \n");
				errors = str5 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (4 != struct_sizes[i++])
			{
				string str6 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(4);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.CommandTarget \n");
				errors = str6 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (8 != struct_sizes[i++])
			{
				string str7 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(8);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.CommandFlags \n");
				errors = str7 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(CTextureDesc) != struct_sizes[i++])
			{
				string str8 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(CTextureDesc));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.CTextureDesc \n");
				errors = str8 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(Transform) != struct_sizes[i++])
			{
				string str9 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(Transform));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tTransform \n");
				errors = str9 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(VideoDisplayMode) != struct_sizes[i++])
			{
				string str10 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(VideoDisplayMode));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tSandbox.VideoDisplayMode \n");
				errors = str10 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (4 != struct_sizes[i++])
			{
				string str11 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(42, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(4);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tSandbox.NetworkDisconnectionReason \n");
				errors = str11 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (4 != struct_sizes[i++])
			{
				string str12 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(4);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tSandbox.GameLoopStage \n");
				errors = str12 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(HMaterial) != struct_sizes[i++])
			{
				string str13 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(HMaterial));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.HMaterial \n");
				errors = str13 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (4 != struct_sizes[i++])
			{
				string str14 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(4);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tSandbox.ImageFormat \n");
				errors = str14 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(IndexBufferHandle) != struct_sizes[i++])
			{
				string str15 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(IndexBufferHandle));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.IndexBufferHandle \n");
				errors = str15 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (4 != struct_sizes[i++])
			{
				string str16 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(39, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(4);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.InputCommandSource \n");
				errors = str16 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(InputEvent) != struct_sizes[i++])
			{
				string str17 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(InputEvent));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.InputEvent \n");
				errors = str17 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (4 != struct_sizes[i++])
			{
				string str18 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(4);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tSandbox.CursorType \n");
				errors = str18 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (4 != struct_sizes[i++])
			{
				string str19 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(4);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.LevelLoadingProgress \n");
				errors = str19 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(Angles) != struct_sizes[i++])
			{
				string str20 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(Angles));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tAngles \n");
				errors = str20 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(Rotation) != struct_sizes[i++])
			{
				string str21 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(Rotation));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tRotation \n");
				errors = str21 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(NativeRect) != struct_sizes[i++])
			{
				string str22 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(NativeRect));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeRect \n");
				errors = str22 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(Rect3D) != struct_sizes[i++])
			{
				string str23 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(Rect3D));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tRect3D \n");
				errors = str23 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (4 != struct_sizes[i++])
			{
				string str24 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(42, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(4);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.RenderMultisampleType \n");
				errors = str24 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (4 != struct_sizes[i++])
			{
				string str25 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(50, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(4);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.RenderSystemAssetFileLoadMode \n");
				errors = str25 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(Capsule) != struct_sizes[i++])
			{
				string str26 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(Capsule));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tCapsule \n");
				errors = str26 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(Vertex) != struct_sizes[i++])
			{
				string str27 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(Vertex));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tSandbox.Vertex \n");
				errors = str27 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (4 != struct_sizes[i++])
			{
				string str28 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(4);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.SwapChainBuffer \n");
				errors = str28 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(SwapChainHandle) != struct_sizes[i++])
			{
				string str29 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(SwapChainHandle));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.SwapChainHandle \n");
				errors = str29 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(TextureConfig) != struct_sizes[i++])
			{
				string str30 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(TextureConfig));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.TextureConfig \n");
				errors = str30 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(TextureBuilder) != struct_sizes[i++])
			{
				string str31 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(TextureBuilder));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tSandbox.TextureBuilder \n");
				errors = str31 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (4 != struct_sizes[i++])
			{
				string str32 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(4);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.TextureDecodingFlags \n");
				errors = str32 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (4 != struct_sizes[i++])
			{
				string str33 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(49, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(4);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.TextureOnDiskCompressionType \n");
				errors = str33 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (4 != struct_sizes[i++])
			{
				string str34 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(4);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.TextureScope \n");
				errors = str34 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (4 != struct_sizes[i++])
			{
				string str35 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(46, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(4);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.TextureSpecificationFlags \n");
				errors = str35 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (4 != struct_sizes[i++])
			{
				string str36 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(4);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.TextureUsage \n");
				errors = str36 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(Vector3) != struct_sizes[i++])
			{
				string str37 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(Vector3));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tVector3 \n");
				errors = str37 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(Vector2) != struct_sizes[i++])
			{
				string str38 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(Vector2));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tVector2 \n");
				errors = str38 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(Vector4) != struct_sizes[i++])
			{
				string str39 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(Vector4));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tVector4 \n");
				errors = str39 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(VertexBufferHandle) != struct_sizes[i++])
			{
				string str40 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(39, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(VertexBufferHandle));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.VertexBufferHandle \n");
				errors = str40 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(VertexField) != struct_sizes[i++])
			{
				string str41 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(VertexField));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tNativeEngine.VertexField \n");
				errors = str41 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (sizeof(Matrix) != struct_sizes[i++])
			{
				string str42 = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(Matrix));
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tMatrix \n");
				errors = str42 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (42 != struct_sizes[i++])
			{
				errors += "Struct size footer not found\n";
			}
			if (!string.IsNullOrEmpty(errors))
			{
				throw new Exception("Data structure size doesn't match:\n\n" + errors.Trim());
			}
		}

		// Token: 0x06000C89 RID: 3209 RVA: 0x00013718 File Offset: 0x00011918
		internal unsafe static void Initialize(int hash, IntPtr* exported, int* struct_sizes, IntPtr* imported)
		{
			int i = 0;
			NativeInterop._ErrorFunction onError = Marshal.GetDelegateForFunctionPointer<NativeInterop._ErrorFunction>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
			try
			{
				if (hash != 64084)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Hash doesn't match ( ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(hash);
					defaultInterpolatedStringHandler.AppendLiteral(" != 64084 )");
					throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				NativeInterop.CheckStructSizes(struct_sizes);
				CEntityClass.__N.CEntty_OnRegister = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CEntityClass.__N.CEntty_GetBaseClass = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CEntityClass.__N.CEntty_GetFlags = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CEntityClass.__N.CEntty_GetNameAsCStr = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CEntityClass.__N.CEntty_GetCPPClassName = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CEntityClass.__N.CEntty_ClassMatches = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_DestroyStrongHandle = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_IsStrongHandleValid = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_IsStrongHandleLoaded = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_CopyStrongHandle = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_GetBindingPtr = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_GetModelName = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_IsTranslucent = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_IsTranslucentTwoPass = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_HasPhysics = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_HasCloth = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_FindModelSubKey = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_GetAttachmentTransform = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_GetNumAttachments = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_GetAttachmentNameFromIndex = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_GetBodyPartForName = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_GetBodyPartName = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_GetNumBodyParts = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_GetNumBodyPartMeshes = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_GetBodyPartMask = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_GetBodyPartMeshMask = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_FindMeshIndexForMask = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_GetNumMeshes = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_GetMeshBounds = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_GetPhysicsBounds = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_GetModelRenderBounds = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_NumBones = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_boneName = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_boneParent = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_bonePosParentSpace = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IModel.__N.CModel_boneRotParentSpace = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				NetworkGameClient.__N.CNetwr_SetManaged = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				NetworkGameClient.__N.CNetwr_FinishSignonState_New = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				NetworkGameClient.__N.CNetwr_SendCustomMessage = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ConCommand.__N.From_ConCommandBase_To_ConCommand = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ConCommand.__N.To_ConCommandBase_From_ConCommand = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ConCommand.__N.CnCmmn_CanAutoComplete = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ConCommand.__N.CnCmmn_AutoCompleteSuggest = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ConCommand.__N.CnCmmn_IsCommand = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ConCommand.__N.CnCmmn_GetName = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ConCommand.__N.CnCmmn_GetHelpText = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ConCommand.__N.CnCmmn_IsFlagSet = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ConCommandBase.__N.CnCmmn_f2 = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ConCommandBase.__N.CnCmmn_f3 = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ConCommandBase.__N.CnCmmn_f4 = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ConCommandBase.__N.CnCmmn_f5 = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				NativeEngine.ConVar.__N.From_ConCommandBase_To_ConVar = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				NativeEngine.ConVar.__N.To_ConCommandBase_From_ConVar = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				NativeEngine.ConVar.__N.ConVar_GetFloat = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				NativeEngine.ConVar.__N.ConVar_GetInt = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				NativeEngine.ConVar.__N.ConVar_GetColor = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				NativeEngine.ConVar.__N.ConVar_GetBool = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				NativeEngine.ConVar.__N.ConVar_GetString = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				NativeEngine.ConVar.__N.ConVar_SetValue = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				NativeEngine.ConVar.__N.ConVar_Revert = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				NativeEngine.ConVar.__N.ConVar_IsCommand = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				NativeEngine.ConVar.__N.ConVar_GetName = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				NativeEngine.ConVar.__N.ConVar_GetHelpText = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				NativeEngine.ConVar.__N.ConVar_IsFlagSet = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CPhysSurfaceProperties.__N.CPhysS_UpdatePhysics = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CPhysSurfaceProperties.__N.CPhysS_UpdateSounds = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CPhysSurfaceProperties.__N.Get__CPhysS_m_name = Marshal.GetDelegateForFunctionPointer<CPhysSurfaceProperties.__N._Get__CPhysS_m_name>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
				CPhysSurfaceProperties.__N.Set__CPhysS_m_name = Marshal.GetDelegateForFunctionPointer<CPhysSurfaceProperties.__N._Set__CPhysS_m_name>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
				CPhysSurfaceProperties.__N.Get__CPhysS_m_nameHash = Marshal.GetDelegateForFunctionPointer<CPhysSurfaceProperties.__N._Get__CPhysS_m_nameHash>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
				CPhysSurfaceProperties.__N.Set__CPhysS_m_nameHash = Marshal.GetDelegateForFunctionPointer<CPhysSurfaceProperties.__N._Set__CPhysS_m_nameHash>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
				CPhysSurfaceProperties.__N.Get__CPhysS_m_baseNameHash = Marshal.GetDelegateForFunctionPointer<CPhysSurfaceProperties.__N._Get__CPhysS_m_baseNameHash>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
				CPhysSurfaceProperties.__N.Set__CPhysS_m_baseNameHash = Marshal.GetDelegateForFunctionPointer<CPhysSurfaceProperties.__N._Set__CPhysS_m_baseNameHash>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
				CPhysSurfaceProperties.__N.Get__CPhysS_m_nIndex = Marshal.GetDelegateForFunctionPointer<CPhysSurfaceProperties.__N._Get__CPhysS_m_nIndex>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
				CPhysSurfaceProperties.__N.Set__CPhysS_m_nIndex = Marshal.GetDelegateForFunctionPointer<CPhysSurfaceProperties.__N._Set__CPhysS_m_nIndex>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
				CPhysSurfaceProperties.__N.Get__CPhysS_m_nBaseIndex = Marshal.GetDelegateForFunctionPointer<CPhysSurfaceProperties.__N._Get__CPhysS_m_nBaseIndex>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
				CPhysSurfaceProperties.__N.Set__CPhysS_m_nBaseIndex = Marshal.GetDelegateForFunctionPointer<CPhysSurfaceProperties.__N._Set__CPhysS_m_nBaseIndex>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
				CPhysSurfaceProperties.__N.Get__CPhysS_m_bHidden = Marshal.GetDelegateForFunctionPointer<CPhysSurfaceProperties.__N._Get__CPhysS_m_bHidden>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
				CPhysSurfaceProperties.__N.Set__CPhysS_m_bHidden = Marshal.GetDelegateForFunctionPointer<CPhysSurfaceProperties.__N._Set__CPhysS_m_bHidden>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
				CPhysSurfaceProperties.__N.Get__CPhysS_m_description = Marshal.GetDelegateForFunctionPointer<CPhysSurfaceProperties.__N._Get__CPhysS_m_description>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
				CPhysSurfaceProperties.__N.Set__CPhysS_m_description = Marshal.GetDelegateForFunctionPointer<CPhysSurfaceProperties.__N._Set__CPhysS_m_description>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
				IMesh.__N.CRende_DestroyStrongHandle = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IMesh.__N.CRende_IsStrongHandleValid = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IMesh.__N.CRende_IsStrongHandleLoaded = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IMesh.__N.CRende_CopyStrongHandle = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IMesh.__N.CRende_GetBindingPtr = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ServerSideClient.__N.CServe_SetManaged = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ServerSideClient.__N.CServe_SendCustomMessage = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ServerSideClient.__N.CServe_GetPlayerSlot = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ServerSideClient.__N.CServe_GetClientName = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ServerSideClient.__N.CServe_GetUserId = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ServerSideClient.__N.CServe_PendingReliable = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ServerSideClient.__N.CServe_Disconnect = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ITexture.__N.CTextr_DestroyStrongHandle = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ITexture.__N.CTextr_IsStrongHandleValid = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ITexture.__N.CTextr_IsStrongHandleLoaded = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ITexture.__N.CTextr_CopyStrongHandle = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ITexture.__N.CTextr_GetBindingPtr = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CUtlString.__N.CUtlSt_Get = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CUtlString.__N.CUtlSt_Clear = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CUtlString.__N.CUtlSt_Length = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CUtlString.__N.CUtlSt_IsEmpty = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CUtlVectorString.__N.CUtlVe_DeleteThis = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CUtlVectorString.__N.CUtlVe_Create = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CUtlVectorString.__N.CUtlVe_Count = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CUtlVectorString.__N.CUtlVe_Element = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				EngineGlue.__N.EngneG_JsonToKeyValues3 = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				EngineGlue.__N.EngneG_KeyValues3ToJson = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				EngineGlue.__N.EngneG_LoadKeyValues3 = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				EngineGlue.__N.EngneG_GetStringToken = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				EngineGlue.__N.EngneG_SendClientUserInfo = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				EngineGlue.__N.EngneG_IsListenServer = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				EngineGlue.__N.EngneG_GetConvarValue = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				EngineGlue.__N.EngneG_GetConvarValueFloat = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				EngineGlue.__N.EngneG_SetConvarValue = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				EngineGlue.__N.EngneG_AddSearchPath = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				EngineGlue.__N.EngneG_RemoveSearchPath = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ICVar.__N.g_pCVa_AllocateDLLIdentifier = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ICVar.__N.g_pCVa_RegisterConCommand = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ICVar.__N.g_pCVa_UnregisterConCommand = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ICVar.__N.g_pCVa_UnregisterConCommands = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ICVar.__N.g_pCVa_GetCommandLineValue = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ICVar.__N.g_pCVa_FindCommandBase = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				FullFileSystem.__N.gpFllF_GetSymLink = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				FullFileSystem.__N.gpFllF_AddSymLink = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				FullFileSystem.__N.gpFllF_ClearSymLinks = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				FullFileSystem.__N.gpFllF_AddAddonsSearchPaths = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				GameUIService.__N.gpGmeU_EnableUIMouse = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				GameUIService.__N.gpGmeU_SetCursor = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				HostStateMgr.__N.gpHstS_RequestHS_Quit = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				HostStateMgr.__N.gpHstS_RequestHS_Idle = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				InputService.__N.gpInpt_InsertCommand = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				InputService.__N.gpInpt_IsAppActive = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				InputService.__N.gpInpt_HasMouseFocus = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				InputService.__N.gpInpt_GetFrameCount = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				InputService.__N.gpInpt_Key_NameForBinding = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				InputService.__N.gpInpt_GetBinding = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				InputSystem.__N.gpInpt_GetCursorPosition = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				InputSystem.__N.gpInpt_SetCursorPosition = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				InputSystem.__N.gpInpt_f2 = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				InputSystem.__N.gpInpt_f3 = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				InputSystem.__N.gpInpt_IsIMEAllowed = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				InputSystem.__N.gpInpt_SetIMEAllowed = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				InputSystem.__N.gpInpt_SetIMETextLocation = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				InputSystem.__N.gpInpt_DismissIME = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				InputSystem.__N.gpInpt_GetIMEComposition = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				InputSystem.__N.gpInpt_CodeToString = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				InputSystem.__N.gpInpt_StringToButtonCode = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MaterialSystem2.__N.gpMter_CreateRawMaterial = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MaterialSystem2.__N.gpMter_CreateProceduralMaterialCopy = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MaterialSystem2.__N.gpMter_FindOrCreateMaterialFromResource = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				RenderDevice.__N.gpRend_FindOrCreateFileTexture = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				RenderDevice.__N.gpRend_FindOrCreateTexture2 = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				RenderDevice.__N.gpRend_AsyncSetTextureData2 = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				RenderDevice.__N.gpRend_GetSwapChainTexture = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				RenderDevice.__N.gpRend_GetTextureDesc = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				RenderDevice.__N.gpRend_GetOnDiskTextureDesc = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				RenderDevice.__N.gpRend_GetTextureMultisampleType = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				RenderService.__N.gpRend_GetMultisampleType = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				SoundEventManager.__N.gpSndO_IsValidSoundEventName = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				SoundEventManager.__N.gpSndO_IsSoundEventInLibrary = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				SoundEventManager.__N.gpSndO_AddSoundEvent = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				SoundEventManager.__N.gpSndO_AddSoundEvents = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				SoundSystem.__N.gpSndS_AddVOIPData = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				SoundSystem.__N.gpSndS_IsVoiceEnabled = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				SoundSystem.__N.gpSndS_IsVoiceLoopbackEnabled = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				VPhysics2.__N.gpVPhy_NumWorlds = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				VPhysics2.__N.gpVPhy_IsMultiThreaded = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				VPhysics2.__N.gpVPhy_SetMultiThreaded = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				VPhysics2.__N.gpVPhy_GetSurfacePropertyController = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				EngineGlobal.__N.global_Plat_ScreenToWindowCoords = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				EngineGlobal.__N.global_Plat_WindowToScreenCoords = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				EngineGlobal.__N.global_Plat_MessageBox = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				EngineGlobal.__N.global_SPROF_ENTER_SCOPE = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				EngineGlobal.__N.global_SPROF_EXIT_SCOPE = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				EngineGlobal.__N.Get__global_g_pNetworkClientService = Marshal.GetDelegateForFunctionPointer<EngineGlobal.__N._Get__global_g_pNetworkClientService>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
				EngineGlobal.__N.Set__global_g_pNetworkClientService = Marshal.GetDelegateForFunctionPointer<EngineGlobal.__N._Set__global_g_pNetworkClientService>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
				Mathlib.__N.glblMt_ImprovedPerlinNoise = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				Mathlib.__N.glblMt_SparseConvolutionNoise = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				Mathlib.__N.glblMt_SparseConvolutionNoiseNormalized = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				Mathlib.__N.glblMt_FractalNoise = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				Mathlib.__N.glblMt_Turbulence = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				RenderDeviceManager.__N.Glue_Render_GetConfigInt = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				RenderDeviceManager.__N.Glue_Render_SetConfigInt = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				RenderDeviceManager.__N.Glue_Render_WriteVideoConfig = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				RenderDeviceManager.__N.Glue_Render_ResetVideoConfig = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				RenderDeviceManager.__N.Glue_Render_ChangeVideoMode = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				RenderDeviceManager.__N.Glue_Render_GetDisplayModes = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				Resources.__N.Glue_Resrce_LoadResource = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				Resources.__N.Glue_Resrce_ReleaseCached = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				Resources.__N.Glue_Resrce_GetMaterial = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				Resources.__N.Glue_Resrce_GetTexture = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				Resources.__N.Glue_Resrce_GetModel = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				Resources.__N.Glue_Resrce_EnsureResourceInManifest = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAsyncResourceDataRequest.__N.IAsync_GetFileName = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAsyncResourceDataRequest.__N.IAsync_GetResultBuffer = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAsyncResourceDataRequest.__N.IAsync_GetResultBufferSize = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ImageLoader.__N.ImgeLd_GetMemRequired = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IMaterial.__N.IMterl_DestroyStrongHandle = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IMaterial.__N.IMterl_IsStrongHandleValid = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IMaterial.__N.IMterl_IsStrongHandleLoaded = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IMaterial.__N.IMterl_CopyStrongHandle = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IMaterial.__N.IMterl_GetBindingPtr = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IMaterial.__N.IMterl_GetName = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IMaterial.__N.IMterl_GetNameWithMod = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IMaterial.__N.IMterl_GetSimilarityKey = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IMaterial.__N.IMterl_IsLoaded = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IMaterial.__N.IMterl_OverrideTextureParamWithScopeGuard = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IMaterial.__N.IMterl_SetParamTexture = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				INetworkClientService.__N.INetwr_IsActiveInGame = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				INetworkClientService.__N.INetwr_IsConnected = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				INetworkClientService.__N.INetwr_IsMultiplayer = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				INetworkClientService.__N.INetwr_IsPaused = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				INetworkClientService.__N.INetwr_IsDisconnecting = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				INetworkClientService.__N.INetwr_GetDisconnectReason = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				INetworkClientService.__N.INetwr_SendStringCmd = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IParticleCollection.__N.IPrtcl_SetRenderingEnabled = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IParticleCollection.__N.IPrtcl_GetRenderingEnabled = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IParticleCollection.__N.IPrtcl_IsControlPointSet = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IParticleCollection.__N.IPrtcl_GetControlPointPosition = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IPhysSurfacePropertyController.__N.IPhysS_GetSurfacePropCount = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IPhysSurfacePropertyController.__N.IPhysS_GetSurfaceProperty = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IPhysSurfacePropertyController.__N.IPhysS_AddProperty = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ResourceDataUtils.__N.IRDReg_SetDataRegistrationFailed = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ResourceDataUtils.__N.IRDReg_IsReloading = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ResourceDataUtils.__N.IRDReg_SetFinalResourceData = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ResourceDataUtils.__N.IRDReg_GetDataRegistrationFailed = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ResourceDataUtils.__N.IRDReg_GetFinalResourceData = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				ResourceDataUtils.__N.IRDReg_GetResultBufferSize = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				KeyValues3.__N.KeyVle_DeleteThis = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				KeyValues3.__N.KeyVle_Create = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				KeyValues3.__N.KeyVle_IsArray = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				KeyValues3.__N.KeyVle_IsTable = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				KeyValues3.__N.KeyVle_SetValueBool = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				KeyValues3.__N.KeyVle_SetValueString = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				KeyValues3.__N.KeyVle_SetValueResourceString = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				KeyValues3.__N.KeyVle_SetValueInt = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				KeyValues3.__N.KeyVle_SetValueFloat = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				KeyValues3.__N.KeyVle_SetMemberString = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				KeyValues3.__N.KeyVle_SetMemberInt = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				KeyValues3.__N.KeyVle_SetMemberFloat = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				KeyValues3.__N.KeyVle_GetMemberString = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				KeyValues3.__N.KeyVle_SetToEmptyArray = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				KeyValues3.__N.KeyVle_GetArrayLength = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				KeyValues3.__N.KeyVle_ArrayAddToTail = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				KeyValues3.__N.KeyVle_GetArrayElement = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				KeyValues3.__N.KeyVle_SetToEmptyTable = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_CreateRenderMesh = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_CreateModel = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_CreateModel2 = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_CreateRawModel = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_GetModelNumVertices = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_GetModelVertices = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_GetModelNumIndices = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_GetModelIndices = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_SetMeshMaterial = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_SetMeshPrimType = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_SetMeshBounds = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_SetMeshVertexRange = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_SetMeshIndexRange = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_SetMeshVertexBuffer = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_SetMeshIndexBuffer = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_CreateVertexBuffer = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_CreateIndexBuffer = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_DestroyVertexBuffer = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_DestroyIndexBuffer = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_LockVertexBuffer = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_UnlockVertexBuffer = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_LockIndexBuffer = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_UnlockIndexBuffer = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_SetVertexBufferData = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_SetIndexBufferData = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_SetVertexBufferSize = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				MeshGlue.__N.MeshGl_SetIndexBufferSize = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				Console.__N.NtveEn_Consol_GetAll = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				Console.__N.NtveEn_Consol_AutoComplete = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				WindowsGlue.__N.WndwsG_FindFile = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				i = 0;
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(SandboEngine_Btstrp_PreInit);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(SandboEngine_Btstrp_Init);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_EnterMainMenu);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_LeaveMainMenu);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_EnterGame);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_LeaveGame);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_ShowGameUI);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_HideGameUI);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_FrameStart);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_FrameEnd);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_FrameStage);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_PreInput);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_PostInput);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_InitNetworkGameClient);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_InitServerSideClient);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_StartConnecting);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_UpdateProgressBar);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_HandleInputEvent);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_ConvarFromClient);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_SimulateUI);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_Print);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_LoadStart);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_LoadLoop);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_HideLoadingPlaque);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_ResolveMapName);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_ClientDisconnect);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_EngneL_Exiting);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_INetwr_Shutdown);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_INetwr_OnFullConnect);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_INetwr_OnNet);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_INetwr_ProcessServerInfo);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_INetwr_SignOnState_New);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_INetwr_SignOnState_Full);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_INetwr_Tick);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_INetwr_f2);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_INetwr_f3);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_INetwr_f4);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_INetwr_FillServerInfo);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_RelTme_Update);
			}
			catch (Exception ___e)
			{
				onError(___e.Message + "\n\n" + ___e.StackTrace);
			}
		}

		// Token: 0x02000383 RID: 899
		// (Invoke) Token: 0x06001693 RID: 5779
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void _ErrorFunction(string message);
	}
}
