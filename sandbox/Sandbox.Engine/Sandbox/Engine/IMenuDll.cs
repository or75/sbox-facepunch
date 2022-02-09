using System;
using NativeEngine;

namespace Sandbox.Engine
{
	// Token: 0x020002F7 RID: 759
	internal interface IMenuDll : IBaseDll
	{
		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06001427 RID: 5159 RVA: 0x0002B217 File Offset: 0x00029417
		// (set) Token: 0x06001428 RID: 5160 RVA: 0x0002B21E File Offset: 0x0002941E
		IMenuDll Current { get; set; }

		// Token: 0x06001429 RID: 5161
		unsafe void InitInterop_Client(int hash, IntPtr* exported, int* struct_sizes, IntPtr* imported);

		/// <summary>
		/// A command has been run from the input service
		/// </summary>
		// Token: 0x0600142A RID: 5162
		void RunCommandFromInputBuffer(int slot, string command);

		// Token: 0x0600142B RID: 5163
		void UpdateProgressBar(LevelLoadingProgress e);

		// Token: 0x0600142C RID: 5164
		void SwitchToMainuMenu();

		// Token: 0x0600142D RID: 5165
		unsafe void InitInterop_Menu(int hash, IntPtr* exported, int* struct_sizes, IntPtr* imported);

		/// <summary>
		/// Return true if the input was swallowed
		/// </summary>
		// Token: 0x0600142E RID: 5166
		bool HandleInputEvent(InputEvent data);

		// Token: 0x0600142F RID: 5167
		void SimulateUI();

		// Token: 0x06001430 RID: 5168
		void StartConnecting();

		// Token: 0x06001431 RID: 5169
		void ShowMenu(bool v);

		// Token: 0x06001432 RID: 5170
		void DispatchCommand(string name, string args, long flaglong, int client);

		// Token: 0x06001433 RID: 5171
		void OnServerInfo(string gameIdent, string mapIdent);
	}
}
