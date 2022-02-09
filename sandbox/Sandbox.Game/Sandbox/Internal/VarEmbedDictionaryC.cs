using System;
using System.Collections.Generic;

namespace Sandbox.Internal
{
	// Token: 0x02000189 RID: 393
	public sealed class VarEmbedDictionaryC<TKey, TVal> : VarEmbedDictionary<TKey, TVal> where TKey : class where TVal : LibraryClass, INetworkTable
	{
		// Token: 0x06001C34 RID: 7220 RVA: 0x0007115D File Offset: 0x0006F35D
		public VarEmbedDictionaryC()
			: base(null)
		{
		}

		// Token: 0x06001C35 RID: 7221 RVA: 0x00071166 File Offset: 0x0006F366
		public VarEmbedDictionaryC(Dictionary<TKey, TVal> defaultValue = null)
			: base(defaultValue)
		{
		}

		// Token: 0x06001C36 RID: 7222 RVA: 0x00071170 File Offset: 0x0006F370
		internal override TKey ReadKey(ref NetRead read)
		{
			return read.ReadClass<TKey>(default(TKey));
		}

		// Token: 0x06001C37 RID: 7223 RVA: 0x0007118C File Offset: 0x0006F38C
		internal override void WriteKey(NetWrite write, TKey element)
		{
			write.Write<TKey>(element);
		}
	}
}
