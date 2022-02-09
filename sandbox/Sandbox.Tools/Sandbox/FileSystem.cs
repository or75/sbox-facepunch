using System;

namespace Sandbox
{
	/// <summary>
	/// A filesystem that can be accessed by the game
	/// </summary>
	// Token: 0x0200006D RID: 109
	public static class FileSystem
	{
		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06001270 RID: 4720 RVA: 0x0005070C File Offset: 0x0004E90C
		public static BaseFileSystem Mounted { get; } = new AggFileSystem();

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06001271 RID: 4721 RVA: 0x00050713 File Offset: 0x0004E913
		public static BaseFileSystem Root
		{
			get
			{
				return EngineFileSystem.Root;
			}
		}
	}
}
