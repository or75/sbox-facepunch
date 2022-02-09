using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Sandbox;
using Sandbox.Internal;

// Token: 0x02000007 RID: 7
public static class GameServices
{
	/// <summary>
	/// End the game. Submit and clear scores.
	/// </summary>
	// Token: 0x06000018 RID: 24 RVA: 0x000026C4 File Offset: 0x000008C4
	public static void EndGame()
	{
		if (GameServices.Desc == null)
		{
			return;
		}
		Host.AssertServer("EndGame");
		GameServices.Desc.EndTime = DateTime.UtcNow;
		Api.Commit(GameServices.Desc);
		GameServices.Desc = null;
	}

	/// <summary>
	/// Record this player's score
	/// </summary>
	// Token: 0x06000019 RID: 25 RVA: 0x000026FD File Offset: 0x000008FD
	public static void RecordScore(long steamId, bool isBot, GameplayResult result, float score)
	{
		if (GameServices.Desc == null)
		{
			return;
		}
		Host.AssertServer("RecordScore");
		GameDescription.PlayerInfo player = GameServices.Desc.GetPlayer(steamId, isBot);
		player.Result = result;
		player.Score = score;
	}

	/// <summary>
	/// Abandon the game. Set playerLeave to true if the game was ended because 
	/// a player left and they should probably be pubished for it.
	/// </summary>
	// Token: 0x0600001A RID: 26 RVA: 0x0000272A File Offset: 0x0000092A
	public static void AbandonGame(bool playerLeave = false)
	{
		if (GameServices.Desc == null)
		{
			return;
		}
		GameServices.Desc.Abandoned = true;
		GameServices.Desc.AbandonedBecausePlayerLeave = playerLeave;
		GameServices.EndGame();
	}

	/// <summary>
	/// Start the game. Start recording shit.
	/// </summary>
	// Token: 0x0600001B RID: 27 RVA: 0x00002750 File Offset: 0x00000950
	public static void StartGame()
	{
		Host.AssertServer("StartGame");
		GameServices.Desc = new GameDescription(GlobalGameNamespace.Global.GameName, GlobalGameNamespace.Global.MapName);
		GameServices.Desc.StartTime = DateTime.UtcNow;
		foreach (KeyValuePair<string, ValueTuple<Assembly, int>> assembly in GameAssemblyManager.Loaded)
		{
			GameServices.Desc.AddAssembly(assembly.Key, assembly.Value.Item2);
		}
		foreach (Client client in Client.All)
		{
			GameDescription.PlayerInfo player = new GameDescription.PlayerInfo(client.PlayerId, client.IsBot);
			player.FromStart = true;
			GameServices.Desc.Players.Add(player);
		}
	}

	/// <summary>
	/// Record a game event (for diagnostic reasons)
	/// </summary>
	// Token: 0x0600001C RID: 28 RVA: 0x00002854 File Offset: 0x00000A54
	[NullableContext(1)]
	public static void RecordEvent(Client client, string detail, int? score = null, [Nullable(2)] Client victim = null)
	{
		GameServices.RecordEvent(client.PlayerId, detail, score, (victim != null) ? new long?(victim.PlayerId) : null);
	}

	/// <summary>
	/// Record a game event (for diagnostic reasons)
	/// </summary>
	// Token: 0x0600001D RID: 29 RVA: 0x00002888 File Offset: 0x00000A88
	[NullableContext(1)]
	public static void RecordEvent(long steamid, string detail, int? score = null, long? victimsteamid = null)
	{
		if (GameServices.Desc == null)
		{
			return;
		}
		GameDescription.LogEntry entry = new GameDescription.LogEntry(detail);
		entry.UserId = steamid.ToString();
		entry.VictimId = ((victimsteamid != null) ? victimsteamid.GetValueOrDefault().ToString() : null);
		entry.Score = score;
		GameServices.Desc.Log.Add(entry);
	}

	/// <summary>
	/// A player left the game
	/// </summary>
	// Token: 0x0600001E RID: 30 RVA: 0x000028EC File Offset: 0x00000AEC
	internal static void PlayerLeave(long steamid)
	{
		if (GameServices.Desc == null)
		{
			return;
		}
		GameDescription.PlayerInfo player = GameServices.Desc.FindPlayer(steamid);
		if (player == null)
		{
			return;
		}
		player.Disconnect = true;
		player.LastSeen = DateTime.UtcNow;
	}

	// Token: 0x04000011 RID: 17
	[Nullable(2)]
	private static GameDescription Desc;

	// Token: 0x02000194 RID: 404
	public static class Leaderboard
	{
		/// <summary>
		/// Query the API for leaderboard entries
		/// </summary>
		// Token: 0x06001CCB RID: 7371 RVA: 0x00072598 File Offset: 0x00070798
		[NullableContext(1)]
		public static async Task<LeaderboardResult> Query(string game, long? playerid = null, [Nullable(2)] string bucket = null, long? skip = null, long? take = null)
		{
			Dictionary<string, object> o = new Dictionary<string, object> { { "game", game } };
			if (playerid != null)
			{
				o["playerid"] = playerid;
			}
			if (bucket != null)
			{
				o["bucket"] = bucket;
			}
			if (skip != null)
			{
				o["skip"] = skip;
			}
			if (take != null)
			{
				o["take"] = take;
			}
			return await Api.GetAsync<LeaderboardResult>("sandbox-asset-leaderboard", o, 300f);
		}
	}
}
