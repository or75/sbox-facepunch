using System;
using System.ComponentModel.DataAnnotations;

namespace Sandbox.DataModel
{
	// Token: 0x0200030E RID: 782
	public enum GameNetworkType
	{
		// Token: 0x0400158A RID: 5514
		[Display(Name = "Multi Player")]
		[Icon("sentiment_dissatisfied")]
		Multiplayer,
		// Token: 0x0400158B RID: 5515
		[Display(Name = "Single Player")]
		[Icon("sentiment_dissatisfied")]
		Singleplayer,
		// Token: 0x0400158C RID: 5516
		[Display(Name = "Custom")]
		[Icon("sentiment_dissatisfied")]
		Custom
	}
}
