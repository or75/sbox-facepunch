using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200004F RID: 79
	internal struct IPhysicsBody
	{
		// Token: 0x06000A8D RID: 2701 RVA: 0x00039E6B File Offset: 0x0003806B
		public static implicit operator IntPtr(IPhysicsBody value)
		{
			return value.self;
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x00039E74 File Offset: 0x00038074
		public static implicit operator IPhysicsBody(IntPtr value)
		{
			return new IPhysicsBody
			{
				self = value
			};
		}

		// Token: 0x06000A8F RID: 2703 RVA: 0x00039E92 File Offset: 0x00038092
		public static bool operator ==(IPhysicsBody c1, IPhysicsBody c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x00039EA5 File Offset: 0x000380A5
		public static bool operator !=(IPhysicsBody c1, IPhysicsBody c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x00039EB8 File Offset: 0x000380B8
		public override bool Equals(object obj)
		{
			if (obj is IPhysicsBody)
			{
				IPhysicsBody c = (IPhysicsBody)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x00039EE2 File Offset: 0x000380E2
		internal IPhysicsBody(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x00039EEC File Offset: 0x000380EC
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
			defaultInterpolatedStringHandler.AppendLiteral("IPhysicsBody ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000A94 RID: 2708 RVA: 0x00039F28 File Offset: 0x00038128
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000A95 RID: 2709 RVA: 0x00039F3A File Offset: 0x0003813A
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x00039F45 File Offset: 0x00038145
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x00039F58 File Offset: 0x00038158
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("IPhysicsBody was null when calling " + n);
			}
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x00039F73 File Offset: 0x00038173
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x00039F80 File Offset: 0x00038180
		internal readonly float GetSurfaceArea()
		{
			this.NullCheck("GetSurfaceArea");
			method iphysc_GetSurfaceArea = IPhysicsBody.__N.IPhysc_GetSurfaceArea;
			return calli(System.Single(System.IntPtr), this.self, iphysc_GetSurfaceArea);
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x00039FAC File Offset: 0x000381AC
		internal readonly void SetGravityScale(float f)
		{
			this.NullCheck("SetGravityScale");
			method iphysc_SetGravityScale = IPhysicsBody.__N.IPhysc_SetGravityScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, f, iphysc_SetGravityScale);
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x00039FD8 File Offset: 0x000381D8
		internal readonly float GetGravityScale()
		{
			this.NullCheck("GetGravityScale");
			method iphysc_GetGravityScale = IPhysicsBody.__N.IPhysc_GetGravityScale;
			return calli(System.Single(System.IntPtr), this.self, iphysc_GetGravityScale);
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x0003A004 File Offset: 0x00038204
		internal readonly bool IsGravityEnabled()
		{
			this.NullCheck("IsGravityEnabled");
			method iphysc_IsGravityEnabled = IPhysicsBody.__N.IPhysc_IsGravityEnabled;
			return calli(System.Int32(System.IntPtr), this.self, iphysc_IsGravityEnabled) > 0;
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x0003A034 File Offset: 0x00038234
		internal readonly void EnableGravity(bool value)
		{
			this.NullCheck("EnableGravity");
			method iphysc_EnableGravity = IPhysicsBody.__N.IPhysc_EnableGravity;
			calli(System.Void(System.IntPtr,System.Int32), this.self, value ? 1 : 0, iphysc_EnableGravity);
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x0003A068 File Offset: 0x00038268
		internal readonly void SetMass(float f)
		{
			this.NullCheck("SetMass");
			method iphysc_SetMass = IPhysicsBody.__N.IPhysc_SetMass;
			calli(System.Void(System.IntPtr,System.Single), this.self, f, iphysc_SetMass);
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x0003A094 File Offset: 0x00038294
		internal readonly float GetMass()
		{
			this.NullCheck("GetMass");
			method iphysc_GetMass = IPhysicsBody.__N.IPhysc_GetMass;
			return calli(System.Single(System.IntPtr), this.self, iphysc_GetMass);
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x0003A0C0 File Offset: 0x000382C0
		internal readonly float GetPhysicalMassInv()
		{
			this.NullCheck("GetPhysicalMassInv");
			method iphysc_GetPhysicalMassInv = IPhysicsBody.__N.IPhysc_GetPhysicalMassInv;
			return calli(System.Single(System.IntPtr), this.self, iphysc_GetPhysicalMassInv);
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x0003A0EC File Offset: 0x000382EC
		internal readonly Vector3 GetMassCenter()
		{
			this.NullCheck("GetMassCenter");
			method iphysc_GetMassCenter = IPhysicsBody.__N.IPhysc_GetMassCenter;
			return calli(Vector3(System.IntPtr), this.self, iphysc_GetMassCenter);
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x0003A118 File Offset: 0x00038318
		internal readonly Vector3 GetLocalMassCenter()
		{
			this.NullCheck("GetLocalMassCenter");
			method iphysc_GetLocalMassCenter = IPhysicsBody.__N.IPhysc_GetLocalMassCenter;
			return calli(Vector3(System.IntPtr), this.self, iphysc_GetLocalMassCenter);
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x0003A144 File Offset: 0x00038344
		internal unsafe readonly void OverrideMassCenter(Vector3 v)
		{
			this.NullCheck("OverrideMassCenter");
			method iphysc_OverrideMassCenter = IPhysicsBody.__N.IPhysc_OverrideMassCenter;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, iphysc_OverrideMassCenter);
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x0003A174 File Offset: 0x00038374
		internal unsafe readonly void SetPosition(Vector3 v)
		{
			this.NullCheck("SetPosition");
			method iphysc_SetPosition = IPhysicsBody.__N.IPhysc_SetPosition;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, iphysc_SetPosition);
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x0003A1A4 File Offset: 0x000383A4
		internal readonly Vector3 GetPosition()
		{
			this.NullCheck("GetPosition");
			method iphysc_GetPosition = IPhysicsBody.__N.IPhysc_GetPosition;
			return calli(Vector3(System.IntPtr), this.self, iphysc_GetPosition);
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x0003A1D0 File Offset: 0x000383D0
		internal unsafe readonly void SetOrientation(Rotation q)
		{
			this.NullCheck("SetOrientation");
			method iphysc_SetOrientation = IPhysicsBody.__N.IPhysc_SetOrientation;
			calli(System.Void(System.IntPtr,Rotation*), this.self, &q, iphysc_SetOrientation);
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x0003A200 File Offset: 0x00038400
		internal readonly Rotation GetOrientation()
		{
			this.NullCheck("GetOrientation");
			method iphysc_GetOrientation = IPhysicsBody.__N.IPhysc_GetOrientation;
			return calli(Rotation(System.IntPtr), this.self, iphysc_GetOrientation);
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x0003A22C File Offset: 0x0003842C
		internal unsafe readonly void SetTransform(Vector3 v, Rotation q)
		{
			this.NullCheck("SetTransform");
			method iphysc_SetTransform = IPhysicsBody.__N.IPhysc_SetTransform;
			calli(System.Void(System.IntPtr,Vector3*,Rotation*), this.self, &v, &q, iphysc_SetTransform);
		}

		// Token: 0x06000AA9 RID: 2729 RVA: 0x0003A25C File Offset: 0x0003845C
		internal readonly Transform GetCTransform()
		{
			this.NullCheck("GetCTransform");
			method iphysc_GetCTransform = IPhysicsBody.__N.IPhysc_GetCTransform;
			return calli(Transform(System.IntPtr), this.self, iphysc_GetCTransform);
		}

		// Token: 0x06000AAA RID: 2730 RVA: 0x0003A288 File Offset: 0x00038488
		internal readonly float GetScale()
		{
			this.NullCheck("GetScale");
			method iphysc_GetScale = IPhysicsBody.__N.IPhysc_GetScale;
			return calli(System.Single(System.IntPtr), this.self, iphysc_GetScale);
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x0003A2B4 File Offset: 0x000384B4
		internal unsafe readonly void SetLinearVelocity(Vector3 v)
		{
			this.NullCheck("SetLinearVelocity");
			method iphysc_SetLinearVelocity = IPhysicsBody.__N.IPhysc_SetLinearVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, iphysc_SetLinearVelocity);
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x0003A2E4 File Offset: 0x000384E4
		internal readonly Vector3 GetLinearVelocity()
		{
			this.NullCheck("GetLinearVelocity");
			method iphysc_GetLinearVelocity = IPhysicsBody.__N.IPhysc_GetLinearVelocity;
			return calli(Vector3(System.IntPtr), this.self, iphysc_GetLinearVelocity);
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x0003A310 File Offset: 0x00038510
		internal unsafe readonly Vector3 GetVelocityAtPoint(Vector3 v)
		{
			this.NullCheck("GetVelocityAtPoint");
			method iphysc_GetVelocityAtPoint = IPhysicsBody.__N.IPhysc_GetVelocityAtPoint;
			return calli(Vector3(System.IntPtr,Vector3*), this.self, &v, iphysc_GetVelocityAtPoint);
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x0003A340 File Offset: 0x00038540
		internal unsafe readonly void AddLinearVelocity(Vector3 v)
		{
			this.NullCheck("AddLinearVelocity");
			method iphysc_AddLinearVelocity = IPhysicsBody.__N.IPhysc_AddLinearVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, iphysc_AddLinearVelocity);
		}

		// Token: 0x06000AAF RID: 2735 RVA: 0x0003A370 File Offset: 0x00038570
		internal unsafe readonly void SetAngularVelocity(Vector3 v)
		{
			this.NullCheck("SetAngularVelocity");
			method iphysc_SetAngularVelocity = IPhysicsBody.__N.IPhysc_SetAngularVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, iphysc_SetAngularVelocity);
		}

		// Token: 0x06000AB0 RID: 2736 RVA: 0x0003A3A0 File Offset: 0x000385A0
		internal readonly Vector3 GetAngularVelocity()
		{
			this.NullCheck("GetAngularVelocity");
			method iphysc_GetAngularVelocity = IPhysicsBody.__N.IPhysc_GetAngularVelocity;
			return calli(Vector3(System.IntPtr), this.self, iphysc_GetAngularVelocity);
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x0003A3CC File Offset: 0x000385CC
		internal readonly void Wake()
		{
			this.NullCheck("Wake");
			method iphysc_Wake = IPhysicsBody.__N.IPhysc_Wake;
			calli(System.Void(System.IntPtr), this.self, iphysc_Wake);
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x0003A3F8 File Offset: 0x000385F8
		internal readonly void Sleep()
		{
			this.NullCheck("Sleep");
			method iphysc_Sleep = IPhysicsBody.__N.IPhysc_Sleep;
			calli(System.Void(System.IntPtr), this.self, iphysc_Sleep);
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x0003A424 File Offset: 0x00038624
		internal readonly bool IsSleeping()
		{
			this.NullCheck("IsSleeping");
			method iphysc_IsSleeping = IPhysicsBody.__N.IPhysc_IsSleeping;
			return calli(System.Int32(System.IntPtr), this.self, iphysc_IsSleeping) > 0;
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x0003A454 File Offset: 0x00038654
		internal readonly void EnableAutoSleeping()
		{
			this.NullCheck("EnableAutoSleeping");
			method iphysc_EnableAutoSleeping = IPhysicsBody.__N.IPhysc_EnableAutoSleeping;
			calli(System.Void(System.IntPtr), this.self, iphysc_EnableAutoSleeping);
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x0003A480 File Offset: 0x00038680
		internal readonly void DisableAutoSleeping()
		{
			this.NullCheck("DisableAutoSleeping");
			method iphysc_DisableAutoSleeping = IPhysicsBody.__N.IPhysc_DisableAutoSleeping;
			calli(System.Void(System.IntPtr), this.self, iphysc_DisableAutoSleeping);
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x0003A4AC File Offset: 0x000386AC
		internal readonly void RemoveShadowController()
		{
			this.NullCheck("RemoveShadowController");
			method iphysc_RemoveShadowController = IPhysicsBody.__N.IPhysc_RemoveShadowController;
			calli(System.Void(System.IntPtr), this.self, iphysc_RemoveShadowController);
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x0003A4D8 File Offset: 0x000386D8
		internal readonly void EnableTouchEvents()
		{
			this.NullCheck("EnableTouchEvents");
			method iphysc_EnableTouchEvents = IPhysicsBody.__N.IPhysc_EnableTouchEvents;
			calli(System.Void(System.IntPtr), this.self, iphysc_EnableTouchEvents);
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x0003A504 File Offset: 0x00038704
		internal readonly void DisableTouchEvents()
		{
			this.NullCheck("DisableTouchEvents");
			method iphysc_DisableTouchEvents = IPhysicsBody.__N.IPhysc_DisableTouchEvents;
			calli(System.Void(System.IntPtr), this.self, iphysc_DisableTouchEvents);
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x0003A530 File Offset: 0x00038730
		internal readonly bool IsTouchEventEnabled()
		{
			this.NullCheck("IsTouchEventEnabled");
			method iphysc_IsTouchEventEnabled = IPhysicsBody.__N.IPhysc_IsTouchEventEnabled;
			return calli(System.Int32(System.IntPtr), this.self, iphysc_IsTouchEventEnabled) > 0;
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x0003A560 File Offset: 0x00038760
		internal readonly PhysicsBodyType GetType_Native()
		{
			this.NullCheck("GetType_Native");
			method iphysc_GetType = IPhysicsBody.__N.IPhysc_GetType;
			return calli(System.Int64(System.IntPtr), this.self, iphysc_GetType);
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x0003A58C File Offset: 0x0003878C
		internal readonly void SetType(PhysicsBodyType type)
		{
			this.NullCheck("SetType");
			method iphysc_SetType = IPhysicsBody.__N.IPhysc_SetType;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, iphysc_SetType);
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x0003A5B8 File Offset: 0x000387B8
		internal readonly int GetShapeCount()
		{
			this.NullCheck("GetShapeCount");
			method iphysc_GetShapeCount = IPhysicsBody.__N.IPhysc_GetShapeCount;
			return calli(System.Int32(System.IntPtr), this.self, iphysc_GetShapeCount);
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x0003A5E4 File Offset: 0x000387E4
		internal readonly PhysicsShape GetShape(int nShape)
		{
			this.NullCheck("GetShape");
			method iphysc_GetShape = IPhysicsBody.__N.IPhysc_GetShape;
			return HandleIndex.Get<PhysicsShape>(calli(System.Int32(System.IntPtr,System.Int32), this.self, nShape, iphysc_GetShape));
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x0003A614 File Offset: 0x00038814
		internal readonly int GetShapeIndex(PhysicsShape pShape)
		{
			this.NullCheck("GetShapeIndex");
			method iphysc_GetShapeIndex = IPhysicsBody.__N.IPhysc_GetShapeIndex;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, (pShape == null) ? IntPtr.Zero : pShape.native, iphysc_GetShapeIndex);
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x0003A654 File Offset: 0x00038854
		internal unsafe readonly PhysicsShape AddSphereShape(Vector3 vCenter, float flRadius, bool bRebuildMass)
		{
			this.NullCheck("AddSphereShape");
			method iphysc_AddSphereShape = IPhysicsBody.__N.IPhysc_AddSphereShape;
			return HandleIndex.Get<PhysicsShape>(calli(System.Int32(System.IntPtr,Vector3*,System.Single,System.Int32), this.self, &vCenter, flRadius, bRebuildMass ? 1 : 0, iphysc_AddSphereShape));
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x0003A690 File Offset: 0x00038890
		internal unsafe readonly PhysicsShape AddCapsuleShape(Vector3 vCenter1, Vector3 vCenter2, float flRadius, bool bRebuildMass)
		{
			this.NullCheck("AddCapsuleShape");
			method iphysc_AddCapsuleShape = IPhysicsBody.__N.IPhysc_AddCapsuleShape;
			return HandleIndex.Get<PhysicsShape>(calli(System.Int32(System.IntPtr,Vector3*,Vector3*,System.Single,System.Int32), this.self, &vCenter1, &vCenter2, flRadius, bRebuildMass ? 1 : 0, iphysc_AddCapsuleShape));
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x0003A6D0 File Offset: 0x000388D0
		internal readonly PhysicsShape AddCloneShape(PhysicsShape pShape)
		{
			this.NullCheck("AddCloneShape");
			method iphysc_AddCloneShape = IPhysicsBody.__N.IPhysc_AddCloneShape;
			return HandleIndex.Get<PhysicsShape>(calli(System.Int32(System.IntPtr,System.IntPtr), this.self, (pShape == null) ? IntPtr.Zero : pShape.native, iphysc_AddCloneShape));
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x0003A714 File Offset: 0x00038914
		internal readonly void RemoveShape(PhysicsShape pShape)
		{
			this.NullCheck("RemoveShape");
			method iphysc_RemoveShape = IPhysicsBody.__N.IPhysc_RemoveShape;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, (pShape == null) ? IntPtr.Zero : pShape.native, iphysc_RemoveShape);
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x0003A754 File Offset: 0x00038954
		internal readonly void PurgeShapes()
		{
			this.NullCheck("PurgeShapes");
			method iphysc_PurgeShapes = IPhysicsBody.__N.IPhysc_PurgeShapes;
			calli(System.Void(System.IntPtr), this.self, iphysc_PurgeShapes);
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x0003A780 File Offset: 0x00038980
		internal unsafe readonly Vector3 TransformVectorToLocal(Vector3 v)
		{
			this.NullCheck("TransformVectorToLocal");
			method iphysc_TransformVectorToLocal = IPhysicsBody.__N.IPhysc_TransformVectorToLocal;
			return calli(Vector3(System.IntPtr,Vector3*), this.self, &v, iphysc_TransformVectorToLocal);
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x0003A7B0 File Offset: 0x000389B0
		internal unsafe readonly Vector3 TransformVectorToWorld(Vector3 v)
		{
			this.NullCheck("TransformVectorToWorld");
			method iphysc_TransformVectorToWorld = IPhysicsBody.__N.IPhysc_TransformVectorToWorld;
			return calli(Vector3(System.IntPtr,Vector3*), this.self, &v, iphysc_TransformVectorToWorld);
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x0003A7E0 File Offset: 0x000389E0
		internal unsafe readonly Vector3 TransformPointToLocal(Vector3 p)
		{
			this.NullCheck("TransformPointToLocal");
			method iphysc_TransformPointToLocal = IPhysicsBody.__N.IPhysc_TransformPointToLocal;
			return calli(Vector3(System.IntPtr,Vector3*), this.self, &p, iphysc_TransformPointToLocal);
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x0003A810 File Offset: 0x00038A10
		internal unsafe readonly Vector3 TransformPointToWorld(Vector3 p)
		{
			this.NullCheck("TransformPointToWorld");
			method iphysc_TransformPointToWorld = IPhysicsBody.__N.IPhysc_TransformPointToWorld;
			return calli(Vector3(System.IntPtr,Vector3*), this.self, &p, iphysc_TransformPointToWorld);
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x0003A840 File Offset: 0x00038A40
		internal unsafe readonly Rotation TransformOrientationToLocal(Rotation q)
		{
			this.NullCheck("TransformOrientationToLocal");
			method iphysc_TransformOrientationToLocal = IPhysicsBody.__N.IPhysc_TransformOrientationToLocal;
			return calli(Rotation(System.IntPtr,Rotation*), this.self, &q, iphysc_TransformOrientationToLocal);
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x0003A870 File Offset: 0x00038A70
		internal unsafe readonly Rotation TransformOrientationToWorld(Rotation q)
		{
			this.NullCheck("TransformOrientationToWorld");
			method iphysc_TransformOrientationToWorld = IPhysicsBody.__N.IPhysc_TransformOrientationToWorld;
			return calli(Rotation(System.IntPtr,Rotation*), this.self, &q, iphysc_TransformOrientationToWorld);
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x0003A8A0 File Offset: 0x00038AA0
		internal unsafe readonly void ApplyLinearImpulse(Vector3 impulse)
		{
			this.NullCheck("ApplyLinearImpulse");
			method iphysc_ApplyLinearImpulse = IPhysicsBody.__N.IPhysc_ApplyLinearImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &impulse, iphysc_ApplyLinearImpulse);
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x0003A8D0 File Offset: 0x00038AD0
		internal unsafe readonly void ApplyLinearImpulseAtWorldSpace(Vector3 impulse, Vector3 pos)
		{
			this.NullCheck("ApplyLinearImpulseAtWorldSpace");
			method iphysc_ApplyLinearImpulseAtWorldSpace = IPhysicsBody.__N.IPhysc_ApplyLinearImpulseAtWorldSpace;
			calli(System.Void(System.IntPtr,Vector3*,Vector3*), this.self, &impulse, &pos, iphysc_ApplyLinearImpulseAtWorldSpace);
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x0003A900 File Offset: 0x00038B00
		internal unsafe readonly void ApplyAngularImpulse(Vector3 impulse)
		{
			this.NullCheck("ApplyAngularImpulse");
			method iphysc_ApplyAngularImpulse = IPhysicsBody.__N.IPhysc_ApplyAngularImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &impulse, iphysc_ApplyAngularImpulse);
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x0003A930 File Offset: 0x00038B30
		internal unsafe readonly void ApplyForce(Vector3 F)
		{
			this.NullCheck("ApplyForce");
			method iphysc_ApplyForce = IPhysicsBody.__N.IPhysc_ApplyForce;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &F, iphysc_ApplyForce);
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x0003A960 File Offset: 0x00038B60
		internal unsafe readonly void ApplyForceAt(Vector3 F, Vector3 r)
		{
			this.NullCheck("ApplyForceAt");
			method iphysc_ApplyForceAt = IPhysicsBody.__N.IPhysc_ApplyForceAt;
			calli(System.Void(System.IntPtr,Vector3*,Vector3*), this.self, &F, &r, iphysc_ApplyForceAt);
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x0003A990 File Offset: 0x00038B90
		internal unsafe readonly void ApplyTorque(Vector3 M)
		{
			this.NullCheck("ApplyTorque");
			method iphysc_ApplyTorque = IPhysicsBody.__N.IPhysc_ApplyTorque;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &M, iphysc_ApplyTorque);
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x0003A9C0 File Offset: 0x00038BC0
		internal readonly void ClearForces()
		{
			this.NullCheck("ClearForces");
			method iphysc_ClearForces = IPhysicsBody.__N.IPhysc_ClearForces;
			calli(System.Void(System.IntPtr), this.self, iphysc_ClearForces);
		}

		// Token: 0x06000AD1 RID: 2769 RVA: 0x0003A9EC File Offset: 0x00038BEC
		internal readonly void ClearTorques()
		{
			this.NullCheck("ClearTorques");
			method iphysc_ClearTorques = IPhysicsBody.__N.IPhysc_ClearTorques;
			calli(System.Void(System.IntPtr), this.self, iphysc_ClearTorques);
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x0003AA18 File Offset: 0x00038C18
		internal readonly void Enable()
		{
			this.NullCheck("Enable");
			method iphysc_Enable = IPhysicsBody.__N.IPhysc_Enable;
			calli(System.Void(System.IntPtr), this.self, iphysc_Enable);
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x0003AA44 File Offset: 0x00038C44
		internal readonly void Disable()
		{
			this.NullCheck("Disable");
			method iphysc_Disable = IPhysicsBody.__N.IPhysc_Disable;
			calli(System.Void(System.IntPtr), this.self, iphysc_Disable);
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x0003AA70 File Offset: 0x00038C70
		internal readonly bool IsEnabled()
		{
			this.NullCheck("IsEnabled");
			method iphysc_IsEnabled = IPhysicsBody.__N.IPhysc_IsEnabled;
			return calli(System.Int32(System.IntPtr), this.self, iphysc_IsEnabled) > 0;
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x0003AAA0 File Offset: 0x00038CA0
		internal readonly bool IsCollisionEnabled()
		{
			this.NullCheck("IsCollisionEnabled");
			method iphysc_IsCollisionEnabled = IPhysicsBody.__N.IPhysc_IsCollisionEnabled;
			return calli(System.Int32(System.IntPtr), this.self, iphysc_IsCollisionEnabled) > 0;
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x0003AAD0 File Offset: 0x00038CD0
		internal readonly bool IsMotionEnabled()
		{
			this.NullCheck("IsMotionEnabled");
			method iphysc_IsMotionEnabled = IPhysicsBody.__N.IPhysc_IsMotionEnabled;
			return calli(System.Int32(System.IntPtr), this.self, iphysc_IsMotionEnabled) > 0;
		}

		// Token: 0x06000AD7 RID: 2775 RVA: 0x0003AB00 File Offset: 0x00038D00
		internal readonly bool IsMoveable()
		{
			this.NullCheck("IsMoveable");
			method iphysc_IsMoveable = IPhysicsBody.__N.IPhysc_IsMoveable;
			return calli(System.Int32(System.IntPtr), this.self, iphysc_IsMoveable) > 0;
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x0003AB30 File Offset: 0x00038D30
		internal readonly void EnableMotion(bool bEnable)
		{
			this.NullCheck("EnableMotion");
			method iphysc_EnableMotion = IPhysicsBody.__N.IPhysc_EnableMotion;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnable ? 1 : 0, iphysc_EnableMotion);
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x0003AB64 File Offset: 0x00038D64
		internal readonly void EnableCollisions(bool bEnable)
		{
			this.NullCheck("EnableCollisions");
			method iphysc_EnableCollisions = IPhysicsBody.__N.IPhysc_EnableCollisions;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnable ? 1 : 0, iphysc_EnableCollisions);
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x0003AB98 File Offset: 0x00038D98
		internal readonly void SetMinSolverIterations(int nMinVelocityIterations, int nMinPositionIterations)
		{
			this.NullCheck("SetMinSolverIterations");
			method iphysc_SetMinSolverIterations = IPhysicsBody.__N.IPhysc_SetMinSolverIterations;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32), this.self, nMinVelocityIterations, nMinPositionIterations, iphysc_SetMinSolverIterations);
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x0003ABC4 File Offset: 0x00038DC4
		internal readonly void BuildMass()
		{
			this.NullCheck("BuildMass");
			method iphysc_BuildMass = IPhysicsBody.__N.IPhysc_BuildMass;
			calli(System.Void(System.IntPtr), this.self, iphysc_BuildMass);
		}

		// Token: 0x06000ADC RID: 2780 RVA: 0x0003ABF0 File Offset: 0x00038DF0
		internal readonly void SetLinearDamping(float d)
		{
			this.NullCheck("SetLinearDamping");
			method iphysc_SetLinearDamping = IPhysicsBody.__N.IPhysc_SetLinearDamping;
			calli(System.Void(System.IntPtr,System.Single), this.self, d, iphysc_SetLinearDamping);
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x0003AC1C File Offset: 0x00038E1C
		internal readonly float GetLinearDamping()
		{
			this.NullCheck("GetLinearDamping");
			method iphysc_GetLinearDamping = IPhysicsBody.__N.IPhysc_GetLinearDamping;
			return calli(System.Single(System.IntPtr), this.self, iphysc_GetLinearDamping);
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x0003AC48 File Offset: 0x00038E48
		internal readonly void SetAngularDamping(float d)
		{
			this.NullCheck("SetAngularDamping");
			method iphysc_SetAngularDamping = IPhysicsBody.__N.IPhysc_SetAngularDamping;
			calli(System.Void(System.IntPtr,System.Single), this.self, d, iphysc_SetAngularDamping);
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x0003AC74 File Offset: 0x00038E74
		internal readonly float GetAngularDamping()
		{
			this.NullCheck("GetAngularDamping");
			method iphysc_GetAngularDamping = IPhysicsBody.__N.IPhysc_GetAngularDamping;
			return calli(System.Single(System.IntPtr), this.self, iphysc_GetAngularDamping);
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x0003ACA0 File Offset: 0x00038EA0
		internal readonly void EnableDrag(bool bEnable)
		{
			this.NullCheck("EnableDrag");
			method iphysc_EnableDrag = IPhysicsBody.__N.IPhysc_EnableDrag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnable ? 1 : 0, iphysc_EnableDrag);
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x0003ACD4 File Offset: 0x00038ED4
		internal readonly bool IsDragEnabled()
		{
			this.NullCheck("IsDragEnabled");
			method iphysc_IsDragEnabled = IPhysicsBody.__N.IPhysc_IsDragEnabled;
			return calli(System.Int32(System.IntPtr), this.self, iphysc_IsDragEnabled) > 0;
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x0003AD04 File Offset: 0x00038F04
		internal readonly void SetLinearDrag(float flLinearDrag)
		{
			this.NullCheck("SetLinearDrag");
			method iphysc_SetLinearDrag = IPhysicsBody.__N.IPhysc_SetLinearDrag;
			calli(System.Void(System.IntPtr,System.Single), this.self, flLinearDrag, iphysc_SetLinearDrag);
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x0003AD30 File Offset: 0x00038F30
		internal readonly float GetLinearDrag()
		{
			this.NullCheck("GetLinearDrag");
			method iphysc_GetLinearDrag = IPhysicsBody.__N.IPhysc_GetLinearDrag;
			return calli(System.Single(System.IntPtr), this.self, iphysc_GetLinearDrag);
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x0003AD5C File Offset: 0x00038F5C
		internal readonly void SetAngularDrag(float flAngularDrag)
		{
			this.NullCheck("SetAngularDrag");
			method iphysc_SetAngularDrag = IPhysicsBody.__N.IPhysc_SetAngularDrag;
			calli(System.Void(System.IntPtr,System.Single), this.self, flAngularDrag, iphysc_SetAngularDrag);
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x0003AD88 File Offset: 0x00038F88
		internal readonly float GetAngularDrag()
		{
			this.NullCheck("GetAngularDrag");
			method iphysc_GetAngularDrag = IPhysicsBody.__N.IPhysc_GetAngularDrag;
			return calli(System.Single(System.IntPtr), this.self, iphysc_GetAngularDrag);
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x0003ADB4 File Offset: 0x00038FB4
		internal readonly void RecomputeDragBases()
		{
			this.NullCheck("RecomputeDragBases");
			method iphysc_RecomputeDragBases = IPhysicsBody.__N.IPhysc_RecomputeDragBases;
			calli(System.Void(System.IntPtr), this.self, iphysc_RecomputeDragBases);
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x0003ADE0 File Offset: 0x00038FE0
		internal readonly BBox BuildBounds()
		{
			this.NullCheck("BuildBounds");
			method iphysc_BuildBounds = IPhysicsBody.__N.IPhysc_BuildBounds;
			return calli(BBox(System.IntPtr), this.self, iphysc_BuildBounds);
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x0003AE0C File Offset: 0x0003900C
		internal readonly float GetDensity()
		{
			this.NullCheck("GetDensity");
			method iphysc_GetDensity = IPhysicsBody.__N.IPhysc_GetDensity;
			return calli(System.Single(System.IntPtr), this.self, iphysc_GetDensity);
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x0003AE38 File Offset: 0x00039038
		internal unsafe readonly Vector3 FindClosestPointOnConvexShapes(Vector3 vec)
		{
			this.NullCheck("FindClosestPointOnConvexShapes");
			method iphysc_FindClosestPointOnConvexShapes = IPhysicsBody.__N.IPhysc_FindClosestPointOnConvexShapes;
			return calli(Vector3(System.IntPtr,Vector3*), this.self, &vec, iphysc_FindClosestPointOnConvexShapes);
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x0003AE68 File Offset: 0x00039068
		internal readonly void SetSpeculativeContactEnabled(bool bEnable)
		{
			this.NullCheck("SetSpeculativeContactEnabled");
			method iphysc_SetSpeculativeContactEnabled = IPhysicsBody.__N.IPhysc_SetSpeculativeContactEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnable ? 1 : 0, iphysc_SetSpeculativeContactEnabled);
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x0003AE9C File Offset: 0x0003909C
		internal readonly bool IsSpeculativeContactEnabled()
		{
			this.NullCheck("IsSpeculativeContactEnabled");
			method iphysc_IsSpeculativeContactEnabled = IPhysicsBody.__N.IPhysc_IsSpeculativeContactEnabled;
			return calli(System.Int32(System.IntPtr), this.self, iphysc_IsSpeculativeContactEnabled) > 0;
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x0003AECC File Offset: 0x000390CC
		internal readonly void UpdateSurfaceProperties(IntPtr pSurfaceProperties)
		{
			this.NullCheck("UpdateSurfaceProperties");
			method iphysc_UpdateSurfaceProperties = IPhysicsBody.__N.IPhysc_UpdateSurfaceProperties;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, pSurfaceProperties, iphysc_UpdateSurfaceProperties);
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x0003AEF8 File Offset: 0x000390F8
		internal readonly void SetMaterialIndex(string name)
		{
			this.NullCheck("SetMaterialIndex");
			method iphysc_SetMaterialIndex = IPhysicsBody.__N.IPhysc_SetMaterialIndex;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(name), iphysc_SetMaterialIndex);
		}

		// Token: 0x040000BD RID: 189
		internal IntPtr self;

		// Token: 0x020001D4 RID: 468
		internal static class __N
		{
			// Token: 0x04000F84 RID: 3972
			internal static method IPhysc_GetSurfaceArea;

			// Token: 0x04000F85 RID: 3973
			internal static method IPhysc_SetGravityScale;

			// Token: 0x04000F86 RID: 3974
			internal static method IPhysc_GetGravityScale;

			// Token: 0x04000F87 RID: 3975
			internal static method IPhysc_IsGravityEnabled;

			// Token: 0x04000F88 RID: 3976
			internal static method IPhysc_EnableGravity;

			// Token: 0x04000F89 RID: 3977
			internal static method IPhysc_SetMass;

			// Token: 0x04000F8A RID: 3978
			internal static method IPhysc_GetMass;

			// Token: 0x04000F8B RID: 3979
			internal static method IPhysc_GetPhysicalMassInv;

			// Token: 0x04000F8C RID: 3980
			internal static method IPhysc_GetMassCenter;

			// Token: 0x04000F8D RID: 3981
			internal static method IPhysc_GetLocalMassCenter;

			// Token: 0x04000F8E RID: 3982
			internal static method IPhysc_OverrideMassCenter;

			// Token: 0x04000F8F RID: 3983
			internal static method IPhysc_SetPosition;

			// Token: 0x04000F90 RID: 3984
			internal static method IPhysc_GetPosition;

			// Token: 0x04000F91 RID: 3985
			internal static method IPhysc_SetOrientation;

			// Token: 0x04000F92 RID: 3986
			internal static method IPhysc_GetOrientation;

			// Token: 0x04000F93 RID: 3987
			internal static method IPhysc_SetTransform;

			// Token: 0x04000F94 RID: 3988
			internal static method IPhysc_GetCTransform;

			// Token: 0x04000F95 RID: 3989
			internal static method IPhysc_GetScale;

			// Token: 0x04000F96 RID: 3990
			internal static method IPhysc_SetLinearVelocity;

			// Token: 0x04000F97 RID: 3991
			internal static method IPhysc_GetLinearVelocity;

			// Token: 0x04000F98 RID: 3992
			internal static method IPhysc_GetVelocityAtPoint;

			// Token: 0x04000F99 RID: 3993
			internal static method IPhysc_AddLinearVelocity;

			// Token: 0x04000F9A RID: 3994
			internal static method IPhysc_SetAngularVelocity;

			// Token: 0x04000F9B RID: 3995
			internal static method IPhysc_GetAngularVelocity;

			// Token: 0x04000F9C RID: 3996
			internal static method IPhysc_Wake;

			// Token: 0x04000F9D RID: 3997
			internal static method IPhysc_Sleep;

			// Token: 0x04000F9E RID: 3998
			internal static method IPhysc_IsSleeping;

			// Token: 0x04000F9F RID: 3999
			internal static method IPhysc_EnableAutoSleeping;

			// Token: 0x04000FA0 RID: 4000
			internal static method IPhysc_DisableAutoSleeping;

			// Token: 0x04000FA1 RID: 4001
			internal static method IPhysc_RemoveShadowController;

			// Token: 0x04000FA2 RID: 4002
			internal static method IPhysc_EnableTouchEvents;

			// Token: 0x04000FA3 RID: 4003
			internal static method IPhysc_DisableTouchEvents;

			// Token: 0x04000FA4 RID: 4004
			internal static method IPhysc_IsTouchEventEnabled;

			// Token: 0x04000FA5 RID: 4005
			internal static method IPhysc_GetType;

			// Token: 0x04000FA6 RID: 4006
			internal static method IPhysc_SetType;

			// Token: 0x04000FA7 RID: 4007
			internal static method IPhysc_GetShapeCount;

			// Token: 0x04000FA8 RID: 4008
			internal static method IPhysc_GetShape;

			// Token: 0x04000FA9 RID: 4009
			internal static method IPhysc_GetShapeIndex;

			// Token: 0x04000FAA RID: 4010
			internal static method IPhysc_AddSphereShape;

			// Token: 0x04000FAB RID: 4011
			internal static method IPhysc_AddCapsuleShape;

			// Token: 0x04000FAC RID: 4012
			internal static method IPhysc_AddCloneShape;

			// Token: 0x04000FAD RID: 4013
			internal static method IPhysc_RemoveShape;

			// Token: 0x04000FAE RID: 4014
			internal static method IPhysc_PurgeShapes;

			// Token: 0x04000FAF RID: 4015
			internal static method IPhysc_TransformVectorToLocal;

			// Token: 0x04000FB0 RID: 4016
			internal static method IPhysc_TransformVectorToWorld;

			// Token: 0x04000FB1 RID: 4017
			internal static method IPhysc_TransformPointToLocal;

			// Token: 0x04000FB2 RID: 4018
			internal static method IPhysc_TransformPointToWorld;

			// Token: 0x04000FB3 RID: 4019
			internal static method IPhysc_TransformOrientationToLocal;

			// Token: 0x04000FB4 RID: 4020
			internal static method IPhysc_TransformOrientationToWorld;

			// Token: 0x04000FB5 RID: 4021
			internal static method IPhysc_ApplyLinearImpulse;

			// Token: 0x04000FB6 RID: 4022
			internal static method IPhysc_ApplyLinearImpulseAtWorldSpace;

			// Token: 0x04000FB7 RID: 4023
			internal static method IPhysc_ApplyAngularImpulse;

			// Token: 0x04000FB8 RID: 4024
			internal static method IPhysc_ApplyForce;

			// Token: 0x04000FB9 RID: 4025
			internal static method IPhysc_ApplyForceAt;

			// Token: 0x04000FBA RID: 4026
			internal static method IPhysc_ApplyTorque;

			// Token: 0x04000FBB RID: 4027
			internal static method IPhysc_ClearForces;

			// Token: 0x04000FBC RID: 4028
			internal static method IPhysc_ClearTorques;

			// Token: 0x04000FBD RID: 4029
			internal static method IPhysc_Enable;

			// Token: 0x04000FBE RID: 4030
			internal static method IPhysc_Disable;

			// Token: 0x04000FBF RID: 4031
			internal static method IPhysc_IsEnabled;

			// Token: 0x04000FC0 RID: 4032
			internal static method IPhysc_IsCollisionEnabled;

			// Token: 0x04000FC1 RID: 4033
			internal static method IPhysc_IsMotionEnabled;

			// Token: 0x04000FC2 RID: 4034
			internal static method IPhysc_IsMoveable;

			// Token: 0x04000FC3 RID: 4035
			internal static method IPhysc_EnableMotion;

			// Token: 0x04000FC4 RID: 4036
			internal static method IPhysc_EnableCollisions;

			// Token: 0x04000FC5 RID: 4037
			internal static method IPhysc_SetMinSolverIterations;

			// Token: 0x04000FC6 RID: 4038
			internal static method IPhysc_BuildMass;

			// Token: 0x04000FC7 RID: 4039
			internal static method IPhysc_SetLinearDamping;

			// Token: 0x04000FC8 RID: 4040
			internal static method IPhysc_GetLinearDamping;

			// Token: 0x04000FC9 RID: 4041
			internal static method IPhysc_SetAngularDamping;

			// Token: 0x04000FCA RID: 4042
			internal static method IPhysc_GetAngularDamping;

			// Token: 0x04000FCB RID: 4043
			internal static method IPhysc_EnableDrag;

			// Token: 0x04000FCC RID: 4044
			internal static method IPhysc_IsDragEnabled;

			// Token: 0x04000FCD RID: 4045
			internal static method IPhysc_SetLinearDrag;

			// Token: 0x04000FCE RID: 4046
			internal static method IPhysc_GetLinearDrag;

			// Token: 0x04000FCF RID: 4047
			internal static method IPhysc_SetAngularDrag;

			// Token: 0x04000FD0 RID: 4048
			internal static method IPhysc_GetAngularDrag;

			// Token: 0x04000FD1 RID: 4049
			internal static method IPhysc_RecomputeDragBases;

			// Token: 0x04000FD2 RID: 4050
			internal static method IPhysc_BuildBounds;

			// Token: 0x04000FD3 RID: 4051
			internal static method IPhysc_GetDensity;

			// Token: 0x04000FD4 RID: 4052
			internal static method IPhysc_FindClosestPointOnConvexShapes;

			// Token: 0x04000FD5 RID: 4053
			internal static method IPhysc_SetSpeculativeContactEnabled;

			// Token: 0x04000FD6 RID: 4054
			internal static method IPhysc_IsSpeculativeContactEnabled;

			// Token: 0x04000FD7 RID: 4055
			internal static method IPhysc_UpdateSurfaceProperties;

			// Token: 0x04000FD8 RID: 4056
			internal static method IPhysc_SetMaterialIndex;
		}
	}
}
