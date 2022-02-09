using System;
using System.Text;
using Microsoft.CodeAnalysis;

namespace Sandbox.Utility
{
	// Token: 0x02000004 RID: 4
	internal class CodeWriter
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600001D RID: 29 RVA: 0x00002BB3 File Offset: 0x00000DB3
		// (set) Token: 0x0600001E RID: 30 RVA: 0x00002BBB File Offset: 0x00000DBB
		public int Indent { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00002BC4 File Offset: 0x00000DC4
		// (set) Token: 0x06000020 RID: 32 RVA: 0x00002BCC File Offset: 0x00000DCC
		public StringBuilder sb { get; protected set; } = new StringBuilder();

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002BD5 File Offset: 0x00000DD5
		public bool Empty
		{
			get
			{
				return this.sb.Length == 0;
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002BE5 File Offset: 0x00000DE5
		public void Write(string line, bool indent = false)
		{
			if (indent)
			{
				this.sb.Append(new string('\t', this.Indent));
			}
			this.sb.Append(line);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002C10 File Offset: 0x00000E10
		public void WriteLine(string line = "")
		{
			this.sb.Append(new string('\t', this.Indent));
			this.sb.AppendLine(line);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002C38 File Offset: 0x00000E38
		public void WriteLines(string text)
		{
			foreach (string line in text.Split(new char[] { '\n' }))
			{
				this.WriteLine(line.TrimEnd(Array.Empty<char>()));
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002C7C File Offset: 0x00000E7C
		public void StartBlock(string line)
		{
			this.WriteLine(line);
			this.WriteLine("{");
			int indent = this.Indent;
			this.Indent = indent + 1;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002CAC File Offset: 0x00000EAC
		public void EndBlock(string line = "")
		{
			int indent = this.Indent;
			this.Indent = indent - 1;
			this.WriteLine("}" + line);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002CDA File Offset: 0x00000EDA
		public override string ToString()
		{
			return this.sb.ToString();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002CE8 File Offset: 0x00000EE8
		internal void StartClass(ITypeSymbol key)
		{
			if (key.ContainingType != null)
			{
				this.StartClass(key.ContainingType);
			}
			else if (!key.ContainingNamespace.IsGlobalNamespace)
			{
				this.StartBlock(string.Format("namespace {0}", key.ContainingNamespace));
			}
			this.StartBlock((key.IsStatic ? "static " : "") + "partial class " + key.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat));
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002D5D File Offset: 0x00000F5D
		internal void EndClass(ITypeSymbol key)
		{
			this.EndBlock("");
			if (key.ContainingType != null)
			{
				this.EndClass(key.ContainingType);
				return;
			}
			if (!key.ContainingNamespace.IsGlobalNamespace)
			{
				this.EndBlock("");
			}
		}
	}
}
