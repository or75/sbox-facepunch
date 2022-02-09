using System;

namespace Sandbox
{
	// Token: 0x0200009E RID: 158
	[Library("bot_mimic")]
	public class MimicBot : Bot
	{
		// Token: 0x06001024 RID: 4132 RVA: 0x00048148 File Offset: 0x00046348
		[AdminCmd("bot_add", Help = "Spawn a bot player that mimics another player")]
		internal static void SpawnMimicBot(int clientIndex = 1, float yawOffset = 180f, bool forceCrouch = false)
		{
			Host.AssertServer("SpawnMimicBot");
			MimicBot mimicBot = new MimicBot();
			mimicBot.YawOffset = yawOffset;
			mimicBot.ForceCrouch = forceCrouch;
			mimicBot.TargetClient = Entity.FindByIndex(clientIndex) as ClientEntity;
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06001025 RID: 4133 RVA: 0x00048177 File Offset: 0x00046377
		// (set) Token: 0x06001026 RID: 4134 RVA: 0x0004817F File Offset: 0x0004637F
		public Client TargetClient { get; set; }

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06001027 RID: 4135 RVA: 0x00048188 File Offset: 0x00046388
		// (set) Token: 0x06001028 RID: 4136 RVA: 0x00048190 File Offset: 0x00046390
		public float YawOffset { get; set; } = 180f;

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06001029 RID: 4137 RVA: 0x00048199 File Offset: 0x00046399
		// (set) Token: 0x0600102A RID: 4138 RVA: 0x000481A1 File Offset: 0x000463A1
		public bool ForceCrouch { get; set; }

		// Token: 0x0600102B RID: 4139 RVA: 0x000481AA File Offset: 0x000463AA
		public MimicBot()
		{
		}

		// Token: 0x0600102C RID: 4140 RVA: 0x000481BD File Offset: 0x000463BD
		public MimicBot(string name)
			: base(name)
		{
		}

		// Token: 0x0600102D RID: 4141 RVA: 0x000481D4 File Offset: 0x000463D4
		public override void BuildInput(InputBuilder builder)
		{
			if (this.TargetClient.IsValid())
			{
				ClientEntity target = this.TargetClient as ClientEntity;
				if (target != null)
				{
					builder.CopyLastInput(target);
					builder.ViewAngles = builder.ViewAngles.WithYaw(builder.ViewAngles.yaw + this.YawOffset);
					if (this.ForceCrouch)
					{
						builder.SetButton(InputButton.Duck, true);
					}
				}
			}
		}
	}
}
