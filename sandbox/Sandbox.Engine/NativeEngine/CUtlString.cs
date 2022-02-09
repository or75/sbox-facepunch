using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200022B RID: 555
	internal struct CUtlString
	{
		// Token: 0x06000E21 RID: 3617 RVA: 0x00018F52 File Offset: 0x00017152
		public static implicit operator IntPtr(CUtlString value)
		{
			return value.self;
		}

		// Token: 0x06000E22 RID: 3618 RVA: 0x00018F5C File Offset: 0x0001715C
		public static implicit operator CUtlString(IntPtr value)
		{
			return new CUtlString
			{
				self = value
			};
		}

		// Token: 0x06000E23 RID: 3619 RVA: 0x00018F7A File Offset: 0x0001717A
		public static bool operator ==(CUtlString c1, CUtlString c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x00018F8D File Offset: 0x0001718D
		public static bool operator !=(CUtlString c1, CUtlString c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000E25 RID: 3621 RVA: 0x00018FA0 File Offset: 0x000171A0
		public override bool Equals(object obj)
		{
			if (obj is CUtlString)
			{
				CUtlString c = (CUtlString)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000E26 RID: 3622 RVA: 0x00018FCA File Offset: 0x000171CA
		internal CUtlString(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000E27 RID: 3623 RVA: 0x00018FD4 File Offset: 0x000171D4
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CUtlString ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x06000E28 RID: 3624 RVA: 0x00019010 File Offset: 0x00017210
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x06000E29 RID: 3625 RVA: 0x00019022 File Offset: 0x00017222
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x0001902D File Offset: 0x0001722D
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x00019040 File Offset: 0x00017240
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CUtlString was null when calling " + n);
			}
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x0001905B File Offset: 0x0001725B
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x00019068 File Offset: 0x00017268
		internal readonly string Get()
		{
			this.NullCheck("Get");
			method cutlSt_Get = CUtlString.__N.CUtlSt_Get;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cutlSt_Get));
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x00019098 File Offset: 0x00017298
		internal readonly void Clear()
		{
			this.NullCheck("Clear");
			method cutlSt_Clear = CUtlString.__N.CUtlSt_Clear;
			calli(System.Void(System.IntPtr), this.self, cutlSt_Clear);
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x000190C4 File Offset: 0x000172C4
		internal readonly int Length()
		{
			this.NullCheck("Length");
			method cutlSt_Length = CUtlString.__N.CUtlSt_Length;
			return calli(System.Int32(System.IntPtr), this.self, cutlSt_Length);
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x000190F0 File Offset: 0x000172F0
		internal readonly bool IsEmpty()
		{
			this.NullCheck("IsEmpty");
			method cutlSt_IsEmpty = CUtlString.__N.CUtlSt_IsEmpty;
			return calli(System.Int32(System.IntPtr), this.self, cutlSt_IsEmpty) > 0;
		}

		// Token: 0x04000E42 RID: 3650
		internal IntPtr self;

		// Token: 0x02000390 RID: 912
		internal static class __N
		{
			// Token: 0x04001826 RID: 6182
			internal static method CUtlSt_Get;

			// Token: 0x04001827 RID: 6183
			internal static method CUtlSt_Clear;

			// Token: 0x04001828 RID: 6184
			internal static method CUtlSt_Length;

			// Token: 0x04001829 RID: 6185
			internal static method CUtlSt_IsEmpty;
		}
	}
}
