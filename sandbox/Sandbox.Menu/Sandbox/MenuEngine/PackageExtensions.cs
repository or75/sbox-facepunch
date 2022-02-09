using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using Sandbox.DataModel;
using Sandbox.Internal;

namespace Sandbox.MenuEngine
{
	// Token: 0x02000014 RID: 20
	public static class PackageExtensions
	{
		// Token: 0x06000068 RID: 104 RVA: 0x00003910 File Offset: 0x00001B10
		public static async Task UpdateDetails(this Package package)
		{
			Host.AssertMenu("UpdateDetails");
			ApiUpdateResult<Package> p = await Api.UpdateAsset(new
			{
				id = package.FullIdent,
				Title = package.Title,
				Summary = package.Summary,
				Description = package.Description,
				CategoryId = package.CategoryId
			}, "sandbox-asset-update");
			if (p != null)
			{
				if (p.Valid)
				{
					package.Title = p.Result.Title;
					package.CategoryId = p.Result.CategoryId;
					package.Description = p.Result.Description;
					package.Summary = p.Result.Summary;
				}
				else
				{
					GlobalGameNamespace.Log.Warning("Couldn't save!");
					foreach (ApiUpdateResult<Package>.Error error in p.Errors)
					{
						GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("\t{0}: {1}", new object[] { error.Name, error.Message }));
					}
				}
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003954 File Offset: 0x00001B54
		public static async Task UpdateConfig(this Package package)
		{
			Host.AssertMenu("UpdateConfig");
			string configJson = "";
			if (package.PackageType == Package.Type.Gamemode)
			{
				configJson = JsonSerializer.Serialize<GameConfiguration>(package.GameConfiguration, null);
			}
			ApiUpdateResult<Package> p = await Api.UpdateAsset(new
			{
				id = package.FullIdent,
				json = configJson
			}, "sandbox-asset-updateconfig");
			if (p != null)
			{
				if (p.Valid)
				{
					package.Title = p.Result.Title;
					package.ConfigJson = p.Result.ConfigJson;
				}
				else
				{
					GlobalGameNamespace.Log.Warning("Couldn't save!");
					foreach (ApiUpdateResult<Package>.Error error in p.Errors)
					{
						GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("\t{0}: {1}", new object[] { error.Name, error.Message }));
					}
				}
			}
		}
	}
}
