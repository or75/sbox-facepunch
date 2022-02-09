using System;
using Microsoft.CodeAnalysis;

namespace Sandbox.Generator
{
	// Token: 0x02000005 RID: 5
	public static class Errors
	{
		// Token: 0x04000006 RID: 6
		public static DiagnosticDescriptor ServerCmdOnMember = new DiagnosticDescriptor("SB1001", "ServerCmd On Member", "ServerCmd should only be used on a static method. You can't add console commands to members methods.", "generator", DiagnosticSeverity.Error, true, null, null, Array.Empty<string>());
	}
}
