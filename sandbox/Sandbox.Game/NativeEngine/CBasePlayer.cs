using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000028 RID: 40
	internal struct CBasePlayer
	{
		// Token: 0x06000514 RID: 1300 RVA: 0x0002C019 File Offset: 0x0002A219
		public static implicit operator IntPtr(CBasePlayer value)
		{
			return value.self;
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x0002C024 File Offset: 0x0002A224
		public static implicit operator CBasePlayer(IntPtr value)
		{
			return new CBasePlayer
			{
				self = value
			};
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0002C042 File Offset: 0x0002A242
		public static bool operator ==(CBasePlayer c1, CBasePlayer c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x0002C055 File Offset: 0x0002A255
		public static bool operator !=(CBasePlayer c1, CBasePlayer c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x0002C068 File Offset: 0x0002A268
		public override bool Equals(object obj)
		{
			if (obj is CBasePlayer)
			{
				CBasePlayer c = (CBasePlayer)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x0002C092 File Offset: 0x0002A292
		internal CBasePlayer(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x0002C09C File Offset: 0x0002A29C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CBasePlayer ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x0002C0D8 File Offset: 0x0002A2D8
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600051C RID: 1308 RVA: 0x0002C0EA File Offset: 0x0002A2EA
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x0002C0F5 File Offset: 0x0002A2F5
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x0002C108 File Offset: 0x0002A308
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CBasePlayer was null when calling " + n);
			}
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x0002C123 File Offset: 0x0002A323
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x0002C130 File Offset: 0x0002A330
		public static implicit operator CBaseModelEntity(CBasePlayer value)
		{
			method to_CBaseModelEntity_From_CBasePlayer = CBasePlayer.__N.To_CBaseModelEntity_From_CBasePlayer;
			return calli(System.IntPtr(System.IntPtr), value, to_CBaseModelEntity_From_CBasePlayer);
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x0002C154 File Offset: 0x0002A354
		public static explicit operator CBasePlayer(CBaseModelEntity value)
		{
			method from_CBaseModelEntity_To_CBasePlayer = CBasePlayer.__N.From_CBaseModelEntity_To_CBasePlayer;
			return calli(System.IntPtr(System.IntPtr), value, from_CBaseModelEntity_To_CBasePlayer);
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0002C178 File Offset: 0x0002A378
		public static implicit operator CBaseEntity(CBasePlayer value)
		{
			method to_CBaseEntity_From_CBasePlayer = CBasePlayer.__N.To_CBaseEntity_From_CBasePlayer;
			return calli(System.IntPtr(System.IntPtr), value, to_CBaseEntity_From_CBasePlayer);
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0002C19C File Offset: 0x0002A39C
		public static explicit operator CBasePlayer(CBaseEntity value)
		{
			method from_CBaseEntity_To_CBasePlayer = CBasePlayer.__N.From_CBaseEntity_To_CBasePlayer;
			return calli(System.IntPtr(System.IntPtr), value, from_CBaseEntity_To_CBasePlayer);
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0002C1C0 File Offset: 0x0002A3C0
		public static implicit operator CGameEntity(CBasePlayer value)
		{
			method to_CGameEntity_From_CBasePlayer = CBasePlayer.__N.To_CGameEntity_From_CBasePlayer;
			return calli(System.IntPtr(System.IntPtr), value, to_CGameEntity_From_CBasePlayer);
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x0002C1E4 File Offset: 0x0002A3E4
		public static explicit operator CBasePlayer(CGameEntity value)
		{
			method from_CGameEntity_To_CBasePlayer = CBasePlayer.__N.From_CGameEntity_To_CBasePlayer;
			return calli(System.IntPtr(System.IntPtr), value, from_CGameEntity_To_CBasePlayer);
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0002C208 File Offset: 0x0002A408
		public static implicit operator CEntityInstance(CBasePlayer value)
		{
			method to_CEntityInstance_From_CBasePlayer = CBasePlayer.__N.To_CEntityInstance_From_CBasePlayer;
			return calli(System.IntPtr(System.IntPtr), value, to_CEntityInstance_From_CBasePlayer);
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x0002C22C File Offset: 0x0002A42C
		public static explicit operator CBasePlayer(CEntityInstance value)
		{
			method from_CEntityInstance_To_CBasePlayer = CBasePlayer.__N.From_CEntityInstance_To_CBasePlayer;
			return calli(System.IntPtr(System.IntPtr), value, from_CEntityInstance_To_CBasePlayer);
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x0002C250 File Offset: 0x0002A450
		public static implicit operator IHandleEntity(CBasePlayer value)
		{
			method to_IHandleEntity_From_CBasePlayer = CBasePlayer.__N.To_IHandleEntity_From_CBasePlayer;
			return calli(System.IntPtr(System.IntPtr), value, to_IHandleEntity_From_CBasePlayer);
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x0002C274 File Offset: 0x0002A474
		public static explicit operator CBasePlayer(IHandleEntity value)
		{
			method from_IHandleEntity_To_CBasePlayer = CBasePlayer.__N.From_IHandleEntity_To_CBasePlayer;
			return calli(System.IntPtr(System.IntPtr), value, from_IHandleEntity_To_CBasePlayer);
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x0002C298 File Offset: 0x0002A498
		internal readonly string GetPlayerName()
		{
			this.NullCheck("GetPlayerName");
			method cbsePl_GetPlayerName = CBasePlayer.__N.CBsePl_GetPlayerName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetPlayerName));
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0002C2C8 File Offset: 0x0002A4C8
		internal readonly int GetUserID()
		{
			this.NullCheck("GetUserID");
			method cbsePl_GetUserID = CBasePlayer.__N.CBsePl_GetUserID;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_GetUserID);
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x0002C2F4 File Offset: 0x0002A4F4
		internal readonly void SetPlayerName(string name)
		{
			this.NullCheck("SetPlayerName");
			method cbsePl_SetPlayerName = CBasePlayer.__N.CBsePl_SetPlayerName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbsePl_SetPlayerName);
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x0002C324 File Offset: 0x0002A524
		internal readonly void ClientCommand(string command)
		{
			this.NullCheck("ClientCommand");
			method cbsePl_ClientCommand = CBasePlayer.__N.CBsePl_ClientCommand;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(command), cbsePl_ClientCommand);
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x0002C354 File Offset: 0x0002A554
		internal readonly void UpdateButtonState(int buttons)
		{
			this.NullCheck("UpdateButtonState");
			method cbsePl_UpdateButtonState = CBasePlayer.__N.CBsePl_UpdateButtonState;
			calli(System.Void(System.IntPtr,System.Int32), this.self, buttons, cbsePl_UpdateButtonState);
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x0002C380 File Offset: 0x0002A580
		internal readonly ulong GetSteamIDAsUInt64()
		{
			this.NullCheck("GetSteamIDAsUInt64");
			method cbsePl_GetSteamIDAsUInt = CBasePlayer.__N.CBsePl_GetSteamIDAsUInt64;
			return calli(System.UInt64(System.IntPtr), this.self, cbsePl_GetSteamIDAsUInt);
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x0002C3AC File Offset: 0x0002A5AC
		internal readonly void PlayerRunCommand(ref CUserCmd ucmd)
		{
			this.NullCheck("PlayerRunCommand");
			method cbsePl_PlayerRunCommand = CBasePlayer.__N.CBsePl_PlayerRunCommand;
			calli(System.Void(System.IntPtr,NativeEngine.CUserCmd&), this.self, ref ucmd, cbsePl_PlayerRunCommand);
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x0002C3D8 File Offset: 0x0002A5D8
		internal readonly CUserCmd GetLastUserCommand()
		{
			this.NullCheck("GetLastUserCommand");
			method cbsePl_GetLastUserCommand = CBasePlayer.__N.CBsePl_GetLastUserCommand;
			return calli(NativeEngine.CUserCmd(System.IntPtr), this.self, cbsePl_GetLastUserCommand);
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x0002C404 File Offset: 0x0002A604
		internal readonly void SetLastUserCommand(ref CUserCmd cmd)
		{
			this.NullCheck("SetLastUserCommand");
			method cbsePl_SetLastUserCommand = CBasePlayer.__N.CBsePl_SetLastUserCommand;
			calli(System.Void(System.IntPtr,NativeEngine.CUserCmd&), this.self, ref cmd, cbsePl_SetLastUserCommand);
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x0002C430 File Offset: 0x0002A630
		internal readonly void PreBotTick()
		{
			this.NullCheck("PreBotTick");
			method cbsePl_PreBotTick = CBasePlayer.__N.CBsePl_PreBotTick;
			calli(System.Void(System.IntPtr), this.self, cbsePl_PreBotTick);
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x0002C45C File Offset: 0x0002A65C
		internal readonly void PostBotTick()
		{
			this.NullCheck("PostBotTick");
			method cbsePl_PostBotTick = CBasePlayer.__N.CBsePl_PostBotTick;
			calli(System.Void(System.IntPtr), this.self, cbsePl_PostBotTick);
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x0002C488 File Offset: 0x0002A688
		internal readonly void StartLagCompensation()
		{
			this.NullCheck("StartLagCompensation");
			method cbsePl_StartLagCompensation = CBasePlayer.__N.CBsePl_StartLagCompensation;
			calli(System.Void(System.IntPtr), this.self, cbsePl_StartLagCompensation);
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x0002C4B4 File Offset: 0x0002A6B4
		internal readonly void FinishLagCompensation()
		{
			this.NullCheck("FinishLagCompensation");
			method cbsePl_FinishLagCompensation = CBasePlayer.__N.CBsePl_FinishLagCompensation;
			calli(System.Void(System.IntPtr), this.self, cbsePl_FinishLagCompensation);
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x0002C4E0 File Offset: 0x0002A6E0
		internal readonly bool IsVrUser()
		{
			this.NullCheck("IsVrUser");
			method cbsePl_IsVrUser = CBasePlayer.__N.CBsePl_IsVrUser;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_IsVrUser) > 0;
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x0002C510 File Offset: 0x0002A710
		internal readonly CSkeletonInstance GetSkeletonInstance()
		{
			this.NullCheck("GetSkeletonInstance");
			method cbsePl_GetSkeletonInstance = CBasePlayer.__N.CBsePl_GetSkeletonInstance;
			return calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetSkeletonInstance);
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0002C540 File Offset: 0x0002A740
		internal readonly void SetModelScale(float scale)
		{
			this.NullCheck("SetModelScale");
			method cbsePl_SetModelScale = CBasePlayer.__N.CBsePl_SetModelScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, scale, cbsePl_SetModelScale);
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x0002C56C File Offset: 0x0002A76C
		internal readonly float GetModelScale()
		{
			this.NullCheck("GetModelScale");
			method cbsePl_GetModelScale = CBasePlayer.__N.CBsePl_GetModelScale;
			return calli(System.Single(System.IntPtr), this.self, cbsePl_GetModelScale);
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x0002C598 File Offset: 0x0002A798
		internal readonly int GetNumBones()
		{
			this.NullCheck("GetNumBones");
			method cbsePl_GetNumBones = CBasePlayer.__N.CBsePl_GetNumBones;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_GetNumBones);
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x0002C5C4 File Offset: 0x0002A7C4
		internal readonly int LookupBone(string szName)
		{
			this.NullCheck("LookupBone");
			method cbsePl_LookupBone = CBasePlayer.__N.CBsePl_LookupBone;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(szName), cbsePl_LookupBone);
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x0002C5F4 File Offset: 0x0002A7F4
		internal readonly int GetAttachmentCount()
		{
			this.NullCheck("GetAttachmentCount");
			method cbsePl_GetAttachmentCount = CBasePlayer.__N.CBsePl_GetAttachmentCount;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_GetAttachmentCount);
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x0002C620 File Offset: 0x0002A820
		internal readonly float GetMinFadeDist()
		{
			this.NullCheck("GetMinFadeDist");
			method cbsePl_GetMinFadeDist = CBasePlayer.__N.CBsePl_GetMinFadeDist;
			return calli(System.Single(System.IntPtr), this.self, cbsePl_GetMinFadeDist);
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0002C64C File Offset: 0x0002A84C
		internal readonly float GetMaxFadeDist()
		{
			this.NullCheck("GetMaxFadeDist");
			method cbsePl_GetMaxFadeDist = CBasePlayer.__N.CBsePl_GetMaxFadeDist;
			return calli(System.Single(System.IntPtr), this.self, cbsePl_GetMaxFadeDist);
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x0002C678 File Offset: 0x0002A878
		internal readonly void SetModel(string name)
		{
			this.NullCheck("SetModel");
			method cbsePl_SetModel = CBasePlayer.__N.CBsePl_SetModel;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbsePl_SetModel);
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x0002C6A8 File Offset: 0x0002A8A8
		internal readonly IModel GetModel()
		{
			this.NullCheck("GetModel");
			method cbsePl_GetModel = CBasePlayer.__N.CBsePl_GetModel;
			return calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetModel);
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x0002C6D8 File Offset: 0x0002A8D8
		internal readonly void SetModel(IModel model)
		{
			this.NullCheck("SetModel");
			method cbsePl_f = CBasePlayer.__N.CBsePl_f2;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, model, cbsePl_f);
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x0002C708 File Offset: 0x0002A908
		internal readonly void SetModelAsync(string name)
		{
			this.NullCheck("SetModelAsync");
			method cbsePl_SetModelAsync = CBasePlayer.__N.CBsePl_SetModelAsync;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbsePl_SetModelAsync);
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x0002C738 File Offset: 0x0002A938
		internal readonly void SetBodygroup(int iGroup, int iValue)
		{
			this.NullCheck("SetBodygroup");
			method cbsePl_SetBodygroup = CBasePlayer.__N.CBsePl_SetBodygroup;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32), this.self, iGroup, iValue, cbsePl_SetBodygroup);
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x0002C764 File Offset: 0x0002A964
		internal readonly void SetBodygroupByName(string pName, int iValue)
		{
			this.NullCheck("SetBodygroupByName");
			method cbsePl_SetBodygroupByName = CBasePlayer.__N.CBsePl_SetBodygroupByName;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(pName), iValue, cbsePl_SetBodygroupByName);
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0002C798 File Offset: 0x0002A998
		internal readonly ulong GetRawMeshGroupMask()
		{
			this.NullCheck("GetRawMeshGroupMask");
			method cbsePl_GetRawMeshGroupMask = CBasePlayer.__N.CBsePl_GetRawMeshGroupMask;
			return calli(System.UInt64(System.IntPtr), this.self, cbsePl_GetRawMeshGroupMask);
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x0002C7C4 File Offset: 0x0002A9C4
		internal readonly void SetRawMeshGroupMask_LegacyDoNotUse(ulong nBody)
		{
			this.NullCheck("SetRawMeshGroupMask_LegacyDoNotUse");
			method cbsePl_SetRawMeshGroupMask_LegacyDoNotUse = CBasePlayer.__N.CBsePl_SetRawMeshGroupMask_LegacyDoNotUse;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBody, cbsePl_SetRawMeshGroupMask_LegacyDoNotUse);
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x0002C7F0 File Offset: 0x0002A9F0
		internal readonly int GetSkinCount()
		{
			this.NullCheck("GetSkinCount");
			method cbsePl_GetSkinCount = CBasePlayer.__N.CBsePl_GetSkinCount;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_GetSkinCount);
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x0002C81C File Offset: 0x0002AA1C
		internal readonly void SetSkin(int iSkin)
		{
			this.NullCheck("SetSkin");
			method cbsePl_SetSkin = CBasePlayer.__N.CBsePl_SetSkin;
			calli(System.Void(System.IntPtr,System.Int32), this.self, iSkin, cbsePl_SetSkin);
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x0002C848 File Offset: 0x0002AA48
		internal readonly void SetSkin(string name)
		{
			this.NullCheck("SetSkin");
			method cbsePl_f = CBasePlayer.__N.CBsePl_f3;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(name), cbsePl_f);
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x0002C878 File Offset: 0x0002AA78
		internal readonly int GetS1Skin()
		{
			this.NullCheck("GetS1Skin");
			method cbsePl_GetS1Skin = CBasePlayer.__N.CBsePl_GetS1Skin;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_GetS1Skin);
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x0002C8A4 File Offset: 0x0002AAA4
		internal readonly CollisionProperty CollisionProp()
		{
			this.NullCheck("CollisionProp");
			method cbsePl_CollisionProp = CBasePlayer.__N.CBsePl_CollisionProp;
			return calli(System.IntPtr(System.IntPtr), this.self, cbsePl_CollisionProp);
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x0002C8D4 File Offset: 0x0002AAD4
		internal readonly void SetRenderAlpha(byte alpha)
		{
			this.NullCheck("SetRenderAlpha");
			method cbsePl_SetRenderAlpha = CBasePlayer.__N.CBsePl_SetRenderAlpha;
			calli(System.Void(System.IntPtr,System.Byte), this.self, alpha, cbsePl_SetRenderAlpha);
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x0002C900 File Offset: 0x0002AB00
		internal readonly byte GetRenderAlpha()
		{
			this.NullCheck("GetRenderAlpha");
			method cbsePl_GetRenderAlpha = CBasePlayer.__N.CBsePl_GetRenderAlpha;
			return calli(System.Byte(System.IntPtr), this.self, cbsePl_GetRenderAlpha);
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x0002C92C File Offset: 0x0002AB2C
		internal readonly void SetRenderColor(byte r, byte g, byte b)
		{
			this.NullCheck("SetRenderColor");
			method cbsePl_SetRenderColor = CBasePlayer.__N.CBsePl_SetRenderColor;
			calli(System.Void(System.IntPtr,System.Byte,System.Byte,System.Byte), this.self, r, g, b, cbsePl_SetRenderColor);
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0002C95C File Offset: 0x0002AB5C
		internal readonly void SetRenderColorAndAlpha(Color32 color)
		{
			this.NullCheck("SetRenderColorAndAlpha");
			method cbsePl_SetRenderColorAndAlpha = CBasePlayer.__N.CBsePl_SetRenderColorAndAlpha;
			calli(System.Void(System.IntPtr,Color32), this.self, color, cbsePl_SetRenderColorAndAlpha);
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0002C988 File Offset: 0x0002AB88
		internal readonly Color24 GetRenderColor()
		{
			this.NullCheck("GetRenderColor");
			method cbsePl_GetRenderColor = CBasePlayer.__N.CBsePl_GetRenderColor;
			return calli(Color24(System.IntPtr), this.self, cbsePl_GetRenderColor);
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0002C9B4 File Offset: 0x0002ABB4
		internal readonly CGlowProperty GlowProp()
		{
			this.NullCheck("GlowProp");
			method cbsePl_GlowProp = CBasePlayer.__N.CBsePl_GlowProp;
			return calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GlowProp);
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0002C9E4 File Offset: 0x0002ABE4
		internal readonly Transform GetBoneTransform(int bone)
		{
			this.NullCheck("GetBoneTransform");
			method cbsePl_GetBoneTransform = CBasePlayer.__N.CBsePl_GetBoneTransform;
			return calli(Transform(System.IntPtr,System.Int32), this.self, bone, cbsePl_GetBoneTransform);
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0002CA10 File Offset: 0x0002AC10
		internal readonly DataTable GetDataTable()
		{
			this.NullCheck("GetDataTable");
			method cbsePl_GetDataTable = CBasePlayer.__N.CBsePl_GetDataTable;
			return calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetDataTable);
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x0002CA40 File Offset: 0x0002AC40
		internal readonly int GetEntityHandle()
		{
			this.NullCheck("GetEntityHandle");
			method cbsePl_GetEntityHandle = CBasePlayer.__N.CBsePl_GetEntityHandle;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_GetEntityHandle);
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x0002CA6C File Offset: 0x0002AC6C
		internal unsafe readonly void SetLocalOrigin(Vector3 v)
		{
			this.NullCheck("SetLocalOrigin");
			method cbsePl_SetLocalOrigin = CBasePlayer.__N.CBsePl_SetLocalOrigin;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, cbsePl_SetLocalOrigin);
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x0002CA9C File Offset: 0x0002AC9C
		internal readonly Vector3 GetLocalOrigin()
		{
			this.NullCheck("GetLocalOrigin");
			method cbsePl_GetLocalOrigin = CBasePlayer.__N.CBsePl_GetLocalOrigin;
			return calli(Vector3(System.IntPtr), this.self, cbsePl_GetLocalOrigin);
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x0002CAC8 File Offset: 0x0002ACC8
		internal unsafe readonly void SetAbsOrigin(Vector3 origin)
		{
			this.NullCheck("SetAbsOrigin");
			method cbsePl_SetAbsOrigin = CBasePlayer.__N.CBsePl_SetAbsOrigin;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &origin, cbsePl_SetAbsOrigin);
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x0002CAF8 File Offset: 0x0002ACF8
		internal unsafe readonly void SetAbsAngles(Angles angles)
		{
			this.NullCheck("SetAbsAngles");
			method cbsePl_SetAbsAngles = CBasePlayer.__N.CBsePl_SetAbsAngles;
			calli(System.Void(System.IntPtr,Angles*), this.self, &angles, cbsePl_SetAbsAngles);
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x0002CB28 File Offset: 0x0002AD28
		internal readonly string GetClassname()
		{
			this.NullCheck("GetClassname");
			method cbsePl_GetClassname = CBasePlayer.__N.CBsePl_GetClassname;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetClassname));
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x0002CB58 File Offset: 0x0002AD58
		internal readonly Vector3 GetAbsOrigin()
		{
			this.NullCheck("GetAbsOrigin");
			method cbsePl_GetAbsOrigin = CBasePlayer.__N.CBsePl_GetAbsOrigin;
			return calli(Vector3(System.IntPtr), this.self, cbsePl_GetAbsOrigin);
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x0002CB84 File Offset: 0x0002AD84
		internal readonly Angles GetAbsAngles()
		{
			this.NullCheck("GetAbsAngles");
			method cbsePl_GetAbsAngles = CBasePlayer.__N.CBsePl_GetAbsAngles;
			return calli(Angles(System.IntPtr), this.self, cbsePl_GetAbsAngles);
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x0002CBB0 File Offset: 0x0002ADB0
		internal readonly void EnableLagCompensation(bool enabled)
		{
			this.NullCheck("EnableLagCompensation");
			method cbsePl_EnableLagCompensation = CBasePlayer.__N.CBsePl_EnableLagCompensation;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, cbsePl_EnableLagCompensation);
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x0002CBE4 File Offset: 0x0002ADE4
		internal readonly bool IsLagCompensationEnabled()
		{
			this.NullCheck("IsLagCompensationEnabled");
			method cbsePl_IsLagCompensationEnabled = CBasePlayer.__N.CBsePl_IsLagCompensationEnabled;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_IsLagCompensationEnabled) > 0;
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x0002CC14 File Offset: 0x0002AE14
		internal readonly Rotation GetLocalQuat()
		{
			this.NullCheck("GetLocalQuat");
			method cbsePl_GetLocalQuat = CBasePlayer.__N.CBsePl_GetLocalQuat;
			return calli(Rotation(System.IntPtr), this.self, cbsePl_GetLocalQuat);
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x0002CC40 File Offset: 0x0002AE40
		internal unsafe readonly void SetLocalQuat(Rotation rot)
		{
			this.NullCheck("SetLocalQuat");
			method cbsePl_SetLocalQuat = CBasePlayer.__N.CBsePl_SetLocalQuat;
			calli(System.Void(System.IntPtr,Rotation*), this.self, &rot, cbsePl_SetLocalQuat);
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x0002CC70 File Offset: 0x0002AE70
		internal readonly Rotation GetAbsQuat()
		{
			this.NullCheck("GetAbsQuat");
			method cbsePl_GetAbsQuat = CBasePlayer.__N.CBsePl_GetAbsQuat;
			return calli(Rotation(System.IntPtr), this.self, cbsePl_GetAbsQuat);
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x0002CC9C File Offset: 0x0002AE9C
		internal unsafe readonly void SetAbsQuat(Rotation rot)
		{
			this.NullCheck("SetAbsQuat");
			method cbsePl_SetAbsQuat = CBasePlayer.__N.CBsePl_SetAbsQuat;
			calli(System.Void(System.IntPtr,Rotation*), this.self, &rot, cbsePl_SetAbsQuat);
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0002CCCC File Offset: 0x0002AECC
		internal readonly float GetAbsScale()
		{
			this.NullCheck("GetAbsScale");
			method cbsePl_GetAbsScale = CBasePlayer.__N.CBsePl_GetAbsScale;
			return calli(System.Single(System.IntPtr), this.self, cbsePl_GetAbsScale);
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x0002CCF8 File Offset: 0x0002AEF8
		internal readonly void SetAbsScale(float flScale)
		{
			this.NullCheck("SetAbsScale");
			method cbsePl_SetAbsScale = CBasePlayer.__N.CBsePl_SetAbsScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, flScale, cbsePl_SetAbsScale);
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x0002CD24 File Offset: 0x0002AF24
		internal readonly float GetLocalScale()
		{
			this.NullCheck("GetLocalScale");
			method cbsePl_GetLocalScale = CBasePlayer.__N.CBsePl_GetLocalScale;
			return calli(System.Single(System.IntPtr), this.self, cbsePl_GetLocalScale);
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x0002CD50 File Offset: 0x0002AF50
		internal readonly void SetLocalScale(float flScale)
		{
			this.NullCheck("SetLocalScale");
			method cbsePl_SetLocalScale = CBasePlayer.__N.CBsePl_SetLocalScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, flScale, cbsePl_SetLocalScale);
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x0002CD7C File Offset: 0x0002AF7C
		internal readonly int entindex()
		{
			this.NullCheck("entindex");
			method cbsePl_entindex = CBasePlayer.__N.CBsePl_entindex;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_entindex);
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x0002CDA8 File Offset: 0x0002AFA8
		internal unsafe readonly void SetAbsVelocity(Vector3 origin)
		{
			this.NullCheck("SetAbsVelocity");
			method cbsePl_SetAbsVelocity = CBasePlayer.__N.CBsePl_SetAbsVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &origin, cbsePl_SetAbsVelocity);
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x0002CDD8 File Offset: 0x0002AFD8
		internal readonly Vector3 GetAbsVelocity()
		{
			this.NullCheck("GetAbsVelocity");
			method cbsePl_GetAbsVelocity = CBasePlayer.__N.CBsePl_GetAbsVelocity;
			return calli(Vector3(System.IntPtr), this.self, cbsePl_GetAbsVelocity);
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0002CE04 File Offset: 0x0002B004
		internal readonly void AddFlag(int flags)
		{
			this.NullCheck("AddFlag");
			method cbsePl_AddFlag = CBasePlayer.__N.CBsePl_AddFlag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flags, cbsePl_AddFlag);
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0002CE30 File Offset: 0x0002B030
		internal readonly void RemoveFlag(int flagsToRemove)
		{
			this.NullCheck("RemoveFlag");
			method cbsePl_RemoveFlag = CBasePlayer.__N.CBsePl_RemoveFlag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flagsToRemove, cbsePl_RemoveFlag);
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0002CE5C File Offset: 0x0002B05C
		internal readonly void ToggleFlag(int flagToToggle)
		{
			this.NullCheck("ToggleFlag");
			method cbsePl_ToggleFlag = CBasePlayer.__N.CBsePl_ToggleFlag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flagToToggle, cbsePl_ToggleFlag);
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0002CE88 File Offset: 0x0002B088
		internal readonly void ClearFlags()
		{
			this.NullCheck("ClearFlags");
			method cbsePl_ClearFlags = CBasePlayer.__N.CBsePl_ClearFlags;
			calli(System.Void(System.IntPtr), this.self, cbsePl_ClearFlags);
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x0002CEB4 File Offset: 0x0002B0B4
		internal readonly int GetFlags()
		{
			this.NullCheck("GetFlags");
			method cbsePl_GetFlags = CBasePlayer.__N.CBsePl_GetFlags;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_GetFlags);
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x0002CEE0 File Offset: 0x0002B0E0
		internal readonly void SetLifeState(LifeState state)
		{
			this.NullCheck("SetLifeState");
			method cbsePl_SetLifeState = CBasePlayer.__N.CBsePl_SetLifeState;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)state, cbsePl_SetLifeState);
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x0002CF0C File Offset: 0x0002B10C
		internal readonly LifeState GetLifeState()
		{
			this.NullCheck("GetLifeState");
			method cbsePl_GetLifeState = CBasePlayer.__N.CBsePl_GetLifeState;
			return calli(System.Int64(System.IntPtr), this.self, cbsePl_GetLifeState);
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x0002CF38 File Offset: 0x0002B138
		internal readonly int GetEffects()
		{
			this.NullCheck("GetEffects");
			method cbsePl_GetEffects = CBasePlayer.__N.CBsePl_GetEffects;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_GetEffects);
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x0002CF64 File Offset: 0x0002B164
		internal readonly void AddEffects(int nEffects)
		{
			this.NullCheck("AddEffects");
			method cbsePl_AddEffects = CBasePlayer.__N.CBsePl_AddEffects;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nEffects, cbsePl_AddEffects);
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x0002CF90 File Offset: 0x0002B190
		internal readonly void RemoveEffects(int nEffects)
		{
			this.NullCheck("RemoveEffects");
			method cbsePl_RemoveEffects = CBasePlayer.__N.CBsePl_RemoveEffects;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nEffects, cbsePl_RemoveEffects);
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x0002CFBC File Offset: 0x0002B1BC
		internal readonly void ClearEffects()
		{
			this.NullCheck("ClearEffects");
			method cbsePl_ClearEffects = CBasePlayer.__N.CBsePl_ClearEffects;
			calli(System.Void(System.IntPtr), this.self, cbsePl_ClearEffects);
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x0002CFE8 File Offset: 0x0002B1E8
		internal readonly void SetEffects(int nEffects)
		{
			this.NullCheck("SetEffects");
			method cbsePl_SetEffects = CBasePlayer.__N.CBsePl_SetEffects;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nEffects, cbsePl_SetEffects);
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x0002D014 File Offset: 0x0002B214
		internal readonly bool IsEffectActive(int nEffectMask)
		{
			this.NullCheck("IsEffectActive");
			method cbsePl_IsEffectActive = CBasePlayer.__N.CBsePl_IsEffectActive;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, nEffectMask, cbsePl_IsEffectActive) > 0;
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0002D044 File Offset: 0x0002B244
		internal readonly void CreateVPhysics()
		{
			this.NullCheck("CreateVPhysics");
			method cbsePl_CreateVPhysics = CBasePlayer.__N.CBsePl_CreateVPhysics;
			calli(System.Void(System.IntPtr), this.self, cbsePl_CreateVPhysics);
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x0002D070 File Offset: 0x0002B270
		internal unsafe readonly void ApplyAbsVelocityImpulse(Vector3 vecImpulse)
		{
			this.NullCheck("ApplyAbsVelocityImpulse");
			method cbsePl_ApplyAbsVelocityImpulse = CBasePlayer.__N.CBsePl_ApplyAbsVelocityImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vecImpulse, cbsePl_ApplyAbsVelocityImpulse);
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0002D0A0 File Offset: 0x0002B2A0
		internal unsafe readonly void ApplyLocalVelocityImpulse(Vector3 vecImpulse)
		{
			this.NullCheck("ApplyLocalVelocityImpulse");
			method cbsePl_ApplyLocalVelocityImpulse = CBasePlayer.__N.CBsePl_ApplyLocalVelocityImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vecImpulse, cbsePl_ApplyLocalVelocityImpulse);
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x0002D0D0 File Offset: 0x0002B2D0
		internal unsafe readonly void ApplyLocalAngularVelocityImpulse(Vector3 angImpulse)
		{
			this.NullCheck("ApplyLocalAngularVelocityImpulse");
			method cbsePl_ApplyLocalAngularVelocityImpulse = CBasePlayer.__N.CBsePl_ApplyLocalAngularVelocityImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &angImpulse, cbsePl_ApplyLocalAngularVelocityImpulse);
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x0002D100 File Offset: 0x0002B300
		internal readonly void SetMoveType(MoveType val, MoveCollide moveCollide)
		{
			this.NullCheck("SetMoveType");
			method cbsePl_SetMoveType = CBasePlayer.__N.CBsePl_SetMoveType;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (ulong)val, (ulong)moveCollide, cbsePl_SetMoveType);
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x0002D130 File Offset: 0x0002B330
		internal readonly MoveType GetMoveType()
		{
			this.NullCheck("GetMoveType");
			method cbsePl_GetMoveType = CBasePlayer.__N.CBsePl_GetMoveType;
			return calli(System.Int64(System.IntPtr), this.self, cbsePl_GetMoveType);
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x0002D15C File Offset: 0x0002B35C
		internal readonly void PhysicsEnableMotion(bool bEnable)
		{
			this.NullCheck("PhysicsEnableMotion");
			method cbsePl_PhysicsEnableMotion = CBasePlayer.__N.CBsePl_PhysicsEnableMotion;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnable ? 1 : 0, cbsePl_PhysicsEnableMotion);
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x0002D190 File Offset: 0x0002B390
		internal readonly void FollowEntity(IntPtr pBaseEntity, bool bBoneMerge)
		{
			this.NullCheck("FollowEntity");
			method cbsePl_FollowEntity = CBasePlayer.__N.CBsePl_FollowEntity;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, pBaseEntity, bBoneMerge ? 1 : 0, cbsePl_FollowEntity);
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x0002D1C4 File Offset: 0x0002B3C4
		internal readonly void StopFollowingEntity()
		{
			this.NullCheck("StopFollowingEntity");
			method cbsePl_StopFollowingEntity = CBasePlayer.__N.CBsePl_StopFollowingEntity;
			calli(System.Void(System.IntPtr), this.self, cbsePl_StopFollowingEntity);
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x0002D1F0 File Offset: 0x0002B3F0
		internal readonly bool IsFollowingEntity()
		{
			this.NullCheck("IsFollowingEntity");
			method cbsePl_IsFollowingEntity = CBasePlayer.__N.CBsePl_IsFollowingEntity;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_IsFollowingEntity) > 0;
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x0002D220 File Offset: 0x0002B420
		internal readonly CBaseEntity GetFollowedEntity()
		{
			this.NullCheck("GetFollowedEntity");
			method cbsePl_GetFollowedEntity = CBasePlayer.__N.CBsePl_GetFollowedEntity;
			return calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetFollowedEntity);
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x0002D250 File Offset: 0x0002B450
		internal readonly PhysicsGroup VPhysicsGetAggregate()
		{
			this.NullCheck("VPhysicsGetAggregate");
			method cbsePl_VPhysicsGetAggregate = CBasePlayer.__N.CBsePl_VPhysicsGetAggregate;
			return HandleIndex.Get<PhysicsGroup>(calli(System.Int32(System.IntPtr), this.self, cbsePl_VPhysicsGetAggregate));
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x0002D280 File Offset: 0x0002B480
		internal readonly Vector3 GetBaseVelocity()
		{
			this.NullCheck("GetBaseVelocity");
			method cbsePl_GetBaseVelocity = CBasePlayer.__N.CBsePl_GetBaseVelocity;
			return calli(Vector3(System.IntPtr), this.self, cbsePl_GetBaseVelocity);
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x0002D2AC File Offset: 0x0002B4AC
		internal unsafe readonly void SetBaseVelocity(Vector3 v)
		{
			this.NullCheck("SetBaseVelocity");
			method cbsePl_SetBaseVelocity = CBasePlayer.__N.CBsePl_SetBaseVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, cbsePl_SetBaseVelocity);
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x0002D2DC File Offset: 0x0002B4DC
		internal readonly void SetGroundEntity(CBaseEntity ground)
		{
			this.NullCheck("SetGroundEntity");
			method cbsePl_SetGroundEntity = CBasePlayer.__N.CBsePl_SetGroundEntity;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, ground, cbsePl_SetGroundEntity);
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x0002D30C File Offset: 0x0002B50C
		internal readonly CBaseEntity GetGroundEntity()
		{
			this.NullCheck("GetGroundEntity");
			method cbsePl_GetGroundEntity = CBasePlayer.__N.CBsePl_GetGroundEntity;
			return calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetGroundEntity);
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x0002D33C File Offset: 0x0002B53C
		internal readonly string GetModelNameString()
		{
			this.NullCheck("GetModelNameString");
			method cbsePl_GetModelNameString = CBasePlayer.__N.CBsePl_GetModelNameString;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetModelNameString));
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x0002D36C File Offset: 0x0002B56C
		internal unsafe readonly void SetParent(CBaseEntity parent, string nBoneOrAttachName, Transform pOffsetTransform)
		{
			this.NullCheck("SetParent");
			method cbsePl_SetParent = CBasePlayer.__N.CBsePl_SetParent;
			calli(System.Void(System.IntPtr,System.IntPtr,System.UInt32,Transform*), this.self, parent, StringToken.FindOrCreate(nBoneOrAttachName), &pOffsetTransform, cbsePl_SetParent);
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x0002D3A8 File Offset: 0x0002B5A8
		internal readonly void SetParent(CBaseEntity parent, string nBoneOrAttachName)
		{
			this.NullCheck("SetParent");
			method cbsePl_f = CBasePlayer.__N.CBsePl_f4;
			calli(System.Void(System.IntPtr,System.IntPtr,System.UInt32), this.self, parent, StringToken.FindOrCreate(nBoneOrAttachName), cbsePl_f);
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x0002D3E0 File Offset: 0x0002B5E0
		internal readonly CBaseEntity GetParent()
		{
			this.NullCheck("GetParent");
			method cbsePl_GetParent = CBasePlayer.__N.CBsePl_GetParent;
			return calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetParent);
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x0002D410 File Offset: 0x0002B610
		internal readonly void IncrementInterpolationFrame()
		{
			this.NullCheck("IncrementInterpolationFrame");
			method cbsePl_IncrementInterpolationFrame = CBasePlayer.__N.CBsePl_IncrementInterpolationFrame;
			calli(System.Void(System.IntPtr), this.self, cbsePl_IncrementInterpolationFrame);
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x0002D43C File Offset: 0x0002B63C
		internal readonly void DispatchUpdateTransmitState()
		{
			this.NullCheck("DispatchUpdateTransmitState");
			method cbsePl_DispatchUpdateTransmitState = CBasePlayer.__N.CBsePl_DispatchUpdateTransmitState;
			calli(System.Void(System.IntPtr), this.self, cbsePl_DispatchUpdateTransmitState);
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x0002D468 File Offset: 0x0002B668
		internal readonly void SetActiveChild(CBaseEntity child)
		{
			this.NullCheck("SetActiveChild");
			method cbsePl_SetActiveChild = CBasePlayer.__N.CBsePl_SetActiveChild;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, child, cbsePl_SetActiveChild);
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x0002D498 File Offset: 0x0002B698
		internal readonly CBaseEntity GetActiveChild()
		{
			this.NullCheck("GetActiveChild");
			method cbsePl_GetActiveChild = CBasePlayer.__N.CBsePl_GetActiveChild;
			return calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetActiveChild);
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x0002D4C8 File Offset: 0x0002B6C8
		internal readonly void SetOwnerEntity(CBaseEntity child)
		{
			this.NullCheck("SetOwnerEntity");
			method cbsePl_SetOwnerEntity = CBasePlayer.__N.CBsePl_SetOwnerEntity;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, child, cbsePl_SetOwnerEntity);
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x0002D4F8 File Offset: 0x0002B6F8
		internal readonly CBaseEntity GetOwnerEntity()
		{
			this.NullCheck("GetOwnerEntity");
			method cbsePl_GetOwnerEntity = CBasePlayer.__N.CBsePl_GetOwnerEntity;
			return calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetOwnerEntity);
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x0002D528 File Offset: 0x0002B728
		internal readonly void SetSimulationTime(float time)
		{
			this.NullCheck("SetSimulationTime");
			method cbsePl_SetSimulationTime = CBasePlayer.__N.CBsePl_SetSimulationTime;
			calli(System.Void(System.IntPtr,System.Single), this.self, time, cbsePl_SetSimulationTime);
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0002D554 File Offset: 0x0002B754
		internal readonly bool HasSpawnFlags(int nFlags)
		{
			this.NullCheck("HasSpawnFlags");
			method cbsePl_HasSpawnFlags = CBasePlayer.__N.CBsePl_HasSpawnFlags;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, nFlags, cbsePl_HasSpawnFlags) > 0;
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x0002D584 File Offset: 0x0002B784
		internal readonly int GetSpawnFlags()
		{
			this.NullCheck("GetSpawnFlags");
			method cbsePl_GetSpawnFlags = CBasePlayer.__N.CBsePl_GetSpawnFlags;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_GetSpawnFlags);
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x0002D5B0 File Offset: 0x0002B7B0
		internal readonly void AddSpawnFlags(int nFlags)
		{
			this.NullCheck("AddSpawnFlags");
			method cbsePl_AddSpawnFlags = CBasePlayer.__N.CBsePl_AddSpawnFlags;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nFlags, cbsePl_AddSpawnFlags);
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x0002D5DC File Offset: 0x0002B7DC
		internal readonly void RemoveSpawnFlags(int nFlags)
		{
			this.NullCheck("RemoveSpawnFlags");
			method cbsePl_RemoveSpawnFlags = CBasePlayer.__N.CBsePl_RemoveSpawnFlags;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nFlags, cbsePl_RemoveSpawnFlags);
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x0002D608 File Offset: 0x0002B808
		internal readonly void ClearSpawnFlags()
		{
			this.NullCheck("ClearSpawnFlags");
			method cbsePl_ClearSpawnFlags = CBasePlayer.__N.CBsePl_ClearSpawnFlags;
			calli(System.Void(System.IntPtr), this.self, cbsePl_ClearSpawnFlags);
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x0002D634 File Offset: 0x0002B834
		internal readonly CLightComponent GetLightComponent()
		{
			this.NullCheck("GetLightComponent");
			method cbsePl_GetLightComponent = CBasePlayer.__N.CBsePl_GetLightComponent;
			return calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetLightComponent);
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x0002D664 File Offset: 0x0002B864
		internal readonly void SetMoveDoneTime(float time)
		{
			this.NullCheck("SetMoveDoneTime");
			method cbsePl_SetMoveDoneTime = CBasePlayer.__N.CBsePl_SetMoveDoneTime;
			calli(System.Void(System.IntPtr,System.Single), this.self, time, cbsePl_SetMoveDoneTime);
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x0002D690 File Offset: 0x0002B890
		internal readonly float GetMoveDoneTime()
		{
			this.NullCheck("GetMoveDoneTime");
			method cbsePl_GetMoveDoneTime = CBasePlayer.__N.CBsePl_GetMoveDoneTime;
			return calli(System.Single(System.IntPtr), this.self, cbsePl_GetMoveDoneTime);
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x0002D6BC File Offset: 0x0002B8BC
		internal unsafe readonly void SetLocalVelocity(Vector3 vecVelocity)
		{
			this.NullCheck("SetLocalVelocity");
			method cbsePl_SetLocalVelocity = CBasePlayer.__N.CBsePl_SetLocalVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vecVelocity, cbsePl_SetLocalVelocity);
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x0002D6EC File Offset: 0x0002B8EC
		internal readonly Vector3 GetLocalVelocity()
		{
			this.NullCheck("GetLocalVelocity");
			method cbsePl_GetLocalVelocity = CBasePlayer.__N.CBsePl_GetLocalVelocity;
			return calli(Vector3(System.IntPtr), this.self, cbsePl_GetLocalVelocity);
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x0002D718 File Offset: 0x0002B918
		internal unsafe readonly void SetLocalAngularVelocity(Angles vecAngVelocity)
		{
			this.NullCheck("SetLocalAngularVelocity");
			method cbsePl_SetLocalAngularVelocity = CBasePlayer.__N.CBsePl_SetLocalAngularVelocity;
			calli(System.Void(System.IntPtr,Angles*), this.self, &vecAngVelocity, cbsePl_SetLocalAngularVelocity);
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x0002D748 File Offset: 0x0002B948
		internal readonly Angles GetLocalAngularVelocity()
		{
			this.NullCheck("GetLocalAngularVelocity");
			method cbsePl_GetLocalAngularVelocity = CBasePlayer.__N.CBsePl_GetLocalAngularVelocity;
			return calli(Angles(System.IntPtr), this.self, cbsePl_GetLocalAngularVelocity);
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x0002D774 File Offset: 0x0002B974
		internal readonly void SetDebugBits(ulong nBitMask)
		{
			this.NullCheck("SetDebugBits");
			method cbsePl_SetDebugBits = CBasePlayer.__N.CBsePl_SetDebugBits;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBitMask, cbsePl_SetDebugBits);
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x0002D7A0 File Offset: 0x0002B9A0
		internal readonly bool HasDebugBitsSet(ulong nBitMask)
		{
			this.NullCheck("HasDebugBitsSet");
			method cbsePl_HasDebugBitsSet = CBasePlayer.__N.CBsePl_HasDebugBitsSet;
			return calli(System.Int32(System.IntPtr,System.UInt64), this.self, nBitMask, cbsePl_HasDebugBitsSet) > 0;
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x0002D7D0 File Offset: 0x0002B9D0
		internal readonly void ClearDebugBits(ulong nBitMask)
		{
			this.NullCheck("ClearDebugBits");
			method cbsePl_ClearDebugBits = CBasePlayer.__N.CBsePl_ClearDebugBits;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBitMask, cbsePl_ClearDebugBits);
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x0002D7FC File Offset: 0x0002B9FC
		internal readonly void ToggleDebugBits(ulong nBitMask)
		{
			this.NullCheck("ToggleDebugBits");
			method cbsePl_ToggleDebugBits = CBasePlayer.__N.CBsePl_ToggleDebugBits;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBitMask, cbsePl_ToggleDebugBits);
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x0002D828 File Offset: 0x0002BA28
		internal readonly ulong GetDebugBits()
		{
			this.NullCheck("GetDebugBits");
			method cbsePl_GetDebugBits = CBasePlayer.__N.CBsePl_GetDebugBits;
			return calli(System.UInt64(System.IntPtr), this.self, cbsePl_GetDebugBits);
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x0002D854 File Offset: 0x0002BA54
		internal readonly void SetWaterEntity(CBaseEntity ent)
		{
			this.NullCheck("SetWaterEntity");
			method cbsePl_SetWaterEntity = CBasePlayer.__N.CBsePl_SetWaterEntity;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, ent, cbsePl_SetWaterEntity);
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x0002D884 File Offset: 0x0002BA84
		internal readonly Entity GetWaterEntity()
		{
			this.NullCheck("GetWaterEntity");
			method cbsePl_GetWaterEntity = CBasePlayer.__N.CBsePl_GetWaterEntity;
			return InteropSystem.Get<Entity>(calli(System.UInt32(System.IntPtr), this.self, cbsePl_GetWaterEntity));
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x0002D8B4 File Offset: 0x0002BAB4
		internal readonly void WorldSpaceAABB(out Vector3 mins, out Vector3 maxs)
		{
			this.NullCheck("WorldSpaceAABB");
			method cbsePl_WorldSpaceAABB = CBasePlayer.__N.CBsePl_WorldSpaceAABB;
			calli(System.Void(System.IntPtr,Vector3& modreq(System.Runtime.InteropServices.OutAttribute),Vector3& modreq(System.Runtime.InteropServices.OutAttribute)), this.self, ref mins, ref maxs, cbsePl_WorldSpaceAABB);
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x0002D8E0 File Offset: 0x0002BAE0
		internal readonly void RemoveAllDecals()
		{
			this.NullCheck("RemoveAllDecals");
			method cbsePl_RemoveAllDecals = CBasePlayer.__N.CBsePl_RemoveAllDecals;
			calli(System.Void(System.IntPtr), this.self, cbsePl_RemoveAllDecals);
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x0002D90C File Offset: 0x0002BB0C
		internal readonly string SB_GetEntityName()
		{
			this.NullCheck("SB_GetEntityName");
			method cbsePl_SB_GetEntityName = CBasePlayer.__N.CBsePl_SB_GetEntityName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbsePl_SB_GetEntityName));
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x0002D93C File Offset: 0x0002BB3C
		internal readonly void SB_SetEntityName(string name)
		{
			this.NullCheck("SB_SetEntityName");
			method cbsePl_SB_SetEntityName = CBasePlayer.__N.CBsePl_SB_SetEntityName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbsePl_SB_SetEntityName);
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x0002D96C File Offset: 0x0002BB6C
		internal readonly void SetData(int index, bool local, IntPtr data, int size)
		{
			this.NullCheck("SetData");
			method cbsePl_SetData = CBasePlayer.__N.CBsePl_SetData;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32,System.IntPtr,System.Int32), this.self, index, local ? 1 : 0, data, size, cbsePl_SetData);
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x0002D9A4 File Offset: 0x0002BBA4
		internal readonly void ClearData()
		{
			this.NullCheck("ClearData");
			method cbsePl_ClearData = CBasePlayer.__N.CBsePl_ClearData;
			calli(System.Void(System.IntPtr), this.self, cbsePl_ClearData);
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x0002D9D0 File Offset: 0x0002BBD0
		internal readonly bool IsServerOnly()
		{
			this.NullCheck("IsServerOnly");
			method cbsePl_IsServerOnly = CBasePlayer.__N.CBsePl_IsServerOnly;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_IsServerOnly) > 0;
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x0002DA00 File Offset: 0x0002BC00
		internal readonly bool IsClientOnly()
		{
			this.NullCheck("IsClientOnly");
			method cbsePl_IsClientOnly = CBasePlayer.__N.CBsePl_IsClientOnly;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_IsClientOnly) > 0;
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x0002DA30 File Offset: 0x0002BC30
		internal readonly bool IsClientServerNetworked()
		{
			this.NullCheck("IsClientServerNetworked");
			method cbsePl_IsClientServerNetworked = CBasePlayer.__N.CBsePl_IsClientServerNetworked;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_IsClientServerNetworked) > 0;
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060005AE RID: 1454 RVA: 0x0002DA5D File Offset: 0x0002BC5D
		// (set) Token: 0x060005AF RID: 1455 RVA: 0x0002DA7F File Offset: 0x0002BC7F
		internal CBaseEntity m_Pawn
		{
			get
			{
				this.NullCheck("m_Pawn");
				return CBasePlayer.__N.Get__CBsePl_m_Pawn(this.self);
			}
			set
			{
				this.NullCheck("m_Pawn");
				CBasePlayer.__N.Set__CBsePl_m_Pawn(this.self, value);
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x0002DAA2 File Offset: 0x0002BCA2
		// (set) Token: 0x060005B1 RID: 1457 RVA: 0x0002DABF File Offset: 0x0002BCBF
		internal int m_Ping
		{
			get
			{
				this.NullCheck("m_Ping");
				return CBasePlayer.__N.Get__CBsePl_m_Ping(this.self);
			}
			set
			{
				this.NullCheck("m_Ping");
				CBasePlayer.__N.Set__CBsePl_m_Ping(this.self, value);
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060005B2 RID: 1458 RVA: 0x0002DADD File Offset: 0x0002BCDD
		// (set) Token: 0x060005B3 RID: 1459 RVA: 0x0002DAFA File Offset: 0x0002BCFA
		internal int m_PacketLoss
		{
			get
			{
				this.NullCheck("m_PacketLoss");
				return CBasePlayer.__N.Get__CBsePl_m_PacketLoss(this.self);
			}
			set
			{
				this.NullCheck("m_PacketLoss");
				CBasePlayer.__N.Set__CBsePl_m_PacketLoss(this.self, value);
			}
		}

		// Token: 0x040000A4 RID: 164
		internal IntPtr self;

		// Token: 0x020001AD RID: 429
		internal static class __N
		{
			// Token: 0x04000B37 RID: 2871
			internal static method From_CBaseModelEntity_To_CBasePlayer;

			// Token: 0x04000B38 RID: 2872
			internal static method To_CBaseModelEntity_From_CBasePlayer;

			// Token: 0x04000B39 RID: 2873
			internal static method From_CBaseEntity_To_CBasePlayer;

			// Token: 0x04000B3A RID: 2874
			internal static method To_CBaseEntity_From_CBasePlayer;

			// Token: 0x04000B3B RID: 2875
			internal static method From_CGameEntity_To_CBasePlayer;

			// Token: 0x04000B3C RID: 2876
			internal static method To_CGameEntity_From_CBasePlayer;

			// Token: 0x04000B3D RID: 2877
			internal static method From_CEntityInstance_To_CBasePlayer;

			// Token: 0x04000B3E RID: 2878
			internal static method To_CEntityInstance_From_CBasePlayer;

			// Token: 0x04000B3F RID: 2879
			internal static method From_IHandleEntity_To_CBasePlayer;

			// Token: 0x04000B40 RID: 2880
			internal static method To_IHandleEntity_From_CBasePlayer;

			// Token: 0x04000B41 RID: 2881
			internal static method CBsePl_GetPlayerName;

			// Token: 0x04000B42 RID: 2882
			internal static method CBsePl_GetUserID;

			// Token: 0x04000B43 RID: 2883
			internal static method CBsePl_SetPlayerName;

			// Token: 0x04000B44 RID: 2884
			internal static method CBsePl_ClientCommand;

			// Token: 0x04000B45 RID: 2885
			internal static method CBsePl_UpdateButtonState;

			// Token: 0x04000B46 RID: 2886
			internal static method CBsePl_GetSteamIDAsUInt64;

			// Token: 0x04000B47 RID: 2887
			internal static method CBsePl_PlayerRunCommand;

			// Token: 0x04000B48 RID: 2888
			internal static method CBsePl_GetLastUserCommand;

			// Token: 0x04000B49 RID: 2889
			internal static method CBsePl_SetLastUserCommand;

			// Token: 0x04000B4A RID: 2890
			internal static method CBsePl_PreBotTick;

			// Token: 0x04000B4B RID: 2891
			internal static method CBsePl_PostBotTick;

			// Token: 0x04000B4C RID: 2892
			internal static method CBsePl_StartLagCompensation;

			// Token: 0x04000B4D RID: 2893
			internal static method CBsePl_FinishLagCompensation;

			// Token: 0x04000B4E RID: 2894
			internal static method CBsePl_IsVrUser;

			// Token: 0x04000B4F RID: 2895
			internal static method CBsePl_GetSkeletonInstance;

			// Token: 0x04000B50 RID: 2896
			internal static method CBsePl_SetModelScale;

			// Token: 0x04000B51 RID: 2897
			internal static method CBsePl_GetModelScale;

			// Token: 0x04000B52 RID: 2898
			internal static method CBsePl_GetNumBones;

			// Token: 0x04000B53 RID: 2899
			internal static method CBsePl_LookupBone;

			// Token: 0x04000B54 RID: 2900
			internal static method CBsePl_GetAttachmentCount;

			// Token: 0x04000B55 RID: 2901
			internal static method CBsePl_GetMinFadeDist;

			// Token: 0x04000B56 RID: 2902
			internal static method CBsePl_GetMaxFadeDist;

			// Token: 0x04000B57 RID: 2903
			internal static method CBsePl_SetModel;

			// Token: 0x04000B58 RID: 2904
			internal static method CBsePl_GetModel;

			// Token: 0x04000B59 RID: 2905
			internal static method CBsePl_f2;

			// Token: 0x04000B5A RID: 2906
			internal static method CBsePl_SetModelAsync;

			// Token: 0x04000B5B RID: 2907
			internal static method CBsePl_SetBodygroup;

			// Token: 0x04000B5C RID: 2908
			internal static method CBsePl_SetBodygroupByName;

			// Token: 0x04000B5D RID: 2909
			internal static method CBsePl_GetRawMeshGroupMask;

			// Token: 0x04000B5E RID: 2910
			internal static method CBsePl_SetRawMeshGroupMask_LegacyDoNotUse;

			// Token: 0x04000B5F RID: 2911
			internal static method CBsePl_GetSkinCount;

			// Token: 0x04000B60 RID: 2912
			internal static method CBsePl_SetSkin;

			// Token: 0x04000B61 RID: 2913
			internal static method CBsePl_f3;

			// Token: 0x04000B62 RID: 2914
			internal static method CBsePl_GetS1Skin;

			// Token: 0x04000B63 RID: 2915
			internal static method CBsePl_CollisionProp;

			// Token: 0x04000B64 RID: 2916
			internal static method CBsePl_SetRenderAlpha;

			// Token: 0x04000B65 RID: 2917
			internal static method CBsePl_GetRenderAlpha;

			// Token: 0x04000B66 RID: 2918
			internal static method CBsePl_SetRenderColor;

			// Token: 0x04000B67 RID: 2919
			internal static method CBsePl_SetRenderColorAndAlpha;

			// Token: 0x04000B68 RID: 2920
			internal static method CBsePl_GetRenderColor;

			// Token: 0x04000B69 RID: 2921
			internal static method CBsePl_GlowProp;

			// Token: 0x04000B6A RID: 2922
			internal static method CBsePl_GetBoneTransform;

			// Token: 0x04000B6B RID: 2923
			internal static method CBsePl_GetDataTable;

			// Token: 0x04000B6C RID: 2924
			internal static method CBsePl_GetEntityHandle;

			// Token: 0x04000B6D RID: 2925
			internal static method CBsePl_SetLocalOrigin;

			// Token: 0x04000B6E RID: 2926
			internal static method CBsePl_GetLocalOrigin;

			// Token: 0x04000B6F RID: 2927
			internal static method CBsePl_SetAbsOrigin;

			// Token: 0x04000B70 RID: 2928
			internal static method CBsePl_SetAbsAngles;

			// Token: 0x04000B71 RID: 2929
			internal static method CBsePl_GetClassname;

			// Token: 0x04000B72 RID: 2930
			internal static method CBsePl_GetAbsOrigin;

			// Token: 0x04000B73 RID: 2931
			internal static method CBsePl_GetAbsAngles;

			// Token: 0x04000B74 RID: 2932
			internal static method CBsePl_EnableLagCompensation;

			// Token: 0x04000B75 RID: 2933
			internal static method CBsePl_IsLagCompensationEnabled;

			// Token: 0x04000B76 RID: 2934
			internal static method CBsePl_GetLocalQuat;

			// Token: 0x04000B77 RID: 2935
			internal static method CBsePl_SetLocalQuat;

			// Token: 0x04000B78 RID: 2936
			internal static method CBsePl_GetAbsQuat;

			// Token: 0x04000B79 RID: 2937
			internal static method CBsePl_SetAbsQuat;

			// Token: 0x04000B7A RID: 2938
			internal static method CBsePl_GetAbsScale;

			// Token: 0x04000B7B RID: 2939
			internal static method CBsePl_SetAbsScale;

			// Token: 0x04000B7C RID: 2940
			internal static method CBsePl_GetLocalScale;

			// Token: 0x04000B7D RID: 2941
			internal static method CBsePl_SetLocalScale;

			// Token: 0x04000B7E RID: 2942
			internal static method CBsePl_entindex;

			// Token: 0x04000B7F RID: 2943
			internal static method CBsePl_SetAbsVelocity;

			// Token: 0x04000B80 RID: 2944
			internal static method CBsePl_GetAbsVelocity;

			// Token: 0x04000B81 RID: 2945
			internal static method CBsePl_AddFlag;

			// Token: 0x04000B82 RID: 2946
			internal static method CBsePl_RemoveFlag;

			// Token: 0x04000B83 RID: 2947
			internal static method CBsePl_ToggleFlag;

			// Token: 0x04000B84 RID: 2948
			internal static method CBsePl_ClearFlags;

			// Token: 0x04000B85 RID: 2949
			internal static method CBsePl_GetFlags;

			// Token: 0x04000B86 RID: 2950
			internal static method CBsePl_SetLifeState;

			// Token: 0x04000B87 RID: 2951
			internal static method CBsePl_GetLifeState;

			// Token: 0x04000B88 RID: 2952
			internal static method CBsePl_GetEffects;

			// Token: 0x04000B89 RID: 2953
			internal static method CBsePl_AddEffects;

			// Token: 0x04000B8A RID: 2954
			internal static method CBsePl_RemoveEffects;

			// Token: 0x04000B8B RID: 2955
			internal static method CBsePl_ClearEffects;

			// Token: 0x04000B8C RID: 2956
			internal static method CBsePl_SetEffects;

			// Token: 0x04000B8D RID: 2957
			internal static method CBsePl_IsEffectActive;

			// Token: 0x04000B8E RID: 2958
			internal static method CBsePl_CreateVPhysics;

			// Token: 0x04000B8F RID: 2959
			internal static method CBsePl_ApplyAbsVelocityImpulse;

			// Token: 0x04000B90 RID: 2960
			internal static method CBsePl_ApplyLocalVelocityImpulse;

			// Token: 0x04000B91 RID: 2961
			internal static method CBsePl_ApplyLocalAngularVelocityImpulse;

			// Token: 0x04000B92 RID: 2962
			internal static method CBsePl_SetMoveType;

			// Token: 0x04000B93 RID: 2963
			internal static method CBsePl_GetMoveType;

			// Token: 0x04000B94 RID: 2964
			internal static method CBsePl_PhysicsEnableMotion;

			// Token: 0x04000B95 RID: 2965
			internal static method CBsePl_FollowEntity;

			// Token: 0x04000B96 RID: 2966
			internal static method CBsePl_StopFollowingEntity;

			// Token: 0x04000B97 RID: 2967
			internal static method CBsePl_IsFollowingEntity;

			// Token: 0x04000B98 RID: 2968
			internal static method CBsePl_GetFollowedEntity;

			// Token: 0x04000B99 RID: 2969
			internal static method CBsePl_VPhysicsGetAggregate;

			// Token: 0x04000B9A RID: 2970
			internal static method CBsePl_GetBaseVelocity;

			// Token: 0x04000B9B RID: 2971
			internal static method CBsePl_SetBaseVelocity;

			// Token: 0x04000B9C RID: 2972
			internal static method CBsePl_SetGroundEntity;

			// Token: 0x04000B9D RID: 2973
			internal static method CBsePl_GetGroundEntity;

			// Token: 0x04000B9E RID: 2974
			internal static method CBsePl_GetModelNameString;

			// Token: 0x04000B9F RID: 2975
			internal static method CBsePl_SetParent;

			// Token: 0x04000BA0 RID: 2976
			internal static method CBsePl_f4;

			// Token: 0x04000BA1 RID: 2977
			internal static method CBsePl_GetParent;

			// Token: 0x04000BA2 RID: 2978
			internal static method CBsePl_IncrementInterpolationFrame;

			// Token: 0x04000BA3 RID: 2979
			internal static method CBsePl_DispatchUpdateTransmitState;

			// Token: 0x04000BA4 RID: 2980
			internal static method CBsePl_SetActiveChild;

			// Token: 0x04000BA5 RID: 2981
			internal static method CBsePl_GetActiveChild;

			// Token: 0x04000BA6 RID: 2982
			internal static method CBsePl_SetOwnerEntity;

			// Token: 0x04000BA7 RID: 2983
			internal static method CBsePl_GetOwnerEntity;

			// Token: 0x04000BA8 RID: 2984
			internal static method CBsePl_SetSimulationTime;

			// Token: 0x04000BA9 RID: 2985
			internal static method CBsePl_HasSpawnFlags;

			// Token: 0x04000BAA RID: 2986
			internal static method CBsePl_GetSpawnFlags;

			// Token: 0x04000BAB RID: 2987
			internal static method CBsePl_AddSpawnFlags;

			// Token: 0x04000BAC RID: 2988
			internal static method CBsePl_RemoveSpawnFlags;

			// Token: 0x04000BAD RID: 2989
			internal static method CBsePl_ClearSpawnFlags;

			// Token: 0x04000BAE RID: 2990
			internal static method CBsePl_GetLightComponent;

			// Token: 0x04000BAF RID: 2991
			internal static method CBsePl_SetMoveDoneTime;

			// Token: 0x04000BB0 RID: 2992
			internal static method CBsePl_GetMoveDoneTime;

			// Token: 0x04000BB1 RID: 2993
			internal static method CBsePl_SetLocalVelocity;

			// Token: 0x04000BB2 RID: 2994
			internal static method CBsePl_GetLocalVelocity;

			// Token: 0x04000BB3 RID: 2995
			internal static method CBsePl_SetLocalAngularVelocity;

			// Token: 0x04000BB4 RID: 2996
			internal static method CBsePl_GetLocalAngularVelocity;

			// Token: 0x04000BB5 RID: 2997
			internal static method CBsePl_SetDebugBits;

			// Token: 0x04000BB6 RID: 2998
			internal static method CBsePl_HasDebugBitsSet;

			// Token: 0x04000BB7 RID: 2999
			internal static method CBsePl_ClearDebugBits;

			// Token: 0x04000BB8 RID: 3000
			internal static method CBsePl_ToggleDebugBits;

			// Token: 0x04000BB9 RID: 3001
			internal static method CBsePl_GetDebugBits;

			// Token: 0x04000BBA RID: 3002
			internal static method CBsePl_SetWaterEntity;

			// Token: 0x04000BBB RID: 3003
			internal static method CBsePl_GetWaterEntity;

			// Token: 0x04000BBC RID: 3004
			internal static method CBsePl_WorldSpaceAABB;

			// Token: 0x04000BBD RID: 3005
			internal static method CBsePl_RemoveAllDecals;

			// Token: 0x04000BBE RID: 3006
			internal static method CBsePl_SB_GetEntityName;

			// Token: 0x04000BBF RID: 3007
			internal static method CBsePl_SB_SetEntityName;

			// Token: 0x04000BC0 RID: 3008
			internal static method CBsePl_SetData;

			// Token: 0x04000BC1 RID: 3009
			internal static method CBsePl_ClearData;

			// Token: 0x04000BC2 RID: 3010
			internal static method CBsePl_IsServerOnly;

			// Token: 0x04000BC3 RID: 3011
			internal static method CBsePl_IsClientOnly;

			// Token: 0x04000BC4 RID: 3012
			internal static method CBsePl_IsClientServerNetworked;

			// Token: 0x04000BC5 RID: 3013
			internal static CBasePlayer.__N._Get__CBsePl_m_Pawn Get__CBsePl_m_Pawn;

			// Token: 0x04000BC6 RID: 3014
			internal static CBasePlayer.__N._Set__CBsePl_m_Pawn Set__CBsePl_m_Pawn;

			// Token: 0x04000BC7 RID: 3015
			internal static CBasePlayer.__N._Get__CBsePl_m_Ping Get__CBsePl_m_Ping;

			// Token: 0x04000BC8 RID: 3016
			internal static CBasePlayer.__N._Set__CBsePl_m_Ping Set__CBsePl_m_Ping;

			// Token: 0x04000BC9 RID: 3017
			internal static CBasePlayer.__N._Get__CBsePl_m_PacketLoss Get__CBsePl_m_PacketLoss;

			// Token: 0x04000BCA RID: 3018
			internal static CBasePlayer.__N._Set__CBsePl_m_PacketLoss Set__CBsePl_m_PacketLoss;

			// Token: 0x020002F5 RID: 757
			// (Invoke) Token: 0x060020D0 RID: 8400
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr _Get__CBsePl_m_Pawn(IntPtr self);

			// Token: 0x020002F6 RID: 758
			// (Invoke) Token: 0x060020D4 RID: 8404
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBsePl_m_Pawn(IntPtr self, IntPtr val);

			// Token: 0x020002F7 RID: 759
			// (Invoke) Token: 0x060020D8 RID: 8408
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int _Get__CBsePl_m_Ping(IntPtr self);

			// Token: 0x020002F8 RID: 760
			// (Invoke) Token: 0x060020DC RID: 8412
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBsePl_m_Ping(IntPtr self, int val);

			// Token: 0x020002F9 RID: 761
			// (Invoke) Token: 0x060020E0 RID: 8416
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int _Get__CBsePl_m_PacketLoss(IntPtr self);

			// Token: 0x020002FA RID: 762
			// (Invoke) Token: 0x060020E4 RID: 8420
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBsePl_m_PacketLoss(IntPtr self, int val);
		}
	}
}
