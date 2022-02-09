using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sandbox.Internal
{
	// Token: 0x02000182 RID: 386
	public sealed class VarDictionaryUC<[IsUnmanaged] TKey, TVal> : NetworkBaseDictionary<TKey, TVal> where TKey : struct, ValueType where TVal : class
	{
		// Token: 0x06001C02 RID: 7170 RVA: 0x000709CE File Offset: 0x0006EBCE
		public VarDictionaryUC()
			: base(null)
		{
		}

		// Token: 0x06001C03 RID: 7171 RVA: 0x000709D7 File Offset: 0x0006EBD7
		public VarDictionaryUC(Dictionary<TKey, TVal> defaultValue = null)
			: base(defaultValue)
		{
		}

		// Token: 0x06001C04 RID: 7172 RVA: 0x000709E0 File Offset: 0x0006EBE0
		internal override TKey ReadKey(ref NetRead read)
		{
			return read.Read<TKey>();
		}

		// Token: 0x06001C05 RID: 7173 RVA: 0x000709E8 File Offset: 0x0006EBE8
		internal override TVal ReadValue(ref NetRead read)
		{
			return read.ReadClass<TVal>(default(TVal));
		}

		// Token: 0x06001C06 RID: 7174 RVA: 0x00070A04 File Offset: 0x0006EC04
		internal override void WriteKey(NetWrite write, TKey element)
		{
			write.Write<TKey>(element);
		}

		// Token: 0x06001C07 RID: 7175 RVA: 0x00070A0D File Offset: 0x0006EC0D
		internal override void WriteValue(NetWrite write, TVal element)
		{
			write.Write<TVal>(element);
		}
	}
}
