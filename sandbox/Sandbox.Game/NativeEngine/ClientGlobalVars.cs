using System;
using System.Runtime.InteropServices;

namespace NativeEngine
{
	// Token: 0x02000021 RID: 33
	internal static class ClientGlobalVars
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000369 RID: 873 RVA: 0x00027DCF File Offset: 0x00025FCF
		// (set) Token: 0x0600036A RID: 874 RVA: 0x00027DDB File Offset: 0x00025FDB
		internal static float realtime
		{
			get
			{
				return ClientGlobalVars.__N.Get__gpGlbl_realtime();
			}
			set
			{
				ClientGlobalVars.__N.Set__gpGlbl_realtime(value);
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600036B RID: 875 RVA: 0x00027DE8 File Offset: 0x00025FE8
		// (set) Token: 0x0600036C RID: 876 RVA: 0x00027DF4 File Offset: 0x00025FF4
		internal static int framecount
		{
			get
			{
				return ClientGlobalVars.__N.Get__gpGlbl_framecount();
			}
			set
			{
				ClientGlobalVars.__N.Set__gpGlbl_framecount(value);
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600036D RID: 877 RVA: 0x00027E01 File Offset: 0x00026001
		// (set) Token: 0x0600036E RID: 878 RVA: 0x00027E0D File Offset: 0x0002600D
		internal static float unfilteredframetime
		{
			get
			{
				return ClientGlobalVars.__N.Get__gpGlbl_unfilteredframetime();
			}
			set
			{
				ClientGlobalVars.__N.Set__gpGlbl_unfilteredframetime(value);
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600036F RID: 879 RVA: 0x00027E1A File Offset: 0x0002601A
		// (set) Token: 0x06000370 RID: 880 RVA: 0x00027E26 File Offset: 0x00026026
		internal static int maxClients
		{
			get
			{
				return ClientGlobalVars.__N.Get__gpGlbl_maxClients();
			}
			set
			{
				ClientGlobalVars.__N.Set__gpGlbl_maxClients(value);
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000371 RID: 881 RVA: 0x00027E33 File Offset: 0x00026033
		// (set) Token: 0x06000372 RID: 882 RVA: 0x00027E3F File Offset: 0x0002603F
		internal static int tickcount
		{
			get
			{
				return ClientGlobalVars.__N.Get__gpGlbl_tickcount();
			}
			set
			{
				ClientGlobalVars.__N.Set__gpGlbl_tickcount(value);
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000373 RID: 883 RVA: 0x00027E4C File Offset: 0x0002604C
		// (set) Token: 0x06000374 RID: 884 RVA: 0x00027E58 File Offset: 0x00026058
		internal static float interval_per_tick
		{
			get
			{
				return ClientGlobalVars.__N.Get__gpGlbl_interval_per_tick();
			}
			set
			{
				ClientGlobalVars.__N.Set__gpGlbl_interval_per_tick(value);
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000375 RID: 885 RVA: 0x00027E65 File Offset: 0x00026065
		// (set) Token: 0x06000376 RID: 886 RVA: 0x00027E71 File Offset: 0x00026071
		internal static float interval_per_tick_prediction
		{
			get
			{
				return ClientGlobalVars.__N.Get__gpGlbl_interval_per_tick_prediction();
			}
			set
			{
				ClientGlobalVars.__N.Set__gpGlbl_interval_per_tick_prediction(value);
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000377 RID: 887 RVA: 0x00027E7E File Offset: 0x0002607E
		// (set) Token: 0x06000378 RID: 888 RVA: 0x00027E8A File Offset: 0x0002608A
		internal static int m_simTicksThisFrameIndex
		{
			get
			{
				return ClientGlobalVars.__N.Get__gpGlbl_m_simTicksThisFrameIndex();
			}
			set
			{
				ClientGlobalVars.__N.Set__gpGlbl_m_simTicksThisFrameIndex(value);
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000379 RID: 889 RVA: 0x00027E97 File Offset: 0x00026097
		// (set) Token: 0x0600037A RID: 890 RVA: 0x00027EA3 File Offset: 0x000260A3
		internal static int m_simTicksThisFrameTotal
		{
			get
			{
				return ClientGlobalVars.__N.Get__gpGlbl_m_simTicksThisFrameTotal();
			}
			set
			{
				ClientGlobalVars.__N.Set__gpGlbl_m_simTicksThisFrameTotal(value);
			}
		}

		// Token: 0x020001A6 RID: 422
		internal static class __N
		{
			// Token: 0x040009BC RID: 2492
			internal static ClientGlobalVars.__N._Get__gpGlbl_realtime Get__gpGlbl_realtime;

			// Token: 0x040009BD RID: 2493
			internal static ClientGlobalVars.__N._Set__gpGlbl_realtime Set__gpGlbl_realtime;

			// Token: 0x040009BE RID: 2494
			internal static ClientGlobalVars.__N._Get__gpGlbl_framecount Get__gpGlbl_framecount;

			// Token: 0x040009BF RID: 2495
			internal static ClientGlobalVars.__N._Set__gpGlbl_framecount Set__gpGlbl_framecount;

			// Token: 0x040009C0 RID: 2496
			internal static ClientGlobalVars.__N._Get__gpGlbl_unfilteredframetime Get__gpGlbl_unfilteredframetime;

			// Token: 0x040009C1 RID: 2497
			internal static ClientGlobalVars.__N._Set__gpGlbl_unfilteredframetime Set__gpGlbl_unfilteredframetime;

			// Token: 0x040009C2 RID: 2498
			internal static ClientGlobalVars.__N._Get__gpGlbl_maxClients Get__gpGlbl_maxClients;

			// Token: 0x040009C3 RID: 2499
			internal static ClientGlobalVars.__N._Set__gpGlbl_maxClients Set__gpGlbl_maxClients;

			// Token: 0x040009C4 RID: 2500
			internal static ClientGlobalVars.__N._Get__gpGlbl_tickcount Get__gpGlbl_tickcount;

			// Token: 0x040009C5 RID: 2501
			internal static ClientGlobalVars.__N._Set__gpGlbl_tickcount Set__gpGlbl_tickcount;

			// Token: 0x040009C6 RID: 2502
			internal static ClientGlobalVars.__N._Get__gpGlbl_interval_per_tick Get__gpGlbl_interval_per_tick;

			// Token: 0x040009C7 RID: 2503
			internal static ClientGlobalVars.__N._Set__gpGlbl_interval_per_tick Set__gpGlbl_interval_per_tick;

			// Token: 0x040009C8 RID: 2504
			internal static ClientGlobalVars.__N._Get__gpGlbl_interval_per_tick_prediction Get__gpGlbl_interval_per_tick_prediction;

			// Token: 0x040009C9 RID: 2505
			internal static ClientGlobalVars.__N._Set__gpGlbl_interval_per_tick_prediction Set__gpGlbl_interval_per_tick_prediction;

			// Token: 0x040009CA RID: 2506
			internal static ClientGlobalVars.__N._Get__gpGlbl_m_simTicksThisFrameIndex Get__gpGlbl_m_simTicksThisFrameIndex;

			// Token: 0x040009CB RID: 2507
			internal static ClientGlobalVars.__N._Set__gpGlbl_m_simTicksThisFrameIndex Set__gpGlbl_m_simTicksThisFrameIndex;

			// Token: 0x040009CC RID: 2508
			internal static ClientGlobalVars.__N._Get__gpGlbl_m_simTicksThisFrameTotal Get__gpGlbl_m_simTicksThisFrameTotal;

			// Token: 0x040009CD RID: 2509
			internal static ClientGlobalVars.__N._Set__gpGlbl_m_simTicksThisFrameTotal Set__gpGlbl_m_simTicksThisFrameTotal;

			// Token: 0x020002D3 RID: 723
			// (Invoke) Token: 0x06002048 RID: 8264
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate float _Get__gpGlbl_realtime();

			// Token: 0x020002D4 RID: 724
			// (Invoke) Token: 0x0600204C RID: 8268
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__gpGlbl_realtime(float val);

			// Token: 0x020002D5 RID: 725
			// (Invoke) Token: 0x06002050 RID: 8272
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int _Get__gpGlbl_framecount();

			// Token: 0x020002D6 RID: 726
			// (Invoke) Token: 0x06002054 RID: 8276
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__gpGlbl_framecount(int val);

			// Token: 0x020002D7 RID: 727
			// (Invoke) Token: 0x06002058 RID: 8280
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate float _Get__gpGlbl_unfilteredframetime();

			// Token: 0x020002D8 RID: 728
			// (Invoke) Token: 0x0600205C RID: 8284
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__gpGlbl_unfilteredframetime(float val);

			// Token: 0x020002D9 RID: 729
			// (Invoke) Token: 0x06002060 RID: 8288
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int _Get__gpGlbl_maxClients();

			// Token: 0x020002DA RID: 730
			// (Invoke) Token: 0x06002064 RID: 8292
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__gpGlbl_maxClients(int val);

			// Token: 0x020002DB RID: 731
			// (Invoke) Token: 0x06002068 RID: 8296
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int _Get__gpGlbl_tickcount();

			// Token: 0x020002DC RID: 732
			// (Invoke) Token: 0x0600206C RID: 8300
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__gpGlbl_tickcount(int val);

			// Token: 0x020002DD RID: 733
			// (Invoke) Token: 0x06002070 RID: 8304
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate float _Get__gpGlbl_interval_per_tick();

			// Token: 0x020002DE RID: 734
			// (Invoke) Token: 0x06002074 RID: 8308
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__gpGlbl_interval_per_tick(float val);

			// Token: 0x020002DF RID: 735
			// (Invoke) Token: 0x06002078 RID: 8312
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate float _Get__gpGlbl_interval_per_tick_prediction();

			// Token: 0x020002E0 RID: 736
			// (Invoke) Token: 0x0600207C RID: 8316
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__gpGlbl_interval_per_tick_prediction(float val);

			// Token: 0x020002E1 RID: 737
			// (Invoke) Token: 0x06002080 RID: 8320
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int _Get__gpGlbl_m_simTicksThisFrameIndex();

			// Token: 0x020002E2 RID: 738
			// (Invoke) Token: 0x06002084 RID: 8324
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__gpGlbl_m_simTicksThisFrameIndex(int val);

			// Token: 0x020002E3 RID: 739
			// (Invoke) Token: 0x06002088 RID: 8328
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int _Get__gpGlbl_m_simTicksThisFrameTotal();

			// Token: 0x020002E4 RID: 740
			// (Invoke) Token: 0x0600208C RID: 8332
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__gpGlbl_m_simTicksThisFrameTotal(int val);
		}
	}
}
