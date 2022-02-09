using System;
using NativeEngine;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x020000E4 RID: 228
	internal static class PlayerCommand
	{
		// Token: 0x06001381 RID: 4993 RVA: 0x0004F553 File Offset: 0x0004D753
		internal static void RunClient(Client player, ref CUserCmd cmd)
		{
			ThreadSafe.AssertIsMainThread("RunClient");
			Prediction.FirstTime = cmd.hasbeenpredicted == 0;
			PlayerCommand.Run(player, ref cmd);
		}

		// Token: 0x06001382 RID: 4994 RVA: 0x0004F574 File Offset: 0x0004D774
		internal static void RunClientFrame(ref CUserCmd cmd)
		{
			ThreadSafe.AssertIsMainThread("RunClientFrame");
			Prediction.FirstTime = cmd.hasbeenpredicted == 0;
			Input.UpdateFromUserCmd(ref cmd);
			if (Local.Client == null)
			{
				return;
			}
			try
			{
				Client cl = Local.Client;
				Prediction.CurrentHost = cl;
				Prediction.Enabled = true;
				ClientEntity clEnt = cl as ClientEntity;
				if (clEnt != null)
				{
					clEnt.Position = Input.Position;
					clEnt.Rotation = Input.Rotation;
					GameBase gameBase = GameBase.Current;
					if (gameBase != null)
					{
						gameBase.FrameSimulate(cl);
					}
				}
			}
			finally
			{
				Prediction.CurrentHost = null;
				Prediction.FirstTime = true;
				Input.Clear();
			}
		}

		// Token: 0x06001383 RID: 4995 RVA: 0x0004F610 File Offset: 0x0004D810
		internal static void RunServer(Client player, ref CUserCmd cmd)
		{
			ThreadSafe.AssertIsMainThread("RunServer");
			Prediction.FirstTime = true;
			PlayerCommand.Run(player, ref cmd);
			Var.WriteAll();
		}

		// Token: 0x06001384 RID: 4996 RVA: 0x0004F630 File Offset: 0x0004D830
		private static void Run(Client cl, ref CUserCmd cmd)
		{
			using (Performance.Scope("PlayerCommand.Run"))
			{
				try
				{
					Prediction.CurrentHost = cl;
					Prediction.Enabled = true;
					ClientEntity clEnt = cl as ClientEntity;
					if (clEnt != null)
					{
						Input.UpdateFrom(clEnt, ref cmd);
						clEnt.Position = Input.Position;
						clEnt.Rotation = Input.Rotation;
						using (Performance.Scope("Game.Simulate( cl )"))
						{
							GameBase gameBase = GameBase.Current;
							if (gameBase != null)
							{
								gameBase.Simulate(cl);
							}
						}
						if (clEnt != null)
						{
							clEnt.FinishLagCompensation();
						}
						if (clEnt != null)
						{
							clEnt.SetSimulationTime(Time.Now);
						}
					}
				}
				finally
				{
					Prediction.CurrentHost = null;
					Prediction.FirstTime = true;
					Input.Clear();
				}
			}
		}
	}
}
