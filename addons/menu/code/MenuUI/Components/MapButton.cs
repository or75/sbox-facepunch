
using Sandbox;
using Sandbox.Internal;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading.Tasks;

public class MapButton : Panel
{
	Image MapThumbnail;
	Label Title;
	Label Author;

	[Property]
	public Package GamePackage { get; set; }

	public MapButton()
	{
		StyleSheet.Load( "/MenuUI/Components/MapButton.scss" );

		AddChild( out MapThumbnail, "map_thumbnail" );

		var detail = Add.Panel( "details" );

		detail.AddChild( out Title, "map_title" );
		detail.AddChild( out Author, "map_author" );

		MapThumbnail.SetTexture( "/ui/mainmenu/map_default.jpg" );

		AddClass( "button" );
	}

	protected override void OnClick( MousePanelEvent e )
	{
		if ( GamePackage == null )
			throw new System.Exception( "Can't select map - GamePackage is null!" );

		CreateEvent( "navigate", $"/game/{GamePackage.FullIdent}/maps" );
	}

	public override void SetProperty( string name, string value )
	{
		base.SetProperty( name, value );

		if ( name == "value" )
		{
			SetValue( value );
		}
	}

	public void SetValue( string mapIdent )
	{
		StringValue = mapIdent;
		MapThumbnail.SetTexture( "/ui/mainmenu/map_default.jpg" );
		Title.Text = StringValue;
		_ = FetchMapDetails( StringValue );
	}

	private async Task FetchMapDetails( string mapname )
	{
		var mapInfo = await Package.Fetch( mapname, true );
		if ( mapInfo == null )
			return;

		Title.Text = mapInfo.Title;
		Author.Text = mapInfo.Org.Title;

		if ( !string.IsNullOrWhiteSpace( mapInfo.Thumb ) )
		{
			MapThumbnail.Texture = await Texture.LoadAsync( FileSystem.Mounted, mapInfo.Thumb, false );
		}
	}
}


