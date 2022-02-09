using System;

/// <summary>
/// Clientside console variable.
/// </summary>
// Token: 0x02000007 RID: 7
[AttributeUsage(AttributeTargets.Property)]
public class ClientVarAttribute : ConsoleVariableAttribute
{
	// Token: 0x17000004 RID: 4
	// (get) Token: 0x06000015 RID: 21 RVA: 0x00002210 File Offset: 0x00000410
	internal override bool IsServer
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x06000016 RID: 22 RVA: 0x00002213 File Offset: 0x00000413
	internal override bool IsClient
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00002216 File Offset: 0x00000416
	public ClientVarAttribute(string name = null)
		: base(name)
	{
	}
}
