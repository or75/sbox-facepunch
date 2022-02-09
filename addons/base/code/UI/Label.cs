using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.UI
{
	[Library( "label", Alias = new[] { "text" } )]
	public partial class Label : Panel
	{
		internal Sandbox.Internal.UI.TextPanel InternalLabel;

		protected StringInfo StringInfo = new();

		public virtual string Text
		{
			get => InternalLabel.Text;
			set
			{
				InternalLabel.Text = value;
				StringInfo.String = InternalLabel.Text ?? string.Empty;
				CaretSantity();
			}
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
			if ( name == "text" )
			{
				Text = value;
				return;
			}

			if ( name == "selectable" )
			{
				//Selectable = value.ToBool();
				return;
			}

			base.SetProperty( name, value );
		}

		/// <summary>
		/// If false then this label won't be selected, even if the parent has TextSelection enabled.
		/// </summary>
		public bool Selectable
		{
			get => InternalLabel?.Selectable ?? false;
			set { InternalLabel.Selectable = value; }
		}		
		
		public bool ShouldDrawSelection
		{
			get => InternalLabel?.ShouldDrawSelection ?? false;
			set { InternalLabel.ShouldDrawSelection = value; }
		}

		public int SelectionStart
		{
			get => InternalLabel?.SelectionStart ?? 0;
			set { InternalLabel.SelectionStart = value.Clamp( 0, StringInfo.LengthInTextElements ); }
		}
		public int SelectionEnd
		{
			get => InternalLabel?.SelectionEnd ?? 0;
			set { InternalLabel.SelectionEnd = value.Clamp( 0, StringInfo.LengthInTextElements ); }
		}

		public Label()
		{
			InternalLabel = new Internal.UI.TextPanel( this );
			AddClass( "label" );
		}

		public Rect GetCaretRect( int i ) => InternalLabel.GetCaretRect( i );

		public int GetLetterAt( Vector2 pos ) => InternalLabel.GetLetterAt( pos );
		public int GetLetterAtScreenPosition( Vector2 pos ) => InternalLabel.GetLetterAtScreenPosition( pos );

		public override void SetContent( string value )
		{
			Text = value;
		}

		public int CaretPosition { get; set; }

		public int TextLength => StringInfo.LengthInTextElements;

		protected void CaretSantity()
		{
			if ( CaretPosition > TextLength ) CaretPosition = TextLength;
			if ( SelectionStart > TextLength ) SelectionStart = TextLength;
			if ( SelectionEnd > TextLength ) SelectionEnd = TextLength;
		}

		public bool HasSelection() => ShouldDrawSelection && SelectionStart != SelectionEnd;

		public string GetSelectedText()
		{
			CaretSantity();

			var s = Math.Min( SelectionStart, SelectionEnd );
			var e = Math.Max( SelectionStart, SelectionEnd );

			return StringInfo.SubstringByTextElements( s, e-s );
		}

		public override string GetClipboardValue( bool cut )
		{
			if ( !HasSelection() )
				return null;

			var txt = GetSelectedText();

			return txt;
		}
	}

	namespace Construct
	{
		public static class LabelConstructor
		{
			public static Label Label( this PanelCreator self, string text = null, string classname = null )
			{
				var control = self.panel.AddChild<Label>();

				if ( text != null )
					control.Text = text;

				if ( classname != null )
					control.AddClass( classname );

				return control;
			}
		}
	}
}
