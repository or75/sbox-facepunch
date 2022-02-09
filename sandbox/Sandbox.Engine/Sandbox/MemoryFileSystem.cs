using System;
using Zio.FileSystems;

namespace Sandbox
{
	// Token: 0x020002A5 RID: 677
	internal class MemoryFileSystem : BaseFileSystem
	{
		// Token: 0x0600113B RID: 4411 RVA: 0x00020B78 File Offset: 0x0001ED78
		internal MemoryFileSystem()
			: base(new MemoryFileSystem())
		{
		}
	}
}
