using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Tools;

// Token: 0x02000015 RID: 21
internal struct CPlainTextEdit
{
	// Token: 0x0600012F RID: 303 RVA: 0x00004E3D File Offset: 0x0000303D
	public static implicit operator IntPtr(CPlainTextEdit value)
	{
		return value.self;
	}

	// Token: 0x06000130 RID: 304 RVA: 0x00004E48 File Offset: 0x00003048
	public static implicit operator CPlainTextEdit(IntPtr value)
	{
		return new CPlainTextEdit
		{
			self = value
		};
	}

	// Token: 0x06000131 RID: 305 RVA: 0x00004E66 File Offset: 0x00003066
	public static bool operator ==(CPlainTextEdit c1, CPlainTextEdit c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x06000132 RID: 306 RVA: 0x00004E79 File Offset: 0x00003079
	public static bool operator !=(CPlainTextEdit c1, CPlainTextEdit c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x06000133 RID: 307 RVA: 0x00004E8C File Offset: 0x0000308C
	public override bool Equals(object obj)
	{
		if (obj is CPlainTextEdit)
		{
			CPlainTextEdit c = (CPlainTextEdit)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x06000134 RID: 308 RVA: 0x00004EB6 File Offset: 0x000030B6
	internal CPlainTextEdit(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x06000135 RID: 309 RVA: 0x00004EC0 File Offset: 0x000030C0
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CPlainTextEdit ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x06000136 RID: 310 RVA: 0x00004EFC File Offset: 0x000030FC
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000016 RID: 22
	// (get) Token: 0x06000137 RID: 311 RVA: 0x00004F0E File Offset: 0x0000310E
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x06000138 RID: 312 RVA: 0x00004F19 File Offset: 0x00003119
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000139 RID: 313 RVA: 0x00004F2C File Offset: 0x0000312C
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("CPlainTextEdit was null when calling " + n);
		}
	}

	// Token: 0x0600013A RID: 314 RVA: 0x00004F47 File Offset: 0x00003147
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x0600013B RID: 315 RVA: 0x00004F54 File Offset: 0x00003154
	internal static QPlainTextEdit Create(QWidget parent, TextEdit managedobj)
	{
		method cplnTe_Create = CPlainTextEdit.__N.CPlnTe_Create;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (managedobj == null) ? 0U : InteropSystem.GetAddress<TextEdit>(managedobj, true), cplnTe_Create);
	}

	// Token: 0x04000011 RID: 17
	internal IntPtr self;

	// Token: 0x020000E5 RID: 229
	internal static class __N
	{
		// Token: 0x04000595 RID: 1429
		internal static method CPlnTe_Create;
	}
}
