using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sandbox.Utility;

namespace Sandbox.Generator
{
	// Token: 0x02000009 RID: 9
	internal static class ClientCmd
	{
		// Token: 0x0600003B RID: 59 RVA: 0x00003524 File Offset: 0x00001724
		internal static MethodDeclarationSyntax VisitMethod(MethodDeclarationSyntax node, IMethodSymbol symbol, Worker master)
		{
			if (!symbol.IsStatic)
			{
				return node;
			}
			AttributeSyntax attribute = node.GetAttribute("ClientCmd") ?? node.GetAttribute("ClientCmdAttribute");
			if (attribute == null)
			{
				return node;
			}
			string name = attribute.GetArgumentValue(0, "Name", node.Identifier.ToString());
			if (attribute.GetArgumentValue(-1, "CanBeCalledFromServer", "false") != "false")
			{
				new CodeWriter();
				ParameterListSyntax extraParams = SyntaxFactory.ParseParameterList("To to_target", 0, null, true);
				ParameterListSyntax newParams = node.ParameterList.WithParameters(node.ParameterList.Parameters.Insert(0, extraParams.Parameters[0]));
				List<StatementSyntax> s = new List<StatementSyntax>();
				s.Add(SyntaxFactory.ParseStatement("Sandbox.Host.AssertServer();", 0, null, true));
				s.Add(SyntaxFactory.ParseStatement("string _cmdstr_ = Sandbox.ConsoleSystem.Build( " + string.Join(", ", new string[] { name }.Concat(symbol.Parameters.Select((IParameterSymbol x) => x.Name))) + " );", 0, null, true));
				s.Add(SyntaxFactory.ParseStatement("to_target.SendCommand( _cmdstr_ );", 0, null, true));
				MethodDeclarationSyntax toSpecificPlayer = node.WithBody(SyntaxFactory.Block(s)).WithParameterList(newParams).WithAttributeLists(SyntaxFactory.List<AttributeListSyntax>());
				master.AddToCurrentClass(toSpecificPlayer.ToString(), true);
			}
			return node.AddStatementToFront(string.Format("if ( Sandbox.Host.IsServer ) throw new System.Exception( \"Trying to call {0} serverside!\" );\n", node.Identifier));
		}
	}
}
