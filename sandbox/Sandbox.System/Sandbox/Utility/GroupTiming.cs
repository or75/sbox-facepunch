using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Sandbox.Internal;

namespace Sandbox.Utility
{
	// Token: 0x02000067 RID: 103
	public class GroupTiming
	{
		// Token: 0x0600048E RID: 1166 RVA: 0x00020F93 File Offset: 0x0001F193
		public IDisposable Record(string v)
		{
			return new GroupTiming.Section(v, this);
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x00020FA4 File Offset: 0x0001F1A4
		public string GetFormattedResults(string title)
		{
			StringBuilder sb = new StringBuilder();
			int left = 35;
			int right = 10;
			int w = left + right + 6;
			int h = w / 2;
			sb.AppendLine(new string(' ', h - title.Length / 2) + title);
			sb.AppendLine(new string('-', w));
			foreach (GroupTiming.Section section in this.Sections)
			{
				string c = string.Format("{0:N0}ms", section.duration);
				sb.AppendLine(string.Concat(new string[]
				{
					"|",
					new string(' ', left - section.name.Length),
					section.name,
					" | ",
					new string(' ', right - c.Length),
					c,
					" |"
				}));
			}
			sb.AppendLine(new string('-', w));
			string total = string.Format("{0:N0}ms", this.Stopwatch.Elapsed.TotalMilliseconds);
			sb.AppendLine(string.Concat(new string[]
			{
				" ",
				new string(' ', left),
				"   ",
				new string(' ', right - total.Length),
				total,
				" "
			}));
			return sb.ToString();
		}

		// Token: 0x0400092E RID: 2350
		private Stopwatch Stopwatch = Stopwatch.StartNew();

		// Token: 0x0400092F RID: 2351
		private List<GroupTiming.Section> Sections = new List<GroupTiming.Section>();

		// Token: 0x02000090 RID: 144
		internal struct Section : IDisposable
		{
			// Token: 0x1700011F RID: 287
			// (get) Token: 0x0600054D RID: 1357 RVA: 0x000231C7 File Offset: 0x000213C7
			public double duration
			{
				get
				{
					return Math.Floor(this.EndMs - this.StartMs);
				}
			}

			// Token: 0x0600054E RID: 1358 RVA: 0x000231DC File Offset: 0x000213DC
			public Section(string name, GroupTiming group)
			{
				this.name = name.Truncate(32, null);
				this.group = group;
				this.StartMs = group.Stopwatch.Elapsed.TotalMilliseconds;
				this.EndMs = this.StartMs;
			}

			// Token: 0x0600054F RID: 1359 RVA: 0x00023224 File Offset: 0x00021424
			public void Dispose()
			{
				this.EndMs = this.group.Stopwatch.Elapsed.TotalMilliseconds;
				this.group.Sections.Add(this);
				int left = 40;
				string c = string.Format("{0:N0}ms", this.duration);
				GlobalSystemNamespace.Log.Trace(FormattableStringFactory.Create("{0}{1} : {2}", new object[]
				{
					new string(' ', left - this.name.Length),
					this.name,
					c
				}));
			}

			// Token: 0x040009A4 RID: 2468
			public string name;

			// Token: 0x040009A5 RID: 2469
			public GroupTiming group;

			// Token: 0x040009A6 RID: 2470
			public double StartMs;

			// Token: 0x040009A7 RID: 2471
			public double EndMs;
		}
	}
}
