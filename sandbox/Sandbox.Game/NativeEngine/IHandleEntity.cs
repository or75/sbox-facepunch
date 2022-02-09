using System;
using System.Runtime.CompilerServices;

namespace NativeEngine
{
	// Token: 0x0200004C RID: 76
	internal struct IHandleEntity
	{
		// Token: 0x06000A47 RID: 2631 RVA: 0x000394CE File Offset: 0x000376CE
		public static implicit operator IntPtr(IHandleEntity value)
		{
			return value.self;
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x000394D8 File Offset: 0x000376D8
		public static implicit operator IHandleEntity(IntPtr value)
		{
			return new IHandleEntity
			{
				self = value
			};
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x000394F6 File Offset: 0x000376F6
		public static bool operator ==(IHandleEntity c1, IHandleEntity c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x00039509 File Offset: 0x00037709
		public static bool operator !=(IHandleEntity c1, IHandleEntity c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000A4B RID: 2635 RVA: 0x0003951C File Offset: 0x0003771C
		public override bool Equals(object obj)
		{
			if (obj is IHandleEntity)
			{
				IHandleEntity c = (IHandleEntity)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x00039546 File Offset: 0x00037746
		internal IHandleEntity(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x00039550 File Offset: 0x00037750
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
			defaultInterpolatedStringHandler.AppendLiteral("IHandleEntity ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000A4E RID: 2638 RVA: 0x0003958C File Offset: 0x0003778C
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000A4F RID: 2639 RVA: 0x0003959E File Offset: 0x0003779E
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x000395A9 File Offset: 0x000377A9
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x000395BC File Offset: 0x000377BC
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("IHandleEntity was null when calling " + n);
			}
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x000395D7 File Offset: 0x000377D7
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x000395E4 File Offset: 0x000377E4
		internal readonly CBaseHandle GetRefEHandle()
		{
			this.NullCheck("GetRefEHandle");
			method ihndle_GetRefEHandle = IHandleEntity.__N.IHndle_GetRefEHandle;
			return calli(NativeEngine.CBaseHandle(System.IntPtr), this.self, ihndle_GetRefEHandle);
		}

		// Token: 0x040000BA RID: 186
		internal IntPtr self;

		// Token: 0x020001D1 RID: 465
		internal static class __N
		{
			// Token: 0x04000F62 RID: 3938
			internal static method IHndle_GetRefEHandle;
		}
	}
}
