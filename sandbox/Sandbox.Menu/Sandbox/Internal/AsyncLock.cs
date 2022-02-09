using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Internal
{
	// Token: 0x0200000C RID: 12
	internal class AsyncLock
	{
		// Token: 0x06000036 RID: 54 RVA: 0x00003220 File Offset: 0x00001420
		public AsyncLock(int count = 1)
		{
			this._semaphore = new SemaphoreSlim(count, count);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003238 File Offset: 0x00001438
		public async ValueTask<IDisposable> LockAsync()
		{
			await this._semaphore.WaitAsync();
			return new AsyncLock.Releaser
			{
				Semaphore = this._semaphore
			};
		}

		// Token: 0x0400000B RID: 11
		private readonly SemaphoreSlim _semaphore;

		// Token: 0x0200001C RID: 28
		private class Releaser : IDisposable, IEquatable<AsyncLock.Releaser>
		{
			// Token: 0x17000017 RID: 23
			// (get) Token: 0x06000085 RID: 133 RVA: 0x00003F92 File Offset: 0x00002192
			[Nullable(1)]
			protected virtual Type EqualityContract
			{
				[NullableContext(1)]
				[CompilerGenerated]
				get
				{
					return typeof(AsyncLock.Releaser);
				}
			}

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x06000086 RID: 134 RVA: 0x00003F9E File Offset: 0x0000219E
			// (set) Token: 0x06000087 RID: 135 RVA: 0x00003FA6 File Offset: 0x000021A6
			public SemaphoreSlim Semaphore { get; set; }

			// Token: 0x06000088 RID: 136 RVA: 0x00003FAF File Offset: 0x000021AF
			public void Dispose()
			{
				this.Semaphore.Release();
			}

			// Token: 0x06000089 RID: 137 RVA: 0x00003FC0 File Offset: 0x000021C0
			[NullableContext(1)]
			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("Releaser");
				stringBuilder.Append(" { ");
				if (this.PrintMembers(stringBuilder))
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append('}');
				return stringBuilder.ToString();
			}

			// Token: 0x0600008A RID: 138 RVA: 0x0000400C File Offset: 0x0000220C
			[NullableContext(1)]
			protected virtual bool PrintMembers(StringBuilder builder)
			{
				RuntimeHelpers.EnsureSufficientExecutionStack();
				builder.Append("Semaphore = ");
				builder.Append(this.Semaphore);
				return true;
			}

			// Token: 0x0600008B RID: 139 RVA: 0x0000402D File Offset: 0x0000222D
			[NullableContext(2)]
			public static bool operator !=(AsyncLock.Releaser left, AsyncLock.Releaser right)
			{
				return !(left == right);
			}

			// Token: 0x0600008C RID: 140 RVA: 0x00004039 File Offset: 0x00002239
			[NullableContext(2)]
			public static bool operator ==(AsyncLock.Releaser left, AsyncLock.Releaser right)
			{
				return left == right || (left != null && left.Equals(right));
			}

			// Token: 0x0600008D RID: 141 RVA: 0x0000404D File Offset: 0x0000224D
			public override int GetHashCode()
			{
				return EqualityComparer<Type>.Default.GetHashCode(this.EqualityContract) * -1521134295 + EqualityComparer<SemaphoreSlim>.Default.GetHashCode(this.<Semaphore>k__BackingField);
			}

			// Token: 0x0600008E RID: 142 RVA: 0x00004076 File Offset: 0x00002276
			[NullableContext(2)]
			public override bool Equals(object obj)
			{
				return this.Equals(obj as AsyncLock.Releaser);
			}

			// Token: 0x0600008F RID: 143 RVA: 0x00004084 File Offset: 0x00002284
			[NullableContext(2)]
			public virtual bool Equals(AsyncLock.Releaser other)
			{
				return this == other || (other != null && this.EqualityContract == other.EqualityContract && EqualityComparer<SemaphoreSlim>.Default.Equals(this.<Semaphore>k__BackingField, other.<Semaphore>k__BackingField));
			}

			// Token: 0x06000090 RID: 144 RVA: 0x000040BA File Offset: 0x000022BA
			[NullableContext(1)]
			public virtual AsyncLock.Releaser <Clone>$()
			{
				return new AsyncLock.Releaser(this);
			}

			// Token: 0x06000091 RID: 145 RVA: 0x000040C2 File Offset: 0x000022C2
			protected Releaser([Nullable(1)] AsyncLock.Releaser original)
			{
				this.Semaphore = original.<Semaphore>k__BackingField;
			}

			// Token: 0x06000092 RID: 146 RVA: 0x000040D6 File Offset: 0x000022D6
			public Releaser()
			{
			}
		}
	}
}
