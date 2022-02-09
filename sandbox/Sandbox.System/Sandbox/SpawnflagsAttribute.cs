using System;

namespace Sandbox
{
	// Token: 0x02000036 RID: 54
	[AttributeUsage(AttributeTargets.Enum)]
	public class SpawnflagsAttribute : FlagsAttribute
	{
		/// <summary>
		/// The default values for the spawnflags
		/// </summary>
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060002EE RID: 750 RVA: 0x0000BAC0 File Offset: 0x00009CC0
		// (set) Token: 0x060002EF RID: 751 RVA: 0x0000BAC8 File Offset: 0x00009CC8
		public int Default { get; set; }

		// Token: 0x060002F0 RID: 752 RVA: 0x0000BAD1 File Offset: 0x00009CD1
		public SpawnflagsAttribute()
		{
			this.Default = 0;
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0000BAE0 File Offset: 0x00009CE0
		public SpawnflagsAttribute(int defaultFlags)
		{
			this.Default = defaultFlags;
		}
	}
}
