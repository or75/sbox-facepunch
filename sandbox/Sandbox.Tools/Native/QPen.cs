using System;
using System.Runtime.CompilerServices;

namespace Native
{
	// Token: 0x02000054 RID: 84
	internal struct QPen : IDisposable
	{
		// Token: 0x06000CCA RID: 3274 RVA: 0x00022A22 File Offset: 0x00020C22
		public static implicit operator IntPtr(QPen value)
		{
			return value.self;
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x00022A2C File Offset: 0x00020C2C
		public static implicit operator QPen(IntPtr value)
		{
			return new QPen
			{
				self = value
			};
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x00022A4A File Offset: 0x00020C4A
		public static bool operator ==(QPen c1, QPen c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000CCD RID: 3277 RVA: 0x00022A5D File Offset: 0x00020C5D
		public static bool operator !=(QPen c1, QPen c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000CCE RID: 3278 RVA: 0x00022A70 File Offset: 0x00020C70
		public override bool Equals(object obj)
		{
			if (obj is QPen)
			{
				QPen c = (QPen)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000CCF RID: 3279 RVA: 0x00022A9A File Offset: 0x00020C9A
		internal QPen(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000CD0 RID: 3280 RVA: 0x00022AA4 File Offset: 0x00020CA4
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QPen ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000CD1 RID: 3281 RVA: 0x00022ADF File Offset: 0x00020CDF
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000CD2 RID: 3282 RVA: 0x00022AF1 File Offset: 0x00020CF1
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000CD3 RID: 3283 RVA: 0x00022AFC File Offset: 0x00020CFC
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x00022B0F File Offset: 0x00020D0F
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QPen was null when calling " + n);
			}
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x00022B2A File Offset: 0x00020D2A
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x00022B38 File Offset: 0x00020D38
		void IDisposable.Dispose()
		{
			if (this.IsNull)
			{
				return;
			}
			this.NullCheck("Dispose");
			method qpen_Dispose = QPen.__N.QPen_Dispose;
			calli(System.Void(System.IntPtr), this.self, qpen_Dispose);
		}

		// Token: 0x06000CD7 RID: 3287 RVA: 0x00022B6B File Offset: 0x00020D6B
		internal static QPen Create()
		{
			return calli(System.IntPtr(), QPen.__N.QPen_Create);
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x00022B7C File Offset: 0x00020D7C
		internal readonly void setDashOffset(float doffset)
		{
			this.NullCheck("setDashOffset");
			method qpen_setDashOffset = QPen.__N.QPen_setDashOffset;
			calli(System.Void(System.IntPtr,System.Single), this.self, doffset, qpen_setDashOffset);
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x00022BA8 File Offset: 0x00020DA8
		internal readonly void setMiterLimit(float limit)
		{
			this.NullCheck("setMiterLimit");
			method qpen_setMiterLimit = QPen.__N.QPen_setMiterLimit;
			calli(System.Void(System.IntPtr,System.Single), this.self, limit, qpen_setMiterLimit);
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x00022BD4 File Offset: 0x00020DD4
		internal readonly void setWidthF(float width)
		{
			this.NullCheck("setWidthF");
			method qpen_setWidthF = QPen.__N.QPen_setWidthF;
			calli(System.Void(System.IntPtr,System.Single), this.self, width, qpen_setWidthF);
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x00022C00 File Offset: 0x00020E00
		internal readonly void setColor(Color32 color)
		{
			this.NullCheck("setColor");
			method qpen_setColor = QPen.__N.QPen_setColor;
			calli(System.Void(System.IntPtr,Color32), this.self, color, qpen_setColor);
		}

		// Token: 0x06000CDC RID: 3292 RVA: 0x00022C2C File Offset: 0x00020E2C
		internal readonly void setBrush(QBrush brush)
		{
			this.NullCheck("setBrush");
			method qpen_setBrush = QPen.__N.QPen_setBrush;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, brush, qpen_setBrush);
		}

		// Token: 0x06000CDD RID: 3293 RVA: 0x00022C5C File Offset: 0x00020E5C
		internal readonly void setCosmetic(bool cosmetic)
		{
			this.NullCheck("setCosmetic");
			method qpen_setCosmetic = QPen.__N.QPen_setCosmetic;
			calli(System.Void(System.IntPtr,System.Int32), this.self, cosmetic ? 1 : 0, qpen_setCosmetic);
		}

		// Token: 0x0400005F RID: 95
		internal IntPtr self;

		// Token: 0x02000120 RID: 288
		internal static class __N
		{
			// Token: 0x04000EA0 RID: 3744
			internal static method QPen_Dispose;

			// Token: 0x04000EA1 RID: 3745
			internal static method QPen_Create;

			// Token: 0x04000EA2 RID: 3746
			internal static method QPen_setDashOffset;

			// Token: 0x04000EA3 RID: 3747
			internal static method QPen_setMiterLimit;

			// Token: 0x04000EA4 RID: 3748
			internal static method QPen_setWidthF;

			// Token: 0x04000EA5 RID: 3749
			internal static method QPen_setColor;

			// Token: 0x04000EA6 RID: 3750
			internal static method QPen_setBrush;

			// Token: 0x04000EA7 RID: 3751
			internal static method QPen_setCosmetic;
		}
	}
}
