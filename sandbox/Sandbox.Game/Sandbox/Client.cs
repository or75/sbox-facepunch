using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x02000097 RID: 151
	public interface Client : IClient, IEntity
	{
		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000F8E RID: 3982 RVA: 0x0004719C File Offset: 0x0004539C
		IReadOnlyList<Client> All
		{
			get
			{
				return Client._all.AsReadOnly();
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000F8F RID: 3983
		bool IsBot { get; }

		/// <summary>
		/// The Id of this client. This is generally their SteamId.
		/// </summary>
		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000F90 RID: 3984
		long PlayerId { get; }

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000F91 RID: 3985 RVA: 0x000471A8 File Offset: 0x000453A8
		[Obsolete("Please use PlayerId instead of SteamId")]
		[Browsable(false)]
		ulong SteamId
		{
			get
			{
				return (ulong)this.PlayerId;
			}
		}

		/// <summary>
		/// The Steam name of this client.
		/// </summary>
		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000F92 RID: 3986
		string Name { get; }

		/// <summary>
		/// The entity ID of this client. These will be reused as players join and leave.
		/// </summary>
		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000F93 RID: 3987
		int NetworkIdent { get; }

		/// <summary>
		/// User ID of this client. These IDs will never be reused, even for the same player after rejoin.
		/// </summary>
		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000F94 RID: 3988
		int SessionId { get; }

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000F95 RID: 3989 RVA: 0x000471B0 File Offset: 0x000453B0
		[Obsolete("Why are you using this? Use PlayerId instead?")]
		int UserId
		{
			get
			{
				return this.SessionId;
			}
		}

		/// <summary>
		/// Last voice level heard
		/// </summary>
		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000F96 RID: 3990
		// (set) Token: 0x06000F97 RID: 3991
		float VoiceLevel { get; set; }

		/// <summary>
		/// Time since client last spoke on voice chat
		/// </summary>
		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000F98 RID: 3992
		// (set) Token: 0x06000F99 RID: 3993
		TimeSince TimeSinceLastVoice { get; set; }

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000F9A RID: 3994
		bool IsUsingVr { get; }

		// Token: 0x06000F9B RID: 3995
		bool HasPermission(string v);

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000F9C RID: 3996
		// (set) Token: 0x06000F9D RID: 3997
		ICamera Camera { get; set; }

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000F9E RID: 3998
		// (set) Token: 0x06000F9F RID: 3999
		ICamera DevCamera { get; set; }

		// Token: 0x06000FA0 RID: 4000
		void SetValue(string key, object value);

		// Token: 0x06000FA1 RID: 4001
		T GetValue<T>(string key, T defaultValue = default(T));

		// Token: 0x06000FA2 RID: 4002 RVA: 0x000471B8 File Offset: 0x000453B8
		void SetInt(string key, int value)
		{
			this.SetValue(key, value);
		}

		// Token: 0x06000FA3 RID: 4003 RVA: 0x000471C7 File Offset: 0x000453C7
		int GetInt(string key, int defaultValue = 0)
		{
			return this.GetValue<int>(key, defaultValue);
		}

		// Token: 0x06000FA4 RID: 4004 RVA: 0x000471D1 File Offset: 0x000453D1
		void AddInt(string key, int value = 1)
		{
			this.SetInt(key, this.GetInt(key, 0) + value);
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000FA5 RID: 4005
		PvsConfig Pvs { get; }

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000FA6 RID: 4006
		// (set) Token: 0x06000FA7 RID: 4007
		Entity Pawn { get; set; }

		/// <summary>
		/// Gets the convar value from a ClientData convar
		/// </summary>
		// Token: 0x06000FA8 RID: 4008
		string GetClientData(string key, string defaultValue = null);

		/// <summary>
		/// Gets the convar value from a ClientData convar
		/// </summary>
		// Token: 0x06000FA9 RID: 4009
		T GetClientData<T>(string key, T defaultValue = default(T));

		// Token: 0x06000FAA RID: 4010
		void SendCommandToClient(string command);

		/// <summary>
		/// Kick this client from the server.
		/// </summary>
		// Token: 0x06000FAB RID: 4011
		void Kick();

		/// <summary>
		/// Returns true if this client is the listen server host
		/// </summary>
		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000FAC RID: 4012
		bool IsListenServerHost { get; }

		/// <summary>
		/// Set/Get components for this client
		/// </summary>
		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000FAD RID: 4013
		EntityComponentAccessor Components { get; }

		/// <summary>
		/// The time it takes for a network message to get to this client
		/// </summary>
		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000FAE RID: 4014
		int Ping { get; }

		/// <summary>
		/// This client's packet loss as a percentage (0-100)
		/// </summary>
		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000FAF RID: 4015
		int PacketLoss { get; }

		// Token: 0x06000FB0 RID: 4016 RVA: 0x000471E4 File Offset: 0x000453E4
		[Obsolete]
		void SetScore(string key, object value)
		{
			this.SetValue(key, value);
		}

		// Token: 0x06000FB1 RID: 4017 RVA: 0x000471EE File Offset: 0x000453EE
		[Obsolete]
		T GetScore<T>(string key, T defaultValue = default(T))
		{
			return this.GetValue<T>(key, defaultValue);
		}

		// Token: 0x06000FB2 RID: 4018
		void SetGameResult(GameplayResult wld, float score = 0f);

		// Token: 0x06000FB3 RID: 4019 RVA: 0x000471F8 File Offset: 0x000453F8
		void SetGameResult(GameplayResult wld, int score)
		{
			this.SetGameResult(wld, (float)score);
		}

		// Token: 0x06000FB4 RID: 4020 RVA: 0x00047203 File Offset: 0x00045403
		void SetGameResult(GameplayResult wld, TimeSpan score)
		{
			this.SetGameResult(wld, (float)score.TotalSeconds);
		}

		// Token: 0x06000FB5 RID: 4021 RVA: 0x00047214 File Offset: 0x00045414
		Task<PlayerGameRank> FetchGameRankAsync()
		{
			Client.<FetchGameRankAsync>d__59 <FetchGameRankAsync>d__;
			<FetchGameRankAsync>d__.<>t__builder = AsyncTaskMethodBuilder<PlayerGameRank>.Create();
			<FetchGameRankAsync>d__.<>4__this = this;
			<FetchGameRankAsync>d__.<>1__state = -1;
			<FetchGameRankAsync>d__.<>t__builder.Start<Client.<FetchGameRankAsync>d__59>(ref <FetchGameRankAsync>d__);
			return <FetchGameRankAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0400028C RID: 652
		internal static List<Client> _all = new List<Client>();
	}
}
