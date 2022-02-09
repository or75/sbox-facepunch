using System;
using Sandbox;
using Sandbox.Joints;

namespace NativeEngine
{
	// Token: 0x0200004A RID: 74
	internal static class PhysJoints
	{
		// Token: 0x06000994 RID: 2452 RVA: 0x0003749C File Offset: 0x0003569C
		internal unsafe static PhysicsJoint AddWeldJoint(WeldJointBuilder config)
		{
			method glue_Physcs_AddWeldJoint = PhysJoints.__N.Glue_Physcs_AddWeldJoint;
			return HandleIndex.Get<PhysicsJoint>(calli(System.Int32(Sandbox.Joints.WeldJointBuilder*), &config, glue_Physcs_AddWeldJoint));
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x000374C0 File Offset: 0x000356C0
		internal unsafe static PhysicsJoint AddRevoluteJoint(RevoluteJointBuilder config)
		{
			method glue_Physcs_AddRevoluteJoint = PhysJoints.__N.Glue_Physcs_AddRevoluteJoint;
			return HandleIndex.Get<PhysicsJoint>(calli(System.Int32(Sandbox.Joints.RevoluteJointBuilder*), &config, glue_Physcs_AddRevoluteJoint));
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x000374E4 File Offset: 0x000356E4
		internal unsafe static PhysicsJoint AddPrismaticJoint(PrismaticJointBuilder config)
		{
			method glue_Physcs_AddPrismaticJoint = PhysJoints.__N.Glue_Physcs_AddPrismaticJoint;
			return HandleIndex.Get<PhysicsJoint>(calli(System.Int32(Sandbox.Joints.PrismaticJointBuilder*), &config, glue_Physcs_AddPrismaticJoint));
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x00037508 File Offset: 0x00035708
		internal unsafe static PhysicsJoint AddConicalJoint(ConicalJointBuilder config)
		{
			method glue_Physcs_AddConicalJoint = PhysJoints.__N.Glue_Physcs_AddConicalJoint;
			return HandleIndex.Get<PhysicsJoint>(calli(System.Int32(Sandbox.Joints.ConicalJointBuilder*), &config, glue_Physcs_AddConicalJoint));
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x0003752C File Offset: 0x0003572C
		internal unsafe static PhysicsJoint AddSpringJoint(SpringJointBuilder config)
		{
			method glue_Physcs_AddSpringJoint = PhysJoints.__N.Glue_Physcs_AddSpringJoint;
			return HandleIndex.Get<PhysicsJoint>(calli(System.Int32(Sandbox.Joints.SpringJointBuilder*), &config, glue_Physcs_AddSpringJoint));
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x00037550 File Offset: 0x00035750
		internal unsafe static PhysicsJoint AddSphericalJoint(SphericalJointBuilder config)
		{
			method glue_Physcs_AddSphericalJoint = PhysJoints.__N.Glue_Physcs_AddSphericalJoint;
			return HandleIndex.Get<PhysicsJoint>(calli(System.Int32(Sandbox.Joints.SphericalJointBuilder*), &config, glue_Physcs_AddSphericalJoint));
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x00037574 File Offset: 0x00035774
		internal unsafe static PhysicsJoint AddGenericJoint(GenericJointBuilder config)
		{
			method glue_Physcs_AddGenericJoint = PhysJoints.__N.Glue_Physcs_AddGenericJoint;
			return HandleIndex.Get<PhysicsJoint>(calli(System.Int32(Sandbox.Joints.GenericJointBuilder*), &config, glue_Physcs_AddGenericJoint));
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x00037598 File Offset: 0x00035798
		internal static bool RemoveJoint(PhysicsJoint pJoint)
		{
			method glue_Physcs_RemoveJoint = PhysJoints.__N.Glue_Physcs_RemoveJoint;
			return calli(System.Int32(System.IntPtr), (pJoint == null) ? IntPtr.Zero : pJoint.native, glue_Physcs_RemoveJoint) > 0;
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x000375CC File Offset: 0x000357CC
		internal static Rotation Weld_GetJointFrame1(PhysicsJoint self)
		{
			method glue_Physcs_Weld_GetJointFrame = PhysJoints.__N.Glue_Physcs_Weld_GetJointFrame1;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Weld_GetJointFrame);
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x000375FC File Offset: 0x000357FC
		internal static Rotation Weld_GetLocalJointFrame1(PhysicsJoint self)
		{
			method glue_Physcs_Weld_GetLocalJointFrame = PhysJoints.__N.Glue_Physcs_Weld_GetLocalJointFrame1;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Weld_GetLocalJointFrame);
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x0003762C File Offset: 0x0003582C
		internal static Rotation Weld_GetLocalJointFrame2(PhysicsJoint self)
		{
			method glue_Physcs_Weld_GetLocalJointFrame = PhysJoints.__N.Glue_Physcs_Weld_GetLocalJointFrame2;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Weld_GetLocalJointFrame);
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x0003765C File Offset: 0x0003585C
		internal static Rotation Weld_GetJointFrame2(PhysicsJoint self)
		{
			method glue_Physcs_Weld_GetJointFrame = PhysJoints.__N.Glue_Physcs_Weld_GetJointFrame2;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Weld_GetJointFrame);
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x0003768C File Offset: 0x0003588C
		internal static void Weld_SetLinearFrequency(PhysicsJoint self, float flFrequency)
		{
			method glue_Physcs_Weld_SetLinearFrequency = PhysJoints.__N.Glue_Physcs_Weld_SetLinearFrequency;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flFrequency, glue_Physcs_Weld_SetLinearFrequency);
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x000376BC File Offset: 0x000358BC
		internal static float Weld_GetLinearFrequency(PhysicsJoint self)
		{
			method glue_Physcs_Weld_GetLinearFrequency = PhysJoints.__N.Glue_Physcs_Weld_GetLinearFrequency;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Weld_GetLinearFrequency);
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x000376EC File Offset: 0x000358EC
		internal static void Weld_SetLinearDampingRatio(PhysicsJoint self, float flDampingRatio)
		{
			method glue_Physcs_Weld_SetLinearDampingRatio = PhysJoints.__N.Glue_Physcs_Weld_SetLinearDampingRatio;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flDampingRatio, glue_Physcs_Weld_SetLinearDampingRatio);
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x0003771C File Offset: 0x0003591C
		internal static float Weld_GetLinearDampingRatio(PhysicsJoint self)
		{
			method glue_Physcs_Weld_GetLinearDampingRatio = PhysJoints.__N.Glue_Physcs_Weld_GetLinearDampingRatio;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Weld_GetLinearDampingRatio);
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x0003774C File Offset: 0x0003594C
		internal static void Weld_SetMaxForce(PhysicsJoint self, float flMaxForce)
		{
			method glue_Physcs_Weld_SetMaxForce = PhysJoints.__N.Glue_Physcs_Weld_SetMaxForce;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flMaxForce, glue_Physcs_Weld_SetMaxForce);
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0003777C File Offset: 0x0003597C
		internal static float Weld_GetMaxForce(PhysicsJoint self)
		{
			method glue_Physcs_Weld_GetMaxForce = PhysJoints.__N.Glue_Physcs_Weld_GetMaxForce;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Weld_GetMaxForce);
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x000377AC File Offset: 0x000359AC
		internal static void Weld_SetAngularFrequency(PhysicsJoint self, float flFrequency)
		{
			method glue_Physcs_Weld_SetAngularFrequency = PhysJoints.__N.Glue_Physcs_Weld_SetAngularFrequency;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flFrequency, glue_Physcs_Weld_SetAngularFrequency);
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x000377DC File Offset: 0x000359DC
		internal static float Weld_GetAngularFrequency(PhysicsJoint self)
		{
			method glue_Physcs_Weld_GetAngularFrequency = PhysJoints.__N.Glue_Physcs_Weld_GetAngularFrequency;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Weld_GetAngularFrequency);
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x0003780C File Offset: 0x00035A0C
		internal static void Weld_SetAngularDampingRatio(PhysicsJoint self, float flDampingRatio)
		{
			method glue_Physcs_Weld_SetAngularDampingRatio = PhysJoints.__N.Glue_Physcs_Weld_SetAngularDampingRatio;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flDampingRatio, glue_Physcs_Weld_SetAngularDampingRatio);
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x0003783C File Offset: 0x00035A3C
		internal static float Weld_GetAngularDampingRatio(PhysicsJoint self)
		{
			method glue_Physcs_Weld_GetAngularDampingRatio = PhysJoints.__N.Glue_Physcs_Weld_GetAngularDampingRatio;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Weld_GetAngularDampingRatio);
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x0003786C File Offset: 0x00035A6C
		internal static void Weld_SetMaxTorque(PhysicsJoint self, float flMaxTorque)
		{
			method glue_Physcs_Weld_SetMaxTorque = PhysJoints.__N.Glue_Physcs_Weld_SetMaxTorque;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flMaxTorque, glue_Physcs_Weld_SetMaxTorque);
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x0003789C File Offset: 0x00035A9C
		internal static float Weld_GetMaxTorque(PhysicsJoint self)
		{
			method glue_Physcs_Weld_GetMaxTorque = PhysJoints.__N.Glue_Physcs_Weld_GetMaxTorque;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Weld_GetMaxTorque);
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x000378CC File Offset: 0x00035ACC
		internal static void Weld_Reset(PhysicsJoint self)
		{
			method glue_Physcs_Weld_Reset = PhysJoints.__N.Glue_Physcs_Weld_Reset;
			calli(System.Void(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Weld_Reset);
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x000378FC File Offset: 0x00035AFC
		internal static Vector3 Revolute_GetAnchor1(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_GetAnchor = PhysJoints.__N.Glue_Physcs_Revolute_GetAnchor1;
			return calli(Vector3(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_GetAnchor);
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x0003792C File Offset: 0x00035B2C
		internal static Vector3 Revolute_GetLocalAnchor1(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_GetLocalAnchor = PhysJoints.__N.Glue_Physcs_Revolute_GetLocalAnchor1;
			return calli(Vector3(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_GetLocalAnchor);
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x0003795C File Offset: 0x00035B5C
		internal static Vector3 Revolute_GetAnchor2(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_GetAnchor = PhysJoints.__N.Glue_Physcs_Revolute_GetAnchor2;
			return calli(Vector3(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_GetAnchor);
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x0003798C File Offset: 0x00035B8C
		internal static Vector3 Revolute_GetLocalAnchor2(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_GetLocalAnchor = PhysJoints.__N.Glue_Physcs_Revolute_GetLocalAnchor2;
			return calli(Vector3(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_GetLocalAnchor);
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x000379BC File Offset: 0x00035BBC
		internal static Rotation Revolute_GetLocalJointFrame1(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_GetLocalJointFrame = PhysJoints.__N.Glue_Physcs_Revolute_GetLocalJointFrame1;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_GetLocalJointFrame);
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x000379EC File Offset: 0x00035BEC
		internal static Rotation Revolute_GetJointFrame1(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_GetJointFrame = PhysJoints.__N.Glue_Physcs_Revolute_GetJointFrame1;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_GetJointFrame);
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x00037A1C File Offset: 0x00035C1C
		internal static Rotation Revolute_GetLocalJointFrame2(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_GetLocalJointFrame = PhysJoints.__N.Glue_Physcs_Revolute_GetLocalJointFrame2;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_GetLocalJointFrame);
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x00037A4C File Offset: 0x00035C4C
		internal static Rotation Revolute_GetJointFrame2(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_GetJointFrame = PhysJoints.__N.Glue_Physcs_Revolute_GetJointFrame2;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_GetJointFrame);
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x00037A7C File Offset: 0x00035C7C
		internal static void Revolute_SetMotorMode(PhysicsJoint self, PhysicsJointMotorMode nMotorMode)
		{
			method glue_Physcs_Revolute_SetMotorMode = PhysJoints.__N.Glue_Physcs_Revolute_SetMotorMode;
			calli(System.Void(System.IntPtr,System.Int64), (self == null) ? IntPtr.Zero : self.native, (long)nMotorMode, glue_Physcs_Revolute_SetMotorMode);
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x00037AAC File Offset: 0x00035CAC
		internal static PhysicsJointMotorMode Revolute_GetMotorMode(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_GetMotorMode = PhysJoints.__N.Glue_Physcs_Revolute_GetMotorMode;
			return calli(System.Int64(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_GetMotorMode);
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x00037ADC File Offset: 0x00035CDC
		internal static void Revolute_SetMotorTargetAngle(PhysicsJoint self, float flTargetAngle)
		{
			method glue_Physcs_Revolute_SetMotorTargetAngle = PhysJoints.__N.Glue_Physcs_Revolute_SetMotorTargetAngle;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flTargetAngle, glue_Physcs_Revolute_SetMotorTargetAngle);
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x00037B0C File Offset: 0x00035D0C
		internal static float Revolute_GetMotorTargetAngle(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_GetMotorTargetAngle = PhysJoints.__N.Glue_Physcs_Revolute_GetMotorTargetAngle;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_GetMotorTargetAngle);
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x00037B3C File Offset: 0x00035D3C
		internal static void Revolute_SetMotorFrequency(PhysicsJoint self, float flFrequency)
		{
			method glue_Physcs_Revolute_SetMotorFrequency = PhysJoints.__N.Glue_Physcs_Revolute_SetMotorFrequency;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flFrequency, glue_Physcs_Revolute_SetMotorFrequency);
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x00037B6C File Offset: 0x00035D6C
		internal static float Revolute_GetMotorFrequency(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_GetMotorFrequency = PhysJoints.__N.Glue_Physcs_Revolute_GetMotorFrequency;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_GetMotorFrequency);
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x00037B9C File Offset: 0x00035D9C
		internal static void Revolute_SetMotorDampingRatio(PhysicsJoint self, float flDampingRatio)
		{
			method glue_Physcs_Revolute_SetMotorDampingRatio = PhysJoints.__N.Glue_Physcs_Revolute_SetMotorDampingRatio;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flDampingRatio, glue_Physcs_Revolute_SetMotorDampingRatio);
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x00037BCC File Offset: 0x00035DCC
		internal static float Revolute_GetMotorDampingRatio(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_GetMotorDampingRatio = PhysJoints.__N.Glue_Physcs_Revolute_GetMotorDampingRatio;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_GetMotorDampingRatio);
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x00037BFC File Offset: 0x00035DFC
		internal static void Revolute_SetMotorTargetVelocity(PhysicsJoint self, float flTargetVelocity)
		{
			method glue_Physcs_Revolute_SetMotorTargetVelocity = PhysJoints.__N.Glue_Physcs_Revolute_SetMotorTargetVelocity;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flTargetVelocity, glue_Physcs_Revolute_SetMotorTargetVelocity);
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x00037C2C File Offset: 0x00035E2C
		internal static float Revolute_GetMotorTargetVelocity(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_GetMotorTargetVelocity = PhysJoints.__N.Glue_Physcs_Revolute_GetMotorTargetVelocity;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_GetMotorTargetVelocity);
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x00037C5C File Offset: 0x00035E5C
		internal static void Revolute_SetMotorMaxTorque(PhysicsJoint self, float flMaxTorque)
		{
			method glue_Physcs_Revolute_SetMotorMaxTorque = PhysJoints.__N.Glue_Physcs_Revolute_SetMotorMaxTorque;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flMaxTorque, glue_Physcs_Revolute_SetMotorMaxTorque);
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x00037C8C File Offset: 0x00035E8C
		internal static float Revolute_GetMotorMaxTorque(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_GetMotorMaxTorque = PhysJoints.__N.Glue_Physcs_Revolute_GetMotorMaxTorque;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_GetMotorMaxTorque);
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x00037CBC File Offset: 0x00035EBC
		internal static void Revolute_SetMotorFriction(PhysicsJoint self, float flFriction)
		{
			method glue_Physcs_Revolute_SetMotorFriction = PhysJoints.__N.Glue_Physcs_Revolute_SetMotorFriction;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flFriction, glue_Physcs_Revolute_SetMotorFriction);
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x00037CEC File Offset: 0x00035EEC
		internal static void Revolute_EnableLimit(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_EnableLimit = PhysJoints.__N.Glue_Physcs_Revolute_EnableLimit;
			calli(System.Void(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_EnableLimit);
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x00037D1C File Offset: 0x00035F1C
		internal static void Revolute_DisableLimit(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_DisableLimit = PhysJoints.__N.Glue_Physcs_Revolute_DisableLimit;
			calli(System.Void(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_DisableLimit);
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x00037D4C File Offset: 0x00035F4C
		internal static bool Revolute_IsLimitEnabled(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_IsLimitEnabled = PhysJoints.__N.Glue_Physcs_Revolute_IsLimitEnabled;
			return calli(System.Int32(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_IsLimitEnabled) > 0;
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x00037D80 File Offset: 0x00035F80
		internal static void Revolute_SetLimitRange(PhysicsJoint self, float flMin, float flMax)
		{
			method glue_Physcs_Revolute_SetLimitRange = PhysJoints.__N.Glue_Physcs_Revolute_SetLimitRange;
			calli(System.Void(System.IntPtr,System.Single,System.Single), (self == null) ? IntPtr.Zero : self.native, flMin, flMax, glue_Physcs_Revolute_SetLimitRange);
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x00037DB0 File Offset: 0x00035FB0
		internal static void Revolute_GetLimitRange(PhysicsJoint self, out float flMin, out float flMax)
		{
			method glue_Physcs_Revolute_GetLimitRange = PhysJoints.__N.Glue_Physcs_Revolute_GetLimitRange;
			calli(System.Void(System.IntPtr,System.Single& modreq(System.Runtime.InteropServices.OutAttribute),System.Single& modreq(System.Runtime.InteropServices.OutAttribute)), (self == null) ? IntPtr.Zero : self.native, ref flMin, ref flMax, glue_Physcs_Revolute_GetLimitRange);
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x00037DE0 File Offset: 0x00035FE0
		internal static float Revolute_GetAngle(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_GetAngle = PhysJoints.__N.Glue_Physcs_Revolute_GetAngle;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_GetAngle);
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x00037E10 File Offset: 0x00036010
		internal static float Revolute_GetAngleSpeed(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_GetAngleSpeed = PhysJoints.__N.Glue_Physcs_Revolute_GetAngleSpeed;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_GetAngleSpeed);
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x00037E40 File Offset: 0x00036040
		internal static Vector3 Revolute_GetAngleAxis(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_GetAngleAxis = PhysJoints.__N.Glue_Physcs_Revolute_GetAngleAxis;
			return calli(Vector3(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_GetAngleAxis);
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x00037E70 File Offset: 0x00036070
		internal static bool Revolute_UseBlockSolver(PhysicsJoint self)
		{
			method glue_Physcs_Revolute_UseBlockSolver = PhysJoints.__N.Glue_Physcs_Revolute_UseBlockSolver;
			return calli(System.Int32(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Revolute_UseBlockSolver) > 0;
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x00037EA4 File Offset: 0x000360A4
		internal static Rotation Prismatic_GetLocalJointFrame1(PhysicsJoint self)
		{
			method glue_Physcs_Prismatic_GetLocalJointFrame = PhysJoints.__N.Glue_Physcs_Prismatic_GetLocalJointFrame1;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Prismatic_GetLocalJointFrame);
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x00037ED4 File Offset: 0x000360D4
		internal static Rotation Prismatic_GetJointFrame1(PhysicsJoint self)
		{
			method glue_Physcs_Prismatic_GetJointFrame = PhysJoints.__N.Glue_Physcs_Prismatic_GetJointFrame1;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Prismatic_GetJointFrame);
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x00037F04 File Offset: 0x00036104
		internal static Rotation Prismatic_GetLocalJointFrame2(PhysicsJoint self)
		{
			method glue_Physcs_Prismatic_GetLocalJointFrame = PhysJoints.__N.Glue_Physcs_Prismatic_GetLocalJointFrame2;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Prismatic_GetLocalJointFrame);
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x00037F34 File Offset: 0x00036134
		internal static Rotation Prismatic_GetJointFrame2(PhysicsJoint self)
		{
			method glue_Physcs_Prismatic_GetJointFrame = PhysJoints.__N.Glue_Physcs_Prismatic_GetJointFrame2;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Prismatic_GetJointFrame);
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x00037F64 File Offset: 0x00036164
		internal static PhysicsJointMotorMode Prismatic_GetMotorMode(PhysicsJoint self)
		{
			method glue_Physcs_Prismatic_GetMotorMode = PhysJoints.__N.Glue_Physcs_Prismatic_GetMotorMode;
			return calli(System.Int64(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Prismatic_GetMotorMode);
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x00037F94 File Offset: 0x00036194
		internal static float Prismatic_GetMotorTargetOffset(PhysicsJoint self)
		{
			method glue_Physcs_Prismatic_GetMotorTargetOffset = PhysJoints.__N.Glue_Physcs_Prismatic_GetMotorTargetOffset;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Prismatic_GetMotorTargetOffset);
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x00037FC4 File Offset: 0x000361C4
		internal static float Prismatic_GetMotorFrequency(PhysicsJoint self)
		{
			method glue_Physcs_Prismatic_GetMotorFrequency = PhysJoints.__N.Glue_Physcs_Prismatic_GetMotorFrequency;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Prismatic_GetMotorFrequency);
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x00037FF4 File Offset: 0x000361F4
		internal static float Prismatic_GetMotorDampingRatio(PhysicsJoint self)
		{
			method glue_Physcs_Prismatic_GetMotorDampingRatio = PhysJoints.__N.Glue_Physcs_Prismatic_GetMotorDampingRatio;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Prismatic_GetMotorDampingRatio);
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x00038024 File Offset: 0x00036224
		internal static float Prismatic_GetMotorTargetVelocity(PhysicsJoint self)
		{
			method glue_Physcs_Prismatic_GetMotorTargetVelocity = PhysJoints.__N.Glue_Physcs_Prismatic_GetMotorTargetVelocity;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Prismatic_GetMotorTargetVelocity);
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x00038054 File Offset: 0x00036254
		internal static float Prismatic_GetMotorMaxForce(PhysicsJoint self)
		{
			method glue_Physcs_Prismatic_GetMotorMaxForce = PhysJoints.__N.Glue_Physcs_Prismatic_GetMotorMaxForce;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Prismatic_GetMotorMaxForce);
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x00038084 File Offset: 0x00036284
		internal static bool Prismatic_IsLimitEnabled(PhysicsJoint self)
		{
			method glue_Physcs_Prismatic_IsLimitEnabled = PhysJoints.__N.Glue_Physcs_Prismatic_IsLimitEnabled;
			return calli(System.Int32(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Prismatic_IsLimitEnabled) > 0;
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x000380B8 File Offset: 0x000362B8
		internal static Vector2 Prismatic_GetLimitRange(PhysicsJoint self)
		{
			method glue_Physcs_Prismatic_GetLimitRange = PhysJoints.__N.Glue_Physcs_Prismatic_GetLimitRange;
			return calli(Vector2(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Prismatic_GetLimitRange);
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x000380E8 File Offset: 0x000362E8
		internal static float Prismatic_GetOffset(PhysicsJoint self)
		{
			method glue_Physcs_Prismatic_GetOffset = PhysJoints.__N.Glue_Physcs_Prismatic_GetOffset;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Prismatic_GetOffset);
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x00038118 File Offset: 0x00036318
		internal static float Prismatic_GetOffsetSpeed(PhysicsJoint self)
		{
			method glue_Physcs_Prismatic_GetOffsetSpeed = PhysJoints.__N.Glue_Physcs_Prismatic_GetOffsetSpeed;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Prismatic_GetOffsetSpeed);
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x00038148 File Offset: 0x00036348
		internal static Vector3 Prismatic_GetOffsetAxis(PhysicsJoint self)
		{
			method glue_Physcs_Prismatic_GetOffsetAxis = PhysJoints.__N.Glue_Physcs_Prismatic_GetOffsetAxis;
			return calli(Vector3(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Prismatic_GetOffsetAxis);
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x00038178 File Offset: 0x00036378
		internal static void Prismatic_SetMotorMode(PhysicsJoint self, PhysicsJointMotorMode nMotorMode)
		{
			method glue_Physcs_Prismatic_SetMotorMode = PhysJoints.__N.Glue_Physcs_Prismatic_SetMotorMode;
			calli(System.Void(System.IntPtr,System.Int64), (self == null) ? IntPtr.Zero : self.native, (long)nMotorMode, glue_Physcs_Prismatic_SetMotorMode);
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x000381A8 File Offset: 0x000363A8
		internal static void Prismatic_SetMotorTargetOffset(PhysicsJoint self, float flTargetOffset)
		{
			method glue_Physcs_Prismatic_SetMotorTargetOffset = PhysJoints.__N.Glue_Physcs_Prismatic_SetMotorTargetOffset;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flTargetOffset, glue_Physcs_Prismatic_SetMotorTargetOffset);
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x000381D8 File Offset: 0x000363D8
		internal static void Prismatic_SetMotorFrequency(PhysicsJoint self, float flFrequency)
		{
			method glue_Physcs_Prismatic_SetMotorFrequency = PhysJoints.__N.Glue_Physcs_Prismatic_SetMotorFrequency;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flFrequency, glue_Physcs_Prismatic_SetMotorFrequency);
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x00038208 File Offset: 0x00036408
		internal static void Prismatic_SetMotorDampingRatio(PhysicsJoint self, float flDampingRatio)
		{
			method glue_Physcs_Prismatic_SetMotorDampingRatio = PhysJoints.__N.Glue_Physcs_Prismatic_SetMotorDampingRatio;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flDampingRatio, glue_Physcs_Prismatic_SetMotorDampingRatio);
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x00038238 File Offset: 0x00036438
		internal static void Prismatic_SetMotorTargetVelocity(PhysicsJoint self, float flTargetVelocity)
		{
			method glue_Physcs_Prismatic_SetMotorTargetVelocity = PhysJoints.__N.Glue_Physcs_Prismatic_SetMotorTargetVelocity;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flTargetVelocity, glue_Physcs_Prismatic_SetMotorTargetVelocity);
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x00038268 File Offset: 0x00036468
		internal static void Prismatic_SetMotorMaxForce(PhysicsJoint self, float flMaxForce)
		{
			method glue_Physcs_Prismatic_SetMotorMaxForce = PhysJoints.__N.Glue_Physcs_Prismatic_SetMotorMaxForce;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flMaxForce, glue_Physcs_Prismatic_SetMotorMaxForce);
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x00038298 File Offset: 0x00036498
		internal static void Prismatic_SetMotorFriction(PhysicsJoint self, float flFriction)
		{
			method glue_Physcs_Prismatic_SetMotorFriction = PhysJoints.__N.Glue_Physcs_Prismatic_SetMotorFriction;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flFriction, glue_Physcs_Prismatic_SetMotorFriction);
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x000382C8 File Offset: 0x000364C8
		internal static void Prismatic_EnableLimit(PhysicsJoint self)
		{
			method glue_Physcs_Prismatic_EnableLimit = PhysJoints.__N.Glue_Physcs_Prismatic_EnableLimit;
			calli(System.Void(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Prismatic_EnableLimit);
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x000382F8 File Offset: 0x000364F8
		internal static void Prismatic_DisableLimit(PhysicsJoint self)
		{
			method glue_Physcs_Prismatic_DisableLimit = PhysJoints.__N.Glue_Physcs_Prismatic_DisableLimit;
			calli(System.Void(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Prismatic_DisableLimit);
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x00038328 File Offset: 0x00036528
		internal unsafe static void Prismatic_SetLimitRange(PhysicsJoint self, Vector2 range)
		{
			method glue_Physcs_Prismatic_SetLimitRange = PhysJoints.__N.Glue_Physcs_Prismatic_SetLimitRange;
			calli(System.Void(System.IntPtr,Vector2*), (self == null) ? IntPtr.Zero : self.native, &range, glue_Physcs_Prismatic_SetLimitRange);
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x0003835C File Offset: 0x0003655C
		internal static Rotation Conical_GetLocalJointFrame1(PhysicsJoint self)
		{
			method glue_Physcs_Conical_GetLocalJointFrame = PhysJoints.__N.Glue_Physcs_Conical_GetLocalJointFrame1;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_GetLocalJointFrame);
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x0003838C File Offset: 0x0003658C
		internal static Rotation Conical_GetJointFrame1(PhysicsJoint self)
		{
			method glue_Physcs_Conical_GetJointFrame = PhysJoints.__N.Glue_Physcs_Conical_GetJointFrame1;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_GetJointFrame);
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x000383BC File Offset: 0x000365BC
		internal static Rotation Conical_GetLocalJointFrame2(PhysicsJoint self)
		{
			method glue_Physcs_Conical_GetLocalJointFrame = PhysJoints.__N.Glue_Physcs_Conical_GetLocalJointFrame2;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_GetLocalJointFrame);
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x000383EC File Offset: 0x000365EC
		internal static Rotation Conical_GetJointFrame2(PhysicsJoint self)
		{
			method glue_Physcs_Conical_GetJointFrame = PhysJoints.__N.Glue_Physcs_Conical_GetJointFrame2;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_GetJointFrame);
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x0003841C File Offset: 0x0003661C
		internal static PhysicsJointMotorMode Conical_GetMotorMode(PhysicsJoint self)
		{
			method glue_Physcs_Conical_GetMotorMode = PhysJoints.__N.Glue_Physcs_Conical_GetMotorMode;
			return calli(System.Int64(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_GetMotorMode);
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x0003844C File Offset: 0x0003664C
		internal static Rotation Conical_GetMotorTargetOrientation(PhysicsJoint self)
		{
			method glue_Physcs_Conical_GetMotorTargetOrientation = PhysJoints.__N.Glue_Physcs_Conical_GetMotorTargetOrientation;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_GetMotorTargetOrientation);
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x0003847C File Offset: 0x0003667C
		internal static float Conical_GetMotorFrequency(PhysicsJoint self)
		{
			method glue_Physcs_Conical_GetMotorFrequency = PhysJoints.__N.Glue_Physcs_Conical_GetMotorFrequency;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_GetMotorFrequency);
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x000384AC File Offset: 0x000366AC
		internal static float Conical_GetMotorDampingRatio(PhysicsJoint self)
		{
			method glue_Physcs_Conical_GetMotorDampingRatio = PhysJoints.__N.Glue_Physcs_Conical_GetMotorDampingRatio;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_GetMotorDampingRatio);
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x000384DC File Offset: 0x000366DC
		internal static Vector3 Conical_GetMotorTargetVelocity(PhysicsJoint self)
		{
			method glue_Physcs_Conical_GetMotorTargetVelocity = PhysJoints.__N.Glue_Physcs_Conical_GetMotorTargetVelocity;
			return calli(Vector3(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_GetMotorTargetVelocity);
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x0003850C File Offset: 0x0003670C
		internal static float Conical_GetMotorMaxTorque(PhysicsJoint self)
		{
			method glue_Physcs_Conical_GetMotorMaxTorque = PhysJoints.__N.Glue_Physcs_Conical_GetMotorMaxTorque;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_GetMotorMaxTorque);
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x0003853C File Offset: 0x0003673C
		internal static bool Conical_IsTwistLimitEnabled(PhysicsJoint self)
		{
			method glue_Physcs_Conical_IsTwistLimitEnabled = PhysJoints.__N.Glue_Physcs_Conical_IsTwistLimitEnabled;
			return calli(System.Int32(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_IsTwistLimitEnabled) > 0;
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x00038570 File Offset: 0x00036770
		internal static Vector2 Conical_GetTwistRange(PhysicsJoint self)
		{
			method glue_Physcs_Conical_GetTwistRange = PhysJoints.__N.Glue_Physcs_Conical_GetTwistRange;
			return calli(Vector2(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_GetTwistRange);
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x000385A0 File Offset: 0x000367A0
		internal static float Conical_GetTwistAngle(PhysicsJoint self)
		{
			method glue_Physcs_Conical_GetTwistAngle = PhysJoints.__N.Glue_Physcs_Conical_GetTwistAngle;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_GetTwistAngle);
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x000385D0 File Offset: 0x000367D0
		internal static float Conical_GetTwistTorque(PhysicsJoint self, float dt)
		{
			method glue_Physcs_Conical_GetTwistTorque = PhysJoints.__N.Glue_Physcs_Conical_GetTwistTorque;
			return calli(System.Single(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, dt, glue_Physcs_Conical_GetTwistTorque);
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x00038600 File Offset: 0x00036800
		internal static bool Conical_IsSwingLimitEnabled(PhysicsJoint self)
		{
			method glue_Physcs_Conical_IsSwingLimitEnabled = PhysJoints.__N.Glue_Physcs_Conical_IsSwingLimitEnabled;
			return calli(System.Int32(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_IsSwingLimitEnabled) > 0;
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x00038634 File Offset: 0x00036834
		internal static float Conical_GetSwingLimit(PhysicsJoint self)
		{
			method glue_Physcs_Conical_GetSwingLimit = PhysJoints.__N.Glue_Physcs_Conical_GetSwingLimit;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_GetSwingLimit);
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x00038664 File Offset: 0x00036864
		internal static float Conical_GetSwingAngle(PhysicsJoint self)
		{
			method glue_Physcs_Conical_GetSwingAngle = PhysJoints.__N.Glue_Physcs_Conical_GetSwingAngle;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_GetSwingAngle);
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x00038694 File Offset: 0x00036894
		internal static float Conical_GetSwingTorque(PhysicsJoint self, float dt)
		{
			method glue_Physcs_Conical_GetSwingTorque = PhysJoints.__N.Glue_Physcs_Conical_GetSwingTorque;
			return calli(System.Single(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, dt, glue_Physcs_Conical_GetSwingTorque);
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x000386C4 File Offset: 0x000368C4
		internal static void Conical_SetMotorMode(PhysicsJoint self, PhysicsJointMotorMode nMotorMode)
		{
			method glue_Physcs_Conical_SetMotorMode = PhysJoints.__N.Glue_Physcs_Conical_SetMotorMode;
			calli(System.Void(System.IntPtr,System.Int64), (self == null) ? IntPtr.Zero : self.native, (long)nMotorMode, glue_Physcs_Conical_SetMotorMode);
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x000386F4 File Offset: 0x000368F4
		internal unsafe static void Conical_SetMotorTargetOrientation(PhysicsJoint self, Rotation qTargetOrientation)
		{
			method glue_Physcs_Conical_SetMotorTargetOrientation = PhysJoints.__N.Glue_Physcs_Conical_SetMotorTargetOrientation;
			calli(System.Void(System.IntPtr,Rotation*), (self == null) ? IntPtr.Zero : self.native, &qTargetOrientation, glue_Physcs_Conical_SetMotorTargetOrientation);
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x00038728 File Offset: 0x00036928
		internal static void Conical_SetMotorFrequency(PhysicsJoint self, float flFrequency)
		{
			method glue_Physcs_Conical_SetMotorFrequency = PhysJoints.__N.Glue_Physcs_Conical_SetMotorFrequency;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flFrequency, glue_Physcs_Conical_SetMotorFrequency);
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x00038758 File Offset: 0x00036958
		internal static void Conical_SetMotorDampingRatio(PhysicsJoint self, float flDampingRatio)
		{
			method glue_Physcs_Conical_SetMotorDampingRatio = PhysJoints.__N.Glue_Physcs_Conical_SetMotorDampingRatio;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flDampingRatio, glue_Physcs_Conical_SetMotorDampingRatio);
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x00038788 File Offset: 0x00036988
		internal unsafe static void Conical_SetMotorTargetVelocity(PhysicsJoint self, Vector3 vTargetVelocity)
		{
			method glue_Physcs_Conical_SetMotorTargetVelocity = PhysJoints.__N.Glue_Physcs_Conical_SetMotorTargetVelocity;
			calli(System.Void(System.IntPtr,Vector3*), (self == null) ? IntPtr.Zero : self.native, &vTargetVelocity, glue_Physcs_Conical_SetMotorTargetVelocity);
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x000387BC File Offset: 0x000369BC
		internal static void Conical_SetMotorMaxTorque(PhysicsJoint self, float flMaxTorque)
		{
			method glue_Physcs_Conical_SetMotorMaxTorque = PhysJoints.__N.Glue_Physcs_Conical_SetMotorMaxTorque;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flMaxTorque, glue_Physcs_Conical_SetMotorMaxTorque);
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x000387EC File Offset: 0x000369EC
		internal static void Conical_SetMotorFriction(PhysicsJoint self, float flFriction)
		{
			method glue_Physcs_Conical_SetMotorFriction = PhysJoints.__N.Glue_Physcs_Conical_SetMotorFriction;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flFriction, glue_Physcs_Conical_SetMotorFriction);
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x0003881C File Offset: 0x00036A1C
		internal static void Conical_EnableTwistLimit(PhysicsJoint self)
		{
			method glue_Physcs_Conical_EnableTwistLimit = PhysJoints.__N.Glue_Physcs_Conical_EnableTwistLimit;
			calli(System.Void(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_EnableTwistLimit);
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x0003884C File Offset: 0x00036A4C
		internal static void Conical_DisableTwistLimit(PhysicsJoint self)
		{
			method glue_Physcs_Conical_DisableTwistLimit = PhysJoints.__N.Glue_Physcs_Conical_DisableTwistLimit;
			calli(System.Void(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_DisableTwistLimit);
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x0003887C File Offset: 0x00036A7C
		internal unsafe static void Conical_SetTwistRange(PhysicsJoint self, Vector2 range)
		{
			method glue_Physcs_Conical_SetTwistRange = PhysJoints.__N.Glue_Physcs_Conical_SetTwistRange;
			calli(System.Void(System.IntPtr,Vector2*), (self == null) ? IntPtr.Zero : self.native, &range, glue_Physcs_Conical_SetTwistRange);
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x000388B0 File Offset: 0x00036AB0
		internal static void Conical_EnableSwingLimit(PhysicsJoint self)
		{
			method glue_Physcs_Conical_EnableSwingLimit = PhysJoints.__N.Glue_Physcs_Conical_EnableSwingLimit;
			calli(System.Void(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_EnableSwingLimit);
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x000388E0 File Offset: 0x00036AE0
		internal static void Conical_DisableSwingLimit(PhysicsJoint self)
		{
			method glue_Physcs_Conical_DisableSwingLimit = PhysJoints.__N.Glue_Physcs_Conical_DisableSwingLimit;
			calli(System.Void(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Conical_DisableSwingLimit);
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x00038910 File Offset: 0x00036B10
		internal static void Conical_SetSwingLimit(PhysicsJoint self, float flSwingLimit)
		{
			method glue_Physcs_Conical_SetSwingLimit = PhysJoints.__N.Glue_Physcs_Conical_SetSwingLimit;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flSwingLimit, glue_Physcs_Conical_SetSwingLimit);
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x00038940 File Offset: 0x00036B40
		internal static Rotation Spherical_GetLocalJointFrame1(PhysicsJoint self)
		{
			method glue_Physcs_Spherical_GetLocalJointFrame = PhysJoints.__N.Glue_Physcs_Spherical_GetLocalJointFrame1;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spherical_GetLocalJointFrame);
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x00038970 File Offset: 0x00036B70
		internal static Rotation Spherical_GetJointFrame1(PhysicsJoint self)
		{
			method glue_Physcs_Spherical_GetJointFrame = PhysJoints.__N.Glue_Physcs_Spherical_GetJointFrame1;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spherical_GetJointFrame);
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x000389A0 File Offset: 0x00036BA0
		internal static Rotation Spherical_GetLocalJointFrame2(PhysicsJoint self)
		{
			method glue_Physcs_Spherical_GetLocalJointFrame = PhysJoints.__N.Glue_Physcs_Spherical_GetLocalJointFrame2;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spherical_GetLocalJointFrame);
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x000389D0 File Offset: 0x00036BD0
		internal static Rotation Spherical_GetJointFrame2(PhysicsJoint self)
		{
			method glue_Physcs_Spherical_GetJointFrame = PhysJoints.__N.Glue_Physcs_Spherical_GetJointFrame2;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spherical_GetJointFrame);
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x00038A00 File Offset: 0x00036C00
		internal static PhysicsJointMotorMode Spherical_GetMotorMode(PhysicsJoint self)
		{
			method glue_Physcs_Spherical_GetMotorMode = PhysJoints.__N.Glue_Physcs_Spherical_GetMotorMode;
			return calli(System.Int64(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spherical_GetMotorMode);
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x00038A30 File Offset: 0x00036C30
		internal static Rotation Spherical_GetMotorTargetOrientation(PhysicsJoint self)
		{
			method glue_Physcs_Spherical_GetMotorTargetOrientation = PhysJoints.__N.Glue_Physcs_Spherical_GetMotorTargetOrientation;
			return calli(Rotation(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spherical_GetMotorTargetOrientation);
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x00038A60 File Offset: 0x00036C60
		internal static float Spherical_GetMotorFrequency(PhysicsJoint self)
		{
			method glue_Physcs_Spherical_GetMotorFrequency = PhysJoints.__N.Glue_Physcs_Spherical_GetMotorFrequency;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spherical_GetMotorFrequency);
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x00038A90 File Offset: 0x00036C90
		internal static float Spherical_GetMotorDampingRatio(PhysicsJoint self)
		{
			method glue_Physcs_Spherical_GetMotorDampingRatio = PhysJoints.__N.Glue_Physcs_Spherical_GetMotorDampingRatio;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spherical_GetMotorDampingRatio);
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x00038AC0 File Offset: 0x00036CC0
		internal static Vector3 Spherical_GetMotorTargetVelocity(PhysicsJoint self)
		{
			method glue_Physcs_Spherical_GetMotorTargetVelocity = PhysJoints.__N.Glue_Physcs_Spherical_GetMotorTargetVelocity;
			return calli(Vector3(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spherical_GetMotorTargetVelocity);
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x00038AF0 File Offset: 0x00036CF0
		internal static float Spherical_GetMotorMaxTorque(PhysicsJoint self)
		{
			method glue_Physcs_Spherical_GetMotorMaxTorque = PhysJoints.__N.Glue_Physcs_Spherical_GetMotorMaxTorque;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spherical_GetMotorMaxTorque);
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x00038B20 File Offset: 0x00036D20
		internal static void Spherical_SetMotorMode(PhysicsJoint self, PhysicsJointMotorMode nMotorMode)
		{
			method glue_Physcs_Spherical_SetMotorMode = PhysJoints.__N.Glue_Physcs_Spherical_SetMotorMode;
			calli(System.Void(System.IntPtr,System.Int64), (self == null) ? IntPtr.Zero : self.native, (long)nMotorMode, glue_Physcs_Spherical_SetMotorMode);
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x00038B50 File Offset: 0x00036D50
		internal unsafe static void Spherical_SetMotorTargetOrientation(PhysicsJoint self, Rotation qTargetOrientation)
		{
			method glue_Physcs_Spherical_SetMotorTargetOrientation = PhysJoints.__N.Glue_Physcs_Spherical_SetMotorTargetOrientation;
			calli(System.Void(System.IntPtr,Rotation*), (self == null) ? IntPtr.Zero : self.native, &qTargetOrientation, glue_Physcs_Spherical_SetMotorTargetOrientation);
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x00038B84 File Offset: 0x00036D84
		internal static void Spherical_SetMotorFrequency(PhysicsJoint self, float flFrequency)
		{
			method glue_Physcs_Spherical_SetMotorFrequency = PhysJoints.__N.Glue_Physcs_Spherical_SetMotorFrequency;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flFrequency, glue_Physcs_Spherical_SetMotorFrequency);
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x00038BB4 File Offset: 0x00036DB4
		internal static void Spherical_SetMotorDampingRatio(PhysicsJoint self, float flDampingRatio)
		{
			method glue_Physcs_Spherical_SetMotorDampingRatio = PhysJoints.__N.Glue_Physcs_Spherical_SetMotorDampingRatio;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flDampingRatio, glue_Physcs_Spherical_SetMotorDampingRatio);
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x00038BE4 File Offset: 0x00036DE4
		internal unsafe static void Spherical_SetMotorTargetVelocity(PhysicsJoint self, Vector3 vTargetVelocity)
		{
			method glue_Physcs_Spherical_SetMotorTargetVelocity = PhysJoints.__N.Glue_Physcs_Spherical_SetMotorTargetVelocity;
			calli(System.Void(System.IntPtr,Vector3*), (self == null) ? IntPtr.Zero : self.native, &vTargetVelocity, glue_Physcs_Spherical_SetMotorTargetVelocity);
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x00038C18 File Offset: 0x00036E18
		internal static void Spherical_SetMotorMaxTorque(PhysicsJoint self, float flMaxTorque)
		{
			method glue_Physcs_Spherical_SetMotorMaxTorque = PhysJoints.__N.Glue_Physcs_Spherical_SetMotorMaxTorque;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flMaxTorque, glue_Physcs_Spherical_SetMotorMaxTorque);
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x00038C48 File Offset: 0x00036E48
		internal static void Spherical_SetMotorFriction(PhysicsJoint self, float flFriction)
		{
			method glue_Physcs_Spherical_SetMotorFriction = PhysJoints.__N.Glue_Physcs_Spherical_SetMotorFriction;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flFriction, glue_Physcs_Spherical_SetMotorFriction);
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x00038C78 File Offset: 0x00036E78
		internal static float Spring_GetFrequency(PhysicsJoint self)
		{
			method glue_Physcs_Spring_GetFrequency = PhysJoints.__N.Glue_Physcs_Spring_GetFrequency;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spring_GetFrequency);
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x00038CA8 File Offset: 0x00036EA8
		internal static float Spring_GetDampingRatio(PhysicsJoint self)
		{
			method glue_Physcs_Spring_GetDampingRatio = PhysJoints.__N.Glue_Physcs_Spring_GetDampingRatio;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spring_GetDampingRatio);
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x00038CD8 File Offset: 0x00036ED8
		internal static float Spring_GetReferenceMass(PhysicsJoint self)
		{
			method glue_Physcs_Spring_GetReferenceMass = PhysJoints.__N.Glue_Physcs_Spring_GetReferenceMass;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spring_GetReferenceMass);
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x00038D08 File Offset: 0x00036F08
		internal static float Spring_GetRestLengthMin(PhysicsJoint self)
		{
			method glue_Physcs_Spring_GetRestLengthMin = PhysJoints.__N.Glue_Physcs_Spring_GetRestLengthMin;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spring_GetRestLengthMin);
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x00038D38 File Offset: 0x00036F38
		internal static float Spring_GetRestLengthMax(PhysicsJoint self)
		{
			method glue_Physcs_Spring_GetRestLengthMax = PhysJoints.__N.Glue_Physcs_Spring_GetRestLengthMax;
			return calli(System.Single(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spring_GetRestLengthMax);
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x00038D68 File Offset: 0x00036F68
		internal static Vector2 Spring_GetParameters(PhysicsJoint self)
		{
			method glue_Physcs_Spring_GetParameters = PhysJoints.__N.Glue_Physcs_Spring_GetParameters;
			return calli(Vector2(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spring_GetParameters);
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x00038D98 File Offset: 0x00036F98
		internal static bool Spring_IsCollisionEnabled(PhysicsJoint self)
		{
			method glue_Physcs_Spring_IsCollisionEnabled = PhysJoints.__N.Glue_Physcs_Spring_IsCollisionEnabled;
			return calli(System.Int32(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spring_IsCollisionEnabled) > 0;
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x00038DCC File Offset: 0x00036FCC
		internal static void Spring_SetFrequency(PhysicsJoint self, float flFrequency)
		{
			method glue_Physcs_Spring_SetFrequency = PhysJoints.__N.Glue_Physcs_Spring_SetFrequency;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flFrequency, glue_Physcs_Spring_SetFrequency);
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x00038DFC File Offset: 0x00036FFC
		internal static void Spring_SetDampingRatio(PhysicsJoint self, float flDampingRatio)
		{
			method glue_Physcs_Spring_SetDampingRatio = PhysJoints.__N.Glue_Physcs_Spring_SetDampingRatio;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flDampingRatio, glue_Physcs_Spring_SetDampingRatio);
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x00038E2C File Offset: 0x0003702C
		internal static void Spring_SetReferenceMass(PhysicsJoint self, float flReferenceMass)
		{
			method glue_Physcs_Spring_SetReferenceMass = PhysJoints.__N.Glue_Physcs_Spring_SetReferenceMass;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flReferenceMass, glue_Physcs_Spring_SetReferenceMass);
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x00038E5C File Offset: 0x0003705C
		internal static void Spring_SetRestLength(PhysicsJoint self, float flRestLengthMin, float flRestLengthMax)
		{
			method glue_Physcs_Spring_SetRestLength = PhysJoints.__N.Glue_Physcs_Spring_SetRestLength;
			calli(System.Void(System.IntPtr,System.Single,System.Single), (self == null) ? IntPtr.Zero : self.native, flRestLengthMin, flRestLengthMax, glue_Physcs_Spring_SetRestLength);
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x00038E8C File Offset: 0x0003708C
		internal static void Spring_SetParameters(PhysicsJoint self, float flStiffness, float flDamping)
		{
			method glue_Physcs_Spring_SetParameters = PhysJoints.__N.Glue_Physcs_Spring_SetParameters;
			calli(System.Void(System.IntPtr,System.Single,System.Single), (self == null) ? IntPtr.Zero : self.native, flStiffness, flDamping, glue_Physcs_Spring_SetParameters);
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x00038EBC File Offset: 0x000370BC
		internal static void Spring_EnableCollision(PhysicsJoint self)
		{
			method glue_Physcs_Spring_EnableCollision = PhysJoints.__N.Glue_Physcs_Spring_EnableCollision;
			calli(System.Void(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spring_EnableCollision);
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x00038EEC File Offset: 0x000370EC
		internal static void Spring_DisableCollision(PhysicsJoint self)
		{
			method glue_Physcs_Spring_DisableCollision = PhysJoints.__N.Glue_Physcs_Spring_DisableCollision;
			calli(System.Void(System.IntPtr), (self == null) ? IntPtr.Zero : self.native, glue_Physcs_Spring_DisableCollision);
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x00038F1C File Offset: 0x0003711C
		internal static JointMotion Generic_GetLinearMotion(PhysicsJoint self, int nAxis)
		{
			method glue_Physcs_Generic_GetLinearMotion = PhysJoints.__N.Glue_Physcs_Generic_GetLinearMotion;
			return calli(System.Int64(System.IntPtr,System.Int32), (self == null) ? IntPtr.Zero : self.native, nAxis, glue_Physcs_Generic_GetLinearMotion);
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x00038F4C File Offset: 0x0003714C
		internal static float Generic_GetLinearFrequency(PhysicsJoint self, int nAxis)
		{
			method glue_Physcs_Generic_GetLinearFrequency = PhysJoints.__N.Glue_Physcs_Generic_GetLinearFrequency;
			return calli(System.Single(System.IntPtr,System.Int32), (self == null) ? IntPtr.Zero : self.native, nAxis, glue_Physcs_Generic_GetLinearFrequency);
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x00038F7C File Offset: 0x0003717C
		internal static float Generic_GetLinearDampingRatio(PhysicsJoint self, int nAxis)
		{
			method glue_Physcs_Generic_GetLinearDampingRatio = PhysJoints.__N.Glue_Physcs_Generic_GetLinearDampingRatio;
			return calli(System.Single(System.IntPtr,System.Int32), (self == null) ? IntPtr.Zero : self.native, nAxis, glue_Physcs_Generic_GetLinearDampingRatio);
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x00038FAC File Offset: 0x000371AC
		internal static float Generic_GetLinearConstraintImpulse(PhysicsJoint self, int nAxis)
		{
			method glue_Physcs_Generic_GetLinearConstraintImpulse = PhysJoints.__N.Glue_Physcs_Generic_GetLinearConstraintImpulse;
			return calli(System.Single(System.IntPtr,System.Int32), (self == null) ? IntPtr.Zero : self.native, nAxis, glue_Physcs_Generic_GetLinearConstraintImpulse);
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x00038FDC File Offset: 0x000371DC
		internal static JointMotion Generic_GetAngularMotion(PhysicsJoint self, int nAxis)
		{
			method glue_Physcs_Generic_GetAngularMotion = PhysJoints.__N.Glue_Physcs_Generic_GetAngularMotion;
			return calli(System.Int64(System.IntPtr,System.Int32), (self == null) ? IntPtr.Zero : self.native, nAxis, glue_Physcs_Generic_GetAngularMotion);
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x0003900C File Offset: 0x0003720C
		internal static float Generic_GetAngularFrequency(PhysicsJoint self, int nAxis)
		{
			method glue_Physcs_Generic_GetAngularFrequency = PhysJoints.__N.Glue_Physcs_Generic_GetAngularFrequency;
			return calli(System.Single(System.IntPtr,System.Int32), (self == null) ? IntPtr.Zero : self.native, nAxis, glue_Physcs_Generic_GetAngularFrequency);
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x0003903C File Offset: 0x0003723C
		internal static float Generic_GetAngularDampingRatio(PhysicsJoint self, int nAxis)
		{
			method glue_Physcs_Generic_GetAngularDampingRatio = PhysJoints.__N.Glue_Physcs_Generic_GetAngularDampingRatio;
			return calli(System.Single(System.IntPtr,System.Int32), (self == null) ? IntPtr.Zero : self.native, nAxis, glue_Physcs_Generic_GetAngularDampingRatio);
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x0003906C File Offset: 0x0003726C
		internal static float Generic_GetMaxLinearConstraintImpulse(PhysicsJoint self, int nAxis)
		{
			method glue_Physcs_Generic_GetMaxLinearConstraintImpulse = PhysJoints.__N.Glue_Physcs_Generic_GetMaxLinearConstraintImpulse;
			return calli(System.Single(System.IntPtr,System.Int32), (self == null) ? IntPtr.Zero : self.native, nAxis, glue_Physcs_Generic_GetMaxLinearConstraintImpulse);
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x0003909C File Offset: 0x0003729C
		internal static float Generic_GetMaxAngularConstraintImpulse(PhysicsJoint self, int nAxis)
		{
			method glue_Physcs_Generic_GetMaxAngularConstraintImpulse = PhysJoints.__N.Glue_Physcs_Generic_GetMaxAngularConstraintImpulse;
			return calli(System.Single(System.IntPtr,System.Int32), (self == null) ? IntPtr.Zero : self.native, nAxis, glue_Physcs_Generic_GetMaxAngularConstraintImpulse);
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x000390CC File Offset: 0x000372CC
		internal static void Generic_SetLinearMotion(PhysicsJoint self, int nAxis, JointMotion nMotion)
		{
			method glue_Physcs_Generic_SetLinearMotion = PhysJoints.__N.Glue_Physcs_Generic_SetLinearMotion;
			calli(System.Void(System.IntPtr,System.Int32,System.Int64), (self == null) ? IntPtr.Zero : self.native, nAxis, (long)nMotion, glue_Physcs_Generic_SetLinearMotion);
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x00039100 File Offset: 0x00037300
		internal static void Generic_SetLinearFrequency(PhysicsJoint self, int nAxis, float flFrequency)
		{
			method glue_Physcs_Generic_SetLinearFrequency = PhysJoints.__N.Glue_Physcs_Generic_SetLinearFrequency;
			calli(System.Void(System.IntPtr,System.Int32,System.Single), (self == null) ? IntPtr.Zero : self.native, nAxis, flFrequency, glue_Physcs_Generic_SetLinearFrequency);
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x00039130 File Offset: 0x00037330
		internal static void Generic_SetLinearDampingRatio(PhysicsJoint self, int nAxis, float flDampingRatio)
		{
			method glue_Physcs_Generic_SetLinearDampingRatio = PhysJoints.__N.Glue_Physcs_Generic_SetLinearDampingRatio;
			calli(System.Void(System.IntPtr,System.Int32,System.Single), (self == null) ? IntPtr.Zero : self.native, nAxis, flDampingRatio, glue_Physcs_Generic_SetLinearDampingRatio);
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x00039160 File Offset: 0x00037360
		internal static void Generic_SetAngularMotion(PhysicsJoint self, int nAxis, JointMotion nMotion)
		{
			method glue_Physcs_Generic_SetAngularMotion = PhysJoints.__N.Glue_Physcs_Generic_SetAngularMotion;
			calli(System.Void(System.IntPtr,System.Int32,System.Int64), (self == null) ? IntPtr.Zero : self.native, nAxis, (long)nMotion, glue_Physcs_Generic_SetAngularMotion);
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x00039194 File Offset: 0x00037394
		internal static void Generic_SetAngularFrequency(PhysicsJoint self, int nAxis, float flFrequency)
		{
			method glue_Physcs_Generic_SetAngularFrequency = PhysJoints.__N.Glue_Physcs_Generic_SetAngularFrequency;
			calli(System.Void(System.IntPtr,System.Int32,System.Single), (self == null) ? IntPtr.Zero : self.native, nAxis, flFrequency, glue_Physcs_Generic_SetAngularFrequency);
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x000391C4 File Offset: 0x000373C4
		internal static void Generic_SetAngularDampingRatio(PhysicsJoint self, int nAxis, float flDampingRatio)
		{
			method glue_Physcs_Generic_SetAngularDampingRatio = PhysJoints.__N.Glue_Physcs_Generic_SetAngularDampingRatio;
			calli(System.Void(System.IntPtr,System.Int32,System.Single), (self == null) ? IntPtr.Zero : self.native, nAxis, flDampingRatio, glue_Physcs_Generic_SetAngularDampingRatio);
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x000391F4 File Offset: 0x000373F4
		internal static void Generic_SetMaxLinearConstraintImpulse(PhysicsJoint self, int nAxis, float flMaxLinearConstraintImpulse)
		{
			method glue_Physcs_Generic_SetMaxLinearConstraintImpulse = PhysJoints.__N.Glue_Physcs_Generic_SetMaxLinearConstraintImpulse;
			calli(System.Void(System.IntPtr,System.Int32,System.Single), (self == null) ? IntPtr.Zero : self.native, nAxis, flMaxLinearConstraintImpulse, glue_Physcs_Generic_SetMaxLinearConstraintImpulse);
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00039224 File Offset: 0x00037424
		internal static void Generic_SetMaxAngularConstraintImpulse(PhysicsJoint self, int nAxis, float flMaxAngularConstraintImpulse)
		{
			method glue_Physcs_Generic_SetMaxAngularConstraintImpulse = PhysJoints.__N.Glue_Physcs_Generic_SetMaxAngularConstraintImpulse;
			calli(System.Void(System.IntPtr,System.Int32,System.Single), (self == null) ? IntPtr.Zero : self.native, nAxis, flMaxAngularConstraintImpulse, glue_Physcs_Generic_SetMaxAngularConstraintImpulse);
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x00039254 File Offset: 0x00037454
		internal static void Generic_ScaleLambdas(PhysicsJoint self, float flSpeedup)
		{
			method glue_Physcs_Generic_ScaleLambdas = PhysJoints.__N.Glue_Physcs_Generic_ScaleLambdas;
			calli(System.Void(System.IntPtr,System.Single), (self == null) ? IntPtr.Zero : self.native, flSpeedup, glue_Physcs_Generic_ScaleLambdas);
		}

		// Token: 0x020001CF RID: 463
		internal static class __N
		{
			// Token: 0x04000EBB RID: 3771
			internal static method Glue_Physcs_AddWeldJoint;

			// Token: 0x04000EBC RID: 3772
			internal static method Glue_Physcs_AddRevoluteJoint;

			// Token: 0x04000EBD RID: 3773
			internal static method Glue_Physcs_AddPrismaticJoint;

			// Token: 0x04000EBE RID: 3774
			internal static method Glue_Physcs_AddConicalJoint;

			// Token: 0x04000EBF RID: 3775
			internal static method Glue_Physcs_AddSpringJoint;

			// Token: 0x04000EC0 RID: 3776
			internal static method Glue_Physcs_AddSphericalJoint;

			// Token: 0x04000EC1 RID: 3777
			internal static method Glue_Physcs_AddGenericJoint;

			// Token: 0x04000EC2 RID: 3778
			internal static method Glue_Physcs_RemoveJoint;

			// Token: 0x04000EC3 RID: 3779
			internal static method Glue_Physcs_Weld_GetJointFrame1;

			// Token: 0x04000EC4 RID: 3780
			internal static method Glue_Physcs_Weld_GetLocalJointFrame1;

			// Token: 0x04000EC5 RID: 3781
			internal static method Glue_Physcs_Weld_GetLocalJointFrame2;

			// Token: 0x04000EC6 RID: 3782
			internal static method Glue_Physcs_Weld_GetJointFrame2;

			// Token: 0x04000EC7 RID: 3783
			internal static method Glue_Physcs_Weld_SetLinearFrequency;

			// Token: 0x04000EC8 RID: 3784
			internal static method Glue_Physcs_Weld_GetLinearFrequency;

			// Token: 0x04000EC9 RID: 3785
			internal static method Glue_Physcs_Weld_SetLinearDampingRatio;

			// Token: 0x04000ECA RID: 3786
			internal static method Glue_Physcs_Weld_GetLinearDampingRatio;

			// Token: 0x04000ECB RID: 3787
			internal static method Glue_Physcs_Weld_SetMaxForce;

			// Token: 0x04000ECC RID: 3788
			internal static method Glue_Physcs_Weld_GetMaxForce;

			// Token: 0x04000ECD RID: 3789
			internal static method Glue_Physcs_Weld_SetAngularFrequency;

			// Token: 0x04000ECE RID: 3790
			internal static method Glue_Physcs_Weld_GetAngularFrequency;

			// Token: 0x04000ECF RID: 3791
			internal static method Glue_Physcs_Weld_SetAngularDampingRatio;

			// Token: 0x04000ED0 RID: 3792
			internal static method Glue_Physcs_Weld_GetAngularDampingRatio;

			// Token: 0x04000ED1 RID: 3793
			internal static method Glue_Physcs_Weld_SetMaxTorque;

			// Token: 0x04000ED2 RID: 3794
			internal static method Glue_Physcs_Weld_GetMaxTorque;

			// Token: 0x04000ED3 RID: 3795
			internal static method Glue_Physcs_Weld_Reset;

			// Token: 0x04000ED4 RID: 3796
			internal static method Glue_Physcs_Revolute_GetAnchor1;

			// Token: 0x04000ED5 RID: 3797
			internal static method Glue_Physcs_Revolute_GetLocalAnchor1;

			// Token: 0x04000ED6 RID: 3798
			internal static method Glue_Physcs_Revolute_GetAnchor2;

			// Token: 0x04000ED7 RID: 3799
			internal static method Glue_Physcs_Revolute_GetLocalAnchor2;

			// Token: 0x04000ED8 RID: 3800
			internal static method Glue_Physcs_Revolute_GetLocalJointFrame1;

			// Token: 0x04000ED9 RID: 3801
			internal static method Glue_Physcs_Revolute_GetJointFrame1;

			// Token: 0x04000EDA RID: 3802
			internal static method Glue_Physcs_Revolute_GetLocalJointFrame2;

			// Token: 0x04000EDB RID: 3803
			internal static method Glue_Physcs_Revolute_GetJointFrame2;

			// Token: 0x04000EDC RID: 3804
			internal static method Glue_Physcs_Revolute_SetMotorMode;

			// Token: 0x04000EDD RID: 3805
			internal static method Glue_Physcs_Revolute_GetMotorMode;

			// Token: 0x04000EDE RID: 3806
			internal static method Glue_Physcs_Revolute_SetMotorTargetAngle;

			// Token: 0x04000EDF RID: 3807
			internal static method Glue_Physcs_Revolute_GetMotorTargetAngle;

			// Token: 0x04000EE0 RID: 3808
			internal static method Glue_Physcs_Revolute_SetMotorFrequency;

			// Token: 0x04000EE1 RID: 3809
			internal static method Glue_Physcs_Revolute_GetMotorFrequency;

			// Token: 0x04000EE2 RID: 3810
			internal static method Glue_Physcs_Revolute_SetMotorDampingRatio;

			// Token: 0x04000EE3 RID: 3811
			internal static method Glue_Physcs_Revolute_GetMotorDampingRatio;

			// Token: 0x04000EE4 RID: 3812
			internal static method Glue_Physcs_Revolute_SetMotorTargetVelocity;

			// Token: 0x04000EE5 RID: 3813
			internal static method Glue_Physcs_Revolute_GetMotorTargetVelocity;

			// Token: 0x04000EE6 RID: 3814
			internal static method Glue_Physcs_Revolute_SetMotorMaxTorque;

			// Token: 0x04000EE7 RID: 3815
			internal static method Glue_Physcs_Revolute_GetMotorMaxTorque;

			// Token: 0x04000EE8 RID: 3816
			internal static method Glue_Physcs_Revolute_SetMotorFriction;

			// Token: 0x04000EE9 RID: 3817
			internal static method Glue_Physcs_Revolute_EnableLimit;

			// Token: 0x04000EEA RID: 3818
			internal static method Glue_Physcs_Revolute_DisableLimit;

			// Token: 0x04000EEB RID: 3819
			internal static method Glue_Physcs_Revolute_IsLimitEnabled;

			// Token: 0x04000EEC RID: 3820
			internal static method Glue_Physcs_Revolute_SetLimitRange;

			// Token: 0x04000EED RID: 3821
			internal static method Glue_Physcs_Revolute_GetLimitRange;

			// Token: 0x04000EEE RID: 3822
			internal static method Glue_Physcs_Revolute_GetAngle;

			// Token: 0x04000EEF RID: 3823
			internal static method Glue_Physcs_Revolute_GetAngleSpeed;

			// Token: 0x04000EF0 RID: 3824
			internal static method Glue_Physcs_Revolute_GetAngleAxis;

			// Token: 0x04000EF1 RID: 3825
			internal static method Glue_Physcs_Revolute_UseBlockSolver;

			// Token: 0x04000EF2 RID: 3826
			internal static method Glue_Physcs_Prismatic_GetLocalJointFrame1;

			// Token: 0x04000EF3 RID: 3827
			internal static method Glue_Physcs_Prismatic_GetJointFrame1;

			// Token: 0x04000EF4 RID: 3828
			internal static method Glue_Physcs_Prismatic_GetLocalJointFrame2;

			// Token: 0x04000EF5 RID: 3829
			internal static method Glue_Physcs_Prismatic_GetJointFrame2;

			// Token: 0x04000EF6 RID: 3830
			internal static method Glue_Physcs_Prismatic_GetMotorMode;

			// Token: 0x04000EF7 RID: 3831
			internal static method Glue_Physcs_Prismatic_GetMotorTargetOffset;

			// Token: 0x04000EF8 RID: 3832
			internal static method Glue_Physcs_Prismatic_GetMotorFrequency;

			// Token: 0x04000EF9 RID: 3833
			internal static method Glue_Physcs_Prismatic_GetMotorDampingRatio;

			// Token: 0x04000EFA RID: 3834
			internal static method Glue_Physcs_Prismatic_GetMotorTargetVelocity;

			// Token: 0x04000EFB RID: 3835
			internal static method Glue_Physcs_Prismatic_GetMotorMaxForce;

			// Token: 0x04000EFC RID: 3836
			internal static method Glue_Physcs_Prismatic_IsLimitEnabled;

			// Token: 0x04000EFD RID: 3837
			internal static method Glue_Physcs_Prismatic_GetLimitRange;

			// Token: 0x04000EFE RID: 3838
			internal static method Glue_Physcs_Prismatic_GetOffset;

			// Token: 0x04000EFF RID: 3839
			internal static method Glue_Physcs_Prismatic_GetOffsetSpeed;

			// Token: 0x04000F00 RID: 3840
			internal static method Glue_Physcs_Prismatic_GetOffsetAxis;

			// Token: 0x04000F01 RID: 3841
			internal static method Glue_Physcs_Prismatic_SetMotorMode;

			// Token: 0x04000F02 RID: 3842
			internal static method Glue_Physcs_Prismatic_SetMotorTargetOffset;

			// Token: 0x04000F03 RID: 3843
			internal static method Glue_Physcs_Prismatic_SetMotorFrequency;

			// Token: 0x04000F04 RID: 3844
			internal static method Glue_Physcs_Prismatic_SetMotorDampingRatio;

			// Token: 0x04000F05 RID: 3845
			internal static method Glue_Physcs_Prismatic_SetMotorTargetVelocity;

			// Token: 0x04000F06 RID: 3846
			internal static method Glue_Physcs_Prismatic_SetMotorMaxForce;

			// Token: 0x04000F07 RID: 3847
			internal static method Glue_Physcs_Prismatic_SetMotorFriction;

			// Token: 0x04000F08 RID: 3848
			internal static method Glue_Physcs_Prismatic_EnableLimit;

			// Token: 0x04000F09 RID: 3849
			internal static method Glue_Physcs_Prismatic_DisableLimit;

			// Token: 0x04000F0A RID: 3850
			internal static method Glue_Physcs_Prismatic_SetLimitRange;

			// Token: 0x04000F0B RID: 3851
			internal static method Glue_Physcs_Conical_GetLocalJointFrame1;

			// Token: 0x04000F0C RID: 3852
			internal static method Glue_Physcs_Conical_GetJointFrame1;

			// Token: 0x04000F0D RID: 3853
			internal static method Glue_Physcs_Conical_GetLocalJointFrame2;

			// Token: 0x04000F0E RID: 3854
			internal static method Glue_Physcs_Conical_GetJointFrame2;

			// Token: 0x04000F0F RID: 3855
			internal static method Glue_Physcs_Conical_GetMotorMode;

			// Token: 0x04000F10 RID: 3856
			internal static method Glue_Physcs_Conical_GetMotorTargetOrientation;

			// Token: 0x04000F11 RID: 3857
			internal static method Glue_Physcs_Conical_GetMotorFrequency;

			// Token: 0x04000F12 RID: 3858
			internal static method Glue_Physcs_Conical_GetMotorDampingRatio;

			// Token: 0x04000F13 RID: 3859
			internal static method Glue_Physcs_Conical_GetMotorTargetVelocity;

			// Token: 0x04000F14 RID: 3860
			internal static method Glue_Physcs_Conical_GetMotorMaxTorque;

			// Token: 0x04000F15 RID: 3861
			internal static method Glue_Physcs_Conical_IsTwistLimitEnabled;

			// Token: 0x04000F16 RID: 3862
			internal static method Glue_Physcs_Conical_GetTwistRange;

			// Token: 0x04000F17 RID: 3863
			internal static method Glue_Physcs_Conical_GetTwistAngle;

			// Token: 0x04000F18 RID: 3864
			internal static method Glue_Physcs_Conical_GetTwistTorque;

			// Token: 0x04000F19 RID: 3865
			internal static method Glue_Physcs_Conical_IsSwingLimitEnabled;

			// Token: 0x04000F1A RID: 3866
			internal static method Glue_Physcs_Conical_GetSwingLimit;

			// Token: 0x04000F1B RID: 3867
			internal static method Glue_Physcs_Conical_GetSwingAngle;

			// Token: 0x04000F1C RID: 3868
			internal static method Glue_Physcs_Conical_GetSwingTorque;

			// Token: 0x04000F1D RID: 3869
			internal static method Glue_Physcs_Conical_SetMotorMode;

			// Token: 0x04000F1E RID: 3870
			internal static method Glue_Physcs_Conical_SetMotorTargetOrientation;

			// Token: 0x04000F1F RID: 3871
			internal static method Glue_Physcs_Conical_SetMotorFrequency;

			// Token: 0x04000F20 RID: 3872
			internal static method Glue_Physcs_Conical_SetMotorDampingRatio;

			// Token: 0x04000F21 RID: 3873
			internal static method Glue_Physcs_Conical_SetMotorTargetVelocity;

			// Token: 0x04000F22 RID: 3874
			internal static method Glue_Physcs_Conical_SetMotorMaxTorque;

			// Token: 0x04000F23 RID: 3875
			internal static method Glue_Physcs_Conical_SetMotorFriction;

			// Token: 0x04000F24 RID: 3876
			internal static method Glue_Physcs_Conical_EnableTwistLimit;

			// Token: 0x04000F25 RID: 3877
			internal static method Glue_Physcs_Conical_DisableTwistLimit;

			// Token: 0x04000F26 RID: 3878
			internal static method Glue_Physcs_Conical_SetTwistRange;

			// Token: 0x04000F27 RID: 3879
			internal static method Glue_Physcs_Conical_EnableSwingLimit;

			// Token: 0x04000F28 RID: 3880
			internal static method Glue_Physcs_Conical_DisableSwingLimit;

			// Token: 0x04000F29 RID: 3881
			internal static method Glue_Physcs_Conical_SetSwingLimit;

			// Token: 0x04000F2A RID: 3882
			internal static method Glue_Physcs_Spherical_GetLocalJointFrame1;

			// Token: 0x04000F2B RID: 3883
			internal static method Glue_Physcs_Spherical_GetJointFrame1;

			// Token: 0x04000F2C RID: 3884
			internal static method Glue_Physcs_Spherical_GetLocalJointFrame2;

			// Token: 0x04000F2D RID: 3885
			internal static method Glue_Physcs_Spherical_GetJointFrame2;

			// Token: 0x04000F2E RID: 3886
			internal static method Glue_Physcs_Spherical_GetMotorMode;

			// Token: 0x04000F2F RID: 3887
			internal static method Glue_Physcs_Spherical_GetMotorTargetOrientation;

			// Token: 0x04000F30 RID: 3888
			internal static method Glue_Physcs_Spherical_GetMotorFrequency;

			// Token: 0x04000F31 RID: 3889
			internal static method Glue_Physcs_Spherical_GetMotorDampingRatio;

			// Token: 0x04000F32 RID: 3890
			internal static method Glue_Physcs_Spherical_GetMotorTargetVelocity;

			// Token: 0x04000F33 RID: 3891
			internal static method Glue_Physcs_Spherical_GetMotorMaxTorque;

			// Token: 0x04000F34 RID: 3892
			internal static method Glue_Physcs_Spherical_SetMotorMode;

			// Token: 0x04000F35 RID: 3893
			internal static method Glue_Physcs_Spherical_SetMotorTargetOrientation;

			// Token: 0x04000F36 RID: 3894
			internal static method Glue_Physcs_Spherical_SetMotorFrequency;

			// Token: 0x04000F37 RID: 3895
			internal static method Glue_Physcs_Spherical_SetMotorDampingRatio;

			// Token: 0x04000F38 RID: 3896
			internal static method Glue_Physcs_Spherical_SetMotorTargetVelocity;

			// Token: 0x04000F39 RID: 3897
			internal static method Glue_Physcs_Spherical_SetMotorMaxTorque;

			// Token: 0x04000F3A RID: 3898
			internal static method Glue_Physcs_Spherical_SetMotorFriction;

			// Token: 0x04000F3B RID: 3899
			internal static method Glue_Physcs_Spring_GetFrequency;

			// Token: 0x04000F3C RID: 3900
			internal static method Glue_Physcs_Spring_GetDampingRatio;

			// Token: 0x04000F3D RID: 3901
			internal static method Glue_Physcs_Spring_GetReferenceMass;

			// Token: 0x04000F3E RID: 3902
			internal static method Glue_Physcs_Spring_GetRestLengthMin;

			// Token: 0x04000F3F RID: 3903
			internal static method Glue_Physcs_Spring_GetRestLengthMax;

			// Token: 0x04000F40 RID: 3904
			internal static method Glue_Physcs_Spring_GetParameters;

			// Token: 0x04000F41 RID: 3905
			internal static method Glue_Physcs_Spring_IsCollisionEnabled;

			// Token: 0x04000F42 RID: 3906
			internal static method Glue_Physcs_Spring_SetFrequency;

			// Token: 0x04000F43 RID: 3907
			internal static method Glue_Physcs_Spring_SetDampingRatio;

			// Token: 0x04000F44 RID: 3908
			internal static method Glue_Physcs_Spring_SetReferenceMass;

			// Token: 0x04000F45 RID: 3909
			internal static method Glue_Physcs_Spring_SetRestLength;

			// Token: 0x04000F46 RID: 3910
			internal static method Glue_Physcs_Spring_SetParameters;

			// Token: 0x04000F47 RID: 3911
			internal static method Glue_Physcs_Spring_EnableCollision;

			// Token: 0x04000F48 RID: 3912
			internal static method Glue_Physcs_Spring_DisableCollision;

			// Token: 0x04000F49 RID: 3913
			internal static method Glue_Physcs_Generic_GetLinearMotion;

			// Token: 0x04000F4A RID: 3914
			internal static method Glue_Physcs_Generic_GetLinearFrequency;

			// Token: 0x04000F4B RID: 3915
			internal static method Glue_Physcs_Generic_GetLinearDampingRatio;

			// Token: 0x04000F4C RID: 3916
			internal static method Glue_Physcs_Generic_GetLinearConstraintImpulse;

			// Token: 0x04000F4D RID: 3917
			internal static method Glue_Physcs_Generic_GetAngularMotion;

			// Token: 0x04000F4E RID: 3918
			internal static method Glue_Physcs_Generic_GetAngularFrequency;

			// Token: 0x04000F4F RID: 3919
			internal static method Glue_Physcs_Generic_GetAngularDampingRatio;

			// Token: 0x04000F50 RID: 3920
			internal static method Glue_Physcs_Generic_GetMaxLinearConstraintImpulse;

			// Token: 0x04000F51 RID: 3921
			internal static method Glue_Physcs_Generic_GetMaxAngularConstraintImpulse;

			// Token: 0x04000F52 RID: 3922
			internal static method Glue_Physcs_Generic_SetLinearMotion;

			// Token: 0x04000F53 RID: 3923
			internal static method Glue_Physcs_Generic_SetLinearFrequency;

			// Token: 0x04000F54 RID: 3924
			internal static method Glue_Physcs_Generic_SetLinearDampingRatio;

			// Token: 0x04000F55 RID: 3925
			internal static method Glue_Physcs_Generic_SetAngularMotion;

			// Token: 0x04000F56 RID: 3926
			internal static method Glue_Physcs_Generic_SetAngularFrequency;

			// Token: 0x04000F57 RID: 3927
			internal static method Glue_Physcs_Generic_SetAngularDampingRatio;

			// Token: 0x04000F58 RID: 3928
			internal static method Glue_Physcs_Generic_SetMaxLinearConstraintImpulse;

			// Token: 0x04000F59 RID: 3929
			internal static method Glue_Physcs_Generic_SetMaxAngularConstraintImpulse;

			// Token: 0x04000F5A RID: 3930
			internal static method Glue_Physcs_Generic_ScaleLambdas;
		}
	}
}
