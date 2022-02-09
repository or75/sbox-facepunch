using System;

namespace NativeEngine
{
	// Token: 0x02000058 RID: 88
	internal static class Trace
	{
		// Token: 0x06000BA3 RID: 2979 RVA: 0x0003C880 File Offset: 0x0003AA80
		internal unsafe static TraceResult Ray(TraceRequest request)
		{
			method trace_Ray = Trace.__N.Trace_Ray;
			return calli(NativeEngine.TraceResult(NativeEngine.TraceRequest*), &request, trace_Ray);
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x0003C89C File Offset: 0x0003AA9C
		internal unsafe static TraceResult Capsule(TraceRequest request)
		{
			method trace_Capsule = Trace.__N.Trace_Capsule;
			return calli(NativeEngine.TraceResult(NativeEngine.TraceRequest*), &request, trace_Capsule);
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x0003C8B8 File Offset: 0x0003AAB8
		internal unsafe static TraceResult SweepPhysicsBody(TraceRequest request)
		{
			method trace_SweepPhysicsBody = Trace.__N.Trace_SweepPhysicsBody;
			return calli(NativeEngine.TraceResult(NativeEngine.TraceRequest*), &request, trace_SweepPhysicsBody);
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x0003C8D4 File Offset: 0x0003AAD4
		internal unsafe static int RayAll(TraceRequest request, IntPtr target, int max)
		{
			method trace_RayAll = Trace.__N.Trace_RayAll;
			return calli(System.Int32(NativeEngine.TraceRequest*,System.IntPtr,System.Int32), &request, target, max, trace_RayAll);
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x0003C8F4 File Offset: 0x0003AAF4
		internal unsafe static int CapsuleAll(TraceRequest request, IntPtr target, int max)
		{
			method trace_CapsuleAll = Trace.__N.Trace_CapsuleAll;
			return calli(System.Int32(NativeEngine.TraceRequest*,System.IntPtr,System.Int32), &request, target, max, trace_CapsuleAll);
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x0003C914 File Offset: 0x0003AB14
		internal unsafe static int SweepPhysicsBodyAll(TraceRequest request, IntPtr target, int max)
		{
			method trace_SweepPhysicsBodyAll = Trace.__N.Trace_SweepPhysicsBodyAll;
			return calli(System.Int32(NativeEngine.TraceRequest*,System.IntPtr,System.Int32), &request, target, max, trace_SweepPhysicsBodyAll);
		}

		// Token: 0x020001DD RID: 477
		internal static class __N
		{
			// Token: 0x04001046 RID: 4166
			internal static method Trace_Ray;

			// Token: 0x04001047 RID: 4167
			internal static method Trace_Capsule;

			// Token: 0x04001048 RID: 4168
			internal static method Trace_SweepPhysicsBody;

			// Token: 0x04001049 RID: 4169
			internal static method Trace_RayAll;

			// Token: 0x0400104A RID: 4170
			internal static method Trace_CapsuleAll;

			// Token: 0x0400104B RID: 4171
			internal static method Trace_SweepPhysicsBodyAll;
		}
	}
}
