using System;
using System.Runtime.CompilerServices;

namespace NativeEngine
{
	// Token: 0x02000030 RID: 48
	internal struct NavObstacle
	{
		// Token: 0x060006F9 RID: 1785 RVA: 0x00030DF5 File Offset: 0x0002EFF5
		public static implicit operator IntPtr(NavObstacle value)
		{
			return value.self;
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00030E00 File Offset: 0x0002F000
		public static implicit operator NavObstacle(IntPtr value)
		{
			return new NavObstacle
			{
				self = value
			};
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x00030E1E File Offset: 0x0002F01E
		public static bool operator ==(NavObstacle c1, NavObstacle c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x00030E31 File Offset: 0x0002F031
		public static bool operator !=(NavObstacle c1, NavObstacle c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x00030E44 File Offset: 0x0002F044
		public override bool Equals(object obj)
		{
			if (obj is NavObstacle)
			{
				NavObstacle c = (NavObstacle)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x00030E6E File Offset: 0x0002F06E
		internal NavObstacle(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x00030E78 File Offset: 0x0002F078
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
			defaultInterpolatedStringHandler.AppendLiteral("NavObstacle ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000700 RID: 1792 RVA: 0x00030EB4 File Offset: 0x0002F0B4
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000701 RID: 1793 RVA: 0x00030EC6 File Offset: 0x0002F0C6
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00030ED1 File Offset: 0x0002F0D1
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x00030EE4 File Offset: 0x0002F0E4
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("NavObstacle was null when calling " + n);
			}
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x00030EFF File Offset: 0x0002F0FF
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x00030F0C File Offset: 0x0002F10C
		internal static IntPtr SBOX_Create(IntPtr ent, int type, bool active, bool useBody)
		{
			method cnvObs_SBOX_Create = NavObstacle.__N.CNvObs_SBOX_Create;
			return calli(System.IntPtr(System.IntPtr,System.Int32,System.Int32,System.Int32), ent, type, active ? 1 : 0, useBody ? 1 : 0, cnvObs_SBOX_Create);
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x00030F38 File Offset: 0x0002F138
		internal readonly void SBOX_Delete()
		{
			this.NullCheck("SBOX_Delete");
			method cnvObs_SBOX_Delete = NavObstacle.__N.CNvObs_SBOX_Delete;
			calli(System.Void(System.IntPtr), this.self, cnvObs_SBOX_Delete);
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x00030F64 File Offset: 0x0002F164
		internal readonly void SBOX_Update()
		{
			this.NullCheck("SBOX_Update");
			method cnvObs_SBOX_Update = NavObstacle.__N.CNvObs_SBOX_Update;
			calli(System.Void(System.IntPtr), this.self, cnvObs_SBOX_Update);
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x00030F90 File Offset: 0x0002F190
		internal readonly void SetObstacleActive(bool enable)
		{
			this.NullCheck("SetObstacleActive");
			method cnvObs_SetObstacleActive = NavObstacle.__N.CNvObs_SetObstacleActive;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, cnvObs_SetObstacleActive);
		}

		// Token: 0x040000AC RID: 172
		internal IntPtr self;

		// Token: 0x020001B5 RID: 437
		internal static class __N
		{
			// Token: 0x04000CBC RID: 3260
			internal static method CNvObs_SBOX_Create;

			// Token: 0x04000CBD RID: 3261
			internal static method CNvObs_SBOX_Delete;

			// Token: 0x04000CBE RID: 3262
			internal static method CNvObs_SBOX_Update;

			// Token: 0x04000CBF RID: 3263
			internal static method CNvObs_SetObstacleActive;
		}
	}
}
