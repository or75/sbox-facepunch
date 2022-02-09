using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Hammer;
using NativeEngine;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x02000098 RID: 152
	[Library("client")]
	[Skip]
	[Display(Name = "Client")]
	[Icon("account_circle")]
	internal sealed class ClientEntity : Entity, Client, IClient, IEntity
	{
		/// <summary>
		/// Returns true if this is the local player. This will
		/// only return true on the client for the player that is
		/// being controlled. It won't ever return true serverside.
		/// </summary>
		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000FB7 RID: 4023 RVA: 0x00047263 File Offset: 0x00045463
		[Category("Client")]
		public bool IsLocalPlayer
		{
			get
			{
				return Local.Client == this;
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000FB8 RID: 4024 RVA: 0x0004726D File Offset: 0x0004546D
		// (set) Token: 0x06000FB9 RID: 4025 RVA: 0x0004727B File Offset: 0x0004547B
		[Category("Client")]
		[Net]
		public unsafe bool IsBot
		{
			get
			{
				return *this.__isBot.GetValue();
			}
			internal set
			{
				this.__isBot.SetValue(value);
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06000FBA RID: 4026 RVA: 0x0004728A File Offset: 0x0004548A
		// (set) Token: 0x06000FBB RID: 4027 RVA: 0x00047292 File Offset: 0x00045492
		[Category("Client")]
		public bool IsUsingVr { get; set; }

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000FBC RID: 4028 RVA: 0x0004729B File Offset: 0x0004549B
		// (set) Token: 0x06000FBD RID: 4029 RVA: 0x000472A3 File Offset: 0x000454A3
		[Category("Client")]
		public float VoiceLevel { get; set; }

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000FBE RID: 4030 RVA: 0x000472AC File Offset: 0x000454AC
		// (set) Token: 0x06000FBF RID: 4031 RVA: 0x000472B4 File Offset: 0x000454B4
		[Category("Client")]
		public TimeSince TimeSinceLastVoice { get; set; }

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000FC0 RID: 4032 RVA: 0x000472BD File Offset: 0x000454BD
		internal override string NativeEntityClass
		{
			get
			{
				return "player";
			}
		}

		// Token: 0x06000FC1 RID: 4033 RVA: 0x000472C4 File Offset: 0x000454C4
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<long>(this.PlayerId);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(base.Name);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000FC2 RID: 4034 RVA: 0x00047307 File Offset: 0x00045507
		EntityComponentAccessor Client.Components
		{
			get
			{
				return this.Components;
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000FC3 RID: 4035 RVA: 0x0004730F File Offset: 0x0004550F
		[Category("Networking")]
		public int Ping
		{
			get
			{
				if (this.serverPlayer.IsValid)
				{
					return this.serverPlayer.m_Ping;
				}
				if (this.clientPlayer.IsValid)
				{
					return this.clientPlayer.m_Ping;
				}
				return 0;
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000FC4 RID: 4036 RVA: 0x00047344 File Offset: 0x00045544
		[Category("Networking")]
		public int PacketLoss
		{
			get
			{
				if (this.serverPlayer.IsValid)
				{
					return this.serverPlayer.m_PacketLoss;
				}
				if (this.clientPlayer.IsValid)
				{
					return this.clientPlayer.m_PacketLoss;
				}
				return 0;
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000FC5 RID: 4037 RVA: 0x00047379 File Offset: 0x00045579
		[Category("Client")]
		int Client.SessionId
		{
			get
			{
				if (!this.clientPlayer.IsNull)
				{
					return this.clientPlayer.GetUserID();
				}
				if (!this.serverPlayer.IsNull)
				{
					return this.serverPlayer.GetUserID();
				}
				return -1;
			}
		}

		// Token: 0x06000FC6 RID: 4038 RVA: 0x000473AE File Offset: 0x000455AE
		public override void Spawn()
		{
			base.Spawn();
			base.Transmit = TransmitType.Always;
		}

		/// <summary>
		/// This player's SteamId
		/// </summary>
		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000FC7 RID: 4039 RVA: 0x000473C0 File Offset: 0x000455C0
		[Category("Client")]
		public long PlayerId
		{
			get
			{
				if (this._steamidCache != 0L)
				{
					return this._steamidCache;
				}
				if (this.clientPlayer.IsValid)
				{
					this._steamidCache = (long)this.clientPlayer.GetSteamIDAsUInt64();
				}
				if (this.serverPlayer.IsValid)
				{
					this._steamidCache = (long)this.serverPlayer.GetSteamIDAsUInt64();
				}
				return this._steamidCache;
			}
		}

		// Token: 0x06000FC8 RID: 4040 RVA: 0x0004741E File Offset: 0x0004561E
		internal void StartLagCompensation()
		{
			if (this.serverPlayer.IsValid)
			{
				this.serverPlayer.StartLagCompensation();
			}
		}

		// Token: 0x06000FC9 RID: 4041 RVA: 0x00047438 File Offset: 0x00045638
		internal void FinishLagCompensation()
		{
			if (this.serverPlayer.IsValid)
			{
				this.serverPlayer.FinishLagCompensation();
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000FCA RID: 4042 RVA: 0x00047454 File Offset: 0x00045654
		// (set) Token: 0x06000FCB RID: 4043 RVA: 0x00047483 File Offset: 0x00045683
		internal CUserCmd LastUserCmd
		{
			get
			{
				if (!this.serverPlayer.IsNull)
				{
					return this.serverPlayer.GetLastUserCommand();
				}
				return default(CUserCmd);
			}
			set
			{
				if (!this.serverPlayer.IsNull)
				{
					this.serverPlayer.SetLastUserCommand(ref value);
				}
			}
		}

		// Token: 0x06000FCC RID: 4044 RVA: 0x0004749F File Offset: 0x0004569F
		internal void RunUserCmd(CUserCmd cmd)
		{
			Host.AssertServer("RunUserCmd");
			if (!this.serverPlayer.IsNull)
			{
				this.serverPlayer.PlayerRunCommand(ref cmd);
			}
		}

		// Token: 0x06000FCD RID: 4045 RVA: 0x000474C5 File Offset: 0x000456C5
		internal void PreBotTick()
		{
			Host.AssertServer("PreBotTick");
			if (!this.serverPlayer.IsNull)
			{
				this.serverPlayer.PreBotTick();
			}
		}

		// Token: 0x06000FCE RID: 4046 RVA: 0x000474E9 File Offset: 0x000456E9
		internal void PostBotTick()
		{
			Host.AssertServer("PostBotTick");
			if (!this.serverPlayer.IsNull)
			{
				this.serverPlayer.PostBotTick();
			}
		}

		// Token: 0x06000FCF RID: 4047 RVA: 0x00047510 File Offset: 0x00045710
		internal override void OnNativeEntity(CEntityInstance ent)
		{
			base.OnNativeEntity(ent);
			if (base.IsClient)
			{
				this.clientPlayer = (C_BasePlayer)this.clientEnt;
				if (this.clientPlayer.IsNull)
				{
					throw new Exception("clientPlayer is null");
				}
			}
			if (base.IsServer)
			{
				this.serverPlayer = (CBasePlayer)this.serverEnt;
				if (this.serverPlayer.IsNull)
				{
					throw new Exception("serverPlayer is null");
				}
				this.IsUsingVr = this.serverPlayer.IsVrUser();
			}
		}

		// Token: 0x06000FD0 RID: 4048 RVA: 0x00047597 File Offset: 0x00045797
		internal override void ConstructServer(string engineName)
		{
			base.ConstructServer(engineName);
			if (Client._all.Contains(this))
			{
				throw new Exception("Client._all already contains client!?");
			}
			Client._all.Add(this);
		}

		// Token: 0x06000FD1 RID: 4049 RVA: 0x000475C3 File Offset: 0x000457C3
		internal override void ConstructClient()
		{
			base.ConstructClient();
			if (!Client._all.Contains(this))
			{
				Client._all.Add(this);
			}
		}

		// Token: 0x06000FD2 RID: 4050 RVA: 0x000475E3 File Offset: 0x000457E3
		internal override void InternalClientCreated()
		{
			base.InternalClientCreated();
			if (this.clientPlayer.IsLocalPlayer())
			{
				Local.Client = this;
			}
		}

		// Token: 0x06000FD3 RID: 4051 RVA: 0x00047600 File Offset: 0x00045800
		internal override void InternalDestruct()
		{
			this.clientPlayer = IntPtr.Zero;
			this.serverPlayer = IntPtr.Zero;
			base.InternalDestruct();
			Client._all.Remove(this);
			if (this.IsBot)
			{
				Bot.Remove(this);
			}
			if (Local.Client == this)
			{
				Local.Client = null;
			}
		}

		/// <summary>
		/// Send a console command to this client to be run. Use ConsoleSystem.Build to safely build
		/// a console command.
		/// </summary>
		// Token: 0x06000FD4 RID: 4052 RVA: 0x0004765B File Offset: 0x0004585B
		public void SendCommandToClient(string command)
		{
			Host.AssertServer("SendCommandToClient");
			ServerEngine.ClientCommand(this.NetworkIdent, "%s", command);
		}

		// Token: 0x06000FD5 RID: 4053 RVA: 0x00047678 File Offset: 0x00045878
		public bool HasPermission(string mode)
		{
			return this.IsListenServerHost || (this.IsListenServerHost && mode.StartsWith("server."));
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000FD6 RID: 4054 RVA: 0x0004769C File Offset: 0x0004589C
		public bool IsListenServerHost
		{
			get
			{
				return GlobalGameNamespace.Global.IsListenServer && this.NetworkIdent == 1;
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000FD7 RID: 4055 RVA: 0x000476B8 File Offset: 0x000458B8
		// (set) Token: 0x06000FD8 RID: 4056 RVA: 0x00047708 File Offset: 0x00045908
		public Entity Pawn
		{
			get
			{
				if (!this.clientPlayer.IsNull)
				{
					return Entity.GetEntity(this.clientPlayer.m_Pawn);
				}
				if (!this.serverPlayer.IsNull)
				{
					return Entity.GetEntity(this.serverPlayer.m_Pawn);
				}
				throw new NotImplementedException();
			}
			set
			{
				if (!this.clientPlayer.IsNull)
				{
					this.clientPlayer.m_Pawn = ((value != null) ? value.clientEnt : default(C_BaseEntity));
				}
				if (!this.serverPlayer.IsNull)
				{
					this.serverPlayer.m_Pawn = ((value != null) ? value.serverEnt : default(CBaseEntity));
				}
				if (value != null)
				{
					value.Owner = this;
				}
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000FD9 RID: 4057 RVA: 0x00047777 File Offset: 0x00045977
		// (set) Token: 0x06000FDA RID: 4058 RVA: 0x00047784 File Offset: 0x00045984
		[Net]
		[Predicted]
		public ICamera DevCamera
		{
			get
			{
				return this.__devCamera.GetValue();
			}
			set
			{
				this.__devCamera.SetValue(value);
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000FDB RID: 4059 RVA: 0x00047792 File Offset: 0x00045992
		// (set) Token: 0x06000FDC RID: 4060 RVA: 0x0004779F File Offset: 0x0004599F
		[Net]
		public IDictionary<int, object> ValueDictionary
		{
			get
			{
				return this.__dataStore.GetValue();
			}
			set
			{
				this.__dataStore.SetValue(value);
			}
		}

		// Token: 0x06000FDD RID: 4061 RVA: 0x000477B0 File Offset: 0x000459B0
		public override void BuildNetworkTable(NetworkTable table)
		{
			table.Register<VarClass<ICamera>>(ref this.__devCamera, "DevCamera", true, true);
			table.Register<VarObjectDictionaryU<int>>(ref this.__dataStore, "DataStore", false, false);
			table.Register<VarUnmanaged<bool>>(ref this.__isBot, "IsBot", false, false);
			base.BuildNetworkTable(table);
		}

		// Token: 0x06000FDE RID: 4062 RVA: 0x00047800 File Offset: 0x00045A00
		public void Kick()
		{
			INetworkServer client = INetworkServer.FindBySessionId(((Client)this).SessionId);
			if (client == null)
			{
				return;
			}
			client.Disconnect(NetworkDisconnectionReason.Kicked);
		}

		/// <summary>
		/// Convenience function, calls GameServices.RecordScore
		/// </summary>
		// Token: 0x06000FDF RID: 4063 RVA: 0x00047825 File Offset: 0x00045A25
		public void SetGameResult(GameplayResult result, float score)
		{
			GameServices.RecordScore(this.PlayerId, this.IsBot, result, score);
		}

		// Token: 0x06000FE0 RID: 4064 RVA: 0x0004783C File Offset: 0x00045A3C
		public void SetValue(string key, object value)
		{
			int token = (int)StringToken.FindOrCreate(key);
			this.ValueDictionary[token] = value;
		}

		// Token: 0x06000FE1 RID: 4065 RVA: 0x00047860 File Offset: 0x00045A60
		public T GetValue<T>(string key, T defaultValue = default(T))
		{
			int token = (int)StringToken.FindOrCreate(key);
			object t;
			if (this.ValueDictionary.TryGetValue(token, out t) && t is T)
			{
				return (T)((object)t);
			}
			return defaultValue;
		}

		/// <summary>
		/// Called by the server to determine what the player can see, from a network pov
		/// Add points here that the player should see.
		/// </summary>
		// Token: 0x06000FE2 RID: 4066 RVA: 0x00047898 File Offset: 0x00045A98
		internal override void PlayerSetupVisibility(int spawngroup, IntPtr visInfo)
		{
			PVSManager.AddOriginToPVS(spawngroup, this.Position, visInfo);
			Entity pawn = this.Pawn;
			if (pawn != null)
			{
				PVSManager.AddOriginToPVS(spawngroup, pawn.Position, visInfo);
			}
			if (this.Pvs.Ents == null)
			{
				return;
			}
			this.Pvs.Clean();
			foreach (Entity ent in this.Pvs.Ents)
			{
				PVSManager.AddOriginToPVS(spawngroup, ent.Position, visInfo);
			}
		}

		/// <summary>
		/// Potentially Visible Set. Use this to add new areas to the player's PVS. This is useful if you're
		/// spectating another entity and want to be able to see what they see etc.
		/// </summary>
		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000FE3 RID: 4067 RVA: 0x00047944 File Offset: 0x00045B44
		// (set) Token: 0x06000FE4 RID: 4068 RVA: 0x0004794C File Offset: 0x00045B4C
		public PvsConfig Pvs { get; internal set; } = new PvsConfig();

		// Token: 0x06000FE5 RID: 4069 RVA: 0x00047958 File Offset: 0x00045B58
		internal static void InternalSetUserVar(int id, string key, string value)
		{
			Dictionary<string, string> data;
			if (!ClientEntity.UserData.TryGetValue(id, out data))
			{
				data = new Dictionary<string, string>();
				ClientEntity.UserData[id] = data;
			}
			data[key] = value;
		}

		// Token: 0x06000FE6 RID: 4070 RVA: 0x00047990 File Offset: 0x00045B90
		public string GetClientData(string key, string defaultValue = null)
		{
			if (Host.IsServer)
			{
				Dictionary<string, string> data;
				if (!ClientEntity.UserData.TryGetValue(this.NetworkIdent, out data))
				{
					return defaultValue;
				}
				string val;
				if (data.TryGetValue(key, out val))
				{
					return val;
				}
			}
			if (Host.IsClient)
			{
				return ConsoleSystem.FindManagedValue(key, defaultValue);
			}
			return defaultValue;
		}

		// Token: 0x06000FE7 RID: 4071 RVA: 0x000479D8 File Offset: 0x00045BD8
		public T GetClientData<T>(string key, T defaultValue = default(T))
		{
			string str = this.GetClientData(key, null);
			object val;
			if (str != null && str.TryToType(typeof(T), out val))
			{
				return (T)((object)val);
			}
			return defaultValue;
		}

		// Token: 0x0400028D RID: 653
		private VarUnmanaged<bool> __isBot = new VarUnmanaged<bool>();

		// Token: 0x04000291 RID: 657
		private CBasePlayer serverPlayer;

		// Token: 0x04000292 RID: 658
		private C_BasePlayer clientPlayer;

		// Token: 0x04000293 RID: 659
		private long _steamidCache;

		// Token: 0x04000294 RID: 660
		private VarClass<ICamera> __devCamera = new VarClass<ICamera>();

		// Token: 0x04000295 RID: 661
		private VarObjectDictionaryU<int> __dataStore = new VarObjectDictionaryU<int>();

		// Token: 0x04000297 RID: 663
		private static Dictionary<int, Dictionary<string, string>> UserData = new Dictionary<int, Dictionary<string, string>>();
	}
}
