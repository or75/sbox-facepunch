using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sandbox.Utility;

namespace Sandbox.Generator
{
	// Token: 0x0200000F RID: 15
	internal static class HammerOutput
	{
		// Token: 0x06000045 RID: 69 RVA: 0x00004128 File Offset: 0x00002328
		internal static void VisitProperty(ref PropertyDeclarationSyntax node, IPropertySymbol symbol, Worker master)
		{
			ITypeSymbol type = symbol.Type;
			if (type.FullName() != "global::Sandbox.Entity.Output" && !type.FullName().StartsWith("global::Sandbox.Entity.Output<"))
			{
				return;
			}
			if (symbol.IsStatic)
			{
				return;
			}
			string genericType = "";
			if (type.FullName().Contains("<"))
			{
				genericType = type.FullName().Substring(29);
			}
			string name = symbol.Name;
			if (name.EndsWith("Output"))
			{
				name = name.Substring(0, name.Length - 6);
			}
			master.AddClassBlock("hammer_output", string.Concat(new string[]
			{
				symbol.Name,
				" = new Output",
				genericType,
				"( this, ",
				symbol.Name.QuoteSafe(),
				" );"
			}), symbol.ContainingType);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00004204 File Offset: 0x00002404
		internal static void BuildStaticBlock(List<SyntaxTree> trees, IEnumerable<IGrouping<ITypeSymbol, Worker.ClassBlock>> blocks)
		{
			CodeWriter code = new CodeWriter();
			code.WriteLine("using Sandbox;");
			code.WriteLine("using System.Collections.Generic;");
			foreach (IGrouping<ITypeSymbol, Worker.ClassBlock> classGroup in blocks)
			{
				code.StartClass(classGroup.Key);
				code.WriteLine("[System.ComponentModel.EditorBrowsable( System.ComponentModel.EditorBrowsableState.Never )]");
				code.StartBlock("protected override void CreateHammerOutputs()");
				foreach (Worker.ClassBlock block in classGroup)
				{
					code.WriteLine(block.Text);
				}
				code.WriteLine("");
				code.WriteLine("\tbase.CreateHammerOutputs();");
				code.EndBlock("");
				code.EndClass(classGroup.Key);
			}
			SyntaxTree st = SyntaxFactory.ParseSyntaxTree(code.ToString(), null, "_HammerOutputs", Encoding.UTF8, default(CancellationToken));
			trees.Add(st);
		}
	}
}
