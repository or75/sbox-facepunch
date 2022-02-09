using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.Internal
{
	/// <summary>
	/// A network variable that points to a bunch of other variables
	/// </summary>
	// Token: 0x0200017D RID: 381
	public abstract class VarContainer : Var
	{
		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x06001BCA RID: 7114 RVA: 0x0006FD29 File Offset: 0x0006DF29
		protected int VariableCount
		{
			get
			{
				List<Var> variables = this.Variables;
				if (variables == null)
				{
					return 0;
				}
				return variables.Count;
			}
		}

		// Token: 0x06001BCB RID: 7115 RVA: 0x0006FD3C File Offset: 0x0006DF3C
		protected void ReleaseVariables()
		{
			if (this.Variables == null)
			{
				return;
			}
			foreach (Var var in this.Variables)
			{
				this.OnVariableRemoved(var);
				var.Release();
			}
			this.Variables.Clear();
			this.NeedsRebuild = true;
		}

		// Token: 0x06001BCC RID: 7116 RVA: 0x0006FDB0 File Offset: 0x0006DFB0
		internal override void SetLocation(NetworkTable table, int i)
		{
			base.SetLocation(table, i);
			this.NeedsRebuild = true;
		}

		// Token: 0x06001BCD RID: 7117 RVA: 0x0006FDC1 File Offset: 0x0006DFC1
		internal override void Release()
		{
			this.ReleaseVariables();
			base.Release();
		}

		// Token: 0x06001BCE RID: 7118 RVA: 0x0006FDCF File Offset: 0x0006DFCF
		protected void AddVariable(Var var, int? location)
		{
			if (this.Variables == null)
			{
				this.Variables = new List<Var>();
			}
			this.Variables.Add(var);
			this.NetworkTable.AddVariable(var, location);
			this.OnVariableAdded(var);
		}

		// Token: 0x06001BCF RID: 7119 RVA: 0x0006FE04 File Offset: 0x0006E004
		protected virtual void OnVariableAdded(Var var)
		{
		}

		// Token: 0x06001BD0 RID: 7120 RVA: 0x0006FE06 File Offset: 0x0006E006
		protected virtual void OnVariableRemoved(Var var)
		{
		}

		// Token: 0x06001BD1 RID: 7121 RVA: 0x0006FE08 File Offset: 0x0006E008
		protected virtual Var CreateVariableFromSlot(int location)
		{
			return null;
		}

		// Token: 0x06001BD2 RID: 7122 RVA: 0x0006FE0B File Offset: 0x0006E00B
		internal override void Read(NetRead read)
		{
			this.ReadVariables(ref read);
		}

		// Token: 0x06001BD3 RID: 7123 RVA: 0x0006FE18 File Offset: 0x0006E018
		protected void ReadVariables(ref NetRead read)
		{
			int c = read.TryRead<int>();
			if (c == 0)
			{
				this.ReleaseVariables();
				return;
			}
			if (this.ValidEntries == null)
			{
				this.ValidEntries = new List<Var>();
			}
			if (this.Variables == null)
			{
				this.Variables = new List<Var>();
			}
			this.ValidEntries.Clear();
			this.ValidEntries.AddRange(this.Variables);
			for (int i = 0; i < c; i++)
			{
				int slot = read.Read<int>();
				Var v = this.Variables.FirstOrDefault((Var x) => x.Index == slot);
				if (v == null)
				{
					v = this.CreateVariableFromSlot(slot);
					this.AddVariable(v, new int?(slot));
				}
				v.Read();
				this.ValidEntries.Remove(v);
			}
			foreach (Var var in this.ValidEntries)
			{
				this.OnVariableRemoved(var);
				var.Release();
				this.Variables.Remove(var);
			}
		}

		// Token: 0x04000799 RID: 1945
		protected List<Var> Variables;

		// Token: 0x0400079A RID: 1946
		protected bool NeedsRebuild = true;

		// Token: 0x0400079B RID: 1947
		private List<Var> ValidEntries;
	}
}
