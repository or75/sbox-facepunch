using System;

namespace Tools
{
	// Token: 0x020000A3 RID: 163
	public ref struct CloseEvent
	{
		// Token: 0x06001488 RID: 5256 RVA: 0x000560FF File Offset: 0x000542FF
		public readonly void Accept()
		{
			this.ptr.accept();
		}

		// Token: 0x06001489 RID: 5257 RVA: 0x0005610C File Offset: 0x0005430C
		public readonly void Ignore()
		{
			this.ptr.ignore();
		}

		// Token: 0x04000410 RID: 1040
		internal QEvent ptr;
	}
}
