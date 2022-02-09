using Sandbox;
using System;
using System.Linq;
using Tools;

[Tool( "Test Window Test", "account_tree", "A test window, for testing" )]
public class TestWindow : Window
{
	[Menu( "Editor", "Help/About", "info" )]
	public static void OpenWindow()
	{
		Log.Info( "Open Window!" );
	}

	public TestWindow()
	{
		Title = "Garry's Test Window [САСАМБА]";
		Size = new Vector2( 1920, 1080 );

		CreateUI();
		Show();
	}

	public void BuildMenu()
	{
		var menu = MenuBar.AddMenu( "File" );
		menu.AddOption( "Open" );
		menu.AddOption( "Save" );

		menu.AddOption( "Quit" ).Triggered += () => Close();
	}


	public void CreateUI()
	{
		Clear();

		BuildMenu();

		var w = new Widget( null );
		var lo = new BoxLayout( BoxLayout.Direction.TopToBottom, w );
		var e = new NodeEditor.GraphView( w );
		lo.Add( e );
		e.Size = new Vector2( 500, 500 );

		e.AddNodeType<FloatNode>( true );
		e.AddNodeType<AdditionNode>( true );

		Canvas = w;
	}

	[Sandbox.Event.Hotload]
	public void OnHotload()
	{
		CreateUI();
	}
}
