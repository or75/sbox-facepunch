using System;
using System.ComponentModel.DataAnnotations;
using Hammer;

namespace Sandbox
{
	/// <summary>
	/// The world entity.
	/// </summary>
	// Token: 0x020000A2 RID: 162
	[Library("worldent")]
	[Skip]
	[Display(Name = "World")]
	[Icon("public")]
	public class WorldEntity : ModelEntity
	{
		// Token: 0x17000220 RID: 544
		// (get) Token: 0x060010DC RID: 4316 RVA: 0x00048D4C File Offset: 0x00046F4C
		internal override string NativeEntityClass
		{
			get
			{
				return "worldent";
			}
		}

		// Token: 0x060010DD RID: 4317 RVA: 0x00048D53 File Offset: 0x00046F53
		public override void Spawn()
		{
			base.Spawn();
			this.Tags.Add("World");
			base.Transmit = TransmitType.Always;
		}
	}
}
