using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sandbox.Utility;

namespace Sandbox.Generator
{
	// Token: 0x02000016 RID: 22
	public class Worker : CSharpSyntaxRewriter
	{
		// Token: 0x06000072 RID: 114 RVA: 0x00006A27 File Offset: 0x00004C27
		public static Task<Worker> Process(CSharpCompilation compilation, SyntaxTree tree, string root, bool isInGame)
		{
			Worker m = new Worker(compilation, tree, root, isInGame);
			return Task.Run<Worker>(() => m.Run());
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00006A4D File Offset: 0x00004C4D
		// (set) Token: 0x06000074 RID: 116 RVA: 0x00006A55 File Offset: 0x00004C55
		public SyntaxTree TreeInput { get; private set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00006A5E File Offset: 0x00004C5E
		// (set) Token: 0x06000076 RID: 118 RVA: 0x00006A66 File Offset: 0x00004C66
		public bool IsFullGeneration { get; private set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00006A6F File Offset: 0x00004C6F
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00006A77 File Offset: 0x00004C77
		public CSharpSyntaxNode OutputNode { get; private set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00006A80 File Offset: 0x00004C80
		// (set) Token: 0x0600007A RID: 122 RVA: 0x00006A88 File Offset: 0x00004C88
		public string Root { get; private set; }

		// Token: 0x0600007B RID: 123 RVA: 0x00006A94 File Offset: 0x00004C94
		internal Worker(CSharpCompilation compilation, SyntaxTree tree, string root, bool isInGame)
			: base(false)
		{
			this.IsFullGeneration = isInGame;
			this.Compilation = compilation;
			this.TreeInput = tree;
			this.Model = this.Compilation.GetSemanticModel(tree, false);
			this.Root = root;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00006B1C File Offset: 0x00004D1C
		internal Worker Run()
		{
			CSharpSyntaxNode node = this.TreeInput.GetRoot(default(CancellationToken)) as CSharpSyntaxNode;
			this.OutputNode = this.Visit(node) as CSharpSyntaxNode;
			return this;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00006B56 File Offset: 0x00004D56
		public void AddToCurrentClass(string text, bool useSourceGen)
		{
			if (useSourceGen)
			{
				this.ClassAdditions.Add(text);
				return;
			}
			this.ClassModifiers.Add(text);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00006B74 File Offset: 0x00004D74
		internal void AddClassBlock(string group, string text, ITypeSymbol clss)
		{
			Worker.ClassBlock b = new Worker.ClassBlock
			{
				Group = group,
				Text = text,
				TypeSymbol = clss
			};
			this.ClassBlocks.Add(b);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00006BAF File Offset: 0x00004DAF
		public override SyntaxNode VisitAttribute(AttributeSyntax node)
		{
			node = base.VisitAttribute(node) as AttributeSyntax;
			UseTemplate.VisitAttribute(ref node, this);
			return node;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00006BC8 File Offset: 0x00004DC8
		public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
		{
			IMethodSymbol symbol = this.Model.GetDeclaredSymbol(node, default(CancellationToken));
			node = base.VisitMethodDeclaration(node) as MethodDeclarationSyntax;
			node = LinePreserve.AddLineNumber<MethodDeclarationSyntax>(node, this.TreeInput);
			node = ClientCmd.VisitMethod(node, symbol, this);
			node = ServerCmd.VisitMethod(node, symbol, this);
			Rpc.VisitMethod(ref node, symbol, this);
			Description.VisitMethod(ref node, symbol, this);
			return node;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00006C30 File Offset: 0x00004E30
		public override SyntaxNode VisitPropertyDeclaration(PropertyDeclarationSyntax node)
		{
			IPropertySymbol symbol = this.Model.GetDeclaredSymbol(node, default(CancellationToken));
			node = base.VisitPropertyDeclaration(node) as PropertyDeclarationSyntax;
			node = LinePreserve.AddLineNumber<PropertyDeclarationSyntax>(node, this.TreeInput);
			node = ConvarReplicated.VisitProperty(node, symbol, this);
			node = ConvarClientData.VisitProperty(node, symbol, this);
			node = ConvarMenu.VisitProperty(node, symbol, this);
			DefaultValue.VisitProperty(ref node, symbol, this);
			Replicate.VisitProperty(ref node, symbol, this);
			HammerOutput.VisitProperty(ref node, symbol, this);
			Description.VisitProperty(ref node, symbol, this);
			BindComponent.VisitProperty(ref node, symbol, this);
			return node;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00006CBC File Offset: 0x00004EBC
		public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
		{
			INamedTypeSymbol symbol = this.Model.GetDeclaredSymbol(node, default(CancellationToken));
			this.ClassAdditions.Clear();
			this.ClassModifiers.Clear();
			node = base.VisitClassDeclaration(node) as ClassDeclarationSyntax;
			node = LinePreserve.AddLineNumber<ClassDeclarationSyntax>(node, this.TreeInput);
			Description.VisitClass(ref node, symbol, this);
			if (this.ClassAdditions.Count > 0)
			{
				if (!node.Modifiers.Any((SyntaxToken m) => m.IsKind(SyntaxKind.PartialKeyword)))
				{
					this.AddError(node.GetLocation(), "Please declare class '" + symbol.Name + "' as a partial so we can add codegen to it");
					return node;
				}
				string filename = string.Format("{0}_{1}.cs", Path.GetFileNameWithoutExtension(this.TreeInput.FilePath), node.Identifier);
				CodeWriter code = new CodeWriter();
				code.WriteLine("using Sandbox;");
				code.WriteLine("using System.Collections.Generic;");
				code.WriteLine("");
				code.StartClass(symbol);
				foreach (string add in this.ClassAdditions)
				{
					code.WriteLines(add);
				}
				code.EndClass(symbol);
				SyntaxTree st = SyntaxFactory.ParseSyntaxTree(code.ToString(), this.TreeInput.Options, filename, this.TreeInput.Encoding, default(CancellationToken));
				this.AddedTrees.Add(st);
			}
			if (this.ClassModifiers.Count > 0)
			{
				MemberDeclarationSyntax[] members = this.ClassModifiers.Select((string x) => SyntaxFactory.ParseMemberDeclaration(x, 0, null, true)).ToArray<MemberDeclarationSyntax>();
				node = node.AddMembers(members);
			}
			return node;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00006EA8 File Offset: 0x000050A8
		internal void AddError(Location location, DiagnosticDescriptor diagnostic, params object[] messageArgs)
		{
			this.Diagnostics.Add(Diagnostic.Create(diagnostic, location, messageArgs));
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00006EC0 File Offset: 0x000050C0
		internal void AddError(Location location, string error)
		{
			this.AddError(location, new DiagnosticDescriptor("SB2000", "Net Not Supported", error, "generator", DiagnosticSeverity.Error, true, null, null, Array.Empty<string>()), Array.Empty<object>());
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00006EF8 File Offset: 0x000050F8
		internal void Log(string v, Location location = null)
		{
			v = v.Replace("\n", "");
			v = v.Replace("\r", "");
			DiagnosticDescriptor d = new DiagnosticDescriptor("SB0002", "Net Not Supported", v, "generator", DiagnosticSeverity.Warning, true, null, null, Array.Empty<string>());
			this.Diagnostics.Add(Diagnostic.Create(d, location, Array.Empty<object>()));
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00006F60 File Offset: 0x00005160
		public INamedTypeSymbol GetOrCreateTypeByMetadataName(string name)
		{
			INamedTypeSymbol type;
			if (this.Types.TryGetValue(name, out type))
			{
				return type;
			}
			type = this.Compilation.GetTypeByMetadataName(name);
			this.Types[name] = type;
			return type;
		}

		// Token: 0x0400000F RID: 15
		private CSharpCompilation Compilation;

		// Token: 0x04000012 RID: 18
		public List<SyntaxTree> AddedTrees = new List<SyntaxTree>();

		// Token: 0x04000013 RID: 19
		internal SemanticModel Model;

		// Token: 0x04000016 RID: 22
		internal static List<string> VisitedClasses = new List<string>();

		// Token: 0x04000017 RID: 23
		internal List<string> ClassAdditions = new List<string>();

		// Token: 0x04000018 RID: 24
		private List<string> ClassModifiers = new List<string>();

		// Token: 0x04000019 RID: 25
		internal List<Worker.ClassBlock> ClassBlocks = new List<Worker.ClassBlock>();

		// Token: 0x0400001A RID: 26
		public List<Diagnostic> Diagnostics = new List<Diagnostic>();

		// Token: 0x0400001B RID: 27
		internal Dictionary<string, INamedTypeSymbol> Types = new Dictionary<string, INamedTypeSymbol>();

		// Token: 0x0200002A RID: 42
		internal struct ClassBlock
		{
			// Token: 0x0400004E RID: 78
			public string Group;

			// Token: 0x0400004F RID: 79
			public string Text;

			// Token: 0x04000050 RID: 80
			public ITypeSymbol TypeSymbol;
		}
	}
}
