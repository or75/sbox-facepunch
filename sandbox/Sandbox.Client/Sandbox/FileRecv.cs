using System;
using System.IO;

namespace Sandbox
{
	// Token: 0x02000009 RID: 9
	internal class FileRecv
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002671 File Offset: 0x00000871
		// (set) Token: 0x06000019 RID: 25 RVA: 0x00002679 File Offset: 0x00000879
		public string Filename { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002682 File Offset: 0x00000882
		// (set) Token: 0x0600001B RID: 27 RVA: 0x0000268A File Offset: 0x0000088A
		public uint CRC { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001C RID: 28 RVA: 0x00002693 File Offset: 0x00000893
		// (set) Token: 0x0600001D RID: 29 RVA: 0x0000269B File Offset: 0x0000089B
		public uint TotalSize { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600001E RID: 30 RVA: 0x000026A4 File Offset: 0x000008A4
		// (set) Token: 0x0600001F RID: 31 RVA: 0x000026AC File Offset: 0x000008AC
		public bool IsComplete { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000026B5 File Offset: 0x000008B5
		// (set) Token: 0x06000021 RID: 33 RVA: 0x000026BD File Offset: 0x000008BD
		public int Id { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000022 RID: 34 RVA: 0x000026C6 File Offset: 0x000008C6
		// (set) Token: 0x06000023 RID: 35 RVA: 0x000026CE File Offset: 0x000008CE
		public DateTime Start { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000024 RID: 36 RVA: 0x000026D7 File Offset: 0x000008D7
		// (set) Token: 0x06000025 RID: 37 RVA: 0x000026DF File Offset: 0x000008DF
		public long DownloadedSize { get; private set; }

		// Token: 0x06000026 RID: 38 RVA: 0x000026E8 File Offset: 0x000008E8
		internal void OnChunk(Span<byte> span)
		{
			if (this.Filename == null)
			{
				throw new Exception("Getting File Chunk but no name!");
			}
			if (this.Stream == null)
			{
				string targetName = DownloadedAssets.GetCacheName(this.Filename, this.CRC);
				this.Stream = EngineFileSystem.DownloadedFiles.OpenWrite(targetName, FileMode.Create);
			}
			this.Stream.Write(span);
			this.DownloadedSize = this.Stream.Length;
			if (this.Stream.Length == (long)((ulong)this.TotalSize))
			{
				this.Stream.Dispose();
				DownloadedAssets.AddFileAsync(this.Filename, DownloadedAssets.GetCacheName(this.Filename, this.CRC)).Wait();
				this.IsComplete = true;
			}
		}

		// Token: 0x0400000A RID: 10
		private Stream Stream;
	}
}
