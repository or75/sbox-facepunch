using System;
using System.Runtime.CompilerServices;

namespace NativeEngine
{
	// Token: 0x02000039 RID: 57
	internal struct CSunLightManager
	{
		// Token: 0x060008F0 RID: 2288 RVA: 0x00036062 File Offset: 0x00034262
		public static implicit operator IntPtr(CSunLightManager value)
		{
			return value.self;
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x0003606C File Offset: 0x0003426C
		public static implicit operator CSunLightManager(IntPtr value)
		{
			return new CSunLightManager
			{
				self = value
			};
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x0003608A File Offset: 0x0003428A
		public static bool operator ==(CSunLightManager c1, CSunLightManager c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x0003609D File Offset: 0x0003429D
		public static bool operator !=(CSunLightManager c1, CSunLightManager c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x000360B0 File Offset: 0x000342B0
		public override bool Equals(object obj)
		{
			if (obj is CSunLightManager)
			{
				CSunLightManager c = (CSunLightManager)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x000360DA File Offset: 0x000342DA
		internal CSunLightManager(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x000360E4 File Offset: 0x000342E4
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CSunLightManager ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060008F7 RID: 2295 RVA: 0x00036120 File Offset: 0x00034320
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060008F8 RID: 2296 RVA: 0x00036132 File Offset: 0x00034332
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x0003613D File Offset: 0x0003433D
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x00036150 File Offset: 0x00034350
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CSunLightManager was null when calling " + n);
			}
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x0003616B File Offset: 0x0003436B
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x040000B5 RID: 181
		internal IntPtr self;

		// Token: 0x020001BE RID: 446
		internal static class __N
		{
		}
	}
}
