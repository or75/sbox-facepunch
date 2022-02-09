using System;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x02000087 RID: 135
	[Library]
	public class EntityComponent : BaseNetworkable, IComponent
	{
		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000E32 RID: 3634 RVA: 0x00044ED9 File Offset: 0x000430D9
		// (set) Token: 0x06000E33 RID: 3635 RVA: 0x00044EE7 File Offset: 0x000430E7
		public unsafe virtual bool Enabled
		{
			get
			{
				return *this._enabledNet.GetValue();
			}
			set
			{
				if (*this._enabledNet.GetValue() == value)
				{
					return;
				}
				this._enabledNet.SetValue(value);
				this.Entity.OnComponentEnableStateChangedInternal(this, value);
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000E34 RID: 3636 RVA: 0x00044F13 File Offset: 0x00043113
		// (set) Token: 0x06000E35 RID: 3637 RVA: 0x00044F1B File Offset: 0x0004311B
		public Entity Entity { get; internal set; }

		// Token: 0x06000E36 RID: 3638 RVA: 0x00044F24 File Offset: 0x00043124
		internal void EnableStateChanged(bool state)
		{
			if (state)
			{
				this.OnActivate();
				return;
			}
			this.OnDeactivate();
		}

		/// <summary>
		/// Called when this component is enabled (or added to the entity)
		/// </summary>
		// Token: 0x06000E37 RID: 3639 RVA: 0x00044F36 File Offset: 0x00043136
		protected virtual void OnActivate()
		{
		}

		/// <summary>
		/// Called when this component is disabled (or removed from the entity)
		/// </summary>
		// Token: 0x06000E38 RID: 3640 RVA: 0x00044F38 File Offset: 0x00043138
		protected virtual void OnDeactivate()
		{
		}

		/// <summary>
		/// Return false if can't be added to this entity for some reason
		/// </summary>
		// Token: 0x06000E39 RID: 3641 RVA: 0x00044F3A File Offset: 0x0004313A
		public virtual bool CanAddToEntity(Entity entity)
		{
			return true;
		}

		/// <summary>
		/// Remove this component from the parent entity. Entity will become null immediately,
		/// so don't try to access it after calling this!
		/// </summary>
		// Token: 0x06000E3A RID: 3642 RVA: 0x00044F3D File Offset: 0x0004313D
		public void Remove()
		{
			if (!this.Entity.IsValid())
			{
				return;
			}
			this.Entity.Components.Remove(this);
		}

		// Token: 0x06000E3B RID: 3643 RVA: 0x00044F5F File Offset: 0x0004315F
		public override void BuildNetworkTable(NetworkTable table)
		{
			base.BuildNetworkTable(table);
			table.Register<VarUnmanaged<bool>>(ref this._enabledNet, "Enabled", false, false);
			this._enabledNet.SetCallback<bool>(delegate(bool oldval, bool newval)
			{
				Entity entity = this.Entity;
				if (entity == null)
				{
					return;
				}
				entity.OnComponentEnableStateChangedInternal(this, newval);
			});
		}

		// Token: 0x0400020B RID: 523
		private VarUnmanaged<bool> _enabledNet = new VarUnmanaged<bool>(true);
	}
}
