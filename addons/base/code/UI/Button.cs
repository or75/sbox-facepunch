using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;

namespace Sandbox.UI
{

	[Library( "Button" )]
	public class Button : Panel
	{
		protected Label TextLabel;
		protected Label SubtitleLabel;
		protected IconPanel IconPanel;

		public Button()
		{
			AddClass( "button" );
		}

		public Button( string text ) : this()
		{
			if ( text != null )
				Text = text;
		}

		public Button( string text, string icon ) : this()
		{
			if ( icon != null )
				Icon = icon;

			if ( text != null )
				Text = text;
		}

		public Button( string text, string icon, Action onClick ) : this( text, icon )
		{
			AddEventListener( "onclick", onClick );
		}

		public string Text
		{
			get => TextLabel?.Text;
			set
			{
				TextLabel ??= Add.Label( value, "button-label" );
				TextLabel.Text = value;

				SetClass( "has-label", TextLabel != null );
			}
		}

		public string Subtitle
		{
			get => SubtitleLabel?.Text;
			set
			{
				SubtitleLabel ??= Add.Label( value, "button-subtitle" );
				SubtitleLabel.Text = value;

				SetClass( "has-subtitle", SubtitleLabel != null );
			}
		}

		public void DeleteText()
		{
			if ( TextLabel == null ) return;

			TextLabel?.Delete();
			TextLabel = null;
			RemoveClass( "has-label" );
		}

		public string Icon
		{
			get => IconPanel?.Text;
			set
			{
				if ( string.IsNullOrEmpty( value ) )
				{
					IconPanel?.Delete( true );
				}
				else
				{
					IconPanel ??= Add.Icon( value );
					IconPanel.Text = value;
				}

				SetClass( "has-icon", IconPanel != null );
			}
		}

		public void DeleteIcon()
		{
			if ( IconPanel == null ) return;

			IconPanel?.Delete();
			IconPanel = null;
			RemoveClass( "has-icon" );
		}

		/// <summary>
		/// Calls Text = value
		/// </summary>
		public virtual void SetText( string text )
		{
			Text = text;
		}

		public override void SetProperty( string name, string value )
		{
			switch ( name )
			{
				case "text":
					{
						SetText( value );
						return;
					}

				case "html":
					{
						SetText( value );
						return;
					}

				case "icon":
					{
						Icon = value;
						return;
					}				
			}

			base.SetProperty( name, value );
		}

		public void Click()
		{
			CreateEvent( new MousePanelEvent( "onclick", this, "mouseleft" ) );
		}

		public override void SetContent( string value )
		{
			SetText( value );
		}

		[Property]
		public string ActiveValue { get; set; }		
		
		[Property]
		public string InactiveValue { get; set; }

		[Property]
		public string Active
		{
			get => ActiveValue;

			set
			{
				SetClass( "active", value == ActiveValue );
			}
		}

		protected override void OnClick( MousePanelEvent e )
		{
			base.OnClick( e );

			if ( !string.IsNullOrEmpty( ActiveValue ) )
			{
				if ( HasClass( "active" ) && !string.IsNullOrEmpty( InactiveValue ) )
				{
					CreateValueEvent( "active", InactiveValue );
					Active = InactiveValue;
				}
				else
				{
					CreateValueEvent( "active", ActiveValue );
					Active = ActiveValue;
				}
			}
		}

	}

	namespace Construct
	{
		public static class ButtonConstructor
		{
			public static Button Button( this PanelCreator self, string text, Action onClick = null )
			{
				var b = new Button( text, null, onClick );
				self.panel.AddChild( b );
				return b;
			}

			public static Button Button( this PanelCreator self, string text, string className, Action onClick = null )
			{
				var control = self.panel.AddChild<Button>();

				if ( text != null )
					control.SetText( text );

				if ( onClick != null )
					control.AddEventListener( "onclick", onClick );

				if ( className != null )
					control.AddClass( className );

				return control;
			}

			public static Button ButtonWithIcon( this PanelCreator self, string text, string icon, string className, Action onClick = null )
			{
				var control = self.panel.AddChild<Button>();

				if ( icon != null )
					control.Icon = icon;

				if ( text != null )
					control.SetText( text );

				if ( onClick != null )
					control.AddEventListener( "onclick", onClick );

				if ( className != null )
					control.AddClass( className );

				return control;
			}

			public static Button ButtonWithConsoleCommand( this PanelCreator self, string text, string command )
			{
				return Button( self, text, () => ConsoleSystem.Run( command ) );
			}
		}
	}

}
