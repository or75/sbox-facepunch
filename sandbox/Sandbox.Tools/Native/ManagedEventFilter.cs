using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x0200003C RID: 60
	internal struct ManagedEventFilter
	{
		// Token: 0x060005FD RID: 1533 RVA: 0x000108BD File Offset: 0x0000EABD
		public static implicit operator IntPtr(ManagedEventFilter value)
		{
			return value.self;
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x000108C8 File Offset: 0x0000EAC8
		public static implicit operator ManagedEventFilter(IntPtr value)
		{
			return new ManagedEventFilter
			{
				self = value
			};
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x000108E6 File Offset: 0x0000EAE6
		public static bool operator ==(ManagedEventFilter c1, ManagedEventFilter c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x000108F9 File Offset: 0x0000EAF9
		public static bool operator !=(ManagedEventFilter c1, ManagedEventFilter c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0001090C File Offset: 0x0000EB0C
		public override bool Equals(object obj)
		{
			if (obj is ManagedEventFilter)
			{
				ManagedEventFilter c = (ManagedEventFilter)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x00010936 File Offset: 0x0000EB36
		internal ManagedEventFilter(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x00010940 File Offset: 0x0000EB40
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
			defaultInterpolatedStringHandler.AppendLiteral("ManagedEventFilter ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000604 RID: 1540 RVA: 0x0001097C File Offset: 0x0000EB7C
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000605 RID: 1541 RVA: 0x0001098E File Offset: 0x0000EB8E
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x00010999 File Offset: 0x0000EB99
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x000109AC File Offset: 0x0000EBAC
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("ManagedEventFilter was null when calling " + n);
			}
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x000109C7 File Offset: 0x0000EBC7
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x000109D4 File Offset: 0x0000EBD4
		public static implicit operator QObject(ManagedEventFilter value)
		{
			method to_QObject_From_ManagedEventFilter = ManagedEventFilter.__N.To_QObject_From_ManagedEventFilter;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_ManagedEventFilter);
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x000109F8 File Offset: 0x0000EBF8
		public static explicit operator ManagedEventFilter(QObject value)
		{
			method from_QObject_To_ManagedEventFilter = ManagedEventFilter.__N.From_QObject_To_ManagedEventFilter;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_ManagedEventFilter);
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x00010A1C File Offset: 0x0000EC1C
		internal static ManagedEventFilter Create(QObject parent, EventFilter filter)
		{
			method mngedE_Create = ManagedEventFilter.__N.MngedE_Create;
			return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (filter == null) ? 0U : InteropSystem.GetAddress<EventFilter>(filter, true), mngedE_Create);
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x00010A50 File Offset: 0x0000EC50
		internal readonly void deleteLater()
		{
			this.NullCheck("deleteLater");
			method mngedE_deleteLater = ManagedEventFilter.__N.MngedE_deleteLater;
			calli(System.Void(System.IntPtr), this.self, mngedE_deleteLater);
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x00010A7C File Offset: 0x0000EC7C
		internal readonly string objectName()
		{
			this.NullCheck("objectName");
			method mngedE_objectName = ManagedEventFilter.__N.MngedE_objectName;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, mngedE_objectName));
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x00010AAC File Offset: 0x0000ECAC
		internal readonly void setObjectName(string name)
		{
			this.NullCheck("setObjectName");
			method mngedE_setObjectName = ManagedEventFilter.__N.MngedE_setObjectName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), mngedE_setObjectName);
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x00010ADC File Offset: 0x0000ECDC
		internal readonly void setProperty(string key, bool value)
		{
			this.NullCheck("setProperty");
			method mngedE_setProperty = ManagedEventFilter.__N.MngedE_setProperty;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(key), value ? 1 : 0, mngedE_setProperty);
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x00010B14 File Offset: 0x0000ED14
		internal readonly void setProperty(string key, float value)
		{
			this.NullCheck("setProperty");
			method mngedE_f = ManagedEventFilter.__N.MngedE_f2;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Single), this.self, Interop.GetPointer(key), value, mngedE_f);
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x00010B48 File Offset: 0x0000ED48
		internal readonly void setProperty(string key, string value)
		{
			this.NullCheck("setProperty");
			method mngedE_f = ManagedEventFilter.__N.MngedE_f3;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(key), Interop.GetPointer(value), mngedE_f);
		}

		// Token: 0x04000048 RID: 72
		internal IntPtr self;

		// Token: 0x02000108 RID: 264
		internal static class __N
		{
			// Token: 0x040008E7 RID: 2279
			internal static method From_QObject_To_ManagedEventFilter;

			// Token: 0x040008E8 RID: 2280
			internal static method To_QObject_From_ManagedEventFilter;

			// Token: 0x040008E9 RID: 2281
			internal static method MngedE_Create;

			// Token: 0x040008EA RID: 2282
			internal static method MngedE_deleteLater;

			// Token: 0x040008EB RID: 2283
			internal static method MngedE_objectName;

			// Token: 0x040008EC RID: 2284
			internal static method MngedE_setObjectName;

			// Token: 0x040008ED RID: 2285
			internal static method MngedE_setProperty;

			// Token: 0x040008EE RID: 2286
			internal static method MngedE_f2;

			// Token: 0x040008EF RID: 2287
			internal static method MngedE_f3;
		}
	}
}
