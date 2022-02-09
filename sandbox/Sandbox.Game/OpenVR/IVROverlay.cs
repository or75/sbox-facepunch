using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace OpenVR
{
	// Token: 0x02000013 RID: 19
	internal struct IVROverlay
	{
		// Token: 0x06000148 RID: 328 RVA: 0x0002292A File Offset: 0x00020B2A
		public static implicit operator IntPtr(IVROverlay value)
		{
			return value.self;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00022934 File Offset: 0x00020B34
		public static implicit operator IVROverlay(IntPtr value)
		{
			return new IVROverlay
			{
				self = value
			};
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00022952 File Offset: 0x00020B52
		public static bool operator ==(IVROverlay c1, IVROverlay c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00022965 File Offset: 0x00020B65
		public static bool operator !=(IVROverlay c1, IVROverlay c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00022978 File Offset: 0x00020B78
		public override bool Equals(object obj)
		{
			if (obj is IVROverlay)
			{
				IVROverlay c = (IVROverlay)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x0600014D RID: 333 RVA: 0x000229A2 File Offset: 0x00020BA2
		internal IVROverlay(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x000229AC File Offset: 0x00020BAC
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
			defaultInterpolatedStringHandler.AppendLiteral("IVROverlay ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600014F RID: 335 RVA: 0x000229E8 File Offset: 0x00020BE8
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000150 RID: 336 RVA: 0x000229FA File Offset: 0x00020BFA
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00022A05 File Offset: 0x00020C05
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00022A18 File Offset: 0x00020C18
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("IVROverlay was null when calling " + n);
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00022A33 File Offset: 0x00020C33
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00022A40 File Offset: 0x00020C40
		internal readonly VROverlayError CreateOverlay(string key, string name, out ulong handle)
		{
			this.NullCheck("CreateOverlay");
			method vr_IVROve_CreateOverlay = IVROverlay.__N.vr_IVROve_CreateOverlay;
			return calli(System.Int64(System.IntPtr,System.IntPtr,System.IntPtr,System.UInt64& modreq(System.Runtime.InteropServices.OutAttribute)), this.self, Interop.GetPointer(key), Interop.GetPointer(name), ref handle, vr_IVROve_CreateOverlay);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00022A78 File Offset: 0x00020C78
		internal readonly VROverlayError DestroyOverlay(ulong handle)
		{
			this.NullCheck("DestroyOverlay");
			method vr_IVROve_DestroyOverlay = IVROverlay.__N.vr_IVROve_DestroyOverlay;
			return calli(System.Int64(System.IntPtr,System.UInt64), this.self, handle, vr_IVROve_DestroyOverlay);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00022AA4 File Offset: 0x00020CA4
		internal readonly VROverlayError FindOverlay(string key, out ulong handle)
		{
			this.NullCheck("FindOverlay");
			method vr_IVROve_FindOverlay = IVROverlay.__N.vr_IVROve_FindOverlay;
			return calli(System.Int64(System.IntPtr,System.IntPtr,System.UInt64& modreq(System.Runtime.InteropServices.OutAttribute)), this.self, Interop.GetPointer(key), ref handle, vr_IVROve_FindOverlay);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00022AD8 File Offset: 0x00020CD8
		internal readonly string GetOverlayErrorNameFromEnum(VROverlayError error)
		{
			this.NullCheck("GetOverlayErrorNameFromEnum");
			method vr_IVROve_GetOverlayErrorNameFromEnum = IVROverlay.__N.vr_IVROve_GetOverlayErrorNameFromEnum;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr,System.Int64), this.self, (long)error, vr_IVROve_GetOverlayErrorNameFromEnum));
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00022B0C File Offset: 0x00020D0C
		internal readonly VROverlayError ShowOverlay(ulong handle)
		{
			this.NullCheck("ShowOverlay");
			method vr_IVROve_ShowOverlay = IVROverlay.__N.vr_IVROve_ShowOverlay;
			return calli(System.Int64(System.IntPtr,System.UInt64), this.self, handle, vr_IVROve_ShowOverlay);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00022B38 File Offset: 0x00020D38
		internal readonly VROverlayError HideOverlay(ulong handle)
		{
			this.NullCheck("HideOverlay");
			method vr_IVROve_HideOverlay = IVROverlay.__N.vr_IVROve_HideOverlay;
			return calli(System.Int64(System.IntPtr,System.UInt64), this.self, handle, vr_IVROve_HideOverlay);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00022B64 File Offset: 0x00020D64
		internal readonly bool IsOverlayVisible(ulong handle)
		{
			this.NullCheck("IsOverlayVisible");
			method vr_IVROve_IsOverlayVisible = IVROverlay.__N.vr_IVROve_IsOverlayVisible;
			return calli(System.Int32(System.IntPtr,System.UInt64), this.self, handle, vr_IVROve_IsOverlayVisible) > 0;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00022B94 File Offset: 0x00020D94
		internal readonly VROverlayError SetOverlayFlag(ulong handle, VROverlayFlags overlayFlag, bool enabled)
		{
			this.NullCheck("SetOverlayFlag");
			method vr_IVROve_SetOverlayFlag = IVROverlay.__N.vr_IVROve_SetOverlayFlag;
			return calli(System.Int64(System.IntPtr,System.UInt64,System.Int64,System.Int32), this.self, handle, (long)overlayFlag, enabled ? 1 : 0, vr_IVROve_SetOverlayFlag);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00022BCC File Offset: 0x00020DCC
		internal readonly VROverlayError SetOverlayTexture(ulong handle, ref VRTexture texture)
		{
			this.NullCheck("SetOverlayTexture");
			method vr_IVROve_SetOverlayTexture = IVROverlay.__N.vr_IVROve_SetOverlayTexture;
			return calli(System.Int64(System.IntPtr,System.UInt64,OpenVR.VRTexture&), this.self, handle, ref texture, vr_IVROve_SetOverlayTexture);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00022BFC File Offset: 0x00020DFC
		internal readonly VROverlayError ClearOverlayTexture(ulong handle)
		{
			this.NullCheck("ClearOverlayTexture");
			method vr_IVROve_ClearOverlayTexture = IVROverlay.__N.vr_IVROve_ClearOverlayTexture;
			return calli(System.Int64(System.IntPtr,System.UInt64), this.self, handle, vr_IVROve_ClearOverlayTexture);
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00022C28 File Offset: 0x00020E28
		internal readonly VROverlayError SetOverlayWidthInMeters(ulong handle, float widthInMeters)
		{
			this.NullCheck("SetOverlayWidthInMeters");
			method vr_IVROve_SetOverlayWidthInMeters = IVROverlay.__N.vr_IVROve_SetOverlayWidthInMeters;
			return calli(System.Int64(System.IntPtr,System.UInt64,System.Single), this.self, handle, widthInMeters, vr_IVROve_SetOverlayWidthInMeters);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00022C58 File Offset: 0x00020E58
		internal readonly VROverlayError SetOverlayCurvature(ulong handle, float curvature)
		{
			this.NullCheck("SetOverlayCurvature");
			method vr_IVROve_SetOverlayCurvature = IVROverlay.__N.vr_IVROve_SetOverlayCurvature;
			return calli(System.Int64(System.IntPtr,System.UInt64,System.Single), this.self, handle, curvature, vr_IVROve_SetOverlayCurvature);
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00022C88 File Offset: 0x00020E88
		internal readonly VROverlayError SetOverlayTransformAbsolute(ulong handle, TrackingUniverseOrigin trackingOrigin, ref Matrix trackingOriginToOverlayTransform)
		{
			this.NullCheck("SetOverlayTransformAbsolute");
			method vr_IVROve_SetOverlayTransformAbsolute = IVROverlay.__N.vr_IVROve_SetOverlayTransformAbsolute;
			return calli(System.Int64(System.IntPtr,System.UInt64,System.Int64,Matrix&), this.self, handle, (long)trackingOrigin, ref trackingOriginToOverlayTransform, vr_IVROve_SetOverlayTransformAbsolute);
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00022CB8 File Offset: 0x00020EB8
		internal readonly VROverlayError SetOverlayTransformOverlayRelative(ulong handle, ulong relativeOverlayHandle, ref Matrix trackingOriginToOverlayTransform)
		{
			this.NullCheck("SetOverlayTransformOverlayRelative");
			method vr_IVROve_SetOverlayTransformOverlayRelative = IVROverlay.__N.vr_IVROve_SetOverlayTransformOverlayRelative;
			return calli(System.Int64(System.IntPtr,System.UInt64,System.UInt64,Matrix&), this.self, handle, relativeOverlayHandle, ref trackingOriginToOverlayTransform, vr_IVROve_SetOverlayTransformOverlayRelative);
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00022CE8 File Offset: 0x00020EE8
		internal readonly VROverlayError SetOverlayTransformTrackedDeviceRelative(ulong handle, uint unTrackedDevice, ref Matrix trackedDeviceToOverlayTransform)
		{
			this.NullCheck("SetOverlayTransformTrackedDeviceRelative");
			method vr_IVROve_SetOverlayTransformTrackedDeviceRelative = IVROverlay.__N.vr_IVROve_SetOverlayTransformTrackedDeviceRelative;
			return calli(System.Int64(System.IntPtr,System.UInt64,System.UInt32,Matrix&), this.self, handle, unTrackedDevice, ref trackedDeviceToOverlayTransform, vr_IVROve_SetOverlayTransformTrackedDeviceRelative);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00022D18 File Offset: 0x00020F18
		internal readonly VROverlayError SetOverlayTransformTrackedDeviceComponent(ulong handle, uint unDeviceIndex, string componentName)
		{
			this.NullCheck("SetOverlayTransformTrackedDeviceComponent");
			method vr_IVROve_SetOverlayTransformTrackedDeviceComponent = IVROverlay.__N.vr_IVROve_SetOverlayTransformTrackedDeviceComponent;
			return calli(System.Int64(System.IntPtr,System.UInt64,System.UInt32,System.IntPtr), this.self, handle, unDeviceIndex, Interop.GetPointer(componentName), vr_IVROve_SetOverlayTransformTrackedDeviceComponent);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00022D4C File Offset: 0x00020F4C
		internal readonly VROverlayError SetOverlayColor(ulong handle, float red, float green, float blue)
		{
			this.NullCheck("SetOverlayColor");
			method vr_IVROve_SetOverlayColor = IVROverlay.__N.vr_IVROve_SetOverlayColor;
			return calli(System.Int64(System.IntPtr,System.UInt64,System.Single,System.Single,System.Single), this.self, handle, red, green, blue, vr_IVROve_SetOverlayColor);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00022D7C File Offset: 0x00020F7C
		internal readonly VROverlayError SetOverlayAlpha(ulong handle, float alpha)
		{
			this.NullCheck("SetOverlayAlpha");
			method vr_IVROve_SetOverlayAlpha = IVROverlay.__N.vr_IVROve_SetOverlayAlpha;
			return calli(System.Int64(System.IntPtr,System.UInt64,System.Single), this.self, handle, alpha, vr_IVROve_SetOverlayAlpha);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00022DAC File Offset: 0x00020FAC
		internal readonly VROverlayError SetOverlayTexelAspect(ulong handle, float fTexelAspect)
		{
			this.NullCheck("SetOverlayTexelAspect");
			method vr_IVROve_SetOverlayTexelAspect = IVROverlay.__N.vr_IVROve_SetOverlayTexelAspect;
			return calli(System.Int64(System.IntPtr,System.UInt64,System.Single), this.self, handle, fTexelAspect, vr_IVROve_SetOverlayTexelAspect);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00022DDC File Offset: 0x00020FDC
		internal readonly VROverlayError SetOverlaySortOrder(ulong handle, uint sortOrder)
		{
			this.NullCheck("SetOverlaySortOrder");
			method vr_IVROve_SetOverlaySortOrder = IVROverlay.__N.vr_IVROve_SetOverlaySortOrder;
			return calli(System.Int64(System.IntPtr,System.UInt64,System.UInt32), this.self, handle, sortOrder, vr_IVROve_SetOverlaySortOrder);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00022E0C File Offset: 0x0002100C
		internal readonly bool PollNextOverlayEvent(ulong handle, ref VREvent vrEvent, uint sizeVREvent)
		{
			this.NullCheck("PollNextOverlayEvent");
			method vr_IVROve_PollNextOverlayEvent = IVROverlay.__N.vr_IVROve_PollNextOverlayEvent;
			return calli(System.Int32(System.IntPtr,System.UInt64,OpenVR.VREvent&,System.UInt32), this.self, handle, ref vrEvent, sizeVREvent, vr_IVROve_PollNextOverlayEvent) > 0;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00022E3C File Offset: 0x0002103C
		internal readonly VROverlayError SetOverlayInputMethod(ulong handle, VROverlayInputMethod inputMethod)
		{
			this.NullCheck("SetOverlayInputMethod");
			method vr_IVROve_SetOverlayInputMethod = IVROverlay.__N.vr_IVROve_SetOverlayInputMethod;
			return calli(System.Int64(System.IntPtr,System.UInt64,System.Int64), this.self, handle, (long)inputMethod, vr_IVROve_SetOverlayInputMethod);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00022E6C File Offset: 0x0002106C
		internal readonly VROverlayError SetOverlayMouseScale(ulong handle, ref Vector2 mouseScale)
		{
			this.NullCheck("SetOverlayMouseScale");
			method vr_IVROve_SetOverlayMouseScale = IVROverlay.__N.vr_IVROve_SetOverlayMouseScale;
			return calli(System.Int64(System.IntPtr,System.UInt64,Vector2&), this.self, handle, ref mouseScale, vr_IVROve_SetOverlayMouseScale);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00022E9C File Offset: 0x0002109C
		internal readonly VROverlayError TriggerLaserMouseHapticVibration(ulong handle, float durationSeconds, float frequency, float amplitude)
		{
			this.NullCheck("TriggerLaserMouseHapticVibration");
			method vr_IVROve_TriggerLaserMouseHapticVibration = IVROverlay.__N.vr_IVROve_TriggerLaserMouseHapticVibration;
			return calli(System.Int64(System.IntPtr,System.UInt64,System.Single,System.Single,System.Single), this.self, handle, durationSeconds, frequency, amplitude, vr_IVROve_TriggerLaserMouseHapticVibration);
		}

		// Token: 0x04000013 RID: 19
		internal IntPtr self;

		// Token: 0x0200019E RID: 414
		internal static class __N
		{
			// Token: 0x040007FB RID: 2043
			internal static method vr_IVROve_CreateOverlay;

			// Token: 0x040007FC RID: 2044
			internal static method vr_IVROve_DestroyOverlay;

			// Token: 0x040007FD RID: 2045
			internal static method vr_IVROve_FindOverlay;

			// Token: 0x040007FE RID: 2046
			internal static method vr_IVROve_GetOverlayErrorNameFromEnum;

			// Token: 0x040007FF RID: 2047
			internal static method vr_IVROve_ShowOverlay;

			// Token: 0x04000800 RID: 2048
			internal static method vr_IVROve_HideOverlay;

			// Token: 0x04000801 RID: 2049
			internal static method vr_IVROve_IsOverlayVisible;

			// Token: 0x04000802 RID: 2050
			internal static method vr_IVROve_SetOverlayFlag;

			// Token: 0x04000803 RID: 2051
			internal static method vr_IVROve_SetOverlayTexture;

			// Token: 0x04000804 RID: 2052
			internal static method vr_IVROve_ClearOverlayTexture;

			// Token: 0x04000805 RID: 2053
			internal static method vr_IVROve_SetOverlayWidthInMeters;

			// Token: 0x04000806 RID: 2054
			internal static method vr_IVROve_SetOverlayCurvature;

			// Token: 0x04000807 RID: 2055
			internal static method vr_IVROve_SetOverlayTransformAbsolute;

			// Token: 0x04000808 RID: 2056
			internal static method vr_IVROve_SetOverlayTransformOverlayRelative;

			// Token: 0x04000809 RID: 2057
			internal static method vr_IVROve_SetOverlayTransformTrackedDeviceRelative;

			// Token: 0x0400080A RID: 2058
			internal static method vr_IVROve_SetOverlayTransformTrackedDeviceComponent;

			// Token: 0x0400080B RID: 2059
			internal static method vr_IVROve_SetOverlayColor;

			// Token: 0x0400080C RID: 2060
			internal static method vr_IVROve_SetOverlayAlpha;

			// Token: 0x0400080D RID: 2061
			internal static method vr_IVROve_SetOverlayTexelAspect;

			// Token: 0x0400080E RID: 2062
			internal static method vr_IVROve_SetOverlaySortOrder;

			// Token: 0x0400080F RID: 2063
			internal static method vr_IVROve_PollNextOverlayEvent;

			// Token: 0x04000810 RID: 2064
			internal static method vr_IVROve_SetOverlayInputMethod;

			// Token: 0x04000811 RID: 2065
			internal static method vr_IVROve_SetOverlayMouseScale;

			// Token: 0x04000812 RID: 2066
			internal static method vr_IVROve_TriggerLaserMouseHapticVibration;
		}
	}
}
