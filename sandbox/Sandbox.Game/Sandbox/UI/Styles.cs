using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Sandbox.Internal;

namespace Sandbox.UI
{
	// Token: 0x02000139 RID: 313
	[Hotload.SkipAttribute]
	public class Styles : BaseStyles
	{
		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x06001891 RID: 6289 RVA: 0x000646DC File Offset: 0x000628DC
		public bool HasTransitions
		{
			get
			{
				return this.Transitions != null && this.Transitions.List.Count > 0;
			}
		}

		// Token: 0x06001892 RID: 6290 RVA: 0x000646FB File Offset: 0x000628FB
		public Styles()
		{
			Host.AssertClientOrMenu(".ctor");
		}

		// Token: 0x06001893 RID: 6291 RVA: 0x00064723 File Offset: 0x00062923
		public override void Dirty()
		{
		}

		// Token: 0x17000427 RID: 1063
		// (set) Token: 0x06001894 RID: 6292 RVA: 0x00064725 File Offset: 0x00062925
		public Length? Padding
		{
			set
			{
				base.PaddingLeft = value;
				base.PaddingTop = value;
				base.PaddingRight = value;
				base.PaddingBottom = value;
			}
		}

		// Token: 0x17000428 RID: 1064
		// (set) Token: 0x06001895 RID: 6293 RVA: 0x00064743 File Offset: 0x00062943
		public Length? Margin
		{
			set
			{
				base.MarginLeft = value;
				base.MarginTop = value;
				base.MarginRight = value;
				base.MarginBottom = value;
			}
		}

		// Token: 0x17000429 RID: 1065
		// (set) Token: 0x06001896 RID: 6294 RVA: 0x00064761 File Offset: 0x00062961
		public Length? BorderWidth
		{
			set
			{
				base.BorderLeftWidth = value;
				base.BorderRightWidth = value;
				base.BorderTopWidth = value;
				base.BorderBottomWidth = value;
			}
		}

		// Token: 0x1700042A RID: 1066
		// (set) Token: 0x06001897 RID: 6295 RVA: 0x0006477F File Offset: 0x0006297F
		public Color? BorderColor
		{
			set
			{
				base.BorderLeftColor = value;
				base.BorderRightColor = value;
				base.BorderTopColor = value;
				base.BorderBottomColor = value;
			}
		}

		// Token: 0x06001898 RID: 6296 RVA: 0x000647A0 File Offset: 0x000629A0
		public Margin GetInset(Vector2 size)
		{
			Margin edges = Sandbox.UI.Margin.GetEdges(size, base.BorderLeftWidth, base.BorderTopWidth, base.BorderRightWidth, base.BorderBottomWidth);
			Margin padding = Sandbox.UI.Margin.GetEdges(size, base.PaddingLeft, base.PaddingTop, base.PaddingRight, base.PaddingBottom);
			return edges + padding;
		}

		// Token: 0x06001899 RID: 6297 RVA: 0x000647F0 File Offset: 0x000629F0
		public Margin GetOutset(Vector2 size)
		{
			return Sandbox.UI.Margin.GetEdges(size, base.MarginLeft, base.MarginTop, base.MarginRight, base.MarginBottom);
		}

		// Token: 0x0600189A RID: 6298 RVA: 0x00064810 File Offset: 0x00062A10
		internal bool SetInternal(string styles, string fileAndLine = null)
		{
			bool success = false;
			Parse p = new Parse(styles, "nofile");
			while (!p.IsEnd)
			{
				p = p.SkipWhitespaceAndNewlines(null);
				string property = p.ReadUntilOrEnd(" :;", false);
				p = p.SkipWhitespaceAndNewlines(null);
				if (p.IsEnd)
				{
					break;
				}
				if (p.Current != ':')
				{
					throw new Exception("Error parsing style: " + styles);
				}
				p.Pointer++;
				p = p.SkipWhitespaceAndNewlines(null);
				if (p.IsEnd)
				{
					throw new Exception("Error parsing style: " + styles);
				}
				string value = p.ReadUntilOrEnd(";", false);
				p.Pointer++;
				bool wasSuccessful = this.Set(property, value);
				if (!wasSuccessful)
				{
					string extra = string.Empty;
					if (fileAndLine != null)
					{
						extra = fileAndLine + ": ";
					}
					GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("{0}{1} is not valid with {2}", new object[] { extra, value, property }));
				}
				success = wasSuccessful || success;
				p = p.SkipWhitespaceAndNewlines(null);
			}
			return success;
		}

		// Token: 0x0600189B RID: 6299 RVA: 0x00064929 File Offset: 0x00062B29
		public bool Set(string styles)
		{
			return this.SetInternal(styles, null);
		}

		// Token: 0x0600189C RID: 6300 RVA: 0x00064934 File Offset: 0x00062B34
		public override void Add(Styles a)
		{
			if (a.HasTransitions)
			{
				if (this.Transitions == null)
				{
					this.Transitions = new TransitionList();
				}
				this.Transitions.AddTransitions(a.Transitions);
			}
			this.BoxShadow.AddFrom(a.BoxShadow);
			this.TextShadow.AddFrom(a.TextShadow);
			base.Add(a);
		}

		// Token: 0x0600189D RID: 6301 RVA: 0x00064998 File Offset: 0x00062B98
		public override void From(Styles a)
		{
			TransitionList transitions = this.Transitions;
			if (transitions != null)
			{
				transitions.Clear();
			}
			if (a.HasTransitions)
			{
				if (this.Transitions == null)
				{
					this.Transitions = new TransitionList();
				}
				this.Transitions.AddTransitions(a.Transitions);
			}
			this.BoxShadow.Clear();
			this.BoxShadow.IsNone = a.BoxShadow.IsNone;
			this.BoxShadow.AddRange(a.BoxShadow);
			this.TextShadow.Clear();
			this.TextShadow.IsNone = a.TextShadow.IsNone;
			this.TextShadow.AddRange(a.TextShadow);
			base.From(a);
		}

		// Token: 0x0600189E RID: 6302 RVA: 0x00064A50 File Offset: 0x00062C50
		private byte[] GenerateGradient(string token, int gradientWidth, ColorInterpolation colorInterpolation = Sandbox.UI.ColorInterpolation.Linear)
		{
			List<Styles.GradientGenerator> gradientGenerators = new List<Styles.GradientGenerator>();
			Color? lastColor = null;
			float? lastOffset = null;
			Parse p = new Parse(token, "nofile");
			while (!p.IsEnd)
			{
				p = p.SkipWhitespaceAndNewlines(null);
				string w = p.ReadSentence();
				Parse wp = new Parse(w, "nofile");
				Color? c = Color.Parse(ref wp, false);
				if (c == null)
				{
					GlobalGameNamespace.Log.Error(FormattableStringFactory.Create("Cannot read a color from '{0}'", new object[] { w }));
					break;
				}
				wp = wp.SkipWhitespaceAndNewlines(null);
				float? offset = null;
				float stop;
				if (wp.IsDigit && wp.TryReadFloat(out stop))
				{
					if (!wp.Is('%', 0, false))
					{
						GlobalGameNamespace.Log.Error(FormattableStringFactory.Create("Only percent stop values are supported: '{0}'", new object[] { w }));
						break;
					}
					wp.Pointer++;
					offset = new float?(stop / 100f);
				}
				wp = wp.SkipWhitespaceAndNewlines(null);
				if (!wp.IsEnd)
				{
					GlobalGameNamespace.Log.Error(FormattableStringFactory.Create("Extra text found after color stop: '{0}'", new object[] { w }));
					break;
				}
				if (c != null)
				{
					if (lastColor != null)
					{
						Styles.GradientGenerator gradient = default(Styles.GradientGenerator);
						gradient.from.color = lastColor.Value;
						gradient.from.offset = lastOffset;
						gradient.to.color = c.Value;
						gradient.to.offset = offset;
						gradientGenerators.Add(gradient);
					}
					lastColor = c;
					lastOffset = offset;
				}
				if (!p.Is(',', 0, false))
				{
					break;
				}
				p.Pointer++;
			}
			if (gradientGenerators.Count != 0)
			{
				float perSliceDistance = 1f / (float)gradientGenerators.Count;
				for (int i = 0; i < gradientGenerators.Count; i++)
				{
					Styles.GradientGenerator gradientGenerator = gradientGenerators[i];
					if (gradientGenerator.from.offset == null)
					{
						gradientGenerator.from.offset = new float?((float)i * perSliceDistance);
					}
					if (gradientGenerator.to.offset == null)
					{
						gradientGenerator.to.offset = new float?((float)(i + 1) * perSliceDistance);
					}
					gradientGenerators[i] = gradientGenerator;
				}
				List<Styles.GradientGenerator> list = gradientGenerators;
				Styles.GradientGenerator lastGenerator = list[list.Count - 1];
				if (lastGenerator.to.offset.Value < 1f)
				{
					gradientGenerators.Add(new Styles.GradientGenerator
					{
						from = lastGenerator.to,
						to = new Styles.GradientColorOffset
						{
							color = lastGenerator.to.color,
							offset = new float?((float)1)
						}
					});
				}
				byte[] gradientData = new byte[gradientWidth * 4];
				foreach (Styles.GradientGenerator gradient2 in gradientGenerators)
				{
					int fromPixel = (int)(gradient2.from.offset.Value * (float)gradientWidth);
					int toPixel = (int)(gradient2.to.offset.Value * (float)gradientWidth);
					float num = 1f / (float)(fromPixel - toPixel);
					Color color2 = gradient2.from.color;
					bool newMethod = color2.ComponentCountChangedBetweenColors(gradient2.to.color) > 1;
					if (colorInterpolation == Sandbox.UI.ColorInterpolation.Linear)
					{
						newMethod = false;
					}
					if (colorInterpolation == Sandbox.UI.ColorInterpolation.Lab)
					{
						newMethod = true;
					}
					for (int j = fromPixel; j < toPixel; j++)
					{
						float k = (float)(j - fromPixel) / (float)(toPixel - fromPixel);
						Color color;
						if (newMethod)
						{
							color = ColorXYZ.Lerp(gradient2.from.color, gradient2.to.color, k, true);
						}
						else
						{
							color = Color.Lerp(gradient2.from.color, gradient2.to.color, k, true);
						}
						gradientData[j * 4] = (byte)(color.r * 255f);
						gradientData[j * 4 + 1] = (byte)(color.g * 255f);
						gradientData[j * 4 + 2] = (byte)(color.b * 255f);
						gradientData[j * 4 + 3] = (byte)(color.a * 255f);
					}
				}
				return gradientData;
			}
			if (lastColor != null)
			{
				return new byte[]
				{
					(byte)(lastColor.Value.r * 255f),
					(byte)(lastColor.Value.g * 255f),
					(byte)(lastColor.Value.b * 255f),
					(byte)(lastColor.Value.a * 255f)
				};
			}
			return new byte[] { 0, 0, 0, byte.MaxValue };
		}

		// Token: 0x0600189F RID: 6303 RVA: 0x00064F3C File Offset: 0x0006313C
		private Texture GenerateConicGradientTexture(string token, ColorInterpolation colorInterpolation = Sandbox.UI.ColorInterpolation.Linear)
		{
			Parse p = new Parse(token, "nofile");
			Vector2 centerOffset = new Vector2(0.5f, 0.5f);
			byte[] gradientLUT = this.GenerateGradient(p.ReadRemaining(false), 128, colorInterpolation);
			int gradientWidth = gradientLUT.Length / 4;
			byte[] gradientData = new byte[gradientWidth * gradientWidth * 4];
			for (int x = 0; x < gradientWidth; x++)
			{
				for (int y = 0; y < gradientWidth; y++)
				{
					Vector2 pos = new Vector2((float)x / (float)gradientWidth, (float)y / (float)gradientWidth);
					double distance = (Math.Atan2((double)(pos.y - centerOffset.y), (double)(pos.x - centerOffset.y)) + 3.141592653589793) / 6.283185307179586;
					int s = Math.Clamp(gradientWidth - (int)(distance * (double)gradientWidth), 0, gradientWidth - 1);
					int outS = (x * gradientWidth + y) * 4;
					gradientData[outS] = gradientLUT[s * 4];
					gradientData[outS + 1] = gradientLUT[s * 4 + 1];
					gradientData[outS + 2] = gradientLUT[s * 4 + 2];
					gradientData[outS + 3] = gradientLUT[s * 4 + 3];
				}
			}
			return Texture.Create(gradientWidth, gradientWidth, ImageFormat.RGBA8888).WithData(gradientData).Finish();
		}

		// Token: 0x060018A0 RID: 6304 RVA: 0x0006507C File Offset: 0x0006327C
		private Texture GenerateRadialGradientTexture(string token, ColorInterpolation colorInterpolation = Sandbox.UI.ColorInterpolation.Linear)
		{
			Parse p = new Parse(token, "nofile");
			p.SkipWhitespaceAndNewlines(null);
			if (!p.Is("closest-side", 0, true) && !p.Is("closest-corner", 0, true) && !p.Is("farthest-side", 0, true))
			{
				p.Is("farthest-corner", 0, true);
			}
			Vector2 centerOffset = new Vector2(0.5f, 0.5f);
			byte[] gradientLUT = this.GenerateGradient(p.ReadRemaining(false), 128, colorInterpolation);
			int gradientWidth = gradientLUT.Length / 4;
			byte[] gradientData = new byte[gradientWidth * gradientWidth * 4];
			for (int x = 0; x < gradientWidth; x++)
			{
				for (int y = 0; y < gradientWidth; y++)
				{
					int s = Math.Clamp((int)(Vector2.GetDistance(new Vector2((float)x / (float)gradientWidth, (float)y / (float)gradientWidth), centerOffset) * (float)gradientWidth), 0, gradientWidth - 1);
					int outS = (x * gradientWidth + y) * 4;
					gradientData[outS] = gradientLUT[s * 4];
					gradientData[outS + 1] = gradientLUT[s * 4 + 1];
					gradientData[outS + 2] = gradientLUT[s * 4 + 2];
					gradientData[outS + 3] = gradientLUT[s * 4 + 3];
				}
			}
			return Texture.Create(gradientWidth, gradientWidth, ImageFormat.RGBA8888).WithData(gradientData).Finish();
		}

		// Token: 0x060018A1 RID: 6305 RVA: 0x000651C0 File Offset: 0x000633C0
		private Texture GenerateLinearGradientTexture(string token, ColorInterpolation colorInterpolation = Sandbox.UI.ColorInterpolation.Linear, bool isTextBackground = false)
		{
			int gradientWidth = ((colorInterpolation == Sandbox.UI.ColorInterpolation.Linear) ? 256 : 512);
			Parse p = new Parse(token, "nofile");
			Parse restoreP = p;
			string angle = p.ReadSentence();
			if (this.SetBackgroundAngle(angle, isTextBackground))
			{
				p.Pointer++;
			}
			else
			{
				p = restoreP;
			}
			byte[] gradientData = this.GenerateGradient(p.ReadRemaining(false), gradientWidth, colorInterpolation);
			return Texture.Create(1, gradientData.Length / 4, ImageFormat.RGBA8888).WithData(gradientData).Finish();
		}

		// Token: 0x060018A2 RID: 6306 RVA: 0x00065244 File Offset: 0x00063444
		internal void ApplyScale(Vector2 scale)
		{
			float s = (scale.x + scale.y) * 0.5f;
			this.Scale(ref this._fontsize, scale.y);
			this.Scale(ref this._letterspacing, scale.y);
			this.Scale(ref this._width, scale.x);
			this.Scale(ref this._minwidth, scale.x);
			this.Scale(ref this._maxwidth, scale.x);
			this.Scale(ref this._left, scale.x);
			this.Scale(ref this._right, scale.x);
			this.Scale(ref this._top, scale.y);
			this.Scale(ref this._bottom, scale.y);
			this.Scale(ref this._height, scale.y);
			this.Scale(ref this._minheight, scale.y);
			this.Scale(ref this._maxheight, scale.y);
			this.Scale(ref this._flexbasis, scale.y);
			this.Scale(ref this._marginleft, scale.x);
			this.Scale(ref this._margintop, scale.y);
			this.Scale(ref this._marginright, scale.x);
			this.Scale(ref this._marginbottom, scale.y);
			this.Scale(ref this._paddingleft, scale.x);
			this.Scale(ref this._paddingtop, scale.y);
			this.Scale(ref this._paddingright, scale.x);
			this.Scale(ref this._paddingbottom, scale.y);
			this.Scale(ref this._borderleftwidth, scale.x);
			this.Scale(ref this._bordertopwidth, scale.y);
			this.Scale(ref this._borderrightwidth, scale.x);
			this.Scale(ref this._borderbottomwidth, scale.y);
			this.Scale(ref this._bordertopleftradius, s);
			this.Scale(ref this._bordertoprightradius, s);
			this.Scale(ref this._borderbottomrightradius, s);
			this.Scale(ref this._borderbottomleftradius, s);
			this.Scale(this.BoxShadow, s);
			this.Scale(this.TextShadow, s);
		}

		// Token: 0x060018A3 RID: 6307 RVA: 0x00065490 File Offset: 0x00063690
		internal bool CalcVisible()
		{
			return (base.Display == null || base.Display.Value != DisplayMode.None) && (base.Opacity ?? 1f) > 0f;
		}

		// Token: 0x060018A4 RID: 6308 RVA: 0x000654E8 File Offset: 0x000636E8
		private void Scale(ref Length? fontSize, float amount)
		{
			if (fontSize == null)
			{
				return;
			}
			if (fontSize.Value.Unit == LengthUnit.Pixels)
			{
				fontSize = Length.Pixels(fontSize.Value.Value * amount);
			}
		}

		// Token: 0x060018A5 RID: 6309 RVA: 0x00065534 File Offset: 0x00063734
		private void Scale(ShadowList shadows, float amount)
		{
			if (shadows == null)
			{
				return;
			}
			for (int i = 0; i < shadows.Count; i++)
			{
				shadows[i] = shadows[i].Scale(amount);
			}
		}

		// Token: 0x060018A6 RID: 6310 RVA: 0x00065570 File Offset: 0x00063770
		public override bool Set(string property, string value)
		{
			if (property == "color")
			{
				property = "font-color";
			}
			uint num = <PrivateImplementationDetails>.ComputeStringHash(property);
			if (num <= 2307110152U)
			{
				if (num <= 946671509U)
				{
					if (num <= 301795354U)
					{
						if (num <= 170351812U)
						{
							if (num != 63716737U)
							{
								if (num != 127652482U)
								{
									if (num != 170351812U)
									{
										goto IL_964;
									}
									if (!(property == "transform-origin"))
									{
										goto IL_964;
									}
									return this.SetTransformOrigin(value);
								}
								else
								{
									if (!(property == "text-align"))
									{
										goto IL_964;
									}
									return this.SetTextAlign(value);
								}
							}
							else
							{
								if (!(property == "text-stroke"))
								{
									goto IL_964;
								}
								return this.SetTextStroke(value);
							}
						}
						else if (num != 252494808U)
						{
							if (num != 297582947U)
							{
								if (num != 301795354U)
								{
									goto IL_964;
								}
								if (!(property == "transition-timing-function"))
								{
									goto IL_964;
								}
							}
							else
							{
								if (!(property == "image-rendering"))
								{
									goto IL_964;
								}
								return this.SetImageRendering(value);
							}
						}
						else
						{
							if (!(property == "font-style"))
							{
								goto IL_964;
							}
							return this.SetFontStyle(value);
						}
					}
					else if (num <= 525480503U)
					{
						if (num != 362053203U)
						{
							if (num != 421574197U)
							{
								if (num != 525480503U)
								{
									goto IL_964;
								}
								if (!(property == "border"))
								{
									goto IL_964;
								}
								return this.SetBorder(value, delegate(Length? w)
								{
									this.BorderWidth = w;
								}, delegate(Color? c)
								{
									this.BorderColor = c;
								});
							}
							else if (!(property == "transition-duration"))
							{
								goto IL_964;
							}
						}
						else
						{
							if (!(property == "align-self"))
							{
								goto IL_964;
							}
							base.AlignSelf = this.GetAlign(value);
							return base.AlignSelf != null;
						}
					}
					else if (num != 862454147U)
					{
						if (num != 892039382U)
						{
							if (num != 946671509U)
							{
								goto IL_964;
							}
							if (!(property == "border-bottom"))
							{
								goto IL_964;
							}
							return this.SetBorder(value, delegate(Length? w)
							{
								base.BorderBottomWidth = w;
							}, delegate(Color? c)
							{
								base.BorderBottomColor = c;
							});
						}
						else
						{
							if (!(property == "font-color"))
							{
								goto IL_964;
							}
							return this.SetFontColor(value);
						}
					}
					else
					{
						if (!(property == "border-image"))
						{
							goto IL_964;
						}
						return this.SetBorderImage(value);
					}
				}
				else if (num <= 1421292290U)
				{
					if (num <= 1164572437U)
					{
						if (num != 973254076U)
						{
							if (num != 1021466580U)
							{
								if (num != 1164572437U)
								{
									goto IL_964;
								}
								if (!(property == "display"))
								{
									goto IL_964;
								}
								return this.SetDisplay(value);
							}
							else
							{
								if (!(property == "text-decoration-line"))
								{
									goto IL_964;
								}
								return this.SetTextDecorationLine(value);
							}
						}
						else
						{
							if (!(property == "border-radius"))
							{
								goto IL_964;
							}
							return this.SetBorderRadius(value);
						}
					}
					else if (num != 1269553309U)
					{
						if (num != 1326443451U)
						{
							if (num != 1421292290U)
							{
								goto IL_964;
							}
							if (!(property == "flex-direction"))
							{
								goto IL_964;
							}
							return this.SetFlexDirction(value);
						}
						else
						{
							if (!(property == "border-left"))
							{
								goto IL_964;
							}
							return this.SetBorder(value, delegate(Length? w)
							{
								base.BorderLeftWidth = w;
							}, delegate(Color? c)
							{
								base.BorderLeftColor = c;
							});
						}
					}
					else
					{
						if (!(property == "background"))
						{
							goto IL_964;
						}
						goto IL_91E;
					}
				}
				else if (num <= 2041122471U)
				{
					if (num != 1560681280U)
					{
						if (num != 2000487999U)
						{
							if (num != 2041122471U)
							{
								goto IL_964;
							}
							if (!(property == "text-decoration"))
							{
								goto IL_964;
							}
							return this.SetTextDecoration(value);
						}
						else
						{
							if (!(property == "background-repeat"))
							{
								goto IL_964;
							}
							return this.SetBackgroundRepeat(value);
						}
					}
					else if (!(property == "transition-property"))
					{
						goto IL_964;
					}
				}
				else if (num != 2157316278U)
				{
					if (num != 2290173017U)
					{
						if (num != 2307110152U)
						{
							goto IL_964;
						}
						if (!(property == "backdrop-filter"))
						{
							goto IL_964;
						}
						return this.SetBackdropFilter(value);
					}
					else
					{
						if (!(property == "border-top"))
						{
							goto IL_964;
						}
						return this.SetBorder(value, delegate(Length? w)
						{
							base.BorderTopWidth = w;
						}, delegate(Color? c)
						{
							base.BorderTopColor = c;
						});
					}
				}
				else
				{
					if (!(property == "padding"))
					{
						goto IL_964;
					}
					return this.SetPadding(value);
				}
			}
			else if (num <= 2980770829U)
			{
				if (num <= 2703595299U)
				{
					if (num <= 2471448074U)
					{
						if (num != 2361821363U)
						{
							if (num != 2396109838U)
							{
								if (num != 2471448074U)
								{
									goto IL_964;
								}
								if (!(property == "position"))
								{
									goto IL_964;
								}
								return this.SetPosition(value);
							}
							else
							{
								if (!(property == "align-content"))
								{
									goto IL_964;
								}
								base.AlignContent = this.GetAlign(value);
								return base.AlignContent != null;
							}
						}
						else
						{
							if (!(property == "background-position"))
							{
								goto IL_964;
							}
							return this.SetBackgroundPosition(value);
						}
					}
					else if (num != 2572986219U)
					{
						if (num != 2649052369U)
						{
							if (num != 2703595299U)
							{
								goto IL_964;
							}
							if (!(property == "align-items"))
							{
								goto IL_964;
							}
							base.AlignItems = this.GetAlign(value);
							return base.AlignItems != null;
						}
						else
						{
							if (!(property == "border-color"))
							{
								goto IL_964;
							}
							Color? borderColor = Color.Parse(value);
							this.BorderColor = borderColor;
							return borderColor != null;
						}
					}
					else
					{
						if (!(property == "overflow"))
						{
							goto IL_964;
						}
						return this.SetOverflow(value);
					}
				}
				else if (num <= 2789833231U)
				{
					if (num != 2731256135U)
					{
						if (num != 2787607266U)
						{
							if (num != 2789833231U)
							{
								goto IL_964;
							}
							if (!(property == "text-transform"))
							{
								goto IL_964;
							}
							return this.SetTextTransform(value);
						}
						else if (!(property == "transition"))
						{
							goto IL_964;
						}
					}
					else
					{
						if (!(property == "color-interpolation"))
						{
							goto IL_964;
						}
						return this.SetColorInterpolation(value);
					}
				}
				else if (num != 2876269101U)
				{
					if (num != 2938760115U)
					{
						if (num != 2980770829U)
						{
							goto IL_964;
						}
						if (!(property == "background-image"))
						{
							goto IL_964;
						}
						goto IL_91E;
					}
					else
					{
						if (!(property == "text-decoration-style"))
						{
							goto IL_964;
						}
						return this.SetTextDecorationStyle(value);
					}
				}
				else
				{
					if (!(property == "text-shadow"))
					{
						goto IL_964;
					}
					return this.SetTextShadow(value);
				}
			}
			else if (num <= 3491265536U)
			{
				if (num <= 3247228931U)
				{
					if (num != 3069341508U)
					{
						if (num != 3146254473U)
						{
							if (num != 3247228931U)
							{
								goto IL_964;
							}
							if (!(property == "font-weight"))
							{
								goto IL_964;
							}
							return this.SetFontWeight(value);
						}
						else
						{
							if (!(property == "box-shadow"))
							{
								goto IL_964;
							}
							return this.SetBoxShadow(value);
						}
					}
					else
					{
						if (!(property == "text-decoration-skip-ink"))
						{
							goto IL_964;
						}
						return this.SetTextDecorationSkipInk(value);
					}
				}
				else if (num != 3309482346U)
				{
					if (num != 3353438327U)
					{
						if (num != 3491265536U)
						{
							goto IL_964;
						}
						if (!(property == "transition-delay"))
						{
							goto IL_964;
						}
					}
					else
					{
						if (!(property == "filter"))
						{
							goto IL_964;
						}
						return this.SetFilter(value);
					}
				}
				else
				{
					if (!(property == "border-width"))
					{
						goto IL_964;
					}
					Length? borderWidth = Length.Parse(value);
					this.BorderWidth = borderWidth;
					return borderWidth != null;
				}
			}
			else if (num <= 3835907397U)
			{
				if (num != 3614522491U)
				{
					if (num != 3786248987U)
					{
						if (num != 3835907397U)
						{
							goto IL_964;
						}
						if (!(property == "background-image-tint"))
						{
							goto IL_964;
						}
						property = "background-tint";
						goto IL_964;
					}
					else
					{
						if (!(property == "transform"))
						{
							goto IL_964;
						}
						return this.SetTransform(value);
					}
				}
				else
				{
					if (!(property == "margin"))
					{
						goto IL_964;
					}
					return this.SetMargin(value);
				}
			}
			else if (num <= 3977472865U)
			{
				if (num != 3939361453U)
				{
					if (num != 3977472865U)
					{
						goto IL_964;
					}
					if (!(property == "background-size"))
					{
						goto IL_964;
					}
					return this.SetBackgroundSize(value);
				}
				else
				{
					if (!(property == "flex-wrap"))
					{
						goto IL_964;
					}
					return this.SetFlexWrap(value);
				}
			}
			else if (num != 4001223300U)
			{
				if (num != 4272933607U)
				{
					goto IL_964;
				}
				if (!(property == "justify-content"))
				{
					goto IL_964;
				}
				return this.SetJustifyContent(value);
			}
			else
			{
				if (!(property == "border-right"))
				{
					goto IL_964;
				}
				return this.SetBorder(value, delegate(Length? w)
				{
					base.BorderRightWidth = w;
				}, delegate(Color? c)
				{
					base.BorderRightColor = c;
				});
			}
			this.Transitions = TransitionDesc.ParseProperty(property, value, this.Transitions);
			return true;
			IL_91E:
			return this.SetImage(value, delegate(Texture t)
			{
				this.SetBackgroundImageFromTexture(t);
			}, false);
			IL_964:
			return base.Set(property, value);
		}

		// Token: 0x060018A7 RID: 6311 RVA: 0x00065EEC File Offset: 0x000640EC
		private bool SetFontColor(string value)
		{
			Color? fontColor = Color.Parse(value);
			if (fontColor != null)
			{
				base.FontColor = fontColor;
				return true;
			}
			return this.SetImage(value, delegate(Texture t)
			{
				this.SetTextBackgroundImageFromTexture(t);
			}, true);
		}

		// Token: 0x060018A8 RID: 6312 RVA: 0x00065F28 File Offset: 0x00064128
		private bool SetBorderImage(string value)
		{
			Parse p = new Parse(value, "nofile");
			p = p.SkipWhitespaceAndNewlines(null);
			Texture borderTexture = null;
			if (!this.SetImage(p.Text, delegate(Texture t)
			{
				borderTexture = t;
			}, false))
			{
				throw new Exception("Expected image as first border-image parameter.");
			}
			base.BorderImageSource = borderTexture;
			p.Pointer += p.ReadUntilOrEnd(")", false).Length;
			List<Length> borderSliceList = new List<Length>();
			List<Length> borderWidthList = new List<Length>();
			Styles.EBorderImageParseType parseType = Styles.EBorderImageParseType.ParseSlice;
			while (!p.IsEnd)
			{
				Length lengthValue;
				if (p.Is("stretch", 0, true))
				{
					p.Pointer += "stretch".Length;
					base.BorderImageRepeat = new BorderImageRepeat?(Sandbox.UI.BorderImageRepeat.Stretch);
				}
				else if (p.Is("round", 0, true))
				{
					p.Pointer += "round".Length;
					base.BorderImageRepeat = new BorderImageRepeat?(Sandbox.UI.BorderImageRepeat.Round);
				}
				else if (p.Is("fill", 0, true))
				{
					p.Pointer += "fill".Length;
					base.BorderImageFill = new BorderImageFill?(Sandbox.UI.BorderImageFill.Filled);
				}
				else if (p.Is("/", 0, true))
				{
					p.Pointer++;
					if (borderSliceList.Count == 0)
					{
						throw new Exception("border-image needs at least one value before splitting ('/')");
					}
					if (parseType == Styles.EBorderImageParseType.ParseWidth)
					{
						throw new Exception("border-image only supports up to slice and width params for splitting('/')");
					}
					parseType++;
				}
				else if (p.TryReadLength(out lengthValue))
				{
					if (parseType != Styles.EBorderImageParseType.ParseSlice)
					{
						if (parseType == Styles.EBorderImageParseType.ParseWidth)
						{
							borderWidthList.Add(lengthValue);
						}
					}
					else
					{
						borderSliceList.Add(lengthValue);
					}
				}
				if (p.IsEnd)
				{
					break;
				}
				p.Pointer++;
				p.SkipWhitespaceAndNewlines(null);
			}
			switch (borderSliceList.Count)
			{
			case 0:
			{
				Length? length = new Length?((float)base.BorderImageSource.Width / 3f);
				base.BorderImageWidthBottom = length;
				Length? length2 = (base.BorderImageWidthRight = (base.BorderImageWidthTop = length));
				base.BorderImageWidthLeft = length2;
				break;
			}
			case 1:
			{
				Length? length = new Length?(borderSliceList[0]);
				base.BorderImageWidthBottom = length;
				Length? length2 = (base.BorderImageWidthRight = (base.BorderImageWidthTop = length));
				base.BorderImageWidthLeft = length2;
				break;
			}
			case 2:
			{
				Length? length2 = new Length?(borderSliceList[0]);
				base.BorderImageWidthBottom = length2;
				base.BorderImageWidthTop = length2;
				length2 = new Length?(borderSliceList[1]);
				base.BorderImageWidthRight = length2;
				base.BorderImageWidthLeft = length2;
				break;
			}
			case 3:
			{
				base.BorderImageWidthTop = new Length?(borderSliceList[0]);
				Length? length2 = new Length?(borderSliceList[1]);
				base.BorderImageWidthRight = length2;
				base.BorderImageWidthLeft = length2;
				base.BorderImageWidthBottom = new Length?(borderSliceList[2]);
				break;
			}
			case 4:
				base.BorderImageWidthTop = new Length?(borderSliceList[0]);
				base.BorderImageWidthRight = new Length?(borderSliceList[1]);
				base.BorderImageWidthBottom = new Length?(borderSliceList[2]);
				base.BorderImageWidthLeft = new Length?(borderSliceList[3]);
				break;
			}
			switch (borderWidthList.Count)
			{
			case 0:
				base.BorderLeftWidth = base.BorderImageWidthLeft;
				base.BorderRightWidth = base.BorderImageWidthRight;
				base.BorderTopWidth = base.BorderImageWidthTop;
				base.BorderBottomWidth = base.BorderImageWidthBottom;
				break;
			case 1:
			{
				Length? length = new Length?(borderWidthList[0]);
				base.BorderBottomWidth = length;
				Length? length2 = (base.BorderRightWidth = (base.BorderTopWidth = length));
				base.BorderLeftWidth = length2;
				break;
			}
			case 2:
			{
				Length? length2 = new Length?(borderWidthList[0]);
				base.BorderBottomWidth = length2;
				base.BorderTopWidth = length2;
				length2 = new Length?(borderWidthList[1]);
				base.BorderRightWidth = length2;
				base.BorderLeftWidth = length2;
				break;
			}
			case 3:
			{
				base.BorderTopWidth = new Length?(borderWidthList[0]);
				Length? length2 = new Length?(borderWidthList[1]);
				base.BorderRightWidth = length2;
				base.BorderLeftWidth = length2;
				base.BorderBottomWidth = new Length?(borderWidthList[2]);
				break;
			}
			case 4:
				base.BorderTopWidth = new Length?(borderWidthList[0]);
				base.BorderRightWidth = new Length?(borderWidthList[1]);
				base.BorderBottomWidth = new Length?(borderWidthList[2]);
				base.BorderLeftWidth = new Length?(borderWidthList[3]);
				break;
			}
			return true;
		}

		// Token: 0x060018A9 RID: 6313 RVA: 0x000663D0 File Offset: 0x000645D0
		private bool SetBorderRadius(string value)
		{
			Parse p = new Parse(value, "nofile");
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return false;
			}
			Length a;
			if (!p.TryReadLength(out a))
			{
				return false;
			}
			Length b;
			if (p.IsEnd || !p.TryReadLength(out b))
			{
				base.BorderTopLeftRadius = new Length?(a);
				base.BorderTopRightRadius = new Length?(a);
				base.BorderBottomRightRadius = new Length?(a);
				base.BorderBottomLeftRadius = new Length?(a);
				return true;
			}
			Length c;
			if (p.IsEnd || !p.TryReadLength(out c))
			{
				base.BorderTopLeftRadius = new Length?(a);
				base.BorderTopRightRadius = new Length?(b);
				base.BorderBottomRightRadius = new Length?(a);
				base.BorderBottomLeftRadius = new Length?(b);
				return true;
			}
			Length d;
			if (p.IsEnd || !p.TryReadLength(out d))
			{
				base.BorderTopLeftRadius = new Length?(a);
				base.BorderTopRightRadius = new Length?(b);
				base.BorderBottomRightRadius = new Length?(c);
				base.BorderBottomLeftRadius = new Length?(b);
				return true;
			}
			base.BorderTopLeftRadius = new Length?(a);
			base.BorderTopRightRadius = new Length?(b);
			base.BorderBottomRightRadius = new Length?(c);
			base.BorderBottomLeftRadius = new Length?(d);
			return true;
		}

		// Token: 0x060018AA RID: 6314 RVA: 0x00066510 File Offset: 0x00064710
		private bool SetBorder(string value, Action<Length?> setWidth, Action<Color?> setColor)
		{
			Parse p = new Parse(value, "nofile");
			p = p.SkipWhitespaceAndNewlines(null);
			if (value == "none")
			{
				setWidth(Length.Pixels(0f));
				return true;
			}
			if (p.IsEnd)
			{
				return false;
			}
			Length a;
			if (p.TryReadLength(out a))
			{
				setWidth(new Length?(a));
			}
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return true;
			}
			if (p.IsLetter)
			{
				Parse restoreP = p;
				if (!(p.ReadWord(null, true) == "solid"))
				{
					p = restoreP;
				}
			}
			Color? c = Color.Parse(ref p, false);
			if (c == null)
			{
				return false;
			}
			setColor(c);
			return true;
		}

		// Token: 0x060018AB RID: 6315 RVA: 0x000665C8 File Offset: 0x000647C8
		private bool SetPadding(string value)
		{
			Parse p = new Parse(value, "nofile");
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return false;
			}
			Length a;
			if (p.TryReadLength(out a))
			{
				this.Padding = new Length?(a);
			}
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return true;
			}
			Length b;
			if (p.TryReadLength(out b))
			{
				base.PaddingLeft = new Length?(b);
				base.PaddingRight = new Length?(b);
			}
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return true;
			}
			Length c;
			if (p.TryReadLength(out c))
			{
				base.PaddingBottom = new Length?(c);
			}
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return true;
			}
			Length d;
			if (p.TryReadLength(out d))
			{
				base.PaddingTop = new Length?(a);
				base.PaddingRight = new Length?(b);
				base.PaddingBottom = new Length?(c);
				base.PaddingLeft = new Length?(d);
			}
			return true;
		}

		// Token: 0x060018AC RID: 6316 RVA: 0x000666C0 File Offset: 0x000648C0
		private bool SetMargin(string value)
		{
			Parse p = new Parse(value, "nofile");
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return false;
			}
			Length a;
			if (p.TryReadLength(out a))
			{
				base.MarginLeft = new Length?(a);
				base.MarginTop = new Length?(a);
				base.MarginRight = new Length?(a);
				base.MarginBottom = new Length?(a);
			}
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return true;
			}
			Length b;
			if (p.TryReadLength(out b))
			{
				base.MarginLeft = new Length?(b);
				base.MarginRight = new Length?(b);
			}
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return true;
			}
			Length c;
			if (p.TryReadLength(out c))
			{
				base.MarginBottom = new Length?(c);
			}
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return true;
			}
			Length d;
			if (p.TryReadLength(out d))
			{
				base.MarginTop = new Length?(a);
				base.MarginRight = new Length?(b);
				base.MarginBottom = new Length?(c);
				base.MarginLeft = new Length?(d);
			}
			return true;
		}

		// Token: 0x060018AD RID: 6317 RVA: 0x000667DC File Offset: 0x000649DC
		private bool SetFontWeight(string value)
		{
			int i;
			if (int.TryParse(value, out i))
			{
				base.FontWeight = new int?(i);
				return true;
			}
			uint num = <PrivateImplementationDetails>.ComputeStringHash(value);
			if (num <= 1891473428U)
			{
				if (num <= 349762515U)
				{
					if (num <= 295673152U)
					{
						if (num != 243248722U)
						{
							if (num != 295673152U)
							{
								return false;
							}
							if (!(value == "heavy"))
							{
								return false;
							}
							goto IL_369;
						}
						else if (!(value == "extrabold"))
						{
							return false;
						}
					}
					else if (num != 344111399U)
					{
						if (num != 349762515U)
						{
							return false;
						}
						if (!(value == "extralight"))
						{
							return false;
						}
						goto IL_2EB;
					}
					else
					{
						if (!(value == "demibold"))
						{
							return false;
						}
						goto IL_333;
					}
				}
				else if (num <= 1059707444U)
				{
					if (num != 900716406U)
					{
						if (num != 1059707444U)
						{
							return false;
						}
						if (!(value == "ultrablack"))
						{
							return false;
						}
						goto IL_37B;
					}
					else
					{
						if (!(value == "medium"))
						{
							return false;
						}
						base.FontWeight = new int?(500);
						return true;
					}
				}
				else if (num != 1238267715U)
				{
					if (num != 1452231588U)
					{
						if (num != 1891473428U)
						{
							return false;
						}
						if (!(value == "ultabold"))
						{
							return false;
						}
					}
					else
					{
						if (!(value == "black"))
						{
							return false;
						}
						goto IL_369;
					}
				}
				else
				{
					if (!(value == "hairline"))
					{
						return false;
					}
					goto IL_2DC;
				}
				base.FontWeight = new int?(800);
				return true;
				IL_369:
				base.FontWeight = new int?(900);
				return true;
			}
			if (num > 2908061953U)
			{
				if (num <= 3307975026U)
				{
					if (num != 3064469271U)
					{
						if (num != 3307975026U)
						{
							return false;
						}
						if (!(value == "thin"))
						{
							return false;
						}
						goto IL_2DC;
					}
					else if (!(value == "regular"))
					{
						return false;
					}
				}
				else if (num != 3734435446U)
				{
					if (num != 3801947695U)
					{
						if (num != 3867909202U)
						{
							return false;
						}
						if (!(value == "normal"))
						{
							return false;
						}
					}
					else
					{
						if (!(value == "light"))
						{
							return false;
						}
						base.FontWeight = new int?(300);
						return true;
					}
				}
				else
				{
					if (!(value == "bold"))
					{
						return false;
					}
					base.FontWeight = new int?(700);
					return true;
				}
				base.FontWeight = new int?(400);
				return true;
			}
			if (num <= 2125505604U)
			{
				if (num != 2042070808U)
				{
					if (num != 2125505604U)
					{
						return false;
					}
					if (!(value == "semibold"))
					{
						return false;
					}
					goto IL_333;
				}
				else
				{
					if (!(value == "extrablack"))
					{
						return false;
					}
					goto IL_37B;
				}
			}
			else if (num != 2130105951U)
			{
				if (num != 2574515428U)
				{
					if (num != 2908061953U)
					{
						return false;
					}
					if (!(value == "bolder"))
					{
						return false;
					}
					base.FontWeight = new int?(900);
					return true;
				}
				else
				{
					if (!(value == "lighter"))
					{
						return false;
					}
					base.FontWeight = new int?(200);
					return true;
				}
			}
			else
			{
				if (!(value == "ultralight"))
				{
					return false;
				}
				goto IL_2EB;
			}
			IL_2DC:
			base.FontWeight = new int?(100);
			return true;
			IL_2EB:
			base.FontWeight = new int?(200);
			return true;
			IL_333:
			base.FontWeight = new int?(600);
			return true;
			IL_37B:
			base.FontWeight = new int?(950);
			return true;
		}

		// Token: 0x060018AE RID: 6318 RVA: 0x00066B9C File Offset: 0x00064D9C
		private bool SetBoxShadow(string value)
		{
			Parse p = new Parse(value, "nofile");
			this.BoxShadow.Clear();
			if (p.Is("none", 0, true))
			{
				this.BoxShadow.IsNone = true;
				return true;
			}
			while (!p.IsEnd)
			{
				Shadow shadow = default(Shadow);
				Length x;
				if (!p.TryReadLength(out x))
				{
					return false;
				}
				Length y;
				if (!p.TryReadLength(out y))
				{
					return false;
				}
				shadow.OffsetX = x.Value;
				shadow.OffsetY = y.Value;
				Length blur;
				if (p.TryReadLength(out blur))
				{
					shadow.Blur = blur.Value;
					Length spread;
					if (p.TryReadLength(out spread))
					{
						shadow.Spread = spread.Value;
					}
				}
				Color color;
				if (p.TryReadColor(out color))
				{
					shadow.Color = color;
				}
				this.BoxShadow.Add(shadow);
				p.SkipWhitespaceAndNewlines(null);
				if (p.IsEnd || p.Current != ',')
				{
					return true;
				}
				p.Pointer++;
				p.SkipWhitespaceAndNewlines(null);
			}
			return true;
		}

		// Token: 0x060018AF RID: 6319 RVA: 0x00066CB4 File Offset: 0x00064EB4
		private bool SetTextShadow(string value)
		{
			Parse p = new Parse(value, "nofile");
			this.TextShadow.Clear();
			if (p.Is("none", 0, true))
			{
				this.TextShadow.IsNone = true;
				return true;
			}
			while (!p.IsEnd)
			{
				Shadow shadow = default(Shadow);
				Length x;
				if (!p.TryReadLength(out x))
				{
					return false;
				}
				Length y;
				if (!p.TryReadLength(out y))
				{
					return false;
				}
				shadow.OffsetX = x.Value;
				shadow.OffsetY = y.Value;
				Length blur;
				if (p.TryReadLength(out blur))
				{
					shadow.Blur = blur.Value;
					Length spread;
					if (p.TryReadLength(out spread))
					{
						shadow.Spread = spread.Value;
					}
				}
				Color color;
				if (p.TryReadColor(out color))
				{
					shadow.Color = color;
				}
				this.TextShadow.Add(shadow);
				p.SkipWhitespaceAndNewlines(null);
				if (p.IsEnd || p.Current != ',')
				{
					return true;
				}
				p.Pointer++;
				p.SkipWhitespaceAndNewlines(null);
			}
			return true;
		}

		// Token: 0x060018B0 RID: 6320 RVA: 0x00066DCC File Offset: 0x00064FCC
		private bool SetTextStroke(string value)
		{
			Parse p = new Parse(value, "nofile");
			Length width;
			if (!p.TryReadLength(out width))
			{
				return false;
			}
			Color color;
			if (!p.TryReadColor(out color))
			{
				return false;
			}
			base.TextStrokeWidth = new Length?(width);
			base.TextStrokeColor = new Color?(color);
			return true;
		}

		// Token: 0x060018B1 RID: 6321 RVA: 0x00066E1C File Offset: 0x0006501C
		private bool SetDisplay(string value)
		{
			if (value == "none")
			{
				base.Display = new DisplayMode?(DisplayMode.None);
				return true;
			}
			if (!(value == "flex"))
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Unhandled display property: {0}", new object[] { value }));
				return false;
			}
			base.Display = new DisplayMode?(DisplayMode.Flex);
			return true;
		}

		// Token: 0x060018B2 RID: 6322 RVA: 0x00066E80 File Offset: 0x00065080
		private bool SetPosition(string value)
		{
			if (value == "absolute")
			{
				base.Position = new PositionMode?(PositionMode.Absolute);
				return true;
			}
			if (!(value == "relative"))
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Unhandled position property: {0}", new object[] { value }));
				return false;
			}
			base.Position = new PositionMode?(PositionMode.Relative);
			return true;
		}

		// Token: 0x060018B3 RID: 6323 RVA: 0x00066EE4 File Offset: 0x000650E4
		private bool SetOverflow(string value)
		{
			if (value == "hidden")
			{
				base.Overflow = new OverflowMode?(OverflowMode.Hidden);
				return true;
			}
			if (value == "scroll")
			{
				base.Overflow = new OverflowMode?(OverflowMode.Scroll);
				return true;
			}
			if (!(value == "visible"))
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Unhandled overflow property: {0}", new object[] { value }));
				return false;
			}
			base.Overflow = new OverflowMode?(OverflowMode.Visible);
			return true;
		}

		// Token: 0x060018B4 RID: 6324 RVA: 0x00066F64 File Offset: 0x00065164
		private bool SetColorInterpolation(string value)
		{
			if (value == "auto")
			{
				base.ColorInterpolation = new ColorInterpolation?(Sandbox.UI.ColorInterpolation.Auto);
				return true;
			}
			if (value == "linearRGB" || value == "sRGB")
			{
				base.ColorInterpolation = new ColorInterpolation?(Sandbox.UI.ColorInterpolation.Linear);
				return true;
			}
			if (!(value == "lab"))
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Unhandled color-interpolation property: {0}", new object[] { value }));
				return false;
			}
			base.ColorInterpolation = new ColorInterpolation?(Sandbox.UI.ColorInterpolation.Lab);
			return true;
		}

		// Token: 0x060018B5 RID: 6325 RVA: 0x00066FF0 File Offset: 0x000651F0
		private bool SetFlexDirction(string value)
		{
			if (value == "column")
			{
				base.FlexDirection = new FlexDirection?(Sandbox.UI.FlexDirection.Column);
				return true;
			}
			if (value == "column-reverse")
			{
				base.FlexDirection = new FlexDirection?(Sandbox.UI.FlexDirection.ColumnReverse);
				return true;
			}
			if (value == "row")
			{
				base.FlexDirection = new FlexDirection?(Sandbox.UI.FlexDirection.Row);
				return true;
			}
			if (!(value == "row-reverse"))
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Unhandled flex-direction property: {0}", new object[] { value }));
				return false;
			}
			base.FlexDirection = new FlexDirection?(Sandbox.UI.FlexDirection.RowReverse);
			return true;
		}

		// Token: 0x060018B6 RID: 6326 RVA: 0x0006708C File Offset: 0x0006528C
		private bool SetFlexWrap(string value)
		{
			if (value == "nowrap")
			{
				base.FlexWrap = new Wrap?(Wrap.NoWrap);
				return true;
			}
			if (value == "wrap")
			{
				base.FlexWrap = new Wrap?(Wrap.Wrap);
				return true;
			}
			if (!(value == "wrap-reverse"))
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Unhandled flex-wrap property: {0}", new object[] { value }));
				return false;
			}
			base.FlexWrap = new Wrap?(Wrap.WrapReverse);
			return true;
		}

		// Token: 0x060018B7 RID: 6327 RVA: 0x0006710C File Offset: 0x0006530C
		private bool SetJustifyContent(string value)
		{
			if (value == "flex-start")
			{
				base.JustifyContent = new Justify?(Justify.FlexStart);
				return true;
			}
			if (value == "center")
			{
				base.JustifyContent = new Justify?(Justify.Center);
				return true;
			}
			if (value == "flex-end")
			{
				base.JustifyContent = new Justify?(Justify.FlexEnd);
				return true;
			}
			if (value == "space-between")
			{
				base.JustifyContent = new Justify?(Justify.SpaceBetween);
				return true;
			}
			if (value == "space-around")
			{
				base.JustifyContent = new Justify?(Justify.SpaceAround);
				return true;
			}
			if (!(value == "space-evenly"))
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Unhandled justify-content property: {0}", new object[] { value }));
				return false;
			}
			base.JustifyContent = new Justify?(Justify.SpaceEvenly);
			return true;
		}

		// Token: 0x060018B8 RID: 6328 RVA: 0x000671DC File Offset: 0x000653DC
		private Align? GetAlign(string value)
		{
			uint num = <PrivateImplementationDetails>.ComputeStringHash(value);
			if (num <= 2453644182U)
			{
				if (num <= 93078660U)
				{
					if (num != 55218674U)
					{
						if (num == 93078660U)
						{
							if (value == "center")
							{
								return new Align?(Align.Center);
							}
						}
					}
					else if (value == "flex-end")
					{
						return new Align?(Align.FlexEnd);
					}
				}
				else if (num != 2371343224U)
				{
					if (num == 2453644182U)
					{
						if (value == "auto")
						{
							return new Align?(Align.Auto);
						}
					}
				}
				else if (value == "space-between")
				{
					return new Align?(Align.SpaceBetween);
				}
			}
			else if (num <= 2885213762U)
			{
				if (num != 2608302999U)
				{
					if (num == 2885213762U)
					{
						if (value == "baseline")
						{
							return new Align?(Align.Baseline);
						}
					}
				}
				else if (value == "flex-start")
				{
					return new Align?(Align.FlexStart);
				}
			}
			else if (num != 3525284817U)
			{
				if (num == 3542801962U)
				{
					if (value == "stretch")
					{
						return new Align?(Align.Stretch);
					}
				}
			}
			else if (value == "space-around")
			{
				return new Align?(Align.SpaceAround);
			}
			GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Unhandled align property: {0}", new object[] { value }));
			return null;
		}

		// Token: 0x060018B9 RID: 6329 RVA: 0x00067348 File Offset: 0x00065548
		private bool SetTextAlign(string value)
		{
			if (value == "center")
			{
				base.TextAlign = new TextAlign?(Sandbox.UI.TextAlign.Center);
				return true;
			}
			if (value == "left")
			{
				base.TextAlign = new TextAlign?(Sandbox.UI.TextAlign.Left);
				return true;
			}
			if (!(value == "right"))
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Unhandled text-align property: {0}", new object[] { value }));
				return false;
			}
			base.TextAlign = new TextAlign?(Sandbox.UI.TextAlign.Right);
			return true;
		}

		// Token: 0x060018BA RID: 6330 RVA: 0x000673C8 File Offset: 0x000655C8
		private TextDecoration GetTextDecorationFromValue(string value)
		{
			TextDecoration td = TextDecoration.None;
			if (value.Contains("underline"))
			{
				td |= TextDecoration.Underline;
			}
			if (value.Contains("line-through"))
			{
				td |= TextDecoration.LineThrough;
			}
			if (value.Contains("overline"))
			{
				td |= TextDecoration.Overline;
			}
			return td;
		}

		// Token: 0x060018BB RID: 6331 RVA: 0x0006740C File Offset: 0x0006560C
		private bool SetTextDecoration(string value)
		{
			Parse p = new Parse(value, "nofile");
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return false;
			}
			TextDecoration td = TextDecoration.None;
			while (!p.IsEnd)
			{
				p = p.SkipWhitespaceAndNewlines(null);
				Length decorationThickness;
				Color decorationColor;
				if (p.TryReadLength(out decorationThickness))
				{
					base.TextDecorationThickness = new Length?(decorationThickness);
				}
				else if (p.TryReadColor(out decorationColor))
				{
					base.TextDecorationColor = new Color?(decorationColor);
				}
				else
				{
					string subValue = p.ReadWord(null, true);
					TextDecoration textDecoration = this.GetTextDecorationFromValue(subValue);
					if (textDecoration != TextDecoration.None)
					{
						td |= textDecoration;
					}
					else if (!this.SetTextDecorationStyle(subValue))
					{
						return false;
					}
				}
			}
			if (td != TextDecoration.None)
			{
				base.TextDecorationLine = new TextDecoration?(td);
			}
			return true;
		}

		// Token: 0x060018BC RID: 6332 RVA: 0x000674BE File Offset: 0x000656BE
		private bool SetTextDecorationLine(string value)
		{
			base.TextDecorationLine = new TextDecoration?(this.GetTextDecorationFromValue(value));
			return true;
		}

		// Token: 0x060018BD RID: 6333 RVA: 0x000674D4 File Offset: 0x000656D4
		private bool SetTextDecorationSkipInk(string value)
		{
			if (value == "auto" || value == "all")
			{
				base.TextDecorationSkipInk = new TextSkipInk?(TextSkipInk.All);
				return true;
			}
			if (!(value == "none"))
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Unhandled text-decoration-skip-ink property: {0}", new object[] { value }));
				return false;
			}
			base.TextDecorationSkipInk = new TextSkipInk?(TextSkipInk.None);
			return true;
		}

		// Token: 0x060018BE RID: 6334 RVA: 0x00067548 File Offset: 0x00065748
		private bool SetTextDecorationStyle(string value)
		{
			if (value == "solid")
			{
				base.TextDecorationStyle = new TextDecorationStyle?(Sandbox.UI.TextDecorationStyle.Solid);
				return true;
			}
			if (value == "double")
			{
				base.TextDecorationStyle = new TextDecorationStyle?(Sandbox.UI.TextDecorationStyle.Double);
				return true;
			}
			if (value == "dotted")
			{
				base.TextDecorationStyle = new TextDecorationStyle?(Sandbox.UI.TextDecorationStyle.Dotted);
				return true;
			}
			if (value == "dashed")
			{
				base.TextDecorationStyle = new TextDecorationStyle?(Sandbox.UI.TextDecorationStyle.Dashed);
				return true;
			}
			if (!(value == "wavy"))
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Unhandled text-decoration-style property: {0}", new object[] { value }));
				return false;
			}
			base.TextDecorationStyle = new TextDecorationStyle?(Sandbox.UI.TextDecorationStyle.Wavy);
			return true;
		}

		// Token: 0x060018BF RID: 6335 RVA: 0x00067600 File Offset: 0x00065800
		private bool SetFontStyle(string value)
		{
			FontStyle fs = Sandbox.UI.FontStyle.None;
			if (value.Contains("italic"))
			{
				fs |= Sandbox.UI.FontStyle.Italic;
			}
			if (value.Contains("oblique"))
			{
				fs |= Sandbox.UI.FontStyle.Oblique;
			}
			base.FontStyle = new FontStyle?(fs);
			return true;
		}

		// Token: 0x060018C0 RID: 6336 RVA: 0x00067640 File Offset: 0x00065840
		private bool SetTextTransform(string value)
		{
			if (value == "capitalize")
			{
				base.TextTransform = new TextTransform?(Sandbox.UI.TextTransform.Capitalize);
				return true;
			}
			if (value == "uppercase")
			{
				base.TextTransform = new TextTransform?(Sandbox.UI.TextTransform.Uppercase);
				return true;
			}
			if (value == "lowercase")
			{
				base.TextTransform = new TextTransform?(Sandbox.UI.TextTransform.Lowercase);
				return true;
			}
			if (!(value == "none"))
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Unhandled text-transform property: {0}", new object[] { value }));
				return false;
			}
			base.TextTransform = new TextTransform?(Sandbox.UI.TextTransform.None);
			return true;
		}

		// Token: 0x060018C1 RID: 6337 RVA: 0x000676DC File Offset: 0x000658DC
		private bool SetTransformOrigin(string value)
		{
			Parse p = new Parse(value, "nofile");
			Length x;
			if (!p.TryReadLength(out x))
			{
				return false;
			}
			base.TransformOriginX = new Length?(x);
			Length y;
			if (!p.TryReadLength(out y))
			{
				base.TransformOriginY = new Length?(x);
				return true;
			}
			base.TransformOriginY = new Length?(y);
			return true;
		}

		// Token: 0x060018C2 RID: 6338 RVA: 0x00067738 File Offset: 0x00065938
		private bool SetTransform(string value)
		{
			if (string.IsNullOrEmpty(value) || value == "none")
			{
				base.Transform = null;
				return true;
			}
			PanelTransform t = default(PanelTransform);
			t.Parse(value);
			base.Transform = new PanelTransform?(t);
			return true;
		}

		// Token: 0x060018C3 RID: 6339 RVA: 0x00067788 File Offset: 0x00065988
		private bool GetTokenValueUnderParenthesis(Parse p, string tokenName, out string result)
		{
			if (!p.Is(tokenName, 0, true))
			{
				result = "";
				return false;
			}
			p.Pointer += tokenName.Length;
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.Current != '(')
			{
				throw new Exception("Expected ( after " + tokenName);
			}
			p.Pointer++;
			int stack = 1;
			Parse wordStart = p;
			while (!p.IsEnd && stack > 0)
			{
				p.Pointer++;
				if (p.Current == '(')
				{
					stack++;
				}
				if (p.Current == ')')
				{
					stack--;
				}
			}
			if (p.IsEnd)
			{
				throw new Exception("Expected ) after " + tokenName);
			}
			result = wordStart.Read(p.Pointer - wordStart.Pointer);
			return true;
		}

		// Token: 0x060018C4 RID: 6340 RVA: 0x00067860 File Offset: 0x00065A60
		private bool SetImage(string value, Action<Texture> setImage, bool isTextBackground = false)
		{
			Parse p = new Parse(value, "nofile");
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.Is("none", 0, true))
			{
				setImage(Texture.Invalid);
				return true;
			}
			string url;
			if (this.GetTokenValueUnderParenthesis(p, "url", out url))
			{
				url = url.Trim(new char[] { ' ', '"', '\'' });
				setImage(Texture.Load(FileSystem.Mounted, url, true));
				return true;
			}
			string gradient;
			if (this.GetTokenValueUnderParenthesis(p, "linear-gradient", out gradient))
			{
				Texture gradientTexture = this.GenerateLinearGradientTexture(gradient, base.ColorInterpolation ?? Sandbox.UI.ColorInterpolation.Linear, isTextBackground);
				if (!isTextBackground)
				{
					this.SetBackgroundImageFromTexture(gradientTexture);
					this.SetBackgroundSize("100%");
					this.SetBackgroundRepeat("clamp");
				}
				else
				{
					setImage(gradientTexture);
				}
				return true;
			}
			string radialGradient;
			if (this.GetTokenValueUnderParenthesis(p, "radial-gradient", out radialGradient))
			{
				Texture gradientTexture2 = this.GenerateRadialGradientTexture(radialGradient, base.ColorInterpolation ?? Sandbox.UI.ColorInterpolation.Linear);
				if (!isTextBackground)
				{
					this.SetBackgroundImageFromTexture(gradientTexture2);
					this.SetBackgroundSize("100%");
					this.SetBackgroundRepeat("clamp");
				}
				else
				{
					setImage(gradientTexture2);
				}
				return true;
			}
			string conicGradient;
			if (this.GetTokenValueUnderParenthesis(p, "conic-gradient", out conicGradient))
			{
				Texture gradientTexture3 = this.GenerateConicGradientTexture(conicGradient, base.ColorInterpolation ?? Sandbox.UI.ColorInterpolation.Linear);
				if (!isTextBackground)
				{
					this.SetBackgroundImageFromTexture(gradientTexture3);
					this.SetBackgroundSize("100%");
					this.SetBackgroundRepeat("clamp");
				}
				else
				{
					setImage(gradientTexture3);
				}
				return true;
			}
			string materialUrl;
			if (this.GetTokenValueUnderParenthesis(p, "material", out materialUrl))
			{
				return true;
			}
			GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Unknown Image Type \"{0}\"\n", new object[] { value }));
			return false;
		}

		// Token: 0x060018C5 RID: 6341 RVA: 0x00067A3C File Offset: 0x00065C3C
		private bool SetImageRendering(string value)
		{
			uint num = <PrivateImplementationDetails>.ComputeStringHash(value);
			if (num > 979200790U)
			{
				if (num <= 2453644182U)
				{
					if (num != 1373605797U)
					{
						if (num != 2453644182U)
						{
							goto IL_10B;
						}
						if (!(value == "auto"))
						{
							goto IL_10B;
						}
					}
					else
					{
						if (!(value == "bilinear"))
						{
							goto IL_10B;
						}
						base.ImageRendering = new ImageRendering?(Sandbox.UI.ImageRendering.Bilinear);
						return true;
					}
				}
				else if (num != 4116479946U)
				{
					if (num != 4193827475U)
					{
						goto IL_10B;
					}
					if (!(value == "pixelated"))
					{
						goto IL_10B;
					}
					goto IL_FD;
				}
				else if (!(value == "anisotropic"))
				{
					goto IL_10B;
				}
				base.ImageRendering = new ImageRendering?(Sandbox.UI.ImageRendering.Anisotropic);
				return true;
			}
			if (num != 414084241U)
			{
				if (num != 417460167U)
				{
					if (num != 979200790U)
					{
						goto IL_10B;
					}
					if (!(value == "nearest-neighbor"))
					{
						goto IL_10B;
					}
				}
				else
				{
					if (!(value == "trilinear"))
					{
						goto IL_10B;
					}
					base.ImageRendering = new ImageRendering?(Sandbox.UI.ImageRendering.Trilinear);
					return true;
				}
			}
			else if (!(value == "point"))
			{
				goto IL_10B;
			}
			IL_FD:
			base.ImageRendering = new ImageRendering?(Sandbox.UI.ImageRendering.Point);
			return true;
			IL_10B:
			GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Unknown Image Rendering \"{0}\"\n", new object[] { value }));
			return false;
		}

		// Token: 0x060018C6 RID: 6342 RVA: 0x00067B74 File Offset: 0x00065D74
		private bool SetBackdropFilter(string value)
		{
			Parse p = new Parse(value, "nofile");
			p = p.SkipWhitespaceAndNewlines(null);
			while (!p.IsEnd)
			{
				p = p.SkipWhitespaceAndNewlines(null);
				if (p.IsEnd)
				{
					return true;
				}
				string name = p.ReadWord("(", false);
				string innervalue = p.ReadInnerBrackets('(', ')');
				if (name == "blur")
				{
					base.BackdropFilterBlur = Length.Parse(innervalue);
				}
				else if (name == "invert")
				{
					base.BackdropFilterInvert = Length.Parse(innervalue);
				}
				else if (name == "contrast")
				{
					base.BackdropFilterContrast = Length.Parse(innervalue);
				}
				else if (name == "brightness")
				{
					base.BackdropFilterBrightness = Length.Parse(innervalue);
				}
				else if (name == "grayscale")
				{
					base.BackdropFilterSaturate = Length.Parse(innervalue);
					if (base.BackdropFilterSaturate != null)
					{
						float val = base.BackdropFilterSaturate.Value.GetPixels(1f);
						base.BackdropFilterSaturate = new Length?(1f - val);
					}
				}
				else if (name == "saturate")
				{
					base.BackdropFilterSaturate = Length.Parse(innervalue);
				}
				else if (name == "sepia")
				{
					base.BackdropFilterSepia = Length.Parse(innervalue);
				}
				else
				{
					if (!(name == "hue-rotate"))
					{
						return false;
					}
					base.BackdropFilterHueRotate = Length.Parse(innervalue);
				}
			}
			return true;
		}

		// Token: 0x060018C7 RID: 6343 RVA: 0x00067D08 File Offset: 0x00065F08
		private bool SetFilter(string value)
		{
			Parse p = new Parse(value, "nofile");
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return true;
			}
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return true;
			}
			string name = p.ReadWord("(", false);
			string innervalue = p.ReadInnerBrackets('(', ')');
			uint num = <PrivateImplementationDetails>.ComputeStringHash(name);
			if (num <= 727181892U)
			{
				if (num <= 630476745U)
				{
					if (num != 352001611U)
					{
						if (num == 630476745U)
						{
							if (name == "sepia")
							{
								base.FilterSepia = Length.Parse(innervalue);
								return true;
							}
						}
					}
					else if (name == "hue-rotate")
					{
						base.FilterHueRotate = Length.Parse(innervalue);
						return true;
					}
				}
				else if (num != 713384307U)
				{
					if (num == 727181892U)
					{
						if (name == "saturate")
						{
							base.FilterSaturate = Length.Parse(innervalue);
							return true;
						}
					}
				}
				else if (name == "contrast")
				{
					base.FilterContrast = Length.Parse(innervalue);
					return true;
				}
			}
			else if (num <= 886071850U)
			{
				if (num != 829202337U)
				{
					if (num == 886071850U)
					{
						if (name == "brightness")
						{
							base.FilterBrightness = Length.Parse(innervalue);
							return true;
						}
					}
				}
				else if (name == "invert")
				{
					base.FilterInvert = Length.Parse(innervalue);
					return true;
				}
			}
			else if (num != 1547034252U)
			{
				if (num == 1811665304U)
				{
					if (name == "blur")
					{
						base.FilterBlur = Length.Parse(innervalue);
						return true;
					}
				}
			}
			else if (name == "tint")
			{
				base.FilterTint = Color.Parse(innervalue);
				return true;
			}
			GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Unknown filter property {0}", new object[] { innervalue }));
			return false;
		}

		// Token: 0x060018C8 RID: 6344 RVA: 0x00067F0D File Offset: 0x0006610D
		private bool SetBackgroundImageFromTexture(Texture texture)
		{
			if (texture == null)
			{
				return true;
			}
			base.BackgroundImage = texture;
			return true;
		}

		// Token: 0x060018C9 RID: 6345 RVA: 0x00067F1C File Offset: 0x0006611C
		private bool SetTextBackgroundImageFromTexture(Texture texture)
		{
			if (texture == null)
			{
				return true;
			}
			base.TextBackgroundImage = texture;
			return true;
		}

		// Token: 0x060018CA RID: 6346 RVA: 0x00067F2C File Offset: 0x0006612C
		private bool SetBackgroundAngle(string value, bool isTextBackground = false)
		{
			Parse p = new Parse(value, "nofile");
			p.SkipWhitespaceAndNewlines(null);
			string[] directionsLUT = new string[] { "top", "right", "bottom", "left" };
			Length? backgroundAngle = null;
			if (p.Is("to ", 0, true))
			{
				p.Pointer += 3;
				p.SkipWhitespaceAndNewlines(null);
				for (int i = 0; i < directionsLUT.Length; i++)
				{
					if (p.Is(directionsLUT[i], 0, true))
					{
						backgroundAngle = new Length?((float)i / 4f);
						p.Pointer += directionsLUT[i].Length;
						break;
					}
				}
			}
			Parse lastP = p;
			Length lenx;
			if (backgroundAngle == null && p.TryReadLength(out lenx) && lenx.Unit != LengthUnit.Pixels)
			{
				base.BackgroundAngle = new Length?(lenx);
			}
			if (backgroundAngle == null)
			{
				p = lastP;
				float num;
				if (p.TryReadFloat(out num))
				{
					backgroundAngle = new Length?(StyleHelpers.RotationDegrees(num, p.ReadUntilWhitespaceOrNewlineOrEnd(",")).DegreeToRadian());
				}
			}
			if (isTextBackground)
			{
				base.TextBackgroundAngle = backgroundAngle;
			}
			else
			{
				base.BackgroundAngle = backgroundAngle;
			}
			return backgroundAngle != null;
		}

		// Token: 0x060018CB RID: 6347 RVA: 0x00068084 File Offset: 0x00066284
		private bool SetBackgroundSize(string value)
		{
			Parse p = new Parse(value, "nofile");
			Length lenx;
			if (p.TryReadLength(out lenx))
			{
				base.BackgroundSizeX = new Length?(lenx);
				base.BackgroundSizeY = new Length?(lenx);
				Length leny;
				if (p.TryReadLength(out leny))
				{
					base.BackgroundSizeY = new Length?(leny);
				}
			}
			return true;
		}

		// Token: 0x060018CC RID: 6348 RVA: 0x000680DC File Offset: 0x000662DC
		private bool SetBackgroundPosition(string value)
		{
			Parse p = new Parse(value, "nofile");
			Length lenx;
			if (p.TryReadLength(out lenx))
			{
				base.BackgroundPositionX = new Length?(lenx);
				base.BackgroundPositionY = new Length?(lenx);
				Length leny;
				if (p.TryReadLength(out leny))
				{
					base.BackgroundPositionY = new Length?(leny);
				}
			}
			return true;
		}

		// Token: 0x060018CD RID: 6349 RVA: 0x00068134 File Offset: 0x00066334
		private bool SetBackgroundRepeat(string value)
		{
			if (value == "no-repeat")
			{
				base.BackgroundRepeat = new BackgroundRepeat?(Sandbox.UI.BackgroundRepeat.NoRepeat);
				return true;
			}
			if (value == "repeat-x")
			{
				base.BackgroundRepeat = new BackgroundRepeat?(Sandbox.UI.BackgroundRepeat.RepeatX);
				return true;
			}
			if (value == "repeat-y")
			{
				base.BackgroundRepeat = new BackgroundRepeat?(Sandbox.UI.BackgroundRepeat.RepeatY);
				return true;
			}
			if (value == "repeat")
			{
				base.BackgroundRepeat = new BackgroundRepeat?(Sandbox.UI.BackgroundRepeat.Repeat);
				return true;
			}
			if (!(value == "clamp"))
			{
				return false;
			}
			base.BackgroundRepeat = new BackgroundRepeat?(Sandbox.UI.BackgroundRepeat.Clamp);
			return true;
		}

		// Token: 0x0400067C RID: 1660
		public TransitionList Transitions;

		// Token: 0x0400067D RID: 1661
		public ShadowList BoxShadow = new ShadowList();

		// Token: 0x0400067E RID: 1662
		public ShadowList TextShadow = new ShadowList();

		// Token: 0x0400067F RID: 1663
		public static readonly Styles Default = new Styles
		{
			Padding = new Length?(0f)
		};

		// Token: 0x02000290 RID: 656
		public struct GradientColorOffset
		{
			// Token: 0x040012CF RID: 4815
			public Color color;

			// Token: 0x040012D0 RID: 4816
			public float? offset;
		}

		// Token: 0x02000291 RID: 657
		public struct GradientGenerator
		{
			// Token: 0x040012D1 RID: 4817
			public Styles.GradientColorOffset from;

			// Token: 0x040012D2 RID: 4818
			public Styles.GradientColorOffset to;
		}

		// Token: 0x02000292 RID: 658
		private enum EBorderImageParseType
		{
			// Token: 0x040012D4 RID: 4820
			ParseSlice,
			// Token: 0x040012D5 RID: 4821
			ParseWidth
		}
	}
}
