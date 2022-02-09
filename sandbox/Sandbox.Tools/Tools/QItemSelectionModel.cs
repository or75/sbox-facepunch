using System;
using System.Runtime.CompilerServices;

namespace Tools
{
	// Token: 0x02000083 RID: 131
	internal struct QItemSelectionModel
	{
		// Token: 0x06001339 RID: 4921 RVA: 0x000530E0 File Offset: 0x000512E0
		public static implicit operator IntPtr(QItemSelectionModel value)
		{
			return value.self;
		}

		// Token: 0x0600133A RID: 4922 RVA: 0x000530E8 File Offset: 0x000512E8
		public static implicit operator QItemSelectionModel(IntPtr value)
		{
			return new QItemSelectionModel
			{
				self = value
			};
		}

		// Token: 0x0600133B RID: 4923 RVA: 0x00053106 File Offset: 0x00051306
		public static bool operator ==(QItemSelectionModel c1, QItemSelectionModel c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600133C RID: 4924 RVA: 0x00053119 File Offset: 0x00051319
		public static bool operator !=(QItemSelectionModel c1, QItemSelectionModel c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600133D RID: 4925 RVA: 0x0005312C File Offset: 0x0005132C
		public override bool Equals(object obj)
		{
			if (obj is QItemSelectionModel)
			{
				QItemSelectionModel c = (QItemSelectionModel)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x0600133E RID: 4926 RVA: 0x00053156 File Offset: 0x00051356
		internal QItemSelectionModel(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x0600133F RID: 4927 RVA: 0x00053160 File Offset: 0x00051360
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QItemSelectionModel ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06001340 RID: 4928 RVA: 0x0005319C File Offset: 0x0005139C
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06001341 RID: 4929 RVA: 0x000531AE File Offset: 0x000513AE
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06001342 RID: 4930 RVA: 0x000531B9 File Offset: 0x000513B9
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06001343 RID: 4931 RVA: 0x000531CC File Offset: 0x000513CC
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QItemSelectionModel was null when calling " + n);
			}
		}

		// Token: 0x06001344 RID: 4932 RVA: 0x000531E7 File Offset: 0x000513E7
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06001345 RID: 4933 RVA: 0x000531F4 File Offset: 0x000513F4
		internal readonly ModelIndex currentIndex()
		{
			this.NullCheck("currentIndex");
			method qitemS_currentIndex = QItemSelectionModel.__N.QItemS_currentIndex;
			return calli(Tools.ModelIndex(System.IntPtr), this.self, qitemS_currentIndex);
		}

		// Token: 0x06001346 RID: 4934 RVA: 0x00053220 File Offset: 0x00051420
		internal readonly bool hasSelection()
		{
			this.NullCheck("hasSelection");
			method qitemS_hasSelection = QItemSelectionModel.__N.QItemS_hasSelection;
			return calli(System.Int32(System.IntPtr), this.self, qitemS_hasSelection) > 0;
		}

		// Token: 0x06001347 RID: 4935 RVA: 0x00053250 File Offset: 0x00051450
		internal readonly QModelIndexList selectedIndexes()
		{
			this.NullCheck("selectedIndexes");
			method qitemS_selectedIndexes = QItemSelectionModel.__N.QItemS_selectedIndexes;
			return new QModelIndexList(calli(System.IntPtr(System.IntPtr), this.self, qitemS_selectedIndexes));
		}

		// Token: 0x06001348 RID: 4936 RVA: 0x00053280 File Offset: 0x00051480
		internal readonly void clearSelection()
		{
			this.NullCheck("clearSelection");
			method qitemS_clearSelection = QItemSelectionModel.__N.QItemS_clearSelection;
			calli(System.Void(System.IntPtr), this.self, qitemS_clearSelection);
		}

		// Token: 0x06001349 RID: 4937 RVA: 0x000532AC File Offset: 0x000514AC
		internal readonly void clearCurrentIndex()
		{
			this.NullCheck("clearCurrentIndex");
			method qitemS_clearCurrentIndex = QItemSelectionModel.__N.QItemS_clearCurrentIndex;
			calli(System.Void(System.IntPtr), this.self, qitemS_clearCurrentIndex);
		}

		// Token: 0x040001B7 RID: 439
		internal IntPtr self;

		// Token: 0x0200013E RID: 318
		internal static class __N
		{
			// Token: 0x0400125F RID: 4703
			internal static method QItemS_currentIndex;

			// Token: 0x04001260 RID: 4704
			internal static method QItemS_hasSelection;

			// Token: 0x04001261 RID: 4705
			internal static method QItemS_selectedIndexes;

			// Token: 0x04001262 RID: 4706
			internal static method QItemS_clearSelection;

			// Token: 0x04001263 RID: 4707
			internal static method QItemS_clearCurrentIndex;
		}
	}
}
