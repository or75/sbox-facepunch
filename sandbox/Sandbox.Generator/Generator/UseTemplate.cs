using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sandbox.Generator
{
	// Token: 0x02000014 RID: 20
	internal static class UseTemplate
	{
		// Token: 0x0600005D RID: 93 RVA: 0x000062B4 File Offset: 0x000044B4
		internal static void VisitAttribute(ref AttributeSyntax node, Worker master)
		{
			if (node.Name.ToString() != "UseTemplate")
			{
				return;
			}
			if (node.ArgumentList == null || node.ArgumentList.Arguments.Count == 0)
			{
				string path = node.GetLocation().SourceTree.FilePath.Substring(master.Root.Length).Replace('\\', '/');
				if (!path.EndsWith(".cs"))
				{
					return;
				}
				path = path.ToLower();
				string code = "/code/";
				if (path.StartsWith("/code/"))
				{
					path = path.Substring(code.Length - 1);
				}
				path = path.Substring(0, path.Length - 3);
				path += ".html";
				AttributeArgumentListSyntax argList = SyntaxFactory.AttributeArgumentList(SyntaxFactory.SingletonSeparatedList<AttributeArgumentSyntax>(SyntaxFactory.AttributeArgument(SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(path)))));
				node = node.WithArgumentList(argList);
			}
		}
	}
}
