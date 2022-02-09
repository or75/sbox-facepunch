using System;
using System.Runtime.CompilerServices;
using NativeEngine;

namespace Sandbox
{
	/// <summary>
	/// A particle system.
	/// </summary>
	// Token: 0x0200007A RID: 122
	public class Particles : IDisposable
	{
		/// <summary>
		/// Should we play the particle simulation or not
		/// </summary>
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000CAB RID: 3243 RVA: 0x00040E9C File Offset: 0x0003F09C
		// (set) Token: 0x06000CAC RID: 3244 RVA: 0x00040EA4 File Offset: 0x0003F0A4
		public bool Simulating
		{
			get
			{
				return this.isSimulating;
			}
			set
			{
				this.isSimulating = value;
				GameParticleManager.SetFrozen(this.ParticleIndex, !value);
			}
		}

		/// <summary>
		/// Should we be drawing the particles or not
		/// </summary>
		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000CAD RID: 3245 RVA: 0x00040EBD File Offset: 0x0003F0BD
		// (set) Token: 0x06000CAE RID: 3246 RVA: 0x00040EC5 File Offset: 0x0003F0C5
		public bool EnableDrawing
		{
			get
			{
				return this.isDrawing;
			}
			set
			{
				this.isDrawing = value;
				GameParticleManager.SetShouldDraw(this.ParticleIndex, value);
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000CAF RID: 3247 RVA: 0x00040EDB File Offset: 0x0003F0DB
		// (set) Token: 0x06000CB0 RID: 3248 RVA: 0x00040EE3 File Offset: 0x0003F0E3
		public float TimeScale
		{
			get
			{
				return this.timescale;
			}
			set
			{
				this.timescale = value;
				GameParticleManager.SetParticleSimulationTimescale(this.ParticleIndex, value);
			}
		}

		// Token: 0x06000CB1 RID: 3249 RVA: 0x00040EF9 File Offset: 0x0003F0F9
		internal static Particles Create(string name, Entity entity)
		{
			if (entity.IsValid())
			{
				return new Particles
				{
					ParticleIndex = GameParticleManager.CreateParticleIndex(Prediction.CurrentHostIndex, name, ParticleAttachment.CustomOrigin, entity.GetEntityIntPtr())
				};
			}
			return Particles.Create(name);
		}

		/// <summary>
		/// Create a particle system by name
		/// </summary>
		// Token: 0x06000CB2 RID: 3250 RVA: 0x00040F27 File Offset: 0x0003F127
		public static Particles Create(string name)
		{
			if (!Prediction.FirstTime)
			{
				return null;
			}
			return new Particles
			{
				ParticleIndex = GameParticleManager.CreateParticleIndex(Prediction.CurrentHostIndex, name, ParticleAttachment.CustomOrigin, IntPtr.Zero)
			};
		}

		/// <summary>
		/// Create a particle system by name at a world position
		/// </summary>
		// Token: 0x06000CB3 RID: 3251 RVA: 0x00040F4E File Offset: 0x0003F14E
		public static Particles Create(string name, Vector3 position)
		{
			if (!Prediction.FirstTime)
			{
				return null;
			}
			Particles particles = Particles.Create(name);
			particles.SetPosition(0, position);
			return particles;
		}

		/// <summary>
		/// Create a particle system by name tied to an entity
		/// </summary>
		// Token: 0x06000CB4 RID: 3252 RVA: 0x00040F67 File Offset: 0x0003F167
		public static Particles Create(string name, Entity entity, bool follow = true)
		{
			if (!Prediction.FirstTime)
			{
				return null;
			}
			Particles particles = Particles.Create(name, entity);
			particles.SetEntity(0, entity, follow);
			return particles;
		}

		/// <summary>
		/// Create a particle system by name tied to an attachment on an entity
		/// </summary>
		// Token: 0x06000CB5 RID: 3253 RVA: 0x00040F82 File Offset: 0x0003F182
		public static Particles Create(string name, Entity entity, string attachment, bool follow = true)
		{
			if (!Prediction.FirstTime)
			{
				return null;
			}
			Particles particles = Particles.Create(name, entity);
			particles.SetEntityAttachment(0, entity, attachment, follow);
			return particles;
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x00040FA0 File Offset: 0x0003F1A0
		~Particles()
		{
			this.Dispose(false);
		}

		/// <summary>
		/// Dispose of this particle system
		/// </summary>
		// Token: 0x06000CB7 RID: 3255 RVA: 0x00040FD0 File Offset: 0x0003F1D0
		public void Dispose()
		{
			ThreadSafe.AssertIsMainThread("Dispose");
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000CB8 RID: 3256 RVA: 0x00040FEC File Offset: 0x0003F1EC
		protected virtual void Dispose(bool disposing)
		{
			if (ThreadSafe.IsMainThread)
			{
				if (this.ParticleIndex != -1)
				{
					GameParticleManager.ReleaseParticleIndex(this.ParticleIndex);
					this.ParticleIndex = -1;
				}
				return;
			}
			MainThreadContext instance = MainThreadContext.Instance;
			if (instance == null)
			{
				return;
			}
			instance.Post(delegate(object o)
			{
				this.Dispose(disposing);
			}, null);
		}

		/// <summary>
		/// Destroy this particle system
		/// </summary>
		// Token: 0x06000CB9 RID: 3257 RVA: 0x0004104C File Offset: 0x0003F24C
		public void Destroy(bool immediately = false)
		{
			GameParticleManager.DestroyParticleEffect(this.ParticleIndex, immediately);
		}

		/// <summary>
		/// Set control point data as a position vector
		/// </summary>
		// Token: 0x06000CBA RID: 3258 RVA: 0x0004105A File Offset: 0x0003F25A
		public void SetPosition(int index, Vector3 position)
		{
			GameParticleManager.SetParticleControl(this.ParticleIndex, index, position);
		}

		/// <summary>
		/// Set a single component of a given control point's position
		/// </summary>
		// Token: 0x06000CBB RID: 3259 RVA: 0x0004106C File Offset: 0x0003F26C
		public void SetPositionComponent(int index, int component, float value)
		{
			if (component < 0 || component > 2)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(68, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Invalid value passed to argument 'key', must be in range [0,2], got ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(component);
				throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			GameParticleManager.SetParticleControlComponent(this.ParticleIndex, index, component, value);
		}

		/// <summary>
		/// Set control point data as an orientation
		/// </summary>
		// Token: 0x06000CBC RID: 3260 RVA: 0x000410BB File Offset: 0x0003F2BB
		public void SetOrientation(int index, Angles angles)
		{
			GameParticleManager.SetParticleControlOrientation(this.ParticleIndex, index, angles);
		}

		/// <summary>
		/// Set control point data as an orientation. Converts Rotation to Angles for you.
		/// </summary>
		// Token: 0x06000CBD RID: 3261 RVA: 0x000410CB File Offset: 0x0003F2CB
		public void SetOrientation(int index, Rotation rotation)
		{
			this.SetOrientation(index, rotation.Angles());
		}

		/// <summary>
		/// Set control point data as a direction vector
		/// </summary>
		// Token: 0x06000CBE RID: 3262 RVA: 0x000410DB File Offset: 0x0003F2DB
		public void SetForward(int index, Vector3 forward)
		{
			GameParticleManager.SetParticleControlForward(this.ParticleIndex, index, forward);
		}

		/// <summary>
		/// Set the control point to an entity's origin. Can specify whether to follow or not.
		/// </summary>
		// Token: 0x06000CBF RID: 3263 RVA: 0x000410EB File Offset: 0x0003F2EB
		public void SetEntity(int index, Entity entity, bool follow = true)
		{
			GameParticleManager.SetParticleControlEnt(this.ParticleIndex, index, entity.GetEntityIntPtr(), follow ? ParticleAttachment.OriginFollow : ParticleAttachment.Origin, null);
		}

		/// <summary>
		/// Set the control point to an entity's origin offset by the local offset.
		/// </summary>
		// Token: 0x06000CC0 RID: 3264 RVA: 0x00041108 File Offset: 0x0003F308
		public void SetEntity(int index, Entity entity, Vector3 offset, bool follow = true)
		{
			GameParticleManager.SetParticleControlEnt(this.ParticleIndex, index, entity.GetEntityIntPtr(), follow ? ParticleAttachment.OriginFollow : ParticleAttachment.Origin, null);
			GameParticleManager.SetParticleControlOffset(this.ParticleIndex, index, offset);
		}

		/// <summary>
		/// Set the control point to an entity's attachment position. Can specify whether to follow or not.
		/// </summary>
		// Token: 0x06000CC1 RID: 3265 RVA: 0x00041134 File Offset: 0x0003F334
		public void SetEntityAttachment(int index, Entity entity, string attachment, bool follow = true)
		{
			GameParticleManager.SetParticleControlEnt(this.ParticleIndex, index, entity.GetEntityIntPtr(), follow ? ParticleAttachment.AttachmentFollow : ParticleAttachment.Attachment, attachment);
		}

		/// <summary>
		/// Set the control point to an entity's attachment position with an offset and custom attachment type.
		/// </summary>
		// Token: 0x06000CC2 RID: 3266 RVA: 0x00041152 File Offset: 0x0003F352
		public void SetEntityAttachment(int index, Entity entity, string attachmentName, Vector3 offset, ParticleAttachment attachment = ParticleAttachment.AttachmentFollow)
		{
			GameParticleManager.SetParticleControlEnt(this.ParticleIndex, index, entity.GetEntityIntPtr(), attachment, attachmentName);
			GameParticleManager.SetParticleControlOffset(this.ParticleIndex, index, offset);
		}

		/// <summary>
		/// Set the control point to an entity's bone position. Can specify whether to follow or not.
		/// </summary>
		// Token: 0x06000CC3 RID: 3267 RVA: 0x00041179 File Offset: 0x0003F379
		public void SetEntityBone(int index, Entity entity, int boneId, Transform offset = default(Transform), bool follow = true)
		{
			GameParticleManager.SetParticleControlEntBone(this.ParticleIndex, index, entity.GetEntityIntPtr(), follow ? ParticleAttachment.BoneFollow : ParticleAttachment.Bone, boneId, offset);
		}

		/// <summary>
		/// Sets the model of the control point.
		/// </summary>
		// Token: 0x06000CC4 RID: 3268 RVA: 0x0004119B File Offset: 0x0003F39B
		public void SetModel(int index, Model model)
		{
			GameParticleManager.SetParticleControlModel(this.ParticleIndex, index, model.native);
		}

		/// <summary>
		/// Sets the particle snapshot by asset name.
		/// </summary>
		// Token: 0x06000CC5 RID: 3269 RVA: 0x000411B0 File Offset: 0x0003F3B0
		public void SetSnapshot(int index, string assetName)
		{
			GameParticleManager.SetParticleControlSnapshotAsset(this.ParticleIndex, index, assetName);
		}

		// Token: 0x040001C8 RID: 456
		private int ParticleIndex;

		// Token: 0x040001C9 RID: 457
		private bool isSimulating = true;

		// Token: 0x040001CA RID: 458
		private bool isDrawing = true;

		// Token: 0x040001CB RID: 459
		private float timescale = 1f;
	}
}
