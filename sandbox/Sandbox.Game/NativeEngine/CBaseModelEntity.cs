using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000027 RID: 39
	internal struct CBaseModelEntity
	{
		// Token: 0x0600048A RID: 1162 RVA: 0x0002A896 File Offset: 0x00028A96
		public static implicit operator IntPtr(CBaseModelEntity value)
		{
			return value.self;
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x0002A8A0 File Offset: 0x00028AA0
		public static implicit operator CBaseModelEntity(IntPtr value)
		{
			return new CBaseModelEntity
			{
				self = value
			};
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0002A8BE File Offset: 0x00028ABE
		public static bool operator ==(CBaseModelEntity c1, CBaseModelEntity c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x0002A8D1 File Offset: 0x00028AD1
		public static bool operator !=(CBaseModelEntity c1, CBaseModelEntity c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x0002A8E4 File Offset: 0x00028AE4
		public override bool Equals(object obj)
		{
			if (obj is CBaseModelEntity)
			{
				CBaseModelEntity c = (CBaseModelEntity)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x0002A90E File Offset: 0x00028B0E
		internal CBaseModelEntity(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0002A918 File Offset: 0x00028B18
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CBaseModelEntity ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x0002A954 File Offset: 0x00028B54
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000492 RID: 1170 RVA: 0x0002A966 File Offset: 0x00028B66
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0002A971 File Offset: 0x00028B71
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0002A984 File Offset: 0x00028B84
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CBaseModelEntity was null when calling " + n);
			}
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0002A99F File Offset: 0x00028B9F
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x0002A9AC File Offset: 0x00028BAC
		public static implicit operator CBaseEntity(CBaseModelEntity value)
		{
			method to_CBaseEntity_From_CBaseModelEntity = CBaseModelEntity.__N.To_CBaseEntity_From_CBaseModelEntity;
			return calli(System.IntPtr(System.IntPtr), value, to_CBaseEntity_From_CBaseModelEntity);
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x0002A9D0 File Offset: 0x00028BD0
		public static explicit operator CBaseModelEntity(CBaseEntity value)
		{
			method from_CBaseEntity_To_CBaseModelEntity = CBaseModelEntity.__N.From_CBaseEntity_To_CBaseModelEntity;
			return calli(System.IntPtr(System.IntPtr), value, from_CBaseEntity_To_CBaseModelEntity);
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x0002A9F4 File Offset: 0x00028BF4
		public static implicit operator CGameEntity(CBaseModelEntity value)
		{
			method to_CGameEntity_From_CBaseModelEntity = CBaseModelEntity.__N.To_CGameEntity_From_CBaseModelEntity;
			return calli(System.IntPtr(System.IntPtr), value, to_CGameEntity_From_CBaseModelEntity);
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x0002AA18 File Offset: 0x00028C18
		public static explicit operator CBaseModelEntity(CGameEntity value)
		{
			method from_CGameEntity_To_CBaseModelEntity = CBaseModelEntity.__N.From_CGameEntity_To_CBaseModelEntity;
			return calli(System.IntPtr(System.IntPtr), value, from_CGameEntity_To_CBaseModelEntity);
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0002AA3C File Offset: 0x00028C3C
		public static implicit operator CEntityInstance(CBaseModelEntity value)
		{
			method to_CEntityInstance_From_CBaseModelEntity = CBaseModelEntity.__N.To_CEntityInstance_From_CBaseModelEntity;
			return calli(System.IntPtr(System.IntPtr), value, to_CEntityInstance_From_CBaseModelEntity);
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x0002AA60 File Offset: 0x00028C60
		public static explicit operator CBaseModelEntity(CEntityInstance value)
		{
			method from_CEntityInstance_To_CBaseModelEntity = CBaseModelEntity.__N.From_CEntityInstance_To_CBaseModelEntity;
			return calli(System.IntPtr(System.IntPtr), value, from_CEntityInstance_To_CBaseModelEntity);
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x0002AA84 File Offset: 0x00028C84
		public static implicit operator IHandleEntity(CBaseModelEntity value)
		{
			method to_IHandleEntity_From_CBaseModelEntity = CBaseModelEntity.__N.To_IHandleEntity_From_CBaseModelEntity;
			return calli(System.IntPtr(System.IntPtr), value, to_IHandleEntity_From_CBaseModelEntity);
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x0002AAA8 File Offset: 0x00028CA8
		public static explicit operator CBaseModelEntity(IHandleEntity value)
		{
			method from_IHandleEntity_To_CBaseModelEntity = CBaseModelEntity.__N.From_IHandleEntity_To_CBaseModelEntity;
			return calli(System.IntPtr(System.IntPtr), value, from_IHandleEntity_To_CBaseModelEntity);
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x0002AACC File Offset: 0x00028CCC
		internal readonly CSkeletonInstance GetSkeletonInstance()
		{
			this.NullCheck("GetSkeletonInstance");
			method cbseMd_GetSkeletonInstance = CBaseModelEntity.__N.CBseMd_GetSkeletonInstance;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetSkeletonInstance);
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0002AAFC File Offset: 0x00028CFC
		internal readonly void SetModelScale(float scale)
		{
			this.NullCheck("SetModelScale");
			method cbseMd_SetModelScale = CBaseModelEntity.__N.CBseMd_SetModelScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, scale, cbseMd_SetModelScale);
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x0002AB28 File Offset: 0x00028D28
		internal readonly float GetModelScale()
		{
			this.NullCheck("GetModelScale");
			method cbseMd_GetModelScale = CBaseModelEntity.__N.CBseMd_GetModelScale;
			return calli(System.Single(System.IntPtr), this.self, cbseMd_GetModelScale);
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x0002AB54 File Offset: 0x00028D54
		internal readonly int GetNumBones()
		{
			this.NullCheck("GetNumBones");
			method cbseMd_GetNumBones = CBaseModelEntity.__N.CBseMd_GetNumBones;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_GetNumBones);
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x0002AB80 File Offset: 0x00028D80
		internal readonly int LookupBone(string szName)
		{
			this.NullCheck("LookupBone");
			method cbseMd_LookupBone = CBaseModelEntity.__N.CBseMd_LookupBone;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(szName), cbseMd_LookupBone);
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x0002ABB0 File Offset: 0x00028DB0
		internal readonly int GetAttachmentCount()
		{
			this.NullCheck("GetAttachmentCount");
			method cbseMd_GetAttachmentCount = CBaseModelEntity.__N.CBseMd_GetAttachmentCount;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_GetAttachmentCount);
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x0002ABDC File Offset: 0x00028DDC
		internal readonly float GetMinFadeDist()
		{
			this.NullCheck("GetMinFadeDist");
			method cbseMd_GetMinFadeDist = CBaseModelEntity.__N.CBseMd_GetMinFadeDist;
			return calli(System.Single(System.IntPtr), this.self, cbseMd_GetMinFadeDist);
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x0002AC08 File Offset: 0x00028E08
		internal readonly float GetMaxFadeDist()
		{
			this.NullCheck("GetMaxFadeDist");
			method cbseMd_GetMaxFadeDist = CBaseModelEntity.__N.CBseMd_GetMaxFadeDist;
			return calli(System.Single(System.IntPtr), this.self, cbseMd_GetMaxFadeDist);
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x0002AC34 File Offset: 0x00028E34
		internal readonly void SetModel(string name)
		{
			this.NullCheck("SetModel");
			method cbseMd_SetModel = CBaseModelEntity.__N.CBseMd_SetModel;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseMd_SetModel);
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x0002AC64 File Offset: 0x00028E64
		internal readonly IModel GetModel()
		{
			this.NullCheck("GetModel");
			method cbseMd_GetModel = CBaseModelEntity.__N.CBseMd_GetModel;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetModel);
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x0002AC94 File Offset: 0x00028E94
		internal readonly void SetModel(IModel model)
		{
			this.NullCheck("SetModel");
			method cbseMd_f = CBaseModelEntity.__N.CBseMd_f2;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, model, cbseMd_f);
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x0002ACC4 File Offset: 0x00028EC4
		internal readonly void SetModelAsync(string name)
		{
			this.NullCheck("SetModelAsync");
			method cbseMd_SetModelAsync = CBaseModelEntity.__N.CBseMd_SetModelAsync;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseMd_SetModelAsync);
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x0002ACF4 File Offset: 0x00028EF4
		internal readonly void SetBodygroup(int iGroup, int iValue)
		{
			this.NullCheck("SetBodygroup");
			method cbseMd_SetBodygroup = CBaseModelEntity.__N.CBseMd_SetBodygroup;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32), this.self, iGroup, iValue, cbseMd_SetBodygroup);
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x0002AD20 File Offset: 0x00028F20
		internal readonly void SetBodygroupByName(string pName, int iValue)
		{
			this.NullCheck("SetBodygroupByName");
			method cbseMd_SetBodygroupByName = CBaseModelEntity.__N.CBseMd_SetBodygroupByName;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(pName), iValue, cbseMd_SetBodygroupByName);
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x0002AD54 File Offset: 0x00028F54
		internal readonly ulong GetRawMeshGroupMask()
		{
			this.NullCheck("GetRawMeshGroupMask");
			method cbseMd_GetRawMeshGroupMask = CBaseModelEntity.__N.CBseMd_GetRawMeshGroupMask;
			return calli(System.UInt64(System.IntPtr), this.self, cbseMd_GetRawMeshGroupMask);
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x0002AD80 File Offset: 0x00028F80
		internal readonly void SetRawMeshGroupMask_LegacyDoNotUse(ulong nBody)
		{
			this.NullCheck("SetRawMeshGroupMask_LegacyDoNotUse");
			method cbseMd_SetRawMeshGroupMask_LegacyDoNotUse = CBaseModelEntity.__N.CBseMd_SetRawMeshGroupMask_LegacyDoNotUse;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBody, cbseMd_SetRawMeshGroupMask_LegacyDoNotUse);
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x0002ADAC File Offset: 0x00028FAC
		internal readonly int GetSkinCount()
		{
			this.NullCheck("GetSkinCount");
			method cbseMd_GetSkinCount = CBaseModelEntity.__N.CBseMd_GetSkinCount;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_GetSkinCount);
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x0002ADD8 File Offset: 0x00028FD8
		internal readonly void SetSkin(int iSkin)
		{
			this.NullCheck("SetSkin");
			method cbseMd_SetSkin = CBaseModelEntity.__N.CBseMd_SetSkin;
			calli(System.Void(System.IntPtr,System.Int32), this.self, iSkin, cbseMd_SetSkin);
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x0002AE04 File Offset: 0x00029004
		internal readonly void SetSkin(string name)
		{
			this.NullCheck("SetSkin");
			method cbseMd_f = CBaseModelEntity.__N.CBseMd_f3;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(name), cbseMd_f);
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x0002AE34 File Offset: 0x00029034
		internal readonly int GetS1Skin()
		{
			this.NullCheck("GetS1Skin");
			method cbseMd_GetS1Skin = CBaseModelEntity.__N.CBseMd_GetS1Skin;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_GetS1Skin);
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0002AE60 File Offset: 0x00029060
		internal readonly CollisionProperty CollisionProp()
		{
			this.NullCheck("CollisionProp");
			method cbseMd_CollisionProp = CBaseModelEntity.__N.CBseMd_CollisionProp;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_CollisionProp);
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0002AE90 File Offset: 0x00029090
		internal readonly void SetRenderAlpha(byte alpha)
		{
			this.NullCheck("SetRenderAlpha");
			method cbseMd_SetRenderAlpha = CBaseModelEntity.__N.CBseMd_SetRenderAlpha;
			calli(System.Void(System.IntPtr,System.Byte), this.self, alpha, cbseMd_SetRenderAlpha);
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x0002AEBC File Offset: 0x000290BC
		internal readonly byte GetRenderAlpha()
		{
			this.NullCheck("GetRenderAlpha");
			method cbseMd_GetRenderAlpha = CBaseModelEntity.__N.CBseMd_GetRenderAlpha;
			return calli(System.Byte(System.IntPtr), this.self, cbseMd_GetRenderAlpha);
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x0002AEE8 File Offset: 0x000290E8
		internal readonly void SetRenderColor(byte r, byte g, byte b)
		{
			this.NullCheck("SetRenderColor");
			method cbseMd_SetRenderColor = CBaseModelEntity.__N.CBseMd_SetRenderColor;
			calli(System.Void(System.IntPtr,System.Byte,System.Byte,System.Byte), this.self, r, g, b, cbseMd_SetRenderColor);
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x0002AF18 File Offset: 0x00029118
		internal readonly void SetRenderColorAndAlpha(Color32 color)
		{
			this.NullCheck("SetRenderColorAndAlpha");
			method cbseMd_SetRenderColorAndAlpha = CBaseModelEntity.__N.CBseMd_SetRenderColorAndAlpha;
			calli(System.Void(System.IntPtr,Color32), this.self, color, cbseMd_SetRenderColorAndAlpha);
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x0002AF44 File Offset: 0x00029144
		internal readonly Color24 GetRenderColor()
		{
			this.NullCheck("GetRenderColor");
			method cbseMd_GetRenderColor = CBaseModelEntity.__N.CBseMd_GetRenderColor;
			return calli(Color24(System.IntPtr), this.self, cbseMd_GetRenderColor);
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x0002AF70 File Offset: 0x00029170
		internal readonly CGlowProperty GlowProp()
		{
			this.NullCheck("GlowProp");
			method cbseMd_GlowProp = CBaseModelEntity.__N.CBseMd_GlowProp;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GlowProp);
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0002AFA0 File Offset: 0x000291A0
		internal readonly Transform GetBoneTransform(int bone)
		{
			this.NullCheck("GetBoneTransform");
			method cbseMd_GetBoneTransform = CBaseModelEntity.__N.CBseMd_GetBoneTransform;
			return calli(Transform(System.IntPtr,System.Int32), this.self, bone, cbseMd_GetBoneTransform);
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x0002AFCC File Offset: 0x000291CC
		internal readonly DataTable GetDataTable()
		{
			this.NullCheck("GetDataTable");
			method cbseMd_GetDataTable = CBaseModelEntity.__N.CBseMd_GetDataTable;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetDataTable);
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x0002AFFC File Offset: 0x000291FC
		internal readonly int GetEntityHandle()
		{
			this.NullCheck("GetEntityHandle");
			method cbseMd_GetEntityHandle = CBaseModelEntity.__N.CBseMd_GetEntityHandle;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_GetEntityHandle);
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0002B028 File Offset: 0x00029228
		internal unsafe readonly void SetLocalOrigin(Vector3 v)
		{
			this.NullCheck("SetLocalOrigin");
			method cbseMd_SetLocalOrigin = CBaseModelEntity.__N.CBseMd_SetLocalOrigin;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, cbseMd_SetLocalOrigin);
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0002B058 File Offset: 0x00029258
		internal readonly Vector3 GetLocalOrigin()
		{
			this.NullCheck("GetLocalOrigin");
			method cbseMd_GetLocalOrigin = CBaseModelEntity.__N.CBseMd_GetLocalOrigin;
			return calli(Vector3(System.IntPtr), this.self, cbseMd_GetLocalOrigin);
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0002B084 File Offset: 0x00029284
		internal unsafe readonly void SetAbsOrigin(Vector3 origin)
		{
			this.NullCheck("SetAbsOrigin");
			method cbseMd_SetAbsOrigin = CBaseModelEntity.__N.CBseMd_SetAbsOrigin;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &origin, cbseMd_SetAbsOrigin);
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0002B0B4 File Offset: 0x000292B4
		internal unsafe readonly void SetAbsAngles(Angles angles)
		{
			this.NullCheck("SetAbsAngles");
			method cbseMd_SetAbsAngles = CBaseModelEntity.__N.CBseMd_SetAbsAngles;
			calli(System.Void(System.IntPtr,Angles*), this.self, &angles, cbseMd_SetAbsAngles);
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0002B0E4 File Offset: 0x000292E4
		internal readonly string GetClassname()
		{
			this.NullCheck("GetClassname");
			method cbseMd_GetClassname = CBaseModelEntity.__N.CBseMd_GetClassname;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetClassname));
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x0002B114 File Offset: 0x00029314
		internal readonly Vector3 GetAbsOrigin()
		{
			this.NullCheck("GetAbsOrigin");
			method cbseMd_GetAbsOrigin = CBaseModelEntity.__N.CBseMd_GetAbsOrigin;
			return calli(Vector3(System.IntPtr), this.self, cbseMd_GetAbsOrigin);
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x0002B140 File Offset: 0x00029340
		internal readonly Angles GetAbsAngles()
		{
			this.NullCheck("GetAbsAngles");
			method cbseMd_GetAbsAngles = CBaseModelEntity.__N.CBseMd_GetAbsAngles;
			return calli(Angles(System.IntPtr), this.self, cbseMd_GetAbsAngles);
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x0002B16C File Offset: 0x0002936C
		internal readonly void EnableLagCompensation(bool enabled)
		{
			this.NullCheck("EnableLagCompensation");
			method cbseMd_EnableLagCompensation = CBaseModelEntity.__N.CBseMd_EnableLagCompensation;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, cbseMd_EnableLagCompensation);
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x0002B1A0 File Offset: 0x000293A0
		internal readonly bool IsLagCompensationEnabled()
		{
			this.NullCheck("IsLagCompensationEnabled");
			method cbseMd_IsLagCompensationEnabled = CBaseModelEntity.__N.CBseMd_IsLagCompensationEnabled;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_IsLagCompensationEnabled) > 0;
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x0002B1D0 File Offset: 0x000293D0
		internal readonly Rotation GetLocalQuat()
		{
			this.NullCheck("GetLocalQuat");
			method cbseMd_GetLocalQuat = CBaseModelEntity.__N.CBseMd_GetLocalQuat;
			return calli(Rotation(System.IntPtr), this.self, cbseMd_GetLocalQuat);
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x0002B1FC File Offset: 0x000293FC
		internal unsafe readonly void SetLocalQuat(Rotation rot)
		{
			this.NullCheck("SetLocalQuat");
			method cbseMd_SetLocalQuat = CBaseModelEntity.__N.CBseMd_SetLocalQuat;
			calli(System.Void(System.IntPtr,Rotation*), this.self, &rot, cbseMd_SetLocalQuat);
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0002B22C File Offset: 0x0002942C
		internal readonly Rotation GetAbsQuat()
		{
			this.NullCheck("GetAbsQuat");
			method cbseMd_GetAbsQuat = CBaseModelEntity.__N.CBseMd_GetAbsQuat;
			return calli(Rotation(System.IntPtr), this.self, cbseMd_GetAbsQuat);
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x0002B258 File Offset: 0x00029458
		internal unsafe readonly void SetAbsQuat(Rotation rot)
		{
			this.NullCheck("SetAbsQuat");
			method cbseMd_SetAbsQuat = CBaseModelEntity.__N.CBseMd_SetAbsQuat;
			calli(System.Void(System.IntPtr,Rotation*), this.self, &rot, cbseMd_SetAbsQuat);
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x0002B288 File Offset: 0x00029488
		internal readonly float GetAbsScale()
		{
			this.NullCheck("GetAbsScale");
			method cbseMd_GetAbsScale = CBaseModelEntity.__N.CBseMd_GetAbsScale;
			return calli(System.Single(System.IntPtr), this.self, cbseMd_GetAbsScale);
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0002B2B4 File Offset: 0x000294B4
		internal readonly void SetAbsScale(float flScale)
		{
			this.NullCheck("SetAbsScale");
			method cbseMd_SetAbsScale = CBaseModelEntity.__N.CBseMd_SetAbsScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, flScale, cbseMd_SetAbsScale);
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x0002B2E0 File Offset: 0x000294E0
		internal readonly float GetLocalScale()
		{
			this.NullCheck("GetLocalScale");
			method cbseMd_GetLocalScale = CBaseModelEntity.__N.CBseMd_GetLocalScale;
			return calli(System.Single(System.IntPtr), this.self, cbseMd_GetLocalScale);
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x0002B30C File Offset: 0x0002950C
		internal readonly void SetLocalScale(float flScale)
		{
			this.NullCheck("SetLocalScale");
			method cbseMd_SetLocalScale = CBaseModelEntity.__N.CBseMd_SetLocalScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, flScale, cbseMd_SetLocalScale);
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x0002B338 File Offset: 0x00029538
		internal readonly int entindex()
		{
			this.NullCheck("entindex");
			method cbseMd_entindex = CBaseModelEntity.__N.CBseMd_entindex;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_entindex);
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x0002B364 File Offset: 0x00029564
		internal unsafe readonly void SetAbsVelocity(Vector3 origin)
		{
			this.NullCheck("SetAbsVelocity");
			method cbseMd_SetAbsVelocity = CBaseModelEntity.__N.CBseMd_SetAbsVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &origin, cbseMd_SetAbsVelocity);
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x0002B394 File Offset: 0x00029594
		internal readonly Vector3 GetAbsVelocity()
		{
			this.NullCheck("GetAbsVelocity");
			method cbseMd_GetAbsVelocity = CBaseModelEntity.__N.CBseMd_GetAbsVelocity;
			return calli(Vector3(System.IntPtr), this.self, cbseMd_GetAbsVelocity);
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x0002B3C0 File Offset: 0x000295C0
		internal readonly void AddFlag(int flags)
		{
			this.NullCheck("AddFlag");
			method cbseMd_AddFlag = CBaseModelEntity.__N.CBseMd_AddFlag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flags, cbseMd_AddFlag);
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x0002B3EC File Offset: 0x000295EC
		internal readonly void RemoveFlag(int flagsToRemove)
		{
			this.NullCheck("RemoveFlag");
			method cbseMd_RemoveFlag = CBaseModelEntity.__N.CBseMd_RemoveFlag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flagsToRemove, cbseMd_RemoveFlag);
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x0002B418 File Offset: 0x00029618
		internal readonly void ToggleFlag(int flagToToggle)
		{
			this.NullCheck("ToggleFlag");
			method cbseMd_ToggleFlag = CBaseModelEntity.__N.CBseMd_ToggleFlag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flagToToggle, cbseMd_ToggleFlag);
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x0002B444 File Offset: 0x00029644
		internal readonly void ClearFlags()
		{
			this.NullCheck("ClearFlags");
			method cbseMd_ClearFlags = CBaseModelEntity.__N.CBseMd_ClearFlags;
			calli(System.Void(System.IntPtr), this.self, cbseMd_ClearFlags);
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x0002B470 File Offset: 0x00029670
		internal readonly int GetFlags()
		{
			this.NullCheck("GetFlags");
			method cbseMd_GetFlags = CBaseModelEntity.__N.CBseMd_GetFlags;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_GetFlags);
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x0002B49C File Offset: 0x0002969C
		internal readonly void SetLifeState(LifeState state)
		{
			this.NullCheck("SetLifeState");
			method cbseMd_SetLifeState = CBaseModelEntity.__N.CBseMd_SetLifeState;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)state, cbseMd_SetLifeState);
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x0002B4C8 File Offset: 0x000296C8
		internal readonly LifeState GetLifeState()
		{
			this.NullCheck("GetLifeState");
			method cbseMd_GetLifeState = CBaseModelEntity.__N.CBseMd_GetLifeState;
			return calli(System.Int64(System.IntPtr), this.self, cbseMd_GetLifeState);
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x0002B4F4 File Offset: 0x000296F4
		internal readonly int GetEffects()
		{
			this.NullCheck("GetEffects");
			method cbseMd_GetEffects = CBaseModelEntity.__N.CBseMd_GetEffects;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_GetEffects);
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x0002B520 File Offset: 0x00029720
		internal readonly void AddEffects(int nEffects)
		{
			this.NullCheck("AddEffects");
			method cbseMd_AddEffects = CBaseModelEntity.__N.CBseMd_AddEffects;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nEffects, cbseMd_AddEffects);
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x0002B54C File Offset: 0x0002974C
		internal readonly void RemoveEffects(int nEffects)
		{
			this.NullCheck("RemoveEffects");
			method cbseMd_RemoveEffects = CBaseModelEntity.__N.CBseMd_RemoveEffects;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nEffects, cbseMd_RemoveEffects);
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x0002B578 File Offset: 0x00029778
		internal readonly void ClearEffects()
		{
			this.NullCheck("ClearEffects");
			method cbseMd_ClearEffects = CBaseModelEntity.__N.CBseMd_ClearEffects;
			calli(System.Void(System.IntPtr), this.self, cbseMd_ClearEffects);
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x0002B5A4 File Offset: 0x000297A4
		internal readonly void SetEffects(int nEffects)
		{
			this.NullCheck("SetEffects");
			method cbseMd_SetEffects = CBaseModelEntity.__N.CBseMd_SetEffects;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nEffects, cbseMd_SetEffects);
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0002B5D0 File Offset: 0x000297D0
		internal readonly bool IsEffectActive(int nEffectMask)
		{
			this.NullCheck("IsEffectActive");
			method cbseMd_IsEffectActive = CBaseModelEntity.__N.CBseMd_IsEffectActive;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, nEffectMask, cbseMd_IsEffectActive) > 0;
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x0002B600 File Offset: 0x00029800
		internal readonly void CreateVPhysics()
		{
			this.NullCheck("CreateVPhysics");
			method cbseMd_CreateVPhysics = CBaseModelEntity.__N.CBseMd_CreateVPhysics;
			calli(System.Void(System.IntPtr), this.self, cbseMd_CreateVPhysics);
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x0002B62C File Offset: 0x0002982C
		internal unsafe readonly void ApplyAbsVelocityImpulse(Vector3 vecImpulse)
		{
			this.NullCheck("ApplyAbsVelocityImpulse");
			method cbseMd_ApplyAbsVelocityImpulse = CBaseModelEntity.__N.CBseMd_ApplyAbsVelocityImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vecImpulse, cbseMd_ApplyAbsVelocityImpulse);
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x0002B65C File Offset: 0x0002985C
		internal unsafe readonly void ApplyLocalVelocityImpulse(Vector3 vecImpulse)
		{
			this.NullCheck("ApplyLocalVelocityImpulse");
			method cbseMd_ApplyLocalVelocityImpulse = CBaseModelEntity.__N.CBseMd_ApplyLocalVelocityImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vecImpulse, cbseMd_ApplyLocalVelocityImpulse);
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x0002B68C File Offset: 0x0002988C
		internal unsafe readonly void ApplyLocalAngularVelocityImpulse(Vector3 angImpulse)
		{
			this.NullCheck("ApplyLocalAngularVelocityImpulse");
			method cbseMd_ApplyLocalAngularVelocityImpulse = CBaseModelEntity.__N.CBseMd_ApplyLocalAngularVelocityImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &angImpulse, cbseMd_ApplyLocalAngularVelocityImpulse);
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x0002B6BC File Offset: 0x000298BC
		internal readonly void SetMoveType(MoveType val, MoveCollide moveCollide)
		{
			this.NullCheck("SetMoveType");
			method cbseMd_SetMoveType = CBaseModelEntity.__N.CBseMd_SetMoveType;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (ulong)val, (ulong)moveCollide, cbseMd_SetMoveType);
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x0002B6EC File Offset: 0x000298EC
		internal readonly MoveType GetMoveType()
		{
			this.NullCheck("GetMoveType");
			method cbseMd_GetMoveType = CBaseModelEntity.__N.CBseMd_GetMoveType;
			return calli(System.Int64(System.IntPtr), this.self, cbseMd_GetMoveType);
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x0002B718 File Offset: 0x00029918
		internal readonly void PhysicsEnableMotion(bool bEnable)
		{
			this.NullCheck("PhysicsEnableMotion");
			method cbseMd_PhysicsEnableMotion = CBaseModelEntity.__N.CBseMd_PhysicsEnableMotion;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnable ? 1 : 0, cbseMd_PhysicsEnableMotion);
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x0002B74C File Offset: 0x0002994C
		internal readonly void FollowEntity(IntPtr pBaseEntity, bool bBoneMerge)
		{
			this.NullCheck("FollowEntity");
			method cbseMd_FollowEntity = CBaseModelEntity.__N.CBseMd_FollowEntity;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, pBaseEntity, bBoneMerge ? 1 : 0, cbseMd_FollowEntity);
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x0002B780 File Offset: 0x00029980
		internal readonly void StopFollowingEntity()
		{
			this.NullCheck("StopFollowingEntity");
			method cbseMd_StopFollowingEntity = CBaseModelEntity.__N.CBseMd_StopFollowingEntity;
			calli(System.Void(System.IntPtr), this.self, cbseMd_StopFollowingEntity);
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x0002B7AC File Offset: 0x000299AC
		internal readonly bool IsFollowingEntity()
		{
			this.NullCheck("IsFollowingEntity");
			method cbseMd_IsFollowingEntity = CBaseModelEntity.__N.CBseMd_IsFollowingEntity;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_IsFollowingEntity) > 0;
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x0002B7DC File Offset: 0x000299DC
		internal readonly CBaseEntity GetFollowedEntity()
		{
			this.NullCheck("GetFollowedEntity");
			method cbseMd_GetFollowedEntity = CBaseModelEntity.__N.CBseMd_GetFollowedEntity;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetFollowedEntity);
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x0002B80C File Offset: 0x00029A0C
		internal readonly PhysicsGroup VPhysicsGetAggregate()
		{
			this.NullCheck("VPhysicsGetAggregate");
			method cbseMd_VPhysicsGetAggregate = CBaseModelEntity.__N.CBseMd_VPhysicsGetAggregate;
			return HandleIndex.Get<PhysicsGroup>(calli(System.Int32(System.IntPtr), this.self, cbseMd_VPhysicsGetAggregate));
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0002B83C File Offset: 0x00029A3C
		internal readonly Vector3 GetBaseVelocity()
		{
			this.NullCheck("GetBaseVelocity");
			method cbseMd_GetBaseVelocity = CBaseModelEntity.__N.CBseMd_GetBaseVelocity;
			return calli(Vector3(System.IntPtr), this.self, cbseMd_GetBaseVelocity);
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x0002B868 File Offset: 0x00029A68
		internal unsafe readonly void SetBaseVelocity(Vector3 v)
		{
			this.NullCheck("SetBaseVelocity");
			method cbseMd_SetBaseVelocity = CBaseModelEntity.__N.CBseMd_SetBaseVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, cbseMd_SetBaseVelocity);
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x0002B898 File Offset: 0x00029A98
		internal readonly void SetGroundEntity(CBaseEntity ground)
		{
			this.NullCheck("SetGroundEntity");
			method cbseMd_SetGroundEntity = CBaseModelEntity.__N.CBseMd_SetGroundEntity;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, ground, cbseMd_SetGroundEntity);
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x0002B8C8 File Offset: 0x00029AC8
		internal readonly CBaseEntity GetGroundEntity()
		{
			this.NullCheck("GetGroundEntity");
			method cbseMd_GetGroundEntity = CBaseModelEntity.__N.CBseMd_GetGroundEntity;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetGroundEntity);
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x0002B8F8 File Offset: 0x00029AF8
		internal readonly string GetModelNameString()
		{
			this.NullCheck("GetModelNameString");
			method cbseMd_GetModelNameString = CBaseModelEntity.__N.CBseMd_GetModelNameString;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetModelNameString));
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x0002B928 File Offset: 0x00029B28
		internal unsafe readonly void SetParent(CBaseEntity parent, string nBoneOrAttachName, Transform pOffsetTransform)
		{
			this.NullCheck("SetParent");
			method cbseMd_SetParent = CBaseModelEntity.__N.CBseMd_SetParent;
			calli(System.Void(System.IntPtr,System.IntPtr,System.UInt32,Transform*), this.self, parent, StringToken.FindOrCreate(nBoneOrAttachName), &pOffsetTransform, cbseMd_SetParent);
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x0002B964 File Offset: 0x00029B64
		internal readonly void SetParent(CBaseEntity parent, string nBoneOrAttachName)
		{
			this.NullCheck("SetParent");
			method cbseMd_f = CBaseModelEntity.__N.CBseMd_f4;
			calli(System.Void(System.IntPtr,System.IntPtr,System.UInt32), this.self, parent, StringToken.FindOrCreate(nBoneOrAttachName), cbseMd_f);
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x0002B99C File Offset: 0x00029B9C
		internal readonly CBaseEntity GetParent()
		{
			this.NullCheck("GetParent");
			method cbseMd_GetParent = CBaseModelEntity.__N.CBseMd_GetParent;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetParent);
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x0002B9CC File Offset: 0x00029BCC
		internal readonly void IncrementInterpolationFrame()
		{
			this.NullCheck("IncrementInterpolationFrame");
			method cbseMd_IncrementInterpolationFrame = CBaseModelEntity.__N.CBseMd_IncrementInterpolationFrame;
			calli(System.Void(System.IntPtr), this.self, cbseMd_IncrementInterpolationFrame);
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x0002B9F8 File Offset: 0x00029BF8
		internal readonly void DispatchUpdateTransmitState()
		{
			this.NullCheck("DispatchUpdateTransmitState");
			method cbseMd_DispatchUpdateTransmitState = CBaseModelEntity.__N.CBseMd_DispatchUpdateTransmitState;
			calli(System.Void(System.IntPtr), this.self, cbseMd_DispatchUpdateTransmitState);
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x0002BA24 File Offset: 0x00029C24
		internal readonly void SetActiveChild(CBaseEntity child)
		{
			this.NullCheck("SetActiveChild");
			method cbseMd_SetActiveChild = CBaseModelEntity.__N.CBseMd_SetActiveChild;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, child, cbseMd_SetActiveChild);
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x0002BA54 File Offset: 0x00029C54
		internal readonly CBaseEntity GetActiveChild()
		{
			this.NullCheck("GetActiveChild");
			method cbseMd_GetActiveChild = CBaseModelEntity.__N.CBseMd_GetActiveChild;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetActiveChild);
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x0002BA84 File Offset: 0x00029C84
		internal readonly void SetOwnerEntity(CBaseEntity child)
		{
			this.NullCheck("SetOwnerEntity");
			method cbseMd_SetOwnerEntity = CBaseModelEntity.__N.CBseMd_SetOwnerEntity;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, child, cbseMd_SetOwnerEntity);
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x0002BAB4 File Offset: 0x00029CB4
		internal readonly CBaseEntity GetOwnerEntity()
		{
			this.NullCheck("GetOwnerEntity");
			method cbseMd_GetOwnerEntity = CBaseModelEntity.__N.CBseMd_GetOwnerEntity;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetOwnerEntity);
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0002BAE4 File Offset: 0x00029CE4
		internal readonly void SetSimulationTime(float time)
		{
			this.NullCheck("SetSimulationTime");
			method cbseMd_SetSimulationTime = CBaseModelEntity.__N.CBseMd_SetSimulationTime;
			calli(System.Void(System.IntPtr,System.Single), this.self, time, cbseMd_SetSimulationTime);
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x0002BB10 File Offset: 0x00029D10
		internal readonly bool HasSpawnFlags(int nFlags)
		{
			this.NullCheck("HasSpawnFlags");
			method cbseMd_HasSpawnFlags = CBaseModelEntity.__N.CBseMd_HasSpawnFlags;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, nFlags, cbseMd_HasSpawnFlags) > 0;
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x0002BB40 File Offset: 0x00029D40
		internal readonly int GetSpawnFlags()
		{
			this.NullCheck("GetSpawnFlags");
			method cbseMd_GetSpawnFlags = CBaseModelEntity.__N.CBseMd_GetSpawnFlags;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_GetSpawnFlags);
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x0002BB6C File Offset: 0x00029D6C
		internal readonly void AddSpawnFlags(int nFlags)
		{
			this.NullCheck("AddSpawnFlags");
			method cbseMd_AddSpawnFlags = CBaseModelEntity.__N.CBseMd_AddSpawnFlags;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nFlags, cbseMd_AddSpawnFlags);
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x0002BB98 File Offset: 0x00029D98
		internal readonly void RemoveSpawnFlags(int nFlags)
		{
			this.NullCheck("RemoveSpawnFlags");
			method cbseMd_RemoveSpawnFlags = CBaseModelEntity.__N.CBseMd_RemoveSpawnFlags;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nFlags, cbseMd_RemoveSpawnFlags);
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x0002BBC4 File Offset: 0x00029DC4
		internal readonly void ClearSpawnFlags()
		{
			this.NullCheck("ClearSpawnFlags");
			method cbseMd_ClearSpawnFlags = CBaseModelEntity.__N.CBseMd_ClearSpawnFlags;
			calli(System.Void(System.IntPtr), this.self, cbseMd_ClearSpawnFlags);
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x0002BBF0 File Offset: 0x00029DF0
		internal readonly CLightComponent GetLightComponent()
		{
			this.NullCheck("GetLightComponent");
			method cbseMd_GetLightComponent = CBaseModelEntity.__N.CBseMd_GetLightComponent;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetLightComponent);
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x0002BC20 File Offset: 0x00029E20
		internal readonly void SetMoveDoneTime(float time)
		{
			this.NullCheck("SetMoveDoneTime");
			method cbseMd_SetMoveDoneTime = CBaseModelEntity.__N.CBseMd_SetMoveDoneTime;
			calli(System.Void(System.IntPtr,System.Single), this.self, time, cbseMd_SetMoveDoneTime);
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x0002BC4C File Offset: 0x00029E4C
		internal readonly float GetMoveDoneTime()
		{
			this.NullCheck("GetMoveDoneTime");
			method cbseMd_GetMoveDoneTime = CBaseModelEntity.__N.CBseMd_GetMoveDoneTime;
			return calli(System.Single(System.IntPtr), this.self, cbseMd_GetMoveDoneTime);
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0002BC78 File Offset: 0x00029E78
		internal unsafe readonly void SetLocalVelocity(Vector3 vecVelocity)
		{
			this.NullCheck("SetLocalVelocity");
			method cbseMd_SetLocalVelocity = CBaseModelEntity.__N.CBseMd_SetLocalVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vecVelocity, cbseMd_SetLocalVelocity);
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x0002BCA8 File Offset: 0x00029EA8
		internal readonly Vector3 GetLocalVelocity()
		{
			this.NullCheck("GetLocalVelocity");
			method cbseMd_GetLocalVelocity = CBaseModelEntity.__N.CBseMd_GetLocalVelocity;
			return calli(Vector3(System.IntPtr), this.self, cbseMd_GetLocalVelocity);
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x0002BCD4 File Offset: 0x00029ED4
		internal unsafe readonly void SetLocalAngularVelocity(Angles vecAngVelocity)
		{
			this.NullCheck("SetLocalAngularVelocity");
			method cbseMd_SetLocalAngularVelocity = CBaseModelEntity.__N.CBseMd_SetLocalAngularVelocity;
			calli(System.Void(System.IntPtr,Angles*), this.self, &vecAngVelocity, cbseMd_SetLocalAngularVelocity);
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x0002BD04 File Offset: 0x00029F04
		internal readonly Angles GetLocalAngularVelocity()
		{
			this.NullCheck("GetLocalAngularVelocity");
			method cbseMd_GetLocalAngularVelocity = CBaseModelEntity.__N.CBseMd_GetLocalAngularVelocity;
			return calli(Angles(System.IntPtr), this.self, cbseMd_GetLocalAngularVelocity);
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x0002BD30 File Offset: 0x00029F30
		internal readonly void SetDebugBits(ulong nBitMask)
		{
			this.NullCheck("SetDebugBits");
			method cbseMd_SetDebugBits = CBaseModelEntity.__N.CBseMd_SetDebugBits;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBitMask, cbseMd_SetDebugBits);
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x0002BD5C File Offset: 0x00029F5C
		internal readonly bool HasDebugBitsSet(ulong nBitMask)
		{
			this.NullCheck("HasDebugBitsSet");
			method cbseMd_HasDebugBitsSet = CBaseModelEntity.__N.CBseMd_HasDebugBitsSet;
			return calli(System.Int32(System.IntPtr,System.UInt64), this.self, nBitMask, cbseMd_HasDebugBitsSet) > 0;
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x0002BD8C File Offset: 0x00029F8C
		internal readonly void ClearDebugBits(ulong nBitMask)
		{
			this.NullCheck("ClearDebugBits");
			method cbseMd_ClearDebugBits = CBaseModelEntity.__N.CBseMd_ClearDebugBits;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBitMask, cbseMd_ClearDebugBits);
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x0002BDB8 File Offset: 0x00029FB8
		internal readonly void ToggleDebugBits(ulong nBitMask)
		{
			this.NullCheck("ToggleDebugBits");
			method cbseMd_ToggleDebugBits = CBaseModelEntity.__N.CBseMd_ToggleDebugBits;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBitMask, cbseMd_ToggleDebugBits);
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x0002BDE4 File Offset: 0x00029FE4
		internal readonly ulong GetDebugBits()
		{
			this.NullCheck("GetDebugBits");
			method cbseMd_GetDebugBits = CBaseModelEntity.__N.CBseMd_GetDebugBits;
			return calli(System.UInt64(System.IntPtr), this.self, cbseMd_GetDebugBits);
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x0002BE10 File Offset: 0x0002A010
		internal readonly void SetWaterEntity(CBaseEntity ent)
		{
			this.NullCheck("SetWaterEntity");
			method cbseMd_SetWaterEntity = CBaseModelEntity.__N.CBseMd_SetWaterEntity;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, ent, cbseMd_SetWaterEntity);
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x0002BE40 File Offset: 0x0002A040
		internal readonly Entity GetWaterEntity()
		{
			this.NullCheck("GetWaterEntity");
			method cbseMd_GetWaterEntity = CBaseModelEntity.__N.CBseMd_GetWaterEntity;
			return InteropSystem.Get<Entity>(calli(System.UInt32(System.IntPtr), this.self, cbseMd_GetWaterEntity));
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x0002BE70 File Offset: 0x0002A070
		internal readonly void WorldSpaceAABB(out Vector3 mins, out Vector3 maxs)
		{
			this.NullCheck("WorldSpaceAABB");
			method cbseMd_WorldSpaceAABB = CBaseModelEntity.__N.CBseMd_WorldSpaceAABB;
			calli(System.Void(System.IntPtr,Vector3& modreq(System.Runtime.InteropServices.OutAttribute),Vector3& modreq(System.Runtime.InteropServices.OutAttribute)), this.self, ref mins, ref maxs, cbseMd_WorldSpaceAABB);
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x0002BE9C File Offset: 0x0002A09C
		internal readonly void RemoveAllDecals()
		{
			this.NullCheck("RemoveAllDecals");
			method cbseMd_RemoveAllDecals = CBaseModelEntity.__N.CBseMd_RemoveAllDecals;
			calli(System.Void(System.IntPtr), this.self, cbseMd_RemoveAllDecals);
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x0002BEC8 File Offset: 0x0002A0C8
		internal readonly string SB_GetEntityName()
		{
			this.NullCheck("SB_GetEntityName");
			method cbseMd_SB_GetEntityName = CBaseModelEntity.__N.CBseMd_SB_GetEntityName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbseMd_SB_GetEntityName));
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x0002BEF8 File Offset: 0x0002A0F8
		internal readonly void SB_SetEntityName(string name)
		{
			this.NullCheck("SB_SetEntityName");
			method cbseMd_SB_SetEntityName = CBaseModelEntity.__N.CBseMd_SB_SetEntityName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseMd_SB_SetEntityName);
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x0002BF28 File Offset: 0x0002A128
		internal readonly void SetData(int index, bool local, IntPtr data, int size)
		{
			this.NullCheck("SetData");
			method cbseMd_SetData = CBaseModelEntity.__N.CBseMd_SetData;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32,System.IntPtr,System.Int32), this.self, index, local ? 1 : 0, data, size, cbseMd_SetData);
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x0002BF60 File Offset: 0x0002A160
		internal readonly void ClearData()
		{
			this.NullCheck("ClearData");
			method cbseMd_ClearData = CBaseModelEntity.__N.CBseMd_ClearData;
			calli(System.Void(System.IntPtr), this.self, cbseMd_ClearData);
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x0002BF8C File Offset: 0x0002A18C
		internal readonly bool IsServerOnly()
		{
			this.NullCheck("IsServerOnly");
			method cbseMd_IsServerOnly = CBaseModelEntity.__N.CBseMd_IsServerOnly;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_IsServerOnly) > 0;
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0002BFBC File Offset: 0x0002A1BC
		internal readonly bool IsClientOnly()
		{
			this.NullCheck("IsClientOnly");
			method cbseMd_IsClientOnly = CBaseModelEntity.__N.CBseMd_IsClientOnly;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_IsClientOnly) > 0;
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0002BFEC File Offset: 0x0002A1EC
		internal readonly bool IsClientServerNetworked()
		{
			this.NullCheck("IsClientServerNetworked");
			method cbseMd_IsClientServerNetworked = CBaseModelEntity.__N.CBseMd_IsClientServerNetworked;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_IsClientServerNetworked) > 0;
		}

		// Token: 0x040000A3 RID: 163
		internal IntPtr self;

		// Token: 0x020001AC RID: 428
		internal static class __N
		{
			// Token: 0x04000AB9 RID: 2745
			internal static method From_CBaseEntity_To_CBaseModelEntity;

			// Token: 0x04000ABA RID: 2746
			internal static method To_CBaseEntity_From_CBaseModelEntity;

			// Token: 0x04000ABB RID: 2747
			internal static method From_CGameEntity_To_CBaseModelEntity;

			// Token: 0x04000ABC RID: 2748
			internal static method To_CGameEntity_From_CBaseModelEntity;

			// Token: 0x04000ABD RID: 2749
			internal static method From_CEntityInstance_To_CBaseModelEntity;

			// Token: 0x04000ABE RID: 2750
			internal static method To_CEntityInstance_From_CBaseModelEntity;

			// Token: 0x04000ABF RID: 2751
			internal static method From_IHandleEntity_To_CBaseModelEntity;

			// Token: 0x04000AC0 RID: 2752
			internal static method To_IHandleEntity_From_CBaseModelEntity;

			// Token: 0x04000AC1 RID: 2753
			internal static method CBseMd_GetSkeletonInstance;

			// Token: 0x04000AC2 RID: 2754
			internal static method CBseMd_SetModelScale;

			// Token: 0x04000AC3 RID: 2755
			internal static method CBseMd_GetModelScale;

			// Token: 0x04000AC4 RID: 2756
			internal static method CBseMd_GetNumBones;

			// Token: 0x04000AC5 RID: 2757
			internal static method CBseMd_LookupBone;

			// Token: 0x04000AC6 RID: 2758
			internal static method CBseMd_GetAttachmentCount;

			// Token: 0x04000AC7 RID: 2759
			internal static method CBseMd_GetMinFadeDist;

			// Token: 0x04000AC8 RID: 2760
			internal static method CBseMd_GetMaxFadeDist;

			// Token: 0x04000AC9 RID: 2761
			internal static method CBseMd_SetModel;

			// Token: 0x04000ACA RID: 2762
			internal static method CBseMd_GetModel;

			// Token: 0x04000ACB RID: 2763
			internal static method CBseMd_f2;

			// Token: 0x04000ACC RID: 2764
			internal static method CBseMd_SetModelAsync;

			// Token: 0x04000ACD RID: 2765
			internal static method CBseMd_SetBodygroup;

			// Token: 0x04000ACE RID: 2766
			internal static method CBseMd_SetBodygroupByName;

			// Token: 0x04000ACF RID: 2767
			internal static method CBseMd_GetRawMeshGroupMask;

			// Token: 0x04000AD0 RID: 2768
			internal static method CBseMd_SetRawMeshGroupMask_LegacyDoNotUse;

			// Token: 0x04000AD1 RID: 2769
			internal static method CBseMd_GetSkinCount;

			// Token: 0x04000AD2 RID: 2770
			internal static method CBseMd_SetSkin;

			// Token: 0x04000AD3 RID: 2771
			internal static method CBseMd_f3;

			// Token: 0x04000AD4 RID: 2772
			internal static method CBseMd_GetS1Skin;

			// Token: 0x04000AD5 RID: 2773
			internal static method CBseMd_CollisionProp;

			// Token: 0x04000AD6 RID: 2774
			internal static method CBseMd_SetRenderAlpha;

			// Token: 0x04000AD7 RID: 2775
			internal static method CBseMd_GetRenderAlpha;

			// Token: 0x04000AD8 RID: 2776
			internal static method CBseMd_SetRenderColor;

			// Token: 0x04000AD9 RID: 2777
			internal static method CBseMd_SetRenderColorAndAlpha;

			// Token: 0x04000ADA RID: 2778
			internal static method CBseMd_GetRenderColor;

			// Token: 0x04000ADB RID: 2779
			internal static method CBseMd_GlowProp;

			// Token: 0x04000ADC RID: 2780
			internal static method CBseMd_GetBoneTransform;

			// Token: 0x04000ADD RID: 2781
			internal static method CBseMd_GetDataTable;

			// Token: 0x04000ADE RID: 2782
			internal static method CBseMd_GetEntityHandle;

			// Token: 0x04000ADF RID: 2783
			internal static method CBseMd_SetLocalOrigin;

			// Token: 0x04000AE0 RID: 2784
			internal static method CBseMd_GetLocalOrigin;

			// Token: 0x04000AE1 RID: 2785
			internal static method CBseMd_SetAbsOrigin;

			// Token: 0x04000AE2 RID: 2786
			internal static method CBseMd_SetAbsAngles;

			// Token: 0x04000AE3 RID: 2787
			internal static method CBseMd_GetClassname;

			// Token: 0x04000AE4 RID: 2788
			internal static method CBseMd_GetAbsOrigin;

			// Token: 0x04000AE5 RID: 2789
			internal static method CBseMd_GetAbsAngles;

			// Token: 0x04000AE6 RID: 2790
			internal static method CBseMd_EnableLagCompensation;

			// Token: 0x04000AE7 RID: 2791
			internal static method CBseMd_IsLagCompensationEnabled;

			// Token: 0x04000AE8 RID: 2792
			internal static method CBseMd_GetLocalQuat;

			// Token: 0x04000AE9 RID: 2793
			internal static method CBseMd_SetLocalQuat;

			// Token: 0x04000AEA RID: 2794
			internal static method CBseMd_GetAbsQuat;

			// Token: 0x04000AEB RID: 2795
			internal static method CBseMd_SetAbsQuat;

			// Token: 0x04000AEC RID: 2796
			internal static method CBseMd_GetAbsScale;

			// Token: 0x04000AED RID: 2797
			internal static method CBseMd_SetAbsScale;

			// Token: 0x04000AEE RID: 2798
			internal static method CBseMd_GetLocalScale;

			// Token: 0x04000AEF RID: 2799
			internal static method CBseMd_SetLocalScale;

			// Token: 0x04000AF0 RID: 2800
			internal static method CBseMd_entindex;

			// Token: 0x04000AF1 RID: 2801
			internal static method CBseMd_SetAbsVelocity;

			// Token: 0x04000AF2 RID: 2802
			internal static method CBseMd_GetAbsVelocity;

			// Token: 0x04000AF3 RID: 2803
			internal static method CBseMd_AddFlag;

			// Token: 0x04000AF4 RID: 2804
			internal static method CBseMd_RemoveFlag;

			// Token: 0x04000AF5 RID: 2805
			internal static method CBseMd_ToggleFlag;

			// Token: 0x04000AF6 RID: 2806
			internal static method CBseMd_ClearFlags;

			// Token: 0x04000AF7 RID: 2807
			internal static method CBseMd_GetFlags;

			// Token: 0x04000AF8 RID: 2808
			internal static method CBseMd_SetLifeState;

			// Token: 0x04000AF9 RID: 2809
			internal static method CBseMd_GetLifeState;

			// Token: 0x04000AFA RID: 2810
			internal static method CBseMd_GetEffects;

			// Token: 0x04000AFB RID: 2811
			internal static method CBseMd_AddEffects;

			// Token: 0x04000AFC RID: 2812
			internal static method CBseMd_RemoveEffects;

			// Token: 0x04000AFD RID: 2813
			internal static method CBseMd_ClearEffects;

			// Token: 0x04000AFE RID: 2814
			internal static method CBseMd_SetEffects;

			// Token: 0x04000AFF RID: 2815
			internal static method CBseMd_IsEffectActive;

			// Token: 0x04000B00 RID: 2816
			internal static method CBseMd_CreateVPhysics;

			// Token: 0x04000B01 RID: 2817
			internal static method CBseMd_ApplyAbsVelocityImpulse;

			// Token: 0x04000B02 RID: 2818
			internal static method CBseMd_ApplyLocalVelocityImpulse;

			// Token: 0x04000B03 RID: 2819
			internal static method CBseMd_ApplyLocalAngularVelocityImpulse;

			// Token: 0x04000B04 RID: 2820
			internal static method CBseMd_SetMoveType;

			// Token: 0x04000B05 RID: 2821
			internal static method CBseMd_GetMoveType;

			// Token: 0x04000B06 RID: 2822
			internal static method CBseMd_PhysicsEnableMotion;

			// Token: 0x04000B07 RID: 2823
			internal static method CBseMd_FollowEntity;

			// Token: 0x04000B08 RID: 2824
			internal static method CBseMd_StopFollowingEntity;

			// Token: 0x04000B09 RID: 2825
			internal static method CBseMd_IsFollowingEntity;

			// Token: 0x04000B0A RID: 2826
			internal static method CBseMd_GetFollowedEntity;

			// Token: 0x04000B0B RID: 2827
			internal static method CBseMd_VPhysicsGetAggregate;

			// Token: 0x04000B0C RID: 2828
			internal static method CBseMd_GetBaseVelocity;

			// Token: 0x04000B0D RID: 2829
			internal static method CBseMd_SetBaseVelocity;

			// Token: 0x04000B0E RID: 2830
			internal static method CBseMd_SetGroundEntity;

			// Token: 0x04000B0F RID: 2831
			internal static method CBseMd_GetGroundEntity;

			// Token: 0x04000B10 RID: 2832
			internal static method CBseMd_GetModelNameString;

			// Token: 0x04000B11 RID: 2833
			internal static method CBseMd_SetParent;

			// Token: 0x04000B12 RID: 2834
			internal static method CBseMd_f4;

			// Token: 0x04000B13 RID: 2835
			internal static method CBseMd_GetParent;

			// Token: 0x04000B14 RID: 2836
			internal static method CBseMd_IncrementInterpolationFrame;

			// Token: 0x04000B15 RID: 2837
			internal static method CBseMd_DispatchUpdateTransmitState;

			// Token: 0x04000B16 RID: 2838
			internal static method CBseMd_SetActiveChild;

			// Token: 0x04000B17 RID: 2839
			internal static method CBseMd_GetActiveChild;

			// Token: 0x04000B18 RID: 2840
			internal static method CBseMd_SetOwnerEntity;

			// Token: 0x04000B19 RID: 2841
			internal static method CBseMd_GetOwnerEntity;

			// Token: 0x04000B1A RID: 2842
			internal static method CBseMd_SetSimulationTime;

			// Token: 0x04000B1B RID: 2843
			internal static method CBseMd_HasSpawnFlags;

			// Token: 0x04000B1C RID: 2844
			internal static method CBseMd_GetSpawnFlags;

			// Token: 0x04000B1D RID: 2845
			internal static method CBseMd_AddSpawnFlags;

			// Token: 0x04000B1E RID: 2846
			internal static method CBseMd_RemoveSpawnFlags;

			// Token: 0x04000B1F RID: 2847
			internal static method CBseMd_ClearSpawnFlags;

			// Token: 0x04000B20 RID: 2848
			internal static method CBseMd_GetLightComponent;

			// Token: 0x04000B21 RID: 2849
			internal static method CBseMd_SetMoveDoneTime;

			// Token: 0x04000B22 RID: 2850
			internal static method CBseMd_GetMoveDoneTime;

			// Token: 0x04000B23 RID: 2851
			internal static method CBseMd_SetLocalVelocity;

			// Token: 0x04000B24 RID: 2852
			internal static method CBseMd_GetLocalVelocity;

			// Token: 0x04000B25 RID: 2853
			internal static method CBseMd_SetLocalAngularVelocity;

			// Token: 0x04000B26 RID: 2854
			internal static method CBseMd_GetLocalAngularVelocity;

			// Token: 0x04000B27 RID: 2855
			internal static method CBseMd_SetDebugBits;

			// Token: 0x04000B28 RID: 2856
			internal static method CBseMd_HasDebugBitsSet;

			// Token: 0x04000B29 RID: 2857
			internal static method CBseMd_ClearDebugBits;

			// Token: 0x04000B2A RID: 2858
			internal static method CBseMd_ToggleDebugBits;

			// Token: 0x04000B2B RID: 2859
			internal static method CBseMd_GetDebugBits;

			// Token: 0x04000B2C RID: 2860
			internal static method CBseMd_SetWaterEntity;

			// Token: 0x04000B2D RID: 2861
			internal static method CBseMd_GetWaterEntity;

			// Token: 0x04000B2E RID: 2862
			internal static method CBseMd_WorldSpaceAABB;

			// Token: 0x04000B2F RID: 2863
			internal static method CBseMd_RemoveAllDecals;

			// Token: 0x04000B30 RID: 2864
			internal static method CBseMd_SB_GetEntityName;

			// Token: 0x04000B31 RID: 2865
			internal static method CBseMd_SB_SetEntityName;

			// Token: 0x04000B32 RID: 2866
			internal static method CBseMd_SetData;

			// Token: 0x04000B33 RID: 2867
			internal static method CBseMd_ClearData;

			// Token: 0x04000B34 RID: 2868
			internal static method CBseMd_IsServerOnly;

			// Token: 0x04000B35 RID: 2869
			internal static method CBseMd_IsClientOnly;

			// Token: 0x04000B36 RID: 2870
			internal static method CBseMd_IsClientServerNetworked;
		}
	}
}
