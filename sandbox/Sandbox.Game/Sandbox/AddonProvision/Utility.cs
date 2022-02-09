using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Sandbox.Internal;

namespace Sandbox.AddonProvision
{
	/// <summary>
	/// Downloading and getting information about a specific addon.
	/// </summary>
	/// <summary>
	/// Downloading and getting information about a specific addon.
	/// </summary>
	// Token: 0x0200010A RID: 266
	internal static class Utility
	{
		// Token: 0x0600156F RID: 5487 RVA: 0x00055438 File Offset: 0x00053638
		internal static async Task<bool> FindAndDownloadGamemode(string gamemode, CancellationToken cancelToken)
		{
			IMenuAddon.SetLoadingStatus("Getting Game Information", "Looking Up..");
			Package package = await Package.FindAsync(gamemode);
			bool result;
			if (cancelToken.IsCancellationRequested)
			{
				result = true;
			}
			else if (package == null)
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Gamemode {0} not found!", new object[] { gamemode }));
				await Task.Delay(16);
				result = false;
			}
			else if (ServerAddons.TryLoadLocal(gamemode))
			{
				IMenuAddon.SetLoadingStatus("Getting Game Information", "Done");
				result = true;
			}
			else if (package.Download == null)
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Gamemode found - but there is no download config!", Array.Empty<object>()));
				result = false;
			}
			else
			{
				BaseAddonProvider provider = BaseAddonProvider.FindProvider(package.Download.Type, package.Download.Url, new BaseAddonProvider.ProgressDelegate(IMenuAddon.DownloadProgressCallback));
				if (provider != null)
				{
					IMenuAddon.SetLoadingStatus("Getting Game Information", "Downloading Information");
					BaseFileSystem filesystem = await provider.Download(cancelToken);
					if (cancelToken.IsCancellationRequested)
					{
						result = true;
					}
					else if (filesystem == null)
					{
						GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Download error.", Array.Empty<object>()));
						result = false;
					}
					else
					{
						if (ServerAddons.Add(gamemode, filesystem, true) == null)
						{
							filesystem.Dispose();
						}
						Content content = new Content(filesystem);
						content.ClientShouldInstall = true;
						content.Ident = gamemode;
						IMenuAddon.SetLoadingStatus("Getting Game Information", "Done");
						result = true;
					}
				}
				else
				{
					GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Gamemode found - but I don't know how to download it [url is \"{0}\"]!", new object[] { package.Download.Url }));
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06001570 RID: 5488 RVA: 0x00055484 File Offset: 0x00053684
		internal static async Task<bool> FindAndDownloadMap(string mapName, CancellationToken cancelToken)
		{
			bool result;
			if (Utility.IsLocalMap(mapName))
			{
				result = true;
			}
			else
			{
				IMenuAddon.SetLoadingStatus("Getting Map Information", "Looking Up");
				Package package = await Package.Fetch(mapName, false);
				Package assetInfo = package;
				if (cancelToken.IsCancellationRequested)
				{
					result = true;
				}
				else if (assetInfo == null)
				{
					GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Map {0} not found!", new object[] { mapName }));
					result = false;
				}
				else
				{
					BaseAddonProvider provider = BaseAddonProvider.FindProvider(assetInfo.Download.Type, assetInfo.Download.Url, new BaseAddonProvider.ProgressDelegate(IMenuAddon.DownloadProgressCallback));
					if (provider != null)
					{
						IMenuAddon.SetLoadingStatus("Getting Map Information", "Downloading");
						BaseFileSystem filesystem = await provider.Download(cancelToken);
						if (cancelToken.IsCancellationRequested)
						{
							result = true;
						}
						else if (filesystem == null)
						{
							GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Download error.", Array.Empty<object>()));
							result = false;
						}
						else
						{
							IMenuAddon.SetLoadingStatus("Getting Map Information", "Mounting");
							Content content = new Content(filesystem);
							content.ClientShouldInstall = true;
							content.Ident = assetInfo.FullIdent;
							IMenuAddon.SetLoadingStatus("Getting Map Information", "Done");
							result = true;
						}
					}
					else
					{
						GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Map found - but I don't know how to download it [url is \"{0}\"]!", new object[] { assetInfo.Download.Url }));
						result = false;
					}
				}
			}
			return result;
		}

		// Token: 0x06001571 RID: 5489 RVA: 0x000554CF File Offset: 0x000536CF
		private static bool IsLocalMap(string mapname)
		{
			return !mapname.Contains('.');
		}
	}
}
