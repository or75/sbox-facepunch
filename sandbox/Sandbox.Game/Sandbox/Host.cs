using System;
using System.Runtime.CompilerServices;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x020000AC RID: 172
	public static class Host
	{
		// Token: 0x0600114A RID: 4426 RVA: 0x00049DF0 File Offset: 0x00047FF0
		internal static void Init(string name)
		{
			Host.Name = name;
			Host.IsServer = name == "server";
			Host.IsClient = name == "client";
			Host.IsMenu = name == "menu";
			GlobalGameNamespace.Log = new Logger(name);
			Event.Init(GlobalGameNamespace.Log);
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x0600114B RID: 4427 RVA: 0x00049E48 File Offset: 0x00048048
		// (set) Token: 0x0600114C RID: 4428 RVA: 0x00049E4F File Offset: 0x0004804F
		internal static bool IsUnitTest { get; set; }

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x0600114D RID: 4429 RVA: 0x00049E57 File Offset: 0x00048057
		// (set) Token: 0x0600114E RID: 4430 RVA: 0x00049E5E File Offset: 0x0004805E
		public static bool IsServer { get; private set; }

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x0600114F RID: 4431 RVA: 0x00049E66 File Offset: 0x00048066
		// (set) Token: 0x06001150 RID: 4432 RVA: 0x00049E6D File Offset: 0x0004806D
		public static bool IsClient { get; private set; }

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06001151 RID: 4433 RVA: 0x00049E75 File Offset: 0x00048075
		// (set) Token: 0x06001152 RID: 4434 RVA: 0x00049E7C File Offset: 0x0004807C
		public static bool IsMenu { get; private set; }

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06001153 RID: 4435 RVA: 0x00049E84 File Offset: 0x00048084
		public static bool IsMenuOrClient
		{
			get
			{
				return Host.IsClient || Host.IsMenu;
			}
		}

		/// <summary>
		/// Color or the current realm. Will either be Cyan for server, Orange for client or Green for menu.
		/// </summary>
		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06001154 RID: 4436 RVA: 0x00049E94 File Offset: 0x00048094
		public static Color Color
		{
			get
			{
				if (Host.IsServer)
				{
					return Color.Cyan;
				}
				if (!Host.IsMenu)
				{
					return Color.Orange;
				}
				return Color.Green;
			}
		}

		/// <summary>
		/// The name of the "realm" the code is currently running in, i.e. menu, server or client.
		/// </summary>
		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06001155 RID: 4437 RVA: 0x00049EB5 File Offset: 0x000480B5
		// (set) Token: 0x06001156 RID: 4438 RVA: 0x00049EBC File Offset: 0x000480BC
		public static string Name { get; private set; }

		// Token: 0x06001157 RID: 4439 RVA: 0x00049EC4 File Offset: 0x000480C4
		public static void AssertClient([CallerMemberName] string memberName = "")
		{
			if (!Host.IsClient)
			{
				throw new Exception(memberName + " should only be called on the Client!");
			}
		}

		// Token: 0x06001158 RID: 4440 RVA: 0x00049EDE File Offset: 0x000480DE
		public static void AssertServer([CallerMemberName] string memberName = "")
		{
			if (!Host.IsServer)
			{
				throw new Exception(memberName + " should only be called on the Server!");
			}
		}

		// Token: 0x06001159 RID: 4441 RVA: 0x00049EF8 File Offset: 0x000480F8
		public static void AssertMenu([CallerMemberName] string memberName = "")
		{
			if (!Host.IsMenu)
			{
				throw new Exception(memberName + " should only be called in the Menu!");
			}
		}

		// Token: 0x0600115A RID: 4442 RVA: 0x00049F12 File Offset: 0x00048112
		public static void AssertClientOrMenu([CallerMemberName] string memberName = "")
		{
			if (!Host.IsMenuOrClient)
			{
				throw new Exception(memberName + " should only be called in the Menu or Client!");
			}
		}
	}
}
