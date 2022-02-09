using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace Sandbox.Internal
{
	// Token: 0x02000180 RID: 384
	public abstract class NetworkBaseList<T> : Var
	{
		// Token: 0x06001BF1 RID: 7153 RVA: 0x00070705 File Offset: 0x0006E905
		public NetworkBaseList(List<T> defaultValue = null)
		{
			if (Host.IsServer)
			{
				this.Value.CollectionChanged += this.Value_CollectionChanged;
			}
		}

		// Token: 0x06001BF2 RID: 7154 RVA: 0x00070736 File Offset: 0x0006E936
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

		// Token: 0x06001BF3 RID: 7155 RVA: 0x0007076F File Offset: 0x0006E96F
		protected virtual void OnItemsAdded(IList items)
		{
		}

		// Token: 0x06001BF4 RID: 7156 RVA: 0x00070771 File Offset: 0x0006E971
		protected virtual void OnItemsRemoved(IList items)
		{
		}

		// Token: 0x06001BF5 RID: 7157 RVA: 0x00070773 File Offset: 0x0006E973
		public IList<T> GetValue()
		{
			return this.Value;
		}

		// Token: 0x06001BF6 RID: 7158 RVA: 0x0007077C File Offset: 0x0006E97C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 2);
			defaultInterpolatedStringHandler.AppendLiteral("List<");
			defaultInterpolatedStringHandler.AppendFormatted<Type>(typeof(T));
			defaultInterpolatedStringHandler.AppendLiteral(">(");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Value.Count);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06001BF7 RID: 7159 RVA: 0x000707E0 File Offset: 0x0006E9E0
		public void SetValue(IList<T> val)
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
			foreach (T v in val)
			{
				this.Value.Add(v);
			}
		}

		// Token: 0x06001BF8 RID: 7160
		internal abstract T ReadElement(ref NetRead read);

		// Token: 0x06001BF9 RID: 7161
		internal abstract void WriteElement(NetWrite write, T element);

		// Token: 0x06001BFA RID: 7162 RVA: 0x00070848 File Offset: 0x0006EA48
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
				foreach (T c in this.Value)
				{
					this.WriteElement(writer, c);
				}
				this.NetworkTable.Write(this, writer);
			}
		}

		// Token: 0x06001BFB RID: 7163 RVA: 0x000708EC File Offset: 0x0006EAEC
		internal override void Read(NetRead read)
		{
			int count = read.TryRead<int>();
			bool hasChanged = false;
			if (this.Value.Count == count)
			{
				for (int i = 0; i < count; i++)
				{
					T newValue = this.ReadElement(ref read);
					if (!object.Equals(this.Value[i], newValue))
					{
						this.Value[i] = newValue;
						hasChanged = true;
					}
				}
			}
			else
			{
				hasChanged = true;
				this.Value.Clear();
				for (int j = 0; j < count; j++)
				{
					this.Value.Add(this.ReadElement(ref read));
				}
			}
			if (hasChanged)
			{
				base.OnChanged(this.Value, this.Value);
			}
		}

		// Token: 0x0400079F RID: 1951
		public ObservableCollection<T> Value = new ObservableCollection<T>();
	}
}
