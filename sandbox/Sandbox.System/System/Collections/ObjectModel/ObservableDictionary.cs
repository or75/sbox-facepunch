using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace System.Collections.ObjectModel
{
	// Token: 0x02000028 RID: 40
	public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged
	{
		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000264 RID: 612 RVA: 0x0000AA7C File Offset: 0x00008C7C
		protected IDictionary<TKey, TValue> Dictionary
		{
			get
			{
				return this._Dictionary;
			}
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000AA84 File Offset: 0x00008C84
		public ObservableDictionary()
		{
			this._Dictionary = new Dictionary<TKey, TValue>();
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000AA97 File Offset: 0x00008C97
		public ObservableDictionary(IDictionary<TKey, TValue> dictionary)
		{
			this._Dictionary = new Dictionary<TKey, TValue>(dictionary);
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000AAAB File Offset: 0x00008CAB
		public ObservableDictionary(IEqualityComparer<TKey> comparer)
		{
			this._Dictionary = new Dictionary<TKey, TValue>(comparer);
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000AABF File Offset: 0x00008CBF
		public ObservableDictionary(int capacity)
		{
			this._Dictionary = new Dictionary<TKey, TValue>(capacity);
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000AAD3 File Offset: 0x00008CD3
		public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		{
			this._Dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0000AAE8 File Offset: 0x00008CE8
		public ObservableDictionary(int capacity, IEqualityComparer<TKey> comparer)
		{
			this._Dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000AAFD File Offset: 0x00008CFD
		public void Add(TKey key, TValue value)
		{
			this.Insert(key, value, true);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000AB08 File Offset: 0x00008D08
		public bool ContainsKey(TKey key)
		{
			return this.Dictionary.ContainsKey(key);
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600026D RID: 621 RVA: 0x0000AB16 File Offset: 0x00008D16
		public ICollection<TKey> Keys
		{
			get
			{
				return this.Dictionary.Keys;
			}
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000AB24 File Offset: 0x00008D24
		public bool Remove(TKey key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			TValue value;
			this.Dictionary.TryGetValue(key, out value);
			bool flag = this.Dictionary.Remove(key);
			if (flag)
			{
				this.OnCollectionChanged();
			}
			return flag;
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000AB68 File Offset: 0x00008D68
		public bool TryGetValue(TKey key, out TValue value)
		{
			return this.Dictionary.TryGetValue(key, out value);
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000270 RID: 624 RVA: 0x0000AB77 File Offset: 0x00008D77
		public ICollection<TValue> Values
		{
			get
			{
				return this.Dictionary.Values;
			}
		}

		// Token: 0x1700007B RID: 123
		public TValue this[TKey key]
		{
			get
			{
				return this.Dictionary[key];
			}
			set
			{
				this.Insert(key, value, false);
			}
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000AB9D File Offset: 0x00008D9D
		public void Add(KeyValuePair<TKey, TValue> item)
		{
			this.Insert(item.Key, item.Value, true);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000ABB4 File Offset: 0x00008DB4
		public void Clear()
		{
			if (this.Dictionary.Count > 0)
			{
				this.Dictionary.Clear();
				this.OnCollectionChanged();
			}
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000ABD5 File Offset: 0x00008DD5
		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return this.Dictionary.Contains(item);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000ABE3 File Offset: 0x00008DE3
		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			this.Dictionary.CopyTo(array, arrayIndex);
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000277 RID: 631 RVA: 0x0000ABF2 File Offset: 0x00008DF2
		public int Count
		{
			get
			{
				return this.Dictionary.Count;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000278 RID: 632 RVA: 0x0000ABFF File Offset: 0x00008DFF
		public bool IsReadOnly
		{
			get
			{
				return this.Dictionary.IsReadOnly;
			}
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000AC0C File Offset: 0x00008E0C
		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return this.Remove(item.Key);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000AC1B File Offset: 0x00008E1B
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return this.Dictionary.GetEnumerator();
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000AC28 File Offset: 0x00008E28
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.Dictionary.GetEnumerator();
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600027C RID: 636 RVA: 0x0000AC38 File Offset: 0x00008E38
		// (remove) Token: 0x0600027D RID: 637 RVA: 0x0000AC70 File Offset: 0x00008E70
		public event NotifyCollectionChangedEventHandler CollectionChanged;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600027E RID: 638 RVA: 0x0000ACA8 File Offset: 0x00008EA8
		// (remove) Token: 0x0600027F RID: 639 RVA: 0x0000ACE0 File Offset: 0x00008EE0
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x06000280 RID: 640 RVA: 0x0000AD18 File Offset: 0x00008F18
		public void AddRange(IDictionary<TKey, TValue> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			if (items.Count > 0)
			{
				if (this.Dictionary.Count > 0)
				{
					if (items.Keys.Any((TKey k) => this.Dictionary.ContainsKey(k)))
					{
						throw new ArgumentException("An item with the same key has already been added.");
					}
					using (IEnumerator<KeyValuePair<TKey, TValue>> enumerator = items.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							KeyValuePair<TKey, TValue> item = enumerator.Current;
							this.Dictionary.Add(item);
						}
						goto IL_85;
					}
				}
				this._Dictionary = new Dictionary<TKey, TValue>(items);
				IL_85:
				this.OnCollectionChanged(NotifyCollectionChangedAction.Add, items.ToArray<KeyValuePair<TKey, TValue>>());
			}
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000ADC8 File Offset: 0x00008FC8
		private void Insert(TKey key, TValue value, bool add)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			TValue item;
			if (!this.Dictionary.TryGetValue(key, out item))
			{
				this.Dictionary[key] = value;
				this.OnCollectionChanged(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value));
				return;
			}
			if (add)
			{
				throw new ArgumentException("An item with the same key has already been added.");
			}
			if (object.Equals(item, value))
			{
				return;
			}
			this.Dictionary[key] = value;
			this.OnCollectionChanged(NotifyCollectionChangedAction.Replace, new KeyValuePair<TKey, TValue>(key, value), new KeyValuePair<TKey, TValue>(key, item));
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000AE58 File Offset: 0x00009058
		private void OnPropertyChanged()
		{
			this.OnPropertyChanged("Count");
			this.OnPropertyChanged("Item[]");
			this.OnPropertyChanged("Keys");
			this.OnPropertyChanged("Values");
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000AE86 File Offset: 0x00009086
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000AEA2 File Offset: 0x000090A2
		private void OnCollectionChanged()
		{
			this.OnPropertyChanged();
			if (this.CollectionChanged != null)
			{
				this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
			}
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000AEC4 File Offset: 0x000090C4
		private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> changedItem)
		{
			this.OnPropertyChanged();
			if (this.CollectionChanged != null)
			{
				this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, changedItem));
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000AEEC File Offset: 0x000090EC
		private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> newItem, KeyValuePair<TKey, TValue> oldItem)
		{
			this.OnPropertyChanged();
			if (this.CollectionChanged != null)
			{
				this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, newItem, oldItem));
			}
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000AF1A File Offset: 0x0000911A
		private void OnCollectionChanged(NotifyCollectionChangedAction action, IList newItems)
		{
			this.OnPropertyChanged();
			if (this.CollectionChanged != null)
			{
				this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, newItems));
			}
		}

		// Token: 0x0400007F RID: 127
		private const string CountString = "Count";

		// Token: 0x04000080 RID: 128
		private const string IndexerName = "Item[]";

		// Token: 0x04000081 RID: 129
		private const string KeysName = "Keys";

		// Token: 0x04000082 RID: 130
		private const string ValuesName = "Values";

		// Token: 0x04000083 RID: 131
		private IDictionary<TKey, TValue> _Dictionary;
	}
}
