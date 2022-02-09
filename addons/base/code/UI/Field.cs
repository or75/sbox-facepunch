using Sandbox.Html;
using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.UI
{
	/// <summary>
	/// A field in a form, usually contains a label and a control
	/// </summary>
	[Library( "field" )]
	public class Field : Panel
	{
		public Field()
		{
			AddClass( "field" );
		}
	}

	/// <summary>
	/// A field in a form, usually contains a label and a control
	/// </summary>
	[Library( "control" )]
	public class FieldControl : Panel
	{
		public FieldControl()
		{
			AddClass( "field-control control" );
		}
	}
}
