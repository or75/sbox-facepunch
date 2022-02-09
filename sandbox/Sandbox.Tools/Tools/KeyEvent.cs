using System;

namespace Tools
{
	// Token: 0x020000A6 RID: 166
	public ref struct KeyEvent
	{
		// Token: 0x0600149B RID: 5275 RVA: 0x000562A3 File Offset: 0x000544A3
		internal KeyEvent(QKeyEvent ptr)
		{
			this.ptr = ptr;
			this.Key = (KeyCode)ptr.key();
			this.Text = ptr.text();
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600149C RID: 5276 RVA: 0x000562C6 File Offset: 0x000544C6
		// (set) Token: 0x0600149D RID: 5277 RVA: 0x000562CE File Offset: 0x000544CE
		public KeyCode Key { readonly get; set; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600149E RID: 5278 RVA: 0x000562D7 File Offset: 0x000544D7
		// (set) Token: 0x0600149F RID: 5279 RVA: 0x000562DF File Offset: 0x000544DF
		public string Text { readonly get; set; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060014A0 RID: 5280 RVA: 0x000562E8 File Offset: 0x000544E8
		// (set) Token: 0x060014A1 RID: 5281 RVA: 0x000562F5 File Offset: 0x000544F5
		public readonly bool Accepted
		{
			get
			{
				return this.ptr.isAccepted();
			}
			set
			{
				this.ptr.setAccepted(value);
			}
		}

		// Token: 0x04000414 RID: 1044
		internal QKeyEvent ptr;
	}
}
