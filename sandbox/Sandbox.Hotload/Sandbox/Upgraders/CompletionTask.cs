using System;
using System.Runtime.CompilerServices;

namespace Sandbox.Upgraders
{
	// Token: 0x02000011 RID: 17
	internal struct CompletionTask : IEquatable<CompletionTask>
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00004AA4 File Offset: 0x00002CA4
		public readonly Hotload.IBaseCallback NewInstance { get; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00004AAC File Offset: 0x00002CAC
		public readonly Hotload.IBaseCallback OldInstance { get; }

		// Token: 0x06000087 RID: 135 RVA: 0x00004AB4 File Offset: 0x00002CB4
		public CompletionTask(Hotload.IBaseCallback newInstance, Hotload.IBaseCallback oldInstance)
		{
			this.NewInstance = newInstance;
			this.OldInstance = oldInstance;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00004AC4 File Offset: 0x00002CC4
		public bool Equals(CompletionTask other)
		{
			return this.NewInstance == other.NewInstance;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00004AD5 File Offset: 0x00002CD5
		public override int GetHashCode()
		{
			return RuntimeHelpers.GetHashCode(this.NewInstance);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00004AE4 File Offset: 0x00002CE4
		public void OnComplete()
		{
			if (this.NewInstance != this.OldInstance)
			{
				Hotload.IKilled ikilled = this.OldInstance as Hotload.IKilled;
				if (ikilled != null)
				{
					ikilled.HotloadKilled(this.NewInstance);
				}
			}
		}
	}
}
