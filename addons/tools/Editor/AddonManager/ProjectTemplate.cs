using Sandbox;
using Sandbox.DataModel;
using System.IO;

internal class ProjectTemplate
{
	AddonConfig Config;
	private string TemplateName;
	private string TargetPath;

	public ProjectTemplate( AddonConfig config, string templateName, string addonPath )
	{
		Config = config;
		TemplateName = templateName;
		TargetPath = addonPath;
	}

	public void Apply()
	{
		var sourceFolder = FileSystem.Root.GetFullPath( $"/templates/{Config.Type}.{TemplateName}/" );
		if ( !System.IO.Directory.Exists( sourceFolder ) )
			return;

		CopyFolder( sourceFolder, TargetPath );
	}


	void CopyFolder( string sourceDir, string targetDir )
	{
		System.IO.Directory.CreateDirectory( targetDir );

		foreach ( var file in Directory.GetFiles( sourceDir ) )
		{
			CopyAndProcessFile( targetDir, file );
		}

		foreach ( var directory in Directory.GetDirectories( sourceDir ) )
		{
			CopyFolder( directory, Path.Combine( targetDir, Path.GetFileName( directory ) ) );
		}
	}

	private void CopyAndProcessFile( string targetDir, string file )
	{
		var targetname = Path.Combine( targetDir, Path.GetFileName( file ) );
		
		// replace $ident with our ident in file name
		targetname = targetname.Replace( "$ident", Config.Ident );

		System.IO.File.Copy( file, targetname );
	}
}
