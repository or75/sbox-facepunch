using System;
using Native;
using Sandbox;
using Sandbox.Internal;

namespace Tools
{
	// Token: 0x020000A4 RID: 164
	public class EventFilter : QObject
	{
		// Token: 0x0600148A RID: 5258 RVA: 0x0005611C File Offset: 0x0005431C
		internal EventFilter(QObject parent)
		{
			InteropSystem.Alloc<EventFilter>(this);
			ManagedEventFilter ptr = ManagedEventFilter.Create(parent._object, this);
			this.NativeInit(ptr);
		}

		// Token: 0x0600148B RID: 5259 RVA: 0x0005614E File Offset: 0x0005434E
		internal override void NativeInit(IntPtr ptr)
		{
			this._filter = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x0600148C RID: 5260 RVA: 0x00056163 File Offset: 0x00054363
		internal override void NativeShutdown()
		{
			this._filter = default(ManagedEventFilter);
			InteropSystem.Free<EventFilter>(this);
			base.NativeShutdown();
		}

		// Token: 0x0600148D RID: 5261 RVA: 0x0005617D File Offset: 0x0005437D
		internal int OnKeyPressed()
		{
			GlobalToolsNamespace.Log.Info("On key pressed!");
			return 1;
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600148E RID: 5262 RVA: 0x00056190 File Offset: 0x00054390
		// (remove) Token: 0x0600148F RID: 5263 RVA: 0x000561C8 File Offset: 0x000543C8
		public event Func<bool> OnClosed;

		// Token: 0x06001490 RID: 5264 RVA: 0x000561FD File Offset: 0x000543FD
		internal bool OnEvent(EventType e)
		{
			if (e == EventType.Close)
			{
				Func<bool> onClosed = this.OnClosed;
				return onClosed != null && onClosed();
			}
			return false;
		}

		// Token: 0x04000411 RID: 1041
		internal ManagedEventFilter _filter;
	}
}
