using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Steamworks.Data;

namespace Steamworks.ServerList
{
	// Token: 0x020000C3 RID: 195
	internal abstract class Base : IDisposable
	{
		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600073C RID: 1852 RVA: 0x0000C2F6 File Offset: 0x0000A4F6
		internal static ISteamMatchmakingServers Internal
		{
			get
			{
				return SteamMatchmakingServers.Internal;
			}
		}

		/// <summary>
		/// Which app we're querying. Defaults to the current app.
		/// </summary>
		// Token: 0x17000085 RID: 133
		// (get) Token: 0x0600073D RID: 1853 RVA: 0x0000C2FD File Offset: 0x0000A4FD
		// (set) Token: 0x0600073E RID: 1854 RVA: 0x0000C305 File Offset: 0x0000A505
		internal AppId AppId { get; set; }

		/// <summary>
		/// When a new server is added, this function will get called
		/// </summary>
		// Token: 0x14000036 RID: 54
		// (add) Token: 0x0600073F RID: 1855 RVA: 0x0000C310 File Offset: 0x0000A510
		// (remove) Token: 0x06000740 RID: 1856 RVA: 0x0000C348 File Offset: 0x0000A548
		internal event Action OnChanges;

		/// <summary>
		/// Called for every responsive server
		/// </summary>
		// Token: 0x14000037 RID: 55
		// (add) Token: 0x06000741 RID: 1857 RVA: 0x0000C380 File Offset: 0x0000A580
		// (remove) Token: 0x06000742 RID: 1858 RVA: 0x0000C3B8 File Offset: 0x0000A5B8
		internal event Action<ServerInfo> OnResponsiveServer;

		// Token: 0x06000743 RID: 1859 RVA: 0x0000C3ED File Offset: 0x0000A5ED
		internal Base()
		{
			this.AppId = SteamClient.AppId;
		}

		/// <summary>
		/// Query the server list. Task result will be true when finished
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000744 RID: 1860 RVA: 0x0000C42C File Offset: 0x0000A62C
		internal virtual async Task<bool> RunQueryAsync(float timeoutSeconds = 10f)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			this.Reset();
			this.LaunchQuery();
			HServerListRequest thisRequest = this.request;
			while (this.IsRefreshing)
			{
				await Task.Delay(33);
				bool result;
				if (this.request.Value == IntPtr.Zero || thisRequest.Value != this.request.Value)
				{
					result = false;
				}
				else if (!SteamClient.IsValid)
				{
					result = false;
				}
				else
				{
					int count = this.Responsive.Count;
					this.UpdatePending();
					this.UpdateResponsive();
					if (count != this.Responsive.Count)
					{
						this.InvokeChanges();
					}
					if (stopwatch.Elapsed.TotalSeconds <= (double)timeoutSeconds)
					{
						continue;
					}
					break;
				}
				return result;
			}
			this.MovePendingToUnresponsive();
			this.InvokeChanges();
			return true;
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x0000C477 File Offset: 0x0000A677
		internal virtual void Cancel()
		{
			Base.Internal.CancelQuery(this.request);
		}

		// Token: 0x06000746 RID: 1862
		internal abstract void LaunchQuery();

		// Token: 0x06000747 RID: 1863 RVA: 0x0000C489 File Offset: 0x0000A689
		internal virtual MatchMakingKeyValuePair[] GetFilters()
		{
			return this.filters.ToArray();
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x0000C498 File Offset: 0x0000A698
		internal void AddFilter(string key, string value)
		{
			this.filters.Add(new MatchMakingKeyValuePair
			{
				Key = key,
				Value = value
			});
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000749 RID: 1865 RVA: 0x0000C4C9 File Offset: 0x0000A6C9
		internal int Count
		{
			get
			{
				return Base.Internal.GetServerCount(this.request);
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600074A RID: 1866 RVA: 0x0000C4DB File Offset: 0x0000A6DB
		internal bool IsRefreshing
		{
			get
			{
				return this.request.Value != IntPtr.Zero && Base.Internal.IsRefreshing(this.request);
			}
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x0000C506 File Offset: 0x0000A706
		private void Reset()
		{
			this.ReleaseQuery();
			this.LastCount = 0;
			this.watchList.Clear();
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x0000C520 File Offset: 0x0000A720
		private void ReleaseQuery()
		{
			if (this.request.Value != IntPtr.Zero)
			{
				this.Cancel();
				Base.Internal.ReleaseRequest(this.request);
				this.request = IntPtr.Zero;
			}
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x0000C55F File Offset: 0x0000A75F
		public void Dispose()
		{
			this.ReleaseQuery();
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x0000C567 File Offset: 0x0000A767
		internal void InvokeChanges()
		{
			Action onChanges = this.OnChanges;
			if (onChanges == null)
			{
				return;
			}
			onChanges();
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x0000C57C File Offset: 0x0000A77C
		private void UpdatePending()
		{
			int count = this.Count;
			if (count == this.LastCount)
			{
				return;
			}
			for (int i = this.LastCount; i < count; i++)
			{
				this.watchList.Add(i);
			}
			this.LastCount = count;
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x0000C5BE File Offset: 0x0000A7BE
		internal void UpdateResponsive()
		{
			this.watchList.RemoveAll(delegate(int x)
			{
				gameserveritem_t info = Base.Internal.GetServerDetails(this.request, x);
				if (info.HadSuccessfulResponse)
				{
					this.OnServer(ServerInfo.From(info), info.HadSuccessfulResponse);
					return true;
				}
				return false;
			});
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x0000C5D8 File Offset: 0x0000A7D8
		private void MovePendingToUnresponsive()
		{
			this.watchList.RemoveAll(delegate(int x)
			{
				gameserveritem_t info = Base.Internal.GetServerDetails(this.request, x);
				this.OnServer(ServerInfo.From(info), info.HadSuccessfulResponse);
				return true;
			});
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x0000C5F2 File Offset: 0x0000A7F2
		private void OnServer(ServerInfo serverInfo, bool responded)
		{
			if (!responded)
			{
				this.Unresponsive.Add(serverInfo);
				return;
			}
			this.Responsive.Add(serverInfo);
			Action<ServerInfo> onResponsiveServer = this.OnResponsiveServer;
			if (onResponsiveServer == null)
			{
				return;
			}
			onResponsiveServer(serverInfo);
		}

		/// <summary>
		/// A list of servers that responded. If you're only interested in servers that responded since you
		/// last updated, then simply clear this list.
		/// </summary>
		// Token: 0x04000977 RID: 2423
		internal List<ServerInfo> Responsive = new List<ServerInfo>();

		/// <summary>
		/// A list of servers that were in the master list but didn't respond. 
		/// </summary>
		// Token: 0x04000978 RID: 2424
		internal List<ServerInfo> Unresponsive = new List<ServerInfo>();

		// Token: 0x04000979 RID: 2425
		internal HServerListRequest request;

		// Token: 0x0400097A RID: 2426
		internal List<MatchMakingKeyValuePair> filters = new List<MatchMakingKeyValuePair>();

		// Token: 0x0400097B RID: 2427
		internal List<int> watchList = new List<int>();

		// Token: 0x0400097C RID: 2428
		internal int LastCount;
	}
}
