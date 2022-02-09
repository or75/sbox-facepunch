using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Sandbox.Utility;
using Zio;
using Zio.FileSystems;

namespace Sandbox
{
	// Token: 0x020002A2 RID: 674
	public class BaseFileSystem
	{
		// Token: 0x060010F5 RID: 4341 RVA: 0x0001FBA9 File Offset: 0x0001DDA9
		internal BaseFileSystem(IFileSystem system)
		{
			this.system = system;
		}

		// Token: 0x060010F6 RID: 4342 RVA: 0x0001FBBF File Offset: 0x0001DDBF
		internal BaseFileSystem()
		{
		}

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x060010F7 RID: 4343 RVA: 0x0001FBCE File Offset: 0x0001DDCE
		public bool IsValid
		{
			get
			{
				return this.system != null;
			}
		}

		// Token: 0x060010F8 RID: 4344 RVA: 0x0001FBDC File Offset: 0x0001DDDC
		internal virtual void Dispose()
		{
			List<BaseFileSystem> withChanges = FileWatch.WithChanges;
			lock (withChanges)
			{
				IFileSystem fileSystem = this.system;
				if (fileSystem != null)
				{
					fileSystem.Dispose();
				}
				this.system = null;
				IFileSystemWatcher fileSystemWatcher = this.watcher;
				if (fileSystemWatcher != null)
				{
					fileSystemWatcher.Dispose();
				}
				this.watcher = null;
				this.watchers = null;
				this.changedFiles = null;
			}
		}

		/// <summary>
		/// Get a list of directories
		/// </summary>
		// Token: 0x060010F9 RID: 4345 RVA: 0x0001FC54 File Offset: 0x0001DE54
		public IEnumerable<string> FindDirectory(string folder, string pattern = "*", bool recursive = false)
		{
			folder = BaseFileSystem.FixPath(folder);
			foreach (UPath path in this.system.EnumeratePaths(folder, pattern, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly, SearchTarget.Directory))
			{
				yield return path.FullName.Substring(folder.Length).Trim('/');
			}
			IEnumerator<UPath> enumerator = null;
			yield break;
			yield break;
		}

		/// <summary>
		/// Get a list of files
		/// </summary>
		// Token: 0x060010FA RID: 4346 RVA: 0x0001FC79 File Offset: 0x0001DE79
		public IEnumerable<string> FindFile(string folder, string pattern = "*", bool recursive = false)
		{
			folder = BaseFileSystem.FixPath(folder);
			foreach (UPath path in this.system.EnumeratePaths(folder, pattern, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly, SearchTarget.File))
			{
				yield return path.FullName.Substring(folder.Length).Trim('/');
			}
			IEnumerator<UPath> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x060010FB RID: 4347 RVA: 0x0001FC9E File Offset: 0x0001DE9E
		internal void TriggerChangedFiles(List<string> value)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Delete a folder and optionally all of its contents
		/// </summary>
		// Token: 0x060010FC RID: 4348 RVA: 0x0001FCA5 File Offset: 0x0001DEA5
		public void DeleteDirectory(string folder, bool recursive = false)
		{
			this.system.DeleteDirectory(BaseFileSystem.FixPath(folder), recursive);
		}

		/// <summary>
		/// Delete a file
		/// </summary>
		// Token: 0x060010FD RID: 4349 RVA: 0x0001FCBE File Offset: 0x0001DEBE
		public void DeleteFile(string path)
		{
			this.system.DeleteFile(BaseFileSystem.FixPath(path));
		}

		/// <summary>
		/// Create a directory - or a tree of directories. 
		/// Returns silently if the directory already exists.
		/// </summary>
		/// <param name="folder"></param>
		// Token: 0x060010FE RID: 4350 RVA: 0x0001FCD6 File Offset: 0x0001DED6
		public void CreateDirectory(string folder)
		{
			if (string.IsNullOrWhiteSpace(folder))
			{
				return;
			}
			this.system.CreateDirectory(BaseFileSystem.FixPath(folder));
		}

		/// <summary>
		/// Returns true if the file exists on this filesystem
		/// </summary>
		// Token: 0x060010FF RID: 4351 RVA: 0x0001FCF7 File Offset: 0x0001DEF7
		public bool FileExists(string path)
		{
			return this.system.FileExists(BaseFileSystem.FixPath(path));
		}

		/// <summary>
		///  Returns true if the directory exists on this filesystem
		/// </summary>
		// Token: 0x06001100 RID: 4352 RVA: 0x0001FD0F File Offset: 0x0001DF0F
		public bool DirectoryExists(string path)
		{
			return this.system.DirectoryExists(BaseFileSystem.FixPath(path));
		}

		/// <summary>
		/// Returns the full physical path to a file or folder on disk,
		/// or null if it isn't on disk.
		/// </summary>
		// Token: 0x06001101 RID: 4353 RVA: 0x0001FD28 File Offset: 0x0001DF28
		public string GetFullPath(string path)
		{
			SubFileSystem sfs = this.system as SubFileSystem;
			if (sfs != null)
			{
				return sfs.ConvertPathToInternal(BaseFileSystem.FixPath(path));
			}
			AggregateFileSystem afs = this.system as AggregateFileSystem;
			if (afs == null)
			{
				return null;
			}
			FileSystemEntry entry = afs.FindFirstFileSystemEntry(BaseFileSystem.FixPath(path));
			if (entry == null)
			{
				return null;
			}
			if (entry == null)
			{
				return null;
			}
			return entry.FileSystem.ConvertPathToInternal(entry.Path);
		}

		/// <summary>
		/// Write the contents to the path. The file will be over-written if the file exists
		/// </summary>
		// Token: 0x06001102 RID: 4354 RVA: 0x0001FD9C File Offset: 0x0001DF9C
		public void WriteAllText(string path, string contents)
		{
			using (Stream stream = this.OpenWrite(path, FileMode.Create))
			{
				using (StreamWriter writer = new StreamWriter(stream))
				{
					writer.Write(contents);
				}
			}
		}

		/// <summary>
		/// Read the contents of path and return it as a string.
		/// Returns null if file not found.
		/// </summary>
		// Token: 0x06001103 RID: 4355 RVA: 0x0001FDF4 File Offset: 0x0001DFF4
		public string ReadAllText(string path)
		{
			if (!this.FileExists(path))
			{
				return null;
			}
			string result;
			using (Stream f = this.OpenRead(path, FileMode.Open))
			{
				using (StreamReader r = new StreamReader(f, Encoding.UTF8, true))
				{
					result = r.ReadToEnd();
				}
			}
			return result;
		}

		/// <summary>
		/// Read the contents of path and return it as a string
		/// </summary>
		// Token: 0x06001104 RID: 4356 RVA: 0x0001FE5C File Offset: 0x0001E05C
		public Span<byte> ReadAllBytes(string path)
		{
			Span<byte> result;
			using (Stream f = this.OpenRead(path, FileMode.Open))
			{
				byte[] bytes = new byte[f.Length];
				f.Read(bytes, 0, bytes.Length);
				result = bytes;
			}
			return result;
		}

		/// <summary>
		/// Read the contents of path and return it as a string
		/// </summary>
		// Token: 0x06001105 RID: 4357 RVA: 0x0001FEB0 File Offset: 0x0001E0B0
		public async Task<byte[]> ReadAllBytesAsync(string path)
		{
			byte[] result;
			using (Stream f = this.OpenRead(path, FileMode.Open))
			{
				byte[] bytes = new byte[f.Length];
				await f.ReadAsync(bytes, 0, bytes.Length);
				result = bytes;
			}
			return result;
		}

		/// <summary>
		/// Read the contents of path and return it as a string
		/// </summary>
		// Token: 0x06001106 RID: 4358 RVA: 0x0001FEFC File Offset: 0x0001E0FC
		public async Task<string> ReadAllTextAsync(string path)
		{
			string result;
			using (Stream f = this.OpenRead(path, FileMode.Open))
			{
				using (StreamReader r = new StreamReader(f, Encoding.UTF8, true))
				{
					result = await r.ReadToEndAsync();
				}
			}
			return result;
		}

		/// <summary>
		/// Create a sub-filesystem at the specified path
		/// </summary>
		// Token: 0x06001107 RID: 4359 RVA: 0x0001FF47 File Offset: 0x0001E147
		public BaseFileSystem CreateSubSystem(string path)
		{
			return new BaseFileSystem(new SubFileSystem(this.system, BaseFileSystem.FixPath(path), false));
		}

		/// <summary>
		/// Open a file for write. If the file exists we'll overwrite it (by default)
		/// </summary>
		// Token: 0x06001108 RID: 4360 RVA: 0x0001FF65 File Offset: 0x0001E165
		public Stream OpenWrite(string path, FileMode mode = FileMode.Create)
		{
			return this.system.OpenFile(BaseFileSystem.FixPath(path), mode, FileAccess.Write, FileShare.None);
		}

		/// <summary>
		/// Open a file for read. Will throw an exception if it doesn't exist.
		/// </summary>
		// Token: 0x06001109 RID: 4361 RVA: 0x0001FF80 File Offset: 0x0001E180
		public Stream OpenRead(string path, FileMode mode = FileMode.Open)
		{
			return this.system.OpenFile(BaseFileSystem.FixPath(path), mode, FileAccess.Read, FileShare.Read);
		}

		/// <summary>
		/// Read Json from a file using System.Text.Json.JsonSerializer. This will throw exceptions
		/// if the file is missing, unacccessible or not valid json.
		/// </summary>
		// Token: 0x0600110A RID: 4362 RVA: 0x0001FF9C File Offset: 0x0001E19C
		public T ReadJson<T>(string filename, T defaultValue = default(T))
		{
			string text = this.ReadAllText(filename);
			if (string.IsNullOrWhiteSpace(text))
			{
				return defaultValue;
			}
			JsonSerializerOptions options = new JsonSerializerOptions
			{
				ReadCommentHandling = JsonCommentHandling.Skip,
				PropertyNameCaseInsensitive = true,
				AllowTrailingCommas = true
			};
			return JsonSerializer.Deserialize<T>(text, options);
		}

		/// <summary>
		/// The same as ReadJson except will return a default value on missing/error.
		/// </summary>
		// Token: 0x0600110B RID: 4363 RVA: 0x0001FFE0 File Offset: 0x0001E1E0
		public T ReadJsonOrDefault<T>(string filename, T returnOnError = default(T))
		{
			T result;
			try
			{
				result = this.ReadJson<T>(filename, returnOnError);
			}
			catch (Exception)
			{
				result = returnOnError;
			}
			return result;
		}

		/// <summary>
		/// Convert object to json and write it to the specified file
		/// </summary>
		// Token: 0x0600110C RID: 4364 RVA: 0x00020010 File Offset: 0x0001E210
		public void WriteJson<T>(string filename, T data)
		{
			JsonSerializerOptions options = new JsonSerializerOptions
			{
				ReadCommentHandling = JsonCommentHandling.Skip,
				PropertyNameCaseInsensitive = true,
				AllowTrailingCommas = true,
				WriteIndented = true
			};
			string text = JsonSerializer.Serialize<T>(data, options);
			this.WriteAllText(filename, text);
		}

		/// <summary>
		/// Gets the size in bytes of all the files in a directory
		/// </summary>
		// Token: 0x0600110D RID: 4365 RVA: 0x00020050 File Offset: 0x0001E250
		public int DirectorySize(string path, bool recursive = false)
		{
			return (int)this.FindFile(path, "*", recursive).Sum((string x) => this.system.GetFileLength(Path.Combine(path, x)));
		}

		// Token: 0x0600110E RID: 4366 RVA: 0x00020098 File Offset: 0x0001E298
		public FileWatch Watch(string pathglob)
		{
			IFileSystemWatcher fileSystemWatcher = this.watcher;
			if (fileSystemWatcher != null)
			{
				fileSystemWatcher.Dispose();
			}
			this.watcher = null;
			if (this.watcher == null)
			{
				this.watcher = this.system.Watch("/");
				this.watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Attributes | NotifyFilters.Size | NotifyFilters.LastWrite | NotifyFilters.CreationTime | NotifyFilters.Security;
				this.watcher.IncludeSubdirectories = true;
				this.watcher.Changed += this.OnDirectoryContentsChanged;
				this.watcher.Deleted += this.OnDirectoryContentsChanged;
				this.watcher.Created += this.OnDirectoryContentsChanged;
				this.watcher.Renamed += this.OnDirectoryContentsRenamed;
				this.watcher.EnableRaisingEvents = true;
			}
			if (this.watchers == null)
			{
				this.watchers = new List<FileWatch>();
			}
			FileWatch w = new FileWatch(this, pathglob);
			this.watchers.Add(w);
			return w;
		}

		// Token: 0x0600110F RID: 4367 RVA: 0x00020190 File Offset: 0x0001E390
		public FileWatch Watch()
		{
			IFileSystemWatcher fileSystemWatcher = this.watcher;
			if (fileSystemWatcher != null)
			{
				fileSystemWatcher.Dispose();
			}
			this.watcher = null;
			if (this.watcher == null)
			{
				this.watcher = this.system.Watch("/");
				this.watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Attributes | NotifyFilters.Size | NotifyFilters.LastWrite | NotifyFilters.CreationTime | NotifyFilters.Security;
				this.watcher.IncludeSubdirectories = true;
				this.watcher.Changed += this.OnDirectoryContentsChanged;
				this.watcher.Deleted += this.OnDirectoryContentsChanged;
				this.watcher.Created += this.OnDirectoryContentsChanged;
				this.watcher.Renamed += this.OnDirectoryContentsRenamed;
				this.watcher.EnableRaisingEvents = true;
			}
			if (this.watchers == null)
			{
				this.watchers = new List<FileWatch>();
			}
			FileWatch w = new FileWatch(this);
			this.watchers.Add(w);
			return w;
		}

		// Token: 0x06001110 RID: 4368 RVA: 0x00020286 File Offset: 0x0001E486
		internal void RemoveWatcher(FileWatch watcher)
		{
			List<FileWatch> list = this.watchers;
			if (list == null)
			{
				return;
			}
			list.Remove(watcher);
		}

		// Token: 0x06001111 RID: 4369 RVA: 0x0002029C File Offset: 0x0001E49C
		internal void AddChangedFile(string path)
		{
			if (!this.WatchEnabled)
			{
				return;
			}
			path = path.ToLower();
			if (path.EndsWith(".tmp") || path.EndsWith("~"))
			{
				return;
			}
			if (path == "/accesslist.txt")
			{
				return;
			}
			List<BaseFileSystem> withChanges = FileWatch.WithChanges;
			lock (withChanges)
			{
				if (this.changedFiles == null)
				{
					this.changedFiles = new List<string>();
				}
				if (!this.changedFiles.Contains(path))
				{
					this.changedFiles.Add(path);
					if (!FileWatch.WithChanges.Contains(this))
					{
						FileWatch.WithChanges.Add(this);
					}
					FileWatch.TimeSinceLastChange = 0f;
				}
			}
		}

		// Token: 0x06001112 RID: 4370 RVA: 0x00020368 File Offset: 0x0001E568
		internal void OnDirectoryContentsChanged(object sender, FileChangedEventArgs e)
		{
			string path = e.FullPath.FullName;
			this.AddChangedFile(path);
		}

		// Token: 0x06001113 RID: 4371 RVA: 0x0002038C File Offset: 0x0001E58C
		internal void OnDirectoryContentsRenamed(object sender, FileRenamedEventArgs e)
		{
			string path = e.FullPath.FullName;
			string oldpath = e.OldFullPath.FullName;
			this.AddChangedFile(path);
			this.AddChangedFile(oldpath);
		}

		// Token: 0x06001114 RID: 4372 RVA: 0x000203C8 File Offset: 0x0001E5C8
		public async Task<uint> GetCRC(string filename)
		{
			uint result;
			try
			{
				using (Stream s = this.OpenRead(filename, FileMode.Open))
				{
					result = await Crc32.FromStreamAsync(s);
				}
			}
			catch (FileNotFoundException)
			{
				result = 0U;
			}
			return result;
		}

		// Token: 0x06001115 RID: 4373 RVA: 0x00020413 File Offset: 0x0001E613
		public long FileSize(string filename)
		{
			return this.system.GetFileLength(BaseFileSystem.FixPath(filename));
		}

		// Token: 0x06001116 RID: 4374 RVA: 0x0002042B File Offset: 0x0001E62B
		internal void Mount(BaseFileSystem filesystem)
		{
			if (filesystem == null)
			{
				return;
			}
			(this.system as AggregateFileSystem).AddFileSystem(filesystem.system);
		}

		// Token: 0x06001117 RID: 4375 RVA: 0x00020447 File Offset: 0x0001E647
		internal void UnMount(BaseFileSystem filesystem)
		{
			if (filesystem == null)
			{
				return;
			}
			if (filesystem.system == null)
			{
				return;
			}
			(this.system as AggregateFileSystem).RemoveFileSystem(filesystem.system);
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x0002046C File Offset: 0x0001E66C
		internal void UnMountAll()
		{
			(this.system as AggregateFileSystem).ClearFileSystems();
		}

		/// <summary>
		/// Mount this path on the filesystem, so it's accesisble in Mount
		/// </summary>
		// Token: 0x06001119 RID: 4377 RVA: 0x00020480 File Offset: 0x0001E680
		internal BaseFileSystem CreateAndMount(BaseFileSystem system, string path)
		{
			BaseFileSystem sub = system.CreateSubSystem(path);
			this.Mount(sub);
			return sub;
		}

		/// <summary>
		/// Zio wants good paths to start with '/' - so we add it here if it isn't already on
		/// </summary>
		// Token: 0x0600111A RID: 4378 RVA: 0x0002049D File Offset: 0x0001E69D
		internal static string FixPath(string path)
		{
			if (path.Length < 1)
			{
				return "/";
			}
			if (path[0] == '/')
			{
				return path;
			}
			return "/" + path;
		}

		// Token: 0x04001368 RID: 4968
		private static Logger log = Logging.GetLogger(null);

		// Token: 0x04001369 RID: 4969
		internal IFileSystem system;

		// Token: 0x0400136A RID: 4970
		internal IFileSystemWatcher watcher;

		// Token: 0x0400136B RID: 4971
		internal List<FileWatch> watchers;

		// Token: 0x0400136C RID: 4972
		internal List<string> changedFiles;

		// Token: 0x0400136D RID: 4973
		public bool WatchEnabled = true;

		// Token: 0x0400136E RID: 4974
		private static Stopwatch timeSinceActivity = Stopwatch.StartNew();
	}
}
