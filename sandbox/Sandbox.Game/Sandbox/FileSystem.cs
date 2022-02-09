using System;

namespace Sandbox
{
	/// <summary>
	/// A filesystem that can be accessed by the game
	/// </summary>
	// Token: 0x020000A4 RID: 164
	public static class FileSystem
	{
		// Token: 0x060010E0 RID: 4320 RVA: 0x00048EA0 File Offset: 0x000470A0
		public static string NormalizeFilename(string filename)
		{
			return filename.ToLower().Replace("\\", "//");
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x060010E1 RID: 4321 RVA: 0x00048EB7 File Offset: 0x000470B7
		// (set) Token: 0x060010E2 RID: 4322 RVA: 0x00048EBE File Offset: 0x000470BE
		public static BaseFileSystem Mounted { get; internal set; }

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x060010E3 RID: 4323 RVA: 0x00048EC6 File Offset: 0x000470C6
		// (set) Token: 0x060010E4 RID: 4324 RVA: 0x00048ECD File Offset: 0x000470CD
		public static BaseFileSystem Data { get; internal set; }

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x060010E5 RID: 4325 RVA: 0x00048ED5 File Offset: 0x000470D5
		// (set) Token: 0x060010E6 RID: 4326 RVA: 0x00048EDC File Offset: 0x000470DC
		public static BaseFileSystem OrganizationData { get; internal set; }
	}
}
