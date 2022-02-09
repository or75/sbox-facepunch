using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace Sandbox.SolutionGenerator
{
	/// <summary>
	/// Class to produce the template output
	/// </summary>
	// Token: 0x02000005 RID: 5
	[GeneratedCode("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
	internal class Project : ProjectBase
	{
		/// <summary>
		/// Create the template output
		/// </summary>
		// Token: 0x06000023 RID: 35 RVA: 0x00002A24 File Offset: 0x00000C24
		public virtual string TransformText()
		{
			base.Write("<Project Sdk=\"Microsoft.NET.Sdk\">\r\n\r\n\t<PropertyGroup>\r\n\t\t<TargetFramework>net6.0</TargetFramework>\r\n\t\t<GenerateDocumentationFile>true</GenerateDocumentationFile>\r\n\t\t<AssemblyName>");
			base.Write(base.ToStringHelper.ToStringWithCulture(this.ProjectName));
			base.Write("</AssemblyName>\r\n\t\t<PackageId>");
			base.Write(base.ToStringHelper.ToStringWithCulture(this.ProjectName));
			base.Write("</PackageId>\r\n\t\t<LangVersion>10</LangVersion>\r\n\t\t<NoWarn>1701;1702;1591;</NoWarn>\r\n\t\t<AppendTargetFrameworkToOutputPath>false</AppendTargetFrameworkToOutputPath>\r\n\t\t<DefineConstants>SANDBOX;DEBUG;TRACE</DefineConstants>\r\n\t</PropertyGroup>\r\n\r\n\t<ItemGroup>\r\n\t\t<None Update=\"**\\*.scss\" DependentUpon=\"%(Filename).cs\" />\r\n\t\t<None Update=\"**\\*.css\" DependentUpon=\"%(Filename).cs\" />\r\n\t\t<None Update=\"**\\*.sass\" DependentUpon=\"%(Filename).cs\" />\r\n\t\t<None Update=\"**\\*.html\" DependentUpon=\"%(Filename).cs\" />\r\n\t\t<None Update=\"**\\*.htm\" DependentUpon=\"%(Filename).cs\" />\r\n\t</ItemGroup>\r\n\r\n\t<ItemGroup>\r\n");
			foreach (string entry in this.GlobalNamespaces)
			{
				base.Write("\t\t<Using Include=\"");
				base.Write(base.ToStringHelper.ToStringWithCulture(entry));
				base.Write("\" Static=\"true\" />\r\n");
			}
			base.Write("\t</ItemGroup>\r\n\r\n  <PropertyGroup>\r\n\t<OutputPath>../.vs/output/</OutputPath>\r\n\t<DocumentationFile>../.vs/output/");
			base.Write(base.ToStringHelper.ToStringWithCulture(this.ProjectName));
			base.Write(".xml</DocumentationFile>\r\n\t<RootNamespace>");
			base.Write(base.ToStringHelper.ToStringWithCulture(this.RootNamespace));
			base.Write("</RootNamespace>\r\n  </PropertyGroup>\r\n\r\n\t<ItemGroup>\r\n\t\t<Analyzer Include=\"");
			base.Write(base.ToStringHelper.ToStringWithCulture(this.ManagedRoot));
			base.Write("\\Sandbox.Generator.dll\"/>\r\n");
			foreach (string entry2 in this.References)
			{
				base.Write("\t\t<Reference Include=\"");
				base.Write(base.ToStringHelper.ToStringWithCulture(this.ManagedRoot));
				base.Write("/");
				base.Write(base.ToStringHelper.ToStringWithCulture(entry2));
				base.Write("\" />\r\n");
			}
			base.Write("\t</ItemGroup>\r\n\r\n  <ItemGroup>\r\n");
			base.Write(base.ToStringHelper.ToStringWithCulture(this.ProjectReferences));
			base.Write("\r\n  </ItemGroup>\r\n\r\n</Project>\r\n");
			return base.GenerationEnvironment.ToString();
		}

		// Token: 0x0400000E RID: 14
		public string ProjectName;

		// Token: 0x0400000F RID: 15
		public List<string> References;

		// Token: 0x04000010 RID: 16
		public List<string> GlobalNamespaces;

		// Token: 0x04000011 RID: 17
		public string ProjectReferences;

		// Token: 0x04000012 RID: 18
		public string ManagedRoot;

		// Token: 0x04000013 RID: 19
		public string RootNamespace;
	}
}
