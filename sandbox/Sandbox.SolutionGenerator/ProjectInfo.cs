using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Sandbox.SolutionGenerator
{
	// Token: 0x02000004 RID: 4
	public class ProjectInfo
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000027F3 File Offset: 0x000009F3
		// (set) Token: 0x0600000E RID: 14 RVA: 0x000027FB File Offset: 0x000009FB
		public string Name { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002804 File Offset: 0x00000A04
		// (set) Token: 0x06000010 RID: 16 RVA: 0x0000280C File Offset: 0x00000A0C
		public string Path { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002815 File Offset: 0x00000A15
		// (set) Token: 0x06000012 RID: 18 RVA: 0x0000281D File Offset: 0x00000A1D
		public string Folder { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00002826 File Offset: 0x00000A26
		// (set) Token: 0x06000014 RID: 20 RVA: 0x0000282E File Offset: 0x00000A2E
		public string CsprojPath { get; private set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000015 RID: 21 RVA: 0x00002837 File Offset: 0x00000A37
		// (set) Token: 0x06000016 RID: 22 RVA: 0x0000283F File Offset: 0x00000A3F
		public string Guid { get; private set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00002848 File Offset: 0x00000A48
		// (set) Token: 0x06000018 RID: 24 RVA: 0x00002850 File Offset: 0x00000A50
		public string RootNamespace { get; private set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000019 RID: 25 RVA: 0x00002859 File Offset: 0x00000A59
		// (set) Token: 0x0600001A RID: 26 RVA: 0x00002861 File Offset: 0x00000A61
		public bool IsBaseProject { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001B RID: 27 RVA: 0x0000286A File Offset: 0x00000A6A
		// (set) Token: 0x0600001C RID: 28 RVA: 0x00002872 File Offset: 0x00000A72
		public List<string> References { get; set; } = new List<string> { "Sandbox.System.dll", "Sandbox.Engine.dll", "Sandbox.Game.dll", "Sandbox.Event.dll", "Sandbox.Reflection.dll" };

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001D RID: 29 RVA: 0x0000287B File Offset: 0x00000A7B
		// (set) Token: 0x0600001E RID: 30 RVA: 0x00002883 File Offset: 0x00000A83
		public List<string> GlobalNamespaces { get; set; } = new List<string>();

		// Token: 0x0600001F RID: 31 RVA: 0x0000288C File Offset: 0x00000A8C
		public ProjectInfo(string folder, string name, string path, string defaultNamespace = "$(MSBuildProjectName.Replace(\" \", \"_\"))")
		{
			this.Folder = folder;
			this.Name = name;
			this.Path = path;
			this.CsprojPath = System.IO.Path.Combine(this.Path, this.Name + ".csproj");
			this.Guid = ProjectInfo.GetHashFromProjectName(this.Name);
			this.RootNamespace = defaultNamespace;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000293C File Offset: 0x00000B3C
		private static string GetHashFromProjectName(string name)
		{
			Random random = new Random(ProjectInfo.iNum++);
			byte[] guidseed = new byte[16];
			random.NextBytes(guidseed);
			Guid Guid = new Guid(guidseed);
			return Guid.ToString("B").ToUpper();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002982 File Offset: 0x00000B82
		public IEnumerable<ProjectInfo> GetDependencies(Dictionary<string, ProjectInfo> allProjects)
		{
			if (this.Name == "base")
			{
				yield break;
			}
			HashSet<ProjectInfo> seen = new HashSet<ProjectInfo>();
			ProjectInfo p;
			if (!allProjects.TryGetValue("base", out p) || !seen.Add(p))
			{
				yield break;
			}
			yield return p;
			foreach (ProjectInfo e in p.GetDependencies(allProjects))
			{
				if (seen.Add(e))
				{
					yield return e;
				}
			}
			IEnumerator<ProjectInfo> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000299C File Offset: 0x00000B9C
		public bool TryLoadConfig()
		{
			bool result;
			try
			{
				if (!File.Exists(System.IO.Path.Combine(this.Path, ".addon")))
				{
					result = false;
				}
				else
				{
					JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
					jsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
					jsonSerializerOptions.PropertyNameCaseInsensitive = true;
					jsonSerializerOptions.AllowTrailingCommas = true;
					result = true;
				}
			}
			catch (Exception e)
			{
				Console.Error.WriteLine("Error: failed to read config from " + this.Path + ":");
				Console.Error.WriteLine(e);
				result = false;
			}
			return result;
		}

		// Token: 0x0400000D RID: 13
		private static int iNum;
	}
}
