using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Sandbox.UI.Dev
{
	public class StackTrace : Panel
	{
		[EditorProvider( "StackTrace", PreferNoLabel = true )]
		public static Panel StackTraceProvider( EditorProvider.Config config )
		{
			return new StackTrace( config.Value as string );
		}

		public StackTrace( string stack )
		{
			AllowChildSelection = true;
			AcceptsFocus = true;

			Set( stack );
		}


		internal void Set( string stack )
		{
			SetClass( "open", true );

			DeleteChildren( true );

			stack ??= "";

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

					var pnl = Add.Panel( "stack-entry" );
					pnl.SetClass( "is-engine", line.Contains( "\\engine\\Sandbox." ) );
					pnl.Add.Label( functionName, "function" );
					pnl.Add.Label( $"{fileName}:{fileLine}", "file" );

					pnl.AddEventListener( "onclick", () => MenuEngine.Tools.OpenSourceFile( fileName, fileLine.ToInt() ) );
				}
				else
				{
					if ( functionName.StartsWith( "System.Threading" ) )
						return;

					if ( functionName.StartsWith( "System.Runtime" ) )
						return;

					if ( functionName.StartsWith( "Microsoft.Win32" ) )
						return;

					var pnl = Add.Panel( "stack-entry" );
					pnl.SetClass( "is-engine", true );
					pnl.Add.Label( functionName, "message" );
				}
			}
			else
			{
				var pnl = Add.Panel( "stack-entry" );
				pnl.SetClass( "is-engine", line.Contains( "\\engine\\Sandbox." ) );
				pnl.Add.Label( line, "message" );
			}
		}
	}
}
