using System;
using System.Collections.Generic;

namespace Sandbox
{
	// Token: 0x02000099 RID: 153
	public class PvsConfig
	{
		/// <summary>
		/// Add an entity tp the player's PVS. The player will be able to see everything that this entity can see.
		/// </summary>
		// Token: 0x06000FEA RID: 4074 RVA: 0x00047A4D File Offset: 0x00045C4D
		public void Add(Entity ent)
		{
			Assert.True(ent.IsValid());
			if (this.Ents == null)
			{
				this.Ents = new List<Entity>();
			}
			this.Ents.Add(ent);
		}

		/// <summary>
		/// Remove entity from this player's PVS
		/// </summary>
		// Token: 0x06000FEB RID: 4075 RVA: 0x00047A79 File Offset: 0x00045C79
		public void Remove(Entity ent)
		{
			if (this.Ents == null)
			{
				return;
			}
			this.Ents.Remove(ent);
		}

		/// <summary>
		/// Remove all specialization
		/// </summary>
		// Token: 0x06000FEC RID: 4076 RVA: 0x00047A91 File Offset: 0x00045C91
		public void Clear()
		{
			this.Ents = null;
		}

		/// <summary>
		/// Remove all entries that aren't value
		/// </summary>
		// Token: 0x06000FED RID: 4077 RVA: 0x00047A9C File Offset: 0x00045C9C
		internal void Clean()
		{
			if (this.Ents == null || this.Ents.Count == 0)
			{
				return;
			}
			this.Ents.RemoveAll((Entity x) => !x.IsValid());
		}

		// Token: 0x04000298 RID: 664
		internal List<Entity> Ents;
	}
}
