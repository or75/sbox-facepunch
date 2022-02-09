using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Steamworks.Data
{
	// Token: 0x020001EC RID: 492
	internal struct Stat
	{
		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000C4E RID: 3150 RVA: 0x000118FD File Offset: 0x0000FAFD
		// (set) Token: 0x06000C4F RID: 3151 RVA: 0x00011905 File Offset: 0x0000FB05
		internal string Name { readonly get; set; }

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000C50 RID: 3152 RVA: 0x0001190E File Offset: 0x0000FB0E
		// (set) Token: 0x06000C51 RID: 3153 RVA: 0x00011916 File Offset: 0x0000FB16
		internal SteamId UserId { readonly get; set; }

		// Token: 0x06000C52 RID: 3154 RVA: 0x0001191F File Offset: 0x0000FB1F
		internal Stat(string name)
		{
			this.Name = name;
			this.UserId = 0UL;
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x00011935 File Offset: 0x0000FB35
		internal Stat(string name, SteamId user)
		{
			this.Name = name;
			this.UserId = user;
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x00011945 File Offset: 0x0000FB45
		internal void LocalUserOnly([CallerMemberName] string caller = null)
		{
			if (this.UserId == 0UL)
			{
				return;
			}
			throw new Exception("Stat." + caller + " can only be called for the local user");
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x0001196C File Offset: 0x0000FB6C
		internal double GetGlobalFloat()
		{
			double val = 0.0;
			if (SteamUserStats.Internal.GetGlobalStat(this.Name, ref val))
			{
				return val;
			}
			return 0.0;
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x000119A4 File Offset: 0x0000FBA4
		internal long GetGlobalInt()
		{
			long val = 0L;
			SteamUserStats.Internal.GetGlobalStat(this.Name, ref val);
			return val;
		}

		// Token: 0x06000C57 RID: 3159 RVA: 0x000119C8 File Offset: 0x0000FBC8
		internal async Task<long[]> GetGlobalIntDaysAsync(int days)
		{
			GlobalStatsReceived_t? result = await SteamUserStats.Internal.RequestGlobalStats(days);
			long[] result2;
			if (result == null || result.GetValueOrDefault().Result != Result.OK)
			{
				result2 = null;
			}
			else
			{
				long[] r = new long[days];
				int rows = SteamUserStats.Internal.GetGlobalStatHistory(this.Name, r, (uint)(r.Length * 8));
				if (days != rows)
				{
					r = r.Take(rows).ToArray<long>();
				}
				result2 = r;
			}
			return result2;
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x00011A18 File Offset: 0x0000FC18
		internal async Task<double[]> GetGlobalFloatDays(int days)
		{
			GlobalStatsReceived_t? result = await SteamUserStats.Internal.RequestGlobalStats(days);
			double[] result2;
			if (result == null || result.GetValueOrDefault().Result != Result.OK)
			{
				result2 = null;
			}
			else
			{
				double[] r = new double[days];
				int rows = SteamUserStats.Internal.GetGlobalStatHistory(this.Name, r, (uint)(r.Length * 8));
				if (days != rows)
				{
					r = r.Take(rows).ToArray<double>();
				}
				result2 = r;
			}
			return result2;
		}

		// Token: 0x06000C59 RID: 3161 RVA: 0x00011A68 File Offset: 0x0000FC68
		internal float GetFloat()
		{
			float val = 0f;
			if (this.UserId > 0UL)
			{
				SteamUserStats.Internal.GetUserStat(this.UserId, this.Name, ref val);
			}
			else
			{
				SteamUserStats.Internal.GetStat(this.Name, ref val);
			}
			return 0f;
		}

		// Token: 0x06000C5A RID: 3162 RVA: 0x00011AC0 File Offset: 0x0000FCC0
		internal int GetInt()
		{
			int val = 0;
			if (this.UserId > 0UL)
			{
				SteamUserStats.Internal.GetUserStat(this.UserId, this.Name, ref val);
			}
			else
			{
				SteamUserStats.Internal.GetStat(this.Name, ref val);
			}
			return val;
		}

		// Token: 0x06000C5B RID: 3163 RVA: 0x00011B0D File Offset: 0x0000FD0D
		internal bool Set(int val)
		{
			this.LocalUserOnly("Set");
			return SteamUserStats.Internal.SetStat(this.Name, val);
		}

		// Token: 0x06000C5C RID: 3164 RVA: 0x00011B2B File Offset: 0x0000FD2B
		internal bool Set(float val)
		{
			this.LocalUserOnly("Set");
			return SteamUserStats.Internal.SetStat(this.Name, val);
		}

		// Token: 0x06000C5D RID: 3165 RVA: 0x00011B49 File Offset: 0x0000FD49
		internal bool Add(int val)
		{
			this.LocalUserOnly("Add");
			return this.Set(this.GetInt() + val);
		}

		// Token: 0x06000C5E RID: 3166 RVA: 0x00011B64 File Offset: 0x0000FD64
		internal bool Add(float val)
		{
			this.LocalUserOnly("Add");
			return this.Set(this.GetFloat() + val);
		}

		// Token: 0x06000C5F RID: 3167 RVA: 0x00011B7F File Offset: 0x0000FD7F
		internal bool UpdateAverageRate(float count, float sessionlength)
		{
			this.LocalUserOnly("UpdateAverageRate");
			return SteamUserStats.Internal.UpdateAvgRateStat(this.Name, count, (double)sessionlength);
		}

		// Token: 0x06000C60 RID: 3168 RVA: 0x00011B9F File Offset: 0x0000FD9F
		internal bool Store()
		{
			this.LocalUserOnly("Store");
			return SteamUserStats.Internal.StoreStats();
		}
	}
}
