using System;
using Sandbox;
using Sandbox.Engine;
using Sandbox.Internal;

// Token: 0x02000005 RID: 5
public static class AssemblyInitialize
{
	// Token: 0x06000005 RID: 5 RVA: 0x0000208E File Offset: 0x0000028E
	public static void Initialize()
	{
		Event.Init(GlobalToolsNamespace.Log);
		IToolsDll.Current = new ToolsDll();
	}
}
