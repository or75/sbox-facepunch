using System;

namespace Sandbox
{
	/// <summary>
	/// Garry: wtf is this for
	/// </summary>
	[Obsolete("Delete me?")]
	[Library("volume_water")]
	[Hammer.Skip]
	public partial class WaterVolume : Water
	{
		static Logger log = Logging.GetLogger();
		public override void Spawn()
		{
			base.Spawn();
		}
	}
}
