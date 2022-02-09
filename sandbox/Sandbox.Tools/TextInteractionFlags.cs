using System;

// Token: 0x02000034 RID: 52
internal enum TextInteractionFlags
{
	// Token: 0x04000032 RID: 50
	NoTextInteraction,
	// Token: 0x04000033 RID: 51
	TextSelectableByMouse,
	// Token: 0x04000034 RID: 52
	TextSelectableByKeyboard,
	// Token: 0x04000035 RID: 53
	LinksAccessibleByMouse = 4,
	// Token: 0x04000036 RID: 54
	LinksAccessibleByKeyboard = 8,
	// Token: 0x04000037 RID: 55
	TextEditable = 16,
	// Token: 0x04000038 RID: 56
	TextEditorInteraction = 19,
	// Token: 0x04000039 RID: 57
	TextBrowserInteraction = 13
}
