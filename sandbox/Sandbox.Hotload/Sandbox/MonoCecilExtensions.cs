using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

namespace Sandbox
{
	// Token: 0x02000006 RID: 6
	internal static class MonoCecilExtensions
	{
		// Token: 0x06000038 RID: 56 RVA: 0x00003969 File Offset: 0x00001B69
		public static IEnumerable<MethodDefinition> GetConstructors(this TypeDefinition typeDef)
		{
			return typeDef.Methods.Where((MethodDefinition x) => x.IsConstructor);
		}
	}
}
