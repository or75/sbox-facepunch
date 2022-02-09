using Sandbox;
using Tools;

public class GameAddonEditor : BaseAddonEditor
{
	public GameAddonEditor( AddonManager manager, LocalAddon addon ) : base( manager, addon )
	{

	}

	public override void AddonForm()
	{
		base.AddonForm();

		AddSectionHeader( "Game Code" );
		AddProperty( Addon.Config, nameof( Addon.Config.HasCode ) );
		AddProperty( Addon.Config, nameof( Addon.Config.CodePath ) );
		AddProperty( Addon.Config, nameof( Addon.Config.RootNamespace ) );

		AddSectionHeader( "Game Assets" );
		AddProperty( Addon.Config, nameof( Addon.Config.HasAssets ) );
		AddProperty( Addon.Config, nameof( Addon.Config.AssetsPath ) );
		AddProperty( Addon.Config, nameof( Addon.Config.SharedAssets ) );

		UpdateRowRules();
	}

	public override void OnAddonEdited()
	{
		base.OnAddonEdited();

		UpdateRowRules();
	}

	void UpdateRowRules()
	{
		EnableRow( nameof( Addon.Config.CodePath ), Addon.Config.HasCode );
		EnableRow( nameof( Addon.Config.RootNamespace ), Addon.Config.HasCode );		
		
		EnableRow( nameof( Addon.Config.AssetsPath ), Addon.Config.HasAssets );
		EnableRow( nameof( Addon.Config.SharedAssets ), Addon.Config.HasAssets );

		Update();
	}
}
