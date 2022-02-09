using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000038 RID: 56
	internal struct CSkeletonInstance
	{
		// Token: 0x060008BE RID: 2238 RVA: 0x00035801 File Offset: 0x00033A01
		public static implicit operator IntPtr(CSkeletonInstance value)
		{
			return value.self;
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x0003580C File Offset: 0x00033A0C
		public static implicit operator CSkeletonInstance(IntPtr value)
		{
			return new CSkeletonInstance
			{
				self = value
			};
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x0003582A File Offset: 0x00033A2A
		public static bool operator ==(CSkeletonInstance c1, CSkeletonInstance c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x0003583D File Offset: 0x00033A3D
		public static bool operator !=(CSkeletonInstance c1, CSkeletonInstance c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x00035850 File Offset: 0x00033A50
		public override bool Equals(object obj)
		{
			if (obj is CSkeletonInstance)
			{
				CSkeletonInstance c = (CSkeletonInstance)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x0003587A File Offset: 0x00033A7A
		internal CSkeletonInstance(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x00035884 File Offset: 0x00033A84
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CSkeletonInstance ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060008C5 RID: 2245 RVA: 0x000358C0 File Offset: 0x00033AC0
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060008C6 RID: 2246 RVA: 0x000358D2 File Offset: 0x00033AD2
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x000358DD File Offset: 0x00033ADD
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x000358F0 File Offset: 0x00033AF0
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CSkeletonInstance was null when calling " + n);
			}
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x0003590B File Offset: 0x00033B0B
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x00035918 File Offset: 0x00033B18
		public static implicit operator CGameSceneNode(CSkeletonInstance value)
		{
			method to_CGameSceneNode_From_CSkeletonInstance = CSkeletonInstance.__N.To_CGameSceneNode_From_CSkeletonInstance;
			return calli(System.IntPtr(System.IntPtr), value, to_CGameSceneNode_From_CSkeletonInstance);
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x0003593C File Offset: 0x00033B3C
		public static explicit operator CSkeletonInstance(CGameSceneNode value)
		{
			method from_CGameSceneNode_To_CSkeletonInstance = CSkeletonInstance.__N.From_CGameSceneNode_To_CSkeletonInstance;
			return calli(System.IntPtr(System.IntPtr), value, from_CGameSceneNode_To_CSkeletonInstance);
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x00035960 File Offset: 0x00033B60
		internal readonly void SetRenderingEnabled(bool b)
		{
			this.NullCheck("SetRenderingEnabled");
			method cskele_SetRenderingEnabled = CSkeletonInstance.__N.CSkele_SetRenderingEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, cskele_SetRenderingEnabled);
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x00035994 File Offset: 0x00033B94
		internal readonly bool IsRenderingEnabled()
		{
			this.NullCheck("IsRenderingEnabled");
			method cskele_IsRenderingEnabled = CSkeletonInstance.__N.CSkele_IsRenderingEnabled;
			return calli(System.Int32(System.IntPtr), this.self, cskele_IsRenderingEnabled) > 0;
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x000359C4 File Offset: 0x00033BC4
		internal readonly void SetAnimationEnabled(bool b)
		{
			this.NullCheck("SetAnimationEnabled");
			method cskele_SetAnimationEnabled = CSkeletonInstance.__N.CSkele_SetAnimationEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, cskele_SetAnimationEnabled);
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x000359F8 File Offset: 0x00033BF8
		internal readonly bool IsAnimationEnabled()
		{
			this.NullCheck("IsAnimationEnabled");
			method cskele_IsAnimationEnabled = CSkeletonInstance.__N.CSkele_IsAnimationEnabled;
			return calli(System.Int32(System.IntPtr), this.self, cskele_IsAnimationEnabled) > 0;
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x00035A28 File Offset: 0x00033C28
		internal readonly bool IsRigidSkeleton()
		{
			this.NullCheck("IsRigidSkeleton");
			method cskele_IsRigidSkeleton = CSkeletonInstance.__N.CSkele_IsRigidSkeleton;
			return calli(System.Int32(System.IntPtr), this.self, cskele_IsRigidSkeleton) > 0;
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x00035A58 File Offset: 0x00033C58
		internal readonly bool HasPhysics()
		{
			this.NullCheck("HasPhysics");
			method cskele_HasPhysics = CSkeletonInstance.__N.CSkele_HasPhysics;
			return calli(System.Int32(System.IntPtr), this.self, cskele_HasPhysics) > 0;
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x00035A88 File Offset: 0x00033C88
		internal readonly bool HasRendering()
		{
			this.NullCheck("HasRendering");
			method cskele_HasRendering = CSkeletonInstance.__N.CSkele_HasRendering;
			return calli(System.Int32(System.IntPtr), this.self, cskele_HasRendering) > 0;
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x00035AB8 File Offset: 0x00033CB8
		internal readonly void SetupPhysics()
		{
			this.NullCheck("SetupPhysics");
			method cskele_SetupPhysics = CSkeletonInstance.__N.CSkele_SetupPhysics;
			calli(System.Void(System.IntPtr), this.self, cskele_SetupPhysics);
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x00035AE4 File Offset: 0x00033CE4
		internal readonly void CleanupPhysics()
		{
			this.NullCheck("CleanupPhysics");
			method cskele_CleanupPhysics = CSkeletonInstance.__N.CSkele_CleanupPhysics;
			calli(System.Void(System.IntPtr), this.self, cskele_CleanupPhysics);
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x00035B10 File Offset: 0x00033D10
		internal readonly void CleanupCloth()
		{
			this.NullCheck("CleanupCloth");
			method cskele_CleanupCloth = CSkeletonInstance.__N.CSkele_CleanupCloth;
			calli(System.Void(System.IntPtr), this.self, cskele_CleanupCloth);
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x00035B3C File Offset: 0x00033D3C
		internal readonly int LookupBone(string name)
		{
			this.NullCheck("LookupBone");
			method cskele_LookupBone = CSkeletonInstance.__N.CSkele_LookupBone;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cskele_LookupBone);
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x00035B6C File Offset: 0x00033D6C
		internal readonly int GetNumBones()
		{
			this.NullCheck("GetNumBones");
			method cskele_GetNumBones = CSkeletonInstance.__N.CSkele_GetNumBones;
			return calli(System.Int32(System.IntPtr), this.self, cskele_GetNumBones);
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x00035B98 File Offset: 0x00033D98
		internal readonly int GetRootBoneMergeBone()
		{
			this.NullCheck("GetRootBoneMergeBone");
			method cskele_GetRootBoneMergeBone = CSkeletonInstance.__N.CSkele_GetRootBoneMergeBone;
			return calli(System.Int32(System.IntPtr), this.self, cskele_GetRootBoneMergeBone);
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x00035BC4 File Offset: 0x00033DC4
		internal readonly Transform GetAnimationStateParentSpaceTransform(int boneIndex)
		{
			this.NullCheck("GetAnimationStateParentSpaceTransform");
			method cskele_GetAnimationStateParentSpaceTransform = CSkeletonInstance.__N.CSkele_GetAnimationStateParentSpaceTransform;
			return calli(Transform(System.IntPtr,System.Int32), this.self, boneIndex, cskele_GetAnimationStateParentSpaceTransform);
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x00035BF0 File Offset: 0x00033DF0
		internal unsafe readonly Transform GetAnimationStateWorldSpaceTransform(Transform rootToWorld, int boneIndex)
		{
			this.NullCheck("GetAnimationStateWorldSpaceTransform");
			method cskele_GetAnimationStateWorldSpaceTransform = CSkeletonInstance.__N.CSkele_GetAnimationStateWorldSpaceTransform;
			return calli(Transform(System.IntPtr,Transform*,System.Int32), this.self, &rootToWorld, boneIndex, cskele_GetAnimationStateWorldSpaceTransform);
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x00035C20 File Offset: 0x00033E20
		internal unsafe readonly int SBox_GetWorldspaceBones(BoneFlags boneflags, Transform[] ArrayOftx, int txmax)
		{
			this.NullCheck("SBox_GetWorldspaceBones");
			if (ArrayOftx == null)
			{
				Transform* ArrayOftx_array_ptr = null;
				method cskele_SBox_GetWorldspaceBones = CSkeletonInstance.__N.CSkele_SBox_GetWorldspaceBones;
				return calli(System.Int32(System.IntPtr,System.Int64,Transform*,System.Int32), this.self, (ulong)boneflags, ArrayOftx_array_ptr, txmax, cskele_SBox_GetWorldspaceBones);
			}
			fixed (Transform* ptr = &ArrayOftx[0])
			{
				Transform* ArrayOftx_array_ptr2 = ptr;
				method cskele_SBox_GetWorldspaceBones = CSkeletonInstance.__N.CSkele_SBox_GetWorldspaceBones;
				return calli(System.Int32(System.IntPtr,System.Int64,Transform*,System.Int32), this.self, (ulong)boneflags, ArrayOftx_array_ptr2, txmax, cskele_SBox_GetWorldspaceBones);
			}
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x00035C78 File Offset: 0x00033E78
		internal readonly int SBox_GetBoneParent(int boneId)
		{
			this.NullCheck("SBox_GetBoneParent");
			method cskele_SBox_GetBoneParent = CSkeletonInstance.__N.CSkele_SBox_GetBoneParent;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, boneId, cskele_SBox_GetBoneParent);
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x00035CA4 File Offset: 0x00033EA4
		internal readonly string SBox_GetBoneName(int boneId)
		{
			this.NullCheck("SBox_GetBoneName");
			method cskele_SBox_GetBoneName = CSkeletonInstance.__N.CSkele_SBox_GetBoneName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr,System.Int32), this.self, boneId, cskele_SBox_GetBoneName));
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x00035CD4 File Offset: 0x00033ED4
		internal unsafe readonly bool SBox_SetBoneTransform(int boneId, Transform tx, bool worldspace)
		{
			this.NullCheck("SBox_SetBoneTransform");
			method cskele_SBox_SetBoneTransform = CSkeletonInstance.__N.CSkele_SBox_SetBoneTransform;
			return calli(System.Int32(System.IntPtr,System.Int32,Transform*,System.Int32), this.self, boneId, &tx, worldspace ? 1 : 0, cskele_SBox_SetBoneTransform) > 0;
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x00035D0C File Offset: 0x00033F0C
		internal readonly Transform SBox_GetBoneTransform(int boneId, bool worldspace)
		{
			this.NullCheck("SBox_GetBoneTransform");
			method cskele_SBox_GetBoneTransform = CSkeletonInstance.__N.CSkele_SBox_GetBoneTransform;
			return calli(Transform(System.IntPtr,System.Int32,System.Int32), this.self, boneId, worldspace ? 1 : 0, cskele_SBox_GetBoneTransform);
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x00035D40 File Offset: 0x00033F40
		internal readonly int Sbox_GetPhysicsBodyId(int boneId)
		{
			this.NullCheck("Sbox_GetPhysicsBodyId");
			method cskele_Sbox_GetPhysicsBodyId = CSkeletonInstance.__N.CSkele_Sbox_GetPhysicsBodyId;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, boneId, cskele_Sbox_GetPhysicsBodyId);
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00035D6C File Offset: 0x00033F6C
		internal readonly PhysicsBody Sbox_GetPhysicsBody(int boneId)
		{
			this.NullCheck("Sbox_GetPhysicsBody");
			method cskele_Sbox_GetPhysicsBody = CSkeletonInstance.__N.CSkele_Sbox_GetPhysicsBody;
			return HandleIndex.Get<PhysicsBody>(calli(System.Int32(System.IntPtr,System.Int32), this.self, boneId, cskele_Sbox_GetPhysicsBody));
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x00035D9C File Offset: 0x00033F9C
		internal readonly int Sbox_PhysicsBodyToBone(PhysicsBody body)
		{
			this.NullCheck("Sbox_PhysicsBodyToBone");
			method cskele_Sbox_PhysicsBodyToBone = CSkeletonInstance.__N.CSkele_Sbox_PhysicsBodyToBone;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, (body == null) ? IntPtr.Zero : body.native, cskele_Sbox_PhysicsBodyToBone);
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x00035DDC File Offset: 0x00033FDC
		internal unsafe readonly int SBox_ComputeBonesAtTime(Transform[] ArrayOftx, int capacity, float timeOffset)
		{
			this.NullCheck("SBox_ComputeBonesAtTime");
			if (ArrayOftx == null)
			{
				Transform* ArrayOftx_array_ptr = null;
				method cskele_SBox_ComputeBonesAtTime = CSkeletonInstance.__N.CSkele_SBox_ComputeBonesAtTime;
				return calli(System.Int32(System.IntPtr,Transform*,System.Int32,System.Single), this.self, ArrayOftx_array_ptr, capacity, timeOffset, cskele_SBox_ComputeBonesAtTime);
			}
			fixed (Transform* ptr = &ArrayOftx[0])
			{
				Transform* ArrayOftx_array_ptr2 = ptr;
				method cskele_SBox_ComputeBonesAtTime = CSkeletonInstance.__N.CSkele_SBox_ComputeBonesAtTime;
				return calli(System.Int32(System.IntPtr,Transform*,System.Int32,System.Single), this.self, ArrayOftx_array_ptr2, capacity, timeOffset, cskele_SBox_ComputeBonesAtTime);
			}
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x00035E30 File Offset: 0x00034030
		internal readonly bool SBox_GetAttachment(string name, bool worldspace, out Transform tx)
		{
			this.NullCheck("SBox_GetAttachment");
			method cskele_SBox_GetAttachment = CSkeletonInstance.__N.CSkele_SBox_GetAttachment;
			return calli(System.Int32(System.IntPtr,System.UInt32,System.Int32,Transform& modreq(System.Runtime.InteropServices.OutAttribute)), this.self, StringToken.FindOrCreate(name), worldspace ? 1 : 0, ref tx, cskele_SBox_GetAttachment) > 0;
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x00035E6C File Offset: 0x0003406C
		internal readonly void SetHitboxSet(int setnum)
		{
			this.NullCheck("SetHitboxSet");
			method cskele_SetHitboxSet = CSkeletonInstance.__N.CSkele_SetHitboxSet;
			calli(System.Void(System.IntPtr,System.Int32), this.self, setnum, cskele_SetHitboxSet);
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00035E98 File Offset: 0x00034098
		internal readonly void SetHitboxSetByName(string pSetName)
		{
			this.NullCheck("SetHitboxSetByName");
			method cskele_SetHitboxSetByName = CSkeletonInstance.__N.CSkele_SetHitboxSetByName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pSetName), cskele_SetHitboxSetByName);
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x00035EC8 File Offset: 0x000340C8
		internal readonly int GetHitboxSet()
		{
			this.NullCheck("GetHitboxSet");
			method cskele_GetHitboxSet = CSkeletonInstance.__N.CSkele_GetHitboxSet;
			return calli(System.Int32(System.IntPtr), this.self, cskele_GetHitboxSet);
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x00035EF4 File Offset: 0x000340F4
		internal readonly string GetHitboxSetName()
		{
			this.NullCheck("GetHitboxSetName");
			method cskele_GetHitboxSetName = CSkeletonInstance.__N.CSkele_GetHitboxSetName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cskele_GetHitboxSetName));
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x00035F24 File Offset: 0x00034124
		internal readonly int GetHitboxSetCount()
		{
			this.NullCheck("GetHitboxSetCount");
			method cskele_GetHitboxSetCount = CSkeletonInstance.__N.CSkele_GetHitboxSetCount;
			return calli(System.Int32(System.IntPtr), this.self, cskele_GetHitboxSetCount);
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x00035F50 File Offset: 0x00034150
		internal readonly int GetBoneIndexForHitbox(int box)
		{
			this.NullCheck("GetBoneIndexForHitbox");
			method cskele_GetBoneIndexForHitbox = CSkeletonInstance.__N.CSkele_GetBoneIndexForHitbox;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, box, cskele_GetBoneIndexForHitbox);
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x00035F7C File Offset: 0x0003417C
		internal readonly int GetHitboxGroup(int box)
		{
			this.NullCheck("GetHitboxGroup");
			method cskele_GetHitboxGroup = CSkeletonInstance.__N.CSkele_GetHitboxGroup;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, box, cskele_GetHitboxGroup);
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x00035FA8 File Offset: 0x000341A8
		internal unsafe readonly void SBox_SetBoneOverride(string name, Transform tx)
		{
			this.NullCheck("SBox_SetBoneOverride");
			method cskele_SBox_SetBoneOverride = CSkeletonInstance.__N.CSkele_SBox_SetBoneOverride;
			calli(System.Void(System.IntPtr,System.UInt32,Transform*), this.self, StringToken.FindOrCreate(name), &tx, cskele_SBox_SetBoneOverride);
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x00035FDC File Offset: 0x000341DC
		internal unsafe readonly void SBox_SetBoneOverride(int boneId, Transform tx)
		{
			this.NullCheck("SBox_SetBoneOverride");
			method cskele_f = CSkeletonInstance.__N.CSkele_f2;
			calli(System.Void(System.IntPtr,System.Int32,Transform*), this.self, boneId, &tx, cskele_f);
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x0003600C File Offset: 0x0003420C
		internal readonly void SBox_ClearBoneOverride()
		{
			this.NullCheck("SBox_ClearBoneOverride");
			method cskele_SBox_ClearBoneOverride = CSkeletonInstance.__N.CSkele_SBox_ClearBoneOverride;
			calli(System.Void(System.IntPtr), this.self, cskele_SBox_ClearBoneOverride);
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x00036038 File Offset: 0x00034238
		internal readonly Vector3 GetLocalOrigin()
		{
			this.NullCheck("GetLocalOrigin");
			method cskele_GetLocalOrigin = CSkeletonInstance.__N.CSkele_GetLocalOrigin;
			return calli(Vector3(System.IntPtr), this.self, cskele_GetLocalOrigin);
		}

		// Token: 0x040000B4 RID: 180
		internal IntPtr self;

		// Token: 0x020001BD RID: 445
		internal static class __N
		{
			// Token: 0x04000E21 RID: 3617
			internal static method From_CGameSceneNode_To_CSkeletonInstance;

			// Token: 0x04000E22 RID: 3618
			internal static method To_CGameSceneNode_From_CSkeletonInstance;

			// Token: 0x04000E23 RID: 3619
			internal static method CSkele_SetRenderingEnabled;

			// Token: 0x04000E24 RID: 3620
			internal static method CSkele_IsRenderingEnabled;

			// Token: 0x04000E25 RID: 3621
			internal static method CSkele_SetAnimationEnabled;

			// Token: 0x04000E26 RID: 3622
			internal static method CSkele_IsAnimationEnabled;

			// Token: 0x04000E27 RID: 3623
			internal static method CSkele_IsRigidSkeleton;

			// Token: 0x04000E28 RID: 3624
			internal static method CSkele_HasPhysics;

			// Token: 0x04000E29 RID: 3625
			internal static method CSkele_HasRendering;

			// Token: 0x04000E2A RID: 3626
			internal static method CSkele_SetupPhysics;

			// Token: 0x04000E2B RID: 3627
			internal static method CSkele_CleanupPhysics;

			// Token: 0x04000E2C RID: 3628
			internal static method CSkele_CleanupCloth;

			// Token: 0x04000E2D RID: 3629
			internal static method CSkele_LookupBone;

			// Token: 0x04000E2E RID: 3630
			internal static method CSkele_GetNumBones;

			// Token: 0x04000E2F RID: 3631
			internal static method CSkele_GetRootBoneMergeBone;

			// Token: 0x04000E30 RID: 3632
			internal static method CSkele_GetAnimationStateParentSpaceTransform;

			// Token: 0x04000E31 RID: 3633
			internal static method CSkele_GetAnimationStateWorldSpaceTransform;

			// Token: 0x04000E32 RID: 3634
			internal static method CSkele_SBox_GetWorldspaceBones;

			// Token: 0x04000E33 RID: 3635
			internal static method CSkele_SBox_GetBoneParent;

			// Token: 0x04000E34 RID: 3636
			internal static method CSkele_SBox_GetBoneName;

			// Token: 0x04000E35 RID: 3637
			internal static method CSkele_SBox_SetBoneTransform;

			// Token: 0x04000E36 RID: 3638
			internal static method CSkele_SBox_GetBoneTransform;

			// Token: 0x04000E37 RID: 3639
			internal static method CSkele_Sbox_GetPhysicsBodyId;

			// Token: 0x04000E38 RID: 3640
			internal static method CSkele_Sbox_GetPhysicsBody;

			// Token: 0x04000E39 RID: 3641
			internal static method CSkele_Sbox_PhysicsBodyToBone;

			// Token: 0x04000E3A RID: 3642
			internal static method CSkele_SBox_ComputeBonesAtTime;

			// Token: 0x04000E3B RID: 3643
			internal static method CSkele_SBox_GetAttachment;

			// Token: 0x04000E3C RID: 3644
			internal static method CSkele_SetHitboxSet;

			// Token: 0x04000E3D RID: 3645
			internal static method CSkele_SetHitboxSetByName;

			// Token: 0x04000E3E RID: 3646
			internal static method CSkele_GetHitboxSet;

			// Token: 0x04000E3F RID: 3647
			internal static method CSkele_GetHitboxSetName;

			// Token: 0x04000E40 RID: 3648
			internal static method CSkele_GetHitboxSetCount;

			// Token: 0x04000E41 RID: 3649
			internal static method CSkele_GetBoneIndexForHitbox;

			// Token: 0x04000E42 RID: 3650
			internal static method CSkele_GetHitboxGroup;

			// Token: 0x04000E43 RID: 3651
			internal static method CSkele_SBox_SetBoneOverride;

			// Token: 0x04000E44 RID: 3652
			internal static method CSkele_f2;

			// Token: 0x04000E45 RID: 3653
			internal static method CSkele_SBox_ClearBoneOverride;

			// Token: 0x04000E46 RID: 3654
			internal static method CSkele_GetLocalOrigin;
		}
	}
}
