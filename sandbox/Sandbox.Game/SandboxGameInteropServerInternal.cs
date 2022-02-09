using System;
using System.Runtime.CompilerServices;
using Sandbox;

// Token: 0x02000009 RID: 9
internal static class SandboxGameInteropServerInternal
{
	// Token: 0x06000020 RID: 32 RVA: 0x00002990 File Offset: 0x00000B90
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
