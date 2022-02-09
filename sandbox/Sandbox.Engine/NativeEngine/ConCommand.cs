using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000224 RID: 548
	internal struct ConCommand
	{
		// Token: 0x06000D93 RID: 3475 RVA: 0x00017E09 File Offset: 0x00016009
		public static implicit operator IntPtr(ConCommand value)
		{
			return value.self;
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x00017E14 File Offset: 0x00016014
		public static implicit operator ConCommand(IntPtr value)
		{
			return new ConCommand
			{
				self = value
			};
		}

		// Token: 0x06000D95 RID: 3477 RVA: 0x00017E32 File Offset: 0x00016032
		public static bool operator ==(ConCommand c1, ConCommand c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000D96 RID: 3478 RVA: 0x00017E45 File Offset: 0x00016045
		public static bool operator !=(ConCommand c1, ConCommand c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000D97 RID: 3479 RVA: 0x00017E58 File Offset: 0x00016058
		public override bool Equals(object obj)
		{
			if (obj is ConCommand)
			{
				ConCommand c = (ConCommand)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000D98 RID: 3480 RVA: 0x00017E82 File Offset: 0x00016082
		internal ConCommand(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000D99 RID: 3481 RVA: 0x00017E8C File Offset: 0x0001608C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
			defaultInterpolatedStringHandler.AppendLiteral("ConCommand ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x06000D9A RID: 3482 RVA: 0x00017EC8 File Offset: 0x000160C8
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x06000D9B RID: 3483 RVA: 0x00017EDA File Offset: 0x000160DA
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000D9C RID: 3484 RVA: 0x00017EE5 File Offset: 0x000160E5
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000D9D RID: 3485 RVA: 0x00017EF8 File Offset: 0x000160F8
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("ConCommand was null when calling " + n);
			}
		}

		// Token: 0x06000D9E RID: 3486 RVA: 0x00017F13 File Offset: 0x00016113
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000D9F RID: 3487 RVA: 0x00017F20 File Offset: 0x00016120
		public static implicit operator ConCommandBase(ConCommand value)
		{
			method to_ConCommandBase_From_ConCommand = ConCommand.__N.To_ConCommandBase_From_ConCommand;
			return calli(System.IntPtr(System.IntPtr), value, to_ConCommandBase_From_ConCommand);
		}

		// Token: 0x06000DA0 RID: 3488 RVA: 0x00017F44 File Offset: 0x00016144
		public static explicit operator ConCommand(ConCommandBase value)
		{
			method from_ConCommandBase_To_ConCommand = ConCommand.__N.From_ConCommandBase_To_ConCommand;
			return calli(System.IntPtr(System.IntPtr), value, from_ConCommandBase_To_ConCommand);
		}

		// Token: 0x06000DA1 RID: 3489 RVA: 0x00017F68 File Offset: 0x00016168
		internal readonly bool CanAutoComplete()
		{
			this.NullCheck("CanAutoComplete");
			method cnCmmn_CanAutoComplete = ConCommand.__N.CnCmmn_CanAutoComplete;
			return calli(System.Int32(System.IntPtr), this.self, cnCmmn_CanAutoComplete) > 0;
		}

		// Token: 0x06000DA2 RID: 3490 RVA: 0x00017F98 File Offset: 0x00016198
		internal readonly int AutoCompleteSuggest(string partial, CUtlVectorString commands)
		{
			this.NullCheck("AutoCompleteSuggest");
			method cnCmmn_AutoCompleteSuggest = ConCommand.__N.CnCmmn_AutoCompleteSuggest;
			return calli(System.Int32(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(partial), commands, cnCmmn_AutoCompleteSuggest);
		}

		// Token: 0x06000DA3 RID: 3491 RVA: 0x00017FD0 File Offset: 0x000161D0
		internal readonly bool IsCommand()
		{
			this.NullCheck("IsCommand");
			method cnCmmn_IsCommand = ConCommand.__N.CnCmmn_IsCommand;
			return calli(System.Int32(System.IntPtr), this.self, cnCmmn_IsCommand) > 0;
		}

		// Token: 0x06000DA4 RID: 3492 RVA: 0x00018000 File Offset: 0x00016200
		internal readonly string GetName()
		{
			this.NullCheck("GetName");
			method cnCmmn_GetName = ConCommand.__N.CnCmmn_GetName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cnCmmn_GetName));
		}

		// Token: 0x06000DA5 RID: 3493 RVA: 0x00018030 File Offset: 0x00016230
		internal readonly string GetHelpText()
		{
			this.NullCheck("GetHelpText");
			method cnCmmn_GetHelpText = ConCommand.__N.CnCmmn_GetHelpText;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cnCmmn_GetHelpText));
		}

		// Token: 0x06000DA6 RID: 3494 RVA: 0x00018060 File Offset: 0x00016260
		internal readonly bool IsFlagSet(CommandFlags flag)
		{
			this.NullCheck("IsFlagSet");
			method cnCmmn_IsFlagSet = ConCommand.__N.CnCmmn_IsFlagSet;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, flag, cnCmmn_IsFlagSet) > 0;
		}

		// Token: 0x04000E3B RID: 3643
		internal IntPtr self;

		// Token: 0x02000389 RID: 905
		internal static class __N
		{
			// Token: 0x040017EC RID: 6124
			internal static method From_ConCommandBase_To_ConCommand;

			// Token: 0x040017ED RID: 6125
			internal static method To_ConCommandBase_From_ConCommand;

			// Token: 0x040017EE RID: 6126
			internal static method CnCmmn_CanAutoComplete;

			// Token: 0x040017EF RID: 6127
			internal static method CnCmmn_AutoCompleteSuggest;

			// Token: 0x040017F0 RID: 6128
			internal static method CnCmmn_IsCommand;

			// Token: 0x040017F1 RID: 6129
			internal static method CnCmmn_GetName;

			// Token: 0x040017F2 RID: 6130
			internal static method CnCmmn_GetHelpText;

			// Token: 0x040017F3 RID: 6131
			internal static method CnCmmn_IsFlagSet;
		}
	}
}
