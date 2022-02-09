using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x02000072 RID: 114
	public static class AddonManager
	{
		/// <summary>
		/// Try to add an addon by path. Returns false if addon already exists.
		/// </summary>
		// Token: 0x0600128B RID: 4747 RVA: 0x00050868 File Offset: 0x0004EA68
		public static bool TryAddAddon(string absolutePath)
		{
			ToolAddon addon = AddonManager.All.FirstOrDefault((ToolAddon x) => x.Path == absolutePath);
			if (addon != null)
			{
				return false;
			}
			addon = new ToolAddon(absolutePath);
			AddonManager.All.Add(addon);
			return true;
		}

		/// <summary>
		/// Try to add an addon by path. Returns false if addon already exists.
		/// </summary>
		// Token: 0x0600128C RID: 4748 RVA: 0x000508B8 File Offset: 0x0004EAB8
		internal static void Frame()
		{
			foreach (ToolAddon toolAddon in AddonManager.All)
			{
				toolAddon.Frame();
			}
		}

		// Token: 0x0600128D RID: 4749 RVA: 0x00050908 File Offset: 0x0004EB08
		internal static void BlockForCompiles()
		{
			for (;;)
			{
				if (!AddonManager.All.Any((ToolAddon x) => x.IsBuilding))
				{
					break;
				}
				QApp.processEvents();
				Thread.Sleep(10);
				MainThreadContext instance = MainThreadContext.Instance;
				if (instance != null)
				{
					instance.ProcessQueue();
				}
			}
		}

		/// <summary>
		/// Remove/dispose all addons
		/// </summary>
		// Token: 0x0600128E RID: 4750 RVA: 0x00050960 File Offset: 0x0004EB60
		public static void Shutdown()
		{
			foreach (ToolAddon toolAddon in AddonManager.All)
			{
				toolAddon.Dispose();
			}
			AddonManager.All.Clear();
		}

		// Token: 0x04000169 RID: 361
		public static List<ToolAddon> All = new List<ToolAddon>();
	}
}
