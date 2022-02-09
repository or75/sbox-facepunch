using System;
using Sandbox;

namespace Tools
{
	// Token: 0x02000093 RID: 147
	public struct ModelIndex
	{
		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06001455 RID: 5205 RVA: 0x000559B3 File Offset: 0x00053BB3
		public DataModel Model
		{
			get
			{
				return InteropSystem.Get<DataModel>(this.ModelIdx);
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06001456 RID: 5206 RVA: 0x000559C0 File Offset: 0x00053BC0
		public DataNode Node
		{
			get
			{
				DataModel model = this.Model;
				if (model == null)
				{
					return null;
				}
				return model.GetNode(this);
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06001457 RID: 5207 RVA: 0x000559D9 File Offset: 0x00053BD9
		public bool IsValid
		{
			get
			{
				return this.Row >= 0 && this.Column >= 0;
			}
		}

		// Token: 0x06001458 RID: 5208 RVA: 0x000559F2 File Offset: 0x00053BF2
		public override string ToString()
		{
			DataNode node = this.Node;
			return ((node != null) ? node.ToString() : null) ?? "null";
		}

		// Token: 0x06001459 RID: 5209 RVA: 0x00055A0F File Offset: 0x00053C0F
		public ModelIndex()
		{
			this.Row = -1;
			this.Column = -1;
			this.ModelIdx = 0U;
			this.Index = 0;
			this.DataModel = 0;
		}

		// Token: 0x040001EE RID: 494
		public int Row;

		// Token: 0x040001EF RID: 495
		public int Column;

		// Token: 0x040001F0 RID: 496
		public uint ModelIdx;

		// Token: 0x040001F1 RID: 497
		public int Index;

		// Token: 0x040001F2 RID: 498
		internal IntPtr DataModel;
	}
}
