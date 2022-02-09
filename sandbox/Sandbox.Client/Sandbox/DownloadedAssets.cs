using System;
using System.IO;
using System.Threading.Tasks;

namespace Sandbox
{
	/// <summary>
	/// Client class for handling storing and access of downloaded files.
	/// </summary>
	// Token: 0x02000008 RID: 8
	internal static class DownloadedAssets
	{
		// Token: 0x06000015 RID: 21 RVA: 0x000025EE File Offset: 0x000007EE
		public static void Init()
		{
			Host.AssertClient("Init");
			DownloadedAssets.FileSystem = new MemoryFileSystem();
		}

		/// <summary>
		/// Copy the file from the cache folder to our memory based filesystem.
		/// We should probably just be redirecting filenames here.
		/// </summary>
		// Token: 0x06000016 RID: 22 RVA: 0x00002604 File Offset: 0x00000804
		internal static async Task AddFileAsync(string filename, string cacheName)
		{
			DownloadedAssets.FileSystem.CreateDirectory(Path.GetDirectoryName(filename));
			using (Stream stream = DownloadedAssets.FileSystem.OpenWrite(filename, FileMode.Create))
			{
				using (Stream reader = EngineFileSystem.DownloadedFiles.OpenRead(cacheName, FileMode.Open))
				{
					await reader.CopyToAsync(stream);
				}
				Stream reader = null;
			}
			Stream stream = null;
		}

		/// <summary>
		/// Get the cache filename we should use for this downloaded file
		/// </summary>
		// Token: 0x06000017 RID: 23 RVA: 0x0000264F File Offset: 0x0000084F
		internal static string GetCacheName(string filename, uint crc)
		{
			return "/.sv/" + crc.ToString("x").ToLower() + ".cache";
		}

		// Token: 0x04000003 RID: 3
		public static BaseFileSystem FileSystem;
	}
}
