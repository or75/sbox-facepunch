using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.UI
{
	public partial class Label
	{
		public bool Multiline { get; set; }

		public void ReplaceSelection( string str )
		{
			var s = Math.Min( SelectionStart, SelectionEnd );
			var e = Math.Max( SelectionStart, SelectionEnd );
			var len = e - s;

			if ( CaretPosition > e ) CaretPosition -= len;
			else if ( CaretPosition > s ) CaretPosition = s;

			CaretPosition += new StringInfo( str ).LengthInTextElements;
			InsertText( str, s, e );

			SelectionStart = 0;
			SelectionEnd = 0;
		}

		public void SetSelection( int start, int end )
		{
			var s = Math.Min( start, end ).Clamp( 0, TextLength );
			var e = Math.Max( start, end ).Clamp( 0, TextLength );

			if ( s == e )
			{
				s = 0;
				e = 0;
			}

			SelectionStart = s;
			SelectionEnd = e;
		}

		private bool IsWordDelimittingCharacter(char c)
		{
			return !char.IsLetterOrDigit( c ) && c != '&';
		}

		private bool IsAmbiguousBoundaryCharacter(char c)
		{
			// These can appear in words, according to web standards these are considered ambiguous
			return c == '\'' || c == '’' || c == '״';
		}

		public void FindWordBoundary( int position, out int startBoundary, out int endBoundary, bool skipMulti = false )
		{
			position = position.Clamp( 0, Math.Max( Text.Length - 1, 0 ) );
			bool bHasHitRealCharacter = false;
			bool bHitMulti = false;
			int startPosition = position;
			while( startPosition > 0 )
			{
				int curIndex = startPosition;
				char previousCharacter = Text[ --curIndex ];
				char nextPrevious = curIndex > 0 ? Text[curIndex - 1] : '\0';
				if( IsWordDelimittingCharacter( previousCharacter) )
				{
					if ( curIndex <= 0 ) break;

					if( skipMulti && !bHasHitRealCharacter )
					{
						if( previousCharacter == nextPrevious )
						{
							startPosition--;
							bHitMulti = true;
							continue;
						}
					}

					if ( !IsAmbiguousBoundaryCharacter( previousCharacter ) ) break;

					// Lets traverse back and see if we hit anything
					if ( IsWordDelimittingCharacter( Text[--curIndex] ) ) break;
				}
				bHasHitRealCharacter = true;
				startPosition--;
			}

			if( bHitMulti && startPosition > 0 )
			{
				startPosition--;
			}

			bHasHitRealCharacter = false;
			bHitMulti = false;

			int endPosition = position;
			while( endPosition < Text.Length )
			{
				char currentCharacter = Text[ endPosition ];
				if( IsWordDelimittingCharacter( currentCharacter ) )
				{
					int nextCharacterIndex = endPosition + 1;
					if ( nextCharacterIndex >= Text.Length ) break;
					
					char nextCharacter = Text[ nextCharacterIndex ];

					if ( skipMulti && !bHasHitRealCharacter )
					{
						if ( currentCharacter == nextCharacter )
						{
							endPosition++;
							bHitMulti = true;
							continue;
						}
					}

					if ( !IsAmbiguousBoundaryCharacter( currentCharacter ) ) break;
					if( IsWordDelimittingCharacter( nextCharacter ) ) break;
				}
				endPosition++;
				bHasHitRealCharacter = true;
			}

			if ( bHitMulti && endPosition < Text.Length - 1 )
			{
				endPosition++;
			}

			startBoundary = startPosition;
			endBoundary = endPosition;
		}

		public void SetCaretPosition( int p, bool selecting = false )
		{
			if ( SelectionEnd == 0 && SelectionStart == 0 && selecting )
			{
				SelectionStart = CaretPosition.Clamp( 0, TextLength );
			}

			CaretPosition = p.Clamp( 0, TextLength );

			if ( selecting )
			{
				SelectionEnd = CaretPosition;
			}
			else
			{
				SelectionEnd = 0;
				SelectionStart = 0;
			}
		}

		public void MoveCaratPos( int delta, bool selecting = false )
		{
			SetCaretPosition( CaretPosition + delta, selecting );
		}

		public void InsertText( string str, int pos, int? endpos = null )
		{
			CaretSantity();

			pos = Math.Clamp( pos, 0, TextLength );
			if ( endpos.HasValue ) endpos = Math.Clamp( endpos.Value, 0, TextLength );

			var a = pos > 0 ? StringInfo.SubstringByTextElements( 0, pos ) : "";
			var b = "";

			if ( endpos.HasValue )
			{
				if ( endpos < TextLength ) b = StringInfo.SubstringByTextElements( endpos.Value );
			}
			else
			{
				if ( pos < TextLength ) b = StringInfo.SubstringByTextElements( pos );
			}

			Text = $"{a}{str}{b}";
		}

		public virtual void RemoveText( int start, int count )
		{
			var a = start > 0 ? StringInfo.SubstringByTextElements( 0, start ) : "";
			var b = (start + count < TextLength) ? StringInfo.SubstringByTextElements( start + count ) : "";

			Text = a + b;
		}


		public bool IsNewline( string str )
		{
			if ( str == "\n" ) return true;
			if ( str == "\r\n" ) return true;
			if ( str == "\r" ) return true;

			return false;
		}

		public void MoveToLineStart( bool andSelect = false )
		{
			if ( !Multiline )
			{
				SetCaretPosition( 0, andSelect );
				return;
			}

			int iNewline = 0;
			var e = StringInfo.GetTextElementEnumerator( Text );
			while ( e.MoveNext() )
			{
				if ( e.ElementIndex >= CaretPosition )
					break;

				if ( IsNewline( e.GetTextElement() ) )
					iNewline = e.ElementIndex + 1;
			}

			SetCaretPosition( iNewline, andSelect );
		}

		public void MoveToLineEnd( bool andSelect = false )
		{
			if ( !Multiline )
			{
				SetCaretPosition( TextLength, andSelect );
				return;
			}

			var e = StringInfo.GetTextElementEnumerator( Text );
			while ( e.MoveNext() )
			{
				if ( e.ElementIndex < CaretPosition )
					continue;

				if ( IsNewline( e.GetTextElement() ) )
				{
					SetCaretPosition( e.ElementIndex, andSelect );
					return;
				}
			}


			SetCaretPosition( TextLength, andSelect );
		}

		public void MoveCaretLine( int offset_line, bool andSelect )
		{
			if ( !Multiline )
			{
				if ( offset_line < 0 ) SetCaretPosition( 0, andSelect );
				if ( offset_line > 0 ) SetCaretPosition( TextLength, andSelect );
				return;
			}

			var caret = GetCaretRect( CaretPosition );

			var height = caret.Size;
			height.x = 0;

			var click = caret.Position + caret.Size * 0.5f + height * offset_line * 1.2f;
			click -= Box.Rect.Position;
			click += Box.RectInner.Position;

			var pos = GetLetterAtScreenPosition( click );
			SetCaretPosition( pos, andSelect );
		}

		public void SelectWord( int wordPos )
		{
			if ( TextLength == 0 )
				return;

			if ( TextLength <= wordPos )
			{
				wordPos = TextLength - 1;
			}

			SelectionStart = wordPos;
			SelectionEnd = wordPos;

			while ( SelectionStart > 0 )
			{
				if ( char.IsWhiteSpace( Text[SelectionStart - 1] ) )
					break;

				SelectionStart--;
			}

			while ( SelectionEnd < TextLength )
			{
				if ( char.IsWhiteSpace( Text[SelectionEnd] ) )
					break;

				SelectionEnd++;
			}

			CaretPosition = SelectionEnd;
		}

		int? ImeInputPos;
		string ImeInputStart;

		protected override void OnEvent( PanelEvent e )
		{
			// Ime input started
			if ( e.Name == "onimestart" )
			{
				ImeInputStart = Text;
				ImeInputPos = CaretPosition;
			}

			// Ime input ended
			if ( e.Name == "onimeend" )
			{
				ImeInputStart = default;
				ImeInputPos = default;
			}

			// ime input changed
			if ( e.Name == "onime" )
			{
				if ( ImeInputPos == null ) return;

				var str = (string)e.Value;
				var info = new StringInfo( str );

				Text = ImeInputStart;
				InsertText( str, ImeInputPos.Value );
				CaretPosition = ImeInputPos.Value + info.LengthInTextElements;
			}

			base.OnEvent( e );
		}
	}
}
