using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Sandbox
{
	// Token: 0x02000005 RID: 5
	internal class FileSend : IDisposable
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002078 File Offset: 0x00000278
		internal unsafe void Tick(NetworkServer server)
		{
			int remainingSpace = 8192 - server.PendingReliable;
			if (remainingSpace < 0)
			{
				return;
			}
			if (this.Stream == null)
			{
				if (this.FileQueue.Count<int>() == 0)
				{
					return;
				}
				int id = this.FileQueue.First<int>();
				this.FileQueue.RemoveAll((int x) => x == id);
				string filename = StringTables.Assets.GetString(id);
				StringTables.Assets.GetData<NetworkAssetList.AssetData>(id);
				FileSend.log.Info(FormattableStringFactory.Create("Sending '{0}' to {1}", new object[] { filename, server.ClientName }));
				this.Stream = FileSystem.Mounted.OpenRead(filename, FileMode.Open);
				server.Send<int>(NetMsgType.FileStart, id);
			}
			byte[] bytes = new byte[remainingSpace];
			int read = this.Stream.Read(bytes);
			if (read > 0)
			{
				void* ptr = Unsafe.AsPointer<byte>(ref bytes[0]);
				server.Send(NetMsgType.FileChunk, ptr, read);
			}
			if (this.Stream.Position == this.Stream.Length)
			{
				this.Stream.Dispose();
				this.Stream = null;
			}
			this.Tick(server);
		}

		/// <summary>
		/// Add a file to download
		/// </summary>
		// Token: 0x06000005 RID: 5 RVA: 0x000021B0 File Offset: 0x000003B0
		internal void Queue(int fileId)
		{
			this.FileQueue.Add(fileId);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000021BE File Offset: 0x000003BE
		public void Dispose()
		{
			Stream stream = this.Stream;
			if (stream != null)
			{
				stream.Dispose();
			}
			this.Stream = null;
			this.FileQueue.Clear();
		}

		// Token: 0x04000001 RID: 1
		private static readonly Logger log = Logging.GetLogger(null);

		// Token: 0x04000002 RID: 2
		private List<int> FileQueue = new List<int>();

		// Token: 0x04000003 RID: 3
		private Stream Stream;
	}
}
