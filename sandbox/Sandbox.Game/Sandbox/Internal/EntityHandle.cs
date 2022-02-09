using System;

namespace Sandbox.Internal
{
	/// <summary>
	/// This is how entities are networked via NetworkAtomic. You can access this like a normal entity.
	/// The downside is that each time you "get" the entity it's a FindByIndex. Which sucks. So I might roll this back.
	/// </summary>
	// Token: 0x02000173 RID: 371
	public struct EntityHandle<T> where T : Entity
	{
		// Token: 0x06001B8F RID: 7055 RVA: 0x0006EEF8 File Offset: 0x0006D0F8
		public static implicit operator EntityHandle<T>(T value)
		{
			EntityHandle<T> result = default(EntityHandle<T>);
			T t = value;
			result.EntityId = ((t != null) ? (t.NetworkIdent + 1) : 0);
			return result;
		}

		// Token: 0x06001B90 RID: 7056 RVA: 0x0006EF2C File Offset: 0x0006D12C
		public static implicit operator T(EntityHandle<T> value)
		{
			if (value.EntityId <= 0)
			{
				return default(T);
			}
			return Entity.FindByIndex(value.EntityId - 1) as T;
		}

		// Token: 0x0400078A RID: 1930
		public int EntityId;
	}
}
