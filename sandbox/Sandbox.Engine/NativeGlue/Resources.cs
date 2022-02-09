using System;
using NativeEngine;
using Sandbox;

namespace NativeGlue
{
	// Token: 0x020001EF RID: 495
	internal static class Resources
	{
		// Token: 0x06000C8A RID: 3210 RVA: 0x000157E8 File Offset: 0x000139E8
		internal static bool LoadResource(string name)
		{
			method glue_Resrce_LoadResource = Resources.__N.Glue_Resrce_LoadResource;
			return calli(System.Int32(System.IntPtr), Interop.GetPointer(name), glue_Resrce_LoadResource) > 0;
		}

		// Token: 0x06000C8B RID: 3211 RVA: 0x0001580A File Offset: 0x00013A0A
		internal static void ReleaseCached()
		{
			calli(System.Void(), Resources.__N.Glue_Resrce_ReleaseCached);
		}

		// Token: 0x06000C8C RID: 3212 RVA: 0x00015818 File Offset: 0x00013A18
		internal static IMaterial GetMaterial(string name)
		{
			method glue_Resrce_GetMaterial = Resources.__N.Glue_Resrce_GetMaterial;
			return calli(System.IntPtr(System.IntPtr), Interop.GetPointer(name), glue_Resrce_GetMaterial);
		}

		// Token: 0x06000C8D RID: 3213 RVA: 0x0001583C File Offset: 0x00013A3C
		internal static ITexture GetTexture(string name)
		{
			method glue_Resrce_GetTexture = Resources.__N.Glue_Resrce_GetTexture;
			return calli(System.IntPtr(System.IntPtr), Interop.GetPointer(name), glue_Resrce_GetTexture);
		}

		// Token: 0x06000C8E RID: 3214 RVA: 0x00015860 File Offset: 0x00013A60
		internal static IModel GetModel(string name)
		{
			method glue_Resrce_GetModel = Resources.__N.Glue_Resrce_GetModel;
			return calli(System.IntPtr(System.IntPtr), Interop.GetPointer(name), glue_Resrce_GetModel);
		}

		// Token: 0x06000C8F RID: 3215 RVA: 0x00015884 File Offset: 0x00013A84
		internal static void EnsureResourceInManifest(string name)
		{
			method glue_Resrce_EnsureResourceInManifest = Resources.__N.Glue_Resrce_EnsureResourceInManifest;
			calli(System.Void(System.IntPtr), Interop.GetPointer(name), glue_Resrce_EnsureResourceInManifest);
		}

		// Token: 0x02000384 RID: 900
		internal static class __N
		{
			// Token: 0x040017BD RID: 6077
			internal static method Glue_Resrce_LoadResource;

			// Token: 0x040017BE RID: 6078
			internal static method Glue_Resrce_ReleaseCached;

			// Token: 0x040017BF RID: 6079
			internal static method Glue_Resrce_GetMaterial;

			// Token: 0x040017C0 RID: 6080
			internal static method Glue_Resrce_GetTexture;

			// Token: 0x040017C1 RID: 6081
			internal static method Glue_Resrce_GetModel;

			// Token: 0x040017C2 RID: 6082
			internal static method Glue_Resrce_EnsureResourceInManifest;
		}
	}
}
