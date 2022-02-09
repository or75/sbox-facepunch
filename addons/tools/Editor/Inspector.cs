using System.Collections.Generic;
using System.Linq;
using Tools;

[Dock( "Editor", "Inspector", "manage_search" )]
public class Inspector : Widget
{
	static int counter;
	BoxLayout layout;
	ScrollArea Canvas;
	PropertySheet PropertySheet;

	InspectorHeader Header;

	public Inspector( Widget parent ) : base( parent )
	{
		layout = MakeTopToBottom();

		Header = new InspectorHeader( this );
		Header.SetSizeMode( SizeMode.Default, SizeMode.CanShrink );
		layout.Add( Header );

		Canvas = layout.Add( new ScrollArea( this ), 2 );
	//	Canvas.SetSizeMode( SizeMode.Default, SizeMode.CanShrink );

		PropertySheet = new PropertySheet( Canvas );
	//	PropertySheet.SetSizeMode( SizeMode.Default, SizeMode.CanShrink );

		layout.AddStretchCell( -1 );

		Utility.OnInspect += StartInspecting;

		// Debug - start inspecting self
		StartInspecting( this );

		Canvas.Canvas = PropertySheet;
	}

	private void StartInspecting( object obj )
	{
		if ( PropertySheet.Target == obj )
			return;

		PropertySheet.Target = obj;

		// Clear everything in our forward
		while ( ObjectHistory.Count > HistoryPlace + 1 )
			ObjectHistory.RemoveAt( ObjectHistory.Count - 1 );

		// Add to history
		ObjectHistory.Add( obj );
		HistoryPlace = ObjectHistory.Count - 1;

		// limit history size
		if ( ObjectHistory.Count > 100 )
		{
			ObjectHistory.RemoveAt( 0 );
			HistoryPlace--;
		}

		// keep buttons updates
		UpdateBackForward();
	}

	private void JumpToHistory()
	{
		PropertySheet.Target = ObjectHistory[HistoryPlace];
		UpdateBackForward();
	}

	public override void OnDestroyed()
	{
		base.OnDestroyed();

		Utility.OnInspect -= StartInspecting;
	}

	protected override void OnMousePress( MouseEvent e )
	{
		if ( e.Button == MouseButtons.Back && GoBack() )
		{
			e.Accepted = true;
			return;
		}

		if ( e.Button == MouseButtons.Forward && GoForward() )
		{
			e.Accepted = true;
			return;
		}

		base.OnMousePress( e );
	}

	public bool GoBack()
	{
		if ( HistoryPlace == 0 )
			return false;

		HistoryPlace--;
		JumpToHistory();

		return true;
	}

	public bool GoForward()
	{
		if ( HistoryPlace >= ObjectHistory.Count()-1 )
			return false;

		HistoryPlace++;
		JumpToHistory();

		return true;
	}

	void UpdateBackForward()
	{
		Header.UpdateBackForward( HistoryPlace > 0, HistoryPlace < ObjectHistory.Count() - 1 );
	}

	public int HistoryPlace = 0;
	public List<object> ObjectHistory = new();
}

public class InspectorHeader : ToolBar
{
	Inspector Inspector;

	Option Back;
	Option Forward;

	public InspectorHeader( Inspector parent ) : base( parent )
	{
		Inspector = parent;

		SetIconSize( 16 );

		Back = AddOption( new Option( this, "Previous", "arrow_back", () => Inspector.GoBack() ) );
		Forward = AddOption( new Option( this, "Next", "arrow_forward", () => Inspector.GoForward() ) );

		AddSeparator();

		AddWidget( new LineEdit( this ) { PlaceholderText = "Filter.." } );

		UpdateBackForward( false, false );
	}

	public void UpdateBackForward( bool back, bool forward )
	{
		Back.Enabled = back;
		Forward.Enabled = forward;
	}
}
