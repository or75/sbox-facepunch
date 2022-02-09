using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using Managed.SandboxEngine;
using Sandbox.Engine;

namespace Sandbox
{
	// Token: 0x020002AF RID: 687
	internal static class Interop
	{
		// Token: 0x06001179 RID: 4473 RVA: 0x000232F8 File Offset: 0x000214F8
		internal unsafe static void CreateInterface(IntPtr interfaceName, int hash, IntPtr* exported, int* struct_sizes, IntPtr* imported)
		{
			string name = Interop.GetString(interfaceName);
			if (name == "engine")
			{
				NativeInterop.Initialize(hash, exported, struct_sizes, imported);
				return;
			}
			if (name == "server")
			{
				IServerDll serverDll = IServerDll.Current;
				if (serverDll == null)
				{
					return;
				}
				serverDll.InteropInit(hash, exported, struct_sizes, imported);
				return;
			}
			else if (name == "client")
			{
				IMenuDll menuDll = IMenuDll.Current;
				if (menuDll != null)
				{
					menuDll.InitInterop_Client(hash, exported, struct_sizes, imported);
				}
				IClientDll current = IClientDll.Current;
				if (current == null)
				{
					return;
				}
				current.InitInterop(hash, exported, struct_sizes, imported);
				return;
			}
			else if (name == "menu")
			{
				IMenuDll menuDll2 = IMenuDll.Current;
				if (menuDll2 == null)
				{
					return;
				}
				menuDll2.InitInterop_Menu(hash, exported, struct_sizes, imported);
				return;
			}
			else if (name == "tools")
			{
				IToolsDll toolsDll = IToolsDll.Current;
				if (toolsDll == null)
				{
					return;
				}
				toolsDll.InteropInit(hash, exported, struct_sizes, imported);
				return;
			}
			else
			{
				IToolsDll toolsDll2 = IToolsDll.Current;
				if (toolsDll2 != null && toolsDll2.InitToolInterface(name, hash, exported, struct_sizes, imported))
				{
					return;
				}
				throw new Exception("Unknown Interface: " + name);
			}
		}

		// Token: 0x0600117A RID: 4474 RVA: 0x000233EC File Offset: 0x000215EC
		public static int Free()
		{
			int i = 0;
			IntPtr ptr;
			while (Interop.Allocations.Reader.TryRead(out ptr))
			{
				Marshal.FreeHGlobal(ptr);
				i++;
			}
			if (Interop.TimeSinceFlush > 30f)
			{
				Interop.TimeSinceFlush = 0f;
				foreach (KeyValuePair<string, IntPtr> entry in Interop.Utf8Lookup)
				{
					if (Interop.Utf8Lookup.TryRemove(entry))
					{
						Marshal.FreeHGlobal(entry.Value);
						i++;
					}
				}
				foreach (KeyValuePair<string, IntPtr> entry2 in Interop.Utf16Lookup)
				{
					if (Interop.Utf16Lookup.TryRemove(entry2))
					{
						Marshal.FreeHGlobal(entry2.Value);
						i++;
					}
				}
			}
			return i;
		}

		/// <summary>
		/// Convert a native utf pointer to a string
		/// </summary>
		// Token: 0x0600117B RID: 4475 RVA: 0x000234E8 File Offset: 0x000216E8
		public static string GetString(IntPtr pointer)
		{
			if (pointer == IntPtr.Zero)
			{
				return null;
			}
			return Marshal.PtrToStringUTF8(pointer);
		}

		/// <summary>
		/// Convert a native utf pointer to a string
		/// </summary>
		// Token: 0x0600117C RID: 4476 RVA: 0x000234FF File Offset: 0x000216FF
		public static string GetString(IntPtr pointer, int byteLen)
		{
			if (pointer == IntPtr.Zero || byteLen <= 0)
			{
				return null;
			}
			return Marshal.PtrToStringUTF8(pointer, byteLen);
		}

		/// <summary>
		/// Convert a native utf pointer to a string
		/// </summary>
		// Token: 0x0600117D RID: 4477 RVA: 0x0002351B File Offset: 0x0002171B
		public static string GetWString(IntPtr pointer)
		{
			if (pointer == IntPtr.Zero)
			{
				return null;
			}
			return Marshal.PtrToStringUni(pointer);
		}

		/// <summary>
		/// Convert a native utf pointer to a string
		/// </summary>
		// Token: 0x0600117E RID: 4478 RVA: 0x00023532 File Offset: 0x00021732
		public static string GetWString(IntPtr pointer, int byteLen)
		{
			if (pointer == IntPtr.Zero || byteLen <= 0)
			{
				return null;
			}
			return Marshal.PtrToStringUni(pointer, byteLen);
		}

		/// <summary>
		/// Get a native friendly utf8 pointer
		/// </summary>
		// Token: 0x0600117F RID: 4479 RVA: 0x00023550 File Offset: 0x00021750
		public static IntPtr GetPointer(string str)
		{
			if (str == null)
			{
				return IntPtr.Zero;
			}
			if (str.Length < 32)
			{
				return Interop.Utf8Lookup.GetOrAdd(str, (string x) => Marshal.StringToCoTaskMemUTF8(x));
			}
			IntPtr ptr = Marshal.StringToCoTaskMemUTF8(str);
			Interop.Allocations.Writer.TryWrite(ptr);
			return ptr;
		}

		/// <summary>
		/// Get a native friendly unicode pointer
		/// </summary>
		// Token: 0x06001180 RID: 4480 RVA: 0x000235B4 File Offset: 0x000217B4
		public static IntPtr GetWPointer(string str)
		{
			if (str == null)
			{
				return IntPtr.Zero;
			}
			if (str.Length < 32)
			{
				return Interop.Utf16Lookup.GetOrAdd(str, (string x) => Marshal.StringToCoTaskMemUni(x));
			}
			IntPtr ptr = Marshal.StringToCoTaskMemUni(str);
			Interop.Allocations.Writer.TryWrite(ptr);
			return ptr;
		}

		/// <summary>
		/// Called by the binding system to log an exception when calling a binding
		/// </summary>
		// Token: 0x06001181 RID: 4481 RVA: 0x00023618 File Offset: 0x00021818
		public static void BindingException(string ClassName, string MethodName, Exception e)
		{
			try
			{
				Interop.log.Error(e, e.Message);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x04001394 RID: 5012
		private static Logger log = Logging.GetLogger(null);

		// Token: 0x04001395 RID: 5013
		private static ConcurrentDictionary<string, IntPtr> Utf8Lookup = new ConcurrentDictionary<string, IntPtr>();

		// Token: 0x04001396 RID: 5014
		private static ConcurrentDictionary<string, IntPtr> Utf16Lookup = new ConcurrentDictionary<string, IntPtr>();

		// Token: 0x04001397 RID: 5015
		public static Channel<IntPtr> Allocations = Channel.CreateUnbounded<IntPtr>();

		// Token: 0x04001398 RID: 5016
		private static RealTimeSince TimeSinceFlush;
	}
}
