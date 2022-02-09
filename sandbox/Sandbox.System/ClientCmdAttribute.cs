using System;

/// <summary>
/// Makes this method a clientside only console command, with optional ability for the server to run it on any client
/// </summary>
// Token: 0x0200000E RID: 14
public class ClientCmdAttribute : ConsoleCommand
{
	// Token: 0x0600002C RID: 44 RVA: 0x00002285 File Offset: 0x00000485
	public ClientCmdAttribute(string name = null)
		: base(name)
	{
	}

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x0600002D RID: 45 RVA: 0x0000228E File Offset: 0x0000048E
	internal override bool IsClient
	{
		get
		{
			return true;
		}
	}

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x0600002E RID: 46 RVA: 0x00002291 File Offset: 0x00000491
	internal override bool IsServer
	{
		get
		{
			return false;
		}
	}

	/// <summary>
	/// If true the server can run this command on the client any time it wants
	/// </summary>
	// Token: 0x04000006 RID: 6
	public bool CanBeCalledFromServer;
}
