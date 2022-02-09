using Sandbox;
using Tools;

public static class AboutDialog
{

	static GraphicsView graphicsView;

	[Event( "frame" )]
	public static void Frame()
	{
		// this dunt work because frame doesn't get called with a modal dialog
		if ( graphicsView.IsValid() )
		{
			//graphicsView.Rotation += 20.0f * RealTime.Delta;
			//graphicsView.CenterOn( new Vector2( 100, 10 ) );
		}
	}	

	[Event( "about.open" )]
	public static void Open( Widget dialog )
	{
		var layout = new BoxLayout( BoxLayout.Direction.TopToBottom, dialog );
		layout.Spacing = 5;

		Log.Info( "Opening About Dialog" );

		var text = new Tools.Graphic.SimpleText( "Hello simple text" );

		graphicsView = new GraphicsView( dialog );
		graphicsView.SceneRect = new( 0, 0, 1000, 1000 );
		graphicsView.Scale = 3;
		graphicsView.Rotation = 32;
		graphicsView.CenterOn( new Vector2( 100, 10 ) );

		text.Position = new Vector2( 100, 10 );
		graphicsView.Add( text );

		var bb = new Button( "Bog f!!!" );

		var proxy = graphicsView.Add( bb );
		graphicsView.Add( proxy );
		proxy.Position = new Vector2( 10, 10 );

		bb.Pressed += () => proxy.Position += Vector2.Random * 5.0f;
		bb.Released += () => proxy.Position += Vector2.Random * 10.0f;

		var x = new Tools.Graphic.SimpleText( "Poop Oppoo", text );
		x.Position = new Vector2( 100, 10 );

		layout.Add( graphicsView );

		var editor = new LineEdit( "", dialog );
		editor.PlaceholderText = "Write Somethign Here!";

		layout.Add( editor );

		var button = new Label( "Hello there!", dialog );

		layout.Add( button, 2 );

		editor.TextEdited += ( str ) => button.Text = $"You Wrote: \"{str}\"";

		var buttonTwo = new Button( "This is BUTTON 2 ❤😀", dialog );

		buttonTwo.Clicked += () => button.Text = "Button 2 was CLICKED!";
		buttonTwo.Pressed += () => button.Text = "Button 2 was pressed!";

		layout.Add( buttonTwo );

		{
			var bottomRow = new BoxLayout( BoxLayout.Direction.LeftToRight, dialog );

			int i = 1;
			buttonTwo.Clicked += () =>
			{
				text.Text = $"{i}";
				var b = new Button( $"#{i++}", dialog );
				bottomRow.Add( b );

				graphicsView.Destroy();
			};

			layout.Add( bottomRow );
		}
	}
}

namespace Tools
{
	public class ConsoleWidget : Widget
	{
		public ConsoleWidget( Widget parent ) : base( parent )
		{
			MinimumSize = new( 200, 200 );

			var layout = new BoxLayout( BoxLayout.Direction.TopToBottom, this );

			layout.Add( new Widget( null ) );
			layout.Add( new LineEdit() );
		}
	}
}
