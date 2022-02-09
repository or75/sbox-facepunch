using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200004E RID: 78
	internal struct IPhysAggregateInstance
	{
		// Token: 0x06000A6D RID: 2669 RVA: 0x000399A1 File Offset: 0x00037BA1
		public static implicit operator IntPtr(IPhysAggregateInstance value)
		{
			return value.self;
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x000399AC File Offset: 0x00037BAC
		public static implicit operator IPhysAggregateInstance(IntPtr value)
		{
			return new IPhysAggregateInstance
			{
				self = value
			};
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x000399CA File Offset: 0x00037BCA
		public static bool operator ==(IPhysAggregateInstance c1, IPhysAggregateInstance c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x000399DD File Offset: 0x00037BDD
		public static bool operator !=(IPhysAggregateInstance c1, IPhysAggregateInstance c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x000399F0 File Offset: 0x00037BF0
		public override bool Equals(object obj)
		{
			if (obj is IPhysAggregateInstance)
			{
				IPhysAggregateInstance c = (IPhysAggregateInstance)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x00039A1A File Offset: 0x00037C1A
		internal IPhysAggregateInstance(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x00039A24 File Offset: 0x00037C24
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
			defaultInterpolatedStringHandler.AppendLiteral("IPhysAggregateInstance ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000A74 RID: 2676 RVA: 0x00039A60 File Offset: 0x00037C60
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000A75 RID: 2677 RVA: 0x00039A72 File Offset: 0x00037C72
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x00039A7D File Offset: 0x00037C7D
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x00039A90 File Offset: 0x00037C90
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("IPhysAggregateInstance was null when calling " + n);
			}
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x00039AAB File Offset: 0x00037CAB
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x00039AB8 File Offset: 0x00037CB8
		internal readonly void WakeUp()
		{
			this.NullCheck("WakeUp");
			method iphysA_WakeUp = IPhysAggregateInstance.__N.IPhysA_WakeUp;
			calli(System.Void(System.IntPtr), this.self, iphysA_WakeUp);
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x00039AE4 File Offset: 0x00037CE4
		internal readonly void PutToSleep()
		{
			this.NullCheck("PutToSleep");
			method iphysA_PutToSleep = IPhysAggregateInstance.__N.IPhysA_PutToSleep;
			calli(System.Void(System.IntPtr), this.self, iphysA_PutToSleep);
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x00039B10 File Offset: 0x00037D10
		internal unsafe readonly void SetVelocity(Vector3 v)
		{
			this.NullCheck("SetVelocity");
			method iphysA_SetVelocity = IPhysAggregateInstance.__N.IPhysA_SetVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, iphysA_SetVelocity);
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x00039B40 File Offset: 0x00037D40
		internal unsafe readonly void AddVelocity(Vector3 v)
		{
			this.NullCheck("AddVelocity");
			method iphysA_AddVelocity = IPhysAggregateInstance.__N.IPhysA_AddVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, iphysA_AddVelocity);
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x00039B70 File Offset: 0x00037D70
		internal unsafe readonly void SetAngularVelocity(Vector3 v)
		{
			this.NullCheck("SetAngularVelocity");
			method iphysA_SetAngularVelocity = IPhysAggregateInstance.__N.IPhysA_SetAngularVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, iphysA_SetAngularVelocity);
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x00039BA0 File Offset: 0x00037DA0
		internal unsafe readonly void AddAngularVelocity(Vector3 v)
		{
			this.NullCheck("AddAngularVelocity");
			method iphysA_AddAngularVelocity = IPhysAggregateInstance.__N.IPhysA_AddAngularVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, iphysA_AddAngularVelocity);
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x00039BD0 File Offset: 0x00037DD0
		internal readonly int GetBodyCount()
		{
			this.NullCheck("GetBodyCount");
			method iphysA_GetBodyCount = IPhysAggregateInstance.__N.IPhysA_GetBodyCount;
			return calli(System.Int32(System.IntPtr), this.self, iphysA_GetBodyCount);
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x00039BFC File Offset: 0x00037DFC
		internal readonly PhysicsBody GetBodyHandle(int i)
		{
			this.NullCheck("GetBodyHandle");
			method iphysA_GetBodyHandle = IPhysAggregateInstance.__N.IPhysA_GetBodyHandle;
			return HandleIndex.Get<PhysicsBody>(calli(System.Int32(System.IntPtr,System.Int32), this.self, i, iphysA_GetBodyHandle));
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x00039C2C File Offset: 0x00037E2C
		internal readonly string GetBodyName(int i)
		{
			this.NullCheck("GetBodyName");
			method iphysA_GetBodyName = IPhysAggregateInstance.__N.IPhysA_GetBodyName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr,System.Int32), this.self, i, iphysA_GetBodyName));
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x00039C5C File Offset: 0x00037E5C
		internal readonly uint GetBodyNameHash(int i)
		{
			this.NullCheck("GetBodyNameHash");
			method iphysA_GetBodyNameHash = IPhysAggregateInstance.__N.IPhysA_GetBodyNameHash;
			return calli(System.UInt32(System.IntPtr,System.Int32), this.self, i, iphysA_GetBodyNameHash);
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x00039C88 File Offset: 0x00037E88
		internal readonly PhysicsBody GetBodyByNameHash(int i)
		{
			this.NullCheck("GetBodyByNameHash");
			method iphysA_GetBodyByNameHash = IPhysAggregateInstance.__N.IPhysA_GetBodyByNameHash;
			return HandleIndex.Get<PhysicsBody>(calli(System.Int32(System.IntPtr,System.Int32), this.self, i, iphysA_GetBodyByNameHash));
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x00039CB8 File Offset: 0x00037EB8
		internal readonly int GetBodyIndex(PhysicsBody body)
		{
			this.NullCheck("GetBodyIndex");
			method iphysA_GetBodyIndex = IPhysAggregateInstance.__N.IPhysA_GetBodyIndex;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, (body == null) ? IntPtr.Zero : body.native, iphysA_GetBodyIndex);
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x00039CF8 File Offset: 0x00037EF8
		internal readonly PhysicsBody FindBodyByName(string name)
		{
			this.NullCheck("FindBodyByName");
			method iphysA_FindBodyByName = IPhysAggregateInstance.__N.IPhysA_FindBodyByName;
			return HandleIndex.Get<PhysicsBody>(calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), iphysA_FindBodyByName));
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x00039D30 File Offset: 0x00037F30
		internal readonly int GetJointCount()
		{
			this.NullCheck("GetJointCount");
			method iphysA_GetJointCount = IPhysAggregateInstance.__N.IPhysA_GetJointCount;
			return calli(System.Int32(System.IntPtr), this.self, iphysA_GetJointCount);
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x00039D5C File Offset: 0x00037F5C
		internal readonly PhysicsJoint GetJointHandle(int nIndex)
		{
			this.NullCheck("GetJointHandle");
			method iphysA_GetJointHandle = IPhysAggregateInstance.__N.IPhysA_GetJointHandle;
			return HandleIndex.Get<PhysicsJoint>(calli(System.Int32(System.IntPtr,System.Int32), this.self, nIndex, iphysA_GetJointHandle));
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x00039D8C File Offset: 0x00037F8C
		internal readonly Vector3 GetOrigin()
		{
			this.NullCheck("GetOrigin");
			method iphysA_GetOrigin = IPhysAggregateInstance.__N.IPhysA_GetOrigin;
			return calli(Vector3(System.IntPtr), this.self, iphysA_GetOrigin);
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x00039DB8 File Offset: 0x00037FB8
		internal readonly Vector3 GetMassCenter()
		{
			this.NullCheck("GetMassCenter");
			method iphysA_GetMassCenter = IPhysAggregateInstance.__N.IPhysA_GetMassCenter;
			return calli(Vector3(System.IntPtr), this.self, iphysA_GetMassCenter);
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x00039DE4 File Offset: 0x00037FE4
		internal readonly void SetSurfaceProperties(string name)
		{
			this.NullCheck("SetSurfaceProperties");
			method iphysA_SetSurfaceProperties = IPhysAggregateInstance.__N.IPhysA_SetSurfaceProperties;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(name), iphysA_SetSurfaceProperties);
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x00039E14 File Offset: 0x00038014
		internal readonly float GetTotalMass()
		{
			this.NullCheck("GetTotalMass");
			method iphysA_GetTotalMass = IPhysAggregateInstance.__N.IPhysA_GetTotalMass;
			return calli(System.Single(System.IntPtr), this.self, iphysA_GetTotalMass);
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x00039E40 File Offset: 0x00038040
		internal readonly void SetTotalMass(float flMass)
		{
			this.NullCheck("SetTotalMass");
			method iphysA_SetTotalMass = IPhysAggregateInstance.__N.IPhysA_SetTotalMass;
			calli(System.Void(System.IntPtr,System.Single), this.self, flMass, iphysA_SetTotalMass);
		}

		// Token: 0x040000BC RID: 188
		internal IntPtr self;

		// Token: 0x020001D3 RID: 467
		internal static class __N
		{
			// Token: 0x04000F70 RID: 3952
			internal static method IPhysA_WakeUp;

			// Token: 0x04000F71 RID: 3953
			internal static method IPhysA_PutToSleep;

			// Token: 0x04000F72 RID: 3954
			internal static method IPhysA_SetVelocity;

			// Token: 0x04000F73 RID: 3955
			internal static method IPhysA_AddVelocity;

			// Token: 0x04000F74 RID: 3956
			internal static method IPhysA_SetAngularVelocity;

			// Token: 0x04000F75 RID: 3957
			internal static method IPhysA_AddAngularVelocity;

			// Token: 0x04000F76 RID: 3958
			internal static method IPhysA_GetBodyCount;

			// Token: 0x04000F77 RID: 3959
			internal static method IPhysA_GetBodyHandle;

			// Token: 0x04000F78 RID: 3960
			internal static method IPhysA_GetBodyName;

			// Token: 0x04000F79 RID: 3961
			internal static method IPhysA_GetBodyNameHash;

			// Token: 0x04000F7A RID: 3962
			internal static method IPhysA_GetBodyByNameHash;

			// Token: 0x04000F7B RID: 3963
			internal static method IPhysA_GetBodyIndex;

			// Token: 0x04000F7C RID: 3964
			internal static method IPhysA_FindBodyByName;

			// Token: 0x04000F7D RID: 3965
			internal static method IPhysA_GetJointCount;

			// Token: 0x04000F7E RID: 3966
			internal static method IPhysA_GetJointHandle;

			// Token: 0x04000F7F RID: 3967
			internal static method IPhysA_GetOrigin;

			// Token: 0x04000F80 RID: 3968
			internal static method IPhysA_GetMassCenter;

			// Token: 0x04000F81 RID: 3969
			internal static method IPhysA_SetSurfaceProperties;

			// Token: 0x04000F82 RID: 3970
			internal static method IPhysA_GetTotalMass;

			// Token: 0x04000F83 RID: 3971
			internal static method IPhysA_SetTotalMass;
		}
	}
}
