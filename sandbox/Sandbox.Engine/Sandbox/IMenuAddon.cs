using System;

namespace Sandbox
{
	/// <summary>
	/// This is how the engine communicates with the menu system
	/// </summary>
	// Token: 0x020002AE RID: 686
	public abstract class IMenuAddon
	{
		// Token: 0x1700034D RID: 845
		// (get) Token: 0x06001168 RID: 4456 RVA: 0x0002326D File Offset: 0x0002146D
		// (set) Token: 0x06001169 RID: 4457 RVA: 0x00023274 File Offset: 0x00021474
		internal static IMenuAddon Current { get; set; }

		/// <summary>
		/// Called to initialize the menu system
		/// </summary>
		// Token: 0x0600116A RID: 4458
		public abstract void Init();

		/// <summary>
		/// Close down the menu, delete everything
		/// </summary>
		// Token: 0x0600116B RID: 4459
		public abstract void Shutdown();

		/// <summary>
		/// Update the load screen values
		/// </summary>
		// Token: 0x0600116C RID: 4460
		public abstract void OnLoadProgress(float progress, string title, string subtitle, string statistic);

		/// <summary>
		/// Update the load screen download values
		/// </summary>
		// Token: 0x0600116D RID: 4461
		public abstract void OnDownloadProgress(long downloaded, long total);

		/// <summary>
		/// Show/Hide the menu screen
		/// </summary>
		// Token: 0x0600116E RID: 4462
		public abstract void SetMenuScreen(bool show);

		/// <summary>
		/// If the menu screen is open
		/// </summary>
		// Token: 0x0600116F RID: 4463
		public abstract bool IsMenuScreenVisible();

		/// <summary>
		/// Show/Hide the loading screen
		/// </summary>
		// Token: 0x06001170 RID: 4464
		public abstract void SetLoading(bool show);

		/// <summary>
		/// Show a popup
		/// </summary>
		// Token: 0x06001171 RID: 4465
		public abstract void Popup(string type, string title, string subtitle);

		/// <summary>
		/// Show a popup
		/// </summary>
		// Token: 0x06001172 RID: 4466
		public abstract void DevNotice(string category, string icon, string title, int seconds, string type, string information);

		// Token: 0x06001173 RID: 4467 RVA: 0x0002327C File Offset: 0x0002147C
		internal static void SetLoadingVisible(bool show)
		{
			IMenuAddon menuAddon = IMenuAddon.Current;
			if (menuAddon == null)
			{
				return;
			}
			menuAddon.SetLoading(show);
		}

		// Token: 0x06001174 RID: 4468 RVA: 0x0002328E File Offset: 0x0002148E
		internal static void SetLoadingStatus(string title, string subtitle = "")
		{
			IMenuAddon menuAddon = IMenuAddon.Current;
			if (menuAddon == null)
			{
				return;
			}
			menuAddon.OnLoadProgress(0f, title, subtitle, "");
		}

		// Token: 0x06001175 RID: 4469 RVA: 0x000232AB File Offset: 0x000214AB
		internal static void DownloadProgressCallback(long downloaded, long total)
		{
			IMenuAddon menuAddon = IMenuAddon.Current;
			if (menuAddon == null)
			{
				return;
			}
			menuAddon.OnDownloadProgress(downloaded, total);
		}

		// Token: 0x06001176 RID: 4470 RVA: 0x000232BE File Offset: 0x000214BE
		internal static void ShowServerError(string title, string subtitle)
		{
			IMenuAddon menuAddon = IMenuAddon.Current;
			if (menuAddon == null)
			{
				return;
			}
			menuAddon.Popup("error", title, subtitle);
		}

		// Token: 0x06001177 RID: 4471 RVA: 0x000232D6 File Offset: 0x000214D6
		internal static void ShowDevNotice(string category, string icon, string title, int seconds, string type, string information)
		{
			IMenuAddon menuAddon = IMenuAddon.Current;
			if (menuAddon == null)
			{
				return;
			}
			menuAddon.DevNotice(category, icon, title, seconds, type, information);
		}
	}
}
