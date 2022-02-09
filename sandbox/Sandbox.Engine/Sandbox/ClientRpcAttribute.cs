using System;

namespace Sandbox
{
	/// <summary>
	/// A method that can be called by the server
	/// </summary>
	// Token: 0x020002B5 RID: 693
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class ClientRpcAttribute : Attribute
	{
	}
}
