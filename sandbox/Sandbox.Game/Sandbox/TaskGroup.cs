using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Sandbox
{
	/// <summary>
	/// Run a bunch of tasks in a thread, be able to wait until they're all finished
	/// </summary>
	// Token: 0x020000FD RID: 253
	internal class TaskGroup
	{
		// Token: 0x060014CE RID: 5326 RVA: 0x00053244 File Offset: 0x00051444
		public void Finish()
		{
			Task item;
			while (this.channel.Reader.TryRead(out item))
			{
				if (!item.IsCompleted)
				{
					item.Wait();
				}
			}
		}

		// Token: 0x060014CF RID: 5327 RVA: 0x00053278 File Offset: 0x00051478
		public void Add(Task task)
		{
			this.channel.Writer.WriteAsync(task, default(CancellationToken));
		}

		// Token: 0x060014D0 RID: 5328 RVA: 0x000532A0 File Offset: 0x000514A0
		internal void Run(Action p)
		{
			this.Add(Task.Run(p));
		}

		// Token: 0x060014D1 RID: 5329 RVA: 0x000532AE File Offset: 0x000514AE
		internal void Run(Func<Task> p)
		{
			this.Add(Task.Run(p));
		}

		// Token: 0x040004DB RID: 1243
		private Channel<Task> channel = Channel.CreateUnbounded<Task>();
	}
}
