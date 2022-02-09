using System;

namespace Tools
{
	// Token: 0x0200009A RID: 154
	public class DragData : QObject
	{
		// Token: 0x0600147E RID: 5246 RVA: 0x00056013 File Offset: 0x00054213
		public DragData()
		{
			this.NativeInit(QMimeData.Create());
		}

		// Token: 0x0600147F RID: 5247 RVA: 0x0005602B File Offset: 0x0005422B
		internal DragData(QMimeData mimedata)
		{
			this.NativeInit(mimedata);
		}

		// Token: 0x06001480 RID: 5248 RVA: 0x0005603F File Offset: 0x0005423F
		internal override void NativeInit(IntPtr ptr)
		{
			this._data = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x06001481 RID: 5249 RVA: 0x00056054 File Offset: 0x00054254
		internal override void NativeShutdown()
		{
			this._data = default(QMimeData);
			base.NativeShutdown();
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06001482 RID: 5250 RVA: 0x00056068 File Offset: 0x00054268
		// (set) Token: 0x06001483 RID: 5251 RVA: 0x00056075 File Offset: 0x00054275
		public string Text
		{
			get
			{
				return this._data.text();
			}
			set
			{
				this._data.setText(value);
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06001484 RID: 5252 RVA: 0x00056083 File Offset: 0x00054283
		// (set) Token: 0x06001485 RID: 5253 RVA: 0x00056090 File Offset: 0x00054290
		public string Html
		{
			get
			{
				return this._data.html();
			}
			set
			{
				this._data.setHtml(value);
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06001486 RID: 5254 RVA: 0x0005609E File Offset: 0x0005429E
		public bool HasFileOrFolder
		{
			get
			{
				return this.Text.StartsWith("file:///");
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06001487 RID: 5255 RVA: 0x000560B0 File Offset: 0x000542B0
		public string FileOrFolder
		{
			get
			{
				string pre = "file:///";
				string f = this.Text;
				if (f.Length < pre.Length + 1)
				{
					return null;
				}
				if (!f.StartsWith(pre))
				{
					return null;
				}
				string text = f;
				int length = text.Length;
				int length2 = pre.Length;
				int length3 = length - length2;
				return text.Substring(length2, length3);
			}
		}

		// Token: 0x0400020A RID: 522
		internal QMimeData _data;
	}
}
