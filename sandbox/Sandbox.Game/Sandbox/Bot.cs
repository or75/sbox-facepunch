using System;
using System.Collections.Generic;
using System.Linq;
using NativeEngine;

namespace Sandbox
{
	/// <summary>
	/// Create a bot. When you create one of these, a fake client will join the server and its input and behavior
	/// can be controlled by overriding the BuildInput method serverside. Bots otherwise act like regular clients
	/// and also have their own pawn.
	/// </summary>
	// Token: 0x02000096 RID: 150
	[Library("bot")]
	public class Bot
	{
		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000F81 RID: 3969 RVA: 0x00046E0C File Offset: 0x0004500C
		public static IReadOnlyList<Bot> All
		{
			get
			{
				return Bot._all.AsReadOnly();
			}
		}

		/// <summary>
		/// Set a list of default bot names. Unless a bot is given a specific name, a name
		/// will be chosen from this list until they have all been used. If all names have been
		/// used already, a random name will be chosen from the list
		/// </summary>
		// Token: 0x06000F82 RID: 3970 RVA: 0x00046E18 File Offset: 0x00045018
		public static void SetDefaultNames(List<string> names)
		{
			Assert.NotNull<List<string>>(names);
			Assert.True(names.Count > 0);
			Bot._defaultNames = names;
		}

		// Token: 0x06000F83 RID: 3971 RVA: 0x00046E34 File Offset: 0x00045034
		internal static void Remove(Client client)
		{
			for (int i = 0; i < Bot._all.Count; i++)
			{
				if (Bot._all[i].Client == client)
				{
					Bot._all.RemoveAt(i);
					return;
				}
			}
		}

		/// <summary>
		/// The fake client that this bot represents
		/// </summary>
		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000F84 RID: 3972 RVA: 0x00046E75 File Offset: 0x00045075
		// (set) Token: 0x06000F85 RID: 3973 RVA: 0x00046E7D File Offset: 0x0004507D
		public Client Client { get; private set; }

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000F86 RID: 3974 RVA: 0x00046E86 File Offset: 0x00045086
		private InputBuilder InputBuilder
		{
			get
			{
				return new InputBuilder();
			}
		}

		// Token: 0x06000F87 RID: 3975 RVA: 0x00046E8D File Offset: 0x0004508D
		public Bot()
			: this(null)
		{
		}

		// Token: 0x06000F88 RID: 3976 RVA: 0x00046E98 File Offset: 0x00045098
		public Bot(string name)
		{
			if (Host.IsClient)
			{
				throw new Exception("Unable to create a new bot clientside.");
			}
			if (string.IsNullOrEmpty(name))
			{
				List<string> unusedNames = Bot._defaultNames.Except(Bot._all.Select(delegate(Bot b)
				{
					Client client = b.Client;
					return ((client != null) ? client.Name : null) ?? null;
				})).ToList<string>();
				if (unusedNames.Count == 0)
				{
					name = Bot._defaultNames[Time.Tick % Bot._defaultNames.Count];
				}
				else
				{
					name = unusedNames[Time.Tick % unusedNames.Count];
				}
			}
			int entityId = GameGlue.CreateFakeClient(name);
			if (entityId == -1)
			{
				throw new Exception("Unable to create a new bot. Max players reached.");
			}
			this.Client = Entity.FindByIndex(entityId) as Client;
			Assert.NotNull<Client>(this.Client);
			Bot._all.Add(this);
		}

		/// <summary>
		/// Called serverside each frame to build the bot's input data. You can use this to set what
		/// buttons a bot is pressing, or where they should be looking, for example
		/// </summary>
		// Token: 0x06000F89 RID: 3977 RVA: 0x00046F75 File Offset: 0x00045175
		public virtual void BuildInput(InputBuilder builder)
		{
		}

		/// <summary>
		/// Called serverside for each tick that the bot exists in the server
		/// </summary>
		// Token: 0x06000F8A RID: 3978 RVA: 0x00046F77 File Offset: 0x00045177
		public virtual void Tick()
		{
		}

		// Token: 0x06000F8B RID: 3979 RVA: 0x00046F7C File Offset: 0x0004517C
		internal void InternalTick()
		{
			ClientEntity entity = this.Client as ClientEntity;
			if (entity == null)
			{
				return;
			}
			using (Performance.Scope("TickBot"))
			{
				CUserCmd lastCmd = entity.LastUserCmd;
				InputBuilder input = this.InputBuilder;
				input.Clear();
				input.FromUserCmd(lastCmd);
				entity.PreBotTick();
				this.BuildInput(input);
				CUserCmd cmd = input.ToUserCmd();
				entity.RunUserCmd(cmd);
				entity.LastUserCmd = cmd;
				this.Tick();
				entity.PostBotTick();
			}
		}

		// Token: 0x06000F8C RID: 3980 RVA: 0x0004700C File Offset: 0x0004520C
		internal static void RunAll()
		{
			using (Performance.Scope("Bot.RunAll"))
			{
				for (int i = Bot._all.Count - 1; i >= 0; i--)
				{
					Bot._all[i].InternalTick();
				}
			}
		}

		// Token: 0x04000289 RID: 649
		internal static List<Bot> _all = new List<Bot>();

		// Token: 0x0400028A RID: 650
		internal static List<string> _defaultNames = new List<string>
		{
			"Moe", "Kent", "Edna", "Carl", "Hans", "Jimbo", "Agnes", "Lionel", "Lenny", "Clancy",
			"Milhouse", "Ned", "Ralph", "Patty", "Selma", "Seymour", "Todd", "Rod", "Kearney", "Nelson",
			"Willie", "Kirk", "Cletus", "Apu", "Barney"
		};
	}
}
