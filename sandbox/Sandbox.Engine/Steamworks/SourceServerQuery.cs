using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x020000B9 RID: 185
	internal static class SourceServerQuery
	{
		// Token: 0x0600070C RID: 1804 RVA: 0x0000B400 File Offset: 0x00009600
		internal static Task<Dictionary<string, string>> GetRules(ServerInfo server)
		{
			IPEndPoint endpoint = new IPEndPoint(server.Address, server.QueryPort);
			Dictionary<IPEndPoint, Task<Dictionary<string, string>>> pendingQueries = SourceServerQuery.PendingQueries;
			Task<Dictionary<string, string>> result;
			lock (pendingQueries)
			{
				Task<Dictionary<string, string>> pending;
				if (SourceServerQuery.PendingQueries.TryGetValue(endpoint, out pending))
				{
					result = pending;
				}
				else
				{
					Task<Dictionary<string, string>> task = SourceServerQuery.GetRulesImpl(endpoint).ContinueWith<Task<Dictionary<string, string>>>(delegate([Nullable(new byte[] { 1, 0, 0, 0 })] Task<Dictionary<string, string>> t)
					{
						Dictionary<IPEndPoint, Task<Dictionary<string, string>>> pendingQueries2 = SourceServerQuery.PendingQueries;
						lock (pendingQueries2)
						{
							SourceServerQuery.PendingQueries.Remove(endpoint);
						}
						return t;
					}).Unwrap<Dictionary<string, string>>();
					SourceServerQuery.PendingQueries.Add(endpoint, task);
					result = task;
				}
			}
			return result;
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x0000B4AC File Offset: 0x000096AC
		private static async Task<Dictionary<string, string>> GetRulesImpl(IPEndPoint endpoint)
		{
			Dictionary<string, string> result;
			try
			{
				using (UdpClient client = new UdpClient())
				{
					client.Client.SendTimeout = 3000;
					client.Client.ReceiveTimeout = 3000;
					client.Connect(endpoint);
					result = await SourceServerQuery.GetRules(client);
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x0000B4F0 File Offset: 0x000096F0
		private static async Task<Dictionary<string, string>> GetRules(UdpClient client)
		{
			byte[] challengeBytes = await SourceServerQuery.GetChallengeData(client);
			challengeBytes[0] = 86;
			await SourceServerQuery.Send(client, challengeBytes);
			byte[] buffer = await SourceServerQuery.Receive(client);
			Dictionary<string, string> rules = new Dictionary<string, string>();
			using (BinaryReader br = new BinaryReader(new MemoryStream(buffer)))
			{
				if (br.ReadByte() != 69)
				{
					throw new Exception("Invalid data received in response to A2S_RULES request");
				}
				ushort numRules = br.ReadUInt16();
				for (int index = 0; index < (int)numRules; index++)
				{
					rules.Add(br.ReadNullTerminatedUTF8String(), br.ReadNullTerminatedUTF8String());
				}
			}
			return rules;
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x0000B534 File Offset: 0x00009734
		private static async Task<byte[]> Receive(UdpClient client)
		{
			byte[][] packets = null;
			do
			{
				byte[] buffer = (await client.ReceiveAsync()).Buffer;
				using (BinaryReader br = new BinaryReader(new MemoryStream(buffer)))
				{
					int header = br.ReadInt32();
					if (header == -1)
					{
						byte[] unsplitdata = new byte[(long)buffer.Length - br.BaseStream.Position];
						Buffer.BlockCopy(buffer, (int)br.BaseStream.Position, unsplitdata, 0, unsplitdata.Length);
						return unsplitdata;
					}
					if (header != -2)
					{
						throw new Exception("Invalid Header");
					}
					br.ReadInt32();
					byte packetNumber = br.ReadByte();
					byte packetCount = br.ReadByte();
					br.ReadInt32();
					if (packets == null)
					{
						packets = new byte[(int)packetCount][];
					}
					byte[] data = new byte[(long)buffer.Length - br.BaseStream.Position];
					Buffer.BlockCopy(buffer, (int)br.BaseStream.Position, data, 0, data.Length);
					packets[(int)packetNumber] = data;
				}
			}
			while (packets.Any((byte[] p) => p == null));
			return SourceServerQuery.Combine(packets);
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x0000B578 File Offset: 0x00009778
		private static async Task<byte[]> GetChallengeData(UdpClient client)
		{
			await SourceServerQuery.Send(client, SourceServerQuery.A2S_SERVERQUERY_GETCHALLENGE);
			byte[] array = await SourceServerQuery.Receive(client);
			if (array[0] != 65)
			{
				throw new Exception("Invalid Challenge");
			}
			return array;
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x0000B5BC File Offset: 0x000097BC
		private static async Task Send(UdpClient client, byte[] message)
		{
			byte[] sendBuffer = new byte[message.Length + 4];
			sendBuffer[0] = byte.MaxValue;
			sendBuffer[1] = byte.MaxValue;
			sendBuffer[2] = byte.MaxValue;
			sendBuffer[3] = byte.MaxValue;
			Buffer.BlockCopy(message, 0, sendBuffer, 4, message.Length);
			await client.SendAsync(sendBuffer, message.Length + 4);
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x0000B608 File Offset: 0x00009808
		private static byte[] Combine(byte[][] arrays)
		{
			byte[] rv = new byte[arrays.Sum((byte[] a) => a.Length)];
			int offset = 0;
			foreach (byte[] array in arrays)
			{
				Buffer.BlockCopy(array, 0, rv, offset, array.Length);
				offset += array.Length;
			}
			return rv;
		}

		// Token: 0x04000961 RID: 2401
		private static readonly byte[] A2S_SERVERQUERY_GETCHALLENGE = new byte[] { 85, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue };

		// Token: 0x04000962 RID: 2402
		private const byte A2S_RULES = 86;

		// Token: 0x04000963 RID: 2403
		private static readonly Dictionary<IPEndPoint, Task<Dictionary<string, string>>> PendingQueries = new Dictionary<IPEndPoint, Task<Dictionary<string, string>>>();
	}
}
