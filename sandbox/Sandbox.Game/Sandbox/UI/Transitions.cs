using System;
using System.Collections.Generic;

namespace Sandbox.UI
{
	// Token: 0x0200014B RID: 331
	public class Transitions
	{
		// Token: 0x060018FD RID: 6397 RVA: 0x00068C30 File Offset: 0x00066E30
		internal Transitions(Panel panel)
		{
			this.panel = panel;
			Host.AssertClientOrMenu(".ctor");
		}

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x060018FE RID: 6398 RVA: 0x00068C49 File Offset: 0x00066E49
		public bool HasAny
		{
			get
			{
				List<Transitions.Entry> entries = this.Entries;
				return entries != null && entries.Count > 0;
			}
		}

		// Token: 0x060018FF RID: 6399 RVA: 0x00068C60 File Offset: 0x00066E60
		internal void Kill(Styles from)
		{
			if (!from.HasTransitions)
			{
				return;
			}
			if (this.Entries == null)
			{
				return;
			}
			using (List<TransitionDesc>.Enumerator enumerator = from.Transitions.List.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					TransitionDesc tran = enumerator.Current;
					this.Entries.RemoveAll((Transitions.Entry x) => x.property == tran.Property);
				}
			}
		}

		// Token: 0x06001900 RID: 6400 RVA: 0x00068CE8 File Offset: 0x00066EE8
		internal void Kill()
		{
			List<Transitions.Entry> entries = this.Entries;
			if (entries == null)
			{
				return;
			}
			entries.Clear();
		}

		// Token: 0x06001901 RID: 6401 RVA: 0x00068CFC File Offset: 0x00066EFC
		private Color LerpWithColorSpace(Color a, Color b, float delta, ColorInterpolation colorInterpolation)
		{
			bool labColorSpace = a.ComponentCountChangedBetweenColors(b) > 1;
			if (colorInterpolation == ColorInterpolation.Linear)
			{
				labColorSpace = false;
			}
			if (colorInterpolation == ColorInterpolation.Lab)
			{
				labColorSpace = true;
			}
			if (labColorSpace)
			{
				return ColorXYZ.Lerp(a, b, delta, true);
			}
			return Color.Lerp(a, b, delta, true);
		}

		// Token: 0x06001902 RID: 6402 RVA: 0x00068D48 File Offset: 0x00066F48
		internal void Add(Styles from, Styles to)
		{
			if (!to.HasTransitions)
			{
				return;
			}
			foreach (TransitionDesc tran in to.Transitions.List)
			{
				this.StyleAlt = null;
				this.Transition(tran, "background-color", from.BackgroundColor, to.BackgroundColor, delegate(Styles style, float delta, Color a, Color b)
				{
					style.BackgroundColor = new Color?(this.LerpWithColorSpace(a, b, delta, style.ColorInterpolation ?? ColorInterpolation.Linear));
				});
				this.Transition(tran, "width", from.Width, to.Width, this.panel.Box.Rect.width, delegate(Styles style, float delta, Length a, Length b)
				{
					style.Width = Length.Lerp(a, b, delta, this.GetWidth());
				});
				this.Transition(tran, "min-width", from.MinWidth, to.MinWidth, this.panel.Box.Rect.width, delegate(Styles style, float delta, Length a, Length b)
				{
					style.MinWidth = Length.Lerp(a, b, delta, this.GetWidth());
				});
				this.Transition(tran, "max-width", from.MaxWidth, to.MaxWidth, this.panel.Box.Rect.width, delegate(Styles style, float delta, Length a, Length b)
				{
					style.MaxWidth = Length.Lerp(a, b, delta, this.GetWidth());
				});
				this.Transition(tran, "height", from.Height, to.Height, this.panel.Box.Rect.height, delegate(Styles style, float delta, Length a, Length b)
				{
					style.Height = Length.Lerp(a, b, delta, this.GetHeight());
				});
				this.Transition(tran, "min-height", from.MinHeight, to.MinHeight, this.panel.Box.Rect.height, delegate(Styles style, float delta, Length a, Length b)
				{
					style.MinHeight = Length.Lerp(a, b, delta, this.GetHeight());
				});
				this.Transition(tran, "max-height", from.MaxHeight, to.MaxHeight, this.panel.Box.Rect.height, delegate(Styles style, float delta, Length a, Length b)
				{
					style.MaxHeight = Length.Lerp(a, b, delta, this.GetHeight());
				});
				this.Transition(tran, "left", from.Left, to.Left, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.Left = Length.Lerp(a, b, delta, this.GetWidth());
				});
				this.Transition(tran, "right", from.Right, to.Right, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.Right = Length.Lerp(a, b, delta, this.GetWidth());
				});
				this.Transition(tran, "top", from.Top, to.Top, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.Top = Length.Lerp(a, b, delta, this.GetHeight());
				});
				this.Transition(tran, "bottom", from.Bottom, to.Bottom, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.Bottom = Length.Lerp(a, b, delta, this.GetHeight());
				});
				this.Transition(tran, "color", from.FontColor, to.FontColor, delegate(Styles style, float delta, Color a, Color b)
				{
					style.FontColor = new Color?(this.LerpWithColorSpace(a, b, delta, style.ColorInterpolation ?? ColorInterpolation.Linear));
				});
				this.Transition(tran, "font-size", from.FontSize, to.FontSize, delegate(Styles style, float delta, Length a, Length b)
				{
					style.FontSize = Length.Lerp(a, b, delta, this.GetHeight());
				});
				this.StyleAlt = "padding";
				this.Transition(tran, "padding-left", from.PaddingLeft, to.PaddingLeft, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.PaddingLeft = Length.Lerp(a, b, delta, this.GetWidth());
				});
				this.Transition(tran, "padding-right", from.PaddingRight, to.PaddingRight, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.PaddingRight = Length.Lerp(a, b, delta, this.GetWidth());
				});
				this.Transition(tran, "padding-top", from.PaddingTop, to.PaddingTop, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.PaddingTop = Length.Lerp(a, b, delta, this.GetHeight());
				});
				this.Transition(tran, "padding-bottom", from.PaddingBottom, to.PaddingBottom, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.PaddingBottom = Length.Lerp(a, b, delta, this.GetHeight());
				});
				this.StyleAlt = "margin";
				this.Transition(tran, "margin-left", from.MarginLeft, to.MarginLeft, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.MarginLeft = Length.Lerp(a, b, delta, this.GetWidth());
				});
				this.Transition(tran, "margin-right", from.MarginRight, to.MarginRight, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.MarginRight = Length.Lerp(a, b, delta, this.GetWidth());
				});
				this.Transition(tran, "margin-top", from.MarginTop, to.MarginTop, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.MarginTop = Length.Lerp(a, b, delta, this.GetHeight());
				});
				this.Transition(tran, "margin-bottom", from.MarginBottom, to.MarginBottom, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.MarginBottom = Length.Lerp(a, b, delta, this.GetHeight());
				});
				this.StyleAlt = "border-radius";
				this.Transition(tran, "border-top-left-radius", from.BorderTopLeftRadius, to.BorderTopLeftRadius, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.BorderTopLeftRadius = Length.Lerp(a, b, delta, this.GetWidth());
				});
				this.Transition(tran, "border-top-right-radius", from.BorderTopRightRadius, to.BorderTopRightRadius, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.BorderTopRightRadius = Length.Lerp(a, b, delta, this.GetWidth());
				});
				this.Transition(tran, "border-bottom-right-radius", from.BorderBottomRightRadius, to.BorderBottomRightRadius, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.BorderBottomRightRadius = Length.Lerp(a, b, delta, this.GetWidth());
				});
				this.Transition(tran, "border-bottom-left-radius", from.BorderBottomLeftRadius, to.BorderBottomLeftRadius, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.BorderBottomLeftRadius = Length.Lerp(a, b, delta, this.GetWidth());
				});
				this.StyleAlt = "border";
				this.Transition(tran, "border-left-width", from.BorderLeftWidth, to.BorderLeftWidth, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.BorderLeftWidth = Length.Lerp(a, b, delta, this.GetWidth());
				});
				this.Transition(tran, "border-right-width", from.BorderRightWidth, to.BorderRightWidth, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.BorderRightWidth = Length.Lerp(a, b, delta, this.GetWidth());
				});
				this.Transition(tran, "border-top-width", from.BorderTopWidth, to.BorderTopWidth, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.BorderTopWidth = Length.Lerp(a, b, delta, this.GetWidth());
				});
				this.Transition(tran, "border-bottom-width", from.BorderBottomWidth, to.BorderBottomWidth, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.BorderBottomWidth = Length.Lerp(a, b, delta, this.GetWidth());
				});
				this.Transition(tran, "border-left-color", from.BorderLeftColor, to.BorderLeftColor, delegate(Styles style, float delta, Color a, Color b)
				{
					style.BorderLeftColor = new Color?(this.LerpWithColorSpace(a, b, delta, style.ColorInterpolation ?? ColorInterpolation.Linear));
				});
				this.Transition(tran, "border-right-color", from.BorderRightColor, to.BorderRightColor, delegate(Styles style, float delta, Color a, Color b)
				{
					style.BorderRightColor = new Color?(this.LerpWithColorSpace(a, b, delta, style.ColorInterpolation ?? ColorInterpolation.Linear));
				});
				this.Transition(tran, "border-top-color", from.BorderTopColor, to.BorderTopColor, delegate(Styles style, float delta, Color a, Color b)
				{
					style.BorderTopColor = new Color?(this.LerpWithColorSpace(a, b, delta, style.ColorInterpolation ?? ColorInterpolation.Linear));
				});
				this.Transition(tran, "border-bottom-color", from.BorderBottomColor, to.BorderBottomColor, delegate(Styles style, float delta, Color a, Color b)
				{
					style.BorderBottomColor = new Color?(this.LerpWithColorSpace(a, b, delta, style.ColorInterpolation ?? ColorInterpolation.Linear));
				});
				this.StyleAlt = "backdrop-filter";
				this.Transition(tran, "backdrop-filter-blur", from.BackdropFilterBlur, to.BackdropFilterBlur, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.BackdropFilterBlur = Length.Lerp(a, b, delta, 1f);
				});
				this.StyleAlt = "filter";
				this.Transition(tran, "backdrop-filter-blur", from.FilterBlur, to.FilterBlur, 0f, delegate(Styles style, float delta, Length a, Length b)
				{
					style.FilterBlur = Length.Lerp(a, b, delta, 1f);
				});
				this.StyleAlt = null;
				this.Transition(tran, "opacity", from.Opacity ?? 1f, to.Opacity ?? 1f, delegate(Styles style, float delta, float a, float b)
				{
					style.Opacity = new float?(a.LerpTo(b, delta, true));
				});
				this.Transition(tran, "box-shadow", from.BoxShadow, to.BoxShadow, delegate(Styles style, float delta, ShadowList a, ShadowList b)
				{
					style.BoxShadow.SetFromLerp(a, b, delta);
				});
				this.Transition(tran, "text-shadow", from.TextShadow, to.TextShadow, delegate(Styles style, float delta, ShadowList a, ShadowList b)
				{
					style.TextShadow.SetFromLerp(a, b, delta);
				});
				this.Transition(tran, "transform", from.Transform, to.Transform, delegate(Styles style, float delta, PanelTransform? a, PanelTransform? b)
				{
					style.Transform = PanelTransform.Lerp(a, b, delta);
				});
				if (from.AspectRatio != null && to.AspectRatio != null)
				{
					this.Transition(tran, "aspect-ratio", from.AspectRatio.Value, to.AspectRatio.Value, delegate(Styles style, float delta, float a, float b)
					{
						style.AspectRatio = new float?(a.LerpTo(b, delta, true));
					});
				}
				this.Transition(tran, "flex-grow", from.FlexGrow.GetValueOrDefault(), to.FlexGrow.GetValueOrDefault(), delegate(Styles style, float delta, float a, float b)
				{
					style.FlexGrow = new float?(a.LerpTo(b, delta, true));
				});
				this.Transition(tran, "flex-shrink", from.FlexShrink ?? 1f, to.FlexShrink ?? 1f, delegate(Styles style, float delta, float a, float b)
				{
					style.FlexShrink = new float?(a.LerpTo(b, delta, true));
				});
			}
		}

		// Token: 0x06001903 RID: 6403 RVA: 0x00069624 File Offset: 0x00067824
		private float GetWidth()
		{
			Panel parent = this.panel.Parent;
			if (parent == null)
			{
				return 0f;
			}
			return parent.Box.RectInner.width;
		}

		// Token: 0x06001904 RID: 6404 RVA: 0x0006964A File Offset: 0x0006784A
		private float GetHeight()
		{
			Panel parent = this.panel.Parent;
			if (parent == null)
			{
				return 0f;
			}
			return parent.Box.RectInner.height;
		}

		// Token: 0x06001905 RID: 6405 RVA: 0x00069670 File Offset: 0x00067870
		private void Transition(TransitionDesc desc, string name, Length? a, Length? b, Transitions.TransitionFunctionLength fn)
		{
			if (a == null)
			{
				return;
			}
			if (b == null)
			{
				return;
			}
			if (a == b)
			{
				return;
			}
			if (desc.Property != "all" && desc.Property != name && this.StyleAlt != desc.Property)
			{
				return;
			}
			this.Add(desc, name, delegate(Styles style, float delta)
			{
				fn(style, delta, a.Value, b.Value);
			});
		}

		// Token: 0x06001906 RID: 6406 RVA: 0x00069714 File Offset: 0x00067914
		private void Transition(TransitionDesc desc, string name, Length? a, Length? b, float defaultValue, Transitions.TransitionFunctionLength fn)
		{
			if (a == null)
			{
				a = new Length?(defaultValue);
			}
			if (b == null)
			{
				b = new Length?(defaultValue);
			}
			if (a == b)
			{
				return;
			}
			if (desc.Property != "all" && desc.Property != name && this.StyleAlt != desc.Property)
			{
				return;
			}
			this.Add(desc, name, delegate(Styles style, float delta)
			{
				fn(style, delta, a.Value, b.Value);
			});
		}

		// Token: 0x06001907 RID: 6407 RVA: 0x000697D8 File Offset: 0x000679D8
		private void Transition(TransitionDesc desc, string name, Color? a, Color? b, Transitions.TransitionFunctionColor fn)
		{
			if (a == null)
			{
				return;
			}
			if (b == null)
			{
				return;
			}
			if (a == b)
			{
				return;
			}
			if (desc.Property != "all" && desc.Property != name && this.StyleAlt != desc.Property)
			{
				return;
			}
			this.Add(desc, name, delegate(Styles style, float delta)
			{
				fn(style, delta, a.Value, b.Value);
			});
		}

		// Token: 0x06001908 RID: 6408 RVA: 0x000698AC File Offset: 0x00067AAC
		private void Transition(TransitionDesc desc, string name, float a, float b, Transitions.TransitionFunctionFloat fn)
		{
			if (a == b)
			{
				return;
			}
			if (desc.Property != "all" && desc.Property != name && this.StyleAlt != desc.Property)
			{
				return;
			}
			this.Add(desc, name, delegate(Styles style, float delta)
			{
				fn(style, delta, a, b);
			});
		}

		// Token: 0x06001909 RID: 6409 RVA: 0x00069930 File Offset: 0x00067B30
		private void Transition(TransitionDesc desc, string name, PanelTransform? a, PanelTransform? b, Transitions.TransitionFunctionTransform fn)
		{
			if (a == null && b == null)
			{
				return;
			}
			if (desc.Property != "all" && desc.Property != name && this.StyleAlt != desc.Property)
			{
				return;
			}
			this.Add(desc, name, delegate(Styles style, float delta)
			{
				fn(style, delta, a, b);
			});
		}

		// Token: 0x0600190A RID: 6410 RVA: 0x000699C0 File Offset: 0x00067BC0
		private void Transition(TransitionDesc desc, string name, ShadowList a, ShadowList b, Transitions.TransitionFunctionShadows fn)
		{
			if (a.Count == 0 && b.Count == 0)
			{
				return;
			}
			if (desc.Property != "all" && desc.Property != name && this.StyleAlt != desc.Property)
			{
				return;
			}
			a = a.MakeCopy();
			b = b.MakeCopy();
			this.Add(desc, name, delegate(Styles style, float delta)
			{
				fn(style, delta, a, b);
			});
		}

		// Token: 0x0600190B RID: 6411 RVA: 0x00069A70 File Offset: 0x00067C70
		private void Add(TransitionDesc desc, string type, Transitions.TransitionFunction act)
		{
			List<Transitions.Entry> entries = this.Entries;
			if (entries != null)
			{
				entries.RemoveAll((Transitions.Entry x) => x.type == type);
			}
			float length = 1f;
			float startTime = this.panel.Now - Time.Delta;
			if (desc.Duration != null)
			{
				length = desc.Duration.Value / 1000f;
			}
			if (length <= 0f && desc.Delay == null)
			{
				return;
			}
			if (desc.Delay != null)
			{
				startTime += desc.Delay.Value / 1000f;
			}
			if (this.Entries == null)
			{
				this.Entries = new List<Transitions.Entry>();
			}
			this.Entries.Add(new Transitions.Entry
			{
				action = act,
				startTime = startTime,
				length = length,
				property = desc.Property,
				type = type,
				ease = Easing.GetFunction(desc.TimingFunction)
			});
		}

		// Token: 0x0600190C RID: 6412 RVA: 0x00069B88 File Offset: 0x00067D88
		internal bool Run(Styles style)
		{
			if (!this.HasAny)
			{
				return false;
			}
			float now = this.panel.Now;
			this.Entries.RemoveAll((Transitions.Entry x) => x.startTime + x.length < now);
			foreach (Transitions.Entry entry in this.Entries)
			{
				if (now < entry.startTime)
				{
					entry.action(style, entry.ease(0f));
				}
				else
				{
					float endTime = entry.startTime + entry.length;
					if (now <= endTime)
					{
						entry.action(style, entry.ease((now - entry.startTime) / entry.length));
					}
				}
			}
			return true;
		}

		// Token: 0x040006D7 RID: 1751
		public List<Transitions.Entry> Entries;

		// Token: 0x040006D8 RID: 1752
		private Panel panel;

		// Token: 0x040006D9 RID: 1753
		private string StyleAlt;

		// Token: 0x0200029A RID: 666
		// (Invoke) Token: 0x06001F8F RID: 8079
		public delegate void TransitionFunction(Styles style, float delta);

		// Token: 0x0200029B RID: 667
		// (Invoke) Token: 0x06001F93 RID: 8083
		public delegate void TransitionFunctionLength(Styles style, float delta, Length a, Length b);

		// Token: 0x0200029C RID: 668
		// (Invoke) Token: 0x06001F97 RID: 8087
		public delegate void TransitionFunctionColor(Styles style, float delta, Color a, Color b);

		// Token: 0x0200029D RID: 669
		// (Invoke) Token: 0x06001F9B RID: 8091
		public delegate void TransitionFunctionFloat(Styles style, float delta, float a, float b);

		// Token: 0x0200029E RID: 670
		// (Invoke) Token: 0x06001F9F RID: 8095
		public delegate void TransitionFunctionShadows(Styles style, float delta, ShadowList a, ShadowList b);

		// Token: 0x0200029F RID: 671
		// (Invoke) Token: 0x06001FA3 RID: 8099
		public delegate void TransitionFunctionTransform(Styles style, float delta, PanelTransform? a, PanelTransform? b);

		// Token: 0x020002A0 RID: 672
		public struct Entry
		{
			// Token: 0x040012E7 RID: 4839
			public string type;

			// Token: 0x040012E8 RID: 4840
			public string property;

			// Token: 0x040012E9 RID: 4841
			public float startTime;

			// Token: 0x040012EA RID: 4842
			public float length;

			// Token: 0x040012EB RID: 4843
			public Transitions.TransitionFunction action;

			// Token: 0x040012EC RID: 4844
			public Easing.Function ease;
		}
	}
}
