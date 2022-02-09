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
	// Token: 0x02000012 RID: 18
	internal class Rpc
	{
		// Token: 0x06000054 RID: 84 RVA: 0x00005590 File Offset: 0x00003790
		internal static void VisitMethod(ref MethodDeclarationSyntax node, IMethodSymbol symbol, Worker master)
		{
			AttributeSyntax attribute = node.GetAttribute("ClientRpc");
			if (attribute == null)
			{
				return;
			}
			string Static = (symbol.IsStatic ? "static " : "");
			attribute.GetArgumentValue(0, "Name", node.Identifier.ToString());
			attribute.GetArgumentValue(-1, "CanBeCalledFromServer", "false");
			int hash = string.Format("{0}{1}.{2}", symbol.ContainingType.ContainingNamespace, symbol.ContainingType.Name, symbol).FastHash();
			Rpc.AddSendToSpecificClient(symbol, master, Static);
			Rpc.WriteProxy(symbol, master, Static, hash);
			string arguments = string.Join(", ", symbol.Parameters.Select((IParameterSymbol x) => x.Name)).Trim(new char[] { ',', ' ' });
			StatementSyntax statement = SyntaxFactory.ParseStatement(string.Format("if ( !{0}__RpcProxy( {1} ) ) return;", node.Identifier, arguments), 0, null, true);
			node = node.WithBody(node.Body.WithStatements(node.Body.Statements.Insert(0, statement)));
			CodeWriter reader = new CodeWriter();
			reader.StartBlock(string.Format("case {0}:", hash));
			reader.WriteLines(Rpc.CreateReader(symbol));
			if (symbol.IsStatic)
			{
				reader.WriteLine("return true;");
			}
			else
			{
				reader.WriteLine("return;");
			}
			reader.EndBlock("");
			if (symbol.IsStatic)
			{
				master.AddClassBlock("rpc_read_static", reader.ToString(), symbol.ContainingType);
				return;
			}
			master.AddClassBlock("rpc_read", reader.ToString(), symbol.ContainingType);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00005754 File Offset: 0x00003954
		private static string CreateReader(IMethodSymbol rpc)
		{
			CodeWriter code = new CodeWriter();
			code.WriteLine("");
			code.WriteLine("");
			foreach (IParameterSymbol symbol in rpc.Parameters)
			{
				code.WriteLine(symbol.Type.ToDisplayString(null) + " __" + symbol.Name + " = default;");
				if (symbol.Type.TypeKind == TypeKind.Array)
				{
					if (Rpc.IsUnmanagedArray(symbol))
					{
						code.WriteLine(string.Concat(new string[] { "__", symbol.Name, " = read.ReadUnmanagedArray( __", symbol.Name, " );" }));
					}
					else
					{
						ITypeSymbol elementType = (symbol.Type as IArrayTypeSymbol).ElementType;
						if (elementType.IsValueType)
						{
							code.WriteLine(string.Format("__{0} = read.ReadArray<{1}>( __{2} );", symbol.Name, elementType, symbol.Name));
						}
						else
						{
							code.WriteLine(string.Format("__{0} = read.ReadArrayClass<{1}>( __{2} );", symbol.Name, elementType, symbol.Name));
						}
					}
				}
				else if (symbol.Type.IsValueType)
				{
					code.WriteLine(string.Concat(new string[] { "__", symbol.Name, " = read.ReadData( __", symbol.Name, " );" }));
				}
				else
				{
					code.WriteLine(string.Concat(new string[] { "__", symbol.Name, " = read.ReadClass( __", symbol.Name, " );" }));
				}
				code.WriteLine("");
			}
			IEnumerable<string> prams = rpc.Parameters.Select((IParameterSymbol x) => "__" + x.Name);
			string paramString = string.Join(", ", prams);
			code.WriteLine("// Call Actual Function");
			code.StartBlock(string.Concat(new string[]
			{
				"if ( !Prediction.WasPredicted( \"",
				rpc.Name,
				"\"",
				(paramString.Length > 0) ? ", " : "",
				" ",
				paramString,
				" ) )"
			}));
			if (rpc.IsStatic)
			{
				code.WriteLine(string.Concat(new string[]
				{
					rpc.ContainingType.ContainingNamespace.PrintableWithPeriod(),
					rpc.ContainingType.Name,
					".",
					rpc.Name,
					"( ",
					paramString,
					" );"
				}));
			}
			else
			{
				code.WriteLine(rpc.Name + "( " + string.Join(", ", prams) + " );");
			}
			code.EndBlock("");
			return code.ToString();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00005A58 File Offset: 0x00003C58
		private static void WriteProxy(IMethodSymbol symbol, Worker master, string Static, int hash)
		{
			if (symbol.IsOverride)
			{
				return;
			}
			List<string> argList = symbol.Parameters.Select((IParameterSymbol x) => x.ToMinimalDisplayString(master.Model, 0, null)).ToList<string>();
			argList.Add("To? toTarget = null");
			string visibility = (string.IsNullOrEmpty(Static) ? "protected" : "private");
			CodeWriter code = new CodeWriter();
			code.WriteLine("// ");
			code.WriteLine("// This is called automatically when calling " + symbol.Name + " from anywhere.");
			code.WriteLine("// If we return true the rest of the function will be called.");
			code.WriteLine("// ");
			code.StartBlock(string.Concat(new string[]
			{
				Static,
				" ",
				visibility,
				" bool ",
				symbol.Name,
				"__RpcProxy( ",
				string.Join(",", argList),
				" )"
			}));
			code.WriteLine("// don't call RPCs at all during prediction recalc");
			code.WriteLine("if ( !Prediction.FirstTime ) return false;");
			code.StartBlock("if ( !Sandbox.Host.IsServer )");
			string argNames = string.Join(", ", symbol.Parameters.Select((IParameterSymbol x) => x.Name));
			if (!string.IsNullOrWhiteSpace(argNames))
			{
				argNames = ", " + argNames;
			}
			code.WriteLine(string.Concat(new string[] { "Prediction.Watch( \"", symbol.Name, "\"", argNames, " );" }));
			code.WriteLine("return true;");
			code.EndBlock("");
			code.WriteLine("");
			code.StartBlock(string.Format("using (var writer = Sandbox.NetWrite.StartRpc( {0}, {1} ))", hash, symbol.IsStatic ? "null" : "this"));
			code.WriteLine("");
			foreach (IParameterSymbol parameter in symbol.Parameters)
			{
				code.StartBlock("if ( !Sandbox.NetRead.IsSupported( " + parameter.Name + " ) )");
				code.WriteLine(string.Concat(new string[]
				{
					"Log.Error( \"[ClientRpc] ",
					symbol.Name,
					" is not allowed to use ",
					parameter.Type.Name,
					" for the parameter '",
					parameter.Name,
					"'!\" );"
				}));
				code.WriteLine("return false;");
				code.EndBlock("");
				code.WriteLine("");
				if (Rpc.IsUnmanagedArray(parameter))
				{
					code.WriteLine(string.Format("writer.WriteUnmanagedArray( {0} ); // Param: {1} - {2}\n", parameter.Name, parameter.Name, parameter.Type));
				}
				else
				{
					code.WriteLine(string.Format("writer.Write( {0} ); // Param: {1} - {2}\n", parameter.Name, parameter.Name, parameter.Type));
				}
			}
			code.WriteLine("writer.SendRpc( toTarget" + (symbol.IsStatic ? ", null" : ", this") + " ); ");
			code.EndBlock("");
			code.WriteLine("");
			code.WriteLine("return false;");
			code.EndBlock("");
			master.AddToCurrentClass(code.ToString(), false);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00005DBC File Offset: 0x00003FBC
		private static bool IsUnmanagedArray(IParameterSymbol symbol)
		{
			return symbol.Type.TypeKind == TypeKind.Array && (symbol.Type as IArrayTypeSymbol).ElementType.IsValueType;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00005DE8 File Offset: 0x00003FE8
		private static void AddSendToSpecificClient(IMethodSymbol symbol, Worker master, string Static)
		{
			List<string> argList = symbol.Parameters.Select((IParameterSymbol x) => x.ToMinimalDisplayString(master.Model, 0, null)).ToList<string>();
			argList.Insert(0, "To toTarget");
			CodeWriter code = new CodeWriter();
			code.StartBlock(string.Concat(new string[]
			{
				Static,
				" public ",
				symbol.IsVirtual ? "virtual" : "",
				" ",
				symbol.IsOverride ? "override" : "",
				" void ",
				symbol.Name,
				"( ",
				string.Join(", ", argList),
				" )"
			}));
			if (master.IsFullGeneration)
			{
				List<string> paramList = symbol.Parameters.Select((IParameterSymbol x) => x.Name).ToList<string>();
				paramList.Add("toTarget");
				code.WriteLine(symbol.Name + "__RpcProxy( " + string.Join(", ", paramList) + " );");
			}
			code.EndBlock("");
			master.AddToCurrentClass(code.ToString(), true);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00005F40 File Offset: 0x00004140
		internal static void BuildReadBlock(List<SyntaxTree> trees, IEnumerable<IGrouping<ITypeSymbol, Worker.ClassBlock>> blocks)
		{
			CodeWriter code = new CodeWriter();
			code.WriteLine("using Sandbox;");
			code.WriteLine("using System.Collections.Generic;");
			foreach (IGrouping<ITypeSymbol, Worker.ClassBlock> classGroup in blocks)
			{
				code.StartClass(classGroup.Key);
				code.StartBlock("protected override void OnCallRemoteProcedure( int id, NetRead read )");
				code.StartBlock("switch( id )");
				foreach (Worker.ClassBlock block in classGroup)
				{
					code.WriteLine(block.Text);
				}
				code.EndBlock("");
				code.WriteLine("");
				code.WriteLine("\tbase.OnCallRemoteProcedure( id, read );");
				code.EndBlock("");
				code.WriteLine("");
				code.EndClass(classGroup.Key);
			}
			SyntaxTree st = SyntaxFactory.ParseSyntaxTree(code.ToString(), null, "rpc_read", Encoding.UTF8, default(CancellationToken));
			trees.Add(st);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00006074 File Offset: 0x00004274
		internal static void BuildStaticReadBlock(List<SyntaxTree> trees, IEnumerable<IGrouping<ITypeSymbol, Worker.ClassBlock>> blocks)
		{
			CodeWriter code = new CodeWriter();
			code.WriteLine("using Sandbox;");
			code.WriteLine("using System.Collections.Generic;");
			code.StartBlock("public static class GlobalRpcHandler");
			code.StartBlock("public static bool OnRpc( int id, NetRead read )");
			code.StartBlock("switch( id )");
			foreach (IGrouping<ITypeSymbol, Worker.ClassBlock> grouping in blocks)
			{
				foreach (Worker.ClassBlock block in grouping)
				{
					code.WriteLine(block.Text);
				}
			}
			code.EndBlock("");
			code.WriteLine("return false;");
			code.EndBlock("");
			code.EndBlock("");
			SyntaxTree st = SyntaxFactory.ParseSyntaxTree(code.ToString(), null, "rpc_read_static", Encoding.UTF8, default(CancellationToken));
			trees.Add(st);
		}
	}
}
