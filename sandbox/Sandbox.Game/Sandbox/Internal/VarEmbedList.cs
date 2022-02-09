using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace Sandbox.Internal
{
	/// <summary>
	/// A list of anything readable/writable with NetRead/NetWrite
	/// </summary>
	// Token: 0x0200017E RID: 382
	public sealed class VarEmbedList<T> : VarContainer where T : LibraryClass, INetworkTable
	{
		// Token: 0x06001BD5 RID: 7125 RVA: 0x0006FF53 File Offset: 0x0006E153
		public VarEmbedList()
			: this(null)
		{
		}

		// Token: 0x06001BD6 RID: 7126 RVA: 0x0006FF5C File Offset: 0x0006E15C
		public VarEmbedList(List<T> defaultValue = null)
		{
			if (Host.IsServer)
			{
				this.Value.CollectionChanged += this.Value_CollectionChanged;
			}
		}

		// Token: 0x06001BD7 RID: 7127 RVA: 0x0006FF90 File Offset: 0x0006E190
		private void Value_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (Host.IsClient)
			{
				return;
			}
			if (this.NetworkTable == null)
			{
				return;
			}
			if (this.ServerValues == null)
			{
				this.ServerValues = new Dictionary<T, VarClass<T>>();
			}
			if (e.Action == NotifyCollectionChangedAction.Reset)
			{
				foreach (KeyValuePair<T, VarClass<T>> items in this.ServerValues)
				{
					items.Value.Release();
				}
				this.ServerValues.Clear();
				this.Build();
				this.SetDirty(false);
				return;
			}
			this.ItemsAdded(e.NewItems);
			this.ItemsRemoved(e.OldItems);
			this.SetDirty(false);
		}

		// Token: 0x06001BD8 RID: 7128 RVA: 0x00070050 File Offset: 0x0006E250
		private void ItemsAdded(IList items)
		{
			if (items == null)
			{
				return;
			}
			foreach (object obj in items)
			{
				T item = (T)((object)obj);
				if (item is Entity)
				{
					throw new Exception("Trying to send entity as a BaseNetworkable");
				}
				VarClass<T> var = new VarClass<T>();
				base.AddVariable(var, null);
				var.SetValue(item);
				this.ServerValues[item] = var;
			}
		}

		// Token: 0x06001BD9 RID: 7129 RVA: 0x000700E8 File Offset: 0x0006E2E8
		private void ItemsRemoved(IList items)
		{
			if (items == null)
			{
				return;
			}
			foreach (object obj in items)
			{
				T item = (T)((object)obj);
				VarClass<T> var;
				if (this.ServerValues.TryGetValue(item, out var))
				{
					this.ServerValues.Remove(item);
					var.Release();
				}
			}
		}

		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x06001BDA RID: 7130 RVA: 0x0007015C File Offset: 0x0006E35C
		private Entity Entity
		{
			get
			{
				return this.NetworkTable.Entity;
			}
		}

		// Token: 0x06001BDB RID: 7131 RVA: 0x00070169 File Offset: 0x0006E369
		public IList<T> GetValue()
		{
			return this.Value;
		}

		// Token: 0x06001BDC RID: 7132 RVA: 0x00070174 File Offset: 0x0006E374
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
			defaultInterpolatedStringHandler.AppendLiteral("VarEmbedList<");
			defaultInterpolatedStringHandler.AppendFormatted<Type>(typeof(T));
			defaultInterpolatedStringHandler.AppendLiteral(">(");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Value.Count);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06001BDD RID: 7133 RVA: 0x000701DC File Offset: 0x0006E3DC
		public void SetValue(IList<T> val)
		{
			if (!base.CanChangeValue())
			{
				return;
			}
			if (val == null)
			{
				return;
			}
			this.Value.Clear();
			foreach (T v in val)
			{
				this.Value.Add(v);
			}
		}

		// Token: 0x06001BDE RID: 7134 RVA: 0x00070244 File Offset: 0x0006E444
		internal override void Write()
		{
			Dictionary<T, VarClass<T>> serverValues = this.ServerValues;
			if (serverValues == null || serverValues.Count == 0)
			{
				base.NetWrite<int>(0);
				return;
			}
			base.Write();
		}

		// Token: 0x06001BDF RID: 7135 RVA: 0x00070268 File Offset: 0x0006E468
		internal override void Write(NetWrite write)
		{
			write.Write<int>(this.ServerValues.Count);
			foreach (KeyValuePair<T, VarClass<T>> c in this.ServerValues)
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

		// Token: 0x06001BE0 RID: 7136 RVA: 0x0007031C File Offset: 0x0006E51C
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
			if (this.ServerValues == null)
			{
				this.ServerValues = new Dictionary<T, VarClass<T>>();
			}
			foreach (T item in this.Value)
			{
				VarClass<T> var = new VarClass<T>();
				base.AddVariable(var, null);
				var.SetValue(item);
				this.ServerValues[item] = var;
			}
		}

		/// <summary>
		/// Create the right type of variable
		/// </summary>
		// Token: 0x06001BE1 RID: 7137 RVA: 0x000703C8 File Offset: 0x0006E5C8
		protected override Var CreateVariableFromSlot(int location)
		{
			return new VarClass<T>();
		}

		/// <summary>
		/// A variable has been added. The slot is right. We can read it here and do stuff with the result.
		/// </summary>
		// Token: 0x06001BE2 RID: 7138 RVA: 0x000703D0 File Offset: 0x0006E5D0
		protected override void OnVariableAdded(Var var)
		{
			if (!Host.IsClient)
			{
				return;
			}
			VarClass<T> varClass = var as VarClass<T>;
			if (varClass == null)
			{
				throw new Exception("Network Error!");
			}
			varClass.Read();
			T component = varClass.GetValue();
			this.Value.Add(component);
		}

		/// <summary>
		/// A variable has been removed. We can get the value here and do stuff with the result.
		/// </summary>
		// Token: 0x06001BE3 RID: 7139 RVA: 0x00070414 File Offset: 0x0006E614
		protected override void OnVariableRemoved(Var var)
		{
			if (!Host.IsClient)
			{
				return;
			}
			VarClass<T> varClass = var as VarClass<T>;
			if (varClass == null)
			{
				throw new Exception("Network Error!");
			}
			T component = varClass.GetValue();
			if (component == null)
			{
				return;
			}
			this.Value.Remove(component);
		}

		// Token: 0x0400079C RID: 1948
		public ObservableCollection<T> Value = new ObservableCollection<T>();

		// Token: 0x0400079D RID: 1949
		public Dictionary<T, VarClass<T>> ServerValues;
	}
}
