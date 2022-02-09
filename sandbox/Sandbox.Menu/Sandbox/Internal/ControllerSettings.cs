using System;
using System.Collections.Generic;
using System.Linq;
using Sandbox.Engine;

namespace Sandbox.Internal
{
	/// <summary>
	/// An abstraction of <see cref="T:Sandbox.Engine.Controller" /> for the menu.
	/// </summary>
	// Token: 0x0200000D RID: 13
	public class ControllerSettings
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000038 RID: 56 RVA: 0x0000327C File Offset: 0x0000147C
		public static IEnumerable<ControllerSettings> ConnectedControllers
		{
			get
			{
				return from c in Controller.All
					where c.Connected
					select new ControllerSettings(c);
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000032D6 File Offset: 0x000014D6
		internal ControllerSettings(Controller controller)
		{
			this.EngineController = controller;
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600003A RID: 58 RVA: 0x000032E8 File Offset: 0x000014E8
		public string Type
		{
			get
			{
				return this.EngineController.Type.ToString();
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000330E File Offset: 0x0000150E
		public void OpenBindingPanel()
		{
			Host.AssertMenu("OpenBindingPanel");
			this.EngineController.ShowBindingPanel();
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003326 File Offset: 0x00001526
		public override int GetHashCode()
		{
			return this.EngineController.GetHashCode();
		}

		// Token: 0x0400000C RID: 12
		internal Controller EngineController;
	}
}
