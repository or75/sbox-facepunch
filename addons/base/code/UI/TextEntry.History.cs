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
		internal List<string> History { get; set; } = new List<string>();

		public int HistoryMaxItems { get; set; } = 30;

		string _historyCookie;
		public string HistoryCookie
		{
			get => _historyCookie;
			set
			{
				if ( _historyCookie == value ) return;

				_historyCookie = value;

				if ( string.IsNullOrEmpty( _historyCookie ) )
					return;
				
				History = Cookie.Get( value, History );
				return;
			}
		}


		public void AddToHistory( string str )
		{
			History.RemoveAll( x => x == str );
			History.Add( str );

			if ( HistoryMaxItems > 0 )
			{
				while ( History.Count > HistoryMaxItems )
				{
					History.RemoveAt( 0 );
				}
			}

			if ( !string.IsNullOrEmpty( HistoryCookie ) )
			{
				Cookie.Set( HistoryCookie, History );
			}
		}

		public void ClearHistory()
		{
			History.Clear();

			if ( !string.IsNullOrEmpty( HistoryCookie ) )
			{
				Cookie.Set( HistoryCookie, History );
			}
		}
	}
}
