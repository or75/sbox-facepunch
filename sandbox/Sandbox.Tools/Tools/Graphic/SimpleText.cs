using System;
using Native;
using Sandbox;

namespace Tools.Graphic
{
	// Token: 0x020000D8 RID: 216
	public class SimpleText : GraphicsItem
	{
		// Token: 0x060017CB RID: 6091 RVA: 0x0005BB6F File Offset: 0x00059D6F
		public SimpleText(string text, GraphicsItem parent = null)
			: base(null)
		{
			this.NativeInit(QGraphicsSimpleTextItem.Create(text, parent.IsValid() ? parent._graphicsitem : IntPtr.Zero));
			base.Parent = parent;
		}

		// Token: 0x060017CC RID: 6092 RVA: 0x0005BBAA File Offset: 0x00059DAA
		internal override void NativeInit(QGraphicsItem ptr)
		{
			this._simpletext = (QGraphicsSimpleTextItem)ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x060017CD RID: 6093 RVA: 0x0005BBBF File Offset: 0x00059DBF
		internal override void NativeShutdown()
		{
			this._simpletext = default(QGraphicsSimpleTextItem);
			base.NativeShutdown();
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x060017CE RID: 6094 RVA: 0x0005BBD3 File Offset: 0x00059DD3
		// (set) Token: 0x060017CF RID: 6095 RVA: 0x0005BBE0 File Offset: 0x00059DE0
		public string Text
		{
			get
			{
				return this._simpletext.text();
			}
			set
			{
				this._simpletext.setText(value);
			}
		}

		// Token: 0x040004E5 RID: 1253
		private QGraphicsSimpleTextItem _simpletext;
	}
}
