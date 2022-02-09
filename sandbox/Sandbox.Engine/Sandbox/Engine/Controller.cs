using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Sandbox.Internal;
using Sandbox.TextureLoader;
using Steamworks;
using Steamworks.Data;

namespace Sandbox.Engine
{
	/// <summary>
	/// Represents a controller from Steam Input.
	/// </summary>
	// Token: 0x020002FD RID: 765
	internal class Controller
	{
		/// <summary>
		/// All connected controllers.
		/// </summary>
		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x0600144F RID: 5199 RVA: 0x0002B385 File Offset: 0x00029585
		internal static IEnumerable<Controller> All
		{
			get
			{
				return Controller._all.Values.Where((Controller c) => c.Connected);
			}
		}

		/// <summary>
		/// Easy accessor to the first connected controller.
		/// Elaborate on this stuff more if adding multi controller support.
		/// </summary>
		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x06001450 RID: 5200 RVA: 0x0002B3B5 File Offset: 0x000295B5
		internal static Controller First
		{
			get
			{
				return Controller.All.FirstOrDefault<Controller>();
			}
		}

		/// <summary>
		/// Initialize a Controller from a Steam Input handle.
		/// </summary>
		// Token: 0x06001451 RID: 5201 RVA: 0x0002B3C1 File Offset: 0x000295C1
		internal Controller(InputHandle_t inputHandle_t)
		{
			this.Handle = inputHandle_t;
		}

		/// <summary>
		/// If the controller is temporarily disconnected and reconnected this Controller will be revived.
		/// </summary>
		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06001452 RID: 5202 RVA: 0x0002B3ED File Offset: 0x000295ED
		// (set) Token: 0x06001453 RID: 5203 RVA: 0x0002B3F5 File Offset: 0x000295F5
		internal bool Connected { get; private set; } = true;

		/// <summary>
		/// Initialize the Steam Input API and load it's action manifest file.
		/// </summary>
		// Token: 0x06001454 RID: 5204 RVA: 0x0002B400 File Offset: 0x00029600
		internal static void Init()
		{
			SteamInput.OnControllerConnected += Controller.OnControllerConnected;
			SteamInput.OnControllerDisconnected += Controller.OnControllerDisconnected;
			SteamInput.OnConfigLoaded += Controller.OnConfigLoaded;
			SteamInput.Internal.Init(false);
			SteamInput.Internal.EnableDeviceCallbacks();
			string manifestPath = EngineFileSystem.Root.GetFullPath("/config/steaminput/manifest.vdf");
			if (!SteamInput.Internal.SetInputActionManifestFilePath(manifestPath))
			{
				GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Failed to load Steam Input action manifest: {0}", new object[] { manifestPath }));
				return;
			}
		}

		// Token: 0x06001455 RID: 5205 RVA: 0x0002B494 File Offset: 0x00029694
		internal static void OnControllerConnected(ulong handle)
		{
			Controller controller;
			if (Controller._all.TryGetValue(handle, out controller))
			{
				if (controller.Connected)
				{
					return;
				}
				controller.Connected = true;
				IMenuDll menuDll = IMenuDll.Current;
				if (menuDll != null)
				{
					menuDll.RunEvent("controller.connected", controller);
				}
				IClientDll current = IClientDll.Current;
				if (current == null)
				{
					return;
				}
				current.RunEvent("controller.connected", controller);
				return;
			}
			else
			{
				controller = new Controller(handle);
				Controller._all[handle] = controller;
				IMenuDll menuDll2 = IMenuDll.Current;
				if (menuDll2 != null)
				{
					menuDll2.RunEvent("controller.connected", controller);
				}
				IClientDll current2 = IClientDll.Current;
				if (current2 == null)
				{
					return;
				}
				current2.RunEvent("controller.connected", controller);
				return;
			}
		}

		// Token: 0x06001456 RID: 5206 RVA: 0x0002B53C File Offset: 0x0002973C
		internal static void OnControllerDisconnected(ulong handle)
		{
			Controller controller;
			if (!Controller._all.TryGetValue(handle, out controller))
			{
				return;
			}
			if (!controller.Connected)
			{
				return;
			}
			controller.Connected = false;
			IMenuDll menuDll = IMenuDll.Current;
			if (menuDll != null)
			{
				menuDll.RunEvent("controller.disconnected", controller);
			}
			IClientDll current = IClientDll.Current;
			if (current == null)
			{
				return;
			}
			current.RunEvent("controller.disconnected", controller);
		}

		// Token: 0x06001457 RID: 5207 RVA: 0x0002B59C File Offset: 0x0002979C
		internal static void OnConfigLoaded(SteamInputConfigurationLoaded_t loaded)
		{
			Controller.ActionSetHandles.Clear();
			foreach (Controller controller in Controller.All)
			{
				controller.DigitalActionHandles.Clear();
				controller.AnalogActionHandles.Clear();
			}
		}

		/// <summary>
		/// Update the action set of controllers depending on if they're ingame or not.
		/// </summary>
		// Token: 0x06001458 RID: 5208 RVA: 0x0002B600 File Offset: 0x00029800
		internal static void Tick(bool ingame)
		{
			foreach (Controller controller in Controller.All)
			{
				controller.ActionSet = Controller.GetActionSetHandle(ingame ? "InGame" : "Menu");
			}
		}

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x06001459 RID: 5209 RVA: 0x0002B660 File Offset: 0x00029860
		internal InputType Type
		{
			get
			{
				return SteamInput.Internal.GetInputTypeForHandle(this.Handle);
			}
		}

		/// <summary>
		/// Reconfigure the controller to use the specified action set (ie 'Menu', 'Walk' or 'Drive')
		/// </summary>
		/// <remarks>
		/// It's often easier to repeatedly call in your state loops instead of trying to place it in all of your state transitions.
		/// </remarks>
		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x0600145A RID: 5210 RVA: 0x0002B672 File Offset: 0x00029872
		// (set) Token: 0x0600145B RID: 5211 RVA: 0x0002B684 File Offset: 0x00029884
		internal InputActionSetHandle_t ActionSet
		{
			get
			{
				return SteamInput.Internal.GetCurrentActionSet(this.Handle);
			}
			set
			{
				SteamInput.Internal.ActivateActionSet(this.Handle, value);
			}
		}

		/// <summary>
		/// Gets the current state of a digital action.
		/// </summary>
		// Token: 0x0600145C RID: 5212 RVA: 0x0002B697 File Offset: 0x00029897
		internal DigitalState GetDigitalActionState(string action)
		{
			return SteamInput.Internal.GetDigitalActionData(this.Handle, this.GetDigitalActionHandle(action));
		}

		/// <summary>
		/// Gets the current state of an analog action.
		/// </summary>
		// Token: 0x0600145D RID: 5213 RVA: 0x0002B6B0 File Offset: 0x000298B0
		internal AnalogState GetAnalogActionState(string action)
		{
			return SteamInput.Internal.GetAnalogActionData(this.Handle, this.GetAnalogActionHandle(action));
		}

		/// <summary>
		/// Returns a localized string (from Steam's language setting) for the user-facing action name corresponding
		/// to the specified action
		/// </summary>
		// Token: 0x0600145E RID: 5214 RVA: 0x0002B6C9 File Offset: 0x000298C9
		internal string GetDigitalActionName(string action)
		{
			return SteamInput.Internal.GetStringForDigitalActionName(this.GetDigitalActionHandle(action));
		}

		/// <summary>
		/// Returns a localized string (from Steam's language setting) for the user-facing action name corresponding
		/// to the specified action
		/// </summary>
		// Token: 0x0600145F RID: 5215 RVA: 0x0002B6DC File Offset: 0x000298DC
		internal string GetAnalogActionName(string action)
		{
			return SteamInput.Internal.GetStringForAnalogActionName(this.GetAnalogActionHandle(action));
		}

		/// <summary>
		/// Gets a controller-specific button name of a digital action.
		/// </summary>
		// Token: 0x06001460 RID: 5216 RVA: 0x0002B6F0 File Offset: 0x000298F0
		internal string GetDigitalActionOriginName(string action)
		{
			InputActionOrigin origin = SteamInput.GetDigitalActionOrigins(this.Handle, SteamInput.Internal.GetCurrentActionSet(this.Handle), this.GetDigitalActionHandle(action)).FirstOrDefault<InputActionOrigin>();
			return SteamInput.Internal.GetStringForActionOrigin(origin);
		}

		/// <summary>
		/// Gets a controller-specific button name of an analog action.
		/// </summary>
		// Token: 0x06001461 RID: 5217 RVA: 0x0002B730 File Offset: 0x00029930
		internal string GetAnalogActionOriginName(string action)
		{
			InputActionOrigin origin = SteamInput.GetAnalogActionOrigins(this.Handle, SteamInput.Internal.GetCurrentActionSet(this.Handle), this.GetAnalogActionHandle(action)).FirstOrDefault<InputActionOrigin>();
			return SteamInput.Internal.GetStringForActionOrigin(origin);
		}

		/// <summary>
		/// Gets a controller-specific glyph texture of a digital action.
		/// </summary>
		/// <remarks>This is cheap to call and should be done every frame since these can change with action sets or configuration changes.</remarks>
		/// <returns>Null if user does not have the action bound to anything.</returns>
		// Token: 0x06001462 RID: 5218 RVA: 0x0002B770 File Offset: 0x00029970
		internal Texture GetDigitalActionGlyph(string action, GlyphSize size = GlyphSize.Small, SteamInputGlyphStyle style = SteamInputGlyphStyle.Knockout)
		{
			InputActionOrigin origin = SteamInput.GetDigitalActionOrigins(this.Handle, SteamInput.Internal.GetCurrentActionSet(this.Handle), this.GetDigitalActionHandle(action)).FirstOrDefault<InputActionOrigin>();
			if (origin == InputActionOrigin.None)
			{
				return null;
			}
			return SteamInputGlyph.Load(origin, size, style);
		}

		/// <summary>
		/// Gets a controller-specific glyph texture of an analog action.
		/// </summary>
		/// <remarks>This is cheap to call and should be done every frame since these can change with action sets or configuration changes.</remarks>
		/// <returns>Null if user does not have the action bound to anything.</returns>
		// Token: 0x06001463 RID: 5219 RVA: 0x0002B7B4 File Offset: 0x000299B4
		internal Texture GetAnalogActionGlyph(string action, GlyphSize size = GlyphSize.Small, SteamInputGlyphStyle style = SteamInputGlyphStyle.Knockout)
		{
			InputActionOrigin origin = SteamInput.GetAnalogActionOrigins(this.Handle, SteamInput.Internal.GetCurrentActionSet(this.Handle), this.GetAnalogActionHandle(action)).FirstOrDefault<InputActionOrigin>();
			if (origin == InputActionOrigin.None)
			{
				return null;
			}
			return SteamInputGlyph.Load(origin, size, style);
		}

		/// <summary>
		/// Trigger a vibration event on support controllers including Xbox trigger impusle rumble.
		/// </summary>
		/// <remarks>
		/// Steam Input will translate these commands into haptic pulses for the Steam Controller or Steam Deck.
		/// </remarks>
		/// <param name="leftMotor">The speed of the left motor, between 0.0 and 1.0.</param>
		/// <param name="rightMotor">The speed of the right motor, between 0.0 and 1.0.</param>
		/// <param name="leftTrigger">(Xbox One controller only) The speed of the left trigger motor, between 0.0 and 1.0.</param>
		/// <param name="rightTrigger">(Xbox One controller only) The speed of the right trigger motor, between 0.0 and 1.0.</param>
		// Token: 0x06001464 RID: 5220 RVA: 0x0002B7F8 File Offset: 0x000299F8
		internal void TriggerVibration(float leftMotor, float rightMotor, float leftTrigger = 0f, float rightTrigger = 0f)
		{
			SteamInput.Internal.TriggerVibrationExtended(this.Handle, (ushort)(Math.Clamp(leftMotor, 0f, 1f) * 65535f), (ushort)(Math.Clamp(rightMotor, 0f, 1f) * 65535f), (ushort)(Math.Clamp(leftTrigger, 0f, 1f) * 65535f), (ushort)(Math.Clamp(rightTrigger, 0f, 1f) * 65535f));
		}

		/// <summary>
		/// Set the controller LED color on supported controllers.
		/// Steam will handle the behavior on exit of your program so you don't need to try restore the default as you are shutting down.
		/// </summary>
		/// <remarks>PS4/PS5 controllers are only ones that support this.</remarks>
		// Token: 0x06001465 RID: 5221 RVA: 0x0002B872 File Offset: 0x00029A72
		internal void SetLEDColor(Color32 color)
		{
			SteamInput.Internal.SetLEDColor(this.Handle, color.r, color.g, color.b, 0U);
		}

		/// <summary>
		/// Invokes the Steam overlay and brings up the binding screen if the user is using Big Picture Mode.
		/// If the user is not in Big Picture Mode it will open up the binding in a new window.
		///
		/// The Steam Input configurator screen uses in-game actions that the player performs in your game, instead of keys or buttons.
		/// </summary>
		// Token: 0x06001466 RID: 5222 RVA: 0x0002B89A File Offset: 0x00029A9A
		internal bool ShowBindingPanel()
		{
			return SteamInput.Internal.ShowBindingPanel(this.Handle);
		}

		// Token: 0x06001467 RID: 5223 RVA: 0x0002B8AC File Offset: 0x00029AAC
		internal static InputActionSetHandle_t GetActionSetHandle(string actionSet)
		{
			InputActionSetHandle_t handle;
			if (Controller.ActionSetHandles.TryGetValue(actionSet, out handle))
			{
				return handle;
			}
			handle = SteamInput.Internal.GetActionSetHandle(actionSet);
			if (handle == 0UL)
			{
				return handle;
			}
			Controller.ActionSetHandles[actionSet] = handle;
			return Controller.ActionSetHandles[actionSet];
		}

		// Token: 0x06001468 RID: 5224 RVA: 0x0002B900 File Offset: 0x00029B00
		internal InputDigitalActionHandle_t GetDigitalActionHandle(string action)
		{
			InputDigitalActionHandle_t handle;
			if (this.DigitalActionHandles.TryGetValue(action, out handle))
			{
				return handle;
			}
			handle = SteamInput.Internal.GetDigitalActionHandle(action);
			if (handle == 0UL)
			{
				return handle;
			}
			this.DigitalActionHandles[action] = handle;
			return this.DigitalActionHandles[action];
		}

		// Token: 0x06001469 RID: 5225 RVA: 0x0002B958 File Offset: 0x00029B58
		internal InputAnalogActionHandle_t GetAnalogActionHandle(string action)
		{
			InputAnalogActionHandle_t handle;
			if (this.AnalogActionHandles.TryGetValue(action, out handle))
			{
				return handle;
			}
			handle = SteamInput.Internal.GetAnalogActionHandle(action);
			if (handle == 0UL)
			{
				return handle;
			}
			this.AnalogActionHandles[action] = SteamInput.Internal.GetAnalogActionHandle(action);
			return this.AnalogActionHandles[action];
		}

		// Token: 0x0600146A RID: 5226 RVA: 0x0002B9B7 File Offset: 0x00029BB7
		public override int GetHashCode()
		{
			return this.Handle.GetHashCode();
		}

		// Token: 0x0600146B RID: 5227 RVA: 0x0002B9CC File Offset: 0x00029BCC
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<InputType>(SteamInput.Internal.GetInputTypeForHandle(this.Handle));
			defaultInterpolatedStringHandler.AppendLiteral(".");
			defaultInterpolatedStringHandler.AppendFormatted<ulong>(this.Handle.Value);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0400153F RID: 5439
		private static Dictionary<InputHandle_t, Controller> _all = new Dictionary<InputHandle_t, Controller>();

		// Token: 0x04001540 RID: 5440
		internal InputHandle_t Handle;

		// Token: 0x04001542 RID: 5442
		internal static Dictionary<string, InputActionSetHandle_t> ActionSetHandles = new Dictionary<string, InputActionSetHandle_t>();

		// Token: 0x04001543 RID: 5443
		internal Dictionary<string, InputDigitalActionHandle_t> DigitalActionHandles = new Dictionary<string, InputDigitalActionHandle_t>();

		// Token: 0x04001544 RID: 5444
		internal Dictionary<string, InputAnalogActionHandle_t> AnalogActionHandles = new Dictionary<string, InputAnalogActionHandle_t>();
	}
}
