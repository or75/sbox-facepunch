using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	/// <summary>
	/// An awaitable version of a SteamAPICall_t
	/// </summary>
	// Token: 0x02000017 RID: 23
	internal struct CallResult<T> : INotifyCompletion where T : struct, ICallbackData
	{
		// Token: 0x06000013 RID: 19 RVA: 0x00002308 File Offset: 0x00000508
		internal CallResult(SteamAPICall_t call, bool server)
		{
			this.call = call;
			this.server = server;
			this.utils = (server ? SteamSharedClass<SteamUtils>.InterfaceServer : SteamSharedClass<SteamUtils>.InterfaceClient) as ISteamUtils;
			if (this.utils == null)
			{
				this.utils = SteamSharedClass<SteamUtils>.Interface as ISteamUtils;
			}
		}

		/// <summary>
		/// This gets called if IsComplete returned false on the first call.
		/// The Action "continues" the async call. We pass it to the Dispatch
		/// to be called when the callback returns.
		/// </summary>
		// Token: 0x06000014 RID: 20 RVA: 0x00002355 File Offset: 0x00000555
		public void OnCompleted(Action continuation)
		{
			if (this.IsCompleted)
			{
				continuation();
				return;
			}
			Dispatch.OnCallComplete<T>(this.call, continuation, this.server);
		}

		/// <summary>
		/// Gets the result. This is called internally by the async shit.
		/// </summary>
		// Token: 0x06000015 RID: 21 RVA: 0x00002378 File Offset: 0x00000578
		internal T? GetResult()
		{
			bool failed = false;
			T? t2;
			if (!this.utils.IsAPICallCompleted(this.call, ref failed) || failed)
			{
				t2 = null;
				return t2;
			}
			T t = default(T);
			int size = t.DataSize;
			IntPtr ptr = Marshal.AllocHGlobal(size);
			try
			{
				if (!this.utils.GetAPICallResult(this.call, ptr, size, (int)t.CallbackType, ref failed) || failed)
				{
					t2 = null;
					t2 = t2;
				}
				else
				{
					t2 = new T?((T)((object)Marshal.PtrToStructure(ptr, typeof(T))));
				}
			}
			finally
			{
				Marshal.FreeHGlobal(ptr);
			}
			return t2;
		}

		/// <summary>
		/// Return true if complete or failed
		/// </summary>
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002438 File Offset: 0x00000638
		internal bool IsCompleted
		{
			get
			{
				bool failed = false;
				return this.utils.IsAPICallCompleted(this.call, ref failed) || failed;
			}
		}

		/// <summary>
		/// This is what makes this struct awaitable
		/// </summary>
		// Token: 0x06000017 RID: 23 RVA: 0x00002461 File Offset: 0x00000661
		internal CallResult<T> GetAwaiter()
		{
			return this;
		}

		// Token: 0x04000117 RID: 279
		private SteamAPICall_t call;

		// Token: 0x04000118 RID: 280
		private ISteamUtils utils;

		// Token: 0x04000119 RID: 281
		private bool server;
	}
}
