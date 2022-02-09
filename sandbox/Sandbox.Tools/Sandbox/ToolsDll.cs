using System;
using Managed.SourceAssetSytem;
using Managed.SourceTools;
using Native;
using Sandbox.Engine;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x0200006F RID: 111
	internal class ToolsDll : IToolsDll, IBaseDll
	{
		// Token: 0x06001277 RID: 4727 RVA: 0x00050744 File Offset: 0x0004E944
		void IBaseDll.Exiting()
		{
			Event.Run("app.exit");
			GlobalToolsNamespace.Cookie.Save();
			if (GlobalToolsNamespace.ToolsTrayIcon != null)
			{
				GlobalToolsNamespace.ToolsTrayIcon.Visible = false;
				GlobalToolsNamespace.ToolsTrayIcon.Destroy();
				GlobalToolsNamespace.ToolsTrayIcon = null;
			}
		}

		// Token: 0x06001278 RID: 4728 RVA: 0x0005077C File Offset: 0x0004E97C
		unsafe void IToolsDll.InteropInit(int hash, IntPtr* exported, int* struct_sizes, IntPtr* imported)
		{
			Managed.SourceTools.NativeInterop.Initialize(hash, exported, struct_sizes, imported);
		}

		// Token: 0x06001279 RID: 4729 RVA: 0x00050788 File Offset: 0x0004E988
		void IBaseDll.RunEvent(string name)
		{
			Event.Run(name);
		}

		// Token: 0x0600127A RID: 4730 RVA: 0x00050790 File Offset: 0x0004E990
		void IBaseDll.RunEvent(string name, object argument)
		{
			Event.Run<object>(name, argument);
		}

		// Token: 0x0600127B RID: 4731 RVA: 0x00050799 File Offset: 0x0004E999
		public void SetStatus(string name)
		{
			GlobalToolsNamespace.EditorWindow.StatusBar.ShowMessage(name, 5f);
			QApp.processEvents();
		}

		// Token: 0x0600127C RID: 4732 RVA: 0x000507B5 File Offset: 0x0004E9B5
		public bool ConsoleFocus()
		{
			GlobalToolsNamespace.EditorWindow.ConsoleFocus();
			return true;
		}

		// Token: 0x0600127D RID: 4733 RVA: 0x000507C2 File Offset: 0x0004E9C2
		unsafe bool IToolsDll.InitToolInterface(string name, int hash, IntPtr* exported, int* struct_sizes, IntPtr* imported)
		{
			if (name == "assetsystem")
			{
				Managed.SourceAssetSytem.NativeInterop.Initialize(hash, exported, struct_sizes, imported);
				return true;
			}
			return false;
		}
	}
}
