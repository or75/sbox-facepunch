using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Sandbox.Internal
{
	// Token: 0x0200018D RID: 397
	public sealed class Http : IDisposable
	{
		// Token: 0x06001C61 RID: 7265 RVA: 0x0007159F File Offset: 0x0006F79F
		public static bool IsAllowed(Uri uri)
		{
			return true;
		}

		// Token: 0x06001C62 RID: 7266 RVA: 0x000715A4 File Offset: 0x0006F7A4
		public static bool AreHeadersAllowed(Dictionary<string, string> headers)
		{
			if (headers == null)
			{
				return true;
			}
			bool allowed = true;
			foreach (KeyValuePair<string, string> keyValuePair in headers)
			{
				string text;
				string text2;
				keyValuePair.Deconstruct(out text, out text2);
				string key = text;
				if (Http.ForbiddenHeaders.Contains(key) || key.StartsWith("Proxy-", StringComparison.InvariantCultureIgnoreCase) || key.StartsWith("Sec-", StringComparison.InvariantCultureIgnoreCase))
				{
					GlobalGameNamespace.Log.Error(FormattableStringFactory.Create("Cannot use HTTP header: {0}", new object[] { key }));
					allowed = false;
				}
			}
			return allowed;
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x06001C63 RID: 7267 RVA: 0x0007164C File Offset: 0x0006F84C
		// (set) Token: 0x06001C64 RID: 7268 RVA: 0x00071654 File Offset: 0x0006F854
		public Uri Uri { get; private set; }

		// Token: 0x06001C65 RID: 7269 RVA: 0x0007165D File Offset: 0x0006F85D
		public Http(Uri uri)
		{
			if (!Http.IsAllowed(uri))
			{
				throw new NotSupportedException();
			}
			this.client = new HttpClient();
			this.Uri = uri;
		}

		// Token: 0x06001C66 RID: 7270 RVA: 0x00071688 File Offset: 0x0006F888
		public Task<string> GetStringAsync()
		{
			Http.<GetStringAsync>d__11 <GetStringAsync>d__;
			<GetStringAsync>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<GetStringAsync>d__.<>4__this = this;
			<GetStringAsync>d__.<>1__state = -1;
			<GetStringAsync>d__.<>t__builder.Start<Http.<GetStringAsync>d__11>(ref <GetStringAsync>d__);
			return <GetStringAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06001C67 RID: 7271 RVA: 0x000716CC File Offset: 0x0006F8CC
		public Task<byte[]> GetBytesAsync()
		{
			Http.<GetBytesAsync>d__12 <GetBytesAsync>d__;
			<GetBytesAsync>d__.<>t__builder = AsyncTaskMethodBuilder<byte[]>.Create();
			<GetBytesAsync>d__.<>4__this = this;
			<GetBytesAsync>d__.<>1__state = -1;
			<GetBytesAsync>d__.<>t__builder.Start<Http.<GetBytesAsync>d__12>(ref <GetBytesAsync>d__);
			return <GetBytesAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06001C68 RID: 7272 RVA: 0x00071710 File Offset: 0x0006F910
		public Task<Stream> GetStreamAsync()
		{
			Http.<GetStreamAsync>d__13 <GetStreamAsync>d__;
			<GetStreamAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Stream>.Create();
			<GetStreamAsync>d__.<>4__this = this;
			<GetStreamAsync>d__.<>1__state = -1;
			<GetStreamAsync>d__.<>t__builder.Start<Http.<GetStreamAsync>d__13>(ref <GetStreamAsync>d__);
			return <GetStreamAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06001C69 RID: 7273 RVA: 0x00071753 File Offset: 0x0006F953
		public void Dispose()
		{
			HttpClient httpClient = this.client;
			if (httpClient == null)
			{
				return;
			}
			httpClient.Dispose();
		}

		// Token: 0x040007AA RID: 1962
		public const string UserAgent = "facepunch-s&box";

		// Token: 0x040007AB RID: 1963
		public const string Origin = "https://sbox.facepunch.com/";

		// Token: 0x040007AC RID: 1964
		private static readonly HashSet<string> ForbiddenHeaders = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase)
		{
			"Accept-Charset", "Accept-Encoding", "Access-Control-Request-Headers", "Access-Control-Request-Method", "Connection", "Content-Length", "Date", "DNT", "Expect", "Feature-Policy",
			"Host", "Keep-Alive", "Origin", "Referer", "TE", "Trailer", "Transfer-Encoding", "Upgrade", "Via", "User-Agent"
		};

		// Token: 0x040007AD RID: 1965
		private HttpClient client;
	}
}
