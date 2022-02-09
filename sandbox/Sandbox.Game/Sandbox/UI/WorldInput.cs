using System;

namespace Sandbox.UI
{
	/// <summary>
	/// WorldInput can be used to simulate standard mouse inputs on WorldPanels.
	/// </summary>
	/// <remarks>
	/// <para>
	/// You need to set <see cref="P:Sandbox.UI.WorldInput.Ray" /> and <see cref="P:Sandbox.UI.WorldInput.MouseLeftPressed" /> to simulate inputs,
	/// ideally this should be done in a BuildInput event.
	/// </para>
	/// <para>
	/// You can create this on your Pawn.
	/// </para>
	/// <para>
	/// A nice way to simulate world inputs for VR is to have a <see cref="T:Sandbox.UI.WorldInput" /> for each <see cref="T:Sandbox.Input.VrHand" />.
	/// </para>
	/// </remarks>
	// Token: 0x0200011A RID: 282
	public class WorldInput
	{
		// Token: 0x1700034A RID: 842
		// (get) Token: 0x060015D1 RID: 5585 RVA: 0x00057E2A File Offset: 0x0005602A
		// (set) Token: 0x060015D2 RID: 5586 RVA: 0x00057E32 File Offset: 0x00056032
		internal WorldInputInternal WorldInputInternal { get; set; } = new WorldInputInternal();

		/// <summary>
		/// This input won't tick when this is false.
		/// Any hovered panels will be cleared.
		/// </summary>
		// Token: 0x1700034B RID: 843
		// (get) Token: 0x060015D3 RID: 5587 RVA: 0x00057E3B File Offset: 0x0005603B
		// (set) Token: 0x060015D4 RID: 5588 RVA: 0x00057E48 File Offset: 0x00056048
		public bool Enabled
		{
			get
			{
				return this.WorldInputInternal.Enabled;
			}
			set
			{
				this.WorldInputInternal.Enabled = value;
			}
		}

		/// <summary>
		/// The Ray used to intersect with your world panels, simulating mouse position.
		/// </summary>
		/// <remarks>
		/// This should ideally be set in BuildInput or FrameSimulate.
		///
		/// <example>
		/// This could be your <see cref="P:Sandbox.Local.Pawn" /> EyePos and EyeDir:
		/// <code>
		/// WorldInput.Ray = new Ray( Local.Pawn.EyePos, Local.Pawn.EyeDir );
		/// </code>
		///
		/// This could also be <see cref="P:Sandbox.Input.Cursor" /> if you want to use the mouse cursor.
		/// <code>
		/// WorldInput.Ray = Input.Cursor;
		/// </code>
		///
		/// If using VR you may want to derive the Ray from a <see cref="T:Sandbox.Input.VrHand" />.
		/// <code>
		/// WorldInput.Ray = new Ray( VRHand.Transform.Position, VRHand.Transform.Rotation.Forward );
		/// WorldInput.MouseLeftPressed = VRHand.Trigger.Active;
		/// </code>
		/// </example>
		/// </remarks>
		// Token: 0x1700034C RID: 844
		// (get) Token: 0x060015D5 RID: 5589 RVA: 0x00057E56 File Offset: 0x00056056
		// (set) Token: 0x060015D6 RID: 5590 RVA: 0x00057E63 File Offset: 0x00056063
		public Ray Ray
		{
			get
			{
				return this.WorldInputInternal.Ray;
			}
			set
			{
				this.WorldInputInternal.Ray = value;
			}
		}

		/// <summary>
		/// Simulate if the left mouse button is pressed.
		/// You can use <seealso cref="M:Sandbox.Input.Down(Sandbox.InputButton)" />.
		/// </summary>
		// Token: 0x1700034D RID: 845
		// (get) Token: 0x060015D7 RID: 5591 RVA: 0x00057E71 File Offset: 0x00056071
		// (set) Token: 0x060015D8 RID: 5592 RVA: 0x00057E7E File Offset: 0x0005607E
		public bool MouseLeftPressed
		{
			get
			{
				return this.WorldInputInternal.MouseLeftPressed;
			}
			set
			{
				this.WorldInputInternal.MouseLeftPressed = value;
			}
		}

		/// <summary>
		/// Simulate if the right mouse button is pressed.
		/// You can use <seealso cref="M:Sandbox.Input.Down(Sandbox.InputButton)" />.
		/// </summary>
		// Token: 0x1700034E RID: 846
		// (get) Token: 0x060015D9 RID: 5593 RVA: 0x00057E8C File Offset: 0x0005608C
		// (set) Token: 0x060015DA RID: 5594 RVA: 0x00057E99 File Offset: 0x00056099
		public bool MouseRightPressed
		{
			get
			{
				return this.WorldInputInternal.MouseRightPressed;
			}
			set
			{
				this.WorldInputInternal.MouseRightPressed = value;
			}
		}

		/// <summary>
		/// Simulate the mouse scroll wheel.
		/// You could use <seealso cref="P:Sandbox.Input.MouseWheel" />
		/// Or you could simulate it with the camera view delta for example.
		/// </summary>
		// Token: 0x1700034F RID: 847
		// (get) Token: 0x060015DB RID: 5595 RVA: 0x00057EA7 File Offset: 0x000560A7
		// (set) Token: 0x060015DC RID: 5596 RVA: 0x00057EB4 File Offset: 0x000560B4
		public float MouseScroll
		{
			get
			{
				return this.WorldInputInternal.MouseScroll;
			}
			set
			{
				this.WorldInputInternal.MouseScroll = value;
			}
		}

		/// <summary>
		/// Instead of simulating mouse input, this will simply use the mouse input.
		/// </summary>
		// Token: 0x17000350 RID: 848
		// (get) Token: 0x060015DD RID: 5597 RVA: 0x00057EC2 File Offset: 0x000560C2
		// (set) Token: 0x060015DE RID: 5598 RVA: 0x00057ECF File Offset: 0x000560CF
		public bool UseMouseInput
		{
			get
			{
				return this.WorldInputInternal.UseMouseInput;
			}
			set
			{
				this.WorldInputInternal.UseMouseInput = value;
			}
		}

		/// <summary>
		/// The <see cref="T:Sandbox.UI.Panel" /> that is currently hovered by this input.
		/// </summary>
		// Token: 0x17000351 RID: 849
		// (get) Token: 0x060015DF RID: 5599 RVA: 0x00057EDD File Offset: 0x000560DD
		public Panel Hovered
		{
			get
			{
				return this.WorldInputInternal.Hovered;
			}
		}

		/// <summary>
		/// The <see cref="T:Sandbox.UI.Panel" /> that is currently pressed by this input.
		/// </summary>
		// Token: 0x17000352 RID: 850
		// (get) Token: 0x060015E0 RID: 5600 RVA: 0x00057EEA File Offset: 0x000560EA
		public Panel Active
		{
			get
			{
				return this.WorldInputInternal.Active;
			}
		}

		// Token: 0x060015E1 RID: 5601 RVA: 0x00057EF7 File Offset: 0x000560F7
		[Obsolete("WorldInput.Update is obsolete. Use a WorldInput instance instead.", true)]
		public static bool Update(Ray ray, bool leftMouseDown, bool rightMouseDown, Vector2 scroll)
		{
			return false;
		}
	}
}
