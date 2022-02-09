using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sandbox.Generator
{
	// Token: 0x02000015 RID: 21
	public static class RoslynExtensions
	{
		// Token: 0x0600005E RID: 94 RVA: 0x000063A4 File Offset: 0x000045A4
		public static bool HasAttribute(this MemberDeclarationSyntax symbol, string name)
		{
			return symbol.GetAttribute(name) != null;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000063B0 File Offset: 0x000045B0
		public static AttributeSyntax GetAttribute(this MemberDeclarationSyntax symbol, string name)
		{
			return symbol.AttributeLists.SelectMany((AttributeListSyntax x) => x.Attributes).FirstOrDefault((AttributeSyntax y) => y.Name.ToString() == name || y.Name.ToString() == name + "Attribute");
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000640A File Offset: 0x0000460A
		public static bool HasAttribute(this IMethodSymbol symbol, string name)
		{
			return symbol.GetAttribute(name) != null;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00006418 File Offset: 0x00004618
		public static AttributeData GetAttribute(this IMethodSymbol symbol, string name)
		{
			return symbol.GetAttributes().FirstOrDefault((AttributeData y) => y.AttributeClass.Name == name || y.AttributeClass.Name == name + "Attribute");
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000644C File Offset: 0x0000464C
		public static AttributeData GetAttribute(this IPropertySymbol symbol, string name)
		{
			return symbol.GetAttributes().FirstOrDefault((AttributeData y) => y.AttributeClass.Name == name || y.AttributeClass.Name == name + "Attribute");
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00006480 File Offset: 0x00004680
		public static AttributeData GetAttribute(this IPropertySymbol symbol, string parentName, string name)
		{
			return symbol.GetAttributes().FirstOrDefault((AttributeData y) => y.AttributeClass.ContainingType != null && y.AttributeClass.ContainingType.Name == parentName && (y.AttributeClass.Name == name || y.AttributeClass.Name == name + "Attribute"));
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000064B8 File Offset: 0x000046B8
		public static AttributeArgumentSyntax GetArgument(this AttributeArgumentListSyntax list, int position, string name)
		{
			if (list == null)
			{
				return null;
			}
			SeparatedSyntaxList<AttributeArgumentSyntax> args = list.Arguments;
			AttributeArgumentSyntax arg = args.FirstOrDefault((AttributeArgumentSyntax x) => x.NameColon != null && x.NameColon.Name.ToString() == name);
			if (arg != null)
			{
				return arg;
			}
			arg = args.FirstOrDefault((AttributeArgumentSyntax x) => x.NameEquals != null && x.NameEquals.Name.ToString() == name);
			if (arg != null)
			{
				return arg;
			}
			if (args.Count <= position)
			{
				return null;
			}
			return args[position];
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000652C File Offset: 0x0000472C
		public static string GetArgumentValue(this AttributeData ad, int position, string name, string defaultValue = null)
		{
			if (ad == null)
			{
				return defaultValue;
			}
			KeyValuePair<string, TypedConstant> named = ad.NamedArguments.FirstOrDefault((KeyValuePair<string, TypedConstant> x) => x.Key == name);
			if (named.Key == name)
			{
				return named.Value.Value.ToString();
			}
			if (position < 0 || ad.ConstructorArguments.Count<TypedConstant>() <= position)
			{
				return defaultValue;
			}
			object value = ad.ConstructorArguments[position].Value;
			return ((value != null) ? value.ToString() : null) ?? defaultValue;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000065D0 File Offset: 0x000047D0
		public static string GetArgumentValue(this AttributeSyntax ad, int position, string name, string defaultValue = null)
		{
			if (ad == null || ad.ArgumentList == null)
			{
				return defaultValue;
			}
			int i = 0;
			foreach (AttributeArgumentSyntax arg in ad.ArgumentList.Arguments)
			{
				if (arg.NameColon != null && arg.NameColon.Name.ToString() == name)
				{
					return arg.Expression.ToString();
				}
				if (arg.NameEquals != null && arg.NameEquals.Name.ToString() == name)
				{
					return arg.Expression.ToString();
				}
				if (arg.NameColon == null)
				{
					if (i == position)
					{
						return arg.Expression.ToString();
					}
					i++;
				}
			}
			return defaultValue;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000668C File Offset: 0x0000488C
		public static MethodDeclarationSyntax AddStatementToFront(this MethodDeclarationSyntax node, string statement)
		{
			if (node.Body != null)
			{
				BlockSyntax body = node.Body;
				SyntaxList<StatementSyntax> statements = body.Statements.Insert(0, SyntaxFactory.ParseStatement(statement, 0, null, true));
				body = body.WithStatements(statements);
				return node.WithBody(body);
			}
			MethodDeclarationSyntax methodDeclarationSyntax = SyntaxFactory.MethodDeclaration(node.AttributeLists, node.Modifiers, node.ReturnType, node.ExplicitInterfaceSpecifier, node.Identifier, node.TypeParameterList, node.ParameterList, node.ConstraintClauses, null, node.SemicolonToken);
			StatementSyntax callStatement;
			if (!node.ReturnType.IsKind(SyntaxKind.PredefinedType) || (node.ReturnType as PredefinedTypeSyntax).Keyword.Text != "void")
			{
				callStatement = SyntaxFactory.ParseStatement("return " + node.ExpressionBody.Expression.ToFullString() + ";", 0, null, true);
			}
			else
			{
				callStatement = SyntaxFactory.ParseStatement(node.ExpressionBody.Expression.ToFullString() + ";", 0, null, true);
			}
			return methodDeclarationSyntax.AddBodyStatements(new StatementSyntax[]
			{
				SyntaxFactory.ParseStatement(statement, 0, null, true),
				callStatement
			});
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000067AC File Offset: 0x000049AC
		public static string ToDisplayString(this Accessibility accessibility)
		{
			switch (accessibility)
			{
			case Accessibility.NotApplicable:
				return null;
			case Accessibility.Private:
				return "private";
			case Accessibility.ProtectedAndInternal:
				return "private protected";
			case Accessibility.Protected:
				return "protected";
			case Accessibility.Internal:
				return "internal";
			case Accessibility.ProtectedOrInternal:
				return "protected internal";
			case Accessibility.Public:
				return "public";
			default:
				throw new NotSupportedException(accessibility.ToString());
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00006818 File Offset: 0x00004A18
		public static bool ImplementsGetOrSet(this PropertyDeclarationSyntax prop)
		{
			AccessorDeclarationSyntax get = prop.AccessorList.Accessors.FirstOrDefault((AccessorDeclarationSyntax x) => x.Keyword.IsKind(SyntaxKind.GetKeyword));
			AccessorDeclarationSyntax set = prop.AccessorList.Accessors.FirstOrDefault((AccessorDeclarationSyntax x) => x.Keyword.IsKind(SyntaxKind.SetKeyword));
			return get != null && set != null && get.Body == null && set.Body == null;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000068AA File Offset: 0x00004AAA
		public static string BackingFieldName(this PropertyDeclarationSyntax prop)
		{
			return string.Format("_repback__{0}", prop.Identifier);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000068C1 File Offset: 0x00004AC1
		public static INamedTypeSymbol GetType(this SemanticModel model, string name)
		{
			INamedTypeSymbol typeByMetadataName = model.Compilation.GetTypeByMetadataName(name);
			if (typeByMetadataName == null)
			{
				throw new InvalidOperationException("Type '" + name + "' could not be found in the compilation.");
			}
			return typeByMetadataName;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000068E8 File Offset: 0x00004AE8
		public static ITypeSymbol GetElementType(this ITypeSymbol symbol)
		{
			IArrayTypeSymbol arrayTypeSymbol = symbol as IArrayTypeSymbol;
			if (arrayTypeSymbol == null)
			{
				throw new InvalidOperationException("Cannot get the array element type from type '" + symbol.ToDisplayString(null) + "'.");
			}
			return arrayTypeSymbol.ElementType;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00006914 File Offset: 0x00004B14
		public static bool DerivesFrom(this ITypeSymbol symbol, ITypeSymbol search)
		{
			return symbol != null && (symbol.MetadataName == search.MetadataName || symbol.BaseType.DerivesFrom(search));
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000693C File Offset: 0x00004B3C
		public static string PrintableWithPeriod(this INamespaceSymbol containingNamespace)
		{
			if (containingNamespace.IsGlobalNamespace)
			{
				return "global::";
			}
			return string.Format("{0}.", containingNamespace);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00006957 File Offset: 0x00004B57
		public static string FullName(this ITypeSymbol type)
		{
			return type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00006964 File Offset: 0x00004B64
		public static bool DerivesFrom(this ITypeSymbol symbol, string name, bool exact = false)
		{
			return symbol != null && ((exact && symbol.FullName() == name) || (!exact && symbol.FullName().StartsWith(name)) || symbol.BaseType.DerivesFrom(name, exact));
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000069A0 File Offset: 0x00004BA0
		public static bool DerivesFromOrImplementsAnyConstructionOf(this INamedTypeSymbol type, INamedTypeSymbol parentType)
		{
			if (!parentType.IsDefinition)
			{
				throw new ArgumentException("The type parentType is not a definition; it is a constructed type", "parentType");
			}
			INamedTypeSymbol baseType2;
			for (INamedTypeSymbol baseType = type.OriginalDefinition; baseType != null; baseType = ((baseType2 != null) ? baseType2.OriginalDefinition : null))
			{
				if (baseType.Equals(parentType))
				{
					return true;
				}
				baseType2 = baseType.BaseType;
			}
			return type.OriginalDefinition.AllInterfaces.Any((INamedTypeSymbol baseInterface) => baseInterface.OriginalDefinition.Equals(parentType));
		}
	}
}
