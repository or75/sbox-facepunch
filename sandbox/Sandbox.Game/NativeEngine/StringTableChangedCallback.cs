using System;
using System.Runtime.InteropServices;

namespace NativeEngine
{
	// Token: 0x0200005F RID: 95
	// (Invoke) Token: 0x06000BBC RID: 3004
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void StringTableChangedCallback(IntPtr ptr, int datalen, IntPtr str, IntPtr data);
}
