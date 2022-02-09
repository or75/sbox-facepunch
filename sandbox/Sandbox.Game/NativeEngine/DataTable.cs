using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NativeEngine
{
	// Token: 0x0200003C RID: 60
	internal struct DataTable
	{
		// Token: 0x0600091C RID: 2332 RVA: 0x000364E7 File Offset: 0x000346E7
		public static implicit operator IntPtr(DataTable value)
		{
			return value.self;
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x000364F0 File Offset: 0x000346F0
		public static implicit operator DataTable(IntPtr value)
		{
			return new DataTable
			{
				self = value
			};
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x0003650E File Offset: 0x0003470E
		public static bool operator ==(DataTable c1, DataTable c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x00036521 File Offset: 0x00034721
		public static bool operator !=(DataTable c1, DataTable c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x00036534 File Offset: 0x00034734
		public override bool Equals(object obj)
		{
			if (obj is DataTable)
			{
				DataTable c = (DataTable)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x0003655E File Offset: 0x0003475E
		internal DataTable(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x00036568 File Offset: 0x00034768
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
			defaultInterpolatedStringHandler.AppendLiteral("DataTable ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000923 RID: 2339 RVA: 0x000365A4 File Offset: 0x000347A4
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000924 RID: 2340 RVA: 0x000365B6 File Offset: 0x000347B6
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x000365C1 File Offset: 0x000347C1
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x000365D4 File Offset: 0x000347D4
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("DataTable was null when calling " + n);
			}
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x000365EF File Offset: 0x000347EF
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x000365FC File Offset: 0x000347FC
		internal readonly int GetTags(IntPtr data, int max)
		{
			this.NullCheck("GetTags");
			method dtTble_GetTags = DataTable.__N.DtTble_GetTags;
			return calli(System.Int32(System.IntPtr,System.IntPtr,System.Int32), this.self, data, max, dtTble_GetTags);
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x00036628 File Offset: 0x00034828
		internal readonly void RemoveTag(uint tag)
		{
			this.NullCheck("RemoveTag");
			method dtTble_RemoveTag = DataTable.__N.DtTble_RemoveTag;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, tag, dtTble_RemoveTag);
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x00036654 File Offset: 0x00034854
		internal readonly void AddTag(uint tag)
		{
			this.NullCheck("AddTag");
			method dtTble_AddTag = DataTable.__N.DtTble_AddTag;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, tag, dtTble_AddTag);
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x0600092B RID: 2347 RVA: 0x0003667F File Offset: 0x0003487F
		// (set) Token: 0x0600092C RID: 2348 RVA: 0x0003669F File Offset: 0x0003489F
		internal bool m_bPredictable
		{
			get
			{
				this.NullCheck("m_bPredictable");
				return DataTable.__N.Get__DtTble_m_bPredictable(this.self) != 0;
			}
			set
			{
				this.NullCheck("m_bPredictable");
				DataTable.__N.Set__DtTble_m_bPredictable(this.self, value ? 1 : 0);
			}
		}

		// Token: 0x040000B8 RID: 184
		internal IntPtr self;

		// Token: 0x020001C1 RID: 449
		internal static class __N
		{
			// Token: 0x04000E4F RID: 3663
			internal static method DtTble_GetTags;

			// Token: 0x04000E50 RID: 3664
			internal static method DtTble_RemoveTag;

			// Token: 0x04000E51 RID: 3665
			internal static method DtTble_AddTag;

			// Token: 0x04000E52 RID: 3666
			internal static DataTable.__N._Get__DtTble_m_bPredictable Get__DtTble_m_bPredictable;

			// Token: 0x04000E53 RID: 3667
			internal static DataTable.__N._Set__DtTble_m_bPredictable Set__DtTble_m_bPredictable;

			// Token: 0x020002FB RID: 763
			// (Invoke) Token: 0x060020E8 RID: 8424
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int _Get__DtTble_m_bPredictable(IntPtr self);

			// Token: 0x020002FC RID: 764
			// (Invoke) Token: 0x060020EC RID: 8428
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__DtTble_m_bPredictable(IntPtr self, int val);
		}
	}
}
