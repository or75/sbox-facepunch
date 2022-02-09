using System;
using System.Text;

namespace Sandbox.Internal
{
	// Token: 0x020002EA RID: 746
	public class BaseTransformAttribute : BaseModelDocAttribute
	{
		/// <summary>
		/// Internal name of the key that dictates which bone to use as parent for position/angles.
		/// </summary>
		// Token: 0x170003CF RID: 975
		// (get) Token: 0x060013CD RID: 5069 RVA: 0x0002A6F8 File Offset: 0x000288F8
		// (set) Token: 0x060013CE RID: 5070 RVA: 0x0002A700 File Offset: 0x00028900
		public string Bone { get; set; }

		/// <summary>
		/// Internal name of the key that dictates which attachment to use as parent for position/angles.
		/// </summary>
		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x060013CF RID: 5071 RVA: 0x0002A709 File Offset: 0x00028909
		// (set) Token: 0x060013D0 RID: 5072 RVA: 0x0002A711 File Offset: 0x00028911
		public string Attachment { get; set; }

		/// <summary>
		/// Internal name of the key to store position in, if set, allows the helper to be moved.
		/// </summary>
		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x060013D1 RID: 5073 RVA: 0x0002A71A File Offset: 0x0002891A
		// (set) Token: 0x060013D2 RID: 5074 RVA: 0x0002A722 File Offset: 0x00028922
		public string Origin { get; set; }

		/// <summary>
		/// Internal name of the key to store angles in, allows the helper to be rotated.
		/// </summary>
		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x060013D3 RID: 5075 RVA: 0x0002A72B File Offset: 0x0002892B
		// (set) Token: 0x060013D4 RID: 5076 RVA: 0x0002A733 File Offset: 0x00028933
		public string Angles { get; set; }

		// Token: 0x060013D5 RID: 5077 RVA: 0x0002A73C File Offset: 0x0002893C
		public BaseTransformAttribute(string name)
			: base(name)
		{
		}

		// Token: 0x060013D6 RID: 5078 RVA: 0x0002A748 File Offset: 0x00028948
		protected override void AddTransform(StringBuilder sb)
		{
			string transformKeys = "";
			if (!string.IsNullOrEmpty(this.Origin))
			{
				transformKeys = transformKeys + "\t\torigin_key = " + this.Origin.QuoteSafe() + "\r\n";
			}
			if (!string.IsNullOrEmpty(this.Angles))
			{
				transformKeys = transformKeys + "\t\tangles_key = " + this.Angles.QuoteSafe() + "\r\n";
			}
			if (!string.IsNullOrEmpty(this.Attachment))
			{
				transformKeys = transformKeys + "\t\tattachment_key = " + this.Attachment.QuoteSafe() + "\r\n";
			}
			if (!string.IsNullOrEmpty(this.Bone))
			{
				transformKeys = transformKeys + "\t\tbone_key = " + this.Bone.QuoteSafe() + "\r\n";
			}
			if (!string.IsNullOrEmpty(transformKeys))
			{
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(20, 1, sb);
				appendInterpolatedStringHandler.AppendLiteral("\ttransform =\r\n\t{\r\n");
				appendInterpolatedStringHandler.AppendFormatted(transformKeys);
				appendInterpolatedStringHandler.AppendLiteral("\t}");
				sb.AppendLine(ref appendInterpolatedStringHandler);
			}
		}
	}
}
