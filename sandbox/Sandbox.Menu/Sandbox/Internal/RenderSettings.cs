using System;
using System.Runtime.CompilerServices;
using NativeEngine;

namespace Sandbox.Internal
{
	// Token: 0x02000010 RID: 16
	public static class RenderSettings
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00003491 File Offset: 0x00001691
		// (set) Token: 0x06000048 RID: 72 RVA: 0x000034A2 File Offset: 0x000016A2
		public static int ResolutionWidth
		{
			get
			{
				return RenderSettings.GetInt("setting.defaultres", 1920);
			}
			set
			{
				RenderSettings.SetInt("setting.defaultres", value);
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000049 RID: 73 RVA: 0x000034AF File Offset: 0x000016AF
		// (set) Token: 0x0600004A RID: 74 RVA: 0x000034C0 File Offset: 0x000016C0
		public static int ResolutionHeight
		{
			get
			{
				return RenderSettings.GetInt("setting.defaultresheight", 1080);
			}
			set
			{
				RenderSettings.SetInt("setting.defaultresheight", value);
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600004B RID: 75 RVA: 0x000034CD File Offset: 0x000016CD
		// (set) Token: 0x0600004C RID: 76 RVA: 0x000034DD File Offset: 0x000016DD
		public static bool Fullscreen
		{
			get
			{
				return RenderSettings.GetInt("setting.fullscreen", 1) != 0;
			}
			set
			{
				RenderSettings.SetInt("setting.fullscreen", value ? 1 : 0);
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600004D RID: 77 RVA: 0x000034F0 File Offset: 0x000016F0
		// (set) Token: 0x0600004E RID: 78 RVA: 0x00003500 File Offset: 0x00001700
		public static bool Borderless
		{
			get
			{
				return RenderSettings.GetInt("setting.nowindowborder", 1) != 0;
			}
			set
			{
				RenderSettings.SetInt("setting.nowindowborder", value ? 1 : 0);
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00003513 File Offset: 0x00001713
		// (set) Token: 0x06000050 RID: 80 RVA: 0x00003523 File Offset: 0x00001723
		public static bool VSync
		{
			get
			{
				return RenderSettings.GetInt("setting.mat_vsync", 1) != 0;
			}
			set
			{
				RenderSettings.SetInt("setting.mat_vsync", value ? 1 : 0);
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00003536 File Offset: 0x00001736
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00003548 File Offset: 0x00001748
		public static int TextureFiltering
		{
			get
			{
				return int.Parse(ConsoleSystem.GetValue("r_texturefilteringquality", null));
			}
			set
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r_texturefilteringquality ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				ConsoleSystem.Run(defaultInterpolatedStringHandler.ToStringAndClear());
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000053 RID: 83 RVA: 0x0000357F File Offset: 0x0000177F
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00003594 File Offset: 0x00001794
		public static int MaxFrameRate
		{
			get
			{
				return int.Parse(ConsoleSystem.GetValue("fps_max", null));
			}
			set
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
				defaultInterpolatedStringHandler.AppendLiteral("fps_max ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				ConsoleSystem.Run(defaultInterpolatedStringHandler.ToStringAndClear());
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000035CC File Offset: 0x000017CC
		public static int GetInt(string name, int defaultValue)
		{
			Host.AssertMenu("GetInt");
			int v = RenderDeviceManager.GetConfigInt(name);
			if (v != -1)
			{
				return v;
			}
			return defaultValue;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000035F1 File Offset: 0x000017F1
		public static void SetInt(string name, int value)
		{
			Host.AssertMenu("SetInt");
			RenderDeviceManager.SetConfigInt(name, value);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003604 File Offset: 0x00001804
		public static void Apply()
		{
			Host.AssertMenu("Apply");
			if (!GlobalGameNamespace.Global.IsToolsMode)
			{
				RenderDeviceManager.ChangeVideoMode(RenderSettings.Fullscreen, RenderSettings.Borderless, RenderSettings.VSync, RenderSettings.ResolutionWidth, RenderSettings.ResolutionHeight);
			}
			RenderDeviceManager.WriteVideoConfig();
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003640 File Offset: 0x00001840
		public static VideoDisplayMode[] DisplayModes(bool windowed)
		{
			Host.AssertMenu("DisplayModes");
			VideoDisplayMode[] modes = new VideoDisplayMode[1024];
			int c = RenderDeviceManager.GetDisplayModes(modes, modes.Length, windowed);
			Array.Resize<VideoDisplayMode>(ref modes, c);
			return modes;
		}
	}
}
