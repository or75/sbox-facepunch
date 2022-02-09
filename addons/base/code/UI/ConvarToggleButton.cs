using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;

namespace Sandbox.UI
{

	[Library( "ConvarToggleButton" )]
	public class ConvarToggleButton : Button
	{
		public string ConVar { get; set; }
		public string ValueOn { get; set; }
		public string ValueOff { get; set; }

		public ConvarToggleButton()
		{
		}

		public ConvarToggleButton( Panel parent, string label, string convar, string onvalue, string offvalue, string icon = null )
		{
			this.Parent = parent;
			this.Icon = icon;
			this.Text = label;

			ConVar = convar;
			ValueOn = onvalue;
			ValueOff = offvalue;
		}

		public override void Tick()
		{
			base.Tick();

			if ( ConVar == null ) return;

			var val = ConsoleSystem.GetValue( ConVar );
			if ( val == null ) return;

			SetClass( "active", String.Equals( val, ValueOn, StringComparison.OrdinalIgnoreCase ) );
		}

		public void Toggle()
		{
			if ( ConVar == null ) return;

			var val = ConsoleSystem.GetValue( ConVar );
			var status = String.Equals( val, ValueOn, StringComparison.OrdinalIgnoreCase );

			ConsoleSystem.Run( ConVar, status ? ValueOff : ValueOn );
		}

		public override void SetProperty( string name, string value )
		{
			base.SetProperty( name, value );

			if ( name == "on" ) ValueOn = value;
			if ( name == "off" ) ValueOff = value;
			if ( name == "convar" ) ConVar = value;
		}

		protected override void OnClick( MousePanelEvent e )
		{
			Toggle();
		}
	}

}
