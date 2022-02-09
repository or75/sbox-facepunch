
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sandbox.Internal;

[NavigatorTarget( "/games/live" )]
public class LiveGameList : Panel
{
	List<GameIcon> GameIcons = new List<GameIcon>();
	Panel DevelopmentGroup;

	public LiveGameList()
	{
		AddClass( "gamelist" );
		Rebuild();
	}

	public void Rebuild(  )
	{
		DeleteChildren( true );
		GameIcons.Clear();

		_ = RefreshFromApi();
	}

	async Task RefreshFromApi()
	{
		var label = Add.Label( "Live Development", "grouptitle" );
		DevelopmentGroup = Add.Panel( "group" );

		await RefreshLobby();
	}

	async Task RefreshLobby()
	{
		var result = await Lobby.GetList();
		if ( result == null )
			return;

		//
		// Clear the dev group icons (this is temporary)
		//
		if ( DevelopmentGroup != null )
		{
			foreach ( var icon in DevelopmentGroup.ChildrenOfType<GameIcon>() )
			{
				GameIcons.Remove( icon );
			}

			DevelopmentGroup.DeleteChildren( true );
		}

		foreach ( var group in result.GroupBy( x => x.GetData( "game" ) ) )
		{
			var players = group.Sum( x => x.MemberCount );

			// Log.Info( $"{group.Key}: {players}" );
			bool found = false;
			foreach ( var game in GameIcons )
			{
				if ( game == null ) continue;
				if ( game.Package.FullIdent != group.Key ) continue;

			//	game.SetPlayerCount( players );
				found = true;
			}

			//
			// not in our list, for now lets show them at the bottom so devs can have
			// people live joining their servers
			//
			if ( !found )
			{
				//var gameIcon = new GameIcon( group.First() );
				//gameIcon.Parent = DevelopmentGroup;
				//gameIcon.SetPlayerCount( players );
				//GameIcons.Add( gameIcon );
			}
		}
	}
}

