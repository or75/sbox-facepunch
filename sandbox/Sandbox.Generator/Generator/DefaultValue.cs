using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sandbox.Generator
{
	// Token: 0x0200000D RID: 13
	internal class DefaultValue
	{
		// Token: 0x0600003F RID: 63 RVA: 0x00003C38 File Offset: 0x00001E38
		internal static void WriteAttribute(ref PropertyDeclarationSyntax node)
		{
			NameSyntax name = SyntaxFactory.ParseName("Sandbox.Internal.DefaultValueAttribute", 0, true);
			AttributeArgumentListSyntax arguments = SyntaxFactory.ParseAttributeArgumentList(string.Format("( {0} )", node.Initializer.Value), 0, null, true);
			AttributeSyntax attribute = SyntaxFactory.Attribute(name, arguments);
			SeparatedSyntaxList<AttributeSyntax> attributeList = default(SeparatedSyntaxList<AttributeSyntax>).Add(attribute);
			AttributeListSyntax list = SyntaxFactory.AttributeList(attributeList);
			node = node.AddAttributeLists(new AttributeListSyntax[] { list });
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003CA4 File Offset: 0x00001EA4
		internal static void VisitProperty(ref PropertyDeclarationSyntax node, IPropertySymbol symbol, Worker master)
		{
			if (symbol.IsStatic)
			{
				return;
			}
			if (node.Initializer == null)
			{
				return;
			}
			if (symbol.Type.TypeKind == TypeKind.Class && symbol.Type.SpecialType != SpecialType.System_String)
			{
				return;
			}
			ExpressionSyntax initializer = node.Initializer.Value;
			bool isString = initializer.ToString().StartsWith("\"") && initializer.ToString().EndsWith("\"");
			int num;
			float num2;
			if (!isString && symbol.Type.TypeKind == TypeKind.Struct && symbol.NullableAnnotation == NullableAnnotation.Annotated && (int.TryParse(node.Initializer.Value.ToString(), out num) || float.TryParse(node.Initializer.Value.ToString(), out num2)))
			{
				DefaultValue.WriteAttribute(ref node);
				return;
			}
			if (!isString && symbol.Type.SpecialType != SpecialType.System_String && symbol.Type.SpecialType != SpecialType.System_Int32 && symbol.Type.SpecialType != SpecialType.System_Boolean && symbol.Type.SpecialType != SpecialType.System_Single && symbol.Type.SpecialType != SpecialType.System_Enum && symbol.Type.TypeKind != TypeKind.Enum)
			{
				return;
			}
			DefaultValue.WriteAttribute(ref node);
		}
	}
}
