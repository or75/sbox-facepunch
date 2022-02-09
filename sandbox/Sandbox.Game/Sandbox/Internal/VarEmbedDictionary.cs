using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Sandbox.Internal
{
	// Token: 0x02000187 RID: 391
	public abstract class VarEmbedDictionary<TKey, TVal> : VarContainer where TVal : LibraryClass, INetworkTable
	{
		// Token: 0x06001C20 RID: 7200 RVA: 0x00070B36 File Offset: 0x0006ED36
		public VarEmbedDictionary(Dictionary<TKey, TVal> defaultValue = null)
		{
			if (Host.IsServer)
			{
				this.Value.CollectionChanged += this.Value_CollectionChanged;
			}
		}

		// Token: 0x06001C21 RID: 7201 RVA: 0x00070B68 File Offset: 0x0006ED68
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
				this.ServerValues = new Dictionary<TVal, VarClass<TVal>>();
			}
			if (e.Action == NotifyCollectionChangedAction.Reset)
			{
				foreach (KeyValuePair<TVal, VarClass<TVal>> items in this.ServerValues)
				{
					items.Value.Release();
				}
				this.ServerValues.Clear();
				this.Build();
				this.SetDirty(false);
				return;
			}
			if (e.NewItems != null)
			{
				this.ItemsAdded(e.NewItems);
			}
			if (e.OldItems != null)
			{
				this.ItemsRemoved(e.OldItems);
			}
			this.SetDirty(false);
		}

		// Token: 0x06001C22 RID: 7202 RVA: 0x00070C38 File Offset: 0x0006EE38
		private void ItemsAdded(IList items)
		{
			if (items == null)
			{
				return;
			}
			foreach (object obj in items)
			{
				KeyValuePair<TKey, TVal> item = (KeyValuePair<TKey, TVal>)obj;
				VarClass<TVal> var = new VarClass<TVal>();
				base.AddVariable(var, null);
				var.SetValue(item.Value);
				this.ServerValues[item.Value] = var;
			}
		}

		// Token: 0x06001C23 RID: 7203 RVA: 0x00070CC4 File Offset: 0x0006EEC4
		private void ItemsRemoved(IList items)
		{
			if (items == null)
			{
				return;
			}
			foreach (object obj in items)
			{
				KeyValuePair<TKey, TVal> item = (KeyValuePair<TKey, TVal>)obj;
				VarClass<TVal> var;
				if (this.ServerValues.TryGetValue(item.Value, out var))
				{
					this.ServerValues.Remove(item.Value);
					var.Release();
				}
			}
		}

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x06001C24 RID: 7204 RVA: 0x00070D44 File Offset: 0x0006EF44
		private Entity Entity
		{
			get
			{
				return this.NetworkTable.Entity;
			}
		}

		// Token: 0x06001C25 RID: 7205 RVA: 0x00070D51 File Offset: 0x0006EF51
		public IDictionary<TKey, TVal> GetValue()
		{
			return this.Value;
		}

		// Token: 0x06001C26 RID: 7206 RVA: 0x00070D5C File Offset: 0x0006EF5C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 3);
			defaultInterpolatedStringHandler.AppendLiteral("VarEmbedDictionary<");
			defaultInterpolatedStringHandler.AppendFormatted<Type>(typeof(TKey));
			defaultInterpolatedStringHandler.AppendLiteral(", ");
			defaultInterpolatedStringHandler.AppendFormatted<Type>(typeof(TVal));
			defaultInterpolatedStringHandler.AppendLiteral(">(");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Value.Count);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06001C27 RID: 7207 RVA: 0x00070DE0 File Offset: 0x0006EFE0
		public void SetValue(IDictionary<TKey, TVal> val)
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
			foreach (KeyValuePair<TKey, TVal> v in val)
			{
				this.Value.Add(v);
			}
		}

		// Token: 0x06001C28 RID: 7208 RVA: 0x00070E48 File Offset: 0x0006F048
		internal override void Write()
		{
			if (Host.IsClient)
			{
				return;
			}
			ObservableDictionary<TKey, TVal> value = this.Value;
			if (value == null || value.Count == 0)
			{
				base.NetWrite<int>(0);
				return;
			}
			base.Write();
		}

		// Token: 0x06001C29 RID: 7209 RVA: 0x00070E74 File Offset: 0x0006F074
		internal override void Write(NetWrite write)
		{
			write.Write<int>(this.ServerValues.Count);
			foreach (KeyValuePair<TVal, VarClass<TVal>> c in this.ServerValues)
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
			write.Write<int>(this.Value.Count);
			foreach (KeyValuePair<TKey, TVal> c2 in this.Value)
			{
				write.Write<TKey>(c2.Key);
				write.Write<int>(this.ServerValues[c2.Value].Index);
			}
		}

		// Token: 0x06001C2A RID: 7210
		internal abstract TKey ReadKey(ref NetRead read);

		// Token: 0x06001C2B RID: 7211
		internal abstract void WriteKey(NetWrite write, TKey element);

		// Token: 0x06001C2C RID: 7212 RVA: 0x00070F98 File Offset: 0x0006F198
		internal override void Read(NetRead read)
		{
			base.ReadVariables(ref read);
			int count = read.TryRead<int>();
			this.Value.Clear();
			for (int i = 0; i < count; i++)
			{
				TKey varKey = this.ReadKey(ref read);
				int valueSlot = read.Read<int>();
				Var var = this.Variables.FirstOrDefault((Var x) => x.Index == valueSlot);
				if (var == null)
				{
					GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Can't find {0} : {1}", new object[] { varKey, valueSlot }));
				}
				else
				{
					this.Value[varKey] = (var as VarClass<TVal>).GetValue();
				}
			}
		}

		// Token: 0x06001C2D RID: 7213 RVA: 0x00071058 File Offset: 0x0006F258
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
				this.ServerValues = new Dictionary<TVal, VarClass<TVal>>();
			}
			foreach (KeyValuePair<TKey, TVal> item in this.Value)
			{
				VarClass<TVal> var = new VarClass<TVal>();
				base.AddVariable(var, null);
				var.SetValue(item.Value);
				this.ServerValues[item.Value] = var;
			}
		}

		/// <summary>
		/// Create the right type of variable
		/// </summary>
		// Token: 0x06001C2E RID: 7214 RVA: 0x00071110 File Offset: 0x0006F310
		protected override Var CreateVariableFromSlot(int location)
		{
			return new VarClass<TVal>();
		}

		/// <summary>
		/// A variable has been added. The slot is right. We can read it here and do stuff with the result.
		/// </summary>
		// Token: 0x06001C2F RID: 7215 RVA: 0x00071117 File Offset: 0x0006F317
		protected override void OnVariableAdded(Var var)
		{
			if (!Host.IsClient)
			{
				return;
			}
			VarClass<TVal> varClass = var as VarClass<TVal>;
			if (varClass == null)
			{
				throw new Exception("Network Error!");
			}
			varClass.Read();
		}

		// Token: 0x040007A0 RID: 1952
		public ObservableDictionary<TKey, TVal> Value = new ObservableDictionary<TKey, TVal>();

		// Token: 0x040007A1 RID: 1953
		public Dictionary<TVal, VarClass<TVal>> ServerValues;
	}
}
