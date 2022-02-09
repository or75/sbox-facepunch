
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sandbox.Internal;

public class MatchmakingGame : BaseGamePanel
{
	MatchmakingFront Intro;
	GameLobby GameLobby;

	public MatchmakingGame( BaseGamePanel gamePanel ) : base ( gamePanel )
	{
		AddEventListener( "onplaygame", ( e ) => _ = CreateLobby() );
		AddEventListener( "onleavelobby", ( e ) => LeaveLobby() );
		AddEventListener( "joingamelobby", ( e ) => _ = JoinGameLobby( e.Value as Lobby ) );

		LeaveLobby();
	}

	public async Task JoinGameLobby( Lobby lobby )
	{
		if ( await lobby.TryJoin() )
		{
			OnLobby( lobby );
		}
	}

	public async Task CreateLobby()
	{
		var lobby = await CreateStagingLobby( Package.FullIdent );
		lobby.SetData( "map", Package.GameConfiguration.MapList.First() );

		if ( lobby  == null )
		{
			LeaveLobby();
			return;
		}

		OnLobby( lobby );
	}

	public void LeaveLobby()
	{
		Intro?.Delete();

		Intro = new MatchmakingFront( this );
		AddChild( Intro );

		GameLobby?.Delete( true );
		GameLobby = null;

		SetClass( "wider", false );
	}

	private void OnLobby( Lobby lobby )
	{
		SetClass( "in-lobby", lobby != null );

		Intro?.Delete( true );
		GameLobby?.Delete( true );
		GameLobby = null;

		if ( lobby == null )
			return;

		lobby.SetLocalMemberData( "status", "staging" );

		GameLobby = new GameLobby( lobby, this );
		AddChild( GameLobby );
		SetClass( "wider", true );

		// Leave other lobbies
		foreach( var active in Lobby.Active.Where( x => x.State == "staging" && x != lobby ).ToArray() )
		{
			active.Leave();
		}
	}

	async Task<Lobby> CreateStagingLobby( string ident )
	{
		return await Lobby.Create( Package.GameConfiguration.MaxPlayers, Package.FullIdent, "staging" );
	}

	public static async Task<Lobby> FindStagingLobby( string ident )
	{
		var result = await Lobby.GetList( ident, "staging" );
		if ( result == null )
			return null;

		foreach ( var lobby in result )
		{
			if ( lobby.MemberCount >= lobby.MaxMembers )
				continue;

			if ( await lobby.TryJoin() )
				return lobby;

			Log.Info( $"Couldn't join lobby {lobby}" );
		}

		Log.Info( $"Couldn't join any of these lobbies" );
		return null;
	}

	internal void SetMap( string value )
	{
		GameLobby?.SetMap( value );
	}
}
