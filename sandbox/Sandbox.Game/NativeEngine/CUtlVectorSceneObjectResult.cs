using System;
using System.Runtime.CompilerServices;

namespace NativeEngine
{
	// Token: 0x0200003A RID: 58
	internal struct CUtlVectorSceneObjectResult
	{
		// Token: 0x060008FC RID: 2300 RVA: 0x00036178 File Offset: 0x00034378
		public static implicit operator IntPtr(CUtlVectorSceneObjectResult value)
		{
			return value.self;
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x00036180 File Offset: 0x00034380
		public static implicit operator CUtlVectorSceneObjectResult(IntPtr value)
		{
			return new CUtlVectorSceneObjectResult
			{
				self = value
			};
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x0003619E File Offset: 0x0003439E
		public static bool operator ==(CUtlVectorSceneObjectResult c1, CUtlVectorSceneObjectResult c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x000361B1 File Offset: 0x000343B1
		public static bool operator !=(CUtlVectorSceneObjectResult c1, CUtlVectorSceneObjectResult c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x000361C4 File Offset: 0x000343C4
		public override bool Equals(object obj)
		{
			if (obj is CUtlVectorSceneObjectResult)
			{
				CUtlVectorSceneObjectResult c = (CUtlVectorSceneObjectResult)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x000361EE File Offset: 0x000343EE
		internal CUtlVectorSceneObjectResult(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x000361F8 File Offset: 0x000343F8
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CUtlVectorSceneObjectResult ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000903 RID: 2307 RVA: 0x00036234 File Offset: 0x00034434
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000904 RID: 2308 RVA: 0x00036246 File Offset: 0x00034446
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x00036251 File Offset: 0x00034451
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x00036264 File Offset: 0x00034464
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CUtlVectorSceneObjectResult was null when calling " + n);
			}
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x0003627F File Offset: 0x0003447F
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x0003628C File Offset: 0x0003448C
		internal readonly void DeleteThis()
		{
			this.NullCheck("DeleteThis");
			method cutlVe_f = CUtlVectorSceneObjectResult.__N.CUtlVe_f2;
			calli(System.Void(System.IntPtr), this.self, cutlVe_f);
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x000362B8 File Offset: 0x000344B8
		internal static CUtlVectorSceneObjectResult Create(int growsize, int initialcapacity)
		{
			method cutlVe_f = CUtlVectorSceneObjectResult.__N.CUtlVe_f3;
			return calli(System.IntPtr(System.Int32,System.Int32), growsize, initialcapacity, cutlVe_f);
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x000362D8 File Offset: 0x000344D8
		internal readonly int Count()
		{
			this.NullCheck("Count");
			method cutlVe_f = CUtlVectorSceneObjectResult.__N.CUtlVe_f4;
			return calli(System.Int32(System.IntPtr), this.self, cutlVe_f);
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x00036304 File Offset: 0x00034504
		internal readonly int Element(int i)
		{
			this.NullCheck("Element");
			method cutlVe_f = CUtlVectorSceneObjectResult.__N.CUtlVe_f5;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, i, cutlVe_f);
		}

		// Token: 0x040000B6 RID: 182
		internal IntPtr self;

		// Token: 0x020001BF RID: 447
		internal static class __N
		{
			// Token: 0x04000E47 RID: 3655
			internal static method CUtlVe_f2;

			// Token: 0x04000E48 RID: 3656
			internal static method CUtlVe_f3;

			// Token: 0x04000E49 RID: 3657
			internal static method CUtlVe_f4;

			// Token: 0x04000E4A RID: 3658
			internal static method CUtlVe_f5;
		}
	}
}
