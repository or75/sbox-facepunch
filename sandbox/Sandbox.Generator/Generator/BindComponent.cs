using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sandbox.Generator
{
	// Token: 0x02000008 RID: 8
	internal class BindComponent
	{
		// Token: 0x06000039 RID: 57 RVA: 0x000033C0 File Offset: 0x000015C0
		internal static void VisitProperty(ref PropertyDeclarationSyntax node, IPropertySymbol symbol, Worker master)
		{
			if (symbol.IsStatic)
			{
				return;
			}
			if (node.GetAttribute("BindComponent") == null)
			{
				return;
			}
			if (!symbol.ContainingType.DerivesFrom("global::Sandbox.Entity", true))
			{
				master.AddError(node.GetLocation(), "[BindComponent] is only allowed on an Entity");
				return;
			}
			AccessorDeclarationSyntax get = node.AccessorList.Accessors.FirstOrDefault((AccessorDeclarationSyntax x) => x.Keyword.IsKind(SyntaxKind.GetKeyword));
			AccessorDeclarationSyntax set = node.AccessorList.Accessors.FirstOrDefault((AccessorDeclarationSyntax x) => x.Keyword.IsKind(SyntaxKind.SetKeyword));
			if (get == null)
			{
				master.AddError(node.GetLocation(), "You can't [BindComponent] this property because it doesn't have a get accessor");
				return;
			}
			if (set != null)
			{
				master.AddError(node.GetLocation(), "[BindComponent] properties shouldn't have a set accessor");
				return;
			}
			ExpressionSyntax statements = SyntaxFactory.ParseExpression("Components.Get<" + symbol.Type.FullName() + ">( false );", 0, null, true);
			get = SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithExpressionBody(SyntaxFactory.ArrowExpressionClause(statements));
			node = node.WithAccessorList(SyntaxFactory.AccessorList(SyntaxFactory.List<AccessorDeclarationSyntax>(new AccessorDeclarationSyntax[] { get }))).WithInitializer(null).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.None))
				.NormalizeWhitespace("    ", "\r\n", false);
		}
	}
}
