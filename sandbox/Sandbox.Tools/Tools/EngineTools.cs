using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Native;

namespace Tools
{
	// Token: 0x02000081 RID: 129
	internal static class EngineTools
	{
		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x0600132A RID: 4906 RVA: 0x00052D21 File Offset: 0x00050F21
		public static IReadOnlyList<EngineTools.ToolDescription> All
		{
			get
			{
				return EngineTools.AllTools.AsReadOnly();
			}
		}

		// Token: 0x0600132B RID: 4907 RVA: 0x00052D30 File Offset: 0x00050F30
		public static void ShowTool(string name)
		{
			EngineTools.ToolDescription tool = EngineTools.AllTools.FirstOrDefault((EngineTools.ToolDescription x) => x.Name == name);
			ToolGlue.ShowTool("tools/" + tool.Library + ".dll");
		}

		// Token: 0x040001B3 RID: 435
		private static List<EngineTools.ToolDescription> AllTools = new List<EngineTools.ToolDescription>
		{
			new EngineTools.ToolDescription("Hammer", "For editing maps", "hammer", "handyman"),
			new EngineTools.ToolDescription("Material Editor", "For editing materials", "met", "insert_photo"),
			new EngineTools.ToolDescription("Model Editor", "For editing models", "modeldoc_editor", "view_in_ar"),
			new EngineTools.ToolDescription("Animgraph Editor", "For editing animation graphs", "animgraph_editor", "directions_run"),
			new EngineTools.ToolDescription("Particle Editor", "For editing particle systems", "pet", "auto_fix_high"),
			new EngineTools.ToolDescription("Hotspot Editor", "For defining hotspot materials", "subrecteditor", "dashboard"),
			new EngineTools.ToolDescription("Postprocessing Editor", "For editing color correction", "postprocessingeditor", "camera"),
			new EngineTools.ToolDescription("Source Filmmaker", "For making dumb movies", "sfm", "movie_creation"),
			new EngineTools.ToolDescription("Inspector", "For editing .asset files", "inspector", "manage_search")
		};

		// Token: 0x0200013B RID: 315
		public class ToolDescription : IEquatable<EngineTools.ToolDescription>
		{
			// Token: 0x060017F6 RID: 6134 RVA: 0x0005BD60 File Offset: 0x00059F60
			public ToolDescription(string Name, string Description, string Library, string Icon)
			{
				this.Name = Name;
				this.Description = Description;
				this.Library = Library;
				this.Icon = Icon;
				base..ctor();
			}

			// Token: 0x170001C8 RID: 456
			// (get) Token: 0x060017F7 RID: 6135 RVA: 0x0005BD85 File Offset: 0x00059F85
			[Nullable(1)]
			protected virtual Type EqualityContract
			{
				[NullableContext(1)]
				[CompilerGenerated]
				get
				{
					return typeof(EngineTools.ToolDescription);
				}
			}

			// Token: 0x170001C9 RID: 457
			// (get) Token: 0x060017F8 RID: 6136 RVA: 0x0005BD91 File Offset: 0x00059F91
			// (set) Token: 0x060017F9 RID: 6137 RVA: 0x0005BD99 File Offset: 0x00059F99
			public string Name { get; set; }

			// Token: 0x170001CA RID: 458
			// (get) Token: 0x060017FA RID: 6138 RVA: 0x0005BDA2 File Offset: 0x00059FA2
			// (set) Token: 0x060017FB RID: 6139 RVA: 0x0005BDAA File Offset: 0x00059FAA
			public string Description { get; set; }

			// Token: 0x170001CB RID: 459
			// (get) Token: 0x060017FC RID: 6140 RVA: 0x0005BDB3 File Offset: 0x00059FB3
			// (set) Token: 0x060017FD RID: 6141 RVA: 0x0005BDBB File Offset: 0x00059FBB
			public string Library { get; set; }

			// Token: 0x170001CC RID: 460
			// (get) Token: 0x060017FE RID: 6142 RVA: 0x0005BDC4 File Offset: 0x00059FC4
			// (set) Token: 0x060017FF RID: 6143 RVA: 0x0005BDCC File Offset: 0x00059FCC
			public string Icon { get; set; }

			// Token: 0x06001800 RID: 6144 RVA: 0x0005BDD8 File Offset: 0x00059FD8
			[NullableContext(1)]
			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("ToolDescription");
				stringBuilder.Append(" { ");
				if (this.PrintMembers(stringBuilder))
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append('}');
				return stringBuilder.ToString();
			}

			// Token: 0x06001801 RID: 6145 RVA: 0x0005BE24 File Offset: 0x0005A024
			[NullableContext(1)]
			protected virtual bool PrintMembers(StringBuilder builder)
			{
				RuntimeHelpers.EnsureSufficientExecutionStack();
				builder.Append("Name = ");
				builder.Append(this.Name);
				builder.Append(", Description = ");
				builder.Append(this.Description);
				builder.Append(", Library = ");
				builder.Append(this.Library);
				builder.Append(", Icon = ");
				builder.Append(this.Icon);
				return true;
			}

			// Token: 0x06001802 RID: 6146 RVA: 0x0005BE9B File Offset: 0x0005A09B
			[NullableContext(2)]
			public static bool operator !=(EngineTools.ToolDescription left, EngineTools.ToolDescription right)
			{
				return !(left == right);
			}

			// Token: 0x06001803 RID: 6147 RVA: 0x0005BEA7 File Offset: 0x0005A0A7
			[NullableContext(2)]
			public static bool operator ==(EngineTools.ToolDescription left, EngineTools.ToolDescription right)
			{
				return left == right || (left != null && left.Equals(right));
			}

			// Token: 0x06001804 RID: 6148 RVA: 0x0005BEBC File Offset: 0x0005A0BC
			public override int GetHashCode()
			{
				return (((EqualityComparer<Type>.Default.GetHashCode(this.EqualityContract) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.<Name>k__BackingField)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.<Description>k__BackingField)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.<Library>k__BackingField)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.<Icon>k__BackingField);
			}

			// Token: 0x06001805 RID: 6149 RVA: 0x0005BF35 File Offset: 0x0005A135
			[NullableContext(2)]
			public override bool Equals(object obj)
			{
				return this.Equals(obj as EngineTools.ToolDescription);
			}

			// Token: 0x06001806 RID: 6150 RVA: 0x0005BF44 File Offset: 0x0005A144
			[NullableContext(2)]
			public virtual bool Equals(EngineTools.ToolDescription other)
			{
				return this == other || (other != null && this.EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(this.<Name>k__BackingField, other.<Name>k__BackingField) && EqualityComparer<string>.Default.Equals(this.<Description>k__BackingField, other.<Description>k__BackingField) && EqualityComparer<string>.Default.Equals(this.<Library>k__BackingField, other.<Library>k__BackingField) && EqualityComparer<string>.Default.Equals(this.<Icon>k__BackingField, other.<Icon>k__BackingField));
			}

			// Token: 0x06001807 RID: 6151 RVA: 0x0005BFCD File Offset: 0x0005A1CD
			[NullableContext(1)]
			public virtual EngineTools.ToolDescription <Clone>$()
			{
				return new EngineTools.ToolDescription(this);
			}

			// Token: 0x06001808 RID: 6152 RVA: 0x0005BFD5 File Offset: 0x0005A1D5
			protected ToolDescription([Nullable(1)] EngineTools.ToolDescription original)
			{
				this.Name = original.<Name>k__BackingField;
				this.Description = original.<Description>k__BackingField;
				this.Library = original.<Library>k__BackingField;
				this.Icon = original.<Icon>k__BackingField;
			}

			// Token: 0x06001809 RID: 6153 RVA: 0x0005C00D File Offset: 0x0005A20D
			public void Deconstruct(out string Name, out string Description, out string Library, out string Icon)
			{
				Name = this.Name;
				Description = this.Description;
				Library = this.Library;
				Icon = this.Icon;
			}
		}
	}
}
