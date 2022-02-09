using System;
using System.ComponentModel.DataAnnotations;

namespace Sandbox
{
	/// <summary>
	/// Simple Skybox
	/// </summary>
	[Display( Name = "Sky" ), Icon( "cloud_circle" )]
	public partial class Sky : Entity
	{
		// Todo: hammerprop doesn't work with Material handles yet
		[Property]
		public Material skyname { get; set; }

		public Material SkyMaterial { get; set; }
		public SkyboxObject SkyObject { get; set; }

		public Sky() : base()
		{
			CreateSky();
		}

		public virtual void CreateSky()
		{
			Transmit = TransmitType.Always;
			SkyMaterial = FetchSkyMaterial();

			if( IsClient )
			{
				SkyObject = new SkyboxObject( SkyMaterial );
			}
		}

		public virtual Material FetchSkyMaterial()
		{
			return skyname;
		}

		public override void Spawn()
		{
		}
	}
}
