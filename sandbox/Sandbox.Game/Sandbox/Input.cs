using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NativeEngine;
using Sandbox.Engine;
using Sandbox.TextureLoader;
using Steamworks;

namespace Sandbox
{
	/// <summary>
	/// Sandbox provides an action-based input system, you can query what actions the user has pressed.
	/// Actions are bound by the user from mouse + keyboard and game controllers.
	/// <para>
	/// Input is built clientside in <see cref="M:Sandbox.Entity.BuildInput(Sandbox.InputBuilder)" />, this is sent to the server.
	/// </para>
	/// <para>
	/// <see cref="T:Sandbox.Input" /> is valid within <see cref="M:Sandbox.Entity.Simulate(Sandbox.Client)" /> for that <see cref="T:Sandbox.Client" />.
	/// </para>
	/// </summary>
	// Token: 0x0200009A RID: 154
	public static class Input
	{
		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000FEF RID: 4079 RVA: 0x00047AF2 File Offset: 0x00045CF2
		// (set) Token: 0x06000FF0 RID: 4080 RVA: 0x00047AF9 File Offset: 0x00045CF9
		public static Rotation Rotation { get; set; }

		/// <summary>
		/// A float in range of -1 to 0 to 1 that represents how much the user wants to move forwards (1) or backwards (-1)
		/// </summary>
		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000FF1 RID: 4081 RVA: 0x00047B01 File Offset: 0x00045D01
		// (set) Token: 0x06000FF2 RID: 4082 RVA: 0x00047B08 File Offset: 0x00045D08
		public static float Forward { get; set; }

		/// <summary>
		/// A float in range of -1 to 0 to 1 that represents how much the user wants to move left (1) or right (-1)
		/// </summary>
		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000FF3 RID: 4083 RVA: 0x00047B10 File Offset: 0x00045D10
		// (set) Token: 0x06000FF4 RID: 4084 RVA: 0x00047B17 File Offset: 0x00045D17
		public static float Left { get; set; }

		/// <summary>
		/// A float in range of -1 to 0 to 1 that represents how much the user wants to move up (1) or down (-1)
		/// </summary>
		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000FF5 RID: 4085 RVA: 0x00047B1F File Offset: 0x00045D1F
		// (set) Token: 0x06000FF6 RID: 4086 RVA: 0x00047B26 File Offset: 0x00045D26
		public static float Up { get; set; }

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000FF7 RID: 4087 RVA: 0x00047B2E File Offset: 0x00045D2E
		// (set) Token: 0x06000FF8 RID: 4088 RVA: 0x00047B35 File Offset: 0x00045D35
		public static Vector3 MouseDelta { get; set; }

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000FF9 RID: 4089 RVA: 0x00047B3D File Offset: 0x00045D3D
		// (set) Token: 0x06000FFA RID: 4090 RVA: 0x00047B44 File Offset: 0x00045D44
		public static int MouseWheel { get; set; }

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000FFB RID: 4091 RVA: 0x00047B4C File Offset: 0x00045D4C
		// (set) Token: 0x06000FFC RID: 4092 RVA: 0x00047B53 File Offset: 0x00045D53
		public static Entity ActiveChild { get; set; }

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000FFD RID: 4093 RVA: 0x00047B5B File Offset: 0x00045D5B
		// (set) Token: 0x06000FFE RID: 4094 RVA: 0x00047B62 File Offset: 0x00045D62
		private static int SelectionIndex { get; set; }

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06000FFF RID: 4095 RVA: 0x00047B6A File Offset: 0x00045D6A
		// (set) Token: 0x06001000 RID: 4096 RVA: 0x00047B71 File Offset: 0x00045D71
		private static int SelectionSubIndex { get; set; }

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x06001001 RID: 4097 RVA: 0x00047B79 File Offset: 0x00045D79
		// (set) Token: 0x06001002 RID: 4098 RVA: 0x00047B80 File Offset: 0x00045D80
		public static Ray Cursor { get; set; }

		/// <summary>
		/// The location of the camera on the client when this command was issued
		/// </summary>
		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06001003 RID: 4099 RVA: 0x00047B88 File Offset: 0x00045D88
		// (set) Token: 0x06001004 RID: 4100 RVA: 0x00047B8F File Offset: 0x00045D8F
		public static Vector3 Position { get; set; }

		/// <summary>
		/// Called every tick
		/// </summary>
		// Token: 0x06001005 RID: 4101 RVA: 0x00047B98 File Offset: 0x00045D98
		internal static void UpdateFrom(Client client, ref CUserCmd cmd)
		{
			Input.Rotation = Rotation.From(cmd.viewangles);
			Input.Position = cmd.viewpos;
			Input.Forward = cmd.move.x.Clamp(-1f, 1f);
			Input.Left = cmd.move.y.Clamp(-1f, 1f);
			Input.Up = cmd.move.z.Clamp(-1f, 1f);
			Input.Buttons = (InputButton)cmd.buttons;
			Input.LastButtons = (InputButton)cmd.lastbuttons;
			Input.MouseWheel = (int)cmd.mousewheel;
			Input.MouseDelta = new Vector2((float)cmd.mousedx, (float)cmd.mousedy);
			Input.SelectionIndex = cmd.SelectionIndex;
			Input.SelectionSubIndex = cmd.SelectionSubIndex;
			Input.Cursor = new Ray
			{
				Direction = cmd.cursor_aim,
				Origin = cmd.cursor_origin
			};
			Input.UsingController = cmd.usingcontroller == 1;
			Input.AnalogInputs[0] = cmd.analog_action_move;
			Input.AnalogInputs[1] = cmd.analog_action_look;
			Input.AnalogInputs[2] = (double)cmd.analog_action_trigger.x;
			Input.AnalogInputs[3] = (double)cmd.analog_action_trigger.y;
			Input.ActiveChild = ((cmd.SelectionIndex > 0) ? Entity.FindByIndex(Input.SelectionIndex) : null);
			if (Input.ActiveChild.IsValid() && Input.ActiveChild.Owner != client && Input.ActiveChild.Owner != client.Pawn)
			{
				Input.ActiveChild = null;
			}
			Input.UpdateForVr(ref cmd);
		}

		/// <summary>
		/// Called each frame
		/// </summary>
		// Token: 0x06001006 RID: 4102 RVA: 0x00047D54 File Offset: 0x00045F54
		internal static void UpdateFromInput(InputData data)
		{
			Host.AssertClient("UpdateFromInput");
			Input.Rotation = Rotation.From(data.ViewAng);
			Input.Position = data.ViewPos;
			Input.UsingController = data.IsController == 1;
			Input.Cursor = new Ray
			{
				Direction = data.CursorAim,
				Origin = data.CursorOrigin
			};
		}

		/// <summary>
		/// Called each frame
		/// </summary>
		// Token: 0x06001007 RID: 4103 RVA: 0x00047DC1 File Offset: 0x00045FC1
		internal static void UpdateFromUserCmd(ref CUserCmd cmd)
		{
			Host.AssertClient("UpdateFromUserCmd");
			Input.UpdateForVr(ref cmd);
		}

		/// <summary>
		/// Todo clear the lot
		/// </summary>
		// Token: 0x06001008 RID: 4104 RVA: 0x00047DD4 File Offset: 0x00045FD4
		internal static void Clear()
		{
			if (Host.IsClient)
			{
				return;
			}
			Input.Rotation = default(Rotation);
			Input.Position = default(Vector3);
			Input.LastButtons = InputButton.Next;
			Input.Buttons = InputButton.Next;
			Input.ActiveChild = null;
			for (int i = 0; i < Input.AnalogInputs.Count; i++)
			{
				Input.AnalogInputs[i] = default(Vector2);
			}
		}

		/// <summary>
		/// We want Input.VR.IsActive to return the correct values on client join
		/// </summary>
		// Token: 0x06001009 RID: 4105 RVA: 0x00047E44 File Offset: 0x00046044
		internal static void UpdateForClient(Client client)
		{
			Input.Clear();
			Input.VR = new Input.VrInput
			{
				IsActive = client.IsUsingVr
			};
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x0600100A RID: 4106 RVA: 0x00047E71 File Offset: 0x00046071
		// (set) Token: 0x0600100B RID: 4107 RVA: 0x00047E78 File Offset: 0x00046078
		public static Input.VrInput VR { get; internal set; }

		// Token: 0x0600100C RID: 4108 RVA: 0x00047E80 File Offset: 0x00046080
		internal static void UpdateForVr(ref CUserCmd cmd)
		{
			Input.VR = new Input.VrInput(ref cmd, Input.VR._objectList);
		}

		/// <summary>
		///  Button is pressed down
		/// </summary>
		// Token: 0x0600100D RID: 4109 RVA: 0x00047E97 File Offset: 0x00046097
		public static bool Down(InputButton button)
		{
			return (Input.Buttons & button) == button;
		}

		// Token: 0x0600100E RID: 4110 RVA: 0x00047EA3 File Offset: 0x000460A3
		internal static bool WasDownLastCommand(InputButton button)
		{
			return (Input.LastButtons & button) == button;
		}

		/// <summary>
		/// Button wasn't pressed but now is it
		/// </summary>
		// Token: 0x0600100F RID: 4111 RVA: 0x00047EAF File Offset: 0x000460AF
		public static bool Pressed(InputButton button)
		{
			return !Input.WasDownLastCommand(button) && Input.Down(button);
		}

		/// <summary>
		/// Button was pressed but now it isn't
		/// </summary>
		// Token: 0x06001010 RID: 4112 RVA: 0x00047EC1 File Offset: 0x000460C1
		public static bool Released(InputButton button)
		{
			return Input.WasDownLastCommand(button) && !Input.Down(button);
		}

		/// <summary>
		/// Returns the name of a key bound to this <see cref="T:Sandbox.InputButton" />.
		/// <example>For example:
		/// <code>Input.GetButtonOrigin( InputButton.Jump )</code>
		/// could return <c>SPACE</c> if using keyboard or <c>A Button</c> when using a controller.
		/// </example>
		/// </summary>
		// Token: 0x06001011 RID: 4113 RVA: 0x00047ED8 File Offset: 0x000460D8
		public static string GetButtonOrigin(InputButton button, bool ignoreController = false)
		{
			Host.AssertClientOrMenu("GetButtonOrigin");
			if (!Input.UsingController || ignoreController)
			{
				return Input.GetKeyWithBinding(GameGlue.GetInputButtonBinding((ulong)button));
			}
			Controller controller = Controller.All.FirstOrDefault<Controller>();
			if (controller == null)
			{
				return null;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
			defaultInterpolatedStringHandler.AppendLiteral("InputButton_");
			defaultInterpolatedStringHandler.AppendFormatted<InputButton>(button);
			return controller.GetDigitalActionOriginName(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		/// <summary>
		/// Returns the name of a key that is bound to this value
		/// <example>
		/// <code>Input.GetKeyWithBinding( "+iv_jump" );</code> returns "SPACE".
		/// </example>
		/// </summary>
		// Token: 0x06001012 RID: 4114 RVA: 0x00047F3F File Offset: 0x0004613F
		public static string GetKeyWithBinding(string binding)
		{
			Host.AssertClientOrMenu("GetKeyWithBinding");
			return Input.GetKeyWithBinding(binding);
		}

		/// <summary>
		/// Returns the binding for this key
		/// </summary>
		// Token: 0x06001013 RID: 4115 RVA: 0x00047F51 File Offset: 0x00046151
		public static string GetBindingForButton(string keyName)
		{
			Host.AssertClientOrMenu("GetBindingForButton");
			return Input.GetBindingForButton(keyName);
		}

		/// <summary>
		/// If the <see cref="T:Sandbox.Client" /> has used a controller input more recently then M+KB.
		/// </summary>
		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06001014 RID: 4116 RVA: 0x00047F63 File Offset: 0x00046163
		// (set) Token: 0x06001015 RID: 4117 RVA: 0x00047F6A File Offset: 0x0004616A
		public static bool UsingController { get; internal set; }

		/// <summary>
		/// Returns a normalized <see cref="T:Vector2" /> of the <see cref="T:Sandbox.InputAnalog" /> from the user's controller.
		/// </summary>
		// Token: 0x06001016 RID: 4118 RVA: 0x00047F72 File Offset: 0x00046172
		public static Vector2 GetAnalog(InputAnalog axis)
		{
			return Input.AnalogInputs[(int)axis];
		}

		/// <summary>
		/// Get a glyph texture from the controller bound to the action.
		/// If no binding is found will return an 'UNBOUND' glyph.
		/// </summary>
		/// <remarks>You should update your UI with this every frame, it's very cheap to call and context can change.</remarks>
		// Token: 0x06001017 RID: 4119 RVA: 0x00047F80 File Offset: 0x00046180
		public static Texture GetGlyph(InputButton button, InputGlyphSize size = InputGlyphSize.Small, GlyphStyle style = default(GlyphStyle))
		{
			Host.AssertClientOrMenu("GetGlyph");
			if (!Input.UsingController)
			{
				string key = Input.GetButtonOrigin(button, false);
				if (string.IsNullOrEmpty(key))
				{
					key = "UNBOUND";
				}
				return KeyGlyphLoader.Load(key.ToUpperInvariant(), size, style);
			}
			Controller first = Controller.First;
			Texture texture;
			if (first == null)
			{
				texture = null;
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
				defaultInterpolatedStringHandler.AppendLiteral("InputButton_");
				defaultInterpolatedStringHandler.AppendFormatted<InputButton>(button);
				texture = first.GetDigitalActionGlyph(defaultInterpolatedStringHandler.ToStringAndClear(), (GlyphSize)size, (SteamInputGlyphStyle)style.Style);
			}
			Texture glyph = texture;
			if (glyph != null)
			{
				return glyph;
			}
			return KeyGlyphLoader.Load("UNBOUND", size, style);
		}

		/// <summary>
		/// Get a glyph texture from an analog input on a controller.
		/// </summary>
		// Token: 0x06001018 RID: 4120 RVA: 0x00048014 File Offset: 0x00046214
		public static Texture GetGlyph(InputAnalog analog, InputGlyphSize size = InputGlyphSize.Small)
		{
			Host.AssertClientOrMenu("GetGlyph");
			Controller first = Controller.First;
			if (first == null)
			{
				return null;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<InputAnalog>(analog);
			return first.GetAnalogActionGlyph(defaultInterpolatedStringHandler.ToStringAndClear(), (GlyphSize)size, SteamInputGlyphStyle.Knockout);
		}

		/// <summary>
		/// Returns the name of the analog axis bound to this <see cref="T:Sandbox.InputAnalog" />
		/// <example>For example:
		/// <code>Input.GetButtonOrigin( InputAnalog.Move )</code>
		/// could return <c>Left Joystick</c>
		/// </example>
		/// </summary>
		// Token: 0x06001019 RID: 4121 RVA: 0x00048058 File Offset: 0x00046258
		public static string GetButtonOrigin(InputAnalog analog)
		{
			Host.AssertClientOrMenu("GetButtonOrigin");
			Controller first = Controller.First;
			if (first == null)
			{
				return null;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<InputAnalog>(analog);
			return first.GetAnalogActionOriginName(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		/// <summary>
		/// Trigger a vibration event on supported controllers including Xbox trigger impusle rumble.
		/// </summary>
		/// <remarks>
		/// Steam Input will translate these commands into haptic pulses for the Steam Controller or Steam Deck.
		/// </remarks>
		/// <param name="leftMotor">The speed of the left motor, between 0.0 and 1.0.</param>
		/// <param name="rightMotor">The speed of the right motor, between 0.0 and 1.0.</param>
		/// <param name="leftTrigger">(Xbox One controller only) The speed of the left trigger motor, between 0.0 and 1.0.</param>
		/// <param name="rightTrigger">(Xbox One controller only) The speed of the right trigger motor, between 0.0 and 1.0.</param>
		// Token: 0x0600101A RID: 4122 RVA: 0x00048097 File Offset: 0x00046297
		internal static void TriggerVibration(float leftMotor, float rightMotor, float leftTrigger = 0f, float rightTrigger = 0f)
		{
			Host.AssertClientOrMenu("TriggerVibration");
			Controller first = Controller.First;
			if (first == null)
			{
				return;
			}
			first.TriggerVibration(leftMotor, rightMotor, leftTrigger, rightTrigger);
		}

		// Token: 0x040002A5 RID: 677
		internal static InputButton Buttons;

		// Token: 0x040002A6 RID: 678
		internal static InputButton LastButtons;

		// Token: 0x040002A8 RID: 680
		internal static List<Vector2> AnalogInputs = new List<Vector2>(new Vector2[Enum.GetValues(typeof(InputAnalog)).Length]);

		// Token: 0x0200021F RID: 543
		public struct DigitalInput
		{
			// Token: 0x1700054C RID: 1356
			// (get) Token: 0x06001D95 RID: 7573 RVA: 0x00073A19 File Offset: 0x00071C19
			public readonly bool IsPressed
			{
				get
				{
					return this.data.m_bState > 0;
				}
			}

			// Token: 0x1700054D RID: 1357
			// (get) Token: 0x06001D96 RID: 7574 RVA: 0x00073A29 File Offset: 0x00071C29
			public readonly bool WasPressed
			{
				get
				{
					return this.IsPressed && this.data.m_bChanged > 0;
				}
			}

			// Token: 0x06001D97 RID: 7575 RVA: 0x00073A43 File Offset: 0x00071C43
			public static implicit operator bool(Input.DigitalInput o)
			{
				return o.IsPressed;
			}

			// Token: 0x04001117 RID: 4375
			internal VrInputDigitalActionData_t data;
		}

		// Token: 0x02000220 RID: 544
		public struct AnalogInput
		{
			// Token: 0x1700054E RID: 1358
			// (get) Token: 0x06001D98 RID: 7576 RVA: 0x00073A4C File Offset: 0x00071C4C
			public readonly float Value
			{
				get
				{
					return this.data.m_vPosition.x;
				}
			}

			// Token: 0x1700054F RID: 1359
			// (get) Token: 0x06001D99 RID: 7577 RVA: 0x00073A5E File Offset: 0x00071C5E
			public readonly float Delta
			{
				get
				{
					return this.data.m_vDelta.x;
				}
			}

			// Token: 0x17000550 RID: 1360
			// (get) Token: 0x06001D9A RID: 7578 RVA: 0x00073A70 File Offset: 0x00071C70
			public readonly bool Active
			{
				get
				{
					return this.data.m_bActive > 0;
				}
			}

			// Token: 0x06001D9B RID: 7579 RVA: 0x00073A80 File Offset: 0x00071C80
			public static implicit operator float(Input.AnalogInput o)
			{
				return o.Value;
			}

			// Token: 0x04001118 RID: 4376
			internal VrInputAnalogActionData_t data;
		}

		// Token: 0x02000221 RID: 545
		public struct AnalogInput2D
		{
			// Token: 0x17000551 RID: 1361
			// (get) Token: 0x06001D9C RID: 7580 RVA: 0x00073A89 File Offset: 0x00071C89
			public readonly Vector2 Value
			{
				get
				{
					return new Vector2(this.data.m_vPosition.x, this.data.m_vPosition.y);
				}
			}

			// Token: 0x17000552 RID: 1362
			// (get) Token: 0x06001D9D RID: 7581 RVA: 0x00073AB0 File Offset: 0x00071CB0
			public readonly Vector2 Delta
			{
				get
				{
					return new Vector2(this.data.m_vDelta.x, this.data.m_vDelta.y);
				}
			}

			// Token: 0x17000553 RID: 1363
			// (get) Token: 0x06001D9E RID: 7582 RVA: 0x00073AD7 File Offset: 0x00071CD7
			public readonly bool Active
			{
				get
				{
					return this.data.m_bActive > 0;
				}
			}

			// Token: 0x06001D9F RID: 7583 RVA: 0x00073AE7 File Offset: 0x00071CE7
			public static implicit operator Vector2(Input.AnalogInput2D o)
			{
				return o.Value;
			}

			// Token: 0x04001119 RID: 4377
			internal VrInputAnalogActionData_t data;
		}

		// Token: 0x02000222 RID: 546
		public struct VrHand
		{
			/// <summary>
			/// Transform of this hand
			/// </summary>
			// Token: 0x17000554 RID: 1364
			// (get) Token: 0x06001DA0 RID: 7584 RVA: 0x00073AF0 File Offset: 0x00071CF0
			public readonly Transform Transform
			{
				get
				{
					return new Transform(this.hand.m_vPosition, this.hand.m_Angles.ToRotation(), 1f);
				}
			}

			/// <summary>
			/// Velocity of this hand
			/// </summary>
			// Token: 0x17000555 RID: 1365
			// (get) Token: 0x06001DA1 RID: 7585 RVA: 0x00073B17 File Offset: 0x00071D17
			public readonly Vector3 Velocity
			{
				get
				{
					return this.hand.m_vVelocity;
				}
			}

			/// <summary>
			/// Velocity of this hand
			/// </summary>
			// Token: 0x17000556 RID: 1366
			// (get) Token: 0x06001DA2 RID: 7586 RVA: 0x00073B24 File Offset: 0x00071D24
			public readonly Vector3 AngularVelocity
			{
				get
				{
					return this.hand.m_FilteredAngularVel;
				}
			}

			// Token: 0x17000557 RID: 1367
			// (get) Token: 0x06001DA3 RID: 7587 RVA: 0x00073B31 File Offset: 0x00071D31
			// (set) Token: 0x06001DA4 RID: 7588 RVA: 0x00073B39 File Offset: 0x00071D39
			public Input.AnalogInput Trigger { readonly get; internal set; }

			// Token: 0x17000558 RID: 1368
			// (get) Token: 0x06001DA5 RID: 7589 RVA: 0x00073B42 File Offset: 0x00071D42
			// (set) Token: 0x06001DA6 RID: 7590 RVA: 0x00073B4A File Offset: 0x00071D4A
			public Input.AnalogInput Grip { readonly get; internal set; }

			// Token: 0x17000559 RID: 1369
			// (get) Token: 0x06001DA7 RID: 7591 RVA: 0x00073B53 File Offset: 0x00071D53
			// (set) Token: 0x06001DA8 RID: 7592 RVA: 0x00073B5B File Offset: 0x00071D5B
			public Input.AnalogInput2D Joystick { readonly get; internal set; }

			// Token: 0x1700055A RID: 1370
			// (get) Token: 0x06001DA9 RID: 7593 RVA: 0x00073B64 File Offset: 0x00071D64
			// (set) Token: 0x06001DAA RID: 7594 RVA: 0x00073B6C File Offset: 0x00071D6C
			public Input.DigitalInput JoystickPress { readonly get; internal set; }

			// Token: 0x1700055B RID: 1371
			// (get) Token: 0x06001DAB RID: 7595 RVA: 0x00073B75 File Offset: 0x00071D75
			// (set) Token: 0x06001DAC RID: 7596 RVA: 0x00073B7D File Offset: 0x00071D7D
			public Input.DigitalInput ButtonA { readonly get; internal set; }

			// Token: 0x1700055C RID: 1372
			// (get) Token: 0x06001DAD RID: 7597 RVA: 0x00073B86 File Offset: 0x00071D86
			// (set) Token: 0x06001DAE RID: 7598 RVA: 0x00073B8E File Offset: 0x00071D8E
			public Input.DigitalInput ButtonB { readonly get; internal set; }

			// Token: 0x06001DAF RID: 7599 RVA: 0x00073B98 File Offset: 0x00071D98
			public float GetFingerValue(FingerValue value)
			{
				switch (value)
				{
				case FingerValue.ThumbCurl:
					return this.hand.m_flFinger0;
				case FingerValue.IndexCurl:
					return this.hand.m_flFinger1;
				case FingerValue.MiddleCurl:
					return this.hand.m_flFinger2;
				case FingerValue.RingCurl:
					return this.hand.m_flFinger3;
				case FingerValue.PinkyCurl:
					return this.hand.m_flFinger4;
				case FingerValue.ThumbIndexSplay:
					return this.hand.m_flFingerSplay0;
				case FingerValue.IndexMiddleSplay:
					return this.hand.m_flFingerSplay1;
				case FingerValue.MiddleRingSplay:
					return this.hand.m_flFingerSplay2;
				case FingerValue.RingPinkySplay:
					return this.hand.m_flFingerSplay3;
				}
				return 0f;
			}

			// Token: 0x06001DB0 RID: 7600 RVA: 0x00073C56 File Offset: 0x00071E56
			public float GetFingerCurl(int index)
			{
				if (index < 0)
				{
					throw new ArgumentException("Should be 0-4", "index");
				}
				if (index > 4)
				{
					throw new ArgumentException("Should be 0-4", "index");
				}
				return this.GetFingerValue((FingerValue)index);
			}

			// Token: 0x06001DB1 RID: 7601 RVA: 0x00073C87 File Offset: 0x00071E87
			public float GetFingerSplay(int index)
			{
				if (index < 0)
				{
					throw new ArgumentException("Should be 0-3", "index");
				}
				if (index > 4)
				{
					throw new ArgumentException("Should be 0-3", "index");
				}
				return this.GetFingerValue(FingerValue.ThumbIndexSplay + index);
			}

			// Token: 0x06001DB2 RID: 7602 RVA: 0x00073CBC File Offset: 0x00071EBC
			internal VrHand(ref HandInfo_t hand, ref VrInputAnalogActions_t analog, ref VrInputDigitalActions_t digital)
			{
				this.hand = hand;
				this.Trigger = new Input.AnalogInput
				{
					data = analog.Trigger
				};
				this.Grip = new Input.AnalogInput
				{
					data = analog.Grip
				};
				this.Joystick = new Input.AnalogInput2D
				{
					data = analog.Joystick
				};
				this.JoystickPress = new Input.DigitalInput
				{
					data = digital.JoystickPress
				};
				this.ButtonA = new Input.DigitalInput
				{
					data = digital.ButtonA
				};
				this.ButtonB = new Input.DigitalInput
				{
					data = digital.ButtonB
				};
			}

			// Token: 0x0400111A RID: 4378
			private HandInfo_t hand;
		}

		// Token: 0x02000223 RID: 547
		public struct TrackedObject
		{
			// Token: 0x06001DB3 RID: 7603 RVA: 0x00073D7D File Offset: 0x00071F7D
			internal TrackedObject(TrackedObjects trackedObjects)
			{
				this.trackedObjects = trackedObjects;
			}

			// Token: 0x1700055D RID: 1373
			// (get) Token: 0x06001DB4 RID: 7604 RVA: 0x00073D86 File Offset: 0x00071F86
			public Transform Transform
			{
				get
				{
					return new Transform(this.trackedObjects.position, this.trackedObjects.rotation, 1f);
				}
			}

			// Token: 0x1700055E RID: 1374
			// (get) Token: 0x06001DB5 RID: 7605 RVA: 0x00073DA8 File Offset: 0x00071FA8
			public TrackedDeviceType Type
			{
				get
				{
					return (TrackedDeviceType)this.trackedObjects.deviceType;
				}
			}

			// Token: 0x04001121 RID: 4385
			private TrackedObjects trackedObjects;
		}

		// Token: 0x02000224 RID: 548
		public struct VrInput
		{
			// Token: 0x1700055F RID: 1375
			// (get) Token: 0x06001DB6 RID: 7606 RVA: 0x00073DB5 File Offset: 0x00071FB5
			// (set) Token: 0x06001DB7 RID: 7607 RVA: 0x00073DBD File Offset: 0x00071FBD
			public bool IsActive { readonly get; internal set; }

			// Token: 0x17000560 RID: 1376
			// (get) Token: 0x06001DB8 RID: 7608 RVA: 0x00073DC6 File Offset: 0x00071FC6
			// (set) Token: 0x06001DB9 RID: 7609 RVA: 0x00073DCE File Offset: 0x00071FCE
			public Transform Head { readonly get; internal set; }

			// Token: 0x17000561 RID: 1377
			// (get) Token: 0x06001DBA RID: 7610 RVA: 0x00073DD7 File Offset: 0x00071FD7
			// (set) Token: 0x06001DBB RID: 7611 RVA: 0x00073DDF File Offset: 0x00071FDF
			public Input.VrHand LeftHand { readonly get; internal set; }

			// Token: 0x17000562 RID: 1378
			// (get) Token: 0x06001DBC RID: 7612 RVA: 0x00073DE8 File Offset: 0x00071FE8
			// (set) Token: 0x06001DBD RID: 7613 RVA: 0x00073DF0 File Offset: 0x00071FF0
			public Input.VrHand RightHand { readonly get; internal set; }

			// Token: 0x17000563 RID: 1379
			// (get) Token: 0x06001DBE RID: 7614 RVA: 0x00073DF9 File Offset: 0x00071FF9
			public IReadOnlyList<Input.TrackedObject> TrackedObjects
			{
				get
				{
					return this._objectList;
				}
			}

			// Token: 0x06001DBF RID: 7615 RVA: 0x00073E04 File Offset: 0x00072004
			internal VrInput(ref CUserCmd cmd, List<Input.TrackedObject> objectList)
			{
				this = default(Input.VrInput);
				this.IsActive = cmd.hmd_active > 0;
				if (!this.IsActive)
				{
					return;
				}
				this.Head = new Transform(cmd.hmd_middle_eye_local, cmd.hmd_viewangles_local.ToRotation(), 1f);
				this._type = (int)cmd.hmd_controller_type;
				this.LeftHand = new Input.VrHand(ref cmd.LeftHandInfo, ref cmd.analog_action_data_left, ref cmd.digital_action_data_left);
				this.RightHand = new Input.VrHand(ref cmd.RightHandInfo, ref cmd.analog_action_data_right, ref cmd.digital_action_data_right);
				if (objectList == null)
				{
					objectList = new List<Input.TrackedObject>();
				}
				this._objectList = objectList;
				this._objectList.Clear();
				for (int i = 0; i < (int)cmd.numTrackedObjects; i++)
				{
					this._objectList.Add(new Input.TrackedObject(cmd.GetTrackedObject(i)));
				}
			}

			/// <summary>
			/// Returns true if this is a vive
			/// </summary>
			// Token: 0x17000564 RID: 1380
			// (get) Token: 0x06001DC0 RID: 7616 RVA: 0x00073EDB File Offset: 0x000720DB
			public readonly bool IsVive
			{
				get
				{
					return this._type == 2;
				}
			}

			/// <summary>
			/// Returns true if this is a rift or a touch
			/// </summary>
			// Token: 0x17000565 RID: 1381
			// (get) Token: 0x06001DC1 RID: 7617 RVA: 0x00073EE6 File Offset: 0x000720E6
			public readonly bool IsRift
			{
				get
				{
					return this._type == 3 || this._type == 4;
				}
			}

			/// <summary>
			/// Returns true if this is an index
			/// </summary>
			// Token: 0x17000566 RID: 1382
			// (get) Token: 0x06001DC2 RID: 7618 RVA: 0x00073EFC File Offset: 0x000720FC
			public readonly bool IsKnuckles
			{
				get
				{
					return this._type == 5 || this._type == 6;
				}
			}

			/// <summary>
			/// Returns the headset type - like "vive", "touch", "rift". Returns empty string if unknown.
			/// </summary>
			// Token: 0x17000567 RID: 1383
			// (get) Token: 0x06001DC3 RID: 7619 RVA: 0x00073F14 File Offset: 0x00072114
			public readonly string Type
			{
				get
				{
					switch (this._type)
					{
					case 1:
						return "x360";
					case 2:
						return "vive_controller";
					case 3:
						return "oculus_touch";
					case 4:
						return "oculus_touch";
					case 5:
						return "knuckles_ev1";
					case 6:
						return "knuckles";
					case 7:
						return "holographic_controller";
					case 8:
						return "holographic_controller";
					case 9:
						return "generic";
					case 10:
						return "vive_cosmos_controller";
					case 11:
						return "hpmotioncontroller";
					default:
						return string.Empty;
					}
				}
			}

			// Token: 0x04001126 RID: 4390
			internal int _type;

			// Token: 0x04001127 RID: 4391
			internal List<Input.TrackedObject> _objectList;
		}
	}
}
