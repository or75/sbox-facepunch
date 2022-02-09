using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Steamworks.Data;

namespace Steamworks.ServerList
{
	// Token: 0x020000C8 RID: 200
	internal class IpList : Internet
	{
		// Token: 0x0600075D RID: 1885 RVA: 0x0000C7B2 File Offset: 0x0000A9B2
		internal IpList(IEnumerable<string> list)
		{
			this.Ips.AddRange(list);
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x0000C7D1 File Offset: 0x0000A9D1
		internal IpList(params string[] list)
		{
			this.Ips.AddRange(list);
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0000C7F0 File Offset: 0x0000A9F0
		internal override async Task<bool> RunQueryAsync(float timeoutSeconds = 10f)
		{
			int blockSize = 16;
			int pointer = 0;
			string[] ips = this.Ips.ToArray();
			for (;;)
			{
				IEnumerable<string> sublist = ips.Skip(pointer).Take(blockSize);
				if (sublist.Count<string>() == 0)
				{
					break;
				}
				using (Internet list = new Internet())
				{
					list.AddFilter("or", sublist.Count<string>().ToString());
					foreach (string server in sublist)
					{
						list.AddFilter("gameaddr", server);
					}
					await list.RunQueryAsync(timeoutSeconds);
					if (this.wantsCancel)
					{
						return false;
					}
					this.Responsive.AddRange(list.Responsive);
					this.Responsive = this.Responsive.Distinct<ServerInfo>().ToList<ServerInfo>();
					this.Unresponsive.AddRange(list.Unresponsive);
					this.Unresponsive = this.Unresponsive.Distinct<ServerInfo>().ToList<ServerInfo>();
				}
				Internet list = null;
				pointer += sublist.Count<string>();
				base.InvokeChanges();
				sublist = null;
			}
			return true;
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x0000C83B File Offset: 0x0000AA3B
		internal override void Cancel()
		{
			this.wantsCancel = true;
		}

		// Token: 0x0400097D RID: 2429
		internal List<string> Ips = new List<string>();

		// Token: 0x0400097E RID: 2430
		private bool wantsCancel;
	}
}
