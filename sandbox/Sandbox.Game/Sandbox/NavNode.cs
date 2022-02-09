using System;

namespace Sandbox
{
	// Token: 0x020000C1 RID: 193
	public struct NavNode
	{
		/// <summary>
		/// How to traverse this segment of the path
		/// </summary>
		// Token: 0x0400039B RID: 923
		public NavNodeType SegmentType;

		/// <summary>
		/// How to exit the previous area to get to this one
		/// </summary>
		// Token: 0x0400039C RID: 924
		public NavTraverseType EnterType;

		/// <summary>
		/// The current areas navigation attributes, are these stairs? Do you need to crouch here? etc. This is a bit flag!
		/// </summary>
		// Token: 0x0400039D RID: 925
		public NavAreaAttribute AreaFlags;

		/// <summary>
		/// The previous areas navigation attributes, are these stairs? Do you need to crouch here? etc. This is a bit flag!
		/// </summary>
		// Token: 0x0400039E RID: 926
		public NavAreaAttribute PreviousAreaFlags;

		/// <summary>
		/// Our movement goal position at this point in the path
		/// </summary>
		// Token: 0x0400039F RID: 927
		public Vector3 Position;

		/// <summary>
		/// The forward direction of the path segment
		/// </summary>
		// Token: 0x040003A0 RID: 928
		public Vector3 Direction;

		/// <summary>
		/// The current length of the segment
		/// </summary>
		// Token: 0x040003A1 RID: 929
		public float Length;

		/// <summary>
		/// How far the segment is from the start
		/// </summary>
		// Token: 0x040003A2 RID: 930
		public float DistanceFromStart;

		/// <summary>
		/// How much the path "curves" at this point in the XY plane (0 = none, 1 = 180 degree double-back)
		/// </summary>
		// Token: 0x040003A3 RID: 931
		public float Curvature;
	}
}
