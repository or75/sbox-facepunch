using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Hammer;
using NativeEngine;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x0200008E RID: 142
	[Library("model_entity")]
	[Skip]
	[Display(Name = "Model Entity")]
	[Icon("view_in_ar")]
	public class ModelEntity : Entity
	{
		// Token: 0x06000E9F RID: 3743 RVA: 0x00045760 File Offset: 0x00043960
		public Transform? GetAttachment(string name, bool worldspace = true)
		{
			Transform tx;
			if (this.skeleton.SBox_GetAttachment(name, worldspace, out tx))
			{
				return new Transform?(tx);
			}
			return null;
		}

		/// <summary>
		/// Set body group to replace parts of the model
		/// Uses index for bodygroup
		/// </summary>
		// Token: 0x06000EA0 RID: 3744 RVA: 0x0004578E File Offset: 0x0004398E
		public void SetBodyGroup(int group, int value)
		{
			if (!this.clientModel.IsNull)
			{
				this.clientModel.SetBodygroup(group, value);
			}
			if (!this.serverModel.IsNull)
			{
				this.serverModel.SetBodygroup(group, value);
			}
		}

		/// <summary>
		/// Set body group to replace parts of the model
		/// Uses name for bodygroup
		/// </summary>
		// Token: 0x06000EA1 RID: 3745 RVA: 0x000457C4 File Offset: 0x000439C4
		public void SetBodyGroup(string group, int value)
		{
			if (!this.clientModel.IsNull)
			{
				this.clientModel.SetBodygroupByName(group, value);
			}
			if (!this.serverModel.IsNull)
			{
				this.serverModel.SetBodygroupByName(group, value);
			}
		}

		/// <summary>
		/// Copy body groups over to this model
		/// </summary>
		// Token: 0x06000EA2 RID: 3746 RVA: 0x000457FA File Offset: 0x000439FA
		public void CopyBodyGroups(ModelEntity from)
		{
			if (from.IsValid())
			{
				this.GetBodyGroupMask(from.GetBodyGroupMask());
			}
		}

		// Token: 0x06000EA3 RID: 3747 RVA: 0x00045810 File Offset: 0x00043A10
		internal ulong GetBodyGroupMask()
		{
			if (!this.clientModel.IsNull)
			{
				return this.clientModel.GetRawMeshGroupMask();
			}
			if (!this.serverModel.IsNull)
			{
				return this.serverModel.GetRawMeshGroupMask();
			}
			return 0UL;
		}

		// Token: 0x06000EA4 RID: 3748 RVA: 0x00045846 File Offset: 0x00043A46
		internal void GetBodyGroupMask(ulong mask)
		{
			if (!this.clientModel.IsNull)
			{
				this.clientModel.SetRawMeshGroupMask_LegacyDoNotUse(mask);
			}
			if (!this.serverModel.IsNull)
			{
				this.serverModel.SetRawMeshGroupMask_LegacyDoNotUse(mask);
			}
		}

		/// <summary>
		/// Enable or disable all physics/solid collisions as well as 
		/// trace collisions.
		/// </summary>
		// Token: 0x17000154 RID: 340
		// (set) Token: 0x06000EA5 RID: 3749 RVA: 0x0004587A File Offset: 0x00043A7A
		[Category("Collision")]
		public bool EnableAllCollisions
		{
			set
			{
				if (value)
				{
					this.collisionProperty.EnableAllCollisions();
					return;
				}
				this.collisionProperty.DisableAllCollisions();
			}
		}

		// Token: 0x17000155 RID: 341
		// (set) Token: 0x06000EA6 RID: 3750 RVA: 0x00045898 File Offset: 0x00043A98
		[Category("Collision")]
		public bool EnableSolidCollisions
		{
			set
			{
				if (value)
				{
					this.collisionProperty.EnableSolidCollisions();
					return;
				}
				this.collisionProperty.DisableSolidCollisions();
			}
		}

		// Token: 0x17000156 RID: 342
		// (set) Token: 0x06000EA7 RID: 3751 RVA: 0x000458B6 File Offset: 0x00043AB6
		[Category("Collision")]
		public bool EnableTraceAndQueries
		{
			set
			{
				if (value)
				{
					this.collisionProperty.EnableTraceAndQueries();
					return;
				}
				this.collisionProperty.DisableTraceAndQueries();
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000EA8 RID: 3752 RVA: 0x000458D4 File Offset: 0x00043AD4
		[Browsable(false)]
		public PhysicsBody PhysicsBody
		{
			get
			{
				return this.collisionProperty.GetVPhysicsBody();
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000EA9 RID: 3753 RVA: 0x000458E1 File Offset: 0x00043AE1
		// (set) Token: 0x06000EAA RID: 3754 RVA: 0x000458EE File Offset: 0x00043AEE
		[Category("Collision")]
		public CollisionGroup CollisionGroup
		{
			get
			{
				return (CollisionGroup)this.collisionProperty.GetCollisionGroup();
			}
			set
			{
				this.collisionProperty.SetCollisionGroup((int)value);
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000EAC RID: 3756 RVA: 0x00045915 File Offset: 0x00043B15
		// (set) Token: 0x06000EAB RID: 3755 RVA: 0x000458FC File Offset: 0x00043AFC
		[Browsable(false)]
		public BBox CollisionBounds
		{
			get
			{
				return this.collisionProperty.GetCollisionBounds();
			}
			set
			{
				this.collisionProperty.SetCollisionBounds(value.Mins, value.Maxs);
			}
		}

		/// <summary>
		/// Allow Touch callbacks to be called
		/// </summary>
		// Token: 0x1700015A RID: 346
		// (set) Token: 0x06000EAD RID: 3757 RVA: 0x00045924 File Offset: 0x00043B24
		[Category("Collision")]
		public bool EnableTouch
		{
			set
			{
				if (value)
				{
					this.collisionProperty.EnableTouchEvents();
				}
				else
				{
					this.collisionProperty.DisableTouchEvents();
				}
				PhysicsBody phys = this.PhysicsBody;
				if (phys != null)
				{
					phys.EnableTouch = value;
				}
			}
		}

		/// <summary>
		/// Allow Touch callbacks to be called
		/// </summary>
		// Token: 0x1700015B RID: 347
		// (set) Token: 0x06000EAE RID: 3758 RVA: 0x0004595F File Offset: 0x00043B5F
		public bool EnableTouchPersists
		{
			set
			{
				if (value)
				{
					this.collisionProperty.EnableTouchPersistsNotification();
					return;
				}
				this.collisionProperty.DisableTouchPersistsNotification();
			}
		}

		/// <summary>
		/// Use Hitboxes for traces etc
		/// </summary>
		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000EAF RID: 3759 RVA: 0x0004597D File Offset: 0x00043B7D
		// (set) Token: 0x06000EB0 RID: 3760 RVA: 0x0004598A File Offset: 0x00043B8A
		[Category("Collision")]
		public bool EnableHitboxes
		{
			get
			{
				return this.collisionProperty.IsHitboxEnabled();
			}
			set
			{
				if (value)
				{
					this.collisionProperty.EnableHitboxes();
					return;
				}
				this.collisionProperty.DisableHitboxes();
			}
		}

		/// <summary>
		/// Allow ragdoll parts to collide with each other
		/// </summary>
		// Token: 0x1700015D RID: 349
		// (set) Token: 0x06000EB1 RID: 3761 RVA: 0x000459A6 File Offset: 0x00043BA6
		[Category("Collision")]
		public bool EnableSelfCollisions
		{
			set
			{
				if (value)
				{
					this.collisionProperty.EnableSelfCollisions();
					return;
				}
				this.collisionProperty.DisableSelfCollisions();
			}
		}

		/// <summary>
		/// Set the method used to work out the surrounding bounds. The bounds are important for 
		/// traces and collision checks, because they're used the quickly eliminate collisions.
		/// </summary>
		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000EB2 RID: 3762 RVA: 0x000459C4 File Offset: 0x00043BC4
		// (set) Token: 0x06000EB3 RID: 3763 RVA: 0x000459D1 File Offset: 0x00043BD1
		[Category("Collision")]
		public SurroundingBoundsType SurroundingBoundsMode
		{
			get
			{
				return this.collisionProperty.GetSurroundingBoundsType();
			}
			set
			{
				this.collisionProperty.SetSurroundingBoundsType(value);
			}
		}

		// Token: 0x06000EB4 RID: 3764 RVA: 0x000459DF File Offset: 0x00043BDF
		public void AddCollisionLayer(CollisionLayer layer)
		{
			this.collisionProperty.EnableInteractsAsMask((ulong)layer);
		}

		// Token: 0x06000EB5 RID: 3765 RVA: 0x000459ED File Offset: 0x00043BED
		public void RemoveCollisionLayer(CollisionLayer layer)
		{
			this.collisionProperty.DisableInteractsAsMask((ulong)layer);
		}

		// Token: 0x06000EB6 RID: 3766 RVA: 0x000459FB File Offset: 0x00043BFB
		public void ClearCollisionLayers()
		{
			this.collisionProperty.ClearInteractsAsMask();
		}

		/// <summary>
		/// Which interaction layers do I represent?
		/// </summary>
		// Token: 0x06000EB7 RID: 3767 RVA: 0x00045A08 File Offset: 0x00043C08
		public void SetInteractsAs(CollisionLayer layer)
		{
			this.collisionProperty.ClearInteractsAsMask();
			this.collisionProperty.EnableInteractsAsMask((ulong)layer);
		}

		/// <summary>
		/// Which interaction layers do I interact or collide with?
		/// </summary>
		// Token: 0x06000EB8 RID: 3768 RVA: 0x00045A21 File Offset: 0x00043C21
		public void SetInteractsWith(CollisionLayer layer)
		{
			this.collisionProperty.ClearInteractsWithMask();
			this.collisionProperty.EnableInteractsWithMask((ulong)layer);
		}

		/// <summary>
		/// Which interaction layers do I represent?
		/// </summary>
		// Token: 0x06000EB9 RID: 3769 RVA: 0x00045A3A File Offset: 0x00043C3A
		public void SetInteractsExclude(CollisionLayer layer)
		{
			this.collisionProperty.ClearInteractsExcludeMask();
			this.collisionProperty.EnableInteractsExcludeMask((ulong)layer);
		}

		// Token: 0x06000EBA RID: 3770 RVA: 0x00045A53 File Offset: 0x00043C53
		public CollisionLayer GetInteractsAs()
		{
			return (CollisionLayer)this.collisionProperty.GetInteractsAsMask();
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x00045A60 File Offset: 0x00043C60
		public CollisionLayer GetInteractsWith()
		{
			return (CollisionLayer)this.collisionProperty.GetInteractsWithMask();
		}

		// Token: 0x06000EBC RID: 3772 RVA: 0x00045A6D File Offset: 0x00043C6D
		public CollisionLayer GetInteractsExclude()
		{
			return (CollisionLayer)this.collisionProperty.GetInteractsExcludeMask();
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000EBD RID: 3773 RVA: 0x00045A7A File Offset: 0x00043C7A
		internal override string NativeEntityClass
		{
			get
			{
				return "basemodelentity";
			}
		}

		// Token: 0x06000EBE RID: 3774 RVA: 0x00045A81 File Offset: 0x00043C81
		public ModelEntity()
		{
		}

		// Token: 0x06000EBF RID: 3775 RVA: 0x00045A90 File Offset: 0x00043C90
		public ModelEntity(string modelName)
		{
			this.SetModel(modelName);
		}

		// Token: 0x06000EC0 RID: 3776 RVA: 0x00045AA6 File Offset: 0x00043CA6
		public ModelEntity(string modelName, Entity parent)
		{
			this.SetModel(modelName);
			base.SetParent(parent, true);
		}

		// Token: 0x06000EC1 RID: 3777 RVA: 0x00045AC4 File Offset: 0x00043CC4
		internal override void OnNativeEntity(CEntityInstance ent)
		{
			base.OnNativeEntity(ent);
			if (base.IsClient)
			{
				this.clientModel = (C_BaseModelEntity)this.clientEnt;
				if (this.clientModel.IsNull)
				{
					throw new Exception("clientModel is null");
				}
				this.collisionProperty = this.clientModel.CollisionProp();
				if (this.collisionProperty.IsNull)
				{
					throw new Exception("collisionProperty is null");
				}
				this.skeleton = this.clientModel.GetSkeletonInstance();
				if (this.skeleton.IsNull)
				{
					throw new Exception("skeleton is null");
				}
				this.glowProperty = this.clientModel.GlowProp();
				if (this.glowProperty.IsNull)
				{
					throw new Exception("glowProperty is null");
				}
			}
			if (base.IsServer)
			{
				this.serverModel = (CBaseModelEntity)this.serverEnt;
				if (this.serverModel.IsNull)
				{
					throw new Exception("serverModel is null");
				}
				this.collisionProperty = this.serverModel.CollisionProp();
				if (this.collisionProperty.IsNull)
				{
					throw new Exception("collisionProperty is null");
				}
				this.skeleton = this.serverModel.GetSkeletonInstance();
				if (this.skeleton.IsNull)
				{
					throw new Exception("skeleton is null");
				}
				this.glowProperty = this.serverModel.GlowProp();
				if (this.glowProperty.IsNull)
				{
					throw new Exception("glowProperty is null");
				}
			}
			this.AddCollisionLayer(CollisionLayer.Solid);
			this.EnableSelfCollisions = true;
		}

		// Token: 0x06000EC2 RID: 3778 RVA: 0x00045C48 File Offset: 0x00043E48
		internal override void InternalDestruct()
		{
			base.InternalDestruct();
			this.serverModel = IntPtr.Zero;
			this.clientModel = IntPtr.Zero;
			this.collisionProperty = IntPtr.Zero;
			this.skeleton = IntPtr.Zero;
			this.glowProperty = IntPtr.Zero;
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06000EC3 RID: 3779 RVA: 0x00045CAB File Offset: 0x00043EAB
		// (set) Token: 0x06000EC4 RID: 3780 RVA: 0x00045CB3 File Offset: 0x00043EB3
		public override Vector3 LocalPosition
		{
			get
			{
				return base.LocalPosition;
			}
			set
			{
				base.LocalPosition = value;
				if (base.MoveType == MoveType.Physics && this.PhysicsBody != null)
				{
					this.PhysicsBody.Position = value;
				}
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06000EC5 RID: 3781 RVA: 0x00045CD9 File Offset: 0x00043ED9
		// (set) Token: 0x06000EC6 RID: 3782 RVA: 0x00045CE1 File Offset: 0x00043EE1
		public override Rotation LocalRotation
		{
			get
			{
				return base.LocalRotation;
			}
			set
			{
				base.LocalRotation = value;
				if (base.MoveType == MoveType.Physics && this.PhysicsBody != null)
				{
					this.PhysicsBody.Rotation = value;
				}
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000EC7 RID: 3783 RVA: 0x00045D07 File Offset: 0x00043F07
		// (set) Token: 0x06000EC8 RID: 3784 RVA: 0x00045D0F File Offset: 0x00043F0F
		public override Vector3 Position
		{
			get
			{
				return base.Position;
			}
			set
			{
				base.Position = value;
				if (base.MoveType == MoveType.Physics && this.PhysicsBody != null)
				{
					this.PhysicsBody.Position = value;
				}
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000EC9 RID: 3785 RVA: 0x00045D35 File Offset: 0x00043F35
		// (set) Token: 0x06000ECA RID: 3786 RVA: 0x00045D3D File Offset: 0x00043F3D
		public override Rotation Rotation
		{
			get
			{
				return base.Rotation;
			}
			set
			{
				base.Rotation = value;
				if (base.MoveType == MoveType.Physics && this.PhysicsBody != null)
				{
					this.PhysicsBody.Rotation = value;
				}
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06000ECB RID: 3787 RVA: 0x00045D63 File Offset: 0x00043F63
		// (set) Token: 0x06000ECC RID: 3788 RVA: 0x00045D88 File Offset: 0x00043F88
		public override Vector3 Velocity
		{
			get
			{
				if (base.MoveType == MoveType.Physics && this.PhysicsBody != null)
				{
					return this.PhysicsBody.Velocity;
				}
				return base.Velocity;
			}
			set
			{
				base.Velocity = value;
				if (base.MoveType == MoveType.Physics && this.PhysicsBody != null)
				{
					this.PhysicsBody.Velocity = value;
				}
			}
		}

		// Token: 0x06000ECD RID: 3789 RVA: 0x00045DB0 File Offset: 0x00043FB0
		public void SetModel(string name)
		{
			if (!this.clientModel.IsNull)
			{
				this.clientModel.SetModel(string.IsNullOrEmpty(name) ? null : name);
			}
			if (!this.serverModel.IsNull)
			{
				if (string.IsNullOrEmpty(name))
				{
					this.serverModel.SetModel(null);
					return;
				}
				Precache.Add(name);
				this.serverModel.SetModel(name);
			}
		}

		// Token: 0x06000ECE RID: 3790 RVA: 0x00045E15 File Offset: 0x00044015
		[Obsolete("Use Model property")]
		public Model GetModel()
		{
			return this.Model;
		}

		// Token: 0x06000ECF RID: 3791 RVA: 0x00045E1D File Offset: 0x0004401D
		[Obsolete("Use Model property")]
		public void SetModel(Model model)
		{
			this.Model = model;
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06000ED0 RID: 3792 RVA: 0x00045E26 File Offset: 0x00044026
		// (set) Token: 0x06000ED1 RID: 3793 RVA: 0x00045E68 File Offset: 0x00044068
		public Model Model
		{
			get
			{
				if (this.clientModel.IsValid)
				{
					return Model.Get(this.clientModel.GetModel());
				}
				if (this.serverModel.IsValid)
				{
					return Model.Get(this.serverModel.GetModel());
				}
				return null;
			}
			set
			{
				if (this.clientModel.IsValid)
				{
					this.clientModel.SetModel((value != null) ? value.native : default(IModel));
				}
				if (this.serverModel.IsValid)
				{
					this.serverModel.SetModel((value != null) ? value.native : default(IModel));
				}
			}
		}

		/// <summary>
		/// Sets the scene objects material
		/// </summary>
		// Token: 0x06000ED2 RID: 3794 RVA: 0x00045ECD File Offset: 0x000440CD
		public void SetMaterialOverride(Material material)
		{
			Host.AssertClient("SetMaterialOverride");
			SceneObject sceneObject = this.SceneObject;
			if (sceneObject == null)
			{
				return;
			}
			sceneObject.SetMaterialOverride(material);
		}

		/// <summary>
		/// Sets the scene objects material
		/// </summary>
		// Token: 0x06000ED3 RID: 3795 RVA: 0x00045EEA File Offset: 0x000440EA
		public void SetMaterialOverride(string materialPath)
		{
			Host.AssertClient("SetMaterialOverride");
			this.SetMaterialOverride(Material.Load(materialPath));
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000ED4 RID: 3796 RVA: 0x00045F02 File Offset: 0x00044102
		[Category("Collision")]
		public Vector3 CollisionPosition
		{
			get
			{
				return this.collisionProperty.GetCollisionOrigin();
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000ED5 RID: 3797 RVA: 0x00045F0F File Offset: 0x0004410F
		[Category("Collision")]
		public Rotation CollisionRotation
		{
			get
			{
				return Rotation.From(this.collisionProperty.GetCollisionAngles());
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000ED6 RID: 3798 RVA: 0x00045F21 File Offset: 0x00044121
		[Category("Collision")]
		public Vector3 CollisionWorldSpaceCenter
		{
			get
			{
				return this.collisionProperty.WorldSpaceCenter();
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000ED7 RID: 3799 RVA: 0x00045F2E File Offset: 0x0004412E
		[Obsolete("Use CollisionBounds")]
		public BBox OOBBox
		{
			get
			{
				return this.CollisionBounds;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000ED8 RID: 3800 RVA: 0x00045F36 File Offset: 0x00044136
		public int BoneCount
		{
			get
			{
				return this.skeleton.GetNumBones();
			}
		}

		// Token: 0x06000ED9 RID: 3801 RVA: 0x00045F43 File Offset: 0x00044143
		public string GetBoneName(int i)
		{
			return this.skeleton.SBox_GetBoneName(i);
		}

		// Token: 0x06000EDA RID: 3802 RVA: 0x00045F51 File Offset: 0x00044151
		public int GetBoneParent(int i)
		{
			return this.skeleton.SBox_GetBoneParent(i);
		}

		// Token: 0x06000EDB RID: 3803 RVA: 0x00045F5F File Offset: 0x0004415F
		public int GetBoneParent(string boneName)
		{
			return this.GetBoneParent(this.GetBoneIndex(boneName));
		}

		// Token: 0x06000EDC RID: 3804 RVA: 0x00045F6E File Offset: 0x0004416E
		public int GetBoneIndex(string boneName)
		{
			return this.skeleton.LookupBone(boneName);
		}

		// Token: 0x1700016B RID: 363
		// (set) Token: 0x06000EDD RID: 3805 RVA: 0x00045F7C File Offset: 0x0004417C
		public bool UsePhysicsCollision
		{
			set
			{
				this.collisionProperty.SetSolid(SolidType.Physics);
			}
		}

		// Token: 0x06000EDE RID: 3806 RVA: 0x00045F8A File Offset: 0x0004418A
		public bool SetBoneTransform(int i, Transform tx, bool worldspace = true)
		{
			return this.skeleton.SBox_SetBoneTransform(i, tx, worldspace);
		}

		// Token: 0x06000EDF RID: 3807 RVA: 0x00045F9C File Offset: 0x0004419C
		public Transform GetBoneTransform(int i, bool worldspace = true)
		{
			if (!base.IsClientOnly)
			{
				return this.skeleton.SBox_GetBoneTransform(i, worldspace);
			}
			if (!this.clientModel.IsNull)
			{
				return this.clientModel.GetBoneTransform(i);
			}
			if (!this.serverModel.IsNull)
			{
				return this.serverModel.GetBoneTransform(i);
			}
			return Transform.Zero;
		}

		// Token: 0x06000EE0 RID: 3808 RVA: 0x00045FF8 File Offset: 0x000441F8
		public bool SetBoneTransform(string boneName, Transform tx, bool worldspace = true)
		{
			return this.SetBoneTransform(this.GetBoneIndex(boneName), tx, worldspace);
		}

		// Token: 0x06000EE1 RID: 3809 RVA: 0x00046009 File Offset: 0x00044209
		public Transform GetBoneTransform(string boneName, bool worldspace = true)
		{
			return this.GetBoneTransform(this.GetBoneIndex(boneName), worldspace);
		}

		// Token: 0x06000EE2 RID: 3810 RVA: 0x0004601C File Offset: 0x0004421C
		public Transform[] ComputeBones(float timeOffset)
		{
			if (this.BoneCount <= 0)
			{
				return Array.Empty<Transform>();
			}
			Transform[] c = new Transform[this.BoneCount];
			this.skeleton.SBox_ComputeBonesAtTime(c, c.Length, timeOffset);
			return c;
		}

		// Token: 0x06000EE3 RID: 3811 RVA: 0x00046056 File Offset: 0x00044256
		public string GetModelName()
		{
			if (!this.clientEnt.IsNull)
			{
				return this.clientEnt.GetModelNameString();
			}
			if (!this.serverEnt.IsNull)
			{
				return this.serverEnt.GetModelNameString();
			}
			return null;
		}

		/// <summary>
		/// Called from engine when a new model is set
		/// </summary>
		// Token: 0x06000EE4 RID: 3812 RVA: 0x0004608B File Offset: 0x0004428B
		internal override void InternalOnNewModel()
		{
			this.OnNewModel(this.Model);
		}

		/// <summary>
		/// Called when the model is changed.
		/// </summary>
		// Token: 0x06000EE5 RID: 3813 RVA: 0x00046099 File Offset: 0x00044299
		public virtual void OnNewModel(Model model)
		{
			this.Liquid = ModelEntity.LiquidManager.Init(this);
		}

		// Token: 0x06000EE6 RID: 3814 RVA: 0x000460A7 File Offset: 0x000442A7
		internal override void InternalAnimEvent(string name, int intData, float floatData, Vector3 vectorData, string stringData)
		{
			this.OnAnimEventGeneric(name, intData, floatData, vectorData, stringData);
		}

		// Token: 0x06000EE7 RID: 3815 RVA: 0x000460B6 File Offset: 0x000442B6
		public virtual void OnAnimEventGeneric(string name, int intData, float floatData, Vector3 vectorData, string stringData)
		{
		}

		// Token: 0x06000EE8 RID: 3816 RVA: 0x000460B8 File Offset: 0x000442B8
		internal override void InternalAnimEventFootstep(Vector3 pos, int foot, float volume)
		{
			this.OnAnimEventFootstep(pos, foot, volume);
		}

		// Token: 0x06000EE9 RID: 3817 RVA: 0x000460C3 File Offset: 0x000442C3
		public virtual void OnAnimEventFootstep(Vector3 position, int foot, float volume)
		{
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06000EEA RID: 3818 RVA: 0x000460C8 File Offset: 0x000442C8
		// (set) Token: 0x06000EEB RID: 3819 RVA: 0x00046198 File Offset: 0x00044398
		[Category("Rendering")]
		public Color RenderColor
		{
			get
			{
				if (this.clientEnt.IsValid)
				{
					Color24 c = this.clientModel.GetRenderColor();
					byte a = this.clientModel.GetRenderAlpha();
					return new Color32(c.r, c.g, c.b, byte.MaxValue).ToColor().WithAlpha((float)a / 255f);
				}
				if (this.serverEnt.IsValid)
				{
					Color24 c2 = this.serverModel.GetRenderColor();
					byte a2 = this.serverModel.GetRenderAlpha();
					return new Color32(c2.r, c2.g, c2.b, byte.MaxValue).ToColor().WithAlpha((float)a2 / 255f);
				}
				return default(Color);
			}
			set
			{
				Color32 c = value;
				if (this.clientEnt.IsValid)
				{
					this.clientModel.SetRenderColor(c.r, c.g, c.b);
				}
				if (this.clientEnt.IsValid)
				{
					this.clientModel.SetRenderAlpha(c.a);
				}
				if (this.serverEnt.IsValid)
				{
					this.serverModel.SetRenderColor(c.r, c.g, c.b);
				}
				if (this.serverEnt.IsValid)
				{
					this.serverModel.SetRenderAlpha(c.a);
				}
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000EEC RID: 3820 RVA: 0x00046244 File Offset: 0x00044444
		// (set) Token: 0x06000EED RID: 3821 RVA: 0x0004624C File Offset: 0x0004444C
		[Obsolete("Replaced with RenderColor")]
		[Browsable(false)]
		public Color RenderColorWithAlpha
		{
			get
			{
				return this.RenderColor;
			}
			set
			{
				this.RenderColor = value;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000EEE RID: 3822 RVA: 0x00046255 File Offset: 0x00044455
		// (set) Token: 0x06000EEF RID: 3823 RVA: 0x0004625C File Offset: 0x0004445C
		[Obsolete("Replaced with RenderColor")]
		[Browsable(false)]
		public float RenderAlpha
		{
			get
			{
				return 1f;
			}
			set
			{
			}
		}

		// Token: 0x1700016F RID: 367
		// (set) Token: 0x06000EF0 RID: 3824 RVA: 0x0004625E File Offset: 0x0004445E
		[Browsable(false)]
		public string SceneLayer
		{
			set
			{
				if (this.clientEnt.IsValid)
				{
					this.clientModel.SetSceneLayerID(value);
				}
				if (this.serverEnt.IsValid)
				{
					throw new Exception("SceneLayer is unsupported on Server.");
				}
			}
		}

		/// <summary>
		/// Move all of the decals from this entity onto ourself
		/// </summary>
		// Token: 0x06000EF1 RID: 3825 RVA: 0x00046291 File Offset: 0x00044491
		public void TakeDecalsFrom(ModelEntity source)
		{
			DecalGameSystem.MoveDecals(source.GetEntityIntPtr(), base.GetEntityIntPtr());
		}

		/// <summary>
		/// Allow the entity to do what it wants when it's added to the inventory.
		/// Default behaviour is to add the target entity as a parent and stop moving.
		/// </summary>
		// Token: 0x06000EF2 RID: 3826 RVA: 0x000462A4 File Offset: 0x000444A4
		public override void OnCarryStart(Entity carrier)
		{
			if (base.IsClient)
			{
				return;
			}
			base.OnCarryStart(carrier);
			this.EnableAllCollisions = false;
		}

		/// <summary>
		/// Allow the entity to do what it wants when it's removed from the inventory
		/// </summary>
		// Token: 0x06000EF3 RID: 3827 RVA: 0x000462BD File Offset: 0x000444BD
		public override void OnCarryDrop(Entity carrier)
		{
			if (base.IsClient)
			{
				return;
			}
			base.OnCarryDrop(carrier);
			this.EnableAllCollisions = true;
		}

		// Token: 0x06000EF4 RID: 3828 RVA: 0x000462D8 File Offset: 0x000444D8
		[Input]
		[Sandbox.Internal.Description("Sets the color of this entity. Format is '255 255 255 255'.")]
		internal void SetColor(string color)
		{
			Color? col = Color.Parse(color);
			if (col == null)
			{
				return;
			}
			this.RenderColor = col.Value;
		}

		/// <summary>
		/// Get and set the color of the glow override on this object.
		/// </summary>
		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000EF5 RID: 3829 RVA: 0x00046303 File Offset: 0x00044503
		// (set) Token: 0x06000EF6 RID: 3830 RVA: 0x00046315 File Offset: 0x00044515
		[Category("Glow")]
		public Color GlowColor
		{
			get
			{
				return this.glowProperty.GetGlowColorOverride();
			}
			set
			{
				this.glowProperty.SetGlowColorOverride(value);
			}
		}

		/// <summary>
		/// Get and set the behaviour of the glow.
		/// Note that you still need to use GlowActive to enable it.
		/// </summary>
		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06000EF7 RID: 3831 RVA: 0x00046328 File Offset: 0x00044528
		// (set) Token: 0x06000EF8 RID: 3832 RVA: 0x00046335 File Offset: 0x00044535
		[Category("Glow")]
		public GlowStates GlowState
		{
			get
			{
				return (GlowStates)this.glowProperty.GetGlowState();
			}
			set
			{
				this.glowProperty.SetGlowState((int)value);
			}
		}

		/// <summary>
		/// Gets or set if the glow is active on the object.
		/// </summary>
		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000EF9 RID: 3833 RVA: 0x00046343 File Offset: 0x00044543
		// (set) Token: 0x06000EFA RID: 3834 RVA: 0x00046350 File Offset: 0x00044550
		[Category("Glow")]
		public bool GlowActive
		{
			get
			{
				return this.glowProperty.IsGlowing();
			}
			set
			{
				if (this.GlowState == GlowStates.Off)
				{
					this.GlowState = GlowStates.On;
				}
				if (value)
				{
					this.glowProperty.StartGlowing();
					return;
				}
				this.GlowState = GlowStates.Off;
				this.glowProperty.StopGlowing();
			}
		}

		/// <summary>
		/// The minimum distance that this object will start glowing.
		/// </summary>
		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000EFB RID: 3835 RVA: 0x00046382 File Offset: 0x00044582
		// (set) Token: 0x06000EFC RID: 3836 RVA: 0x0004638F File Offset: 0x0004458F
		[Category("Glow")]
		public int GlowDistanceStart
		{
			get
			{
				return this.glowProperty.GetGlowRangeMin();
			}
			set
			{
				this.glowProperty.SetGlowRangeMin(value);
			}
		}

		/// <summary>
		/// The maximum distance that this object will glow.
		/// </summary>
		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000EFD RID: 3837 RVA: 0x0004639D File Offset: 0x0004459D
		// (set) Token: 0x06000EFE RID: 3838 RVA: 0x000463AA File Offset: 0x000445AA
		[Category("Glow")]
		public int GlowDistanceEnd
		{
			get
			{
				return this.glowProperty.GetGlowRange();
			}
			set
			{
				this.glowProperty.SetGlowRange(value);
			}
		}

		/// <summary>
		/// Override the material that this object will use to glow
		/// </summary>
		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06000EFF RID: 3839 RVA: 0x000463B8 File Offset: 0x000445B8
		// (set) Token: 0x06000F00 RID: 3840 RVA: 0x000463BB File Offset: 0x000445BB
		[Category("Glow")]
		public Material GlowMaterial
		{
			get
			{
				return null;
			}
			set
			{
				this.glowProperty.SetGlowMaterialOverride((value != null) ? value.native : IntPtr.Zero);
			}
		}

		/// <summary>
		/// Don't cast no shadow.
		/// </summary>
		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06000F01 RID: 3841 RVA: 0x000463DD File Offset: 0x000445DD
		// (set) Token: 0x06000F02 RID: 3842 RVA: 0x000463E5 File Offset: 0x000445E5
		[DefaultValue(true)]
		[Property("enable_shadows", "Shadow Casting", "Whether this entity should cast shadows or not")]
		[Category("Rendering")]
		public new bool EnableShadowCasting
		{
			get
			{
				return base.EnableShadowCasting;
			}
			set
			{
				base.EnableShadowCasting = value;
			}
		}

		/// <summary>
		/// Set material group to replace materials of the model
		/// Uses index for material group
		/// </summary>
		// Token: 0x17000177 RID: 375
		// (get) Token: 0x06000F03 RID: 3843 RVA: 0x000463EE File Offset: 0x000445EE
		public int MaterialGroupCount
		{
			get
			{
				if (!this.clientModel.IsNull)
				{
					return this.clientModel.GetSkinCount();
				}
				if (!this.serverModel.IsNull)
				{
					return this.serverModel.GetSkinCount();
				}
				return 0;
			}
		}

		/// <summary>
		/// Set material group to replace materials of the model
		/// Uses index for material group
		/// </summary>
		// Token: 0x06000F04 RID: 3844 RVA: 0x00046423 File Offset: 0x00044623
		public void SetMaterialGroup(int group)
		{
			if (!this.clientModel.IsNull)
			{
				this.clientModel.SetSkin(group);
			}
			if (!this.serverModel.IsNull)
			{
				this.serverModel.SetSkin(group);
			}
		}

		/// <summary>
		/// Set material group to replace materials of the model
		/// </summary>
		// Token: 0x06000F05 RID: 3845 RVA: 0x00046457 File Offset: 0x00044657
		public void SetMaterialGroup(string group)
		{
			if (!this.clientModel.IsNull)
			{
				this.clientModel.SetSkin(group);
			}
			if (!this.serverModel.IsNull)
			{
				this.serverModel.SetSkin(group);
			}
		}

		// Token: 0x06000F06 RID: 3846 RVA: 0x0004648B File Offset: 0x0004468B
		public int GetMaterialGroup()
		{
			if (!this.clientModel.IsNull)
			{
				return this.clientModel.GetS1Skin();
			}
			if (!this.serverModel.IsNull)
			{
				return this.serverModel.GetS1Skin();
			}
			return 0;
		}

		/// <summary>
		/// Copy material group over to this model
		/// </summary>
		// Token: 0x06000F07 RID: 3847 RVA: 0x000464C0 File Offset: 0x000446C0
		public void CopyMaterialGroup(ModelEntity from)
		{
			if (from.IsValid())
			{
				this.SetMaterialGroup(from.GetMaterialGroup());
			}
		}

		// Token: 0x06000F08 RID: 3848 RVA: 0x000464D8 File Offset: 0x000446D8
		public void MoveTo(Vector3 position, float seconds)
		{
			Host.AssertServer("MoveTo");
			if (!this.serverEnt.IsValid)
			{
				return;
			}
			Vector3 delta = position - this.Position;
			base.MoveType = MoveType.Push;
			this.Velocity = delta / seconds;
			this.serverEnt.SetMoveDoneTime(seconds);
		}

		/// <summary>
		/// AGH! This doesn't work! Either the Rotation.Difference or .Angles() is fucked!
		/// </summary>
		// Token: 0x06000F09 RID: 3849 RVA: 0x0004652C File Offset: 0x0004472C
		public void MoveTo(Rotation rotation, float seconds)
		{
			Host.AssertServer("MoveTo");
			if (!this.serverEnt.IsValid)
			{
				return;
			}
			Angles delta = Rotation.Difference(this.Rotation, rotation).Angles();
			base.MoveType = MoveType.Push;
			this.AngularVelocity = delta / seconds;
			this.serverEnt.SetMoveDoneTime(seconds);
		}

		/// <summary>
		/// Angles. Blah.
		/// </summary>
		// Token: 0x06000F0A RID: 3850 RVA: 0x00046588 File Offset: 0x00044788
		public void MoveTo(Angles rotation, float seconds)
		{
			Host.AssertServer("MoveTo");
			if (!this.serverEnt.IsValid)
			{
				return;
			}
			Angles delta = (rotation - this.Rotation.Angles()).Normal;
			base.MoveType = MoveType.Push;
			this.AngularVelocity = delta / seconds;
			this.serverEnt.SetMoveDoneTime(seconds);
		}

		/// <summary>
		/// Called when your move is finished
		/// </summary>
		// Token: 0x06000F0B RID: 3851 RVA: 0x000465EA File Offset: 0x000447EA
		public virtual void MoveFinished()
		{
		}

		/// <summary>
		/// Called when your move is blocked
		/// </summary>
		// Token: 0x06000F0C RID: 3852 RVA: 0x000465EC File Offset: 0x000447EC
		public virtual void MoveBlocked(Entity entity)
		{
			GlobalGameNamespace.Log.Info(FormattableStringFactory.Create("{0} Move Blocked by {1}", new object[] { this, entity }));
		}

		// Token: 0x06000F0D RID: 3853 RVA: 0x00046610 File Offset: 0x00044810
		internal override void InternalMoveDone()
		{
			this.MoveFinished();
		}

		// Token: 0x06000F0E RID: 3854 RVA: 0x00046618 File Offset: 0x00044818
		internal override void InternalMoveBlocked(Entity entity)
		{
			this.MoveBlocked(entity);
		}

		/// <summary>
		/// Enable or disable physics motion
		/// </summary>
		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06000F0F RID: 3855 RVA: 0x00046621 File Offset: 0x00044821
		// (set) Token: 0x06000F10 RID: 3856 RVA: 0x00046629 File Offset: 0x00044829
		public bool PhysicsEnabled
		{
			get
			{
				return this._physicsEnabled;
			}
			set
			{
				this._physicsEnabled = value;
				if (!this.serverModel.IsNull)
				{
					this.serverModel.PhysicsEnableMotion(value);
					if (value)
					{
						this.PhysicsWake();
					}
				}
			}
		}

		// Token: 0x06000F11 RID: 3857 RVA: 0x00046654 File Offset: 0x00044854
		internal void PhysicsWake()
		{
			PhysicsGroup physicsGroup = base.PhysicsGroup;
			if (physicsGroup == null)
			{
				return;
			}
			physicsGroup.Wake();
		}

		/// <summary>
		/// Get the physics body attached to this bone
		/// </summary>
		// Token: 0x06000F12 RID: 3858 RVA: 0x00046666 File Offset: 0x00044866
		public PhysicsBody GetBonePhysicsBody(int iBone)
		{
			if (iBone < 0)
			{
				throw new ArgumentException("should not be lower than 0", "iBone");
			}
			return this.skeleton.Sbox_GetPhysicsBody(iBone);
		}

		/// <summary>
		/// Get the bone that this physics body is attached to
		/// </summary>
		// Token: 0x06000F13 RID: 3859 RVA: 0x00046688 File Offset: 0x00044888
		public int GetBone(PhysicsBody body)
		{
			return this.skeleton.Sbox_PhysicsBodyToBone(body);
		}

		/// <summary>
		/// Destroy any physics objects
		/// </summary>
		// Token: 0x06000F14 RID: 3860 RVA: 0x00046696 File Offset: 0x00044896
		public override void PhysicsClear()
		{
			base.PhysicsClear();
			this.skeleton.CleanupPhysics();
			this.collisionProperty.SetSolid(SolidType.SOLID_NONE);
		}

		// Token: 0x06000F15 RID: 3861 RVA: 0x000466B5 File Offset: 0x000448B5
		public PhysicsGroup SetupPhysicsFromModel(PhysicsMotionType motionType, bool startasleep = false)
		{
			return this.collisionProperty.SetupPhysicsFromUnscaledModel(motionType, (int)this.CollisionGroup, startasleep);
		}

		// Token: 0x06000F16 RID: 3862 RVA: 0x000466CA File Offset: 0x000448CA
		public PhysicsGroup SetupPhysicsFromAABB(PhysicsMotionType motionType, Vector3 mins, Vector3 maxs)
		{
			return this.collisionProperty.SetupPhysicsFromUnscaledAABB(motionType, (int)this.CollisionGroup, mins, maxs);
		}

		// Token: 0x06000F17 RID: 3863 RVA: 0x000466E0 File Offset: 0x000448E0
		public PhysicsGroup SetupPhysicsFromOBB(PhysicsMotionType motionType, Vector3 mins, Vector3 maxs)
		{
			return this.collisionProperty.SetupPhysicsFromUnscaledOBB(motionType, (int)this.CollisionGroup, mins, maxs);
		}

		// Token: 0x06000F18 RID: 3864 RVA: 0x000466F6 File Offset: 0x000448F6
		public PhysicsGroup SetupPhysicsFromCapsule(PhysicsMotionType motionType, Capsule capsule)
		{
			return this.collisionProperty.SetupPhysicsFromUnscaledCapsule(motionType, (int)this.CollisionGroup, capsule);
		}

		// Token: 0x06000F19 RID: 3865 RVA: 0x0004670B File Offset: 0x0004490B
		public PhysicsGroup SetupPhysicsFromOrientedCapsule(PhysicsMotionType motionType, Capsule capsule)
		{
			return this.collisionProperty.SetupPhysicsFromUnscaledOrientedCapsule(motionType, (int)this.CollisionGroup, capsule);
		}

		// Token: 0x06000F1A RID: 3866 RVA: 0x00046720 File Offset: 0x00044920
		public PhysicsGroup SetupPhysicsFromSphere(PhysicsMotionType motionType, Vector3 center, float radius)
		{
			return this.collisionProperty.SetupPhysicsFromUnscaledSphere(motionType, (int)this.CollisionGroup, center, radius);
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x06000F1B RID: 3867 RVA: 0x00046736 File Offset: 0x00044936
		[Browsable(false)]
		public SceneObject SceneObject
		{
			get
			{
				if (this.clientModel.IsValid)
				{
					return this.clientModel.GetSceneObject(0);
				}
				return null;
			}
		}

		/// <summary>
		/// Return which bone is this hitbox attached to.
		/// </summary>
		// Token: 0x06000F1C RID: 3868 RVA: 0x00046753 File Offset: 0x00044953
		public int GetHitboxBone(int hitbox)
		{
			return this.skeleton.GetBoneIndexForHitbox(hitbox);
		}

		/// <summary>
		/// Return group id for this hitbox.
		/// </summary>
		// Token: 0x06000F1D RID: 3869 RVA: 0x00046761 File Offset: 0x00044961
		public int GetHitboxGroup(int hitbox)
		{
			return this.skeleton.GetHitboxGroup(hitbox);
		}

		/// <summary>
		/// The currently active hitbox set.
		/// </summary>
		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000F1E RID: 3870 RVA: 0x0004676F File Offset: 0x0004496F
		// (set) Token: 0x06000F1F RID: 3871 RVA: 0x0004677C File Offset: 0x0004497C
		public string HitboxSet
		{
			get
			{
				return this.skeleton.GetHitboxSetName();
			}
			set
			{
				this.skeleton.SetHitboxSetByName(value);
			}
		}

		// Token: 0x06000F20 RID: 3872 RVA: 0x0004678A File Offset: 0x0004498A
		public void SetBone(int i, Transform tx)
		{
			this.skeleton.SBox_SetBoneOverride(i, tx);
		}

		// Token: 0x06000F21 RID: 3873 RVA: 0x00046799 File Offset: 0x00044999
		public void SetBone(string name, Transform tx)
		{
			this.skeleton.SBox_SetBoneOverride(name, tx);
		}

		// Token: 0x06000F22 RID: 3874 RVA: 0x000467A8 File Offset: 0x000449A8
		public void ResetBone(int i)
		{
			this.skeleton.SBox_SetBoneOverride(i, new Transform(new Vector3(float.MaxValue, float.MaxValue, float.MaxValue)));
		}

		// Token: 0x06000F23 RID: 3875 RVA: 0x000467CF File Offset: 0x000449CF
		public void ResetBone(string name)
		{
			this.skeleton.SBox_SetBoneOverride(name, new Transform(new Vector3(float.MaxValue, float.MaxValue, float.MaxValue)));
		}

		// Token: 0x06000F24 RID: 3876 RVA: 0x000467F6 File Offset: 0x000449F6
		public void ResetBones()
		{
			this.skeleton.SBox_ClearBoneOverride();
		}

		// Token: 0x04000255 RID: 597
		private static Logger log = Logging.GetLogger(null);

		// Token: 0x04000256 RID: 598
		internal CBaseModelEntity serverModel;

		// Token: 0x04000257 RID: 599
		internal C_BaseModelEntity clientModel;

		// Token: 0x04000258 RID: 600
		internal CollisionProperty collisionProperty;

		// Token: 0x04000259 RID: 601
		internal CSkeletonInstance skeleton;

		// Token: 0x0400025A RID: 602
		internal CGlowProperty glowProperty;

		// Token: 0x0400025B RID: 603
		public ModelEntity.LiquidManager Liquid;

		// Token: 0x0400025C RID: 604
		private bool _physicsEnabled = true;

		// Token: 0x02000214 RID: 532
		public class LiquidManager
		{
			// Token: 0x06001D86 RID: 7558 RVA: 0x00073305 File Offset: 0x00071505
			private static bool HasLiquidMaterialInMesh(ModelEntity parent)
			{
				return GameGlue.HasLiquidMaterial(parent.GetEntityIntPtr());
			}

			/// <summary>
			/// Creates a liquid manager if the model uses a liquid material
			/// </summary>
			// Token: 0x06001D87 RID: 7559 RVA: 0x00073314 File Offset: 0x00071514
			internal static ModelEntity.LiquidManager Init(ModelEntity parent)
			{
				if (parent.IsServer)
				{
					return null;
				}
				if (!ModelEntity.LiquidManager.HasLiquidMaterialInMesh(parent))
				{
					return null;
				}
				ModelEntity.LiquidManager liquidManager = new ModelEntity.LiquidManager();
				liquidManager.Parent = parent;
				liquidManager.Settings = new ModelEntity.LiquidManager.LiquidSettings
				{
					SettleDuration = 20f,
					GravityScale = 1f,
					Agitation = 5f,
					AdditivePower = 10f,
					Dampening = 0.4f,
					FoamDuration = 30f,
					FoamAgitation = 200f,
					FoamAdditivePower = 1f,
					FoamDampening = 0.2f
				};
				ModelEntity.LiquidManager.LiquidParameters liquidParameters = default(ModelEntity.LiquidManager.LiquidParameters);
				liquidParameters.PerPropRandom = (byte)Rand.Int(0, 255);
				liquidParameters.Bubbles = 0;
				liquidParameters.Agitation = 0;
				liquidParameters.ForceDirection = PhysicsWorld.Gravity.Normal;
				parent.RenderColor = liquidParameters.ToColor();
				return liquidManager;
			}

			// Token: 0x06001D88 RID: 7560 RVA: 0x00073408 File Offset: 0x00071608
			private float Remap(float val, float A, float B, float C, float D)
			{
				float cVal = (val - A) / (B - A);
				cVal = Math.Clamp(cVal, 0f, 1f);
				return C + (D - C) * cVal;
			}

			/// <summary>
			/// Updates the parameters of the liquid per frame
			/// Can take extra aggitation besides standard physical forces as an optional parameter
			/// </summary>
			// Token: 0x06001D89 RID: 7561 RVA: 0x00073438 File Offset: 0x00071638
			public void Update(Vector3? extraAggitation = null)
			{
				Vector3 vecVelocity = (this.Parent.Position - this.PrevPosition) / Time.Delta;
				float fAngVelocity = this.Parent.Rotation.Distance(this.PrevRotation) / Time.Delta;
				if (extraAggitation != null)
				{
					vecVelocity += extraAggitation.Value;
				}
				float flAgitation = MathF.Pow((vecVelocity - this.PrevVelocity).Length + fAngVelocity, 1f - this.Settings.Dampening);
				float num = MathF.Pow((vecVelocity - this.PrevVelocity).Length + fAngVelocity, 1f - this.Settings.FoamDampening);
				this.PrevPosition = this.Parent.Position;
				this.PrevVelocity = vecVelocity;
				this.PrevRotation = this.Parent.Rotation;
				if (flAgitation > 0.1f)
				{
					float flTimeToSettle = this.SettleTime + this.Settings.SettleDuration;
					if (flTimeToSettle > Time.Now)
					{
						float flProportion = (flTimeToSettle - Time.Now) / this.Settings.SettleDuration;
						float flNewAgitation = MathF.Max(this.PrevHighAgitation * flProportion + MathF.Pow(Math.Clamp(flAgitation / this.Settings.Agitation, 0f, 1f), this.Settings.AdditivePower) * flAgitation, flAgitation);
						this.PrevHighAgitation = MathF.Min(this.Settings.Agitation, flNewAgitation);
					}
					else
					{
						this.PrevHighAgitation = MathF.Min(this.Settings.Agitation, flAgitation);
					}
					this.SettleTime = Time.Now;
				}
				if (num > 0.1f)
				{
					float flTimeToSettle2 = this.FoamSettleTime + this.Settings.FoamDuration;
					if (flTimeToSettle2 > Time.Now)
					{
						float flProportion2 = (flTimeToSettle2 - Time.Now) / this.Settings.FoamDuration;
						float flNewAgitation2 = MathF.Max(this.PrevHighFoamAgitation * flProportion2 + MathF.Pow(Math.Clamp(flAgitation / this.Settings.FoamAgitation, 0f, 1f), this.Settings.FoamAdditivePower) * flAgitation, flAgitation);
						this.PrevHighFoamAgitation = MathF.Min(this.Settings.FoamAgitation, flNewAgitation2);
					}
					else
					{
						this.PrevHighFoamAgitation = Math.Min(this.Settings.FoamAgitation, flAgitation);
					}
					this.FoamSettleTime = Time.Now;
				}
				float CurAgitation = this.Remap(Time.Now - this.SettleTime, 0f, this.Settings.SettleDuration, this.PrevHighAgitation, 0f);
				float CurFoamAgitation = this.Remap(Time.Now - this.FoamSettleTime, 0f, this.Settings.FoamDuration, this.PrevHighFoamAgitation, 0f);
				byte nNewAgitation = (byte)this.Remap(CurAgitation, 0f, this.Settings.Agitation, 0f, 255f);
				byte nNewFoamAgitation = (byte)this.Remap(CurFoamAgitation, 0f, this.Settings.FoamAgitation, 0f, 255f);
				ModelEntity parent = this.Parent;
				ModelEntity.LiquidManager.LiquidParameters liquidParameters = default(ModelEntity.LiquidManager.LiquidParameters);
				liquidParameters.PerPropRandom = 0;
				liquidParameters.Bubbles = nNewFoamAgitation;
				liquidParameters.Agitation = nNewAgitation;
				liquidParameters.ForceDirection = PhysicsWorld.Gravity.Normal;
				parent.RenderColor = liquidParameters.ToColor();
			}

			// Token: 0x040010DE RID: 4318
			public ModelEntity.LiquidManager.LiquidSettings Settings;

			// Token: 0x040010DF RID: 4319
			private float PrevHighAgitation;

			// Token: 0x040010E0 RID: 4320
			private float PrevHighFoamAgitation;

			// Token: 0x040010E1 RID: 4321
			private float SettleTime;

			// Token: 0x040010E2 RID: 4322
			private float FoamSettleTime;

			// Token: 0x040010E3 RID: 4323
			private Rotation PrevRotation;

			// Token: 0x040010E4 RID: 4324
			private Vector3 PrevVelocity;

			// Token: 0x040010E5 RID: 4325
			private Vector3 PrevPosition;

			// Token: 0x040010E6 RID: 4326
			private ModelEntity Parent;

			// Token: 0x02000301 RID: 769
			public struct LiquidSettings
			{
				// Token: 0x04001358 RID: 4952
				public float SettleDuration;

				// Token: 0x04001359 RID: 4953
				public float GravityScale;

				// Token: 0x0400135A RID: 4954
				public float Agitation;

				// Token: 0x0400135B RID: 4955
				public float AdditivePower;

				// Token: 0x0400135C RID: 4956
				public float Dampening;

				// Token: 0x0400135D RID: 4957
				public float FoamDuration;

				// Token: 0x0400135E RID: 4958
				public float FoamAgitation;

				// Token: 0x0400135F RID: 4959
				public float FoamAdditivePower;

				// Token: 0x04001360 RID: 4960
				public float FoamDampening;
			}

			// Token: 0x02000302 RID: 770
			internal struct LiquidParameters
			{
				// Token: 0x060020FF RID: 8447 RVA: 0x0007A94C File Offset: 0x00078B4C
				internal byte EncodeDirection(Vector3 vecDir)
				{
					Vector2 vecEncodedDirection = (new Vector2(MathF.Atan2(vecDir.y, vecDir.z) / 3.1415927f, vecDir.x) + new Vector2(1f, 1f)) * 0.5f;
					int num = (int)((byte)Math.Floor((double)((vecEncodedDirection.x + 0.01f) * 15f)));
					byte byteHigh = (byte)Math.Floor((double)((vecEncodedDirection.y + 0.01f) * 15f));
					byte b = (byte)(num & 15);
					byteHigh = (byte)(byteHigh << 4);
					return b | byteHigh;
				}

				// Token: 0x06002100 RID: 8448 RVA: 0x0007A9E0 File Offset: 0x00078BE0
				public Color ToColor()
				{
					return new Color((float)this.PerPropRandom / 255f, (float)this.Bubbles / 255f, (float)this.Agitation / 255f, (float)this.EncodeDirection(this.ForceDirection) / 255f);
				}

				// Token: 0x04001361 RID: 4961
				public byte PerPropRandom;

				// Token: 0x04001362 RID: 4962
				public byte Bubbles;

				// Token: 0x04001363 RID: 4963
				public byte Agitation;

				// Token: 0x04001364 RID: 4964
				public Vector3 ForceDirection;
			}
		}
	}
}
