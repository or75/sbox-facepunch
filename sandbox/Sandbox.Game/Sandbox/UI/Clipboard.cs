using System;
using NativeEngine;

namespace Sandbox.UI
{
	// Token: 0x0200010B RID: 267
	public static class Clipboard
	{
		/// <summary>
		/// Sets the clipboard text
		/// </summary>
		// Token: 0x06001572 RID: 5490 RVA: 0x000554DC File Offset: 0x000536DC
		public static void SetText(string text)
		{
			ClientGlobal.SDL_SetClipboardText(text);
		}
	}
}
