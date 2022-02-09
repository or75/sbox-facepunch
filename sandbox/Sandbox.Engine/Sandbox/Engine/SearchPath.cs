using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NativeEngine;
using Sandbox.Internal;

namespace Sandbox.Engine
{
	// Token: 0x020002F3 RID: 755
	[Hotload.SkipAttribute]
	internal class SearchPath : IDisposable
	{
		/// <summary>
		/// Absolute path
		/// </summary>
		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x0600140A RID: 5130 RVA: 0x0002AC69 File Offset: 0x00028E69
		// (set) Token: 0x0600140B RID: 5131 RVA: 0x0002AC71 File Offset: 0x00028E71
		public string Path { get; set; }

		/// <summary>
		/// ie "GAME", "MOD"
		/// </summary>
		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x0600140C RID: 5132 RVA: 0x0002AC7A File Offset: 0x00028E7A
		// (set) Token: 0x0600140D RID: 5133 RVA: 0x0002AC82 File Offset: 0x00028E82
		public string PathId { get; set; }

		// Token: 0x0600140E RID: 5134 RVA: 0x0002AC8B File Offset: 0x00028E8B
		private SearchPath(string path, string pathid, bool head)
		{
			this.Path = path;
			this.PathId = pathid;
			EngineGlue.AddSearchPath(this.Path, this.PathId, head);
			this.IsMounted = true;
		}

		// Token: 0x0600140F RID: 5135 RVA: 0x0002ACBC File Offset: 0x00028EBC
		public void Dispose()
		{
			if (!this.IsMounted)
			{
				return;
			}
			this.IsMounted = false;
			SearchPath.All.Remove(this);
			if (!EngineGlue.RemoveSearchPath(this.Path, this.PathId))
			{
				GlobalSystemNamespace.Log.Error(FormattableStringFactory.Create("Failed to remove search path [{0}:{1}]", new object[] { this.Path, this.PathId }));
			}
		}

		/// <summary>
		/// Add a search path to the engine if it doesn't already exist. Adds it to an internal
		/// list so we can clean it up using Clear() after we're done.
		/// </summary>
		// Token: 0x06001410 RID: 5136 RVA: 0x0002AD24 File Offset: 0x00028F24
		public static void Add(string path, string pathid, bool head)
		{
			if (SearchPath.All.Any((SearchPath x) => x.Path == path && x.PathId == pathid))
			{
				GlobalSystemNamespace.Log.Info(FormattableStringFactory.Create("Skipping path mount, already mounted: {0} {1}", new object[] { path, pathid }));
				return;
			}
			SearchPath mount = new SearchPath(path, pathid, head);
			SearchPath.All.Add(mount);
		}

		/// <summary>
		/// Unmount all paths mounted using Add.
		/// </summary>
		// Token: 0x06001411 RID: 5137 RVA: 0x0002ADA8 File Offset: 0x00028FA8
		public static void Clear()
		{
			SearchPath[] array = SearchPath.All.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Dispose();
			}
			if (SearchPath.All.Count > 0)
			{
				GlobalSystemNamespace.Log.Error(FormattableStringFactory.Create("EnginePathMount - cleared but still have {0} items!", new object[] { SearchPath.All.Count }));
			}
		}

		// Token: 0x0400152E RID: 5422
		public static List<SearchPath> All = new List<SearchPath>();

		// Token: 0x04001531 RID: 5425
		private bool IsMounted;
	}
}
