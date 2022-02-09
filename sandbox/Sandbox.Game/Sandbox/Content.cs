using System;
using System.Collections.Generic;
using Sandbox.Engine;

namespace Sandbox
{
	// Token: 0x02000077 RID: 119
	[Hotload.SkipAttribute]
	internal class Content : IDisposable
	{
		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000C98 RID: 3224 RVA: 0x00040B84 File Offset: 0x0003ED84
		// (set) Token: 0x06000C99 RID: 3225 RVA: 0x00040B8C File Offset: 0x0003ED8C
		public string AbsolutePath { get; private set; }

		// Token: 0x06000C9A RID: 3226 RVA: 0x00040B98 File Offset: 0x0003ED98
		public Content(BaseFileSystem fileSystem)
		{
			this.FileSystem = fileSystem;
			Sandbox.FileSystem.Mounted.Mount(this.FileSystem);
			this.AbsolutePath = fileSystem.GetFullPath("/");
			SearchPath.Add(this.AbsolutePath, "GAME", true);
			Content.All.Add(this);
		}

		// Token: 0x06000C9B RID: 3227 RVA: 0x00040BF0 File Offset: 0x0003EDF0
		public void Dispose()
		{
			if (this.FileSystem != null)
			{
				Sandbox.FileSystem.Mounted.UnMount(this.FileSystem);
				BaseFileSystem fileSystem = this.FileSystem;
				if (fileSystem != null)
				{
					fileSystem.Dispose();
				}
				Content.All.Remove(this);
			}
			this.FileSystem = null;
			this.AbsolutePath = null;
		}

		// Token: 0x06000C9C RID: 3228 RVA: 0x00040C40 File Offset: 0x0003EE40
		public static void Clear()
		{
			Content[] array = Content.All.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Dispose();
			}
		}

		// Token: 0x040001B2 RID: 434
		public static List<Content> All = new List<Content>();

		// Token: 0x040001B3 RID: 435
		public string Ident;

		// Token: 0x040001B4 RID: 436
		public bool ClientShouldInstall;

		// Token: 0x040001B5 RID: 437
		private BaseFileSystem FileSystem;
	}
}
