using System;

namespace ModelDoc
{
	/// <summary>
	/// Draws a cylinder, which can be manipulated via gizmos. You can have multiple of these.
	/// </summary>
	// Token: 0x020001F5 RID: 501
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
	public class CylinderAttribute : CapsuleAttribute
	{
		/// <summary>
		/// This variation has 1 radius for both points.
		/// </summary>
		// Token: 0x06000CBB RID: 3259 RVA: 0x00015BF1 File Offset: 0x00013DF1
		public CylinderAttribute(string point1Key, string point2key, string radiusKey)
			: base(point1Key, point2key, radiusKey)
		{
			this.HelperName = "cylinder";
		}

		/// <summary>
		/// This variation has independent radius for each point.
		/// </summary>
		// Token: 0x06000CBC RID: 3260 RVA: 0x00015C07 File Offset: 0x00013E07
		public CylinderAttribute(string point1Key, string point2key, string radius1Key, string radius2Key)
			: base(point1Key, point2key, radius1Key, radius2Key)
		{
			this.HelperName = "cylinder";
		}
	}
}
