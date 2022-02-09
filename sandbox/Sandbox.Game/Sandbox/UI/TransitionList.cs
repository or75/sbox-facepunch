using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.UI
{
	/// <summary>
	/// Utility to create a transition by comparing the 
	/// panel style before and after the scope
	/// </summary>
	// Token: 0x02000113 RID: 275
	public class TransitionList
	{
		// Token: 0x060015A5 RID: 5541 RVA: 0x00056020 File Offset: 0x00054220
		internal void AddTransitions(TransitionList transitions)
		{
			foreach (TransitionDesc t in transitions.List)
			{
				this.Add(t);
			}
		}

		// Token: 0x060015A6 RID: 5542 RVA: 0x00056074 File Offset: 0x00054274
		internal void Add(TransitionDesc t)
		{
			TransitionDesc i = this.List.FirstOrDefault((TransitionDesc x) => x.Property == t.Property);
			if (t.Delay != null)
			{
				i.Delay = t.Delay;
			}
			if (t.TimingFunction != null)
			{
				i.TimingFunction = t.TimingFunction;
			}
			if (t.Property != null)
			{
				i.Property = t.Property;
			}
			if (t.Duration != null)
			{
				i.Duration = t.Duration;
			}
			this.List.RemoveAll((TransitionDesc x) => x.Property == t.Property);
			this.List.Add(i);
		}

		// Token: 0x060015A7 RID: 5543 RVA: 0x00056150 File Offset: 0x00054350
		public void Clear()
		{
			this.List.Clear();
		}

		// Token: 0x04000545 RID: 1349
		public List<TransitionDesc> List = new List<TransitionDesc>();
	}
}
