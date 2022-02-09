using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Sandbox.Engine;

namespace Sandbox.Internal
{
	// Token: 0x020002EC RID: 748
	internal static class EntityRegistry
	{
		// Token: 0x060013DE RID: 5086 RVA: 0x0002A940 File Offset: 0x00028B40
		internal static EntityEntry Get(int id, bool create)
		{
			EntityEntry entry;
			if (EntityRegistry.Entries.TryGetValue(id, out entry))
			{
				return entry;
			}
			if (!create)
			{
				return null;
			}
			entry = new EntityEntry
			{
				Id = id
			};
			EntityRegistry.Entries[id] = entry;
			EntityRegistry.EntriesList.Add(entry);
			IToolsDll toolsDll = IToolsDll.Current;
			if (toolsDll != null)
			{
				toolsDll.RunEvent("entity.added", entry);
			}
			return entry;
		}

		// Token: 0x060013DF RID: 5087 RVA: 0x0002A9A0 File Offset: 0x00028BA0
		internal static void Add(bool server, int id, IEntity entity)
		{
			if (!Bootstrap.IsToolsMode)
			{
				return;
			}
			EntityEntry entry = EntityRegistry.Get(id, true);
			if (server)
			{
				if (entry.Server != null)
				{
					GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("EntityRegistry: {0} already has a server entry!", new object[] { id }));
				}
				entry.Server = entity;
				return;
			}
			if (entry.Client != null)
			{
				GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("EntityRegistry: {0} already has a client entry!", new object[] { id }));
			}
			entry.Client = entity;
		}

		// Token: 0x060013E0 RID: 5088 RVA: 0x0002AA28 File Offset: 0x00028C28
		internal static void Remove(bool server, int id)
		{
			if (!Bootstrap.IsToolsMode)
			{
				return;
			}
			EntityEntry entry = EntityRegistry.Get(id, false);
			if (entry == null)
			{
				return;
			}
			if (server)
			{
				if (entry.Server == null)
				{
					GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("EntityRegistry: {0} has no server entry!", new object[] { id }));
				}
				entry.Server = null;
			}
			else
			{
				if (entry.Client == null)
				{
					GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("EntityRegistry: {0} has no client entry!", new object[] { id }));
				}
				entry.Client = null;
			}
			if (entry.Server == null && entry.Client == null)
			{
				EntityRegistry.Entries.Remove(id);
				EntityRegistry.EntriesList.Remove(entry);
				IToolsDll toolsDll = IToolsDll.Current;
				if (toolsDll == null)
				{
					return;
				}
				toolsDll.RunEvent("entity.removed", entry);
			}
		}

		// Token: 0x060013E1 RID: 5089 RVA: 0x0002AAF0 File Offset: 0x00028CF0
		internal static void Changed(int id)
		{
			if (!Bootstrap.IsToolsMode)
			{
				return;
			}
			EntityEntry entry = EntityRegistry.Get(id, false);
			if (entry == null)
			{
				return;
			}
			IToolsDll toolsDll = IToolsDll.Current;
			if (toolsDll == null)
			{
				return;
			}
			toolsDll.RunEvent("entity.changed", entry);
		}

		// Token: 0x060013E2 RID: 5090 RVA: 0x0002AB28 File Offset: 0x00028D28
		internal static void ParentChanged(int id)
		{
			if (!Bootstrap.IsToolsMode)
			{
				return;
			}
			EntityEntry entry = EntityRegistry.Get(id, false);
			if (entry == null)
			{
				return;
			}
			IToolsDll toolsDll = IToolsDll.Current;
			if (toolsDll == null)
			{
				return;
			}
			toolsDll.RunEvent("entity.parentchanged", entry);
		}

		// Token: 0x04001527 RID: 5415
		internal static Dictionary<int, EntityEntry> Entries = new Dictionary<int, EntityEntry>();

		// Token: 0x04001528 RID: 5416
		internal static List<EntityEntry> EntriesList = new List<EntityEntry>();
	}
}
