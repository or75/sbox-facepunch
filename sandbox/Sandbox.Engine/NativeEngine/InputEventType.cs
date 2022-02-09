using System;

namespace NativeEngine
{
	// Token: 0x0200025B RID: 603
	internal enum InputEventType
	{
		// Token: 0x04001074 RID: 4212
		ButtonPressed,
		// Token: 0x04001075 RID: 4213
		ButtonReleased,
		// Token: 0x04001076 RID: 4214
		ButtonDoubleClick,
		// Token: 0x04001077 RID: 4215
		IE_AnalogValueChanged,
		// Token: 0x04001078 RID: 4216
		IE_ButtonPressedRepeating,
		// Token: 0x04001079 RID: 4217
		CursorPositionChanged,
		// Token: 0x0400107A RID: 4218
		IE_LastStandardEvent,
		// Token: 0x0400107B RID: 4219
		IE_FirstSystemEvent = 100,
		// Token: 0x0400107C RID: 4220
		IE_Quit = 100,
		// Token: 0x0400107D RID: 4221
		IE_ControllerInserted,
		// Token: 0x0400107E RID: 4222
		IE_ControllerUnplugged,
		// Token: 0x0400107F RID: 4223
		IE_Close,
		// Token: 0x04001080 RID: 4224
		IE_WindowSizeChanged,
		// Token: 0x04001081 RID: 4225
		IE_ActivateApp,
		// Token: 0x04001082 RID: 4226
		IE_ActivateWindow,
		// Token: 0x04001083 RID: 4227
		IE_WindowMove,
		// Token: 0x04001084 RID: 4228
		IE_CopyData,
		// Token: 0x04001085 RID: 4229
		IE_MonitorOrientationChanged,
		// Token: 0x04001086 RID: 4230
		IE_LastSystemEvent,
		// Token: 0x04001087 RID: 4231
		KeyTyped = 200,
		// Token: 0x04001088 RID: 4232
		KeyCodeTyped,
		// Token: 0x04001089 RID: 4233
		IE_KeyCodeReleased,
		// Token: 0x0400108A RID: 4234
		IE_InputLanguageChanged,
		// Token: 0x0400108B RID: 4235
		IE_IMESetWindow,
		// Token: 0x0400108C RID: 4236
		IE_IMEStartComposition,
		// Token: 0x0400108D RID: 4237
		IE_IMEComposition,
		// Token: 0x0400108E RID: 4238
		IE_IMEEndComposition,
		// Token: 0x0400108F RID: 4239
		IE_IMEShowCandidates,
		// Token: 0x04001090 RID: 4240
		IE_IMEChangeCandidates,
		// Token: 0x04001091 RID: 4241
		IE_IMECloseCandidates,
		// Token: 0x04001092 RID: 4242
		IE_IMERecomputeModes,
		// Token: 0x04001093 RID: 4243
		IE_MultiTouchData,
		// Token: 0x04001094 RID: 4244
		IE_LastUIEvent,
		// Token: 0x04001095 RID: 4245
		IE_FirstVguiEvent = 1000,
		// Token: 0x04001096 RID: 4246
		IE_FirstAppEvent = 2000
	}
}
