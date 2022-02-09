using System;

namespace Tools
{
	// Token: 0x020000B4 RID: 180
	internal enum StateFlag
	{
		// Token: 0x0400043A RID: 1082
		None,
		// Token: 0x0400043B RID: 1083
		Enabled,
		// Token: 0x0400043C RID: 1084
		Raised,
		// Token: 0x0400043D RID: 1085
		Sunken = 4,
		// Token: 0x0400043E RID: 1086
		Off = 8,
		// Token: 0x0400043F RID: 1087
		NoChange = 16,
		// Token: 0x04000440 RID: 1088
		On = 32,
		// Token: 0x04000441 RID: 1089
		DownArrow = 64,
		// Token: 0x04000442 RID: 1090
		Horizontal = 128,
		// Token: 0x04000443 RID: 1091
		HasFocus = 256,
		// Token: 0x04000444 RID: 1092
		Top = 512,
		// Token: 0x04000445 RID: 1093
		Bottom = 1024,
		// Token: 0x04000446 RID: 1094
		FocusAtBorder = 2048,
		// Token: 0x04000447 RID: 1095
		AutoRaise = 4096,
		// Token: 0x04000448 RID: 1096
		MouseOver = 8192,
		// Token: 0x04000449 RID: 1097
		UpArrow = 16384,
		// Token: 0x0400044A RID: 1098
		Selected = 32768,
		// Token: 0x0400044B RID: 1099
		Active = 65536,
		// Token: 0x0400044C RID: 1100
		Window = 131072,
		// Token: 0x0400044D RID: 1101
		Open = 262144,
		// Token: 0x0400044E RID: 1102
		Children = 524288,
		// Token: 0x0400044F RID: 1103
		Item = 1048576,
		// Token: 0x04000450 RID: 1104
		Sibling = 2097152,
		// Token: 0x04000451 RID: 1105
		Editing = 4194304,
		// Token: 0x04000452 RID: 1106
		KeyboardFocusChange = 8388608,
		// Token: 0x04000453 RID: 1107
		HasEditFocus = 16777216,
		// Token: 0x04000454 RID: 1108
		ReadOnly = 33554432,
		// Token: 0x04000455 RID: 1109
		Small = 67108864,
		// Token: 0x04000456 RID: 1110
		Mini = 134217728
	}
}
