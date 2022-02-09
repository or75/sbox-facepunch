using System;
using Zio.FileSystems;

namespace Sandbox
{
	// Token: 0x020002A1 RID: 673
	internal class AggFileSystem : BaseFileSystem
	{
		// Token: 0x060010F4 RID: 4340 RVA: 0x0001FB9B File Offset: 0x0001DD9B
		internal AggFileSystem()
			: base(new AggregateFileSystem(true))
		{
		}
	}
}
