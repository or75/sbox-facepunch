using System;

namespace Sandbox
{
	/// <summary>
	/// Mark this property as a ranged float/int. In inspector we'll be able to create a slider
	/// instead of a text entry.
	/// TODO: Replace this with the System.ComponentModel.DataAnnotations.Range one - move step and clamped to their own attributes
	/// </summary>
	// Token: 0x02000038 RID: 56
	[AttributeUsage(AttributeTargets.Property)]
	public class RangeAttribute : Attribute
	{
		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x0000BB28 File Offset: 0x00009D28
		public float Min { get; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x0000BB30 File Offset: 0x00009D30
		public float Max { get; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060002FA RID: 762 RVA: 0x0000BB38 File Offset: 0x00009D38
		public float Step { get; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060002FB RID: 763 RVA: 0x0000BB40 File Offset: 0x00009D40
		public bool Clamped { get; }

		// Token: 0x060002FC RID: 764 RVA: 0x0000BB48 File Offset: 0x00009D48
		public RangeAttribute(float min, float max, float step = 0.01f, bool clamped = true)
		{
			this.Min = min;
			this.Max = max;
			this.Step = step;
			this.Clamped = clamped;
		}
	}
}
