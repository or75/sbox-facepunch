using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Tools;

// Token: 0x0200000F RID: 15
internal struct CDataModel
{
	// Token: 0x06000064 RID: 100 RVA: 0x00003012 File Offset: 0x00001212
	public static implicit operator IntPtr(CDataModel value)
	{
		return value.self;
	}

	// Token: 0x06000065 RID: 101 RVA: 0x0000301C File Offset: 0x0000121C
	public static implicit operator CDataModel(IntPtr value)
	{
		return new CDataModel
		{
			self = value
		};
	}

	// Token: 0x06000066 RID: 102 RVA: 0x0000303A File Offset: 0x0000123A
	public static bool operator ==(CDataModel c1, CDataModel c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x06000067 RID: 103 RVA: 0x0000304D File Offset: 0x0000124D
	public static bool operator !=(CDataModel c1, CDataModel c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x06000068 RID: 104 RVA: 0x00003060 File Offset: 0x00001260
	public override bool Equals(object obj)
	{
		if (obj is CDataModel)
		{
			CDataModel c = (CDataModel)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x06000069 RID: 105 RVA: 0x0000308A File Offset: 0x0000128A
	internal CDataModel(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x0600006A RID: 106 RVA: 0x00003094 File Offset: 0x00001294
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CDataModel ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000009 RID: 9
	// (get) Token: 0x0600006B RID: 107 RVA: 0x000030D0 File Offset: 0x000012D0
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x0600006C RID: 108 RVA: 0x000030E2 File Offset: 0x000012E2
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x0600006D RID: 109 RVA: 0x000030ED File Offset: 0x000012ED
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x0600006E RID: 110 RVA: 0x00003100 File Offset: 0x00001300
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("CDataModel was null when calling " + n);
		}
	}

	// Token: 0x0600006F RID: 111 RVA: 0x0000311B File Offset: 0x0000131B
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000070 RID: 112 RVA: 0x00003128 File Offset: 0x00001328
	public static implicit operator Native.QObject(CDataModel value)
	{
		method to_QObject_From_CDataModel = CDataModel.__N.To_QObject_From_CDataModel;
		return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_CDataModel);
	}

	// Token: 0x06000071 RID: 113 RVA: 0x0000314C File Offset: 0x0000134C
	public static explicit operator CDataModel(Native.QObject value)
	{
		method from_QObject_To_CDataModel = CDataModel.__N.From_QObject_To_CDataModel;
		return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_CDataModel);
	}

	// Token: 0x06000072 RID: 114 RVA: 0x00003170 File Offset: 0x00001370
	internal static CDataModel Create(Native.QObject parent, DataModel obj)
	{
		method cdtMde_Create = CDataModel.__N.CDtMde_Create;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (obj == null) ? 0U : InteropSystem.GetAddress<DataModel>(obj, true), cdtMde_Create);
	}

	// Token: 0x06000073 RID: 115 RVA: 0x000031A4 File Offset: 0x000013A4
	internal unsafe readonly void LayoutChanged(ModelIndex parent)
	{
		this.NullCheck("LayoutChanged");
		method cdtMde_LayoutChanged = CDataModel.__N.CDtMde_LayoutChanged;
		calli(System.Void(System.IntPtr,Tools.ModelIndex*), this.self, &parent, cdtMde_LayoutChanged);
	}

	// Token: 0x06000074 RID: 116 RVA: 0x000031D4 File Offset: 0x000013D4
	internal unsafe readonly void DataChanged(ModelIndex node)
	{
		this.NullCheck("DataChanged");
		method cdtMde_DataChanged = CDataModel.__N.CDtMde_DataChanged;
		calli(System.Void(System.IntPtr,Tools.ModelIndex*), this.self, &node, cdtMde_DataChanged);
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00003204 File Offset: 0x00001404
	internal readonly void deleteLater()
	{
		this.NullCheck("deleteLater");
		method cdtMde_deleteLater = CDataModel.__N.CDtMde_deleteLater;
		calli(System.Void(System.IntPtr), this.self, cdtMde_deleteLater);
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00003230 File Offset: 0x00001430
	internal readonly string objectName()
	{
		this.NullCheck("objectName");
		method cdtMde_objectName = CDataModel.__N.CDtMde_objectName;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, cdtMde_objectName));
	}

	// Token: 0x06000077 RID: 119 RVA: 0x00003260 File Offset: 0x00001460
	internal readonly void setObjectName(string name)
	{
		this.NullCheck("setObjectName");
		method cdtMde_setObjectName = CDataModel.__N.CDtMde_setObjectName;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), cdtMde_setObjectName);
	}

	// Token: 0x06000078 RID: 120 RVA: 0x00003290 File Offset: 0x00001490
	internal readonly void setProperty(string key, bool value)
	{
		this.NullCheck("setProperty");
		method cdtMde_setProperty = CDataModel.__N.CDtMde_setProperty;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(key), value ? 1 : 0, cdtMde_setProperty);
	}

	// Token: 0x06000079 RID: 121 RVA: 0x000032C8 File Offset: 0x000014C8
	internal readonly void setProperty(string key, float value)
	{
		this.NullCheck("setProperty");
		method cdtMde_f = CDataModel.__N.CDtMde_f2;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Single), this.self, Interop.GetPointer(key), value, cdtMde_f);
	}

	// Token: 0x0600007A RID: 122 RVA: 0x000032FC File Offset: 0x000014FC
	internal readonly void setProperty(string key, string value)
	{
		this.NullCheck("setProperty");
		method cdtMde_f = CDataModel.__N.CDtMde_f3;
		calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(key), Interop.GetPointer(value), cdtMde_f);
	}

	// Token: 0x0400000B RID: 11
	internal IntPtr self;

	// Token: 0x020000DF RID: 223
	internal static class __N
	{
		// Token: 0x04000512 RID: 1298
		internal static method From_QObject_To_CDataModel;

		// Token: 0x04000513 RID: 1299
		internal static method To_QObject_From_CDataModel;

		// Token: 0x04000514 RID: 1300
		internal static method CDtMde_Create;

		// Token: 0x04000515 RID: 1301
		internal static method CDtMde_LayoutChanged;

		// Token: 0x04000516 RID: 1302
		internal static method CDtMde_DataChanged;

		// Token: 0x04000517 RID: 1303
		internal static method CDtMde_deleteLater;

		// Token: 0x04000518 RID: 1304
		internal static method CDtMde_objectName;

		// Token: 0x04000519 RID: 1305
		internal static method CDtMde_setObjectName;

		// Token: 0x0400051A RID: 1306
		internal static method CDtMde_setProperty;

		// Token: 0x0400051B RID: 1307
		internal static method CDtMde_f2;

		// Token: 0x0400051C RID: 1308
		internal static method CDtMde_f3;
	}
}
