using System;

namespace Sandbox
{
	// Token: 0x0200007F RID: 127
	public sealed class AnimationSequence
	{
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000CED RID: 3309 RVA: 0x000418AD File Offset: 0x0003FAAD
		// (set) Token: 0x06000CEE RID: 3310 RVA: 0x000418B5 File Offset: 0x0003FAB5
		public AnimEntity Entity { get; private set; }

		// Token: 0x06000CEF RID: 3311 RVA: 0x000418BE File Offset: 0x0003FABE
		internal AnimationSequence(AnimEntity entity)
		{
			this.Entity = entity;
		}

		/// <summary>
		/// The duration of the currently playing sequence (seconds)
		/// </summary>
		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000CF0 RID: 3312 RVA: 0x000418D0 File Offset: 0x0003FAD0
		public float Duration
		{
			get
			{
				if (!this.Entity.clientAnimating.IsNull)
				{
					return this.Entity.clientAnimating.SequenceDuration();
				}
				if (!this.Entity.serverAnimating.IsNull)
				{
					return this.Entity.serverAnimating.SequenceDuration();
				}
				return 0f;
			}
		}

		/// <summary>
		/// Get whether the current animation sequence has finished
		/// </summary>
		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000CF1 RID: 3313 RVA: 0x00041928 File Offset: 0x0003FB28
		public bool IsFinished
		{
			get
			{
				if (!this.Entity.clientAnimating.IsNull)
				{
					return this.Entity.clientAnimating.IsSequenceFinished();
				}
				return !this.Entity.serverAnimating.IsNull && this.Entity.serverAnimating.IsSequenceFinished();
			}
		}

		/// <summary>
		/// The name of the currently playing animation sequence
		/// </summary>
		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000CF3 RID: 3315 RVA: 0x000419D0 File Offset: 0x0003FBD0
		// (set) Token: 0x06000CF2 RID: 3314 RVA: 0x0004197C File Offset: 0x0003FB7C
		public string Name
		{
			get
			{
				if (!this.Entity.clientAnimating.IsNull)
				{
					return this.Entity.clientAnimating.Script_GetSequence();
				}
				if (!this.Entity.serverAnimating.IsNull)
				{
					return this.Entity.serverAnimating.Script_GetSequence();
				}
				return null;
			}
			set
			{
				if (!this.Entity.clientAnimating.IsNull)
				{
					this.Entity.clientAnimating.Script_ResetSequence(value);
				}
				if (!this.Entity.serverAnimating.IsNull)
				{
					this.Entity.serverAnimating.Script_ResetSequence(value);
				}
			}
		}

		/// <summary>
		/// The normalized (between 0 and 1) elapsed time of the currently playing
		/// animation sequence
		/// </summary>
		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000CF4 RID: 3316 RVA: 0x00041A24 File Offset: 0x0003FC24
		// (set) Token: 0x06000CF5 RID: 3317 RVA: 0x00041A7C File Offset: 0x0003FC7C
		public float TimeNormalized
		{
			get
			{
				if (!this.Entity.clientAnimating.IsNull)
				{
					return this.Entity.clientAnimating.GetCycle();
				}
				if (!this.Entity.serverAnimating.IsNull)
				{
					return this.Entity.serverAnimating.GetCycle();
				}
				return 0f;
			}
			set
			{
				if (!this.Entity.clientAnimating.IsNull)
				{
					this.Entity.clientAnimating.SetCycle(value);
				}
				if (!this.Entity.serverAnimating.IsNull)
				{
					this.Entity.serverAnimating.SetCycle(value);
				}
			}
		}

		/// <summary>
		/// The elapsed time of the currently playing animation sequence (seconds)
		/// </summary>
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000CF6 RID: 3318 RVA: 0x00041ACF File Offset: 0x0003FCCF
		// (set) Token: 0x06000CF7 RID: 3319 RVA: 0x00041ADE File Offset: 0x0003FCDE
		public float Time
		{
			get
			{
				return this.TimeNormalized * this.Duration;
			}
			set
			{
				this.TimeNormalized = value / this.Duration;
			}
		}
	}
}
