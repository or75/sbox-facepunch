using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x0200007B RID: 123
	public class SkyboxObject : SceneObject
	{
		// Token: 0x06000CC7 RID: 3271 RVA: 0x000411E1 File Offset: 0x0003F3E1
		internal SkyboxObject()
		{
		}

		// Token: 0x06000CC8 RID: 3272 RVA: 0x000411E9 File Offset: 0x0003F3E9
		internal SkyboxObject(HandleCreationData _)
		{
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x000411F1 File Offset: 0x0003F3F1
		internal override void OnNativeInit(CSceneObject ptr)
		{
			base.OnNativeInit(ptr);
			this.skyboxNative = (CSceneSkyBoxObject)ptr;
		}

		// Token: 0x06000CCA RID: 3274 RVA: 0x00041206 File Offset: 0x0003F406
		internal override void OnNativeDestroy()
		{
			base.OnNativeDestroy();
			this.skyboxNative = default(CSceneSkyBoxObject);
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x0004121A File Offset: 0x0003F41A
		public SkyboxObject(Material skyMaterial)
		{
			Host.AssertClient(".ctor");
			this.CreateThisNative(skyMaterial);
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x00041234 File Offset: 0x0003F434
		internal void CreateThisNative(Material skyMaterial)
		{
			try
			{
				HandleIndex.ForceNextObject(this);
				Assert.AreEqual<SkyboxObject>(CSceneSystem.CreateSkyBox(skyMaterial.native, SceneWorld.Current), this);
			}
			finally
			{
				HandleIndex.UsedNextObject(this);
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000CCD RID: 3277 RVA: 0x00041278 File Offset: 0x0003F478
		// (set) Token: 0x06000CCE RID: 3278 RVA: 0x0004127B File Offset: 0x0003F47B
		public Material SkyMaterial
		{
			get
			{
				return null;
			}
			set
			{
				this.skyboxNative.SetMaterial(value.native);
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000CCF RID: 3279 RVA: 0x00041290 File Offset: 0x0003F490
		// (set) Token: 0x06000CD0 RID: 3280 RVA: 0x000412EE File Offset: 0x0003F4EE
		public SkyboxObject.FogParamInfo FogParams
		{
			get
			{
				return new SkyboxObject.FogParamInfo
				{
					FogMinStart = this.skyboxNative.GetFogMinStart(),
					FogMinEnd = this.skyboxNative.GetFogMinEnd(),
					FogMaxStart = this.skyboxNative.GetFogMaxStart(),
					FogMaxEnd = this.skyboxNative.GetFogMaxEnd()
				};
			}
			set
			{
				this.skyboxNative.SetAngularFogParams(value.FogMinStart, value.FogMinEnd, value.FogMaxStart, value.FogMaxEnd);
			}
		}

		// Token: 0x06000CD1 RID: 3281 RVA: 0x00041313 File Offset: 0x0003F513
		public void SetSkyLighting(Vector3 ConstantSkyLight)
		{
			this.skyboxNative.SetLighting_ConstantColorHemisphere(ConstantSkyLight);
		}

		// Token: 0x06000CD2 RID: 3282 RVA: 0x00041321 File Offset: 0x0003F521
		public void SetSkyLighting(SkyboxObject.SkyLightInfo[] skyLights)
		{
		}

		// Token: 0x040001CC RID: 460
		private CSceneSkyBoxObject skyboxNative;

		// Token: 0x020001FF RID: 511
		public struct FogParamInfo
		{
			// Token: 0x04001092 RID: 4242
			public float FogMinStart;

			// Token: 0x04001093 RID: 4243
			public float FogMinEnd;

			// Token: 0x04001094 RID: 4244
			public float FogMaxStart;

			// Token: 0x04001095 RID: 4245
			public float FogMaxEnd;
		}

		// Token: 0x02000200 RID: 512
		public struct SkyLightInfo
		{
			// Token: 0x04001096 RID: 4246
			public Vector3 LightColor;

			// Token: 0x04001097 RID: 4247
			public Vector3 LightDirection;
		}
	}
}
