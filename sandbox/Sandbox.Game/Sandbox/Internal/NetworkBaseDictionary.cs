using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace Sandbox.Internal
{
	// Token: 0x0200017F RID: 383
	public abstract class NetworkBaseDictionary<T, U> : Var
	{
		// Token: 0x06001BE4 RID: 7140 RVA: 0x00070459 File Offset: 0x0006E659
		public NetworkBaseDictionary(Dictionary<T, U> defaultValue = null)
		{
			if (Host.IsServer)
			{
				this.Value.CollectionChanged += this.Value_CollectionChanged;
			}
		}

		// Token: 0x06001BE5 RID: 7141 RVA: 0x0007048A File Offset: 0x0006E68A
		private void Value_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (Host.IsClient)
			{
				return;
			}
			if (e.NewItems != null)
			{
				this.OnItemsAdded(e.NewItems);
			}
			if (e.OldItems != null)
			{
				this.OnItemsRemoved(e.OldItems);
			}
			this.SetDirty(false);
		}

		// Token: 0x06001BE6 RID: 7142 RVA: 0x000704C3 File Offset: 0x0006E6C3
		protected virtual void OnItemsAdded(IList items)
		{
		}

		// Token: 0x06001BE7 RID: 7143 RVA: 0x000704C5 File Offset: 0x0006E6C5
		protected virtual void OnItemsRemoved(IList items)
		{
		}

		// Token: 0x06001BE8 RID: 7144 RVA: 0x000704C7 File Offset: 0x0006E6C7
		public IDictionary<T, U> GetValue()
		{
			return this.Value;
		}

		// Token: 0x06001BE9 RID: 7145 RVA: 0x000704D0 File Offset: 0x0006E6D0
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Dictionary<");
			defaultInterpolatedStringHandler.AppendFormatted<Type>(typeof(T));
			defaultInterpolatedStringHandler.AppendLiteral(">(");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Value.Count);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06001BEA RID: 7146 RVA: 0x00070538 File Offset: 0x0006E738
		public void SetValue(IDictionary<T, U> val)
		{
			if (!base.CanChangeValue())
			{
				return;
			}
			this.Value.Clear();
			if (val == null)
			{
				return;
			}
			foreach (KeyValuePair<T, U> v in val)
			{
				this.Value.Add(v);
			}
		}

		// Token: 0x06001BEB RID: 7147
		internal abstract T ReadKey(ref NetRead read);

		// Token: 0x06001BEC RID: 7148
		internal abstract U ReadValue(ref NetRead read);

		// Token: 0x06001BED RID: 7149
		internal abstract void WriteKey(NetWrite write, T element);

		// Token: 0x06001BEE RID: 7150
		internal abstract void WriteValue(NetWrite write, U element);

		// Token: 0x06001BEF RID: 7151 RVA: 0x000705A0 File Offset: 0x0006E7A0
		internal override void Write()
		{
			if (Host.IsClient)
			{
				return;
			}
			if (this.Value == null)
			{
				base.NetWrite<int>(0);
				return;
			}
			using (NetWrite writer = new NetWrite())
			{
				writer.Write<int>(this.Value.Count);
				foreach (KeyValuePair<T, U> c in this.Value)
				{
					this.WriteKey(writer, c.Key);
					this.WriteValue(writer, c.Value);
				}
				this.NetworkTable.Write(this, writer);
			}
		}

		// Token: 0x06001BF0 RID: 7152 RVA: 0x00070658 File Offset: 0x0006E858
		internal override void Read(NetRead read)
		{
			int count = read.TryRead<int>();
			bool hasChanged = false;
			if (this.Value.Count == count)
			{
				for (int i = 0; i < count; i++)
				{
					T varKey = this.ReadKey(ref read);
					U varValue = this.ReadValue(ref read);
					this.Value[varKey] = varValue;
					hasChanged = true;
				}
			}
			else
			{
				hasChanged = true;
				this.Value.Clear();
				for (int j = 0; j < count; j++)
				{
					T varKey2 = this.ReadKey(ref read);
					U varValue2 = this.ReadValue(ref read);
					this.Value[varKey2] = varValue2;
					hasChanged = true;
				}
			}
			if (hasChanged)
			{
				base.OnChanged(this.Value, this.Value);
			}
		}

		// Token: 0x0400079E RID: 1950
		public ObservableDictionary<T, U> Value = new ObservableDictionary<T, U>();
	}
}
