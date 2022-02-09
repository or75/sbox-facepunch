using System;
using System.Threading.Tasks;
using NativeEngine;

namespace Sandbox.Engine
{
	// Token: 0x020002F9 RID: 761
	internal interface IServerDll : IBaseDll
	{
		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x06001438 RID: 5176 RVA: 0x0002B244 File Offset: 0x00029444
		// (set) Token: 0x06001439 RID: 5177 RVA: 0x0002B24B File Offset: 0x0002944B
		IServerDll Current { get; set; }

		/// <summary>
		/// Called when a batch of compilers are compiled.
		/// </summary>
		// Token: 0x0600143A RID: 5178
		Task<bool> OnAddonsCompiled(Compiler[] compiled);

		/// <summary>
		/// A client's userdata value has been updated
		/// </summary>
		// Token: 0x0600143B RID: 5179
		bool UserVarFromClient(int clientSlot, string key, string val);

		/// <summary>
		/// Server is starting to load, kick it off
		/// </summary>
		// Token: 0x0600143C RID: 5180
		void ServerLoadStart();

		/// <summary>
		/// Server is loading, return true to finish loading
		/// </summary>
		// Token: 0x0600143D RID: 5181
		bool ServerLoadLoop();

		/// <summary>
		/// Local client disconnected from some server, for any reason
		/// </summary>
		// Token: 0x0600143E RID: 5182
		void LocalClientDisconnected();

		// Token: 0x0600143F RID: 5183
		unsafe void InteropInit(int hash, IntPtr* exported, int* struct_sizes, IntPtr* imported);

		// Token: 0x06001440 RID: 5184
		void InitServerSideClient(ServerSideClient sl);
	}
}
