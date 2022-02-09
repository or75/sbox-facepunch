using System;
using System.Linq;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sandbox.Generator
{
	// Token: 0x0200000E RID: 14
	internal static class Description
	{
		// Token: 0x06000042 RID: 66 RVA: 0x00003DD4 File Offset: 0x00001FD4
		internal static void VisitProperty(ref PropertyDeclarationSyntax node, IPropertySymbol symbol, Worker master)
		{
			string comment = symbol.GetDocumentationCommentXml(null, false, default(CancellationToken));
			if (string.IsNullOrEmpty(comment))
			{
				return;
			}
			XDocument doc = null;
			try
			{
				doc = XDocument.Parse(comment);
			}
			catch (Exception)
			{
			}
			if (doc == null)
			{
				return;
			}
			XElement summary = doc.Descendants("summary").FirstOrDefault<XElement>();
			if (summary == null)
			{
				return;
			}
			XmlReader xmlReader = summary.CreateReader();
			xmlReader.MoveToContent();
			comment = xmlReader.ReadInnerXml().Trim();
			comment = comment.Replace("\\", "\\\\");
			comment = comment.Replace("\n", " ");
			comment = comment.Replace("\r", "");
			comment = comment.Replace("    ", "");
			NameSyntax name = SyntaxFactory.ParseName("Sandbox.Internal.DescriptionAttribute", 0, true);
			AttributeArgumentListSyntax arguments = SyntaxFactory.ParseAttributeArgumentList("( " + comment.QuoteSafe() + " )", 0, null, true);
			AttributeSyntax attribute = SyntaxFactory.Attribute(name, arguments);
			SeparatedSyntaxList<AttributeSyntax> attributeList = default(SeparatedSyntaxList<AttributeSyntax>).Add(attribute);
			AttributeListSyntax list = SyntaxFactory.AttributeList(attributeList);
			node = node.AddAttributeLists(new AttributeListSyntax[] { list });
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003EF8 File Offset: 0x000020F8
		internal static void VisitMethod(ref MethodDeclarationSyntax node, IMethodSymbol symbol, Worker master)
		{
			string comment = symbol.GetDocumentationCommentXml(null, false, default(CancellationToken));
			if (string.IsNullOrEmpty(comment))
			{
				return;
			}
			XDocument doc = null;
			try
			{
				doc = XDocument.Parse(comment);
			}
			catch (Exception)
			{
			}
			if (doc == null)
			{
				return;
			}
			XElement summary = doc.Descendants("summary").FirstOrDefault<XElement>();
			if (summary == null)
			{
				return;
			}
			comment = summary.Value.Trim();
			comment = comment.Replace("\\", "\\\\");
			comment = comment.Replace("\n", " ");
			comment = comment.Replace("\r", "");
			comment = comment.Replace("    ", "");
			NameSyntax name = SyntaxFactory.ParseName("Sandbox.Internal.DescriptionAttribute", 0, true);
			AttributeArgumentListSyntax arguments = SyntaxFactory.ParseAttributeArgumentList("( " + comment.QuoteSafe() + " )", 0, null, true);
			AttributeSyntax attribute = SyntaxFactory.Attribute(name, arguments);
			SeparatedSyntaxList<AttributeSyntax> attributeList = default(SeparatedSyntaxList<AttributeSyntax>).Add(attribute);
			AttributeListSyntax list = SyntaxFactory.AttributeList(attributeList);
			node = node.AddAttributeLists(new AttributeListSyntax[] { list });
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00004010 File Offset: 0x00002210
		internal static void VisitClass(ref ClassDeclarationSyntax node, INamedTypeSymbol symbol, Worker master)
		{
			string comment = symbol.GetDocumentationCommentXml(null, false, default(CancellationToken));
			if (string.IsNullOrEmpty(comment))
			{
				return;
			}
			XDocument doc = null;
			try
			{
				doc = XDocument.Parse(comment);
			}
			catch (Exception)
			{
			}
			if (doc == null)
			{
				return;
			}
			XElement summary = doc.Descendants("summary").FirstOrDefault<XElement>();
			if (summary == null)
			{
				return;
			}
			comment = summary.Value.Trim();
			comment = comment.Replace("\\", "\\\\");
			comment = comment.Replace("\n", " ");
			comment = comment.Replace("\r", "");
			comment = comment.Replace("    ", "");
			NameSyntax name = SyntaxFactory.ParseName("Sandbox.Internal.DescriptionAttribute", 0, true);
			AttributeArgumentListSyntax arguments = SyntaxFactory.ParseAttributeArgumentList("( " + comment.QuoteSafe() + " )", 0, null, true);
			AttributeSyntax attribute = SyntaxFactory.Attribute(name, arguments);
			SeparatedSyntaxList<AttributeSyntax> attributeList = default(SeparatedSyntaxList<AttributeSyntax>).Add(attribute);
			AttributeListSyntax list = SyntaxFactory.AttributeList(attributeList);
			node = node.AddAttributeLists(new AttributeListSyntax[] { list });
		}
	}
}
