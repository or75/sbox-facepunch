﻿using System;

namespace Sandbox
{
	// Token: 0x0200029C RID: 668
	public enum NetworkDisconnectionReason
	{
		// Token: 0x040012DB RID: 4827
		INVALID,
		// Token: 0x040012DC RID: 4828
		SHUTDOWN,
		// Token: 0x040012DD RID: 4829
		DISCONNECT_BY_USER,
		// Token: 0x040012DE RID: 4830
		DISCONNECT_BY_SERVER,
		// Token: 0x040012DF RID: 4831
		LOST,
		// Token: 0x040012E0 RID: 4832
		OVERFLOW,
		// Token: 0x040012E1 RID: 4833
		STEAM_BANNED,
		// Token: 0x040012E2 RID: 4834
		STEAM_INUSE,
		// Token: 0x040012E3 RID: 4835
		STEAM_TICKET,
		// Token: 0x040012E4 RID: 4836
		STEAM_LOGON,
		// Token: 0x040012E5 RID: 4837
		STEAM_AUTHCANCELLED,
		// Token: 0x040012E6 RID: 4838
		STEAM_AUTHALREADYUSED,
		// Token: 0x040012E7 RID: 4839
		STEAM_AUTHINVALID,
		// Token: 0x040012E8 RID: 4840
		STEAM_VACBANSTATE,
		// Token: 0x040012E9 RID: 4841
		STEAM_LOGGED_IN_ELSEWHERE,
		// Token: 0x040012EA RID: 4842
		STEAM_VAC_CHECK_TIMEDOUT,
		// Token: 0x040012EB RID: 4843
		STEAM_DROPPED,
		// Token: 0x040012EC RID: 4844
		STEAM_OWNERSHIP,
		// Token: 0x040012ED RID: 4845
		SERVERINFO_OVERFLOW,
		// Token: 0x040012EE RID: 4846
		TICKMSG_OVERFLOW,
		// Token: 0x040012EF RID: 4847
		STRINGTABLEMSG_OVERFLOW,
		// Token: 0x040012F0 RID: 4848
		DELTAENTMSG_OVERFLOW,
		// Token: 0x040012F1 RID: 4849
		TEMPENTMSG_OVERFLOW,
		// Token: 0x040012F2 RID: 4850
		SOUNDSMSG_OVERFLOW,
		// Token: 0x040012F3 RID: 4851
		SNAPSHOTOVERFLOW,
		// Token: 0x040012F4 RID: 4852
		SNAPSHOTERROR,
		// Token: 0x040012F5 RID: 4853
		RELIABLEOVERFLOW,
		// Token: 0x040012F6 RID: 4854
		BADDELTATICK,
		// Token: 0x040012F7 RID: 4855
		NOMORESPLITS,
		// Token: 0x040012F8 RID: 4856
		TIMEDOUT,
		// Token: 0x040012F9 RID: 4857
		DISCONNECTED,
		// Token: 0x040012FA RID: 4858
		LEAVINGSPLIT,
		// Token: 0x040012FB RID: 4859
		DIFFERENTCLASSTABLES,
		// Token: 0x040012FC RID: 4860
		BADRELAYPASSWORD,
		// Token: 0x040012FD RID: 4861
		BADSPECTATORPASSWORD,
		// Token: 0x040012FE RID: 4862
		HLTVRESTRICTED,
		// Token: 0x040012FF RID: 4863
		NOSPECTATORS,
		// Token: 0x04001300 RID: 4864
		HLTVUNAVAILABLE,
		// Token: 0x04001301 RID: 4865
		HLTVSTOP,
		// Token: 0x04001302 RID: 4866
		Kicked,
		// Token: 0x04001303 RID: 4867
		Banned,
		// Token: 0x04001304 RID: 4868
		Kickbanned,
		// Token: 0x04001305 RID: 4869
		HLTVDIRECT,
		// Token: 0x04001306 RID: 4870
		PURESERVER_CLIENTEXTRA,
		// Token: 0x04001307 RID: 4871
		PURESERVER_MISMATCH,
		// Token: 0x04001308 RID: 4872
		USERCMD,
		// Token: 0x04001309 RID: 4873
		REJECTED_BY_GAME,
		// Token: 0x0400130A RID: 4874
		MESSAGE_PARSE_ERROR,
		// Token: 0x0400130B RID: 4875
		INVALID_MESSAGE_ERROR,
		// Token: 0x0400130C RID: 4876
		BAD_SERVER_PASSWORD,
		// Token: 0x0400130D RID: 4877
		DIRECT_CONNECT_RESERVATION,
		// Token: 0x0400130E RID: 4878
		CONNECTION_FAILURE,
		// Token: 0x0400130F RID: 4879
		NO_PEER_GROUP_HANDLERS,
		// Token: 0x04001310 RID: 4880
		RECONNECTION,
		// Token: 0x04001311 RID: 4881
		LOOPSHUTDOWN,
		// Token: 0x04001312 RID: 4882
		LOOPDEACTIVATE,
		// Token: 0x04001313 RID: 4883
		HOST_ENDGAME,
		// Token: 0x04001314 RID: 4884
		LOOP_LEVELLOAD_ACTIVATE,
		// Token: 0x04001315 RID: 4885
		CREATE_SERVER_FAILED,
		// Token: 0x04001316 RID: 4886
		EXITING,
		// Token: 0x04001317 RID: 4887
		REQUEST_HOSTSTATE_IDLE,
		// Token: 0x04001318 RID: 4888
		REQUEST_HOSTSTATE_HLTVRELAY,
		// Token: 0x04001319 RID: 4889
		CLIENT_CONSISTENCY_FAIL,
		// Token: 0x0400131A RID: 4890
		CLIENT_UNABLE_TO_CRC_MAP,
		// Token: 0x0400131B RID: 4891
		CLIENT_NO_MAP,
		// Token: 0x0400131C RID: 4892
		CLIENT_DIFFERENT_MAP,
		// Token: 0x0400131D RID: 4893
		SERVER_REQUIRES_STEAM,
		// Token: 0x0400131E RID: 4894
		STEAM_DENY_MISC,
		// Token: 0x0400131F RID: 4895
		STEAM_DENY_BAD_ANTI_CHEAT,
		// Token: 0x04001320 RID: 4896
		SERVER_SHUTDOWN,
		// Token: 0x04001321 RID: 4897
		SPLITPACKET_SEND_OVERFLOW,
		// Token: 0x04001322 RID: 4898
		REPLAY_INCOMPATIBLE,
		// Token: 0x04001323 RID: 4899
		CONNECT_REQUEST_TIMEDOUT,
		// Token: 0x04001324 RID: 4900
		SERVER_INCOMPATIBLE,
		// Token: 0x04001325 RID: 4901
		LOCALPROBLEM_MANYRELAYS,
		// Token: 0x04001326 RID: 4902
		LOCALPROBLEM_HOSTEDSERVERPRIMARYRELAY,
		// Token: 0x04001327 RID: 4903
		LOCALPROBLEM_NETWORKCONFIG,
		// Token: 0x04001328 RID: 4904
		LOCALPROBLEM_OTHER,
		// Token: 0x04001329 RID: 4905
		REMOTE_TIMEOUT = 79,
		// Token: 0x0400132A RID: 4906
		REMOTE_TIMEOUT_CONNECTING,
		// Token: 0x0400132B RID: 4907
		REMOTE_OTHER,
		// Token: 0x0400132C RID: 4908
		REMOTE_BADCRYPT,
		// Token: 0x0400132D RID: 4909
		REMOTE_CERTNOTTRUSTED,
		// Token: 0x0400132E RID: 4910
		UNUSUAL,
		// Token: 0x0400132F RID: 4911
		INTERNAL_ERROR,
		// Token: 0x04001330 RID: 4912
		REJECT_BADCHALLENGE = 128,
		// Token: 0x04001331 RID: 4913
		REJECT_NOLOBBY,
		// Token: 0x04001332 RID: 4914
		REJECT_BACKGROUND_MAP,
		// Token: 0x04001333 RID: 4915
		REJECT_SINGLE_PLAYER,
		// Token: 0x04001334 RID: 4916
		REJECT_HIDDEN_GAME,
		// Token: 0x04001335 RID: 4917
		REJECT_LANRESTRICT,
		// Token: 0x04001336 RID: 4918
		REJECT_BADPASSWORD,
		// Token: 0x04001337 RID: 4919
		REJECT_SERVERFULL,
		// Token: 0x04001338 RID: 4920
		REJECT_INVALIDRESERVATION,
		// Token: 0x04001339 RID: 4921
		REJECT_FAILEDCHANNEL,
		// Token: 0x0400133A RID: 4922
		REJECT_CONNECT_FROM_LOBBY,
		// Token: 0x0400133B RID: 4923
		REJECT_RESERVED_FOR_LOBBY,
		// Token: 0x0400133C RID: 4924
		REJECT_INVALIDKEYLENGTH,
		// Token: 0x0400133D RID: 4925
		REJECT_OLDPROTOCOL,
		// Token: 0x0400133E RID: 4926
		REJECT_NEWPROTOCOL,
		// Token: 0x0400133F RID: 4927
		REJECT_INVALIDCONNECTION,
		// Token: 0x04001340 RID: 4928
		REJECT_INVALIDCERTLEN,
		// Token: 0x04001341 RID: 4929
		REJECT_INVALIDSTEAMCERTLEN,
		// Token: 0x04001342 RID: 4930
		REJECT_STEAM,
		// Token: 0x04001343 RID: 4931
		REJECT_SERVERAUTHDISABLED,
		// Token: 0x04001344 RID: 4932
		REJECT_SERVERCDKEYAUTHINVALID,
		// Token: 0x04001345 RID: 4933
		REJECT_BANNED
	}
}
