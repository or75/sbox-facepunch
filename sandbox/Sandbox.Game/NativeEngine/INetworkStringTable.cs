using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200004D RID: 77
	internal struct INetworkStringTable
	{
		// Token: 0x06000A54 RID: 2644 RVA: 0x0003960E File Offset: 0x0003780E
		public static implicit operator IntPtr(INetworkStringTable value)
		{
			return value.self;
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x00039618 File Offset: 0x00037818
		public static implicit operator INetworkStringTable(IntPtr value)
		{
			return new INetworkStringTable
			{
				self = value
			};
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x00039636 File Offset: 0x00037836
		public static bool operator ==(INetworkStringTable c1, INetworkStringTable c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x00039649 File Offset: 0x00037849
		public static bool operator !=(INetworkStringTable c1, INetworkStringTable c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x0003965C File Offset: 0x0003785C
		public override bool Equals(object obj)
		{
			if (obj is INetworkStringTable)
			{
				INetworkStringTable c = (INetworkStringTable)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x00039686 File Offset: 0x00037886
		internal INetworkStringTable(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x00039690 File Offset: 0x00037890
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
			defaultInterpolatedStringHandler.AppendLiteral("INetworkStringTable ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000A5B RID: 2651 RVA: 0x000396CC File Offset: 0x000378CC
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000A5C RID: 2652 RVA: 0x000396DE File Offset: 0x000378DE
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x000396E9 File Offset: 0x000378E9
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x000396FC File Offset: 0x000378FC
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("INetworkStringTable was null when calling " + n);
			}
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x00039717 File Offset: 0x00037917
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x00039724 File Offset: 0x00037924
		internal readonly string GetTableName()
		{
			this.NullCheck("GetTableName");
			method inetwr_GetTableName = INetworkStringTable.__N.INetwr_GetTableName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, inetwr_GetTableName));
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x00039754 File Offset: 0x00037954
		internal readonly int GetTableId()
		{
			this.NullCheck("GetTableId");
			method inetwr_GetTableId = INetworkStringTable.__N.INetwr_GetTableId;
			return calli(System.Int32(System.IntPtr), this.self, inetwr_GetTableId);
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x00039780 File Offset: 0x00037980
		internal readonly int GetNumStrings()
		{
			this.NullCheck("GetNumStrings");
			method inetwr_GetNumStrings = INetworkStringTable.__N.INetwr_GetNumStrings;
			return calli(System.Int32(System.IntPtr), this.self, inetwr_GetNumStrings);
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x000397AC File Offset: 0x000379AC
		internal readonly void SetStringChangeTick(int tick)
		{
			this.NullCheck("SetStringChangeTick");
			method inetwr_SetStringChangeTick = INetworkStringTable.__N.INetwr_SetStringChangeTick;
			calli(System.Void(System.IntPtr,System.Int32), this.self, tick, inetwr_SetStringChangeTick);
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x000397D8 File Offset: 0x000379D8
		internal readonly int GetStringChangeTick()
		{
			this.NullCheck("GetStringChangeTick");
			method inetwr_GetStringChangeTick = INetworkStringTable.__N.INetwr_GetStringChangeTick;
			return calli(System.Int32(System.IntPtr), this.self, inetwr_GetStringChangeTick);
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x00039804 File Offset: 0x00037A04
		internal readonly bool ChangedSinceTick(int tick)
		{
			this.NullCheck("ChangedSinceTick");
			method inetwr_ChangedSinceTick = INetworkStringTable.__N.INetwr_ChangedSinceTick;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, tick, inetwr_ChangedSinceTick) > 0;
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x00039834 File Offset: 0x00037A34
		internal readonly int AddString(bool server, string value, int dataLength, IntPtr data)
		{
			this.NullCheck("AddString");
			method inetwr_AddString = INetworkStringTable.__N.INetwr_AddString;
			return calli(System.Int32(System.IntPtr,System.Int32,System.IntPtr,System.Int32,System.IntPtr), this.self, server ? 1 : 0, Interop.GetPointer(value), dataLength, data, inetwr_AddString);
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x00039870 File Offset: 0x00037A70
		internal readonly string GetString(int number, bool failSilently)
		{
			this.NullCheck("GetString");
			method inetwr_GetString = INetworkStringTable.__N.INetwr_GetString;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr,System.Int32,System.Int32), this.self, number, failSilently ? 1 : 0, inetwr_GetString));
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x000398A8 File Offset: 0x00037AA8
		internal readonly void SetStringUserData(int stringnumber, int dataLength, IntPtr data, bool forced)
		{
			this.NullCheck("SetStringUserData");
			method inetwr_SetStringUserData = INetworkStringTable.__N.INetwr_SetStringUserData;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32,System.IntPtr,System.Int32), this.self, stringnumber, dataLength, data, forced ? 1 : 0, inetwr_SetStringUserData);
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x000398E0 File Offset: 0x00037AE0
		internal readonly IntPtr GetStringUserData(int stringnumber, out int length)
		{
			this.NullCheck("GetStringUserData");
			method inetwr_GetStringUserData = INetworkStringTable.__N.INetwr_GetStringUserData;
			return calli(System.IntPtr(System.IntPtr,System.Int32,System.Int32& modreq(System.Runtime.InteropServices.OutAttribute)), this.self, stringnumber, ref length, inetwr_GetStringUserData);
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x0003990C File Offset: 0x00037B0C
		internal readonly int FindStringIndex(string name)
		{
			this.NullCheck("FindStringIndex");
			method inetwr_FindStringIndex = INetworkStringTable.__N.INetwr_FindStringIndex;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), inetwr_FindStringIndex);
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x0003993C File Offset: 0x00037B3C
		internal readonly void SetStringChangedCallback(IntPtr callback, bool invoke)
		{
			this.NullCheck("SetStringChangedCallback");
			method inetwr_SetStringChangedCallback = INetworkStringTable.__N.INetwr_SetStringChangedCallback;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, callback, invoke ? 1 : 0, inetwr_SetStringChangedCallback);
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x00039970 File Offset: 0x00037B70
		internal readonly void SetAllowClientSideAddString(bool t)
		{
			this.NullCheck("SetAllowClientSideAddString");
			method inetwr_SetAllowClientSideAddString = INetworkStringTable.__N.INetwr_SetAllowClientSideAddString;
			calli(System.Void(System.IntPtr,System.Int32), this.self, t ? 1 : 0, inetwr_SetAllowClientSideAddString);
		}

		// Token: 0x040000BB RID: 187
		internal IntPtr self;

		// Token: 0x020001D2 RID: 466
		internal static class __N
		{
			// Token: 0x04000F63 RID: 3939
			internal static method INetwr_GetTableName;

			// Token: 0x04000F64 RID: 3940
			internal static method INetwr_GetTableId;

			// Token: 0x04000F65 RID: 3941
			internal static method INetwr_GetNumStrings;

			// Token: 0x04000F66 RID: 3942
			internal static method INetwr_SetStringChangeTick;

			// Token: 0x04000F67 RID: 3943
			internal static method INetwr_GetStringChangeTick;

			// Token: 0x04000F68 RID: 3944
			internal static method INetwr_ChangedSinceTick;

			// Token: 0x04000F69 RID: 3945
			internal static method INetwr_AddString;

			// Token: 0x04000F6A RID: 3946
			internal static method INetwr_GetString;

			// Token: 0x04000F6B RID: 3947
			internal static method INetwr_SetStringUserData;

			// Token: 0x04000F6C RID: 3948
			internal static method INetwr_GetStringUserData;

			// Token: 0x04000F6D RID: 3949
			internal static method INetwr_FindStringIndex;

			// Token: 0x04000F6E RID: 3950
			internal static method INetwr_SetStringChangedCallback;

			// Token: 0x04000F6F RID: 3951
			internal static method INetwr_SetAllowClientSideAddString;
		}
	}
}
