using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Sandbox.Generator;
using Sandbox.Internal;
using Sentry;

namespace Sandbox
{
	/// <summary>
	/// Given a folder of .cs files, this will produce (and load) an assembly
	/// </summary>
	// Token: 0x0200028F RID: 655
	[Hotload.SkipAttribute]
	internal class Compiler : IDisposable
	{
		// Token: 0x17000325 RID: 805
		// (get) Token: 0x0600107A RID: 4218 RVA: 0x0001E7A4 File Offset: 0x0001C9A4
		// (set) Token: 0x0600107B RID: 4219 RVA: 0x0001E7AC File Offset: 0x0001C9AC
		public Exception BuildException { get; private set; }

		/// <summary>
		/// If true, this addon will compile and load
		/// </summary>
		// Token: 0x17000326 RID: 806
		// (get) Token: 0x0600107C RID: 4220 RVA: 0x0001E7B5 File Offset: 0x0001C9B5
		// (set) Token: 0x0600107D RID: 4221 RVA: 0x0001E7BD File Offset: 0x0001C9BD
		public bool Active { get; private set; }

		/// <summary>
		/// Is this addon is still building?
		/// </summary>
		// Token: 0x17000327 RID: 807
		// (get) Token: 0x0600107E RID: 4222 RVA: 0x0001E7C6 File Offset: 0x0001C9C6
		// (set) Token: 0x0600107F RID: 4223 RVA: 0x0001E7CE File Offset: 0x0001C9CE
		public bool Building { get; internal set; }

		/// <summary>
		/// Name of this assembly. This isn't an assembly name - it should not contain ".dll" etc.
		/// </summary>
		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06001080 RID: 4224 RVA: 0x0001E7D7 File Offset: 0x0001C9D7
		public string Name { get; }

		/// <summary>
		/// Generated assembly. This should be NULL until build is called.
		/// If it's null after build is called then check out BuildResult for errors.
		/// </summary>
		// Token: 0x17000329 RID: 809
		// (get) Token: 0x06001081 RID: 4225 RVA: 0x0001E7DF File Offset: 0x0001C9DF
		// (set) Token: 0x06001082 RID: 4226 RVA: 0x0001E7E7 File Offset: 0x0001C9E7
		public string AssemblyName { get; private set; }

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06001083 RID: 4227 RVA: 0x0001E7F0 File Offset: 0x0001C9F0
		// (set) Token: 0x06001084 RID: 4228 RVA: 0x0001E7F8 File Offset: 0x0001C9F8
		public string DllName { get; private set; }

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x06001085 RID: 4229 RVA: 0x0001E801 File Offset: 0x0001CA01
		// (set) Token: 0x06001086 RID: 4230 RVA: 0x0001E809 File Offset: 0x0001CA09
		public string PdbName { get; private set; }

		/// <summary>
		/// A list of compilers that we depend upon
		/// </summary>
		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06001087 RID: 4231 RVA: 0x0001E812 File Offset: 0x0001CA12
		// (set) Token: 0x06001088 RID: 4232 RVA: 0x0001E81A File Offset: 0x0001CA1A
		public List<Compiler> Dependancies { get; set; } = new List<Compiler>();

		/// <summary>
		/// References needed for compile
		/// </summary>
		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06001089 RID: 4233 RVA: 0x0001E823 File Offset: 0x0001CA23
		// (set) Token: 0x0600108A RID: 4234 RVA: 0x0001E82B File Offset: 0x0001CA2B
		public List<string> References { get; set; } = new List<string> { "Sandbox.System", "Sandbox.Engine", "Sandbox.Game", "Sandbox.Event", "Sandbox.Reflection" };

		/// <summary>
		/// Global namespaces
		/// </summary>
		// Token: 0x1700032E RID: 814
		// (get) Token: 0x0600108B RID: 4235 RVA: 0x0001E834 File Offset: 0x0001CA34
		// (set) Token: 0x0600108C RID: 4236 RVA: 0x0001E83C File Offset: 0x0001CA3C
		public List<string> GlobalNamespaces { get; set; } = new List<string>();

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x0600108D RID: 4237 RVA: 0x0001E845 File Offset: 0x0001CA45
		// (set) Token: 0x0600108E RID: 4238 RVA: 0x0001E84D File Offset: 0x0001CA4D
		private Logger log { get; set; }

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x0600108F RID: 4239 RVA: 0x0001E856 File Offset: 0x0001CA56
		// (set) Token: 0x06001090 RID: 4240 RVA: 0x0001E85E File Offset: 0x0001CA5E
		internal BaseFileSystem filesystem { get; set; }

		// Token: 0x06001091 RID: 4241 RVA: 0x0001E868 File Offset: 0x0001CA68
		internal Compiler(string name, BaseFileSystem filesystem)
		{
			this.filesystem = filesystem;
			this.log = Logging.GetLogger("CMP/" + name);
			this.Name = name;
			this.parseOptions = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp10).WithPreprocessorSymbols(new string[] { "SANDBOX", "DEBUG", "TRACE" });
		}

		// Token: 0x06001092 RID: 4242 RVA: 0x0001E93C File Offset: 0x0001CB3C
		internal async Task BuildInternal()
		{
			this.BuildSuccess = false;
			List<PortableExecutableReference> list = await this.BuildReferences();
			List<PortableExecutableReference> refs = list;
			Stopwatch time = Stopwatch.StartNew();
			this.Cleanup();
			this.SyntaxTree.Clear();
			double timeSyntax = time.Elapsed.TotalSeconds;
			await this.GetSyntaxTree(this.SyntaxTree);
			timeSyntax = time.Elapsed.TotalSeconds - timeSyntax;
			EmbeddedText[] embeddedTexts = this.SyntaxTree.Select((SyntaxTree x) => EmbeddedText.FromSource(x.FilePath, x.GetText(default(CancellationToken)))).ToArray<EmbeddedText>();
			Dictionary<string, ReportDiagnostic> Diagnostics = new Dictionary<string, ReportDiagnostic>
			{
				{
					"CS1701",
					ReportDiagnostic.Suppress
				},
				{
					"CS8019",
					ReportDiagnostic.Suppress
				}
			};
			if (refs.Any((PortableExecutableReference x) => x == null))
			{
				throw new Exception("Missing references");
			}
			CSharpCompilationOptions optn = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, false, null, null, null, null, OptimizationLevel.Debug, false, false, null, null, default(ImmutableArray<byte>), null, Platform.AnyCpu, ReportDiagnostic.Default, 4, null, true, false, null, null, null, null, null, false, MetadataImportOptions.Public, NullableContextOptions.Disable).WithConcurrentBuild(true).WithOptimizationLevel(OptimizationLevel.Debug).WithGeneralDiagnosticOption(ReportDiagnostic.Info)
				.WithSpecificDiagnosticOptions(Diagnostics)
				.WithPlatform(Platform.AnyCpu)
				.WithAllowUnsafe(false);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Dynamic.");
			defaultInterpolatedStringHandler.AppendFormatted(this.Name);
			defaultInterpolatedStringHandler.AppendLiteral(".");
			defaultInterpolatedStringHandler.AppendFormatted<int>(Interlocked.Increment(ref Compiler.compileCounter));
			this.AssemblyName = defaultInterpolatedStringHandler.ToStringAndClear();
			CSharpCompilation compiler = CSharpCompilation.Create(this.AssemblyName, this.SyntaxTree, refs, optn);
			double timeGenerators = time.Elapsed.TotalSeconds;
			compiler = this.RunGenerators(compiler);
			timeGenerators = time.Elapsed.TotalSeconds - timeGenerators;
			this.DllName = this.AssemblyName + ".dll";
			this.PdbName = this.AssemblyName + ".pdb";
			using (MemoryStream peStream = new MemoryStream())
			{
				using (MemoryStream pdbStream = new MemoryStream())
				{
					this.BuildResult = compiler.Emit(peStream, pdbStream, null, null, null, new EmitOptions(false, (DebugInformationFormat)0, null, null, 0, 0UL, false, default(SubsystemVersion), null, false, true, default(ImmutableArray<InstrumentationKind>), null, null, null).WithDebugInformationFormat(DebugInformationFormat.PortablePdb), null, null, embeddedTexts, null, default(CancellationToken));
					this.AsmBinary = peStream.ToArray();
					this.SymBinary = pdbStream.ToArray();
				}
			}
			this.ReportCompileErrors(this.BuildResult.Diagnostics);
			if (!this.BuildResult.Success)
			{
				throw new Exception("Build failed");
			}
			using (MemoryStream a_stream = new MemoryStream(this.AsmBinary))
			{
				this.metaRef = MetadataReference.CreateFromStream(a_stream, default(MetadataReferenceProperties), null, null);
				if (this.metaRef == null)
				{
					throw new Exception("metaRef is null!");
				}
			}
			this.log.Info(FormattableStringFactory.Create("{0} compiled successfully in {1:0.00}s [st:{2:0.00}] [gen:{3:0.00}]", new object[]
			{
				this.Name,
				time.Elapsed.TotalSeconds,
				timeSyntax,
				timeGenerators
			}));
			this.BuildSuccess = true;
		}

		// Token: 0x06001093 RID: 4243 RVA: 0x0001E980 File Offset: 0x0001CB80
		private CSharpCompilation RunGenerators(CSharpCompilation compiler)
		{
			Processor processor = new Processor();
			processor.AddonName = this.Name;
			processor.Run(compiler);
			if (processor.Exception != null)
			{
				GlobalSystemNamespace.Log.Error(processor.Exception, "Error when generating code");
				SentrySdk.WithScope(delegate(Scope scope)
				{
					scope.SetTag("group", "generator");
					SentrySdk.CaptureException(processor.Exception);
				});
			}
			return processor.Compilation;
		}

		// Token: 0x06001094 RID: 4244 RVA: 0x0001EA00 File Offset: 0x0001CC00
		private void ReportCompileErrors(ImmutableArray<Diagnostic> diagnostics)
		{
			foreach (Diagnostic line in diagnostics)
			{
				switch (line.Severity)
				{
				case DiagnosticSeverity.Info:
					this.log.Info(line.ToString());
					break;
				case DiagnosticSeverity.Warning:
					this.log.Warning(line.ToString());
					break;
				case DiagnosticSeverity.Error:
				{
					this.log.Warning(line.ToString());
					string src = this.GetSourceExcerpt(line.Location, 2);
					this.log.Warning(src);
					break;
				}
				}
			}
		}

		// Token: 0x06001095 RID: 4245 RVA: 0x0001EA98 File Offset: 0x0001CC98
		private string GetSourceExcerpt(Location loc, int buffer = 2)
		{
			if (loc.SourceTree == null)
			{
				return string.Empty;
			}
			SyntaxTree sourceTree = this.SyntaxTree.FirstOrDefault((SyntaxTree x) => x.FilePath == loc.SourceTree.FilePath);
			FileLinePositionSpan span = loc.GetMappedLineSpan();
			if (sourceTree == null)
			{
				sourceTree = loc.SourceTree;
				span = loc.GetLineSpan();
			}
			StringBuilder sb = new StringBuilder();
			int startLine = span.StartLinePosition.Line;
			int endLine = span.EndLinePosition.Line;
			string[] src = sourceTree.ToString().Split('\n', StringSplitOptions.None);
			startLine -= buffer;
			if (startLine <= 0)
			{
				startLine = 0;
			}
			endLine += buffer;
			if (endLine >= src.Length)
			{
				endLine = src.Length - 1;
			}
			for (int i = startLine; i <= endLine; i++)
			{
				StringBuilder stringBuilder = sb;
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(2, 2, stringBuilder);
				appendInterpolatedStringHandler.AppendFormatted<int>(i + 1, "0000");
				appendInterpolatedStringHandler.AppendLiteral(": ");
				appendInterpolatedStringHandler.AppendFormatted(src[i]);
				stringBuilder2.AppendLine(ref appendInterpolatedStringHandler);
			}
			return sb.ToString().TrimEnd();
		}

		/// <summary>
		/// Build and load the assembly.
		/// </summary>
		// Token: 0x06001096 RID: 4246 RVA: 0x0001EBC0 File Offset: 0x0001CDC0
		public async Task<bool> Build()
		{
			this.BuildException = null;
			bool result;
			try
			{
				this.Building = true;
				await Task.Run(() => this.BuildInternal());
				result = true;
			}
			catch (Exception e)
			{
				this.BuildException = e;
				this.log.Warning(e.Message);
				result = false;
			}
			finally
			{
				this.Building = false;
			}
			return result;
		}

		/// <summary>
		/// Collect all of the code that should compiled into this assembly
		/// </summary>
		// Token: 0x06001097 RID: 4247 RVA: 0x0001EC04 File Offset: 0x0001CE04
		private async Task GetSyntaxTree(List<SyntaxTree> codeFiles)
		{
			foreach (string file in this.filesystem.FindFile("/", "*.cs", true))
			{
				if (!file.StartsWith("obj/"))
				{
					string code = await this.ReadTextForgivingAsync(file, 10, 5);
					if (code != null)
					{
						string physicalPath = this.filesystem.GetFullPath(file);
						SyntaxTree tree = CSharpSyntaxTree.ParseText(code, this.parseOptions, physicalPath, Encoding.UTF8, default(CancellationToken));
						codeFiles.Add(tree);
						file = null;
					}
				}
			}
			IEnumerator<string> enumerator = null;
			if (this.GlobalNamespaces.Count > 0)
			{
				string path = this.filesystem.GetFullPath("/") + "/.obj/__global_include.cs";
				string code2 = "// Generated\n";
				foreach (string str in this.GlobalNamespaces)
				{
					code2 = code2 + "global using " + str + ";\n";
				}
				codeFiles.Add(CSharpSyntaxTree.ParseText(code2, this.parseOptions, path, Encoding.UTF8, default(CancellationToken)));
			}
		}

		/// <summary>
		/// Read text from a file while dealing with the fact that it might be being saved right 
		/// when we're loading it so it's likely to throw IOExceptions.
		/// </summary>
		// Token: 0x06001098 RID: 4248 RVA: 0x0001EC50 File Offset: 0x0001CE50
		private async Task<string> ReadTextForgivingAsync(string file, int retryCount = 10, int millisecondsBetweenChanges = 5)
		{
			for (int i = 0; i < retryCount; i++)
			{
				try
				{
					return await this.filesystem.ReadAllTextAsync(file);
				}
				catch (IOException)
				{
					Thread.Sleep(millisecondsBetweenChanges);
				}
			}
			return null;
		}

		// Token: 0x06001099 RID: 4249 RVA: 0x0001ECAC File Offset: 0x0001CEAC
		internal async Task<List<PortableExecutableReference>> BuildReferences()
		{
			PortableExecutableReference[] addonRefs = await Task.WhenAll<PortableExecutableReference>(this.Dependancies.Select(new Func<Compiler, Task<PortableExecutableReference>>(this.FindMetadataReference)));
			return CompilerSetup.GetCommonReferences(this.References).Concat(addonRefs).ToList<PortableExecutableReference>();
		}

		/// <summary>
		/// Given a managed assembly name we'll searhc all of the assembly paths and return a MetadataReference. 
		/// If the dll doesn't exist we'll try to convert the .dll into a .ni.dll. Will report an error if still not found.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		// Token: 0x0600109A RID: 4250 RVA: 0x0001ECF0 File Offset: 0x0001CEF0
		internal async Task<PortableExecutableReference> FindMetadataReference(string name)
		{
			Compiler dependency = CompileManager.FindCompilerByName(name);
			if (dependency == null)
			{
				throw new Exception("Unknown Reference: " + name + ".dll");
			}
			while (dependency.Building)
			{
				await Task.Yield();
			}
			if (!dependency.BuildSuccess)
			{
				throw new Exception("Broken Reference: " + dependency.Name);
			}
			if (dependency.metaRef == null)
			{
				this.log.Error(FormattableStringFactory.Create("metaRef for {0} is null (which means that the compile order is wrong)", new object[] { dependency.Name }));
			}
			return dependency.metaRef;
		}

		// Token: 0x0600109B RID: 4251 RVA: 0x0001ED3C File Offset: 0x0001CF3C
		internal async Task<PortableExecutableReference> FindMetadataReference(Compiler dependency)
		{
			if (dependency == null)
			{
				throw new Exception("Missing Reference");
			}
			while (dependency.Building)
			{
				await Task.Yield();
			}
			if (!dependency.BuildSuccess)
			{
				throw new Exception("Broken Reference: " + dependency.Name);
			}
			if (dependency.metaRef == null)
			{
				this.log.Error(FormattableStringFactory.Create("metaRef for {0} is null (which means that the compile order is wrong)", new object[] { dependency.Name }));
			}
			return dependency.metaRef;
		}

		/// <summary>
		/// Unload this assembly. Attempt to remove all created classes and hooks.
		/// </summary>
		// Token: 0x0600109C RID: 4252 RVA: 0x0001ED87 File Offset: 0x0001CF87
		public void Unload()
		{
		}

		// Token: 0x0600109D RID: 4253 RVA: 0x0001ED89 File Offset: 0x0001CF89
		private void Cleanup()
		{
		}

		// Token: 0x0600109E RID: 4254 RVA: 0x0001ED8C File Offset: 0x0001CF8C
		~Compiler()
		{
			this.Cleanup();
			this.Dispose();
		}

		// Token: 0x0600109F RID: 4255 RVA: 0x0001EDC0 File Offset: 0x0001CFC0
		public void Dispose()
		{
			this.Unload();
			CompileManager.OnCompilerDisposed(this);
		}

		// Token: 0x060010A0 RID: 4256 RVA: 0x0001EDCE File Offset: 0x0001CFCE
		public void SetActive(bool b)
		{
			if (this.Active == b)
			{
				return;
			}
			this.Active = b;
			if (!this.Active)
			{
				this.Unload();
			}
		}

		// Token: 0x060010A1 RID: 4257 RVA: 0x0001EDF0 File Offset: 0x0001CFF0
		public int DependancyIndex()
		{
			if (this.Dependancies == null)
			{
				return 0;
			}
			if (this.Dependancies.Count<Compiler>() == 0)
			{
				return 0;
			}
			return this.Dependancies.Max((Compiler x) => x.DependancyIndex()) + 1;
		}

		// Token: 0x060010A2 RID: 4258 RVA: 0x0001EE44 File Offset: 0x0001D044
		public string[] GetErrors()
		{
			if (this.BuildSuccess)
			{
				return Array.Empty<string>();
			}
			if (this.BuildResult == null)
			{
				return Array.Empty<string>();
			}
			return this.BuildResult.Diagnostics.Where((Diagnostic x) => x.Severity == DiagnosticSeverity.Error).Select(delegate(Diagnostic x)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 2);
				defaultInterpolatedStringHandler.AppendFormatted<Diagnostic>(x);
				defaultInterpolatedStringHandler.AppendLiteral("\n\n");
				defaultInterpolatedStringHandler.AppendFormatted(this.GetSourceExcerpt(x.Location, 2));
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}).ToArray<string>();
		}

		// Token: 0x04001283 RID: 4739
		private PortableExecutableReference metaRef;

		// Token: 0x04001284 RID: 4740
		private CSharpParseOptions parseOptions;

		/// <summary>
		/// Results for the assembly build. This can contain warnings or errors.
		/// </summary>
		// Token: 0x04001285 RID: 4741
		public EmitResult BuildResult;

		// Token: 0x04001286 RID: 4742
		public bool BuildSuccess;

		// Token: 0x04001287 RID: 4743
		private List<SyntaxTree> SyntaxTree = new List<SyntaxTree>();

		// Token: 0x04001288 RID: 4744
		public static Func<CSharpCompilation, Dictionary<string, string>, CSharpCompilation> PreBuild;

		// Token: 0x04001289 RID: 4745
		private static int compileCounter = 100;

		// Token: 0x0400128A RID: 4746
		internal byte[] AsmBinary;

		// Token: 0x0400128B RID: 4747
		internal byte[] SymBinary;
	}
}
