using Sandbox;
using System;
using Tools;

public class BaseAddonEditor : PropertySheet
{
	public LocalAddon Addon { get; private set; }
	AddonManager Manager;
//	BoxLayout layout;

	public BaseAddonEditor( AddonManager manager, LocalAddon addon ) : base( manager )
	{
		Manager = manager;
		Addon = addon;

	//	layout = MakeTopToBottom();

		RebuildAddonProperties();
	}

	[Event( "localaddons.changed" )]
	public void RebuildAddonProperties()
	{
		using var suspend = new SuspendUpdates( this );

		foreach ( var child in Children )
			child.Destroy();

		IncludeHeader = false;
		GroupByClass = false;

		var toolbar = new ToolBar( this );
		AddRow( toolbar );
		BuildToolbar( toolbar );

		AddonForm();
	}

	Option SaveOption;

	protected override void Signal( WidgetSignal signal )
	{
		if ( signal.Type == "valuechanged" )
		{
			
			OnAddonEdited();
		}

		base.Signal( signal );
	}

	public virtual void OnAddonEdited()
	{
		SaveOption.Enabled = true;
	}

	public virtual void BuildToolbar( ToolBar toolbar )
	{
		if ( Addon.Active )	toolbar.AddOption( new Option( "Active and Enabled", "check_circle", ToggleEnabled ) );
		else				toolbar.AddOption( new Option( "Disabled", "unpublished", ToggleEnabled ) );

		SaveOption = toolbar.AddOption( $"Save Changes", "save", () => { SaveChanges(); } );
		SaveOption.Enabled = false;

		toolbar.AddOption( $"Open {Addon.Config.Directory.FullName}", "folder", () => { Utility.OpenFolder( Addon.Config.Directory.FullName ); } );
	}

	public virtual void AddonForm()
	{
		AddSectionHeader( "Generic Addon Setup" );
		AddProperty( Addon.Config, nameof( Addon.Config.Title ) );
		AddProperty( Addon.Config, nameof( Addon.Config.Ident ) );
		AddProperty( Addon.Config, nameof( Addon.Config.Org ) );
	}

	void SaveChanges()
	{
		Utility.Addons.Updated( Addon, true );
	}

	void ToggleEnabled()
	{
		Addon.Active = !Addon.Active;
		Utility.Addons.Updated( Addon, true );
	}


	internal static BaseAddonEditor CreateFor( AddonManager addonManager, LocalAddon addon )
	{
		switch (addon.Config.Type)
		{
			case "game":
				return new GameAddonEditor( addonManager, addon );

			case "map":
				return new MapAddonEditor( addonManager, addon );
		}

		return null;
	}
}
