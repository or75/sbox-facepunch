using System;
using System.Collections.Generic;
using NativeEngine;
using Sandbox;

namespace Tools
{
	// Token: 0x02000074 RID: 116
	public class Asset
	{
		// Token: 0x060012A8 RID: 4776 RVA: 0x00050D79 File Offset: 0x0004EF79
		internal Asset(global::IAsset native)
		{
			this.native = native;
			this.AssetId = native.GetAssetIndexInt();
		}

		// Token: 0x060012A9 RID: 4777 RVA: 0x00050D98 File Offset: 0x0004EF98
		internal void UpdateInternals()
		{
			this.AssetId = this.native.GetAssetIndexInt();
			this.Name = this.native.GetFriendlyName_Transient().NormalizeFilename(false);
			this.Path = this.native.GetRelativePath_Transient(AssetLocation_t.Invalid).NormalizeFilename(false);
			this.AbsolutePath = this.native.GetAbsolutePath_Transient(AssetLocation_t.Invalid).NormalizeFilename(false);
			if (this.cachedThumb != null)
			{
				this.cachedThumb = null;
				Event.Run<Asset>("asset.thumb.changed", this);
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060012AA RID: 4778 RVA: 0x00050E17 File Offset: 0x0004F017
		// (set) Token: 0x060012AB RID: 4779 RVA: 0x00050E1F File Offset: 0x0004F01F
		internal uint AssetId { get; private set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060012AC RID: 4780 RVA: 0x00050E28 File Offset: 0x0004F028
		// (set) Token: 0x060012AD RID: 4781 RVA: 0x00050E30 File Offset: 0x0004F030
		public string Name { get; protected set; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060012AE RID: 4782 RVA: 0x00050E39 File Offset: 0x0004F039
		// (set) Token: 0x060012AF RID: 4783 RVA: 0x00050E41 File Offset: 0x0004F041
		public string Path { get; protected set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060012B0 RID: 4784 RVA: 0x00050E4A File Offset: 0x0004F04A
		// (set) Token: 0x060012B1 RID: 4785 RVA: 0x00050E52 File Offset: 0x0004F052
		public string AbsolutePath { get; protected set; }

		// Token: 0x060012B2 RID: 4786 RVA: 0x00050E5B File Offset: 0x0004F05B
		internal void OnRemoved()
		{
			this.native = default(global::IAsset);
			this.cachedThumb = null;
		}

		// Token: 0x060012B3 RID: 4787 RVA: 0x00050E70 File Offset: 0x0004F070
		public string GetCompiledFile(bool absolute = false)
		{
			if (absolute)
			{
				return this.native.GetAbsolutePath_Transient(AssetLocation_t.Game).NormalizeFilename(false);
			}
			return this.native.GetRelativePath_Transient(AssetLocation_t.Game).NormalizeFilename(false);
		}

		// Token: 0x060012B4 RID: 4788 RVA: 0x00050E9A File Offset: 0x0004F09A
		public string GetSourceFile(bool absolute = false)
		{
			if (absolute)
			{
				return this.native.GetAbsolutePath_Transient(AssetLocation_t.Content).NormalizeFilename(false);
			}
			return this.native.GetRelativePath_Transient(AssetLocation_t.Content).NormalizeFilename(false);
		}

		// Token: 0x060012B5 RID: 4789 RVA: 0x00050EC4 File Offset: 0x0004F0C4
		public Pixmap GetAssetThumb(bool generateIfNotInCache = true)
		{
			bool skipCache = false;
			if (!this.isFullThumb && generateIfNotInCache)
			{
				skipCache = true;
				this.isFullThumb = true;
			}
			if (this.cachedThumb != null && !skipCache)
			{
				return this.cachedThumb;
			}
			if (this.cachedThumb == null)
			{
				this.cachedThumb = new Pixmap(256, 256);
			}
			IAssetPreviewSystem.GetThumbnailForAsset(this.native, this.cachedThumb.ptr, generateIfNotInCache);
			return this.cachedThumb;
		}

		// Token: 0x060012B6 RID: 4790 RVA: 0x00050F36 File Offset: 0x0004F136
		public void RebuildThumbnail()
		{
			IAssetPreviewSystem.RefreshThumbnailForAsset(this.native);
		}

		// Token: 0x060012B7 RID: 4791 RVA: 0x00050F43 File Offset: 0x0004F143
		public void OpenInEditor()
		{
			this.native.OpenInTool();
		}

		// Token: 0x060012B8 RID: 4792 RVA: 0x00050F54 File Offset: 0x0004F154
		public List<Asset> GetReferences(bool deep)
		{
			CUtlVectorAsset list = CUtlVectorAsset.Create(4, 4);
			this.native.GetAssetsIReference(list, deep);
			return this.GetAssetList(list, true);
		}

		// Token: 0x060012B9 RID: 4793 RVA: 0x00050F80 File Offset: 0x0004F180
		private List<Asset> GetAssetList(CUtlVectorAsset v, bool free)
		{
			List<Asset> i = new List<Asset>();
			for (int j = 0; j < v.Count(); j++)
			{
				i.Add(AssetSystem.Get(v.Element(j)));
			}
			if (free)
			{
				v.DeleteThis();
			}
			return i;
		}

		// Token: 0x04000173 RID: 371
		internal global::IAsset native;

		// Token: 0x04000178 RID: 376
		private bool isFullThumb;

		// Token: 0x04000179 RID: 377
		private Pixmap cachedThumb;
	}
}
