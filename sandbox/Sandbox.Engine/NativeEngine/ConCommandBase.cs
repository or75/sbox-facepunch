using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000225 RID: 549
	internal struct ConCommandBase
	{
		// Token: 0x06000DA7 RID: 3495 RVA: 0x0001808E File Offset: 0x0001628E
		public static implicit operator IntPtr(ConCommandBase value)
		{
			return value.self;
		}

		// Token: 0x06000DA8 RID: 3496 RVA: 0x00018098 File Offset: 0x00016298
		public static implicit operator ConCommandBase(IntPtr value)
		{
			return new ConCommandBase
			{
				self = value
			};
		}

		// Token: 0x06000DA9 RID: 3497 RVA: 0x000180B6 File Offset: 0x000162B6
		public static bool operator ==(ConCommandBase c1, ConCommandBase c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000DAA RID: 3498 RVA: 0x000180C9 File Offset: 0x000162C9
		public static bool operator !=(ConCommandBase c1, ConCommandBase c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x000180DC File Offset: 0x000162DC
		public override bool Equals(object obj)
		{
			if (obj is ConCommandBase)
			{
				ConCommandBase c = (ConCommandBase)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000DAC RID: 3500 RVA: 0x00018106 File Offset: 0x00016306
		internal ConCommandBase(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000DAD RID: 3501 RVA: 0x00018110 File Offset: 0x00016310
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
			defaultInterpolatedStringHandler.AppendLiteral("ConCommandBase ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x06000DAE RID: 3502 RVA: 0x0001814C File Offset: 0x0001634C
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x06000DAF RID: 3503 RVA: 0x0001815E File Offset: 0x0001635E
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000DB0 RID: 3504 RVA: 0x00018169 File Offset: 0x00016369
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000DB1 RID: 3505 RVA: 0x0001817C File Offset: 0x0001637C
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("ConCommandBase was null when calling " + n);
			}
		}

		// Token: 0x06000DB2 RID: 3506 RVA: 0x00018197 File Offset: 0x00016397
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000DB3 RID: 3507 RVA: 0x000181A4 File Offset: 0x000163A4
		internal readonly bool IsCommand()
		{
			this.NullCheck("IsCommand");
			method cnCmmn_f = ConCommandBase.__N.CnCmmn_f2;
			return calli(System.Int32(System.IntPtr), this.self, cnCmmn_f) > 0;
		}

		// Token: 0x06000DB4 RID: 3508 RVA: 0x000181D4 File Offset: 0x000163D4
		internal readonly string GetName()
		{
			this.NullCheck("GetName");
			method cnCmmn_f = ConCommandBase.__N.CnCmmn_f3;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cnCmmn_f));
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x00018204 File Offset: 0x00016404
		internal readonly string GetHelpText()
		{
			this.NullCheck("GetHelpText");
			method cnCmmn_f = ConCommandBase.__N.CnCmmn_f4;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cnCmmn_f));
		}

		// Token: 0x06000DB6 RID: 3510 RVA: 0x00018234 File Offset: 0x00016434
		internal readonly bool IsFlagSet(CommandFlags flag)
		{
			this.NullCheck("IsFlagSet");
			method cnCmmn_f = ConCommandBase.__N.CnCmmn_f5;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, flag, cnCmmn_f) > 0;
		}

		// Token: 0x04000E3C RID: 3644
		internal IntPtr self;

		// Token: 0x0200038A RID: 906
		internal static class __N
		{
			// Token: 0x040017F4 RID: 6132
			internal static method CnCmmn_f2;

			// Token: 0x040017F5 RID: 6133
			internal static method CnCmmn_f3;

			// Token: 0x040017F6 RID: 6134
			internal static method CnCmmn_f4;

			// Token: 0x040017F7 RID: 6135
			internal static method CnCmmn_f5;
		}
	}
}
