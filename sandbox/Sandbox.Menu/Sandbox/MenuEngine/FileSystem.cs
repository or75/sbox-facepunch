using System;
using System.Runtime.CompilerServices;
using NativeEngine;

namespace Sandbox.MenuEngine
{
	// Token: 0x02000012 RID: 18
	public static class FileSystem
	{
		/// <summary>
		/// Open an 'open file' dialog
		/// </summary>
		// Token: 0x0600005D RID: 93 RVA: 0x0000376C File Offset: 0x0000196C
		[NullableContext(2)]
		public static string OpenFileDialog()
		{
			Host.AssertMenu("OpenFileDialog");
			string r = WindowsGlue.FindFile();
			if (string.IsNullOrEmpty(r))
			{
				return null;
			}
			return r;
		}
	}
}
