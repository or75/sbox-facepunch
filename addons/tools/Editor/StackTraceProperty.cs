using Sandbox;
using System;
using System.Linq;
using Tools;

[CanEdit( "StackTrace" )]
public class StackTraceProperty : Frame, IPropertyInspector
{
	Widget Canvas;
	Layout CanvasLayout;

	Layout Layout;

	public bool IsFullWidth => true;

	public StackTraceProperty( Widget parent ) : base( parent )
	{
		Layout = MakeTopToBottom();
		Canvas = new Widget( this );
		Layout.Add( Canvas, 1 );
	}

	protected override void DataValueChanged( object value )
	{
		if ( value is not string stack ) return;

		Canvas?.Destroy();

		Canvas = new Widget( this );
		Layout.Add( Canvas, 1 );

		CanvasLayout = Canvas.MakeTopToBottom();

		var lines = stack.Split( '\n', '\r' );

		foreach ( var line in lines )
		{
			AddStackLine( line );
		}
	}

	private void AddStackLine( string line )
	{
		if ( string.IsNullOrWhiteSpace( line ) )
			return;

		var match = System.Text.RegularExpressions.Regex.Match( line.Trim(), "^at (.+?)( in (.+):line (.+))?$" );
		if ( match.Success )
		{
			var hasFile = match.Groups[3].Success;
			var isGenerated = match.Groups[3].Value.StartsWith( "Sandbox.Generator." );
			var functionName = match.Groups[1].Value;
			if ( functionName.IndexOf( '(' ) > 0 ) functionName = functionName.Substring( 0, functionName.IndexOf( '(' ) );

			if ( hasFile )
			{
				var fileName = match.Groups[3].Value;
				var fileLine = match.Groups[4].Value;

				var row = new StackRow( functionName, $"{fileName}:{fileLine}" );
				row.IsFromEngine = line.Contains( "\\engine\\Sandbox." );
				row.MouseClick += () => Tools.Utility.OpenCode( fileName, fileLine.ToInt() );

				CanvasLayout.Add( row );
				return;
			}
			else
			{

			}
		}

		{
			var row = new StackRow( line.Trim(), null );
			row.IsFromEngine = line.Contains( "\\engine\\Sandbox." );
			CanvasLayout.Add( row );
		}
	}


	protected class StackRow : Frame
	{
		string FunctionName;
		string FileName;
		public bool IsFromEngine;

		public StackRow( string functionName, string fileName ) : base( null )
		{
			FunctionName = functionName;
			FileName = fileName;
			MinimumSize = 28;
			Cursor = CursorShape.Finger;
		}

		protected override void OnMouseEnter() => Update();
		protected override void OnMouseLeave() => Update();

		protected override void OnPaint()
		{
			var r = new Rect( 0, Size );

			Color c = Theme.Blue;
			if ( !IsFromEngine ) c = Theme.Green;
			if ( FileName == null ) c = Theme.Blue.Darken( 0.3f ).Desaturate( 0.5f );

			if ( IsUnderMouse ) c = c.Lighten( 0.3f );

			Paint.SetPenEmpty();
			Paint.SetBrush( c.Darken( 0.8f ).Desaturate( 0.3f ) );
			Paint.DrawRect( r );

			r = r.Expand( -8.0f, 0 );

			Paint.SetPen( c );
			var textSize = Paint.DrawText( r, FunctionName, TextFlag.Left | TextFlag.VCenter );

			if ( FileName != null )
			{
				r.left = textSize.right + 5;
				Paint.SetPen( c.Darken( 0.3f ) );
				Paint.DrawText( r, FileName, TextFlag.Right | TextFlag.VCenter );
			}
		}
	}
}
