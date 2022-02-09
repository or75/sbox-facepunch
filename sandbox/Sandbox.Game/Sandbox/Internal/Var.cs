using System;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace Sandbox.Internal
{
	// Token: 0x0200018C RID: 396
	public abstract class Var
	{
		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06001C40 RID: 7232 RVA: 0x000711F0 File Offset: 0x0006F3F0
		// (set) Token: 0x06001C41 RID: 7233 RVA: 0x000711F8 File Offset: 0x0006F3F8
		public bool IsPredicted { get; internal set; }

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x06001C42 RID: 7234 RVA: 0x00071201 File Offset: 0x0006F401
		// (set) Token: 0x06001C43 RID: 7235 RVA: 0x00071209 File Offset: 0x0006F409
		public bool IsLocal { get; internal set; }

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x06001C44 RID: 7236 RVA: 0x00071212 File Offset: 0x0006F412
		// (set) Token: 0x06001C45 RID: 7237 RVA: 0x0007121A File Offset: 0x0006F41A
		public Action<object, object> Callback { get; internal set; }

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x06001C46 RID: 7238 RVA: 0x00071223 File Offset: 0x0006F423
		// (set) Token: 0x06001C47 RID: 7239 RVA: 0x0007122B File Offset: 0x0006F42B
		public int Index { get; set; } = -1;

		// Token: 0x06001C48 RID: 7240 RVA: 0x00071234 File Offset: 0x0006F434
		internal virtual void OnRegister(NetworkTable table, string name, bool predicted, bool local)
		{
			this.NetworkTable = table;
			this.Name = name;
			this.IsPredicted = predicted;
			this.IsLocal = local;
			this.Callback = null;
		}

		// Token: 0x06001C49 RID: 7241 RVA: 0x0007125C File Offset: 0x0006F45C
		public void SetCallback<T>(Action<T, T> callback)
		{
			this.Callback = delegate(object a, object b)
			{
				callback((T)((object)a), (T)((object)b));
			};
		}

		// Token: 0x06001C4A RID: 7242 RVA: 0x00071288 File Offset: 0x0006F488
		public void SetCallback<T>(Action<T> callback)
		{
			this.Callback = delegate(object a, object b)
			{
				callback((T)((object)b));
			};
		}

		// Token: 0x06001C4B RID: 7243 RVA: 0x000712B4 File Offset: 0x0006F4B4
		public void SetCallback<T>(Action callback)
		{
			this.Callback = delegate(object a, object b)
			{
				callback();
			};
		}

		// Token: 0x06001C4C RID: 7244 RVA: 0x000712E0 File Offset: 0x0006F4E0
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 3);
			defaultInterpolatedStringHandler.AppendFormatted<Type>(base.GetType());
			defaultInterpolatedStringHandler.AppendLiteral(" - ");
			defaultInterpolatedStringHandler.AppendFormatted(this.Name);
			defaultInterpolatedStringHandler.AppendLiteral(" / [");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Index);
			defaultInterpolatedStringHandler.AppendLiteral("]");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06001C4D RID: 7245 RVA: 0x00071348 File Offset: 0x0006F548
		internal virtual void SetLocation(NetworkTable table, int i)
		{
			this.NetworkTable = table;
			this.Index = i;
			this.SetDirty(false);
		}

		// Token: 0x06001C4E RID: 7246 RVA: 0x0007135F File Offset: 0x0006F55F
		internal virtual void Release()
		{
			NetworkTable networkTable = this.NetworkTable;
			if (networkTable != null)
			{
				networkTable.Release(this);
			}
			this.NetworkTable = null;
			this.Index = -2;
		}

		/// <summary>
		/// This is what's called when the variable is to be written to native memory.
		/// This is a single entry point so we can ignore the write is the variable is
		/// invalid, without doing these checks in other classes.
		/// </summary>
		// Token: 0x06001C4F RID: 7247 RVA: 0x00071382 File Offset: 0x0006F582
		private void DoWrite()
		{
			Host.AssertServer("DoWrite");
			if (this.NetworkTable == null)
			{
				return;
			}
			if (this.Index < 0)
			{
				return;
			}
			this.IsDirty = false;
			this.Write();
		}

		// Token: 0x06001C50 RID: 7248 RVA: 0x000713B0 File Offset: 0x0006F5B0
		internal virtual void Write()
		{
			using (NetWrite write = new NetWrite())
			{
				this.Write(write);
				this.NetworkTable.Write(this, write);
			}
		}

		// Token: 0x06001C51 RID: 7249 RVA: 0x000713F4 File Offset: 0x0006F5F4
		internal virtual void Write(NetWrite write)
		{
		}

		/// <summary>
		/// Look at current value and 
		/// build any child variables if needed
		/// </summary>
		// Token: 0x06001C52 RID: 7250 RVA: 0x000713F6 File Offset: 0x0006F5F6
		internal virtual void Build()
		{
		}

		// Token: 0x06001C53 RID: 7251 RVA: 0x000713F8 File Offset: 0x0006F5F8
		internal void Read()
		{
			Host.AssertClient("Read");
			if (this.NetworkTable == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 1);
				defaultInterpolatedStringHandler.AppendFormatted<Var>(this);
				defaultInterpolatedStringHandler.AppendLiteral(" trying to read - but no network table");
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			NetRead read = this.NetworkTable.Read(this);
			this.Read(read);
		}

		// Token: 0x06001C54 RID: 7252 RVA: 0x00071456 File Offset: 0x0006F656
		internal virtual void Read(NetRead read)
		{
		}

		// Token: 0x06001C55 RID: 7253 RVA: 0x00071458 File Offset: 0x0006F658
		internal void NetWrite<[IsUnmanaged] U>(U value) where U : struct, ValueType
		{
			if (Host.IsClient)
			{
				return;
			}
			if (!this.NetworkTable.IsValid())
			{
				return;
			}
			if (this.Index < 0)
			{
				throw new NotSupportedException();
			}
			this.NetworkTable.Write(this, (IntPtr)Unsafe.AsPointer<U>(ref value), Unsafe.SizeOf<U>());
		}

		// Token: 0x06001C56 RID: 7254 RVA: 0x000714A7 File Offset: 0x0006F6A7
		protected bool CanChangeValue()
		{
			if (Host.IsClient)
			{
				return this.IsPredicted;
			}
			NetworkTable networkTable = this.NetworkTable;
			return networkTable == null || networkTable.CanWrite(this.IsPredicted);
		}

		// Token: 0x06001C57 RID: 7255 RVA: 0x000714CE File Offset: 0x0006F6CE
		protected void CheckValueChanged(object oldValue, object newValue)
		{
			if (this.Callback == null)
			{
				return;
			}
			if (object.Equals(newValue, oldValue))
			{
				return;
			}
			this.Callback(oldValue, newValue);
		}

		// Token: 0x06001C58 RID: 7256 RVA: 0x000714F0 File Offset: 0x0006F6F0
		protected void OnChanged(object oldValue, object newValue)
		{
			if (this.Callback == null)
			{
				return;
			}
			this.Callback(oldValue, newValue);
		}

		/// <summary>
		/// This variable has pending changes, waiting to be written to network. This
		/// variable stops dirty variables being added to the write list twice.
		/// </summary>
		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x06001C59 RID: 7257 RVA: 0x00071508 File Offset: 0x0006F708
		// (set) Token: 0x06001C5A RID: 7258 RVA: 0x00071510 File Offset: 0x0006F710
		public bool IsDirty { get; protected set; }

		/// <summary>
		/// Mark this variable as dirty. Its contents have changed and it needs writing
		/// </summary>
		// Token: 0x06001C5B RID: 7259 RVA: 0x00071519 File Offset: 0x0006F719
		public virtual void SetDirty(bool force = false)
		{
			if (Host.IsClient)
			{
				return;
			}
			if (this.IsDirty && !force)
			{
				return;
			}
			this.IsDirty = true;
			this.AddToWriteList();
		}

		/// <summary>
		/// Add this variable to the write list
		/// </summary>
		// Token: 0x06001C5C RID: 7260 RVA: 0x0007153C File Offset: 0x0006F73C
		protected virtual void AddToWriteList()
		{
			Var.WriteList.Writer.TryWrite(this);
		}

		/// <summary>
		/// Write all the variables that are queued waiting to write.
		/// This writes them to c++ network system, it doesn't actually send them.
		/// </summary>
		// Token: 0x06001C5D RID: 7261 RVA: 0x00071550 File Offset: 0x0006F750
		internal static void WriteAll()
		{
			Var old;
			while (Var.WriteList.Reader.TryRead(out old))
			{
				old.DoWrite();
			}
		}

		/// <summary>
		/// Clear the list, we don't want to be processing this shit in the next session
		/// </summary>
		// Token: 0x06001C5E RID: 7262 RVA: 0x00071578 File Offset: 0x0006F778
		internal static void ClearWriteList()
		{
			Var.WriteList = Channel.CreateUnbounded<Var>();
		}

		// Token: 0x040007A2 RID: 1954
		internal NetworkTable NetworkTable;

		// Token: 0x040007A7 RID: 1959
		public string Name;

		// Token: 0x040007A9 RID: 1961
		private static Channel<Var> WriteList = Channel.CreateUnbounded<Var>();
	}
}
