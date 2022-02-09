using System;
using System.Runtime.CompilerServices;

namespace NativeEngine
{
	// Token: 0x0200003B RID: 59
	internal struct CUtlVectorOverlapResult
	{
		// Token: 0x0600090C RID: 2316 RVA: 0x0003632F File Offset: 0x0003452F
		public static implicit operator IntPtr(CUtlVectorOverlapResult value)
		{
			return value.self;
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x00036338 File Offset: 0x00034538
		public static implicit operator CUtlVectorOverlapResult(IntPtr value)
		{
			return new CUtlVectorOverlapResult
			{
				self = value
			};
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x00036356 File Offset: 0x00034556
		public static bool operator ==(CUtlVectorOverlapResult c1, CUtlVectorOverlapResult c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x00036369 File Offset: 0x00034569
		public static bool operator !=(CUtlVectorOverlapResult c1, CUtlVectorOverlapResult c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x0003637C File Offset: 0x0003457C
		public override bool Equals(object obj)
		{
			if (obj is CUtlVectorOverlapResult)
			{
				CUtlVectorOverlapResult c = (CUtlVectorOverlapResult)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x000363A6 File Offset: 0x000345A6
		internal CUtlVectorOverlapResult(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x000363B0 File Offset: 0x000345B0
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CUtlVectorOverlapResult ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000913 RID: 2323 RVA: 0x000363EC File Offset: 0x000345EC
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000914 RID: 2324 RVA: 0x000363FE File Offset: 0x000345FE
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x00036409 File Offset: 0x00034609
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x0003641C File Offset: 0x0003461C
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CUtlVectorOverlapResult was null when calling " + n);
			}
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x00036437 File Offset: 0x00034637
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x00036444 File Offset: 0x00034644
		internal readonly void DeleteThis()
		{
			this.NullCheck("DeleteThis");
			method cutlVe_Overlp_DeleteThis = CUtlVectorOverlapResult.__N.CUtlVe_Overlp_DeleteThis;
			calli(System.Void(System.IntPtr), this.self, cutlVe_Overlp_DeleteThis);
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x00036470 File Offset: 0x00034670
		internal static CUtlVectorOverlapResult Create(int growsize, int initialcapacity)
		{
			method cutlVe_Overlp_Create = CUtlVectorOverlapResult.__N.CUtlVe_Overlp_Create;
			return calli(System.IntPtr(System.Int32,System.Int32), growsize, initialcapacity, cutlVe_Overlp_Create);
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x00036490 File Offset: 0x00034690
		internal readonly int Count()
		{
			this.NullCheck("Count");
			method cutlVe_Overlp_Count = CUtlVectorOverlapResult.__N.CUtlVe_Overlp_Count;
			return calli(System.Int32(System.IntPtr), this.self, cutlVe_Overlp_Count);
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x000364BC File Offset: 0x000346BC
		internal readonly OverlapResult Element(int i)
		{
			this.NullCheck("Element");
			method cutlVe_Overlp_Element = CUtlVectorOverlapResult.__N.CUtlVe_Overlp_Element;
			return calli(NativeEngine.OverlapResult(System.IntPtr,System.Int32), this.self, i, cutlVe_Overlp_Element);
		}

		// Token: 0x040000B7 RID: 183
		internal IntPtr self;

		// Token: 0x020001C0 RID: 448
		internal static class __N
		{
			// Token: 0x04000E4B RID: 3659
			internal static method CUtlVe_Overlp_DeleteThis;

			// Token: 0x04000E4C RID: 3660
			internal static method CUtlVe_Overlp_Create;

			// Token: 0x04000E4D RID: 3661
			internal static method CUtlVe_Overlp_Count;

			// Token: 0x04000E4E RID: 3662
			internal static method CUtlVe_Overlp_Element;
		}
	}
}
