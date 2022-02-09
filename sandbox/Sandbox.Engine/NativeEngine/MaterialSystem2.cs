using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000234 RID: 564
	internal static class MaterialSystem2
	{
		// Token: 0x06000E6B RID: 3691 RVA: 0x00019794 File Offset: 0x00017994
		internal static IMaterial CreateRawMaterial(string materialName, string shader)
		{
			method gpMter_CreateRawMaterial = MaterialSystem2.__N.gpMter_CreateRawMaterial;
			return calli(System.IntPtr(System.IntPtr,System.IntPtr), Interop.GetPointer(materialName), Interop.GetPointer(shader), gpMter_CreateRawMaterial);
		}

		// Token: 0x06000E6C RID: 3692 RVA: 0x000197C0 File Offset: 0x000179C0
		internal static IMaterial CreateProceduralMaterialCopy(IMaterial hSrcMaterial, int nResourceType, bool bRecreateStaticBuffers)
		{
			method gpMter_CreateProceduralMaterialCopy = MaterialSystem2.__N.gpMter_CreateProceduralMaterialCopy;
			return calli(System.IntPtr(System.IntPtr,System.Int32,System.Int32), hSrcMaterial, nResourceType, bRecreateStaticBuffers ? 1 : 0, gpMter_CreateProceduralMaterialCopy);
		}

		// Token: 0x06000E6D RID: 3693 RVA: 0x000197EC File Offset: 0x000179EC
		internal static IMaterial FindOrCreateMaterialFromResource(string pResourceName)
		{
			method gpMter_FindOrCreateMaterialFromResource = MaterialSystem2.__N.gpMter_FindOrCreateMaterialFromResource;
			return calli(System.IntPtr(System.IntPtr), Interop.GetPointer(pResourceName), gpMter_FindOrCreateMaterialFromResource);
		}

		// Token: 0x02000399 RID: 921
		internal static class __N
		{
			// Token: 0x04001858 RID: 6232
			internal static method gpMter_CreateRawMaterial;

			// Token: 0x04001859 RID: 6233
			internal static method gpMter_CreateProceduralMaterialCopy;

			// Token: 0x0400185A RID: 6234
			internal static method gpMter_FindOrCreateMaterialFromResource;
		}
	}
}
