using System;

namespace Native
{
	// Token: 0x02000060 RID: 96
	internal enum EventType
	{
		// Token: 0x0400006B RID: 107
		None,
		// Token: 0x0400006C RID: 108
		Timer,
		// Token: 0x0400006D RID: 109
		MouseButtonPress,
		// Token: 0x0400006E RID: 110
		MouseButtonRelease,
		// Token: 0x0400006F RID: 111
		MouseButtonDblClick,
		// Token: 0x04000070 RID: 112
		MouseMove,
		// Token: 0x04000071 RID: 113
		KeyPress,
		// Token: 0x04000072 RID: 114
		KeyRelease,
		// Token: 0x04000073 RID: 115
		FocusIn,
		// Token: 0x04000074 RID: 116
		FocusOut,
		// Token: 0x04000075 RID: 117
		FocusAboutToChange = 23,
		// Token: 0x04000076 RID: 118
		Enter = 10,
		// Token: 0x04000077 RID: 119
		Leave,
		// Token: 0x04000078 RID: 120
		Paint,
		// Token: 0x04000079 RID: 121
		Move,
		// Token: 0x0400007A RID: 122
		Resize,
		// Token: 0x0400007B RID: 123
		Create,
		// Token: 0x0400007C RID: 124
		Destroy,
		// Token: 0x0400007D RID: 125
		Show,
		// Token: 0x0400007E RID: 126
		Hide,
		// Token: 0x0400007F RID: 127
		Close,
		// Token: 0x04000080 RID: 128
		Quit,
		// Token: 0x04000081 RID: 129
		ParentChange,
		// Token: 0x04000082 RID: 130
		ParentAboutToChange = 131,
		// Token: 0x04000083 RID: 131
		ThreadChange = 22,
		// Token: 0x04000084 RID: 132
		WindowActivate = 24,
		// Token: 0x04000085 RID: 133
		WindowDeactivate,
		// Token: 0x04000086 RID: 134
		ShowToParent,
		// Token: 0x04000087 RID: 135
		HideToParent,
		// Token: 0x04000088 RID: 136
		Wheel = 31,
		// Token: 0x04000089 RID: 137
		WindowTitleChange = 33,
		// Token: 0x0400008A RID: 138
		WindowIconChange,
		// Token: 0x0400008B RID: 139
		ApplicationWindowIconChange,
		// Token: 0x0400008C RID: 140
		ApplicationFontChange,
		// Token: 0x0400008D RID: 141
		ApplicationLayoutDirectionChange,
		// Token: 0x0400008E RID: 142
		ApplicationPaletteChange,
		// Token: 0x0400008F RID: 143
		PaletteChange,
		// Token: 0x04000090 RID: 144
		Clipboard,
		// Token: 0x04000091 RID: 145
		Speech = 42,
		// Token: 0x04000092 RID: 146
		MetaCall,
		// Token: 0x04000093 RID: 147
		SockAct = 50,
		// Token: 0x04000094 RID: 148
		WinEventAct = 132,
		// Token: 0x04000095 RID: 149
		DeferredDelete = 52,
		// Token: 0x04000096 RID: 150
		DragEnter = 60,
		// Token: 0x04000097 RID: 151
		DragMove,
		// Token: 0x04000098 RID: 152
		DragLeave,
		// Token: 0x04000099 RID: 153
		Drop,
		// Token: 0x0400009A RID: 154
		DragResponse,
		// Token: 0x0400009B RID: 155
		ChildAdded = 68,
		// Token: 0x0400009C RID: 156
		ChildPolished,
		// Token: 0x0400009D RID: 157
		ChildRemoved = 71,
		// Token: 0x0400009E RID: 158
		ShowWindowRequest = 73,
		// Token: 0x0400009F RID: 159
		PolishRequest,
		// Token: 0x040000A0 RID: 160
		Polish,
		// Token: 0x040000A1 RID: 161
		LayoutRequest,
		// Token: 0x040000A2 RID: 162
		UpdateRequest,
		// Token: 0x040000A3 RID: 163
		UpdateLater,
		// Token: 0x040000A4 RID: 164
		EmbeddingControl,
		// Token: 0x040000A5 RID: 165
		ActivateControl,
		// Token: 0x040000A6 RID: 166
		DeactivateControl,
		// Token: 0x040000A7 RID: 167
		ContextMenu,
		// Token: 0x040000A8 RID: 168
		InputMethod,
		// Token: 0x040000A9 RID: 169
		TabletMove = 87,
		// Token: 0x040000AA RID: 170
		LocaleChange,
		// Token: 0x040000AB RID: 171
		LanguageChange,
		// Token: 0x040000AC RID: 172
		LayoutDirectionChange,
		// Token: 0x040000AD RID: 173
		Style,
		// Token: 0x040000AE RID: 174
		TabletPress,
		// Token: 0x040000AF RID: 175
		TabletRelease,
		// Token: 0x040000B0 RID: 176
		OkRequest,
		// Token: 0x040000B1 RID: 177
		HelpRequest,
		// Token: 0x040000B2 RID: 178
		IconDrag,
		// Token: 0x040000B3 RID: 179
		FontChange,
		// Token: 0x040000B4 RID: 180
		EnabledChange,
		// Token: 0x040000B5 RID: 181
		ActivationChange,
		// Token: 0x040000B6 RID: 182
		StyleChange,
		// Token: 0x040000B7 RID: 183
		IconTextChange,
		// Token: 0x040000B8 RID: 184
		ModifiedChange,
		// Token: 0x040000B9 RID: 185
		MouseTrackingChange = 109,
		// Token: 0x040000BA RID: 186
		WindowBlocked = 103,
		// Token: 0x040000BB RID: 187
		WindowUnblocked,
		// Token: 0x040000BC RID: 188
		WindowStateChange,
		// Token: 0x040000BD RID: 189
		ReadOnlyChange,
		// Token: 0x040000BE RID: 190
		ToolTip = 110,
		// Token: 0x040000BF RID: 191
		WhatsThis,
		// Token: 0x040000C0 RID: 192
		StatusTip,
		// Token: 0x040000C1 RID: 193
		ActionChanged,
		// Token: 0x040000C2 RID: 194
		ActionAdded,
		// Token: 0x040000C3 RID: 195
		ActionRemoved,
		// Token: 0x040000C4 RID: 196
		FileOpen,
		// Token: 0x040000C5 RID: 197
		Shortcut,
		// Token: 0x040000C6 RID: 198
		ShortcutOverride = 51,
		// Token: 0x040000C7 RID: 199
		WhatsThisClicked = 118,
		// Token: 0x040000C8 RID: 200
		ToolBarChange = 120,
		// Token: 0x040000C9 RID: 201
		ApplicationActivate,
		// Token: 0x040000CA RID: 202
		ApplicationActivated = 121,
		// Token: 0x040000CB RID: 203
		ApplicationDeactivate,
		// Token: 0x040000CC RID: 204
		ApplicationDeactivated = 122,
		// Token: 0x040000CD RID: 205
		QueryWhatsThis,
		// Token: 0x040000CE RID: 206
		EnterWhatsThisMode,
		// Token: 0x040000CF RID: 207
		LeaveWhatsThisMode,
		// Token: 0x040000D0 RID: 208
		ZOrderChange,
		// Token: 0x040000D1 RID: 209
		HoverEnter,
		// Token: 0x040000D2 RID: 210
		HoverLeave,
		// Token: 0x040000D3 RID: 211
		HoverMove,
		// Token: 0x040000D4 RID: 212
		EnterEditFocus = 150,
		// Token: 0x040000D5 RID: 213
		LeaveEditFocus,
		// Token: 0x040000D6 RID: 214
		AcceptDropsChange,
		// Token: 0x040000D7 RID: 215
		ZeroTimerEvent = 154,
		// Token: 0x040000D8 RID: 216
		GraphicsSceneMouseMove,
		// Token: 0x040000D9 RID: 217
		GraphicsSceneMousePress,
		// Token: 0x040000DA RID: 218
		GraphicsSceneMouseRelease,
		// Token: 0x040000DB RID: 219
		GraphicsSceneMouseDoubleClick,
		// Token: 0x040000DC RID: 220
		GraphicsSceneContextMenu,
		// Token: 0x040000DD RID: 221
		GraphicsSceneHoverEnter,
		// Token: 0x040000DE RID: 222
		GraphicsSceneHoverMove,
		// Token: 0x040000DF RID: 223
		GraphicsSceneHoverLeave,
		// Token: 0x040000E0 RID: 224
		GraphicsSceneHelp,
		// Token: 0x040000E1 RID: 225
		GraphicsSceneDragEnter,
		// Token: 0x040000E2 RID: 226
		GraphicsSceneDragMove,
		// Token: 0x040000E3 RID: 227
		GraphicsSceneDragLeave,
		// Token: 0x040000E4 RID: 228
		GraphicsSceneDrop,
		// Token: 0x040000E5 RID: 229
		GraphicsSceneWheel,
		// Token: 0x040000E6 RID: 230
		KeyboardLayoutChange,
		// Token: 0x040000E7 RID: 231
		DynamicPropertyChange,
		// Token: 0x040000E8 RID: 232
		TabletEnterProximity,
		// Token: 0x040000E9 RID: 233
		TabletLeaveProximity,
		// Token: 0x040000EA RID: 234
		NonClientAreaMouseMove,
		// Token: 0x040000EB RID: 235
		NonClientAreaMouseButtonPress,
		// Token: 0x040000EC RID: 236
		NonClientAreaMouseButtonRelease,
		// Token: 0x040000ED RID: 237
		NonClientAreaMouseButtonDblClick,
		// Token: 0x040000EE RID: 238
		MacSizeChange,
		// Token: 0x040000EF RID: 239
		ContentsRectChange,
		// Token: 0x040000F0 RID: 240
		MacGLWindowChange,
		// Token: 0x040000F1 RID: 241
		FutureCallOut,
		// Token: 0x040000F2 RID: 242
		GraphicsSceneResize,
		// Token: 0x040000F3 RID: 243
		GraphicsSceneMove,
		// Token: 0x040000F4 RID: 244
		CursorChange,
		// Token: 0x040000F5 RID: 245
		ToolTipChange,
		// Token: 0x040000F6 RID: 246
		NetworkReplyUpdated,
		// Token: 0x040000F7 RID: 247
		GrabMouse,
		// Token: 0x040000F8 RID: 248
		UngrabMouse,
		// Token: 0x040000F9 RID: 249
		GrabKeyboard,
		// Token: 0x040000FA RID: 250
		UngrabKeyboard,
		// Token: 0x040000FB RID: 251
		MacGLClearDrawable = 191,
		// Token: 0x040000FC RID: 252
		StateMachineSignal,
		// Token: 0x040000FD RID: 253
		StateMachineWrapped,
		// Token: 0x040000FE RID: 254
		TouchBegin,
		// Token: 0x040000FF RID: 255
		TouchUpdate,
		// Token: 0x04000100 RID: 256
		TouchEnd,
		// Token: 0x04000101 RID: 257
		NativeGesture,
		// Token: 0x04000102 RID: 258
		RequestSoftwareInputPanel = 199,
		// Token: 0x04000103 RID: 259
		CloseSoftwareInputPanel,
		// Token: 0x04000104 RID: 260
		WinIdChange = 203,
		// Token: 0x04000105 RID: 261
		Gesture = 198,
		// Token: 0x04000106 RID: 262
		GestureOverride = 202,
		// Token: 0x04000107 RID: 263
		ScrollPrepare = 204,
		// Token: 0x04000108 RID: 264
		Scroll,
		// Token: 0x04000109 RID: 265
		Expose,
		// Token: 0x0400010A RID: 266
		InputMethodQuery,
		// Token: 0x0400010B RID: 267
		OrientationChange,
		// Token: 0x0400010C RID: 268
		TouchCancel,
		// Token: 0x0400010D RID: 269
		ThemeChange,
		// Token: 0x0400010E RID: 270
		SockClose,
		// Token: 0x0400010F RID: 271
		PlatformPanel,
		// Token: 0x04000110 RID: 272
		StyleAnimationUpdate,
		// Token: 0x04000111 RID: 273
		ApplicationStateChange,
		// Token: 0x04000112 RID: 274
		WindowChangeInternal,
		// Token: 0x04000113 RID: 275
		ScreenChangeInternal,
		// Token: 0x04000114 RID: 276
		PlatformSurface,
		// Token: 0x04000115 RID: 277
		Pointer,
		// Token: 0x04000116 RID: 278
		TabletTrackingChange,
		// Token: 0x04000117 RID: 279
		User = 1000,
		// Token: 0x04000118 RID: 280
		MaxUser = 65535
	}
}
