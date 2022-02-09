using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sandbox.Engine
{
	// Token: 0x02000301 RID: 769
	[Hotload.SkipAttribute]
	internal class MinidumpReporter
	{
		// Token: 0x0600147C RID: 5244 RVA: 0x0002BCDE File Offset: 0x00029EDE
		public MinidumpReporter()
		{
			this.ProcessAll();
		}

		// Token: 0x0600147D RID: 5245 RVA: 0x0002BCF0 File Offset: 0x00029EF0
		public async Task ProcessAll()
		{
			await this.ProcessFiles("*.mdmp");
			await this.ProcessFiles("*.dmp");
		}

		// Token: 0x0600147E RID: 5246 RVA: 0x0002BD34 File Offset: 0x00029F34
		public async Task ProcessFiles(string glob)
		{
			IEnumerable<string> files = Directory.EnumerateFiles(Environment.CurrentDirectory, glob);
			foreach (string file in files)
			{
				using (HttpClient client = new HttpClient())
				{
					using (MultipartFormDataContent content = new MultipartFormDataContent())
					{
						try
						{
							StreamContent mdmp = new StreamContent(new FileStream(file, FileMode.Open, FileAccess.Read));
							content.Add(mdmp, "upload_file_minidump", Path.GetFileName(file));
							await client.PostAsync(MinidumpReporter.EndPoint, content);
						}
						catch (Exception)
						{
						}
					}
					MultipartFormDataContent content = null;
				}
				HttpClient client = null;
				File.Delete(file);
				file = null;
			}
			IEnumerator<string> enumerator = null;
		}

		// Token: 0x04001551 RID: 5457
		private static string EndPoint = "https://o13219.ingest.sentry.io/api/5730657/minidump/?sentry_key=475eb60c33874416b197b0e2b2e30931";
	}
}
