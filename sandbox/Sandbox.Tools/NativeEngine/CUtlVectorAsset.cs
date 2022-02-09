using System;
using System.Runtime.CompilerServices;

namespace NativeEngine
{
	// Token: 0x0200006C RID: 108
	internal struct CUtlVectorAsset
	{
		// Token: 0x06001260 RID: 4704 RVA: 0x00050550 File Offset: 0x0004E750
		public static implicit operator IntPtr(CUtlVectorAsset value)
		{
			return value.self;
		}

		// Token: 0x06001261 RID: 4705 RVA: 0x00050558 File Offset: 0x0004E758
		public static implicit operator CUtlVectorAsset(IntPtr value)
		{
			return new CUtlVectorAsset
			{
				self = value
			};
		}

		// Token: 0x06001262 RID: 4706 RVA: 0x00050576 File Offset: 0x0004E776
		public static bool operator ==(CUtlVectorAsset c1, CUtlVectorAsset c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06001263 RID: 4707 RVA: 0x00050589 File Offset: 0x0004E789
		public static bool operator !=(CUtlVectorAsset c1, CUtlVectorAsset c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06001264 RID: 4708 RVA: 0x0005059C File Offset: 0x0004E79C
		public override bool Equals(object obj)
		{
			if (obj is CUtlVectorAsset)
			{
				CUtlVectorAsset c = (CUtlVectorAsset)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06001265 RID: 4709 RVA: 0x000505C6 File Offset: 0x0004E7C6
		internal CUtlVectorAsset(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06001266 RID: 4710 RVA: 0x000505D0 File Offset: 0x0004E7D0
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CUtlVectorAsset ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06001267 RID: 4711 RVA: 0x0005060C File Offset: 0x0004E80C
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06001268 RID: 4712 RVA: 0x0005061E File Offset: 0x0004E81E
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06001269 RID: 4713 RVA: 0x00050629 File Offset: 0x0004E829
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x0600126A RID: 4714 RVA: 0x0005063C File Offset: 0x0004E83C
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CUtlVectorAsset was null when calling " + n);
			}
		}

		// Token: 0x0600126B RID: 4715 RVA: 0x00050657 File Offset: 0x0004E857
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x0600126C RID: 4716 RVA: 0x00050664 File Offset: 0x0004E864
		internal readonly void DeleteThis()
		{
			this.NullCheck("DeleteThis");
			method cutlVe_DeleteThis = CUtlVectorAsset.__N.CUtlVe_DeleteThis;
			calli(System.Void(System.IntPtr), this.self, cutlVe_DeleteThis);
		}

		// Token: 0x0600126D RID: 4717 RVA: 0x00050690 File Offset: 0x0004E890
		internal static CUtlVectorAsset Create(int growsize, int initialcapacity)
		{
			method cutlVe_Create = CUtlVectorAsset.__N.CUtlVe_Create;
			return calli(System.IntPtr(System.Int32,System.Int32), growsize, initialcapacity, cutlVe_Create);
		}

		// Token: 0x0600126E RID: 4718 RVA: 0x000506B0 File Offset: 0x0004E8B0
		internal readonly int Count()
		{
			this.NullCheck("Count");
			method cutlVe_Count = CUtlVectorAsset.__N.CUtlVe_Count;
			return calli(System.Int32(System.IntPtr), this.self, cutlVe_Count);
		}

		// Token: 0x0600126F RID: 4719 RVA: 0x000506DC File Offset: 0x0004E8DC
		internal readonly IAsset Element(int i)
		{
			this.NullCheck("Element");
			method cutlVe_Element = CUtlVectorAsset.__N.CUtlVe_Element;
			return calli(System.IntPtr(System.IntPtr,System.Int32), this.self, i, cutlVe_Element);
		}

		// Token: 0x04000160 RID: 352
		internal IntPtr self;

		// Token: 0x0200012E RID: 302
		internal static class __N
		{
			// Token: 0x04001241 RID: 4673
			internal static method CUtlVe_DeleteThis;

			// Token: 0x04001242 RID: 4674
			internal static method CUtlVe_Create;

			// Token: 0x04001243 RID: 4675
			internal static method CUtlVe_Count;

			// Token: 0x04001244 RID: 4676
			internal static method CUtlVe_Element;
		}
	}
}
