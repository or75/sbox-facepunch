using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading;

namespace Sandbox.UI.Dev
{
	[Library( "property-sheet" )]
	public class PropertySheet : Panel
	{
		object _target;

		public Inspector Inspector { get; protected set; }

		public object Target
		{
			get => _target;

			set
			{
				if ( _target == value ) return;
				_target = value;
				Rebuild();
			}
		}

		public PropertySheet()
		{
			AddClass( "propertysheet" );
		}

		public void Rebuild()
		{
			//DeleteChildren( true );

			Inspector ??= AddChild<Inspector>( "inspector" );
			Inspector.Target = Target;
			Inspector.Rebuild();
		}
	}
}
