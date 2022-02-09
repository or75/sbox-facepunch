using System;
using System.Collections.Generic;
using NativeEngine;

namespace Sandbox
{
	/// <summary>
	/// Represets a set of <see cref="T:Sandbox.PhysicsBody">PhysicsBody</see> objects.
	/// </summary>
	// Token: 0x020000DC RID: 220
	public class PhysicsGroup : IHandle
	{
		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x0600133A RID: 4922 RVA: 0x0004EF6F File Offset: 0x0004D16F
		// (set) Token: 0x0600133B RID: 4923 RVA: 0x0004EF77 File Offset: 0x0004D177
		internal int HandleValue { get; set; }

		// Token: 0x0600133C RID: 4924 RVA: 0x0004EF80 File Offset: 0x0004D180
		void IHandle.HandleInit(IntPtr ptr)
		{
			this.native = ptr;
		}

		// Token: 0x0600133D RID: 4925 RVA: 0x0004EF8E File Offset: 0x0004D18E
		void IHandle.HandleDestroy()
		{
			this.native = IntPtr.Zero;
		}

		// Token: 0x0600133E RID: 4926 RVA: 0x0004EFA0 File Offset: 0x0004D1A0
		bool IHandle.HandleValid()
		{
			return !this.native.IsNull;
		}

		// Token: 0x0600133F RID: 4927 RVA: 0x0004EFB0 File Offset: 0x0004D1B0
		internal PhysicsGroup()
		{
		}

		// Token: 0x06001340 RID: 4928 RVA: 0x0004EFB8 File Offset: 0x0004D1B8
		internal PhysicsGroup(HandleCreationData _)
		{
		}

		// Token: 0x170002C3 RID: 707
		// (set) Token: 0x06001341 RID: 4929 RVA: 0x0004EFC0 File Offset: 0x0004D1C0
		public Vector3 Velocity
		{
			set
			{
				this.native.SetVelocity(value);
			}
		}

		// Token: 0x170002C4 RID: 708
		// (set) Token: 0x06001342 RID: 4930 RVA: 0x0004EFCE File Offset: 0x0004D1CE
		public Vector3 AngularVelocity
		{
			set
			{
				this.native.SetAngularVelocity(value);
			}
		}

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x06001343 RID: 4931 RVA: 0x0004EFDC File Offset: 0x0004D1DC
		public Vector3 Pos
		{
			get
			{
				return this.native.GetOrigin();
			}
		}

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x06001344 RID: 4932 RVA: 0x0004EFE9 File Offset: 0x0004D1E9
		public Vector3 MassCenter
		{
			get
			{
				return this.native.GetMassCenter();
			}
		}

		// Token: 0x06001345 RID: 4933 RVA: 0x0004EFF6 File Offset: 0x0004D1F6
		public void AddVelocity(Vector3 vel)
		{
			this.native.AddVelocity(vel);
		}

		// Token: 0x06001346 RID: 4934 RVA: 0x0004F004 File Offset: 0x0004D204
		public void AddAngularVelocity(Vector3 vel)
		{
			this.native.AddAngularVelocity(vel);
		}

		// Token: 0x06001347 RID: 4935 RVA: 0x0004F014 File Offset: 0x0004D214
		public void ApplyImpulse(Vector3 vel, bool withMass = false)
		{
			for (int i = 0; i < this.BodyCount; i++)
			{
				PhysicsBody body = this.GetBody(i);
				if (body.IsValid())
				{
					if (withMass)
					{
						body.ApplyImpulse(vel * body.Mass);
					}
					else
					{
						body.ApplyImpulse(vel);
					}
				}
			}
		}

		// Token: 0x06001348 RID: 4936 RVA: 0x0004F060 File Offset: 0x0004D260
		public void ApplyAngularImpulse(Vector3 vel, bool withMass = false)
		{
			for (int i = 0; i < this.BodyCount; i++)
			{
				PhysicsBody body = this.GetBody(i);
				if (body.IsValid())
				{
					if (withMass)
					{
						body.ApplyAngularImpulse(vel * body.Mass);
					}
					else
					{
						body.ApplyAngularImpulse(vel);
					}
				}
			}
		}

		/// <summary>
		/// Wake all physics bodies of this physics group. Physics bodies automatically go to sleep after a certain amount of time of inactivity to save on performance.
		/// </summary>
		// Token: 0x06001349 RID: 4937 RVA: 0x0004F0AC File Offset: 0x0004D2AC
		public void Wake()
		{
			this.native.WakeUp();
		}

		/// <summary>
		/// Put all physics bodies of this physics group to sleep. Physics bodies automatically go to sleep after a certain amount of time of inactivity to save on performance.
		/// </summary>
		// Token: 0x0600134A RID: 4938 RVA: 0x0004F0B9 File Offset: 0x0004D2B9
		public void Sleep()
		{
			this.native.PutToSleep();
		}

		// Token: 0x0600134B RID: 4939 RVA: 0x0004F0C8 File Offset: 0x0004D2C8
		public void RebuildMass()
		{
			for (int i = 0; i < this.BodyCount; i++)
			{
				PhysicsBody body = this.GetBody(i);
				if (body.IsValid())
				{
					body.RebuildMass();
				}
			}
		}

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x0600134C RID: 4940 RVA: 0x0004F0FC File Offset: 0x0004D2FC
		// (set) Token: 0x0600134D RID: 4941 RVA: 0x0004F109 File Offset: 0x0004D309
		public float Mass
		{
			get
			{
				return this.native.GetTotalMass();
			}
			set
			{
				this.native.SetTotalMass(value);
			}
		}

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x0600134E RID: 4942 RVA: 0x0004F117 File Offset: 0x0004D317
		public IEnumerable<PhysicsBody> Bodies
		{
			get
			{
				int bodyCount = this.BodyCount;
				int num;
				for (int i = 0; i < bodyCount; i = num)
				{
					yield return this.GetBody(i);
					num = i + 1;
				}
				yield break;
			}
		}

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x0600134F RID: 4943 RVA: 0x0004F127 File Offset: 0x0004D327
		public int BodyCount
		{
			get
			{
				return this.native.GetBodyCount();
			}
		}

		// Token: 0x06001350 RID: 4944 RVA: 0x0004F134 File Offset: 0x0004D334
		public PhysicsBody GetBody(int index)
		{
			return this.native.GetBodyHandle(index);
		}

		// Token: 0x06001351 RID: 4945 RVA: 0x0004F142 File Offset: 0x0004D342
		public PhysicsBody GetBody(string name)
		{
			return this.native.FindBodyByName(name);
		}

		// Token: 0x06001352 RID: 4946 RVA: 0x0004F150 File Offset: 0x0004D350
		public int GetBodyIndex(PhysicsBody body)
		{
			return this.native.GetBodyIndex(body);
		}

		// Token: 0x06001353 RID: 4947 RVA: 0x0004F15E File Offset: 0x0004D35E
		public string GetBodyBoneName(PhysicsBody body)
		{
			return this.native.GetBodyName(this.GetBodyIndex(body));
		}

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06001354 RID: 4948 RVA: 0x0004F172 File Offset: 0x0004D372
		public IEnumerable<PhysicsJoint> Joints
		{
			get
			{
				int jointCount = this.JointCount;
				int num;
				for (int i = 0; i < jointCount; i = num)
				{
					yield return this.GetJoint(i);
					num = i + 1;
				}
				yield break;
			}
		}

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06001355 RID: 4949 RVA: 0x0004F182 File Offset: 0x0004D382
		public int JointCount
		{
			get
			{
				return this.native.GetJointCount();
			}
		}

		// Token: 0x06001356 RID: 4950 RVA: 0x0004F18F File Offset: 0x0004D38F
		public PhysicsJoint GetJoint(int jointIndex)
		{
			return this.native.GetJointHandle(jointIndex);
		}

		/// <summary>
		/// Sets the physical properties of each <see cref="T:Sandbox.PhysicsShape">PhysicsShape</see> of this group.
		/// </summary>
		// Token: 0x06001357 RID: 4951 RVA: 0x0004F19D File Offset: 0x0004D39D
		public void SetSurface(string name)
		{
			this.native.SetSurfaceProperties(name);
		}

		// Token: 0x0400044D RID: 1101
		internal IPhysAggregateInstance native;
	}
}
