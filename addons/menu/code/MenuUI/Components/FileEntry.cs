using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Sandbox.UI
{

	[Library]
	public partial class FileEntry : Panel, IInputControl
	{
		bool IInputControl.HasValidationErrors => false;

		public TextEntry TextEntry { get; protected set; }
		public Button Button { get; protected set; }

		public FileEntry()
		{
			AddClass( "fileentry" );

			TextEntry = AddChild<TextEntry>();
			Button = AddChild<Button>();
			Button.Icon = "folder";

			Button.AddEventListener( "onclick", OpenFileBrowser );
		}

		public void OpenFileBrowser()
		{
			var file = MenuEngine.FileSystem.OpenFileDialog();
			if ( file  != null )
			{
				TextEntry.Text = file;
			}
		}
	}

}
