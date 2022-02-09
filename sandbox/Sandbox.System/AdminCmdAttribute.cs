using System;

/// <summary>
/// Makes this method an admin only serverside console command. Use <c>Sandbox.ConsoleSystem.Caller</c> to get the command caller.
/// </summary>
// Token: 0x0200000D RID: 13
public class AdminCmdAttribute : ConsoleCommand
{
	// Token: 0x06000028 RID: 40 RVA: 0x00002273 File Offset: 0x00000473
	public AdminCmdAttribute(string name = null)
		: base(name)
	{
	}

	// Token: 0x17000011 RID: 17
	// (get) Token: 0x06000029 RID: 41 RVA: 0x0000227C File Offset: 0x0000047C
	internal override bool IsServer
	{
		get
		{
			return true;
		}
	}

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x0600002A RID: 42 RVA: 0x0000227F File Offset: 0x0000047F
	internal override bool IsClient
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000013 RID: 19
	// (get) Token: 0x0600002B RID: 43 RVA: 0x00002282 File Offset: 0x00000482
	internal override bool Protected
	{
		get
		{
			return true;
		}
	}
}
