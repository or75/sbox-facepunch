using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sandbox.Internal
{
	// Token: 0x02000181 RID: 385
	public sealed class VarDictionaryUU<[IsUnmanaged] TKey, [IsUnmanaged] TVal> : NetworkBaseDictionary<TKey, TVal> where TKey : struct, ValueType where TVal : struct, ValueType
	{
		// Token: 0x06001BFC RID: 7164 RVA: 0x0007099A File Offset: 0x0006EB9A
		public VarDictionaryUU()
			: base(null)
		{
		}

		// Token: 0x06001BFD RID: 7165 RVA: 0x000709A3 File Offset: 0x0006EBA3
		public VarDictionaryUU(Dictionary<TKey, TVal> defaultValue = null)
			: base(defaultValue)
		{
		}

		// Token: 0x06001BFE RID: 7166 RVA: 0x000709AC File Offset: 0x0006EBAC
		internal override TKey ReadKey(ref NetRead read)
		{
			return read.Read<TKey>();
		}

		// Token: 0x06001BFF RID: 7167 RVA: 0x000709B4 File Offset: 0x0006EBB4
		internal override TVal ReadValue(ref NetRead read)
		{
			return read.Read<TVal>();
		}

		// Token: 0x06001C00 RID: 7168 RVA: 0x000709BC File Offset: 0x0006EBBC
		internal override void WriteKey(NetWrite write, TKey element)
		{
			write.Write<TKey>(element);
		}

		// Token: 0x06001C01 RID: 7169 RVA: 0x000709C5 File Offset: 0x0006EBC5
		internal override void WriteValue(NetWrite write, TVal element)
		{
			write.Write<TVal>(element);
		}
	}
}
