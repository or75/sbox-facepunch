using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks.Ugc
{
	// Token: 0x020000C1 RID: 193
	internal struct SteamParamStringArray : IDisposable
	{
		// Token: 0x06000739 RID: 1849 RVA: 0x0000C1CC File Offset: 0x0000A3CC
		internal static SteamParamStringArray From(string[] array)
		{
			SteamParamStringArray a = default(SteamParamStringArray);
			a.NativeStrings = new IntPtr[array.Length];
			for (int i = 0; i < a.NativeStrings.Length; i++)
			{
				a.NativeStrings[i] = Marshal.StringToHGlobalAnsi(array[i]);
			}
			int size = Marshal.SizeOf(typeof(IntPtr)) * a.NativeStrings.Length;
			a.NativeArray = Marshal.AllocHGlobal(size);
			Marshal.Copy(a.NativeStrings, 0, a.NativeArray, a.NativeStrings.Length);
			a.Value = new SteamParamStringArray_t
			{
				Strings = a.NativeArray,
				NumStrings = array.Length
			};
			return a;
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x0000C27C File Offset: 0x0000A47C
		public void Dispose()
		{
			IntPtr[] nativeStrings = this.NativeStrings;
			for (int i = 0; i < nativeStrings.Length; i++)
			{
				Marshal.FreeHGlobal(nativeStrings[i]);
			}
			Marshal.FreeHGlobal(this.NativeArray);
		}

		// Token: 0x0400096E RID: 2414
		internal SteamParamStringArray_t Value;

		// Token: 0x0400096F RID: 2415
		private IntPtr[] NativeStrings;

		// Token: 0x04000970 RID: 2416
		private IntPtr NativeArray;
	}
}
