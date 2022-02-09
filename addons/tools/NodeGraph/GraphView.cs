using Sandbox;
using System;
using System.Collections.Generic;
using Tools;

namespace NodeEditor;

public class GraphView : GraphicsView
{
	Graph _graph;
	Graph Graph
	{
		get => _graph;
		set
		{
			if ( _graph == value ) return;

			_graph = value;
			// clear, rebuild?
		}
	}

	List<Type> AvailableNodes = new();
	List<Connection> Connections = new();

	public GraphView( Widget parent ) : base( parent )
	{
		Antialiasing = true;
		TextAntialiasing = true;
		BilinearFiltering = true;

		SceneRect = new Rect( -100000, -100000, 200000, 200000 );

		SetBackgroundImage( "image/background-grid64.png" );

		HorizontalScrollbar = ScrollbarMode.Off;
		VerticalScrollbar = ScrollbarMode.Off;

		Add( new NodeUI( this, new FloatNode() ) { Position = new Vector2( -200, -200 ) } );
		Add( new NodeUI( this, new FloatNode() ) { Position = new Vector2( 100, -200 ) } );
	}

	[Event.Frame]
	public void Frame()
	{
		//var d = new Vector2();

		//d.x = Noise.Perlin( RealTime.Now * 10.0f, 0, 0 );
		//d.y = Noise.Perlin( RealTime.Now * 10.0f, 1, 0 );

		//text.Position += d * 2;

		
	}

	protected override void OnWheel( WheelEvent e )
	{
		Zoom( e.Delta > 0 ? 1.1f : 0.90f, e.Position );
		e.Accept();
	}

	internal void AddNodeType<T>( bool v )
	{
		if ( AvailableNodes.Contains( typeof( T ) ) ) return;

		AvailableNodes.Add( typeof( T ) );
	}

	protected override void OnMouseReleased( MouseEvent e )
	{
		//TransformAnchor = ViewportAnchorType.NoAnchor;
		//CenterOn( ToScene( e.LocalPosition ) );

		//e.Accept();
	}

	protected override void OnMousePress( MouseEvent e )
	{
		//TransformAnchor = ViewportAnchorType.NoAnchor;
		//CenterOn( ToScene( e.LocalPosition ) );

		//e.Accept();

		if ( e.RightMouseButton )
		{

		}
	}

	protected override void OnContextMenu( ContextMenuEvent e )
	{
		var clickPos = ToScene( e.LocalPosition );

		var menu = new Menu( this );

		foreach( var node in AvailableNodes )
		{
			var display = DisplayInfo.ForType( node );

			var action = menu.AddOption( display.Name );
			action.Triggered += () => Add( new NodeUI( this, Activator.CreateInstance( node ) as BaseNode ) { Position = clickPos } );
		}

		menu.OpenAt( e.ScreenPosition );
	}

	Vector2 lastMousePosition;

	protected override void OnMouseMove( MouseEvent e )
	{
		if ( e.MiddleMouseButton )
		{
			var delta = ToScene( e.LocalPosition ) - lastMousePosition;
			Translate( delta );
			e.Accepted = true;
			Cursor = CursorShape.ClosedHand;
		}
		else
		{
			Cursor = CursorShape.None;
		}

		e.Accepted = true;
		lastMousePosition = ToScene( e.LocalPosition );
	}

	internal PlugIn DropTarget { get; set; }

	Connection Preview;

	internal void DraggingOutput( NodeUI node, NodeEditor.PlugOut nodeOutput, Vector2 scenePosition, Connection source )
	{
		var item = GetItemAt( scenePosition );

		DropTarget?.Update();
		DropTarget = item as NodeEditor.PlugIn;
		DropTarget?.Update();

		if ( Preview == null )
		{
			Preview = new Connection( nodeOutput );
			Add( Preview );
		}

		Preview.LayoutForPreview( nodeOutput, scenePosition, DropTarget );
	}

	internal void DroppedOutput( NodeUI node, NodeEditor.PlugOut nodeOutput, Vector2 scenePosition, Connection source )
	{
		if ( source != null )
		{
			// Dropped on the same connection it was already connected to
			if ( source.Input == DropTarget ) return;

			source.Disconnect();
			source.Destroy();
		}

		if ( DropTarget != null )
		{
			CreateConnection( nodeOutput, DropTarget );
		}

		Preview?.Destroy();
		Preview = null;

		DropTarget?.Update();
		DropTarget = null;
	} 

	private void CreateConnection( PlugOut nodeOutput, PlugIn dropTarget )
	{
		var connection = new Connection( nodeOutput, dropTarget );
		connection.Layout();
		Add( connection );

		Connections.Add( connection ); 
	}

	internal void RemoveConnection( Connection c )
	{
		Connections.Remove( c );
	}

	internal void NodePositionChanged( NodeUI node )
	{
		foreach( var connection in Connections )
		{
			if ( !connection.IsAttachedTo( node ) )
				continue;

			connection.Layout();
		}
	}
}
