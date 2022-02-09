using System;
using System.Collections.Generic;
using System.Diagnostics;
using NativeEngine;
using Sandbox;
using Sandbox.DataModel;
using Sandbox.Engine;

namespace Tools
{
	// Token: 0x020000D3 RID: 211
	public static class Utility
	{
		// Token: 0x060017AE RID: 6062 RVA: 0x0005B82C File Offset: 0x00059A2C
		public static void OpenCode(string filename, int line)
		{
			CodeEditor.OpenSolution(filename, line);
		}

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060017AF RID: 6063 RVA: 0x0005B838 File Offset: 0x00059A38
		// (remove) Token: 0x060017B0 RID: 6064 RVA: 0x0005B86C File Offset: 0x00059A6C
		public static event Action<object> OnInspect;

		// Token: 0x060017B1 RID: 6065 RVA: 0x0005B89F File Offset: 0x00059A9F
		public static void Inspect(object o)
		{
			Action<object> onInspect = Utility.OnInspect;
			if (onInspect == null)
			{
				return;
			}
			onInspect(o);
		}

		// Token: 0x060017B2 RID: 6066 RVA: 0x0005B8B1 File Offset: 0x00059AB1
		public static void RunCommand(string command)
		{
			InputService.InsertCommand(InputCommandSource.ICS_CONSOLE, command + "\n", 0, 0);
		}

		// Token: 0x060017B3 RID: 6067 RVA: 0x0005B8C6 File Offset: 0x00059AC6
		public static void OpenFolder(string path)
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = path,
				UseShellExecute = true,
				Verb = "open"
			});
		}

		// Token: 0x0200015E RID: 350
		public static class Addons
		{
			// Token: 0x06001852 RID: 6226 RVA: 0x0005C655 File Offset: 0x0005A855
			public static IReadOnlyList<LocalAddon> GetAll()
			{
				return LocalAddon.All.AsReadOnly();
			}

			// Token: 0x06001853 RID: 6227 RVA: 0x0005C664 File Offset: 0x0005A864
			public static LocalAddon TryAddFromFile(string addonFilePath)
			{
				LocalAddon localAddon = LocalAddon.AddFromFile(addonFilePath);
				bool? flag;
				if (localAddon == null)
				{
					flag = null;
				}
				else
				{
					AddonConfig config = localAddon.Config;
					flag = ((config != null) ? new bool?(config.HasAssets) : null);
				}
				bool? flag2 = flag;
				if (flag2.GetValueOrDefault())
				{
					Utility.Addons.UpdateAssetPaths();
				}
				Event.Run("localaddons.changed");
				IMenuDll menuDll = IMenuDll.Current;
				if (menuDll == null)
				{
					return localAddon;
				}
				menuDll.RunEvent("localaddons.changed");
				return localAddon;
			}

			// Token: 0x06001854 RID: 6228 RVA: 0x0005C6D2 File Offset: 0x0005A8D2
			public static void UpdateAssetPaths()
			{
				FullFileSystem.AddAddonsSearchPaths(true);
			}

			// Token: 0x06001855 RID: 6229 RVA: 0x0005C6DA File Offset: 0x0005A8DA
			public static void Remove(LocalAddon addon)
			{
				AddonConfig config = addon.Config;
				bool flag = config != null && config.HasAssets;
				LocalAddon.Remove(addon);
				if (flag)
				{
					Utility.Addons.UpdateAssetPaths();
				}
				Event.Run("localaddons.changed");
				IMenuDll menuDll = IMenuDll.Current;
				if (menuDll == null)
				{
					return;
				}
				menuDll.RunEvent("localaddons.changed");
			}

			// Token: 0x06001856 RID: 6230 RVA: 0x0005C719 File Offset: 0x0005A919
			public static void Updated(LocalAddon addon, bool paths)
			{
				LocalAddon.SaveAll();
				LocalAddon.Initialize();
				if (paths)
				{
					Utility.Addons.UpdateAssetPaths();
				}
				IAssetSystem.UpdateMods();
				Event.Run("localaddons.changed");
				IMenuDll menuDll = IMenuDll.Current;
				if (menuDll == null)
				{
					return;
				}
				menuDll.RunEvent("localaddons.changed");
			}

			// Token: 0x06001857 RID: 6231 RVA: 0x0005C750 File Offset: 0x0005A950
			public static void UpgradeSchema(LocalAddon addon)
			{
				if (!addon.Config.Upgrade())
				{
					return;
				}
				LocalAddon.SaveAll();
				LocalAddon.Initialize();
				Utility.Addons.UpdateAssetPaths();
				IAssetSystem.UpdateMods();
				Event.Run("localaddons.changed");
				IMenuDll menuDll = IMenuDll.Current;
				if (menuDll == null)
				{
					return;
				}
				menuDll.RunEvent("localaddons.changed");
			}
		}
	}
}
