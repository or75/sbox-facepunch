using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000242 RID: 578
	internal struct IPhysSurfacePropertyController
	{
		// Token: 0x06000EDD RID: 3805 RVA: 0x0001A5AF File Offset: 0x000187AF
		public static implicit operator IntPtr(IPhysSurfacePropertyController value)
		{
			return value.self;
		}

		// Token: 0x06000EDE RID: 3806 RVA: 0x0001A5B8 File Offset: 0x000187B8
		public static implicit operator IPhysSurfacePropertyController(IntPtr value)
		{
			return new IPhysSurfacePropertyController
			{
				self = value
			};
		}

		// Token: 0x06000EDF RID: 3807 RVA: 0x0001A5D6 File Offset: 0x000187D6
		public static bool operator ==(IPhysSurfacePropertyController c1, IPhysSurfacePropertyController c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000EE0 RID: 3808 RVA: 0x0001A5E9 File Offset: 0x000187E9
		public static bool operator !=(IPhysSurfacePropertyController c1, IPhysSurfacePropertyController c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000EE1 RID: 3809 RVA: 0x0001A5FC File Offset: 0x000187FC
		public override bool Equals(object obj)
		{
			if (obj is IPhysSurfacePropertyController)
			{
				IPhysSurfacePropertyController c = (IPhysSurfacePropertyController)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000EE2 RID: 3810 RVA: 0x0001A626 File Offset: 0x00018826
		internal IPhysSurfacePropertyController(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000EE3 RID: 3811 RVA: 0x0001A630 File Offset: 0x00018830
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 1);
			defaultInterpolatedStringHandler.AppendLiteral("IPhysSurfacePropertyController ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06000EE4 RID: 3812 RVA: 0x0001A66C File Offset: 0x0001886C
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x06000EE5 RID: 3813 RVA: 0x0001A67E File Offset: 0x0001887E
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000EE6 RID: 3814 RVA: 0x0001A689 File Offset: 0x00018889
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000EE7 RID: 3815 RVA: 0x0001A69C File Offset: 0x0001889C
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("IPhysSurfacePropertyController was null when calling " + n);
			}
		}

		// Token: 0x06000EE8 RID: 3816 RVA: 0x0001A6B7 File Offset: 0x000188B7
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000EE9 RID: 3817 RVA: 0x0001A6C4 File Offset: 0x000188C4
		internal readonly int GetSurfacePropCount()
		{
			this.NullCheck("GetSurfacePropCount");
			method iphysS_GetSurfacePropCount = IPhysSurfacePropertyController.__N.IPhysS_GetSurfacePropCount;
			return calli(System.Int32(System.IntPtr), this.self, iphysS_GetSurfacePropCount);
		}

		// Token: 0x06000EEA RID: 3818 RVA: 0x0001A6F0 File Offset: 0x000188F0
		internal readonly CPhysSurfaceProperties GetSurfaceProperty(int nIndex)
		{
			this.NullCheck("GetSurfaceProperty");
			method iphysS_GetSurfaceProperty = IPhysSurfacePropertyController.__N.IPhysS_GetSurfaceProperty;
			return calli(System.IntPtr(System.IntPtr,System.Int32), this.self, nIndex, iphysS_GetSurfaceProperty);
		}

		// Token: 0x06000EEB RID: 3819 RVA: 0x0001A720 File Offset: 0x00018920
		internal readonly CPhysSurfaceProperties AddProperty(string name, string basename, string description)
		{
			this.NullCheck("AddProperty");
			method iphysS_AddProperty = IPhysSurfacePropertyController.__N.IPhysS_AddProperty;
			return calli(System.IntPtr(System.IntPtr,System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), Interop.GetPointer(basename), Interop.GetPointer(description), iphysS_AddProperty);
		}

		// Token: 0x04000E48 RID: 3656
		internal IntPtr self;

		// Token: 0x020003A7 RID: 935
		internal static class __N
		{
			// Token: 0x0400189A RID: 6298
			internal static method IPhysS_GetSurfacePropCount;

			// Token: 0x0400189B RID: 6299
			internal static method IPhysS_GetSurfaceProperty;

			// Token: 0x0400189C RID: 6300
			internal static method IPhysS_AddProperty;
		}
	}
}
