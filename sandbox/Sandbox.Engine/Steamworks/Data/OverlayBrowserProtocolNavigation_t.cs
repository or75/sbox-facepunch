using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x020000ED RID: 237
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct OverlayBrowserProtocolNavigation_t : ICallbackData
	{
		// Token: 0x060007CB RID: 1995 RVA: 0x0000CDA0 File Offset: 0x0000AFA0
		internal string RgchURIUTF8()
		{
			return Encoding.UTF8.GetString(this.RgchURI, 0, Array.IndexOf<byte>(this.RgchURI, 0));
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060007CC RID: 1996 RVA: 0x0000CDBF File Offset: 0x0000AFBF
		public int DataSize
		{
			get
			{
				return OverlayBrowserProtocolNavigation_t._datasize;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060007CD RID: 1997 RVA: 0x0000CDC6 File Offset: 0x0000AFC6
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.OverlayBrowserProtocolNavigation;
			}
		}

		// Token: 0x040009F5 RID: 2549
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
		internal byte[] RgchURI;

		// Token: 0x040009F6 RID: 2550
		internal static int _datasize = Marshal.SizeOf(typeof(OverlayBrowserProtocolNavigation_t));
	}
}
