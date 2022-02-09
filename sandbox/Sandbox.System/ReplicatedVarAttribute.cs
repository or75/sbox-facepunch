using System;

// Token: 0x02000008 RID: 8
[Obsolete]
[AttributeUsage(AttributeTargets.Property)]
public class ReplicatedVarAttribute : ConsoleVariableAttribute
{
	// Token: 0x17000006 RID: 6
	// (get) Token: 0x06000018 RID: 24 RVA: 0x0000221F File Offset: 0x0000041F
	internal override bool IsServer
	{
		get
		{
			return true;
		}
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x06000019 RID: 25 RVA: 0x00002222 File Offset: 0x00000422
	internal override bool IsClient
	{
		get
		{
			return true;
		}
	}

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x0600001A RID: 26 RVA: 0x00002225 File Offset: 0x00000425
	internal override bool Protected
	{
		get
		{
			return true;
		}
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00002228 File Offset: 0x00000428
	public ReplicatedVarAttribute(string name = null)
		: base(name)
	{
	}
}
