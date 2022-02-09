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
	// Token: 0x02000011 RID: 17
	internal class Replicate
	{
		// Token: 0x06000048 RID: 72 RVA: 0x00004424 File Offset: 0x00002624
		internal static void VisitProperty(ref PropertyDeclarationSyntax node, IPropertySymbol symbol, Worker master)
		{
			AttributeSyntax attribute = node.GetAttribute("Net");
			if (attribute == null)
			{
				return;
			}
			if (symbol.IsStatic)
			{
				master.AddError(node.GetLocation(), "You can't make this property networkable because it's static!");
				return;
			}
			attribute.Name.ToString().Replace("Attribute", "");
			if (node.AccessorList == null)
			{
				master.AddError(node.GetLocation(), string.Format("[Net] can only be applied to auto-implemented properties. ( Needs to be {0} {{ get; set; }} )", node.Identifier));
				return;
			}
			AccessorDeclarationSyntax get = node.AccessorList.Accessors.FirstOrDefault((AccessorDeclarationSyntax x) => x.Keyword.IsKind(SyntaxKind.GetKeyword));
			AccessorDeclarationSyntax set = node.AccessorList.Accessors.FirstOrDefault((AccessorDeclarationSyntax x) => x.Keyword.IsKind(SyntaxKind.SetKeyword));
			if (get == null || set == null || get.Body != null || set.Body != null)
			{
				master.AddError(node.GetLocation(), string.Format("[Net] can only be applied to auto-implemented properties. ( Needs to be {0} {{ get; set; }} )", node.Identifier));
				return;
			}
			bool predicted = node.GetAttribute("Predicted") != null;
			bool local = node.GetAttribute("Local") != null;
			if (symbol.Type.DerivesFrom("global::Sandbox.EntityComponent", true))
			{
				master.AddError(node.GetLocation(), "EntityComponents aren't networkable with [Net] - add them to the entity using Components.Add instead.");
				return;
			}
			TypeKind typeKind = symbol.Type.TypeKind;
			if (typeKind <= TypeKind.Enum)
			{
				if (typeKind == TypeKind.Class)
				{
					goto IL_1AC;
				}
				if (typeKind != TypeKind.Enum)
				{
					goto IL_2A8;
				}
			}
			else
			{
				if (typeKind == TypeKind.Interface)
				{
					goto IL_1AC;
				}
				if (typeKind != TypeKind.Struct)
				{
					goto IL_2A8;
				}
			}
			Replicate.MakeNetworkVariable(ref node, symbol, master, predicted, local, "VarUnmanaged", null);
			Replicate.AddCallback(ref node, symbol, master, null, null);
			return;
			IL_1AC:
			INamedTypeSymbol namedType = symbol.Type as INamedTypeSymbol;
			if (namedType.DerivesFromOrImplementsAnyConstructionOf(master.GetOrCreateTypeByMetadataName("System.Collections.Generic.IList`1")))
			{
				Replicate.ReplicateListProperty(ref node, symbol, master);
				return;
			}
			if (namedType.DerivesFromOrImplementsAnyConstructionOf(master.GetOrCreateTypeByMetadataName("System.Collections.Generic.IDictionary`2")))
			{
				Replicate.ReplicateDictionaryProperty(ref node, symbol, master);
				return;
			}
			if (symbol.Type.DerivesFrom("global::Sandbox.Entity", true))
			{
				Replicate.MakeNetworkVariable(ref node, symbol, master, predicted, local, "VarUnmanaged", "Sandbox.Internal.EntityHandle<" + symbol.Type.FullName() + ">");
				Replicate.AddCallback(ref node, symbol, master, "Sandbox.Internal.EntityHandle<" + symbol.Type.FullName() + ">", symbol.Type.FullName());
				return;
			}
			if (symbol.Type.DerivesFrom("global::Sandbox.BaseNetworkable", true))
			{
				Replicate.MakeNetworkVariableEmbed(ref node, symbol, master, predicted, local, "VarClass");
				Replicate.AddCallback(ref node, symbol, master, null, null);
				return;
			}
			Replicate.MakeNetworkVariable(ref node, symbol, master, predicted, local, "VarGeneric", null);
			Replicate.AddCallback(ref node, symbol, master, null, null);
			return;
			IL_2A8:
			master.AddError(node.GetLocation(), new DiagnosticDescriptor("SB1002", "Net Not Supported", string.Format("I don't know how to network {0}", symbol.Type), "generator", DiagnosticSeverity.Error, true, null, null, Array.Empty<string>()), Array.Empty<object>());
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00004718 File Offset: 0x00002918
		private static void AddCallback(ref PropertyDeclarationSyntax node, IPropertySymbol symbol, Worker master, string type = null, string castType = null)
		{
			AttributeData attr = symbol.GetAttribute("Change");
			if (attr == null)
			{
				return;
			}
			if (type == null)
			{
				type = symbol.Type.FullName();
			}
			string fieldName = node.BackingFieldName();
			string functionName = attr.GetArgumentValue(0, "Name", string.Format("On{0}Changed", node.Identifier));
			if (castType != null)
			{
				string castLambda = string.Concat(new string[]
				{
					"( ", type, " oldVal, ", type, " newVal ) => ", functionName, "( (", castType, ")oldVal, (", castType,
					")newVal )"
				});
				master.AddClassBlock("build_network_table", string.Concat(new string[] { fieldName, ".SetCallback<", type, ">( ", castLambda, " );" }), symbol.ContainingType);
				return;
			}
			master.AddClassBlock("build_network_table", string.Concat(new string[] { fieldName, ".SetCallback<", type, ">( ", functionName, " );" }), symbol.ContainingType);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00004850 File Offset: 0x00002A50
		private static void MakeNetworkVariable(ref PropertyDeclarationSyntax node, IPropertySymbol symbol, Worker master, bool predicted, bool local, string NetworkVariable, string type = null)
		{
			AccessorDeclarationSyntax get = node.AccessorList.Accessors.FirstOrDefault((AccessorDeclarationSyntax x) => x.Keyword.IsKind(SyntaxKind.GetKeyword));
			AccessorDeclarationSyntax set = node.AccessorList.Accessors.FirstOrDefault((AccessorDeclarationSyntax x) => x.Keyword.IsKind(SyntaxKind.SetKeyword));
			if (type == null)
			{
				type = symbol.Type.FullName();
			}
			if (type.EndsWith("?"))
			{
				type = type.TrimEnd(new char[] { '?' });
				NetworkVariable += "Nullable";
			}
			string fieldName = node.BackingFieldName();
			ExpressionSyntax statements = SyntaxFactory.ParseExpression(fieldName + ".GetValue();", 0, null, true);
			get = SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithExpressionBody(SyntaxFactory.ArrowExpressionClause(statements));
			StatementSyntax[] s = new StatementSyntax[] { SyntaxFactory.ParseStatement(fieldName + ".SetValue( value );", 0, null, true) };
			set = SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration, SyntaxFactory.Block(s));
			string format = "{0} Sandbox.Internal.{1}<{2}> {3} = new Sandbox.Internal.{4}<{5}>( {6} );\n";
			object[] array = new object[7];
			array[0] = node.Modifiers;
			array[1] = NetworkVariable;
			array[2] = type;
			array[3] = fieldName;
			array[4] = NetworkVariable;
			array[5] = type;
			int num = 6;
			EqualsValueClauseSyntax initializer = node.Initializer;
			array[num] = ((initializer != null) ? initializer.ToString().Trim(new char[] { ' ', '=' }) : null);
			master.AddToCurrentClass(string.Format(format, array), true);
			master.AddClassBlock("build_network_table", string.Concat(new string[]
			{
				"builder.Register( ref ",
				fieldName,
				", \"",
				symbol.Name,
				"\", ",
				predicted.ToString().ToLower(),
				", ",
				local.ToString().ToLower(),
				" );"
			}), symbol.ContainingType);
			node = node.WithAccessorList(SyntaxFactory.AccessorList(SyntaxFactory.List<AccessorDeclarationSyntax>(new AccessorDeclarationSyntax[] { get, set }))).WithInitializer(null).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.None))
				.NormalizeWhitespace("    ", "\r\n", false);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00004A88 File Offset: 0x00002C88
		private static void MakeNetworkVariableArray(ref PropertyDeclarationSyntax node, IPropertySymbol symbol, Worker master, bool predicted, bool local, string typeName, string keyType)
		{
			string fieldName = node.BackingFieldName();
			ExpressionSyntax statements = SyntaxFactory.ParseExpression(fieldName + ".GetValue();", 0, null, true);
			AccessorDeclarationSyntax get = SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithExpressionBody(SyntaxFactory.ArrowExpressionClause(statements));
			StatementSyntax[] s = new StatementSyntax[] { SyntaxFactory.ParseStatement(fieldName + ".SetValue( value );", 0, null, true) };
			AccessorDeclarationSyntax set = SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration, SyntaxFactory.Block(s));
			string format = "{0} Sandbox.Internal.{1}<{2}> {3} = new Sandbox.Internal.{4}<{5}>( {6} );\n";
			object[] array = new object[7];
			array[0] = node.Modifiers;
			array[1] = typeName;
			array[2] = keyType;
			array[3] = fieldName;
			array[4] = typeName;
			array[5] = keyType;
			int num = 6;
			EqualsValueClauseSyntax initializer = node.Initializer;
			array[num] = ((initializer != null) ? initializer.ToString().Trim(new char[] { ' ', '=' }) : null);
			master.AddToCurrentClass(string.Format(format, array), true);
			master.AddClassBlock("build_network_table", string.Concat(new string[]
			{
				"builder.Register( ref ",
				fieldName,
				", \"",
				symbol.Name,
				"\", ",
				predicted.ToString().ToLower(),
				", ",
				local.ToString().ToLower(),
				" );"
			}), symbol.ContainingType);
			node = node.WithType(SyntaxFactory.ParseTypeName("System.Collections.Generic.IList<" + keyType + ">", 0, null, true));
			node = node.WithAccessorList(SyntaxFactory.AccessorList(SyntaxFactory.List<AccessorDeclarationSyntax>(new AccessorDeclarationSyntax[] { get, set }))).WithInitializer(null).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.None))
				.NormalizeWhitespace("    ", "\r\n", false);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00004C34 File Offset: 0x00002E34
		internal static void BuildNetworkTableBlock(List<SyntaxTree> trees, IEnumerable<IGrouping<ITypeSymbol, Worker.ClassBlock>> blocks)
		{
			CodeWriter code = new CodeWriter();
			code.WriteLine("using Sandbox;");
			code.WriteLine("using System.Collections.Generic;");
			foreach (IGrouping<ITypeSymbol, Worker.ClassBlock> classGroup in blocks)
			{
				code.StartClass(classGroup.Key);
				code.StartBlock("public override void BuildNetworkTable( Sandbox.NetworkTable builder )");
				foreach (Worker.ClassBlock block in classGroup)
				{
					code.WriteLines(block.Text);
				}
				code.WriteLine("base.BuildNetworkTable( builder );");
				code.EndBlock("");
				code.EndClass(classGroup.Key);
			}
			SyntaxTree st = SyntaxFactory.ParseSyntaxTree(code.ToString(), null, "BuildNetworkTable", Encoding.UTF8, default(CancellationToken));
			trees.Add(st);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00004D38 File Offset: 0x00002F38
		private static void MakeNetworkVariableEmbed(ref PropertyDeclarationSyntax node, IPropertySymbol symbol, Worker master, bool predicted, bool local, string typeName)
		{
			string type = symbol.Type.FullName();
			string fieldName = node.BackingFieldName();
			INamedTypeSymbol namedType = symbol.Type as INamedTypeSymbol;
			if (namedType.IsGenericType && namedType.TypeArguments.Length > 0)
			{
				type = namedType.TypeArguments.First<ITypeSymbol>().FullName();
			}
			AccessorDeclarationSyntax get = node.AccessorList.Accessors.FirstOrDefault((AccessorDeclarationSyntax x) => x.Keyword.IsKind(SyntaxKind.GetKeyword));
			AccessorDeclarationSyntax set = node.AccessorList.Accessors.FirstOrDefault((AccessorDeclarationSyntax x) => x.Keyword.IsKind(SyntaxKind.SetKeyword));
			ExpressionSyntax statements = SyntaxFactory.ParseExpression(fieldName + ".GetValue();", 0, null, true);
			get = SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithExpressionBody(SyntaxFactory.ArrowExpressionClause(statements));
			StatementSyntax[] s = new StatementSyntax[] { SyntaxFactory.ParseStatement(fieldName + ".SetValue( value );", 0, null, true) };
			set = SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration, SyntaxFactory.Block(s));
			string format = "{0} Sandbox.Internal.{1}<{2}> {3} = new Sandbox.Internal.{4}<{5}>( {6} );\n";
			object[] array = new object[7];
			array[0] = node.Modifiers;
			array[1] = typeName;
			array[2] = type;
			array[3] = fieldName;
			array[4] = typeName;
			array[5] = type;
			int num = 6;
			EqualsValueClauseSyntax initializer = node.Initializer;
			array[num] = ((initializer != null) ? initializer.ToString().Trim(new char[] { ' ', '=' }) : null);
			master.AddToCurrentClass(string.Format(format, array), true);
			master.AddClassBlock("build_network_table", string.Concat(new string[]
			{
				"builder.Register( ref ",
				fieldName,
				", \"",
				symbol.Name,
				"\", ",
				predicted.ToString().ToLower(),
				", ",
				local.ToString().ToLower(),
				" );"
			}), symbol.ContainingType);
			node = node.WithAccessorList(SyntaxFactory.AccessorList(SyntaxFactory.List<AccessorDeclarationSyntax>(new AccessorDeclarationSyntax[] { get, set }))).WithInitializer(null).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.None))
				.NormalizeWhitespace("    ", "\r\n", false);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00004F74 File Offset: 0x00003174
		internal static bool IsNetWriteClass(ITypeSymbol symbol)
		{
			return symbol.FullName() == "string" || symbol.DerivesFrom("global::Sandbox.Entity", true) || symbol.DerivesFrom("global::Sandbox.Client", true) || symbol.DerivesFrom("global::Sandbox.Resource", true);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00004FC8 File Offset: 0x000031C8
		internal static void ReplicateDictionaryProperty(ref PropertyDeclarationSyntax node, IPropertySymbol symbol, Worker master)
		{
			INamedTypeSymbol namedType = symbol.Type as INamedTypeSymbol;
			if (!namedType.IsGenericType || namedType.TypeArguments.Length != 2)
			{
				return;
			}
			ITypeSymbol keyType = namedType.TypeArguments[0];
			ITypeSymbol valType = namedType.TypeArguments[1];
			if (symbol.Type.DerivesFrom("global::System.Collections.Generic.Dictionary<", false))
			{
				master.AddError(node.GetLocation(), Replicate.WarningDictionaryNotIDictionary, new object[]
				{
					symbol,
					keyType.ToDisplayString(null),
					valType.ToDisplayString(null)
				});
			}
			if (!keyType.IsUnmanagedType && !Replicate.IsNetWriteClass(keyType))
			{
				master.AddError(node.GetLocation(), Replicate.ErrorDictionaryUnsupportedKey, new object[]
				{
					symbol,
					keyType.ToDisplayString(null)
				});
				return;
			}
			if (!valType.IsUnmanagedType && !Replicate.IsNetWriteClass(valType) && !valType.DerivesFrom("global::Sandbox.BaseNetworkable", true) && valType.FullName() != "object")
			{
				master.AddError(node.GetLocation(), Replicate.ErrorDictionaryUnsupportedValue, new object[]
				{
					symbol,
					valType.ToDisplayString(null)
				});
				return;
			}
			string implementKey = (keyType.IsUnmanagedType ? "U" : "C");
			string implementVal = (valType.IsUnmanagedType ? "U" : ((valType.Name != "Object") ? "C" : "O"));
			string KeyValType = keyType.FullName() + ", " + valType.FullName();
			string DictionaryType = string.Concat(new string[] { "VarDictionary", implementKey, implementVal, "<", KeyValType, ">" });
			if (valType.FullName() == "object")
			{
				DictionaryType = string.Concat(new string[]
				{
					"VarObjectDictionary",
					implementKey,
					"<",
					keyType.FullName(),
					">"
				});
			}
			if (valType.DerivesFrom("global::Sandbox.BaseNetworkable", true) && !valType.DerivesFrom("global::Sandbox.Entity", true))
			{
				DictionaryType = string.Concat(new string[] { "VarEmbedDictionary", implementKey, "<", KeyValType, ">" });
			}
			bool predicted = node.GetAttribute("Predicted") != null;
			bool local = node.GetAttribute("Local") != null;
			Replicate.MakeNetworkVariableDictionary(ref node, symbol, master, predicted, local, DictionaryType, KeyValType);
			Replicate.AddCallback(ref node, symbol, master, null, null);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00005248 File Offset: 0x00003448
		private static void MakeNetworkVariableDictionary(ref PropertyDeclarationSyntax node, IPropertySymbol symbol, Worker master, bool predicted, bool local, string typeName, string keyValueType)
		{
			string fieldName = node.BackingFieldName();
			ExpressionSyntax statements = SyntaxFactory.ParseExpression(fieldName + ".GetValue();", 0, null, true);
			AccessorDeclarationSyntax get = SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithExpressionBody(SyntaxFactory.ArrowExpressionClause(statements));
			StatementSyntax[] s = new StatementSyntax[] { SyntaxFactory.ParseStatement(fieldName + ".SetValue( value );", 0, null, true) };
			AccessorDeclarationSyntax set = SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration, SyntaxFactory.Block(s));
			string format = "{0} Sandbox.Internal.{1} {2} = new Sandbox.Internal.{3} ( {4} );\n";
			object[] array = new object[5];
			array[0] = node.Modifiers;
			array[1] = typeName;
			array[2] = fieldName;
			array[3] = typeName;
			int num = 4;
			EqualsValueClauseSyntax initializer = node.Initializer;
			array[num] = ((initializer != null) ? initializer.ToString().Trim(new char[] { ' ', '=' }) : null);
			master.AddToCurrentClass(string.Format(format, array), true);
			master.AddClassBlock("build_network_table", string.Concat(new string[]
			{
				"builder.Register( ref ",
				fieldName,
				", \"",
				symbol.Name,
				"\", ",
				predicted.ToString().ToLower(),
				", ",
				local.ToString().ToLower(),
				" );"
			}), symbol.ContainingType);
			node = node.WithType(SyntaxFactory.ParseTypeName("System.Collections.Generic.IDictionary<" + keyValueType + ">", 0, null, true));
			node = node.WithAccessorList(SyntaxFactory.AccessorList(SyntaxFactory.List<AccessorDeclarationSyntax>(new AccessorDeclarationSyntax[] { get, set }))).WithInitializer(null).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.None))
				.NormalizeWhitespace("    ", "\r\n", false);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000053EC File Offset: 0x000035EC
		internal static void ReplicateListProperty(ref PropertyDeclarationSyntax node, IPropertySymbol symbol, Worker master)
		{
			INamedTypeSymbol namedType = symbol.Type as INamedTypeSymbol;
			if (!namedType.IsGenericType || namedType.TypeArguments.Length != 1)
			{
				return;
			}
			ITypeSymbol type = namedType.TypeArguments.First<ITypeSymbol>();
			if (symbol.Type.DerivesFrom("global::System.Collections.Generic.List<", false))
			{
				master.AddError(node.GetLocation(), Replicate.WarningListNotIList, new object[]
				{
					symbol,
					type.ToDisplayString(null)
				});
			}
			string implementListType = "VarGenericList";
			if (type.IsUnmanagedType)
			{
				implementListType = "VarUnmanagedList";
			}
			else if (type.DerivesFrom("global::Sandbox.BaseNetworkable", true) && !type.DerivesFrom("global::Sandbox.Entity", true))
			{
				implementListType = "VarEmbedList";
			}
			bool predicted = node.GetAttribute("Predicted") != null;
			bool local = node.GetAttribute("Local") != null;
			Replicate.MakeNetworkVariableArray(ref node, symbol, master, predicted, local, implementListType, type.FullName());
			Replicate.AddCallback(ref node, symbol, master, null, null);
		}

		// Token: 0x0400000B RID: 11
		private static DiagnosticDescriptor WarningDictionaryNotIDictionary = new DiagnosticDescriptor("SB1002", "Replicated Dictionary should be IDictionary", "Use IDictionary<{1}, {2}> instead of Dictionary<{1}, {2}> on '{0}'", "generator", DiagnosticSeverity.Warning, true, null, null, Array.Empty<string>());

		// Token: 0x0400000C RID: 12
		private static DiagnosticDescriptor ErrorDictionaryUnsupportedKey = new DiagnosticDescriptor("SB1002", "Unsupported replicated Dictionary key type", "Networked {0} does not support key type of {1}", "generator", DiagnosticSeverity.Error, true, null, null, Array.Empty<string>());

		// Token: 0x0400000D RID: 13
		private static DiagnosticDescriptor ErrorDictionaryUnsupportedValue = new DiagnosticDescriptor("SB1002", "Unsupported replicated Dictionary value type", "Networked {0} does not support value type of {1}", "generator", DiagnosticSeverity.Error, true, null, null, Array.Empty<string>());

		// Token: 0x0400000E RID: 14
		private static DiagnosticDescriptor WarningListNotIList = new DiagnosticDescriptor("SB1002", "Replicated List should be IList", "Use IList<{1}> instead of List<{1}> on '{0}'", "generator", DiagnosticSeverity.Warning, true, null, null, Array.Empty<string>());
	}
}
