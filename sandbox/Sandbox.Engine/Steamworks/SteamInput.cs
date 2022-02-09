using System;
using System.Collections.Generic;
using Steamworks.Data;

namespace Steamworks
{
	/// <summary>
	/// Class for utilizing Steam Input.
	/// </summary>
	// Token: 0x0200009E RID: 158
	internal class SteamInput : SteamClientClass<SteamInput>
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000594 RID: 1428 RVA: 0x000076F9 File Offset: 0x000058F9
		internal static ISteamInput Internal
		{
			get
			{
				return SteamClientClass<SteamInput>.Interface as ISteamInput;
			}
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x00007705 File Offset: 0x00005905
		internal override void InitializeInterface(bool server)
		{
			this.SetInterface(server, new ISteamInput(server));
			this.InstallEvents();
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x0000771C File Offset: 0x0000591C
		internal void InstallEvents()
		{
			Dispatch.Install<SteamInputDeviceConnected_t>(delegate(SteamInputDeviceConnected_t x)
			{
				Action<ulong> onControllerConnected = SteamInput.OnControllerConnected;
				if (onControllerConnected == null)
				{
					return;
				}
				onControllerConnected(x.ConnectedDeviceHandle);
			}, false);
			Dispatch.Install<SteamInputDeviceDisconnected_t>(delegate(SteamInputDeviceDisconnected_t x)
			{
				Action<ulong> onControllerDisconnected = SteamInput.OnControllerDisconnected;
				if (onControllerDisconnected == null)
				{
					return;
				}
				onControllerDisconnected(x.DisconnectedDeviceHandle);
			}, false);
			Dispatch.Install<SteamInputConfigurationLoaded_t>(delegate(SteamInputConfigurationLoaded_t x)
			{
				Action<SteamInputConfigurationLoaded_t> onConfigLoaded = SteamInput.OnConfigLoaded;
				if (onConfigLoaded == null)
				{
					return;
				}
				onConfigLoaded(x);
			}, false);
		}

		/// <summary>
		/// Controller Connected - provides info about a single newly connected controller
		/// </summary>
		// Token: 0x1400000C RID: 12
		// (add) Token: 0x06000597 RID: 1431 RVA: 0x00007798 File Offset: 0x00005998
		// (remove) Token: 0x06000598 RID: 1432 RVA: 0x000077CC File Offset: 0x000059CC
		internal static event Action<ulong> OnControllerConnected;

		/// <summary>
		/// Controller Disconnected - provides info about a single disconnected controller
		/// </summary>
		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06000599 RID: 1433 RVA: 0x00007800 File Offset: 0x00005A00
		// (remove) Token: 0x0600059A RID: 1434 RVA: 0x00007834 File Offset: 0x00005A34
		internal static event Action<ulong> OnControllerDisconnected;

		/// <summary>
		/// Controller configuration loaded - these callbacks will always fire if you have a handler.
		/// </summary>
		// Token: 0x1400000E RID: 14
		// (add) Token: 0x0600059B RID: 1435 RVA: 0x00007868 File Offset: 0x00005A68
		// (remove) Token: 0x0600059C RID: 1436 RVA: 0x0000789C File Offset: 0x00005A9C
		internal static event Action<SteamInputConfigurationLoaded_t> OnConfigLoaded;

		// Token: 0x0600059D RID: 1437 RVA: 0x000078CF File Offset: 0x00005ACF
		internal static IEnumerable<InputActionOrigin> GetDigitalActionOrigins(InputHandle_t handle, InputActionSetHandle_t actionSet, InputDigitalActionHandle_t action)
		{
			int count = SteamInput.Internal.GetDigitalActionOrigins(handle, actionSet, action, SteamInput.originsArray);
			int num;
			for (int i = 0; i < count; i = num + 1)
			{
				yield return SteamInput.originsArray[i];
				num = i;
			}
			yield break;
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x000078ED File Offset: 0x00005AED
		internal static IEnumerable<InputActionOrigin> GetAnalogActionOrigins(InputHandle_t handle, InputActionSetHandle_t actionSet, InputAnalogActionHandle_t action)
		{
			int count = SteamInput.Internal.GetAnalogActionOrigins(handle, actionSet, action, SteamInput.originsArray);
			int num;
			for (int i = 0; i < count; i = num + 1)
			{
				yield return SteamInput.originsArray[i];
				num = i;
			}
			yield break;
		}

		// Token: 0x040008FC RID: 2300
		internal const int STEAM_CONTROLLER_MAX_ORIGINS = 8;

		// Token: 0x040008FD RID: 2301
		[ThreadStatic]
		private static readonly InputActionOrigin[] originsArray = new InputActionOrigin[8];
	}
}
