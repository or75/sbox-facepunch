
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sandbox.DataModel;

[UseTemplate, NavigatorTarget( "/game/{game_ident}" )]
public class GameScreen : BaseGamePanel
{
	public Panel BackgroundImage { get; set; }
	public Button MatchmakingMode { get; set; }
	public Panel Org { get; set; }
	public Panel TagCanvas { get; set; }
	public Panel InformationCanvas { get; set; }
	public Button FavouritesButton { get; set; }
	public Button ThumbsUpButton { get; set; }
	public Button ThumbsDownButton { get; set; }
	public Panel GameLogo { get; set; }
	public Panel RankingsPanel { get; set; }

	Panel RightSidebar;

	public NavigatorPanel Navigator { get; set; }

	public GameScreen()
	{

	}

	protected override Task OnFullGameInformation()
	{
		rankTypeHash = -1;

		UpdateGamePanels();
		return Task.CompletedTask;
	}

	public void UpdateGamePanels()
	{
		Org.DeleteChildren( true );
		InformationCanvas.DeleteChildren( true );
		TagCanvas.DeleteChildren( true );

		GameLogo.Style.SetBackgroundImage( Package.Thumb );

		Org.Add.Image( Package.Org.Thumb, "org-thumb" );
		Org.Add.Label( Package.Org.Title, "org-title" );

		foreach ( var tag in Package.Tags )
		{
			if ( tag == "mousekeyboard" )
			{
				InformationCanvas.Add.ButtonWithIcon( "Mouse & Keyboard Supported", "mouse", null );
				continue;
			}

			TagCanvas.Add.Label( tag, "package-tag" );
		}

		InitSidebar();
		InitRankings();

		if ( Navigator.CurrentUrl == null )
		{
			Navigator.Navigate( $"/game/{GameIdent}/home" );
		}

		SetClass( "has-maps", Package.GameConfiguration.MapSelection != MapSelect.Hidden );
		SetClass( "has-leaderboard", Package.GameConfiguration.LeaderboardType != GameConfiguration.LeaderboardTypes.None && !Package.GameConfiguration.PerMapRanking );
	}

	public void InitSidebar()
	{
		if ( Package.GameConfiguration.NetworkType == GameNetworkType.Custom )
		{
			AddRightSidebar( new NetCustomGame( this ) );
			return;
		}

		if ( Package.GameConfiguration.NetworkType == GameNetworkType.Multiplayer )
		{
			AddRightSidebar( new MatchmakingGame( this ) );
			return;
		}

		// TODO - singleplayer mode
		AddRightSidebar( new MatchmakingGame( this ) );
	}

	int rankTypeHash = 0;
	
	public void InitRankings()
	{
		var hash = HashCode.Combine( Package.GameConfiguration.RankType );
		if ( rankTypeHash == hash ) return;
		rankTypeHash = hash;

		RankingsPanel?.DeleteChildren( true );

		if ( Package.GameConfiguration.RankType == GameConfiguration.RankTypes.None )
			return;

		if ( Package.GameConfiguration.PerMapRanking )
			return;

		var rankPanel = RankingsPanel.AddChild<PlayerRankPanel>();

		rankPanel.PlayerId = Local.PlayerId;
		rankPanel.GameIdent = Package.FullIdent;

		_ = rankPanel.UpdateAsync();
	}



	void AddRightSidebar( Panel panel )
	{
		RightSidebar?.Delete( true );

		RightSidebar = panel;
		Navigator.AddChild( RightSidebar );
		RightSidebar.AddClass( "sidebar is-right" );
	}

	protected override void PostTemplateApplied()
	{
		base.PostTemplateApplied();

		FavouritesButton.BindClass( "active", () => Package?.IsFavourite ?? false );
		FavouritesButton.AddEventListener( "onclick", async () =>
		{
			FavouritesButton.SetClass( "disabled", true );
			Package.Favourited = (Package.Favourited + (Package.IsFavourite ? -1 : 1)).Clamp( 0, int.MaxValue );
			await Sandbox.MenuEngine.Account.SetFavourite( Package, !Package.IsFavourite );
			Event.Run( "menu.home.rebuild" );
			FavouritesButton.SetClass( "disabled", false );
		} );		

		if ( Package != null )
		{
			_ = OnFullGameInformation();
		}

		ThumbsUpButton.BindClass( "active", () => Cookie.GetString( $"asset.vote.{Package.FullIdent}" ) == "up" );
		ThumbsDownButton.BindClass( "active", () => Cookie.GetString( $"asset.vote.{Package.FullIdent}" ) == "down" );
	}

	public async Task Rate( bool up )
	{
		Cookie.SetString( $"asset.vote.{Package.FullIdent}", up ? "up" : "down" );

		await Sandbox.MenuEngine.Packages.Rate( Package, up );
	}

	protected override void OnEvent( PanelEvent e )
	{
		if ( e.Name == "package.changed" )
		{
			UpdateGamePanels();

			e.StopPropagation();
			return;
		}		
		
		if ( e.Name == "map.select" )
		{
			if ( RightSidebar is MatchmakingGame mmg )
				mmg.SetMap( e.Value as string );

			e.StopPropagation();
			return;
		}

		base.OnEvent( e );
	}
}

