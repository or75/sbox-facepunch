using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sandbox.Internal
{
	// Token: 0x0200017C RID: 380
	internal sealed class VarComponentList : VarContainer
	{
		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x06001BBF RID: 7103 RVA: 0x0006FA37 File Offset: 0x0006DC37
		private Entity Entity
		{
			get
			{
				return this.NetworkTable.Entity;
			}
		}

		// Token: 0x06001BC0 RID: 7104 RVA: 0x0006FA44 File Offset: 0x0006DC44
		public override string ToString()
		{
			return "VarComponentList";
		}

		// Token: 0x06001BC1 RID: 7105 RVA: 0x0006FA4B File Offset: 0x0006DC4B
		internal override void Write()
		{
			Dictionary<EntityComponent, VarComponent> components = this.Components;
			if (components == null || components.Count == 0)
			{
				base.NetWrite<int>(0);
				return;
			}
			base.Write();
		}

		// Token: 0x06001BC2 RID: 7106 RVA: 0x0006FA70 File Offset: 0x0006DC70
		internal void Add(EntityComponent c)
		{
			Host.AssertServer("Add");
			if (this.Components == null)
			{
				this.Components = new Dictionary<EntityComponent, VarComponent>();
			}
			VarComponent var = new VarComponent();
			base.AddVariable(var, null);
			var.SetValue(c);
			this.Components[c] = var;
			this.SetDirty(false);
		}

		// Token: 0x06001BC3 RID: 7107 RVA: 0x0006FACC File Offset: 0x0006DCCC
		internal void Remove(EntityComponent c)
		{
			Host.AssertServer("Remove");
			if (this.Components == null)
			{
				throw new Exception("Trying to remove component - but we don't have any");
			}
			VarComponent v;
			if (this.Components.TryGetValue(c, out v))
			{
				this.Components.Remove(c);
				v.Release();
			}
			this.SetDirty(false);
		}

		// Token: 0x06001BC4 RID: 7108 RVA: 0x0006FB20 File Offset: 0x0006DD20
		internal override void Build()
		{
			if (!Host.IsServer)
			{
				return;
			}
			List<EntityComponent> components = this.Entity._components;
			if (components == null || components.Count == 0)
			{
				return;
			}
			base.Build();
			if (this.Components == null)
			{
				this.Components = new Dictionary<EntityComponent, VarComponent>();
			}
			foreach (EntityComponent c in this.Entity._components)
			{
				VarComponent var = new VarComponent();
				base.AddVariable(var, null);
				var.SetValue(c);
				this.Components[c] = var;
			}
		}

		// Token: 0x06001BC5 RID: 7109 RVA: 0x0006FBD8 File Offset: 0x0006DDD8
		internal override void Write(NetWrite write)
		{
			write.Write<int>(this.Components.Count);
			foreach (KeyValuePair<EntityComponent, VarComponent> c in this.Components)
			{
				if (c.Value.Index <= 0)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 1);
					defaultInterpolatedStringHandler.AppendLiteral("c.NetworkVariable.Index is ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(c.Value.Index);
					throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				write.Write<int>(c.Value.Index);
			}
		}

		/// <summary>
		/// Create the right type of variable
		/// </summary>
		// Token: 0x06001BC6 RID: 7110 RVA: 0x0006FC8C File Offset: 0x0006DE8C
		protected override Var CreateVariableFromSlot(int location)
		{
			return new VarComponent();
		}

		/// <summary>
		/// A variable has been added. The slot is right. We can read it here and do stuff with the result.
		/// </summary>
		// Token: 0x06001BC7 RID: 7111 RVA: 0x0006FC94 File Offset: 0x0006DE94
		protected override void OnVariableAdded(Var var)
		{
			if (!Host.IsClient)
			{
				return;
			}
			VarComponent varComponent = var as VarComponent;
			if (varComponent == null)
			{
				throw new Exception("Network Error!");
			}
			varComponent.Read();
			EntityComponent component = varComponent.GetValue();
			this.Entity.Components.Add<EntityComponent>(component);
		}

		/// <summary>
		/// A variable has been removed. We can get the value here and do stuff with the result.
		/// </summary>
		// Token: 0x06001BC8 RID: 7112 RVA: 0x0006FCDC File Offset: 0x0006DEDC
		protected override void OnVariableRemoved(Var var)
		{
			if (!Host.IsClient)
			{
				return;
			}
			VarComponent varComponent = var as VarComponent;
			if (varComponent == null)
			{
				throw new Exception("Network Error!");
			}
			EntityComponent component = varComponent.GetValue();
			if (component == null)
			{
				return;
			}
			this.Entity.Components.Remove(component);
		}

		// Token: 0x04000798 RID: 1944
		public Dictionary<EntityComponent, VarComponent> Components;
	}
}
