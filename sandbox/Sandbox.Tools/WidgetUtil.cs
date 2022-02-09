using System;
using Native;
using Sandbox;
using Tools;

// Token: 0x02000032 RID: 50
internal static class WidgetUtil
{
	// Token: 0x06000461 RID: 1121 RVA: 0x0000C3B8 File Offset: 0x0000A5B8
	internal static void OnObject_Destroyed(Native.QObject obj, IntPtr method)
	{
		method wdgetU_OnObject_Destroyed = WidgetUtil.__N.WdgetU_OnObject_Destroyed;
		calli(System.Void(System.IntPtr,System.IntPtr), obj, method, wdgetU_OnObject_Destroyed);
	}

	// Token: 0x06000462 RID: 1122 RVA: 0x0000C3D8 File Offset: 0x0000A5D8
	internal static void OnMenu_AboutToShow(QMenu obj, IntPtr method)
	{
		method wdgetU_OnMenu_AboutToShow = WidgetUtil.__N.WdgetU_OnMenu_AboutToShow;
		calli(System.Void(System.IntPtr,System.IntPtr), obj, method, wdgetU_OnMenu_AboutToShow);
	}

	// Token: 0x06000463 RID: 1123 RVA: 0x0000C3F8 File Offset: 0x0000A5F8
	internal static void OnMenu_AboutToHide(QMenu obj, IntPtr method)
	{
		method wdgetU_OnMenu_AboutToHide = WidgetUtil.__N.WdgetU_OnMenu_AboutToHide;
		calli(System.Void(System.IntPtr,System.IntPtr), obj, method, wdgetU_OnMenu_AboutToHide);
	}

	// Token: 0x06000464 RID: 1124 RVA: 0x0000C418 File Offset: 0x0000A618
	internal static void AddSearchPath(string full)
	{
		method wdgetU_AddSearchPath = WidgetUtil.__N.WdgetU_AddSearchPath;
		calli(System.Void(System.IntPtr), Interop.GetPointer(full), wdgetU_AddSearchPath);
	}

	// Token: 0x06000465 RID: 1125 RVA: 0x0000C438 File Offset: 0x0000A638
	internal static void RemoveSearchPath(string full)
	{
		method wdgetU_RemoveSearchPath = WidgetUtil.__N.WdgetU_RemoveSearchPath;
		calli(System.Void(System.IntPtr), Interop.GetPointer(full), wdgetU_RemoveSearchPath);
	}

	// Token: 0x06000466 RID: 1126 RVA: 0x0000C458 File Offset: 0x0000A658
	internal unsafe static int GetChildren(Native.QObject obj, Native.QObject[] ArrayOfchildrens, int max)
	{
		if (ArrayOfchildrens == null)
		{
			Native.QObject* ArrayOfchildrens_array_ptr = null;
			method wdgetU_GetChildren = WidgetUtil.__N.WdgetU_GetChildren;
			return calli(System.Int32(System.IntPtr,Native.QObject*,System.Int32), obj, ArrayOfchildrens_array_ptr, max, wdgetU_GetChildren);
		}
		fixed (Native.QObject* ptr = &ArrayOfchildrens[0])
		{
			Native.QObject* ArrayOfchildrens_array_ptr2 = ptr;
			method wdgetU_GetChildren = WidgetUtil.__N.WdgetU_GetChildren;
			return calli(System.Int32(System.IntPtr,Native.QObject*,System.Int32), obj, ArrayOfchildrens_array_ptr2, max, wdgetU_GetChildren);
		}
	}

	// Token: 0x06000467 RID: 1127 RVA: 0x0000C4A0 File Offset: 0x0000A6A0
	internal static QGraphicsScene CreateGraphicsScene(Native.QObject parent, GraphicsView managedObject)
	{
		method wdgetU_CreateGraphicsScene = WidgetUtil.__N.WdgetU_CreateGraphicsScene;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (managedObject == null) ? 0U : InteropSystem.GetAddress<GraphicsView>(managedObject, true), wdgetU_CreateGraphicsScene);
	}

	// Token: 0x06000468 RID: 1128 RVA: 0x0000C4D4 File Offset: 0x0000A6D4
	internal static QGraphicsView CreateGraphicsView(QWidget parent, GraphicsView managedObject)
	{
		method wdgetU_CreateGraphicsView = WidgetUtil.__N.WdgetU_CreateGraphicsView;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (managedObject == null) ? 0U : InteropSystem.GetAddress<GraphicsView>(managedObject, true), wdgetU_CreateGraphicsView);
	}

	// Token: 0x06000469 RID: 1129 RVA: 0x0000C508 File Offset: 0x0000A708
	internal static QGraphicsProxyWidget CreateGraphicsProxy(QGraphicsItem parent, GraphicsWidget managedObject)
	{
		method wdgetU_CreateGraphicsProxy = WidgetUtil.__N.WdgetU_CreateGraphicsProxy;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (managedObject == null) ? 0U : InteropSystem.GetAddress<GraphicsWidget>(managedObject, true), wdgetU_CreateGraphicsProxy);
	}

	// Token: 0x0600046A RID: 1130 RVA: 0x0000C53C File Offset: 0x0000A73C
	internal static QWidget CreateMainWindowWidget(QWidget parent)
	{
		method wdgetU_CreateMainWindowWidget = WidgetUtil.__N.WdgetU_CreateMainWindowWidget;
		return calli(System.IntPtr(System.IntPtr), parent, wdgetU_CreateMainWindowWidget);
	}

	// Token: 0x0600046B RID: 1131 RVA: 0x0000C560 File Offset: 0x0000A760
	internal static void PostKeyEvent(QWidget target, int key)
	{
		method wdgetU_PostKeyEvent = WidgetUtil.__N.WdgetU_PostKeyEvent;
		calli(System.Void(System.IntPtr,System.Int32), target, key, wdgetU_PostKeyEvent);
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x0000C580 File Offset: 0x0000A780
	internal static void PaintSetFont(QPainter painter, string fontName, int size, int weight, bool italic, bool heightInPixels)
	{
		method wdgetU_PaintSetFont = WidgetUtil.__N.WdgetU_PaintSetFont;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Int32,System.Int32,System.Int32,System.Int32), painter, Interop.GetPointer(fontName), size, weight, italic ? 1 : 0, heightInPixels ? 1 : 0, wdgetU_PaintSetFont);
	}

	// Token: 0x02000102 RID: 258
	internal static class __N
	{
		// Token: 0x04000787 RID: 1927
		internal static method WdgetU_OnObject_Destroyed;

		// Token: 0x04000788 RID: 1928
		internal static method WdgetU_OnMenu_AboutToShow;

		// Token: 0x04000789 RID: 1929
		internal static method WdgetU_OnMenu_AboutToHide;

		// Token: 0x0400078A RID: 1930
		internal static method WdgetU_AddSearchPath;

		// Token: 0x0400078B RID: 1931
		internal static method WdgetU_RemoveSearchPath;

		// Token: 0x0400078C RID: 1932
		internal static method WdgetU_GetChildren;

		// Token: 0x0400078D RID: 1933
		internal static method WdgetU_CreateGraphicsScene;

		// Token: 0x0400078E RID: 1934
		internal static method WdgetU_CreateGraphicsView;

		// Token: 0x0400078F RID: 1935
		internal static method WdgetU_CreateGraphicsProxy;

		// Token: 0x04000790 RID: 1936
		internal static method WdgetU_CreateMainWindowWidget;

		// Token: 0x04000791 RID: 1937
		internal static method WdgetU_PostKeyEvent;

		// Token: 0x04000792 RID: 1938
		internal static method WdgetU_PaintSetFont;
	}
}
