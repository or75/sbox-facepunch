using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sandbox;

namespace Hammer
{
	/// <summary>
	/// This makes it so the model, skin and bodygroups can be set and changed in Hammer.
	/// </summary>
	// Token: 0x020001FF RID: 511
	[AttributeUsage(AttributeTargets.Class)]
	public class ModelAttribute : MetaDataAttribute
	{
		/// <summary>
		/// The default model to be set to.
		/// </summary>
		// Token: 0x17000288 RID: 648
		// (get) Token: 0x06000CF6 RID: 3318 RVA: 0x00016109 File Offset: 0x00014309
		// (set) Token: 0x06000CF7 RID: 3319 RVA: 0x00016111 File Offset: 0x00014311
		public string Model { get; set; } = "";

		/// <summary>
		/// The default body group to be set to.
		/// </summary>
		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000CF8 RID: 3320 RVA: 0x0001611A File Offset: 0x0001431A
		// (set) Token: 0x06000CF9 RID: 3321 RVA: 0x00016122 File Offset: 0x00014322
		public string BodyGroup { get; set; } = "";

		/// <summary>
		/// The default material group to be set to.
		/// </summary>
		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000CFA RID: 3322 RVA: 0x0001612B File Offset: 0x0001432B
		// (set) Token: 0x06000CFB RID: 3323 RVA: 0x00016133 File Offset: 0x00014333
		public string MaterialGroup { get; set; } = "default";

		/// <summary>
		/// Marks this entity as a representative of a certain model archetype.
		/// This makes this entity class appear in ModelDoc under given archetype(s), which will be used to decide which entity class to use when dragging models from Hammer's Asset browser.
		/// </summary>
		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06000CFC RID: 3324 RVA: 0x0001613C File Offset: 0x0001433C
		// (set) Token: 0x06000CFD RID: 3325 RVA: 0x00016144 File Offset: 0x00014344
		public ModelArchetype Archetypes { get; set; }

		// Token: 0x06000CFE RID: 3326 RVA: 0x0001614D File Offset: 0x0001434D
		public override void AddHeader(StringBuilder sb)
		{
			sb.Append("model() ");
		}

		// Token: 0x06000CFF RID: 3327 RVA: 0x0001615C File Offset: 0x0001435C
		public override void AddBody(StringBuilder sb)
		{
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(118, 1, sb);
			appendInterpolatedStringHandler.AppendLiteral("\tmodel(resource:vmdl) { report = true hide_when_solid = true }: \"World Model\" : ");
			appendInterpolatedStringHandler.AppendFormatted(this.Model.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(" : \"The model this entity should use.\"");
			sb.AppendLine(ref appendInterpolatedStringHandler);
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(152, 1, sb);
			appendInterpolatedStringHandler.AppendLiteral("\tskin(materialgroup) { group = \"Rendering\" hide_when_solid = true } : \"Skin\" : ");
			appendInterpolatedStringHandler.AppendFormatted(this.MaterialGroup.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(" : \"Some models have multiple versions of their textures, called skins.\" ");
			sb.AppendLine(ref appendInterpolatedStringHandler);
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(208, 1, sb);
			appendInterpolatedStringHandler.AppendLiteral("\tbodygroups(bodygroupchoices) { group = \"Rendering\" hide_when_solid = true } : \"Body Groups\" : ");
			appendInterpolatedStringHandler.AppendFormatted(this.BodyGroup.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(" : \"Some models have multiple variations of certain items, such as characters having different hair styles, etc.\"");
			sb.AppendLine(ref appendInterpolatedStringHandler);
		}

		// Token: 0x06000D00 RID: 3328 RVA: 0x00016230 File Offset: 0x00014430
		public override void AddMetaData(StringBuilder sb)
		{
			if (this.Archetypes <= (ModelArchetype)0)
			{
				return;
			}
			List<string> archetypes = new List<string>();
			foreach (object obj in Enum.GetValues(typeof(ModelArchetype)))
			{
				ModelArchetype archetype = (ModelArchetype)obj;
				if ((this.Archetypes & archetype) != (ModelArchetype)0)
				{
					archetypes.Add(archetype.ToString());
				}
			}
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(24, 1, sb);
			appendInterpolatedStringHandler.AppendLiteral("\tmodel_archetypes = [ ");
			appendInterpolatedStringHandler.AppendFormatted(string.Join(", ", archetypes.Select((string x) => string.Format("\"{0}\"", x)).ToList<string>()));
			appendInterpolatedStringHandler.AppendLiteral(" ]");
			sb.AppendLine(ref appendInterpolatedStringHandler);
		}
	}
}
