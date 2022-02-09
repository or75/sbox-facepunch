using System;
using Sandbox;

// Token: 0x02000006 RID: 6
[AttributeUsage(AttributeTargets.Property)]
public class ConsoleVariableAttribute : ConVar.BaseAttribute
{
	/// <summary>
	/// TODO: Implement
	/// </summary>
	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000012 RID: 18 RVA: 0x000021F0 File Offset: 0x000003F0
	// (set) Token: 0x06000013 RID: 19 RVA: 0x000021F8 File Offset: 0x000003F8
	public bool Saved { get; set; }

	// Token: 0x06000014 RID: 20 RVA: 0x00002201 File Offset: 0x00000401
	public ConsoleVariableAttribute(string Name = null)
	{
		base.Name = Name;
	}
}
