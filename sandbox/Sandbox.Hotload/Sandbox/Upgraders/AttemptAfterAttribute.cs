using System;

namespace Sandbox.Upgraders
{
	/// <summary>
	/// Use this attribute to specify that a <see cref="T:Sandbox.Hotload.IInstanceUpgrader" /> should attempt to process
	/// each object after all other specified <see cref="T:Sandbox.Hotload.IInstanceUpgrader" /> types.
	/// </summary>
	// Token: 0x02000023 RID: 35
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class AttemptAfterAttribute : Attribute
	{
		/// <summary>
		/// <see cref="T:Sandbox.Hotload.IInstanceUpgrader" /> types that should attempt to process each object before the type this attribute is on.
		/// </summary>
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000EB RID: 235 RVA: 0x000063BA File Offset: 0x000045BA
		public Type[] InstanceUpgraderTypes { get; }

		/// <summary>
		/// Create an instance of <see cref="T:Sandbox.Upgraders.AttemptAfterAttribute" /> with a list of <see cref="T:Sandbox.Hotload.IInstanceUpgrader" /> types.
		/// </summary>
		/// <param name="instanceUpgraderTypes">One or more <see cref="T:Sandbox.Hotload.IInstanceUpgrader" /> types.</param>
		// Token: 0x060000EC RID: 236 RVA: 0x000063C2 File Offset: 0x000045C2
		public AttemptAfterAttribute(params Type[] instanceUpgraderTypes)
		{
			this.InstanceUpgraderTypes = instanceUpgraderTypes;
		}
	}
}
