using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Hammer;
using NativeEngine;
using Sandbox.EntityIO;
using Sandbox.Internal;

namespace Sandbox
{
	/// <summary>
	/// A base entity all other entities derive from.
	/// </summary>
	// Token: 0x02000082 RID: 130
	[Library("entity")]
	public class Entity : BaseNetworkable, IEntity, IValid
	{
		// Token: 0x06000D2C RID: 3372 RVA: 0x00042245 File Offset: 0x00040445
		public Sound PlaySound(string soundName)
		{
			return Sound.FromEntity(soundName, this);
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000D2D RID: 3373 RVA: 0x0004224E File Offset: 0x0004044E
		[Browsable(false)]
		public bool IsClient
		{
			get
			{
				return Host.IsClient;
			}
		}

		/// <summary>
		/// Returns true if this entity is a purely clientside entity, with no serverside components
		/// </summary>
		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000D2E RID: 3374 RVA: 0x00042255 File Offset: 0x00040455
		// (set) Token: 0x06000D2F RID: 3375 RVA: 0x0004225D File Offset: 0x0004045D
		[Browsable(false)]
		public bool IsClientOnly { get; internal set; }

		// Token: 0x06000D30 RID: 3376 RVA: 0x00042268 File Offset: 0x00040468
		internal virtual void ConstructClient()
		{
			this.InitNativePointer();
			if (Entity.IncomingClientInstance.IsValid)
			{
				this.sharedEnt = Entity.IncomingClientInstance;
				this.clientEnt = Entity.IncomingClientInstance;
				this.dataTable = this.clientEnt.GetDataTable();
				this.clientEnt.InitializeEntityObject(this);
				Entity.IncomingClientInstance = IntPtr.Zero;
			}
			else
			{
				this.IsClientOnly = true;
				if (EntitySystem.CreateFromManaged(this.NativeEntityClass, -1, this).IsNull)
				{
					throw new Exception("ConstructClient '" + this.NativeEntityClass + "' not found");
				}
				if (this.clientEnt.IsNull)
				{
					throw new Exception("ConstructClient: 'clientEnt' is null");
				}
			}
			if (!this.clientEnt.IsNull)
			{
				this.InternalOnParentChanged(Entity.GetEntity(this.clientEnt.GetParent()));
			}
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x00042344 File Offset: 0x00040544
		internal void EnterPVSInternal()
		{
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x00042346 File Offset: 0x00040546
		internal void LeavePVSInternal()
		{
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x00042348 File Offset: 0x00040548
		internal void InternalPreDataUpdate()
		{
		}

		// Token: 0x06000D34 RID: 3380 RVA: 0x0004234A File Offset: 0x0004054A
		internal void InternalPostDataUpdate(int hash)
		{
			if (hash != GameAssemblyManager.Hash)
			{
				return;
			}
			this.UpdateTagsFromNetwork();
			this.UpdateClientOwner();
		}

		// Token: 0x06000D35 RID: 3381 RVA: 0x00042361 File Offset: 0x00040561
		internal void InternalNetworkVariableChanged(int hash, int slot, IntPtr data, int dataSize)
		{
			if (hash != GameAssemblyManager.Hash)
			{
				return;
			}
			this.NetworkTable.Read(slot, data, dataSize);
		}

		// Token: 0x06000D36 RID: 3382 RVA: 0x0004237C File Offset: 0x0004057C
		internal virtual void InternalClientCreated()
		{
			this._entityname = this.clientEnt.SB_GetEntityName();
			this.UpdateTagsFromNetwork();
			this.InitNetworkTables();
			this.InternalOnParentChanged(Entity.GetEntity(this.clientEnt.GetParent()));
			this.ClientSpawn();
			this.UpdateClientOwner();
		}

		// Token: 0x06000D37 RID: 3383 RVA: 0x000423C8 File Offset: 0x000405C8
		public virtual void ClientSpawn()
		{
		}

		/// <summary>
		/// Returns true if this entity is dormant (the client cannot see it, it isn't being networked)
		/// </summary>
		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000D38 RID: 3384 RVA: 0x000423CA File Offset: 0x000405CA
		// (set) Token: 0x06000D39 RID: 3385 RVA: 0x000423D2 File Offset: 0x000405D2
		public bool IsDormant { get; private set; }

		/// <summary>
		/// The entity has entered/exited PVS and has stopped being networked
		/// </summary>
		// Token: 0x06000D3A RID: 3386 RVA: 0x000423DB File Offset: 0x000405DB
		internal void InternalOnSetDormant(bool dormant)
		{
			if (this.IsDormant == dormant)
			{
				return;
			}
			this.IsDormant = dormant;
			if (dormant)
			{
				this.OnNetworkDormant();
			}
			else
			{
				this.OnNetworkActive();
			}
			EntityRegistry.Changed(this.EngineIdent);
		}

		/// <summary>
		/// The entity has left the client's visibility and has stopped receiving network updates.
		/// When it becomes active again OnNetworkActive will be called. 
		/// </summary>
		// Token: 0x06000D3B RID: 3387 RVA: 0x0004240A File Offset: 0x0004060A
		public virtual void OnNetworkDormant()
		{
		}

		/// <summary>
		/// Entity has re-entered the client's visibility and has started receiving network updates again.
		/// </summary>
		// Token: 0x06000D3C RID: 3388 RVA: 0x0004240C File Offset: 0x0004060C
		public virtual void OnNetworkActive()
		{
		}

		// Token: 0x06000D3D RID: 3389 RVA: 0x0004240E File Offset: 0x0004060E
		internal void InternalClientActivate()
		{
			this.OnActive();
		}

		/// <summary>
		/// Entity is active (clientside). This is called after spawn.
		/// </summary>
		// Token: 0x06000D3E RID: 3390 RVA: 0x00042416 File Offset: 0x00040616
		public virtual void OnActive()
		{
		}

		// Token: 0x06000D3F RID: 3391 RVA: 0x00042418 File Offset: 0x00040618
		internal void InternalOnNameChanged(string newName)
		{
			this._entityname = newName;
		}

		// Token: 0x06000D40 RID: 3392 RVA: 0x00042424 File Offset: 0x00040624
		internal void InternalPhysicsCollisionEvent(Entity hitEntity, Vector3 hitPos, Vector3 hitSpeed, Vector3 hitNormal, Vector3 preVelocity, Vector3 postVelocity, Vector3 preAngularVelocity, float speed)
		{
			this.OnPhysicsCollision(new CollisionEventData
			{
				Entity = hitEntity,
				Pos = hitPos,
				Velocity = hitSpeed,
				Normal = hitNormal,
				Speed = speed,
				PreVelocity = preVelocity,
				PostVelocity = postVelocity,
				PreAngularVelocity = preAngularVelocity
			});
		}

		// Token: 0x06000D41 RID: 3393 RVA: 0x00042485 File Offset: 0x00040685
		protected virtual void OnPhysicsCollision(CollisionEventData eventData)
		{
		}

		// Token: 0x06000D42 RID: 3394 RVA: 0x00042488 File Offset: 0x00040688
		internal virtual void OnComponentAddedInternal(EntityComponent component)
		{
			if (this._components == null)
			{
				this._components = new List<EntityComponent>();
			}
			this._components.Add(component);
			if (Host.IsServer)
			{
				this.NetworkComponents.Add(component);
			}
			try
			{
				this.OnComponentAdded(component);
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Error(e);
			}
			if (component.Enabled)
			{
				Event.Register(component);
				component.EnableStateChanged(true);
			}
		}

		/// <summary>
		/// A component has been added to the entity.
		/// </summary>
		// Token: 0x06000D43 RID: 3395 RVA: 0x00042504 File Offset: 0x00040704
		protected virtual void OnComponentAdded(EntityComponent component)
		{
		}

		// Token: 0x06000D44 RID: 3396 RVA: 0x00042508 File Offset: 0x00040708
		internal virtual void OnComponentRemovedInternal(EntityComponent component)
		{
			List<EntityComponent> components = this._components;
			if (components != null)
			{
				components.Remove(component);
			}
			Event.Unregister(component);
			if (Host.IsServer)
			{
				this.NetworkComponents.Remove(component);
			}
			if (component.Enabled)
			{
				component.EnableStateChanged(false);
			}
			try
			{
				this.OnComponentRemoved(component);
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Error(e);
			}
		}

		/// <summary>
		/// A component has been removed from the entity.
		/// </summary>
		// Token: 0x06000D45 RID: 3397 RVA: 0x00042578 File Offset: 0x00040778
		protected virtual void OnComponentRemoved(EntityComponent component)
		{
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x0004257A File Offset: 0x0004077A
		internal void OnComponentEnableStateChangedInternal(EntityComponent component, bool enabled)
		{
			if (enabled)
			{
				Event.Register(component);
			}
			else
			{
				Event.Unregister(component);
			}
			component.EnableStateChanged(enabled);
		}

		/// <summary>
		/// Returns true if we have authority over this entity. This means we're either serverside,
		/// or we're a clientside entity, or we're a serverside entity being predicted on the client.
		/// </summary>
		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000D47 RID: 3399 RVA: 0x00042594 File Offset: 0x00040794
		[Browsable(false)]
		public bool IsAuthority
		{
			get
			{
				return Host.IsServer || this.IsClientOnly || this.IsPredictable();
			}
		}

		/// <summary>
		/// The name of the entity to create in the entity to base this
		/// entity off.
		/// </summary>
		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000D48 RID: 3400 RVA: 0x000425AD File Offset: 0x000407AD
		internal virtual string NativeEntityClass
		{
			get
			{
				return "baseentity";
			}
		}

		/// <summary>
		/// Returns true if this entity is the world
		/// </summary>
		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000D49 RID: 3401 RVA: 0x000425B4 File Offset: 0x000407B4
		[Browsable(false)]
		public bool IsWorld
		{
			get
			{
				return this.IsValid && this.NetworkIdent == 0;
			}
		}

		/// <summary>
		/// Returns true if this entity has not been destroyed and it is valid to access its internals
		/// </summary>
		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000D4A RID: 3402 RVA: 0x000425C9 File Offset: 0x000407C9
		[Browsable(false)]
		public bool IsValid
		{
			get
			{
				return this.sharedEnt.IsValid;
			}
		}

		/// <summary>
		/// Returns true if this specific entity instance was spawned from the map.
		/// </summary>
		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000D4B RID: 3403 RVA: 0x000425D6 File Offset: 0x000407D6
		[Browsable(false)]
		public bool IsFromMap
		{
			get
			{
				return this.HasEntityEffect(EntityEffects.SpawnedWithMap);
			}
		}

		// Token: 0x06000D4C RID: 3404 RVA: 0x000425E3 File Offset: 0x000407E3
		internal void AuthorityCheck()
		{
			if (this.IsAuthority)
			{
				return;
			}
			throw new Exception("No Authority - This server entity needs to be predictable for you to change it clientside.");
		}

		/// <summary>
		/// The entity target name. This is typically used by map IO and to generally access specific entities from code.
		/// </summary>
		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000D4D RID: 3405 RVA: 0x000425F8 File Offset: 0x000407F8
		// (set) Token: 0x06000D4E RID: 3406 RVA: 0x00042600 File Offset: 0x00040800
		[Category("Meta")]
		public string Name
		{
			get
			{
				return this._entityname;
			}
			set
			{
				if (value == this._entityname)
				{
					return;
				}
				this._entityname = value;
				if (this.serverEnt.IsValid)
				{
					this.serverEnt.SB_SetEntityName(value);
				}
				if (this.clientEnt.IsValid)
				{
					this.clientEnt.SB_SetEntityName(value);
				}
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000D4F RID: 3407 RVA: 0x00042655 File Offset: 0x00040855
		[Obsolete]
		public string EntityName
		{
			get
			{
				return this.Name;
			}
		}

		/// <summary>
		/// The entity's position relative to its parent (or the world if no parent)
		/// </summary>
		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000D50 RID: 3408 RVA: 0x0004265D File Offset: 0x0004085D
		// (set) Token: 0x06000D51 RID: 3409 RVA: 0x0004269B File Offset: 0x0004089B
		[Property]
		[Skip]
		[Browsable(false)]
		public virtual Vector3 LocalPosition
		{
			get
			{
				if (!this.clientEnt.IsNull)
				{
					return this.clientEnt.GetLocalOrigin();
				}
				if (!this.serverEnt.IsNull)
				{
					return this.serverEnt.GetLocalOrigin();
				}
				throw new Exception("Invalid Entity");
			}
			set
			{
				this.AuthorityCheck();
				if (!this.clientEnt.IsNull)
				{
					this.clientEnt.SetLocalOrigin(value);
				}
				if (!this.serverEnt.IsNull)
				{
					this.serverEnt.SetLocalOrigin(value);
				}
			}
		}

		/// <summary>
		/// The entity's position relative to its parent (or the world if no parent)
		/// </summary>
		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000D52 RID: 3410 RVA: 0x000426D5 File Offset: 0x000408D5
		// (set) Token: 0x06000D53 RID: 3411 RVA: 0x00042714 File Offset: 0x00040914
		[Property]
		[Skip]
		[Category("Transform")]
		public virtual Vector3 Position
		{
			get
			{
				if (!this.clientEnt.IsNull)
				{
					return this.clientEnt.GetAbsOrigin();
				}
				if (!this.serverEnt.IsNull)
				{
					return this.serverEnt.GetAbsOrigin();
				}
				throw new Exception("Invalid Entity");
			}
			set
			{
				this.AuthorityCheck();
				if (!this.clientEnt.IsNull)
				{
					this.clientEnt.SetAbsOrigin(value);
				}
				if (!this.serverEnt.IsNull)
				{
					Vector3 oldPos = this.serverEnt.GetAbsOrigin();
					PhysicsGroup phys = this.serverEnt.VPhysicsGetAggregate();
					if (phys != null)
					{
						foreach (PhysicsBody body in phys.Bodies)
						{
							if (body.IsValid())
							{
								body.Position = value - (oldPos - body.Position);
							}
						}
					}
					this.serverEnt.SetAbsOrigin(value);
				}
			}
		}

		/// <summary>
		/// The entity's world rotation
		/// </summary>
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000D54 RID: 3412 RVA: 0x000427D0 File Offset: 0x000409D0
		// (set) Token: 0x06000D55 RID: 3413 RVA: 0x00042818 File Offset: 0x00040A18
		[Property]
		[Skip]
		[Category("Transform")]
		public virtual Rotation Rotation
		{
			get
			{
				if (!this.serverEnt.IsNull)
				{
					return this.serverEnt.GetAbsQuat();
				}
				if (!this.clientEnt.IsNull)
				{
					return this.clientEnt.GetAbsQuat();
				}
				return default(Rotation);
			}
			set
			{
				this.AuthorityCheck();
				if (!this.serverEnt.IsNull)
				{
					this.serverEnt.SetAbsQuat(value);
				}
				if (!this.clientEnt.IsNull)
				{
					this.clientEnt.SetAbsQuat(value);
				}
			}
		}

		/// <summary>
		/// The entity's angle
		/// </summary>
		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000D56 RID: 3414 RVA: 0x00042854 File Offset: 0x00040A54
		// (set) Token: 0x06000D57 RID: 3415 RVA: 0x00042883 File Offset: 0x00040A83
		[Property]
		[Skip]
		[Obsolete]
		[Browsable(false)]
		public Angles WorldAng
		{
			get
			{
				if (!this.serverEnt.IsNull)
				{
					return this.serverEnt.GetAbsAngles();
				}
				return default(Angles);
			}
			set
			{
				this.AuthorityCheck();
				if (!this.serverEnt.IsNull)
				{
					this.serverEnt.SetAbsAngles(value);
				}
			}
		}

		/// <summary>
		/// The entity's local rotation
		/// </summary>
		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000D58 RID: 3416 RVA: 0x000428A4 File Offset: 0x00040AA4
		// (set) Token: 0x06000D59 RID: 3417 RVA: 0x000428EC File Offset: 0x00040AEC
		[Property]
		[Skip]
		[Browsable(false)]
		public virtual Rotation LocalRotation
		{
			get
			{
				if (!this.serverEnt.IsNull)
				{
					return this.serverEnt.GetLocalQuat();
				}
				if (!this.clientEnt.IsNull)
				{
					return this.clientEnt.GetLocalQuat();
				}
				return default(Rotation);
			}
			set
			{
				this.AuthorityCheck();
				if (!this.serverEnt.IsNull)
				{
					this.serverEnt.SetLocalQuat(value);
				}
				if (!this.clientEnt.IsNull)
				{
					this.clientEnt.SetLocalQuat(value);
				}
			}
		}

		/// <summary>
		/// The entity's local scale
		/// </summary>
		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000D5A RID: 3418 RVA: 0x00042926 File Offset: 0x00040B26
		// (set) Token: 0x06000D5B RID: 3419 RVA: 0x0004295F File Offset: 0x00040B5F
		[Property]
		[Skip]
		[Browsable(false)]
		public virtual float LocalScale
		{
			get
			{
				if (!this.serverEnt.IsNull)
				{
					return this.serverEnt.GetLocalScale();
				}
				if (!this.clientEnt.IsNull)
				{
					return this.clientEnt.GetLocalScale();
				}
				return 0f;
			}
			set
			{
				this.AuthorityCheck();
				if (!this.serverEnt.IsNull)
				{
					this.serverEnt.SetLocalScale(value);
				}
				if (!this.clientEnt.IsNull)
				{
					this.clientEnt.SetLocalScale(value);
				}
			}
		}

		/// <summary>
		/// The scale of the entity. 1 is normal.
		/// </summary>
		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000D5C RID: 3420 RVA: 0x00042999 File Offset: 0x00040B99
		// (set) Token: 0x06000D5D RID: 3421 RVA: 0x000429D4 File Offset: 0x00040BD4
		[Property]
		[Skip]
		[Category("Transform")]
		public virtual float Scale
		{
			get
			{
				if (!this.serverEnt.IsNull)
				{
					return this.serverEnt.GetAbsScale();
				}
				if (!this.clientEnt.IsNull)
				{
					return this.clientEnt.GetAbsScale();
				}
				return 0f;
			}
			set
			{
				this.AuthorityCheck();
				if (value <= 0f)
				{
					return;
				}
				if (!this.serverEnt.IsNull)
				{
					this.serverEnt.SetAbsScale(value);
				}
				if (!this.clientEnt.IsNull)
				{
					this.clientEnt.SetAbsScale(value);
				}
			}
		}

		/// <summary>
		/// The velocity in world coords.
		/// </summary>
		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000D5E RID: 3422 RVA: 0x00042A22 File Offset: 0x00040C22
		// (set) Token: 0x06000D5F RID: 3423 RVA: 0x00042A60 File Offset: 0x00040C60
		[Property]
		[Skip]
		[Category("Transform")]
		[Browsable(false)]
		public virtual Vector3 Velocity
		{
			get
			{
				if (!this.clientEnt.IsNull)
				{
					return this.clientEnt.GetAbsVelocity();
				}
				if (!this.serverEnt.IsNull)
				{
					return this.serverEnt.GetAbsVelocity();
				}
				throw new Exception("Invalid Entity");
			}
			set
			{
				this.AuthorityCheck();
				if (!this.clientEnt.IsNull)
				{
					this.clientEnt.SetAbsVelocity(value);
				}
				if (!this.serverEnt.IsNull)
				{
					this.serverEnt.SetAbsVelocity(value);
				}
			}
		}

		/// <summary>
		/// The angular velocity in local coords
		/// </summary>
		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000D60 RID: 3424 RVA: 0x00042A9A File Offset: 0x00040C9A
		// (set) Token: 0x06000D61 RID: 3425 RVA: 0x00042AD8 File Offset: 0x00040CD8
		[Property]
		[Skip]
		[Category("Transform")]
		[Browsable(false)]
		public virtual Angles AngularVelocity
		{
			get
			{
				if (!this.clientEnt.IsNull)
				{
					return this.clientEnt.GetLocalAngularVelocity();
				}
				if (!this.serverEnt.IsNull)
				{
					return this.serverEnt.GetLocalAngularVelocity();
				}
				throw new Exception("Invalid Entity");
			}
			set
			{
				this.AuthorityCheck();
				if (!this.clientEnt.IsNull)
				{
					this.clientEnt.SetLocalAngularVelocity(value);
				}
				if (!this.serverEnt.IsNull)
				{
					this.serverEnt.SetLocalAngularVelocity(value);
				}
			}
		}

		/// <summary>
		/// Velocity in local coords
		/// </summary>
		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000D62 RID: 3426 RVA: 0x00042B12 File Offset: 0x00040D12
		// (set) Token: 0x06000D63 RID: 3427 RVA: 0x00042B50 File Offset: 0x00040D50
		[Property]
		[Skip]
		[Browsable(false)]
		public virtual Vector3 LocalVelocity
		{
			get
			{
				if (!this.clientEnt.IsNull)
				{
					return this.clientEnt.GetLocalVelocity();
				}
				if (!this.serverEnt.IsNull)
				{
					return this.serverEnt.GetLocalVelocity();
				}
				throw new Exception("Invalid Entity");
			}
			set
			{
				this.AuthorityCheck();
				if (!this.clientEnt.IsNull)
				{
					this.clientEnt.SetLocalVelocity(value);
				}
				if (!this.serverEnt.IsNull)
				{
					this.serverEnt.SetLocalVelocity(value);
				}
			}
		}

		/// <summary>
		/// Generally describes the velocity of this object that is caused by its parent moving.
		/// Examples would be conveyor belts and elevators.
		/// </summary>
		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000D64 RID: 3428 RVA: 0x00042B8A File Offset: 0x00040D8A
		// (set) Token: 0x06000D65 RID: 3429 RVA: 0x00042BBE File Offset: 0x00040DBE
		[Browsable(false)]
		public Vector3 BaseVelocity
		{
			get
			{
				if (this.IsClient)
				{
					return this.clientEnt.GetBaseVelocity();
				}
				if (this.IsServer)
				{
					return this.serverEnt.GetBaseVelocity();
				}
				throw new Exception("Invalid Entity");
			}
			set
			{
				this.AuthorityCheck();
				if (this.IsClient)
				{
					this.clientEnt.SetBaseVelocity(value);
				}
				if (this.IsServer)
				{
					this.serverEnt.SetBaseVelocity(value);
				}
			}
		}

		/// <summary>
		/// Generally describes the velocity of this object that is caused by its parent moving.
		/// Examples would be conveyor belts and elevators.
		/// </summary>
		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000D66 RID: 3430 RVA: 0x00042BEE File Offset: 0x00040DEE
		// (set) Token: 0x06000D67 RID: 3431 RVA: 0x00042C2C File Offset: 0x00040E2C
		[Browsable(false)]
		public Entity GroundEntity
		{
			get
			{
				if (this.IsClient)
				{
					return Entity.GetEntity(this.clientEnt.GetGroundEntity());
				}
				if (this.IsServer)
				{
					return Entity.GetEntity(this.serverEnt.GetGroundEntity());
				}
				throw new Exception("Invalid Entity");
			}
			set
			{
				this.AuthorityCheck();
				if (this.IsClient)
				{
					this.clientEnt.SetGroundEntity((value == null) ? IntPtr.Zero : value.clientEnt);
				}
				if (this.IsServer)
				{
					this.serverEnt.SetGroundEntity((value == null) ? IntPtr.Zero : value.serverEnt);
				}
			}
		}

		// Token: 0x06000D68 RID: 3432 RVA: 0x00042C8F File Offset: 0x00040E8F
		public void ApplyAbsoluteImpulse(Vector3 impulse)
		{
			this.AuthorityCheck();
			if (this.IsClient)
			{
				this.clientEnt.ApplyAbsVelocityImpulse(impulse);
			}
			if (this.IsServer)
			{
				this.serverEnt.ApplyAbsVelocityImpulse(impulse);
			}
		}

		// Token: 0x06000D69 RID: 3433 RVA: 0x00042CBF File Offset: 0x00040EBF
		public void ApplyLocalImpulse(Vector3 impulse)
		{
			this.AuthorityCheck();
			if (this.IsClient)
			{
				this.clientEnt.ApplyLocalVelocityImpulse(impulse);
			}
			if (this.IsServer)
			{
				this.serverEnt.ApplyLocalVelocityImpulse(impulse);
			}
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x00042CEF File Offset: 0x00040EEF
		public void ApplyLocalAngularImpulse(Vector3 impulse)
		{
			this.AuthorityCheck();
			if (this.IsClient)
			{
				this.clientEnt.ApplyLocalAngularVelocityImpulse(impulse);
			}
			if (this.IsServer)
			{
				this.serverEnt.ApplyLocalAngularVelocityImpulse(impulse);
			}
		}

		// Token: 0x06000D6B RID: 3435 RVA: 0x00042D1F File Offset: 0x00040F1F
		public void RemoveAllDecals()
		{
			this.AuthorityCheck();
			if (this.IsClient)
			{
				this.clientEnt.RemoveAllDecals();
			}
			if (this.IsServer)
			{
				this.serverEnt.RemoveAllDecals();
			}
		}

		/// <summary>
		/// The internal class name of this entity. For debug purposes only.
		/// </summary>
		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000D6C RID: 3436 RVA: 0x00042D50 File Offset: 0x00040F50
		[Property]
		[Skip]
		[Category("Debug")]
		public string EngineEntityName
		{
			get
			{
				if (this._engineEntityName != null)
				{
					return this._engineEntityName;
				}
				if (!this.serverEnt.IsNull)
				{
					this._engineEntityName = this.serverEnt.GetClassname();
				}
				else if (!this.clientEnt.IsNull)
				{
					this._engineEntityName = this.clientEnt.GetClassname();
				}
				return this._engineEntityName;
			}
		}

		// Token: 0x06000D6D RID: 3437 RVA: 0x00042DB0 File Offset: 0x00040FB0
		public Entity()
			: this(null)
		{
		}

		// Token: 0x06000D6E RID: 3438 RVA: 0x00042DBC File Offset: 0x00040FBC
		internal Entity(string engineEntity)
		{
			this.SpawnFlags = new SpawnFlagAccessor(this);
			this.Tags = new EntityTags(this);
			this.WaterLevel = new WaterLevel(this);
			this.Components = new EntityComponentAccessor(this);
			this.CreateHammerOutputs();
			if (this.IsServer)
			{
				this.ConstructServer(engineEntity ?? this.NativeEntityClass);
			}
			if (this.IsClient)
			{
				this.ConstructClient();
			}
			this.AddToLists();
		}

		/// <summary>
		/// Called when we hotload
		/// </summary>
		// Token: 0x06000D6F RID: 3439 RVA: 0x00042E46 File Offset: 0x00041046
		internal virtual void OnHotloaded()
		{
			this.InitNetworkTables();
			this.CreateHammerOutputs();
			this.PredictionDestroy();
		}

		// Token: 0x06000D70 RID: 3440 RVA: 0x00042E5A File Offset: 0x0004105A
		private void AddToLists()
		{
			Entity.InternalAll.Add(this);
			if (this.NetworkIdent >= 0)
			{
				this.AddToListsWithId();
			}
			Event.Register(this);
		}

		// Token: 0x06000D71 RID: 3441 RVA: 0x00042E7C File Offset: 0x0004107C
		private void AddToListsWithId()
		{
			if (this.addedToLists)
			{
				return;
			}
			this.addedToLists = true;
			Entity.Index[this.NetworkIdent] = this;
			EntityRegistry.Add(Host.IsServer, this.EngineIdent, this);
		}

		// Token: 0x06000D72 RID: 3442 RVA: 0x00042EB0 File Offset: 0x000410B0
		private void RemoveFromLists()
		{
			Entity.InternalAll.Remove(this);
			Event.Unregister(this);
			if (this.addedToLists)
			{
				this.addedToLists = false;
				Entity.Index.Remove(this.NetworkIdent);
				EntityRegistry.Remove(Host.IsServer, this.EngineIdent);
			}
			if (this._components != null)
			{
				foreach (EntityComponent entityComponent in this._components)
				{
					entityComponent.EnableStateChanged(false);
					entityComponent.Entity = null;
					Event.Unregister(entityComponent);
				}
				this._components.Clear();
				this._components = null;
			}
		}

		/// <summary>
		/// Careful and know what you're doing! This returns the raw pointer
		/// for the C_BaseEntity or the CBaseEntity - depending on what realm we're in
		/// </summary>
		// Token: 0x06000D73 RID: 3443 RVA: 0x00042F6C File Offset: 0x0004116C
		internal IntPtr GetEntityIntPtr()
		{
			if (this.IsClient)
			{
				return this.clientEnt.self;
			}
			if (this.IsServer)
			{
				return this.serverEnt.self;
			}
			return IntPtr.Zero;
		}

		// Token: 0x06000D74 RID: 3444 RVA: 0x00042F9B File Offset: 0x0004119B
		private void InitNativePointer()
		{
			InteropSystem.Alloc<Entity>(this);
		}

		// Token: 0x06000D75 RID: 3445 RVA: 0x00042FA4 File Offset: 0x000411A4
		internal virtual void OnNativeEntity(CEntityInstance ent)
		{
			if (this.IsServer)
			{
				this.sharedEnt = ent;
				this.serverEnt = (CBaseEntity)this.sharedEnt;
				this.dataTable = this.serverEnt.GetDataTable();
				this._entityname = this.serverEnt.SB_GetEntityName();
				if (base.ClassInfo != null && base.ClassInfo.Identifier != 0)
				{
					this.serverEnt.m_ManagedClassIdent = base.ClassInfo.Identifier;
				}
				else
				{
					Entity.log.Warning(FormattableStringFactory.Create("ClassInfo for class failed {0} ({1})", new object[] { this, base.ClassInfo }));
				}
				this.InitNetworkTables();
			}
			if (this.IsClient)
			{
				this.sharedEnt = ent;
				this.clientEnt = (C_BaseEntity)ent;
				this.dataTable = this.clientEnt.GetDataTable();
				this._entityname = this.clientEnt.SB_GetEntityName();
				if (this.IsClientOnly)
				{
					this.InitNetworkTables();
				}
			}
		}

		// Token: 0x06000D76 RID: 3446 RVA: 0x0004309B File Offset: 0x0004129B
		protected virtual void OnDestroy()
		{
		}

		// Token: 0x06000D77 RID: 3447 RVA: 0x0004309D File Offset: 0x0004129D
		public virtual void Spawn()
		{
		}

		// Token: 0x06000D78 RID: 3448 RVA: 0x000430A0 File Offset: 0x000412A0
		internal virtual void InternalSpawn()
		{
			string internalName = this.sharedEnt.GetEntityNameAsCStr();
			if (string.IsNullOrWhiteSpace(internalName))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted(base.GetType().Name);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.NetworkIdent);
				internalName = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			this.Name = internalName;
			if (this.NetworkIdent >= 0)
			{
				this.AddToListsWithId();
			}
			this.Spawn();
		}

		// Token: 0x06000D79 RID: 3449 RVA: 0x00043119 File Offset: 0x00041319
		internal void AddFlag(EntityFlag flag)
		{
			if (!this.serverEnt.IsNull)
			{
				this.serverEnt.AddFlag((int)flag);
			}
			if (!this.clientEnt.IsNull)
			{
				this.clientEnt.AddFlag((int)flag);
			}
		}

		/// <summary>
		/// Delete this entity. You shouldn't access it anymore.
		/// </summary>
		// Token: 0x06000D7A RID: 3450 RVA: 0x00043150 File Offset: 0x00041350
		public void Delete()
		{
			this.IsBeingDeleted = true;
			if (!this.serverEnt.IsNull)
			{
				ServerGlobal.UTIL_Remove(this.serverEnt);
			}
			if (!this.clientEnt.IsNull)
			{
				if (!this.IsClientOnly)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(95, 1);
					defaultInterpolatedStringHandler.AppendLiteral("[");
					defaultInterpolatedStringHandler.AppendFormatted<Entity>(this);
					defaultInterpolatedStringHandler.AppendLiteral("] You can't delete this entity clientside - it's a networked entity - delete it on the server!");
					throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				Entity[] array = this.Children.ToArray<Entity>();
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Delete();
				}
				ClientGlobal.UTIL_Remove(this.clientEnt);
			}
		}

		/// <summary>
		/// Delete the entity after given delay in seconds.
		/// </summary>
		// Token: 0x06000D7B RID: 3451 RVA: 0x000431F8 File Offset: 0x000413F8
		public async Task DeleteAsync(float fTime)
		{
			await this.Task.DelaySeconds(fTime);
			this.Delete();
		}

		// Token: 0x06000D7C RID: 3452 RVA: 0x00043244 File Offset: 0x00041444
		internal virtual void InternalDestruct()
		{
			this.sharedEnt = IntPtr.Zero;
			this.serverEnt = IntPtr.Zero;
			this.clientEnt = IntPtr.Zero;
			this.dataTable = IntPtr.Zero;
			InteropSystem.Free<Entity>(this);
			this.Task.Expire();
			this.RemoveFromLists();
		}

		// Token: 0x06000D7D RID: 3453 RVA: 0x000432A8 File Offset: 0x000414A8
		internal virtual void InternalUpdateOnRemove()
		{
			try
			{
				if (!this.IsClientOnly && this.IsClient)
				{
					foreach (Entity child in this.Children.ToArray<Entity>())
					{
						if (child.IsClientOnly)
						{
							child.Delete();
						}
					}
				}
				this.InternalOnParentChanged(null);
				this.OnDestroy();
			}
			catch (Exception e)
			{
				Entity.log.Error(e);
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000D7E RID: 3454 RVA: 0x00043320 File Offset: 0x00041520
		// (set) Token: 0x06000D7F RID: 3455 RVA: 0x00043328 File Offset: 0x00041528
		[Browsable(false)]
		public Entity LastAttacker { get; set; }

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000D80 RID: 3456 RVA: 0x00043331 File Offset: 0x00041531
		// (set) Token: 0x06000D81 RID: 3457 RVA: 0x00043339 File Offset: 0x00041539
		[Browsable(false)]
		public Entity LastAttackerWeapon { get; set; }

		// Token: 0x06000D82 RID: 3458 RVA: 0x00043344 File Offset: 0x00041544
		public virtual void TakeDamage(DamageInfo info)
		{
			this.LastAttacker = info.Attacker;
			this.LastAttackerWeapon = info.Weapon;
			if (this.IsServer && this.Health > 0f && this.LifeState == LifeState.Alive)
			{
				this.Health -= info.Damage;
				if (this.Health <= 0f)
				{
					this.Health = 0f;
					this.OnKilled();
				}
			}
		}

		/// <summary>
		/// Called when there's no health left
		/// </summary>
		// Token: 0x06000D83 RID: 3459 RVA: 0x000433BA File Offset: 0x000415BA
		public virtual void OnKilled()
		{
			if (this.LifeState != LifeState.Alive)
			{
				return;
			}
			this.LifeState = LifeState.Dead;
			this.Delete();
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000D84 RID: 3460 RVA: 0x000433D2 File Offset: 0x000415D2
		// (set) Token: 0x06000D85 RID: 3461 RVA: 0x0004340B File Offset: 0x0004160B
		[Category("Life")]
		public float Health
		{
			get
			{
				if (!this.clientEnt.IsNull)
				{
					return this.clientEnt.m_fHealth;
				}
				if (!this.serverEnt.IsNull)
				{
					return this.serverEnt.m_fHealth;
				}
				return 0f;
			}
			set
			{
				if (!this.clientEnt.IsNull)
				{
					this.clientEnt.m_fHealth = value;
				}
				if (!this.serverEnt.IsNull)
				{
					this.serverEnt.m_fHealth = value;
				}
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000D86 RID: 3462 RVA: 0x0004343F File Offset: 0x0004163F
		// (set) Token: 0x06000D87 RID: 3463 RVA: 0x0004346A File Offset: 0x0004166A
		[Category("Life")]
		public LifeState LifeState
		{
			get
			{
				if (this.IsClient)
				{
					return this.clientEnt.GetLifeState();
				}
				if (this.IsServer)
				{
					return this.serverEnt.GetLifeState();
				}
				return LifeState.Alive;
			}
			set
			{
				if (this.IsClient)
				{
					this.clientEnt.SetLifeState(value);
				}
				if (this.IsServer)
				{
					this.serverEnt.SetLifeState(value);
				}
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000D88 RID: 3464 RVA: 0x00043494 File Offset: 0x00041694
		// (set) Token: 0x06000D89 RID: 3465 RVA: 0x000434BF File Offset: 0x000416BF
		[Category("Movement")]
		public MoveType MoveType
		{
			get
			{
				if (this.IsClient)
				{
					return this.clientEnt.GetMoveType();
				}
				if (this.IsServer)
				{
					return this.serverEnt.GetMoveType();
				}
				return MoveType.None;
			}
			set
			{
				if (this.IsClient)
				{
					this.clientEnt.SetMoveType(value, MoveCollide.MOVECOLLIDE_DEFAULT);
				}
				if (this.IsServer)
				{
					this.serverEnt.SetMoveType(value, MoveCollide.MOVECOLLIDE_DEFAULT);
				}
			}
		}

		/// <summary>
		/// Reset the interpolation.
		/// You can use this so if you move an entity it doesn't lerp to the new position
		/// </summary>
		// Token: 0x06000D8A RID: 3466 RVA: 0x000434EB File Offset: 0x000416EB
		public void ResetInterpolation()
		{
			if (!this.clientEnt.IsNull)
			{
				this.clientEnt.ResetLatched();
			}
			if (!this.serverEnt.IsNull)
			{
				this.serverEnt.IncrementInterpolationFrame();
			}
		}

		/// <summary>
		/// I don't think we need to give people access to this?
		/// </summary>
		// Token: 0x06000D8B RID: 3467 RVA: 0x0004351D File Offset: 0x0004171D
		internal void SetSimulationTime(float time)
		{
			if (!this.clientEnt.IsNull)
			{
				this.clientEnt.SetSimulationTime(time);
			}
			if (!this.serverEnt.IsNull)
			{
				this.serverEnt.SetSimulationTime(time);
			}
		}

		// Token: 0x06000D8C RID: 3468 RVA: 0x00043551 File Offset: 0x00041751
		internal virtual void InternalOnNewModel()
		{
		}

		// Token: 0x06000D8D RID: 3469 RVA: 0x00043553 File Offset: 0x00041753
		internal virtual void InternalAnimEvent(string name, int intData, float floatData, Vector3 vectorData, string stringData)
		{
		}

		// Token: 0x06000D8E RID: 3470 RVA: 0x00043555 File Offset: 0x00041755
		internal virtual void InternalAnimEventFootstep(Vector3 pos, int foot, float volume)
		{
		}

		// Token: 0x06000D8F RID: 3471 RVA: 0x00043557 File Offset: 0x00041757
		internal virtual void InternalMoveDone()
		{
		}

		// Token: 0x06000D90 RID: 3472 RVA: 0x00043559 File Offset: 0x00041759
		internal virtual void InternalMoveBlocked(Entity entity)
		{
		}

		/// <summary>
		/// Called when simulating as part of a player's tick. Like if it's a pawn.
		/// </summary>
		// Token: 0x06000D91 RID: 3473 RVA: 0x0004355B File Offset: 0x0004175B
		public virtual void Simulate(Client cl)
		{
		}

		/// <summary>
		/// Called each frame clientside only on Pawn (and anything the pawn decides to call it on)
		/// </summary>
		// Token: 0x06000D92 RID: 3474 RVA: 0x0004355D File Offset: 0x0004175D
		public virtual void FrameSimulate(Client cl)
		{
			Host.AssertClient("FrameSimulate");
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000D93 RID: 3475 RVA: 0x00043569 File Offset: 0x00041769
		// (set) Token: 0x06000D94 RID: 3476 RVA: 0x0004357C File Offset: 0x0004177C
		public ICamera Camera
		{
			get
			{
				VarClass<ICamera> _camera = this.__camera;
				if (_camera == null)
				{
					return null;
				}
				return _camera.GetValue();
			}
			set
			{
				VarClass<ICamera> _camera = this.__camera;
				if (_camera == null)
				{
					return;
				}
				_camera.SetValue(value);
			}
		}

		/// <summary>
		/// Pawns get a chance to mess with the input clientside
		/// </summary>
		// Token: 0x06000D95 RID: 3477 RVA: 0x00043590 File Offset: 0x00041790
		public virtual void BuildInput(InputBuilder inputBuilder)
		{
			Host.AssertClient("BuildInput");
			if (this != Local.Pawn)
			{
				return;
			}
			if (!inputBuilder.UsingController)
			{
				inputBuilder.AnalogLook.pitch = inputBuilder.AnalogLook.pitch * 1.5f;
			}
			inputBuilder.ViewAngles = inputBuilder.ViewAngles.Normal;
			if (inputBuilder.ViewAngles.pitch > 90f || inputBuilder.ViewAngles.pitch < -90f)
			{
				inputBuilder.AnalogLook.yaw = inputBuilder.AnalogLook.yaw * -1f;
			}
			inputBuilder.ViewAngles += inputBuilder.AnalogLook;
			inputBuilder.InputDirection = inputBuilder.AnalogMove;
		}

		/// <summary>
		/// Get the client owner. This will ascend up the owner chain to find the actual owner.
		/// </summary>
		// Token: 0x06000D96 RID: 3478 RVA: 0x00043638 File Offset: 0x00041838
		[Obsolete("Use Client instead")]
		public Client GetClientOwner()
		{
			return this.Client;
		}

		// Token: 0x06000D97 RID: 3479 RVA: 0x00043640 File Offset: 0x00041840
		internal Client FindClientOwner()
		{
			ClientEntity ce = this as ClientEntity;
			if (ce != null)
			{
				return ce;
			}
			Entity owner = this.Owner;
			return ((owner != null) ? owner.FindClientOwner() : null) ?? null;
		}

		/// <summary>
		/// The client that owns this entity. Usualy as a result of being the client's Pawn.
		/// Also could be because the client's pawn owns this entity,
		/// </summary>
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000D98 RID: 3480 RVA: 0x00043670 File Offset: 0x00041870
		// (set) Token: 0x06000D99 RID: 3481 RVA: 0x00043678 File Offset: 0x00041878
		public Client Client { get; internal set; }

		// Token: 0x06000D9A RID: 3482 RVA: 0x00043684 File Offset: 0x00041884
		internal void UpdateClientOwner()
		{
			Client owner = this.FindClientOwner();
			if (this.Client == owner)
			{
				return;
			}
			this.Client = owner;
			foreach (Entity entity in this.Children)
			{
				entity.UpdateClientOwner();
			}
		}

		/// <summary>
		/// Will return true if we're clientside, this entity has an owner and we're
		/// currently treating this owner as the local client. This means the player
		/// could be being spectated.
		/// </summary>
		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000D9B RID: 3483 RVA: 0x000436E8 File Offset: 0x000418E8
		public virtual bool IsLocalPawn
		{
			get
			{
				return this.IsClient && this.Owner != null && (Local.Client == this.Owner || this.Owner.IsLocalPawn);
			}
		}

		/// <summary>
		/// Position a player should be looking from in world space.
		/// </summary>
		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000D9C RID: 3484 RVA: 0x00043718 File Offset: 0x00041918
		// (set) Token: 0x06000D9D RID: 3485 RVA: 0x0004373C File Offset: 0x0004193C
		[Browsable(false)]
		public Vector3 EyePos
		{
			get
			{
				return this.Transform.PointToWorld(this.EyePosLocal);
			}
			set
			{
				this.EyePosLocal = this.Transform.PointToLocal(value);
			}
		}

		/// <summary>
		/// Position a player should be looking from in local coordinates.
		/// </summary>
		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000D9E RID: 3486 RVA: 0x00043760 File Offset: 0x00041960
		// (set) Token: 0x06000D9F RID: 3487 RVA: 0x000437A8 File Offset: 0x000419A8
		[Browsable(false)]
		public Vector3 EyePosLocal
		{
			get
			{
				if (this.clientEnt.IsValid)
				{
					return this.clientEnt.m_EyePosOffset;
				}
				if (this.serverEnt.IsValid)
				{
					return this.serverEnt.m_EyePosOffset;
				}
				return default(Vector3);
			}
			set
			{
				if (this.clientEnt.IsValid)
				{
					this.clientEnt.m_EyePosOffset = value;
				}
				if (this.serverEnt.IsValid)
				{
					this.serverEnt.m_EyePosOffset = value;
				}
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000DA0 RID: 3488 RVA: 0x000437DC File Offset: 0x000419DC
		// (set) Token: 0x06000DA1 RID: 3489 RVA: 0x00043800 File Offset: 0x00041A00
		[Browsable(false)]
		public Rotation EyeRot
		{
			get
			{
				return this.Transform.RotationToWorld(this.EyeRotLocal);
			}
			set
			{
				this.EyeRotLocal = this.Transform.RotationToLocal(value);
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000DA2 RID: 3490 RVA: 0x00043824 File Offset: 0x00041A24
		// (set) Token: 0x06000DA3 RID: 3491 RVA: 0x0004386C File Offset: 0x00041A6C
		[Browsable(false)]
		public Rotation EyeRotLocal
		{
			get
			{
				if (this.clientEnt.IsValid)
				{
					return this.clientEnt.m_EyeRotOffset;
				}
				if (this.serverEnt.IsValid)
				{
					return this.serverEnt.m_EyeRotOffset;
				}
				return default(Rotation);
			}
			set
			{
				if (this.clientEnt.IsValid)
				{
					this.clientEnt.m_EyeRotOffset = value;
				}
				if (this.serverEnt.IsValid)
				{
					this.serverEnt.m_EyeRotOffset = value;
				}
			}
		}

		/// <summary>
		/// Mark render dirty
		/// </summary>
		// Token: 0x06000DA4 RID: 3492 RVA: 0x000438A0 File Offset: 0x00041AA0
		public void RenderDirty()
		{
			if (!this.clientEnt.IsNull)
			{
				this.clientEnt.MarkRenderHandleDirty();
			}
		}

		/// <summary>
		/// Allow a pawn to set up the camera
		/// </summary>
		// Token: 0x06000DA5 RID: 3493 RVA: 0x000438BA File Offset: 0x00041ABA
		public virtual void PostCameraSetup(ref CameraSetup camSetup)
		{
		}

		/// <summary>
		/// Return false if this entity objects to being picked up by this entity
		/// </summary>
		// Token: 0x06000DA6 RID: 3494 RVA: 0x000438BC File Offset: 0x00041ABC
		public virtual bool CanCarry(Entity carrier)
		{
			return false;
		}

		/// <summary>
		/// Allow the entity to do what it wants when it's added to the inventory.
		/// Default behaviour is to add the target entity as a parent and stop moving.
		/// </summary>
		// Token: 0x06000DA7 RID: 3495 RVA: 0x000438BF File Offset: 0x00041ABF
		public virtual void OnCarryStart(Entity carrier)
		{
			if (this.IsClient)
			{
				return;
			}
			this.SetParent(carrier, true);
			this.Owner = carrier;
			this.MoveType = MoveType.None;
			this.EnableDrawing = false;
		}

		/// <summary>
		/// Allow the entity to do what it wants when it's removed from the inventory
		/// </summary>
		// Token: 0x06000DA8 RID: 3496 RVA: 0x000438E8 File Offset: 0x00041AE8
		public virtual void OnCarryDrop(Entity carrier)
		{
			if (this.IsClient)
			{
				return;
			}
			this.SetParent(null, null, null);
			this.Owner = null;
			this.MoveType = MoveType.Physics;
			this.EnableDrawing = true;
		}

		// Token: 0x06000DA9 RID: 3497 RVA: 0x00043924 File Offset: 0x00041B24
		public override string ToString()
		{
			return this.Name;
		}

		/// <summary>
		/// Axis-aligned bounding box in world space.
		/// </summary>
		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000DAA RID: 3498 RVA: 0x0004392C File Offset: 0x00041B2C
		[Browsable(false)]
		public BBox WorldSpaceBounds
		{
			get
			{
				BBox box = default(BBox);
				if (this.clientEnt.IsValid)
				{
					this.clientEnt.WorldSpaceAABB(out box.Mins, out box.Maxs);
				}
				if (this.serverEnt.IsValid)
				{
					this.serverEnt.WorldSpaceAABB(out box.Mins, out box.Maxs);
				}
				return box;
			}
		}

		/// <summary>
		/// Called when a player becomes active
		/// </summary>
		// Token: 0x06000DAB RID: 3499 RVA: 0x0004398E File Offset: 0x00041B8E
		public virtual void OnClientActive()
		{
		}

		// Token: 0x06000DAC RID: 3500 RVA: 0x00043990 File Offset: 0x00041B90
		internal virtual void InternalPostClientActive()
		{
			this.OnClientActive();
		}

		// Token: 0x06000DAD RID: 3501 RVA: 0x00043998 File Offset: 0x00041B98
		internal virtual void InternalOnNewSequence()
		{
		}

		// Token: 0x06000DAE RID: 3502 RVA: 0x0004399A File Offset: 0x00041B9A
		internal virtual void InternalOnSequenceFinished(bool looped)
		{
		}

		// Token: 0x06000DAF RID: 3503 RVA: 0x0004399C File Offset: 0x00041B9C
		internal virtual void InternalOnAnimGraphTag(string tag, int fireMode)
		{
		}

		// Token: 0x06000DB0 RID: 3504 RVA: 0x0004399E File Offset: 0x00041B9E
		internal virtual void InternalOnAnimGraphCreated()
		{
		}

		// Token: 0x06000DB1 RID: 3505 RVA: 0x000439A0 File Offset: 0x00041BA0
		public static Entity Read(BinaryReader reader)
		{
			return Entity.FindByIndex(reader.ReadInt32());
		}

		// Token: 0x06000DB2 RID: 3506 RVA: 0x000439AD File Offset: 0x00041BAD
		public void Write(BinaryWriter writer)
		{
			writer.Write(this.IsValid ? this.NetworkIdent : (-1));
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000DB3 RID: 3507 RVA: 0x000439C6 File Offset: 0x00041BC6
		// (set) Token: 0x06000DB4 RID: 3508 RVA: 0x000439CE File Offset: 0x00041BCE
		public DebugOverlayBits DebugBits
		{
			get
			{
				return this.GetDebugBits();
			}
			set
			{
				this.SetDebugBits(value);
			}
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x000439D7 File Offset: 0x00041BD7
		public void SetDebugBits(DebugOverlayBits bitMask)
		{
			if (this.IsClient)
			{
				this.clientEnt.SetDebugBits((ulong)bitMask);
			}
			if (this.IsServer)
			{
				this.serverEnt.SetDebugBits((ulong)bitMask);
			}
		}

		// Token: 0x06000DB6 RID: 3510 RVA: 0x00043A01 File Offset: 0x00041C01
		public bool HasDebugBitsSet(DebugOverlayBits bitMask)
		{
			if (this.IsClient)
			{
				return this.clientEnt.HasDebugBitsSet((ulong)bitMask);
			}
			if (this.IsServer)
			{
				return this.serverEnt.HasDebugBitsSet((ulong)bitMask);
			}
			throw new Exception("Invalid Entity");
		}

		// Token: 0x06000DB7 RID: 3511 RVA: 0x00043A37 File Offset: 0x00041C37
		public void ClearDebugBits(DebugOverlayBits bitMask)
		{
			if (this.IsClient)
			{
				this.clientEnt.ClearDebugBits((ulong)bitMask);
			}
			if (this.IsServer)
			{
				this.serverEnt.ClearDebugBits((ulong)bitMask);
			}
		}

		// Token: 0x06000DB8 RID: 3512 RVA: 0x00043A61 File Offset: 0x00041C61
		public void ToggleDebugBits(DebugOverlayBits bitMask)
		{
			if (this.IsClient)
			{
				this.clientEnt.ToggleDebugBits((ulong)bitMask);
			}
			if (this.IsServer)
			{
				this.serverEnt.ToggleDebugBits((ulong)bitMask);
			}
		}

		// Token: 0x06000DB9 RID: 3513 RVA: 0x00043A8B File Offset: 0x00041C8B
		public DebugOverlayBits GetDebugBits()
		{
			if (this.IsClient)
			{
				return (DebugOverlayBits)this.clientEnt.GetDebugBits();
			}
			if (this.IsServer)
			{
				return (DebugOverlayBits)this.serverEnt.GetDebugBits();
			}
			throw new Exception("Invalid Entity");
		}

		// Token: 0x06000DBA RID: 3514 RVA: 0x00043AC0 File Offset: 0x00041CC0
		internal bool HasEntityEffect(EntityEffects fx)
		{
			if (this.IsClient)
			{
				return this.clientEnt.IsEffectActive((int)fx);
			}
			return this.IsServer && this.serverEnt.IsEffectActive((int)fx);
		}

		// Token: 0x06000DBB RID: 3515 RVA: 0x00043AFC File Offset: 0x00041CFC
		internal void SetEntityEffects(EntityEffects fx, bool b)
		{
			if (b)
			{
				if (this.IsClient)
				{
					this.clientEnt.AddEffects((int)fx);
				}
				if (this.IsServer)
				{
					this.serverEnt.AddEffects((int)fx);
					return;
				}
			}
			else
			{
				if (this.IsClient)
				{
					this.clientEnt.RemoveEffects((int)fx);
				}
				if (this.IsServer)
				{
					this.serverEnt.RemoveEffects((int)fx);
				}
			}
		}

		/// <summary>
		/// Turning this off will compleletely prevent the entity from drawing
		/// </summary>
		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000DBC RID: 3516 RVA: 0x00043B5F File Offset: 0x00041D5F
		// (set) Token: 0x06000DBD RID: 3517 RVA: 0x00043B6C File Offset: 0x00041D6C
		[Category("Rendering")]
		public bool EnableDrawing
		{
			get
			{
				return !this.HasEntityEffect(EntityEffects.NoDraw);
			}
			set
			{
				this.SetEntityEffects(EntityEffects.NoDraw, !value);
			}
		}

		/// <summary>
		/// Don't cast no shadow
		/// </summary>
		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000DBE RID: 3518 RVA: 0x00043B7A File Offset: 0x00041D7A
		// (set) Token: 0x06000DBF RID: 3519 RVA: 0x00043B87 File Offset: 0x00041D87
		[Category("Rendering")]
		public bool EnableShadowCasting
		{
			get
			{
				return !this.HasEntityEffect(EntityEffects.NoShadow);
			}
			set
			{
				this.SetEntityEffects(EntityEffects.NoShadow, !value);
			}
		}

		/// <summary>
		/// Don't receive no shadow [TODO: DOESNT WORK]
		/// </summary>
		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000DC0 RID: 3520 RVA: 0x00043B95 File Offset: 0x00041D95
		// (set) Token: 0x06000DC1 RID: 3521 RVA: 0x00043BA2 File Offset: 0x00041DA2
		[Category("Rendering")]
		public bool EnableShadowReceive
		{
			get
			{
				return !this.HasEntityEffect(EntityEffects.NoReceiveShadow);
			}
			set
			{
				this.SetEntityEffects(EntityEffects.NoReceiveShadow, !value);
			}
		}

		/// <summary>
		/// Render only shadows
		/// </summary>
		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000DC2 RID: 3522 RVA: 0x00043BB0 File Offset: 0x00041DB0
		// (set) Token: 0x06000DC3 RID: 3523 RVA: 0x00043BBD File Offset: 0x00041DBD
		[Category("Rendering")]
		public bool EnableShadowOnly
		{
			get
			{
				return this.HasEntityEffect(EntityEffects.ShadowOnly);
			}
			set
			{
				this.SetEntityEffects(EntityEffects.ShadowOnly, value);
			}
		}

		/// <summary>
		/// Render Shadows when hidden due to being in first person
		/// </summary>
		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000DC4 RID: 3524 RVA: 0x00043BCB File Offset: 0x00041DCB
		// (set) Token: 0x06000DC5 RID: 3525 RVA: 0x00043BD4 File Offset: 0x00041DD4
		[Category("Rendering")]
		public bool EnableShadowInFirstPerson
		{
			get
			{
				return this.HasEntityEffect(EntityEffects.HiddenCastsShadows);
			}
			set
			{
				this.SetEntityEffects(EntityEffects.HiddenCastsShadows, value);
			}
		}

		/// <summary>
		/// Hide this model when in first person, or our parent is in first person
		/// </summary>
		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000DC6 RID: 3526 RVA: 0x00043BDE File Offset: 0x00041DDE
		// (set) Token: 0x06000DC7 RID: 3527 RVA: 0x00043BE7 File Offset: 0x00041DE7
		[Category("Rendering")]
		public bool EnableHideInFirstPerson
		{
			get
			{
				return this.HasEntityEffect(EntityEffects.HiddenInFirstPerson);
			}
			set
			{
				this.SetEntityEffects(EntityEffects.HiddenInFirstPerson, value);
			}
		}

		/// <summary>
		/// Enable Viewmodel Rendering
		/// </summary>
		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000DC8 RID: 3528 RVA: 0x00043BF1 File Offset: 0x00041DF1
		// (set) Token: 0x06000DC9 RID: 3529 RVA: 0x00043BFE File Offset: 0x00041DFE
		[Category("Rendering")]
		public bool EnableViewmodelRendering
		{
			get
			{
				return this.HasEntityEffect(EntityEffects.DrawAsViewModel);
			}
			set
			{
				this.SetEntityEffects(EntityEffects.DrawAsViewModel, value);
			}
		}

		/// <summary>
		/// similar to ignorez to draw over world but still having depth info
		/// </summary>
		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000DCA RID: 3530 RVA: 0x00043C0C File Offset: 0x00041E0C
		// (set) Token: 0x06000DCB RID: 3531 RVA: 0x00043C19 File Offset: 0x00041E19
		[Category("Rendering")]
		public bool EnableDrawOverWorld
		{
			get
			{
				return this.HasEntityEffect(EntityEffects.DrawOverDepth);
			}
			set
			{
				this.SetEntityEffects(EntityEffects.DrawOverDepth, value);
			}
		}

		/// <summary>
		/// If this entity is being viewed through, or is a child of an entity that is being view
		/// through - will return true. This can be read are we in first person mode.
		/// </summary>
		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000DCC RID: 3532 RVA: 0x00043C27 File Offset: 0x00041E27
		[Browsable(false)]
		public virtual bool IsFirstPersonMode
		{
			get
			{
				return !Host.IsServer && (CurrentView.Viewer == this || (this.Parent != null && this.Parent.IsFirstPersonMode));
			}
		}

		/// <summary>
		/// Called befre InternalSpawn for every EntityKeyValue provided - usually provided by Hammer.
		/// For a property to be settable from Hammer, mark it with [HammerProp]
		/// You can then use it to do any configuration in Spawn.
		/// This is serverside only! Probably!
		/// If the conversion to the type you want to convert to isn't supported - talk to Garry
		/// </summary>
		// Token: 0x06000DCD RID: 3533 RVA: 0x00043C54 File Offset: 0x00041E54
		internal virtual void InternalEntityKeyValue(uint nameToken, string value, int type)
		{
			string key = StringToken.GetValue(nameToken);
			if (key == null)
			{
				return;
			}
			PropertyAttribute propertyAttribute;
			if (!base.ClassInfo.PropertiesInternal.TryGetValue(key, out propertyAttribute))
			{
				return;
			}
			this.SetProperty(key, value);
		}

		/// <summary>
		/// Called on entity spawn with all the Hammer set IO connections
		/// </summary>
		// Token: 0x06000DCE RID: 3534 RVA: 0x00043C8C File Offset: 0x00041E8C
		internal virtual void InternalEntityConnection(string OutputName, EntityIOTargetType targetType, string TargetName, string InputName, string OverrideParam, float Delay, int TimesToFire)
		{
			Sandbox.EntityIO.Output o = new Sandbox.EntityIO.Output
			{
				OutputName = OutputName,
				TargetType = targetType,
				TargetName = TargetName,
				InputName = InputName,
				Param = OverrideParam,
				Delay = Delay,
				TimesToFire = TimesToFire
			};
			if (this.Outputs == null)
			{
				this.Outputs = new OutputCollection();
			}
			this.Outputs.GetOrCreate(OutputName).Add(o);
		}

		/// <summary>
		/// Try to fire this output
		/// </summary>
		// Token: 0x06000DCF RID: 3535 RVA: 0x00043CFC File Offset: 0x00041EFC
		public virtual async ValueTask FireOutput(string output, Entity activator, object value = null, float delay = 0f)
		{
			if (this.Outputs != null)
			{
				List<Sandbox.EntityIO.Output> list;
				if (this.Outputs.TryGetValue(output, out list))
				{
					if (delay > 0f)
					{
						await GameTask.DelaySeconds(delay);
					}
					foreach (Sandbox.EntityIO.Output output2 in list)
					{
						output2.Fire(this, activator, value);
					}
				}
			}
		}

		// Token: 0x06000DD0 RID: 3536 RVA: 0x00043D60 File Offset: 0x00041F60
		public virtual void AddOutputEvent(string name, Entity.StandardOutputDelegate method, float delay = 0f)
		{
			Sandbox.EntityIO.Output o = new Sandbox.EntityIO.Output
			{
				OutputName = name,
				TargetType = EntityIOTargetType.EHANDLE,
				Delegate = delegate(Entity e, Entity a, object d)
				{
					method(a, 0f);
				},
				Delay = delay
			};
			if (this.Outputs == null)
			{
				this.Outputs = new OutputCollection();
			}
			this.Outputs.GetOrCreate(name).Add(o);
		}

		// Token: 0x06000DD1 RID: 3537 RVA: 0x00043DCC File Offset: 0x00041FCC
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual void CreateHammerOutputs()
		{
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000DD2 RID: 3538 RVA: 0x00043DCE File Offset: 0x00041FCE
		// (set) Token: 0x06000DD3 RID: 3539 RVA: 0x00043DD6 File Offset: 0x00041FD6
		public IBaseInventory Inventory { get; protected set; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000DD4 RID: 3540 RVA: 0x00043DE0 File Offset: 0x00041FE0
		[Browsable(false)]
		public IReadOnlyList<Entity> Children
		{
			get
			{
				if (this.children != null)
				{
					return this.children;
				}
				return Array.Empty<Entity>();
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000DD5 RID: 3541 RVA: 0x00043E05 File Offset: 0x00042005
		// (set) Token: 0x06000DD6 RID: 3542 RVA: 0x00043E10 File Offset: 0x00042010
		[Category("Transform")]
		public virtual Entity Parent
		{
			get
			{
				return this.parent;
			}
			set
			{
				if (value != null && value.IsWorld)
				{
					value = null;
				}
				this.SetParent(value, null, null);
			}
		}

		/// <summary>
		/// Gets the top most parent entity. If we don't have a parent, it might be us.
		/// </summary>
		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000DD7 RID: 3543 RVA: 0x00043E3C File Offset: 0x0004203C
		[Browsable(false)]
		public virtual Entity Root
		{
			get
			{
				Entity entity = this.Parent;
				return ((entity != null) ? entity.Root : null) ?? this;
			}
		}

		/// <summary>
		/// Lets remove this
		/// </summary>
		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000DD8 RID: 3544 RVA: 0x00043E55 File Offset: 0x00042055
		// (set) Token: 0x06000DD9 RID: 3545 RVA: 0x00043E94 File Offset: 0x00042094
		public virtual Entity ActiveChild
		{
			get
			{
				if (this.clientEnt.IsValid)
				{
					return Entity.GetEntity(this.clientEnt.GetActiveChild());
				}
				if (this.serverEnt.IsValid)
				{
					return Entity.GetEntity(this.serverEnt.GetActiveChild());
				}
				return null;
			}
			set
			{
				if (!this.clientEnt.IsNull)
				{
					this.clientEnt.SetActiveChild((value == null) ? ((IntPtr)0) : value.GetEntityIntPtr());
				}
				if (!this.serverEnt.IsNull)
				{
					this.serverEnt.SetActiveChild((value == null) ? ((IntPtr)0) : value.GetEntityIntPtr());
				}
			}
		}

		// Token: 0x06000DDA RID: 3546 RVA: 0x00043EF5 File Offset: 0x000420F5
		public virtual void ActiveEnd(Entity ent, bool dropped)
		{
		}

		// Token: 0x06000DDB RID: 3547 RVA: 0x00043EF7 File Offset: 0x000420F7
		public virtual void ActiveStart(Entity ent)
		{
		}

		/// <summary>
		/// The entity that owns this entity
		/// </summary>
		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000DDC RID: 3548 RVA: 0x00043EF9 File Offset: 0x000420F9
		// (set) Token: 0x06000DDD RID: 3549 RVA: 0x00043F38 File Offset: 0x00042138
		[Category("Meta")]
		public virtual Entity Owner
		{
			get
			{
				if (!this.clientEnt.IsNull)
				{
					return Entity.GetEntity(this.clientEnt.GetOwnerEntity());
				}
				if (!this.serverEnt.IsNull)
				{
					return Entity.GetEntity(this.serverEnt.GetOwnerEntity());
				}
				return null;
			}
			set
			{
				if (!this.clientEnt.IsNull)
				{
					this.clientEnt.SetOwnerEntity((value == null) ? ((IntPtr)0) : value.GetEntityIntPtr());
				}
				if (!this.serverEnt.IsNull)
				{
					this.serverEnt.SetOwnerEntity((value == null) ? ((IntPtr)0) : value.GetEntityIntPtr());
				}
				this.UpdateClientOwner();
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000DDE RID: 3550 RVA: 0x00043F9F File Offset: 0x0004219F
		[Browsable(false)]
		public bool IsFollowingEntity
		{
			get
			{
				if (this.IsClient)
				{
					return this.clientEnt.IsFollowingEntity();
				}
				return this.IsServer && this.serverEnt.IsFollowingEntity();
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000DDF RID: 3551 RVA: 0x00043FCA File Offset: 0x000421CA
		[Browsable(false)]
		public Entity FollowedEntity
		{
			get
			{
				if (this.IsClient)
				{
					return Entity.GetEntity(this.clientEnt.GetFollowedEntity());
				}
				if (this.IsServer)
				{
					return Entity.GetEntity(this.serverEnt.GetFollowedEntity());
				}
				return null;
			}
		}

		/// <summary>
		/// Become a child of this entity and follow this attachment or bone if provided.
		/// </summary>
		// Token: 0x06000DE0 RID: 3552 RVA: 0x00044000 File Offset: 0x00042200
		public virtual void SetParent(Entity entity, string attachmentOrBoneName = null, Transform? transform = null)
		{
			if (entity != null && entity.IsWorld)
			{
				entity = null;
			}
			if (entity != null && entity.IsBeingDeleted)
			{
				return;
			}
			if (transform != null)
			{
				if (this.clientEnt.IsValid)
				{
					this.clientEnt.SetParent((entity == null) ? ((IntPtr)0) : entity.GetEntityIntPtr(), attachmentOrBoneName, transform.Value);
				}
				if (this.serverEnt.IsValid)
				{
					this.serverEnt.SetParent((entity == null) ? ((IntPtr)0) : entity.GetEntityIntPtr(), attachmentOrBoneName, transform.Value);
					return;
				}
			}
			else
			{
				if (this.clientEnt.IsValid)
				{
					this.clientEnt.SetParent((entity == null) ? ((IntPtr)0) : entity.GetEntityIntPtr(), attachmentOrBoneName);
				}
				if (this.serverEnt.IsValid)
				{
					this.serverEnt.SetParent((entity == null) ? ((IntPtr)0) : entity.GetEntityIntPtr(), attachmentOrBoneName);
				}
			}
		}

		/// <summary>
		/// Finds the bone name and calls the other SetParent with it.
		/// </summary>
		// Token: 0x06000DE1 RID: 3553 RVA: 0x000440EC File Offset: 0x000422EC
		public virtual void SetParent(Entity entity, int bone, Transform? transform = null)
		{
			if (bone < 0)
			{
				this.SetParent(entity, null, transform);
				return;
			}
			ModelEntity me = entity as ModelEntity;
			if (me == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 1);
				defaultInterpolatedStringHandler.AppendLiteral("invalid bone (");
				defaultInterpolatedStringHandler.AppendFormatted<int>(bone);
				defaultInterpolatedStringHandler.AppendLiteral(") - not a model entity");
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (bone >= me.BoneCount)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 2);
				defaultInterpolatedStringHandler.AppendLiteral("invalid bone  (");
				defaultInterpolatedStringHandler.AppendFormatted<int>(bone);
				defaultInterpolatedStringHandler.AppendLiteral(") - we only have ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(me.BoneCount);
				defaultInterpolatedStringHandler.AppendLiteral(" bones");
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			string boneName = me.GetBoneName(bone);
			if (string.IsNullOrEmpty(boneName))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 1);
				defaultInterpolatedStringHandler.AppendLiteral("invalid bone  (");
				defaultInterpolatedStringHandler.AppendFormatted<int>(bone);
				defaultInterpolatedStringHandler.AppendLiteral(") - couldn't get bone name");
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (entity != null && entity.IsWorld)
			{
				entity = null;
			}
			this.SetParent(entity, boneName, transform);
		}

		/// <summary>
		/// Set the parent to the passed entity
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="boneMerge"></param>
		// Token: 0x06000DE2 RID: 3554 RVA: 0x000441FF File Offset: 0x000423FF
		public void SetParent(Entity entity, bool boneMerge)
		{
			this.SetParent(entity, boneMerge ? "!bonemerge" : null, new Transform?(Transform.Zero));
		}

		// Token: 0x06000DE3 RID: 3555 RVA: 0x00044220 File Offset: 0x00042420
		internal void InternalOnParentChanged(Entity newParent)
		{
			if (this.parent == newParent)
			{
				return;
			}
			if (this.parent != null)
			{
				this.parent.InternalOnChildRemoved(this);
			}
			this.parent = newParent;
			if (this.parent != null)
			{
				this.parent.InternalOnChildAdded(this);
			}
			EntityRegistry.ParentChanged(this.EngineIdent);
		}

		// Token: 0x06000DE4 RID: 3556 RVA: 0x00044274 File Offset: 0x00042474
		internal void InternalOnChildAdded(Entity child)
		{
			if (this.children == null)
			{
				this.children = new List<Entity>();
			}
			if (this.children.Contains(child))
			{
				return;
			}
			this.children.Add(child);
			this.children.Sort(new Comparison<Entity>(this.ChildrenSort));
			this.OnChildAdded(child);
		}

		// Token: 0x06000DE5 RID: 3557 RVA: 0x000442CD File Offset: 0x000424CD
		private int ChildrenSort(Entity x, Entity y)
		{
			return x.NetworkIdent - y.NetworkIdent;
		}

		// Token: 0x06000DE6 RID: 3558 RVA: 0x000442DC File Offset: 0x000424DC
		public virtual void OnChildAdded(Entity child)
		{
			IBaseInventory inventory = this.Inventory;
			if (inventory == null)
			{
				return;
			}
			inventory.OnChildAdded(child);
		}

		// Token: 0x06000DE7 RID: 3559 RVA: 0x000442EF File Offset: 0x000424EF
		internal void InternalOnChildRemoved(Entity child)
		{
			if (child == this.ActiveChild)
			{
				this.ActiveChild = null;
			}
			if (this.children == null)
			{
				return;
			}
			if (!this.children.Contains(child))
			{
				return;
			}
			this.children.Remove(child);
			this.OnChildRemoved(child);
		}

		// Token: 0x06000DE8 RID: 3560 RVA: 0x0004432D File Offset: 0x0004252D
		public virtual void OnChildRemoved(Entity child)
		{
			IBaseInventory inventory = this.Inventory;
			if (inventory == null)
			{
				return;
			}
			inventory.OnChildRemoved(child);
		}

		/// <summary>
		/// Returns true if this is its parent's active child
		/// </summary>
		// Token: 0x06000DE9 RID: 3561 RVA: 0x00044340 File Offset: 0x00042540
		public bool IsActiveChild()
		{
			return this.Parent != null && this.Parent.ActiveChild == this;
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000DEA RID: 3562 RVA: 0x0004435A File Offset: 0x0004255A
		IEntity IEntity.Parent
		{
			get
			{
				return this.Parent;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000DEB RID: 3563 RVA: 0x00044362 File Offset: 0x00042562
		IEntity IEntity.Owner
		{
			get
			{
				return this.Owner;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000DEC RID: 3564 RVA: 0x0004436A File Offset: 0x0004256A
		IClient IEntity.Client
		{
			get
			{
				return this.Client;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000DED RID: 3565 RVA: 0x00044372 File Offset: 0x00042572
		int IEntity.Id
		{
			get
			{
				return this.NetworkIdent;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000DEE RID: 3566 RVA: 0x0004437A File Offset: 0x0004257A
		bool IEntity.IsFromMap
		{
			get
			{
				return this.IsFromMap;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000DEF RID: 3567 RVA: 0x00044382 File Offset: 0x00042582
		Transform IEntity.Transform
		{
			get
			{
				return this.Transform;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000DF0 RID: 3568 RVA: 0x0004438A File Offset: 0x0004258A
		BBox IEntity.WorldSpaceBounds
		{
			get
			{
				return this.WorldSpaceBounds;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000DF1 RID: 3569 RVA: 0x00044392 File Offset: 0x00042592
		bool IEntity.IsOwnedByLocalClient
		{
			get
			{
				if (Host.IsServer)
				{
					Client client = this.Client;
					return client != null && client.NetworkIdent == 1;
				}
				return Local.Client == this.Client;
			}
		}

		/// <summary>
		/// Enable lag compensation. This will rewind all eligible entities to the positions they
		/// were when the client sent the command that is being simulated. When used in a `using` block,
		/// lag compensation will be automatically finished when it is disposed.
		/// </summary>
		// Token: 0x06000DF2 RID: 3570 RVA: 0x000443C0 File Offset: 0x000425C0
		public static IDisposable LagCompensation()
		{
			if (!Host.IsClient)
			{
				ClientEntity cl = Prediction.CurrentHost as ClientEntity;
				if (cl != null)
				{
					cl.StartLagCompensation();
					return new Entity.LagCompensationScope
					{
						Client = cl
					};
				}
			}
			return null;
		}

		/// <summary>
		/// Whether or not this entity will be considered for lag compensation. If this is true, the entity's collision bounds
		/// and any hitboxes it has will be rewound to the positions the client saw them in when sending its input command.
		/// </summary>
		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000DF3 RID: 3571 RVA: 0x00044400 File Offset: 0x00042600
		// (set) Token: 0x06000DF4 RID: 3572 RVA: 0x0004441C File Offset: 0x0004261C
		public bool EnableLagCompensation
		{
			get
			{
				return this.serverEnt.IsValid && this.serverEnt.IsLagCompensationEnabled();
			}
			set
			{
				if (this.serverEnt.IsValid)
				{
					this.serverEnt.EnableLagCompensation(value);
				}
			}
		}

		/// <summary>
		/// Here for debug purposes
		/// </summary>
		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000DF5 RID: 3573 RVA: 0x00044437 File Offset: 0x00042637
		[Browsable(false)]
		public IReadOnlyDictionary<int, Var> NetworkDictionary
		{
			get
			{
				return this.NetworkTable.Table;
			}
		}

		// Token: 0x06000DF6 RID: 3574 RVA: 0x00044444 File Offset: 0x00042644
		public override void BuildNetworkTable(NetworkTable table)
		{
			table.Register<VarComponentList>(ref this.NetworkComponents, "NetworkComponents", true, false);
			table.Register<VarClass<ICamera>>(ref this.__camera, "Camera", true, false);
		}

		/// <summary>
		/// Called on creation and hotload to initialize the network tables
		/// </summary>
		// Token: 0x06000DF7 RID: 3575 RVA: 0x0004446C File Offset: 0x0004266C
		internal void InitNetworkTables()
		{
			NetworkTable networkTable = this.NetworkTable;
			if (networkTable != null)
			{
				networkTable.Clear();
			}
			this.NetworkTable = new NetworkTable(this);
			if (this.serverEnt.IsValid)
			{
				this.serverEnt.ClearData();
				this.serverEnt.m_netHash = GameAssemblyManager.Hash;
			}
			this.NetworkTable.CollectVariables(this, true);
			if (Host.IsServer)
			{
				this.NetworkTable.ServerInitialize();
			}
			if (Host.IsClient && !this.IsClientOnly)
			{
				this.NetworkTable.ReadAll(null);
			}
		}

		// Token: 0x06000DF8 RID: 3576 RVA: 0x000444FC File Offset: 0x000426FC
		internal void UpdateFromNetwork()
		{
			Entity.PredictionDataStore predictedFrame = null;
			Entity.PredictionDataStore lastPredictionFrame;
			if (this.PredictedStore != null && this.PredictedStore.TryGetValue(Prediction.CommandsAcknowledged - 1, out lastPredictionFrame))
			{
				predictedFrame = lastPredictionFrame;
			}
			this.NetworkTable.ReadAll(predictedFrame);
		}

		// Token: 0x06000DF9 RID: 3577 RVA: 0x00044538 File Offset: 0x00042738
		internal int GetNetworkIdFromEngine()
		{
			if (this.serverEnt.IsValid)
			{
				int ix = this.serverEnt.entindex();
				if (ix == 0 && !this.serverEnt.IsClientServerNetworked())
				{
					return -1;
				}
				return ix;
			}
			else
			{
				if (this.clientEnt.IsValid)
				{
					return this.clientEnt.entindex();
				}
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Returns the entity's network id. Client only entities have a network id too!
		/// </summary>
		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000DFA RID: 3578 RVA: 0x00044590 File Offset: 0x00042790
		[Property]
		[Skip]
		[Category("Meta")]
		public override int NetworkIdent
		{
			get
			{
				if (this.cached < 0)
				{
					this.cached = this.GetNetworkIdFromEngine();
				}
				return this.cached;
			}
		}

		/// <summary>
		/// This is an ident we can use to uniquely identify this entity:
		///
		/// 1. Client only entities will be negative
		/// 2. Networked Entities will match
		/// 3. Serverside entities will be &gt; 16k
		/// </summary>
		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000DFB RID: 3579 RVA: 0x000445AD File Offset: 0x000427AD
		internal int EngineIdent
		{
			get
			{
				if (!this.IsClientOnly)
				{
					return this.NetworkIdent;
				}
				return -this.NetworkIdent;
			}
		}

		/// <summary>
		/// If this entity has multiple physics objects, a physics group lets you control them all as one.
		/// </summary>
		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000DFC RID: 3580 RVA: 0x000445C5 File Offset: 0x000427C5
		public PhysicsGroup PhysicsGroup
		{
			get
			{
				if (!this.serverEnt.IsNull)
				{
					return this.serverEnt.VPhysicsGetAggregate();
				}
				if (!this.clientEnt.IsNull)
				{
					return this.clientEnt.VPhysicsGetAggregate();
				}
				return null;
			}
		}

		// Token: 0x06000DFD RID: 3581 RVA: 0x000445FA File Offset: 0x000427FA
		internal void InternalStartTouch(Entity other)
		{
			this.StartTouch(other);
		}

		// Token: 0x06000DFE RID: 3582 RVA: 0x00044603 File Offset: 0x00042803
		internal void InternalOnTouch(Entity other)
		{
			this.Touch(other);
		}

		// Token: 0x06000DFF RID: 3583 RVA: 0x0004460C File Offset: 0x0004280C
		internal void InternalEndTouch(Entity other)
		{
			this.EndTouch(other);
		}

		/// <summary>
		/// An entity has touched this entity
		/// </summary>
		// Token: 0x06000E00 RID: 3584 RVA: 0x00044615 File Offset: 0x00042815
		public virtual void Touch(Entity other)
		{
		}

		/// <summary>
		/// An entity has started touching this entity
		/// </summary>
		// Token: 0x06000E01 RID: 3585 RVA: 0x00044617 File Offset: 0x00042817
		public virtual void StartTouch(Entity other)
		{
		}

		/// <summary>
		/// An entity has stopped touching this entity
		/// </summary>
		// Token: 0x06000E02 RID: 3586 RVA: 0x00044619 File Offset: 0x00042819
		public virtual void EndTouch(Entity other)
		{
		}

		/// <summary>
		/// Destroy any physics objects
		/// </summary>
		// Token: 0x06000E03 RID: 3587 RVA: 0x0004461B File Offset: 0x0004281B
		public virtual void PhysicsClear()
		{
		}

		/// <summary>
		/// Defaults to true, this allows you to turn off prediction for this entity. If you set this
		/// to false then the entity won't be predicted even if it's eligible (has local client owner).
		/// </summary>
		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000E04 RID: 3588 RVA: 0x0004461D File Offset: 0x0004281D
		// (set) Token: 0x06000E05 RID: 3589 RVA: 0x0004462A File Offset: 0x0004282A
		[Category("Networking")]
		public bool Predictable
		{
			get
			{
				return this.dataTable.m_bPredictable;
			}
			set
			{
				this.dataTable.m_bPredictable = value;
			}
		}

		/// <summary>
		/// Returns true if should be simulated, which means:
		///
		/// 1. This is a server entity and we're server side
		/// 2. This is a client entity and we're client side
		/// 3. This is a server entity, we're client side, and prediction is enabled for this entity
		/// </summary>
		// Token: 0x06000E06 RID: 3590 RVA: 0x00044638 File Offset: 0x00042838
		internal bool IsPredictable()
		{
			return this.clientEnt.IsValid && this.clientEnt.GetPredictable();
		}

		/// <summary>
		/// Store our current predicted data in this slot
		/// </summary>
		// Token: 0x06000E07 RID: 3591 RVA: 0x00044654 File Offset: 0x00042854
		internal void PredictionStore(int slot, int command_num, bool network, bool variables)
		{
			using (Performance.Scope("PredictionStore"))
			{
				if (slot == -1)
				{
					this.UpdateFromNetwork();
				}
				if (this.PredictedStore == null)
				{
					this.PredictedStore = new Dictionary<int, Entity.PredictionDataStore>();
				}
				Host.AssertClient("PredictionStore");
				Entity.PredictionDataStore store;
				if (!this.PredictedStore.TryGetValue(slot, out store))
				{
					store = new Entity.PredictionDataStore(this);
					this.PredictedStore[slot] = store;
				}
				store.CommandId = command_num;
				store.Read(network, variables);
			}
		}

		/// <summary>
		/// Restore our current predicted data from this slot
		/// </summary>
		// Token: 0x06000E08 RID: 3592 RVA: 0x000446E4 File Offset: 0x000428E4
		internal void PredictionRestore(int slot, bool network, bool variables)
		{
			using (Performance.Scope("PredictionRestore"))
			{
				Host.AssertClient("PredictionRestore");
				ThreadSafe.AssertIsMainThread("PredictionRestore");
				Entity.PredictionDataStore store;
				if (this.PredictedStore != null && this.PredictedStore.TryGetValue(slot, out store))
				{
					store.Restore(network, variables);
				}
			}
		}

		/// <summary>
		/// We just got predicted data from the server for this command_num. 
		/// The server data is in slot -1
		/// Our stored data is in the passed slot
		/// They should be pretty much identical. Lets compare them and check.
		/// </summary>
		// Token: 0x06000E09 RID: 3593 RVA: 0x00044750 File Offset: 0x00042950
		internal void PredictionVerify(int slot, int command_num)
		{
			Host.AssertClient("PredictionVerify");
			int num = this.verifyCount;
			this.verifyCount = num + 1;
			if (num < 2)
			{
				return;
			}
			if (this.PredictedStore == null)
			{
				return;
			}
			Entity.PredictionDataStore server;
			if (!this.PredictedStore.TryGetValue(-1, out server))
			{
				return;
			}
			Entity.PredictionDataStore client;
			if (!this.PredictedStore.TryGetValue(slot, out client))
			{
				return;
			}
			if (server.CommandId != command_num)
			{
				return;
			}
			if (client.CommandId != command_num)
			{
				return;
			}
			using (Performance.Scope("PredictionVerify"))
			{
				server.Compare(command_num, client, new Action<string, object>(this.OnPredictionError));
			}
		}

		/// <summary>
		/// On prediction errors right now we're just stomping the value in the current 
		/// storage and any future. This could lead to a situation where the client is in
		/// front by a number of ticks and the value changes, it keeps flipping back.
		/// This should really trigger a re-simulate in the engine code. TODO.
		/// </summary>
		// Token: 0x06000E0A RID: 3594 RVA: 0x000447F8 File Offset: 0x000429F8
		internal void OnPredictionError(string varName, object value)
		{
			foreach (KeyValuePair<int, Entity.PredictionDataStore> store in this.PredictedStore)
			{
				if (store.Key != -1)
				{
					store.Value.StompValue(varName, value);
				}
			}
		}

		/// <summary>
		/// Prediction ended, clean up
		/// </summary>
		// Token: 0x06000E0B RID: 3595 RVA: 0x0004485C File Offset: 0x00042A5C
		internal void PredictionDestroy()
		{
			this.PredictedLocal = null;
			this.PredictedNetwork = null;
			Dictionary<int, Entity.PredictionDataStore> predictedStore = this.PredictedStore;
			if (predictedStore != null)
			{
				predictedStore.Clear();
			}
			this.PredictedStore = null;
		}

		/// <summary>
		///
		/// </summary>
		// Token: 0x06000E0C RID: 3596 RVA: 0x00044884 File Offset: 0x00042A84
		internal void PredictionShift(int slots_to_remove)
		{
			if (this.PredictedStore == null)
			{
				return;
			}
			using (Performance.Scope("PredictionShift"))
			{
				int c = this.PredictedStore.Count;
				for (int i = 0; i < c; i++)
				{
					Entity.PredictionDataStore v;
					if (this.PredictedStore.Remove(i, out v) && i - slots_to_remove >= 0)
					{
						this.PredictedStore[i - slots_to_remove] = v;
					}
				}
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000E0D RID: 3597 RVA: 0x00044900 File Offset: 0x00042B00
		// (set) Token: 0x06000E0E RID: 3598 RVA: 0x00044907 File Offset: 0x00042B07
		internal static int ForceNextEntityIndex { get; set; } = -1;

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000E0F RID: 3599 RVA: 0x0004490F File Offset: 0x00042B0F
		[Browsable(false)]
		public bool IsServer
		{
			get
			{
				return Host.IsServer;
			}
		}

		// Token: 0x06000E10 RID: 3600 RVA: 0x00044918 File Offset: 0x00042B18
		internal virtual void ConstructServer(string engineName)
		{
			int entityIndex = Entity.ForceNextEntityIndex;
			Entity.ForceNextEntityIndex = -1;
			this.InitNativePointer();
			if (EntitySystem.CreateFromManaged(engineName, entityIndex, this).IsNull)
			{
				throw new Exception("Unknown entity '" + engineName + "'");
			}
			if (this.serverEnt.IsNull)
			{
				throw new Exception("ConstructServer: 'serverEnt' is null");
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000E11 RID: 3601 RVA: 0x00044977 File Offset: 0x00042B77
		// (set) Token: 0x06000E12 RID: 3602 RVA: 0x0004497F File Offset: 0x00042B7F
		[Category("Networking")]
		public TransmitType Transmit
		{
			get
			{
				return this._transmit;
			}
			set
			{
				this._transmit = value;
				if (!this.serverEnt.IsNull)
				{
					this.serverEnt.m_iTransmitMode = (int)value;
					this.serverEnt.DispatchUpdateTransmitState();
				}
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000E13 RID: 3603 RVA: 0x000449AC File Offset: 0x00042BAC
		// (set) Token: 0x06000E14 RID: 3604 RVA: 0x000449B3 File Offset: 0x00042BB3
		internal static List<Entity> InternalAll { get; set; } = new List<Entity>();

		/// <summary>
		/// A list of all active entities
		/// </summary>
		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000E15 RID: 3605 RVA: 0x000449BB File Offset: 0x00042BBB
		public static IReadOnlyList<Entity> All
		{
			get
			{
				return Entity.InternalAll;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000E16 RID: 3606 RVA: 0x000449C2 File Offset: 0x00042BC2
		// (set) Token: 0x06000E17 RID: 3607 RVA: 0x000449C9 File Offset: 0x00042BC9
		internal static Dictionary<int, Entity> Index { get; set; } = new Dictionary<int, Entity>();

		/// <summary>
		/// Finds an entity by its NetworkIdent
		/// </summary>
		// Token: 0x06000E18 RID: 3608 RVA: 0x000449D4 File Offset: 0x00042BD4
		public static Entity FindByIndex(int index)
		{
			if (index < 0)
			{
				return null;
			}
			Entity ent;
			if (!Entity.Index.TryGetValue(index, out ent))
			{
				return null;
			}
			return ent;
		}

		/// <summary>
		/// Finds entities by EntityName and returns the first found result, if one was found. This does not handle cases where there are multiple entities with a given name.
		/// </summary>
		// Token: 0x06000E19 RID: 3609 RVA: 0x000449FC File Offset: 0x00042BFC
		public static Entity FindByName(string name, Entity fallback = null)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				return fallback;
			}
			return Entity.All.FirstOrDefault((Entity x) => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase)) ?? fallback;
		}

		/// <summary>
		/// Finds all entities by given EntityName.
		/// </summary>
		// Token: 0x06000E1A RID: 3610 RVA: 0x00044A40 File Offset: 0x00042C40
		public static IEnumerable<Entity> FindAllByName(string name)
		{
			return Entity.All.Where((Entity x) => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x00044A70 File Offset: 0x00042C70
		public static T Create<T>() where T : Entity
		{
			return Library.Create<T>(null, true);
		}

		// Token: 0x06000E1C RID: 3612 RVA: 0x00044A7C File Offset: 0x00042C7C
		public static T Create<T>(string name) where T : Entity
		{
			T t = Library.Create<T>(name, false);
			if (t == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Entity '");
				defaultInterpolatedStringHandler.AppendFormatted(name);
				defaultInterpolatedStringHandler.AppendLiteral("' of type '");
				defaultInterpolatedStringHandler.AppendFormatted<Type>(typeof(T));
				defaultInterpolatedStringHandler.AppendLiteral("' not found");
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return t;
		}

		// Token: 0x06000E1D RID: 3613 RVA: 0x00044AEC File Offset: 0x00042CEC
		public static Entity Create(string name)
		{
			return Entity.Create<Entity>(name);
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x00044AF4 File Offset: 0x00042CF4
		internal static Entity GetEntity(C_BaseEntity ent)
		{
			if (ent.IsNull)
			{
				return null;
			}
			return ent.EntityObject;
		}

		// Token: 0x06000E1F RID: 3615 RVA: 0x00044B08 File Offset: 0x00042D08
		internal static Entity GetEntity(CBaseEntity ent)
		{
			if (ent.IsNull)
			{
				return null;
			}
			return ent.EntityObject;
		}

		/// <summary>
		/// Called by the server to determine what the player should see
		/// </summary>
		// Token: 0x06000E20 RID: 3616 RVA: 0x00044B1C File Offset: 0x00042D1C
		internal virtual void PlayerSetupVisibility(int spawngroup, IntPtr visInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000124 RID: 292
		// (set) Token: 0x06000E21 RID: 3617 RVA: 0x00044B24 File Offset: 0x00042D24
		[Property("tags", null)]
		[Skip]
		internal string __tags
		{
			set
			{
				foreach (string tag in value.Split(",", StringSplitOptions.None))
				{
					this.Tags.Add(tag);
				}
			}
		}

		/// <summary>
		/// This is called on the client after a network update to keep the networkTags list up to date
		/// </summary>
		// Token: 0x06000E22 RID: 3618 RVA: 0x00044B5C File Offset: 0x00042D5C
		internal unsafe void UpdateTagsFromNetwork()
		{
			Host.AssertClient("UpdateTagsFromNetwork");
			uint* tagBuffer = stackalloc uint[(UIntPtr)128];
			int c = this.dataTable.GetTags((IntPtr)((void*)tagBuffer), 32);
			if (c == 0)
			{
				if (this.networkTags != null)
				{
					foreach (string str in this.networkTags)
					{
						this.OnTagRemoved(str);
					}
				}
				this.networkTagsHashCode = 0;
				HashSet<string> hashSet = this.networkTags;
				if (hashSet == null)
				{
					return;
				}
				hashSet.Clear();
				return;
			}
			else
			{
				int hashCode = c.GetHashCode();
				for (int i = 0; i < c; i++)
				{
					hashCode += i.GetHashCode();
					hashCode += tagBuffer[i].GetHashCode();
				}
				if (hashCode == this.networkTagsHashCode)
				{
					return;
				}
				this.networkTagsHashCode = hashCode;
				if (this.networkTags == null)
				{
					this.networkTags = new HashSet<string>();
				}
				string[] tags = ArrayPool<string>.Shared.Rent(c);
				for (int j = 0; j < c; j++)
				{
					tags[j] = StringToken.GetValue(tagBuffer[j]);
					if (tags[j] == null)
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 1);
						defaultInterpolatedStringHandler.AppendLiteral("INVALID STRING POOL STRING (");
						defaultInterpolatedStringHandler.AppendFormatted<uint>(tagBuffer[j]);
						defaultInterpolatedStringHandler.AppendLiteral(")");
						throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
					}
				}
				for (int k = 0; k < c; k++)
				{
					if (!this.networkTags.Contains(tags[k]))
					{
						this.networkTags.Add(tags[k]);
						this.OnTagAdded(tags[k]);
					}
				}
				HashSet<string> RemoveList = null;
				foreach (string str2 in this.networkTags)
				{
					if (!tags.Contains(str2))
					{
						if (RemoveList == null)
						{
							RemoveList = new HashSet<string>();
						}
						RemoveList.Add(str2);
					}
				}
				if (RemoveList != null)
				{
					foreach (string e in RemoveList)
					{
						this.networkTags.Remove(e);
						this.OnTagRemoved(e);
					}
				}
				ArrayPool<string>.Shared.Return(tags, true);
				return;
			}
		}

		// Token: 0x06000E23 RID: 3619 RVA: 0x00044DBC File Offset: 0x00042FBC
		internal void OnTagAddedInternal(string tag)
		{
			this.OnTagAdded(tag);
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x00044DC5 File Offset: 0x00042FC5
		internal void OnTagRemovedInternal(string tag)
		{
			this.OnTagRemoved(tag);
		}

		/// <summary>
		/// Called when a tag was added to this entity. On the client this will get called
		/// when an entity is created or enters PVS.
		/// </summary>
		// Token: 0x06000E25 RID: 3621 RVA: 0x00044DCE File Offset: 0x00042FCE
		protected virtual void OnTagAdded(string tag)
		{
		}

		/// <summary>
		/// Called when a tag was removed from this entity.
		/// </summary>
		// Token: 0x06000E26 RID: 3622 RVA: 0x00044DD0 File Offset: 0x00042FD0
		protected virtual void OnTagRemoved(string tag)
		{
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000E27 RID: 3623 RVA: 0x00044DD2 File Offset: 0x00042FD2
		// (set) Token: 0x06000E28 RID: 3624 RVA: 0x00044DEB File Offset: 0x00042FEB
		[Browsable(false)]
		public Transform Transform
		{
			get
			{
				return new Transform(this.Position, this.Rotation, this.Scale);
			}
			set
			{
				this.Position = value.Position;
				this.Rotation = value.Rotation;
				this.Scale = value.Scale;
			}
		}

		/// <summary>
		/// Set in EntityManager when creating an entity from the network.
		/// If null we assume the entity was just a user initiated new() and
		/// will create a clientside entity
		/// </summary>
		// Token: 0x040001DC RID: 476
		internal static C_BaseEntity IncomingClientInstance;

		// Token: 0x040001DD RID: 477
		internal C_BaseEntity clientEnt;

		// Token: 0x040001E0 RID: 480
		public readonly EntityComponentAccessor Components;

		// Token: 0x040001E1 RID: 481
		public List<EntityComponent> _components;

		// Token: 0x040001E2 RID: 482
		private static Logger log = Logging.GetLogger(null);

		// Token: 0x040001E3 RID: 483
		internal DataTable dataTable;

		// Token: 0x040001E4 RID: 484
		internal CEntityInstance sharedEnt;

		// Token: 0x040001E5 RID: 485
		internal bool IsBeingDeleted;

		/// <summary>
		/// Allows Task.Delay calls etc that are automatically cancelled when the entity is destroyed
		/// </summary>
		// Token: 0x040001E6 RID: 486
		public TaskSource Task = new TaskSource(0);

		// Token: 0x040001E7 RID: 487
		private string _entityname;

		// Token: 0x040001E8 RID: 488
		public SpawnFlagAccessor SpawnFlags;

		// Token: 0x040001E9 RID: 489
		private string _engineEntityName;

		// Token: 0x040001EA RID: 490
		private bool addedToLists;

		// Token: 0x040001ED RID: 493
		private VarClass<ICamera> __camera;

		// Token: 0x040001EF RID: 495
		internal OutputCollection Outputs;

		// Token: 0x040001F0 RID: 496
		internal List<Entity> children;

		// Token: 0x040001F2 RID: 498
		internal Entity parent;

		// Token: 0x040001F3 RID: 499
		private NetworkTable NetworkTable;

		// Token: 0x040001F4 RID: 500
		internal VarComponentList NetworkComponents;

		// Token: 0x040001F5 RID: 501
		private int cached = -2;

		// Token: 0x040001F6 RID: 502
		private PropertyInfo[] PredictedLocal;

		// Token: 0x040001F7 RID: 503
		private PropertyInfo[] PredictedNetwork;

		// Token: 0x040001F8 RID: 504
		internal Dictionary<int, Entity.PredictionDataStore> PredictedStore;

		// Token: 0x040001F9 RID: 505
		private int verifyCount;

		// Token: 0x040001FA RID: 506
		internal CBaseEntity serverEnt;

		// Token: 0x040001FC RID: 508
		private TransmitType _transmit;

		/// <summary>
		/// Accessor to add, remove and check entity tags
		/// </summary>
		// Token: 0x040001FF RID: 511
		public readonly EntityTags Tags;

		/// <summary>
		/// Tags that exist on the server and are networked down to the client
		/// </summary>
		// Token: 0x04000200 RID: 512
		internal HashSet<string> networkTags;

		// Token: 0x04000201 RID: 513
		private int networkTagsHashCode;

		// Token: 0x04000202 RID: 514
		public WaterLevel WaterLevel;

		// Token: 0x02000202 RID: 514
		// (Invoke) Token: 0x06001D58 RID: 7512
		public delegate ValueTask StandardOutputDelegate(Entity activator, float delay = 0f);

		/// <summary>
		/// A Map Logic Output, for use in the Hammer Editor.
		/// </summary>
		// Token: 0x02000203 RID: 515
		public struct Output
		{
			/// <summary>
			/// You shouldn't really ever be initializing this manually, 
			/// codegen will take care of that by generating a CreateHammerOutputs method for
			/// each entity filled with constructors for these.
			/// </summary>
			// Token: 0x06001D5B RID: 7515 RVA: 0x00072B91 File Offset: 0x00070D91
			public Output(Entity entity, string name)
			{
				this.Owner = entity;
				this.Name = name;
			}

			// Token: 0x06001D5C RID: 7516 RVA: 0x00072BA1 File Offset: 0x00070DA1
			public void Listen(Entity.StandardOutputDelegate d)
			{
				this.Owner.AddOutputEvent(this.Name, d, 0f);
			}

			// Token: 0x06001D5D RID: 7517 RVA: 0x00072BBA File Offset: 0x00070DBA
			public ValueTask Fire(Entity activator, float delay = 0f)
			{
				return this.Owner.FireOutput(this.Name, activator, null, delay);
			}

			// Token: 0x06001D5E RID: 7518 RVA: 0x00072BD0 File Offset: 0x00070DD0
			[Obsolete("Use Output<T>.Fire instead.")]
			public ValueTask FireWithParam(Entity activator, object value = null, float delay = 0f)
			{
				return this.Owner.FireOutput(this.Name, activator, value, delay);
			}

			// Token: 0x0400109C RID: 4252
			internal Entity Owner;

			// Token: 0x0400109D RID: 4253
			internal string Name;
		}

		/// <summary>
		/// A Map Logic Output with a typed parameter, for use in the Hammer Editor.
		/// </summary>
		// Token: 0x02000204 RID: 516
		public struct Output<T>
		{
			/// <summary>
			/// You shouldn't really ever be initializing this manually, 
			/// codegen will take care of that by generating a CreateHammerOutputs method for
			/// each entity filled with constructors for these.
			/// </summary>
			// Token: 0x06001D5F RID: 7519 RVA: 0x00072BE6 File Offset: 0x00070DE6
			public Output(Entity entity, string name)
			{
				this.Owner = entity;
				this.Name = name;
			}

			// Token: 0x06001D60 RID: 7520 RVA: 0x00072BF6 File Offset: 0x00070DF6
			public void Listen(Entity.StandardOutputDelegate d)
			{
				this.Owner.AddOutputEvent(this.Name, d, 0f);
			}

			// Token: 0x06001D61 RID: 7521 RVA: 0x00072C0F File Offset: 0x00070E0F
			public ValueTask Fire(Entity activator, T value, float delay = 0f)
			{
				return this.Owner.FireOutput(this.Name, activator, value, delay);
			}

			// Token: 0x0400109E RID: 4254
			internal Entity Owner;

			// Token: 0x0400109F RID: 4255
			internal string Name;
		}

		// Token: 0x02000205 RID: 517
		private struct LagCompensationScope : IDisposable
		{
			// Token: 0x06001D62 RID: 7522 RVA: 0x00072C2A File Offset: 0x00070E2A
			public void Dispose()
			{
				if (Prediction.CurrentHost == this.Client)
				{
					this.Client.FinishLagCompensation();
				}
			}

			// Token: 0x040010A0 RID: 4256
			public ClientEntity Client;
		}

		// Token: 0x02000206 RID: 518
		internal class PredictionDataStore
		{
			// Token: 0x06001D63 RID: 7523 RVA: 0x00072C44 File Offset: 0x00070E44
			internal PredictionDataStore(Entity ent)
			{
				this.Entity = ent;
				if (this.Entity.PredictedLocal == null)
				{
					this.Entity.PredictedLocal = (from x in ent.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
						where this.IsAppropriate(x, true, false)
						select x).ToArray<PropertyInfo>();
				}
				if (this.Entity.PredictedNetwork == null)
				{
					this.Entity.PredictedNetwork = (from x in ent.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
						where this.IsAppropriate(x, false, true)
						select x).ToArray<PropertyInfo>();
				}
			}

			// Token: 0x06001D64 RID: 7524 RVA: 0x00072CDF File Offset: 0x00070EDF
			private bool IsAppropriate(PropertyInfo prop, bool network, bool variables)
			{
				return prop.HasAttribute(typeof(PredictedAttribute)) && prop.HasAttribute(typeof(NetAttribute)) == network;
			}

			// Token: 0x06001D65 RID: 7525 RVA: 0x00072D08 File Offset: 0x00070F08
			public bool TryGetValue(string name, out object value)
			{
				return this.Obj.TryGetValue(name, out value);
			}

			// Token: 0x06001D66 RID: 7526 RVA: 0x00072D18 File Offset: 0x00070F18
			public void Read(bool network, bool variables)
			{
				this.Obj.Clear();
				if (network && this.Entity.PredictedNetwork != null)
				{
					foreach (PropertyInfo prop in this.Entity.PredictedNetwork)
					{
						this.Obj[prop.Name] = prop.GetValue(this.Entity);
					}
				}
				if (variables && this.Entity.PredictedLocal != null)
				{
					foreach (PropertyInfo prop2 in this.Entity.PredictedLocal)
					{
						this.Obj[prop2.Name] = prop2.GetValue(this.Entity);
					}
				}
			}

			// Token: 0x06001D67 RID: 7527 RVA: 0x00072DC8 File Offset: 0x00070FC8
			public void Restore(bool network, bool variables)
			{
				if (network && this.Entity.PredictedNetwork != null)
				{
					foreach (PropertyInfo prop in this.Entity.PredictedNetwork)
					{
						object val;
						if (this.Obj.TryGetValue(prop.Name, out val))
						{
							prop.SetValue(this.Entity, val);
						}
					}
				}
				if (variables && this.Entity.PredictedLocal != null)
				{
					foreach (PropertyInfo prop2 in this.Entity.PredictedLocal)
					{
						object val2;
						if (this.Obj.TryGetValue(prop2.Name, out val2))
						{
							prop2.SetValue(this.Entity, val2);
						}
					}
				}
			}

			// Token: 0x06001D68 RID: 7528 RVA: 0x00072E7C File Offset: 0x0007107C
			public void Compare(int tickNumber, Entity.PredictionDataStore predicted, Action<string, object> OnPredictionError)
			{
				foreach (KeyValuePair<string, object> f in this.Obj)
				{
					object predictedValue;
					if (predicted.Obj.TryGetValue(f.Key, out predictedValue) && !this.AreTheSame(f.Value, predictedValue))
					{
						OnPredictionError(f.Key, f.Value);
						GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("[{0}] Prediction Error {1}.{2} ({3} (predicted: {4}) [tick:{5}]", new object[]
						{
							this.Entity,
							this.Entity.GetType(),
							f.Key,
							f.Value,
							predictedValue,
							tickNumber
						}));
						predicted.Obj[f.Key] = f.Value;
					}
				}
			}

			// Token: 0x06001D69 RID: 7529 RVA: 0x00072F78 File Offset: 0x00071178
			private bool AreTheSame(object a, object b)
			{
				if (a == null)
				{
					return b == null;
				}
				if (b == null)
				{
					return a == null;
				}
				if (a.GetType() != b.GetType())
				{
					return false;
				}
				if (a is BaseNetworkable)
				{
					return a.GetType() == b.GetType();
				}
				return object.Equals(a, b);
			}

			/// <summary>
			/// A prediction error has occurred, so we're forcing the values to match what came from the server
			/// </summary>
			// Token: 0x06001D6A RID: 7530 RVA: 0x00072FCB File Offset: 0x000711CB
			public void StompValue(string key, object value)
			{
				if (this.Obj == null)
				{
					return;
				}
				this.Obj[key] = value;
			}

			// Token: 0x040010A1 RID: 4257
			public int CommandId;

			// Token: 0x040010A2 RID: 4258
			private Dictionary<string, object> Obj = new Dictionary<string, object>();

			// Token: 0x040010A3 RID: 4259
			private Entity Entity;
		}
	}
}
