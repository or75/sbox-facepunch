using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000226 RID: 550
	internal struct ConVar
	{
		// Token: 0x06000DB7 RID: 3511 RVA: 0x00018262 File Offset: 0x00016462
		public static implicit operator IntPtr(ConVar value)
		{
			return value.self;
		}

		// Token: 0x06000DB8 RID: 3512 RVA: 0x0001826C File Offset: 0x0001646C
		public static implicit operator ConVar(IntPtr value)
		{
			return new ConVar
			{
				self = value
			};
		}

		// Token: 0x06000DB9 RID: 3513 RVA: 0x0001828A File Offset: 0x0001648A
		public static bool operator ==(ConVar c1, ConVar c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000DBA RID: 3514 RVA: 0x0001829D File Offset: 0x0001649D
		public static bool operator !=(ConVar c1, ConVar c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000DBB RID: 3515 RVA: 0x000182B0 File Offset: 0x000164B0
		public override bool Equals(object obj)
		{
			if (obj is ConVar)
			{
				ConVar c = (ConVar)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000DBC RID: 3516 RVA: 0x000182DA File Offset: 0x000164DA
		internal ConVar(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000DBD RID: 3517 RVA: 0x000182E4 File Offset: 0x000164E4
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
			defaultInterpolatedStringHandler.AppendLiteral("ConVar ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x06000DBE RID: 3518 RVA: 0x0001831F File Offset: 0x0001651F
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x06000DBF RID: 3519 RVA: 0x00018331 File Offset: 0x00016531
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000DC0 RID: 3520 RVA: 0x0001833C File Offset: 0x0001653C
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000DC1 RID: 3521 RVA: 0x0001834F File Offset: 0x0001654F
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("ConVar was null when calling " + n);
			}
		}

		// Token: 0x06000DC2 RID: 3522 RVA: 0x0001836A File Offset: 0x0001656A
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000DC3 RID: 3523 RVA: 0x00018378 File Offset: 0x00016578
		public static implicit operator ConCommandBase(ConVar value)
		{
			method to_ConCommandBase_From_ConVar = ConVar.__N.To_ConCommandBase_From_ConVar;
			return calli(System.IntPtr(System.IntPtr), value, to_ConCommandBase_From_ConVar);
		}

		// Token: 0x06000DC4 RID: 3524 RVA: 0x0001839C File Offset: 0x0001659C
		public static explicit operator ConVar(ConCommandBase value)
		{
			method from_ConCommandBase_To_ConVar = ConVar.__N.From_ConCommandBase_To_ConVar;
			return calli(System.IntPtr(System.IntPtr), value, from_ConCommandBase_To_ConVar);
		}

		// Token: 0x06000DC5 RID: 3525 RVA: 0x000183C0 File Offset: 0x000165C0
		internal readonly float GetFloat()
		{
			this.NullCheck("GetFloat");
			method conVar_GetFloat = ConVar.__N.ConVar_GetFloat;
			return calli(System.Single(System.IntPtr), this.self, conVar_GetFloat);
		}

		// Token: 0x06000DC6 RID: 3526 RVA: 0x000183EC File Offset: 0x000165EC
		internal readonly int GetInt()
		{
			this.NullCheck("GetInt");
			method conVar_GetInt = ConVar.__N.ConVar_GetInt;
			return calli(System.Int32(System.IntPtr), this.self, conVar_GetInt);
		}

		// Token: 0x06000DC7 RID: 3527 RVA: 0x00018418 File Offset: 0x00016618
		internal readonly Color32 GetColor()
		{
			this.NullCheck("GetColor");
			method conVar_GetColor = ConVar.__N.ConVar_GetColor;
			return calli(Color32(System.IntPtr), this.self, conVar_GetColor);
		}

		// Token: 0x06000DC8 RID: 3528 RVA: 0x00018444 File Offset: 0x00016644
		internal readonly bool GetBool()
		{
			this.NullCheck("GetBool");
			method conVar_GetBool = ConVar.__N.ConVar_GetBool;
			return calli(System.Int32(System.IntPtr), this.self, conVar_GetBool) > 0;
		}

		// Token: 0x06000DC9 RID: 3529 RVA: 0x00018474 File Offset: 0x00016674
		internal readonly string GetString()
		{
			this.NullCheck("GetString");
			method conVar_GetString = ConVar.__N.ConVar_GetString;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, conVar_GetString));
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x000184A4 File Offset: 0x000166A4
		internal readonly void SetValue(string value)
		{
			this.NullCheck("SetValue");
			method conVar_SetValue = ConVar.__N.ConVar_SetValue;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(value), conVar_SetValue);
		}

		// Token: 0x06000DCB RID: 3531 RVA: 0x000184D4 File Offset: 0x000166D4
		internal readonly void Revert()
		{
			this.NullCheck("Revert");
			method conVar_Revert = ConVar.__N.ConVar_Revert;
			calli(System.Void(System.IntPtr), this.self, conVar_Revert);
		}

		// Token: 0x06000DCC RID: 3532 RVA: 0x00018500 File Offset: 0x00016700
		internal readonly bool IsCommand()
		{
			this.NullCheck("IsCommand");
			method conVar_IsCommand = ConVar.__N.ConVar_IsCommand;
			return calli(System.Int32(System.IntPtr), this.self, conVar_IsCommand) > 0;
		}

		// Token: 0x06000DCD RID: 3533 RVA: 0x00018530 File Offset: 0x00016730
		internal readonly string GetName()
		{
			this.NullCheck("GetName");
			method conVar_GetName = ConVar.__N.ConVar_GetName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, conVar_GetName));
		}

		// Token: 0x06000DCE RID: 3534 RVA: 0x00018560 File Offset: 0x00016760
		internal readonly string GetHelpText()
		{
			this.NullCheck("GetHelpText");
			method conVar_GetHelpText = ConVar.__N.ConVar_GetHelpText;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, conVar_GetHelpText));
		}

		// Token: 0x06000DCF RID: 3535 RVA: 0x00018590 File Offset: 0x00016790
		internal readonly bool IsFlagSet(CommandFlags flag)
		{
			this.NullCheck("IsFlagSet");
			method conVar_IsFlagSet = ConVar.__N.ConVar_IsFlagSet;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, flag, conVar_IsFlagSet) > 0;
		}

		// Token: 0x04000E3D RID: 3645
		internal IntPtr self;

		// Token: 0x0200038B RID: 907
		internal static class __N
		{
			// Token: 0x040017F8 RID: 6136
			internal static method From_ConCommandBase_To_ConVar;

			// Token: 0x040017F9 RID: 6137
			internal static method To_ConCommandBase_From_ConVar;

			// Token: 0x040017FA RID: 6138
			internal static method ConVar_GetFloat;

			// Token: 0x040017FB RID: 6139
			internal static method ConVar_GetInt;

			// Token: 0x040017FC RID: 6140
			internal static method ConVar_GetColor;

			// Token: 0x040017FD RID: 6141
			internal static method ConVar_GetBool;

			// Token: 0x040017FE RID: 6142
			internal static method ConVar_GetString;

			// Token: 0x040017FF RID: 6143
			internal static method ConVar_SetValue;

			// Token: 0x04001800 RID: 6144
			internal static method ConVar_Revert;

			// Token: 0x04001801 RID: 6145
			internal static method ConVar_IsCommand;

			// Token: 0x04001802 RID: 6146
			internal static method ConVar_GetName;

			// Token: 0x04001803 RID: 6147
			internal static method ConVar_GetHelpText;

			// Token: 0x04001804 RID: 6148
			internal static method ConVar_IsFlagSet;
		}
	}
}
