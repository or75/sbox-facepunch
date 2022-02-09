using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sandbox.Generator
{
	// Token: 0x0200000A RID: 10
	internal static class ConvarClientData
	{
		// Token: 0x0600003C RID: 60 RVA: 0x000036BC File Offset: 0x000018BC
		internal static PropertyDeclarationSyntax VisitProperty(PropertyDeclarationSyntax node, IPropertySymbol symbol, Worker master)
		{
			AttributeData attribute = symbol.GetAttribute("ClientData");
			if (attribute == null)
			{
				return node;
			}
			bool isStatic = symbol.IsStatic;
			string name = attribute.GetArgumentValue(0, "name", node.Identifier.ToString());
			if (!isStatic)
			{
				if (!symbol.ContainingType.DerivesFrom("global::Sandbox.Entity", true))
				{
					master.AddError(node.GetLocation(), "ClientData Convars can only be non static as a member of a pawn entity");
					return node;
				}
				DefaultValue.VisitProperty(ref node, symbol, master);
			}
			string fieldName = node.BackingFieldName();
			TypeSyntax type = node.Type;
			master.AddToCurrentClass(string.Format("{0} {1} {2}{3}; // Backing field for ConVar.ClientData {4}\n", new object[] { node.Modifiers, type, fieldName, node.Initializer, node.Identifier }), false);
			SyntaxList<AccessorDeclarationSyntax> accessors = default(SyntaxList<AccessorDeclarationSyntax>);
			AccessorDeclarationSyntax set = SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration, SyntaxFactory.Block(new List<StatementSyntax>
			{
				SyntaxFactory.ParseStatement("Host.AssertClient();", 0, null, true),
				SyntaxFactory.ParseStatement("if ( " + node.BackingFieldName() + " == value ) return;", 0, null, true),
				SyntaxFactory.ParseStatement(node.BackingFieldName() + " = value;", 0, null, true),
				SyntaxFactory.ParseStatement("Sandbox.ConsoleSystem.UpdateUserData( \"" + name + "\", value );", 0, null, true)
			}));
			accessors = accessors.Add(set);
			List<StatementSyntax> s = new List<StatementSyntax>();
			if (!isStatic)
			{
				s.Add(SyntaxFactory.ParseStatement(string.Format("if ( Host.IsServer ) return Client?.GetClientData<{0}>( \"{1}\" ) ?? default;", node.Type, name), 0, null, true));
			}
			s.Add(SyntaxFactory.ParseStatement("Host.AssertClient();", 0, null, true));
			s.Add(SyntaxFactory.ParseStatement("return " + node.BackingFieldName() + ";", 0, null, true));
			AccessorDeclarationSyntax get = SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration, SyntaxFactory.Block(s));
			accessors = accessors.Add(get);
			node = node.WithAccessorList(node.AccessorList.WithAccessors(accessors));
			node = node.WithInitializer(null);
			return node;
		}
	}
}
