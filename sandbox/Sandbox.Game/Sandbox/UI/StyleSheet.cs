using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Sandbox.Internal;

namespace Sandbox.UI
{
	// Token: 0x02000149 RID: 329
	public class StyleSheet
	{
		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x060018E1 RID: 6369 RVA: 0x00068580 File Offset: 0x00066780
		// (set) Token: 0x060018E2 RID: 6370 RVA: 0x00068587 File Offset: 0x00066787
		public static List<StyleSheet> Loaded { get; internal set; } = new List<StyleSheet>();

		/// <summary>
		/// Between sessions we clear the stylesheets, so one gamemode can't accidentally
		/// use cached values from another.
		/// </summary>
		// Token: 0x060018E3 RID: 6371 RVA: 0x00068590 File Offset: 0x00066790
		internal static void InitStyleSheets()
		{
			foreach (StyleSheet styleSheet in StyleSheet.Loaded)
			{
				if (styleSheet != null)
				{
					styleSheet.Release();
				}
			}
			StyleSheet.Loaded.Clear();
		}

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x060018E4 RID: 6372 RVA: 0x000685F0 File Offset: 0x000667F0
		// (set) Token: 0x060018E5 RID: 6373 RVA: 0x000685F8 File Offset: 0x000667F8
		public List<StyleBlock> Nodes { get; set; } = new List<StyleBlock>();

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x060018E6 RID: 6374 RVA: 0x00068601 File Offset: 0x00066801
		// (set) Token: 0x060018E7 RID: 6375 RVA: 0x00068609 File Offset: 0x00066809
		public string FileName { get; internal set; }

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x060018E8 RID: 6376 RVA: 0x00068612 File Offset: 0x00066812
		// (set) Token: 0x060018E9 RID: 6377 RVA: 0x0006861A File Offset: 0x0006681A
		internal FileWatch Watcher { get; private set; }

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x060018EA RID: 6378 RVA: 0x00068623 File Offset: 0x00066823
		// (set) Token: 0x060018EB RID: 6379 RVA: 0x0006862B File Offset: 0x0006682B
		public List<string> IncludedFiles { get; set; } = new List<string>();

		/// <summary>
		/// Releases the filesystem watcher so we won't get file changed events.
		/// </summary>
		// Token: 0x060018EC RID: 6380 RVA: 0x00068634 File Offset: 0x00066834
		public void Release()
		{
			FileWatch watcher = this.Watcher;
			if (watcher != null)
			{
				watcher.Dispose();
			}
			this.Watcher = null;
		}

		// Token: 0x060018ED RID: 6381 RVA: 0x00068650 File Offset: 0x00066850
		public static StyleSheet FromFile(string filename, [TupleElementNames(new string[] { "key", "value" })] IEnumerable<ValueTuple<string, string>> variables = null)
		{
			filename = FileSystem.NormalizeFilename(filename);
			StyleSheet alreadyLoaded = StyleSheet.Loaded.FirstOrDefault((StyleSheet x) => x.FileName == filename);
			if (alreadyLoaded != null)
			{
				return alreadyLoaded;
			}
			StyleSheet sheet = new StyleSheet();
			sheet.UpdateFromFile(filename, false);
			sheet.AddVariables(variables);
			sheet.FileName = filename;
			StyleSheet.Loaded.Add(sheet);
			return sheet;
		}

		// Token: 0x060018EE RID: 6382 RVA: 0x000686C9 File Offset: 0x000668C9
		internal void AddFilename(string filename)
		{
			this.IncludedFiles.Add(filename);
		}

		// Token: 0x060018EF RID: 6383 RVA: 0x000686D8 File Offset: 0x000668D8
		public static StyleSheet FromString(string styles, string filename = "none", [TupleElementNames(new string[] { "key", "value" })] IEnumerable<ValueTuple<string, string>> variables = null, bool notices = false)
		{
			StyleSheet result;
			try
			{
				result = StyleParser.ParseSheet(styles, filename, variables);
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Warning(e, FormattableStringFactory.Create("Error parsing stylesheet: {0}\n{1}", new object[] { e.Message, e.StackTrace }));
				if (notices)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
					defaultInterpolatedStringHandler.AppendLiteral("styles ");
					defaultInterpolatedStringHandler.AppendFormatted<float>(RealTime.Now);
					Development.Notice(defaultInterpolatedStringHandler.ToStringAndClear(), "format_shapes", "Updating " + filename + " Failed", 10, "error", null);
				}
				result = new StyleSheet();
			}
			return result;
		}

		// Token: 0x060018F0 RID: 6384 RVA: 0x00068788 File Offset: 0x00066988
		private void UpdateFromFile(string name, bool notifications = false)
		{
			float t = RealTime.Now;
			try
			{
				string text = FileSystem.Mounted.ReadAllText(name);
				if (text == null)
				{
					throw new FileNotFoundException("File not found", name);
				}
				StyleSheet sheet = StyleSheet.FromString(text, name, null, notifications);
				this.Nodes = sheet.Nodes;
				this.Variables = sheet.Variables;
				if (sheet.IncludedFiles.Count<string>() > 0)
				{
					this.IncludedFiles = sheet.IncludedFiles;
				}
				FileWatch watcher = this.Watcher;
				if (watcher != null)
				{
					watcher.Dispose();
				}
				this.Watcher = FileSystem.Mounted.Watch();
				this.Watcher.OnChanges += delegate(FileWatch x)
				{
					this.UpdateFromFile(name, true);
					UISystem.DirtyAllStyles();
				};
				foreach (string file in this.IncludedFiles)
				{
					this.Watcher.AddFile(file);
				}
				if (notifications)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
					defaultInterpolatedStringHandler.AppendLiteral("styles ");
					defaultInterpolatedStringHandler.AppendFormatted<float>(t);
					Development.Notice(defaultInterpolatedStringHandler.ToStringAndClear(), "format_shapes", "Updated " + name, 2, "success", null);
				}
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Warning(e, FormattableStringFactory.Create("Error opening stylesheet: {0} ({1})", new object[] { name, e.Message }));
				this.Nodes = new List<StyleBlock>();
				if (notifications)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
					defaultInterpolatedStringHandler.AppendLiteral("styles ");
					defaultInterpolatedStringHandler.AppendFormatted<float>(t);
					Development.Notice(defaultInterpolatedStringHandler.ToStringAndClear(), "format_shapes", "Updating " + name + " Failed", 5, "error", null);
				}
			}
		}

		// Token: 0x060018F1 RID: 6385 RVA: 0x00068994 File Offset: 0x00066B94
		internal void SetVariable(string key, string value, bool isdefault = false)
		{
			if (this.Variables == null)
			{
				this.Variables = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			}
			if (isdefault && this.Variables.ContainsKey(key))
			{
				return;
			}
			value = this.ReplaceVariables(value);
			this.Variables[key] = value;
		}

		// Token: 0x060018F2 RID: 6386 RVA: 0x000689E4 File Offset: 0x00066BE4
		public string GetVariable(string name, string defaultValue = null)
		{
			if (this.Variables == null)
			{
				return defaultValue;
			}
			string val;
			if (this.Variables.TryGetValue(name, out val))
			{
				return val;
			}
			return null;
		}

		// Token: 0x060018F3 RID: 6387 RVA: 0x00068A10 File Offset: 0x00066C10
		public string ReplaceVariables(string str)
		{
			if (!str.Contains('$'))
			{
				return str;
			}
			if (this.Variables == null)
			{
				throw new Exception("Unknown Variable");
			}
			IEnumerable<KeyValuePair<string, string>> source = this.Variables.Where((KeyValuePair<string, string> x) => str.Contains(x.Key)).ToArray<KeyValuePair<string, string>>();
			bool replaced = false;
			foreach (KeyValuePair<string, string> var in source.OrderByDescending((KeyValuePair<string, string> x) => x.Key.Length))
			{
				str = str.Replace(var.Key, var.Value);
				replaced = true;
			}
			if (!replaced)
			{
				throw new Exception("Unknown Variable");
			}
			return str;
		}

		// Token: 0x060018F4 RID: 6388 RVA: 0x00068B00 File Offset: 0x00066D00
		internal void AddVariables([TupleElementNames(new string[] { "key", "value" })] IEnumerable<ValueTuple<string, string>> variables)
		{
			if (variables == null)
			{
				return;
			}
			foreach (ValueTuple<string, string> var in variables)
			{
				this.SetVariable(var.Item1, var.Item2, false);
			}
		}

		// Token: 0x040006D4 RID: 1748
		public Dictionary<string, string> Variables;
	}
}
