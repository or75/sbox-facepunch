using System;

/// <summary>
/// Makes this method a serverside console command. Clients can still run these! Use <c>Sandbox.ConsoleSystem.Caller</c> to get the command caller.
/// </summary>
// Token: 0x0200000C RID: 12
public class ServerCmdAttribute : ConsoleCommand
{
	// Token: 0x06000025 RID: 37 RVA: 0x00002264 File Offset: 0x00000464
	public ServerCmdAttribute(string name = null)
		: base(name)
	{
	}

	// Token: 0x1700000F RID: 15
	// (get) Token: 0x06000026 RID: 38 RVA: 0x0000226D File Offset: 0x0000046D
	internal override bool IsServer
	{
		get
		{
			return true;
		}
	}

	// Token: 0x17000010 RID: 16
	// (get) Token: 0x06000027 RID: 39 RVA: 0x00002270 File Offset: 0x00000470
	internal override bool IsClient
	{
		get
		{
			return false;
		}
	}
}
