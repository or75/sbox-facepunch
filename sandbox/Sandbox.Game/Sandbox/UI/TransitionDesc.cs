using System;
using System.Runtime.CompilerServices;
using Sandbox.Internal;

namespace Sandbox.UI
{
	/// <summary>
	/// Utility to create a transition by comparing the 
	/// panel style before and after the scope
	/// </summary>
	// Token: 0x02000112 RID: 274
	public struct TransitionDesc
	{
		// Token: 0x060015A3 RID: 5539 RVA: 0x00055E58 File Offset: 0x00054058
		internal static TransitionList ParseProperty(string property, string value, TransitionList list)
		{
			Parse p = new Parse(value, "nofile");
			if (list == null)
			{
				list = new TransitionList();
			}
			if (property == "transition")
			{
				int i = 0;
				while (!p.IsEnd)
				{
					p = p.SkipWhitespaceAndNewlines(null);
					string value2 = p.ReadUntilOrEnd(",", false);
					p.Pointer++;
					TransitionDesc transition = TransitionDesc.Parse(value2);
					list.Add(transition);
					i++;
				}
				return list;
			}
			GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Didn't handle transition style: {0}", new object[] { property }));
			return null;
		}

		// Token: 0x060015A4 RID: 5540 RVA: 0x00055EEC File Offset: 0x000540EC
		private static TransitionDesc Parse(string value)
		{
			Parse p = new Parse(value, "nofile");
			TransitionDesc t = default(TransitionDesc);
			t.Delay = new float?(0f);
			p = p.SkipWhitespaceAndNewlines(null);
			t.Property = p.ReadWord(null, true).ToLower();
			if (p.IsEnd)
			{
				return t;
			}
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return t;
			}
			float duration;
			if (!p.TryReadTime(out duration))
			{
				throw new Exception("Expecting time in transition");
			}
			t.Duration = new float?(duration);
			if (p.IsEnd)
			{
				return t;
			}
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return t;
			}
			float delay;
			if (p.TryReadTime(out delay))
			{
				t.Delay = new float?(delay);
			}
			if (p.IsEnd)
			{
				return t;
			}
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return t;
			}
			t.TimingFunction = p.ReadWord(null, true);
			if (p.IsEnd)
			{
				return t;
			}
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return t;
			}
			if (p.TryReadTime(out delay))
			{
				t.Delay = new float?(delay);
			}
			return t;
		}

		// Token: 0x04000541 RID: 1345
		public string Property;

		// Token: 0x04000542 RID: 1346
		public float? Duration;

		// Token: 0x04000543 RID: 1347
		public float? Delay;

		// Token: 0x04000544 RID: 1348
		public string TimingFunction;
	}
}
