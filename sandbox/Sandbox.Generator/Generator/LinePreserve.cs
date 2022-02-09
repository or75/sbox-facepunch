using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sandbox.Generator
{
	// Token: 0x02000010 RID: 16
	internal static class LinePreserve
	{
		// Token: 0x06000047 RID: 71 RVA: 0x00004324 File Offset: 0x00002524
		public static T AddLineNumber<T>(T node, SyntaxTree tree) where T : SyntaxNode
		{
			FileLinePositionSpan lineSpan = node.GetLocation().GetLineSpan();
			if (node.HasLeadingTrivia)
			{
				lineSpan = node.GetLeadingTrivia().First().GetLocation()
					.GetLineSpan();
			}
			SyntaxToken line2 = SyntaxFactory.Literal(string.Format("{0}", lineSpan.StartLinePosition.Line + 1), lineSpan.StartLinePosition.Line + 1);
			SyntaxToken file = SyntaxFactory.Literal(tree.FilePath ?? "");
			LineDirectiveTriviaSyntax line = SyntaxFactory.LineDirectiveTrivia(line2, file, true).NormalizeWhitespace("    ", "\r\n", false).WithLeadingTrivia(new SyntaxTrivia[] { SyntaxFactory.CarriageReturn });
			SyntaxTriviaList trivia = (node.HasLeadingTrivia ? node.GetLeadingTrivia() : SyntaxFactory.TriviaList()).Insert(0, SyntaxFactory.Trivia(line));
			return node.WithLeadingTrivia(trivia);
		}
	}
}
