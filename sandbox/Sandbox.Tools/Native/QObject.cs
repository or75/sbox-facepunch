using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace Native
{
	// Token: 0x02000053 RID: 83
	internal struct QObject
	{
		// Token: 0x06000CB8 RID: 3256 RVA: 0x000227DD File Offset: 0x000209DD
		public static implicit operator IntPtr(QObject value)
		{
			return value.self;
		}

		// Token: 0x06000CB9 RID: 3257 RVA: 0x000227E8 File Offset: 0x000209E8
		public static implicit operator QObject(IntPtr value)
		{
			return new QObject
			{
				self = value
			};
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x00022806 File Offset: 0x00020A06
		public static bool operator ==(QObject c1, QObject c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000CBB RID: 3259 RVA: 0x00022819 File Offset: 0x00020A19
		public static bool operator !=(QObject c1, QObject c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x0002282C File Offset: 0x00020A2C
		public override bool Equals(object obj)
		{
			if (obj is QObject)
			{
				QObject c = (QObject)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x00022856 File Offset: 0x00020A56
		internal QObject(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000CBE RID: 3262 RVA: 0x00022860 File Offset: 0x00020A60
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QObject ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000CBF RID: 3263 RVA: 0x0002289B File Offset: 0x00020A9B
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000CC0 RID: 3264 RVA: 0x000228AD File Offset: 0x00020AAD
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000CC1 RID: 3265 RVA: 0x000228B8 File Offset: 0x00020AB8
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000CC2 RID: 3266 RVA: 0x000228CB File Offset: 0x00020ACB
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QObject was null when calling " + n);
			}
		}

		// Token: 0x06000CC3 RID: 3267 RVA: 0x000228E6 File Offset: 0x00020AE6
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x000228F4 File Offset: 0x00020AF4
		internal readonly void deleteLater()
		{
			this.NullCheck("deleteLater");
			method qobjec_deleteLater = QObject.__N.QObjec_deleteLater;
			calli(System.Void(System.IntPtr), this.self, qobjec_deleteLater);
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x00022920 File Offset: 0x00020B20
		internal readonly string objectName()
		{
			this.NullCheck("objectName");
			method qobjec_objectName = QObject.__N.QObjec_objectName;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qobjec_objectName));
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x00022950 File Offset: 0x00020B50
		internal readonly void setObjectName(string name)
		{
			this.NullCheck("setObjectName");
			method qobjec_setObjectName = QObject.__N.QObjec_setObjectName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qobjec_setObjectName);
		}

		// Token: 0x06000CC7 RID: 3271 RVA: 0x00022980 File Offset: 0x00020B80
		internal readonly void setProperty(string key, bool value)
		{
			this.NullCheck("setProperty");
			method qobjec_setProperty = QObject.__N.QObjec_setProperty;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(key), value ? 1 : 0, qobjec_setProperty);
		}

		// Token: 0x06000CC8 RID: 3272 RVA: 0x000229B8 File Offset: 0x00020BB8
		internal readonly void setProperty(string key, float value)
		{
			this.NullCheck("setProperty");
			method qobjec_f = QObject.__N.QObjec_f2;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Single), this.self, Interop.GetPointer(key), value, qobjec_f);
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x000229EC File Offset: 0x00020BEC
		internal readonly void setProperty(string key, string value)
		{
			this.NullCheck("setProperty");
			method qobjec_f = QObject.__N.QObjec_f3;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(key), Interop.GetPointer(value), qobjec_f);
		}

		// Token: 0x0400005E RID: 94
		internal IntPtr self;

		// Token: 0x0200011F RID: 287
		internal static class __N
		{
			// Token: 0x04000E9A RID: 3738
			internal static method QObjec_deleteLater;

			// Token: 0x04000E9B RID: 3739
			internal static method QObjec_objectName;

			// Token: 0x04000E9C RID: 3740
			internal static method QObjec_setObjectName;

			// Token: 0x04000E9D RID: 3741
			internal static method QObjec_setProperty;

			// Token: 0x04000E9E RID: 3742
			internal static method QObjec_f2;

			// Token: 0x04000E9F RID: 3743
			internal static method QObjec_f3;
		}
	}
}
