using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Sandbox.AddonProvision.Models.Github;

namespace Sandbox.AddonProvision
{
	/// <summary>
	/// Downloading and getting information about a specific addon.
	/// </summary>
	// Token: 0x02000305 RID: 773
	internal class GithubAddonProvider : BaseAddonProvider
	{
		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x060014B6 RID: 5302 RVA: 0x0002C7AF File Offset: 0x0002A9AF
		// (set) Token: 0x060014B7 RID: 5303 RVA: 0x0002C7B7 File Offset: 0x0002A9B7
		public string Organization { get; set; }

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x060014B8 RID: 5304 RVA: 0x0002C7C0 File Offset: 0x0002A9C0
		// (set) Token: 0x060014B9 RID: 5305 RVA: 0x0002C7C8 File Offset: 0x0002A9C8
		public string RepoName { get; set; }

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x060014BA RID: 5306 RVA: 0x0002C7D1 File Offset: 0x0002A9D1
		// (set) Token: 0x060014BB RID: 5307 RVA: 0x0002C7D9 File Offset: 0x0002A9D9
		public string Branch { get; set; }

		// Token: 0x060014BC RID: 5308 RVA: 0x0002C7E4 File Offset: 0x0002A9E4
		public GithubAddonProvider(string url)
			: base(url)
		{
			Match match = this.GithubURL(url);
			if (!match.Success)
			{
				throw new Exception("The github regex didn't match!");
			}
			this.Organization = match.Groups[1].Value;
			this.RepoName = match.Groups[2].Value;
			if (match.Groups[3].Success)
			{
				this.Branch = match.Groups[3].Value;
			}
		}

		// Token: 0x060014BD RID: 5309 RVA: 0x0002C86B File Offset: 0x0002AA6B
		public GithubAddonProvider(string url, BaseAddonProvider.ProgressDelegate callback)
			: this(url)
		{
			this.TargetProgress = (BaseAddonProvider.ProgressDelegate)Delegate.Combine(this.TargetProgress, callback);
		}

		// Token: 0x060014BE RID: 5310 RVA: 0x0002C88B File Offset: 0x0002AA8B
		public override void Dispose()
		{
		}

		// Token: 0x060014BF RID: 5311 RVA: 0x0002C88D File Offset: 0x0002AA8D
		private Match GithubURL(string url)
		{
			return Regex.Match(url, "https://github.com/([^/]+)/([^/]+)?(?:/tree/(.+))?");
		}

		// Token: 0x060014C0 RID: 5312 RVA: 0x0002C89C File Offset: 0x0002AA9C
		private List<GithubAddonProvider.Submodule> ParseSubmodules(string fileContents)
		{
			List<GithubAddonProvider.Submodule> output = new List<GithubAddonProvider.Submodule>();
			if (fileContents == null)
			{
				return output;
			}
			Parse p = new Parse(fileContents, "nofile");
			p.SkipWhitespaceAndNewlines(null);
			if (p.Current != '[')
			{
				return output;
			}
			while (!p.IsEnd)
			{
				string submoduleHeader = p.ReadInnerBrackets('[', ']');
				if (submoduleHeader == null || !submoduleHeader.StartsWith("submodule"))
				{
					break;
				}
				p.SkipWhitespaceAndNewlines(null);
				GithubAddonProvider.Submodule submodule = new GithubAddonProvider.Submodule
				{
					Path = null,
					Url = null
				};
				while (p.Current != '[' && !p.IsEnd)
				{
					string key = p.ReadWord(null, false);
					if (key == null)
					{
						break;
					}
					p.ReadUntilOrEnd("=", false);
					p.Pointer++;
					p.SkipWhitespaceAndNewlines(null);
					string value = p.ReadWord(null, false);
					p.SkipWhitespaceAndNewlines(null);
					if (!(key == "path"))
					{
						if (key == "url")
						{
							submodule.Url = value;
						}
					}
					else
					{
						submodule.Path = value;
					}
				}
				if (submodule.Url != null && submodule.Path != null && this.GithubURL(submodule.Url).Success)
				{
					output.Add(submodule);
				}
			}
			return output;
		}

		// Token: 0x060014C1 RID: 5313 RVA: 0x0002C9EC File Offset: 0x0002ABEC
		protected override async Task<string> DownloadInternal(CancellationToken cancelToken)
		{
			if (string.IsNullOrWhiteSpace(this.Branch))
			{
				RepoInfo repoInfo = await base.HttpGet<RepoInfo>("https://api.github.com/repos/" + this.Organization + "/" + this.RepoName);
				if (repoInfo == null)
				{
					return null;
				}
				this.Branch = repoInfo.Default_Branch ?? "master";
			}
			string result;
			if (cancelToken.IsCancellationRequested)
			{
				result = null;
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 3);
				defaultInterpolatedStringHandler.AppendLiteral("/github/");
				defaultInterpolatedStringHandler.AppendFormatted(this.Organization);
				defaultInterpolatedStringHandler.AppendLiteral("-");
				defaultInterpolatedStringHandler.AppendFormatted(this.RepoName);
				defaultInterpolatedStringHandler.AppendLiteral("-");
				defaultInterpolatedStringHandler.AppendFormatted(this.Branch);
				string repoFolder = defaultInterpolatedStringHandler.ToStringAndClear();
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 3);
				defaultInterpolatedStringHandler.AppendLiteral("https://api.github.com/repos/");
				defaultInterpolatedStringHandler.AppendFormatted(this.Organization);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted(this.RepoName);
				defaultInterpolatedStringHandler.AppendLiteral("/branches/");
				defaultInterpolatedStringHandler.AppendFormatted(this.Branch);
				BranchInfo data = await base.HttpGet<BranchInfo>(defaultInterpolatedStringHandler.ToStringAndClear());
				if (data == null)
				{
					result = null;
				}
				else if (cancelToken.IsCancellationRequested)
				{
					result = null;
				}
				else
				{
					repoFolder = repoFolder + "/" + data.Commit.Sha;
					if (this.TargetFileSystem.DirectoryExists(repoFolder) && this.TargetFileSystem.FindFile(repoFolder, "*", false).Any<string>())
					{
						result = repoFolder;
					}
					else
					{
						this.TargetFileSystem.CreateDirectory(repoFolder);
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 3);
						defaultInterpolatedStringHandler.AppendLiteral("https://github.com/");
						defaultInterpolatedStringHandler.AppendFormatted(this.Organization);
						defaultInterpolatedStringHandler.AppendLiteral("/");
						defaultInterpolatedStringHandler.AppendFormatted(this.RepoName);
						defaultInterpolatedStringHandler.AppendLiteral("/zipball/");
						defaultInterpolatedStringHandler.AppendFormatted(this.Branch);
						TaskAwaiter<bool> taskAwaiter = base.DownloadAndExtractZip(defaultInterpolatedStringHandler.ToStringAndClear(), repoFolder, cancelToken).GetAwaiter();
						TaskAwaiter<bool> taskAwaiter2;
						if (!taskAwaiter.IsCompleted)
						{
							await taskAwaiter;
							taskAwaiter = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter<bool>);
						}
						if (!taskAwaiter.GetResult())
						{
							result = null;
						}
						else
						{
							if (this.TargetFileSystem.FileExists(repoFolder + "/.gitmodules"))
							{
								List<GithubAddonProvider.Submodule> submoduleList = this.ParseSubmodules(this.TargetFileSystem.ReadAllText(repoFolder + "/.gitmodules"));
								Dictionary<string, List<Content>> CachedFileContent = new Dictionary<string, List<Content>>();
								if (cancelToken.IsCancellationRequested)
								{
									return null;
								}
								foreach (GithubAddonProvider.Submodule submodule in submoduleList)
								{
									DirectoryInfo parent = Directory.GetParent(submodule.Path);
									string parentPath = ((parent != null) ? parent.Name : null) ?? submodule.Path;
									List<Content> githubContentListing;
									if (!CachedFileContent.TryGetValue(parentPath, out githubContentListing))
									{
										Dictionary<string, List<Content>> dictionary = CachedFileContent;
										string key = parentPath;
										defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 4);
										defaultInterpolatedStringHandler.AppendLiteral("https://api.github.com/repos/");
										defaultInterpolatedStringHandler.AppendFormatted(this.Organization);
										defaultInterpolatedStringHandler.AppendLiteral("/");
										defaultInterpolatedStringHandler.AppendFormatted(this.RepoName);
										defaultInterpolatedStringHandler.AppendLiteral("/contents/");
										defaultInterpolatedStringHandler.AppendFormatted(parentPath);
										defaultInterpolatedStringHandler.AppendLiteral("?ref=");
										defaultInterpolatedStringHandler.AppendFormatted(this.Branch);
										dictionary[key] = await base.HttpGet<List<Content>>(defaultInterpolatedStringHandler.ToStringAndClear());
										List<Content> list;
										githubContentListing = list;
										dictionary = null;
										key = null;
										if (cancelToken.IsCancellationRequested)
										{
											return null;
										}
									}
									foreach (Content content in githubContentListing)
									{
										if (!(content.Path != submodule.Path))
										{
											string submoduleTargetDirectory = repoFolder + "/" + submodule.Path;
											Match match = this.GithubURL(submodule.Url);
											if (match.Success)
											{
												string submoduleOranization = match.Groups[1].Value;
												string submoduleRepoName = match.Groups[2].Value;
												if (submoduleRepoName.EndsWith(".git"))
												{
													submoduleRepoName = submoduleRepoName.Substring(0, submoduleRepoName.Length - 4);
												}
												if (!this.TargetFileSystem.DirectoryExists(submoduleTargetDirectory))
												{
													this.TargetFileSystem.CreateDirectory(submoduleTargetDirectory);
												}
												defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 3);
												defaultInterpolatedStringHandler.AppendLiteral("https://github.com/");
												defaultInterpolatedStringHandler.AppendFormatted(submoduleOranization);
												defaultInterpolatedStringHandler.AppendLiteral("/");
												defaultInterpolatedStringHandler.AppendFormatted(submoduleRepoName);
												defaultInterpolatedStringHandler.AppendLiteral("/zipball/");
												defaultInterpolatedStringHandler.AppendFormatted(content.Sha);
												taskAwaiter = base.DownloadAndExtractZip(defaultInterpolatedStringHandler.ToStringAndClear(), submoduleTargetDirectory, cancelToken).GetAwaiter();
												if (!taskAwaiter.IsCompleted)
												{
													await taskAwaiter;
													taskAwaiter = taskAwaiter2;
													taskAwaiter2 = default(TaskAwaiter<bool>);
												}
												if (!taskAwaiter.GetResult())
												{
													return null;
												}
											}
										}
									}
									List<Content>.Enumerator enumerator2 = default(List<Content>.Enumerator);
									submodule = default(GithubAddonProvider.Submodule);
								}
								List<GithubAddonProvider.Submodule>.Enumerator enumerator = default(List<GithubAddonProvider.Submodule>.Enumerator);
								CachedFileContent = null;
							}
							result = repoFolder;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x02000474 RID: 1140
		private struct Submodule
		{
			// Token: 0x04001C3D RID: 7229
			public string Path;

			// Token: 0x04001C3E RID: 7230
			public string Url;
		}
	}
}
