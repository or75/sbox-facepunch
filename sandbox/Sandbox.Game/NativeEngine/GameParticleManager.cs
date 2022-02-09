using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000057 RID: 87
	internal static class GameParticleManager
	{
		// Token: 0x06000B8C RID: 2956 RVA: 0x0003C54C File Offset: 0x0003A74C
		internal static int CreateParticleIndex(int hostIndex, string name, ParticleAttachment attachment, IntPtr ent)
		{
			method sbxPrt_CreateParticleIndex = GameParticleManager.__N.SBxPrt_CreateParticleIndex;
			return calli(System.Int32(System.Int32,System.IntPtr,System.Int64,System.IntPtr), hostIndex, Interop.GetPointer(name), (long)attachment, ent, sbxPrt_CreateParticleIndex);
		}

		// Token: 0x06000B8D RID: 2957 RVA: 0x0003C570 File Offset: 0x0003A770
		internal unsafe static bool SetParticleControl(int particleIndex, int iPoint, Vector3 vecPosition)
		{
			method sbxPrt_SetParticleControl = GameParticleManager.__N.SBxPrt_SetParticleControl;
			return calli(System.Int32(System.Int32,System.Int32,Vector3*), particleIndex, iPoint, &vecPosition, sbxPrt_SetParticleControl) > 0;
		}

		// Token: 0x06000B8E RID: 2958 RVA: 0x0003C594 File Offset: 0x0003A794
		internal unsafe static bool SetParticleControlForward(int iIndex, int iPoint, Vector3 vecForward)
		{
			method sbxPrt_SetParticleControlForward = GameParticleManager.__N.SBxPrt_SetParticleControlForward;
			return calli(System.Int32(System.Int32,System.Int32,Vector3*), iIndex, iPoint, &vecForward, sbxPrt_SetParticleControlForward) > 0;
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x0003C5B8 File Offset: 0x0003A7B8
		internal unsafe static bool SetParticleControlOrientation(int particleIndex, int iPoint, Angles angles)
		{
			method sbxPrt_SetParticleControlOrientation = GameParticleManager.__N.SBxPrt_SetParticleControlOrientation;
			return calli(System.Int32(System.Int32,System.Int32,Angles*), particleIndex, iPoint, &angles, sbxPrt_SetParticleControlOrientation) > 0;
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x0003C5DC File Offset: 0x0003A7DC
		internal unsafe static bool SetParticleControlFallback(int particleIndex, int iPoint, Vector3 vecPosition)
		{
			method sbxPrt_SetParticleControlFallback = GameParticleManager.__N.SBxPrt_SetParticleControlFallback;
			return calli(System.Int32(System.Int32,System.Int32,Vector3*), particleIndex, iPoint, &vecPosition, sbxPrt_SetParticleControlFallback) > 0;
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x0003C600 File Offset: 0x0003A800
		internal static bool SetParticleControlEnt(int particleIndex, int iPoint, IntPtr pEnt, ParticleAttachment iAttachType, string pAttachmentName)
		{
			method sbxPrt_SetParticleControlEnt = GameParticleManager.__N.SBxPrt_SetParticleControlEnt;
			return calli(System.Int32(System.Int32,System.Int32,System.IntPtr,System.Int64,System.IntPtr), particleIndex, iPoint, pEnt, (long)iAttachType, Interop.GetPointer(pAttachmentName), sbxPrt_SetParticleControlEnt) > 0;
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x0003C628 File Offset: 0x0003A828
		internal unsafe static bool SetParticleControlEntBone(int particleIndex, int iPoint, IntPtr pEnt, ParticleAttachment iAttachType, int boneId, Transform offset)
		{
			method sbxPrt_SetParticleControlEntBone = GameParticleManager.__N.SBxPrt_SetParticleControlEntBone;
			return calli(System.Int32(System.Int32,System.Int32,System.IntPtr,System.Int64,System.Int32,Transform*), particleIndex, iPoint, pEnt, (long)iAttachType, boneId, &offset, sbxPrt_SetParticleControlEntBone) > 0;
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x0003C650 File Offset: 0x0003A850
		internal unsafe static bool SetParticleControlOffset(int particleIndex, int iPoint, Vector3 vecOriginOffset)
		{
			method sbxPrt_SetParticleControlOffset = GameParticleManager.__N.SBxPrt_SetParticleControlOffset;
			return calli(System.Int32(System.Int32,System.Int32,Vector3*), particleIndex, iPoint, &vecOriginOffset, sbxPrt_SetParticleControlOffset) > 0;
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x0003C674 File Offset: 0x0003A874
		internal unsafe static bool SetParticleControlOffset(int particleIndex, int iPoint, Vector3 vecOriginOffset, Angles angOffset)
		{
			method sbxPrt_f = GameParticleManager.__N.SBxPrt_f2;
			return calli(System.Int32(System.Int32,System.Int32,Vector3*,Angles*), particleIndex, iPoint, &vecOriginOffset, &angOffset, sbxPrt_f) > 0;
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x0003C698 File Offset: 0x0003A898
		internal static bool SetParticleControlModel(int iIndex, int iPoint, IModel hModel)
		{
			method sbxPrt_SetParticleControlModel = GameParticleManager.__N.SBxPrt_SetParticleControlModel;
			return calli(System.Int32(System.Int32,System.Int32,System.IntPtr), iIndex, iPoint, hModel, sbxPrt_SetParticleControlModel) > 0;
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x0003C6BC File Offset: 0x0003A8BC
		internal static bool SetParticleTextureAttribute(int iIndex, string pAttributeName, string pAttributeValue)
		{
			method sbxPrt_SetParticleTextureAttribute = GameParticleManager.__N.SBxPrt_SetParticleTextureAttribute;
			return calli(System.Int32(System.Int32,System.IntPtr,System.IntPtr), iIndex, Interop.GetPointer(pAttributeName), Interop.GetPointer(pAttributeValue), sbxPrt_SetParticleTextureAttribute) > 0;
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x0003C6E8 File Offset: 0x0003A8E8
		internal static bool SetParticleOverrideTexture(int particleIndex, ITexture hOverrideTexture)
		{
			method sbxPrt_SetParticleOverrideTexture = GameParticleManager.__N.SBxPrt_SetParticleOverrideTexture;
			return calli(System.Int32(System.Int32,System.IntPtr), particleIndex, hOverrideTexture, sbxPrt_SetParticleOverrideTexture) > 0;
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x0003C70C File Offset: 0x0003A90C
		internal static void ReleaseParticleIndex(int particleIndex)
		{
			method sbxPrt_ReleaseParticleIndex = GameParticleManager.__N.SBxPrt_ReleaseParticleIndex;
			calli(System.Void(System.Int32), particleIndex, sbxPrt_ReleaseParticleIndex);
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x0003C728 File Offset: 0x0003A928
		internal static void DestroyAllParticleEffectsInvolving(IntPtr pEnt, bool bDestroyImmediately)
		{
			method sbxPrt_DestroyAllParticleEffectsInvolving = GameParticleManager.__N.SBxPrt_DestroyAllParticleEffectsInvolving;
			calli(System.Void(System.IntPtr,System.Int32), pEnt, bDestroyImmediately ? 1 : 0, sbxPrt_DestroyAllParticleEffectsInvolving);
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x0003C74C File Offset: 0x0003A94C
		internal static void DestroyParticleEffect(int particleIndex, bool bDestroyImmediately)
		{
			method sbxPrt_DestroyParticleEffect = GameParticleManager.__N.SBxPrt_DestroyParticleEffect;
			calli(System.Void(System.Int32,System.Int32), particleIndex, bDestroyImmediately ? 1 : 0, sbxPrt_DestroyParticleEffect);
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x0003C770 File Offset: 0x0003A970
		internal static bool SetFrozen(int particleIndex, bool bFrozen)
		{
			method sbxPrt_SetFrozen = GameParticleManager.__N.SBxPrt_SetFrozen;
			return calli(System.Int32(System.Int32,System.Int32), particleIndex, bFrozen ? 1 : 0, sbxPrt_SetFrozen) > 0;
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x0003C794 File Offset: 0x0003A994
		internal static bool SetShouldDraw(int particleIndex, bool bShouldDraw)
		{
			method sbxPrt_SetShouldDraw = GameParticleManager.__N.SBxPrt_SetShouldDraw;
			return calli(System.Int32(System.Int32,System.Int32), particleIndex, bShouldDraw ? 1 : 0, sbxPrt_SetShouldDraw) > 0;
		}

		// Token: 0x06000B9D RID: 2973 RVA: 0x0003C7B8 File Offset: 0x0003A9B8
		internal static bool SetParticleText(int particleIndex, string pszText)
		{
			method sbxPrt_SetParticleText = GameParticleManager.__N.SBxPrt_SetParticleText;
			return calli(System.Int32(System.Int32,System.IntPtr), particleIndex, Interop.GetPointer(pszText), sbxPrt_SetParticleText) > 0;
		}

		// Token: 0x06000B9E RID: 2974 RVA: 0x0003C7DC File Offset: 0x0003A9DC
		internal static bool SetParticleAlwaysInstantiate(int particleIndex)
		{
			method sbxPrt_SetParticleAlwaysInstantiate = GameParticleManager.__N.SBxPrt_SetParticleAlwaysInstantiate;
			return calli(System.Int32(System.Int32), particleIndex, sbxPrt_SetParticleAlwaysInstantiate) > 0;
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x0003C7FC File Offset: 0x0003A9FC
		internal static bool SetParticleAlwaysSimulate(int particleIndex)
		{
			method sbxPrt_SetParticleAlwaysSimulate = GameParticleManager.__N.SBxPrt_SetParticleAlwaysSimulate;
			return calli(System.Int32(System.Int32), particleIndex, sbxPrt_SetParticleAlwaysSimulate) > 0;
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x0003C81C File Offset: 0x0003AA1C
		internal static bool SetParticleControlComponent(int particleIndex, int iPoint, int iComponent, float fValue)
		{
			method sbxPrt_SetParticleControlComponent = GameParticleManager.__N.SBxPrt_SetParticleControlComponent;
			return calli(System.Int32(System.Int32,System.Int32,System.Int32,System.Single), particleIndex, iPoint, iComponent, fValue, sbxPrt_SetParticleControlComponent) > 0;
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x0003C83C File Offset: 0x0003AA3C
		internal static bool SetParticleControlSnapshotAsset(int particleIndex, int iPoint, string assetName)
		{
			method sbxPrt_SetParticleControlSnapshotAsset = GameParticleManager.__N.SBxPrt_SetParticleControlSnapshotAsset;
			return calli(System.Int32(System.Int32,System.Int32,System.IntPtr), particleIndex, iPoint, Interop.GetPointer(assetName), sbxPrt_SetParticleControlSnapshotAsset) > 0;
		}

		// Token: 0x06000BA2 RID: 2978 RVA: 0x0003C860 File Offset: 0x0003AA60
		internal static bool SetParticleSimulationTimescale(int particleIndex, float fTimescale)
		{
			method sbxPrt_SetParticleSimulationTimescale = GameParticleManager.__N.SBxPrt_SetParticleSimulationTimescale;
			return calli(System.Int32(System.Int32,System.Single), particleIndex, fTimescale, sbxPrt_SetParticleSimulationTimescale) > 0;
		}

		// Token: 0x020001DC RID: 476
		internal static class __N
		{
			// Token: 0x0400102F RID: 4143
			internal static method SBxPrt_CreateParticleIndex;

			// Token: 0x04001030 RID: 4144
			internal static method SBxPrt_SetParticleControl;

			// Token: 0x04001031 RID: 4145
			internal static method SBxPrt_SetParticleControlForward;

			// Token: 0x04001032 RID: 4146
			internal static method SBxPrt_SetParticleControlOrientation;

			// Token: 0x04001033 RID: 4147
			internal static method SBxPrt_SetParticleControlFallback;

			// Token: 0x04001034 RID: 4148
			internal static method SBxPrt_SetParticleControlEnt;

			// Token: 0x04001035 RID: 4149
			internal static method SBxPrt_SetParticleControlEntBone;

			// Token: 0x04001036 RID: 4150
			internal static method SBxPrt_SetParticleControlOffset;

			// Token: 0x04001037 RID: 4151
			internal static method SBxPrt_f2;

			// Token: 0x04001038 RID: 4152
			internal static method SBxPrt_SetParticleControlModel;

			// Token: 0x04001039 RID: 4153
			internal static method SBxPrt_SetParticleTextureAttribute;

			// Token: 0x0400103A RID: 4154
			internal static method SBxPrt_SetParticleOverrideTexture;

			// Token: 0x0400103B RID: 4155
			internal static method SBxPrt_ReleaseParticleIndex;

			// Token: 0x0400103C RID: 4156
			internal static method SBxPrt_DestroyAllParticleEffectsInvolving;

			// Token: 0x0400103D RID: 4157
			internal static method SBxPrt_DestroyParticleEffect;

			// Token: 0x0400103E RID: 4158
			internal static method SBxPrt_SetFrozen;

			// Token: 0x0400103F RID: 4159
			internal static method SBxPrt_SetShouldDraw;

			// Token: 0x04001040 RID: 4160
			internal static method SBxPrt_SetParticleText;

			// Token: 0x04001041 RID: 4161
			internal static method SBxPrt_SetParticleAlwaysInstantiate;

			// Token: 0x04001042 RID: 4162
			internal static method SBxPrt_SetParticleAlwaysSimulate;

			// Token: 0x04001043 RID: 4163
			internal static method SBxPrt_SetParticleControlComponent;

			// Token: 0x04001044 RID: 4164
			internal static method SBxPrt_SetParticleControlSnapshotAsset;

			// Token: 0x04001045 RID: 4165
			internal static method SBxPrt_SetParticleSimulationTimescale;
		}
	}
}
