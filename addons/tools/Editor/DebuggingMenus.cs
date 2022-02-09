using Sandbox;
using System;
using System.Linq;
using Tools;

public static class DebuggingMenus
{
	[Menu( "Editor", "Debug/Show Prediction Errors" )]
	public static bool ShowPredictionErrors
	{
		get => ConsoleSystem.GetValue( "cl_showerror" ) == "2";
		set => ConsoleSystem.SetValue( "cl_showerror", value?"2":"0" );
	}	
	
	
	[Menu( "Editor", "Debug/Show Entity IO" )]
	public static bool EntityIO
	{
		get => ConsoleSystem.GetValue( "debug_mapio" ) == "2";
		set => ConsoleSystem.SetValue( "debug_mapio", value?"2":"0" );
	}
}
