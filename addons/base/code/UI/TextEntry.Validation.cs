using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
#nullable enable

namespace Sandbox.UI
{
	public partial class TextEntry
	{
		[Category( "Validation" )]
		public int? MinLength { get; set; }

		[Category( "Validation" )]
		public int? MaxLength { get; set; }		
		
		/// <summary>
		/// If set, will block the input of any character that doesn't match
		/// </summary>
		[Category( "Validation" )]
		public string? CharacterRegex { get; set; }

		/// <summary>
		/// If set, HasValidationErrors will return true if doesn't match regex
		/// </summary>
		[Category( "Validation" )]
		public string? StringRegex { get; set; }

		[Category( "Validation" )]
		public bool Numeric { get; set; } = false;

		bool IInputControl.HasValidationErrors => HasValidationErrors;

		/// <summary>
		/// If true then this control has validation errors and the input shouldn't be accepted
		/// </summary>
		public bool HasValidationErrors { get; set; }

		/// <summary>
		/// Update the validation state of this control.
		/// </summary>
		public void UpdateValidation()
		{
			HasValidationErrors = false;

			if ( MinLength.HasValue && TextLength < MinLength )
			{
				HasValidationErrors = true;
			}

			if ( MaxLength.HasValue && TextLength > MaxLength )
			{
				HasValidationErrors = true;
			}			
			
			if ( StringRegex != null )
			{
				HasValidationErrors = HasValidationErrors || !System.Text.RegularExpressions.Regex.IsMatch( Text, StringRegex );
			}

			if ( CharacterRegex != null )
			{
				// oof
				foreach ( var chr in Text )
				{
					HasValidationErrors = HasValidationErrors || !System.Text.RegularExpressions.Regex.IsMatch( chr.ToString(), CharacterRegex );
				}
			}

			SetClass( "invalid", HasValidationErrors );
		}

		public virtual bool CanEnterCharacter( char c )
		{
			if ( CharacterRegex != null )
			{
				if ( !System.Text.RegularExpressions.Regex.IsMatch( c.ToString(), CharacterRegex ) )
					return false;
			}

			if ( Numeric && c != '.' && c != '-' && c != ',' )
			{
				if ( char.IsDigit( c ) ) return true;
				if ( c == '-' ) return true;
				if ( c == ',' ) return true;
				if ( c == '.' ) return true;

				return false;
			}

			return true;
		}
	}
}
