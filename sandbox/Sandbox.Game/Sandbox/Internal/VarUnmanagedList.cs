using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sandbox.Internal
{
	/// <summary>
	/// A list of atomic types
	/// </summary>
	// Token: 0x0200018B RID: 395
	public sealed class VarUnmanagedList<[IsUnmanaged] T> : NetworkBaseList<T> where T : struct, ValueType
	{
		// Token: 0x06001C3C RID: 7228 RVA: 0x000711CD File Offset: 0x0006F3CD
		public VarUnmanagedList()
			: base(null)
		{
		}

		// Token: 0x06001C3D RID: 7229 RVA: 0x000711D6 File Offset: 0x0006F3D6
		public VarUnmanagedList(List<T> defaultValue = null)
			: base(defaultValue)
		{
		}

		// Token: 0x06001C3E RID: 7230 RVA: 0x000711DF File Offset: 0x0006F3DF
		internal override T ReadElement(ref NetRead read)
		{
			return read.Read<T>();
		}

		// Token: 0x06001C3F RID: 7231 RVA: 0x000711E7 File Offset: 0x0006F3E7
		internal override void WriteElement(NetWrite write, T element)
		{
			write.Write<T>(element);
		}
	}
}
