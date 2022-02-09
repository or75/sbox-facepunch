using System;
using System.ComponentModel.DataAnnotations;
using Hammer;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x02000080 RID: 128
	[Library("animating_entity")]
	[Skip]
	[Display(Name = "Anim Entity")]
	[Icon("directions_run")]
	public class AnimEntity : ModelEntity
	{
		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000CF8 RID: 3320 RVA: 0x00041AEE File Offset: 0x0003FCEE
		internal override string NativeEntityClass
		{
			get
			{
				return "baseanimating";
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000CF9 RID: 3321 RVA: 0x00041AF5 File Offset: 0x0003FCF5
		// (set) Token: 0x06000CFA RID: 3322 RVA: 0x00041AFD File Offset: 0x0003FCFD
		public AnimationSequence CurrentSequence { get; private set; }

		/// <summary>
		/// The currently playing sequence/animation
		/// </summary>
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000CFC RID: 3324 RVA: 0x00041B3A File Offset: 0x0003FD3A
		// (set) Token: 0x06000CFB RID: 3323 RVA: 0x00041B06 File Offset: 0x0003FD06
		[Obsolete("Use CurrentSequence.Name")]
		public string Sequence
		{
			get
			{
				if (!this.clientAnimating.IsNull)
				{
					return this.clientAnimating.Script_GetSequence();
				}
				if (!this.serverAnimating.IsNull)
				{
					return this.serverAnimating.Script_GetSequence();
				}
				return null;
			}
			set
			{
				if (!this.clientAnimating.IsNull)
				{
					this.clientAnimating.Script_ResetSequence(value);
				}
				if (!this.serverAnimating.IsNull)
				{
					this.serverAnimating.Script_ResetSequence(value);
				}
			}
		}

		/// <summary>
		/// Allows the entity to not use the anim graph so it can play sequences directly
		/// </summary>
		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000CFE RID: 3326 RVA: 0x00041BA3 File Offset: 0x0003FDA3
		// (set) Token: 0x06000CFD RID: 3325 RVA: 0x00041B6F File Offset: 0x0003FD6F
		public bool UseAnimGraph
		{
			get
			{
				if (!this.clientAnimating.IsNull)
				{
					return this.clientAnimating.GetShouldUseAnimGraph();
				}
				return !this.serverAnimating.IsNull && this.serverAnimating.GetShouldUseAnimGraph();
			}
			set
			{
				if (!this.clientAnimating.IsNull)
				{
					this.clientAnimating.SetShouldUseAnimGraph(value);
				}
				if (!this.serverAnimating.IsNull)
				{
					this.serverAnimating.SetShouldUseAnimGraph(value);
				}
			}
		}

		/// <summary>
		/// Override the anim graph this entity uses
		/// </summary>
		// Token: 0x06000CFF RID: 3327 RVA: 0x00041BD8 File Offset: 0x0003FDD8
		public void SetAnimGraph(string name)
		{
			if (!this.clientModel.IsNull)
			{
				this.clientAnimating.SetOverrideGraphName(string.IsNullOrEmpty(name) ? null : name);
			}
			if (!this.serverModel.IsNull)
			{
				if (string.IsNullOrEmpty(name))
				{
					this.serverAnimating.SetOverrideGraphName(null);
					return;
				}
				Precache.Add(name);
				this.serverAnimating.SetOverrideGraphName(name);
			}
		}

		/// <summary>
		/// Whether this entity's model has an anim graph or not
		/// </summary>
		// Token: 0x06000D00 RID: 3328 RVA: 0x00041C3D File Offset: 0x0003FE3D
		public bool HasAnimGraph()
		{
			if (!this.clientAnimating.IsNull)
			{
				return this.clientAnimating.HasAnimGraph();
			}
			return !this.serverAnimating.IsNull && this.serverAnimating.HasAnimGraph();
		}

		/// <summary>
		/// Playback rate of the animations on this entity
		/// </summary>
		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000D01 RID: 3329 RVA: 0x00041C72 File Offset: 0x0003FE72
		// (set) Token: 0x06000D02 RID: 3330 RVA: 0x00041CAB File Offset: 0x0003FEAB
		public float PlaybackRate
		{
			get
			{
				if (!this.clientAnimating.IsNull)
				{
					return this.clientAnimating.GetPlaybackRate();
				}
				if (!this.serverAnimating.IsNull)
				{
					return this.serverAnimating.GetPlaybackRate();
				}
				return 0f;
			}
			set
			{
				if (!this.clientAnimating.IsNull)
				{
					this.clientAnimating.SetPlaybackRate(value);
				}
				if (!this.serverAnimating.IsNull)
				{
					this.serverAnimating.SetPlaybackRate(value);
				}
			}
		}

		/// <summary>
		/// Experimental root motion velocity for anim graphs that use root motion
		/// </summary>
		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000D03 RID: 3331 RVA: 0x00041CE0 File Offset: 0x0003FEE0
		public Vector3 RootMotion
		{
			get
			{
				if (!this.clientAnimating.IsNull)
				{
					return this.clientAnimating.GetRootMotion();
				}
				if (!this.serverAnimating.IsNull)
				{
					return this.serverAnimating.GetRootMotion();
				}
				return default(Vector3);
			}
		}

		/// <summary>
		/// Experimental root motion angle velocity for anim graphs that use root motion
		/// </summary>
		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000D04 RID: 3332 RVA: 0x00041D28 File Offset: 0x0003FF28
		public float RootMotionAngle
		{
			get
			{
				if (!this.clientAnimating.IsNull)
				{
					return this.clientAnimating.GetRootMotionAngle();
				}
				if (!this.serverAnimating.IsNull)
				{
					return this.serverAnimating.GetRootMotionAngle();
				}
				return 0f;
			}
		}

		// Token: 0x06000D05 RID: 3333 RVA: 0x00041D61 File Offset: 0x0003FF61
		[Obsolete]
		public void AnimFrame()
		{
		}

		// Token: 0x06000D06 RID: 3334 RVA: 0x00041D63 File Offset: 0x0003FF63
		[Obsolete]
		public void AnimFrame(float amount)
		{
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x00041D65 File Offset: 0x0003FF65
		public AnimEntity()
		{
		}

		// Token: 0x06000D08 RID: 3336 RVA: 0x00041D6D File Offset: 0x0003FF6D
		public AnimEntity(string modelName)
		{
			base.SetModel(modelName);
		}

		// Token: 0x06000D09 RID: 3337 RVA: 0x00041D7C File Offset: 0x0003FF7C
		public AnimEntity(string modelName, Entity parent)
		{
			base.SetModel(modelName);
			base.SetParent(parent, true);
		}

		// Token: 0x06000D0A RID: 3338 RVA: 0x00041D94 File Offset: 0x0003FF94
		internal override void OnNativeEntity(CEntityInstance ent)
		{
			base.OnNativeEntity(ent);
			if (base.IsClient)
			{
				this.clientAnimating = (C_BaseAnimating)this.clientEnt;
				if (this.clientAnimating.IsNull)
				{
					throw new Exception("clientAnimating is null");
				}
			}
			if (base.IsServer)
			{
				this.serverAnimating = (CBaseAnimating)this.serverEnt;
				if (this.serverAnimating.IsNull)
				{
					throw new Exception("serverAnimating is null");
				}
			}
			this.CurrentSequence = new AnimationSequence(this);
		}

		/// <summary>
		/// Get the duration of a sequence by name
		/// </summary>
		// Token: 0x06000D0B RID: 3339 RVA: 0x00041E16 File Offset: 0x00040016
		public float GetSequenceDuration(string sequenceName)
		{
			if (!this.clientAnimating.IsNull)
			{
				return this.clientAnimating.Script_SequenceDuration(sequenceName);
			}
			if (!this.serverAnimating.IsNull)
			{
				return this.serverAnimating.Script_SequenceDuration(sequenceName);
			}
			return 0f;
		}

		/// <summary>
		/// Get the duration of the currently playing sequence
		/// </summary>
		// Token: 0x06000D0C RID: 3340 RVA: 0x00041E51 File Offset: 0x00040051
		[Obsolete("Use CurrentSequence.Duration")]
		public float GetSequenceDuration()
		{
			if (!this.clientAnimating.IsNull)
			{
				return this.clientAnimating.SequenceDuration();
			}
			if (!this.serverAnimating.IsNull)
			{
				return this.serverAnimating.SequenceDuration();
			}
			return 0f;
		}

		/// <summary>
		/// Get whether the current animation sequence has finished
		/// </summary>
		// Token: 0x06000D0D RID: 3341 RVA: 0x00041E8A File Offset: 0x0004008A
		[Obsolete("Use CurrentSequence.IsFinished")]
		public bool IsSequenceFinished()
		{
			if (!this.clientAnimating.IsNull)
			{
				return this.clientAnimating.IsSequenceFinished();
			}
			return !this.serverAnimating.IsNull && this.serverAnimating.IsSequenceFinished();
		}

		/// <summary>
		/// Check whether a sequence is valid by name
		/// </summary>
		// Token: 0x06000D0E RID: 3342 RVA: 0x00041EBF File Offset: 0x000400BF
		public bool IsValidSequence(string sequenceName)
		{
			if (!this.clientAnimating.IsNull)
			{
				return this.clientAnimating.IsValidSequence(sequenceName);
			}
			return !this.serverAnimating.IsNull && this.serverAnimating.IsValidSequence(sequenceName);
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x00041EF6 File Offset: 0x000400F6
		public bool GetAnimBool(string name)
		{
			if (!this.clientAnimating.IsNull)
			{
				return this.clientAnimating.GetBoolGraphParameter(name);
			}
			return !this.serverAnimating.IsNull && this.serverAnimating.GetBoolGraphParameter(name);
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x00041F2D File Offset: 0x0004012D
		public float GetAnimFloat(string name)
		{
			if (!this.clientAnimating.IsNull)
			{
				return this.clientAnimating.GetFloatGraphParameter(name);
			}
			if (!this.serverAnimating.IsNull)
			{
				return this.serverAnimating.GetFloatGraphParameter(name);
			}
			return 0f;
		}

		// Token: 0x06000D11 RID: 3345 RVA: 0x00041F68 File Offset: 0x00040168
		public Vector3 GetAnimVector(string name)
		{
			if (!this.clientAnimating.IsNull)
			{
				return this.clientAnimating.GetVectorGraphParameter(name);
			}
			if (!this.serverAnimating.IsNull)
			{
				return this.serverAnimating.GetVectorGraphParameter(name);
			}
			return default(Vector3);
		}

		// Token: 0x06000D12 RID: 3346 RVA: 0x00041FB2 File Offset: 0x000401B2
		public int GetAnimInt(string name)
		{
			if (!this.clientAnimating.IsNull)
			{
				return this.clientAnimating.GetIntGraphParameter(name);
			}
			if (!this.serverAnimating.IsNull)
			{
				return this.serverAnimating.GetIntGraphParameter(name);
			}
			return 0;
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x00041FE9 File Offset: 0x000401E9
		public void SetAnimBool(string name, bool value)
		{
			if (!this.clientAnimating.IsNull)
			{
				this.clientAnimating.SetGraphParameter(name, value);
			}
			if (!this.serverAnimating.IsNull)
			{
				this.serverAnimating.SetGraphParameter(name, value);
			}
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x0004201F File Offset: 0x0004021F
		public void SetAnimFloat(string name, float value)
		{
			if (!this.clientAnimating.IsNull)
			{
				this.clientAnimating.SetGraphParameter(name, value);
			}
			if (!this.serverAnimating.IsNull)
			{
				this.serverAnimating.SetGraphParameter(name, value);
			}
		}

		// Token: 0x06000D15 RID: 3349 RVA: 0x00042055 File Offset: 0x00040255
		public void SetAnimVector(string name, Vector3 value)
		{
			if (!this.clientAnimating.IsNull)
			{
				this.clientAnimating.SetGraphParameter(name, value);
			}
			if (!this.serverAnimating.IsNull)
			{
				this.serverAnimating.SetGraphParameter(name, value);
			}
		}

		// Token: 0x06000D16 RID: 3350 RVA: 0x0004208B File Offset: 0x0004028B
		public void SetAnimRotation(string name, Rotation value)
		{
			if (!this.clientAnimating.IsNull)
			{
				this.clientAnimating.SetGraphParameter(name, value);
			}
			if (!this.serverAnimating.IsNull)
			{
				this.serverAnimating.SetGraphParameter(name, value);
			}
		}

		// Token: 0x06000D17 RID: 3351 RVA: 0x000420C1 File Offset: 0x000402C1
		public void SetAnimTransform(string name, Transform value)
		{
			this.SetAnimVector(name + ".position", value.Position);
			this.SetAnimRotation(name + ".rotation", value.Rotation);
		}

		/// <summary>
		/// Converts value to vector local to this entity's eyepos and passes it to SetAnimVector
		/// </summary>
		// Token: 0x06000D18 RID: 3352 RVA: 0x000420F4 File Offset: 0x000402F4
		public void SetAnimLookAt(string name, Vector3 value)
		{
			value = (value - base.EyePos) * this.Rotation.Inverse;
			this.SetAnimVector(name, value);
		}

		// Token: 0x06000D19 RID: 3353 RVA: 0x0004212A File Offset: 0x0004032A
		public void SetAnimInt(string name, int value)
		{
			if (!this.clientAnimating.IsNull)
			{
				this.clientAnimating.SetGraphParameter(name, value);
			}
			if (!this.serverAnimating.IsNull)
			{
				this.serverAnimating.SetGraphParameter(name, value);
			}
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x00042160 File Offset: 0x00040360
		public void ResetAnimParams()
		{
			if (!this.clientAnimating.IsNull)
			{
				this.clientAnimating.ResetGraphParameters();
			}
			if (!this.serverAnimating.IsNull)
			{
				this.serverAnimating.ResetGraphParameters();
			}
		}

		// Token: 0x06000D1B RID: 3355 RVA: 0x00042192 File Offset: 0x00040392
		internal override void InternalDestruct()
		{
			base.InternalDestruct();
			this.serverAnimating = IntPtr.Zero;
			this.clientAnimating = IntPtr.Zero;
		}

		// Token: 0x06000D1C RID: 3356 RVA: 0x000421BA File Offset: 0x000403BA
		internal override void InternalSpawn()
		{
			base.InternalSpawn();
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000D1D RID: 3357 RVA: 0x000421C2 File Offset: 0x000403C2
		// (set) Token: 0x06000D1E RID: 3358 RVA: 0x000421CA File Offset: 0x000403CA
		[Obsolete]
		public bool EnableClientsideAnimation { get; set; }

		// Token: 0x06000D1F RID: 3359 RVA: 0x000421D3 File Offset: 0x000403D3
		[Obsolete("Use SetAnimBool")]
		public void SetAnimParam(string name, bool value)
		{
			this.SetAnimBool(name, value);
		}

		// Token: 0x06000D20 RID: 3360 RVA: 0x000421DD File Offset: 0x000403DD
		[Obsolete("Use SetAnimFloat")]
		public void SetAnimParam(string name, float value)
		{
			this.SetAnimFloat(name, value);
		}

		// Token: 0x06000D21 RID: 3361 RVA: 0x000421E7 File Offset: 0x000403E7
		[Obsolete("Use SetAnimVector")]
		public void SetAnimParam(string name, Vector3 value)
		{
			this.SetAnimVector(name, value);
		}

		// Token: 0x06000D22 RID: 3362 RVA: 0x000421F1 File Offset: 0x000403F1
		[Obsolete("Use SetAnimInt")]
		public void SetAnimParam(string name, int value)
		{
			this.SetAnimInt(name, value);
		}

		/// <summary>
		/// Called when a new animation sequence is set
		/// </summary>
		// Token: 0x06000D23 RID: 3363 RVA: 0x000421FB File Offset: 0x000403FB
		protected virtual void OnNewSequence()
		{
		}

		// Token: 0x06000D24 RID: 3364 RVA: 0x000421FD File Offset: 0x000403FD
		internal override void InternalOnNewSequence()
		{
			this.OnNewSequence();
		}

		/// <summary>
		/// Called when an animation sequence has finsihed or looped
		/// </summary>
		/// <param name="looped">If the animation was restarted rather than stopped.</param>
		// Token: 0x06000D25 RID: 3365 RVA: 0x00042205 File Offset: 0x00040405
		protected virtual void OnSequenceFinished(bool looped)
		{
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x00042207 File Offset: 0x00040407
		internal override void InternalOnSequenceFinished(bool looped)
		{
			this.OnSequenceFinished(looped);
		}

		/// <summary>
		/// Called when the anim graph of this entity has a tag change.
		/// This will be called only for "Status" type tags.
		/// </summary>
		/// <param name="tag">The name of the tag that has changed its state, as it is defined in the AnimGraph.</param>
		/// <param name="fireMode">Describes how the state of the tag has changed.</param>
		// Token: 0x06000D27 RID: 3367 RVA: 0x00042210 File Offset: 0x00040410
		protected virtual void OnAnimGraphTag(string tag, AnimEntity.AnimGraphTagEvent fireMode)
		{
		}

		// Token: 0x06000D28 RID: 3368 RVA: 0x00042212 File Offset: 0x00040412
		internal override void InternalOnAnimGraphTag(string tag, int fireMode)
		{
			this.OnAnimGraphTag(tag, (AnimEntity.AnimGraphTagEvent)fireMode);
		}

		/// <summary>
		/// An anim graph has been created for this entity. You will want to set up initial AnimGraph parameters here.
		/// </summary>
		// Token: 0x06000D29 RID: 3369 RVA: 0x0004221C File Offset: 0x0004041C
		protected virtual void OnAnimGraphCreated()
		{
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x0004221E File Offset: 0x0004041E
		internal override void InternalOnAnimGraphCreated()
		{
			this.OnAnimGraphCreated();
		}

		/// <summary>
		/// Allow animgraph tool to use this entity as the preview, Server only
		/// </summary>
		// Token: 0x06000D2B RID: 3371 RVA: 0x00042226 File Offset: 0x00040426
		public void SetAnimGraphPreview()
		{
			if (this.serverAnimating.IsValid)
			{
				GameGlue.SetAnimGraphPreview(this.serverAnimating);
			}
		}

		// Token: 0x040001D4 RID: 468
		internal CBaseAnimating serverAnimating;

		// Token: 0x040001D5 RID: 469
		internal C_BaseAnimating clientAnimating;

		/// <summary>
		/// Enumeration that describes how the AnimGraph tag state changed. Used in <see cref="M:Sandbox.AnimEntity.OnAnimGraphTag(System.String,Sandbox.AnimEntity.AnimGraphTagEvent)" />.
		/// </summary>
		// Token: 0x02000201 RID: 513
		public enum AnimGraphTagEvent
		{
			/// <summary>
			/// Tag was activated and deactivated on the same frame
			/// </summary>
			// Token: 0x04001099 RID: 4249
			Fired,
			/// <summary>
			/// The tag has become active
			/// </summary>
			// Token: 0x0400109A RID: 4250
			Start,
			/// <summary>
			/// The tag has become inactive
			/// </summary>
			// Token: 0x0400109B RID: 4251
			End
		}
	}
}
