using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Sandbox.UI
{
	public partial class TextEntry
	{
		/// <summary>
		/// If you hook a method up here we'll do autocomplete on it
		/// </summary>
		public Func<string, object[]> AutoComplete { get; set; }

		internal Popup AutoCompletePanel;


		public void UpdateAutoComplete()
		{
			if ( AutoComplete == null )
			{
				DestroyAutoComplete();
				return;
			}

			var results = AutoComplete( Text );
			if ( results == null || results.Length == 0 )
			{
				DestroyAutoComplete();
				return;
			}

			UpdateAutoComplete( results );
		}

		public void UpdateAutoComplete( object[] options )
		{
			if ( AutoCompletePanel == null || AutoCompletePanel.IsDeleting )
			{
				AutoCompletePanel = new Popup( this, Popup.PositionMode.AboveLeft, 8 );
				AutoCompletePanel.AddClass( "autocomplete" );
				AutoCompletePanel.SkipTransitions();
			}

			AutoCompletePanel.DeleteChildren( true );
			AutoCompletePanel.UserData = Text;

			foreach ( var r in options )
			{
				var b = AutoCompletePanel.AddOption( r.ToString(), () => AutoCompleteSelected( r ) );
				b.UserData = r;
			}
		}

		public virtual void DestroyAutoComplete()
		{
			AutoCompletePanel?.Delete();
			AutoCompletePanel = null;
		}

		void AutoCompleteSelected( object obj )
		{
			Text = obj.ToString();
			Focus();
			OnValueChanged();

			Label.MoveToLineEnd();
		}

		protected virtual void AutoCompleteSelectionChanged()
		{
			var selected = AutoCompletePanel.SelectedChild;
			if ( selected == null ) return;

			Text = selected.UserData.ToString();
			Label.MoveToLineEnd();
		}

		protected virtual void AutoCompleteCancel()
		{
			Text = AutoCompletePanel.UserData.ToString();
			DestroyAutoComplete();
		}
	}
}
