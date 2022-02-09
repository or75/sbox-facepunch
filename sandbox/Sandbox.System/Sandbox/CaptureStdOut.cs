using System;
using System.IO;
using System.Text;

namespace Sandbox
{
	// Token: 0x02000049 RID: 73
	internal class CaptureStdOut : TextWriter
	{
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000363 RID: 867 RVA: 0x0000D339 File Offset: 0x0000B539
		// (set) Token: 0x06000364 RID: 868 RVA: 0x0000D341 File Offset: 0x0000B541
		internal bool IsErrorOut { get; set; }

		// Token: 0x06000365 RID: 869 RVA: 0x0000D34A File Offset: 0x0000B54A
		public static void Init()
		{
			Console.SetOut(new CaptureStdOut());
			Console.SetError(new CaptureStdOut
			{
				IsErrorOut = true
			});
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000366 RID: 870 RVA: 0x0000D367 File Offset: 0x0000B567
		public override Encoding Encoding
		{
			get
			{
				return Encoding.UTF8;
			}
		}

		// Token: 0x06000367 RID: 871 RVA: 0x0000D36E File Offset: 0x0000B56E
		public override void Write(string value)
		{
			if (this.IsErrorOut)
			{
				CaptureStdOut.log.Error(value);
				return;
			}
			CaptureStdOut.log.Info(value);
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0000D38F File Offset: 0x0000B58F
		public override void WriteLine(string value)
		{
			this.Write(value);
		}

		// Token: 0x06000369 RID: 873 RVA: 0x0000D398 File Offset: 0x0000B598
		public override void Write(char value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x040000BA RID: 186
		private static Logger log = Logging.GetLogger("Console");
	}
}
