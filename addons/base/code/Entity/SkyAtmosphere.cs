using System;
namespace Sandbox
{
	/// <summary>
	/// Fancy dynamic sky
	/// </summary>
    [Library( "env_sky_atmosphere" )]
	[Hammer.EditorSprite( "editor/env_sky_atmosphere.vmat" )]
	public partial class AtmosphereSky : Sky
	{
		public override Material FetchSkyMaterial()
		{
			return Material.Load( "materials/sky/atmosphere_sky.vmat" );
		}
	}
}
