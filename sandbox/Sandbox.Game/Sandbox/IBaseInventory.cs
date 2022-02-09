using System;

namespace Sandbox
{
	// Token: 0x020000AA RID: 170
	public interface IBaseInventory
	{
		// Token: 0x0600113C RID: 4412
		void OnChildAdded(Entity child);

		// Token: 0x0600113D RID: 4413
		void OnChildRemoved(Entity child);

		// Token: 0x0600113E RID: 4414
		void DeleteContents();

		// Token: 0x0600113F RID: 4415
		int Count();

		// Token: 0x06001140 RID: 4416
		Entity GetSlot(int i);

		// Token: 0x06001141 RID: 4417
		int GetActiveSlot();

		// Token: 0x06001142 RID: 4418
		bool SetActiveSlot(int i, bool allowempty);

		// Token: 0x06001143 RID: 4419
		bool SwitchActiveSlot(int idelta, bool loop);

		// Token: 0x06001144 RID: 4420
		Entity DropActive();

		// Token: 0x06001145 RID: 4421
		bool Drop(Entity ent);

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06001146 RID: 4422
		Entity Active { get; }

		// Token: 0x06001147 RID: 4423
		bool SetActive(Entity ent);

		// Token: 0x06001148 RID: 4424
		bool Add(Entity ent, bool makeactive = false);

		// Token: 0x06001149 RID: 4425
		bool Contains(Entity ent);
	}
}
