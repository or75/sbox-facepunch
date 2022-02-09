using System;
using System.Collections.Generic;
using System.Linq;
using Sandbox;

namespace Tools
{
	// Token: 0x02000075 RID: 117
	public static class AssetSystem
	{
		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060012BA RID: 4794 RVA: 0x00050FC3 File Offset: 0x0004F1C3
		public static IEnumerable<Asset> All
		{
			get
			{
				return AssetSystem.allAssets.Values;
			}
		}

		// Token: 0x060012BB RID: 4795 RVA: 0x00050FD0 File Offset: 0x0004F1D0
		internal static void AssetAdded(global::IAsset native)
		{
			Asset a = new Asset(native);
			AssetSystem.allAssets[a.AssetId] = a;
		}

		// Token: 0x060012BC RID: 4796 RVA: 0x00050FF5 File Offset: 0x0004F1F5
		internal static void AssetRemoved(uint index)
		{
			Asset asset = AssetSystem.allAssets[index];
			Assert.NotNull<Asset>(asset);
			AssetSystem.allAssets.Remove(index);
			asset.OnRemoved();
		}

		// Token: 0x060012BD RID: 4797 RVA: 0x00051019 File Offset: 0x0004F219
		internal static void AssetChanged(uint index)
		{
			AssetSystem.allAssets[index].UpdateInternals();
		}

		// Token: 0x060012BE RID: 4798 RVA: 0x0005102C File Offset: 0x0004F22C
		internal static void AssetScanComplete()
		{
			foreach (Asset asset in AssetSystem.allAssets.Values)
			{
				asset.UpdateInternals();
			}
		}

		// Token: 0x060012BF RID: 4799 RVA: 0x00051080 File Offset: 0x0004F280
		public static Asset FindByPath(string path)
		{
			path = path.Replace('\\', '/');
			return AssetSystem.allAssets.Values.FirstOrDefault((Asset x) => string.Equals(x.AbsolutePath, path, StringComparison.OrdinalIgnoreCase));
		}

		// Token: 0x060012C0 RID: 4800 RVA: 0x000510CA File Offset: 0x0004F2CA
		internal static Asset Get(global::IAsset asset)
		{
			return AssetSystem.allAssets[asset.GetAssetIndexInt()];
		}

		// Token: 0x0400017A RID: 378
		private static Dictionary<uint, Asset> allAssets = new Dictionary<uint, Asset>();
	}
}
