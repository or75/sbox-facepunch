using System;
using System.Runtime.CompilerServices;

namespace NativeEngine
{
	// Token: 0x0200022C RID: 556
	internal struct CUtlVectorString
	{
		// Token: 0x06000E31 RID: 3633 RVA: 0x0001911D File Offset: 0x0001731D
		public static implicit operator IntPtr(CUtlVectorString value)
		{
			return value.self;
		}

		// Token: 0x06000E32 RID: 3634 RVA: 0x00019128 File Offset: 0x00017328
		public static implicit operator CUtlVectorString(IntPtr value)
		{
			return new CUtlVectorString
			{
				self = value
			};
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x00019146 File Offset: 0x00017346
		public static bool operator ==(CUtlVectorString c1, CUtlVectorString c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000E34 RID: 3636 RVA: 0x00019159 File Offset: 0x00017359
		public static bool operator !=(CUtlVectorString c1, CUtlVectorString c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000E35 RID: 3637 RVA: 0x0001916C File Offset: 0x0001736C
		public override bool Equals(object obj)
		{
			if (obj is CUtlVectorString)
			{
				CUtlVectorString c = (CUtlVectorString)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000E36 RID: 3638 RVA: 0x00019196 File Offset: 0x00017396
		internal CUtlVectorString(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000E37 RID: 3639 RVA: 0x000191A0 File Offset: 0x000173A0
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CUtlVectorString ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x06000E38 RID: 3640 RVA: 0x000191DC File Offset: 0x000173DC
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x06000E39 RID: 3641 RVA: 0x000191EE File Offset: 0x000173EE
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000E3A RID: 3642 RVA: 0x000191F9 File Offset: 0x000173F9
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000E3B RID: 3643 RVA: 0x0001920C File Offset: 0x0001740C
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CUtlVectorString was null when calling " + n);
			}
		}

		// Token: 0x06000E3C RID: 3644 RVA: 0x00019227 File Offset: 0x00017427
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000E3D RID: 3645 RVA: 0x00019234 File Offset: 0x00017434
		internal readonly void DeleteThis()
		{
			this.NullCheck("DeleteThis");
			method cutlVe_DeleteThis = CUtlVectorString.__N.CUtlVe_DeleteThis;
			calli(System.Void(System.IntPtr), this.self, cutlVe_DeleteThis);
		}

		// Token: 0x06000E3E RID: 3646 RVA: 0x00019260 File Offset: 0x00017460
		internal static CUtlVectorString Create(int growsize, int initialcapacity)
		{
			method cutlVe_Create = CUtlVectorString.__N.CUtlVe_Create;
			return calli(System.IntPtr(System.Int32,System.Int32), growsize, initialcapacity, cutlVe_Create);
		}

		// Token: 0x06000E3F RID: 3647 RVA: 0x00019280 File Offset: 0x00017480
		internal readonly int Count()
		{
			this.NullCheck("Count");
			method cutlVe_Count = CUtlVectorString.__N.CUtlVe_Count;
			return calli(System.Int32(System.IntPtr), this.self, cutlVe_Count);
		}

		// Token: 0x06000E40 RID: 3648 RVA: 0x000192AC File Offset: 0x000174AC
		internal readonly CUtlString Element(int i)
		{
			this.NullCheck("Element");
			method cutlVe_Element = CUtlVectorString.__N.CUtlVe_Element;
			return calli(System.IntPtr(System.IntPtr,System.Int32), this.self, i, cutlVe_Element);
		}

		// Token: 0x04000E43 RID: 3651
		internal IntPtr self;

		// Token: 0x02000391 RID: 913
		internal static class __N
		{
			// Token: 0x0400182A RID: 6186
			internal static method CUtlVe_DeleteThis;

			// Token: 0x0400182B RID: 6187
			internal static method CUtlVe_Create;

			// Token: 0x0400182C RID: 6188
			internal static method CUtlVe_Count;

			// Token: 0x0400182D RID: 6189
			internal static method CUtlVe_Element;
		}
	}
}
