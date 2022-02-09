using System;
using NativeEngine;

namespace Sandbox.Engine
{
	// Token: 0x020002F6 RID: 758
	internal interface IClientDll : IBaseDll
	{
		/// <summary>
		/// A command has been run from the input service
		/// </summary>
		// Token: 0x06001420 RID: 5152
		void RunCommandFromInputBuffer(int slot, string command);

		/// <summary>
		/// Return true if the input was swallowed
		/// </summary>
		// Token: 0x06001421 RID: 5153
		bool HandleInputEvent(InputEvent data);

		// Token: 0x06001422 RID: 5154
		void SimulateUI();

		// Token: 0x06001423 RID: 5155
		Vector3 WorldToScreen(Vector3 vector3);

		// Token: 0x06001424 RID: 5156
		unsafe void InitInterop(int hash, IntPtr* exported, int* struct_sizes, IntPtr* imported);

		// Token: 0x06001425 RID: 5157
		void InitNetworkGameClient(NetworkGameClient cl);

		// Token: 0x06001426 RID: 5158
		void OnServerInfo(string game, string map);

		// Token: 0x04001537 RID: 5431
		public static IClientDll Current;
	}
}
