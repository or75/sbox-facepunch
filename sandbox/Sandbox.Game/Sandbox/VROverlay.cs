using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NativeEngine;
using OpenVR;
using Sandbox.UI;

namespace Sandbox
{
	/// <summary>
	/// <para>VR overlays draw over the top of the 3D scene, they will not be affected by lighting,
	/// post processing effects or anything else in the world.<br />
	/// This makes them ideal for HUDs or menus, or anything else that should be local to the
	/// HMD or tracked devices.</para>
	///
	/// <para>If you need something in the world, consider using WorldPanel
	/// and <see cref="T:Sandbox.UI.WorldInput" /> instead.</para>
	/// </summary>
	// Token: 0x02000106 RID: 262
	public class VROverlay : IDisposable
	{
		// Token: 0x17000328 RID: 808
		// (get) Token: 0x0600152A RID: 5418 RVA: 0x0005420C File Offset: 0x0005240C
		internal static VROverlay HeadsetViewOverlay
		{
			get
			{
				return VROverlay.Find("system.HeadsetView");
			}
		}

		// Token: 0x0600152B RID: 5419 RVA: 0x00054218 File Offset: 0x00052418
		internal static VROverlay Find(string key)
		{
			ulong handle;
			VROverlay.Assert(VRGlue.Overlay().FindOverlay(key, out handle));
			return new VROverlay(handle);
		}

		// Token: 0x0600152C RID: 5420 RVA: 0x00054240 File Offset: 0x00052440
		private VROverlay(ulong handle)
		{
			this.handle = handle;
		}

		// Token: 0x0600152D RID: 5421 RVA: 0x00054268 File Offset: 0x00052468
		public VROverlay()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
			defaultInterpolatedStringHandler.AppendLiteral("sbox_");
			defaultInterpolatedStringHandler.AppendFormatted(Host.Name);
			defaultInterpolatedStringHandler.AppendLiteral(":vroverlay ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(VROverlay.KeyCount++);
			this.key = defaultInterpolatedStringHandler.ToStringAndClear();
			VROverlayError error = VRGlue.Overlay().CreateOverlay(this.key, this.key, out this.handle);
			if (error != VROverlayError.None)
			{
				throw new Exception("Failed to create VROverlay: " + VRGlue.Overlay().GetOverlayErrorNameFromEnum(error));
			}
			this.Visible = true;
			VROverlay.Assert(VRGlue.Overlay().SetOverlayFlag(this.handle, VROverlayFlags.SendVRSmoothScrollEvents, true));
			VROverlay.All.Add(new WeakReference<VROverlay>(this, false));
		}

		// Token: 0x0600152E RID: 5422 RVA: 0x00054358 File Offset: 0x00052558
		~VROverlay()
		{
			this.Dispose(false);
		}

		// Token: 0x0600152F RID: 5423 RVA: 0x00054388 File Offset: 0x00052588
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06001530 RID: 5424 RVA: 0x00054398 File Offset: 0x00052598
		protected virtual void Dispose(bool disposing)
		{
			if (this.handle == 0UL)
			{
				return;
			}
			this.handle = 0UL;
			VRGlue.Overlay().DestroyOverlay(this.handle);
		}

		// Token: 0x06001531 RID: 5425 RVA: 0x000543CC File Offset: 0x000525CC
		internal static void DisposeAll()
		{
			for (int i = VROverlay.All.Count - 1; i >= 0; i--)
			{
				VROverlay overlay;
				if (VROverlay.All[i].TryGetTarget(out overlay))
				{
					overlay.Dispose();
					VROverlay.All.Clear();
				}
			}
		}

		/// <summary>
		/// Shows or hides the VR overlay.
		/// </summary>
		// Token: 0x17000329 RID: 809
		// (get) Token: 0x06001532 RID: 5426 RVA: 0x00054414 File Offset: 0x00052614
		// (set) Token: 0x06001533 RID: 5427 RVA: 0x00054434 File Offset: 0x00052634
		public bool Visible
		{
			get
			{
				return VRGlue.Overlay().IsOverlayVisible(this.handle);
			}
			set
			{
				if (this._visible == value)
				{
					return;
				}
				this._visible = value;
				if (value)
				{
					VROverlay.Assert(VRGlue.Overlay().ShowOverlay(this.handle));
					return;
				}
				VROverlay.Assert(VRGlue.Overlay().HideOverlay(this.handle));
			}
		}

		/// <summary>
		/// Sets the transform to absolute tracking origin
		/// </summary>
		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06001534 RID: 5428 RVA: 0x00054486 File Offset: 0x00052686
		// (set) Token: 0x06001535 RID: 5429 RVA: 0x0005448E File Offset: 0x0005268E
		public Transform Transform
		{
			get
			{
				return this._transform;
			}
			set
			{
				if (this._transform == value)
				{
					return;
				}
				this._transform = value;
				this.SetTransformAbsolute(value);
			}
		}

		// Token: 0x06001536 RID: 5430 RVA: 0x000544B0 File Offset: 0x000526B0
		internal Matrix FromTransform(Transform transform)
		{
			return (Matrix.CreateTranslation(transform.Position) * Matrix.CreateRotation(transform.Rotation) * Matrix.CreateScale(transform.Scale)).SourceToSteamVrCoordinateSystem().Transpose();
		}

		/// <summary>
		/// Sets the transform to absolute tracking origin
		/// </summary>
		// Token: 0x06001537 RID: 5431 RVA: 0x000544FC File Offset: 0x000526FC
		public void SetTransformAbsolute(Transform transform)
		{
			Matrix matrix = this.FromTransform(transform);
			VROverlay.Assert(VRGlue.Overlay().SetOverlayTransformAbsolute(this.handle, TrackingUniverseOrigin.Seated, ref matrix));
		}

		/// <summary>
		/// Sets the transform to relative to the transform of the specified overlay. This overlays visibility will also track the parents visibility.
		/// </summary>
		// Token: 0x06001538 RID: 5432 RVA: 0x0005452C File Offset: 0x0005272C
		public void SetTransformRelative(VROverlay relativeOverlay, Transform transform)
		{
			if (relativeOverlay == null || relativeOverlay.handle == 0UL)
			{
				throw new ArgumentNullException("relativeOverlay");
			}
			Matrix matrix = this.FromTransform(transform);
			VROverlay.Assert(VRGlue.Overlay().SetOverlayTransformOverlayRelative(this.handle, relativeOverlay.handle, ref matrix));
		}

		// Token: 0x06001539 RID: 5433 RVA: 0x00054577 File Offset: 0x00052777
		public void SetHudTransform(Transform tx)
		{
			this.SetTransformRelative(VROverlay.HeadsetViewOverlay, tx);
		}

		// Token: 0x0600153A RID: 5434 RVA: 0x00054588 File Offset: 0x00052788
		public void SetTransformRelative(VRTrackedDevice relativeTrackedDevice, Transform transform)
		{
			if (relativeTrackedDevice == null)
			{
				throw new ArgumentNullException("relativeTrackedDevice");
			}
			Matrix matrix = this.FromTransform(transform);
			VROverlay.Assert(VRGlue.Overlay().SetOverlayTransformTrackedDeviceRelative(this.handle, relativeTrackedDevice.trackedDeviceIndex, ref matrix));
		}

		// Token: 0x1700032B RID: 811
		// (set) Token: 0x0600153B RID: 5435 RVA: 0x000545CC File Offset: 0x000527CC
		public uint SortOrder
		{
			set
			{
				VROverlay.Assert(VRGlue.Overlay().SetOverlaySortOrder(this.handle, value));
			}
		}

		/// <summary>
		/// The width of the overlay quad.
		/// By default overlays are rendered on a quad that is 1 meter across.
		/// </summary>
		// Token: 0x1700032C RID: 812
		// (get) Token: 0x0600153C RID: 5436 RVA: 0x000545F2 File Offset: 0x000527F2
		// (set) Token: 0x0600153D RID: 5437 RVA: 0x00054600 File Offset: 0x00052800
		public float Width
		{
			get
			{
				return this._widthInMeters / 0.0254f;
			}
			set
			{
				if (this._widthInMeters == value * 0.0254f)
				{
					return;
				}
				this._widthInMeters = value * 0.0254f;
				VROverlay.Assert(VRGlue.Overlay().SetOverlayWidthInMeters(this.handle, this._widthInMeters));
			}
		}

		/// <summary>
		/// Use to draw overlay as a curved surface. Curvature is a percentage from (0..1] where 1 is a fully closed cylinder.
		/// For a specific radius, curvature can be computed as: overlay.width / (2 PI r).
		/// </summary>
		// Token: 0x1700032D RID: 813
		// (get) Token: 0x0600153E RID: 5438 RVA: 0x00054648 File Offset: 0x00052848
		// (set) Token: 0x0600153F RID: 5439 RVA: 0x00054650 File Offset: 0x00052850
		public float Curvature
		{
			get
			{
				return this._curvature;
			}
			set
			{
				if (this._curvature == value)
				{
					return;
				}
				this._curvature = value;
				VROverlay.Assert(VRGlue.Overlay().SetOverlayCurvature(this.handle, this._curvature));
			}
		}

		/// <summary>
		/// Sets the color tint of the overlay quad. Use 0.0 to 1.0 per channel.
		/// Sets the alpha of the overlay quad. Use 1.0 for 100 percent opacity to 0.0 for 0 percent opacity.
		/// </summary>
		// Token: 0x1700032E RID: 814
		// (get) Token: 0x06001540 RID: 5440 RVA: 0x0005468C File Offset: 0x0005288C
		// (set) Token: 0x06001541 RID: 5441 RVA: 0x00054694 File Offset: 0x00052894
		public Color Color
		{
			get
			{
				return this._color;
			}
			set
			{
				if (this._color == value)
				{
					return;
				}
				this._color = value;
				VROverlay.Assert(VRGlue.Overlay().SetOverlayColor(this.handle, this._color.r, this._color.g, this._color.b));
				VROverlay.Assert(VRGlue.Overlay().SetOverlayAlpha(this.handle, this._color.a));
			}
		}

		/// <summary>
		/// Texture that is rendered on the overlay quad.
		/// <see cref="T:Sandbox.TextureBuilder" />
		/// </summary>
		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06001542 RID: 5442 RVA: 0x00054713 File Offset: 0x00052913
		// (set) Token: 0x06001543 RID: 5443 RVA: 0x0005471C File Offset: 0x0005291C
		public Texture Texture
		{
			get
			{
				return this._texture;
			}
			set
			{
				this._texture = value;
				if (this.Texture == null || !this.Texture.native.IsValid)
				{
					VRGlue.Overlay().ClearOverlayTexture(this.handle);
				}
			}
		}

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x06001544 RID: 5444 RVA: 0x0005475E File Offset: 0x0005295E
		// (set) Token: 0x06001545 RID: 5445 RVA: 0x00054768 File Offset: 0x00052968
		public Vector2 MouseScale
		{
			get
			{
				return this._mouseScale;
			}
			set
			{
				if (this._mouseScale == value)
				{
					return;
				}
				this._mouseScale = value;
				VROverlay.Assert(VRGlue.Overlay().SetOverlayMouseScale(this.handle, ref this._mouseScale));
			}
		}

		/// <summary>
		/// Triggers a haptic event on the laser mouse controller for this overlay
		/// </summary>
		// Token: 0x06001546 RID: 5446 RVA: 0x000547AC File Offset: 0x000529AC
		internal void TriggerLaserMouseHapticVibration(float durationSeconds, float frequency, float amplitude)
		{
			if (this.handle == 0UL)
			{
				return;
			}
			VROverlay.Assert(VRGlue.Overlay().TriggerLaserMouseHapticVibration(this.handle, durationSeconds, frequency, amplitude));
		}

		// Token: 0x06001547 RID: 5447 RVA: 0x000547E0 File Offset: 0x000529E0
		internal static void Assert(VROverlayError error)
		{
			if (error == VROverlayError.None)
			{
				return;
			}
			throw new Exception(VRGlue.Overlay().GetOverlayErrorNameFromEnum(error));
		}

		// Token: 0x06001548 RID: 5448 RVA: 0x00054804 File Offset: 0x00052A04
		internal static void RenderAll()
		{
			Sandbox.Render.AssertRenderBlock();
			if (!VR.Enabled)
			{
				return;
			}
			for (int i = VROverlay.All.Count - 1; i >= 0; i--)
			{
				VROverlay overlay;
				if (VROverlay.All[i].TryGetTarget(out overlay))
				{
					overlay.Render();
				}
			}
		}

		// Token: 0x06001549 RID: 5449 RVA: 0x00054850 File Offset: 0x00052A50
		internal static void UpdateAll()
		{
			if (!VR.Enabled)
			{
				return;
			}
			for (int i = VROverlay.All.Count - 1; i >= 0; i--)
			{
				VROverlay overlay;
				if (!VROverlay.All[i].TryGetTarget(out overlay) || overlay.handle == 0UL)
				{
					VROverlay.All.RemoveAt(i);
				}
				else
				{
					overlay.Update();
					overlay.PollEvents();
				}
			}
		}

		// Token: 0x0600154A RID: 5450 RVA: 0x000548B4 File Offset: 0x00052AB4
		internal void Update()
		{
			bool visible = this._visible;
			if (Host.IsClient && IMenuAddon.Current.IsMenuScreenVisible())
			{
				visible = false;
			}
			if (VRGlue.IsDashboardShowing())
			{
				visible = false;
			}
			if (visible)
			{
				VROverlay.Assert(VRGlue.Overlay().ShowOverlay(this.handle));
				return;
			}
			VROverlay.Assert(VRGlue.Overlay().HideOverlay(this.handle));
		}

		// Token: 0x0600154B RID: 5451 RVA: 0x0005491C File Offset: 0x00052B1C
		internal void PollEvents()
		{
			VREvent ev = default(VREvent);
			while (VRGlue.Overlay().PollNextOverlayEvent(this.handle, ref ev, (uint)Marshal.SizeOf<VREvent>()))
			{
				switch (ev.eventType)
				{
				case VREventType.MouseMove:
					this.InputData.MousePos = new Vector2(ev.data.mouse.x, -ev.data.mouse.y + this.MouseScale.y);
					break;
				case VREventType.MouseButtonDown:
				case VREventType.MouseButtonUp:
				{
					bool down = ev.eventType == VREventType.MouseButtonDown;
					switch (ev.data.mouse.button)
					{
					case 1U:
						this.InputData.Mouse0 = down;
						break;
					case 2U:
						this.InputData.Mouse1 = down;
						break;
					case 3U:
						this.InputData.Mouse2 = down;
						break;
					}
					break;
				}
				case VREventType.FocusEnter:
					VROverlay.Focused = this;
					break;
				case VREventType.FocusLeave:
					if (VROverlay.Focused == this)
					{
						VROverlay.Focused = null;
					}
					break;
				case VREventType.ScrollDiscrete:
				case VREventType.ScrollSmooth:
					this.InputData.MouseWheel = this.InputData.MouseWheel - ev.data.scroll.ydelta;
					break;
				}
			}
		}

		// Token: 0x0600154C RID: 5452 RVA: 0x00054A7C File Offset: 0x00052C7C
		internal virtual void Render()
		{
			if (!this.Visible || this.Texture == null || !this.Texture.native.IsValid)
			{
				return;
			}
			VRGlue.SetOpenVROverlayTexture(this.handle, this.Texture.native);
		}

		// Token: 0x040004EE RID: 1262
		internal static List<WeakReference<VROverlay>> All = new List<WeakReference<VROverlay>>();

		// Token: 0x040004EF RID: 1263
		internal static VROverlay Focused;

		// Token: 0x040004F0 RID: 1264
		internal ulong handle;

		// Token: 0x040004F1 RID: 1265
		internal string key;

		// Token: 0x040004F2 RID: 1266
		internal static int KeyCount;

		// Token: 0x040004F3 RID: 1267
		internal bool _visible;

		// Token: 0x040004F4 RID: 1268
		internal Transform _transform = Transform.Zero;

		// Token: 0x040004F5 RID: 1269
		internal float _widthInMeters = 1f;

		// Token: 0x040004F6 RID: 1270
		internal float _curvature;

		// Token: 0x040004F7 RID: 1271
		internal Color _color;

		// Token: 0x040004F8 RID: 1272
		internal Texture _texture;

		// Token: 0x040004F9 RID: 1273
		private Vector2 _mouseScale;

		// Token: 0x040004FA RID: 1274
		internal Sandbox.UI.InputData InputData;
	}
}
