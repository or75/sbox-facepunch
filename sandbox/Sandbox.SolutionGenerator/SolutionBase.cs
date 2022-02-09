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
	// Token: 0x02000008 RID: 8
	[GeneratedCode("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
	internal class SolutionBase
	{
		/// <summary>
		/// The string builder that generation-time code is using to assemble generated output
		/// </summary>
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002F89 File Offset: 0x00001189
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00002FA4 File Offset: 0x000011A4
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
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002FAD File Offset: 0x000011AD
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
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002FC8 File Offset: 0x000011C8
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
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002FE3 File Offset: 0x000011E3
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
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00002FEB File Offset: 0x000011EB
		// (set) Token: 0x0600003F RID: 63 RVA: 0x00002FF3 File Offset: 0x000011F3
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
		// Token: 0x06000040 RID: 64 RVA: 0x00002FFC File Offset: 0x000011FC
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
		// Token: 0x06000041 RID: 65 RVA: 0x000030C3 File Offset: 0x000012C3
		public void WriteLine(string textToAppend)
		{
			this.Write(textToAppend);
			this.GenerationEnvironment.AppendLine();
			this.endsWithNewline = true;
		}

		/// <summary>
		/// Write formatted text directly into the generated output
		/// </summary>
		// Token: 0x06000042 RID: 66 RVA: 0x000030DF File Offset: 0x000012DF
		public void Write(string format, params object[] args)
		{
			this.Write(string.Format(CultureInfo.CurrentCulture, format, args));
		}

		/// <summary>
		/// Write formatted text directly into the generated output
		/// </summary>
		// Token: 0x06000043 RID: 67 RVA: 0x000030F3 File Offset: 0x000012F3
		public void WriteLine(string format, params object[] args)
		{
			this.WriteLine(string.Format(CultureInfo.CurrentCulture, format, args));
		}

		/// <summary>
		/// Raise an error
		/// </summary>
		// Token: 0x06000044 RID: 68 RVA: 0x00003108 File Offset: 0x00001308
		public void Error(string message)
		{
			CompilerError compilerError = new CompilerError();
			compilerError.ErrorText = message;
			this.Errors.Add(compilerError);
		}

		/// <summary>
		/// Raise a warning
		/// </summary>
		// Token: 0x06000045 RID: 69 RVA: 0x00003130 File Offset: 0x00001330
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
		// Token: 0x06000046 RID: 70 RVA: 0x0000315E File Offset: 0x0000135E
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
		// Token: 0x06000047 RID: 71 RVA: 0x00003194 File Offset: 0x00001394
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
		// Token: 0x06000048 RID: 72 RVA: 0x00003222 File Offset: 0x00001422
		public void ClearIndent()
		{
			this.indentLengths.Clear();
			this.currentIndentField = "";
		}

		/// <summary>
		/// Helper to produce culture-oriented representation of an object as a string
		/// </summary>
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000049 RID: 73 RVA: 0x0000323A File Offset: 0x0000143A
		public SolutionBase.ToStringInstanceHelper ToStringHelper
		{
			get
			{
				return this.toStringHelperField;
			}
		}

		// Token: 0x0400001E RID: 30
		private StringBuilder generationEnvironmentField;

		// Token: 0x0400001F RID: 31
		private CompilerErrorCollection errorsField;

		// Token: 0x04000020 RID: 32
		private List<int> indentLengthsField;

		// Token: 0x04000021 RID: 33
		private string currentIndentField = "";

		// Token: 0x04000022 RID: 34
		private bool endsWithNewline;

		// Token: 0x04000023 RID: 35
		private IDictionary<string, object> sessionField;

		// Token: 0x04000024 RID: 36
		private SolutionBase.ToStringInstanceHelper toStringHelperField = new SolutionBase.ToStringInstanceHelper();

		/// <summary>
		/// Utility class to produce culture-oriented representation of an object as a string.
		/// </summary>
		// Token: 0x0200000D RID: 13
		public class ToStringInstanceHelper
		{
			/// <summary>
			/// Gets or sets format provider to be used by ToStringWithCulture method.
			/// </summary>
			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000063 RID: 99 RVA: 0x00003589 File Offset: 0x00001789
			// (set) Token: 0x06000064 RID: 100 RVA: 0x00003591 File Offset: 0x00001791
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
			// Token: 0x06000065 RID: 101 RVA: 0x000035A0 File Offset: 0x000017A0
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

			// Token: 0x04000035 RID: 53
			private IFormatProvider formatProviderField = CultureInfo.InvariantCulture;
		}
	}
}
