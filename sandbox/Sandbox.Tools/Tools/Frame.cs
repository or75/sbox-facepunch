using System;
using Native;
using Sandbox;

namespace Tools
{
	/// <summary>
	/// Like a widget - but is drawn
	/// </summary>
	// Token: 0x020000AB RID: 171
	public class Frame : Widget
	{
		// Token: 0x060014C1 RID: 5313 RVA: 0x00056534 File Offset: 0x00054734
		internal Frame()
		{
		}

		// Token: 0x060014C2 RID: 5314 RVA: 0x0005653C File Offset: 0x0005473C
		internal Frame(IntPtr widget)
		{
			this.NativeInit(widget);
		}

		// Token: 0x060014C3 RID: 5315 RVA: 0x0005654C File Offset: 0x0005474C
		public Frame(Widget parent)
		{
			InteropSystem.Alloc<Frame>(this);
			CFrame widget = CFrame.CreateFrame((parent != null) ? parent._widget : default(QWidget), this);
			this.NativeInit(widget);
		}

		// Token: 0x060014C4 RID: 5316 RVA: 0x0005658C File Offset: 0x0005478C
		internal override void NativeInit(IntPtr ptr)
		{
			this._frame = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x060014C5 RID: 5317 RVA: 0x000565A1 File Offset: 0x000547A1
		internal override void NativeShutdown()
		{
			this._frame = default(QFrame);
			base.NativeShutdown();
		}

		// Token: 0x0400041B RID: 1051
		internal QFrame _frame;
	}
}
