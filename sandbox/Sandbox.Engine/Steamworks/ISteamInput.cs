using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x02000029 RID: 41
	internal class ISteamInput : SteamInterface
	{
		// Token: 0x0600026C RID: 620 RVA: 0x00004EC5 File Offset: 0x000030C5
		internal ISteamInput(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x0600026D RID: 621
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamInput_v006();

		// Token: 0x0600026E RID: 622 RVA: 0x00004ED4 File Offset: 0x000030D4
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamInput.SteamAPI_SteamInput_v006();
		}

		// Token: 0x0600026F RID: 623
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_Init")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _Init(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bExplicitlyCallRunFrame);

		// Token: 0x06000270 RID: 624 RVA: 0x00004EDB File Offset: 0x000030DB
		internal bool Init([MarshalAs(UnmanagedType.U1)] bool bExplicitlyCallRunFrame)
		{
			return ISteamInput._Init(this.Self, bExplicitlyCallRunFrame);
		}

		// Token: 0x06000271 RID: 625
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_Shutdown")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _Shutdown(IntPtr self);

		// Token: 0x06000272 RID: 626 RVA: 0x00004EE9 File Offset: 0x000030E9
		internal bool Shutdown()
		{
			return ISteamInput._Shutdown(this.Self);
		}

		// Token: 0x06000273 RID: 627
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_SetInputActionManifestFilePath")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetInputActionManifestFilePath(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchInputActionManifestAbsolutePath);

		// Token: 0x06000274 RID: 628 RVA: 0x00004EF6 File Offset: 0x000030F6
		internal bool SetInputActionManifestFilePath([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchInputActionManifestAbsolutePath)
		{
			return ISteamInput._SetInputActionManifestFilePath(this.Self, pchInputActionManifestAbsolutePath);
		}

		// Token: 0x06000275 RID: 629
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_RunFrame")]
		private static extern void _RunFrame(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bReservedValue);

		// Token: 0x06000276 RID: 630 RVA: 0x00004F04 File Offset: 0x00003104
		internal void RunFrame([MarshalAs(UnmanagedType.U1)] bool bReservedValue)
		{
			ISteamInput._RunFrame(this.Self, bReservedValue);
		}

		// Token: 0x06000277 RID: 631
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_BWaitForData")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BWaitForData(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bWaitForever, uint unTimeout);

		// Token: 0x06000278 RID: 632 RVA: 0x00004F12 File Offset: 0x00003112
		internal bool BWaitForData([MarshalAs(UnmanagedType.U1)] bool bWaitForever, uint unTimeout)
		{
			return ISteamInput._BWaitForData(this.Self, bWaitForever, unTimeout);
		}

		// Token: 0x06000279 RID: 633
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_BNewDataAvailable")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BNewDataAvailable(IntPtr self);

		// Token: 0x0600027A RID: 634 RVA: 0x00004F21 File Offset: 0x00003121
		internal bool BNewDataAvailable()
		{
			return ISteamInput._BNewDataAvailable(this.Self);
		}

		// Token: 0x0600027B RID: 635
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetConnectedControllers")]
		private static extern int _GetConnectedControllers(IntPtr self, [In] [Out] InputHandle_t[] handlesOut);

		// Token: 0x0600027C RID: 636 RVA: 0x00004F2E File Offset: 0x0000312E
		internal int GetConnectedControllers([In] [Out] InputHandle_t[] handlesOut)
		{
			return ISteamInput._GetConnectedControllers(this.Self, handlesOut);
		}

		// Token: 0x0600027D RID: 637
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_EnableDeviceCallbacks")]
		private static extern void _EnableDeviceCallbacks(IntPtr self);

		// Token: 0x0600027E RID: 638 RVA: 0x00004F3C File Offset: 0x0000313C
		internal void EnableDeviceCallbacks()
		{
			ISteamInput._EnableDeviceCallbacks(this.Self);
		}

		// Token: 0x0600027F RID: 639
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetActionSetHandle")]
		private static extern InputActionSetHandle_t _GetActionSetHandle(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszActionSetName);

		// Token: 0x06000280 RID: 640 RVA: 0x00004F49 File Offset: 0x00003149
		internal InputActionSetHandle_t GetActionSetHandle([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszActionSetName)
		{
			return ISteamInput._GetActionSetHandle(this.Self, pszActionSetName);
		}

		// Token: 0x06000281 RID: 641
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_ActivateActionSet")]
		private static extern void _ActivateActionSet(IntPtr self, InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle);

		// Token: 0x06000282 RID: 642 RVA: 0x00004F57 File Offset: 0x00003157
		internal void ActivateActionSet(InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle)
		{
			ISteamInput._ActivateActionSet(this.Self, inputHandle, actionSetHandle);
		}

		// Token: 0x06000283 RID: 643
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetCurrentActionSet")]
		private static extern InputActionSetHandle_t _GetCurrentActionSet(IntPtr self, InputHandle_t inputHandle);

		// Token: 0x06000284 RID: 644 RVA: 0x00004F66 File Offset: 0x00003166
		internal InputActionSetHandle_t GetCurrentActionSet(InputHandle_t inputHandle)
		{
			return ISteamInput._GetCurrentActionSet(this.Self, inputHandle);
		}

		// Token: 0x06000285 RID: 645
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_ActivateActionSetLayer")]
		private static extern void _ActivateActionSetLayer(IntPtr self, InputHandle_t inputHandle, InputActionSetHandle_t actionSetLayerHandle);

		// Token: 0x06000286 RID: 646 RVA: 0x00004F74 File Offset: 0x00003174
		internal void ActivateActionSetLayer(InputHandle_t inputHandle, InputActionSetHandle_t actionSetLayerHandle)
		{
			ISteamInput._ActivateActionSetLayer(this.Self, inputHandle, actionSetLayerHandle);
		}

		// Token: 0x06000287 RID: 647
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_DeactivateActionSetLayer")]
		private static extern void _DeactivateActionSetLayer(IntPtr self, InputHandle_t inputHandle, InputActionSetHandle_t actionSetLayerHandle);

		// Token: 0x06000288 RID: 648 RVA: 0x00004F83 File Offset: 0x00003183
		internal void DeactivateActionSetLayer(InputHandle_t inputHandle, InputActionSetHandle_t actionSetLayerHandle)
		{
			ISteamInput._DeactivateActionSetLayer(this.Self, inputHandle, actionSetLayerHandle);
		}

		// Token: 0x06000289 RID: 649
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_DeactivateAllActionSetLayers")]
		private static extern void _DeactivateAllActionSetLayers(IntPtr self, InputHandle_t inputHandle);

		// Token: 0x0600028A RID: 650 RVA: 0x00004F92 File Offset: 0x00003192
		internal void DeactivateAllActionSetLayers(InputHandle_t inputHandle)
		{
			ISteamInput._DeactivateAllActionSetLayers(this.Self, inputHandle);
		}

		// Token: 0x0600028B RID: 651
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetActiveActionSetLayers")]
		private static extern int _GetActiveActionSetLayers(IntPtr self, InputHandle_t inputHandle, [In] [Out] InputActionSetHandle_t[] handlesOut);

		// Token: 0x0600028C RID: 652 RVA: 0x00004FA0 File Offset: 0x000031A0
		internal int GetActiveActionSetLayers(InputHandle_t inputHandle, [In] [Out] InputActionSetHandle_t[] handlesOut)
		{
			return ISteamInput._GetActiveActionSetLayers(this.Self, inputHandle, handlesOut);
		}

		// Token: 0x0600028D RID: 653
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetDigitalActionHandle")]
		private static extern InputDigitalActionHandle_t _GetDigitalActionHandle(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszActionName);

		// Token: 0x0600028E RID: 654 RVA: 0x00004FAF File Offset: 0x000031AF
		internal InputDigitalActionHandle_t GetDigitalActionHandle([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszActionName)
		{
			return ISteamInput._GetDigitalActionHandle(this.Self, pszActionName);
		}

		// Token: 0x0600028F RID: 655
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetDigitalActionData")]
		private static extern DigitalState _GetDigitalActionData(IntPtr self, InputHandle_t inputHandle, InputDigitalActionHandle_t digitalActionHandle);

		// Token: 0x06000290 RID: 656 RVA: 0x00004FBD File Offset: 0x000031BD
		internal DigitalState GetDigitalActionData(InputHandle_t inputHandle, InputDigitalActionHandle_t digitalActionHandle)
		{
			return ISteamInput._GetDigitalActionData(this.Self, inputHandle, digitalActionHandle);
		}

		// Token: 0x06000291 RID: 657
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetDigitalActionOrigins")]
		private static extern int _GetDigitalActionOrigins(IntPtr self, InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle, InputDigitalActionHandle_t digitalActionHandle, [In] [Out] InputActionOrigin[] originsOut);

		// Token: 0x06000292 RID: 658 RVA: 0x00004FCC File Offset: 0x000031CC
		internal int GetDigitalActionOrigins(InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle, InputDigitalActionHandle_t digitalActionHandle, [In] [Out] InputActionOrigin[] originsOut)
		{
			return ISteamInput._GetDigitalActionOrigins(this.Self, inputHandle, actionSetHandle, digitalActionHandle, originsOut);
		}

		// Token: 0x06000293 RID: 659
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetStringForDigitalActionName")]
		private static extern Utf8StringPointer _GetStringForDigitalActionName(IntPtr self, InputDigitalActionHandle_t eActionHandle);

		// Token: 0x06000294 RID: 660 RVA: 0x00004FDE File Offset: 0x000031DE
		internal string GetStringForDigitalActionName(InputDigitalActionHandle_t eActionHandle)
		{
			return ISteamInput._GetStringForDigitalActionName(this.Self, eActionHandle);
		}

		// Token: 0x06000295 RID: 661
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetAnalogActionHandle")]
		private static extern InputAnalogActionHandle_t _GetAnalogActionHandle(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszActionName);

		// Token: 0x06000296 RID: 662 RVA: 0x00004FF1 File Offset: 0x000031F1
		internal InputAnalogActionHandle_t GetAnalogActionHandle([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszActionName)
		{
			return ISteamInput._GetAnalogActionHandle(this.Self, pszActionName);
		}

		// Token: 0x06000297 RID: 663
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetAnalogActionData")]
		private static extern AnalogState _GetAnalogActionData(IntPtr self, InputHandle_t inputHandle, InputAnalogActionHandle_t analogActionHandle);

		// Token: 0x06000298 RID: 664 RVA: 0x00004FFF File Offset: 0x000031FF
		internal AnalogState GetAnalogActionData(InputHandle_t inputHandle, InputAnalogActionHandle_t analogActionHandle)
		{
			return ISteamInput._GetAnalogActionData(this.Self, inputHandle, analogActionHandle);
		}

		// Token: 0x06000299 RID: 665
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetAnalogActionOrigins")]
		private static extern int _GetAnalogActionOrigins(IntPtr self, InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle, InputAnalogActionHandle_t analogActionHandle, [In] [Out] InputActionOrigin[] originsOut);

		// Token: 0x0600029A RID: 666 RVA: 0x0000500E File Offset: 0x0000320E
		internal int GetAnalogActionOrigins(InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle, InputAnalogActionHandle_t analogActionHandle, [In] [Out] InputActionOrigin[] originsOut)
		{
			return ISteamInput._GetAnalogActionOrigins(this.Self, inputHandle, actionSetHandle, analogActionHandle, originsOut);
		}

		// Token: 0x0600029B RID: 667
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetGlyphPNGForActionOrigin")]
		private static extern Utf8StringPointer _GetGlyphPNGForActionOrigin(IntPtr self, InputActionOrigin eOrigin, GlyphSize eSize, uint unFlags);

		// Token: 0x0600029C RID: 668 RVA: 0x00005020 File Offset: 0x00003220
		internal string GetGlyphPNGForActionOrigin(InputActionOrigin eOrigin, GlyphSize eSize, uint unFlags)
		{
			return ISteamInput._GetGlyphPNGForActionOrigin(this.Self, eOrigin, eSize, unFlags);
		}

		// Token: 0x0600029D RID: 669
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetGlyphSVGForActionOrigin")]
		private static extern Utf8StringPointer _GetGlyphSVGForActionOrigin(IntPtr self, InputActionOrigin eOrigin, uint unFlags);

		// Token: 0x0600029E RID: 670 RVA: 0x00005035 File Offset: 0x00003235
		internal string GetGlyphSVGForActionOrigin(InputActionOrigin eOrigin, uint unFlags)
		{
			return ISteamInput._GetGlyphSVGForActionOrigin(this.Self, eOrigin, unFlags);
		}

		// Token: 0x0600029F RID: 671
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetGlyphForActionOrigin_Legacy")]
		private static extern Utf8StringPointer _GetGlyphForActionOrigin_Legacy(IntPtr self, InputActionOrigin eOrigin);

		// Token: 0x060002A0 RID: 672 RVA: 0x00005049 File Offset: 0x00003249
		internal string GetGlyphForActionOrigin_Legacy(InputActionOrigin eOrigin)
		{
			return ISteamInput._GetGlyphForActionOrigin_Legacy(this.Self, eOrigin);
		}

		// Token: 0x060002A1 RID: 673
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetStringForActionOrigin")]
		private static extern Utf8StringPointer _GetStringForActionOrigin(IntPtr self, InputActionOrigin eOrigin);

		// Token: 0x060002A2 RID: 674 RVA: 0x0000505C File Offset: 0x0000325C
		internal string GetStringForActionOrigin(InputActionOrigin eOrigin)
		{
			return ISteamInput._GetStringForActionOrigin(this.Self, eOrigin);
		}

		// Token: 0x060002A3 RID: 675
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetStringForAnalogActionName")]
		private static extern Utf8StringPointer _GetStringForAnalogActionName(IntPtr self, InputAnalogActionHandle_t eActionHandle);

		// Token: 0x060002A4 RID: 676 RVA: 0x0000506F File Offset: 0x0000326F
		internal string GetStringForAnalogActionName(InputAnalogActionHandle_t eActionHandle)
		{
			return ISteamInput._GetStringForAnalogActionName(this.Self, eActionHandle);
		}

		// Token: 0x060002A5 RID: 677
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_StopAnalogActionMomentum")]
		private static extern void _StopAnalogActionMomentum(IntPtr self, InputHandle_t inputHandle, InputAnalogActionHandle_t eAction);

		// Token: 0x060002A6 RID: 678 RVA: 0x00005082 File Offset: 0x00003282
		internal void StopAnalogActionMomentum(InputHandle_t inputHandle, InputAnalogActionHandle_t eAction)
		{
			ISteamInput._StopAnalogActionMomentum(this.Self, inputHandle, eAction);
		}

		// Token: 0x060002A7 RID: 679
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetMotionData")]
		private static extern MotionState _GetMotionData(IntPtr self, InputHandle_t inputHandle);

		// Token: 0x060002A8 RID: 680 RVA: 0x00005091 File Offset: 0x00003291
		internal MotionState GetMotionData(InputHandle_t inputHandle)
		{
			return ISteamInput._GetMotionData(this.Self, inputHandle);
		}

		// Token: 0x060002A9 RID: 681
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_TriggerVibration")]
		private static extern void _TriggerVibration(IntPtr self, InputHandle_t inputHandle, ushort usLeftSpeed, ushort usRightSpeed);

		// Token: 0x060002AA RID: 682 RVA: 0x0000509F File Offset: 0x0000329F
		internal void TriggerVibration(InputHandle_t inputHandle, ushort usLeftSpeed, ushort usRightSpeed)
		{
			ISteamInput._TriggerVibration(this.Self, inputHandle, usLeftSpeed, usRightSpeed);
		}

		// Token: 0x060002AB RID: 683
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_TriggerVibrationExtended")]
		private static extern void _TriggerVibrationExtended(IntPtr self, InputHandle_t inputHandle, ushort usLeftSpeed, ushort usRightSpeed, ushort usLeftTriggerSpeed, ushort usRightTriggerSpeed);

		// Token: 0x060002AC RID: 684 RVA: 0x000050AF File Offset: 0x000032AF
		internal void TriggerVibrationExtended(InputHandle_t inputHandle, ushort usLeftSpeed, ushort usRightSpeed, ushort usLeftTriggerSpeed, ushort usRightTriggerSpeed)
		{
			ISteamInput._TriggerVibrationExtended(this.Self, inputHandle, usLeftSpeed, usRightSpeed, usLeftTriggerSpeed, usRightTriggerSpeed);
		}

		// Token: 0x060002AD RID: 685
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_TriggerSimpleHapticEvent")]
		private static extern void _TriggerSimpleHapticEvent(IntPtr self, InputHandle_t inputHandle, ControllerHapticLocation eHapticLocation, byte nIntensity, char nGainDB, byte nOtherIntensity, char nOtherGainDB);

		// Token: 0x060002AE RID: 686 RVA: 0x000050C3 File Offset: 0x000032C3
		internal void TriggerSimpleHapticEvent(InputHandle_t inputHandle, ControllerHapticLocation eHapticLocation, byte nIntensity, char nGainDB, byte nOtherIntensity, char nOtherGainDB)
		{
			ISteamInput._TriggerSimpleHapticEvent(this.Self, inputHandle, eHapticLocation, nIntensity, nGainDB, nOtherIntensity, nOtherGainDB);
		}

		// Token: 0x060002AF RID: 687
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_SetLEDColor")]
		private static extern void _SetLEDColor(IntPtr self, InputHandle_t inputHandle, byte nColorR, byte nColorG, byte nColorB, uint nFlags);

		// Token: 0x060002B0 RID: 688 RVA: 0x000050D9 File Offset: 0x000032D9
		internal void SetLEDColor(InputHandle_t inputHandle, byte nColorR, byte nColorG, byte nColorB, uint nFlags)
		{
			ISteamInput._SetLEDColor(this.Self, inputHandle, nColorR, nColorG, nColorB, nFlags);
		}

		// Token: 0x060002B1 RID: 689
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_Legacy_TriggerHapticPulse")]
		private static extern void _Legacy_TriggerHapticPulse(IntPtr self, InputHandle_t inputHandle, SteamControllerPad eTargetPad, ushort usDurationMicroSec);

		// Token: 0x060002B2 RID: 690 RVA: 0x000050ED File Offset: 0x000032ED
		internal void Legacy_TriggerHapticPulse(InputHandle_t inputHandle, SteamControllerPad eTargetPad, ushort usDurationMicroSec)
		{
			ISteamInput._Legacy_TriggerHapticPulse(this.Self, inputHandle, eTargetPad, usDurationMicroSec);
		}

		// Token: 0x060002B3 RID: 691
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_Legacy_TriggerRepeatedHapticPulse")]
		private static extern void _Legacy_TriggerRepeatedHapticPulse(IntPtr self, InputHandle_t inputHandle, SteamControllerPad eTargetPad, ushort usDurationMicroSec, ushort usOffMicroSec, ushort unRepeat, uint nFlags);

		// Token: 0x060002B4 RID: 692 RVA: 0x000050FD File Offset: 0x000032FD
		internal void Legacy_TriggerRepeatedHapticPulse(InputHandle_t inputHandle, SteamControllerPad eTargetPad, ushort usDurationMicroSec, ushort usOffMicroSec, ushort unRepeat, uint nFlags)
		{
			ISteamInput._Legacy_TriggerRepeatedHapticPulse(this.Self, inputHandle, eTargetPad, usDurationMicroSec, usOffMicroSec, unRepeat, nFlags);
		}

		// Token: 0x060002B5 RID: 693
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_ShowBindingPanel")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _ShowBindingPanel(IntPtr self, InputHandle_t inputHandle);

		// Token: 0x060002B6 RID: 694 RVA: 0x00005113 File Offset: 0x00003313
		internal bool ShowBindingPanel(InputHandle_t inputHandle)
		{
			return ISteamInput._ShowBindingPanel(this.Self, inputHandle);
		}

		// Token: 0x060002B7 RID: 695
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetInputTypeForHandle")]
		private static extern InputType _GetInputTypeForHandle(IntPtr self, InputHandle_t inputHandle);

		// Token: 0x060002B8 RID: 696 RVA: 0x00005121 File Offset: 0x00003321
		internal InputType GetInputTypeForHandle(InputHandle_t inputHandle)
		{
			return ISteamInput._GetInputTypeForHandle(this.Self, inputHandle);
		}

		// Token: 0x060002B9 RID: 697
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetControllerForGamepadIndex")]
		private static extern InputHandle_t _GetControllerForGamepadIndex(IntPtr self, int nIndex);

		// Token: 0x060002BA RID: 698 RVA: 0x0000512F File Offset: 0x0000332F
		internal InputHandle_t GetControllerForGamepadIndex(int nIndex)
		{
			return ISteamInput._GetControllerForGamepadIndex(this.Self, nIndex);
		}

		// Token: 0x060002BB RID: 699
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetGamepadIndexForController")]
		private static extern int _GetGamepadIndexForController(IntPtr self, InputHandle_t ulinputHandle);

		// Token: 0x060002BC RID: 700 RVA: 0x0000513D File Offset: 0x0000333D
		internal int GetGamepadIndexForController(InputHandle_t ulinputHandle)
		{
			return ISteamInput._GetGamepadIndexForController(this.Self, ulinputHandle);
		}

		// Token: 0x060002BD RID: 701
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetStringForXboxOrigin")]
		private static extern Utf8StringPointer _GetStringForXboxOrigin(IntPtr self, XboxOrigin eOrigin);

		// Token: 0x060002BE RID: 702 RVA: 0x0000514B File Offset: 0x0000334B
		internal string GetStringForXboxOrigin(XboxOrigin eOrigin)
		{
			return ISteamInput._GetStringForXboxOrigin(this.Self, eOrigin);
		}

		// Token: 0x060002BF RID: 703
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetGlyphForXboxOrigin")]
		private static extern Utf8StringPointer _GetGlyphForXboxOrigin(IntPtr self, XboxOrigin eOrigin);

		// Token: 0x060002C0 RID: 704 RVA: 0x0000515E File Offset: 0x0000335E
		internal string GetGlyphForXboxOrigin(XboxOrigin eOrigin)
		{
			return ISteamInput._GetGlyphForXboxOrigin(this.Self, eOrigin);
		}

		// Token: 0x060002C1 RID: 705
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetActionOriginFromXboxOrigin")]
		private static extern InputActionOrigin _GetActionOriginFromXboxOrigin(IntPtr self, InputHandle_t inputHandle, XboxOrigin eOrigin);

		// Token: 0x060002C2 RID: 706 RVA: 0x00005171 File Offset: 0x00003371
		internal InputActionOrigin GetActionOriginFromXboxOrigin(InputHandle_t inputHandle, XboxOrigin eOrigin)
		{
			return ISteamInput._GetActionOriginFromXboxOrigin(this.Self, inputHandle, eOrigin);
		}

		// Token: 0x060002C3 RID: 707
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_TranslateActionOrigin")]
		private static extern InputActionOrigin _TranslateActionOrigin(IntPtr self, InputType eDestinationInputType, InputActionOrigin eSourceOrigin);

		// Token: 0x060002C4 RID: 708 RVA: 0x00005180 File Offset: 0x00003380
		internal InputActionOrigin TranslateActionOrigin(InputType eDestinationInputType, InputActionOrigin eSourceOrigin)
		{
			return ISteamInput._TranslateActionOrigin(this.Self, eDestinationInputType, eSourceOrigin);
		}

		// Token: 0x060002C5 RID: 709
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetDeviceBindingRevision")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetDeviceBindingRevision(IntPtr self, InputHandle_t inputHandle, ref int pMajor, ref int pMinor);

		// Token: 0x060002C6 RID: 710 RVA: 0x0000518F File Offset: 0x0000338F
		internal bool GetDeviceBindingRevision(InputHandle_t inputHandle, ref int pMajor, ref int pMinor)
		{
			return ISteamInput._GetDeviceBindingRevision(this.Self, inputHandle, ref pMajor, ref pMinor);
		}

		// Token: 0x060002C7 RID: 711
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetRemotePlaySessionID")]
		private static extern uint _GetRemotePlaySessionID(IntPtr self, InputHandle_t inputHandle);

		// Token: 0x060002C8 RID: 712 RVA: 0x0000519F File Offset: 0x0000339F
		internal uint GetRemotePlaySessionID(InputHandle_t inputHandle)
		{
			return ISteamInput._GetRemotePlaySessionID(this.Self, inputHandle);
		}

		// Token: 0x060002C9 RID: 713
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInput_GetSessionInputConfigurationSettings")]
		private static extern ushort _GetSessionInputConfigurationSettings(IntPtr self);

		// Token: 0x060002CA RID: 714 RVA: 0x000051AD File Offset: 0x000033AD
		internal ushort GetSessionInputConfigurationSettings()
		{
			return ISteamInput._GetSessionInputConfigurationSettings(this.Self);
		}
	}
}
