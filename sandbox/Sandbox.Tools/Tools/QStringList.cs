using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Sandbox;

namespace Tools
{
	// Token: 0x02000085 RID: 133
	public class QStringList : IDisposable
	{
		// Token: 0x06001356 RID: 4950 RVA: 0x0005346B File Offset: 0x0005166B
		internal QStringList(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06001357 RID: 4951 RVA: 0x0005347C File Offset: 0x0005167C
		~QStringList()
		{
			if (!this.IsNull)
			{
				MainThread.QueueDispose(this);
			}
		}

		// Token: 0x06001358 RID: 4952 RVA: 0x000534B0 File Offset: 0x000516B0
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QStringList ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06001359 RID: 4953 RVA: 0x000534EC File Offset: 0x000516EC
		internal bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600135A RID: 4954 RVA: 0x000534FE File Offset: 0x000516FE
		internal bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x0600135B RID: 4955 RVA: 0x00053509 File Offset: 0x00051709
		internal IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x0600135C RID: 4956 RVA: 0x0005351C File Offset: 0x0005171C
		internal void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QStringList was null when calling " + n);
			}
		}

		// Token: 0x0600135D RID: 4957 RVA: 0x00053537 File Offset: 0x00051737
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x0600135E RID: 4958 RVA: 0x00053544 File Offset: 0x00051744
		void IDisposable.Dispose()
		{
			if (this.IsNull)
			{
				return;
			}
			this.NullCheck("Dispose");
			try
			{
				method qstrng_Dispose = QStringList.__N.QStrng_Dispose;
				calli(System.Void(System.IntPtr), this.self, qstrng_Dispose);
			}
			finally
			{
				this.self = 0;
			}
		}

		// Token: 0x0600135F RID: 4959 RVA: 0x00053598 File Offset: 0x00051798
		internal int size()
		{
			this.NullCheck("size");
			method qstrng_size = QStringList.__N.QStrng_size;
			return calli(System.Int32(System.IntPtr), this.self, qstrng_size);
		}

		// Token: 0x06001360 RID: 4960 RVA: 0x000535C4 File Offset: 0x000517C4
		internal string at(int i)
		{
			this.NullCheck("at");
			method qstrng_at = QStringList.__N.QStrng_at;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr,System.Int32), this.self, i, qstrng_at));
		}

		// Token: 0x06001361 RID: 4961 RVA: 0x000535F4 File Offset: 0x000517F4
		public List<string> ToList()
		{
			List<string> i = new List<string>();
			for (int j = 0; j < this.size(); j++)
			{
				i.Add(this.at(j));
			}
			return i;
		}

		// Token: 0x040001B9 RID: 441
		internal IntPtr self;

		// Token: 0x02000141 RID: 321
		internal static class __N
		{
			// Token: 0x0400126C RID: 4716
			internal static method QStrng_Dispose;

			// Token: 0x0400126D RID: 4717
			internal static method QStrng_size;

			// Token: 0x0400126E RID: 4718
			internal static method QStrng_at;
		}
	}
}
