using System;
using System.Collections.Generic;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020000E2 RID: 226
	public static class PhysicsWorld
	{
		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x0600136E RID: 4974 RVA: 0x0004F36D File Offset: 0x0004D56D
		internal static IVPhysics2World world
		{
			get
			{
				return GameGlue.GetCurrentPhysicsWorld();
			}
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x0600136F RID: 4975 RVA: 0x0004F374 File Offset: 0x0004D574
		public static IEnumerable<PhysicsBody> Bodies
		{
			get
			{
				int bodyCount = PhysicsWorld.BodyCount;
				int num;
				for (int i = 0; i < bodyCount; i = num)
				{
					yield return PhysicsWorld.GetBody(i);
					num = i + 1;
				}
				yield break;
			}
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06001370 RID: 4976 RVA: 0x0004F380 File Offset: 0x0004D580
		public static int BodyCount
		{
			get
			{
				return PhysicsWorld.world.GetBodyCount();
			}
		}

		// Token: 0x06001371 RID: 4977 RVA: 0x0004F39C File Offset: 0x0004D59C
		public static PhysicsBody GetBody(int bodyIndex)
		{
			return PhysicsWorld.world.GetBody(bodyIndex);
		}

		// Token: 0x06001372 RID: 4978 RVA: 0x0004F3B8 File Offset: 0x0004D5B8
		public static PhysicsBody AddBody()
		{
			return PhysicsWorld.world.AddBody();
		}

		// Token: 0x06001373 RID: 4979 RVA: 0x0004F3D4 File Offset: 0x0004D5D4
		public static PhysicsBody AddBody(Vector3 position, Rotation rotation)
		{
			return PhysicsWorld.world.AddBody(position, rotation);
		}

		// Token: 0x06001374 RID: 4980 RVA: 0x0004F3F0 File Offset: 0x0004D5F0
		public static void RemoveBody(PhysicsBody body)
		{
			PhysicsWorld.world.RemoveBody(body);
		}

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x06001375 RID: 4981 RVA: 0x0004F40C File Offset: 0x0004D60C
		public static PhysicsBody WorldBody
		{
			get
			{
				return PhysicsWorld.world.GetWorldReferenceBody();
			}
		}

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x06001376 RID: 4982 RVA: 0x0004F428 File Offset: 0x0004D628
		public static int JointCount
		{
			get
			{
				return PhysicsWorld.world.GetJointCount();
			}
		}

		// Token: 0x06001377 RID: 4983 RVA: 0x0004F444 File Offset: 0x0004D644
		public static PhysicsJoint GetJoint(int jointIndex)
		{
			return PhysicsWorld.world.GetJoint(jointIndex);
		}

		// Token: 0x06001378 RID: 4984 RVA: 0x0004F460 File Offset: 0x0004D660
		public static bool RemoveJoint(PhysicsJoint joint)
		{
			return PhysicsWorld.world.RemoveJoint(joint);
		}

		// Token: 0x06001379 RID: 4985 RVA: 0x0004F47C File Offset: 0x0004D67C
		public static void RemoveContacts(PhysicsBody body1, PhysicsBody body2)
		{
			if (body1.IsValid() && body2.IsValid())
			{
				PhysicsWorld.world.RemoveContacts(body1, body2);
			}
		}

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x0600137A RID: 4986 RVA: 0x0004F4A8 File Offset: 0x0004D6A8
		// (set) Token: 0x0600137B RID: 4987 RVA: 0x0004F4C4 File Offset: 0x0004D6C4
		public static Vector3 Gravity
		{
			get
			{
				return PhysicsWorld.world.GetGravity();
			}
			set
			{
				PhysicsWorld.world.SetGravity(value);
			}
		}

		// Token: 0x0600137C RID: 4988 RVA: 0x0004F4DF File Offset: 0x0004D6DF
		public static void UseDefaultGravity()
		{
			PhysicsWorld.Gravity = Vector3.Down * 800f;
		}

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x0600137D RID: 4989 RVA: 0x0004F4F8 File Offset: 0x0004D6F8
		// (set) Token: 0x0600137E RID: 4990 RVA: 0x0004F512 File Offset: 0x0004D712
		public static bool Sleeping
		{
			get
			{
				return PhysicsWorld.world.IsSleepingEnabled();
			}
			set
			{
				PhysicsWorld.SetSleeping(value);
			}
		}

		// Token: 0x0600137F RID: 4991 RVA: 0x0004F51C File Offset: 0x0004D71C
		internal static void SetSleeping(bool enabled)
		{
			if (enabled)
			{
				PhysicsWorld.world.EnableSleeping();
				return;
			}
			PhysicsWorld.world.DisableSleeping();
		}

		// Token: 0x06001380 RID: 4992 RVA: 0x0004F547 File Offset: 0x0004D747
		public static void WakeAllBodies()
		{
			GameGlue.PhysicsWakeAllBodies(PhysicsWorld.world);
		}
	}
}
