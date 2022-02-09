using System;

namespace Sandbox
{
	// Token: 0x02000088 RID: 136
	public class EntityComponent<T> : EntityComponent where T : Entity
	{
		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000E3E RID: 3646 RVA: 0x00044FBA File Offset: 0x000431BA
		// (set) Token: 0x06000E3F RID: 3647 RVA: 0x00044FCC File Offset: 0x000431CC
		public new T Entity
		{
			get
			{
				return base.Entity as T;
			}
			set
			{
				this.Entity = value;
			}
		}

		/// <summary>
		/// Return false if target entity is not of type T
		/// </summary>
		// Token: 0x06000E40 RID: 3648 RVA: 0x00044FD5 File Offset: 0x000431D5
		public override bool CanAddToEntity(Entity entity)
		{
			return entity is T;
		}
	}
}
