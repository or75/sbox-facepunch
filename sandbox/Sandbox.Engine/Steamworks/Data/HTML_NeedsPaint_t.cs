using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200016A RID: 362
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_NeedsPaint_t : ICallbackData
	{
		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x0600094F RID: 2383 RVA: 0x0000E0C7 File Offset: 0x0000C2C7
		public int DataSize
		{
			get
			{
				return HTML_NeedsPaint_t._datasize;
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000950 RID: 2384 RVA: 0x0000E0CE File Offset: 0x0000C2CE
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_NeedsPaint;
			}
		}

		// Token: 0x04000BBB RID: 3003
		internal uint UnBrowserHandle;

		// Token: 0x04000BBC RID: 3004
		internal string PBGRA;

		// Token: 0x04000BBD RID: 3005
		internal uint UnWide;

		// Token: 0x04000BBE RID: 3006
		internal uint UnTall;

		// Token: 0x04000BBF RID: 3007
		internal uint UnUpdateX;

		// Token: 0x04000BC0 RID: 3008
		internal uint UnUpdateY;

		// Token: 0x04000BC1 RID: 3009
		internal uint UnUpdateWide;

		// Token: 0x04000BC2 RID: 3010
		internal uint UnUpdateTall;

		// Token: 0x04000BC3 RID: 3011
		internal uint UnScrollX;

		// Token: 0x04000BC4 RID: 3012
		internal uint UnScrollY;

		// Token: 0x04000BC5 RID: 3013
		internal float FlPageScale;

		// Token: 0x04000BC6 RID: 3014
		internal uint UnPageSerial;

		// Token: 0x04000BC7 RID: 3015
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_NeedsPaint_t));
	}
}
