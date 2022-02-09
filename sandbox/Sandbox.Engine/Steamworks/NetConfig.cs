using System;

namespace Steamworks
{
	// Token: 0x02000097 RID: 151
	internal enum NetConfig
	{
		// Token: 0x04000899 RID: 2201
		Invalid,
		// Token: 0x0400089A RID: 2202
		TimeoutInitial = 24,
		// Token: 0x0400089B RID: 2203
		TimeoutConnected,
		// Token: 0x0400089C RID: 2204
		SendBufferSize = 9,
		// Token: 0x0400089D RID: 2205
		ConnectionUserData = 40,
		// Token: 0x0400089E RID: 2206
		SendRateMin = 10,
		// Token: 0x0400089F RID: 2207
		SendRateMax,
		// Token: 0x040008A0 RID: 2208
		NagleTime,
		// Token: 0x040008A1 RID: 2209
		IP_AllowWithoutAuth = 23,
		// Token: 0x040008A2 RID: 2210
		MTU_PacketSize = 32,
		// Token: 0x040008A3 RID: 2211
		MTU_DataSize,
		// Token: 0x040008A4 RID: 2212
		Unencrypted,
		// Token: 0x040008A5 RID: 2213
		SymmetricConnect = 37,
		// Token: 0x040008A6 RID: 2214
		LocalVirtualPort,
		// Token: 0x040008A7 RID: 2215
		DualWifi_Enable,
		// Token: 0x040008A8 RID: 2216
		EnableDiagnosticsUI = 46,
		// Token: 0x040008A9 RID: 2217
		FakePacketLoss_Send = 2,
		// Token: 0x040008AA RID: 2218
		FakePacketLoss_Recv,
		// Token: 0x040008AB RID: 2219
		FakePacketLag_Send,
		// Token: 0x040008AC RID: 2220
		FakePacketLag_Recv,
		// Token: 0x040008AD RID: 2221
		FakePacketReorder_Send,
		// Token: 0x040008AE RID: 2222
		FakePacketReorder_Recv,
		// Token: 0x040008AF RID: 2223
		FakePacketReorder_Time,
		// Token: 0x040008B0 RID: 2224
		FakePacketDup_Send = 26,
		// Token: 0x040008B1 RID: 2225
		FakePacketDup_Recv,
		// Token: 0x040008B2 RID: 2226
		FakePacketDup_TimeMax,
		// Token: 0x040008B3 RID: 2227
		PacketTraceMaxBytes = 41,
		// Token: 0x040008B4 RID: 2228
		FakeRateLimit_Send_Rate,
		// Token: 0x040008B5 RID: 2229
		FakeRateLimit_Send_Burst,
		// Token: 0x040008B6 RID: 2230
		FakeRateLimit_Recv_Rate,
		// Token: 0x040008B7 RID: 2231
		FakeRateLimit_Recv_Burst,
		// Token: 0x040008B8 RID: 2232
		Callback_ConnectionStatusChanged = 201,
		// Token: 0x040008B9 RID: 2233
		Callback_AuthStatusChanged,
		// Token: 0x040008BA RID: 2234
		Callback_RelayNetworkStatusChanged,
		// Token: 0x040008BB RID: 2235
		Callback_MessagesSessionRequest,
		// Token: 0x040008BC RID: 2236
		Callback_MessagesSessionFailed,
		// Token: 0x040008BD RID: 2237
		Callback_CreateConnectionSignaling,
		// Token: 0x040008BE RID: 2238
		Callback_FakeIPResult,
		// Token: 0x040008BF RID: 2239
		P2P_STUN_ServerList = 103,
		// Token: 0x040008C0 RID: 2240
		P2P_Transport_ICE_Enable,
		// Token: 0x040008C1 RID: 2241
		P2P_Transport_ICE_Penalty,
		// Token: 0x040008C2 RID: 2242
		P2P_Transport_SDR_Penalty,
		// Token: 0x040008C3 RID: 2243
		SDRClient_ConsecutitivePingTimeoutsFailInitial = 19,
		// Token: 0x040008C4 RID: 2244
		SDRClient_ConsecutitivePingTimeoutsFail,
		// Token: 0x040008C5 RID: 2245
		SDRClient_MinPingsBeforePingAccurate,
		// Token: 0x040008C6 RID: 2246
		SDRClient_SingleSocket,
		// Token: 0x040008C7 RID: 2247
		SDRClient_ForceRelayCluster = 29,
		// Token: 0x040008C8 RID: 2248
		SDRClient_DebugTicketAddress,
		// Token: 0x040008C9 RID: 2249
		SDRClient_ForceProxyAddr,
		// Token: 0x040008CA RID: 2250
		SDRClient_FakeClusterPing = 36,
		// Token: 0x040008CB RID: 2251
		LogLevel_AckRTT = 13,
		// Token: 0x040008CC RID: 2252
		LogLevel_PacketDecode,
		// Token: 0x040008CD RID: 2253
		LogLevel_Message,
		// Token: 0x040008CE RID: 2254
		LogLevel_PacketGaps,
		// Token: 0x040008CF RID: 2255
		LogLevel_P2PRendezvous,
		// Token: 0x040008D0 RID: 2256
		LogLevel_SDRRelayPings,
		// Token: 0x040008D1 RID: 2257
		DELETED_EnumerateDevVars = 35
	}
}
