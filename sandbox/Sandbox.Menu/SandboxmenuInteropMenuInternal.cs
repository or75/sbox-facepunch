using System;
using System.Runtime.CompilerServices;

// Token: 0x02000008 RID: 8
internal static class SandboxmenuInteropMenuInternal
{
	// Token: 0x06000015 RID: 21 RVA: 0x00002528 File Offset: 0x00000728
	public static int Convert(Type t)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
		defaultInterpolatedStringHandler.AppendLiteral("Can't handle type ");
		defaultInterpolatedStringHandler.AppendFormatted<Type>(t);
		throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
	}
}
