using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace Native
{
	// Token: 0x02000055 RID: 85
	internal struct QPixmap : IDisposable
	{
		// Token: 0x06000CDE RID: 3294 RVA: 0x00022C8D File Offset: 0x00020E8D
		public static implicit operator IntPtr(QPixmap value)
		{
			return value.self;
		}

		// Token: 0x06000CDF RID: 3295 RVA: 0x00022C98 File Offset: 0x00020E98
		public static implicit operator QPixmap(IntPtr value)
		{
			return new QPixmap
			{
				self = value
			};
		}

		// Token: 0x06000CE0 RID: 3296 RVA: 0x00022CB6 File Offset: 0x00020EB6
		public static bool operator ==(QPixmap c1, QPixmap c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x00022CC9 File Offset: 0x00020EC9
		public static bool operator !=(QPixmap c1, QPixmap c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000CE2 RID: 3298 RVA: 0x00022CDC File Offset: 0x00020EDC
		public override bool Equals(object obj)
		{
			if (obj is QPixmap)
			{
				QPixmap c = (QPixmap)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x00022D06 File Offset: 0x00020F06
		internal QPixmap(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x00022D10 File Offset: 0x00020F10
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QPixmap ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000CE5 RID: 3301 RVA: 0x00022D4B File Offset: 0x00020F4B
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000CE6 RID: 3302 RVA: 0x00022D5D File Offset: 0x00020F5D
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x00022D68 File Offset: 0x00020F68
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x00022D7B File Offset: 0x00020F7B
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QPixmap was null when calling " + n);
			}
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x00022D96 File Offset: 0x00020F96
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x00022DA4 File Offset: 0x00020FA4
		void IDisposable.Dispose()
		{
			if (this.IsNull)
			{
				return;
			}
			this.NullCheck("Dispose");
			method qpixma_Dispose = QPixmap.__N.QPixma_Dispose;
			calli(System.Void(System.IntPtr), this.self, qpixma_Dispose);
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x00022DD8 File Offset: 0x00020FD8
		internal static QPixmap CreateFromFile(string filename)
		{
			method qpixma_CreateFromFile = QPixmap.__N.QPixma_CreateFromFile;
			return calli(System.IntPtr(System.IntPtr), Interop.GetWPointer(filename), qpixma_CreateFromFile);
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x00022DFC File Offset: 0x00020FFC
		internal static QPixmap Create(int w, int h)
		{
			method qpixma_Create = QPixmap.__N.QPixma_Create;
			return calli(System.IntPtr(System.Int32,System.Int32), w, h, qpixma_Create);
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x00022E1C File Offset: 0x0002101C
		internal readonly int width()
		{
			this.NullCheck("width");
			method qpixma_width = QPixmap.__N.QPixma_width;
			return calli(System.Int32(System.IntPtr), this.self, qpixma_width);
		}

		// Token: 0x06000CEE RID: 3310 RVA: 0x00022E48 File Offset: 0x00021048
		internal readonly int height()
		{
			this.NullCheck("height");
			method qpixma_height = QPixmap.__N.QPixma_height;
			return calli(System.Int32(System.IntPtr), this.self, qpixma_height);
		}

		// Token: 0x06000CEF RID: 3311 RVA: 0x00022E74 File Offset: 0x00021074
		internal readonly int depth()
		{
			this.NullCheck("depth");
			method qpixma_depth = QPixmap.__N.QPixma_depth;
			return calli(System.Int32(System.IntPtr), this.self, qpixma_depth);
		}

		// Token: 0x06000CF0 RID: 3312 RVA: 0x00022EA0 File Offset: 0x000210A0
		internal readonly void fill(Color32 color)
		{
			this.NullCheck("fill");
			method qpixma_fill = QPixmap.__N.QPixma_fill;
			calli(System.Void(System.IntPtr,Color32), this.self, color, qpixma_fill);
		}

		// Token: 0x04000060 RID: 96
		internal IntPtr self;

		// Token: 0x02000121 RID: 289
		internal static class __N
		{
			// Token: 0x04000EA8 RID: 3752
			internal static method QPixma_Dispose;

			// Token: 0x04000EA9 RID: 3753
			internal static method QPixma_CreateFromFile;

			// Token: 0x04000EAA RID: 3754
			internal static method QPixma_Create;

			// Token: 0x04000EAB RID: 3755
			internal static method QPixma_width;

			// Token: 0x04000EAC RID: 3756
			internal static method QPixma_height;

			// Token: 0x04000EAD RID: 3757
			internal static method QPixma_depth;

			// Token: 0x04000EAE RID: 3758
			internal static method QPixma_fill;
		}
	}
}
