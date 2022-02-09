using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Sandbox;

namespace Tools
{
	// Token: 0x02000084 RID: 132
	public class QModelIndexList : IDisposable
	{
		// Token: 0x0600134A RID: 4938 RVA: 0x000532D6 File Offset: 0x000514D6
		internal QModelIndexList(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x0600134B RID: 4939 RVA: 0x000532E8 File Offset: 0x000514E8
		~QModelIndexList()
		{
			if (!this.IsNull)
			{
				MainThread.QueueDispose(this);
			}
		}

		// Token: 0x0600134C RID: 4940 RVA: 0x0005331C File Offset: 0x0005151C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QModelIndexList ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x0600134D RID: 4941 RVA: 0x00053358 File Offset: 0x00051558
		internal bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600134E RID: 4942 RVA: 0x0005336A File Offset: 0x0005156A
		internal bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x0600134F RID: 4943 RVA: 0x00053375 File Offset: 0x00051575
		internal IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06001350 RID: 4944 RVA: 0x00053388 File Offset: 0x00051588
		internal void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QModelIndexList was null when calling " + n);
			}
		}

		// Token: 0x06001351 RID: 4945 RVA: 0x000533A3 File Offset: 0x000515A3
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06001352 RID: 4946 RVA: 0x000533B0 File Offset: 0x000515B0
		void IDisposable.Dispose()
		{
			if (this.IsNull)
			{
				return;
			}
			this.NullCheck("Dispose");
			try
			{
				method qmdelI_Dispose = QModelIndexList.__N.QMdelI_Dispose;
				calli(System.Void(System.IntPtr), this.self, qmdelI_Dispose);
			}
			finally
			{
				this.self = 0;
			}
		}

		// Token: 0x06001353 RID: 4947 RVA: 0x00053404 File Offset: 0x00051604
		internal int size()
		{
			this.NullCheck("size");
			method qmdelI_size = QModelIndexList.__N.QMdelI_size;
			return calli(System.Int32(System.IntPtr), this.self, qmdelI_size);
		}

		// Token: 0x06001354 RID: 4948 RVA: 0x00053430 File Offset: 0x00051630
		internal ModelIndex at(int i)
		{
			this.NullCheck("at");
			method qmdelI_at = QModelIndexList.__N.QMdelI_at;
			return calli(Tools.ModelIndex(System.IntPtr,System.Int32), this.self, i, qmdelI_at);
		}

		// Token: 0x06001355 RID: 4949 RVA: 0x0005345B File Offset: 0x0005165B
		public IEnumerable<ModelIndex> Enumerate()
		{
			int num;
			for (int i = 0; i < this.size(); i = num + 1)
			{
				yield return this.at(i);
				num = i;
			}
			yield break;
		}

		// Token: 0x040001B8 RID: 440
		internal IntPtr self;

		// Token: 0x0200013F RID: 319
		internal static class __N
		{
			// Token: 0x04001264 RID: 4708
			internal static method QMdelI_Dispose;

			// Token: 0x04001265 RID: 4709
			internal static method QMdelI_size;

			// Token: 0x04001266 RID: 4710
			internal static method QMdelI_at;
		}
	}
}
