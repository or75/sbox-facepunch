using System;
using System.Runtime.CompilerServices;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x020000CB RID: 203
	public static class Prediction
	{
		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06001248 RID: 4680 RVA: 0x0004D77B File Offset: 0x0004B97B
		// (set) Token: 0x06001249 RID: 4681 RVA: 0x0004D782 File Offset: 0x0004B982
		public static bool Enabled { get; internal set; } = true;

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x0600124A RID: 4682 RVA: 0x0004D78A File Offset: 0x0004B98A
		// (set) Token: 0x0600124B RID: 4683 RVA: 0x0004D791 File Offset: 0x0004B991
		public static Client CurrentHost { get; internal set; }

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x0600124C RID: 4684 RVA: 0x0004D799 File Offset: 0x0004B999
		internal static int CurrentHostIndex
		{
			get
			{
				if (!Prediction.Enabled || !Prediction.CurrentHost.IsValid())
				{
					return 0;
				}
				return Prediction.CurrentHost.NetworkIdent;
			}
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x0600124D RID: 4685 RVA: 0x0004D7BA File Offset: 0x0004B9BA
		// (set) Token: 0x0600124E RID: 4686 RVA: 0x0004D7C1 File Offset: 0x0004B9C1
		public static bool FirstTime { get; internal set; } = true;

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x0600124F RID: 4687 RVA: 0x0004D7C9 File Offset: 0x0004B9C9
		// (set) Token: 0x06001250 RID: 4688 RVA: 0x0004D7D0 File Offset: 0x0004B9D0
		internal static bool SupressTest { get; set; }

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06001251 RID: 4689 RVA: 0x0004D7D8 File Offset: 0x0004B9D8
		// (set) Token: 0x06001252 RID: 4690 RVA: 0x0004D7DF File Offset: 0x0004B9DF
		internal static int CurrentTick { get; set; }

		// Token: 0x06001253 RID: 4691 RVA: 0x0004D7E7 File Offset: 0x0004B9E7
		internal static void Init()
		{
			Prediction.RpcHistory = new RpcHistory();
		}

		/// <summary>
		/// At this point if we're scoping right, prediction should always be enabled.
		/// If it isn't then someone fucked up - lets not let that problem persist forever.
		/// </summary>
		// Token: 0x06001254 RID: 4692 RVA: 0x0004D7F3 File Offset: 0x0004B9F3
		internal static void Tick()
		{
			if (Prediction.Enabled)
			{
				return;
			}
			Prediction.Enabled = true;
			GlobalGameNamespace.Log.Warning("Prediction was disabled - something wrong with your scopes");
		}

		/// <summary>
		/// On recieving a network RPC we read who was being simulated when 
		/// the RPC was sent. If that was us then we set SupressTest to true.
		/// </summary>
		// Token: 0x06001255 RID: 4693 RVA: 0x0004D814 File Offset: 0x0004BA14
		internal static void Read(ref NetRead read)
		{
			short id = read.Read<short>();
			int tick = ((id > 0) ? read.Read<int>() : 0);
			Prediction.SupressTest = false;
			Prediction.CurrentTick = 0;
			if (GlobalGameNamespace.Global.IsPlayingDemo)
			{
				return;
			}
			if (!Local.Client.IsValid())
			{
				return;
			}
			if (Local.Client.NetworkIdent != (int)id)
			{
				return;
			}
			Prediction.SupressTest = true;
			Prediction.CurrentTick = tick;
		}

		// Token: 0x06001256 RID: 4694 RVA: 0x0004D876 File Offset: 0x0004BA76
		internal static void Write(NetWrite writer)
		{
			if (!Host.IsServer)
			{
				return;
			}
			writer.Write<short>((short)Prediction.CurrentHostIndex);
			if (Prediction.CurrentHostIndex > 0)
			{
				writer.Write<int>(Time.Tick);
			}
		}

		// Token: 0x06001257 RID: 4695 RVA: 0x0004D8A0 File Offset: 0x0004BAA0
		public static IDisposable Off()
		{
			bool currentState = Prediction.Enabled;
			Prediction.Enabled = false;
			return new Prediction.PredictionScope
			{
				PreviousEnabled = currentState
			};
		}

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06001258 RID: 4696 RVA: 0x0004D8CF File Offset: 0x0004BACF
		// (set) Token: 0x06001259 RID: 4697 RVA: 0x0004D8D6 File Offset: 0x0004BAD6
		public static int CommandsAcknowledged { get; internal set; }

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x0600125A RID: 4698 RVA: 0x0004D8DE File Offset: 0x0004BADE
		// (set) Token: 0x0600125B RID: 4699 RVA: 0x0004D8E5 File Offset: 0x0004BAE5
		public static int LastExecutedPacketNum { get; internal set; }

		// Token: 0x0600125C RID: 4700 RVA: 0x0004D8ED File Offset: 0x0004BAED
		internal static void PreEntityPacketReceived(int packetnum, int commandsacknowledged)
		{
			Prediction.CommandsAcknowledged = commandsacknowledged;
			Prediction.LastExecutedPacketNum = packetnum;
		}

		// Token: 0x0600125D RID: 4701 RVA: 0x0004D8FB File Offset: 0x0004BAFB
		internal static void PostEntityPacketReceived()
		{
		}

		// Token: 0x0600125E RID: 4702 RVA: 0x0004D8FD File Offset: 0x0004BAFD
		private static void LogInternal(string name, int data)
		{
			GlobalGameNamespace.Log.Info(FormattableStringFactory.Create("[{0}] {1} {2}", new object[]
			{
				Time.Tick,
				name,
				data
			}));
		}

		// Token: 0x0600125F RID: 4703 RVA: 0x0004D933 File Offset: 0x0004BB33
		public static void Watch(string name, params object[] args)
		{
			RpcHistory.Remember(name, args);
		}

		// Token: 0x06001260 RID: 4704 RVA: 0x0004D93C File Offset: 0x0004BB3C
		public static bool WasPredicted(string name, params object[] args)
		{
			return Prediction.SupressTest && RpcHistory.Contains(Prediction.CurrentTick, name, args);
		}

		// Token: 0x040003D6 RID: 982
		internal static RpcHistory RpcHistory = new RpcHistory();

		// Token: 0x02000249 RID: 585
		private struct PredictionScope : IDisposable
		{
			// Token: 0x06001E01 RID: 7681 RVA: 0x0007520A File Offset: 0x0007340A
			public void Dispose()
			{
				Prediction.Enabled = this.PreviousEnabled;
			}

			// Token: 0x040011C7 RID: 4551
			public bool PreviousEnabled;
		}
	}
}
