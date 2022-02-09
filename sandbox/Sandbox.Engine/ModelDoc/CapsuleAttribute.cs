using System;
using System.Collections.Generic;
using Sandbox.Internal;

namespace ModelDoc
{
	/// <summary>
	/// Draws a capsule, which can be manipulated via gizmos. You can have multiple of these.
	/// </summary>
	// Token: 0x020001F4 RID: 500
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
	public class CapsuleAttribute : BaseTransformAttribute
	{
		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06000CB0 RID: 3248 RVA: 0x00015ADD File Offset: 0x00013CDD
		// (set) Token: 0x06000CB1 RID: 3249 RVA: 0x00015AE5 File Offset: 0x00013CE5
		internal string Point1 { get; set; }

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000CB2 RID: 3250 RVA: 0x00015AEE File Offset: 0x00013CEE
		// (set) Token: 0x06000CB3 RID: 3251 RVA: 0x00015AF6 File Offset: 0x00013CF6
		internal string Point2 { get; set; }

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000CB4 RID: 3252 RVA: 0x00015AFF File Offset: 0x00013CFF
		// (set) Token: 0x06000CB5 RID: 3253 RVA: 0x00015B07 File Offset: 0x00013D07
		internal string Radius1 { get; set; }

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000CB6 RID: 3254 RVA: 0x00015B10 File Offset: 0x00013D10
		// (set) Token: 0x06000CB7 RID: 3255 RVA: 0x00015B18 File Offset: 0x00013D18
		internal string Radius2 { get; set; }

		/// <summary>
		/// This variation has 1 radius for both points.
		/// </summary>
		// Token: 0x06000CB8 RID: 3256 RVA: 0x00015B21 File Offset: 0x00013D21
		public CapsuleAttribute(string point1Key, string point2key, string radiusKey)
			: base("capsule")
		{
			this.Point1 = point1Key;
			this.Point2 = point2key;
			this.Radius1 = radiusKey;
		}

		/// <summary>
		/// This variation has independent radius for each point.
		/// </summary>
		// Token: 0x06000CB9 RID: 3257 RVA: 0x00015B43 File Offset: 0x00013D43
		public CapsuleAttribute(string point1Key, string point2key, string radius1Key, string radius2Key)
			: base("capsule")
		{
			this.Point1 = point1Key;
			this.Point2 = point2key;
			this.Radius1 = radius1Key;
			this.Radius2 = radius2Key;
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x00015B70 File Offset: 0x00013D70
		protected override void AddKeys(Dictionary<string, object> dict)
		{
			dict.Add("point0_key", this.Point1);
			dict.Add("point1_key", this.Point2);
			if (string.IsNullOrEmpty(this.Radius2))
			{
				dict.Add("radius_key", this.Radius1);
				return;
			}
			dict.Add("independent_radii", true);
			dict.Add("radius0_key", this.Radius1);
			dict.Add("radius1_key", this.Radius2);
		}
	}
}
