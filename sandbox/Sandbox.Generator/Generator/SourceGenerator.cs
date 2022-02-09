using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Sandbox.Generator
{
	// Token: 0x02000007 RID: 7
	[Generator]
	public class SourceGenerator : ISourceGenerator
	{
		// Token: 0x06000036 RID: 54 RVA: 0x0000338F File Offset: 0x0000158F
		public void Initialize(GeneratorInitializationContext context)
		{
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003391 File Offset: 0x00001591
		public void Execute(GeneratorExecutionContext context)
		{
			new Processor
			{
				Context = new GeneratorExecutionContext?(context)
			}.Run(context.Compilation as CSharpCompilation);
		}
	}
}
