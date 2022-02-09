using System;
using Sandbox.Internal;

namespace Sandbox.UI
{
	// Token: 0x0200012E RID: 302
	public class RootPanel : Panel
	{
		// Token: 0x170003AC RID: 940
		// (get) Token: 0x06001764 RID: 5988 RVA: 0x0005F0E8 File Offset: 0x0005D2E8
		// (set) Token: 0x06001765 RID: 5989 RVA: 0x0005F0F0 File Offset: 0x0005D2F0
		public Rect PanelBounds { get; set; } = new Rect(0f, 0f, 512f, 512f);

		/// <summary>
		/// If any of our panels are visible and want mouse input (pointer-events != none) then 
		/// this will be set to the first panel we find where that is the case
		/// </summary>
		// Token: 0x170003AD RID: 941
		// (get) Token: 0x06001766 RID: 5990 RVA: 0x0005F0F9 File Offset: 0x0005D2F9
		// (set) Token: 0x06001767 RID: 5991 RVA: 0x0005F101 File Offset: 0x0005D301
		public Panel WantsMouseInput { get; internal set; }

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x06001768 RID: 5992 RVA: 0x0005F10A File Offset: 0x0005D30A
		// (set) Token: 0x06001769 RID: 5993 RVA: 0x0005F112 File Offset: 0x0005D312
		public float Scale { get; protected set; } = 1f;

		/// <summary>
		/// If set to true this panel won't be rendered to the screen like a normal panel.
		/// This is true when the panel is drawn via other means (like as a world panel)
		/// </summary>
		// Token: 0x170003AF RID: 943
		// (get) Token: 0x0600176A RID: 5994 RVA: 0x0005F11B File Offset: 0x0005D31B
		// (set) Token: 0x0600176B RID: 5995 RVA: 0x0005F123 File Offset: 0x0005D323
		public bool RenderedManually { get; set; }

		/// <summary>
		/// Todo, this might need to exist
		/// </summary>
		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x0600176C RID: 5996 RVA: 0x0005F12C File Offset: 0x0005D32C
		internal bool IsWorldPanel
		{
			get
			{
				return this.RenderedManually;
			}
		}

		/// <summary>
		/// If this panel belongs to a <see cref="T:Sandbox.VROverlay" />.
		/// </summary>
		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x0600176D RID: 5997 RVA: 0x0005F134 File Offset: 0x0005D334
		// (set) Token: 0x0600176E RID: 5998 RVA: 0x0005F13C File Offset: 0x0005D33C
		public bool IsVR { get; internal set; }

		// Token: 0x0600176F RID: 5999 RVA: 0x0005F148 File Offset: 0x0005D348
		public RootPanel()
		{
			base.Style.Width = Length.Percent(100f);
			base.Style.Height = Length.Percent(100f);
			UISystem.AddRoot(this);
			this.AddToLists();
		}

		// Token: 0x06001770 RID: 6000 RVA: 0x0005F1BB File Offset: 0x0005D3BB
		public override void Delete(bool immediate = true)
		{
			base.Delete(immediate);
		}

		// Token: 0x06001771 RID: 6001 RVA: 0x0005F1C4 File Offset: 0x0005D3C4
		public override void OnDeleted()
		{
			base.OnDeleted();
			UISystem.RemoveRoot(this);
		}

		// Token: 0x06001772 RID: 6002 RVA: 0x0005F1D2 File Offset: 0x0005D3D2
		internal override void AddToLists()
		{
			base.AddToLists();
			IPanel.InspectablePanels.Add(this);
		}

		// Token: 0x06001773 RID: 6003 RVA: 0x0005F1E5 File Offset: 0x0005D3E5
		internal override void RemoveFromLists()
		{
			base.RemoveFromLists();
			IPanel.InspectablePanels.Remove(this);
		}

		// Token: 0x06001774 RID: 6004 RVA: 0x0005F1F9 File Offset: 0x0005D3F9
		internal void Layout()
		{
			this.PreLayout();
			this.CalculateLayout();
			this.PostLayout();
		}

		/// <summary>
		/// Called before layout to lock the bounds of this root panel to the screen size (which is passed).
		/// Internally this sets PanelBounds to rect and calls UpdateScale.
		/// </summary>
		// Token: 0x06001775 RID: 6005 RVA: 0x0005F20D File Offset: 0x0005D40D
		protected virtual void UpdateBounds(Rect rect)
		{
			this.PanelBounds = rect;
		}

		/// <summary>
		/// Work out scaling here. Default is to scale relative to the screen being
		/// 1920 wide. ie - scale = screensize.Width / 1920.0f;
		/// </summary>
		// Token: 0x06001776 RID: 6006 RVA: 0x0005F216 File Offset: 0x0005D416
		protected virtual void UpdateScale(Rect screenSize)
		{
			this.Scale = screenSize.height / 1080f;
			if (GlobalGameNamespace.Global.IsRunningOnHandheld)
			{
				this.Scale *= 1.333f;
			}
		}

		// Token: 0x06001777 RID: 6007 RVA: 0x0005F249 File Offset: 0x0005D449
		internal void PreLayout(Rect screenSize)
		{
			this.UpdateBounds(screenSize);
			this.UpdateScale(this.PanelBounds);
			this.PushRootLength();
			this.PreLayout();
		}

		// Token: 0x06001778 RID: 6008 RVA: 0x0005F26C File Offset: 0x0005D46C
		internal void PreLayout()
		{
			LayoutCascade cascade = new LayoutCascade
			{
				Scale = (double)this.Scale,
				Opacity = (base.Style.Opacity ?? 1f),
				Root = this,
				FontSize = new Length?(14f * this.Scale)
			};
			base.Style.Left = new Length?(0f);
			base.Style.Top = new Length?(0f);
			base.Style.Width = new Length?(this.PanelBounds.width * (1f / this.Scale));
			base.Style.Height = new Length?(this.PanelBounds.height * (1f / this.Scale));
			int hash = HashCode.Combine<float, float>(this.PanelBounds.width, this.PanelBounds.height);
			if (hash != this.layoutHash)
			{
				this.layoutHash = hash;
				base.Style.Dirty();
				this.SkipAllTransitions();
			}
			hash = HashCode.Combine<float>(this.Scale);
			if (hash != this.scaleHash)
			{
				this.scaleHash = hash;
				base.DirtyStylesRecursive();
				this.SkipAllTransitions();
			}
			this.WantsMouseInput = null;
			this.PreLayout(cascade);
		}

		// Token: 0x06001779 RID: 6009 RVA: 0x0005F3F8 File Offset: 0x0005D5F8
		internal void CalculateLayout()
		{
			using (Performance.Scope("CalculateLayout"))
			{
				this.PushRootLength();
				this.YogaNode.CalculateLayout();
			}
		}

		// Token: 0x0600177A RID: 6010 RVA: 0x0005F440 File Offset: 0x0005D640
		internal void PostLayout()
		{
			this.PushRootLength();
			this.FinalLayout();
		}

		// Token: 0x0600177B RID: 6011 RVA: 0x0005F450 File Offset: 0x0005D650
		internal void PushRootLength()
		{
			Length.RootSize = new Vector2(this.PanelBounds.width, this.PanelBounds.height);
		}

		// Token: 0x0600177C RID: 6012 RVA: 0x0005F483 File Offset: 0x0005D683
		public override void OnLayout(ref Rect layoutRect)
		{
			layoutRect = this.PanelBounds;
		}

		// Token: 0x0600177D RID: 6013 RVA: 0x0005F491 File Offset: 0x0005D691
		internal void Render()
		{
			if (UISystem.Renderer == null)
			{
				UISystem.Renderer = new PanelRenderer();
			}
			UISystem.Renderer.Render(this);
		}

		// Token: 0x0600177E RID: 6014 RVA: 0x0005F4AF File Offset: 0x0005D6AF
		[Event("ui.skiptransitions")]
		internal void SkipAllTransitions()
		{
			base.SkipTransitions();
		}

		// Token: 0x040005E6 RID: 1510
		internal bool FullScreen;

		// Token: 0x040005EC RID: 1516
		private int layoutHash;

		// Token: 0x040005ED RID: 1517
		private int scaleHash;
	}
}
