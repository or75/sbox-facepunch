using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading;

namespace Sandbox.UI.Dev
{
	public class ConvarDataSource : DataSource.BaseDataSource
	{
		public string ConvarName;

		public ConvarDataSource( string property, string convarname ) : base( property )
		{
			ConvarName = convarname;
		}

		public override object Value 
		{ 
			get => ConsoleSystem.GetValue( ConvarName ); 
			set => ConsoleSystem.Run( ConvarName, value.ToString() );
		}
	}

	[Library( "DeveloperToolbar" )]
	public class DeveloperToolbar : Panel
	{
		public DeveloperToolbar()
		{
			var dropdown = new DropDown( this );
			dropdown.Options.Add( new Option( "Regular", "photo", "0" ) );
			dropdown.Options.Add( new Option( "Full Bright", "lightbulb", "1" ) );
			dropdown.Options.Add( new Option( "Normal Map", "shuffle", "21" ) );
			dropdown.Options.Add( new Option( "Albedo", "palette", "10" ) );
			dropdown.Options.Add( new Option( "Diffuse", "cloud", "2" ) );
			dropdown.Options.Add( new Option( "Reflect", "flare", "3" ) );
			dropdown.Options.Add( new Option( "Ambient", "hdr_weak", "44" ) );
			dropdown.StringValue = "0";

			dropdown.Bind( new ConvarDataSource( "value", "mat_fullbright" ) );

			var physView = Add.ButtonGroup();
			{
				var normal = physView.AddButton( "off", () => ConsoleSystem.Run( "phys_debug_draw off" ) );
				physView.AddButton( "svphys", () => ConsoleSystem.Run( "phys_debug_draw wireframe server" ) );
				physView.AddButton( "clphys", () => ConsoleSystem.Run( "phys_debug_draw wireframe client" ) );

				physView.SelectedButton = normal;
			}

			new ConvarToggleButton( this, "Console Overlay", "consoleoverlay", "true", "false", "article" );
			new ConvarToggleButton( this, "Perf Stats", "widget_perf", "1", "0", "timer" );
			new ConvarToggleButton( this, "Perf Chart", "widget_perfchart", "1", "0", "equalizer" );
			new ConvarToggleButton( this, "Entity IO", "debug_mapio", "2", "0", "share" );

			{
				var fakelag = new DropDown( this );
				fakelag.Options.Add( new Option( "No Fakelag", "emoji_emotions", "0" ) );
				fakelag.Options.Add( new Option( "10ms", "sentiment_neutral", "10" ) );
				fakelag.Options.Add( new Option( "100ms", "sentiment_dissatisfied", "100" ) );
				fakelag.Options.Add( new Option( "200ms", "mood_bad", "200" ) );
				fakelag.StringValue = "0";

				fakelag.Bind( new ConvarDataSource( "value", "net_fakelag" ) );
			}

			new ConvarToggleButton( this, "Prediction Errors", "cl_showerror", "2", "0", "feedback" );
		}
	}
}
