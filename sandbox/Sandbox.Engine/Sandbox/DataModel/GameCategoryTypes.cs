using System;
using System.ComponentModel.DataAnnotations;

namespace Sandbox.DataModel
{
	// Token: 0x0200030F RID: 783
	public enum GameCategoryTypes
	{
		// Token: 0x0400158E RID: 5518
		[Display(Name = "None")]
		[Icon("sentiment_dissatisfied")]
		None,
		// Token: 0x0400158F RID: 5519
		[Display(Name = "Sandbox")]
		[Icon("construction")]
		Sandbox,
		// Token: 0x04001590 RID: 5520
		[Display(Name = "Tech Demos & Experiments")]
		[Icon("science")]
		TechDemos,
		// Token: 0x04001591 RID: 5521
		[Display(Name = "Sports")]
		[Icon("sports_volleyball")]
		Sports,
		// Token: 0x04001592 RID: 5522
		[Display(Name = "Shooter")]
		[Icon("adjust")]
		Shooter,
		// Token: 0x04001593 RID: 5523
		[Display(Name = "Obstacles & Parkour")]
		[Icon("nordic_walking")]
		Parkour,
		// Token: 0x04001594 RID: 5524
		[Display(Name = "Social")]
		[Icon("groups")]
		Social,
		// Token: 0x04001595 RID: 5525
		[Display(Name = "Meme")]
		[Icon("sentiment_very_satisfied")]
		Meme,
		// Token: 0x04001596 RID: 5526
		[Display(Name = "Roleplay")]
		[Icon("history_edu")]
		Roleplay,
		// Token: 0x04001597 RID: 5527
		[Display(Name = "Racing")]
		[Icon("sledding")]
		Racing,
		// Token: 0x04001598 RID: 5528
		[Display(Name = "Mystery")]
		[Icon("search")]
		Mystery,
		// Token: 0x04001599 RID: 5529
		[Display(Name = "Survival")]
		[Icon("cabin")]
		Survival,
		// Token: 0x0400159A RID: 5530
		[Display(Name = "Animals")]
		[Icon("pets")]
		Animals,
		// Token: 0x0400159B RID: 5531
		[Display(Name = "Food")]
		[Icon("lunch_dining")]
		Food,
		// Token: 0x0400159C RID: 5532
		[Display(Name = "Strategy")]
		[Icon("casino")]
		Strategy,
		// Token: 0x0400159D RID: 5533
		[Display(Name = "Space")]
		[Icon("public")]
		Space,
		// Token: 0x0400159E RID: 5534
		[Display(Name = "Fighting")]
		[Icon("sports_kabaddi")]
		Fighting,
		// Token: 0x0400159F RID: 5535
		[Display(Name = "Retro")]
		[Icon("elderly")]
		Retro,
		// Token: 0x040015A0 RID: 5536
		[Display(Name = "Music")]
		[Icon("music_note")]
		Music,
		// Token: 0x040015A1 RID: 5537
		[Display(Name = "Art")]
		[Icon("palette")]
		Art,
		// Token: 0x040015A2 RID: 5538
		[Display(Name = "Tycoon")]
		[Icon("location_city")]
		Tycoon,
		// Token: 0x040015A3 RID: 5539
		[Display(Name = "Streamer")]
		[Icon("live_tv")]
		Streamer
	}
}
