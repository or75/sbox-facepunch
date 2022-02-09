using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sandbox.Utility;

namespace Sandbox.Generator
{
	// Token: 0x02000013 RID: 19
	internal static class ServerCmd
	{
		// Token: 0x0600005C RID: 92 RVA: 0x0000618C File Offset: 0x0000438C
		internal static MethodDeclarationSyntax VisitMethod(MethodDeclarationSyntax node, IMethodSymbol symbol, Worker master)
		{
			AttributeSyntax attribute = node.GetAttribute("ServerCmd") ?? node.GetAttribute("AdminCmd");
			if (attribute == null)
			{
				return node;
			}
			if (!symbol.IsStatic)
			{
				master.AddError(node.GetLocation(), Errors.ServerCmdOnMember, Array.Empty<object>());
				return node;
			}
			string commandName = attribute.GetArgumentValue(0, "Name", string.Format("\"{0}\"", node.Identifier));
			attribute.GetArgumentValue(-1, "CanBeCalledFromServer", "false");
			CodeWriter c = new CodeWriter();
			IEnumerable<string> parameters = node.ParameterList.Parameters.Select((ParameterSyntax x) => x.Identifier.ToString());
			string paramStr = string.Join(",", parameters);
			if (!string.IsNullOrWhiteSpace(paramStr))
			{
				paramStr = ", " + paramStr;
			}
			c.StartBlock("if ( !Sandbox.Host.IsServer )");
			c.WriteLine("Sandbox.ConsoleSystem.Run( " + commandName + paramStr + " );");
			c.WriteLine("return;");
			c.EndBlock("");
			return node.AddStatementToFront(c.ToString());
		}
	}
}
