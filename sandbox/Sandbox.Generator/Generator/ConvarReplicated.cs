using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sandbox.Generator
{
	// Token: 0x0200000C RID: 12
	internal static class ConvarReplicated
	{
		// Token: 0x0600003E RID: 62 RVA: 0x00003AB0 File Offset: 0x00001CB0
		internal static PropertyDeclarationSyntax VisitProperty(PropertyDeclarationSyntax node, IPropertySymbol symbol, Worker master)
		{
			AttributeData attribute = symbol.GetAttribute("Replicated");
			if (attribute == null)
			{
				return node;
			}
			string name = attribute.GetArgumentValue(0, "name", node.Identifier.ToString());
			string fieldName = node.BackingFieldName();
			TypeSyntax type = node.Type;
			master.AddToCurrentClass(string.Format("{0} {1} {2}{3}; // Backing field for ConVar.Replicated {4}\n", new object[] { node.Modifiers, type, fieldName, node.Initializer, node.Identifier }), false);
			SyntaxList<AccessorDeclarationSyntax> accessors = default(SyntaxList<AccessorDeclarationSyntax>);
			AccessorDeclarationSyntax set = SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration, SyntaxFactory.Block(new List<StatementSyntax>
			{
				SyntaxFactory.ParseStatement("if ( " + node.BackingFieldName() + " == value ) return;", 0, null, true),
				SyntaxFactory.ParseStatement(node.BackingFieldName() + " = value;", 0, null, true),
				SyntaxFactory.ParseStatement("if ( Host.IsServer ) Sandbox.ConsoleSystem.SetValue( \"" + name + "\", value );", 0, null, true)
			}));
			accessors = accessors.Add(set);
			StatementSyntax s = SyntaxFactory.ParseStatement("return " + node.BackingFieldName() + ";", 0, null, true);
			AccessorDeclarationSyntax get = SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration, SyntaxFactory.Block(new StatementSyntax[] { s }));
			accessors = accessors.Add(get);
			node = node.WithAccessorList(node.AccessorList.WithAccessors(accessors));
			node = node.WithInitializer(null);
			return node;
		}
	}
}
