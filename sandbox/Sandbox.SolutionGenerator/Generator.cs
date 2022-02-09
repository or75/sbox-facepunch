using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Sandbox.SolutionGenerator
{
	// Token: 0x02000002 RID: 2
	public class Generator
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public ProjectInfo AddProject(string folder, string name, string path, string defaultNamespace = "$(MSBuildProjectName.Replace(\" \", \"_\"))")
		{
			ProjectInfo project = new ProjectInfo(folder, name, path, defaultNamespace);
			this.Projects.Add(project);
			return project;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002075 File Offset: 0x00000275
		private string NormalizePath(string path)
		{
			return new Uri(path).LocalPath;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002084 File Offset: 0x00000284
		private string AttemptAbsoluteToRelative(string basePath, string relativePath, int maxDepth = 5)
		{
			string baseNormalized = this.NormalizePath(basePath);
			string relativeNormalized = this.NormalizePath(relativePath);
			string baseEnding = string.Empty;
			if (Path.HasExtension(baseNormalized))
			{
				baseEnding = Path.GetFileName(baseNormalized);
				baseNormalized = this.NormalizePath(baseNormalized.Substring(0, baseNormalized.Length - baseEnding.Length));
			}
			if (Path.HasExtension(relativeNormalized))
			{
				relativeNormalized = Path.GetDirectoryName(relativeNormalized);
			}
			string finalPath = Path.GetRelativePath(relativeNormalized, basePath);
			if (finalPath.Split("..", StringSplitOptions.None).Length > maxDepth)
			{
				if (baseEnding == null)
				{
					return baseNormalized;
				}
				return Path.Combine(baseNormalized, baseEnding);
			}
			else
			{
				if (baseEnding == null)
				{
					return finalPath;
				}
				return Path.Combine(finalPath, baseEnding);
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002114 File Offset: 0x00000314
		public void Run(string gameExePath, string managedFolder, string solutionPath, string relativePath)
		{
			ProjectInfo baseProj = this.Projects.FirstOrDefault((ProjectInfo x) => x.Name == "base");
			string normalizedRelativePath = this.NormalizePath(relativePath);
			int relativePathoffset = normalizedRelativePath.Length + 1;
			managedFolder = Path.Combine(relativePath, managedFolder);
			solutionPath = Path.Combine(relativePath, solutionPath);
			gameExePath = Path.Combine(relativePath, gameExePath);
			foreach (ProjectInfo p in this.Projects)
			{
				Project csproj = new Project();
				csproj.ProjectName = p.Name;
				csproj.ProjectReferences = "";
				csproj.ManagedRoot = this.AttemptAbsoluteToRelative(managedFolder, p.CsprojPath, 5);
				csproj.References = p.References;
				csproj.GlobalNamespaces = p.GlobalNamespaces;
				csproj.RootNamespace = p.RootNamespace;
				if (!p.IsBaseProject)
				{
					csproj.ProjectReferences = "<ProjectReference Include=\"" + baseProj.Path + "\\base.csproj\" />";
				}
				Generator.WriteTextIfChanged(p.CsprojPath, csproj.TransformText());
				if (gameExePath != null)
				{
					string text = Path.Combine(p.Path, "Properties");
					Directory.CreateDirectory(text);
					string json = JsonSerializer.Serialize<LaunchSettings>(new LaunchSettings
					{
						Profiles = new Dictionary<string, LaunchSettings.Profile> { 
						{
							p.Name,
							new LaunchSettings.Profile
							{
								CommandName = "Executable",
								ExecutablePath = gameExePath,
								CommandLineArgs = "+developer 1 -w 1920 -h 1080 -noassert -tools"
							}
						} }
					}, new JsonSerializerOptions
					{
						WriteIndented = true
					});
					Generator.WriteTextIfDoesntExist(Path.Combine(text, "launchSettings.json"), json);
				}
			}
			StringBuilder projectsList = new StringBuilder();
			StringBuilder nestedProjects = new StringBuilder();
			foreach (ProjectInfo p2 in this.Projects)
			{
				string normalizedProjectPath = this.NormalizePath(p2.CsprojPath);
				if (normalizedProjectPath.StartsWith(normalizedRelativePath))
				{
					normalizedProjectPath = normalizedProjectPath.Substring(relativePathoffset);
				}
				StringBuilder stringBuilder = projectsList;
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(62, 3, stringBuilder);
				appendInterpolatedStringHandler.AppendLiteral("Project(\"{9A19103F-16F7-4668-BE54-9A1E7A4F7556}\") = \"");
				appendInterpolatedStringHandler.AppendFormatted(p2.Name);
				appendInterpolatedStringHandler.AppendLiteral("\", \"");
				appendInterpolatedStringHandler.AppendFormatted(normalizedProjectPath);
				appendInterpolatedStringHandler.AppendLiteral("\", \"");
				appendInterpolatedStringHandler.AppendFormatted(p2.Guid);
				appendInterpolatedStringHandler.AppendLiteral("\"");
				stringBuilder2.AppendLine(ref appendInterpolatedStringHandler);
				projectsList.AppendLine("EndProject");
			}
			int i = 645722;
			foreach (IGrouping<string, ProjectInfo> p3 in from x in this.Projects
				group x by x.Folder)
			{
				string hash = Generator.GetHash(i++);
				StringBuilder stringBuilder = projectsList;
				StringBuilder stringBuilder3 = stringBuilder;
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(62, 3, stringBuilder);
				appendInterpolatedStringHandler.AppendLiteral("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"");
				appendInterpolatedStringHandler.AppendFormatted(p3.Key);
				appendInterpolatedStringHandler.AppendLiteral("\", \"");
				appendInterpolatedStringHandler.AppendFormatted(p3.Key);
				appendInterpolatedStringHandler.AppendLiteral("\", \"");
				appendInterpolatedStringHandler.AppendFormatted(hash);
				appendInterpolatedStringHandler.AppendLiteral("\"");
				stringBuilder3.AppendLine(ref appendInterpolatedStringHandler);
				projectsList.AppendLine("EndProject");
				foreach (ProjectInfo proj in p3)
				{
					stringBuilder = nestedProjects;
					StringBuilder stringBuilder4 = stringBuilder;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 2, stringBuilder);
					appendInterpolatedStringHandler.AppendLiteral("\t\t");
					appendInterpolatedStringHandler.AppendFormatted(proj.Guid);
					appendInterpolatedStringHandler.AppendLiteral(" = ");
					appendInterpolatedStringHandler.AppendFormatted(hash);
					stringBuilder4.AppendLine(ref appendInterpolatedStringHandler);
				}
			}
			StringBuilder projectPlatforms = new StringBuilder();
			foreach (ProjectInfo p4 in this.Projects)
			{
				StringBuilder stringBuilder = projectPlatforms;
				StringBuilder stringBuilder5 = stringBuilder;
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(42, 1, stringBuilder);
				appendInterpolatedStringHandler.AppendLiteral("\t\t");
				appendInterpolatedStringHandler.AppendFormatted(p4.Guid);
				appendInterpolatedStringHandler.AppendLiteral(".Debug|Any CPU.ActiveCfg = Debug|Any CPU");
				stringBuilder5.AppendLine(ref appendInterpolatedStringHandler);
				stringBuilder = projectPlatforms;
				StringBuilder stringBuilder6 = stringBuilder;
				appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(40, 1, stringBuilder);
				appendInterpolatedStringHandler.AppendLiteral("\t\t");
				appendInterpolatedStringHandler.AppendFormatted(p4.Guid);
				appendInterpolatedStringHandler.AppendLiteral(".Debug|Any CPU.Build.0 = Debug|Any CPU");
				stringBuilder6.AppendLine(ref appendInterpolatedStringHandler);
				stringBuilder = projectPlatforms;
				StringBuilder stringBuilder7 = stringBuilder;
				appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(46, 1, stringBuilder);
				appendInterpolatedStringHandler.AppendLiteral("\t\t");
				appendInterpolatedStringHandler.AppendFormatted(p4.Guid);
				appendInterpolatedStringHandler.AppendLiteral(".Release|Any CPU.ActiveCfg = Release|Any CPU");
				stringBuilder7.AppendLine(ref appendInterpolatedStringHandler);
				stringBuilder = projectPlatforms;
				StringBuilder stringBuilder8 = stringBuilder;
				appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(44, 1, stringBuilder);
				appendInterpolatedStringHandler.AppendLiteral("\t\t");
				appendInterpolatedStringHandler.AppendFormatted(p4.Guid);
				appendInterpolatedStringHandler.AppendLiteral(".Release|Any CPU.Build.0 = Release|Any CPU");
				stringBuilder8.AppendLine(ref appendInterpolatedStringHandler);
			}
			Generator.WriteTextIfChanged(solutionPath, new Solution
			{
				Projects = projectsList.ToString(),
				ProjectPlatforms = projectPlatforms.ToString(),
				NestedProjects = nestedProjects.ToString()
			}.TransformText());
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002700 File Offset: 0x00000900
		private static void WriteTextIfChanged(string path, string contents)
		{
			try
			{
				if (File.Exists(path))
				{
					string existingContents = File.ReadAllText(path);
					if (contents == existingContents)
					{
						return;
					}
				}
			}
			catch (Exception)
			{
			}
			string folder = Path.GetDirectoryName(path);
			if (!Directory.Exists(folder))
			{
				Directory.CreateDirectory(folder);
			}
			File.WriteAllText(path, contents);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000275C File Offset: 0x0000095C
		private static void WriteTextIfDoesntExist(string path, string contents)
		{
			if (File.Exists(path))
			{
				return;
			}
			Generator.WriteTextIfChanged(path, contents);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002770 File Offset: 0x00000970
		private static string GetHash(int i)
		{
			Random random = new Random(i);
			byte[] guidseed = new byte[16];
			random.NextBytes(guidseed);
			Guid Guid = new Guid(guidseed);
			return Guid.ToString("B").ToUpper();
		}

		// Token: 0x04000001 RID: 1
		private List<ProjectInfo> Projects = new List<ProjectInfo>();

		// Token: 0x04000002 RID: 2
		private static readonly char[] DirectorySeparators = new char[]
		{
			Path.DirectorySeparatorChar,
			Path.AltDirectorySeparatorChar
		};
	}
}
