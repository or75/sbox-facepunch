using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Sandbox.Internal;

namespace Sandbox.AddonProvision
{
	/// <summary>
	/// Downloading and getting information about a specific addon.
	/// </summary>
	// Token: 0x02000304 RID: 772
	internal class BaseAddonProvider : IDisposable
	{
		// Token: 0x060014A6 RID: 5286 RVA: 0x0002C5B4 File Offset: 0x0002A7B4
		public static void ClearCache()
		{
			BaseAddonProvider.Cache.Clear();
		}

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x060014A7 RID: 5287 RVA: 0x0002C5C0 File Offset: 0x0002A7C0
		// (set) Token: 0x060014A8 RID: 5288 RVA: 0x0002C5C8 File Offset: 0x0002A7C8
		public string Url { get; set; }

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x060014A9 RID: 5289 RVA: 0x0002C5D1 File Offset: 0x0002A7D1
		// (set) Token: 0x060014AA RID: 5290 RVA: 0x0002C5D9 File Offset: 0x0002A7D9
		public string AddonFolder { get; internal set; }

		// Token: 0x060014AB RID: 5291 RVA: 0x0002C5E2 File Offset: 0x0002A7E2
		public BaseAddonProvider(string url)
		{
			this.Url = url;
		}

		// Token: 0x060014AC RID: 5292 RVA: 0x0002C5F1 File Offset: 0x0002A7F1
		public BaseAddonProvider(string url, BaseAddonProvider.ProgressDelegate callback)
			: this(url)
		{
			this.TargetProgress = (BaseAddonProvider.ProgressDelegate)Delegate.Combine(this.TargetProgress, callback);
		}

		// Token: 0x060014AD RID: 5293 RVA: 0x0002C611 File Offset: 0x0002A811
		public virtual void Dispose()
		{
		}

		// Token: 0x060014AE RID: 5294 RVA: 0x0002C613 File Offset: 0x0002A813
		public static BaseAddonProvider FindProvider(string type, string url, BaseAddonProvider.ProgressDelegate callback = null)
		{
			if (string.IsNullOrEmpty(type))
			{
				return null;
			}
			if (type == "github")
			{
				return new GithubAddonProvider(url, callback);
			}
			if (type == "upload")
			{
				return new HttpAddonProvider(url, callback);
			}
			return null;
		}

		// Token: 0x060014AF RID: 5295 RVA: 0x0002C64C File Offset: 0x0002A84C
		public async Task<BaseFileSystem> DownloadUsing(BaseFileSystem fs, CancellationToken cancelToken = default(CancellationToken))
		{
			this.TargetFileSystem = fs;
			BaseFileSystem cacheFs;
			BaseFileSystem result;
			if (BaseAddonProvider.Cache.TryGetValue(this.Url, out cacheFs))
			{
				result = cacheFs;
			}
			else
			{
				string str = await this.DownloadInternal(cancelToken);
				if (str == null)
				{
					result = null;
				}
				else
				{
					BaseFileSystem subSystem = this.TargetFileSystem.CreateSubSystem(str);
					BaseAddonProvider.Cache[this.Url] = subSystem;
					result = subSystem;
				}
			}
			return result;
		}

		// Token: 0x060014B0 RID: 5296 RVA: 0x0002C69F File Offset: 0x0002A89F
		public Task<BaseFileSystem> Download(CancellationToken cancelToken = default(CancellationToken))
		{
			return this.DownloadUsing(EngineFileSystem.DownloadedFiles, cancelToken);
		}

		// Token: 0x060014B1 RID: 5297 RVA: 0x0002C6AD File Offset: 0x0002A8AD
		protected virtual Task<string> DownloadInternal(CancellationToken cancelToken)
		{
			return null;
		}

		// Token: 0x060014B2 RID: 5298 RVA: 0x0002C6B0 File Offset: 0x0002A8B0
		public async Task<bool> DownloadAndExtractZip(string url, string folder, CancellationToken cancelToken)
		{
			HttpClient client = new HttpClient();
			byte[] bytes = null;
			Stopwatch sw = Stopwatch.StartNew();
			using (HttpResponseMessage response = client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancelToken).Result)
			{
				if (!response.IsSuccessStatusCode)
				{
					return false;
				}
				if (cancelToken.IsCancellationRequested)
				{
					return false;
				}
				long? total = response.Content.Headers.ContentLength;
				Stream stream = await response.Content.ReadAsStreamAsync(cancelToken);
				using (Stream contentStream = stream)
				{
					long bytesRead = 0L;
					byte[] buffer = new byte[16384];
					MemoryStream ms = new MemoryStream();
					bool isMoreToRead = true;
					while (isMoreToRead)
					{
						if (cancelToken.IsCancellationRequested)
						{
							return false;
						}
						int read = await contentStream.ReadAsync(buffer, 0, buffer.Length, cancelToken);
						if (read == 0)
						{
							isMoreToRead = false;
						}
						else
						{
							ms.Write(buffer, 0, read);
							bytesRead += (long)read;
							if (this.TargetProgress != null)
							{
								this.TargetProgress(bytesRead, total.GetValueOrDefault());
							}
						}
					}
					bytes = ms.ToArray();
					buffer = null;
					ms = null;
				}
				Stream contentStream = null;
				total = null;
			}
			HttpResponseMessage response = null;
			GlobalSystemNamespace.Log.Info(FormattableStringFactory.Create("Addon Download took {0} seconds ({1}) [{2}]", new object[]
			{
				sw.Elapsed.TotalSeconds,
				bytes.Length.FormatBytes(false),
				url
			}));
			bool result;
			if (bytes == null)
			{
				result = false;
			}
			else
			{
				result = await Task.Run<bool>(() => this.ExtractZip(bytes, folder));
			}
			return result;
		}

		/// <summary>
		/// Extract the zip to the target folder and filesystem
		/// </summary>
		// Token: 0x060014B3 RID: 5299 RVA: 0x0002C70C File Offset: 0x0002A90C
		public async Task<bool> ExtractZip(byte[] data, string targetFolder)
		{
			Stopwatch sw = Stopwatch.StartNew();
			bool result;
			using (MemoryStream stream = new MemoryStream(data))
			{
				using (ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Read))
				{
					string skip = "";
					ZipArchiveEntry first = archive.Entries.FirstOrDefault<ZipArchiveEntry>();
					if (first == null)
					{
						result = false;
					}
					else
					{
						int firstSlash = first.FullName.IndexOf('/');
						if (firstSlash > 0)
						{
							string firstDir = first.FullName.Substring(0, firstSlash + 1);
							if (archive.Entries.All((ZipArchiveEntry x) => x.FullName.StartsWith(firstDir)))
							{
								skip = firstDir;
							}
						}
						foreach (ZipArchiveEntry file in archive.Entries)
						{
							string fullname = file.FullName;
							if (!fullname.EndsWith("/") && !fullname.Contains("/content_src/") && !fullname.Contains("..") && !fullname.Contains(":") && !fullname.Contains("_bakeresourcecache") && !fullname.EndsWith(".tga") && !fullname.EndsWith(".wav") && !fullname.EndsWith(".fbx") && !fullname.EndsWith(".vmap") && !fullname.EndsWith(".los") && !fullname.EndsWith(".exe") && !fullname.EndsWith(".dll") && !fullname.EndsWith(".bat") && !fullname.EndsWith(".los") && !fullname.EndsWith(".vmap"))
							{
								if (skip.Length > 0)
								{
									fullname = fullname.Substring(skip.Length);
								}
								string destinationFile = targetFolder + "/" + fullname;
								this.TargetFileSystem.CreateDirectory(Path.GetDirectoryName(destinationFile));
								try
								{
									using (Stream s = file.Open())
									{
										using (Stream w = this.TargetFileSystem.OpenWrite(destinationFile, FileMode.Create))
										{
											await s.CopyToAsync(w);
										}
										Stream w = null;
									}
									Stream s = null;
								}
								catch (Exception e)
								{
									GlobalSystemNamespace.Log.Warning(e, "Error extracting zip");
									return false;
								}
							}
						}
						IEnumerator<ZipArchiveEntry> enumerator = null;
						GlobalSystemNamespace.Log.Info(FormattableStringFactory.Create("Addon Unzip took {0} seconds", new object[] { sw.Elapsed.TotalSeconds }));
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x060014B4 RID: 5300 RVA: 0x0002C760 File Offset: 0x0002A960
		protected async Task<T> HttpGet<T>(string url)
		{
			T result;
			try
			{
				using (HttpClient wc = new HttpClient())
				{
					wc.DefaultRequestHeaders.Add("User-Agent", "sbox.facepunch.com");
					result = await wc.GetFromJsonAsync(url, default(CancellationToken));
				}
			}
			catch (Exception e)
			{
				GlobalSystemNamespace.Log.Warning(e, FormattableStringFactory.Create("Exception getting {0} from url {1}", new object[]
				{
					typeof(T),
					url
				}));
				result = default(T);
			}
			return result;
		}

		// Token: 0x0400155E RID: 5470
		protected static Dictionary<string, BaseFileSystem> Cache = new Dictionary<string, BaseFileSystem>();

		// Token: 0x04001561 RID: 5473
		protected BaseAddonProvider.ProgressDelegate TargetProgress;

		// Token: 0x04001562 RID: 5474
		protected BaseFileSystem TargetFileSystem;

		// Token: 0x0200046D RID: 1133
		// (Invoke) Token: 0x06001993 RID: 6547
		public delegate void ProgressDelegate(long downloaded, long total);
	}
}
