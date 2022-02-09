using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.AddonProvision
{
	/// <summary>
	/// Downloading and getting information about a specific addon.
	/// </summary>
	// Token: 0x02000306 RID: 774
	internal class HttpAddonProvider : BaseAddonProvider
	{
		// Token: 0x060014C2 RID: 5314 RVA: 0x0002CA37 File Offset: 0x0002AC37
		public HttpAddonProvider(string url)
			: base(url)
		{
		}

		// Token: 0x060014C3 RID: 5315 RVA: 0x0002CA40 File Offset: 0x0002AC40
		public HttpAddonProvider(string url, BaseAddonProvider.ProgressDelegate callback)
			: base(url, callback)
		{
		}

		// Token: 0x060014C4 RID: 5316 RVA: 0x0002CA4A File Offset: 0x0002AC4A
		public override void Dispose()
		{
		}

		// Token: 0x060014C5 RID: 5317 RVA: 0x0002CA4C File Offset: 0x0002AC4C
		protected override async Task<string> DownloadInternal(CancellationToken cancelToken)
		{
			Uri uri = new Uri(base.Url);
			string repoFolder = "/http/" + uri.Host;
			this.TargetFileSystem.CreateDirectory(repoFolder);
			string urlPath = uri.AbsolutePath.Replace(".zip", "").Trim('/');
			urlPath = Regex.Replace(urlPath, "[^a-zA-Z0-9]", "_");
			repoFolder += "/";
			repoFolder += urlPath;
			string result;
			if (this.TargetFileSystem.DirectoryExists(repoFolder) && this.TargetFileSystem.FindFile(repoFolder, "*", true).Count<string>() > 0)
			{
				result = repoFolder;
			}
			else
			{
				this.TargetFileSystem.CreateDirectory(repoFolder);
				TaskAwaiter<bool> taskAwaiter = base.DownloadAndExtractZip(base.Url, repoFolder, cancelToken).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<bool> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<bool>);
				}
				if (!taskAwaiter.GetResult())
				{
					result = null;
				}
				else
				{
					result = repoFolder;
				}
			}
			return result;
		}
	}
}
