using System;
using System.Runtime.CompilerServices;
using Sandbox;

// Token: 0x02000007 RID: 7
internal static class SandboxEngineInteropEngineInternal
{
	// Token: 0x0600000D RID: 13 RVA: 0x00002224 File Offset: 0x00000424
	public static int Convert(Type t)
	{
		if (typeof(INetworkClient).IsAssignableFrom(t))
		{
			return -435993552;
		}
		if (typeof(INetworkServer).IsAssignableFrom(t))
		{
			return 709996636;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
		defaultInterpolatedStringHandler.AppendLiteral("Can't handle type ");
		defaultInterpolatedStringHandler.AppendFormatted<Type>(t);
		throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
	}
}
