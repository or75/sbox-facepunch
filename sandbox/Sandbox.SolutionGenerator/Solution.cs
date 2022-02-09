using System;
using System.CodeDom.Compiler;

namespace Sandbox.SolutionGenerator
{
	/// <summary>
	/// Class to produce the template output
	/// </summary>
	// Token: 0x02000007 RID: 7
	[GeneratedCode("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
	internal class Solution : SolutionBase
	{
		/// <summary>
		/// Create the template output
		/// </summary>
		// Token: 0x06000037 RID: 55 RVA: 0x00002EF8 File Offset: 0x000010F8
		public virtual string TransformText()
		{
			base.Write("Microsoft Visual Studio Solution File, Format Version 12.00\r\n# Visual Studio Version 16\r\nVisualStudioVersion = 16.0.29926.136\r\nMinimumVisualStudioVersion = 15.0.26124.0\r\n");
			base.Write(base.ToStringHelper.ToStringWithCulture(this.Projects));
			base.Write("Global\r\n\tGlobalSection(SolutionConfigurationPlatforms) = preSolution\r\n\t\tDebug|Any CPU = Debug|Any CPU\r\n\t\tRelease|Any CPU = Release|Any CPU\r\n\tEndGlobalSection\r\n\tGlobalSection(ProjectConfigurationPlatforms) = postSolution\r\n");
			base.Write(base.ToStringHelper.ToStringWithCulture(this.ProjectPlatforms));
			base.Write("\tEndGlobalSection\r\n\tGlobalSection(SolutionProperties) = preSolution\r\n\t\tHideSolutionNode = FALSE\r\n\tEndGlobalSection\r\n\tGlobalSection(NestedProjects) = preSolution\r\n");
			base.Write(base.ToStringHelper.ToStringWithCulture(this.NestedProjects));
			base.Write("\tEndGlobalSection\r\n\tGlobalSection(ExtensibilityGlobals) = postSolution\r\n\t\tSolutionGuid = {FD1E2EC4-D69D-418D-8FBF-4CA3864E5C8C}\r\n\tEndGlobalSection\r\nEndGlobal\r\n");
			return base.GenerationEnvironment.ToString();
		}

		// Token: 0x0400001B RID: 27
		public string Projects;

		// Token: 0x0400001C RID: 28
		public string ProjectPlatforms;

		// Token: 0x0400001D RID: 29
		public string NestedProjects;
	}
}
