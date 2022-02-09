using System;
using Zio;
using Zio.FileSystems;

namespace Sandbox
{
	// Token: 0x020002A6 RID: 678
	internal class RootFileSystem : BaseFileSystem
	{
		// Token: 0x17000348 RID: 840
		// (get) Token: 0x0600113C RID: 4412 RVA: 0x00020B85 File Offset: 0x0001ED85
		// (set) Token: 0x0600113D RID: 4413 RVA: 0x00020B8D File Offset: 0x0001ED8D
		internal PhysicalFileSystem Physical { get; private set; }

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x0600113E RID: 4414 RVA: 0x00020B96 File Offset: 0x0001ED96
		internal SubFileSystem Local
		{
			get
			{
				return this.system as SubFileSystem;
			}
		}

		// Token: 0x0600113F RID: 4415 RVA: 0x00020BA4 File Offset: 0x0001EDA4
		internal RootFileSystem(string rootFolder)
		{
			this.Physical = new PhysicalFileSystem();
			UPath rootPath = this.Physical.ConvertPathFromInternal(rootFolder);
			this.system = new SubFileSystem(this.Physical, rootPath, true);
		}

		// Token: 0x06001140 RID: 4416 RVA: 0x00020BE2 File Offset: 0x0001EDE2
		internal override void Dispose()
		{
			base.Dispose();
			PhysicalFileSystem physical = this.Physical;
			if (physical == null)
			{
				return;
			}
			physical.Dispose();
		}
	}
}
