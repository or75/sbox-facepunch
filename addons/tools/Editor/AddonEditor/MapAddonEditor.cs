using Sandbox;
using System.IO;
using System.Linq;
using Tools;

public class MapAddonEditor : BaseAddonEditor
{
	public MapAddonEditor( AddonManager manager, LocalAddon addon ) : base( manager, addon )
	{

	}

	public override void BuildToolbar( ToolBar toolbar )
	{
		base.BuildToolbar( toolbar );

		toolbar.AddOption( "Open In Hammer", "construction", OpenInHammer );
		toolbar.AddOption( "Play Map", "smart_display", OpenInGame );
	}

	void OpenInHammer()
	{
		var mapFile = Path.Combine( Addon.Config.Directory.FullName, "maps", $"{Addon.Config.Ident}.vmap" );

		var asset = AssetSystem.FindByPath( mapFile );
		if ( asset != null )
		{
			asset.OpenInEditor();
		}
		else
		{
			Log.Warning( $"Couldn't find {mapFile}" );
		}
	}

	void OpenInGame()
	{
		Utility.RunCommand( $"map {Addon.Config.Ident}" );
	}
}
