using System;
using System.Collections.Generic;

namespace Sandbox.Internal
{
	/// <summary>
	/// A list of anything readable/writable with NetRead/NetWrite
	/// </summary>
	// Token: 0x0200018A RID: 394
	public sealed class VarGenericList<T> : NetworkBaseList<T> where T : class
	{
		// Token: 0x06001C38 RID: 7224 RVA: 0x00071195 File Offset: 0x0006F395
		public VarGenericList()
			: base(null)
		{
		}

		// Token: 0x06001C39 RID: 7225 RVA: 0x0007119E File Offset: 0x0006F39E
		public VarGenericList(List<T> defaultValue = null)
			: base(defaultValue)
		{
		}

		// Token: 0x06001C3A RID: 7226 RVA: 0x000711A8 File Offset: 0x0006F3A8
		internal override T ReadElement(ref NetRead read)
		{
			return read.ReadClass<T>(default(T));
		}

		// Token: 0x06001C3B RID: 7227 RVA: 0x000711C4 File Offset: 0x0006F3C4
		internal override void WriteElement(NetWrite write, T element)
		{
			write.Write<T>(element);
		}
	}
}
