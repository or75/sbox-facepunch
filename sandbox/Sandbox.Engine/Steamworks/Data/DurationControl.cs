using System;

namespace Steamworks.Data
{
	/// <summary>
	/// Sent for games with enabled anti indulgence / duration control, for enabled users. 
	/// Lets the game know whether persistent rewards or XP should be granted at normal rate, half rate, or zero rate.
	/// </summary>
	// Token: 0x020001DD RID: 477
	internal struct DurationControl
	{
		/// <summary>
		/// appid generating playtime
		/// </summary>
		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000BC4 RID: 3012 RVA: 0x0001067A File Offset: 0x0000E87A
		internal AppId Appid
		{
			get
			{
				return this._inner.Appid;
			}
		}

		/// <summary>
		/// is duration control applicable to user + game combination
		/// </summary>
		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000BC5 RID: 3013 RVA: 0x00010687 File Offset: 0x0000E887
		internal bool Applicable
		{
			get
			{
				return this._inner.Applicable;
			}
		}

		/// <summary>
		/// playtime since most recent 5 hour gap in playtime, only counting up to regulatory limit of playtime, in seconds
		/// </summary>
		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000BC6 RID: 3014 RVA: 0x00010694 File Offset: 0x0000E894
		internal TimeSpan PlaytimeInLastFiveHours
		{
			get
			{
				return TimeSpan.FromSeconds((double)this._inner.CsecsLast5h);
			}
		}

		/// <summary>
		/// playtime on current calendar day
		/// </summary>
		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000BC7 RID: 3015 RVA: 0x000106A7 File Offset: 0x0000E8A7
		internal TimeSpan PlaytimeToday
		{
			get
			{
				return TimeSpan.FromSeconds((double)this._inner.CsecsLast5h);
			}
		}

		/// <summary>
		/// recommended progress
		/// </summary>
		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000BC8 RID: 3016 RVA: 0x000106BA File Offset: 0x0000E8BA
		internal DurationControlProgress Progress
		{
			get
			{
				return this._inner.Progress;
			}
		}

		// Token: 0x04000D69 RID: 3433
		internal DurationControl_t _inner;
	}
}
