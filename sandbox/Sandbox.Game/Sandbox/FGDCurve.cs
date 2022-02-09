using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using NativeEngine;
using Sandbox.Internal.JsonConvert;

namespace Sandbox
{
	/// <summary>
	/// A helper class to handle 'curve' FGD type.
	/// </summary>
	// Token: 0x0200008C RID: 140
	[JsonConverter(typeof(FGDCurveConverter))]
	public class FGDCurve
	{
		// Token: 0x06000E95 RID: 3733 RVA: 0x00045454 File Offset: 0x00043654
		public FGDCurve(string kv3data)
		{
			string jsonCurve = this.KV3ToJSON(kv3data);
			if (string.IsNullOrEmpty(jsonCurve))
			{
				return;
			}
			this.curve = JsonSerializer.Deserialize<FGDCurve.RawCurveData>(jsonCurve, null);
		}

		// Token: 0x06000E96 RID: 3734 RVA: 0x00045488 File Offset: 0x00043688
		private float getYForX(float x, FGDCurve.RawCurveNode c0, FGDCurve.RawCurveNode c1, bool clamp)
		{
			float dx = c1.x - c0.x;
			float dy = c1.y - c0.y;
			float t = x - c0.x;
			if (dx != 0f)
			{
				t /= dx;
			}
			t = Math.Clamp(t, 0f, 1f);
			float y = c0.y + t * (t * (t * ((c1.m_flSlopeIncoming + c0.m_flSlopeOutgoing) * dx - 2f * dy) + (-c1.m_flSlopeIncoming - 2f * c0.m_flSlopeOutgoing) * dx + 3f * dy) + c0.m_flSlopeOutgoing * dx);
			if (clamp)
			{
				y = y.Clamp(this.curve.m_vDomainMins[1], this.curve.m_vDomainMaxs[1]);
			}
			return y;
		}

		/// <summary>
		/// The cubic spline function in ranges as defined in Hammer/Asset editor.
		/// </summary>
		// Token: 0x06000E97 RID: 3735 RVA: 0x00045558 File Offset: 0x00043758
		public float Get(float x, bool clamp = true)
		{
			if (this.curve != null)
			{
				int i = 0;
				while (i < this.curve.m_spline.Length)
				{
					FGDCurve.RawCurveNode nodeNext = this.curve.m_spline[i];
					if (nodeNext.x >= x)
					{
						if (i == 0)
						{
							return this.getYForX(0f, nodeNext, this.curve.m_spline[i + 1], clamp);
						}
						FGDCurve.RawCurveNode nodePrev = this.curve.m_spline[i - 1];
						return this.getYForX(x, nodePrev, nodeNext, clamp);
					}
					else
					{
						i++;
					}
				}
				int lastNodeId = this.curve.m_spline.Length - 1;
				FGDCurve.RawCurveNode lastNode = this.curve.m_spline[lastNodeId];
				return this.getYForX(lastNode.x, this.curve.m_spline[lastNodeId - 1], lastNode, clamp);
			}
			if (clamp)
			{
				return x.Clamp(0f, 1f);
			}
			return x;
		}

		/// <summary>
		/// The cubic spline function normalized to ranges [0,1] on both input and output.
		/// </summary>
		// Token: 0x06000E98 RID: 3736 RVA: 0x00045640 File Offset: 0x00043840
		public float GetNormalized(float x, bool clamp = true)
		{
			if (this.curve != null)
			{
				float unscaledX = x.Remap(0f, 1f, this.curve.m_vDomainMins[0], this.curve.m_vDomainMaxs[0]);
				return this.Get(unscaledX, clamp).Remap(this.curve.m_vDomainMins[1], this.curve.m_vDomainMaxs[1], 0f, 1f);
			}
			if (clamp)
			{
				return x.Clamp(0f, 1f);
			}
			return x;
		}

		/// <summary>
		/// The bottom left corner of the curve. Mins and Maxs represet the range of inputs and outputs of the curve function.
		/// </summary>
		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000E99 RID: 3737 RVA: 0x000456C7 File Offset: 0x000438C7
		public Vector2 Mins
		{
			get
			{
				if (this.curve == null)
				{
					return new Vector2(0f, 0f);
				}
				return new Vector2(this.curve.m_vDomainMins[0], this.curve.m_vDomainMins[1]);
			}
		}

		/// <summary>
		/// The top right corner of the curve. Mins and Maxs represet the range of inputs and outputs of the curve function.
		/// </summary>
		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000E9A RID: 3738 RVA: 0x00045700 File Offset: 0x00043900
		public Vector2 Maxs
		{
			get
			{
				if (this.curve == null)
				{
					return new Vector2(1f, 1f);
				}
				return new Vector2(this.curve.m_vDomainMaxs[0], this.curve.m_vDomainMaxs[1]);
			}
		}

		/// <summary>
		/// Whether the curve was loaded correctly or not
		/// </summary>
		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000E9B RID: 3739 RVA: 0x00045739 File Offset: 0x00043939
		public bool IsValid
		{
			get
			{
				return this.curve != null;
			}
		}

		// Token: 0x06000E9C RID: 3740 RVA: 0x00045744 File Offset: 0x00043944
		internal string KV3ToJSON(string kv3string)
		{
			if (string.IsNullOrEmpty(kv3string))
			{
				return "{}";
			}
			return EngineGlue.KeyValues3ToJson(EngineGlue.LoadKeyValues3(kv3string));
		}

		// Token: 0x04000254 RID: 596
		private FGDCurve.RawCurveData curve;

		// Token: 0x02000212 RID: 530
		internal struct RawCurveNode
		{
			// Token: 0x17000545 RID: 1349
			// (get) Token: 0x06001D77 RID: 7543 RVA: 0x00073286 File Offset: 0x00071486
			// (set) Token: 0x06001D78 RID: 7544 RVA: 0x0007328E File Offset: 0x0007148E
			public float x { readonly get; set; }

			// Token: 0x17000546 RID: 1350
			// (get) Token: 0x06001D79 RID: 7545 RVA: 0x00073297 File Offset: 0x00071497
			// (set) Token: 0x06001D7A RID: 7546 RVA: 0x0007329F File Offset: 0x0007149F
			public float y { readonly get; set; }

			// Token: 0x17000547 RID: 1351
			// (get) Token: 0x06001D7B RID: 7547 RVA: 0x000732A8 File Offset: 0x000714A8
			// (set) Token: 0x06001D7C RID: 7548 RVA: 0x000732B0 File Offset: 0x000714B0
			public float m_flSlopeOutgoing { readonly get; set; }

			// Token: 0x17000548 RID: 1352
			// (get) Token: 0x06001D7D RID: 7549 RVA: 0x000732B9 File Offset: 0x000714B9
			// (set) Token: 0x06001D7E RID: 7550 RVA: 0x000732C1 File Offset: 0x000714C1
			public float m_flSlopeIncoming { readonly get; set; }
		}

		// Token: 0x02000213 RID: 531
		internal class RawCurveData
		{
			// Token: 0x17000549 RID: 1353
			// (get) Token: 0x06001D7F RID: 7551 RVA: 0x000732CA File Offset: 0x000714CA
			// (set) Token: 0x06001D80 RID: 7552 RVA: 0x000732D2 File Offset: 0x000714D2
			public FGDCurve.RawCurveNode[] m_spline { get; set; }

			// Token: 0x1700054A RID: 1354
			// (get) Token: 0x06001D81 RID: 7553 RVA: 0x000732DB File Offset: 0x000714DB
			// (set) Token: 0x06001D82 RID: 7554 RVA: 0x000732E3 File Offset: 0x000714E3
			public float[] m_vDomainMins { get; set; }

			// Token: 0x1700054B RID: 1355
			// (get) Token: 0x06001D83 RID: 7555 RVA: 0x000732EC File Offset: 0x000714EC
			// (set) Token: 0x06001D84 RID: 7556 RVA: 0x000732F4 File Offset: 0x000714F4
			public float[] m_vDomainMaxs { get; set; }
		}
	}
}
