using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000051 RID: 81
	internal struct IPhysicsShape
	{
		// Token: 0x06000B1C RID: 2844 RVA: 0x0003B63B File Offset: 0x0003983B
		public static implicit operator IntPtr(IPhysicsShape value)
		{
			return value.self;
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x0003B644 File Offset: 0x00039844
		public static implicit operator IPhysicsShape(IntPtr value)
		{
			return new IPhysicsShape
			{
				self = value
			};
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x0003B662 File Offset: 0x00039862
		public static bool operator ==(IPhysicsShape c1, IPhysicsShape c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x0003B675 File Offset: 0x00039875
		public static bool operator !=(IPhysicsShape c1, IPhysicsShape c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x0003B688 File Offset: 0x00039888
		public override bool Equals(object obj)
		{
			if (obj is IPhysicsShape)
			{
				IPhysicsShape c = (IPhysicsShape)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x0003B6B2 File Offset: 0x000398B2
		internal IPhysicsShape(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x0003B6BC File Offset: 0x000398BC
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
			defaultInterpolatedStringHandler.AppendLiteral("IPhysicsShape ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000B23 RID: 2851 RVA: 0x0003B6F8 File Offset: 0x000398F8
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000B24 RID: 2852 RVA: 0x0003B70A File Offset: 0x0003990A
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x0003B715 File Offset: 0x00039915
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x0003B728 File Offset: 0x00039928
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("IPhysicsShape was null when calling " + n);
			}
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x0003B743 File Offset: 0x00039943
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x0003B750 File Offset: 0x00039950
		internal readonly void SetCollisionGroup(byte nCollisionGroup)
		{
			this.NullCheck("SetCollisionGroup");
			method iphysc_SetCollisionGroup = IPhysicsShape.__N.IPhysc_SetCollisionGroup;
			calli(System.Void(System.IntPtr,System.Byte), this.self, nCollisionGroup, iphysc_SetCollisionGroup);
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x0003B77C File Offset: 0x0003997C
		internal readonly byte GetCollisionGroup()
		{
			this.NullCheck("GetCollisionGroup");
			method iphysc_GetCollisionGroup = IPhysicsShape.__N.IPhysc_GetCollisionGroup;
			return calli(System.Byte(System.IntPtr), this.self, iphysc_GetCollisionGroup);
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x0003B7A8 File Offset: 0x000399A8
		internal readonly void EnableInteractsAsLayer(int nLayerIndex)
		{
			this.NullCheck("EnableInteractsAsLayer");
			method iphysc_EnableInteractsAsLayer = IPhysicsShape.__N.IPhysc_EnableInteractsAsLayer;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nLayerIndex, iphysc_EnableInteractsAsLayer);
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x0003B7D4 File Offset: 0x000399D4
		internal readonly void DisableInteractsAsLayer(int nLayerIndex)
		{
			this.NullCheck("DisableInteractsAsLayer");
			method iphysc_DisableInteractsAsLayer = IPhysicsShape.__N.IPhysc_DisableInteractsAsLayer;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nLayerIndex, iphysc_DisableInteractsAsLayer);
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x0003B800 File Offset: 0x00039A00
		internal readonly void EnableInteractsWithLayer(int nLayerIndex)
		{
			this.NullCheck("EnableInteractsWithLayer");
			method iphysc_EnableInteractsWithLayer = IPhysicsShape.__N.IPhysc_EnableInteractsWithLayer;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nLayerIndex, iphysc_EnableInteractsWithLayer);
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x0003B82C File Offset: 0x00039A2C
		internal readonly void DisableInteractsWithLayer(int nLayerIndex)
		{
			this.NullCheck("DisableInteractsWithLayer");
			method iphysc_DisableInteractsWithLayer = IPhysicsShape.__N.IPhysc_DisableInteractsWithLayer;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nLayerIndex, iphysc_DisableInteractsWithLayer);
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x0003B858 File Offset: 0x00039A58
		internal readonly void EnableInteractsExcludeLayer(int nLayerIndex)
		{
			this.NullCheck("EnableInteractsExcludeLayer");
			method iphysc_EnableInteractsExcludeLayer = IPhysicsShape.__N.IPhysc_EnableInteractsExcludeLayer;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nLayerIndex, iphysc_EnableInteractsExcludeLayer);
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x0003B884 File Offset: 0x00039A84
		internal readonly void DisableInteractsExcludeLayer(int nLayerIndex)
		{
			this.NullCheck("DisableInteractsExcludeLayer");
			method iphysc_DisableInteractsExcludeLayer = IPhysicsShape.__N.IPhysc_DisableInteractsExcludeLayer;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nLayerIndex, iphysc_DisableInteractsExcludeLayer);
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x0003B8B0 File Offset: 0x00039AB0
		internal readonly void AddCollisionFunctionMask(byte nMask)
		{
			this.NullCheck("AddCollisionFunctionMask");
			method iphysc_AddCollisionFunctionMask = IPhysicsShape.__N.IPhysc_AddCollisionFunctionMask;
			calli(System.Void(System.IntPtr,System.Byte), this.self, nMask, iphysc_AddCollisionFunctionMask);
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x0003B8DC File Offset: 0x00039ADC
		internal readonly void RemoveCollisionFunctionMask(byte nMask)
		{
			this.NullCheck("RemoveCollisionFunctionMask");
			method iphysc_RemoveCollisionFunctionMask = IPhysicsShape.__N.IPhysc_RemoveCollisionFunctionMask;
			calli(System.Void(System.IntPtr,System.Byte), this.self, nMask, iphysc_RemoveCollisionFunctionMask);
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x0003B908 File Offset: 0x00039B08
		internal readonly PhysicsBody GetOwnerBody()
		{
			this.NullCheck("GetOwnerBody");
			method iphysc_GetOwnerBody = IPhysicsShape.__N.IPhysc_GetOwnerBody;
			return HandleIndex.Get<PhysicsBody>(calli(System.Int32(System.IntPtr), this.self, iphysc_GetOwnerBody));
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x0003B938 File Offset: 0x00039B38
		internal readonly Vector3 GetScale()
		{
			this.NullCheck("GetScale");
			method iphysc_f = IPhysicsShape.__N.IPhysc_f5;
			return calli(Vector3(System.IntPtr), this.self, iphysc_f);
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x0003B964 File Offset: 0x00039B64
		internal readonly void SetMaterialIndex(string name)
		{
			this.NullCheck("SetMaterialIndex");
			method iphysc_f = IPhysicsShape.__N.IPhysc_f6;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(name), iphysc_f);
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x0003B994 File Offset: 0x00039B94
		internal readonly PhysicsShapeType GetType_Native()
		{
			this.NullCheck("GetType_Native");
			method iphysc_f = IPhysicsShape.__N.IPhysc_f7;
			return calli(System.Int64(System.IntPtr), this.self, iphysc_f);
		}

		// Token: 0x040000BF RID: 191
		internal IntPtr self;

		// Token: 0x020001D6 RID: 470
		internal static class __N
		{
			// Token: 0x04000FFB RID: 4091
			internal static method IPhysc_SetCollisionGroup;

			// Token: 0x04000FFC RID: 4092
			internal static method IPhysc_GetCollisionGroup;

			// Token: 0x04000FFD RID: 4093
			internal static method IPhysc_EnableInteractsAsLayer;

			// Token: 0x04000FFE RID: 4094
			internal static method IPhysc_DisableInteractsAsLayer;

			// Token: 0x04000FFF RID: 4095
			internal static method IPhysc_EnableInteractsWithLayer;

			// Token: 0x04001000 RID: 4096
			internal static method IPhysc_DisableInteractsWithLayer;

			// Token: 0x04001001 RID: 4097
			internal static method IPhysc_EnableInteractsExcludeLayer;

			// Token: 0x04001002 RID: 4098
			internal static method IPhysc_DisableInteractsExcludeLayer;

			// Token: 0x04001003 RID: 4099
			internal static method IPhysc_AddCollisionFunctionMask;

			// Token: 0x04001004 RID: 4100
			internal static method IPhysc_RemoveCollisionFunctionMask;

			// Token: 0x04001005 RID: 4101
			internal static method IPhysc_GetOwnerBody;

			// Token: 0x04001006 RID: 4102
			internal static method IPhysc_f5;

			// Token: 0x04001007 RID: 4103
			internal static method IPhysc_f6;

			// Token: 0x04001008 RID: 4104
			internal static method IPhysc_f7;
		}
	}
}
