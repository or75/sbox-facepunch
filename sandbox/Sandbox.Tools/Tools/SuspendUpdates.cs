using System;

namespace Tools
{
	/// <summary>
	/// Suspends updates in the widget for this using scope.
	/// </summary>
	// Token: 0x020000D0 RID: 208
	public struct SuspendUpdates : IDisposable
	{
		// Token: 0x0600177A RID: 6010 RVA: 0x0005AFDE File Offset: 0x000591DE
		public SuspendUpdates(Widget widget)
		{
			this.Widget = widget;
			this.oldState = this.Widget.UpdatesEnabled;
			this.Widget.UpdatesEnabled = false;
		}

		// Token: 0x0600177B RID: 6011 RVA: 0x0005B004 File Offset: 0x00059204
		public void Dispose()
		{
			this.Widget.UpdatesEnabled = this.oldState;
		}

		// Token: 0x040004CA RID: 1226
		private Widget Widget;

		// Token: 0x040004CB RID: 1227
		private bool oldState;
	}
}
