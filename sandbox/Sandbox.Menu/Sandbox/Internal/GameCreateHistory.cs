using System;
using System.Collections.Generic;

namespace Sandbox.Internal
{
	// Token: 0x0200000E RID: 14
	public class GameCreateHistory
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00003333 File Offset: 0x00001533
		// (set) Token: 0x0600003E RID: 62 RVA: 0x0000333B File Offset: 0x0000153B
		public Package Package { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00003344 File Offset: 0x00001544
		// (set) Token: 0x06000040 RID: 64 RVA: 0x0000334C File Offset: 0x0000154C
		public Dictionary<string, string> Config { get; set; }

		// Token: 0x06000041 RID: 65 RVA: 0x00003358 File Offset: 0x00001558
		internal static void OnCreateGame(Package game, Dictionary<string, string> details)
		{
			Host.AssertMenu("OnCreateGame");
			List<GameCreateHistory> list = GameCreateHistory.GetHistory();
			list.RemoveAll((GameCreateHistory x) => x.Package == null || x.Package.FullIdent == game.FullIdent);
			while (list.Count > 10)
			{
				list.RemoveAt(list.Count - 1);
			}
			list.Insert(0, new GameCreateHistory
			{
				Package = game,
				Config = details
			});
			GlobalGameNamespace.Cookie.Set<List<GameCreateHistory>>("created_games", list);
			GlobalGameNamespace.Cookie.Save();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000033E8 File Offset: 0x000015E8
		public static List<GameCreateHistory> GetHistory()
		{
			Host.AssertMenu("GetHistory");
			return GlobalGameNamespace.Cookie.Get<List<GameCreateHistory>>("created_games", null) ?? new List<GameCreateHistory>();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003410 File Offset: 0x00001610
		public static void Remove(string ident)
		{
			Host.AssertMenu("Remove");
			List<GameCreateHistory> list = GameCreateHistory.GetHistory();
			list.RemoveAll((GameCreateHistory x) => x.Package.FullIdent == ident);
			GlobalGameNamespace.Cookie.Set<List<GameCreateHistory>>("created_games", list);
			GlobalGameNamespace.Cookie.Save();
		}
	}
}
