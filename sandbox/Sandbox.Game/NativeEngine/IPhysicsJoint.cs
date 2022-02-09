using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000050 RID: 80
	internal struct IPhysicsJoint
	{
		// Token: 0x06000AEE RID: 2798 RVA: 0x0003AF28 File Offset: 0x00039128
		public static implicit operator IntPtr(IPhysicsJoint value)
		{
			return value.self;
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x0003AF30 File Offset: 0x00039130
		public static implicit operator IPhysicsJoint(IntPtr value)
		{
			return new IPhysicsJoint
			{
				self = value
			};
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x0003AF4E File Offset: 0x0003914E
		public static bool operator ==(IPhysicsJoint c1, IPhysicsJoint c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x0003AF61 File Offset: 0x00039161
		public static bool operator !=(IPhysicsJoint c1, IPhysicsJoint c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x0003AF74 File Offset: 0x00039174
		public override bool Equals(object obj)
		{
			if (obj is IPhysicsJoint)
			{
				IPhysicsJoint c = (IPhysicsJoint)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x0003AF9E File Offset: 0x0003919E
		internal IPhysicsJoint(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x0003AFA8 File Offset: 0x000391A8
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
			defaultInterpolatedStringHandler.AppendLiteral("IPhysicsJoint ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000AF5 RID: 2805 RVA: 0x0003AFE4 File Offset: 0x000391E4
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000AF6 RID: 2806 RVA: 0x0003AFF6 File Offset: 0x000391F6
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x0003B001 File Offset: 0x00039201
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x0003B014 File Offset: 0x00039214
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("IPhysicsJoint was null when calling " + n);
			}
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x0003B02F File Offset: 0x0003922F
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x0003B03C File Offset: 0x0003923C
		internal readonly PhysicsBody GetBody1()
		{
			this.NullCheck("GetBody1");
			method iphysc_GetBody = IPhysicsJoint.__N.IPhysc_GetBody1;
			return HandleIndex.Get<PhysicsBody>(calli(System.Int32(System.IntPtr), this.self, iphysc_GetBody));
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x0003B06C File Offset: 0x0003926C
		internal readonly PhysicsBody GetBody2()
		{
			this.NullCheck("GetBody2");
			method iphysc_GetBody = IPhysicsJoint.__N.IPhysc_GetBody2;
			return HandleIndex.Get<PhysicsBody>(calli(System.Int32(System.IntPtr), this.self, iphysc_GetBody));
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x0003B09C File Offset: 0x0003929C
		internal readonly Vector3 GetAnchor1()
		{
			this.NullCheck("GetAnchor1");
			method iphysc_GetAnchor = IPhysicsJoint.__N.IPhysc_GetAnchor1;
			return calli(Vector3(System.IntPtr), this.self, iphysc_GetAnchor);
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x0003B0C8 File Offset: 0x000392C8
		internal readonly Vector3 GetLocalAnchor1()
		{
			this.NullCheck("GetLocalAnchor1");
			method iphysc_GetLocalAnchor = IPhysicsJoint.__N.IPhysc_GetLocalAnchor1;
			return calli(Vector3(System.IntPtr), this.self, iphysc_GetLocalAnchor);
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x0003B0F4 File Offset: 0x000392F4
		internal unsafe readonly void SetLocalAnchor1(Vector3 p1)
		{
			this.NullCheck("SetLocalAnchor1");
			method iphysc_SetLocalAnchor = IPhysicsJoint.__N.IPhysc_SetLocalAnchor1;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &p1, iphysc_SetLocalAnchor);
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x0003B124 File Offset: 0x00039324
		internal readonly Vector3 GetAnchor2()
		{
			this.NullCheck("GetAnchor2");
			method iphysc_GetAnchor = IPhysicsJoint.__N.IPhysc_GetAnchor2;
			return calli(Vector3(System.IntPtr), this.self, iphysc_GetAnchor);
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x0003B150 File Offset: 0x00039350
		internal readonly Vector3 GetLocalAnchor2()
		{
			this.NullCheck("GetLocalAnchor2");
			method iphysc_GetLocalAnchor = IPhysicsJoint.__N.IPhysc_GetLocalAnchor2;
			return calli(Vector3(System.IntPtr), this.self, iphysc_GetLocalAnchor);
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x0003B17C File Offset: 0x0003937C
		internal unsafe readonly void SetLocalAnchor2(Vector3 p2)
		{
			this.NullCheck("SetLocalAnchor2");
			method iphysc_SetLocalAnchor = IPhysicsJoint.__N.IPhysc_SetLocalAnchor2;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &p2, iphysc_SetLocalAnchor);
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x0003B1AC File Offset: 0x000393AC
		internal readonly Rotation GetJointFrame1()
		{
			this.NullCheck("GetJointFrame1");
			method iphysc_GetJointFrame = IPhysicsJoint.__N.IPhysc_GetJointFrame1;
			return calli(Rotation(System.IntPtr), this.self, iphysc_GetJointFrame);
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x0003B1D8 File Offset: 0x000393D8
		internal readonly Rotation GetLocalJointFrame1()
		{
			this.NullCheck("GetLocalJointFrame1");
			method iphysc_GetLocalJointFrame = IPhysicsJoint.__N.IPhysc_GetLocalJointFrame1;
			return calli(Rotation(System.IntPtr), this.self, iphysc_GetLocalJointFrame);
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x0003B204 File Offset: 0x00039404
		internal unsafe readonly void SetLocalJointFrame1(Rotation q)
		{
			this.NullCheck("SetLocalJointFrame1");
			method iphysc_SetLocalJointFrame = IPhysicsJoint.__N.IPhysc_SetLocalJointFrame1;
			calli(System.Void(System.IntPtr,Rotation*), this.self, &q, iphysc_SetLocalJointFrame);
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x0003B234 File Offset: 0x00039434
		internal readonly Rotation GetJointFrame2()
		{
			this.NullCheck("GetJointFrame2");
			method iphysc_GetJointFrame = IPhysicsJoint.__N.IPhysc_GetJointFrame2;
			return calli(Rotation(System.IntPtr), this.self, iphysc_GetJointFrame);
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x0003B260 File Offset: 0x00039460
		internal readonly Rotation GetLocalJointFrame2()
		{
			this.NullCheck("GetLocalJointFrame2");
			method iphysc_GetLocalJointFrame = IPhysicsJoint.__N.IPhysc_GetLocalJointFrame2;
			return calli(Rotation(System.IntPtr), this.self, iphysc_GetLocalJointFrame);
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x0003B28C File Offset: 0x0003948C
		internal unsafe readonly void SetLocalJointFrame2(Rotation q)
		{
			this.NullCheck("SetLocalJointFrame2");
			method iphysc_SetLocalJointFrame = IPhysicsJoint.__N.IPhysc_SetLocalJointFrame2;
			calli(System.Void(System.IntPtr,Rotation*), this.self, &q, iphysc_SetLocalJointFrame);
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x0003B2BC File Offset: 0x000394BC
		internal readonly void EnableCollision()
		{
			this.NullCheck("EnableCollision");
			method iphysc_EnableCollision = IPhysicsJoint.__N.IPhysc_EnableCollision;
			calli(System.Void(System.IntPtr), this.self, iphysc_EnableCollision);
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x0003B2E8 File Offset: 0x000394E8
		internal readonly void DisableCollision()
		{
			this.NullCheck("DisableCollision");
			method iphysc_DisableCollision = IPhysicsJoint.__N.IPhysc_DisableCollision;
			calli(System.Void(System.IntPtr), this.self, iphysc_DisableCollision);
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x0003B314 File Offset: 0x00039514
		internal readonly bool IsCollisionEnabled()
		{
			this.NullCheck("IsCollisionEnabled");
			method iphysc_f = IPhysicsJoint.__N.IPhysc_f2;
			return calli(System.Int32(System.IntPtr), this.self, iphysc_f) > 0;
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x0003B344 File Offset: 0x00039544
		internal readonly void EnableLinearConstraint()
		{
			this.NullCheck("EnableLinearConstraint");
			method iphysc_EnableLinearConstraint = IPhysicsJoint.__N.IPhysc_EnableLinearConstraint;
			calli(System.Void(System.IntPtr), this.self, iphysc_EnableLinearConstraint);
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x0003B370 File Offset: 0x00039570
		internal readonly void DisableLinearConstraint()
		{
			this.NullCheck("DisableLinearConstraint");
			method iphysc_DisableLinearConstraint = IPhysicsJoint.__N.IPhysc_DisableLinearConstraint;
			calli(System.Void(System.IntPtr), this.self, iphysc_DisableLinearConstraint);
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x0003B39C File Offset: 0x0003959C
		internal readonly bool IsLinearConstraintEnabled()
		{
			this.NullCheck("IsLinearConstraintEnabled");
			method iphysc_IsLinearConstraintEnabled = IPhysicsJoint.__N.IPhysc_IsLinearConstraintEnabled;
			return calli(System.Int32(System.IntPtr), this.self, iphysc_IsLinearConstraintEnabled) > 0;
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x0003B3CC File Offset: 0x000395CC
		internal readonly float GetLinearConstraintImpulse(int nAxis)
		{
			this.NullCheck("GetLinearConstraintImpulse");
			method iphysc_GetLinearConstraintImpulse = IPhysicsJoint.__N.IPhysc_GetLinearConstraintImpulse;
			return calli(System.Single(System.IntPtr,System.Int32), this.self, nAxis, iphysc_GetLinearConstraintImpulse);
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x0003B3F8 File Offset: 0x000395F8
		internal readonly float GetLinearConstraintImpulse()
		{
			this.NullCheck("GetLinearConstraintImpulse");
			method iphysc_f = IPhysicsJoint.__N.IPhysc_f3;
			return calli(System.Single(System.IntPtr), this.self, iphysc_f);
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x0003B424 File Offset: 0x00039624
		internal readonly void SetMaxLinearConstraintImpulse(float flMaxLinearConstraintImpulse)
		{
			this.NullCheck("SetMaxLinearConstraintImpulse");
			method iphysc_SetMaxLinearConstraintImpulse = IPhysicsJoint.__N.IPhysc_SetMaxLinearConstraintImpulse;
			calli(System.Void(System.IntPtr,System.Single), this.self, flMaxLinearConstraintImpulse, iphysc_SetMaxLinearConstraintImpulse);
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x0003B450 File Offset: 0x00039650
		internal readonly float GetMaxLinearConstraintImpulse()
		{
			this.NullCheck("GetMaxLinearConstraintImpulse");
			method iphysc_GetMaxLinearConstraintImpulse = IPhysicsJoint.__N.IPhysc_GetMaxLinearConstraintImpulse;
			return calli(System.Single(System.IntPtr), this.self, iphysc_GetMaxLinearConstraintImpulse);
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x0003B47C File Offset: 0x0003967C
		internal readonly void EnableAngularConstraint()
		{
			this.NullCheck("EnableAngularConstraint");
			method iphysc_EnableAngularConstraint = IPhysicsJoint.__N.IPhysc_EnableAngularConstraint;
			calli(System.Void(System.IntPtr), this.self, iphysc_EnableAngularConstraint);
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x0003B4A8 File Offset: 0x000396A8
		internal readonly void DisableAngularConstraint()
		{
			this.NullCheck("DisableAngularConstraint");
			method iphysc_DisableAngularConstraint = IPhysicsJoint.__N.IPhysc_DisableAngularConstraint;
			calli(System.Void(System.IntPtr), this.self, iphysc_DisableAngularConstraint);
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x0003B4D4 File Offset: 0x000396D4
		internal readonly bool IsAngularConstraintEnabled()
		{
			this.NullCheck("IsAngularConstraintEnabled");
			method iphysc_IsAngularConstraintEnabled = IPhysicsJoint.__N.IPhysc_IsAngularConstraintEnabled;
			return calli(System.Int32(System.IntPtr), this.self, iphysc_IsAngularConstraintEnabled) > 0;
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x0003B504 File Offset: 0x00039704
		internal readonly float GetAngularConstraintImpulse()
		{
			this.NullCheck("GetAngularConstraintImpulse");
			method iphysc_GetAngularConstraintImpulse = IPhysicsJoint.__N.IPhysc_GetAngularConstraintImpulse;
			return calli(System.Single(System.IntPtr), this.self, iphysc_GetAngularConstraintImpulse);
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x0003B530 File Offset: 0x00039730
		internal readonly void SetMaxAngularConstraintImpulse(float flMaxAngularConstraintImpulse)
		{
			this.NullCheck("SetMaxAngularConstraintImpulse");
			method iphysc_SetMaxAngularConstraintImpulse = IPhysicsJoint.__N.IPhysc_SetMaxAngularConstraintImpulse;
			calli(System.Void(System.IntPtr,System.Single), this.self, flMaxAngularConstraintImpulse, iphysc_SetMaxAngularConstraintImpulse);
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x0003B55C File Offset: 0x0003975C
		internal readonly float GetMaxAngularConstraintImpulse()
		{
			this.NullCheck("GetMaxAngularConstraintImpulse");
			method iphysc_GetMaxAngularConstraintImpulse = IPhysicsJoint.__N.IPhysc_GetMaxAngularConstraintImpulse;
			return calli(System.Single(System.IntPtr), this.self, iphysc_GetMaxAngularConstraintImpulse);
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x0003B588 File Offset: 0x00039788
		internal readonly void Activate()
		{
			this.NullCheck("Activate");
			method iphysc_Activate = IPhysicsJoint.__N.IPhysc_Activate;
			calli(System.Void(System.IntPtr), this.self, iphysc_Activate);
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x0003B5B4 File Offset: 0x000397B4
		internal readonly void Deactivate()
		{
			this.NullCheck("Deactivate");
			method iphysc_Deactivate = IPhysicsJoint.__N.IPhysc_Deactivate;
			calli(System.Void(System.IntPtr), this.self, iphysc_Deactivate);
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x0003B5E0 File Offset: 0x000397E0
		internal readonly bool IsActive()
		{
			this.NullCheck("IsActive");
			method iphysc_IsActive = IPhysicsJoint.__N.IPhysc_IsActive;
			return calli(System.Int32(System.IntPtr), this.self, iphysc_IsActive) > 0;
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x0003B610 File Offset: 0x00039810
		internal readonly PhysicsJointType GetType_Native()
		{
			this.NullCheck("GetType_Native");
			method iphysc_f = IPhysicsJoint.__N.IPhysc_f4;
			return calli(System.Int64(System.IntPtr), this.self, iphysc_f);
		}

		// Token: 0x040000BE RID: 190
		internal IntPtr self;

		// Token: 0x020001D5 RID: 469
		internal static class __N
		{
			// Token: 0x04000FD9 RID: 4057
			internal static method IPhysc_GetBody1;

			// Token: 0x04000FDA RID: 4058
			internal static method IPhysc_GetBody2;

			// Token: 0x04000FDB RID: 4059
			internal static method IPhysc_GetAnchor1;

			// Token: 0x04000FDC RID: 4060
			internal static method IPhysc_GetLocalAnchor1;

			// Token: 0x04000FDD RID: 4061
			internal static method IPhysc_SetLocalAnchor1;

			// Token: 0x04000FDE RID: 4062
			internal static method IPhysc_GetAnchor2;

			// Token: 0x04000FDF RID: 4063
			internal static method IPhysc_GetLocalAnchor2;

			// Token: 0x04000FE0 RID: 4064
			internal static method IPhysc_SetLocalAnchor2;

			// Token: 0x04000FE1 RID: 4065
			internal static method IPhysc_GetJointFrame1;

			// Token: 0x04000FE2 RID: 4066
			internal static method IPhysc_GetLocalJointFrame1;

			// Token: 0x04000FE3 RID: 4067
			internal static method IPhysc_SetLocalJointFrame1;

			// Token: 0x04000FE4 RID: 4068
			internal static method IPhysc_GetJointFrame2;

			// Token: 0x04000FE5 RID: 4069
			internal static method IPhysc_GetLocalJointFrame2;

			// Token: 0x04000FE6 RID: 4070
			internal static method IPhysc_SetLocalJointFrame2;

			// Token: 0x04000FE7 RID: 4071
			internal static method IPhysc_EnableCollision;

			// Token: 0x04000FE8 RID: 4072
			internal static method IPhysc_DisableCollision;

			// Token: 0x04000FE9 RID: 4073
			internal static method IPhysc_f2;

			// Token: 0x04000FEA RID: 4074
			internal static method IPhysc_EnableLinearConstraint;

			// Token: 0x04000FEB RID: 4075
			internal static method IPhysc_DisableLinearConstraint;

			// Token: 0x04000FEC RID: 4076
			internal static method IPhysc_IsLinearConstraintEnabled;

			// Token: 0x04000FED RID: 4077
			internal static method IPhysc_GetLinearConstraintImpulse;

			// Token: 0x04000FEE RID: 4078
			internal static method IPhysc_f3;

			// Token: 0x04000FEF RID: 4079
			internal static method IPhysc_SetMaxLinearConstraintImpulse;

			// Token: 0x04000FF0 RID: 4080
			internal static method IPhysc_GetMaxLinearConstraintImpulse;

			// Token: 0x04000FF1 RID: 4081
			internal static method IPhysc_EnableAngularConstraint;

			// Token: 0x04000FF2 RID: 4082
			internal static method IPhysc_DisableAngularConstraint;

			// Token: 0x04000FF3 RID: 4083
			internal static method IPhysc_IsAngularConstraintEnabled;

			// Token: 0x04000FF4 RID: 4084
			internal static method IPhysc_GetAngularConstraintImpulse;

			// Token: 0x04000FF5 RID: 4085
			internal static method IPhysc_SetMaxAngularConstraintImpulse;

			// Token: 0x04000FF6 RID: 4086
			internal static method IPhysc_GetMaxAngularConstraintImpulse;

			// Token: 0x04000FF7 RID: 4087
			internal static method IPhysc_Activate;

			// Token: 0x04000FF8 RID: 4088
			internal static method IPhysc_Deactivate;

			// Token: 0x04000FF9 RID: 4089
			internal static method IPhysc_IsActive;

			// Token: 0x04000FFA RID: 4090
			internal static method IPhysc_f4;
		}
	}
}
