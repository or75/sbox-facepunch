using Sandbox;
using System;
using Tools;

[Dock( "Editor", "Panels", "widgets" )]
public class PanelTree : Widget
{
	ComboBox RootSelector;
	TreeView TreeView;

	public PanelTree( Widget parent ) : base( parent )
	{
		var layout = MakeTopToBottom();
		layout.SetContentMargins( 4, 4, 4, 4 );
		layout.Spacing = 4;

		RootSelector = new ComboBox( this );
		layout.Add( RootSelector );

		TreeView = new TreeView( this );
		TreeView.ShowHeader = false;
		TreeView.HoveredNodeChanged += OnHoverNode;

		layout.Add( TreeView, 1 );
	}


	int lastCOunt;

	[Event.Frame]
	public void Frame()
	{
		if ( RootPanels.Count != lastCOunt )
		{
			lastCOunt = RootPanels.Count;
			RootSelector.Clear();

			RootSelector.AddItem( "None", "clear", () => SwitchTreeTo( null ) );

			for ( int i = 0; i < RootPanels.Count; i++ )
			{
				var panel = RootPanels[i];
				RootSelector.AddItem( panel.GetType().FullName, panel.IsMainMenu ? "menu" : "sports_esports", () => SwitchTreeTo( panel ) );
			}
		}
	}

	void SwitchTreeTo( Sandbox.Internal.IPanel panel )
	{
		TreeView.Clear();

		if ( panel == null )
			return;

		var node = new DataValueNode<Sandbox.Internal.IPanel>( panel );
		node.OnPaintItem = PaintItem;
		node.OnGetChildren = ( o ) => o.Children;
		node.OnSelected = ( o ) =>
		{
			EngineOverlay.Redraw();
			SelectedPanel = o;
			Utility.Inspect( o );
		};

		TreeView.SetModel( node );
	}

	private void PaintItem( Sandbox.Internal.IPanel panel, Rect rect, int column )
	{
		var info = DisplayInfo.For( panel );

		Paint.SetPen( Color.White );

		if ( Paint.HasEnabled ) Paint.SetPen( Color.Yellow );
		if ( Paint.HasSelected ) Paint.SetPen( Color.Red );
		if ( Paint.HasMouseOver ) Paint.SetPen( Color.Green );

		var r = rect;

		{
			Paint.SetPen( Theme.Green );
			var size = Paint.DrawMaterialIcon( r, info.Icon ?? "window", 14, TextFlag.LeftCenter );
			r.left += size.width + 5;
		}

		Paint.SetDefaultFont( 9, 400 );

		{
			Paint.SetPen( Theme.White );

			var size = Paint.DrawText( r, panel?.ElementName, TextFlag.LeftCenter );
			r.left += size.width;
		}

		Paint.SetDefaultFont( 8 );

		if ( !string.IsNullOrEmpty( panel?.Classes ) )
		{
			var classText = panel?.Classes.Replace( " ", "." );
			classText = $".{classText}";

			Paint.SetPen( Theme.Blue );
			Paint.DrawText( r, classText, TextFlag.LeftCenter );
		}
	}

	protected override void OnMouseLeave()
	{
		base.OnMouseLeave();
		SelectedPanel = null;
		EngineOverlay.Redraw();
	}

	private void OnHoverNode( DataNode obj )
	{
		EngineOverlay.Redraw();

		HoveredPanel = null;

		if ( TreeView.HoveredNode is DataValueNode<Sandbox.Internal.IPanel> node )
			HoveredPanel = node.Value;
	}


	Sandbox.Internal.IPanel SelectedPanel;
	Sandbox.Internal.IPanel HoveredPanel;

	[Event( "paintoverlay" )]
	public void DrawGameOverlay()
	{
		if ( SelectedPanel != null )
		{
			Paint.SetPen( Color.Magenta, 1.0f );
			Paint.DrawRect( SelectedPanel.InnerRect.Shrink( 0, 0, 1, 1 ) );

			Paint.SetPen( Color.Yellow, 1.0f );
			Paint.DrawRect( SelectedPanel.OuterRect.Shrink( 0, 0, 1, 1 ) );

			Paint.SetPen( Color.Green, 1.0f );
			Paint.DrawRect( SelectedPanel.Rect.Shrink( 0, 0, 1, 1 ) );
		}

		// oof - I bet I can make this not suck so much
		if ( HoveredPanel != null )
		{
			Paint.SetPen( Color.Cyan, 1.0f );
			Paint.DrawRect( HoveredPanel.InnerRect.Shrink( 0, 0, 1, 1 ) );

			Paint.SetPen( Color.Cyan, 1.0f );
			Paint.DrawRect( HoveredPanel.OuterRect.Shrink( 0, 0, 1, 1 ) );

			Paint.SetPen( Color.White, 1.0f );
			Paint.DrawRect( HoveredPanel.Rect.Shrink( 0, 0, 1, 1 ) );
		}
	}
}
