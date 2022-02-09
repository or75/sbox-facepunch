using System;

namespace Sandbox.Engine
{
	// Token: 0x02000300 RID: 768
	internal struct MouseMode
	{
		/// <summary>
		/// Want the mouse cursor to be visible
		/// </summary>
		// Token: 0x0400154E RID: 5454
		public bool Visible;

		/// <summary>
		/// Want the mouse cursor to swallow input
		/// </summary>
		// Token: 0x0400154F RID: 5455
		public bool Input;

		/// <summary>
		/// Want to capture the mouse input exclusively
		/// </summary>
		// Token: 0x04001550 RID: 5456
		public bool Capture;
	}
}
