using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sandbox.Internal
{
	// Token: 0x02000188 RID: 392
	public sealed class VarEmbedDictionaryU<[IsUnmanaged] TKey, TVal> : VarEmbedDictionary<TKey, TVal> where TKey : struct, ValueType where TVal : LibraryClass, INetworkTable
	{
		// Token: 0x06001C30 RID: 7216 RVA: 0x0007113A File Offset: 0x0006F33A
		public VarEmbedDictionaryU()
			: base(null)
		{
		}

		// Token: 0x06001C31 RID: 7217 RVA: 0x00071143 File Offset: 0x0006F343
		public VarEmbedDictionaryU(Dictionary<TKey, TVal> defaultValue = null)
			: base(defaultValue)
		{
		}

		// Token: 0x06001C32 RID: 7218 RVA: 0x0007114C File Offset: 0x0006F34C
		internal override TKey ReadKey(ref NetRead read)
		{
			return read.Read<TKey>();
		}

		// Token: 0x06001C33 RID: 7219 RVA: 0x00071154 File Offset: 0x0006F354
		internal override void WriteKey(NetWrite write, TKey element)
		{
			write.Write<TKey>(element);
		}
	}
}
