using System;

namespace Sandbox
{
	/// <summary>
	/// Mark a property as networked, so it is sent from the server to the client.
	/// </summary>
	// Token: 0x02000039 RID: 57
	[AttributeUsage(AttributeTargets.Property)]
	public class NetAttribute : Attribute
	{
	}
}
