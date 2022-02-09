using System;
using System.Collections.Generic;
using Sandbox.Internal;

namespace ModelDoc
{
	/// <summary>
	/// A helper that draws axis of rotation and angle limit of a hinge joint.
	/// </summary>
	// Token: 0x020001F6 RID: 502
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
	public class HingeJointAttribute : BaseTransformAttribute
	{
		/// <summary>
		/// Key name that dictates whether the hinge limit is enabled or not.
		/// </summary>
		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000CBD RID: 3261 RVA: 0x00015C1F File Offset: 0x00013E1F
		// (set) Token: 0x06000CBE RID: 3262 RVA: 0x00015C27 File Offset: 0x00013E27
		public string EnableLimit { get; set; }

		/// <summary>
		/// Key name that stores the minimum angle value for the revolute joint.
		/// </summary>
		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000CBF RID: 3263 RVA: 0x00015C30 File Offset: 0x00013E30
		// (set) Token: 0x06000CC0 RID: 3264 RVA: 0x00015C38 File Offset: 0x00013E38
		public string MinAngle { get; set; }

		/// <summary>
		/// Key name that stores the maximum angle value for the revolute joint.
		/// </summary>
		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000CC1 RID: 3265 RVA: 0x00015C41 File Offset: 0x00013E41
		// (set) Token: 0x06000CC2 RID: 3266 RVA: 0x00015C49 File Offset: 0x00013E49
		public string MaxAngle { get; set; }

		// Token: 0x06000CC3 RID: 3267 RVA: 0x00015C52 File Offset: 0x00013E52
		public HingeJointAttribute()
			: base("physicsjoint_hinge")
		{
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x00015C5F File Offset: 0x00013E5F
		protected override void AddKeys(Dictionary<string, object> dict)
		{
			dict.Add("min_angle", this.MinAngle);
			dict.Add("max_angle", this.MaxAngle);
			dict.Add("enable_limit", this.EnableLimit);
		}
	}
}
