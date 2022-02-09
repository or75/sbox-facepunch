using System;

namespace Sandbox
{
	/// <summary>
	/// Indicates that this type should generate meta data. Tagging your asset with this will
	/// mean that the .asset file is automatically generated - which means you don't have to do that.
	/// </summary>
	// Token: 0x020002A9 RID: 681
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class AutoGenerateAttribute : Attribute
	{
	}
}
