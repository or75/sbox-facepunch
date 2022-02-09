using System;
using Zio.FileSystems;

namespace Sandbox
{
	// Token: 0x020002A3 RID: 675
	internal static class EngineFileSystem
	{
		// Token: 0x17000340 RID: 832
		// (get) Token: 0x0600111C RID: 4380 RVA: 0x000204DD File Offset: 0x0001E6DD
		// (set) Token: 0x0600111D RID: 4381 RVA: 0x000204E4 File Offset: 0x0001E6E4
		public static RootFileSystem Root { get; private set; }

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x0600111E RID: 4382 RVA: 0x000204EC File Offset: 0x0001E6EC
		// (set) Token: 0x0600111F RID: 4383 RVA: 0x000204F3 File Offset: 0x0001E6F3
		public static BaseFileSystem Config { get; private set; }

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x06001120 RID: 4384 RVA: 0x000204FB File Offset: 0x0001E6FB
		// (set) Token: 0x06001121 RID: 4385 RVA: 0x00020502 File Offset: 0x0001E702
		public static BaseFileSystem Addons { get; private set; }

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x06001122 RID: 4386 RVA: 0x0002050A File Offset: 0x0001E70A
		// (set) Token: 0x06001123 RID: 4387 RVA: 0x00020511 File Offset: 0x0001E711
		public static BaseFileSystem Data { get; private set; }

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x06001124 RID: 4388 RVA: 0x00020519 File Offset: 0x0001E719
		// (set) Token: 0x06001125 RID: 4389 RVA: 0x00020520 File Offset: 0x0001E720
		internal static BaseFileSystem DownloadedFiles { get; private set; }

		/// <summary>
		/// A place to write files temporarily. This is stored in memory so 
		/// cleaning up after yourself is a good idea (!)
		/// </summary>
		// Token: 0x17000345 RID: 837
		// (get) Token: 0x06001126 RID: 4390 RVA: 0x00020528 File Offset: 0x0001E728
		// (set) Token: 0x06001127 RID: 4391 RVA: 0x0002052F File Offset: 0x0001E72F
		public static BaseFileSystem Temporary { get; private set; }

		/// <summary>
		/// Don't try to use the filesystem until you've called this!
		/// </summary>
		// Token: 0x06001128 RID: 4392 RVA: 0x00020537 File Offset: 0x0001E737
		internal static void Initialize(string rootFolder)
		{
			if (EngineFileSystem.Root != null)
			{
				throw new Exception("Filesystem Multi-Initialize");
			}
			EngineFileSystem.Root = new RootFileSystem(rootFolder);
			EngineFileSystem.Temporary = new BaseFileSystem(new MemoryFileSystem());
		}

		/// <summary>
		/// Create Config, Addons, DownloadedFiles mounts. This isn't part of Initialize()
		/// because it's specific to the game, so we don't want to run it in Unit Tests
		/// </summary>
		// Token: 0x06001129 RID: 4393 RVA: 0x00020568 File Offset: 0x0001E768
		internal static void DoMounts()
		{
			EngineFileSystem.Root.CreateDirectory("/config");
			EngineFileSystem.Config = EngineFileSystem.Root.CreateSubSystem("/config");
			EngineFileSystem.Addons = EngineFileSystem.Root.CreateSubSystem("/addons");
			EngineFileSystem.Root.CreateDirectory("/data");
			EngineFileSystem.Root.CreateDirectory("/download");
			EngineFileSystem.Root.CreateDirectory("/download/.sv");
			EngineFileSystem.DownloadedFiles = EngineFileSystem.Root.CreateSubSystem("/download");
			EngineFileSystem.Data = EngineFileSystem.Root.CreateSubSystem("/data");
		}

		/// <summary>
		/// Should only be called at the very death
		/// </summary>
		// Token: 0x0600112A RID: 4394 RVA: 0x00020604 File Offset: 0x0001E804
		internal static void Shutdown()
		{
			EngineFileSystem.Root = null;
			EngineFileSystem.Config = null;
			BaseFileSystem downloadedFiles = EngineFileSystem.DownloadedFiles;
			if (downloadedFiles != null)
			{
				downloadedFiles.Dispose();
			}
			EngineFileSystem.DownloadedFiles = null;
			BaseFileSystem addons = EngineFileSystem.Addons;
			if (addons != null)
			{
				addons.Dispose();
			}
			EngineFileSystem.Addons = null;
			RootFileSystem root = EngineFileSystem.Root;
			if (root != null)
			{
				root.Dispose();
			}
			EngineFileSystem.Root = null;
		}

		// Token: 0x0600112B RID: 4395 RVA: 0x0002065F File Offset: 0x0001E85F
		public static BaseFileSystem ServerInit()
		{
			BaseFileSystem server = EngineFileSystem.Server;
			if (server != null)
			{
				server.Dispose();
			}
			EngineFileSystem.Server = new BaseFileSystem(new AggregateFileSystem(false));
			EngineFileSystem.Server.CreateAndMount(EngineFileSystem.Root, "/core");
			return EngineFileSystem.Server;
		}

		// Token: 0x04001375 RID: 4981
		public static BaseFileSystem Server;

		// Token: 0x04001376 RID: 4982
		public static BaseFileSystem OrgData;

		// Token: 0x04001377 RID: 4983
		public static BaseFileSystem AddonData;
	}
}
