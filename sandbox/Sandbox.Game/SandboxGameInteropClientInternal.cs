using System;
using System.Runtime.CompilerServices;
using Sandbox;

// Token: 0x02000008 RID: 8
internal static class SandboxGameInteropClientInternal
{
	// Token: 0x0600001F RID: 31 RVA: 0x00002928 File Offset: 0x00000B28
	public static int Convert(Type t)
	{
		if (typeof(ClientEntity).IsAssignableFrom(t))
		{
			return 1513687116;
		}
		if (typeof(Entity).IsAssignableFrom(t))
		{
			return -326052403;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
		defaultInterpolatedStringHandler.AppendLiteral("Can't handle type ");
		defaultInterpolatedStringHandler.AppendFormatted<Type>(t);
		throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
	}
}
