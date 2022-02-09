
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Threading.Tasks;

public class AssetCard : Panel
{
	public Package Package { get; }

	public AssetCard( Panel parent, Package package )
	{
		Parent = parent;
		Package = package;
		AddClass( "click-sound" );

		StyleSheet.Load( "/MenuUI/Components/AssetCard.scss" );
		
		var icon = Add.Panel( "icon" );
		icon.Style.Set( "background-image", $"url( {Package.Thumb} )" );

		Add.Label( Package.Title, "title" );
		Add.Label( Package.Org.Title, "org" );

		if ( Package.UsersNow > 0 )
			Add.Label( Package.UsersNow.ToString( "n0" ), "users-now" );
	}

	public AssetCard( Panel parent, string title, string org, string image )
	{
		Parent = parent;

		StyleSheet.Load( "/MenuUI/Components/AssetCard.scss" );

		var icon = Add.Panel( "icon" );
		icon.Style.Set( "background-image", $"url( {image} )" );

		Add.Label( title, "title" );
		Add.Label( org, "org" );
	}

}


