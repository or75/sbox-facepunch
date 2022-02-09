using System;
using System.Text;

namespace Sandbox.Utility
{
	// Token: 0x02000068 RID: 104
	internal class CodeWriter
	{
		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x0002115E File Offset: 0x0001F35E
		// (set) Token: 0x06000492 RID: 1170 RVA: 0x00021166 File Offset: 0x0001F366
		public int Indent { get; set; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000493 RID: 1171 RVA: 0x0002116F File Offset: 0x0001F36F
		// (set) Token: 0x06000494 RID: 1172 RVA: 0x00021177 File Offset: 0x0001F377
		public StringBuilder sb { get; protected set; } = new StringBuilder();

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x00021180 File Offset: 0x0001F380
		public bool Empty
		{
			get
			{
				return this.sb.Length == 0;
			}
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x00021190 File Offset: 0x0001F390
		public void Write(string line, bool indent = false)
		{
			if (indent)
			{
				this.sb.Append(new string('\t', this.Indent));
			}
			this.sb.Append(line);
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x000211BB File Offset: 0x0001F3BB
		public void WriteLine(string line = "")
		{
			this.sb.Append(new string('\t', this.Indent));
			this.sb.AppendLine(line);
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x000211E4 File Offset: 0x0001F3E4
		public void WriteLines(string text)
		{
			foreach (string line in text.Split('\n', StringSplitOptions.None))
			{
				this.WriteLine(line.TrimEnd());
			}
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x0002121C File Offset: 0x0001F41C
		public void StartBlock(string line)
		{
			this.WriteLine(line);
			this.WriteLine("{");
			int indent = this.Indent;
			this.Indent = indent + 1;
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0002124C File Offset: 0x0001F44C
		public void EndBlock(string line = "")
		{
			int indent = this.Indent;
			this.Indent = indent - 1;
			this.WriteLine("}" + line);
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x0002127A File Offset: 0x0001F47A
		public override string ToString()
		{
			return this.sb.ToString();
		}
	}
}
