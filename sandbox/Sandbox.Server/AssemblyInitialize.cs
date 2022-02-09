using System;
using Sandbox;
using Sandbox.Engine;

// Token: 0x02000004 RID: 4
public static class AssemblyInitialize
{
	// Token: 0x06000003 RID: 3 RVA: 0x00002060 File Offset: 0x00000260
	public static void Initialize()
	{
		Host.Init("server");
		IServerDll.Current = new ServerDll();
	}
}
