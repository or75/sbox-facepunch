using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000227 RID: 551
	internal struct CPhysSurfaceProperties
	{
		// Token: 0x06000DD0 RID: 3536 RVA: 0x000185BE File Offset: 0x000167BE
		public static implicit operator IntPtr(CPhysSurfaceProperties value)
		{
			return value.self;
		}

		// Token: 0x06000DD1 RID: 3537 RVA: 0x000185C8 File Offset: 0x000167C8
		public static implicit operator CPhysSurfaceProperties(IntPtr value)
		{
			return new CPhysSurfaceProperties
			{
				self = value
			};
		}

		// Token: 0x06000DD2 RID: 3538 RVA: 0x000185E6 File Offset: 0x000167E6
		public static bool operator ==(CPhysSurfaceProperties c1, CPhysSurfaceProperties c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000DD3 RID: 3539 RVA: 0x000185F9 File Offset: 0x000167F9
		public static bool operator !=(CPhysSurfaceProperties c1, CPhysSurfaceProperties c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000DD4 RID: 3540 RVA: 0x0001860C File Offset: 0x0001680C
		public override bool Equals(object obj)
		{
			if (obj is CPhysSurfaceProperties)
			{
				CPhysSurfaceProperties c = (CPhysSurfaceProperties)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000DD5 RID: 3541 RVA: 0x00018636 File Offset: 0x00016836
		internal CPhysSurfaceProperties(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000DD6 RID: 3542 RVA: 0x00018640 File Offset: 0x00016840
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CPhysSurfaceProperties ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x06000DD7 RID: 3543 RVA: 0x0001867C File Offset: 0x0001687C
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x06000DD8 RID: 3544 RVA: 0x0001868E File Offset: 0x0001688E
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000DD9 RID: 3545 RVA: 0x00018699 File Offset: 0x00016899
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000DDA RID: 3546 RVA: 0x000186AC File Offset: 0x000168AC
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CPhysSurfaceProperties was null when calling " + n);
			}
		}

		// Token: 0x06000DDB RID: 3547 RVA: 0x000186C7 File Offset: 0x000168C7
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000DDC RID: 3548 RVA: 0x000186D4 File Offset: 0x000168D4
		internal readonly void UpdatePhysics(float Friction, float Elasticity, float Density, float Thickness, float Dampening, float BounceThreshold)
		{
			this.NullCheck("UpdatePhysics");
			method cphysS_UpdatePhysics = CPhysSurfaceProperties.__N.CPhysS_UpdatePhysics;
			calli(System.Void(System.IntPtr,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single), this.self, Friction, Elasticity, Density, Thickness, Dampening, BounceThreshold, cphysS_UpdatePhysics);
		}

		// Token: 0x06000DDD RID: 3549 RVA: 0x00018708 File Offset: 0x00016908
		internal readonly void UpdateSounds(string scrapeSmooth, string scrapeRough, float roughness, float roughthreshold, float hardImpactThreshold)
		{
			this.NullCheck("UpdateSounds");
			method cphysS_UpdateSounds = CPhysSurfaceProperties.__N.CPhysS_UpdateSounds;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr,System.Single,System.Single,System.Single), this.self, Interop.GetPointer(scrapeSmooth), Interop.GetPointer(scrapeRough), roughness, roughthreshold, hardImpactThreshold, cphysS_UpdateSounds);
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x06000DDE RID: 3550 RVA: 0x00018743 File Offset: 0x00016943
		// (set) Token: 0x06000DDF RID: 3551 RVA: 0x00018765 File Offset: 0x00016965
		internal string m_name
		{
			get
			{
				this.NullCheck("m_name");
				return Interop.GetString(CPhysSurfaceProperties.__N.Get__CPhysS_m_name(this.self));
			}
			set
			{
				this.NullCheck("m_name");
				CPhysSurfaceProperties.__N.Set__CPhysS_m_name(this.self, Interop.GetPointer(value));
			}
		}

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x06000DE0 RID: 3552 RVA: 0x00018788 File Offset: 0x00016988
		// (set) Token: 0x06000DE1 RID: 3553 RVA: 0x000187A5 File Offset: 0x000169A5
		internal uint m_nameHash
		{
			get
			{
				this.NullCheck("m_nameHash");
				return CPhysSurfaceProperties.__N.Get__CPhysS_m_nameHash(this.self);
			}
			set
			{
				this.NullCheck("m_nameHash");
				CPhysSurfaceProperties.__N.Set__CPhysS_m_nameHash(this.self, value);
			}
		}

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x06000DE2 RID: 3554 RVA: 0x000187C3 File Offset: 0x000169C3
		// (set) Token: 0x06000DE3 RID: 3555 RVA: 0x000187E0 File Offset: 0x000169E0
		internal uint m_baseNameHash
		{
			get
			{
				this.NullCheck("m_baseNameHash");
				return CPhysSurfaceProperties.__N.Get__CPhysS_m_baseNameHash(this.self);
			}
			set
			{
				this.NullCheck("m_baseNameHash");
				CPhysSurfaceProperties.__N.Set__CPhysS_m_baseNameHash(this.self, value);
			}
		}

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x06000DE4 RID: 3556 RVA: 0x000187FE File Offset: 0x000169FE
		// (set) Token: 0x06000DE5 RID: 3557 RVA: 0x0001881B File Offset: 0x00016A1B
		internal int m_nIndex
		{
			get
			{
				this.NullCheck("m_nIndex");
				return CPhysSurfaceProperties.__N.Get__CPhysS_m_nIndex(this.self);
			}
			set
			{
				this.NullCheck("m_nIndex");
				CPhysSurfaceProperties.__N.Set__CPhysS_m_nIndex(this.self, value);
			}
		}

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x06000DE6 RID: 3558 RVA: 0x00018839 File Offset: 0x00016A39
		// (set) Token: 0x06000DE7 RID: 3559 RVA: 0x00018856 File Offset: 0x00016A56
		internal int m_nBaseIndex
		{
			get
			{
				this.NullCheck("m_nBaseIndex");
				return CPhysSurfaceProperties.__N.Get__CPhysS_m_nBaseIndex(this.self);
			}
			set
			{
				this.NullCheck("m_nBaseIndex");
				CPhysSurfaceProperties.__N.Set__CPhysS_m_nBaseIndex(this.self, value);
			}
		}

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x06000DE8 RID: 3560 RVA: 0x00018874 File Offset: 0x00016A74
		// (set) Token: 0x06000DE9 RID: 3561 RVA: 0x00018894 File Offset: 0x00016A94
		internal bool m_bHidden
		{
			get
			{
				this.NullCheck("m_bHidden");
				return CPhysSurfaceProperties.__N.Get__CPhysS_m_bHidden(this.self) != 0;
			}
			set
			{
				this.NullCheck("m_bHidden");
				CPhysSurfaceProperties.__N.Set__CPhysS_m_bHidden(this.self, value ? 1 : 0);
			}
		}

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x06000DEA RID: 3562 RVA: 0x000188B8 File Offset: 0x00016AB8
		// (set) Token: 0x06000DEB RID: 3563 RVA: 0x000188DA File Offset: 0x00016ADA
		internal string m_description
		{
			get
			{
				this.NullCheck("m_description");
				return Interop.GetString(CPhysSurfaceProperties.__N.Get__CPhysS_m_description(this.self));
			}
			set
			{
				this.NullCheck("m_description");
				CPhysSurfaceProperties.__N.Set__CPhysS_m_description(this.self, Interop.GetPointer(value));
			}
		}

		// Token: 0x04000E3E RID: 3646
		internal IntPtr self;

		// Token: 0x0200038C RID: 908
		internal static class __N
		{
			// Token: 0x04001805 RID: 6149
			internal static method CPhysS_UpdatePhysics;

			// Token: 0x04001806 RID: 6150
			internal static method CPhysS_UpdateSounds;

			// Token: 0x04001807 RID: 6151
			internal static CPhysSurfaceProperties.__N._Get__CPhysS_m_name Get__CPhysS_m_name;

			// Token: 0x04001808 RID: 6152
			internal static CPhysSurfaceProperties.__N._Set__CPhysS_m_name Set__CPhysS_m_name;

			// Token: 0x04001809 RID: 6153
			internal static CPhysSurfaceProperties.__N._Get__CPhysS_m_nameHash Get__CPhysS_m_nameHash;

			// Token: 0x0400180A RID: 6154
			internal static CPhysSurfaceProperties.__N._Set__CPhysS_m_nameHash Set__CPhysS_m_nameHash;

			// Token: 0x0400180B RID: 6155
			internal static CPhysSurfaceProperties.__N._Get__CPhysS_m_baseNameHash Get__CPhysS_m_baseNameHash;

			// Token: 0x0400180C RID: 6156
			internal static CPhysSurfaceProperties.__N._Set__CPhysS_m_baseNameHash Set__CPhysS_m_baseNameHash;

			// Token: 0x0400180D RID: 6157
			internal static CPhysSurfaceProperties.__N._Get__CPhysS_m_nIndex Get__CPhysS_m_nIndex;

			// Token: 0x0400180E RID: 6158
			internal static CPhysSurfaceProperties.__N._Set__CPhysS_m_nIndex Set__CPhysS_m_nIndex;

			// Token: 0x0400180F RID: 6159
			internal static CPhysSurfaceProperties.__N._Get__CPhysS_m_nBaseIndex Get__CPhysS_m_nBaseIndex;

			// Token: 0x04001810 RID: 6160
			internal static CPhysSurfaceProperties.__N._Set__CPhysS_m_nBaseIndex Set__CPhysS_m_nBaseIndex;

			// Token: 0x04001811 RID: 6161
			internal static CPhysSurfaceProperties.__N._Get__CPhysS_m_bHidden Get__CPhysS_m_bHidden;

			// Token: 0x04001812 RID: 6162
			internal static CPhysSurfaceProperties.__N._Set__CPhysS_m_bHidden Set__CPhysS_m_bHidden;

			// Token: 0x04001813 RID: 6163
			internal static CPhysSurfaceProperties.__N._Get__CPhysS_m_description Get__CPhysS_m_description;

			// Token: 0x04001814 RID: 6164
			internal static CPhysSurfaceProperties.__N._Set__CPhysS_m_description Set__CPhysS_m_description;

			// Token: 0x0200047D RID: 1149
			// (Invoke) Token: 0x060019A7 RID: 6567
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr _Get__CPhysS_m_name(IntPtr self);

			// Token: 0x0200047E RID: 1150
			// (Invoke) Token: 0x060019AB RID: 6571
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CPhysS_m_name(IntPtr self, IntPtr val);

			// Token: 0x0200047F RID: 1151
			// (Invoke) Token: 0x060019AF RID: 6575
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate uint _Get__CPhysS_m_nameHash(IntPtr self);

			// Token: 0x02000480 RID: 1152
			// (Invoke) Token: 0x060019B3 RID: 6579
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CPhysS_m_nameHash(IntPtr self, uint val);

			// Token: 0x02000481 RID: 1153
			// (Invoke) Token: 0x060019B7 RID: 6583
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate uint _Get__CPhysS_m_baseNameHash(IntPtr self);

			// Token: 0x02000482 RID: 1154
			// (Invoke) Token: 0x060019BB RID: 6587
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CPhysS_m_baseNameHash(IntPtr self, uint val);

			// Token: 0x02000483 RID: 1155
			// (Invoke) Token: 0x060019BF RID: 6591
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int _Get__CPhysS_m_nIndex(IntPtr self);

			// Token: 0x02000484 RID: 1156
			// (Invoke) Token: 0x060019C3 RID: 6595
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CPhysS_m_nIndex(IntPtr self, int val);

			// Token: 0x02000485 RID: 1157
			// (Invoke) Token: 0x060019C7 RID: 6599
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int _Get__CPhysS_m_nBaseIndex(IntPtr self);

			// Token: 0x02000486 RID: 1158
			// (Invoke) Token: 0x060019CB RID: 6603
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CPhysS_m_nBaseIndex(IntPtr self, int val);

			// Token: 0x02000487 RID: 1159
			// (Invoke) Token: 0x060019CF RID: 6607
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int _Get__CPhysS_m_bHidden(IntPtr self);

			// Token: 0x02000488 RID: 1160
			// (Invoke) Token: 0x060019D3 RID: 6611
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CPhysS_m_bHidden(IntPtr self, int val);

			// Token: 0x02000489 RID: 1161
			// (Invoke) Token: 0x060019D7 RID: 6615
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr _Get__CPhysS_m_description(IntPtr self);

			// Token: 0x0200048A RID: 1162
			// (Invoke) Token: 0x060019DB RID: 6619
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CPhysS_m_description(IntPtr self, IntPtr val);
		}
	}
}
