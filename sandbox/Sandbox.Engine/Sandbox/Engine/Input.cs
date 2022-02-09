using System;
using NativeEngine;

namespace Sandbox.Engine
{
	// Token: 0x020002FC RID: 764
	internal static class Input
	{
		/// <summary>
		/// Returns the name of a key that is bound to this value
		/// </summary>
		// Token: 0x0600144D RID: 5197 RVA: 0x0002B356 File Offset: 0x00029556
		public static string GetKeyWithBinding(string binding)
		{
			return InputService.Key_NameForBinding(binding, 0);
		}

		/// <summary>
		/// Returns the binding for this key
		/// </summary>
		// Token: 0x0600144E RID: 5198 RVA: 0x0002B360 File Offset: 0x00029560
		public static string GetBindingForButton(string keyName)
		{
			ButtonCode code = InputSystem.StringToButtonCode(keyName);
			if (code == ButtonCode.BUTTON_CODE_INVALID)
			{
				return "";
			}
			return InputService.GetBinding(code, 0);
		}
	}
}
