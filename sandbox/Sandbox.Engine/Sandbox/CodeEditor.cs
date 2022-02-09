using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x0200028B RID: 651
	internal abstract class CodeEditor
	{
		// Token: 0x0600104B RID: 4171
		public abstract void OpenEditorAddonSolution();

		// Token: 0x0600104C RID: 4172
		public abstract void OpenEditorAt(string filename, int line);

		/// <summary>
		/// Called by the menu/tools to jump to code
		/// </summary>
		// Token: 0x0600104D RID: 4173 RVA: 0x0001D374 File Offset: 0x0001B574
		internal static void OpenSolution(string filename, int line)
		{
			try
			{
				CodeEditor current = CodeEditor.Current;
				if (current != null)
				{
					current.OpenEditorAt(filename, line);
				}
			}
			catch (Exception e)
			{
				GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Couldn't Open Editor: {0} ({1})", new object[] { filename, e.Message }));
			}
		}

		// Token: 0x0600104E RID: 4174 RVA: 0x0001D3D0 File Offset: 0x0001B5D0
		internal static void OpenAddonSolution()
		{
			try
			{
				CodeEditor current = CodeEditor.Current;
				if (current != null)
				{
					current.OpenEditorAddonSolution();
				}
			}
			catch (Exception e)
			{
				GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Couldn't Open Editor ({0})", new object[] { e.Message }));
			}
		}

		// Token: 0x0400126B RID: 4715
		public static CodeEditor Current = new CodeEditor.VisualStudio();

		// Token: 0x020003E8 RID: 1000
		public class VisualStudio : CodeEditor
		{
			// Token: 0x0600176B RID: 5995 RVA: 0x00035EBC File Offset: 0x000340BC
			public override void OpenEditorAt(string filename, int line)
			{
				string exe = Environment.CurrentDirectory + "/bin/win64/vsopen.exe";
				string devenv = CodeEditor.VisualStudio.FindVisualStudio();
				string sln = CodeEditor.VisualStudio.FindSolutions(Path.GetDirectoryName(filename));
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 4);
				defaultInterpolatedStringHandler.AppendLiteral("\"");
				defaultInterpolatedStringHandler.AppendFormatted(devenv);
				defaultInterpolatedStringHandler.AppendLiteral("\" \"");
				defaultInterpolatedStringHandler.AppendFormatted(sln);
				defaultInterpolatedStringHandler.AppendLiteral("\" \"");
				defaultInterpolatedStringHandler.AppendFormatted(filename);
				defaultInterpolatedStringHandler.AppendLiteral("\" \"");
				defaultInterpolatedStringHandler.AppendFormatted<int>(line);
				defaultInterpolatedStringHandler.AppendLiteral("\"");
				string args = defaultInterpolatedStringHandler.ToStringAndClear();
				Process.Start(new ProcessStartInfo
				{
					CreateNoWindow = true,
					Arguments = args,
					FileName = exe
				});
			}

			// Token: 0x0600176C RID: 5996 RVA: 0x00035F7C File Offset: 0x0003417C
			public override void OpenEditorAddonSolution()
			{
				string exe = Environment.CurrentDirectory + "/bin/win64/vsopen.exe";
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 2);
				defaultInterpolatedStringHandler.AppendLiteral("\"");
				defaultInterpolatedStringHandler.AppendFormatted(CodeEditor.VisualStudio.FindVisualStudio());
				defaultInterpolatedStringHandler.AppendLiteral("\" \"");
				defaultInterpolatedStringHandler.AppendFormatted(CodeEditor.VisualStudio.AddonSolution());
				defaultInterpolatedStringHandler.AppendLiteral("\"");
				string args = defaultInterpolatedStringHandler.ToStringAndClear();
				Process.Start(new ProcessStartInfo
				{
					CreateNoWindow = true,
					Arguments = args,
					FileName = exe
				});
			}

			// Token: 0x0600176D RID: 5997 RVA: 0x00036008 File Offset: 0x00034208
			private static string FindVisualStudio()
			{
				Process[] processesByName = Process.GetProcessesByName("devenv");
				int i = 0;
				if (i >= processesByName.Length)
				{
					foreach (string location in CodeEditor.VisualStudio.vslocations)
					{
						if (File.Exists(location))
						{
							return location;
						}
					}
					throw new Exception("Couldn't find visual studio");
				}
				return processesByName[i].MainModule.FileName;
			}

			// Token: 0x0600176E RID: 5998 RVA: 0x00036064 File Offset: 0x00034264
			private static string FindSolutions(string path)
			{
				if (path == null || path.Length < 5)
				{
					throw new Exception("Couldn't find solution file");
				}
				if (File.Exists(Path.Combine(path, ".addon")))
				{
					return CodeEditor.VisualStudio.AddonSolution();
				}
				string[] solutions = Directory.EnumerateFiles(path, "*.sln").ToArray<string>();
				if (solutions.Length != 0)
				{
					return string.Join(";", solutions);
				}
				return CodeEditor.VisualStudio.FindSolutions(Directory.GetParent(path).FullName);
			}

			// Token: 0x0600176F RID: 5999 RVA: 0x000360D1 File Offset: 0x000342D1
			private static string AddonSolution()
			{
				return Environment.CurrentDirectory + "/s&box.sln";
			}

			// Token: 0x04001991 RID: 6545
			private static string[] vslocations = new string[] { "C:\\Program Files\\Microsoft Visual Studio\\2022\\Preview\\Common7\\IDE\\devenv.exe", "C:\\Program Files\\Microsoft Visual Studio\\2022\\Enterprise\\Common7\\IDE\\devenv.exe", "C:\\Program Files\\Microsoft Visual Studio\\2022\\Professional\\Common7\\IDE\\devenv.exe", "C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\Common7\\IDE\\devenv.exe" };
		}
	}
}
