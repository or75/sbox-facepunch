using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000244 RID: 580
	internal struct KeyValues3
	{
		// Token: 0x06000EFE RID: 3838 RVA: 0x0001A986 File Offset: 0x00018B86
		public static implicit operator IntPtr(KeyValues3 value)
		{
			return value.self;
		}

		// Token: 0x06000EFF RID: 3839 RVA: 0x0001A990 File Offset: 0x00018B90
		public static implicit operator KeyValues3(IntPtr value)
		{
			return new KeyValues3
			{
				self = value
			};
		}

		// Token: 0x06000F00 RID: 3840 RVA: 0x0001A9AE File Offset: 0x00018BAE
		public static bool operator ==(KeyValues3 c1, KeyValues3 c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000F01 RID: 3841 RVA: 0x0001A9C1 File Offset: 0x00018BC1
		public static bool operator !=(KeyValues3 c1, KeyValues3 c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000F02 RID: 3842 RVA: 0x0001A9D4 File Offset: 0x00018BD4
		public override bool Equals(object obj)
		{
			if (obj is KeyValues3)
			{
				KeyValues3 c = (KeyValues3)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000F03 RID: 3843 RVA: 0x0001A9FE File Offset: 0x00018BFE
		internal KeyValues3(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000F04 RID: 3844 RVA: 0x0001AA08 File Offset: 0x00018C08
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
			defaultInterpolatedStringHandler.AppendLiteral("KeyValues3 ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x06000F05 RID: 3845 RVA: 0x0001AA44 File Offset: 0x00018C44
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x06000F06 RID: 3846 RVA: 0x0001AA56 File Offset: 0x00018C56
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000F07 RID: 3847 RVA: 0x0001AA61 File Offset: 0x00018C61
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000F08 RID: 3848 RVA: 0x0001AA74 File Offset: 0x00018C74
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("KeyValues3 was null when calling " + n);
			}
		}

		// Token: 0x06000F09 RID: 3849 RVA: 0x0001AA8F File Offset: 0x00018C8F
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000F0A RID: 3850 RVA: 0x0001AA9C File Offset: 0x00018C9C
		internal readonly void DeleteThis()
		{
			this.NullCheck("DeleteThis");
			method keyVle_DeleteThis = KeyValues3.__N.KeyVle_DeleteThis;
			calli(System.Void(System.IntPtr), this.self, keyVle_DeleteThis);
		}

		// Token: 0x06000F0B RID: 3851 RVA: 0x0001AAC6 File Offset: 0x00018CC6
		internal static KeyValues3 Create()
		{
			return calli(System.IntPtr(), KeyValues3.__N.KeyVle_Create);
		}

		// Token: 0x06000F0C RID: 3852 RVA: 0x0001AAD8 File Offset: 0x00018CD8
		internal readonly bool IsArray()
		{
			this.NullCheck("IsArray");
			method keyVle_IsArray = KeyValues3.__N.KeyVle_IsArray;
			return calli(System.Int32(System.IntPtr), this.self, keyVle_IsArray) > 0;
		}

		// Token: 0x06000F0D RID: 3853 RVA: 0x0001AB08 File Offset: 0x00018D08
		internal readonly bool IsTable()
		{
			this.NullCheck("IsTable");
			method keyVle_IsTable = KeyValues3.__N.KeyVle_IsTable;
			return calli(System.Int32(System.IntPtr), this.self, keyVle_IsTable) > 0;
		}

		// Token: 0x06000F0E RID: 3854 RVA: 0x0001AB38 File Offset: 0x00018D38
		internal readonly void SetValueBool(bool o)
		{
			this.NullCheck("SetValueBool");
			method keyVle_SetValueBool = KeyValues3.__N.KeyVle_SetValueBool;
			calli(System.Void(System.IntPtr,System.Int32), this.self, o ? 1 : 0, keyVle_SetValueBool);
		}

		// Token: 0x06000F0F RID: 3855 RVA: 0x0001AB6C File Offset: 0x00018D6C
		internal readonly void SetValueString(string o)
		{
			this.NullCheck("SetValueString");
			method keyVle_SetValueString = KeyValues3.__N.KeyVle_SetValueString;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(o), keyVle_SetValueString);
		}

		// Token: 0x06000F10 RID: 3856 RVA: 0x0001AB9C File Offset: 0x00018D9C
		internal readonly void SetValueResourceString(string o)
		{
			this.NullCheck("SetValueResourceString");
			method keyVle_SetValueResourceString = KeyValues3.__N.KeyVle_SetValueResourceString;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(o), keyVle_SetValueResourceString);
		}

		// Token: 0x06000F11 RID: 3857 RVA: 0x0001ABCC File Offset: 0x00018DCC
		internal readonly void SetValueInt(int o)
		{
			this.NullCheck("SetValueInt");
			method keyVle_SetValueInt = KeyValues3.__N.KeyVle_SetValueInt;
			calli(System.Void(System.IntPtr,System.Int32), this.self, o, keyVle_SetValueInt);
		}

		// Token: 0x06000F12 RID: 3858 RVA: 0x0001ABF8 File Offset: 0x00018DF8
		internal readonly void SetValueFloat(float o)
		{
			this.NullCheck("SetValueFloat");
			method keyVle_SetValueFloat = KeyValues3.__N.KeyVle_SetValueFloat;
			calli(System.Void(System.IntPtr,System.Single), this.self, o, keyVle_SetValueFloat);
		}

		// Token: 0x06000F13 RID: 3859 RVA: 0x0001AC24 File Offset: 0x00018E24
		internal readonly void SetMemberString(string key, string value)
		{
			this.NullCheck("SetMemberString");
			method keyVle_SetMemberString = KeyValues3.__N.KeyVle_SetMemberString;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(key), Interop.GetPointer(value), keyVle_SetMemberString);
		}

		// Token: 0x06000F14 RID: 3860 RVA: 0x0001AC5C File Offset: 0x00018E5C
		internal readonly void SetMemberInt(string key, int value)
		{
			this.NullCheck("SetMemberInt");
			method keyVle_SetMemberInt = KeyValues3.__N.KeyVle_SetMemberInt;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(key), value, keyVle_SetMemberInt);
		}

		// Token: 0x06000F15 RID: 3861 RVA: 0x0001AC90 File Offset: 0x00018E90
		internal readonly void SetMemberFloat(string key, float value)
		{
			this.NullCheck("SetMemberFloat");
			method keyVle_SetMemberFloat = KeyValues3.__N.KeyVle_SetMemberFloat;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Single), this.self, Interop.GetPointer(key), value, keyVle_SetMemberFloat);
		}

		// Token: 0x06000F16 RID: 3862 RVA: 0x0001ACC4 File Offset: 0x00018EC4
		internal readonly string GetMemberString(string key)
		{
			this.NullCheck("GetMemberString");
			method keyVle_GetMemberString = KeyValues3.__N.KeyVle_GetMemberString;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(key), keyVle_GetMemberString));
		}

		// Token: 0x06000F17 RID: 3863 RVA: 0x0001ACFC File Offset: 0x00018EFC
		internal readonly void SetToEmptyArray()
		{
			this.NullCheck("SetToEmptyArray");
			method keyVle_SetToEmptyArray = KeyValues3.__N.KeyVle_SetToEmptyArray;
			calli(System.Void(System.IntPtr), this.self, keyVle_SetToEmptyArray);
		}

		// Token: 0x06000F18 RID: 3864 RVA: 0x0001AD28 File Offset: 0x00018F28
		internal readonly int GetArrayLength()
		{
			this.NullCheck("GetArrayLength");
			method keyVle_GetArrayLength = KeyValues3.__N.KeyVle_GetArrayLength;
			return calli(System.Int32(System.IntPtr), this.self, keyVle_GetArrayLength);
		}

		// Token: 0x06000F19 RID: 3865 RVA: 0x0001AD54 File Offset: 0x00018F54
		internal readonly KeyValues3 ArrayAddToTail()
		{
			this.NullCheck("ArrayAddToTail");
			method keyVle_ArrayAddToTail = KeyValues3.__N.KeyVle_ArrayAddToTail;
			return calli(System.IntPtr(System.IntPtr), this.self, keyVle_ArrayAddToTail);
		}

		// Token: 0x06000F1A RID: 3866 RVA: 0x0001AD84 File Offset: 0x00018F84
		internal readonly KeyValues3 GetArrayElement(int i)
		{
			this.NullCheck("GetArrayElement");
			method keyVle_GetArrayElement = KeyValues3.__N.KeyVle_GetArrayElement;
			return calli(System.IntPtr(System.IntPtr,System.Int32), this.self, i, keyVle_GetArrayElement);
		}

		// Token: 0x06000F1B RID: 3867 RVA: 0x0001ADB4 File Offset: 0x00018FB4
		internal readonly void SetToEmptyTable()
		{
			this.NullCheck("SetToEmptyTable");
			method keyVle_SetToEmptyTable = KeyValues3.__N.KeyVle_SetToEmptyTable;
			calli(System.Void(System.IntPtr), this.self, keyVle_SetToEmptyTable);
		}

		// Token: 0x04000E4A RID: 3658
		internal IntPtr self;

		// Token: 0x020003A9 RID: 937
		internal static class __N
		{
			// Token: 0x040018A3 RID: 6307
			internal static method KeyVle_DeleteThis;

			// Token: 0x040018A4 RID: 6308
			internal static method KeyVle_Create;

			// Token: 0x040018A5 RID: 6309
			internal static method KeyVle_IsArray;

			// Token: 0x040018A6 RID: 6310
			internal static method KeyVle_IsTable;

			// Token: 0x040018A7 RID: 6311
			internal static method KeyVle_SetValueBool;

			// Token: 0x040018A8 RID: 6312
			internal static method KeyVle_SetValueString;

			// Token: 0x040018A9 RID: 6313
			internal static method KeyVle_SetValueResourceString;

			// Token: 0x040018AA RID: 6314
			internal static method KeyVle_SetValueInt;

			// Token: 0x040018AB RID: 6315
			internal static method KeyVle_SetValueFloat;

			// Token: 0x040018AC RID: 6316
			internal static method KeyVle_SetMemberString;

			// Token: 0x040018AD RID: 6317
			internal static method KeyVle_SetMemberInt;

			// Token: 0x040018AE RID: 6318
			internal static method KeyVle_SetMemberFloat;

			// Token: 0x040018AF RID: 6319
			internal static method KeyVle_GetMemberString;

			// Token: 0x040018B0 RID: 6320
			internal static method KeyVle_SetToEmptyArray;

			// Token: 0x040018B1 RID: 6321
			internal static method KeyVle_GetArrayLength;

			// Token: 0x040018B2 RID: 6322
			internal static method KeyVle_ArrayAddToTail;

			// Token: 0x040018B3 RID: 6323
			internal static method KeyVle_GetArrayElement;

			// Token: 0x040018B4 RID: 6324
			internal static method KeyVle_SetToEmptyTable;
		}
	}
}
