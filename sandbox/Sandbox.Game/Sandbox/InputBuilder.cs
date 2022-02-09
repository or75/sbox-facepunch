using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NativeEngine;
using Sandbox.Engine;
using Steamworks;

namespace Sandbox
{
	// Token: 0x020000B1 RID: 177
	public class InputBuilder
	{
		// Token: 0x17000238 RID: 568
		// (get) Token: 0x0600115F RID: 4447 RVA: 0x0004A003 File Offset: 0x00048203
		// (set) Token: 0x06001160 RID: 4448 RVA: 0x0004A00B File Offset: 0x0004820B
		public bool StopProcessing { get; set; }

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06001161 RID: 4449 RVA: 0x0004A014 File Offset: 0x00048214
		// (set) Token: 0x06001162 RID: 4450 RVA: 0x0004A01C File Offset: 0x0004821C
		public bool Paused { get; internal set; }

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06001163 RID: 4451 RVA: 0x0004A025 File Offset: 0x00048225
		// (set) Token: 0x06001164 RID: 4452 RVA: 0x0004A02D File Offset: 0x0004822D
		public bool UsingController { get; internal set; }

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06001165 RID: 4453 RVA: 0x0004A036 File Offset: 0x00048236
		public bool UsingMouse
		{
			get
			{
				return !this.UsingController;
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06001166 RID: 4454 RVA: 0x0004A041 File Offset: 0x00048241
		// (set) Token: 0x06001167 RID: 4455 RVA: 0x0004A049 File Offset: 0x00048249
		internal InputButton ButtonsPrev { get; set; }

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06001168 RID: 4456 RVA: 0x0004A052 File Offset: 0x00048252
		// (set) Token: 0x06001169 RID: 4457 RVA: 0x0004A05A File Offset: 0x0004825A
		internal InputButton Buttons { get; set; }

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x0600116A RID: 4458 RVA: 0x0004A063 File Offset: 0x00048263
		// (set) Token: 0x0600116B RID: 4459 RVA: 0x0004A06B File Offset: 0x0004826B
		internal List<Vector2> AnalogInputs { get; set; } = new List<Vector2>(new Vector2[Enum.GetValues(typeof(InputAnalog)).Length]);

		/// <summary>
		/// Button is pressed down
		/// </summary>
		// Token: 0x0600116C RID: 4460 RVA: 0x0004A074 File Offset: 0x00048274
		public bool Down(InputButton button)
		{
			return this.Buttons.HasFlag(button);
		}

		// Token: 0x0600116D RID: 4461 RVA: 0x0004A08C File Offset: 0x0004828C
		internal bool WasDownLastCommand(InputButton button)
		{
			return this.ButtonsPrev.HasFlag(button);
		}

		/// <summary>
		/// Button wasn't pressed but now is it
		/// </summary>
		// Token: 0x0600116E RID: 4462 RVA: 0x0004A0A4 File Offset: 0x000482A4
		public bool Pressed(InputButton button)
		{
			return !this.WasDownLastCommand(button) && this.Down(button);
		}

		/// <summary>
		/// Button was pressed but now it isn't
		/// </summary>
		// Token: 0x0600116F RID: 4463 RVA: 0x0004A0B8 File Offset: 0x000482B8
		public bool Released(InputButton button)
		{
			return this.WasDownLastCommand(button) && !this.Down(button);
		}

		/// <summary>
		/// Remove this button, so it's no longer being pressed
		/// </summary>
		// Token: 0x06001170 RID: 4464 RVA: 0x0004A0CF File Offset: 0x000482CF
		public void ClearButton(InputButton button)
		{
			this.Buttons &= ~button;
		}

		/// <summary>
		/// Set button as pressed down
		/// </summary>
		// Token: 0x06001171 RID: 4465 RVA: 0x0004A0E0 File Offset: 0x000482E0
		public void SetButton(InputButton button, bool down = true)
		{
			if (down)
			{
				this.Buttons |= button;
				return;
			}
			this.ClearButton(button);
		}

		/// <summary>
		/// Suppress a button, it won't show as down again until it's pressed again
		/// </summary>
		// Token: 0x06001172 RID: 4466 RVA: 0x0004A0FB File Offset: 0x000482FB
		public void SuppressButton(InputButton button)
		{
			InputBuilder.SuppressedButtons |= button;
			this.ClearButton(button);
		}

		// Token: 0x06001173 RID: 4467 RVA: 0x0004A110 File Offset: 0x00048310
		public void ClearButtons()
		{
			this.Buttons = InputButton.Next;
			this.ButtonsPrev = InputButton.Next;
		}

		/// <summary>
		/// Returns a normalized <see cref="T:Vector2" /> of the <see cref="T:Sandbox.InputAnalog" /> from the user's controller.
		/// </summary>
		// Token: 0x06001174 RID: 4468 RVA: 0x0004A122 File Offset: 0x00048322
		public Vector2 GetAnalog(InputAnalog axis)
		{
			return this.AnalogInputs[(int)axis];
		}

		// Token: 0x06001175 RID: 4469 RVA: 0x0004A130 File Offset: 0x00048330
		public void Clear()
		{
			this.ClearButtons();
			this.InputDirection = 0f;
			this.StopProcessing = false;
			this.ActiveChild = null;
			this.AnalogInputs = new List<Vector2>(new Vector2[Enum.GetValues(typeof(InputAnalog)).Length]);
		}

		// Token: 0x06001176 RID: 4470 RVA: 0x0004A188 File Offset: 0x00048388
		internal void FromUserCmd(CUserCmd cmd)
		{
			this.Clear();
			this.Cursor.Direction = cmd.cursor_aim;
			this.Cursor.Origin = cmd.cursor_origin;
			this.ButtonsPrev = (InputButton)cmd.lastbuttons;
			this.Buttons = (InputButton)cmd.buttons;
			this.MouseWheel = (int)cmd.mousewheel;
			this.ActiveChild = ((cmd.SelectionIndex > 0) ? Entity.FindByIndex(cmd.SelectionIndex) : null);
			this.InputDirection = cmd.move;
			this.ViewAngles = cmd.viewangles;
			this.Position = cmd.viewpos;
		}

		// Token: 0x06001177 RID: 4471 RVA: 0x0004A224 File Offset: 0x00048424
		public void CopyLastInput(Client client)
		{
			Host.AssertServer("CopyLastInput");
			ClientEntity entity = client as ClientEntity;
			if (entity == null)
			{
				this.Clear();
				return;
			}
			CUserCmd cmd = entity.LastUserCmd;
			this.FromUserCmd(cmd);
		}

		// Token: 0x06001178 RID: 4472 RVA: 0x0004A25C File Offset: 0x0004845C
		internal CUserCmd ToUserCmd()
		{
			return new CUserCmd
			{
				cursor_aim = this.Cursor.Direction,
				cursor_origin = this.Cursor.Origin,
				lastbuttons = (ulong)this.ButtonsPrev,
				buttons = (ulong)this.Buttons,
				mousewheel = (short)this.MouseWheel,
				SelectionIndex = (this.ActiveChild.IsValid() ? this.ActiveChild.NetworkIdent : 0),
				viewangles = this.ViewAngles,
				viewpos = this.Position,
				move = this.InputDirection
			};
		}

		/// <summary>
		/// Called multiple times between ticks
		/// </summary>
		// Token: 0x06001179 RID: 4473 RVA: 0x0004A308 File Offset: 0x00048508
		internal static void Process(ref InputData data)
		{
			if (Local.Client == null)
			{
				return;
			}
			Time.Delta = data.FrameTime;
			InputButton buttonsDown = (InputButton)data.Buttons;
			InputButton buttonsNot = ~buttonsDown;
			InputBuilder.SuppressedButtons &= ~buttonsNot;
			buttonsDown &= ~InputBuilder.SuppressedButtons;
			InputBuilder.Instance.Clear();
			InputBuilder.Instance.UsingController = false;
			InputBuilder.Instance.Buttons = buttonsDown;
			InputBuilder.Instance.MouseWheel = data.MouseWheel;
			InputBuilder.Instance.ButtonsPrev = (InputButton)InputBuilder.lastButtons;
			InputBuilder.Instance.AnalogLook = new Angles(data.AnalogLook.x, -data.AnalogLook.y, 0f);
			InputBuilder.Instance.AnalogMove = data.AnalogMove;
			InputBuilder.Instance.Paused = data.IsPaused == 1;
			InputBuilder.Instance.ActiveChild = ((data.SelectionIndex > 0) ? Entity.FindByIndex(data.SelectionIndex) : null);
			if (CurrentView.IsOrtho)
			{
				Ray ray = Screen.GetOrthoRay(Mouse.Position);
				InputBuilder.Instance.Cursor.Direction = (Mouse.Visible ? ray.Direction : CurrentView.Rotation.Forward);
				InputBuilder.Instance.Cursor.Origin = (Mouse.Visible ? ray.Origin : CurrentView.Position);
			}
			else
			{
				InputBuilder.Instance.Cursor.Direction = (Mouse.Visible ? Screen.GetDirection(Mouse.Position) : CurrentView.Rotation.Forward);
				InputBuilder.Instance.Cursor.Origin = CurrentView.Position;
			}
			InputBuilder.Instance.Position = CurrentView.Position;
			if (buttonsDown != InputButton.Next)
			{
				InputBuilder.LastInputWasController = false;
			}
			Controller controller = Controller.First;
			if (controller != null)
			{
				InputButton ControllerButtons = InputButton.Next;
				foreach (object obj in Enum.GetValues(typeof(InputButton)))
				{
					InputButton button = (InputButton)obj;
					Controller controller2 = controller;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
					defaultInterpolatedStringHandler.AppendLiteral("InputButton_");
					defaultInterpolatedStringHandler.AppendFormatted<InputButton>(button);
					if (controller2.GetDigitalActionState(defaultInterpolatedStringHandler.ToStringAndClear()).Pressed)
					{
						ControllerButtons |= button;
					}
				}
				for (InputAnalog i = InputAnalog.Move; i < InputAnalog.LeftTrigger; i++)
				{
					Controller controller3 = controller;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<InputAnalog>(i);
					AnalogState state = controller3.GetAnalogActionState(defaultInterpolatedStringHandler.ToStringAndClear());
					InputBuilder.Instance.AnalogInputs[(int)i] = new Vector2(state.X, state.Y);
				}
				AnalogState leftTriggerState = controller.GetAnalogActionState("LeftTrigger");
				AnalogState rightTriggerState = controller.GetAnalogActionState("RightTrigger");
				InputBuilder.Instance.AnalogInputs[2] = new Vector2(leftTriggerState.X, 0f);
				InputBuilder.Instance.AnalogInputs[3] = new Vector2(rightTriggerState.X, 0f);
				if (ControllerButtons == InputButton.Next)
				{
					if (!InputBuilder.Instance.AnalogInputs.Where((Vector2 v) => !v.IsNearZeroLength).Any<Vector2>())
					{
						goto IL_340;
					}
				}
				InputBuilder.LastInputWasController = true;
				InputBuilder.Instance.Buttons |= ControllerButtons;
				IL_340:
				InputBuilder.Instance.UsingController = InputBuilder.LastInputWasController;
				InputBuilder.Instance.AnalogMove += new Vector3(InputBuilder.Instance.AnalogInputs[0].y * 1.5f, -InputBuilder.Instance.AnalogInputs[0].x * 1.5f, 0f);
				InputBuilder.Instance.AnalogLook += new Angles(-InputBuilder.Instance.AnalogInputs[1].y * 1.5f, -InputBuilder.Instance.AnalogInputs[1].x * 1.5f, 0f);
			}
			SteamUser.VoiceRecord = Voice.Enabled && InputBuilder.Instance.Down(InputButton.Voice);
			ulong buttons = (ulong)InputBuilder.Instance.Buttons;
			GameBase gameBase = GameBase.Current;
			if (gameBase != null)
			{
				gameBase.BuildInput(InputBuilder.Instance);
			}
			InputBuilder.lastButtons = buttons;
			InputBuilder.Instance.OriginalViewAngles = InputBuilder.Instance.ViewAngles.Normal;
			data.MouseWheel = InputBuilder.Instance.MouseWheel;
			data.Buttons = (ulong)InputBuilder.Instance.Buttons;
			data.Move = InputBuilder.Instance.InputDirection;
			data.ViewAng = InputBuilder.Instance.ViewAngles.Normal;
			data.ViewPos = InputBuilder.Instance.Position;
			data.CursorAim = InputBuilder.Instance.Cursor.Direction;
			data.CursorOrigin = InputBuilder.Instance.Cursor.Origin;
			Entity activeChild = InputBuilder.Instance.ActiveChild;
			data.SelectionIndex = ((activeChild != null) ? activeChild.NetworkIdent : 0);
			data.IsController = (InputBuilder.Instance.UsingController ? 1 : 0);
			data.AnalogActionMove = InputBuilder.Instance.AnalogInputs[0];
			data.AnalogActionLook = InputBuilder.Instance.AnalogInputs[1];
			data.AnalogActionTrigger = new Vector2(InputBuilder.Instance.AnalogInputs[2].x, InputBuilder.Instance.AnalogInputs[3].x);
			Input.UpdateFromInput(data);
		}

		// Token: 0x04000333 RID: 819
		public int MouseWheel;

		// Token: 0x04000334 RID: 820
		public Entity ActiveChild;

		// Token: 0x04000335 RID: 821
		public Angles AnalogLook;

		// Token: 0x04000336 RID: 822
		public Vector3 AnalogMove;

		// Token: 0x04000337 RID: 823
		public Angles ViewAngles;

		// Token: 0x04000338 RID: 824
		public Angles OriginalViewAngles;

		// Token: 0x04000339 RID: 825
		public Vector3 Position;

		// Token: 0x0400033A RID: 826
		public Vector3 InputDirection;

		// Token: 0x0400033B RID: 827
		public Ray Cursor;

		// Token: 0x0400033F RID: 831
		private static ulong lastButtons;

		// Token: 0x04000340 RID: 832
		private static InputButton SuppressedButtons;

		// Token: 0x04000341 RID: 833
		internal static bool LastInputWasController = false;

		// Token: 0x04000342 RID: 834
		internal static InputBuilder Instance = new InputBuilder();
	}
}
