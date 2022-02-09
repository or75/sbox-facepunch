using System;
using System.Runtime.InteropServices;
using Sandbox;
using Tools;

namespace Managed.SourceAssetSytem
{
	// Token: 0x0200006A RID: 106
	internal static class Exports
	{
		/// <summary>
		/// Tools.AssetSystem.AssetAdded( ... )
		/// </summary>
		// Token: 0x0600125A RID: 4698 RVA: 0x0004FEC0 File Offset: 0x0004E0C0
		[UnmanagedCallersOnly]
		internal static void Tools_AssetS_AssetAdded(IntPtr asset)
		{
			try
			{
				AssetSystem.AssetAdded(asset);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.AssetSystem", "AssetAdded", ___e);
			}
		}

		/// <summary>
		/// Tools.AssetSystem.AssetRemoved( ... )
		/// </summary>
		// Token: 0x0600125B RID: 4699 RVA: 0x0004FF00 File Offset: 0x0004E100
		[UnmanagedCallersOnly]
		internal static void Tools_AssetS_AssetRemoved(uint index)
		{
			try
			{
				AssetSystem.AssetRemoved(index);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.AssetSystem", "AssetRemoved", ___e);
			}
		}

		/// <summary>
		/// Tools.AssetSystem.AssetChanged( ... )
		/// </summary>
		// Token: 0x0600125C RID: 4700 RVA: 0x0004FF38 File Offset: 0x0004E138
		[UnmanagedCallersOnly]
		internal static void Tools_AssetS_AssetChanged(uint index)
		{
			try
			{
				AssetSystem.AssetChanged(index);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.AssetSystem", "AssetChanged", ___e);
			}
		}

		/// <summary>
		/// Tools.AssetSystem.AssetScanComplete( ... )
		/// </summary>
		// Token: 0x0600125D RID: 4701 RVA: 0x0004FF70 File Offset: 0x0004E170
		[UnmanagedCallersOnly]
		internal static void Tools_AssetS_AssetScanComplete()
		{
			try
			{
				AssetSystem.AssetScanComplete();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.AssetSystem", "AssetScanComplete", ___e);
			}
		}
	}
}
