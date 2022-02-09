using System;

namespace Sandbox.Engine
{
	// Token: 0x020002FA RID: 762
	internal interface IToolsDll : IBaseDll
	{
		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x06001441 RID: 5185 RVA: 0x0002B253 File Offset: 0x00029453
		// (set) Token: 0x06001442 RID: 5186 RVA: 0x0002B25A File Offset: 0x0002945A
		IToolsDll Current { get; set; }

		// Token: 0x06001443 RID: 5187
		unsafe void InteropInit(int hash, IntPtr* exported, int* struct_sizes, IntPtr* imported);

		// Token: 0x06001444 RID: 5188
		void SetStatus(string name);

		// Token: 0x06001445 RID: 5189
		bool ConsoleFocus();

		// Token: 0x06001446 RID: 5190
		unsafe bool InitToolInterface(string name, int hash, IntPtr* exported, int* struct_sizes, IntPtr* imported);
	}
}
