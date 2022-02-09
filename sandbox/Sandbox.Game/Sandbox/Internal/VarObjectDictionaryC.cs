using System;
using System.Collections.Generic;

namespace Sandbox.Internal
{
	/// <summary>
	/// A dictionary of atomic types
	/// </summary>
	// Token: 0x02000186 RID: 390
	public sealed class VarObjectDictionaryC<TKey> : NetworkBaseDictionary<TKey, object> where TKey : class
	{
		// Token: 0x06001C1A RID: 7194 RVA: 0x00070AEE File Offset: 0x0006ECEE
		public VarObjectDictionaryC()
			: base(null)
		{
		}

		// Token: 0x06001C1B RID: 7195 RVA: 0x00070AF7 File Offset: 0x0006ECF7
		public VarObjectDictionaryC(Dictionary<TKey, object> defaultValue = null)
			: base(defaultValue)
		{
		}

		// Token: 0x06001C1C RID: 7196 RVA: 0x00070B00 File Offset: 0x0006ED00
		internal override TKey ReadKey(ref NetRead read)
		{
			return read.ReadClass<TKey>(default(TKey));
		}

		// Token: 0x06001C1D RID: 7197 RVA: 0x00070B1C File Offset: 0x0006ED1C
		internal override object ReadValue(ref NetRead read)
		{
			return read.ReadObject();
		}

		// Token: 0x06001C1E RID: 7198 RVA: 0x00070B24 File Offset: 0x0006ED24
		internal override void WriteKey(NetWrite write, TKey element)
		{
			write.Write<TKey>(element);
		}

		// Token: 0x06001C1F RID: 7199 RVA: 0x00070B2D File Offset: 0x0006ED2D
		internal override void WriteValue(NetWrite write, object element)
		{
			write.WriteObject(element);
		}
	}
}
