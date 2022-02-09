using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Tools;

// Token: 0x02000012 RID: 18
internal struct CLineEdit
{
	// Token: 0x06000095 RID: 149 RVA: 0x000035C1 File Offset: 0x000017C1
	public static implicit operator IntPtr(CLineEdit value)
	{
		return value.self;
	}

	// Token: 0x06000096 RID: 150 RVA: 0x000035CC File Offset: 0x000017CC
	public static implicit operator CLineEdit(IntPtr value)
	{
		return new CLineEdit
		{
			self = value
		};
	}

	// Token: 0x06000097 RID: 151 RVA: 0x000035EA File Offset: 0x000017EA
	public static bool operator ==(CLineEdit c1, CLineEdit c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x06000098 RID: 152 RVA: 0x000035FD File Offset: 0x000017FD
	public static bool operator !=(CLineEdit c1, CLineEdit c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x06000099 RID: 153 RVA: 0x00003610 File Offset: 0x00001810
	public override bool Equals(object obj)
	{
		if (obj is CLineEdit)
		{
			CLineEdit c = (CLineEdit)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x0600009A RID: 154 RVA: 0x0000363A File Offset: 0x0000183A
	internal CLineEdit(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x0600009B RID: 155 RVA: 0x00003644 File Offset: 0x00001844
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CLineEdit ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x1700000F RID: 15
	// (get) Token: 0x0600009C RID: 156 RVA: 0x00003680 File Offset: 0x00001880
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000010 RID: 16
	// (get) Token: 0x0600009D RID: 157 RVA: 0x00003692 File Offset: 0x00001892
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x0600009E RID: 158 RVA: 0x0000369D File Offset: 0x0000189D
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x0600009F RID: 159 RVA: 0x000036B0 File Offset: 0x000018B0
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("CLineEdit was null when calling " + n);
		}
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x000036CB File Offset: 0x000018CB
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x000036D8 File Offset: 0x000018D8
	internal static CLineEdit Create(QWidget parent, LineEdit obj)
	{
		method clneEd_Create = CLineEdit.__N.CLneEd_Create;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (obj == null) ? 0U : InteropSystem.GetAddress<LineEdit>(obj, true), clneEd_Create);
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x0000370C File Offset: 0x0000190C
	internal readonly void SetValidation(string str)
	{
		this.NullCheck("SetValidation");
		method clneEd_SetValidation = CLineEdit.__N.CLneEd_SetValidation;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), clneEd_SetValidation);
	}

	// Token: 0x0400000E RID: 14
	internal IntPtr self;

	// Token: 0x020000E2 RID: 226
	internal static class __N
	{
		// Token: 0x0400051F RID: 1311
		internal static method CLneEd_Create;

		// Token: 0x04000520 RID: 1312
		internal static method CLneEd_SetValidation;
	}
}
