using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sandbox.SolutionGenerator
{
	// Token: 0x02000003 RID: 3
	public class LaunchSettings
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000027DA File Offset: 0x000009DA
		// (set) Token: 0x0600000B RID: 11 RVA: 0x000027E2 File Offset: 0x000009E2
		[JsonPropertyName("profiles")]
		public Dictionary<string, LaunchSettings.Profile> Profiles { get; set; }

		// Token: 0x0200000A RID: 10
		public class Profile
		{
			// Token: 0x17000017 RID: 23
			// (get) Token: 0x0600004F RID: 79 RVA: 0x0000328E File Offset: 0x0000148E
			// (set) Token: 0x06000050 RID: 80 RVA: 0x00003296 File Offset: 0x00001496
			[JsonPropertyName("commandName")]
			public string CommandName { get; set; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x06000051 RID: 81 RVA: 0x0000329F File Offset: 0x0000149F
			// (set) Token: 0x06000052 RID: 82 RVA: 0x000032A7 File Offset: 0x000014A7
			[JsonPropertyName("executablePath")]
			public string ExecutablePath { get; set; }

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x06000053 RID: 83 RVA: 0x000032B0 File Offset: 0x000014B0
			// (set) Token: 0x06000054 RID: 84 RVA: 0x000032B8 File Offset: 0x000014B8
			[JsonPropertyName("commandLineArgs")]
			public string CommandLineArgs { get; set; }
		}
	}
}
