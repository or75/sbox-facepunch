using System;

namespace Sandbox
{
	/// <summary>
	/// Combined with [Net], will mean the variable is only sent to the entity's Client.
	/// </summary>
	// Token: 0x0200003A RID: 58
	[AttributeUsage(AttributeTargets.Property)]
	public class LocalAttribute : NetAttribute
	{
	}
}
