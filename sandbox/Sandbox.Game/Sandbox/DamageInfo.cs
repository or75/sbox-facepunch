using System;

namespace Sandbox
{
	// Token: 0x020000A8 RID: 168
	public struct DamageInfo
	{
		/// <summary>
		/// The player or NPC or exploding barrel (etc)1 that is attacking
		/// </summary>
		// Token: 0x17000227 RID: 551
		// (get) Token: 0x0600111E RID: 4382 RVA: 0x00049C0A File Offset: 0x00047E0A
		// (set) Token: 0x0600111F RID: 4383 RVA: 0x00049C12 File Offset: 0x00047E12
		public Entity Attacker { readonly get; set; }

		/// <summary>
		/// The weapon that the attacker is using
		/// </summary>
		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06001120 RID: 4384 RVA: 0x00049C1B File Offset: 0x00047E1B
		// (set) Token: 0x06001121 RID: 4385 RVA: 0x00049C23 File Offset: 0x00047E23
		public Entity Weapon { readonly get; set; }

		/// <summary>
		/// The position the damage is being inflicted (the bullet entry point)
		/// </summary>
		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06001122 RID: 4386 RVA: 0x00049C2C File Offset: 0x00047E2C
		// (set) Token: 0x06001123 RID: 4387 RVA: 0x00049C34 File Offset: 0x00047E34
		public Vector3 Position { readonly get; set; }

		/// <summary>
		/// The force of the damage - for moving physics etc. This would be the tradjectory
		/// of the bullet multiplied by the speed and mass.
		/// </summary>
		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06001124 RID: 4388 RVA: 0x00049C3D File Offset: 0x00047E3D
		// (set) Token: 0x06001125 RID: 4389 RVA: 0x00049C45 File Offset: 0x00047E45
		public Vector3 Force { readonly get; set; }

		/// <summary>
		/// The actual amount of damage this attack causes
		/// </summary>
		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06001126 RID: 4390 RVA: 0x00049C4E File Offset: 0x00047E4E
		// (set) Token: 0x06001127 RID: 4391 RVA: 0x00049C56 File Offset: 0x00047E56
		public float Damage { readonly get; set; }

		/// <summary>
		/// Damage flags, extra infomation about this attack
		/// </summary>
		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06001128 RID: 4392 RVA: 0x00049C5F File Offset: 0x00047E5F
		// (set) Token: 0x06001129 RID: 4393 RVA: 0x00049C67 File Offset: 0x00047E67
		public DamageFlags Flags { readonly get; set; }

		/// <summary>
		/// The physics body that was hit
		/// </summary>
		// Token: 0x1700022D RID: 557
		// (get) Token: 0x0600112A RID: 4394 RVA: 0x00049C70 File Offset: 0x00047E70
		// (set) Token: 0x0600112B RID: 4395 RVA: 0x00049C78 File Offset: 0x00047E78
		public PhysicsBody Body { readonly get; set; }

		/// <summary>
		/// The hitbox index
		/// </summary>
		// Token: 0x1700022E RID: 558
		// (get) Token: 0x0600112C RID: 4396 RVA: 0x00049C81 File Offset: 0x00047E81
		// (set) Token: 0x0600112D RID: 4397 RVA: 0x00049C89 File Offset: 0x00047E89
		public int HitboxIndex { readonly get; set; }

		/// <summary>
		/// The bone index that the hitbox was attached to
		/// </summary>
		// Token: 0x1700022F RID: 559
		// (get) Token: 0x0600112E RID: 4398 RVA: 0x00049C92 File Offset: 0x00047E92
		// (set) Token: 0x0600112F RID: 4399 RVA: 0x00049C9A File Offset: 0x00047E9A
		public int BoneIndex { readonly get; set; }

		/// <summary>
		/// Creates a new DamageInfo with the DamageFlag Bullet
		/// </summary>
		// Token: 0x06001130 RID: 4400 RVA: 0x00049CA4 File Offset: 0x00047EA4
		public static DamageInfo FromBullet(Vector3 hitPosition, Vector3 hitForce, float damage)
		{
			return new DamageInfo
			{
				Position = hitPosition,
				Force = hitForce,
				Damage = damage,
				Flags = DamageFlags.Bullet
			};
		}

		/// <summary>
		/// Creates a new DamageInfo with the DamageFlag Generic
		/// </summary>
		// Token: 0x06001131 RID: 4401 RVA: 0x00049CDC File Offset: 0x00047EDC
		public static DamageInfo Generic(float damage)
		{
			return new DamageInfo
			{
				Damage = damage,
				Flags = DamageFlags.Generic
			};
		}

		/// <summary>
		/// Creates a new DamageInfo with the DamageFlag Blast
		/// </summary>
		// Token: 0x06001132 RID: 4402 RVA: 0x00049D04 File Offset: 0x00047F04
		public static DamageInfo Explosion(Vector3 sourcePosition, Vector3 force, float damage)
		{
			return new DamageInfo
			{
				Position = sourcePosition,
				Force = force,
				Damage = damage,
				Flags = DamageFlags.Blast
			};
		}

		/// <summary>
		/// Set the attacker
		/// </summary>
		// Token: 0x06001133 RID: 4403 RVA: 0x00049D3B File Offset: 0x00047F3B
		public DamageInfo WithAttacker(Entity attacker, Entity weapon = null)
		{
			this.Attacker = attacker;
			if (weapon != null)
			{
				this.Weapon = weapon;
			}
			return this;
		}

		/// <summary>
		/// Set the attacker
		/// </summary>
		// Token: 0x06001134 RID: 4404 RVA: 0x00049D54 File Offset: 0x00047F54
		public DamageInfo WithWeapon(Entity weapon)
		{
			this.Weapon = weapon;
			return this;
		}

		/// <summary>
		/// Add flag(s)
		/// </summary>
		// Token: 0x06001135 RID: 4405 RVA: 0x00049D63 File Offset: 0x00047F63
		public DamageInfo WithFlag(DamageFlags flag)
		{
			this.Flags |= flag;
			return this;
		}

		/// <summary>
		/// Sets the hit physics body
		/// </summary>
		// Token: 0x06001136 RID: 4406 RVA: 0x00049D79 File Offset: 0x00047F79
		public DamageInfo WithHitBody(PhysicsBody body)
		{
			this.Body = body;
			return this;
		}

		/// <summary>
		/// Sets the hitbox index
		/// </summary>
		// Token: 0x06001137 RID: 4407 RVA: 0x00049D88 File Offset: 0x00047F88
		public DamageInfo WithHitbox(int hitbox)
		{
			this.HitboxIndex = hitbox;
			return this;
		}

		/// <summary>
		/// Sets the hitbox index
		/// </summary>
		// Token: 0x06001138 RID: 4408 RVA: 0x00049D97 File Offset: 0x00047F97
		public DamageInfo WithBone(int bone)
		{
			this.BoneIndex = bone;
			return this;
		}

		/// <summary>
		/// Sets the position
		/// </summary>
		// Token: 0x06001139 RID: 4409 RVA: 0x00049DA6 File Offset: 0x00047FA6
		public DamageInfo WithPosition(Vector3 position)
		{
			this.Position = position;
			return this;
		}

		/// <summary>
		/// Sets the force
		/// </summary>
		// Token: 0x0600113A RID: 4410 RVA: 0x00049DB5 File Offset: 0x00047FB5
		public DamageInfo WithForce(Vector3 force)
		{
			this.Force = force;
			return this;
		}

		/// <summary>
		/// Fills in the PhysicsBody and Hitbox from the trace result
		/// </summary>
		// Token: 0x0600113B RID: 4411 RVA: 0x00049DC4 File Offset: 0x00047FC4
		public DamageInfo UsingTraceResult(TraceResult result)
		{
			this.Body = result.Body;
			this.HitboxIndex = result.HitboxIndex;
			this.BoneIndex = result.Bone;
			return this;
		}
	}
}
