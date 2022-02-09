using System;

namespace Steamworks
{
	// Token: 0x02000094 RID: 148
	internal enum NetConnectionEnd
	{
		// Token: 0x0400086D RID: 2157
		Invalid,
		// Token: 0x0400086E RID: 2158
		App_Min = 1000,
		// Token: 0x0400086F RID: 2159
		App_Generic = 1000,
		// Token: 0x04000870 RID: 2160
		App_Max = 1999,
		// Token: 0x04000871 RID: 2161
		AppException_Min,
		// Token: 0x04000872 RID: 2162
		AppException_Generic = 2000,
		// Token: 0x04000873 RID: 2163
		AppException_Max = 2999,
		// Token: 0x04000874 RID: 2164
		Local_Min,
		// Token: 0x04000875 RID: 2165
		Local_OfflineMode,
		// Token: 0x04000876 RID: 2166
		Local_ManyRelayConnectivity,
		// Token: 0x04000877 RID: 2167
		Local_HostedServerPrimaryRelay,
		// Token: 0x04000878 RID: 2168
		Local_NetworkConfig,
		// Token: 0x04000879 RID: 2169
		Local_Rights,
		// Token: 0x0400087A RID: 2170
		Local_P2P_ICE_NoPublicAddresses,
		// Token: 0x0400087B RID: 2171
		Local_Max = 3999,
		// Token: 0x0400087C RID: 2172
		Remote_Min,
		// Token: 0x0400087D RID: 2173
		Remote_Timeout,
		// Token: 0x0400087E RID: 2174
		Remote_BadCrypt,
		// Token: 0x0400087F RID: 2175
		Remote_BadCert,
		// Token: 0x04000880 RID: 2176
		Remote_BadProtocolVersion = 4006,
		// Token: 0x04000881 RID: 2177
		Remote_P2P_ICE_NoPublicAddresses,
		// Token: 0x04000882 RID: 2178
		Remote_Max = 4999,
		// Token: 0x04000883 RID: 2179
		Misc_Min,
		// Token: 0x04000884 RID: 2180
		Misc_Generic,
		// Token: 0x04000885 RID: 2181
		Misc_InternalError,
		// Token: 0x04000886 RID: 2182
		Misc_Timeout,
		// Token: 0x04000887 RID: 2183
		Misc_SteamConnectivity = 5005,
		// Token: 0x04000888 RID: 2184
		Misc_NoRelaySessionsToClient,
		// Token: 0x04000889 RID: 2185
		Misc_P2P_Rendezvous = 5008,
		// Token: 0x0400088A RID: 2186
		Misc_P2P_NAT_Firewall,
		// Token: 0x0400088B RID: 2187
		Misc_PeerSentNoConnection,
		// Token: 0x0400088C RID: 2188
		Misc_Max = 5999
	}
}
