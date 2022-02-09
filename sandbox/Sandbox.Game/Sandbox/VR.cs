using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020000B5 RID: 181
	public static class VR
	{
		// Token: 0x06001187 RID: 4487 RVA: 0x0004AB26 File Offset: 0x00048D26
		internal static void Init()
		{
			Host.AssertClientOrMenu("Init");
			VR.Scale = 1f;
			VR.Anchor = Transform.Zero;
			VR.Enabled = Host.IsMenuOrClient && VRGlue.IsActive();
		}

		/// <summary>
		/// Returns true if VR is active
		/// </summary>
		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06001188 RID: 4488 RVA: 0x0004AB5A File Offset: 0x00048D5A
		// (set) Token: 0x06001189 RID: 4489 RVA: 0x0004AB61 File Offset: 0x00048D61
		public static bool Enabled { get; internal set; }

		/// <summary>
		/// Get or set the player's scale in the world. If you set it to 2 the player will be twice as big.
		/// </summary>
		// Token: 0x17000244 RID: 580
		// (get) Token: 0x0600118A RID: 4490 RVA: 0x0004AB69 File Offset: 0x00048D69
		// (set) Token: 0x0600118B RID: 4491 RVA: 0x0004AB70 File Offset: 0x00048D70
		public static float Scale
		{
			get
			{
				return VR._scale;
			}
			set
			{
				if (!Host.IsMenuOrClient)
				{
					return;
				}
				if (value == VR._scale)
				{
					return;
				}
				if (value == 0f)
				{
					return;
				}
				VR._scale = value;
				VRGlue.SetWorldScale(1f / value);
			}
		}

		/// <summary>
		/// The anchor transform. This is usually where the VR player is standing. Your pawn's position
		/// is the default place for this.
		/// </summary>
		// Token: 0x17000245 RID: 581
		// (get) Token: 0x0600118C RID: 4492 RVA: 0x0004AB9E File Offset: 0x00048D9E
		// (set) Token: 0x0600118D RID: 4493 RVA: 0x0004ABA8 File Offset: 0x00048DA8
		public static Transform Anchor
		{
			get
			{
				return VR._anchorTransform;
			}
			set
			{
				if (value == VR._anchorTransform)
				{
					return;
				}
				if (!Host.IsMenuOrClient)
				{
					return;
				}
				VR._anchorTransform = value;
				VRGlue.SetAnchorOffset(VR._anchorTransform.Position);
				VRGlue.SetAnchorAngles(VR._anchorTransform.Rotation.Angles());
			}
		}

		/// <summary>
		/// Returns true if the SteamVR dashboard is visible
		/// </summary>
		// Token: 0x17000246 RID: 582
		// (get) Token: 0x0600118E RID: 4494 RVA: 0x0004ABF4 File Offset: 0x00048DF4
		public static bool DashboardIsOpen
		{
			get
			{
				return Host.IsMenuOrClient && VRGlue.IsDashboardShowing();
			}
		}

		/// <summary>
		/// Returns true if SteamVR is drawing the controllers
		/// </summary>
		// Token: 0x17000247 RID: 583
		// (get) Token: 0x0600118F RID: 4495 RVA: 0x0004AC04 File Offset: 0x00048E04
		public static bool ControllersAreDrawing
		{
			get
			{
				return Host.IsMenuOrClient && VRGlue.IsSteamVRDrawingControllers();
			}
		}

		/// <summary>
		/// Returns true if the left hand is dominant
		/// </summary>
		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06001190 RID: 4496 RVA: 0x0004AC14 File Offset: 0x00048E14
		public static bool IsLeftHandDominant
		{
			get
			{
				return Host.IsMenuOrClient && VRGlue.IsLeftHandDominant();
			}
		}

		/// <summary>
		/// Returns an appropriate model for the left controller
		/// </summary>
		// Token: 0x06001191 RID: 4497 RVA: 0x0004AC24 File Offset: 0x00048E24
		internal static Model GetLeftControllerModel()
		{
			if (!Host.IsMenuOrClient)
			{
				return null;
			}
			return Model.Get(VRGlue.GetModel(1));
		}

		/// <summary>
		/// Returns an appropriate model for the right controller
		/// </summary>
		// Token: 0x06001192 RID: 4498 RVA: 0x0004AC3A File Offset: 0x00048E3A
		internal static Model GetRightControllerModel()
		{
			if (!Host.IsMenuOrClient)
			{
				return null;
			}
			return Model.Get(VRGlue.GetModel(1));
		}

		// Token: 0x04000378 RID: 888
		private static float _scale = 1f;

		// Token: 0x04000379 RID: 889
		private static Transform _anchorTransform;
	}
}
