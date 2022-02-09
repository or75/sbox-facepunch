using System;
using System.Collections.Generic;

namespace Sandbox.Internal
{
	// Token: 0x020002EB RID: 747
	public class EntityEntry
	{
		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x060013D7 RID: 5079 RVA: 0x0002A83D File Offset: 0x00028A3D
		// (set) Token: 0x060013D8 RID: 5080 RVA: 0x0002A845 File Offset: 0x00028A45
		public float FirstSeen { get; set; } = RealTime.Now;

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x060013D9 RID: 5081 RVA: 0x0002A84E File Offset: 0x00028A4E
		public IEntity AnyEntity
		{
			get
			{
				return this.Server ?? this.Client;
			}
		}

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x060013DA RID: 5082 RVA: 0x0002A860 File Offset: 0x00028A60
		public bool IsClientOnly
		{
			get
			{
				return this.Id < 0;
			}
		}

		// Token: 0x060013DB RID: 5083 RVA: 0x0002A86C File Offset: 0x00028A6C
		public EntityEntry FindParent()
		{
			IEntity server = this.Server;
			int? num;
			if (server == null)
			{
				num = null;
			}
			else
			{
				IEntity parent = server.Parent;
				num = ((parent != null) ? new int?(parent.Id) : null);
			}
			int? num2 = num;
			int num4;
			if (num2 == null)
			{
				IEntity client = this.Client;
				int? num3;
				if (client == null)
				{
					num3 = null;
				}
				else
				{
					IEntity parent2 = client.Parent;
					num3 = ((parent2 != null) ? new int?(parent2.Id) : null);
				}
				num4 = num3 ?? (-1);
			}
			else
			{
				num4 = num2.GetValueOrDefault();
			}
			int parentId = num4;
			if (parentId == -1)
			{
				return null;
			}
			EntityEntry entry;
			if (EntityRegistry.Entries.TryGetValue(parentId, out entry))
			{
				return entry;
			}
			return null;
		}

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x060013DC RID: 5084 RVA: 0x0002A921 File Offset: 0x00028B21
		public static IReadOnlyList<EntityEntry> All
		{
			get
			{
				return EntityRegistry.EntriesList.AsReadOnly();
			}
		}

		// Token: 0x04001523 RID: 5411
		public int Id;

		// Token: 0x04001524 RID: 5412
		public IEntity Server;

		// Token: 0x04001525 RID: 5413
		public IEntity Client;
	}
}
