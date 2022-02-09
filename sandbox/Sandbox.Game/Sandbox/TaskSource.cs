using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox
{
	/// <summary>
	/// Provides a way for us to cancel tasks after common async shit is executed
	/// </summary>
	// Token: 0x02000105 RID: 261
	public struct TaskSource
	{
		// Token: 0x17000325 RID: 805
		// (get) Token: 0x0600151B RID: 5403 RVA: 0x0005402F File Offset: 0x0005222F
		internal static CancellationToken Cancellation
		{
			get
			{
				return TaskSource.currentGenerationCts.Token;
			}
		}

		// Token: 0x0600151C RID: 5404 RVA: 0x0005403B File Offset: 0x0005223B
		internal TaskSource(int i = 0)
		{
			this._isValid = true;
			this._cancellation = TaskSource.Cancellation;
		}

		// Token: 0x0600151D RID: 5405 RVA: 0x0005404F File Offset: 0x0005224F
		internal static void OnSessionEnded()
		{
			CancellationTokenSource cancellationTokenSource = TaskSource.currentGenerationCts;
			TaskSource.currentGenerationCts = new CancellationTokenSource();
			cancellationTokenSource.Cancel();
			cancellationTokenSource.Dispose();
		}

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x0600151E RID: 5406 RVA: 0x0005406B File Offset: 0x0005226B
		public bool IsValid
		{
			get
			{
				return this._isValid && !this._cancellation.IsCancellationRequested;
			}
		}

		// Token: 0x0600151F RID: 5407 RVA: 0x00054085 File Offset: 0x00052285
		public void Expire()
		{
			this._isValid = false;
		}

		// Token: 0x06001520 RID: 5408 RVA: 0x0005408E File Offset: 0x0005228E
		internal void CancelIfInvalid()
		{
			if (!this.IsValid)
			{
				throw new TaskCanceledException();
			}
		}

		// Token: 0x06001521 RID: 5409 RVA: 0x000540A0 File Offset: 0x000522A0
		public async Task Delay(int ms)
		{
			float time = Time.Now + (float)ms / 1000f;
			while (Time.Now < time)
			{
				await Task.Delay(1, this._cancellation);
				this.CancelIfInvalid();
			}
		}

		// Token: 0x06001522 RID: 5410 RVA: 0x000540F0 File Offset: 0x000522F0
		public Task DelaySeconds(float seconds)
		{
			return this.Delay((int)(seconds * 1000f));
		}

		// Token: 0x06001523 RID: 5411 RVA: 0x00054100 File Offset: 0x00052300
		public async Task DelayRealtime(int ms)
		{
			await Task.Delay(ms, this._cancellation);
			this.CancelIfInvalid();
		}

		// Token: 0x06001524 RID: 5412 RVA: 0x00054150 File Offset: 0x00052350
		public Task DelayRealtimeSeconds(float seconds)
		{
			return this.DelayRealtime((int)(seconds * 1000f));
		}

		// Token: 0x06001525 RID: 5413 RVA: 0x00054160 File Offset: 0x00052360
		public async Task NextPhysicsFrame()
		{
			await GameTask.NextPhysicsFrame();
			this.CancelIfInvalid();
		}

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06001526 RID: 5414 RVA: 0x000541A8 File Offset: 0x000523A8
		public Task CompletedTask
		{
			get
			{
				return Task.CompletedTask;
			}
		}

		// Token: 0x06001527 RID: 5415 RVA: 0x000541AF File Offset: 0x000523AF
		public Task FromResult<T>(T t)
		{
			return Task.FromResult<T>(t);
		}

		// Token: 0x06001528 RID: 5416 RVA: 0x000541B8 File Offset: 0x000523B8
		public async Task Yield()
		{
			await Task.Yield();
			this.CancelIfInvalid();
		}

		// Token: 0x040004EB RID: 1259
		private static CancellationTokenSource currentGenerationCts = new CancellationTokenSource();

		// Token: 0x040004EC RID: 1260
		private readonly CancellationToken _cancellation;

		// Token: 0x040004ED RID: 1261
		private bool _isValid;
	}
}
