using System;
using System.Collections.Generic;

namespace Sandbox.Internal
{
	// Token: 0x02000184 RID: 388
	public sealed class VarDictionaryCC<TKey, TVal> : NetworkBaseDictionary<TKey, TVal> where TKey : class where TVal : class
	{
		// Token: 0x06001C0E RID: 7182 RVA: 0x00070A5E File Offset: 0x0006EC5E
		public VarDictionaryCC()
			: base(null)
		{
		}

		// Token: 0x06001C0F RID: 7183 RVA: 0x00070A67 File Offset: 0x0006EC67
		public VarDictionaryCC(Dictionary<TKey, TVal> defaultValue = null)
			: base(defaultValue)
		{
		}

		// Token: 0x06001C10 RID: 7184 RVA: 0x00070A70 File Offset: 0x0006EC70
		internal override TKey ReadKey(ref NetRead read)
		{
			return read.ReadClass<TKey>(default(TKey));
		}

		// Token: 0x06001C11 RID: 7185 RVA: 0x00070A8C File Offset: 0x0006EC8C
		internal override TVal ReadValue(ref NetRead read)
		{
			return read.ReadClass<TVal>(default(TVal));
		}

		// Token: 0x06001C12 RID: 7186 RVA: 0x00070AA8 File Offset: 0x0006ECA8
		internal override void WriteKey(NetWrite write, TKey element)
		{
			write.Write<TKey>(element);
		}

		// Token: 0x06001C13 RID: 7187 RVA: 0x00070AB1 File Offset: 0x0006ECB1
		internal override void WriteValue(NetWrite write, TVal element)
		{
			write.Write<TVal>(element);
		}
	}
}
