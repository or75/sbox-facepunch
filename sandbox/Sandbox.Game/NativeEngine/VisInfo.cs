using System;
using System.Runtime.CompilerServices;

namespace NativeEngine
{
	// Token: 0x02000059 RID: 89
	internal struct VisInfo
	{
		// Token: 0x06000BA9 RID: 2985 RVA: 0x0003C932 File Offset: 0x0003AB32
		public static implicit operator IntPtr(VisInfo value)
		{
			return value.self;
		}

		// Token: 0x06000BAA RID: 2986 RVA: 0x0003C93C File Offset: 0x0003AB3C
		public static implicit operator VisInfo(IntPtr value)
		{
			return new VisInfo
			{
				self = value
			};
		}

		// Token: 0x06000BAB RID: 2987 RVA: 0x0003C95A File Offset: 0x0003AB5A
		public static bool operator ==(VisInfo c1, VisInfo c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x0003C96D File Offset: 0x0003AB6D
		public static bool operator !=(VisInfo c1, VisInfo c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000BAD RID: 2989 RVA: 0x0003C980 File Offset: 0x0003AB80
		public override bool Equals(object obj)
		{
			if (obj is VisInfo)
			{
				VisInfo c = (VisInfo)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000BAE RID: 2990 RVA: 0x0003C9AA File Offset: 0x0003ABAA
		internal VisInfo(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000BAF RID: 2991 RVA: 0x0003C9B4 File Offset: 0x0003ABB4
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
			defaultInterpolatedStringHandler.AppendLiteral("VisInfo ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000BB0 RID: 2992 RVA: 0x0003C9EF File Offset: 0x0003ABEF
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000BB1 RID: 2993 RVA: 0x0003CA01 File Offset: 0x0003AC01
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x0003CA0C File Offset: 0x0003AC0C
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x0003CA1F File Offset: 0x0003AC1F
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("VisInfo was null when calling " + n);
			}
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x0003CA3A File Offset: 0x0003AC3A
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x040000C4 RID: 196
		internal IntPtr self;

		// Token: 0x020001DE RID: 478
		internal static class __N
		{
		}
	}
}
