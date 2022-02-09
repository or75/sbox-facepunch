using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Sandbox.Internal
{
	// Token: 0x020002F1 RID: 753
	public struct SyncTask : INotifyCompletion
	{
		// Token: 0x06001401 RID: 5121 RVA: 0x0002AB98 File Offset: 0x00028D98
		internal SyncTask(MainThreadContext context, int frameOffset = 0)
		{
			this._context = context;
			context.Frame = frameOffset;
			this._frame = frameOffset;
		}

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x06001402 RID: 5122 RVA: 0x0002ABBC File Offset: 0x00028DBC
		public bool IsCompleted
		{
			get
			{
				return this._context == SynchronizationContext.Current && this._frame < this._context.Frame;
			}
		}

		// Token: 0x06001403 RID: 5123 RVA: 0x0002ABE0 File Offset: 0x00028DE0
		public void OnCompleted(Action continuation)
		{
			this._context.Post(SyncTask._postCallback, continuation);
		}

		// Token: 0x06001404 RID: 5124 RVA: 0x0002ABF3 File Offset: 0x00028DF3
		public void GetResult()
		{
		}

		// Token: 0x06001405 RID: 5125 RVA: 0x0002ABF5 File Offset: 0x00028DF5
		public SyncTask GetAwaiter()
		{
			return this;
		}

		// Token: 0x0400152B RID: 5419
		private static readonly SendOrPostCallback _postCallback = delegate(object state)
		{
			((Action)state)();
		};

		// Token: 0x0400152C RID: 5420
		private readonly MainThreadContext _context;

		// Token: 0x0400152D RID: 5421
		private readonly int _frame;
	}
}
