using Sandbox.UI.Construct;
using System;
using System.Linq;

namespace Sandbox.UI.Tests
{
	[UseTemplate]
	public class Zoo : Panel
	{
		public string TextValue { get; set; }
		public bool CheckedValue { get; set; } = true;
		public float FloatValue { get; set; } = 24.0f;
		public Color ColorValue { get; set; } = Color.Red;

		public Zoo()
		{
			ColorValue = Color.Red;
		}

	}
}
