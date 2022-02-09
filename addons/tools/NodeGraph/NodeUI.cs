using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tools;

namespace NodeEditor
{
	public partial class NodeUI : Tools.GraphicsItem
	{
		public BaseNode Node { get; protected set; }

		public GraphView Graph { get; protected set; }
		DropShadow Shadow;
		public NodeTitlebar TitleBar;

		public Color SelectionOutline = Color.Parse( "#ff99c8" ) ?? default;


		public List<PlugIn> Inputs = new();
		public List<PlugOut> Outputs = new();

		public NodeUI( GraphView graph, BaseNode node )
		{
			Node = node;
			Graph = graph;
			Movable = true;
			Selectable = true;
			HoverEvents = true;

			Size = new Vector2( 256, 512 );

			TitleBar = new NodeTitlebar();
			TitleBar.Size = new Vector2( Size.x, 35 );
			TitleBar.Parent = this;

			Shadow = new DropShadow();
			Shadow.Position = new Vector2( -3, -3 );
			Shadow.Parent = this;

			var display = Sandbox.DisplayInfo.For( Node );
			TitleBar.Title = display.Name;

			foreach ( var property in Node.GetType().GetProperties() )
			{
				var input = property.GetCustomAttribute<BaseNode.InputAttribute>();
				if ( input != null )
				{
					var handle = new PlugIn( this, property, input );
					handle.Parent = this;

					Inputs.Add( handle );
				}

				var output = property.GetCustomAttribute<BaseNode.OutputAttribute>();
				if ( output != null )
				{
					var handle = new PlugOut( this, property, output );
					handle.Parent = this;

					Outputs.Add( handle );
				}
			}



			Layout();



			/*
			Widget = new Widget( null );
			Widget.Name = "Node";
			Widget.SetStylesheetFile( "/my_node.css" );
			Widget.Size = new Vector2( 100, 100 );

			Titlebar = new NodeTitlebar( Widget );
			Titlebar.Name = "Title";

			Body = new Widget( Widget );
			Body.Name = "Body";

			var layout = new BoxLayout( BoxLayout.Direction.TopToBottom, Widget );

			layout.Add( Titlebar );
			layout.Add( Body );

			layout.SetCellStretch( 1, 1 );

			var bodyLayout = new BoxLayout( BoxLayout.Direction.TopToBottom, Body );

			for ( int i=0; i<10; i++ )
			{
				bodyLayout.Add( new NodeInput( Body ) );
			}

			for ( int i = 0; i < 2; i++ )
			{
				bodyLayout.Add( new NodeOutput( Body ) );
			}*/
		}

		void Layout()
		{
			var inputHeight = Inputs.Sum( x => x.Size.y );
			var outputHeight = Outputs.Sum( x => x.Size.y );

			var top = TitleBar.Size.y;
			var width = Size.x;

			foreach ( var input in Inputs )
			{
				input.Position = new Vector2( 0, top );
				input.Size = input.Size.WithX( width * 0.5f );
				top += input.Size.y;
			}

			top = TitleBar.Size.y;
			foreach ( var output in Outputs )
			{
				output.Position = new Vector2( width * 0.5f, top );
				output.Size = output.Size.WithX( width * 0.5f );
				top += output.Size.y;
			}

			var bodyHeight = MathF.Max( inputHeight, outputHeight );
			Size = Size.WithY( TitleBar.Size.y + bodyHeight );
			Shadow.Size = Size + 20;
		}

		protected override void OnPaint()
		{
			var rect = new Rect();
			rect.Size = Size;

			Paint.SetPen( new Color( 0.5f, 0.5f, 0.5f, 0.9f ), 1.0f );
			Paint.SetBrush( new Color( 0.2f, 0.2f, 0.2f, 0.9f ) );
			Paint.DrawRect( rect, 5.0f );
			
			Paint.SetPenEmpty();
			Paint.SetBrush( new Color( 0.1f, 0.1f, 0.1f, 0.3f ) );
			Paint.DrawRect( new Rect( rect.width * 0.5f, 34.0f, rect.width * 0.5f - 1, rect.height - 35.0f ), 2 );

			if ( Paint.HasSelected )
			{
				Paint.SetPen( SelectionOutline, 2.0f );
				Paint.SetBrushEmpty();
				Paint.DrawRect( rect, 4.0f );
			}
			else if ( Paint.HasMouseOver )
			{
				Paint.SetPen( SelectionOutline.WithAlpha( 0.4f ), 2.0f );
				Paint.SetBrushEmpty();
				Paint.DrawRect( rect, 4.0f );
			}
		}

		protected override void OnMouseReleased( GraphicsMouseEvent e )
		{
			base.OnMouseReleased( e );

			
		}

		internal void DraggingOutput( PlugOut nodeOutput, Vector2 scenePosition, Connection source = null )
		{
			Graph?.DraggingOutput( this, nodeOutput, scenePosition, source );
		}

		internal void DroppedOutput( PlugOut nodeOutput, Vector2 scenePosition, Connection source = null )
		{
			Graph?.DroppedOutput( this, nodeOutput, scenePosition, source );
		}

		protected override void OnPositionChanged()
		{
			Position = Position.SnapToGrid( 16.0f );

			Graph?.NodePositionChanged( this );
		}
	}


}



namespace Sandbox
{
}
