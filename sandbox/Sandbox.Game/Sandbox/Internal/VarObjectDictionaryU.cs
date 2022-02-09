using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sandbox.Internal
{
	/// <summary>
	/// A dictionary of atomic types
	/// </summary>
	// Token: 0x02000185 RID: 389
	public sealed class VarObjectDictionaryU<[IsUnmanaged] TKey> : NetworkBaseDictionary<TKey, object> where TKey : struct, ValueType
	{
		// Token: 0x06001C14 RID: 7188 RVA: 0x00070ABA File Offset: 0x0006ECBA
		public VarObjectDictionaryU()
			: base(null)
		{
		}

		// Token: 0x06001C15 RID: 7189 RVA: 0x00070AC3 File Offset: 0x0006ECC3
		public VarObjectDictionaryU(Dictionary<TKey, object> defaultValue = null)
			: base(defaultValue)
		{
		}

		// Token: 0x06001C16 RID: 7190 RVA: 0x00070ACC File Offset: 0x0006ECCC
		internal override TKey ReadKey(ref NetRead read)
		{
			return read.Read<TKey>();
		}

		// Token: 0x06001C17 RID: 7191 RVA: 0x00070AD4 File Offset: 0x0006ECD4
		internal override object ReadValue(ref NetRead read)
		{
			return read.ReadObject();
		}

		// Token: 0x06001C18 RID: 7192 RVA: 0x00070ADC File Offset: 0x0006ECDC
		internal override void WriteKey(NetWrite write, TKey element)
		{
			write.Write<TKey>(element);
		}

		// Token: 0x06001C19 RID: 7193 RVA: 0x00070AE5 File Offset: 0x0006ECE5
		internal override void WriteValue(NetWrite write, object element)
		{
			write.WriteObject(element);
		}
	}
}
