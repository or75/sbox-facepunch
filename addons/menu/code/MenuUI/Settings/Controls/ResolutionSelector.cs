
using Sandbox;
using Sandbox.Html;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

public class ResolutionSelector : DropDown
{
	public ResolutionSelector()
	{
		UpdateOptions();
	}

	public void UpdateOptions()
	{
		var smallestAspect = 16.0f / 9.0f;

		var displayModes = Sandbox.Internal.RenderSettings.DisplayModes( false )
										.Where( x => x.Width >= 1280 ) // Fuck small screen sizes
										.Where( x => ((float)x.Width / (float)x.Height) >= smallestAspect ); // fuck small aspect ratios

		foreach ( var res in displayModes.GroupBy( x => $"{x.Width}x{x.Height}" ) )
		{
			Options.Add( new Option
			{
				Title = res.Key,
				Value = res.Key
			} );
		}
	}
}
