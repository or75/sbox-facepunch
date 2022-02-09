using System;
using System.Collections.Generic;
using Native;

namespace Tools
{
	// Token: 0x020000AA RID: 170
	public class FileDialog : Widget
	{
		// Token: 0x060014B4 RID: 5300 RVA: 0x00056428 File Offset: 0x00054628
		public FileDialog(Widget parent)
		{
			QFileDialog ptr = QFileDialog.Create((parent != null) ? parent._widget : default(QWidget));
			this.NativeInit(ptr);
		}

		// Token: 0x060014B5 RID: 5301 RVA: 0x00056461 File Offset: 0x00054661
		internal override void NativeInit(IntPtr ptr)
		{
			this._filedialog = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x060014B6 RID: 5302 RVA: 0x00056476 File Offset: 0x00054676
		internal override void NativeShutdown()
		{
			this._filedialog = default(QFileDialog);
			base.NativeShutdown();
		}

		// Token: 0x060014B7 RID: 5303 RVA: 0x0005648A File Offset: 0x0005468A
		public bool Execute()
		{
			return this._filedialog.exec() != 0;
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060014B8 RID: 5304 RVA: 0x0005649A File Offset: 0x0005469A
		// (set) Token: 0x060014B9 RID: 5305 RVA: 0x000564A7 File Offset: 0x000546A7
		public string Title
		{
			get
			{
				return this._filedialog.windowTitle();
			}
			set
			{
				this._filedialog.setWindowTitle(value);
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060014BA RID: 5306 RVA: 0x000564B5 File Offset: 0x000546B5
		public string SelectedFile
		{
			get
			{
				if (this._filedialog.selectedFiles().size() == 0)
				{
					return null;
				}
				return this._filedialog.selectedFiles().at(0);
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060014BB RID: 5307 RVA: 0x000564DC File Offset: 0x000546DC
		public List<string> SelectedFiles
		{
			get
			{
				return this._filedialog.selectedFiles().ToList();
			}
		}

		// Token: 0x060014BC RID: 5308 RVA: 0x000564EE File Offset: 0x000546EE
		public void SetNameFilter(string text)
		{
			this._filedialog.setNameFilter(text);
		}

		// Token: 0x060014BD RID: 5309 RVA: 0x000564FC File Offset: 0x000546FC
		public void SetFindDirectory()
		{
			this._filedialog.setFileMode(FileDialog.FileMode.Directory);
		}

		// Token: 0x060014BE RID: 5310 RVA: 0x0005650A File Offset: 0x0005470A
		public void SetFindFile()
		{
			this._filedialog.setFileMode(FileDialog.FileMode.AnyFile);
		}

		// Token: 0x060014BF RID: 5311 RVA: 0x00056518 File Offset: 0x00054718
		public void SetFindExistingFile()
		{
			this._filedialog.setFileMode(FileDialog.FileMode.ExistingFile);
		}

		// Token: 0x060014C0 RID: 5312 RVA: 0x00056526 File Offset: 0x00054726
		public void SetFindExistingFiles()
		{
			this._filedialog.setFileMode(FileDialog.FileMode.ExistingFiles);
		}

		// Token: 0x0400041A RID: 1050
		internal QFileDialog _filedialog;

		// Token: 0x02000149 RID: 329
		internal enum ViewMode
		{
			// Token: 0x040012A4 RID: 4772
			Detail,
			// Token: 0x040012A5 RID: 4773
			List
		}

		// Token: 0x0200014A RID: 330
		internal enum FileMode
		{
			// Token: 0x040012A7 RID: 4775
			AnyFile,
			// Token: 0x040012A8 RID: 4776
			ExistingFile,
			// Token: 0x040012A9 RID: 4777
			Directory,
			// Token: 0x040012AA RID: 4778
			ExistingFiles
		}

		// Token: 0x0200014B RID: 331
		internal enum AcceptMode
		{
			// Token: 0x040012AC RID: 4780
			AcceptOpen,
			// Token: 0x040012AD RID: 4781
			AcceptSave
		}

		// Token: 0x0200014C RID: 332
		internal enum DialogLabel
		{
			// Token: 0x040012AF RID: 4783
			LookIn,
			// Token: 0x040012B0 RID: 4784
			FileName,
			// Token: 0x040012B1 RID: 4785
			FileType,
			// Token: 0x040012B2 RID: 4786
			Accept,
			// Token: 0x040012B3 RID: 4787
			Reject
		}

		// Token: 0x0200014D RID: 333
		internal enum Option
		{
			// Token: 0x040012B5 RID: 4789
			ShowDirsOnly = 1,
			// Token: 0x040012B6 RID: 4790
			DontResolveSymlinks,
			// Token: 0x040012B7 RID: 4791
			DontConfirmOverwrite = 4,
			// Token: 0x040012B8 RID: 4792
			DontUseNativeDialog = 16,
			// Token: 0x040012B9 RID: 4793
			ReadOnly = 32,
			// Token: 0x040012BA RID: 4794
			HideNameFilterDetails = 64,
			// Token: 0x040012BB RID: 4795
			DontUseCustomDirectoryIcons = 128
		}
	}
}
