using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000222 RID: 546
	internal struct IModel
	{
		// Token: 0x06000D5A RID: 3418 RVA: 0x000175E3 File Offset: 0x000157E3
		public static implicit operator IntPtr(IModel value)
		{
			return value.self;
		}

		// Token: 0x06000D5B RID: 3419 RVA: 0x000175EC File Offset: 0x000157EC
		public static implicit operator IModel(IntPtr value)
		{
			return new IModel
			{
				self = value
			};
		}

		// Token: 0x06000D5C RID: 3420 RVA: 0x0001760A File Offset: 0x0001580A
		public static bool operator ==(IModel c1, IModel c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000D5D RID: 3421 RVA: 0x0001761D File Offset: 0x0001581D
		public static bool operator !=(IModel c1, IModel c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000D5E RID: 3422 RVA: 0x00017630 File Offset: 0x00015830
		public override bool Equals(object obj)
		{
			if (obj is IModel)
			{
				IModel c = (IModel)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000D5F RID: 3423 RVA: 0x0001765A File Offset: 0x0001585A
		internal IModel(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000D60 RID: 3424 RVA: 0x00017664 File Offset: 0x00015864
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
			defaultInterpolatedStringHandler.AppendLiteral("IModel ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x06000D61 RID: 3425 RVA: 0x0001769F File Offset: 0x0001589F
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06000D62 RID: 3426 RVA: 0x000176B1 File Offset: 0x000158B1
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000D63 RID: 3427 RVA: 0x000176BC File Offset: 0x000158BC
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000D64 RID: 3428 RVA: 0x000176CF File Offset: 0x000158CF
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("IModel was null when calling " + n);
			}
		}

		// Token: 0x06000D65 RID: 3429 RVA: 0x000176EA File Offset: 0x000158EA
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000D66 RID: 3430 RVA: 0x000176F8 File Offset: 0x000158F8
		internal readonly void DestroyStrongHandle()
		{
			this.NullCheck("DestroyStrongHandle");
			method cmodel_DestroyStrongHandle = IModel.__N.CModel_DestroyStrongHandle;
			calli(System.Void(System.IntPtr), this.self, cmodel_DestroyStrongHandle);
		}

		// Token: 0x06000D67 RID: 3431 RVA: 0x00017724 File Offset: 0x00015924
		internal readonly bool IsStrongHandleValid()
		{
			this.NullCheck("IsStrongHandleValid");
			method cmodel_IsStrongHandleValid = IModel.__N.CModel_IsStrongHandleValid;
			return calli(System.Int32(System.IntPtr), this.self, cmodel_IsStrongHandleValid) > 0;
		}

		// Token: 0x06000D68 RID: 3432 RVA: 0x00017754 File Offset: 0x00015954
		internal readonly bool IsStrongHandleLoaded()
		{
			this.NullCheck("IsStrongHandleLoaded");
			method cmodel_IsStrongHandleLoaded = IModel.__N.CModel_IsStrongHandleLoaded;
			return calli(System.Int32(System.IntPtr), this.self, cmodel_IsStrongHandleLoaded) > 0;
		}

		// Token: 0x06000D69 RID: 3433 RVA: 0x00017784 File Offset: 0x00015984
		internal readonly IModel CopyStrongHandle()
		{
			this.NullCheck("CopyStrongHandle");
			method cmodel_CopyStrongHandle = IModel.__N.CModel_CopyStrongHandle;
			return calli(System.IntPtr(System.IntPtr), this.self, cmodel_CopyStrongHandle);
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x000177B4 File Offset: 0x000159B4
		internal readonly IntPtr GetBindingPtr()
		{
			this.NullCheck("GetBindingPtr");
			method cmodel_GetBindingPtr = IModel.__N.CModel_GetBindingPtr;
			return calli(System.IntPtr(System.IntPtr), this.self, cmodel_GetBindingPtr);
		}

		// Token: 0x06000D6B RID: 3435 RVA: 0x000177E0 File Offset: 0x000159E0
		internal readonly string GetModelName()
		{
			this.NullCheck("GetModelName");
			method cmodel_GetModelName = IModel.__N.CModel_GetModelName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cmodel_GetModelName));
		}

		// Token: 0x06000D6C RID: 3436 RVA: 0x00017810 File Offset: 0x00015A10
		internal readonly bool IsTranslucent()
		{
			this.NullCheck("IsTranslucent");
			method cmodel_IsTranslucent = IModel.__N.CModel_IsTranslucent;
			return calli(System.Int32(System.IntPtr), this.self, cmodel_IsTranslucent) > 0;
		}

		// Token: 0x06000D6D RID: 3437 RVA: 0x00017840 File Offset: 0x00015A40
		internal readonly bool IsTranslucentTwoPass()
		{
			this.NullCheck("IsTranslucentTwoPass");
			method cmodel_IsTranslucentTwoPass = IModel.__N.CModel_IsTranslucentTwoPass;
			return calli(System.Int32(System.IntPtr), this.self, cmodel_IsTranslucentTwoPass) > 0;
		}

		// Token: 0x06000D6E RID: 3438 RVA: 0x00017870 File Offset: 0x00015A70
		internal readonly bool HasPhysics()
		{
			this.NullCheck("HasPhysics");
			method cmodel_HasPhysics = IModel.__N.CModel_HasPhysics;
			return calli(System.Int32(System.IntPtr), this.self, cmodel_HasPhysics) > 0;
		}

		// Token: 0x06000D6F RID: 3439 RVA: 0x000178A0 File Offset: 0x00015AA0
		internal readonly bool HasCloth()
		{
			this.NullCheck("HasCloth");
			method cmodel_HasCloth = IModel.__N.CModel_HasCloth;
			return calli(System.Int32(System.IntPtr), this.self, cmodel_HasCloth) > 0;
		}

		// Token: 0x06000D70 RID: 3440 RVA: 0x000178D0 File Offset: 0x00015AD0
		internal readonly KeyValues3 FindModelSubKey(string name)
		{
			this.NullCheck("FindModelSubKey");
			method cmodel_FindModelSubKey = IModel.__N.CModel_FindModelSubKey;
			return calli(System.IntPtr(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cmodel_FindModelSubKey);
		}

		// Token: 0x06000D71 RID: 3441 RVA: 0x00017908 File Offset: 0x00015B08
		internal readonly bool GetAttachmentTransform(string name, out Transform tx)
		{
			this.NullCheck("GetAttachmentTransform");
			method cmodel_GetAttachmentTransform = IModel.__N.CModel_GetAttachmentTransform;
			return calli(System.Int32(System.IntPtr,System.UInt32,Transform& modreq(System.Runtime.InteropServices.OutAttribute)), this.self, StringToken.FindOrCreate(name), ref tx, cmodel_GetAttachmentTransform) > 0;
		}

		// Token: 0x06000D72 RID: 3442 RVA: 0x0001793C File Offset: 0x00015B3C
		internal readonly int GetNumAttachments()
		{
			this.NullCheck("GetNumAttachments");
			method cmodel_GetNumAttachments = IModel.__N.CModel_GetNumAttachments;
			return calli(System.Int32(System.IntPtr), this.self, cmodel_GetNumAttachments);
		}

		// Token: 0x06000D73 RID: 3443 RVA: 0x00017968 File Offset: 0x00015B68
		internal readonly string GetAttachmentNameFromIndex(int index)
		{
			this.NullCheck("GetAttachmentNameFromIndex");
			method cmodel_GetAttachmentNameFromIndex = IModel.__N.CModel_GetAttachmentNameFromIndex;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr,System.Int32), this.self, index, cmodel_GetAttachmentNameFromIndex));
		}

		// Token: 0x06000D74 RID: 3444 RVA: 0x00017998 File Offset: 0x00015B98
		internal readonly int GetBodyPartForName(string pName)
		{
			this.NullCheck("GetBodyPartForName");
			method cmodel_GetBodyPartForName = IModel.__N.CModel_GetBodyPartForName;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pName), cmodel_GetBodyPartForName);
		}

		// Token: 0x06000D75 RID: 3445 RVA: 0x000179C8 File Offset: 0x00015BC8
		internal readonly string GetBodyPartName(int nPart)
		{
			this.NullCheck("GetBodyPartName");
			method cmodel_GetBodyPartName = IModel.__N.CModel_GetBodyPartName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr,System.Int32), this.self, nPart, cmodel_GetBodyPartName));
		}

		// Token: 0x06000D76 RID: 3446 RVA: 0x000179F8 File Offset: 0x00015BF8
		internal readonly int GetNumBodyParts()
		{
			this.NullCheck("GetNumBodyParts");
			method cmodel_GetNumBodyParts = IModel.__N.CModel_GetNumBodyParts;
			return calli(System.Int32(System.IntPtr), this.self, cmodel_GetNumBodyParts);
		}

		// Token: 0x06000D77 RID: 3447 RVA: 0x00017A24 File Offset: 0x00015C24
		internal readonly int GetNumBodyPartMeshes(int nPart)
		{
			this.NullCheck("GetNumBodyPartMeshes");
			method cmodel_GetNumBodyPartMeshes = IModel.__N.CModel_GetNumBodyPartMeshes;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, nPart, cmodel_GetNumBodyPartMeshes);
		}

		// Token: 0x06000D78 RID: 3448 RVA: 0x00017A50 File Offset: 0x00015C50
		internal readonly ulong GetBodyPartMask(int nPart)
		{
			this.NullCheck("GetBodyPartMask");
			method cmodel_GetBodyPartMask = IModel.__N.CModel_GetBodyPartMask;
			return calli(System.UInt64(System.IntPtr,System.Int32), this.self, nPart, cmodel_GetBodyPartMask);
		}

		// Token: 0x06000D79 RID: 3449 RVA: 0x00017A7C File Offset: 0x00015C7C
		internal readonly ulong GetBodyPartMeshMask(int nPart, int nMesh)
		{
			this.NullCheck("GetBodyPartMeshMask");
			method cmodel_GetBodyPartMeshMask = IModel.__N.CModel_GetBodyPartMeshMask;
			return calli(System.UInt64(System.IntPtr,System.Int32,System.Int32), this.self, nPart, nMesh, cmodel_GetBodyPartMeshMask);
		}

		// Token: 0x06000D7A RID: 3450 RVA: 0x00017AA8 File Offset: 0x00015CA8
		internal readonly int FindMeshIndexForMask(int nPart, ulong nMask)
		{
			this.NullCheck("FindMeshIndexForMask");
			method cmodel_FindMeshIndexForMask = IModel.__N.CModel_FindMeshIndexForMask;
			return calli(System.Int32(System.IntPtr,System.Int32,System.UInt64), this.self, nPart, nMask, cmodel_FindMeshIndexForMask);
		}

		// Token: 0x06000D7B RID: 3451 RVA: 0x00017AD4 File Offset: 0x00015CD4
		internal readonly int GetNumMeshes()
		{
			this.NullCheck("GetNumMeshes");
			method cmodel_GetNumMeshes = IModel.__N.CModel_GetNumMeshes;
			return calli(System.Int32(System.IntPtr), this.self, cmodel_GetNumMeshes);
		}

		// Token: 0x06000D7C RID: 3452 RVA: 0x00017B00 File Offset: 0x00015D00
		internal readonly BBox GetMeshBounds()
		{
			this.NullCheck("GetMeshBounds");
			method cmodel_GetMeshBounds = IModel.__N.CModel_GetMeshBounds;
			return calli(BBox(System.IntPtr), this.self, cmodel_GetMeshBounds);
		}

		// Token: 0x06000D7D RID: 3453 RVA: 0x00017B2C File Offset: 0x00015D2C
		internal readonly BBox GetPhysicsBounds()
		{
			this.NullCheck("GetPhysicsBounds");
			method cmodel_GetPhysicsBounds = IModel.__N.CModel_GetPhysicsBounds;
			return calli(BBox(System.IntPtr), this.self, cmodel_GetPhysicsBounds);
		}

		// Token: 0x06000D7E RID: 3454 RVA: 0x00017B58 File Offset: 0x00015D58
		internal readonly BBox GetModelRenderBounds()
		{
			this.NullCheck("GetModelRenderBounds");
			method cmodel_GetModelRenderBounds = IModel.__N.CModel_GetModelRenderBounds;
			return calli(BBox(System.IntPtr), this.self, cmodel_GetModelRenderBounds);
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x00017B84 File Offset: 0x00015D84
		internal readonly int NumBones()
		{
			this.NullCheck("NumBones");
			method cmodel_NumBones = IModel.__N.CModel_NumBones;
			return calli(System.Int32(System.IntPtr), this.self, cmodel_NumBones);
		}

		// Token: 0x06000D80 RID: 3456 RVA: 0x00017BB0 File Offset: 0x00015DB0
		internal readonly string boneName(int iBone)
		{
			this.NullCheck("boneName");
			method cmodel_boneName = IModel.__N.CModel_boneName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr,System.Int32), this.self, iBone, cmodel_boneName));
		}

		// Token: 0x06000D81 RID: 3457 RVA: 0x00017BE0 File Offset: 0x00015DE0
		internal readonly int boneParent(int iBone)
		{
			this.NullCheck("boneParent");
			method cmodel_boneParent = IModel.__N.CModel_boneParent;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, iBone, cmodel_boneParent);
		}

		// Token: 0x06000D82 RID: 3458 RVA: 0x00017C0C File Offset: 0x00015E0C
		internal readonly Vector3 bonePosParentSpace(int iBone)
		{
			this.NullCheck("bonePosParentSpace");
			method cmodel_bonePosParentSpace = IModel.__N.CModel_bonePosParentSpace;
			return calli(Vector3(System.IntPtr,System.Int32), this.self, iBone, cmodel_bonePosParentSpace);
		}

		// Token: 0x06000D83 RID: 3459 RVA: 0x00017C38 File Offset: 0x00015E38
		internal readonly Rotation boneRotParentSpace(int iBone)
		{
			this.NullCheck("boneRotParentSpace");
			method cmodel_boneRotParentSpace = IModel.__N.CModel_boneRotParentSpace;
			return calli(Rotation(System.IntPtr,System.Int32), this.self, iBone, cmodel_boneRotParentSpace);
		}

		// Token: 0x04000E39 RID: 3641
		internal IntPtr self;

		// Token: 0x02000387 RID: 903
		internal static class __N
		{
			// Token: 0x040017CB RID: 6091
			internal static method CModel_DestroyStrongHandle;

			// Token: 0x040017CC RID: 6092
			internal static method CModel_IsStrongHandleValid;

			// Token: 0x040017CD RID: 6093
			internal static method CModel_IsStrongHandleLoaded;

			// Token: 0x040017CE RID: 6094
			internal static method CModel_CopyStrongHandle;

			// Token: 0x040017CF RID: 6095
			internal static method CModel_GetBindingPtr;

			// Token: 0x040017D0 RID: 6096
			internal static method CModel_GetModelName;

			// Token: 0x040017D1 RID: 6097
			internal static method CModel_IsTranslucent;

			// Token: 0x040017D2 RID: 6098
			internal static method CModel_IsTranslucentTwoPass;

			// Token: 0x040017D3 RID: 6099
			internal static method CModel_HasPhysics;

			// Token: 0x040017D4 RID: 6100
			internal static method CModel_HasCloth;

			// Token: 0x040017D5 RID: 6101
			internal static method CModel_FindModelSubKey;

			// Token: 0x040017D6 RID: 6102
			internal static method CModel_GetAttachmentTransform;

			// Token: 0x040017D7 RID: 6103
			internal static method CModel_GetNumAttachments;

			// Token: 0x040017D8 RID: 6104
			internal static method CModel_GetAttachmentNameFromIndex;

			// Token: 0x040017D9 RID: 6105
			internal static method CModel_GetBodyPartForName;

			// Token: 0x040017DA RID: 6106
			internal static method CModel_GetBodyPartName;

			// Token: 0x040017DB RID: 6107
			internal static method CModel_GetNumBodyParts;

			// Token: 0x040017DC RID: 6108
			internal static method CModel_GetNumBodyPartMeshes;

			// Token: 0x040017DD RID: 6109
			internal static method CModel_GetBodyPartMask;

			// Token: 0x040017DE RID: 6110
			internal static method CModel_GetBodyPartMeshMask;

			// Token: 0x040017DF RID: 6111
			internal static method CModel_FindMeshIndexForMask;

			// Token: 0x040017E0 RID: 6112
			internal static method CModel_GetNumMeshes;

			// Token: 0x040017E1 RID: 6113
			internal static method CModel_GetMeshBounds;

			// Token: 0x040017E2 RID: 6114
			internal static method CModel_GetPhysicsBounds;

			// Token: 0x040017E3 RID: 6115
			internal static method CModel_GetModelRenderBounds;

			// Token: 0x040017E4 RID: 6116
			internal static method CModel_NumBones;

			// Token: 0x040017E5 RID: 6117
			internal static method CModel_boneName;

			// Token: 0x040017E6 RID: 6118
			internal static method CModel_boneParent;

			// Token: 0x040017E7 RID: 6119
			internal static method CModel_bonePosParentSpace;

			// Token: 0x040017E8 RID: 6120
			internal static method CModel_boneRotParentSpace;
		}
	}
}
