using System;
using System.Linq;
using System.Runtime.CompilerServices;
using NativeEngine;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x020000C8 RID: 200
	[Hotload.SkipAttribute]
	public static class Networking
	{
		/// <summary>
		/// The entrance point from the engine when a managed network message is recvd
		/// </summary>
		// Token: 0x06001235 RID: 4661 RVA: 0x0004CFC0 File Offset: 0x0004B1C0
		internal unsafe static void OnNetMessage(IntPtr data, int length, int playerEntity)
		{
			NetRead read = new NetRead((byte*)(void*)data, length);
			if (Host.IsClient)
			{
				Prediction.Read(ref read);
			}
			Networking.OnRPC(read);
		}

		// Token: 0x06001236 RID: 4662 RVA: 0x0004CFF0 File Offset: 0x0004B1F0
		private static void OnRPC(NetRead read)
		{
			int networkIdent = read.Read<int>();
			if (networkIdent == 0)
			{
				Networking.OnGlobalRPC(read);
				return;
			}
			if (networkIdent <= 0)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 1);
				defaultInterpolatedStringHandler.AppendLiteral("OnRPC: Unknown Entity (");
				defaultInterpolatedStringHandler.AppendFormatted<int>(networkIdent);
				defaultInterpolatedStringHandler.AppendLiteral(")");
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			Entity ent = Entity.All.FirstOrDefault((Entity x) => x.NetworkIdent == networkIdent);
			if (ent == null)
			{
				return;
			}
			ent.ReceiveMessageFromServer(read);
		}

		// Token: 0x06001237 RID: 4663 RVA: 0x0004D086 File Offset: 0x0004B286
		internal static void Broadcast(IntPtr ptr, int size)
		{
			if (!Host.IsServer)
			{
				return;
			}
			GameGlue.SendMessageToAllClients(ptr, size);
		}

		// Token: 0x06001238 RID: 4664 RVA: 0x0004D097 File Offset: 0x0004B297
		internal static void BroadcastPVS(IntPtr ptr, int size, Entity source)
		{
			if (!Host.IsServer)
			{
				return;
			}
			GameGlue.SendMessageToPVS(ptr, size, source.GetEntityIntPtr());
		}

		// Token: 0x06001239 RID: 4665 RVA: 0x0004D0AE File Offset: 0x0004B2AE
		internal static void Send(IntPtr ptr, int size, Client targetClient)
		{
			if (!Host.IsServer)
			{
				return;
			}
			if (targetClient == null)
			{
				return;
			}
			GameGlue.SendMessageToClient(targetClient.NetworkIdent - 1, ptr, size);
		}

		// Token: 0x0600123A RID: 4666 RVA: 0x0004D0CC File Offset: 0x0004B2CC
		private static void OnGlobalRPC(NetRead read)
		{
			int identifier = read.Read<int>();
			ContextInterface gameInterface = GlobalGameNamespace.Global.GameInterface;
			if (gameInterface == null)
			{
				return;
			}
			gameInterface.OnGlobalRPC(identifier, read);
		}

		// Token: 0x040003C2 RID: 962
		private static readonly Logger log = Logging.GetLogger(null);
	}
}
