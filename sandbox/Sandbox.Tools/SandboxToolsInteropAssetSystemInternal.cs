using System;
using System.Runtime.CompilerServices;
using Tools;

// Token: 0x02000007 RID: 7
internal static class SandboxToolsInteropAssetSystemInternal
{
	// Token: 0x06000006 RID: 6 RVA: 0x000020A4 File Offset: 0x000002A4
	public static int Convert(Type t)
	{
		if (typeof(Button).IsAssignableFrom(t))
		{
			return -864558426;
		}
		if (typeof(CheckBox).IsAssignableFrom(t))
		{
			return -1654626349;
		}
		if (typeof(ComboBox).IsAssignableFrom(t))
		{
			return 297862217;
		}
		if (typeof(DockWidget).IsAssignableFrom(t))
		{
			return -482099785;
		}
		if (typeof(Frame).IsAssignableFrom(t))
		{
			return -953212635;
		}
		if (typeof(GraphicsView).IsAssignableFrom(t))
		{
			return 1357986336;
		}
		if (typeof(LineEdit).IsAssignableFrom(t))
		{
			return 1556294154;
		}
		if (typeof(ListView).IsAssignableFrom(t))
		{
			return -1998446273;
		}
		if (typeof(MenuBar).IsAssignableFrom(t))
		{
			return -1203280446;
		}
		if (typeof(StatusBar).IsAssignableFrom(t))
		{
			return -185122651;
		}
		if (typeof(TextEdit).IsAssignableFrom(t))
		{
			return -1204192655;
		}
		if (typeof(ToolBar).IsAssignableFrom(t))
		{
			return -1339434871;
		}
		if (typeof(TreeView).IsAssignableFrom(t))
		{
			return 953657963;
		}
		if (typeof(Window).IsAssignableFrom(t))
		{
			return -1682846380;
		}
		if (typeof(DataModel).IsAssignableFrom(t))
		{
			return 442436975;
		}
		if (typeof(EventFilter).IsAssignableFrom(t))
		{
			return 945310636;
		}
		if (typeof(GraphicsItem).IsAssignableFrom(t))
		{
			return 1844902176;
		}
		if (typeof(GraphicsWidget).IsAssignableFrom(t))
		{
			return -590035167;
		}
		if (typeof(Option).IsAssignableFrom(t))
		{
			return 1073689443;
		}
		if (typeof(TrayIcon).IsAssignableFrom(t))
		{
			return -2083412611;
		}
		if (typeof(Widget).IsAssignableFrom(t))
		{
			return -532958444;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
		defaultInterpolatedStringHandler.AppendLiteral("Can't handle type ");
		defaultInterpolatedStringHandler.AppendFormatted<Type>(t);
		throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
	}
}
