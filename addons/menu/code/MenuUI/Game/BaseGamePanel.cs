
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sandbox.Internal;

public abstract class BaseGamePanel : Panel
{
	public string GameIdent { get; private set; }

	[Property]
	public Package Package { get; private set; }

	public BaseGamePanel( BaseGamePanel other )
	{
		GameIdent = other.Package.FullIdent;
		Package = other.Package;
	}

	public BaseGamePanel()
	{
		BindClass( "has-edit", () => (Package?.CanEdit ?? false) );
	}

	public override void OnParentChanged()
	{
		base.OnParentChanged();

		if ( Parent is BaseGamePanel other )
		{
			GameIdent = other.Package.FullIdent;
			Package = other.Package;
		}
	}

	public override void SetProperty( string name, string value )
	{
		base.SetProperty( name, value );

		if ( name == "game_ident" )
		{
			GameIdent = value.Trim().ToLower();
			_ = GetGame( GameIdent );
		}
	}

	protected override void PostTemplateApplied()
	{
		base.PostTemplateApplied();

		if ( GameIdent != null )
		{
			_ = GetGame( GameIdent );
		}
	}

	async Task GetGame( string gameName )
	{
		// Try to get immediate data first. We might have this knocking about
		// because we can clean information about a game from the game lists
		Package = await Package.Fetch( gameName, true );

		//
		// Now try to get the full data from the api
		//
		var assetInfo = await Package.Fetch( gameName, false );

		if ( assetInfo == null )
		{
			Log.Warning( $"Something went wrong - {gameName} returned null on fetch!?" );
			return;
		}

		if ( assetInfo.PackageType != Package.Type.Gamemode )
		{
			Log.Warning( $"Something went wrong - {gameName} is a {assetInfo.PackageType} !?" );
			return;
		}

		if ( assetInfo.GameConfiguration == null )
		{
			Log.Warning( $"Something went wrong - {gameName} has no game config" );
			return;
		}

		Package = assetInfo;


		await OnFullGameInformation();
	}

	protected virtual Task OnFullGameInformation()
	{
		return Task.CompletedTask;
	}
}


