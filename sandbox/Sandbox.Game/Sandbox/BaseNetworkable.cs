using System;
using System.Runtime.CompilerServices;
using Sandbox.Internal;

namespace Sandbox
{
	/// <summary>
	/// A network capable object
	/// </summary>
	// Token: 0x02000094 RID: 148
	public abstract class BaseNetworkable : LibraryClass, INetworkTable
	{
		/// <summary>
		/// Should return an ID of this networkable that is common across the network
		/// </summary>
		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000F2A RID: 3882 RVA: 0x00046820 File Offset: 0x00044A20
		public virtual int NetworkIdent
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000F2B RID: 3883 RVA: 0x00046823 File Offset: 0x00044A23
		public virtual void BuildNetworkTable(NetworkTable table)
		{
		}

		/// <summary>
		/// Serialize this class to the network. You shouldn't need to call this manually unless you're 
		/// implementing INetworkSerializer and want to force a write. In other situations we can detect
		/// when things change and update them manually.
		/// </summary>
		// Token: 0x06000F2C RID: 3884 RVA: 0x00046825 File Offset: 0x00044A25
		public void WriteNetworkData()
		{
			if (Host.IsClient)
			{
				return;
			}
			Var networkVariable = this.NetworkVariable;
			if (networkVariable == null)
			{
				return;
			}
			networkVariable.SetDirty(false);
		}

		/// <summary>
		/// Writes the RpcClient identity to a network message. This works
		/// by calling the parent functions first so that they'll be read back
		/// in the right order.
		/// </summary>
		// Token: 0x06000F2D RID: 3885 RVA: 0x00046840 File Offset: 0x00044A40
		internal virtual void RpcWriteIdent(NetWrite nw)
		{
			if (this.NetworkIdent == 0)
			{
				throw new Exception(this.ToString() + " RpcIdent is 0");
			}
			nw.Write<int>(this.NetworkIdent);
		}

		/// <summary>
		///  Generated at compile-time: calls remote procedure implementations
		/// </summary>
		// Token: 0x06000F2E RID: 3886 RVA: 0x0004686C File Offset: 0x00044A6C
		protected virtual void OnCallRemoteProcedure(int id, NetRead read)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Unhandled RPC: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(id);
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		/// <summary>
		/// Called from engine clientside when an entity message has been recieved
		/// </summary>
		// Token: 0x06000F2F RID: 3887 RVA: 0x000468A4 File Offset: 0x00044AA4
		internal void ReceiveMessageFromServer(NetRead read)
		{
			if (Host.IsServer)
			{
				return;
			}
			BaseNetworkable baseNetworkable = this.ReadTarget(ref read);
			int id = read.Read<int>();
			baseNetworkable.OnCallRemoteProcedure(id, read);
		}

		// Token: 0x06000F30 RID: 3888 RVA: 0x000468D0 File Offset: 0x00044AD0
		internal BaseNetworkable ReadTarget(ref NetRead read)
		{
			int targetIdent = read.Read<int>();
			if (targetIdent == 0)
			{
				return this;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 2);
			defaultInterpolatedStringHandler.AppendLiteral("[");
			defaultInterpolatedStringHandler.AppendFormatted(this.ToString());
			defaultInterpolatedStringHandler.AppendLiteral("] Net Target Not Found: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(targetIdent);
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x04000275 RID: 629
		internal Var NetworkVariable;
	}
}
