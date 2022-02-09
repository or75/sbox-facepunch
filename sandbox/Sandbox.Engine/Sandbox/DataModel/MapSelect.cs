using System;
using System.ComponentModel.DataAnnotations;

namespace Sandbox.DataModel
{
	// Token: 0x0200030D RID: 781
	public enum MapSelect
	{
		// Token: 0x04001585 RID: 5509
		[Display(Name = "Unrestricted")]
		[Icon("sentiment_dissatisfied")]
		Unrestricted,
		// Token: 0x04001586 RID: 5510
		[Display(Name = "Hidden")]
		[Icon("sentiment_dissatisfied")]
		Hidden,
		// Token: 0x04001587 RID: 5511
		[Display(Name = "Any With Support")]
		[Icon("sentiment_dissatisfied")]
		Tagged,
		// Token: 0x04001588 RID: 5512
		[Display(Name = "Official Maps Only")]
		[Icon("sentiment_dissatisfied")]
		Official
	}
}
