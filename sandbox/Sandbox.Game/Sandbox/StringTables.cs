using System;

namespace Sandbox
{
	// Token: 0x020000D0 RID: 208
	[Hotload.SkipAttribute]
	internal static class StringTables
	{
		/// <summary>
		/// On server this gets called once
		/// On client this can get called multiple times
		/// </summary>
		// Token: 0x0600127A RID: 4730 RVA: 0x0004DDC5 File Offset: 0x0004BFC5
		internal static void Init()
		{
			StringTables.Assemblies.RefreshPointers();
			StringTables.Assets.RefreshPointers();
			StringTables.Precache.RefreshPointers();
			StringTables.StringPool.RefreshPointers();
		}

		// Token: 0x0600127B RID: 4731 RVA: 0x0004DDEF File Offset: 0x0004BFEF
		internal static void Shutdown()
		{
			StringTables.Assemblies.Shutdown();
			StringTables.Assets.Shutdown();
			StringTables.Precache.Shutdown();
			StringTables.StringPool.Shutdown();
		}

		// Token: 0x040003DF RID: 991
		private static readonly Logger log = Logging.GetLogger(null);

		// Token: 0x040003E0 RID: 992
		internal static StringTable Assemblies = new StringTable("Assemblies");

		// Token: 0x040003E1 RID: 993
		internal static StringTable Assets = new StringTable("Assets");

		// Token: 0x040003E2 RID: 994
		internal static StringTable Precache = new StringTable("Precache");

		// Token: 0x040003E3 RID: 995
		internal static StringTable StringPool = new StringTable("StringPool");
	}
}
