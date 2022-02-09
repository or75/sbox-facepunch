
using Sandbox;
using Sandbox.UI;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sandbox.UI.Tests;
using Sandbox.UI.Construct;
using System.Threading;

[UseTemplate, NavigatorTarget( "/game/{game_ident}/leaderboard" ) ]
public class Leaderboards : BaseGamePanel
{
	public string Bucket { get; set; }
	public Panel Canvas { get; set; }

	public Leaderboards()
	{

	}
	int ActiveHash;

	public override void Tick()
	{
		base.Tick();

		var hash = HashCode.Combine( GameIdent, Bucket );
		if ( hash == ActiveHash ) return;
		ActiveHash = hash;

		_ = Rebuild();
	}

	public async Task Rebuild()
	{
		Canvas?.DeleteChildren( true );

		var hash = ActiveHash;

		var result = await GameServices.Leaderboard.Query( GameIdent, playerid: Local.PlayerId, bucket: Bucket );

		if ( hash != ActiveHash ) return;

		int place = result.Skip + 1;
		foreach( var entry in result.Entries )
		{
			var row = Canvas.Add.Panel( "row leaderboard-row" );

			row.SetClass( "is-me", Local.PlayerId == entry.PlayerId );
			row.SetClass( "is-friend", new Friend( entry.PlayerId ).IsFriend );

			row.Add.Label( $"{(place++).FormatWithSuffix()}" );

			var avatar = row.Add.Panel( "avatar" );
			avatar.Style.SetBackgroundImage( $"avatar:{entry.PlayerId}" );

			row.Add.Label( $"{entry.DisplayName}", "grow" );
			row.Add.Label( $"{entry.Rating:n0}", "is-quater" );
		}

	}
}


