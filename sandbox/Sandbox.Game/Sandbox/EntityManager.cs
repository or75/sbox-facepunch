using System;
using System.Runtime.CompilerServices;
using NativeEngine;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x0200007E RID: 126
	public static class EntityManager
	{
		/// <summary>
		/// The engine wants to create this entity by name.
		/// </summary>
		// Token: 0x06000CE8 RID: 3304 RVA: 0x000416D4 File Offset: 0x0003F8D4
		internal static CEntityInstance CreateServerEntity(string entityName)
		{
			if (entityName == "worldspawn")
			{
				CEntityInstance result = default(CEntityInstance);
				return result;
			}
			Entity ent = Library.Create<Entity>(entityName, false);
			try
			{
				if (ent == null)
				{
					ent = new Entity(entityName);
				}
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("CreateServerEntity: {0}", new object[] { e.Message }));
				CEntityInstance result = default(CEntityInstance);
				return result;
			}
			return ent.serverEnt;
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x0004175C File Offset: 0x0003F95C
		internal static void CreateClientsideOfNetworkedEntity(C_BaseEntity baseEnt, int managedClassIdent)
		{
			Host.AssertClient("CreateClientsideOfNetworkedEntity");
			try
			{
				Entity.IncomingClientInstance = baseEnt;
				if (managedClassIdent == 0)
				{
					new Entity();
				}
				else if (Library.TryCreate<Entity>(managedClassIdent) == null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(42, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Unknown entity with id ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(baseEnt.entindex());
					defaultInterpolatedStringHandler.AppendLiteral(" (native class is ");
					defaultInterpolatedStringHandler.AppendFormatted(baseEnt.GetClassname());
					defaultInterpolatedStringHandler.AppendLiteral(")");
					throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
				}
			}
			finally
			{
				Entity.IncomingClientInstance = IntPtr.Zero;
			}
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x00041804 File Offset: 0x0003FA04
		internal static void Shutdown()
		{
			if (Entity.All.Count != 0)
			{
				EntityManager.log.Error(FormattableStringFactory.Create("Something fucked up, there are {0} unreleased entities!", new object[] { Entity.All.Count }));
			}
			Entity.InternalAll.Clear();
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x00041854 File Offset: 0x0003FA54
		[Event.HotloadAttribute]
		internal static void OnHotloaded()
		{
			foreach (Entity entity in Entity.All)
			{
				entity.OnHotloaded();
			}
		}

		// Token: 0x040001D2 RID: 466
		private static Logger log = Logging.GetLogger(null);
	}
}
