using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Sandbox
{
	/// <summary>
	/// Creates and maintains a list of available assets that the client can download
	/// Along with their CRCs - which we can use to assure we're using the same shit
	/// </summary>
	// Token: 0x020000C5 RID: 197
	[Hotload.SkipAttribute]
	internal static class NetworkAssetList
	{
		/// <summary>
		/// Populates with all files
		/// </summary>
		// Token: 0x06001213 RID: 4627 RVA: 0x0004C388 File Offset: 0x0004A588
		internal static void Initialize()
		{
			Host.AssertServer("Initialize");
			NetworkAssetList.Shutdown();
			NetworkAssetList.Watches = new List<FileWatch>();
			foreach (Addon addon in ServerAddons.Active)
			{
				if (addon.ShouldSendFiles)
				{
					string filter = addon.SharedAssetFilter;
					if (addon.content != null)
					{
						NetworkAssetList.AddFiles(addon.content, filter).Wait();
						FileWatch watch = addon.content.Watch(filter);
						watch.OnChangedFile += delegate(string file)
						{
							NetworkAssetList.OnFileChanged(file);
						};
						NetworkAssetList.Watches.Add(watch);
					}
					if (addon.code != null)
					{
						NetworkAssetList.AddFiles(addon.code, filter).Wait();
						FileWatch watch2 = addon.code.Watch(filter);
						watch2.OnChangedFile += delegate(string file)
						{
							NetworkAssetList.OnFileChanged(file);
						};
						NetworkAssetList.Watches.Add(watch2);
					}
				}
			}
		}

		// Token: 0x06001214 RID: 4628 RVA: 0x0004C4B0 File Offset: 0x0004A6B0
		private static void OnFileChanged(string filename)
		{
			filename = filename.ToLower().Replace('\\', '/').Trim('/');
			if (NetworkAssetList.IgnoredFile(filename))
			{
				return;
			}
			Host.AssertServer("OnFileChanged");
			NetworkAssetList.AddFile(filename).Wait();
		}

		// Token: 0x06001215 RID: 4629 RVA: 0x0004C4E8 File Offset: 0x0004A6E8
		internal static void Shutdown()
		{
			if (NetworkAssetList.Watches != null)
			{
				foreach (FileWatch fileWatch in NetworkAssetList.Watches)
				{
					fileWatch.Dispose();
				}
				NetworkAssetList.Watches = null;
			}
		}

		// Token: 0x06001216 RID: 4630 RVA: 0x0004C544 File Offset: 0x0004A744
		private static async Task AddFiles(BaseFileSystem filesystem, string wildcard)
		{
			if (filesystem != null)
			{
				IEnumerable<string> enumerable = filesystem.FindFile("/", wildcard, true);
				List<Task> tasks = new List<Task>();
				using (IEnumerator<string> enumerator = enumerable.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						string file = enumerator.Current;
						string cleanFile = file.ToLower().Replace('\\', '/').Trim('/');
						if (!NetworkAssetList.IgnoredFile(cleanFile))
						{
							tasks.Add(Task.Run(() => NetworkAssetList.AddFile(cleanFile)));
						}
					}
					goto IL_13A;
				}
				IL_B1:
				await Task.Delay(5);
				tasks.RemoveAll((Task x) => x.IsCompleted);
				IL_13A:
				if (tasks.Count > 0)
				{
					goto IL_B1;
				}
			}
		}

		// Token: 0x06001217 RID: 4631 RVA: 0x0004C590 File Offset: 0x0004A790
		private static async Task AddFile(string name)
		{
			if (FileSystem.Mounted.FileExists(name))
			{
				uint crc = await FileSystem.Mounted.GetCRC(name);
				uint size = (uint)FileSystem.Mounted.FileSize(name);
				if (size > 0U)
				{
					NetworkAssetList.AddFile(name, crc, size);
				}
			}
		}

		/// <summary>
		/// Opportunity to filter out files we don't want to send to the client
		/// </summary>
		// Token: 0x06001218 RID: 4632 RVA: 0x0004C5D4 File Offset: 0x0004A7D4
		private static bool IgnoredFile(string name)
		{
			return name.EndsWith("accesslist.txt") || !name.Contains(".") || name.EndsWith(".cs") || name.Contains("_bakeresourcecache") || name.Contains("codegen-exception") || name.EndsWith(".exe") || name.EndsWith(".cmd") || name.EndsWith(".bat") || name.EndsWith(".dll") || name.EndsWith(".pdb") || name.EndsWith(".bin") || name.EndsWith(".csproj") || name.EndsWith(".cache") || name.StartsWith(".") || name.StartsWith("code/") || name.StartsWith("properties/") || name.StartsWith("obj/") || name.EndsWith(".dmx") || name.EndsWith(".tga") || name.EndsWith(".tif") || name.EndsWith(".psd") || name.EndsWith(".vmat") || name.EndsWith(".wav") || name.EndsWith(".sound") || name.EndsWith(".vpcf") || name.EndsWith(".vmdl") || name.EndsWith(".fbx") || name.EndsWith(".obj") || name.EndsWith(".vanmgrph") || name.EndsWith("_color.png") || name.EndsWith("_color.jpg") || name.EndsWith("_color.txt") || name.EndsWith("_normal.png") || name.EndsWith("_normal.jpg") || name.EndsWith("_normal.txt") || name.EndsWith("_rough.png") || name.EndsWith("_rough.jpg") || name.EndsWith("_rough.txt") || name.EndsWith("_metal.png") || name.EndsWith("_metal.jpg") || name.EndsWith("_metal.txt") || name.EndsWith("_ao.png") || name.EndsWith("_ao.jpg") || name.EndsWith("_ao.txt") || name.EndsWith("_selfillum.png") || name.EndsWith("_selfillum.jpg") || name.EndsWith("_selfillum.txt") || name.EndsWith(".vmap") || name.EndsWith(".los") || name.EndsWith(".smd") || name.EndsWith(".mdl") || name.EndsWith(".vtx") || name.EndsWith(".vvd") || name.EndsWith(".phy") || name.EndsWith(".pcf") || name.EndsWith(".vtf") || name.EndsWith(".vmt");
		}

		// Token: 0x06001219 RID: 4633 RVA: 0x0004C93C File Offset: 0x0004AB3C
		private unsafe static void AddFile(string name, uint crc, uint size)
		{
			StringTable assets = StringTables.Assets;
			lock (assets)
			{
				NetworkAssetList.AssetData data = new NetworkAssetList.AssetData
				{
					Crc = crc,
					Size = size
				};
				void* dataPtr = Unsafe.AsPointer<NetworkAssetList.AssetData>(ref data);
				StringTables.Assets.SetWithData(name, dataPtr, sizeof(NetworkAssetList.AssetData));
			}
		}

		// Token: 0x040003BB RID: 955
		private static List<FileWatch> Watches;

		// Token: 0x02000243 RID: 579
		internal struct AssetData
		{
			// Token: 0x040011B5 RID: 4533
			public uint Crc;

			// Token: 0x040011B6 RID: 4534
			public uint Size;
		}
	}
}
