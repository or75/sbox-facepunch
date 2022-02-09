using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x02000005 RID: 5
internal class OrderedSet<T> : ICollection<T>, IEnumerable<T>, IEnumerable
{
	// Token: 0x06000005 RID: 5 RVA: 0x0000208E File Offset: 0x0000028E
	public OrderedSet()
		: this(EqualityComparer<T>.Default)
	{
	}

	// Token: 0x06000006 RID: 6 RVA: 0x0000209B File Offset: 0x0000029B
	public OrderedSet(IEqualityComparer<T> comparer)
	{
		this._dictionary = new Dictionary<T, LinkedListNode<T>>(comparer);
		this._linkedList = new LinkedList<T>();
	}

	// Token: 0x06000007 RID: 7 RVA: 0x000020BC File Offset: 0x000002BC
	public OrderedSet(IEnumerable<T> items)
		: this()
	{
		foreach (T item in items)
		{
			this.Add(item);
		}
	}

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000008 RID: 8 RVA: 0x0000210C File Offset: 0x0000030C
	public int Count
	{
		get
		{
			return this._dictionary.Count;
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000009 RID: 9 RVA: 0x00002119 File Offset: 0x00000319
	public virtual bool IsReadOnly
	{
		get
		{
			return this._dictionary.IsReadOnly;
		}
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00002126 File Offset: 0x00000326
	void ICollection<!0>.Add(T item)
	{
		this.Add(item);
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00002130 File Offset: 0x00000330
	public bool Add(T item)
	{
		if (this._dictionary.ContainsKey(item))
		{
			return false;
		}
		LinkedListNode<T> node = this._linkedList.AddLast(item);
		this._dictionary.Add(item, node);
		return true;
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00002168 File Offset: 0x00000368
	public void Clear()
	{
		this._linkedList.Clear();
		this._dictionary.Clear();
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00002180 File Offset: 0x00000380
	public bool Remove(T item)
	{
		LinkedListNode<T> node;
		if (!this._dictionary.TryGetValue(item, out node))
		{
			return false;
		}
		this._dictionary.Remove(item);
		this._linkedList.Remove(node);
		return true;
	}

	// Token: 0x0600000E RID: 14 RVA: 0x000021B9 File Offset: 0x000003B9
	public IEnumerator<T> GetEnumerator()
	{
		return this._linkedList.GetEnumerator();
	}

	// Token: 0x0600000F RID: 15 RVA: 0x000021CB File Offset: 0x000003CB
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	// Token: 0x06000010 RID: 16 RVA: 0x000021D3 File Offset: 0x000003D3
	public bool Contains(T item)
	{
		return this._dictionary.ContainsKey(item);
	}

	// Token: 0x06000011 RID: 17 RVA: 0x000021E1 File Offset: 0x000003E1
	public void CopyTo(T[] array, int arrayIndex)
	{
		this._linkedList.CopyTo(array, arrayIndex);
	}

	// Token: 0x04000003 RID: 3
	private readonly IDictionary<T, LinkedListNode<T>> _dictionary;

	// Token: 0x04000004 RID: 4
	private readonly LinkedList<T> _linkedList;
}
