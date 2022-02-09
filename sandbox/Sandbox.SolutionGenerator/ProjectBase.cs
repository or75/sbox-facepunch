using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Sandbox.SolutionGenerator
{
	/// <summary>
	/// Base class for this transformation
	/// </summary>
	// Token: 0x02000006 RID: 6
	[GeneratedCode("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
	internal class ProjectBase
	{
		/// <summary>
		/// The string builder that generation-time code is using to assemble generated output
		/// </summary>
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002C20 File Offset: 0x00000E20
		// (set) Token: 0x06000026 RID: 38 RVA: 0x00002C3B File Offset: 0x00000E3B
		protected StringBuilder GenerationEnvironment
		{
			get
			{
				if (this.generationEnvironmentField == null)
				{
					this.generationEnvironmentField = new StringBuilder();
				}
				return this.generationEnvironmentField;
			}
			set
			{
				this.generationEnvironmentField = value;
			}
		}

		/// <summary>
		/// The error collection for the generation process
		/// </summary>
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00002C44 File Offset: 0x00000E44
		public CompilerErrorCollection Errors
		{
			get
			{
				if (this.errorsField == null)
				{
					this.errorsField = new CompilerErrorCollection();
				}
				return this.errorsField;
			}
		}

		/// <summary>
		/// A list of the lengths of each indent that was added with PushIndent
		/// </summary>
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002C5F File Offset: 0x00000E5F
		private List<int> indentLengths
		{
			get
			{
				if (this.indentLengthsField == null)
				{
					this.indentLengthsField = new List<int>();
				}
				return this.indentLengthsField;
			}
		}

		/// <summary>
		/// Gets the current indent we use when adding lines to the output
		/// </summary>
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002C7A File Offset: 0x00000E7A
		public string CurrentIndent
		{
			get
			{
				return this.currentIndentField;
			}
		}

		/// <summary>
		/// Current transformation session
		/// </summary>
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002C82 File Offset: 0x00000E82
		// (set) Token: 0x0600002B RID: 43 RVA: 0x00002C8A File Offset: 0x00000E8A
		public virtual IDictionary<string, object> Session
		{
			get
			{
				return this.sessionField;
			}
			set
			{
				this.sessionField = value;
			}
		}

		/// <summary>
		/// Write text directly into the generated output
		/// </summary>
		// Token: 0x0600002C RID: 44 RVA: 0x00002C94 File Offset: 0x00000E94
		public void Write(string textToAppend)
		{
			if (string.IsNullOrEmpty(textToAppend))
			{
				return;
			}
			if (this.GenerationEnvironment.Length == 0 || this.endsWithNewline)
			{
				this.GenerationEnvironment.Append(this.currentIndentField);
				this.endsWithNewline = false;
			}
			if (textToAppend.EndsWith(Environment.NewLine, StringComparison.CurrentCulture))
			{
				this.endsWithNewline = true;
			}
			if (this.currentIndentField.Length == 0)
			{
				this.GenerationEnvironment.Append(textToAppend);
				return;
			}
			textToAppend = textToAppend.Replace(Environment.NewLine, Environment.NewLine + this.currentIndentField);
			if (this.endsWithNewline)
			{
				this.GenerationEnvironment.Append(textToAppend, 0, textToAppend.Length - this.currentIndentField.Length);
				return;
			}
			this.GenerationEnvironment.Append(textToAppend);
		}

		/// <summary>
		/// Write text directly into the generated output
		/// </summary>
		// Token: 0x0600002D RID: 45 RVA: 0x00002D5B File Offset: 0x00000F5B
		public void WriteLine(string textToAppend)
		{
			this.Write(textToAppend);
			this.GenerationEnvironment.AppendLine();
			this.endsWithNewline = true;
		}

		/// <summary>
		/// Write formatted text directly into the generated output
		/// </summary>
		// Token: 0x0600002E RID: 46 RVA: 0x00002D77 File Offset: 0x00000F77
		public void Write(string format, params object[] args)
		{
			this.Write(string.Format(CultureInfo.CurrentCulture, format, args));
		}

		/// <summary>
		/// Write formatted text directly into the generated output
		/// </summary>
		// Token: 0x0600002F RID: 47 RVA: 0x00002D8B File Offset: 0x00000F8B
		public void WriteLine(string format, params object[] args)
		{
			this.WriteLine(string.Format(CultureInfo.CurrentCulture, format, args));
		}

		/// <summary>
		/// Raise an error
		/// </summary>
		// Token: 0x06000030 RID: 48 RVA: 0x00002DA0 File Offset: 0x00000FA0
		public void Error(string message)
		{
			CompilerError compilerError = new CompilerError();
			compilerError.ErrorText = message;
			this.Errors.Add(compilerError);
		}

		/// <summary>
		/// Raise a warning
		/// </summary>
		// Token: 0x06000031 RID: 49 RVA: 0x00002DC8 File Offset: 0x00000FC8
		public void Warning(string message)
		{
			CompilerError compilerError = new CompilerError();
			compilerError.ErrorText = message;
			compilerError.IsWarning = true;
			this.Errors.Add(compilerError);
		}

		/// <summary>
		/// Increase the indent
		/// </summary>
		// Token: 0x06000032 RID: 50 RVA: 0x00002DF6 File Offset: 0x00000FF6
		public void PushIndent(string indent)
		{
			if (indent == null)
			{
				throw new ArgumentNullException("indent");
			}
			this.currentIndentField += indent;
			this.indentLengths.Add(indent.Length);
		}

		/// <summary>
		/// Remove the last indent that was added with PushIndent
		/// </summary>
		// Token: 0x06000033 RID: 51 RVA: 0x00002E2C File Offset: 0x0000102C
		public string PopIndent()
		{
			string result = "";
			if (this.indentLengths.Count > 0)
			{
				int num = this.indentLengths[this.indentLengths.Count - 1];
				this.indentLengths.RemoveAt(this.indentLengths.Count - 1);
				if (num > 0)
				{
					result = this.currentIndentField.Substring(this.currentIndentField.Length - num);
					this.currentIndentField = this.currentIndentField.Remove(this.currentIndentField.Length - num);
				}
			}
			return result;
		}

		/// <summary>
		/// Remove any indentation
		/// </summary>
		// Token: 0x06000034 RID: 52 RVA: 0x00002EBA File Offset: 0x000010BA
		public void ClearIndent()
		{
			this.indentLengths.Clear();
			this.currentIndentField = "";
		}

		/// <summary>
		/// Helper to produce culture-oriented representation of an object as a string
		/// </summary>
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00002ED2 File Offset: 0x000010D2
		public ProjectBase.ToStringInstanceHelper ToStringHelper
		{
			get
			{
				return this.toStringHelperField;
			}
		}

		// Token: 0x04000014 RID: 20
		private StringBuilder generationEnvironmentField;

		// Token: 0x04000015 RID: 21
		private CompilerErrorCollection errorsField;

		// Token: 0x04000016 RID: 22
		private List<int> indentLengthsField;

		// Token: 0x04000017 RID: 23
		private string currentIndentField = "";

		// Token: 0x04000018 RID: 24
		private bool endsWithNewline;

		// Token: 0x04000019 RID: 25
		private IDictionary<string, object> sessionField;

		// Token: 0x0400001A RID: 26
		private ProjectBase.ToStringInstanceHelper toStringHelperField = new ProjectBase.ToStringInstanceHelper();

		/// <summary>
		/// Utility class to produce culture-oriented representation of an object as a string.
		/// </summary>
		// Token: 0x0200000C RID: 12
		public class ToStringInstanceHelper
		{
			/// <summary>
			/// Gets or sets format provider to be used by ToStringWithCulture method.
			/// </summary>
			// Token: 0x1700001C RID: 28
			// (get) Token: 0x0600005F RID: 95 RVA: 0x000034F7 File Offset: 0x000016F7
			// (set) Token: 0x06000060 RID: 96 RVA: 0x000034FF File Offset: 0x000016FF
			public IFormatProvider FormatProvider
			{
				get
				{
					return this.formatProviderField;
				}
				set
				{
					if (value != null)
					{
						this.formatProviderField = value;
					}
				}
			}

			/// <summary>
			/// This is called from the compile/run appdomain to convert objects within an expression block to a string
			/// </summary>
			// Token: 0x06000061 RID: 97 RVA: 0x0000350C File Offset: 0x0000170C
			public string ToStringWithCulture(object objectToConvert)
			{
				if (objectToConvert == null)
				{
					throw new ArgumentNullException("objectToConvert");
				}
				MethodInfo method = objectToConvert.GetType().GetMethod("ToString", new Type[] { typeof(IFormatProvider) });
				if (method == null)
				{
					return objectToConvert.ToString();
				}
				return (string)method.Invoke(objectToConvert, new object[] { this.formatProviderField });
			}

			// Token: 0x04000034 RID: 52
			private IFormatProvider formatProviderField = CultureInfo.InvariantCulture;
		}
	}
}
