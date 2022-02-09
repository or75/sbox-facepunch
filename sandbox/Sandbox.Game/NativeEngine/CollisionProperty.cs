using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000029 RID: 41
	internal struct CollisionProperty
	{
		// Token: 0x060005B4 RID: 1460 RVA: 0x0002DB18 File Offset: 0x0002BD18
		public static implicit operator IntPtr(CollisionProperty value)
		{
			return value.self;
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x0002DB20 File Offset: 0x0002BD20
		public static implicit operator CollisionProperty(IntPtr value)
		{
			return new CollisionProperty
			{
				self = value
			};
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x0002DB3E File Offset: 0x0002BD3E
		public static bool operator ==(CollisionProperty c1, CollisionProperty c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x0002DB51 File Offset: 0x0002BD51
		public static bool operator !=(CollisionProperty c1, CollisionProperty c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x0002DB64 File Offset: 0x0002BD64
		public override bool Equals(object obj)
		{
			if (obj is CollisionProperty)
			{
				CollisionProperty c = (CollisionProperty)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x0002DB8E File Offset: 0x0002BD8E
		internal CollisionProperty(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x0002DB98 File Offset: 0x0002BD98
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CollisionProperty ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060005BB RID: 1467 RVA: 0x0002DBD4 File Offset: 0x0002BDD4
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x0002DBE6 File Offset: 0x0002BDE6
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x0002DBF1 File Offset: 0x0002BDF1
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0002DC04 File Offset: 0x0002BE04
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CollisionProperty was null when calling " + n);
			}
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0002DC1F File Offset: 0x0002BE1F
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0002DC2C File Offset: 0x0002BE2C
		internal readonly Vector3 OBBMins()
		{
			this.NullCheck("OBBMins");
			method ccllsn_OBBMins = CollisionProperty.__N.CCllsn_OBBMins;
			return calli(Vector3(System.IntPtr), this.self, ccllsn_OBBMins);
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0002DC58 File Offset: 0x0002BE58
		internal readonly Vector3 OBBMaxs()
		{
			this.NullCheck("OBBMaxs");
			method ccllsn_OBBMaxs = CollisionProperty.__N.CCllsn_OBBMaxs;
			return calli(Vector3(System.IntPtr), this.self, ccllsn_OBBMaxs);
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x0002DC84 File Offset: 0x0002BE84
		internal readonly Vector3 GetCollisionOrigin()
		{
			this.NullCheck("GetCollisionOrigin");
			method ccllsn_GetCollisionOrigin = CollisionProperty.__N.CCllsn_GetCollisionOrigin;
			return calli(Vector3(System.IntPtr), this.self, ccllsn_GetCollisionOrigin);
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x0002DCB0 File Offset: 0x0002BEB0
		internal readonly Angles GetCollisionAngles()
		{
			this.NullCheck("GetCollisionAngles");
			method ccllsn_GetCollisionAngles = CollisionProperty.__N.CCllsn_GetCollisionAngles;
			return calli(Angles(System.IntPtr), this.self, ccllsn_GetCollisionAngles);
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0002DCDC File Offset: 0x0002BEDC
		internal readonly float GetCollisionScale()
		{
			this.NullCheck("GetCollisionScale");
			method ccllsn_GetCollisionScale = CollisionProperty.__N.CCllsn_GetCollisionScale;
			return calli(System.Single(System.IntPtr), this.self, ccllsn_GetCollisionScale);
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x0002DD08 File Offset: 0x0002BF08
		internal readonly SolidType GetSolid()
		{
			this.NullCheck("GetSolid");
			method ccllsn_GetSolid = CollisionProperty.__N.CCllsn_GetSolid;
			return calli(System.Int64(System.IntPtr), this.self, ccllsn_GetSolid);
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x0002DD34 File Offset: 0x0002BF34
		internal readonly int GetSolidFlags()
		{
			this.NullCheck("GetSolidFlags");
			method ccllsn_GetSolidFlags = CollisionProperty.__N.CCllsn_GetSolidFlags;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_GetSolidFlags);
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x0002DD60 File Offset: 0x0002BF60
		internal readonly int GetCollisionGroup()
		{
			this.NullCheck("GetCollisionGroup");
			method ccllsn_GetCollisionGroup = CollisionProperty.__N.CCllsn_GetCollisionGroup;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_GetCollisionGroup);
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x0002DD8C File Offset: 0x0002BF8C
		internal readonly PhysicsBody GetVPhysicsBody()
		{
			this.NullCheck("GetVPhysicsBody");
			method ccllsn_GetVPhysicsBody = CollisionProperty.__N.CCllsn_GetVPhysicsBody;
			return HandleIndex.Get<PhysicsBody>(calli(System.Int32(System.IntPtr), this.self, ccllsn_GetVPhysicsBody));
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x0002DDBC File Offset: 0x0002BFBC
		internal readonly void SetCollisionGroup(int group)
		{
			this.NullCheck("SetCollisionGroup");
			method ccllsn_SetCollisionGroup = CollisionProperty.__N.CCllsn_SetCollisionGroup;
			calli(System.Void(System.IntPtr,System.Int32), this.self, group, ccllsn_SetCollisionGroup);
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0002DDE8 File Offset: 0x0002BFE8
		internal readonly void MarkPartitionHandleDirty()
		{
			this.NullCheck("MarkPartitionHandleDirty");
			method ccllsn_MarkPartitionHandleDirty = CollisionProperty.__N.CCllsn_MarkPartitionHandleDirty;
			calli(System.Void(System.IntPtr), this.self, ccllsn_MarkPartitionHandleDirty);
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0002DE14 File Offset: 0x0002C014
		internal unsafe readonly void SetCollisionBounds(Vector3 mins, Vector3 maxs)
		{
			this.NullCheck("SetCollisionBounds");
			method ccllsn_SetCollisionBounds = CollisionProperty.__N.CCllsn_SetCollisionBounds;
			calli(System.Void(System.IntPtr,Vector3*,Vector3*), this.self, &mins, &maxs, ccllsn_SetCollisionBounds);
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x0002DE44 File Offset: 0x0002C044
		internal readonly BBox GetCollisionBounds()
		{
			this.NullCheck("GetCollisionBounds");
			method ccllsn_GetCollisionBounds = CollisionProperty.__N.CCllsn_GetCollisionBounds;
			return calli(BBox(System.IntPtr), this.self, ccllsn_GetCollisionBounds);
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x0002DE70 File Offset: 0x0002C070
		internal readonly void UseTriggerBounds(bool enable, float bloat)
		{
			this.NullCheck("UseTriggerBounds");
			method ccllsn_UseTriggerBounds = CollisionProperty.__N.CCllsn_UseTriggerBounds;
			calli(System.Void(System.IntPtr,System.Int32,System.Single), this.self, enable ? 1 : 0, bloat, ccllsn_UseTriggerBounds);
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x0002DEA4 File Offset: 0x0002C0A4
		internal readonly void SetSolid(SolidType type)
		{
			this.NullCheck("SetSolid");
			method ccllsn_SetSolid = CollisionProperty.__N.CCllsn_SetSolid;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (ulong)type, ccllsn_SetSolid);
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x0002DED0 File Offset: 0x0002C0D0
		internal readonly Vector3 OBBSize()
		{
			this.NullCheck("OBBSize");
			method ccllsn_OBBSize = CollisionProperty.__N.CCllsn_OBBSize;
			return calli(Vector3(System.IntPtr), this.self, ccllsn_OBBSize);
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x0002DEFC File Offset: 0x0002C0FC
		internal readonly Vector3 OBBCenter()
		{
			this.NullCheck("OBBCenter");
			method ccllsn_OBBCenter = CollisionProperty.__N.CCllsn_OBBCenter;
			return calli(Vector3(System.IntPtr), this.self, ccllsn_OBBCenter);
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x0002DF28 File Offset: 0x0002C128
		internal readonly Vector3 WorldSpaceCenter()
		{
			this.NullCheck("WorldSpaceCenter");
			method ccllsn_WorldSpaceCenter = CollisionProperty.__N.CCllsn_WorldSpaceCenter;
			return calli(Vector3(System.IntPtr), this.self, ccllsn_WorldSpaceCenter);
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x0002DF54 File Offset: 0x0002C154
		internal readonly float BoundingRadius()
		{
			this.NullCheck("BoundingRadius");
			method ccllsn_BoundingRadius = CollisionProperty.__N.CCllsn_BoundingRadius;
			return calli(System.Single(System.IntPtr), this.self, ccllsn_BoundingRadius);
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x0002DF80 File Offset: 0x0002C180
		internal readonly float BoundingRadius2D()
		{
			this.NullCheck("BoundingRadius2D");
			method ccllsn_BoundingRadius2D = CollisionProperty.__N.CCllsn_BoundingRadius2D;
			return calli(System.Single(System.IntPtr), this.self, ccllsn_BoundingRadius2D);
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x0002DFAC File Offset: 0x0002C1AC
		internal readonly void ClearSolidFlags()
		{
			this.NullCheck("ClearSolidFlags");
			method ccllsn_ClearSolidFlags = CollisionProperty.__N.CCllsn_ClearSolidFlags;
			calli(System.Void(System.IntPtr), this.self, ccllsn_ClearSolidFlags);
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x0002DFD8 File Offset: 0x0002C1D8
		internal readonly void RemoveSolidFlags(int flags)
		{
			this.NullCheck("RemoveSolidFlags");
			method ccllsn_RemoveSolidFlags = CollisionProperty.__N.CCllsn_RemoveSolidFlags;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flags, ccllsn_RemoveSolidFlags);
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x0002E004 File Offset: 0x0002C204
		internal readonly void AddSolidFlags(int flags)
		{
			this.NullCheck("AddSolidFlags");
			method ccllsn_AddSolidFlags = CollisionProperty.__N.CCllsn_AddSolidFlags;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flags, ccllsn_AddSolidFlags);
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x0002E030 File Offset: 0x0002C230
		internal readonly bool IsSolidFlagSet(int flags)
		{
			this.NullCheck("IsSolidFlagSet");
			method ccllsn_IsSolidFlagSet = CollisionProperty.__N.CCllsn_IsSolidFlagSet;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, flags, ccllsn_IsSolidFlagSet) > 0;
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x0002E060 File Offset: 0x0002C260
		internal readonly void SetSolidFlags(int flags)
		{
			this.NullCheck("SetSolidFlags");
			method ccllsn_SetSolidFlags = CollisionProperty.__N.CCllsn_SetSolidFlags;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flags, ccllsn_SetSolidFlags);
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x0002E08C File Offset: 0x0002C28C
		internal readonly bool IsSolid()
		{
			this.NullCheck("IsSolid");
			method ccllsn_IsSolid = CollisionProperty.__N.CCllsn_IsSolid;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_IsSolid) > 0;
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x0002E0BC File Offset: 0x0002C2BC
		internal readonly bool IsCollisionEnabled()
		{
			this.NullCheck("IsCollisionEnabled");
			method ccllsn_IsCollisionEnabled = CollisionProperty.__N.CCllsn_IsCollisionEnabled;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_IsCollisionEnabled) > 0;
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x0002E0EC File Offset: 0x0002C2EC
		internal readonly void SetTriggerCollisionGroup()
		{
			this.NullCheck("SetTriggerCollisionGroup");
			method ccllsn_SetTriggerCollisionGroup = CollisionProperty.__N.CCllsn_SetTriggerCollisionGroup;
			calli(System.Void(System.IntPtr), this.self, ccllsn_SetTriggerCollisionGroup);
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x0002E118 File Offset: 0x0002C318
		internal readonly void RemoveTriggerCollisionGroup()
		{
			this.NullCheck("RemoveTriggerCollisionGroup");
			method ccllsn_RemoveTriggerCollisionGroup = CollisionProperty.__N.CCllsn_RemoveTriggerCollisionGroup;
			calli(System.Void(System.IntPtr), this.self, ccllsn_RemoveTriggerCollisionGroup);
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x0002E144 File Offset: 0x0002C344
		internal readonly bool IsTriggerCollisionGroup()
		{
			this.NullCheck("IsTriggerCollisionGroup");
			method ccllsn_IsTriggerCollisionGroup = CollisionProperty.__N.CCllsn_IsTriggerCollisionGroup;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_IsTriggerCollisionGroup) > 0;
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x0002E174 File Offset: 0x0002C374
		internal readonly void ForceTouchTriggers()
		{
			this.NullCheck("ForceTouchTriggers");
			method ccllsn_ForceTouchTriggers = CollisionProperty.__N.CCllsn_ForceTouchTriggers;
			calli(System.Void(System.IntPtr), this.self, ccllsn_ForceTouchTriggers);
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x0002E1A0 File Offset: 0x0002C3A0
		internal readonly bool IsBoundsDefinedInEntitySpace()
		{
			this.NullCheck("IsBoundsDefinedInEntitySpace");
			method ccllsn_IsBoundsDefinedInEntitySpace = CollisionProperty.__N.CCllsn_IsBoundsDefinedInEntitySpace;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_IsBoundsDefinedInEntitySpace) > 0;
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x0002E1D0 File Offset: 0x0002C3D0
		internal readonly bool EnableAllCollisions()
		{
			this.NullCheck("EnableAllCollisions");
			method ccllsn_EnableAllCollisions = CollisionProperty.__N.CCllsn_EnableAllCollisions;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_EnableAllCollisions) > 0;
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0002E200 File Offset: 0x0002C400
		internal readonly bool DisableAllCollisions()
		{
			this.NullCheck("DisableAllCollisions");
			method ccllsn_DisableAllCollisions = CollisionProperty.__N.CCllsn_DisableAllCollisions;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_DisableAllCollisions) > 0;
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x0002E230 File Offset: 0x0002C430
		internal readonly bool EnableSolidCollisions()
		{
			this.NullCheck("EnableSolidCollisions");
			method ccllsn_EnableSolidCollisions = CollisionProperty.__N.CCllsn_EnableSolidCollisions;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_EnableSolidCollisions) > 0;
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x0002E260 File Offset: 0x0002C460
		internal readonly bool DisableSolidCollisions()
		{
			this.NullCheck("DisableSolidCollisions");
			method ccllsn_DisableSolidCollisions = CollisionProperty.__N.CCllsn_DisableSolidCollisions;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_DisableSolidCollisions) > 0;
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x0002E290 File Offset: 0x0002C490
		internal readonly bool IsSolidContactEnabled()
		{
			this.NullCheck("IsSolidContactEnabled");
			method ccllsn_IsSolidContactEnabled = CollisionProperty.__N.CCllsn_IsSolidContactEnabled;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_IsSolidContactEnabled) > 0;
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x0002E2C0 File Offset: 0x0002C4C0
		internal readonly bool EnableTouchEvents()
		{
			this.NullCheck("EnableTouchEvents");
			method ccllsn_EnableTouchEvents = CollisionProperty.__N.CCllsn_EnableTouchEvents;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_EnableTouchEvents) > 0;
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x0002E2F0 File Offset: 0x0002C4F0
		internal readonly bool DisableTouchEvents()
		{
			this.NullCheck("DisableTouchEvents");
			method ccllsn_DisableTouchEvents = CollisionProperty.__N.CCllsn_DisableTouchEvents;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_DisableTouchEvents) > 0;
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x0002E320 File Offset: 0x0002C520
		internal readonly bool EnableTraceAndQueries()
		{
			this.NullCheck("EnableTraceAndQueries");
			method ccllsn_EnableTraceAndQueries = CollisionProperty.__N.CCllsn_EnableTraceAndQueries;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_EnableTraceAndQueries) > 0;
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x0002E350 File Offset: 0x0002C550
		internal readonly bool DisableTraceAndQueries()
		{
			this.NullCheck("DisableTraceAndQueries");
			method ccllsn_DisableTraceAndQueries = CollisionProperty.__N.CCllsn_DisableTraceAndQueries;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_DisableTraceAndQueries) > 0;
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0002E380 File Offset: 0x0002C580
		internal readonly bool EnableSelfCollisions()
		{
			this.NullCheck("EnableSelfCollisions");
			method ccllsn_EnableSelfCollisions = CollisionProperty.__N.CCllsn_EnableSelfCollisions;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_EnableSelfCollisions) > 0;
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0002E3B0 File Offset: 0x0002C5B0
		internal readonly bool DisableSelfCollisions()
		{
			this.NullCheck("DisableSelfCollisions");
			method ccllsn_DisableSelfCollisions = CollisionProperty.__N.CCllsn_DisableSelfCollisions;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_DisableSelfCollisions) > 0;
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x0002E3E0 File Offset: 0x0002C5E0
		internal readonly bool EnableTouchPersistsNotification()
		{
			this.NullCheck("EnableTouchPersistsNotification");
			method ccllsn_EnableTouchPersistsNotification = CollisionProperty.__N.CCllsn_EnableTouchPersistsNotification;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_EnableTouchPersistsNotification) > 0;
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x0002E410 File Offset: 0x0002C610
		internal readonly bool DisableTouchPersistsNotification()
		{
			this.NullCheck("DisableTouchPersistsNotification");
			method ccllsn_DisableTouchPersistsNotification = CollisionProperty.__N.CCllsn_DisableTouchPersistsNotification;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_DisableTouchPersistsNotification) > 0;
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x0002E440 File Offset: 0x0002C640
		internal readonly void EnableHitboxes()
		{
			this.NullCheck("EnableHitboxes");
			method ccllsn_EnableHitboxes = CollisionProperty.__N.CCllsn_EnableHitboxes;
			calli(System.Void(System.IntPtr), this.self, ccllsn_EnableHitboxes);
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x0002E46C File Offset: 0x0002C66C
		internal readonly void DisableHitboxes()
		{
			this.NullCheck("DisableHitboxes");
			method ccllsn_DisableHitboxes = CollisionProperty.__N.CCllsn_DisableHitboxes;
			calli(System.Void(System.IntPtr), this.self, ccllsn_DisableHitboxes);
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x0002E498 File Offset: 0x0002C698
		internal readonly bool IsHitboxEnabled()
		{
			this.NullCheck("IsHitboxEnabled");
			method ccllsn_IsHitboxEnabled = CollisionProperty.__N.CCllsn_IsHitboxEnabled;
			return calli(System.Int32(System.IntPtr), this.self, ccllsn_IsHitboxEnabled) > 0;
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x0002E4C8 File Offset: 0x0002C6C8
		internal readonly void EnableAutoSleeping()
		{
			this.NullCheck("EnableAutoSleeping");
			method ccllsn_EnableAutoSleeping = CollisionProperty.__N.CCllsn_EnableAutoSleeping;
			calli(System.Void(System.IntPtr), this.self, ccllsn_EnableAutoSleeping);
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x0002E4F4 File Offset: 0x0002C6F4
		internal readonly void DisableAutoSleeping()
		{
			this.NullCheck("DisableAutoSleeping");
			method ccllsn_DisableAutoSleeping = CollisionProperty.__N.CCllsn_DisableAutoSleeping;
			calli(System.Void(System.IntPtr), this.self, ccllsn_DisableAutoSleeping);
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x0002E520 File Offset: 0x0002C720
		internal unsafe readonly PhysicsGroup SetupPhysicsFromUnscaledCapsule(PhysicsMotionType nMovement, int nCollisionGroup, Capsule capsule)
		{
			this.NullCheck("SetupPhysicsFromUnscaledCapsule");
			method ccllsn_SetupPhysicsFromUnscaledCapsule = CollisionProperty.__N.CCllsn_SetupPhysicsFromUnscaledCapsule;
			return HandleIndex.Get<PhysicsGroup>(calli(System.Int32(System.IntPtr,System.Int64,System.Int32,Capsule*), this.self, (long)nMovement, nCollisionGroup, &capsule, ccllsn_SetupPhysicsFromUnscaledCapsule));
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x0002E558 File Offset: 0x0002C758
		internal unsafe readonly PhysicsGroup SetupPhysicsFromUnscaledOrientedCapsule(PhysicsMotionType nMovement, int nCollisionGroup, Capsule capsule)
		{
			this.NullCheck("SetupPhysicsFromUnscaledOrientedCapsule");
			method ccllsn_SetupPhysicsFromUnscaledOrientedCapsule = CollisionProperty.__N.CCllsn_SetupPhysicsFromUnscaledOrientedCapsule;
			return HandleIndex.Get<PhysicsGroup>(calli(System.Int32(System.IntPtr,System.Int64,System.Int32,Capsule*), this.self, (long)nMovement, nCollisionGroup, &capsule, ccllsn_SetupPhysicsFromUnscaledOrientedCapsule));
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x0002E590 File Offset: 0x0002C790
		internal readonly PhysicsGroup SetupPhysicsFromUnscaledModel(PhysicsMotionType nMovement, int nCollisionGroup, bool bCreateAsleep)
		{
			this.NullCheck("SetupPhysicsFromUnscaledModel");
			method ccllsn_SetupPhysicsFromUnscaledModel = CollisionProperty.__N.CCllsn_SetupPhysicsFromUnscaledModel;
			return HandleIndex.Get<PhysicsGroup>(calli(System.Int32(System.IntPtr,System.Int64,System.Int32,System.Int32), this.self, (long)nMovement, nCollisionGroup, bCreateAsleep ? 1 : 0, ccllsn_SetupPhysicsFromUnscaledModel));
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x0002E5CC File Offset: 0x0002C7CC
		internal unsafe readonly PhysicsGroup SetupPhysicsFromUnscaledAABB(PhysicsMotionType m, int colgroup, Vector3 mins, Vector3 maxs)
		{
			this.NullCheck("SetupPhysicsFromUnscaledAABB");
			method ccllsn_SetupPhysicsFromUnscaledAABB = CollisionProperty.__N.CCllsn_SetupPhysicsFromUnscaledAABB;
			return HandleIndex.Get<PhysicsGroup>(calli(System.Int32(System.IntPtr,System.Int64,System.Int32,Vector3*,Vector3*), this.self, (long)m, colgroup, &mins, &maxs, ccllsn_SetupPhysicsFromUnscaledAABB));
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x0002E604 File Offset: 0x0002C804
		internal unsafe readonly PhysicsGroup SetupPhysicsFromUnscaledOBB(PhysicsMotionType m, int nCollisionGroup, Vector3 vMins, Vector3 vMaxs)
		{
			this.NullCheck("SetupPhysicsFromUnscaledOBB");
			method ccllsn_SetupPhysicsFromUnscaledOBB = CollisionProperty.__N.CCllsn_SetupPhysicsFromUnscaledOBB;
			return HandleIndex.Get<PhysicsGroup>(calli(System.Int32(System.IntPtr,System.Int64,System.Int32,Vector3*,Vector3*), this.self, (long)m, nCollisionGroup, &vMins, &vMaxs, ccllsn_SetupPhysicsFromUnscaledOBB));
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x0002E63C File Offset: 0x0002C83C
		internal unsafe readonly PhysicsGroup SetupPhysicsFromUnscaledSphere(PhysicsMotionType m, int nCollisionGroup, Vector3 center, float radius)
		{
			this.NullCheck("SetupPhysicsFromUnscaledSphere");
			method ccllsn_SetupPhysicsFromUnscaledSphere = CollisionProperty.__N.CCllsn_SetupPhysicsFromUnscaledSphere;
			return HandleIndex.Get<PhysicsGroup>(calli(System.Int32(System.IntPtr,System.Int64,System.Int32,Vector3*,System.Single), this.self, (long)m, nCollisionGroup, &center, radius, ccllsn_SetupPhysicsFromUnscaledSphere));
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x0002E674 File Offset: 0x0002C874
		internal readonly void EnableInteractsAsMask(ulong nLayerMask)
		{
			this.NullCheck("EnableInteractsAsMask");
			method ccllsn_EnableInteractsAsMask = CollisionProperty.__N.CCllsn_EnableInteractsAsMask;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nLayerMask, ccllsn_EnableInteractsAsMask);
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x0002E6A0 File Offset: 0x0002C8A0
		internal readonly void EnableInteractsWithMask(ulong nLayerMask)
		{
			this.NullCheck("EnableInteractsWithMask");
			method ccllsn_EnableInteractsWithMask = CollisionProperty.__N.CCllsn_EnableInteractsWithMask;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nLayerMask, ccllsn_EnableInteractsWithMask);
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x0002E6CC File Offset: 0x0002C8CC
		internal readonly void EnableInteractsExcludeMask(ulong nLayerMask)
		{
			this.NullCheck("EnableInteractsExcludeMask");
			method ccllsn_EnableInteractsExcludeMask = CollisionProperty.__N.CCllsn_EnableInteractsExcludeMask;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nLayerMask, ccllsn_EnableInteractsExcludeMask);
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x0002E6F8 File Offset: 0x0002C8F8
		internal readonly ulong GetInteractsAsMask()
		{
			this.NullCheck("GetInteractsAsMask");
			method ccllsn_GetInteractsAsMask = CollisionProperty.__N.CCllsn_GetInteractsAsMask;
			return calli(System.UInt64(System.IntPtr), this.self, ccllsn_GetInteractsAsMask);
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x0002E724 File Offset: 0x0002C924
		internal readonly ulong GetInteractsWithMask()
		{
			this.NullCheck("GetInteractsWithMask");
			method ccllsn_GetInteractsWithMask = CollisionProperty.__N.CCllsn_GetInteractsWithMask;
			return calli(System.UInt64(System.IntPtr), this.self, ccllsn_GetInteractsWithMask);
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x0002E750 File Offset: 0x0002C950
		internal readonly ulong GetInteractsExcludeMask()
		{
			this.NullCheck("GetInteractsExcludeMask");
			method ccllsn_GetInteractsExcludeMask = CollisionProperty.__N.CCllsn_GetInteractsExcludeMask;
			return calli(System.UInt64(System.IntPtr), this.self, ccllsn_GetInteractsExcludeMask);
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x0002E77C File Offset: 0x0002C97C
		internal readonly void DisableInteractsAsMask(ulong nLayerMask)
		{
			this.NullCheck("DisableInteractsAsMask");
			method ccllsn_DisableInteractsAsMask = CollisionProperty.__N.CCllsn_DisableInteractsAsMask;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nLayerMask, ccllsn_DisableInteractsAsMask);
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x0002E7A8 File Offset: 0x0002C9A8
		internal readonly void DisableInteractsWithMask(ulong nLayerMask)
		{
			this.NullCheck("DisableInteractsWithMask");
			method ccllsn_DisableInteractsWithMask = CollisionProperty.__N.CCllsn_DisableInteractsWithMask;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nLayerMask, ccllsn_DisableInteractsWithMask);
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x0002E7D4 File Offset: 0x0002C9D4
		internal readonly void DisableInteractsExcludeMask(ulong nLayerMask)
		{
			this.NullCheck("DisableInteractsExcludeMask");
			method ccllsn_DisableInteractsExcludeMask = CollisionProperty.__N.CCllsn_DisableInteractsExcludeMask;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nLayerMask, ccllsn_DisableInteractsExcludeMask);
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0002E800 File Offset: 0x0002CA00
		internal readonly void ClearInteractsAsMask()
		{
			this.NullCheck("ClearInteractsAsMask");
			method ccllsn_ClearInteractsAsMask = CollisionProperty.__N.CCllsn_ClearInteractsAsMask;
			calli(System.Void(System.IntPtr), this.self, ccllsn_ClearInteractsAsMask);
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x0002E82C File Offset: 0x0002CA2C
		internal readonly void ClearInteractsWithMask()
		{
			this.NullCheck("ClearInteractsWithMask");
			method ccllsn_ClearInteractsWithMask = CollisionProperty.__N.CCllsn_ClearInteractsWithMask;
			calli(System.Void(System.IntPtr), this.self, ccllsn_ClearInteractsWithMask);
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x0002E858 File Offset: 0x0002CA58
		internal readonly void ClearInteractsExcludeMask()
		{
			this.NullCheck("ClearInteractsExcludeMask");
			method ccllsn_ClearInteractsExcludeMask = CollisionProperty.__N.CCllsn_ClearInteractsExcludeMask;
			calli(System.Void(System.IntPtr), this.self, ccllsn_ClearInteractsExcludeMask);
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x0002E884 File Offset: 0x0002CA84
		internal readonly void SetSurroundingBoundsType(SurroundingBoundsType type)
		{
			this.NullCheck("SetSurroundingBoundsType");
			method ccllsn_SetSurroundingBoundsType = CollisionProperty.__N.CCllsn_SetSurroundingBoundsType;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (ulong)type, ccllsn_SetSurroundingBoundsType);
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0002E8B0 File Offset: 0x0002CAB0
		internal readonly SurroundingBoundsType GetSurroundingBoundsType()
		{
			this.NullCheck("GetSurroundingBoundsType");
			method ccllsn_GetSurroundingBoundsType = CollisionProperty.__N.CCllsn_GetSurroundingBoundsType;
			return calli(System.Int64(System.IntPtr), this.self, ccllsn_GetSurroundingBoundsType);
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x0002E8DC File Offset: 0x0002CADC
		internal readonly void MarkSurroundingBoundsDirty()
		{
			this.NullCheck("MarkSurroundingBoundsDirty");
			method ccllsn_MarkSurroundingBoundsDirty = CollisionProperty.__N.CCllsn_MarkSurroundingBoundsDirty;
			calli(System.Void(System.IntPtr), this.self, ccllsn_MarkSurroundingBoundsDirty);
		}

		// Token: 0x040000A5 RID: 165
		internal IntPtr self;

		// Token: 0x020001AE RID: 430
		internal static class __N
		{
			// Token: 0x04000BCB RID: 3019
			internal static method CCllsn_OBBMins;

			// Token: 0x04000BCC RID: 3020
			internal static method CCllsn_OBBMaxs;

			// Token: 0x04000BCD RID: 3021
			internal static method CCllsn_GetCollisionOrigin;

			// Token: 0x04000BCE RID: 3022
			internal static method CCllsn_GetCollisionAngles;

			// Token: 0x04000BCF RID: 3023
			internal static method CCllsn_GetCollisionScale;

			// Token: 0x04000BD0 RID: 3024
			internal static method CCllsn_GetSolid;

			// Token: 0x04000BD1 RID: 3025
			internal static method CCllsn_GetSolidFlags;

			// Token: 0x04000BD2 RID: 3026
			internal static method CCllsn_GetCollisionGroup;

			// Token: 0x04000BD3 RID: 3027
			internal static method CCllsn_GetVPhysicsBody;

			// Token: 0x04000BD4 RID: 3028
			internal static method CCllsn_SetCollisionGroup;

			// Token: 0x04000BD5 RID: 3029
			internal static method CCllsn_MarkPartitionHandleDirty;

			// Token: 0x04000BD6 RID: 3030
			internal static method CCllsn_SetCollisionBounds;

			// Token: 0x04000BD7 RID: 3031
			internal static method CCllsn_GetCollisionBounds;

			// Token: 0x04000BD8 RID: 3032
			internal static method CCllsn_UseTriggerBounds;

			// Token: 0x04000BD9 RID: 3033
			internal static method CCllsn_SetSolid;

			// Token: 0x04000BDA RID: 3034
			internal static method CCllsn_OBBSize;

			// Token: 0x04000BDB RID: 3035
			internal static method CCllsn_OBBCenter;

			// Token: 0x04000BDC RID: 3036
			internal static method CCllsn_WorldSpaceCenter;

			// Token: 0x04000BDD RID: 3037
			internal static method CCllsn_BoundingRadius;

			// Token: 0x04000BDE RID: 3038
			internal static method CCllsn_BoundingRadius2D;

			// Token: 0x04000BDF RID: 3039
			internal static method CCllsn_ClearSolidFlags;

			// Token: 0x04000BE0 RID: 3040
			internal static method CCllsn_RemoveSolidFlags;

			// Token: 0x04000BE1 RID: 3041
			internal static method CCllsn_AddSolidFlags;

			// Token: 0x04000BE2 RID: 3042
			internal static method CCllsn_IsSolidFlagSet;

			// Token: 0x04000BE3 RID: 3043
			internal static method CCllsn_SetSolidFlags;

			// Token: 0x04000BE4 RID: 3044
			internal static method CCllsn_IsSolid;

			// Token: 0x04000BE5 RID: 3045
			internal static method CCllsn_IsCollisionEnabled;

			// Token: 0x04000BE6 RID: 3046
			internal static method CCllsn_SetTriggerCollisionGroup;

			// Token: 0x04000BE7 RID: 3047
			internal static method CCllsn_RemoveTriggerCollisionGroup;

			// Token: 0x04000BE8 RID: 3048
			internal static method CCllsn_IsTriggerCollisionGroup;

			// Token: 0x04000BE9 RID: 3049
			internal static method CCllsn_ForceTouchTriggers;

			// Token: 0x04000BEA RID: 3050
			internal static method CCllsn_IsBoundsDefinedInEntitySpace;

			// Token: 0x04000BEB RID: 3051
			internal static method CCllsn_EnableAllCollisions;

			// Token: 0x04000BEC RID: 3052
			internal static method CCllsn_DisableAllCollisions;

			// Token: 0x04000BED RID: 3053
			internal static method CCllsn_EnableSolidCollisions;

			// Token: 0x04000BEE RID: 3054
			internal static method CCllsn_DisableSolidCollisions;

			// Token: 0x04000BEF RID: 3055
			internal static method CCllsn_IsSolidContactEnabled;

			// Token: 0x04000BF0 RID: 3056
			internal static method CCllsn_EnableTouchEvents;

			// Token: 0x04000BF1 RID: 3057
			internal static method CCllsn_DisableTouchEvents;

			// Token: 0x04000BF2 RID: 3058
			internal static method CCllsn_EnableTraceAndQueries;

			// Token: 0x04000BF3 RID: 3059
			internal static method CCllsn_DisableTraceAndQueries;

			// Token: 0x04000BF4 RID: 3060
			internal static method CCllsn_EnableSelfCollisions;

			// Token: 0x04000BF5 RID: 3061
			internal static method CCllsn_DisableSelfCollisions;

			// Token: 0x04000BF6 RID: 3062
			internal static method CCllsn_EnableTouchPersistsNotification;

			// Token: 0x04000BF7 RID: 3063
			internal static method CCllsn_DisableTouchPersistsNotification;

			// Token: 0x04000BF8 RID: 3064
			internal static method CCllsn_EnableHitboxes;

			// Token: 0x04000BF9 RID: 3065
			internal static method CCllsn_DisableHitboxes;

			// Token: 0x04000BFA RID: 3066
			internal static method CCllsn_IsHitboxEnabled;

			// Token: 0x04000BFB RID: 3067
			internal static method CCllsn_EnableAutoSleeping;

			// Token: 0x04000BFC RID: 3068
			internal static method CCllsn_DisableAutoSleeping;

			// Token: 0x04000BFD RID: 3069
			internal static method CCllsn_SetupPhysicsFromUnscaledCapsule;

			// Token: 0x04000BFE RID: 3070
			internal static method CCllsn_SetupPhysicsFromUnscaledOrientedCapsule;

			// Token: 0x04000BFF RID: 3071
			internal static method CCllsn_SetupPhysicsFromUnscaledModel;

			// Token: 0x04000C00 RID: 3072
			internal static method CCllsn_SetupPhysicsFromUnscaledAABB;

			// Token: 0x04000C01 RID: 3073
			internal static method CCllsn_SetupPhysicsFromUnscaledOBB;

			// Token: 0x04000C02 RID: 3074
			internal static method CCllsn_SetupPhysicsFromUnscaledSphere;

			// Token: 0x04000C03 RID: 3075
			internal static method CCllsn_EnableInteractsAsMask;

			// Token: 0x04000C04 RID: 3076
			internal static method CCllsn_EnableInteractsWithMask;

			// Token: 0x04000C05 RID: 3077
			internal static method CCllsn_EnableInteractsExcludeMask;

			// Token: 0x04000C06 RID: 3078
			internal static method CCllsn_GetInteractsAsMask;

			// Token: 0x04000C07 RID: 3079
			internal static method CCllsn_GetInteractsWithMask;

			// Token: 0x04000C08 RID: 3080
			internal static method CCllsn_GetInteractsExcludeMask;

			// Token: 0x04000C09 RID: 3081
			internal static method CCllsn_DisableInteractsAsMask;

			// Token: 0x04000C0A RID: 3082
			internal static method CCllsn_DisableInteractsWithMask;

			// Token: 0x04000C0B RID: 3083
			internal static method CCllsn_DisableInteractsExcludeMask;

			// Token: 0x04000C0C RID: 3084
			internal static method CCllsn_ClearInteractsAsMask;

			// Token: 0x04000C0D RID: 3085
			internal static method CCllsn_ClearInteractsWithMask;

			// Token: 0x04000C0E RID: 3086
			internal static method CCllsn_ClearInteractsExcludeMask;

			// Token: 0x04000C0F RID: 3087
			internal static method CCllsn_SetSurroundingBoundsType;

			// Token: 0x04000C10 RID: 3088
			internal static method CCllsn_GetSurroundingBoundsType;

			// Token: 0x04000C11 RID: 3089
			internal static method CCllsn_MarkSurroundingBoundsDirty;
		}
	}
}
