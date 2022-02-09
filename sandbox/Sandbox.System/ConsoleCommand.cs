using System;
using Sandbox;

// Token: 0x0200000B RID: 11
[AttributeUsage(AttributeTargets.Method)]
public abstract class ConsoleCommand : ConVar.BaseAttribute
{
	// Token: 0x06000024 RID: 36 RVA: 0x00002255 File Offset: 0x00000455
	public ConsoleCommand(string Name = null)
	{
		base.Name = Name;
	}
}
