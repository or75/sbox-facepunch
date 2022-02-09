using Sandbox;
using System;
using Tools;

/// <summary>
/// A text box with a draggable icon on the left.
/// Dragging the icon left and right will change the value
/// Dragging the icon up and down will change the rate at which the value changes
/// So dragging down, then left and right will change in 100s, dragging up and then left and right will change in 0.01s
/// </summary>
[CanEdit( "folder" )]
public class FolderProperty : LineEdit
{
	public Action<string> FolderSelected;
	public string DialogTitle { get; set; } = "Find Folder";

	public FolderProperty( Widget parent ) : base( parent )
	{
		MinimumSize = Theme.RowHeight;
		MaximumSize = new Vector2( 4096, Theme.RowHeight );

		AddOptionToEnd( new Option( "Browse For Folder", "folder", Browse ) );
	}

	public void Browse()
	{
		var fd = new FileDialog( null );
		fd.Title = DialogTitle;
		fd.SetFindDirectory();

		if ( fd.Execute() )
		{
			Text = fd.SelectedFile;
			FolderSelected?.Invoke( Text );
		}
	}

	protected override void OnMouseEnter()
	{
		base.OnMouseEnter();
		Update();
	}

	protected override void OnMouseLeave()
	{
		base.OnMouseLeave();
		Update();
	}

	protected override void OnPaint()
	{
		base.OnPaint();
	}

	public override DropAction OnDragEnter( DragData data )
	{
		if ( !data.HasFileOrFolder )
			return DropAction.Ignore;

		return DropAction.Link;
	}

	public override DropAction OnDropEvent( DragData data )
	{
		if ( !data.HasFileOrFolder )
			return DropAction.Ignore;

		// TODO - trim filename if it's a file?

		Text = data.FileOrFolder;
		FolderSelected?.Invoke( Text );

		return DropAction.Link;
	}

}
