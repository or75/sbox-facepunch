using System;

/// <summary>
/// Menu only console command.
/// </summary>
// Token: 0x0200000F RID: 15
public class MenuCmdAttribute : ConsoleCommand
{
	// Token: 0x0600002F RID: 47 RVA: 0x00002294 File Offset: 0x00000494
	public MenuCmdAttribute(string name = null)
		: base(name)
	{
	}

	// Token: 0x17000016 RID: 22
	// (get) Token: 0x06000030 RID: 48 RVA: 0x0000229D File Offset: 0x0000049D
	internal override bool IsMenu
	{
		get
		{
			return true;
		}
	}

	// Token: 0x17000017 RID: 23
	// (get) Token: 0x06000031 RID: 49 RVA: 0x000022A0 File Offset: 0x000004A0
	internal override bool IsClient
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000018 RID: 24
	// (get) Token: 0x06000032 RID: 50 RVA: 0x000022A3 File Offset: 0x000004A3
	internal override bool IsServer
	{
		get
		{
			return false;
		}
	}

	/// <summary>
	/// If true the server can run this command on the client any time it wants.
	/// </summary>
	// Token: 0x04000007 RID: 7
	public bool CanBeCalledFromServer;
}
