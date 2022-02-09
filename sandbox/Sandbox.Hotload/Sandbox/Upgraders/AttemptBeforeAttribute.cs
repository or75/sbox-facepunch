using System;

namespace Sandbox.Upgraders
{
	/// <summary>
	/// Use this attribute to specify that a <see cref="T:Sandbox.Hotload.IInstanceUpgrader" /> should attempt to process
	/// each object before all other specified <see cref="T:Sandbox.Hotload.IInstanceUpgrader" /> types.
	/// </summary>
	// Token: 0x02000022 RID: 34
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class AttemptBeforeAttribute : Attribute
	{
		/// <summary>
		/// <see cref="T:Sandbox.Hotload.IInstanceUpgrader" /> types that should attempt to process each object after the type this attribute is on.
		/// </summary>
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x000063A3 File Offset: 0x000045A3
		public Type[] InstanceUpgraderTypes { get; }

		/// <summary>
		/// Create an instance of <see cref="T:Sandbox.Upgraders.AttemptBeforeAttribute" /> with a list of <see cref="T:Sandbox.Hotload.IInstanceUpgrader" /> types.
		/// </summary>
		/// <param name="instanceUpgraderTypes">One or more <see cref="T:Sandbox.Hotload.IInstanceUpgrader" /> types.</param>
		// Token: 0x060000EA RID: 234 RVA: 0x000063AB File Offset: 0x000045AB
		public AttemptBeforeAttribute(params Type[] instanceUpgraderTypes)
		{
			this.InstanceUpgraderTypes = instanceUpgraderTypes;
		}
	}
}
