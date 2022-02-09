using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandbox.MenuEngine
{
	// Token: 0x02000015 RID: 21
	public static class Packages
	{
		/// <summary>
		/// Find package information
		/// </summary>
		// Token: 0x0600006A RID: 106 RVA: 0x00003998 File Offset: 0x00001B98
		public static async Task<Package[]> GetPackage(Package.Type type, string order = "popular", int category = 0, string searchText = null, List<string> tags = null)
		{
			Host.AssertMenu("GetPackage");
			Package[] result = await Api.QueryAssets(type, order, category, searchText, tags);
			Package[] result2;
			if (result == null)
			{
				result2 = null;
			}
			else
			{
				Package.Cache(result, true);
				result2 = result;
			}
			return result2;
		}

		/// <summary>
		/// Find package categories
		/// </summary>
		// Token: 0x0600006B RID: 107 RVA: 0x000039FC File Offset: 0x00001BFC
		public static async Task<Package.CategoryList> GetCategoryList(Package.Type type, List<string> tags = null)
		{
			Host.AssertMenu("GetCategoryList");
			return await Api.GetCategories(type, tags);
		}

		/// <summary>
		/// Rate package (thumbs up, thumbs down)
		/// </summary>
		// Token: 0x0600006C RID: 108 RVA: 0x00003A48 File Offset: 0x00001C48
		public static async Task Rate(Package package, bool up)
		{
			Host.AssertMenu("Rate");
			Package a = await Api.RateAsset(package.FullIdent, up);
			if (a != null)
			{
				package.Favourited = a.Favourited;
				package.VotesDown = a.VotesDown;
				package.VotesUp = a.VotesUp;
			}
		}
	}
}
