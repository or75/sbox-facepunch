using System;
using System.Threading.Channels;

namespace Sandbox
{
	// Token: 0x020002DB RID: 731
	internal static class MainThread
	{
		// Token: 0x0600134D RID: 4941 RVA: 0x00027AEF File Offset: 0x00025CEF
		internal static void QueueDispose(IDisposable disposable)
		{
			if (ThreadSafe.IsMainThread)
			{
				disposable.Dispose();
				return;
			}
			MainThread.Disposables.Writer.TryWrite(disposable);
		}

		// Token: 0x0600134E RID: 4942 RVA: 0x00027B10 File Offset: 0x00025D10
		internal static void RunQueues()
		{
			IDisposable disposable;
			while (MainThread.Disposables.Reader.TryRead(out disposable))
			{
				disposable.Dispose();
			}
		}

		// Token: 0x040014DC RID: 5340
		private static Channel<IDisposable> Disposables = Channel.CreateUnbounded<IDisposable>();
	}
}
