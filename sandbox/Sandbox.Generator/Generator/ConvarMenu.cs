using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sandbox.Generator
{
	// Token: 0x0200000B RID: 11
	internal static class ConvarMenu
	{
		// Token: 0x0600003D RID: 61 RVA: 0x000038CC File Offset: 0x00001ACC
		internal static PropertyDeclarationSyntax VisitProperty(PropertyDeclarationSyntax node, IPropertySymbol symbol, Worker master)
		{
			AttributeData attribute = symbol.GetAttribute("ConVar", "Menu");
			if (attribute == null)
			{
				return node;
			}
			bool isStatic = symbol.IsStatic;
			string name = attribute.GetArgumentValue(0, "name", node.Identifier.ToString());
			attribute.GetArgumentValue(-1, "ClientData", node.Identifier.ToString());
			if (!isStatic)
			{
				return node;
			}
			string fieldName = node.BackingFieldName();
			TypeSyntax type = node.Type;
			master.AddToCurrentClass(string.Format("{0} {1} {2}{3}; // Backing field for ConVar.Menu {4}\n", new object[] { node.Modifiers, type, fieldName, node.Initializer, node.Identifier }), false);
			SyntaxList<AccessorDeclarationSyntax> accessors = default(SyntaxList<AccessorDeclarationSyntax>);
			AccessorDeclarationSyntax set = SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration, SyntaxFactory.Block(new List<StatementSyntax>
			{
				SyntaxFactory.ParseStatement("Host.AssertMenu();", 0, null, true),
				SyntaxFactory.ParseStatement("if ( " + node.BackingFieldName() + " == value ) return;", 0, null, true),
				SyntaxFactory.ParseStatement(node.BackingFieldName() + " = value;", 0, null, true),
				SyntaxFactory.ParseStatement("Sandbox.ConsoleSystem.SetValue( \"" + name + "\", value );", 0, null, true)
			}));
			accessors = accessors.Add(set);
			AccessorDeclarationSyntax get = SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration, SyntaxFactory.Block(new List<StatementSyntax>
			{
				SyntaxFactory.ParseStatement("Host.AssertMenu();", 0, null, true),
				SyntaxFactory.ParseStatement("return " + node.BackingFieldName() + ";", 0, null, true)
			}));
			accessors = accessors.Add(get);
			node = node.WithAccessorList(node.AccessorList.WithAccessors(accessors));
			node = node.WithInitializer(null);
			return node;
		}
	}
}
