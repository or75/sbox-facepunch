using System;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x020000B5 RID: 181
	public class Pen
	{
		// Token: 0x06001552 RID: 5458 RVA: 0x0005743E File Offset: 0x0005563E
		public Pen()
		{
			this.ptr = QPen.Create();
		}

		// Token: 0x06001553 RID: 5459 RVA: 0x00057451 File Offset: 0x00055651
		public Pen(Color color, float width)
		{
			this.ptr = QPen.Create();
			this.ptr.setColor(color);
			this.ptr.setWidthF(width);
		}

		// Token: 0x06001554 RID: 5460 RVA: 0x00057484 File Offset: 0x00055684
		~Pen()
		{
			MainThread.QueueDispose(this.ptr);
			this.ptr = default(QPen);
		}

		// Token: 0x04000457 RID: 1111
		internal QPen ptr;
	}
}
