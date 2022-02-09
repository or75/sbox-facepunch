using Sandbox.Internal;
using Sandbox.UI.Construct;
using Sandbox.UI.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using Sandbox;

namespace Sandbox.UI.Dev
{
	[Library( "console" )]
	public class Console : Panel
	{
		internal List<LogEvent> Entries = new();
		internal VirtualScrollPanel Output;
		internal TextEntry Input;
		internal TextEntry Filter;
		internal Button ScrollConsole;

		struct MessageCategory
		{
			public Button Button;
			public int Count;
			public bool Disabled;

			public void Toggle()
			{
				Disabled = !Disabled;
				Button.SetClass( "disabled", Disabled );
			}

			public void Clear()
			{
				Button.Text = "0";
				Count = 0;
			}
		}

		MessageCategory Message;
		MessageCategory Warning;
		MessageCategory Error;

		public Console()
		{
			StyleSheet.Load( "/devui/devmode/Console.scss" );

			Output = AddChild<VirtualScrollPanel>();
			Output.AddClass( "output" );
			Output.Layout.ItemHeight = 19;
			Output.PreferScrollToBottom = true;
			Output.OnCreateCell = ( cell, data ) =>
			{
				var entry = new ConsoleEntry();
				entry.Parent = cell;
				entry.SetLogEvent( (LogEvent)data );
			};

			Input = Add.TextEntry( "" );
			Input.AddClass( "input" );
			Input.AddEventListener( "onsubmit", OnSubmit );
			Input.AutoComplete = FillAutoComplete;
			Input.HistoryCookie = "console-input-history";

			var toolbar = Add.Panel( "toolbar" );
			{
				Error.Button = toolbar.Add.Button( "0", "type err" );
				Error.Button.AddEventListener( "onclick", () => { Error.Toggle(); OnFilter(); } );

				Warning.Button = toolbar.Add.Button( "0", "type wrn" );
				Warning.Button.AddEventListener( "onclick", () => { Warning.Toggle(); OnFilter(); } );

				Message.Button = toolbar.Add.Button( "0", "type msg" );
				Message.Button.AddEventListener( "onclick", () => { Message.Toggle(); OnFilter(); } );

				toolbar.Add.Panel( "spacer" );

				Filter = toolbar.Add.TextEntry( "" );
				Filter.AddClass( "filter" );
				Filter.AddEventListener( "onchange", OnFilter );
				Filter.Placeholder = "Filter..";

				var clear = toolbar.Add.Button( "clear", "clear", () => OnClear() );
				ScrollConsole = toolbar.Add.Button( "⬇", "scroll", () => Output?.TryScrollToBottom() );
			}

			MenuEngine.Tools.AddLogger( OnConsoleMessage );

			Output.AcceptsFocus = true;
			Output.AllowChildSelection = true;
		}

		private void OnConsoleMessage( LogEvent e )
		{
			if ( e.Message.Contains( '\n' ) || e.Message.Contains( '\r' ) )
			{
				var parts = e.Message.Split( new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries );
				foreach ( var part in parts )
				{
					var ee = e;
					ee.Message = part;

					AddEvent( ee );
				}
			}
			else
			{
				AddEvent( e );
			}
		}

		void AddEvent( LogEvent e )
		{
			Entries.Add( e );

			if ( ShouldShowEvent( e ) )
			{
				Output.AddItem( e );
			}

			if ( e.Level == LogLevel.Info || e.Level == LogLevel.Trace )
			{
				Message.Count++;
				Message.Button.Text = $"{Message.Count:n0}";
			}

			if ( e.Level == LogLevel.Warn )
			{
				Warning.Count++;
				Warning.Button.Text = $"{Warning.Count:n0}";
			}

			if ( e.Level == LogLevel.Error )
			{
				Error.Count++;
				Error.Button.Text = $"{Error.Count:n0}";
			}
		}

		void OnFilter()
		{
			Output.SetItems( Entries.Where( x => ShouldShowEvent( x ) ).Select( x => x as object ) );
		}

		bool ShouldShowEvent( LogEvent e )
		{
			if ( e.Level == LogLevel.Error && Error.Disabled ) return false;
			if ( e.Level == LogLevel.Warn && Warning.Disabled ) return false;
			if ( e.Level == LogLevel.Info && Message.Disabled ) return false;
			if ( e.Level == LogLevel.Trace && Message.Disabled ) return false;

			if ( string.IsNullOrWhiteSpace( Filter.Text ) )
				return true;

			return e.Message.Contains( Filter.Text, StringComparison.OrdinalIgnoreCase );
		}

		public override void Tick()
		{
			base.Tick();
			ScrollConsole?.SetClass( "active", Output?.IsScrollAtBottom ?? false );
		}

		void OnClear()
		{
			Output.Clear();
			Entries.Clear();

			Message.Clear();
			Warning.Clear();
			Error.Clear();
		}

		void OnSubmit()
		{
			var t = Input.Text;
			if ( string.IsNullOrWhiteSpace( t ) )
			{
				Input.Text = "";
				return;
			}

			if ( t == "clear" )
			{
				OnClear();
			}
			else
			{
				var e = new LogEvent() { Message = $"> {t}", Level = LogLevel.Info, Logger = "in", Time = DateTime.Now };
				Entries.Add( e );
				Output.AddItem( e );
				ConsoleSystem.Run( t );
			}

			Output.TryScrollToBottom();

			Input.Text = "";
			Input.AddToHistory( t );
			Input.DestroyAutoComplete();
			Input.Focus();
		}

		private object[] FillAutoComplete( string arg )
		{
			if ( string.IsNullOrWhiteSpace( arg ) )
				return Array.Empty<object>();

			return MenuEngine.Tools.AutoComplete( arg, 20 );
		}

	}
}
