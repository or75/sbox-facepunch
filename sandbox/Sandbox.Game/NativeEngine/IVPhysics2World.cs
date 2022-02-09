using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000055 RID: 85
	internal struct IVPhysics2World
	{
		// Token: 0x06000B6E RID: 2926 RVA: 0x0003C087 File Offset: 0x0003A287
		public static implicit operator IntPtr(IVPhysics2World value)
		{
			return value.self;
		}

		// Token: 0x06000B6F RID: 2927 RVA: 0x0003C090 File Offset: 0x0003A290
		public static implicit operator IVPhysics2World(IntPtr value)
		{
			return new IVPhysics2World
			{
				self = value
			};
		}

		// Token: 0x06000B70 RID: 2928 RVA: 0x0003C0AE File Offset: 0x0003A2AE
		public static bool operator ==(IVPhysics2World c1, IVPhysics2World c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x0003C0C1 File Offset: 0x0003A2C1
		public static bool operator !=(IVPhysics2World c1, IVPhysics2World c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x0003C0D4 File Offset: 0x0003A2D4
		public override bool Equals(object obj)
		{
			if (obj is IVPhysics2World)
			{
				IVPhysics2World c = (IVPhysics2World)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x0003C0FE File Offset: 0x0003A2FE
		internal IVPhysics2World(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x0003C108 File Offset: 0x0003A308
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
			defaultInterpolatedStringHandler.AppendLiteral("IVPhysics2World ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000B75 RID: 2933 RVA: 0x0003C144 File Offset: 0x0003A344
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000B76 RID: 2934 RVA: 0x0003C156 File Offset: 0x0003A356
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000B77 RID: 2935 RVA: 0x0003C161 File Offset: 0x0003A361
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000B78 RID: 2936 RVA: 0x0003C174 File Offset: 0x0003A374
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("IVPhysics2World was null when calling " + n);
			}
		}

		// Token: 0x06000B79 RID: 2937 RVA: 0x0003C18F File Offset: 0x0003A38F
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000B7A RID: 2938 RVA: 0x0003C19C File Offset: 0x0003A39C
		internal readonly int GetBodyCount()
		{
			this.NullCheck("GetBodyCount");
			method ivphys_GetBodyCount = IVPhysics2World.__N.IVPhys_GetBodyCount;
			return calli(System.Int32(System.IntPtr), this.self, ivphys_GetBodyCount);
		}

		// Token: 0x06000B7B RID: 2939 RVA: 0x0003C1C8 File Offset: 0x0003A3C8
		internal readonly PhysicsBody GetBody(int nBody)
		{
			this.NullCheck("GetBody");
			method ivphys_GetBody = IVPhysics2World.__N.IVPhys_GetBody;
			return HandleIndex.Get<PhysicsBody>(calli(System.Int32(System.IntPtr,System.Int32), this.self, nBody, ivphys_GetBody));
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x0003C1F8 File Offset: 0x0003A3F8
		internal readonly void MoveToHead(PhysicsBody pBody)
		{
			this.NullCheck("MoveToHead");
			method ivphys_MoveToHead = IVPhysics2World.__N.IVPhys_MoveToHead;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, (pBody == null) ? IntPtr.Zero : pBody.native, ivphys_MoveToHead);
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x0003C238 File Offset: 0x0003A438
		internal readonly PhysicsBody AddBody()
		{
			this.NullCheck("AddBody");
			method ivphys_AddBody = IVPhysics2World.__N.IVPhys_AddBody;
			return HandleIndex.Get<PhysicsBody>(calli(System.Int32(System.IntPtr), this.self, ivphys_AddBody));
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x0003C268 File Offset: 0x0003A468
		internal unsafe readonly PhysicsBody AddBody(Vector3 p, Rotation q)
		{
			this.NullCheck("AddBody");
			method ivphys_f = IVPhysics2World.__N.IVPhys_f2;
			return HandleIndex.Get<PhysicsBody>(calli(System.Int32(System.IntPtr,Vector3*,Rotation*), this.self, &p, &q, ivphys_f));
		}

		// Token: 0x06000B7F RID: 2943 RVA: 0x0003C2A0 File Offset: 0x0003A4A0
		internal readonly void RemoveBody(PhysicsBody pBody)
		{
			this.NullCheck("RemoveBody");
			method ivphys_RemoveBody = IVPhysics2World.__N.IVPhys_RemoveBody;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, (pBody == null) ? IntPtr.Zero : pBody.native, ivphys_RemoveBody);
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x0003C2E0 File Offset: 0x0003A4E0
		internal readonly PhysicsBody GetWorldReferenceBody()
		{
			this.NullCheck("GetWorldReferenceBody");
			method ivphys_GetWorldReferenceBody = IVPhysics2World.__N.IVPhys_GetWorldReferenceBody;
			return HandleIndex.Get<PhysicsBody>(calli(System.Int32(System.IntPtr), this.self, ivphys_GetWorldReferenceBody));
		}

		// Token: 0x06000B81 RID: 2945 RVA: 0x0003C310 File Offset: 0x0003A510
		internal readonly int GetJointCount()
		{
			this.NullCheck("GetJointCount");
			method ivphys_GetJointCount = IVPhysics2World.__N.IVPhys_GetJointCount;
			return calli(System.Int32(System.IntPtr), this.self, ivphys_GetJointCount);
		}

		// Token: 0x06000B82 RID: 2946 RVA: 0x0003C33C File Offset: 0x0003A53C
		internal readonly PhysicsJoint GetJoint(int nJoint)
		{
			this.NullCheck("GetJoint");
			method ivphys_GetJoint = IVPhysics2World.__N.IVPhys_GetJoint;
			return HandleIndex.Get<PhysicsJoint>(calli(System.Int32(System.IntPtr,System.Int32), this.self, nJoint, ivphys_GetJoint));
		}

		// Token: 0x06000B83 RID: 2947 RVA: 0x0003C36C File Offset: 0x0003A56C
		internal readonly void MoveToHead(PhysicsJoint pJoint)
		{
			this.NullCheck("MoveToHead");
			method ivphys_f = IVPhysics2World.__N.IVPhys_f3;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, (pJoint == null) ? IntPtr.Zero : pJoint.native, ivphys_f);
		}

		// Token: 0x06000B84 RID: 2948 RVA: 0x0003C3AC File Offset: 0x0003A5AC
		internal readonly bool RemoveJoint(PhysicsJoint pJoint)
		{
			this.NullCheck("RemoveJoint");
			method ivphys_RemoveJoint = IVPhysics2World.__N.IVPhys_RemoveJoint;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, (pJoint == null) ? IntPtr.Zero : pJoint.native, ivphys_RemoveJoint) > 0;
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x0003C3F0 File Offset: 0x0003A5F0
		internal unsafe readonly void SetGravity(Vector3 gravity)
		{
			this.NullCheck("SetGravity");
			method ivphys_SetGravity = IVPhysics2World.__N.IVPhys_SetGravity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &gravity, ivphys_SetGravity);
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x0003C420 File Offset: 0x0003A620
		internal readonly Vector3 GetGravity()
		{
			this.NullCheck("GetGravity");
			method ivphys_GetGravity = IVPhysics2World.__N.IVPhys_GetGravity;
			return calli(Vector3(System.IntPtr), this.self, ivphys_GetGravity);
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x0003C44C File Offset: 0x0003A64C
		internal readonly void EnableSleeping()
		{
			this.NullCheck("EnableSleeping");
			method ivphys_EnableSleeping = IVPhysics2World.__N.IVPhys_EnableSleeping;
			calli(System.Void(System.IntPtr), this.self, ivphys_EnableSleeping);
		}

		// Token: 0x06000B88 RID: 2952 RVA: 0x0003C478 File Offset: 0x0003A678
		internal readonly void DisableSleeping()
		{
			this.NullCheck("DisableSleeping");
			method ivphys_DisableSleeping = IVPhysics2World.__N.IVPhys_DisableSleeping;
			calli(System.Void(System.IntPtr), this.self, ivphys_DisableSleeping);
		}

		// Token: 0x06000B89 RID: 2953 RVA: 0x0003C4A4 File Offset: 0x0003A6A4
		internal readonly bool IsSleepingEnabled()
		{
			this.NullCheck("IsSleepingEnabled");
			method ivphys_IsSleepingEnabled = IVPhysics2World.__N.IVPhys_IsSleepingEnabled;
			return calli(System.Int32(System.IntPtr), this.self, ivphys_IsSleepingEnabled) > 0;
		}

		// Token: 0x06000B8A RID: 2954 RVA: 0x0003C4D4 File Offset: 0x0003A6D4
		internal readonly void RemoveContacts(PhysicsBody pBody1, PhysicsBody pBody2)
		{
			this.NullCheck("RemoveContacts");
			method ivphys_RemoveContacts = IVPhysics2World.__N.IVPhys_RemoveContacts;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, (pBody1 == null) ? IntPtr.Zero : pBody1.native, (pBody2 == null) ? IntPtr.Zero : pBody2.native, ivphys_RemoveContacts);
		}

		// Token: 0x040000C3 RID: 195
		internal IntPtr self;

		// Token: 0x020001DA RID: 474
		internal static class __N
		{
			// Token: 0x0400101D RID: 4125
			internal static method IVPhys_GetBodyCount;

			// Token: 0x0400101E RID: 4126
			internal static method IVPhys_GetBody;

			// Token: 0x0400101F RID: 4127
			internal static method IVPhys_MoveToHead;

			// Token: 0x04001020 RID: 4128
			internal static method IVPhys_AddBody;

			// Token: 0x04001021 RID: 4129
			internal static method IVPhys_f2;

			// Token: 0x04001022 RID: 4130
			internal static method IVPhys_RemoveBody;

			// Token: 0x04001023 RID: 4131
			internal static method IVPhys_GetWorldReferenceBody;

			// Token: 0x04001024 RID: 4132
			internal static method IVPhys_GetJointCount;

			// Token: 0x04001025 RID: 4133
			internal static method IVPhys_GetJoint;

			// Token: 0x04001026 RID: 4134
			internal static method IVPhys_f3;

			// Token: 0x04001027 RID: 4135
			internal static method IVPhys_RemoveJoint;

			// Token: 0x04001028 RID: 4136
			internal static method IVPhys_SetGravity;

			// Token: 0x04001029 RID: 4137
			internal static method IVPhys_GetGravity;

			// Token: 0x0400102A RID: 4138
			internal static method IVPhys_EnableSleeping;

			// Token: 0x0400102B RID: 4139
			internal static method IVPhys_DisableSleeping;

			// Token: 0x0400102C RID: 4140
			internal static method IVPhys_IsSleepingEnabled;

			// Token: 0x0400102D RID: 4141
			internal static method IVPhys_RemoveContacts;
		}
	}
}
