using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000062 RID: 98
	internal struct TraceRequest
	{
		// Token: 0x04000144 RID: 324
		public const int NumTagFields = 8;

		/// <summary>
		/// If true, we use a slightly slower path in the trace code that checks each entity.
		/// This is needed for testing things like Tags, so gets set automatically if needed.
		/// </summary>
		// Token: 0x04000145 RID: 325
		public byte ResolveEntities;

		// Token: 0x04000146 RID: 326
		public Vector3 StartPos;

		// Token: 0x04000147 RID: 327
		public Rotation StartRot;

		// Token: 0x04000148 RID: 328
		public Vector3 EndPos;

		// Token: 0x04000149 RID: 329
		public Rotation EndRot;

		// Token: 0x0400014A RID: 330
		public Vector3 Mins;

		// Token: 0x0400014B RID: 331
		public Vector3 Maxs;

		// Token: 0x0400014C RID: 332
		public float Radius;

		// Token: 0x0400014D RID: 333
		public byte World;

		// Token: 0x0400014E RID: 334
		public byte Entities;

		// Token: 0x0400014F RID: 335
		public IntPtr ignoreEntityOne;

		// Token: 0x04000150 RID: 336
		public IntPtr ignoreEntityTwo;

		// Token: 0x04000151 RID: 337
		public bool ignoreHierarchyOne;

		// Token: 0x04000152 RID: 338
		public bool ignoreHierarchyTwo;

		// Token: 0x04000153 RID: 339
		public CollisionLayer Mask;

		// Token: 0x04000154 RID: 340
		public Capsule Capsule;

		// Token: 0x04000155 RID: 341
		public IPhysicsBody PhysicsBody;

		// Token: 0x04000156 RID: 342
		[FixedBuffer(typeof(int), 8)]
		public TraceRequest.<TagRequire>e__FixedBuffer TagRequire;

		// Token: 0x04000157 RID: 343
		[FixedBuffer(typeof(int), 8)]
		public TraceRequest.<TagAny>e__FixedBuffer TagAny;

		// Token: 0x04000158 RID: 344
		[FixedBuffer(typeof(int), 8)]
		public TraceRequest.<TagExclude>e__FixedBuffer TagExclude;

		// Token: 0x020001DF RID: 479
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 32)]
		public struct <TagAny>e__FixedBuffer
		{
			// Token: 0x0400104C RID: 4172
			public int FixedElementField;
		}

		// Token: 0x020001E0 RID: 480
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 32)]
		public struct <TagExclude>e__FixedBuffer
		{
			// Token: 0x0400104D RID: 4173
			public int FixedElementField;
		}

		// Token: 0x020001E1 RID: 481
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 32)]
		public struct <TagRequire>e__FixedBuffer
		{
			// Token: 0x0400104E RID: 4174
			public int FixedElementField;
		}
	}
}
