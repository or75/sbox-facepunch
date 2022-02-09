using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000054 RID: 84
	internal struct ISceneWorld
	{
		// Token: 0x06000B61 RID: 2913 RVA: 0x0003BF42 File Offset: 0x0003A142
		public static implicit operator IntPtr(ISceneWorld value)
		{
			return value.self;
		}

		// Token: 0x06000B62 RID: 2914 RVA: 0x0003BF4C File Offset: 0x0003A14C
		public static implicit operator ISceneWorld(IntPtr value)
		{
			return new ISceneWorld
			{
				self = value
			};
		}

		// Token: 0x06000B63 RID: 2915 RVA: 0x0003BF6A File Offset: 0x0003A16A
		public static bool operator ==(ISceneWorld c1, ISceneWorld c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000B64 RID: 2916 RVA: 0x0003BF7D File Offset: 0x0003A17D
		public static bool operator !=(ISceneWorld c1, ISceneWorld c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000B65 RID: 2917 RVA: 0x0003BF90 File Offset: 0x0003A190
		public override bool Equals(object obj)
		{
			if (obj is ISceneWorld)
			{
				ISceneWorld c = (ISceneWorld)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x0003BFBA File Offset: 0x0003A1BA
		internal ISceneWorld(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000B67 RID: 2919 RVA: 0x0003BFC4 File Offset: 0x0003A1C4
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
			defaultInterpolatedStringHandler.AppendLiteral("ISceneWorld ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000B68 RID: 2920 RVA: 0x0003C000 File Offset: 0x0003A200
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000B69 RID: 2921 RVA: 0x0003C012 File Offset: 0x0003A212
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x0003C01D File Offset: 0x0003A21D
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x0003C030 File Offset: 0x0003A230
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("ISceneWorld was null when calling " + n);
			}
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x0003C04B File Offset: 0x0003A24B
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x0003C058 File Offset: 0x0003A258
		internal readonly Light GetFirstVisibleSunLight()
		{
			this.NullCheck("GetFirstVisibleSunLight");
			method iscene_GetFirstVisibleSunLight = ISceneWorld.__N.IScene_GetFirstVisibleSunLight;
			return HandleIndex.Get<Light>(calli(System.Int32(System.IntPtr), this.self, iscene_GetFirstVisibleSunLight));
		}

		// Token: 0x040000C2 RID: 194
		internal IntPtr self;

		// Token: 0x020001D9 RID: 473
		internal static class __N
		{
			// Token: 0x0400101C RID: 4124
			internal static method IScene_GetFirstVisibleSunLight;
		}
	}
}
