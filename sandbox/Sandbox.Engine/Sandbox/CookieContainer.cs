using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Timers;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x02000295 RID: 661
	public class CookieContainer
	{
		// Token: 0x060010C3 RID: 4291 RVA: 0x0001F2AE File Offset: 0x0001D4AE
		internal CookieContainer(string name)
		{
			this.Name = name;
			this.Load();
		}

		/// <summary>
		/// Set a cookie to be stored between sessions. The cookie will expire one month
		/// from when it was set.
		/// </summary>
		// Token: 0x060010C4 RID: 4292 RVA: 0x0001F2C4 File Offset: 0x0001D4C4
		public void SetString(string key, string value)
		{
			if (this.CookieCache == null)
			{
				return;
			}
			this.CookieCache[key] = new CookieItem
			{
				Value = value,
				Timeout = DateTimeOffset.Now.AddDays(30.0).ToUnixTimeSeconds()
			};
		}

		/// <summary>
		/// Get a stored session cookie.
		/// </summary>
		// Token: 0x060010C5 RID: 4293 RVA: 0x0001F31C File Offset: 0x0001D51C
		public string GetString(string key, string fallback = "")
		{
			if (this.CookieCache == null)
			{
				return fallback;
			}
			CookieItem item;
			if (this.CookieCache.TryGetValue(key, out item))
			{
				return item.Value;
			}
			return fallback;
		}

		/// <summary>
		/// Get a stored session cookie.
		/// </summary>
		// Token: 0x060010C6 RID: 4294 RVA: 0x0001F34C File Offset: 0x0001D54C
		public bool TryGetString(string key, out string val)
		{
			val = null;
			if (this.CookieCache == null)
			{
				return false;
			}
			CookieItem item;
			if (this.CookieCache.TryGetValue(key, out item))
			{
				val = item.Value;
				return true;
			}
			return false;
		}

		/// <summary>
		/// Load JSON encodable data from cookies
		/// </summary>
		// Token: 0x060010C7 RID: 4295 RVA: 0x0001F384 File Offset: 0x0001D584
		public T Get<T>(string key, T fallback)
		{
			if (this.CookieCache == null)
			{
				return fallback;
			}
			string json = this.GetString(key, null);
			if (json == null)
			{
				return fallback;
			}
			T result;
			try
			{
				result = JsonSerializer.Deserialize<T>(json, null);
			}
			catch (Exception)
			{
				result = fallback;
			}
			return result;
		}

		/// <summary>
		/// Set JSON encodable object to data
		/// </summary>
		// Token: 0x060010C8 RID: 4296 RVA: 0x0001F3CC File Offset: 0x0001D5CC
		public void Set<T>(string key, T value)
		{
			if (this.CookieCache == null)
			{
				return;
			}
			this.SetString(key, JsonSerializer.Serialize<T>(value, null));
		}

		// Token: 0x060010C9 RID: 4297 RVA: 0x0001F3E8 File Offset: 0x0001D5E8
		private void ClearExpired()
		{
			if (this.CookieCache == null)
			{
				return;
			}
			List<string> expiredKeys = new List<string>();
			long unixTime = DateTimeOffset.Now.ToUnixTimeSeconds();
			foreach (KeyValuePair<string, CookieItem> kv in this.CookieCache)
			{
				if (unixTime >= kv.Value.Timeout)
				{
					expiredKeys.Add(kv.Key);
				}
			}
			foreach (string key in expiredKeys)
			{
				this.CookieCache.Remove(key);
			}
			if (expiredKeys.Count > 0)
			{
				GlobalSystemNamespace.Log.Info(FormattableStringFactory.Create("Clearing {0} expired Cookies", new object[] { expiredKeys.Count }));
			}
		}

		// Token: 0x060010CA RID: 4298 RVA: 0x0001F4EC File Offset: 0x0001D6EC
		private void StartTimer()
		{
			if (this.Timer != null)
			{
				return;
			}
			this.Timer = new Timer();
			this.Timer.Elapsed += this.OnTimerElapsed;
			this.Timer.Interval = 60000.0;
			this.Timer.Start();
		}

		// Token: 0x060010CB RID: 4299 RVA: 0x0001F543 File Offset: 0x0001D743
		internal void StopTimer()
		{
			if (this.Timer == null)
			{
				return;
			}
			this.Timer.Dispose();
			this.Timer = null;
		}

		// Token: 0x060010CC RID: 4300 RVA: 0x0001F560 File Offset: 0x0001D760
		private void OnTimerElapsed(object sender, ElapsedEventArgs e)
		{
			this.Save();
		}

		// Token: 0x060010CD RID: 4301 RVA: 0x0001F568 File Offset: 0x0001D768
		private void Load()
		{
			if (this.CookieCache == null)
			{
				string fn = this.Name + ".cookies.json";
				if (!EngineFileSystem.Config.FileExists(fn))
				{
					fn = this.Name + ".cookies";
				}
				this.CookieCache = EngineFileSystem.Config.ReadJsonOrDefault<Dictionary<string, CookieItem>>(fn, null);
			}
			if (this.CookieCache == null)
			{
				this.CookieCache = new Dictionary<string, CookieItem>();
			}
			this.ClearExpired();
			this.StartTimer();
			if (EngineFileSystem.Config.FileExists(this.Name + ".cookies"))
			{
				EngineFileSystem.Config.DeleteFile(this.Name + ".cookies");
				this.Save();
			}
		}

		// Token: 0x060010CE RID: 4302 RVA: 0x0001F61C File Offset: 0x0001D81C
		internal void Save()
		{
			if (this.CookieCache == null)
			{
				return;
			}
			this.ClearExpired();
			EngineFileSystem.Config.WriteAllText(this.Name + ".cookies.json", JsonSerializer.Serialize<Dictionary<string, CookieItem>>(this.CookieCache, new JsonSerializerOptions
			{
				WriteIndented = true
			}));
		}

		// Token: 0x0400129C RID: 4764
		private Dictionary<string, CookieItem> CookieCache;

		// Token: 0x0400129D RID: 4765
		private Timer Timer;

		// Token: 0x0400129E RID: 4766
		private string Name;
	}
}
