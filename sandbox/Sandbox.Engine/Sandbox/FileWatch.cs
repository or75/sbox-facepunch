using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Sandbox
{
	/// <summary>
	/// Watch folders, dispatch events on changed files
	/// </summary>
	// Token: 0x020002A4 RID: 676
	[Hotload.SkipAttribute]
	public sealed class FileWatch : IDisposable
	{
		// Token: 0x17000346 RID: 838
		// (get) Token: 0x0600112C RID: 4396 RVA: 0x0002069B File Offset: 0x0001E89B
		// (set) Token: 0x0600112D RID: 4397 RVA: 0x000206A3 File Offset: 0x0001E8A3
		public bool Enabled { get; set; }

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x0600112E RID: 4398 RVA: 0x000206AC File Offset: 0x0001E8AC
		// (set) Token: 0x0600112F RID: 4399 RVA: 0x000206B4 File Offset: 0x0001E8B4
		public List<string> Changes { get; private set; }

		// Token: 0x06001130 RID: 4400 RVA: 0x000206C0 File Offset: 0x0001E8C0
		internal FileWatch(BaseFileSystem system, string path)
		{
			this.system = system;
			this.Enabled = true;
			string pattern = Regex.Escape(path.ToLower()).Replace("\\*", ".*").Replace("\\?", ".");
			this.regexTest = new Regex("^" + pattern + "$", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
		}

		// Token: 0x06001131 RID: 4401 RVA: 0x00020728 File Offset: 0x0001E928
		internal FileWatch(BaseFileSystem system)
		{
			this.system = system;
			this.Enabled = true;
		}

		// Token: 0x06001132 RID: 4402 RVA: 0x0002073E File Offset: 0x0001E93E
		public void Dispose()
		{
			this.OnChanges = null;
			this.OnChangedFile = null;
			BaseFileSystem baseFileSystem = this.system;
			if (baseFileSystem != null)
			{
				baseFileSystem.RemoveWatcher(this);
			}
			this.system = null;
		}

		// Token: 0x06001133 RID: 4403 RVA: 0x00020768 File Offset: 0x0001E968
		private void TriggerCallback(List<string> value)
		{
			if (!this.Enabled)
			{
				return;
			}
			if (this.Changes == null)
			{
				this.Changes = new List<string>();
			}
			this.Changes.Clear();
			using (List<string>.Enumerator enumerator = value.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string change = enumerator.Current;
					if (this.regexTest != null && this.regexTest.IsMatch(change))
					{
						this.Changes.Add(change);
					}
					if (this.watchFiles != null && this.watchFiles.Any((string x) => string.Equals(change, x, StringComparison.OrdinalIgnoreCase)))
					{
						this.Changes.Add(change);
					}
				}
			}
			if (this.Changes.Count == 0)
			{
				return;
			}
			try
			{
				Action<FileWatch> onChanges = this.OnChanges;
				if (onChanges != null)
				{
					onChanges(this);
				}
				foreach (string change2 in this.Changes)
				{
					Action<string> onChangedFile = this.OnChangedFile;
					if (onChangedFile != null)
					{
						onChangedFile(change2);
					}
				}
			}
			catch (Exception e)
			{
				FileWatch.log.Error(e);
			}
		}

		/// <summary>
		/// Called once per batch of files changed
		/// </summary>
		// Token: 0x14000038 RID: 56
		// (add) Token: 0x06001134 RID: 4404 RVA: 0x000208CC File Offset: 0x0001EACC
		// (remove) Token: 0x06001135 RID: 4405 RVA: 0x00020904 File Offset: 0x0001EB04
		public event Action<FileWatch> OnChanges;

		/// <summary>
		/// Called for each file changed
		/// </summary>
		// Token: 0x14000039 RID: 57
		// (add) Token: 0x06001136 RID: 4406 RVA: 0x0002093C File Offset: 0x0001EB3C
		// (remove) Token: 0x06001137 RID: 4407 RVA: 0x00020974 File Offset: 0x0001EB74
		public event Action<string> OnChangedFile;

		// Token: 0x06001138 RID: 4408 RVA: 0x000209AC File Offset: 0x0001EBAC
		public static void Tick()
		{
			Dictionary<BaseFileSystem, List<string>> changes = null;
			List<BaseFileSystem> withChanges = FileWatch.WithChanges;
			lock (withChanges)
			{
				if (FileWatch.TimeSinceLastChange < 0.3f)
				{
					return;
				}
				if (FileWatch.WithChanges.Count == 0)
				{
					return;
				}
				FileWatch.WithChanges.RemoveAll((BaseFileSystem x) => !x.IsValid);
				changes = FileWatch.WithChanges.ToDictionary((BaseFileSystem x) => x, (BaseFileSystem x) => x.changedFiles.ToList<string>());
				foreach (BaseFileSystem baseFileSystem in FileWatch.WithChanges)
				{
					baseFileSystem.changedFiles.Clear();
				}
				FileWatch.WithChanges.Clear();
			}
			foreach (KeyValuePair<BaseFileSystem, List<string>> filesystem in changes)
			{
				FileWatch[] array = filesystem.Key.watchers.ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					array[i].TriggerCallback(filesystem.Value);
				}
			}
		}

		// Token: 0x06001139 RID: 4409 RVA: 0x00020B40 File Offset: 0x0001ED40
		internal void AddFile(string file)
		{
			if (this.watchFiles == null)
			{
				this.watchFiles = new List<string>();
			}
			this.watchFiles.Add(file);
		}

		// Token: 0x04001378 RID: 4984
		private static Logger log = Logging.GetLogger(null);

		// Token: 0x04001379 RID: 4985
		internal static List<BaseFileSystem> WithChanges = new List<BaseFileSystem>();

		// Token: 0x0400137A RID: 4986
		private BaseFileSystem system;

		// Token: 0x0400137D RID: 4989
		private Regex regexTest;

		// Token: 0x0400137E RID: 4990
		public List<string> watchFiles;

		// Token: 0x04001381 RID: 4993
		internal static RealTimeSince TimeSinceLastChange;
	}
}
