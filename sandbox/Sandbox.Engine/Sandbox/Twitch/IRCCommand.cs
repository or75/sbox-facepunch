using System;

namespace Sandbox.Twitch
{
	// Token: 0x020002DF RID: 735
	internal enum IRCCommand
	{
		// Token: 0x040014EC RID: 5356
		Unknown,
		// Token: 0x040014ED RID: 5357
		PrivMsg,
		// Token: 0x040014EE RID: 5358
		Notice,
		// Token: 0x040014EF RID: 5359
		Ping,
		// Token: 0x040014F0 RID: 5360
		Pong,
		// Token: 0x040014F1 RID: 5361
		Join,
		// Token: 0x040014F2 RID: 5362
		Part,
		// Token: 0x040014F3 RID: 5363
		HostTarget,
		// Token: 0x040014F4 RID: 5364
		ClearChat,
		// Token: 0x040014F5 RID: 5365
		ClearMsg,
		// Token: 0x040014F6 RID: 5366
		UserState,
		// Token: 0x040014F7 RID: 5367
		GlobalUserState,
		// Token: 0x040014F8 RID: 5368
		Nick,
		// Token: 0x040014F9 RID: 5369
		Pass,
		// Token: 0x040014FA RID: 5370
		Cap,
		// Token: 0x040014FB RID: 5371
		RPL_001,
		// Token: 0x040014FC RID: 5372
		RPL_002,
		// Token: 0x040014FD RID: 5373
		RPL_003,
		// Token: 0x040014FE RID: 5374
		RPL_004,
		// Token: 0x040014FF RID: 5375
		RPL_353,
		// Token: 0x04001500 RID: 5376
		RPL_366,
		// Token: 0x04001501 RID: 5377
		RPL_372,
		// Token: 0x04001502 RID: 5378
		RPL_375,
		// Token: 0x04001503 RID: 5379
		RPL_376,
		// Token: 0x04001504 RID: 5380
		Whisper,
		// Token: 0x04001505 RID: 5381
		RoomState,
		// Token: 0x04001506 RID: 5382
		Reconnect,
		// Token: 0x04001507 RID: 5383
		ServerChange,
		// Token: 0x04001508 RID: 5384
		UserNotice,
		// Token: 0x04001509 RID: 5385
		Mode
	}
}
