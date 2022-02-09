using System;

namespace Sandbox
{
	/// <summary>
	/// Variable gets saved and restored with other predicted variables. If it's also [Net]worked it'll
	/// be checked with the networked version to make sure it matches for each tick.
	/// </summary>
	// Token: 0x0200003B RID: 59
	[AttributeUsage(AttributeTargets.Property)]
	public class PredictedAttribute : Attribute
	{
	}
}
