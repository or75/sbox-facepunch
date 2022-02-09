using System;

// Token: 0x02000009 RID: 9
[Obsolete]
[AttributeUsage(AttributeTargets.Property)]
public class UserVarAttribute : ConsoleVariableAttribute
{
	// Token: 0x17000009 RID: 9
	// (get) Token: 0x0600001C RID: 28 RVA: 0x00002231 File Offset: 0x00000431
	internal override bool IsServer
	{
		get
		{
			return false;
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x0600001D RID: 29 RVA: 0x00002234 File Offset: 0x00000434
	internal override bool IsClient
	{
		get
		{
			return true;
		}
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x0600001E RID: 30 RVA: 0x00002237 File Offset: 0x00000437
	internal override bool Protected
	{
		get
		{
			return false;
		}
	}

	// Token: 0x0600001F RID: 31 RVA: 0x0000223A File Offset: 0x0000043A
	public UserVarAttribute(string name = null)
		: base(name)
	{
	}
}
