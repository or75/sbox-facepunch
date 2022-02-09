using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Sandbox.UI
{

	[Library( "TextEntry" )]
	public partial class TextEntry : Panel, IInputControl
	{
		public Label Label { get; set; }
		public string Text
		{
			get => Label.Text;
			set => Label.Text = value;
		}

		public int TextLength
		{
			get => Label.TextLength;
		}

		public int CaretPosition
		{
			get => Label.CaretPosition;
			set => Label.CaretPosition = value;
		}

		public override bool HasContent => true;

		public bool AllowEmojiReplace { get; set; } = false;

		/// <summary>
		/// Allow IME input when this is focused
		/// </summary>
		public override bool AcceptsImeInput => true;


		[Category( "Presentation" )]
		public string NumberFormat { get; set; } = null;

		[Property]
		public bool Multiline { get; set; } = false;

		[Property]
		public Color CaretColor { get; set; } = Color.White;


		/// <summary>
		/// If we're numeric, this is the lowest numeric value allowed
		/// </summary>
		public float? MinValue { get; set; }

		/// <summary>
		/// If we're numeric, this is the highest numeric value allowed
		/// </summary>
		public float? MaxValue { get; set; }

		public Label PrefixLabel { get; protected set; }

		public string Prefix
		{
			get => PrefixLabel?.Text;
			set
			{
				PrefixLabel ??= Add.Label( value, "prefix-label" );
				PrefixLabel.Text = value;

				SetClass( "has-prefix", PrefixLabel != null );
			}
		}

		public Label SuffixLabel { get; protected set; }

		public string Suffix
		{
			get => SuffixLabel?.Text;
			set
			{
				SuffixLabel ??= Add.Label( value, "suffix-label" );
				SuffixLabel.Text = value;

				SetClass( "has-suffix", SuffixLabel != null );
			}
		}


		public TextEntry()
		{
			AcceptsFocus = true;
			AddClass( "textentry" );

			Label = Add.Label( "", "content-label" );
		}

		public override void OnPaste( string text )
		{
			foreach ( var c in text )
			{
				OnKeyTyped( c );
			}
		}

		public override string GetClipboardValue( bool cut )
		{
			var value = Label.GetClipboardValue( cut );

			if ( cut )
			{
				Label.ReplaceSelection( "" );
				OnValueChanged();
			}

			return value;
		}



		public override void OnButtonTyped( string button, KeyModifiers km )
		{
			//Log.Info( $"OnButtonTyped {button}" );

			if ( Label.HasSelection() && (button == "delete" || button == "backspace") )
			{
				Label.ReplaceSelection( "" );
				OnValueChanged();

				return;
			}

			if ( button == "delete" )
			{
				if ( CaretPosition < TextLength )
				{
					int amountToRemove = 1;
					if ( km.Ctrl )
					{
						Label.FindWordBoundary( Label.CaretPosition + 1, out int _, out int endPosition, true );
						amountToRemove = endPosition - Label.CaretPosition;
					}

					Label.RemoveText( CaretPosition, amountToRemove );
					OnValueChanged();
				}

				return;
			}

			if ( button == "backspace" )
			{
				if ( CaretPosition > 0 )
				{
					int amountToRemove = 1;
					if ( km.Ctrl )
					{
						Label.FindWordBoundary( Label.CaretPosition - 1, out int startPosition, out int _, true );
						amountToRemove = Label.CaretPosition - startPosition;
					}

					Label.MoveCaratPos( -amountToRemove );
					Label.RemoveText( CaretPosition, amountToRemove );
					OnValueChanged();
				}

				return;
			}

			if ( button == "a" && km.Ctrl )
			{
				Label.SelectionStart = 0;
				Label.SelectionEnd = TextLength;
				return;
			}

			if ( button == "home" )
			{
				Label.MoveToLineStart( km.Shift );
				return;
			}

			if ( button == "end" )
			{
				Label.MoveToLineEnd( km.Shift );
				return;
			}

			if ( button == "left" )
			{
				if ( !km.Ctrl )
				{
					Label.MoveCaratPos( -1, km.Shift );
				}
				else
				{
					Label.FindWordBoundary( Label.CaretPosition - 1, out int startPosition, out int _, true );
					if ( Label.CaretPosition == startPosition && startPosition > 0 ) startPosition--;
					Label.SetCaretPosition( startPosition, km.Shift );
				}
				return;
			}

			if ( button == "right" )
			{
				if ( !km.Ctrl )
				{
					Label.MoveCaratPos( 1, km.Shift );
				}
				else
				{
					Label.FindWordBoundary( Label.CaretPosition + 1, out int _, out int endPosition, true );
					Label.SetCaretPosition( endPosition, km.Shift );
				}
				return;
			}

			if ( button == "down" || button == "up" )
			{
				if ( AutoCompletePanel != null )
				{
					AutoCompletePanel.MoveSelection( button == "up" ? -1 : 1 );
					AutoCompleteSelectionChanged();
					return;
				}

				//
				// We have history items, autocomplete using those
				//
				if ( string.IsNullOrEmpty( Text ) && AutoCompletePanel == null && History.Count > 0 )
				{
					UpdateAutoComplete( History.ToArray() );

					// select last item
					AutoCompletePanel.MoveSelection( -1 );
					AutoCompleteSelectionChanged();

					return;
				}

				Label.MoveCaretLine( button == "up" ? -1 : 1, km.Shift );
				return;
			}

			if ( button == "enter" || button == "pad_enter" )
			{
				if ( Multiline )
				{
					OnKeyTyped( '\n' );
					return;
				}

				if ( AutoCompletePanel != null && AutoCompletePanel.SelectedChild != null )
				{
					DestroyAutoComplete();
				}

				Blur();
				CreateEvent( "onsubmit", Text );
				return;
			}

			if ( button == "escape" )
			{
				if ( AutoCompletePanel != null )
				{
					AutoCompleteCancel();
					return;
				}

				Blur();
				CreateEvent( "oncancel" );
				return;
			}

			base.OnButtonTyped( button, km );
		}

		protected override void OnMouseDown( MousePanelEvent e )
		{
			var pos = Label.GetLetterAtScreenPosition( Mouse.Position );

			Label.SelectionStart = 0;
			Label.SelectionEnd = 0;

			if ( pos >= 0 )
			{
				Label.SetCaretPosition( pos );
			}
		}

		protected override void OnMouseUp( MousePanelEvent e )
		{
			var pos = Label.GetLetterAtScreenPosition( Mouse.Position );
			if ( Label.SelectionEnd > 0 ) pos = Label.SelectionEnd;
			Label.CaretPosition = pos.Clamp( 0, TextLength );
		}

		protected override void OnFocus( PanelEvent e )
		{
			UpdateAutoComplete();
		}

		protected override void OnBlur( PanelEvent e )
		{
			//UpdateAutoComplete();

			if ( Numeric )
			{
				Text = FixNumeric();
			}
		}

		protected override void OnDoubleClick( MousePanelEvent e )
		{
			if ( e.Button == "mouseleft" )
			{
				Label.SelectWord( Label.GetLetterAtScreenPosition( Mouse.Position ) );
			}
		}

		public override void OnKeyTyped( char k )
		{
			if ( !CanEnterCharacter( k ) )
				return;

			if ( MaxLength.HasValue && TextLength >= MaxLength )
				return;

			if ( Label.HasSelection() )
			{
				Label.ReplaceSelection( k.ToString() );
			}
			else
			{
				Text ??= "";
				Label.InsertText( k.ToString(), CaretPosition );
				Label.MoveCaratPos( 1 );
			}

			if ( k == ':' )
			{
				RealtimeEmojiReplace();
			}

			OnValueChanged();
		}


		public override void DrawContent( ref RenderState state )
		{
			Label.ShouldDrawSelection = HasFocus;

			var blinkRate = 0.8f;

			if ( HasFocus )
			{
				var blink = (TimeSinceNotInFocus * blinkRate) % blinkRate < (blinkRate * 0.5f);
				var caret = Label.GetCaretRect( CaretPosition );
				caret.right += 0.4f;
				caret.left -= 0.4f;

				var color = CaretColor;
				color.a *= blink ? 1.0f : 0.05f;

				Render.UI.Box( caret, color );
			}
		}

		void RealtimeEmojiReplace()
		{
			if ( !AllowEmojiReplace )
				return;

			if ( CaretPosition == 0 )
				return;

			string lookup = null;

			for ( int i = CaretPosition - 2; i >= 0; i-- )
			{
				var c = Text[i];

				if ( char.IsWhiteSpace( c ) )
					return;

				if ( c == ':' )
				{
					lookup = Text.Substring( i, CaretPosition - i );
					break;
				}

				if ( i == 0 )
					return;
			}

			if ( lookup == null )
				return;

			var replace = Emoji.FindEmoji( lookup );
			if ( replace == null )
				return;

			var lengthDelta = replace.Length - lookup.Length;

			Text = Text.Replace( lookup, replace );
			CaretPosition += lengthDelta;
		}

		public virtual void OnValueChanged()
		{
			UpdateAutoComplete();
			UpdateValidation();

			if ( Numeric )
			{
				// with numberic, we don't ever want to
				// send out invalid values to binds
				var text = FixNumeric();
				CreateEvent( "onchange" );
				CreateValueEvent( "value", text );
			}
			else
			{
				CreateEvent( "onchange" );
				CreateValueEvent( "value", Text );
			}
		}

		/// <summary>
		/// Keep tabs of when we were focused so we can flash the caret rative to that time.
		/// We want the caret to be visible immediately on focus
		/// </summary>
		RealTimeSince TimeSinceNotInFocus;

		public override void Tick()
		{
			base.Tick();

			SetClass( "is-multiline", Multiline );
			SetClass( "has-placeholder", string.IsNullOrEmpty( Text ) && PlaceholderLabel != null );

			if ( !HasFocus )
				TimeSinceNotInFocus = 0;
		}

		public override void SetProperty( string name, string value )
		{
			base.SetProperty( name, value );

			if ( name == "placeholder" )
			{
				Placeholder = value;
			}

			if ( name == "numeric" )
			{
				Numeric = value.ToBool();
			}

			if ( name == "format" )
			{
				NumberFormat = value;
			}

			if ( name == "value" && !HasFocus )
			{
				//
				// When setting tha value, and we're numeric, convert it to a number
				//
				if ( Numeric )
				{
					if ( !float.TryParse( value, out var floatValue ) )
						return;

					Text = floatValue.ToString( NumberFormat );
					return;
				}

				Text = value;
			}

		}

		public virtual string FixNumeric()
		{
			if ( !float.TryParse( Text, out var floatValue ) )
			{
				var val = 0.0f.Clamp( MinValue ?? floatValue, MaxValue ?? floatValue );
				return val.ToString();
			}

			floatValue = floatValue.Clamp( MinValue ?? floatValue, MaxValue ?? floatValue );
			return floatValue.ToString( NumberFormat );
		}

		protected override void OnDragSelect( SelectionEvent e )
		{
			var tl = new Vector2( e.SelectionRect.left, e.SelectionRect.top );
			var br = new Vector2( e.SelectionRect.right, e.SelectionRect.bottom );

			Label.ShouldDrawSelection = true;
			Label.SelectionStart = Label.GetLetterAtScreenPosition( tl );
			Label.SelectionEnd = Label.GetLetterAtScreenPosition( br );
		}
	}

	namespace Construct
	{
		public static class TextEntryConstructor
		{
			public static TextEntry TextEntry( this PanelCreator self, string text )
			{
				var control = self.panel.AddChild<TextEntry>();
				control.Text = text;

				return control;
			}
		}
	}

}
