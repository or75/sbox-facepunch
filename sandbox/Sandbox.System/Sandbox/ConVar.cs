using System;
using System.ComponentModel;

namespace Sandbox
{
	// Token: 0x0200003D RID: 61
	public static class ConVar
	{
		// Token: 0x0200007B RID: 123
		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract class BaseAttribute : Attribute
		{
			/// <summary>
			/// If unset the name will be set to the name of the method/property
			/// </summary>
			// Token: 0x170000FE RID: 254
			// (get) Token: 0x060004D7 RID: 1239 RVA: 0x000222CF File Offset: 0x000204CF
			// (set) Token: 0x060004D8 RID: 1240 RVA: 0x000222D7 File Offset: 0x000204D7
			public string Name { get; set; }

			/// <summary>
			/// Describes why this command exists
			/// </summary>
			// Token: 0x170000FF RID: 255
			// (get) Token: 0x060004D9 RID: 1241 RVA: 0x000222E0 File Offset: 0x000204E0
			// (set) Token: 0x060004DA RID: 1242 RVA: 0x000222E8 File Offset: 0x000204E8
			public string Help { get; set; }

			// Token: 0x17000100 RID: 256
			// (get) Token: 0x060004DB RID: 1243 RVA: 0x000222F1 File Offset: 0x000204F1
			internal virtual bool IsMenu
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000101 RID: 257
			// (get) Token: 0x060004DC RID: 1244 RVA: 0x000222F4 File Offset: 0x000204F4
			internal virtual bool IsClient
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000102 RID: 258
			// (get) Token: 0x060004DD RID: 1245 RVA: 0x000222F7 File Offset: 0x000204F7
			internal virtual bool IsServer
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000103 RID: 259
			// (get) Token: 0x060004DE RID: 1246 RVA: 0x000222FA File Offset: 0x000204FA
			internal virtual bool Protected
			{
				get
				{
					return false;
				}
			}

			// Token: 0x060004DF RID: 1247 RVA: 0x000222FD File Offset: 0x000204FD
			internal bool IsAny(bool server, bool client, bool menu)
			{
				return (server && this.IsServer) || (client && this.IsClient) || (menu && this.IsMenu);
			}
		}

		/// <summary>
		/// A property with this attribute will be made a ClientData ConVar. It will be
		/// able to be changed by the client at any time and changes will be sent to the server.
		/// The variables will be accessible on the server by name on the Client object.
		/// </summary>
		// Token: 0x0200007C RID: 124
		[AttributeUsage(AttributeTargets.Property)]
		public sealed class ClientDataAttribute : ConsoleVariableAttribute
		{
			// Token: 0x17000104 RID: 260
			// (get) Token: 0x060004E1 RID: 1249 RVA: 0x0002232F File Offset: 0x0002052F
			internal override bool IsServer
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000105 RID: 261
			// (get) Token: 0x060004E2 RID: 1250 RVA: 0x00022332 File Offset: 0x00020532
			internal override bool IsClient
			{
				get
				{
					return true;
				}
			}

			// Token: 0x17000106 RID: 262
			// (get) Token: 0x060004E3 RID: 1251 RVA: 0x00022335 File Offset: 0x00020535
			internal override bool Protected
			{
				get
				{
					return false;
				}
			}

			// Token: 0x060004E4 RID: 1252 RVA: 0x00022338 File Offset: 0x00020538
			public ClientDataAttribute(string name = null)
				: base(name)
			{
			}
		}

		/// <summary>
		/// Properties with this attribute will be replicated from the server to each client. The
		/// value can only be changed by the server or the server admin, but clients can read the
		/// value at any time.
		/// </summary>
		// Token: 0x0200007D RID: 125
		[AttributeUsage(AttributeTargets.Property)]
		public class ReplicatedAttribute : ConsoleVariableAttribute
		{
			// Token: 0x17000107 RID: 263
			// (get) Token: 0x060004E5 RID: 1253 RVA: 0x00022341 File Offset: 0x00020541
			internal override bool IsServer
			{
				get
				{
					return true;
				}
			}

			// Token: 0x17000108 RID: 264
			// (get) Token: 0x060004E6 RID: 1254 RVA: 0x00022344 File Offset: 0x00020544
			internal override bool IsClient
			{
				get
				{
					return true;
				}
			}

			// Token: 0x17000109 RID: 265
			// (get) Token: 0x060004E7 RID: 1255 RVA: 0x00022347 File Offset: 0x00020547
			internal override bool Protected
			{
				get
				{
					return true;
				}
			}

			// Token: 0x060004E8 RID: 1256 RVA: 0x0002234A File Offset: 0x0002054A
			public ReplicatedAttribute(string name = null)
				: base(name)
			{
			}
		}

		/// <summary>
		/// Console variable that is available via the menu
		/// </summary>
		// Token: 0x0200007E RID: 126
		[AttributeUsage(AttributeTargets.Property)]
		public class MenuAttribute : ConsoleVariableAttribute
		{
			// Token: 0x1700010A RID: 266
			// (get) Token: 0x060004E9 RID: 1257 RVA: 0x00022353 File Offset: 0x00020553
			internal override bool IsServer
			{
				get
				{
					return false;
				}
			}

			// Token: 0x1700010B RID: 267
			// (get) Token: 0x060004EA RID: 1258 RVA: 0x00022356 File Offset: 0x00020556
			internal override bool IsMenu
			{
				get
				{
					return true;
				}
			}

			// Token: 0x1700010C RID: 268
			// (get) Token: 0x060004EB RID: 1259 RVA: 0x00022359 File Offset: 0x00020559
			// (set) Token: 0x060004EC RID: 1260 RVA: 0x00022361 File Offset: 0x00020561
			public bool ClientData { get; set; }

			// Token: 0x060004ED RID: 1261 RVA: 0x0002236A File Offset: 0x0002056A
			public MenuAttribute(string name = null)
				: base(name)
			{
			}
		}
	}
}
