using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks
{
	// Token: 0x020000BE RID: 190
	internal class Utf8StringToNative : ICustomMarshaler
	{
		// Token: 0x06000729 RID: 1833 RVA: 0x0000B7D0 File Offset: 0x000099D0
		public unsafe IntPtr MarshalManagedToNative(object managedObj)
		{
			if (managedObj == null)
			{
				return IntPtr.Zero;
			}
			string str = managedObj as string;
			if (str != null)
			{
				char* ptr;
				if (str == null)
				{
					ptr = null;
				}
				else
				{
					fixed (char* pinnableReference = str.GetPinnableReference())
					{
						ptr = pinnableReference;
					}
				}
				char* strPtr = ptr;
				int len = Encoding.UTF8.GetByteCount(str);
				IntPtr mem = Marshal.AllocHGlobal(len + 1);
				int wlen = Encoding.UTF8.GetBytes(strPtr, str.Length, (byte*)(void*)mem, len + 1);
				((byte*)(void*)mem)[wlen] = 0;
				return mem;
			}
			return IntPtr.Zero;
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x0000B848 File Offset: 0x00009A48
		public object MarshalNativeToManaged(IntPtr pNativeData)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x0000B84F File Offset: 0x00009A4F
		public void CleanUpNativeData(IntPtr pNativeData)
		{
			Marshal.FreeHGlobal(pNativeData);
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x0000B857 File Offset: 0x00009A57
		public void CleanUpManagedData(object managedObj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x0000B85E File Offset: 0x00009A5E
		public int GetNativeDataSize()
		{
			return -1;
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x0000B861 File Offset: 0x00009A61
		[Preserve]
		public static ICustomMarshaler GetInstance(string cookie)
		{
			return new Utf8StringToNative();
		}
	}
}
