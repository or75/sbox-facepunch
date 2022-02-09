using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

namespace Sandbox.Generator
{
	// Token: 0x02000006 RID: 6
	public class Processor
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00002DE0 File Offset: 0x00000FE0
		// (set) Token: 0x0600002D RID: 45 RVA: 0x00002DE8 File Offset: 0x00000FE8
		public string AddonName { get; set; } = "AddonName";

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002DF1 File Offset: 0x00000FF1
		// (set) Token: 0x0600002F RID: 47 RVA: 0x00002DF9 File Offset: 0x00000FF9
		public CSharpCompilation Compilation { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002E02 File Offset: 0x00001002
		// (set) Token: 0x06000031 RID: 49 RVA: 0x00002E0A File Offset: 0x0000100A
		public Exception Exception { get; internal set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00002E13 File Offset: 0x00001013
		// (set) Token: 0x06000033 RID: 51 RVA: 0x00002E1B File Offset: 0x0000101B
		public GeneratorExecutionContext? Context { get; set; }

		// Token: 0x06000034 RID: 52 RVA: 0x00002E24 File Offset: 0x00001024
		public void Run(CSharpCompilation c)
		{
			this.Compilation = c;
			if (this.Compilation.SyntaxTrees.Count<SyntaxTree>() == 0)
			{
				return;
			}
			string[] folders = (from x in this.Compilation.SyntaxTrees
				select x.FilePath into x
				select Path.GetDirectoryName(x)).ToArray<string>();
			if (folders.Length == 0)
			{
				return;
			}
			string codePath = folders.OrderBy((string x) => x.Length).First<string>();
			DirectoryInfo addonPath = Directory.GetParent(codePath);
			this.AddonName = addonPath.Name;
			try
			{
				Task<Worker>[] tasks = this.Compilation.SyntaxTrees.Select((SyntaxTree x) => Worker.Process(this.Compilation, x, addonPath.FullName, this.Context == null)).ToArray<Task<Worker>>();
				Task[] tasks2 = tasks;
				Task.WaitAll(tasks2);
				foreach (Task<Worker> task in tasks)
				{
					if (task.Exception != null)
					{
						throw task.Exception;
					}
					Worker worker = task.Result;
					GeneratorExecutionContext? context = this.Context;
					if (context == null)
					{
						this.Compilation = this.Compilation.ReplaceSyntaxTree(worker.TreeInput, CSharpSyntaxTree.Create(worker.OutputNode, worker.TreeInput.Options as CSharpParseOptions, worker.TreeInput.FilePath, worker.TreeInput.Encoding));
					}
					else
					{
						foreach (Diagnostic diag in worker.Diagnostics)
						{
							context = this.Context;
							context.Value.ReportDiagnostic(diag);
						}
					}
				}
				List<SyntaxTree> trees = tasks.SelectMany((Task<Worker> x) => x.Result.AddedTrees).ToList<SyntaxTree>();
				foreach (IGrouping<string, Worker.ClassBlock> blockGroup in from x in tasks.SelectMany((Task<Worker> x) => x.Result.ClassBlocks)
					group x by x.Group)
				{
					string key = blockGroup.Key;
					if (!(key == "build_network_table"))
					{
						if (!(key == "rpc_read"))
						{
							if (!(key == "rpc_read_static"))
							{
								if (key == "hammer_output")
								{
									HammerOutput.BuildStaticBlock(trees, from x in blockGroup
										group x by x.TypeSymbol);
								}
							}
							else
							{
								Rpc.BuildStaticReadBlock(trees, from x in blockGroup
									group x by x.TypeSymbol);
							}
						}
						else
						{
							Rpc.BuildReadBlock(trees, from x in blockGroup
								group x by x.TypeSymbol);
						}
					}
					else
					{
						Replicate.BuildNetworkTableBlock(trees, from x in blockGroup
							group x by x.TypeSymbol);
					}
				}
				if (trees.Count<SyntaxTree>() > 0)
				{
					GeneratorExecutionContext? context = this.Context;
					if (context == null)
					{
						this.Compilation = this.Compilation.AddSyntaxTrees(trees.ToArray());
					}
					foreach (SyntaxTree tree in trees)
					{
						context = this.Context;
						if (context != null)
						{
							context.GetValueOrDefault().AddSource(tree.FilePath, SourceText.From(tree.ToString(), Encoding.UTF8, SourceHashAlgorithm.Sha1));
						}
					}
				}
			}
			catch (Exception e)
			{
				this.Exception = e;
				DiagnosticDescriptor desc = new DiagnosticDescriptor("SB5000", "Generator Crash", "Code Generator Crashed " + this.Exception.StackTrace.Trim(new char[] { '\n', '\r', ' ', '\t' }).Replace("\n", "").Replace("\r", "") + " - " + e.Message, "generator", DiagnosticSeverity.Error, true, null, null, Array.Empty<string>());
				GeneratorExecutionContext? context = this.Context;
				if (context != null)
				{
					context.GetValueOrDefault().ReportDiagnostic(Diagnostic.Create(desc, null, Array.Empty<object>()));
				}
			}
		}
	}
}
