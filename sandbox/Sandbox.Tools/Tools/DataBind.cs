using System;

namespace Tools
{
	// Token: 0x020000D4 RID: 212
	public class DataBind
	{
		// Token: 0x060017B4 RID: 6068 RVA: 0x0005B8EC File Offset: 0x00059AEC
		public void StartRead()
		{
			this.reading++;
		}

		// Token: 0x060017B5 RID: 6069 RVA: 0x0005B8FC File Offset: 0x00059AFC
		public void EndRead()
		{
			this.reading--;
		}

		// Token: 0x060017B6 RID: 6070 RVA: 0x0005B90C File Offset: 0x00059B0C
		private bool CanWrite()
		{
			return this.reading == 0;
		}

		// Token: 0x060017B7 RID: 6071 RVA: 0x0005B917 File Offset: 0x00059B17
		public void SetValue(object value)
		{
			if (!this.CanWrite())
			{
				return;
			}
			this.SetDataValue(value);
		}

		// Token: 0x060017B8 RID: 6072 RVA: 0x0005B929 File Offset: 0x00059B29
		protected virtual void SetDataValue(object value)
		{
		}

		// Token: 0x060017B9 RID: 6073 RVA: 0x0005B92B File Offset: 0x00059B2B
		public virtual object GetValue()
		{
			return null;
		}

		// Token: 0x060017BA RID: 6074 RVA: 0x0005B92E File Offset: 0x00059B2E
		public virtual Type GetTargetType()
		{
			return null;
		}

		// Token: 0x060017BB RID: 6075 RVA: 0x0005B931 File Offset: 0x00059B31
		public virtual bool IsWritable()
		{
			return true;
		}

		// Token: 0x040004DE RID: 1246
		private int reading;
	}
}
