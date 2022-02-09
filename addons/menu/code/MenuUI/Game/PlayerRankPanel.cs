
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sandbox.Internal;
using System.Globalization;
using System.Web;

[UseTemplate]
public class PlayerRankPanel : Panel
{
	public PlayerGameRank Data { get; set; }

	public Panel Leaderboard { get; set; }

	public PlayerRankPanel()
	{

	}

	public long PlayerId { get; internal set; }
	public string GameIdent { get; internal set; }

	internal async Task UpdateAsync()
	{
		AddClass( "loading" );

		Data = await Sandbox.MenuEngine.Account.FetchPlayerRankAsync( PlayerId, GameIdent );

		RemoveClass( "loading" );

		Leaderboard?.DeleteChildren( true );

		AddLeaderboard( Data.Global.Position, "World" );

		AddLeaderboard( Data.Country.Position, Data.Country.Value );

		AddLeaderboard( Data.State.Position, Data.State.Value );
		AddLeaderboard( Data.City.Position, Data.City.Value );
	}

	private void AddLeaderboard( int position, string label )
	{
		if ( string.IsNullOrEmpty( label ) || label == "Unknown" ) return;

		var r = Leaderboard.Add.Panel( "leaderboard-row" );

		if ( position == 1 ) r.AddClass( "is-1" );
		else if ( position == 2 ) r.AddClass( "is-2" );
		else if ( position == 3 ) r.AddClass( "is-3" );
		else if ( position < 10 ) r.AddClass( "is-top10" );
		else if ( position < 100 ) r.AddClass( "is-top100" );

		r.Add.Icon( "medal", "icon" );
		r.Add.Label( position.FormatWithSuffix(), "result" );
		r.Add.Label( label, "label" );

		var bucket = label;

		r.AddEventListener( "onclick", () => CreateEvent( "navigate", $"~/leaderboard?bucket={HttpUtility.UrlEncode(bucket)}" ) );
	}
}

