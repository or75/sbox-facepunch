using System;
using System.Runtime.CompilerServices;

namespace NativeEngine
{
	// Token: 0x0200002C RID: 44
	internal struct CGameSceneNode
	{
		// Token: 0x06000656 RID: 1622 RVA: 0x0002F526 File Offset: 0x0002D726
		public static implicit operator IntPtr(CGameSceneNode value)
		{
			return value.self;
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x0002F530 File Offset: 0x0002D730
		public static implicit operator CGameSceneNode(IntPtr value)
		{
			return new CGameSceneNode
			{
				self = value
			};
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x0002F54E File Offset: 0x0002D74E
		public static bool operator ==(CGameSceneNode c1, CGameSceneNode c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0002F561 File Offset: 0x0002D761
		public static bool operator !=(CGameSceneNode c1, CGameSceneNode c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x0002F574 File Offset: 0x0002D774
		public override bool Equals(object obj)
		{
			if (obj is CGameSceneNode)
			{
				CGameSceneNode c = (CGameSceneNode)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x0002F59E File Offset: 0x0002D79E
		internal CGameSceneNode(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0002F5A8 File Offset: 0x0002D7A8
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CGameSceneNode ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600065D RID: 1629 RVA: 0x0002F5E4 File Offset: 0x0002D7E4
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600065E RID: 1630 RVA: 0x0002F5F6 File Offset: 0x0002D7F6
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x0002F601 File Offset: 0x0002D801
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x0002F614 File Offset: 0x0002D814
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CGameSceneNode was null when calling " + n);
			}
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x0002F62F File Offset: 0x0002D82F
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x0002F63C File Offset: 0x0002D83C
		internal readonly Vector3 GetLocalOrigin()
		{
			this.NullCheck("GetLocalOrigin");
			method cgmeSc_GetLocalOrigin = CGameSceneNode.__N.CGmeSc_GetLocalOrigin;
			return calli(Vector3(System.IntPtr), this.self, cgmeSc_GetLocalOrigin);
		}

		// Token: 0x040000A8 RID: 168
		internal IntPtr self;

		// Token: 0x020001B1 RID: 433
		internal static class __N
		{
			// Token: 0x04000C49 RID: 3145
			internal static method CGmeSc_GetLocalOrigin;
		}
	}
}
