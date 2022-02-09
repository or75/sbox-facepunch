using System;

/// <summary>
/// Serverside only console variable. Only admins can change these.
/// </summary>
// Token: 0x0200000A RID: 10
[AttributeUsage(AttributeTargets.Property)]
public class ServerVarAttribute : ConsoleVariableAttribute
{
	// Token: 0x1700000C RID: 12
	// (get) Token: 0x06000020 RID: 32 RVA: 0x00002243 File Offset: 0x00000443
	internal override bool IsServer
	{
		get
		{
			return true;
		}
	}

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x06000021 RID: 33 RVA: 0x00002246 File Offset: 0x00000446
	internal override bool IsClient
	{
		get
		{
			return false;
		}
	}

	// Token: 0x1700000E RID: 14
	// (get) Token: 0x06000022 RID: 34 RVA: 0x00002249 File Offset: 0x00000449
	internal override bool Protected
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06000023 RID: 35 RVA: 0x0000224C File Offset: 0x0000044C
	public ServerVarAttribute(string name = null)
		: base(name)
	{
	}
}
