using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000221 RID: 545
	internal struct CEntityClass
	{
		// Token: 0x06000D48 RID: 3400 RVA: 0x000173B1 File Offset: 0x000155B1
		public static implicit operator IntPtr(CEntityClass value)
		{
			return value.self;
		}

		// Token: 0x06000D49 RID: 3401 RVA: 0x000173BC File Offset: 0x000155BC
		public static implicit operator CEntityClass(IntPtr value)
		{
			return new CEntityClass
			{
				self = value
			};
		}

		// Token: 0x06000D4A RID: 3402 RVA: 0x000173DA File Offset: 0x000155DA
		public static bool operator ==(CEntityClass c1, CEntityClass c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000D4B RID: 3403 RVA: 0x000173ED File Offset: 0x000155ED
		public static bool operator !=(CEntityClass c1, CEntityClass c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000D4C RID: 3404 RVA: 0x00017400 File Offset: 0x00015600
		public override bool Equals(object obj)
		{
			if (obj is CEntityClass)
			{
				CEntityClass c = (CEntityClass)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000D4D RID: 3405 RVA: 0x0001742A File Offset: 0x0001562A
		internal CEntityClass(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000D4E RID: 3406 RVA: 0x00017434 File Offset: 0x00015634
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CEntityClass ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x06000D4F RID: 3407 RVA: 0x00017470 File Offset: 0x00015670
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x06000D50 RID: 3408 RVA: 0x00017482 File Offset: 0x00015682
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000D51 RID: 3409 RVA: 0x0001748D File Offset: 0x0001568D
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000D52 RID: 3410 RVA: 0x000174A0 File Offset: 0x000156A0
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CEntityClass was null when calling " + n);
			}
		}

		// Token: 0x06000D53 RID: 3411 RVA: 0x000174BB File Offset: 0x000156BB
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000D54 RID: 3412 RVA: 0x000174C8 File Offset: 0x000156C8
		internal readonly void OnRegister()
		{
			this.NullCheck("OnRegister");
			method centty_OnRegister = CEntityClass.__N.CEntty_OnRegister;
			calli(System.Void(System.IntPtr), this.self, centty_OnRegister);
		}

		// Token: 0x06000D55 RID: 3413 RVA: 0x000174F4 File Offset: 0x000156F4
		internal readonly CEntityClass GetBaseClass()
		{
			this.NullCheck("GetBaseClass");
			method centty_GetBaseClass = CEntityClass.__N.CEntty_GetBaseClass;
			return calli(System.IntPtr(System.IntPtr), this.self, centty_GetBaseClass);
		}

		// Token: 0x06000D56 RID: 3414 RVA: 0x00017524 File Offset: 0x00015724
		internal readonly uint GetFlags()
		{
			this.NullCheck("GetFlags");
			method centty_GetFlags = CEntityClass.__N.CEntty_GetFlags;
			return calli(System.UInt32(System.IntPtr), this.self, centty_GetFlags);
		}

		// Token: 0x06000D57 RID: 3415 RVA: 0x00017550 File Offset: 0x00015750
		internal readonly string GetNameAsCStr()
		{
			this.NullCheck("GetNameAsCStr");
			method centty_GetNameAsCStr = CEntityClass.__N.CEntty_GetNameAsCStr;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, centty_GetNameAsCStr));
		}

		// Token: 0x06000D58 RID: 3416 RVA: 0x00017580 File Offset: 0x00015780
		internal readonly string GetCPPClassName()
		{
			this.NullCheck("GetCPPClassName");
			method centty_GetCPPClassName = CEntityClass.__N.CEntty_GetCPPClassName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, centty_GetCPPClassName));
		}

		// Token: 0x06000D59 RID: 3417 RVA: 0x000175B0 File Offset: 0x000157B0
		internal readonly bool ClassMatches(string pszClassNameOrWildcard)
		{
			this.NullCheck("ClassMatches");
			method centty_ClassMatches = CEntityClass.__N.CEntty_ClassMatches;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pszClassNameOrWildcard), centty_ClassMatches) > 0;
		}

		// Token: 0x04000E38 RID: 3640
		internal IntPtr self;

		// Token: 0x02000386 RID: 902
		internal static class __N
		{
			// Token: 0x040017C5 RID: 6085
			internal static method CEntty_OnRegister;

			// Token: 0x040017C6 RID: 6086
			internal static method CEntty_GetBaseClass;

			// Token: 0x040017C7 RID: 6087
			internal static method CEntty_GetFlags;

			// Token: 0x040017C8 RID: 6088
			internal static method CEntty_GetNameAsCStr;

			// Token: 0x040017C9 RID: 6089
			internal static method CEntty_GetCPPClassName;

			// Token: 0x040017CA RID: 6090
			internal static method CEntty_ClassMatches;
		}
	}
}
