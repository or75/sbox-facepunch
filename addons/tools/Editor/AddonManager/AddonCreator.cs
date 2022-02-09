using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools;
using System.ComponentModel.DataAnnotations;
using Sandbox.DataModel;

public class AddonCreator : Window
{
	Button OkayButton;

	LineEdit TitleEdit;
	LineEdit IdentEdit;
	ComboBox AddonType;
	FolderProperty FolderEdit;

	ErrorBox FolderError;

	bool identEdited;

	public AddonCreator( Widget parent ) : base( null )
	{
		Size = new Vector2( 500, 400 );
		MaximumSize = Size;
		// IsModal = true;
		IsDialog = true;
		CloseButtonVisible = false;

		Title = "Create New Addon";

		StatusBar = null;
		Canvas = new Widget( this );
		DeleteOnClose = true;
		SetIcon( "create_new_folder" );

		var topDown = Canvas.MakeTopToBottom();
		topDown.Spacing = 4;
		topDown.SetContentMargins( 8, 8, 8, 8 );

		// body
		{
			//
			// This form stuff with validation stuff is all very messy.
			// I'm gonna use this as an example in the future to make this all more consistent and friendlier
			//

			topDown.AddStretchCell( 1 );

			topDown.Add( new FieldTitle( "Title" ) );
			topDown.Add( new FieldSubtitle( "The human readable title of your addon" ) );
			TitleEdit = topDown.Add( new LineEdit( "" ) {  PlaceholderText = "Garry's Addon" } );
			TitleEdit.TextEdited += ( x ) => UpdateOkay();

			topDown.AddSpacingCell( 8 );			
			
			topDown.Add( new FieldTitle( "Type" ) );
			topDown.Add( new FieldSubtitle( "Don't worry about this right now. We'll have more options in the future." ) );
			AddonType = topDown.Add( new ComboBox() );
			AddonType.Editable = true;
			AddonType.AddItem( "Game", "sports_esports" );
			AddonType.AddItem( "Map", "public" );

			topDown.AddSpacingCell( 8 );

			topDown.Add( new FieldTitle( "Ident" ) );
			topDown.Add( new FieldSubtitle( "Lowercase version of addon name, no special characters - max 16 characters" ) );
			IdentEdit = topDown.Add( new LineEdit( "" ) { PlaceholderText = "garrysaddon" } );
			IdentEdit.TextEdited += (x) => UpdateOkay();
			IdentEdit.TextEdited += ( x ) => identEdited = true;
			IdentEdit.SetValidator( "[a-z0-9_]{2,16}" );

			topDown.AddSpacingCell( 8 );

			topDown.Add( new FieldTitle( "Location" ) );
			topDown.Add( new FieldSubtitle( "An empty folder in which to create your new addon" ) );
			FolderEdit = topDown.Add( new FolderProperty( null ) );
			FolderEdit.TextEdited += ( x ) => UpdateOkay();
			FolderEdit.FolderSelected += ( x ) => UpdateOkay();

			FolderError = topDown.Add( new ErrorBox() );
			FolderError.Visible = false;

			topDown.AddStretchCell( 1 );
		}


		// Footer buttons
		{
			var footer = topDown.Add( new Widget( this ) );
			var footerLayout = footer.MakeLeftToRight();
			footerLayout.Spacing = 4;
			footerLayout.SetContentMargins( 8, 32, 8, 8 );
			footerLayout.AddStretchCell( -1 );
			OkayButton = footerLayout.Add( new Button( "OK" ) { Clicked = CreateAddon } );
			footerLayout.Add( new Button( "Cancel" ) { Clicked = Close } );
		}

		UpdateOkay();
	}

	void UpdateOkay()
	{
		if ( !identEdited )
		{
			IdentEdit.Text = System.Text.RegularExpressions.Regex.Replace( TitleEdit.Text.ToLower(), "[^A-Za-z0-9_]", "_" ).Trim( '_' );
		}

		bool enabled = true;
		if ( string.IsNullOrWhiteSpace( FolderEdit.Text ) ) enabled = false;
		if ( string.IsNullOrWhiteSpace( TitleEdit.Text ) ) enabled = false;
		if ( string.IsNullOrWhiteSpace( IdentEdit.Text ) ) enabled = false;

		FolderError.Visible = false;
		if ( !string.IsNullOrWhiteSpace( FolderEdit.Text ) )
		{
			if ( !System.IO.Path.IsPathRooted( FolderEdit.Text ) )
			{
				FolderError.Text = "Please provide an absolute path to the folder (including C:/ etc)";
				FolderError.Visible = true;
			}
			else if ( !System.IO.Directory.Exists( FolderEdit.Text ) )
			{
				FolderError.Text = "This folder doesn't exist.. what are you trying to do?";
				FolderError.Visible = true;
			}
			else
			{
				var dirInfo = new System.IO.DirectoryInfo( FolderEdit.Text );
				if ( dirInfo.GetFiles().Length > 0 )
				{
					FolderError.Text = "This folder isn't empty. Choose an empty folder for your addon.";
					FolderError.Visible = true;
				}
			}
		}

		OkayButton.Enabled = enabled;
	}

	void CreateAddon()
	{
		var addonPath = FolderEdit.Text;

		var config = new AddonConfig();
		config.CodePath = "/code/";
		config.AssetsPath = "";
		config.HasCode = true;
		config.HasAssets = true;
		config.Ident = IdentEdit.Text;
		config.Title = TitleEdit.Text;
		config.Org = "local";
		config.Type = AddonType.CurrentText.ToLower();
		config.RootNamespace = "Sandbox";
		config.Schema = 1;
		config.SharedAssets = "*.*";

		var configPath = System.IO.Path.Combine( addonPath, ".addon" );
		var txt = config.ToJson();

		System.IO.File.WriteAllText( configPath, txt );

		var pt = new ProjectTemplate( config, "minimal", addonPath );
		pt.Apply();

		var addon = Utility.Addons.TryAddFromFile( configPath );
		AddonManager.Singleton?.SwitchToAddon( addon );

		Close();
	}

	[Menu( "Editor", "Addons//Create New..", "folder", Shortcut = "Ctrl+N" )]
	public static void AddNewAddon()
	{
		var creatorWindow = new AddonCreator( null );
		creatorWindow.Show();
	}
}

// Don't use these form things

internal class ErrorBox : Label
{

}

internal class FieldTitle : Label
{
	public FieldTitle( string title ) : base( title )
	{
	}
}

internal class FieldSubtitle : Label
{
	public FieldSubtitle( string title ) : base( title )
	{
		WordWrap = true;
	}
}
