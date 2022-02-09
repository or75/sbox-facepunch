using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sandbox.Internal
{
	// Token: 0x02000183 RID: 387
	public sealed class VarDictionaryCU<TKey, [IsUnmanaged] TVal> : NetworkBaseDictionary<TKey, TVal> where TKey : class where TVal : struct, ValueType
	{
		// Token: 0x06001C08 RID: 7176 RVA: 0x00070A16 File Offset: 0x0006EC16
		public VarDictionaryCU()
			: base(null)
		{
		}

		// Token: 0x06001C09 RID: 7177 RVA: 0x00070A1F File Offset: 0x0006EC1F
		public VarDictionaryCU(Dictionary<TKey, TVal> defaultValue = null)
			: base(defaultValue)
		{
		}

		// Token: 0x06001C0A RID: 7178 RVA: 0x00070A28 File Offset: 0x0006EC28
		internal override TKey ReadKey(ref NetRead read)
		{
			return read.ReadClass<TKey>(default(TKey));
		}

		// Token: 0x06001C0B RID: 7179 RVA: 0x00070A44 File Offset: 0x0006EC44
		internal override TVal ReadValue(ref NetRead read)
		{
			return read.Read<TVal>();
		}

		// Token: 0x06001C0C RID: 7180 RVA: 0x00070A4C File Offset: 0x0006EC4C
		internal override void WriteKey(NetWrite write, TKey element)
		{
			write.Write<TKey>(element);
		}

		// Token: 0x06001C0D RID: 7181 RVA: 0x00070A55 File Offset: 0x0006EC55
		internal override void WriteValue(NetWrite write, TVal element)
		{
			write.Write<TVal>(element);
		}
	}
}
