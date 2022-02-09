using System;
using System.Reflection;

namespace Sandbox
{
	// Token: 0x02000064 RID: 100
	internal class AssemblyWrapper : IDisposable
	{
		// Token: 0x06000BCC RID: 3020 RVA: 0x0003D84C File Offset: 0x0003BA4C
		public AssemblyWrapper(Assembly assembly)
		{
			this.Assembly = assembly;
			Library.AddAssembly(assembly, null);
			ConsoleSystem.AddAssembly(assembly);
			Type rpcHandler = assembly.GetType("GlobalRpcHandler", false, false);
			if (rpcHandler != null)
			{
				MethodInfo rpc = rpcHandler.GetMethod("OnRpc", BindingFlags.Static | BindingFlags.Public);
				if (rpc != null)
				{
					this.OnRPC = rpc.CreateDelegate<AssemblyWrapper.GlobalRpcDelegate>();
				}
			}
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x0003D8AD File Offset: 0x0003BAAD
		public virtual void Dispose()
		{
			Library.RemoveAssembly(this.Assembly);
			ConsoleSystem.RemoveAssembly(this.Assembly);
			this.OnRPC = null;
			this.Assembly = null;
		}

		// Token: 0x06000BCE RID: 3022 RVA: 0x0003D8D3 File Offset: 0x0003BAD3
		public override string ToString()
		{
			return this.Assembly.ToString();
		}

		// Token: 0x04000165 RID: 357
		public Assembly Assembly;

		// Token: 0x04000166 RID: 358
		public AssemblyWrapper.GlobalRpcDelegate OnRPC;

		// Token: 0x020001E2 RID: 482
		// (Invoke) Token: 0x06001CF1 RID: 7409
		public delegate bool GlobalRpcDelegate(int a, NetRead b);
	}
}
