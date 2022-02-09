using Sandbox.UI.Construct;
using System.Threading;

namespace Sandbox.UI.Dev
{
	public class BaseWidget : Panel
	{
		bool _dragging;
		bool Restored;
		Vector2 DragPosition;

		bool Dragging
		{
			get => _dragging;
			set
			{
				if ( _dragging == value ) return;
				_dragging = value;

				DragPosition = this.ScreenPositionToPanelPosition( Mouse.Position );
			}
		}

		public BaseWidget()
		{
			AddClass( "widget" );
		}

		public void AddHeader( string title, string icon )
		{
			var header = Add.Panel( "header" );
			header.Add.Icon( icon, "icon" );
			header.Add.Label( title, "title" );

			var close = header.Add.Icon( "close", "close" );
			close.AddEventListener( "click", CloseWidget );
		}

		protected override void OnMouseDown( MousePanelEvent e )
		{
			//if ( e.Target == this )
			{
				Dragging = true;
			}
		}		
		
		protected override void OnMouseUp( MousePanelEvent e )
		{
			Dragging = false;
		}

		protected override void OnDoubleClick( MousePanelEvent e )
		{
			base.OnDoubleClick( e );

			SetClass( "editmode", !HasClass( "editmode" ) );
		}

		public override void Tick()
		{
			base.Tick();

			if ( !IsVisible)
			{
				Dragging = false;
				return;
			}

			if ( !Restored )
			{
				Restored = true;

				var pos = Cookie.Get<Vector2>( $"widget.{GetType().Name}.position", -1 );
				if ( pos != -1 )
				{
					MoveTo( pos );
				}
			}

			if ( Dragging )
			{
				var pos = Mouse.Position - DragPosition;
				MoveTo( pos );
			}
		}

		public virtual void MoveTo( Vector3 pos )
		{
			pos.x = pos.x.SnapToGrid( 8.0f );
			pos.y = pos.y.SnapToGrid( 8.0f );

			// constrain to screen
			if ( pos.x < 0 ) pos.x = 0;
			if ( pos.x + Box.Rect.width > Screen.Width ) pos.x = Screen.Width - Box.Rect.width;
			if ( pos.y < 0 ) pos.y = 0;
			if ( pos.y + Box.Rect.height > Screen.Height ) pos.y = Screen.Height - Box.Rect.height;

			Style.Left = pos.x;
			Style.Top = pos.y;
			Style.Dirty();

			Cookie.Set<Vector2>( $"widget.{GetType().Name}.position", pos );
		}

		public virtual void CloseWidget()
		{
			// todo
		}
	}
}
