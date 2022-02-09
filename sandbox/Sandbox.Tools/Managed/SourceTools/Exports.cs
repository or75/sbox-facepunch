using System;
using System.Runtime.InteropServices;
using Native;
using Sandbox;
using Tools;

namespace Managed.SourceTools
{
	// Token: 0x02000068 RID: 104
	internal static class Exports
	{
		/// <summary>
		/// Tools.AboutDialog.Open( ... )
		/// </summary>
		// Token: 0x060010EF RID: 4335 RVA: 0x0002DDD8 File Offset: 0x0002BFD8
		[UnmanagedCallersOnly]
		internal static void Tools_AbtDlg_Open(IntPtr widget)
		{
			try
			{
				AboutDialog.Open(widget);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.AboutDialog", "Open", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalOnPressed( ... )
		/// </summary>
		// Token: 0x060010F0 RID: 4336 RVA: 0x0002DE18 File Offset: 0x0002C018
		[UnmanagedCallersOnly]
		internal static void Tools_Button_InternalOnPressed(uint self)
		{
			try
			{
				Button instance;
				if (InteropSystem.TryGetObject<Button>(self, out instance))
				{
					instance.InternalOnPressed();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalOnPressed", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalOnReleased( ... )
		/// </summary>
		// Token: 0x060010F1 RID: 4337 RVA: 0x0002DE5C File Offset: 0x0002C05C
		[UnmanagedCallersOnly]
		internal static void Tools_Button_InternalOnReleased(uint self)
		{
			try
			{
				Button instance;
				if (InteropSystem.TryGetObject<Button>(self, out instance))
				{
					instance.InternalOnReleased();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalOnReleased", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalOnClicked( ... )
		/// </summary>
		// Token: 0x060010F2 RID: 4338 RVA: 0x0002DEA0 File Offset: 0x0002C0A0
		[UnmanagedCallersOnly]
		internal static void Tools_Button_InternalOnClicked(uint self)
		{
			try
			{
				Button instance;
				if (InteropSystem.TryGetObject<Button>(self, out instance))
				{
					instance.InternalOnClicked();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalOnClicked", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalOnToggled( ... )
		/// </summary>
		// Token: 0x060010F3 RID: 4339 RVA: 0x0002DEE4 File Offset: 0x0002C0E4
		[UnmanagedCallersOnly]
		internal static void Tools_Button_InternalOnToggled(uint self)
		{
			try
			{
				Button instance;
				if (InteropSystem.TryGetObject<Button>(self, out instance))
				{
					instance.InternalOnToggled();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalOnToggled", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalOnEvent( ... )
		/// </summary>
		// Token: 0x060010F4 RID: 4340 RVA: 0x0002DF28 File Offset: 0x0002C128
		[UnmanagedCallersOnly]
		internal static void Tools_Button_InternalOnEvent(uint self, long e)
		{
			try
			{
				Button instance;
				if (InteropSystem.TryGetObject<Button>(self, out instance))
				{
					instance.InternalOnEvent((EventType)e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalOnEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalMousePressEvent( ... )
		/// </summary>
		// Token: 0x060010F5 RID: 4341 RVA: 0x0002DF70 File Offset: 0x0002C170
		[UnmanagedCallersOnly]
		internal static void Tools_Button_InternalMousePressEvent(uint self, IntPtr e)
		{
			try
			{
				Button instance;
				if (InteropSystem.TryGetObject<Button>(self, out instance))
				{
					instance.InternalMousePressEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalMousePressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalMouseEnterEvent( ... )
		/// </summary>
		// Token: 0x060010F6 RID: 4342 RVA: 0x0002DFBC File Offset: 0x0002C1BC
		[UnmanagedCallersOnly]
		internal static void Tools_Button_InternalMouseEnterEvent(uint self, IntPtr e)
		{
			try
			{
				Button instance;
				if (InteropSystem.TryGetObject<Button>(self, out instance))
				{
					instance.InternalMouseEnterEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalMouseEnterEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalMouseLeaveEvent( ... )
		/// </summary>
		// Token: 0x060010F7 RID: 4343 RVA: 0x0002E008 File Offset: 0x0002C208
		[UnmanagedCallersOnly]
		internal static void Tools_Button_InternalMouseLeaveEvent(uint self, IntPtr e)
		{
			try
			{
				Button instance;
				if (InteropSystem.TryGetObject<Button>(self, out instance))
				{
					instance.InternalMouseLeaveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalMouseLeaveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalMouseReleaseEvent( ... )
		/// </summary>
		// Token: 0x060010F8 RID: 4344 RVA: 0x0002E054 File Offset: 0x0002C254
		[UnmanagedCallersOnly]
		internal static void Tools_Button_InternalMouseReleaseEvent(uint self, IntPtr e)
		{
			try
			{
				Button instance;
				if (InteropSystem.TryGetObject<Button>(self, out instance))
				{
					instance.InternalMouseReleaseEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalMouseReleaseEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalMouseMoveEvent( ... )
		/// </summary>
		// Token: 0x060010F9 RID: 4345 RVA: 0x0002E0A0 File Offset: 0x0002C2A0
		[UnmanagedCallersOnly]
		internal static void Tools_Button_InternalMouseMoveEvent(uint self, IntPtr e)
		{
			try
			{
				Button instance;
				if (InteropSystem.TryGetObject<Button>(self, out instance))
				{
					instance.InternalMouseMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalMouseMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalMouseDoubleClickEvent( ... )
		/// </summary>
		// Token: 0x060010FA RID: 4346 RVA: 0x0002E0EC File Offset: 0x0002C2EC
		[UnmanagedCallersOnly]
		internal static void Tools_Button_InternalMouseDoubleClickEvent(uint self, IntPtr e)
		{
			try
			{
				Button instance;
				if (InteropSystem.TryGetObject<Button>(self, out instance))
				{
					instance.InternalMouseDoubleClickEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalMouseDoubleClickEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalWheelEvent( ... )
		/// </summary>
		// Token: 0x060010FB RID: 4347 RVA: 0x0002E138 File Offset: 0x0002C338
		[UnmanagedCallersOnly]
		internal static void Tools_Button_InternalWheelEvent(uint self, IntPtr e)
		{
			try
			{
				Button instance;
				if (InteropSystem.TryGetObject<Button>(self, out instance))
				{
					instance.InternalWheelEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalWheelEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalContextMenuEvent( ... )
		/// </summary>
		// Token: 0x060010FC RID: 4348 RVA: 0x0002E184 File Offset: 0x0002C384
		[UnmanagedCallersOnly]
		internal static void Tools_Button_InternalContextMenuEvent(uint self, IntPtr e)
		{
			try
			{
				Button instance;
				if (InteropSystem.TryGetObject<Button>(self, out instance))
				{
					instance.InternalContextMenuEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalContextMenuEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalKeyPressEvent( ... )
		/// </summary>
		// Token: 0x060010FD RID: 4349 RVA: 0x0002E1D0 File Offset: 0x0002C3D0
		[UnmanagedCallersOnly]
		internal static void Tools_Button_InternalKeyPressEvent(uint self, IntPtr pEvent)
		{
			try
			{
				Button instance;
				if (InteropSystem.TryGetObject<Button>(self, out instance))
				{
					instance.InternalKeyPressEvent(pEvent);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalKeyPressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalFocusInEvent( ... )
		/// </summary>
		// Token: 0x060010FE RID: 4350 RVA: 0x0002E21C File Offset: 0x0002C41C
		[UnmanagedCallersOnly]
		internal static void Tools_Button_InternalFocusInEvent(uint self, long reason)
		{
			try
			{
				Button instance;
				if (InteropSystem.TryGetObject<Button>(self, out instance))
				{
					instance.InternalFocusInEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalFocusInEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalFocusOutEvent( ... )
		/// </summary>
		// Token: 0x060010FF RID: 4351 RVA: 0x0002E264 File Offset: 0x0002C464
		[UnmanagedCallersOnly]
		internal static void Tools_Button_InternalFocusOutEvent(uint self, long reason)
		{
			try
			{
				Button instance;
				if (InteropSystem.TryGetObject<Button>(self, out instance))
				{
					instance.InternalFocusOutEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalFocusOutEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalOnResizeEvent( ... )
		/// </summary>
		// Token: 0x06001100 RID: 4352 RVA: 0x0002E2AC File Offset: 0x0002C4AC
		[UnmanagedCallersOnly]
		internal static void Tools_Button_InternalOnResizeEvent(uint self, IntPtr e)
		{
			try
			{
				Button instance;
				if (InteropSystem.TryGetObject<Button>(self, out instance))
				{
					instance.InternalOnResizeEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalOnResizeEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalOnMoveEvent( ... )
		/// </summary>
		// Token: 0x06001101 RID: 4353 RVA: 0x0002E2F8 File Offset: 0x0002C4F8
		[UnmanagedCallersOnly]
		internal static void Tools_Button_InternalOnMoveEvent(uint self, IntPtr e)
		{
			try
			{
				Button instance;
				if (InteropSystem.TryGetObject<Button>(self, out instance))
				{
					instance.InternalOnMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalOnMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Button.InternalPaintEvent( ... )
		/// </summary>
		// Token: 0x06001102 RID: 4354 RVA: 0x0002E344 File Offset: 0x0002C544
		[UnmanagedCallersOnly]
		internal static int Tools_Button_InternalPaintEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Button instance;
				if (!InteropSystem.TryGetObject<Button>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalPaintEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalPaintEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Button.InternalFocusNextPrevChild( ... )
		/// </summary>
		// Token: 0x06001103 RID: 4355 RVA: 0x0002E39C File Offset: 0x0002C59C
		[UnmanagedCallersOnly]
		internal static int Tools_Button_InternalFocusNextPrevChild(uint self, int next)
		{
			int result;
			try
			{
				Button instance;
				if (!InteropSystem.TryGetObject<Button>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalFocusNextPrevChild(next != 0) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalFocusNextPrevChild", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Button.InternalDragEnterEvent( ... )
		/// </summary>
		// Token: 0x06001104 RID: 4356 RVA: 0x0002E3F0 File Offset: 0x0002C5F0
		[UnmanagedCallersOnly]
		internal static int Tools_Button_InternalDragEnterEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Button instance;
				if (!InteropSystem.TryGetObject<Button>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragEnterEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalDragEnterEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Button.InternalDragMoveEvent( ... )
		/// </summary>
		// Token: 0x06001105 RID: 4357 RVA: 0x0002E448 File Offset: 0x0002C648
		[UnmanagedCallersOnly]
		internal static int Tools_Button_InternalDragMoveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Button instance;
				if (!InteropSystem.TryGetObject<Button>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragMoveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalDragMoveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Button.InternalDragLeaveEvent( ... )
		/// </summary>
		// Token: 0x06001106 RID: 4358 RVA: 0x0002E4A0 File Offset: 0x0002C6A0
		[UnmanagedCallersOnly]
		internal static int Tools_Button_InternalDragLeaveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Button instance;
				if (!InteropSystem.TryGetObject<Button>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragLeaveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalDragLeaveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Button.InternalDropEvent( ... )
		/// </summary>
		// Token: 0x06001107 RID: 4359 RVA: 0x0002E4F8 File Offset: 0x0002C6F8
		[UnmanagedCallersOnly]
		internal static int Tools_Button_InternalDropEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Button instance;
				if (!InteropSystem.TryGetObject<Button>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDropEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Button", "InternalDropEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.CheckBox.InternalOnPressed( ... )
		/// </summary>
		// Token: 0x06001108 RID: 4360 RVA: 0x0002E550 File Offset: 0x0002C750
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalOnPressed(uint self)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalOnPressed();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalOnPressed", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalOnReleased( ... )
		/// </summary>
		// Token: 0x06001109 RID: 4361 RVA: 0x0002E594 File Offset: 0x0002C794
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalOnReleased(uint self)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalOnReleased();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalOnReleased", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalOnClicked( ... )
		/// </summary>
		// Token: 0x0600110A RID: 4362 RVA: 0x0002E5D8 File Offset: 0x0002C7D8
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalOnClicked(uint self)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalOnClicked();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalOnClicked", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalOnToggled( ... )
		/// </summary>
		// Token: 0x0600110B RID: 4363 RVA: 0x0002E61C File Offset: 0x0002C81C
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalOnToggled(uint self)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalOnToggled();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalOnToggled", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalOnStateChanged( ... )
		/// </summary>
		// Token: 0x0600110C RID: 4364 RVA: 0x0002E660 File Offset: 0x0002C860
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalOnStateChanged(uint self)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalOnStateChanged();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalOnStateChanged", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalOnEvent( ... )
		/// </summary>
		// Token: 0x0600110D RID: 4365 RVA: 0x0002E6A4 File Offset: 0x0002C8A4
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalOnEvent(uint self, long e)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalOnEvent((EventType)e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalOnEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalMousePressEvent( ... )
		/// </summary>
		// Token: 0x0600110E RID: 4366 RVA: 0x0002E6EC File Offset: 0x0002C8EC
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalMousePressEvent(uint self, IntPtr e)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalMousePressEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalMousePressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalMouseEnterEvent( ... )
		/// </summary>
		// Token: 0x0600110F RID: 4367 RVA: 0x0002E738 File Offset: 0x0002C938
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalMouseEnterEvent(uint self, IntPtr e)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalMouseEnterEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalMouseEnterEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalMouseLeaveEvent( ... )
		/// </summary>
		// Token: 0x06001110 RID: 4368 RVA: 0x0002E784 File Offset: 0x0002C984
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalMouseLeaveEvent(uint self, IntPtr e)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalMouseLeaveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalMouseLeaveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalMouseReleaseEvent( ... )
		/// </summary>
		// Token: 0x06001111 RID: 4369 RVA: 0x0002E7D0 File Offset: 0x0002C9D0
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalMouseReleaseEvent(uint self, IntPtr e)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalMouseReleaseEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalMouseReleaseEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalMouseMoveEvent( ... )
		/// </summary>
		// Token: 0x06001112 RID: 4370 RVA: 0x0002E81C File Offset: 0x0002CA1C
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalMouseMoveEvent(uint self, IntPtr e)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalMouseMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalMouseMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalMouseDoubleClickEvent( ... )
		/// </summary>
		// Token: 0x06001113 RID: 4371 RVA: 0x0002E868 File Offset: 0x0002CA68
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalMouseDoubleClickEvent(uint self, IntPtr e)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalMouseDoubleClickEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalMouseDoubleClickEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalWheelEvent( ... )
		/// </summary>
		// Token: 0x06001114 RID: 4372 RVA: 0x0002E8B4 File Offset: 0x0002CAB4
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalWheelEvent(uint self, IntPtr e)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalWheelEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalWheelEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalContextMenuEvent( ... )
		/// </summary>
		// Token: 0x06001115 RID: 4373 RVA: 0x0002E900 File Offset: 0x0002CB00
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalContextMenuEvent(uint self, IntPtr e)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalContextMenuEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalContextMenuEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalKeyPressEvent( ... )
		/// </summary>
		// Token: 0x06001116 RID: 4374 RVA: 0x0002E94C File Offset: 0x0002CB4C
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalKeyPressEvent(uint self, IntPtr pEvent)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalKeyPressEvent(pEvent);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalKeyPressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalFocusInEvent( ... )
		/// </summary>
		// Token: 0x06001117 RID: 4375 RVA: 0x0002E998 File Offset: 0x0002CB98
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalFocusInEvent(uint self, long reason)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalFocusInEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalFocusInEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalFocusOutEvent( ... )
		/// </summary>
		// Token: 0x06001118 RID: 4376 RVA: 0x0002E9E0 File Offset: 0x0002CBE0
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalFocusOutEvent(uint self, long reason)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalFocusOutEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalFocusOutEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalOnResizeEvent( ... )
		/// </summary>
		// Token: 0x06001119 RID: 4377 RVA: 0x0002EA28 File Offset: 0x0002CC28
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalOnResizeEvent(uint self, IntPtr e)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalOnResizeEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalOnResizeEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalOnMoveEvent( ... )
		/// </summary>
		// Token: 0x0600111A RID: 4378 RVA: 0x0002EA74 File Offset: 0x0002CC74
		[UnmanagedCallersOnly]
		internal static void Tools_CheckB_InternalOnMoveEvent(uint self, IntPtr e)
		{
			try
			{
				CheckBox instance;
				if (InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					instance.InternalOnMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalOnMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.CheckBox.InternalPaintEvent( ... )
		/// </summary>
		// Token: 0x0600111B RID: 4379 RVA: 0x0002EAC0 File Offset: 0x0002CCC0
		[UnmanagedCallersOnly]
		internal static int Tools_CheckB_InternalPaintEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				CheckBox instance;
				if (!InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalPaintEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalPaintEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.CheckBox.InternalFocusNextPrevChild( ... )
		/// </summary>
		// Token: 0x0600111C RID: 4380 RVA: 0x0002EB18 File Offset: 0x0002CD18
		[UnmanagedCallersOnly]
		internal static int Tools_CheckB_InternalFocusNextPrevChild(uint self, int next)
		{
			int result;
			try
			{
				CheckBox instance;
				if (!InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalFocusNextPrevChild(next != 0) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalFocusNextPrevChild", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.CheckBox.InternalDragEnterEvent( ... )
		/// </summary>
		// Token: 0x0600111D RID: 4381 RVA: 0x0002EB6C File Offset: 0x0002CD6C
		[UnmanagedCallersOnly]
		internal static int Tools_CheckB_InternalDragEnterEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				CheckBox instance;
				if (!InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragEnterEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalDragEnterEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.CheckBox.InternalDragMoveEvent( ... )
		/// </summary>
		// Token: 0x0600111E RID: 4382 RVA: 0x0002EBC4 File Offset: 0x0002CDC4
		[UnmanagedCallersOnly]
		internal static int Tools_CheckB_InternalDragMoveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				CheckBox instance;
				if (!InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragMoveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalDragMoveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.CheckBox.InternalDragLeaveEvent( ... )
		/// </summary>
		// Token: 0x0600111F RID: 4383 RVA: 0x0002EC1C File Offset: 0x0002CE1C
		[UnmanagedCallersOnly]
		internal static int Tools_CheckB_InternalDragLeaveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				CheckBox instance;
				if (!InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragLeaveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalDragLeaveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.CheckBox.InternalDropEvent( ... )
		/// </summary>
		// Token: 0x06001120 RID: 4384 RVA: 0x0002EC74 File Offset: 0x0002CE74
		[UnmanagedCallersOnly]
		internal static int Tools_CheckB_InternalDropEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				CheckBox instance;
				if (!InteropSystem.TryGetObject<CheckBox>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDropEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.CheckBox", "InternalDropEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ComboBox.InternalTextChanged( ... )
		/// </summary>
		// Token: 0x06001121 RID: 4385 RVA: 0x0002ECCC File Offset: 0x0002CECC
		[UnmanagedCallersOnly]
		internal static void Tools_ComboB_InternalTextChanged(uint self)
		{
			try
			{
				ComboBox instance;
				if (InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					instance.InternalTextChanged();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalTextChanged", ___e);
			}
		}

		/// <summary>
		/// Tools.ComboBox.InternalIndexChanged( ... )
		/// </summary>
		// Token: 0x06001122 RID: 4386 RVA: 0x0002ED10 File Offset: 0x0002CF10
		[UnmanagedCallersOnly]
		internal static void Tools_ComboB_InternalIndexChanged(uint self)
		{
			try
			{
				ComboBox instance;
				if (InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					instance.InternalIndexChanged();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalIndexChanged", ___e);
			}
		}

		/// <summary>
		/// Tools.ComboBox.InternalOnEvent( ... )
		/// </summary>
		// Token: 0x06001123 RID: 4387 RVA: 0x0002ED54 File Offset: 0x0002CF54
		[UnmanagedCallersOnly]
		internal static void Tools_ComboB_InternalOnEvent(uint self, long e)
		{
			try
			{
				ComboBox instance;
				if (InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					instance.InternalOnEvent((EventType)e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalOnEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ComboBox.InternalMousePressEvent( ... )
		/// </summary>
		// Token: 0x06001124 RID: 4388 RVA: 0x0002ED9C File Offset: 0x0002CF9C
		[UnmanagedCallersOnly]
		internal static void Tools_ComboB_InternalMousePressEvent(uint self, IntPtr e)
		{
			try
			{
				ComboBox instance;
				if (InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					instance.InternalMousePressEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalMousePressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ComboBox.InternalMouseEnterEvent( ... )
		/// </summary>
		// Token: 0x06001125 RID: 4389 RVA: 0x0002EDE8 File Offset: 0x0002CFE8
		[UnmanagedCallersOnly]
		internal static void Tools_ComboB_InternalMouseEnterEvent(uint self, IntPtr e)
		{
			try
			{
				ComboBox instance;
				if (InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					instance.InternalMouseEnterEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalMouseEnterEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ComboBox.InternalMouseLeaveEvent( ... )
		/// </summary>
		// Token: 0x06001126 RID: 4390 RVA: 0x0002EE34 File Offset: 0x0002D034
		[UnmanagedCallersOnly]
		internal static void Tools_ComboB_InternalMouseLeaveEvent(uint self, IntPtr e)
		{
			try
			{
				ComboBox instance;
				if (InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					instance.InternalMouseLeaveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalMouseLeaveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ComboBox.InternalMouseReleaseEvent( ... )
		/// </summary>
		// Token: 0x06001127 RID: 4391 RVA: 0x0002EE80 File Offset: 0x0002D080
		[UnmanagedCallersOnly]
		internal static void Tools_ComboB_InternalMouseReleaseEvent(uint self, IntPtr e)
		{
			try
			{
				ComboBox instance;
				if (InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					instance.InternalMouseReleaseEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalMouseReleaseEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ComboBox.InternalMouseMoveEvent( ... )
		/// </summary>
		// Token: 0x06001128 RID: 4392 RVA: 0x0002EECC File Offset: 0x0002D0CC
		[UnmanagedCallersOnly]
		internal static void Tools_ComboB_InternalMouseMoveEvent(uint self, IntPtr e)
		{
			try
			{
				ComboBox instance;
				if (InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					instance.InternalMouseMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalMouseMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ComboBox.InternalMouseDoubleClickEvent( ... )
		/// </summary>
		// Token: 0x06001129 RID: 4393 RVA: 0x0002EF18 File Offset: 0x0002D118
		[UnmanagedCallersOnly]
		internal static void Tools_ComboB_InternalMouseDoubleClickEvent(uint self, IntPtr e)
		{
			try
			{
				ComboBox instance;
				if (InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					instance.InternalMouseDoubleClickEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalMouseDoubleClickEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ComboBox.InternalWheelEvent( ... )
		/// </summary>
		// Token: 0x0600112A RID: 4394 RVA: 0x0002EF64 File Offset: 0x0002D164
		[UnmanagedCallersOnly]
		internal static void Tools_ComboB_InternalWheelEvent(uint self, IntPtr e)
		{
			try
			{
				ComboBox instance;
				if (InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					instance.InternalWheelEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalWheelEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ComboBox.InternalContextMenuEvent( ... )
		/// </summary>
		// Token: 0x0600112B RID: 4395 RVA: 0x0002EFB0 File Offset: 0x0002D1B0
		[UnmanagedCallersOnly]
		internal static void Tools_ComboB_InternalContextMenuEvent(uint self, IntPtr e)
		{
			try
			{
				ComboBox instance;
				if (InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					instance.InternalContextMenuEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalContextMenuEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ComboBox.InternalKeyPressEvent( ... )
		/// </summary>
		// Token: 0x0600112C RID: 4396 RVA: 0x0002EFFC File Offset: 0x0002D1FC
		[UnmanagedCallersOnly]
		internal static void Tools_ComboB_InternalKeyPressEvent(uint self, IntPtr pEvent)
		{
			try
			{
				ComboBox instance;
				if (InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					instance.InternalKeyPressEvent(pEvent);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalKeyPressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ComboBox.InternalFocusInEvent( ... )
		/// </summary>
		// Token: 0x0600112D RID: 4397 RVA: 0x0002F048 File Offset: 0x0002D248
		[UnmanagedCallersOnly]
		internal static void Tools_ComboB_InternalFocusInEvent(uint self, long reason)
		{
			try
			{
				ComboBox instance;
				if (InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					instance.InternalFocusInEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalFocusInEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ComboBox.InternalFocusOutEvent( ... )
		/// </summary>
		// Token: 0x0600112E RID: 4398 RVA: 0x0002F090 File Offset: 0x0002D290
		[UnmanagedCallersOnly]
		internal static void Tools_ComboB_InternalFocusOutEvent(uint self, long reason)
		{
			try
			{
				ComboBox instance;
				if (InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					instance.InternalFocusOutEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalFocusOutEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ComboBox.InternalOnResizeEvent( ... )
		/// </summary>
		// Token: 0x0600112F RID: 4399 RVA: 0x0002F0D8 File Offset: 0x0002D2D8
		[UnmanagedCallersOnly]
		internal static void Tools_ComboB_InternalOnResizeEvent(uint self, IntPtr e)
		{
			try
			{
				ComboBox instance;
				if (InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					instance.InternalOnResizeEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalOnResizeEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ComboBox.InternalOnMoveEvent( ... )
		/// </summary>
		// Token: 0x06001130 RID: 4400 RVA: 0x0002F124 File Offset: 0x0002D324
		[UnmanagedCallersOnly]
		internal static void Tools_ComboB_InternalOnMoveEvent(uint self, IntPtr e)
		{
			try
			{
				ComboBox instance;
				if (InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					instance.InternalOnMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalOnMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ComboBox.InternalPaintEvent( ... )
		/// </summary>
		// Token: 0x06001131 RID: 4401 RVA: 0x0002F170 File Offset: 0x0002D370
		[UnmanagedCallersOnly]
		internal static int Tools_ComboB_InternalPaintEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				ComboBox instance;
				if (!InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalPaintEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalPaintEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ComboBox.InternalFocusNextPrevChild( ... )
		/// </summary>
		// Token: 0x06001132 RID: 4402 RVA: 0x0002F1C8 File Offset: 0x0002D3C8
		[UnmanagedCallersOnly]
		internal static int Tools_ComboB_InternalFocusNextPrevChild(uint self, int next)
		{
			int result;
			try
			{
				ComboBox instance;
				if (!InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalFocusNextPrevChild(next != 0) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalFocusNextPrevChild", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ComboBox.InternalDragEnterEvent( ... )
		/// </summary>
		// Token: 0x06001133 RID: 4403 RVA: 0x0002F21C File Offset: 0x0002D41C
		[UnmanagedCallersOnly]
		internal static int Tools_ComboB_InternalDragEnterEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				ComboBox instance;
				if (!InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragEnterEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalDragEnterEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ComboBox.InternalDragMoveEvent( ... )
		/// </summary>
		// Token: 0x06001134 RID: 4404 RVA: 0x0002F274 File Offset: 0x0002D474
		[UnmanagedCallersOnly]
		internal static int Tools_ComboB_InternalDragMoveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				ComboBox instance;
				if (!InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragMoveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalDragMoveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ComboBox.InternalDragLeaveEvent( ... )
		/// </summary>
		// Token: 0x06001135 RID: 4405 RVA: 0x0002F2CC File Offset: 0x0002D4CC
		[UnmanagedCallersOnly]
		internal static int Tools_ComboB_InternalDragLeaveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				ComboBox instance;
				if (!InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragLeaveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalDragLeaveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ComboBox.InternalDropEvent( ... )
		/// </summary>
		// Token: 0x06001136 RID: 4406 RVA: 0x0002F324 File Offset: 0x0002D524
		[UnmanagedCallersOnly]
		internal static int Tools_ComboB_InternalDropEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				ComboBox instance;
				if (!InteropSystem.TryGetObject<ComboBox>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDropEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ComboBox", "InternalDropEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.DataModel.GetIndex( ... )
		/// </summary>
		// Token: 0x06001137 RID: 4407 RVA: 0x0002F37C File Offset: 0x0002D57C
		[UnmanagedCallersOnly]
		internal static ModelIndex Tools_DtMdel_GetIndex(uint self, ModelIndex parent, int r, int c)
		{
			ModelIndex modelIndex;
			try
			{
				DataModel instance;
				if (!InteropSystem.TryGetObject<DataModel>(self, out instance))
				{
					modelIndex = default(ModelIndex);
					modelIndex = modelIndex;
				}
				else
				{
					modelIndex = instance.GetIndex(parent, r, c);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DataModel", "GetIndex", ___e);
				modelIndex = default(ModelIndex);
			}
			return modelIndex;
		}

		/// <summary>
		/// Tools.DataModel.GetNodeRows( ... )
		/// </summary>
		// Token: 0x06001138 RID: 4408 RVA: 0x0002F3DC File Offset: 0x0002D5DC
		[UnmanagedCallersOnly]
		internal static int Tools_DtMdel_GetNodeRows(uint self, ModelIndex idx)
		{
			int result;
			try
			{
				DataModel instance;
				if (!InteropSystem.TryGetObject<DataModel>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = instance.GetNodeRows(idx);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DataModel", "GetNodeRows", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.DataModel.GetNodeColumns( ... )
		/// </summary>
		// Token: 0x06001139 RID: 4409 RVA: 0x0002F428 File Offset: 0x0002D628
		[UnmanagedCallersOnly]
		internal static int Tools_DtMdel_GetNodeColumns(uint self, ModelIndex idx)
		{
			int result;
			try
			{
				DataModel instance;
				if (!InteropSystem.TryGetObject<DataModel>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = instance.GetNodeColumns(idx);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DataModel", "GetNodeColumns", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.DataModel.GetNodeParent( ... )
		/// </summary>
		// Token: 0x0600113A RID: 4410 RVA: 0x0002F474 File Offset: 0x0002D674
		[UnmanagedCallersOnly]
		internal static ModelIndex Tools_DtMdel_GetNodeParent(uint self, ModelIndex child)
		{
			ModelIndex modelIndex;
			try
			{
				DataModel instance;
				if (!InteropSystem.TryGetObject<DataModel>(self, out instance))
				{
					modelIndex = default(ModelIndex);
					modelIndex = modelIndex;
				}
				else
				{
					modelIndex = instance.GetNodeParent(child);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DataModel", "GetNodeParent", ___e);
				modelIndex = default(ModelIndex);
			}
			return modelIndex;
		}

		/// <summary>
		/// Tools.DataModel.GetNodeFlags( ... )
		/// </summary>
		// Token: 0x0600113B RID: 4411 RVA: 0x0002F4D0 File Offset: 0x0002D6D0
		[UnmanagedCallersOnly]
		internal static long Tools_DtMdel_GetNodeFlags(uint self, ModelIndex index)
		{
			long result;
			try
			{
				DataModel instance;
				if (!InteropSystem.TryGetObject<DataModel>(self, out instance))
				{
					result = 0L;
				}
				else
				{
					result = (long)instance.GetNodeFlags(index);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DataModel", "GetNodeFlags", ___e);
				result = 0L;
			}
			return result;
		}

		/// <summary>
		/// Tools.DataModel.InternalPaintItem( ... )
		/// </summary>
		// Token: 0x0600113C RID: 4412 RVA: 0x0002F520 File Offset: 0x0002D720
		[UnmanagedCallersOnly]
		internal static void Tools_DtMdel_InternalPaintItem(uint self, ModelIndex index, IntPtr painter, int state, QRectF rect)
		{
			try
			{
				DataModel instance;
				if (InteropSystem.TryGetObject<DataModel>(self, out instance))
				{
					instance.InternalPaintItem(index, painter, state, rect);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DataModel", "InternalPaintItem", ___e);
			}
		}

		/// <summary>
		/// Tools.DataModel.SizeHint( ... )
		/// </summary>
		// Token: 0x0600113D RID: 4413 RVA: 0x0002F56C File Offset: 0x0002D76C
		[UnmanagedCallersOnly]
		internal static Vector3 Tools_DtMdel_SizeHint(uint self, ModelIndex index)
		{
			Vector3 vector;
			try
			{
				DataModel instance;
				if (!InteropSystem.TryGetObject<DataModel>(self, out instance))
				{
					vector = default(Vector3);
					vector = vector;
				}
				else
				{
					vector = instance.SizeHint(index);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DataModel", "SizeHint", ___e);
				vector = default(Vector3);
			}
			return vector;
		}

		/// <summary>
		/// Tools.DataModel.ToolTipHint( ... )
		/// </summary>
		// Token: 0x0600113E RID: 4414 RVA: 0x0002F5CC File Offset: 0x0002D7CC
		[UnmanagedCallersOnly]
		internal static IntPtr Tools_DtMdel_ToolTipHint(uint self, ModelIndex index)
		{
			IntPtr result;
			try
			{
				DataModel instance;
				if (!InteropSystem.TryGetObject<DataModel>(self, out instance))
				{
					result = (IntPtr)0;
				}
				else
				{
					result = Interop.GetWPointer(instance.ToolTipHint(index));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DataModel", "ToolTipHint", ___e);
				result = (IntPtr)0;
			}
			return result;
		}

		/// <summary>
		/// Tools.DataModel.StatusTipHint( ... )
		/// </summary>
		// Token: 0x0600113F RID: 4415 RVA: 0x0002F620 File Offset: 0x0002D820
		[UnmanagedCallersOnly]
		internal static IntPtr Tools_DtMdel_StatusTipHint(uint self, ModelIndex index)
		{
			IntPtr result;
			try
			{
				DataModel instance;
				if (!InteropSystem.TryGetObject<DataModel>(self, out instance))
				{
					result = (IntPtr)0;
				}
				else
				{
					result = Interop.GetWPointer(instance.StatusTipHint(index));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DataModel", "StatusTipHint", ___e);
				result = (IntPtr)0;
			}
			return result;
		}

		/// <summary>
		/// Tools.DockWidget.InternalOnEvent( ... )
		/// </summary>
		// Token: 0x06001140 RID: 4416 RVA: 0x0002F674 File Offset: 0x0002D874
		[UnmanagedCallersOnly]
		internal static void Tools_DckWdg_InternalOnEvent(uint self, long e)
		{
			try
			{
				DockWidget instance;
				if (InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					instance.InternalOnEvent((EventType)e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalOnEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.DockWidget.InternalMousePressEvent( ... )
		/// </summary>
		// Token: 0x06001141 RID: 4417 RVA: 0x0002F6BC File Offset: 0x0002D8BC
		[UnmanagedCallersOnly]
		internal static void Tools_DckWdg_InternalMousePressEvent(uint self, IntPtr e)
		{
			try
			{
				DockWidget instance;
				if (InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					instance.InternalMousePressEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalMousePressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.DockWidget.InternalMouseEnterEvent( ... )
		/// </summary>
		// Token: 0x06001142 RID: 4418 RVA: 0x0002F708 File Offset: 0x0002D908
		[UnmanagedCallersOnly]
		internal static void Tools_DckWdg_InternalMouseEnterEvent(uint self, IntPtr e)
		{
			try
			{
				DockWidget instance;
				if (InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					instance.InternalMouseEnterEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalMouseEnterEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.DockWidget.InternalMouseLeaveEvent( ... )
		/// </summary>
		// Token: 0x06001143 RID: 4419 RVA: 0x0002F754 File Offset: 0x0002D954
		[UnmanagedCallersOnly]
		internal static void Tools_DckWdg_InternalMouseLeaveEvent(uint self, IntPtr e)
		{
			try
			{
				DockWidget instance;
				if (InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					instance.InternalMouseLeaveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalMouseLeaveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.DockWidget.InternalMouseReleaseEvent( ... )
		/// </summary>
		// Token: 0x06001144 RID: 4420 RVA: 0x0002F7A0 File Offset: 0x0002D9A0
		[UnmanagedCallersOnly]
		internal static void Tools_DckWdg_InternalMouseReleaseEvent(uint self, IntPtr e)
		{
			try
			{
				DockWidget instance;
				if (InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					instance.InternalMouseReleaseEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalMouseReleaseEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.DockWidget.InternalMouseMoveEvent( ... )
		/// </summary>
		// Token: 0x06001145 RID: 4421 RVA: 0x0002F7EC File Offset: 0x0002D9EC
		[UnmanagedCallersOnly]
		internal static void Tools_DckWdg_InternalMouseMoveEvent(uint self, IntPtr e)
		{
			try
			{
				DockWidget instance;
				if (InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					instance.InternalMouseMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalMouseMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.DockWidget.InternalMouseDoubleClickEvent( ... )
		/// </summary>
		// Token: 0x06001146 RID: 4422 RVA: 0x0002F838 File Offset: 0x0002DA38
		[UnmanagedCallersOnly]
		internal static void Tools_DckWdg_InternalMouseDoubleClickEvent(uint self, IntPtr e)
		{
			try
			{
				DockWidget instance;
				if (InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					instance.InternalMouseDoubleClickEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalMouseDoubleClickEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.DockWidget.InternalWheelEvent( ... )
		/// </summary>
		// Token: 0x06001147 RID: 4423 RVA: 0x0002F884 File Offset: 0x0002DA84
		[UnmanagedCallersOnly]
		internal static void Tools_DckWdg_InternalWheelEvent(uint self, IntPtr e)
		{
			try
			{
				DockWidget instance;
				if (InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					instance.InternalWheelEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalWheelEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.DockWidget.InternalContextMenuEvent( ... )
		/// </summary>
		// Token: 0x06001148 RID: 4424 RVA: 0x0002F8D0 File Offset: 0x0002DAD0
		[UnmanagedCallersOnly]
		internal static void Tools_DckWdg_InternalContextMenuEvent(uint self, IntPtr e)
		{
			try
			{
				DockWidget instance;
				if (InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					instance.InternalContextMenuEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalContextMenuEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.DockWidget.InternalKeyPressEvent( ... )
		/// </summary>
		// Token: 0x06001149 RID: 4425 RVA: 0x0002F91C File Offset: 0x0002DB1C
		[UnmanagedCallersOnly]
		internal static void Tools_DckWdg_InternalKeyPressEvent(uint self, IntPtr pEvent)
		{
			try
			{
				DockWidget instance;
				if (InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					instance.InternalKeyPressEvent(pEvent);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalKeyPressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.DockWidget.InternalFocusInEvent( ... )
		/// </summary>
		// Token: 0x0600114A RID: 4426 RVA: 0x0002F968 File Offset: 0x0002DB68
		[UnmanagedCallersOnly]
		internal static void Tools_DckWdg_InternalFocusInEvent(uint self, long reason)
		{
			try
			{
				DockWidget instance;
				if (InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					instance.InternalFocusInEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalFocusInEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.DockWidget.InternalFocusOutEvent( ... )
		/// </summary>
		// Token: 0x0600114B RID: 4427 RVA: 0x0002F9B0 File Offset: 0x0002DBB0
		[UnmanagedCallersOnly]
		internal static void Tools_DckWdg_InternalFocusOutEvent(uint self, long reason)
		{
			try
			{
				DockWidget instance;
				if (InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					instance.InternalFocusOutEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalFocusOutEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.DockWidget.InternalOnResizeEvent( ... )
		/// </summary>
		// Token: 0x0600114C RID: 4428 RVA: 0x0002F9F8 File Offset: 0x0002DBF8
		[UnmanagedCallersOnly]
		internal static void Tools_DckWdg_InternalOnResizeEvent(uint self, IntPtr e)
		{
			try
			{
				DockWidget instance;
				if (InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					instance.InternalOnResizeEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalOnResizeEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.DockWidget.InternalOnMoveEvent( ... )
		/// </summary>
		// Token: 0x0600114D RID: 4429 RVA: 0x0002FA44 File Offset: 0x0002DC44
		[UnmanagedCallersOnly]
		internal static void Tools_DckWdg_InternalOnMoveEvent(uint self, IntPtr e)
		{
			try
			{
				DockWidget instance;
				if (InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					instance.InternalOnMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalOnMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.DockWidget.InternalPaintEvent( ... )
		/// </summary>
		// Token: 0x0600114E RID: 4430 RVA: 0x0002FA90 File Offset: 0x0002DC90
		[UnmanagedCallersOnly]
		internal static int Tools_DckWdg_InternalPaintEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				DockWidget instance;
				if (!InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalPaintEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalPaintEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.DockWidget.InternalFocusNextPrevChild( ... )
		/// </summary>
		// Token: 0x0600114F RID: 4431 RVA: 0x0002FAE8 File Offset: 0x0002DCE8
		[UnmanagedCallersOnly]
		internal static int Tools_DckWdg_InternalFocusNextPrevChild(uint self, int next)
		{
			int result;
			try
			{
				DockWidget instance;
				if (!InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalFocusNextPrevChild(next != 0) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalFocusNextPrevChild", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.DockWidget.InternalDragEnterEvent( ... )
		/// </summary>
		// Token: 0x06001150 RID: 4432 RVA: 0x0002FB3C File Offset: 0x0002DD3C
		[UnmanagedCallersOnly]
		internal static int Tools_DckWdg_InternalDragEnterEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				DockWidget instance;
				if (!InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragEnterEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalDragEnterEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.DockWidget.InternalDragMoveEvent( ... )
		/// </summary>
		// Token: 0x06001151 RID: 4433 RVA: 0x0002FB94 File Offset: 0x0002DD94
		[UnmanagedCallersOnly]
		internal static int Tools_DckWdg_InternalDragMoveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				DockWidget instance;
				if (!InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragMoveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalDragMoveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.DockWidget.InternalDragLeaveEvent( ... )
		/// </summary>
		// Token: 0x06001152 RID: 4434 RVA: 0x0002FBEC File Offset: 0x0002DDEC
		[UnmanagedCallersOnly]
		internal static int Tools_DckWdg_InternalDragLeaveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				DockWidget instance;
				if (!InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragLeaveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalDragLeaveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.DockWidget.InternalDropEvent( ... )
		/// </summary>
		// Token: 0x06001153 RID: 4435 RVA: 0x0002FC44 File Offset: 0x0002DE44
		[UnmanagedCallersOnly]
		internal static int Tools_DckWdg_InternalDropEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				DockWidget instance;
				if (!InteropSystem.TryGetObject<DockWidget>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDropEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.DockWidget", "InternalDropEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.EventFilter.OnKeyPressed( ... )
		/// </summary>
		// Token: 0x06001154 RID: 4436 RVA: 0x0002FC9C File Offset: 0x0002DE9C
		[UnmanagedCallersOnly]
		internal static int Tools_EventF_OnKeyPressed(uint self)
		{
			int result;
			try
			{
				EventFilter instance;
				if (!InteropSystem.TryGetObject<EventFilter>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = instance.OnKeyPressed();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.EventFilter", "OnKeyPressed", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.EventFilter.OnEvent( ... )
		/// </summary>
		// Token: 0x06001155 RID: 4437 RVA: 0x0002FCE8 File Offset: 0x0002DEE8
		[UnmanagedCallersOnly]
		internal static int Tools_EventF_OnEvent(uint self, long e)
		{
			int result;
			try
			{
				EventFilter instance;
				if (!InteropSystem.TryGetObject<EventFilter>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.OnEvent((EventType)e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.EventFilter", "OnEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Frame.InternalOnEvent( ... )
		/// </summary>
		// Token: 0x06001156 RID: 4438 RVA: 0x0002FD3C File Offset: 0x0002DF3C
		[UnmanagedCallersOnly]
		internal static void Tools_Frame_InternalOnEvent(uint self, long e)
		{
			try
			{
				Frame instance;
				if (InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					instance.InternalOnEvent((EventType)e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalOnEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Frame.InternalMousePressEvent( ... )
		/// </summary>
		// Token: 0x06001157 RID: 4439 RVA: 0x0002FD84 File Offset: 0x0002DF84
		[UnmanagedCallersOnly]
		internal static void Tools_Frame_InternalMousePressEvent(uint self, IntPtr e)
		{
			try
			{
				Frame instance;
				if (InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					instance.InternalMousePressEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalMousePressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Frame.InternalMouseEnterEvent( ... )
		/// </summary>
		// Token: 0x06001158 RID: 4440 RVA: 0x0002FDD0 File Offset: 0x0002DFD0
		[UnmanagedCallersOnly]
		internal static void Tools_Frame_InternalMouseEnterEvent(uint self, IntPtr e)
		{
			try
			{
				Frame instance;
				if (InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					instance.InternalMouseEnterEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalMouseEnterEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Frame.InternalMouseLeaveEvent( ... )
		/// </summary>
		// Token: 0x06001159 RID: 4441 RVA: 0x0002FE1C File Offset: 0x0002E01C
		[UnmanagedCallersOnly]
		internal static void Tools_Frame_InternalMouseLeaveEvent(uint self, IntPtr e)
		{
			try
			{
				Frame instance;
				if (InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					instance.InternalMouseLeaveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalMouseLeaveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Frame.InternalMouseReleaseEvent( ... )
		/// </summary>
		// Token: 0x0600115A RID: 4442 RVA: 0x0002FE68 File Offset: 0x0002E068
		[UnmanagedCallersOnly]
		internal static void Tools_Frame_InternalMouseReleaseEvent(uint self, IntPtr e)
		{
			try
			{
				Frame instance;
				if (InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					instance.InternalMouseReleaseEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalMouseReleaseEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Frame.InternalMouseMoveEvent( ... )
		/// </summary>
		// Token: 0x0600115B RID: 4443 RVA: 0x0002FEB4 File Offset: 0x0002E0B4
		[UnmanagedCallersOnly]
		internal static void Tools_Frame_InternalMouseMoveEvent(uint self, IntPtr e)
		{
			try
			{
				Frame instance;
				if (InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					instance.InternalMouseMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalMouseMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Frame.InternalMouseDoubleClickEvent( ... )
		/// </summary>
		// Token: 0x0600115C RID: 4444 RVA: 0x0002FF00 File Offset: 0x0002E100
		[UnmanagedCallersOnly]
		internal static void Tools_Frame_InternalMouseDoubleClickEvent(uint self, IntPtr e)
		{
			try
			{
				Frame instance;
				if (InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					instance.InternalMouseDoubleClickEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalMouseDoubleClickEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Frame.InternalWheelEvent( ... )
		/// </summary>
		// Token: 0x0600115D RID: 4445 RVA: 0x0002FF4C File Offset: 0x0002E14C
		[UnmanagedCallersOnly]
		internal static void Tools_Frame_InternalWheelEvent(uint self, IntPtr e)
		{
			try
			{
				Frame instance;
				if (InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					instance.InternalWheelEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalWheelEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Frame.InternalContextMenuEvent( ... )
		/// </summary>
		// Token: 0x0600115E RID: 4446 RVA: 0x0002FF98 File Offset: 0x0002E198
		[UnmanagedCallersOnly]
		internal static void Tools_Frame_InternalContextMenuEvent(uint self, IntPtr e)
		{
			try
			{
				Frame instance;
				if (InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					instance.InternalContextMenuEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalContextMenuEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Frame.InternalKeyPressEvent( ... )
		/// </summary>
		// Token: 0x0600115F RID: 4447 RVA: 0x0002FFE4 File Offset: 0x0002E1E4
		[UnmanagedCallersOnly]
		internal static void Tools_Frame_InternalKeyPressEvent(uint self, IntPtr pEvent)
		{
			try
			{
				Frame instance;
				if (InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					instance.InternalKeyPressEvent(pEvent);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalKeyPressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Frame.InternalFocusInEvent( ... )
		/// </summary>
		// Token: 0x06001160 RID: 4448 RVA: 0x00030030 File Offset: 0x0002E230
		[UnmanagedCallersOnly]
		internal static void Tools_Frame_InternalFocusInEvent(uint self, long reason)
		{
			try
			{
				Frame instance;
				if (InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					instance.InternalFocusInEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalFocusInEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Frame.InternalFocusOutEvent( ... )
		/// </summary>
		// Token: 0x06001161 RID: 4449 RVA: 0x00030078 File Offset: 0x0002E278
		[UnmanagedCallersOnly]
		internal static void Tools_Frame_InternalFocusOutEvent(uint self, long reason)
		{
			try
			{
				Frame instance;
				if (InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					instance.InternalFocusOutEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalFocusOutEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Frame.InternalOnResizeEvent( ... )
		/// </summary>
		// Token: 0x06001162 RID: 4450 RVA: 0x000300C0 File Offset: 0x0002E2C0
		[UnmanagedCallersOnly]
		internal static void Tools_Frame_InternalOnResizeEvent(uint self, IntPtr e)
		{
			try
			{
				Frame instance;
				if (InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					instance.InternalOnResizeEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalOnResizeEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Frame.InternalOnMoveEvent( ... )
		/// </summary>
		// Token: 0x06001163 RID: 4451 RVA: 0x0003010C File Offset: 0x0002E30C
		[UnmanagedCallersOnly]
		internal static void Tools_Frame_InternalOnMoveEvent(uint self, IntPtr e)
		{
			try
			{
				Frame instance;
				if (InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					instance.InternalOnMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalOnMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Frame.InternalPaintEvent( ... )
		/// </summary>
		// Token: 0x06001164 RID: 4452 RVA: 0x00030158 File Offset: 0x0002E358
		[UnmanagedCallersOnly]
		internal static int Tools_Frame_InternalPaintEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Frame instance;
				if (!InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalPaintEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalPaintEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Frame.InternalFocusNextPrevChild( ... )
		/// </summary>
		// Token: 0x06001165 RID: 4453 RVA: 0x000301B0 File Offset: 0x0002E3B0
		[UnmanagedCallersOnly]
		internal static int Tools_Frame_InternalFocusNextPrevChild(uint self, int next)
		{
			int result;
			try
			{
				Frame instance;
				if (!InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalFocusNextPrevChild(next != 0) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalFocusNextPrevChild", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Frame.InternalDragEnterEvent( ... )
		/// </summary>
		// Token: 0x06001166 RID: 4454 RVA: 0x00030204 File Offset: 0x0002E404
		[UnmanagedCallersOnly]
		internal static int Tools_Frame_InternalDragEnterEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Frame instance;
				if (!InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragEnterEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalDragEnterEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Frame.InternalDragMoveEvent( ... )
		/// </summary>
		// Token: 0x06001167 RID: 4455 RVA: 0x0003025C File Offset: 0x0002E45C
		[UnmanagedCallersOnly]
		internal static int Tools_Frame_InternalDragMoveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Frame instance;
				if (!InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragMoveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalDragMoveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Frame.InternalDragLeaveEvent( ... )
		/// </summary>
		// Token: 0x06001168 RID: 4456 RVA: 0x000302B4 File Offset: 0x0002E4B4
		[UnmanagedCallersOnly]
		internal static int Tools_Frame_InternalDragLeaveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Frame instance;
				if (!InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragLeaveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalDragLeaveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Frame.InternalDropEvent( ... )
		/// </summary>
		// Token: 0x06001169 RID: 4457 RVA: 0x0003030C File Offset: 0x0002E50C
		[UnmanagedCallersOnly]
		internal static int Tools_Frame_InternalDropEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Frame instance;
				if (!InteropSystem.TryGetObject<Frame>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDropEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Frame", "InternalDropEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.GraphicsItem.InternalPaint( ... )
		/// </summary>
		// Token: 0x0600116A RID: 4458 RVA: 0x00030364 File Offset: 0x0002E564
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalPaint(uint self, IntPtr painter, int state)
		{
			try
			{
				GraphicsItem instance;
				if (InteropSystem.TryGetObject<GraphicsItem>(self, out instance))
				{
					instance.InternalPaint(painter, state);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsItem", "InternalPaint", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsItem.InternalGetSize( ... )
		/// </summary>
		// Token: 0x0600116B RID: 4459 RVA: 0x000303B0 File Offset: 0x0002E5B0
		[UnmanagedCallersOnly]
		internal static Vector3 Tools_Grphcs_InternalGetSize(uint self)
		{
			Vector3 vector;
			try
			{
				GraphicsItem instance;
				if (!InteropSystem.TryGetObject<GraphicsItem>(self, out instance))
				{
					vector = default(Vector3);
					vector = vector;
				}
				else
				{
					vector = instance.InternalGetSize();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsItem", "InternalGetSize", ___e);
				vector = default(Vector3);
			}
			return vector;
		}

		/// <summary>
		/// Tools.GraphicsItem.InternalMousePressEvent( ... )
		/// </summary>
		// Token: 0x0600116C RID: 4460 RVA: 0x00030410 File Offset: 0x0002E610
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalMousePressEvent(uint self, IntPtr e)
		{
			try
			{
				GraphicsItem instance;
				if (InteropSystem.TryGetObject<GraphicsItem>(self, out instance))
				{
					instance.InternalMousePressEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsItem", "InternalMousePressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsItem.InternalMouseReleaseEvent( ... )
		/// </summary>
		// Token: 0x0600116D RID: 4461 RVA: 0x0003045C File Offset: 0x0002E65C
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalMouseReleaseEvent(uint self, IntPtr e)
		{
			try
			{
				GraphicsItem instance;
				if (InteropSystem.TryGetObject<GraphicsItem>(self, out instance))
				{
					instance.InternalMouseReleaseEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsItem", "InternalMouseReleaseEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsItem.InternalMouseMoveEvent( ... )
		/// </summary>
		// Token: 0x0600116E RID: 4462 RVA: 0x000304A8 File Offset: 0x0002E6A8
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalMouseMoveEvent(uint self, IntPtr e)
		{
			try
			{
				GraphicsItem instance;
				if (InteropSystem.TryGetObject<GraphicsItem>(self, out instance))
				{
					instance.InternalMouseMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsItem", "InternalMouseMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsItem.InternalHoverEnterEvent( ... )
		/// </summary>
		// Token: 0x0600116F RID: 4463 RVA: 0x000304F4 File Offset: 0x0002E6F4
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalHoverEnterEvent(uint self, IntPtr e)
		{
			try
			{
				GraphicsItem instance;
				if (InteropSystem.TryGetObject<GraphicsItem>(self, out instance))
				{
					instance.InternalHoverEnterEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsItem", "InternalHoverEnterEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsItem.InternalHoverMoveEvent( ... )
		/// </summary>
		// Token: 0x06001170 RID: 4464 RVA: 0x00030540 File Offset: 0x0002E740
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalHoverMoveEvent(uint self, IntPtr e)
		{
			try
			{
				GraphicsItem instance;
				if (InteropSystem.TryGetObject<GraphicsItem>(self, out instance))
				{
					instance.InternalHoverMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsItem", "InternalHoverMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsItem.InternalHoverLeaveEvent( ... )
		/// </summary>
		// Token: 0x06001171 RID: 4465 RVA: 0x0003058C File Offset: 0x0002E78C
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalHoverLeaveEvent(uint self, IntPtr e)
		{
			try
			{
				GraphicsItem instance;
				if (InteropSystem.TryGetObject<GraphicsItem>(self, out instance))
				{
					instance.InternalHoverLeaveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsItem", "InternalHoverLeaveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsItem.InternalItemChange( ... )
		/// </summary>
		// Token: 0x06001172 RID: 4466 RVA: 0x000305D8 File Offset: 0x0002E7D8
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalItemChange(uint self, int type)
		{
			try
			{
				GraphicsItem instance;
				if (InteropSystem.TryGetObject<GraphicsItem>(self, out instance))
				{
					instance.InternalItemChange(type);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsItem", "InternalItemChange", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsView.InternalOnEvent( ... )
		/// </summary>
		// Token: 0x06001173 RID: 4467 RVA: 0x00030620 File Offset: 0x0002E820
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalOnEvent(uint self, long e)
		{
			try
			{
				GraphicsView instance;
				if (InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					instance.InternalOnEvent((EventType)e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalOnEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsView.InternalMousePressEvent( ... )
		/// </summary>
		// Token: 0x06001174 RID: 4468 RVA: 0x00030668 File Offset: 0x0002E868
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_f2(uint self, IntPtr e)
		{
			try
			{
				GraphicsView instance;
				if (InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					instance.InternalMousePressEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalMousePressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsView.InternalMouseEnterEvent( ... )
		/// </summary>
		// Token: 0x06001175 RID: 4469 RVA: 0x000306B4 File Offset: 0x0002E8B4
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalMouseEnterEvent(uint self, IntPtr e)
		{
			try
			{
				GraphicsView instance;
				if (InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					instance.InternalMouseEnterEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalMouseEnterEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsView.InternalMouseLeaveEvent( ... )
		/// </summary>
		// Token: 0x06001176 RID: 4470 RVA: 0x00030700 File Offset: 0x0002E900
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalMouseLeaveEvent(uint self, IntPtr e)
		{
			try
			{
				GraphicsView instance;
				if (InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					instance.InternalMouseLeaveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalMouseLeaveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsView.InternalMouseReleaseEvent( ... )
		/// </summary>
		// Token: 0x06001177 RID: 4471 RVA: 0x0003074C File Offset: 0x0002E94C
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_f3(uint self, IntPtr e)
		{
			try
			{
				GraphicsView instance;
				if (InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					instance.InternalMouseReleaseEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalMouseReleaseEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsView.InternalMouseMoveEvent( ... )
		/// </summary>
		// Token: 0x06001178 RID: 4472 RVA: 0x00030798 File Offset: 0x0002E998
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_f4(uint self, IntPtr e)
		{
			try
			{
				GraphicsView instance;
				if (InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					instance.InternalMouseMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalMouseMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsView.InternalMouseDoubleClickEvent( ... )
		/// </summary>
		// Token: 0x06001179 RID: 4473 RVA: 0x000307E4 File Offset: 0x0002E9E4
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalMouseDoubleClickEvent(uint self, IntPtr e)
		{
			try
			{
				GraphicsView instance;
				if (InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					instance.InternalMouseDoubleClickEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalMouseDoubleClickEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsView.InternalWheelEvent( ... )
		/// </summary>
		// Token: 0x0600117A RID: 4474 RVA: 0x00030830 File Offset: 0x0002EA30
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalWheelEvent(uint self, IntPtr e)
		{
			try
			{
				GraphicsView instance;
				if (InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					instance.InternalWheelEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalWheelEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsView.InternalContextMenuEvent( ... )
		/// </summary>
		// Token: 0x0600117B RID: 4475 RVA: 0x0003087C File Offset: 0x0002EA7C
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalContextMenuEvent(uint self, IntPtr e)
		{
			try
			{
				GraphicsView instance;
				if (InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					instance.InternalContextMenuEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalContextMenuEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsView.InternalKeyPressEvent( ... )
		/// </summary>
		// Token: 0x0600117C RID: 4476 RVA: 0x000308C8 File Offset: 0x0002EAC8
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalKeyPressEvent(uint self, IntPtr pEvent)
		{
			try
			{
				GraphicsView instance;
				if (InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					instance.InternalKeyPressEvent(pEvent);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalKeyPressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsView.InternalFocusInEvent( ... )
		/// </summary>
		// Token: 0x0600117D RID: 4477 RVA: 0x00030914 File Offset: 0x0002EB14
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalFocusInEvent(uint self, long reason)
		{
			try
			{
				GraphicsView instance;
				if (InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					instance.InternalFocusInEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalFocusInEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsView.InternalFocusOutEvent( ... )
		/// </summary>
		// Token: 0x0600117E RID: 4478 RVA: 0x0003095C File Offset: 0x0002EB5C
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalFocusOutEvent(uint self, long reason)
		{
			try
			{
				GraphicsView instance;
				if (InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					instance.InternalFocusOutEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalFocusOutEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsView.InternalOnResizeEvent( ... )
		/// </summary>
		// Token: 0x0600117F RID: 4479 RVA: 0x000309A4 File Offset: 0x0002EBA4
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalOnResizeEvent(uint self, IntPtr e)
		{
			try
			{
				GraphicsView instance;
				if (InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					instance.InternalOnResizeEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalOnResizeEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsView.InternalOnMoveEvent( ... )
		/// </summary>
		// Token: 0x06001180 RID: 4480 RVA: 0x000309F0 File Offset: 0x0002EBF0
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_InternalOnMoveEvent(uint self, IntPtr e)
		{
			try
			{
				GraphicsView instance;
				if (InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					instance.InternalOnMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalOnMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.GraphicsView.InternalPaintEvent( ... )
		/// </summary>
		// Token: 0x06001181 RID: 4481 RVA: 0x00030A3C File Offset: 0x0002EC3C
		[UnmanagedCallersOnly]
		internal static int Tools_Grphcs_InternalPaintEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				GraphicsView instance;
				if (!InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalPaintEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalPaintEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.GraphicsView.InternalFocusNextPrevChild( ... )
		/// </summary>
		// Token: 0x06001182 RID: 4482 RVA: 0x00030A94 File Offset: 0x0002EC94
		[UnmanagedCallersOnly]
		internal static int Tools_Grphcs_InternalFocusNextPrevChild(uint self, int next)
		{
			int result;
			try
			{
				GraphicsView instance;
				if (!InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalFocusNextPrevChild(next != 0) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalFocusNextPrevChild", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.GraphicsView.InternalDragEnterEvent( ... )
		/// </summary>
		// Token: 0x06001183 RID: 4483 RVA: 0x00030AE8 File Offset: 0x0002ECE8
		[UnmanagedCallersOnly]
		internal static int Tools_Grphcs_InternalDragEnterEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				GraphicsView instance;
				if (!InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragEnterEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalDragEnterEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.GraphicsView.InternalDragMoveEvent( ... )
		/// </summary>
		// Token: 0x06001184 RID: 4484 RVA: 0x00030B40 File Offset: 0x0002ED40
		[UnmanagedCallersOnly]
		internal static int Tools_Grphcs_InternalDragMoveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				GraphicsView instance;
				if (!InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragMoveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalDragMoveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.GraphicsView.InternalDragLeaveEvent( ... )
		/// </summary>
		// Token: 0x06001185 RID: 4485 RVA: 0x00030B98 File Offset: 0x0002ED98
		[UnmanagedCallersOnly]
		internal static int Tools_Grphcs_InternalDragLeaveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				GraphicsView instance;
				if (!InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragLeaveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalDragLeaveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.GraphicsView.InternalDropEvent( ... )
		/// </summary>
		// Token: 0x06001186 RID: 4486 RVA: 0x00030BF0 File Offset: 0x0002EDF0
		[UnmanagedCallersOnly]
		internal static int Tools_Grphcs_InternalDropEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				GraphicsView instance;
				if (!InteropSystem.TryGetObject<GraphicsView>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDropEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsView", "InternalDropEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.GraphicsWidget.Poop( ... )
		/// </summary>
		// Token: 0x06001187 RID: 4487 RVA: 0x00030C48 File Offset: 0x0002EE48
		[UnmanagedCallersOnly]
		internal static void Tools_Grphcs_Poop(uint self)
		{
			try
			{
				GraphicsWidget instance;
				if (InteropSystem.TryGetObject<GraphicsWidget>(self, out instance))
				{
					instance.Poop();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.GraphicsWidget", "Poop", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalTextChanged( ... )
		/// </summary>
		// Token: 0x06001188 RID: 4488 RVA: 0x00030C8C File Offset: 0x0002EE8C
		[UnmanagedCallersOnly]
		internal static void Tools_LneEdt_InternalTextChanged(uint self, IntPtr s)
		{
			try
			{
				LineEdit instance;
				if (InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					instance.InternalTextChanged(Interop.GetWString(s));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalTextChanged", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalTextEdited( ... )
		/// </summary>
		// Token: 0x06001189 RID: 4489 RVA: 0x00030CD8 File Offset: 0x0002EED8
		[UnmanagedCallersOnly]
		internal static void Tools_LneEdt_InternalTextEdited(uint self, IntPtr s)
		{
			try
			{
				LineEdit instance;
				if (InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					instance.InternalTextEdited(Interop.GetWString(s));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalTextEdited", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalReturnPressed( ... )
		/// </summary>
		// Token: 0x0600118A RID: 4490 RVA: 0x00030D24 File Offset: 0x0002EF24
		[UnmanagedCallersOnly]
		internal static void Tools_LneEdt_InternalReturnPressed(uint self)
		{
			try
			{
				LineEdit instance;
				if (InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					instance.InternalReturnPressed();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalReturnPressed", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalEditingFinished( ... )
		/// </summary>
		// Token: 0x0600118B RID: 4491 RVA: 0x00030D68 File Offset: 0x0002EF68
		[UnmanagedCallersOnly]
		internal static void Tools_LneEdt_InternalEditingFinished(uint self)
		{
			try
			{
				LineEdit instance;
				if (InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					instance.InternalEditingFinished();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalEditingFinished", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalOnEvent( ... )
		/// </summary>
		// Token: 0x0600118C RID: 4492 RVA: 0x00030DAC File Offset: 0x0002EFAC
		[UnmanagedCallersOnly]
		internal static void Tools_LneEdt_InternalOnEvent(uint self, long e)
		{
			try
			{
				LineEdit instance;
				if (InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					instance.InternalOnEvent((EventType)e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalOnEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalMousePressEvent( ... )
		/// </summary>
		// Token: 0x0600118D RID: 4493 RVA: 0x00030DF4 File Offset: 0x0002EFF4
		[UnmanagedCallersOnly]
		internal static void Tools_LneEdt_InternalMousePressEvent(uint self, IntPtr e)
		{
			try
			{
				LineEdit instance;
				if (InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					instance.InternalMousePressEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalMousePressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalMouseEnterEvent( ... )
		/// </summary>
		// Token: 0x0600118E RID: 4494 RVA: 0x00030E40 File Offset: 0x0002F040
		[UnmanagedCallersOnly]
		internal static void Tools_LneEdt_InternalMouseEnterEvent(uint self, IntPtr e)
		{
			try
			{
				LineEdit instance;
				if (InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					instance.InternalMouseEnterEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalMouseEnterEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalMouseLeaveEvent( ... )
		/// </summary>
		// Token: 0x0600118F RID: 4495 RVA: 0x00030E8C File Offset: 0x0002F08C
		[UnmanagedCallersOnly]
		internal static void Tools_LneEdt_InternalMouseLeaveEvent(uint self, IntPtr e)
		{
			try
			{
				LineEdit instance;
				if (InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					instance.InternalMouseLeaveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalMouseLeaveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalMouseReleaseEvent( ... )
		/// </summary>
		// Token: 0x06001190 RID: 4496 RVA: 0x00030ED8 File Offset: 0x0002F0D8
		[UnmanagedCallersOnly]
		internal static void Tools_LneEdt_InternalMouseReleaseEvent(uint self, IntPtr e)
		{
			try
			{
				LineEdit instance;
				if (InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					instance.InternalMouseReleaseEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalMouseReleaseEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalMouseMoveEvent( ... )
		/// </summary>
		// Token: 0x06001191 RID: 4497 RVA: 0x00030F24 File Offset: 0x0002F124
		[UnmanagedCallersOnly]
		internal static void Tools_LneEdt_InternalMouseMoveEvent(uint self, IntPtr e)
		{
			try
			{
				LineEdit instance;
				if (InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					instance.InternalMouseMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalMouseMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalMouseDoubleClickEvent( ... )
		/// </summary>
		// Token: 0x06001192 RID: 4498 RVA: 0x00030F70 File Offset: 0x0002F170
		[UnmanagedCallersOnly]
		internal static void Tools_LneEdt_InternalMouseDoubleClickEvent(uint self, IntPtr e)
		{
			try
			{
				LineEdit instance;
				if (InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					instance.InternalMouseDoubleClickEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalMouseDoubleClickEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalWheelEvent( ... )
		/// </summary>
		// Token: 0x06001193 RID: 4499 RVA: 0x00030FBC File Offset: 0x0002F1BC
		[UnmanagedCallersOnly]
		internal static void Tools_LneEdt_InternalWheelEvent(uint self, IntPtr e)
		{
			try
			{
				LineEdit instance;
				if (InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					instance.InternalWheelEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalWheelEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalContextMenuEvent( ... )
		/// </summary>
		// Token: 0x06001194 RID: 4500 RVA: 0x00031008 File Offset: 0x0002F208
		[UnmanagedCallersOnly]
		internal static void Tools_LneEdt_InternalContextMenuEvent(uint self, IntPtr e)
		{
			try
			{
				LineEdit instance;
				if (InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					instance.InternalContextMenuEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalContextMenuEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalKeyPressEvent( ... )
		/// </summary>
		// Token: 0x06001195 RID: 4501 RVA: 0x00031054 File Offset: 0x0002F254
		[UnmanagedCallersOnly]
		internal static void Tools_LneEdt_InternalKeyPressEvent(uint self, IntPtr pEvent)
		{
			try
			{
				LineEdit instance;
				if (InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					instance.InternalKeyPressEvent(pEvent);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalKeyPressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalFocusInEvent( ... )
		/// </summary>
		// Token: 0x06001196 RID: 4502 RVA: 0x000310A0 File Offset: 0x0002F2A0
		[UnmanagedCallersOnly]
		internal static void Tools_LneEdt_InternalFocusInEvent(uint self, long reason)
		{
			try
			{
				LineEdit instance;
				if (InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					instance.InternalFocusInEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalFocusInEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalFocusOutEvent( ... )
		/// </summary>
		// Token: 0x06001197 RID: 4503 RVA: 0x000310E8 File Offset: 0x0002F2E8
		[UnmanagedCallersOnly]
		internal static void Tools_LneEdt_InternalFocusOutEvent(uint self, long reason)
		{
			try
			{
				LineEdit instance;
				if (InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					instance.InternalFocusOutEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalFocusOutEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalOnResizeEvent( ... )
		/// </summary>
		// Token: 0x06001198 RID: 4504 RVA: 0x00031130 File Offset: 0x0002F330
		[UnmanagedCallersOnly]
		internal static void Tools_LneEdt_InternalOnResizeEvent(uint self, IntPtr e)
		{
			try
			{
				LineEdit instance;
				if (InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					instance.InternalOnResizeEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalOnResizeEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalOnMoveEvent( ... )
		/// </summary>
		// Token: 0x06001199 RID: 4505 RVA: 0x0003117C File Offset: 0x0002F37C
		[UnmanagedCallersOnly]
		internal static void Tools_LneEdt_InternalOnMoveEvent(uint self, IntPtr e)
		{
			try
			{
				LineEdit instance;
				if (InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					instance.InternalOnMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalOnMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.LineEdit.InternalPaintEvent( ... )
		/// </summary>
		// Token: 0x0600119A RID: 4506 RVA: 0x000311C8 File Offset: 0x0002F3C8
		[UnmanagedCallersOnly]
		internal static int Tools_LneEdt_InternalPaintEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				LineEdit instance;
				if (!InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalPaintEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalPaintEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.LineEdit.InternalFocusNextPrevChild( ... )
		/// </summary>
		// Token: 0x0600119B RID: 4507 RVA: 0x00031220 File Offset: 0x0002F420
		[UnmanagedCallersOnly]
		internal static int Tools_LneEdt_InternalFocusNextPrevChild(uint self, int next)
		{
			int result;
			try
			{
				LineEdit instance;
				if (!InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalFocusNextPrevChild(next != 0) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalFocusNextPrevChild", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.LineEdit.InternalDragEnterEvent( ... )
		/// </summary>
		// Token: 0x0600119C RID: 4508 RVA: 0x00031274 File Offset: 0x0002F474
		[UnmanagedCallersOnly]
		internal static int Tools_LneEdt_InternalDragEnterEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				LineEdit instance;
				if (!InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragEnterEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalDragEnterEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.LineEdit.InternalDragMoveEvent( ... )
		/// </summary>
		// Token: 0x0600119D RID: 4509 RVA: 0x000312CC File Offset: 0x0002F4CC
		[UnmanagedCallersOnly]
		internal static int Tools_LneEdt_InternalDragMoveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				LineEdit instance;
				if (!InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragMoveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalDragMoveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.LineEdit.InternalDragLeaveEvent( ... )
		/// </summary>
		// Token: 0x0600119E RID: 4510 RVA: 0x00031324 File Offset: 0x0002F524
		[UnmanagedCallersOnly]
		internal static int Tools_LneEdt_InternalDragLeaveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				LineEdit instance;
				if (!InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragLeaveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalDragLeaveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.LineEdit.InternalDropEvent( ... )
		/// </summary>
		// Token: 0x0600119F RID: 4511 RVA: 0x0003137C File Offset: 0x0002F57C
		[UnmanagedCallersOnly]
		internal static int Tools_LneEdt_InternalDropEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				LineEdit instance;
				if (!InteropSystem.TryGetObject<LineEdit>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDropEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.LineEdit", "InternalDropEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ListView.InternalItemPressed( ... )
		/// </summary>
		// Token: 0x060011A0 RID: 4512 RVA: 0x000313D4 File Offset: 0x0002F5D4
		[UnmanagedCallersOnly]
		internal static void Tools_LstVew_InternalItemPressed(uint self, ModelIndex index)
		{
			try
			{
				ListView instance;
				if (InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					instance.InternalItemPressed(index);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalItemPressed", ___e);
			}
		}

		/// <summary>
		/// Tools.ListView.InternalItemClicked( ... )
		/// </summary>
		// Token: 0x060011A1 RID: 4513 RVA: 0x0003141C File Offset: 0x0002F61C
		[UnmanagedCallersOnly]
		internal static void Tools_LstVew_InternalItemClicked(uint self, ModelIndex index)
		{
			try
			{
				ListView instance;
				if (InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					instance.InternalItemClicked(index);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalItemClicked", ___e);
			}
		}

		/// <summary>
		/// Tools.ListView.InternalItemDoubleClicked( ... )
		/// </summary>
		// Token: 0x060011A2 RID: 4514 RVA: 0x00031464 File Offset: 0x0002F664
		[UnmanagedCallersOnly]
		internal static void Tools_LstVew_InternalItemDoubleClicked(uint self, ModelIndex index)
		{
			try
			{
				ListView instance;
				if (InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					instance.InternalItemDoubleClicked(index);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalItemDoubleClicked", ___e);
			}
		}

		/// <summary>
		/// Tools.ListView.InternalCurrentChanged( ... )
		/// </summary>
		// Token: 0x060011A3 RID: 4515 RVA: 0x000314AC File Offset: 0x0002F6AC
		[UnmanagedCallersOnly]
		internal static void Tools_LstVew_InternalCurrentChanged(uint self, ModelIndex current, ModelIndex previous)
		{
			try
			{
				ListView instance;
				if (InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					instance.InternalCurrentChanged(current, previous);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalCurrentChanged", ___e);
			}
		}

		/// <summary>
		/// Tools.ListView.InternalOnEvent( ... )
		/// </summary>
		// Token: 0x060011A4 RID: 4516 RVA: 0x000314F4 File Offset: 0x0002F6F4
		[UnmanagedCallersOnly]
		internal static void Tools_LstVew_InternalOnEvent(uint self, long e)
		{
			try
			{
				ListView instance;
				if (InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					instance.InternalOnEvent((EventType)e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalOnEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ListView.InternalMousePressEvent( ... )
		/// </summary>
		// Token: 0x060011A5 RID: 4517 RVA: 0x0003153C File Offset: 0x0002F73C
		[UnmanagedCallersOnly]
		internal static void Tools_LstVew_InternalMousePressEvent(uint self, IntPtr e)
		{
			try
			{
				ListView instance;
				if (InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					instance.InternalMousePressEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalMousePressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ListView.InternalMouseEnterEvent( ... )
		/// </summary>
		// Token: 0x060011A6 RID: 4518 RVA: 0x00031588 File Offset: 0x0002F788
		[UnmanagedCallersOnly]
		internal static void Tools_LstVew_InternalMouseEnterEvent(uint self, IntPtr e)
		{
			try
			{
				ListView instance;
				if (InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					instance.InternalMouseEnterEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalMouseEnterEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ListView.InternalMouseLeaveEvent( ... )
		/// </summary>
		// Token: 0x060011A7 RID: 4519 RVA: 0x000315D4 File Offset: 0x0002F7D4
		[UnmanagedCallersOnly]
		internal static void Tools_LstVew_InternalMouseLeaveEvent(uint self, IntPtr e)
		{
			try
			{
				ListView instance;
				if (InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					instance.InternalMouseLeaveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalMouseLeaveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ListView.InternalMouseReleaseEvent( ... )
		/// </summary>
		// Token: 0x060011A8 RID: 4520 RVA: 0x00031620 File Offset: 0x0002F820
		[UnmanagedCallersOnly]
		internal static void Tools_LstVew_InternalMouseReleaseEvent(uint self, IntPtr e)
		{
			try
			{
				ListView instance;
				if (InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					instance.InternalMouseReleaseEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalMouseReleaseEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ListView.InternalMouseMoveEvent( ... )
		/// </summary>
		// Token: 0x060011A9 RID: 4521 RVA: 0x0003166C File Offset: 0x0002F86C
		[UnmanagedCallersOnly]
		internal static void Tools_LstVew_InternalMouseMoveEvent(uint self, IntPtr e)
		{
			try
			{
				ListView instance;
				if (InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					instance.InternalMouseMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalMouseMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ListView.InternalMouseDoubleClickEvent( ... )
		/// </summary>
		// Token: 0x060011AA RID: 4522 RVA: 0x000316B8 File Offset: 0x0002F8B8
		[UnmanagedCallersOnly]
		internal static void Tools_LstVew_InternalMouseDoubleClickEvent(uint self, IntPtr e)
		{
			try
			{
				ListView instance;
				if (InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					instance.InternalMouseDoubleClickEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalMouseDoubleClickEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ListView.InternalWheelEvent( ... )
		/// </summary>
		// Token: 0x060011AB RID: 4523 RVA: 0x00031704 File Offset: 0x0002F904
		[UnmanagedCallersOnly]
		internal static void Tools_LstVew_InternalWheelEvent(uint self, IntPtr e)
		{
			try
			{
				ListView instance;
				if (InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					instance.InternalWheelEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalWheelEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ListView.InternalContextMenuEvent( ... )
		/// </summary>
		// Token: 0x060011AC RID: 4524 RVA: 0x00031750 File Offset: 0x0002F950
		[UnmanagedCallersOnly]
		internal static void Tools_LstVew_InternalContextMenuEvent(uint self, IntPtr e)
		{
			try
			{
				ListView instance;
				if (InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					instance.InternalContextMenuEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalContextMenuEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ListView.InternalKeyPressEvent( ... )
		/// </summary>
		// Token: 0x060011AD RID: 4525 RVA: 0x0003179C File Offset: 0x0002F99C
		[UnmanagedCallersOnly]
		internal static void Tools_LstVew_InternalKeyPressEvent(uint self, IntPtr pEvent)
		{
			try
			{
				ListView instance;
				if (InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					instance.InternalKeyPressEvent(pEvent);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalKeyPressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ListView.InternalFocusInEvent( ... )
		/// </summary>
		// Token: 0x060011AE RID: 4526 RVA: 0x000317E8 File Offset: 0x0002F9E8
		[UnmanagedCallersOnly]
		internal static void Tools_LstVew_InternalFocusInEvent(uint self, long reason)
		{
			try
			{
				ListView instance;
				if (InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					instance.InternalFocusInEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalFocusInEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ListView.InternalFocusOutEvent( ... )
		/// </summary>
		// Token: 0x060011AF RID: 4527 RVA: 0x00031830 File Offset: 0x0002FA30
		[UnmanagedCallersOnly]
		internal static void Tools_LstVew_InternalFocusOutEvent(uint self, long reason)
		{
			try
			{
				ListView instance;
				if (InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					instance.InternalFocusOutEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalFocusOutEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ListView.InternalOnResizeEvent( ... )
		/// </summary>
		// Token: 0x060011B0 RID: 4528 RVA: 0x00031878 File Offset: 0x0002FA78
		[UnmanagedCallersOnly]
		internal static void Tools_LstVew_InternalOnResizeEvent(uint self, IntPtr e)
		{
			try
			{
				ListView instance;
				if (InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					instance.InternalOnResizeEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalOnResizeEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ListView.InternalOnMoveEvent( ... )
		/// </summary>
		// Token: 0x060011B1 RID: 4529 RVA: 0x000318C4 File Offset: 0x0002FAC4
		[UnmanagedCallersOnly]
		internal static void Tools_LstVew_InternalOnMoveEvent(uint self, IntPtr e)
		{
			try
			{
				ListView instance;
				if (InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					instance.InternalOnMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalOnMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ListView.InternalPaintEvent( ... )
		/// </summary>
		// Token: 0x060011B2 RID: 4530 RVA: 0x00031910 File Offset: 0x0002FB10
		[UnmanagedCallersOnly]
		internal static int Tools_LstVew_InternalPaintEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				ListView instance;
				if (!InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalPaintEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalPaintEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ListView.InternalFocusNextPrevChild( ... )
		/// </summary>
		// Token: 0x060011B3 RID: 4531 RVA: 0x00031968 File Offset: 0x0002FB68
		[UnmanagedCallersOnly]
		internal static int Tools_LstVew_InternalFocusNextPrevChild(uint self, int next)
		{
			int result;
			try
			{
				ListView instance;
				if (!InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalFocusNextPrevChild(next != 0) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalFocusNextPrevChild", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ListView.InternalDragEnterEvent( ... )
		/// </summary>
		// Token: 0x060011B4 RID: 4532 RVA: 0x000319BC File Offset: 0x0002FBBC
		[UnmanagedCallersOnly]
		internal static int Tools_LstVew_InternalDragEnterEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				ListView instance;
				if (!InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragEnterEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalDragEnterEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ListView.InternalDragMoveEvent( ... )
		/// </summary>
		// Token: 0x060011B5 RID: 4533 RVA: 0x00031A14 File Offset: 0x0002FC14
		[UnmanagedCallersOnly]
		internal static int Tools_LstVew_InternalDragMoveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				ListView instance;
				if (!InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragMoveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalDragMoveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ListView.InternalDragLeaveEvent( ... )
		/// </summary>
		// Token: 0x060011B6 RID: 4534 RVA: 0x00031A6C File Offset: 0x0002FC6C
		[UnmanagedCallersOnly]
		internal static int Tools_LstVew_InternalDragLeaveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				ListView instance;
				if (!InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragLeaveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalDragLeaveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ListView.InternalDropEvent( ... )
		/// </summary>
		// Token: 0x060011B7 RID: 4535 RVA: 0x00031AC4 File Offset: 0x0002FCC4
		[UnmanagedCallersOnly]
		internal static int Tools_LstVew_InternalDropEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				ListView instance;
				if (!InteropSystem.TryGetObject<ListView>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDropEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ListView", "InternalDropEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ManagedTools.InitStart( ... )
		/// </summary>
		// Token: 0x060011B8 RID: 4536 RVA: 0x00031B1C File Offset: 0x0002FD1C
		[UnmanagedCallersOnly]
		internal static void Tools_MngedT_InitStart()
		{
			try
			{
				ManagedTools.InitStart();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ManagedTools", "InitStart", ___e);
			}
		}

		/// <summary>
		/// Tools.ManagedTools.InitFinish( ... )
		/// </summary>
		// Token: 0x060011B9 RID: 4537 RVA: 0x00031B54 File Offset: 0x0002FD54
		[UnmanagedCallersOnly]
		internal static void Tools_MngedT_InitFinish()
		{
			try
			{
				ManagedTools.InitFinish();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ManagedTools", "InitFinish", ___e);
			}
		}

		/// <summary>
		/// Tools.ManagedTools.RunFrame( ... )
		/// </summary>
		// Token: 0x060011BA RID: 4538 RVA: 0x00031B8C File Offset: 0x0002FD8C
		[UnmanagedCallersOnly]
		internal static void Tools_MngedT_RunFrame()
		{
			try
			{
				ManagedTools.RunFrame();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ManagedTools", "RunFrame", ___e);
			}
		}

		/// <summary>
		/// Tools.ManagedTools.Shutdown( ... )
		/// </summary>
		// Token: 0x060011BB RID: 4539 RVA: 0x00031BC4 File Offset: 0x0002FDC4
		[UnmanagedCallersOnly]
		internal static void Tools_MngedT_Shutdown()
		{
			try
			{
				ManagedTools.Shutdown();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ManagedTools", "Shutdown", ___e);
			}
		}

		/// <summary>
		/// Tools.ManagedTools.NativeHook( ... )
		/// </summary>
		// Token: 0x060011BC RID: 4540 RVA: 0x00031BFC File Offset: 0x0002FDFC
		[UnmanagedCallersOnly]
		internal static void Tools_MngedT_NativeHook(IntPtr name, IntPtr arg0, IntPtr arg1, IntPtr arg2)
		{
			try
			{
				ManagedTools.NativeHook(Interop.GetString(name), arg0, arg1, arg2);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ManagedTools", "NativeHook", ___e);
			}
		}

		/// <summary>
		/// Tools.ManagedTools.GlobalMousePressed( ... )
		/// </summary>
		// Token: 0x060011BD RID: 4541 RVA: 0x00031C3C File Offset: 0x0002FE3C
		[UnmanagedCallersOnly]
		internal static void Tools_MngedT_GlobalMousePressed()
		{
			try
			{
				ManagedTools.GlobalMousePressed();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ManagedTools", "GlobalMousePressed", ___e);
			}
		}

		/// <summary>
		/// Tools.ManagedTools.GlobalKeyPressed( ... )
		/// </summary>
		// Token: 0x060011BE RID: 4542 RVA: 0x00031C74 File Offset: 0x0002FE74
		[UnmanagedCallersOnly]
		internal static int Tools_MngedT_GlobalKeyPressed(int press, int key)
		{
			int result;
			try
			{
				result = (ManagedTools.GlobalKeyPressed(press != 0, key) ? 1 : 0);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ManagedTools", "GlobalKeyPressed", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ManagedTools.OnToolCommand( ... )
		/// </summary>
		// Token: 0x060011BF RID: 4543 RVA: 0x00031CBC File Offset: 0x0002FEBC
		[UnmanagedCallersOnly]
		internal static void Tools_MngedT_OnToolCommand(IntPtr str)
		{
			try
			{
				ManagedTools.OnToolCommand(Interop.GetString(str));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ManagedTools", "OnToolCommand", ___e);
			}
		}

		/// <summary>
		/// Tools.MenuBar.InternalOnEvent( ... )
		/// </summary>
		// Token: 0x060011C0 RID: 4544 RVA: 0x00031CFC File Offset: 0x0002FEFC
		[UnmanagedCallersOnly]
		internal static void Tools_MenuBa_InternalOnEvent(uint self, long e)
		{
			try
			{
				MenuBar instance;
				if (InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					instance.InternalOnEvent((EventType)e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalOnEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.MenuBar.InternalMousePressEvent( ... )
		/// </summary>
		// Token: 0x060011C1 RID: 4545 RVA: 0x00031D44 File Offset: 0x0002FF44
		[UnmanagedCallersOnly]
		internal static void Tools_MenuBa_InternalMousePressEvent(uint self, IntPtr e)
		{
			try
			{
				MenuBar instance;
				if (InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					instance.InternalMousePressEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalMousePressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.MenuBar.InternalMouseEnterEvent( ... )
		/// </summary>
		// Token: 0x060011C2 RID: 4546 RVA: 0x00031D90 File Offset: 0x0002FF90
		[UnmanagedCallersOnly]
		internal static void Tools_MenuBa_InternalMouseEnterEvent(uint self, IntPtr e)
		{
			try
			{
				MenuBar instance;
				if (InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					instance.InternalMouseEnterEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalMouseEnterEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.MenuBar.InternalMouseLeaveEvent( ... )
		/// </summary>
		// Token: 0x060011C3 RID: 4547 RVA: 0x00031DDC File Offset: 0x0002FFDC
		[UnmanagedCallersOnly]
		internal static void Tools_MenuBa_InternalMouseLeaveEvent(uint self, IntPtr e)
		{
			try
			{
				MenuBar instance;
				if (InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					instance.InternalMouseLeaveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalMouseLeaveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.MenuBar.InternalMouseReleaseEvent( ... )
		/// </summary>
		// Token: 0x060011C4 RID: 4548 RVA: 0x00031E28 File Offset: 0x00030028
		[UnmanagedCallersOnly]
		internal static void Tools_MenuBa_InternalMouseReleaseEvent(uint self, IntPtr e)
		{
			try
			{
				MenuBar instance;
				if (InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					instance.InternalMouseReleaseEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalMouseReleaseEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.MenuBar.InternalMouseMoveEvent( ... )
		/// </summary>
		// Token: 0x060011C5 RID: 4549 RVA: 0x00031E74 File Offset: 0x00030074
		[UnmanagedCallersOnly]
		internal static void Tools_MenuBa_InternalMouseMoveEvent(uint self, IntPtr e)
		{
			try
			{
				MenuBar instance;
				if (InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					instance.InternalMouseMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalMouseMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.MenuBar.InternalMouseDoubleClickEvent( ... )
		/// </summary>
		// Token: 0x060011C6 RID: 4550 RVA: 0x00031EC0 File Offset: 0x000300C0
		[UnmanagedCallersOnly]
		internal static void Tools_MenuBa_InternalMouseDoubleClickEvent(uint self, IntPtr e)
		{
			try
			{
				MenuBar instance;
				if (InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					instance.InternalMouseDoubleClickEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalMouseDoubleClickEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.MenuBar.InternalWheelEvent( ... )
		/// </summary>
		// Token: 0x060011C7 RID: 4551 RVA: 0x00031F0C File Offset: 0x0003010C
		[UnmanagedCallersOnly]
		internal static void Tools_MenuBa_InternalWheelEvent(uint self, IntPtr e)
		{
			try
			{
				MenuBar instance;
				if (InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					instance.InternalWheelEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalWheelEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.MenuBar.InternalContextMenuEvent( ... )
		/// </summary>
		// Token: 0x060011C8 RID: 4552 RVA: 0x00031F58 File Offset: 0x00030158
		[UnmanagedCallersOnly]
		internal static void Tools_MenuBa_InternalContextMenuEvent(uint self, IntPtr e)
		{
			try
			{
				MenuBar instance;
				if (InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					instance.InternalContextMenuEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalContextMenuEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.MenuBar.InternalKeyPressEvent( ... )
		/// </summary>
		// Token: 0x060011C9 RID: 4553 RVA: 0x00031FA4 File Offset: 0x000301A4
		[UnmanagedCallersOnly]
		internal static void Tools_MenuBa_InternalKeyPressEvent(uint self, IntPtr pEvent)
		{
			try
			{
				MenuBar instance;
				if (InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					instance.InternalKeyPressEvent(pEvent);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalKeyPressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.MenuBar.InternalFocusInEvent( ... )
		/// </summary>
		// Token: 0x060011CA RID: 4554 RVA: 0x00031FF0 File Offset: 0x000301F0
		[UnmanagedCallersOnly]
		internal static void Tools_MenuBa_InternalFocusInEvent(uint self, long reason)
		{
			try
			{
				MenuBar instance;
				if (InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					instance.InternalFocusInEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalFocusInEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.MenuBar.InternalFocusOutEvent( ... )
		/// </summary>
		// Token: 0x060011CB RID: 4555 RVA: 0x00032038 File Offset: 0x00030238
		[UnmanagedCallersOnly]
		internal static void Tools_MenuBa_InternalFocusOutEvent(uint self, long reason)
		{
			try
			{
				MenuBar instance;
				if (InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					instance.InternalFocusOutEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalFocusOutEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.MenuBar.InternalOnResizeEvent( ... )
		/// </summary>
		// Token: 0x060011CC RID: 4556 RVA: 0x00032080 File Offset: 0x00030280
		[UnmanagedCallersOnly]
		internal static void Tools_MenuBa_InternalOnResizeEvent(uint self, IntPtr e)
		{
			try
			{
				MenuBar instance;
				if (InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					instance.InternalOnResizeEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalOnResizeEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.MenuBar.InternalOnMoveEvent( ... )
		/// </summary>
		// Token: 0x060011CD RID: 4557 RVA: 0x000320CC File Offset: 0x000302CC
		[UnmanagedCallersOnly]
		internal static void Tools_MenuBa_InternalOnMoveEvent(uint self, IntPtr e)
		{
			try
			{
				MenuBar instance;
				if (InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					instance.InternalOnMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalOnMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.MenuBar.InternalPaintEvent( ... )
		/// </summary>
		// Token: 0x060011CE RID: 4558 RVA: 0x00032118 File Offset: 0x00030318
		[UnmanagedCallersOnly]
		internal static int Tools_MenuBa_InternalPaintEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				MenuBar instance;
				if (!InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalPaintEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalPaintEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.MenuBar.InternalFocusNextPrevChild( ... )
		/// </summary>
		// Token: 0x060011CF RID: 4559 RVA: 0x00032170 File Offset: 0x00030370
		[UnmanagedCallersOnly]
		internal static int Tools_MenuBa_InternalFocusNextPrevChild(uint self, int next)
		{
			int result;
			try
			{
				MenuBar instance;
				if (!InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalFocusNextPrevChild(next != 0) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalFocusNextPrevChild", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.MenuBar.InternalDragEnterEvent( ... )
		/// </summary>
		// Token: 0x060011D0 RID: 4560 RVA: 0x000321C4 File Offset: 0x000303C4
		[UnmanagedCallersOnly]
		internal static int Tools_MenuBa_InternalDragEnterEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				MenuBar instance;
				if (!InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragEnterEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalDragEnterEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.MenuBar.InternalDragMoveEvent( ... )
		/// </summary>
		// Token: 0x060011D1 RID: 4561 RVA: 0x0003221C File Offset: 0x0003041C
		[UnmanagedCallersOnly]
		internal static int Tools_MenuBa_InternalDragMoveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				MenuBar instance;
				if (!InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragMoveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalDragMoveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.MenuBar.InternalDragLeaveEvent( ... )
		/// </summary>
		// Token: 0x060011D2 RID: 4562 RVA: 0x00032274 File Offset: 0x00030474
		[UnmanagedCallersOnly]
		internal static int Tools_MenuBa_InternalDragLeaveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				MenuBar instance;
				if (!InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragLeaveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalDragLeaveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.MenuBar.InternalDropEvent( ... )
		/// </summary>
		// Token: 0x060011D3 RID: 4563 RVA: 0x000322CC File Offset: 0x000304CC
		[UnmanagedCallersOnly]
		internal static int Tools_MenuBa_InternalDropEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				MenuBar instance;
				if (!InteropSystem.TryGetObject<MenuBar>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDropEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.MenuBar", "InternalDropEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Option.InternalTriggered( ... )
		/// </summary>
		// Token: 0x060011D4 RID: 4564 RVA: 0x00032324 File Offset: 0x00030524
		[UnmanagedCallersOnly]
		internal static void Tools_Option_InternalTriggered(uint self)
		{
			try
			{
				Option instance;
				if (InteropSystem.TryGetObject<Option>(self, out instance))
				{
					instance.InternalTriggered();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Option", "InternalTriggered", ___e);
			}
		}

		/// <summary>
		/// Tools.Option.InternalToggled( ... )
		/// </summary>
		// Token: 0x060011D5 RID: 4565 RVA: 0x00032368 File Offset: 0x00030568
		[UnmanagedCallersOnly]
		internal static void Tools_Option_InternalToggled(uint self, int b)
		{
			try
			{
				Option instance;
				if (InteropSystem.TryGetObject<Option>(self, out instance))
				{
					instance.InternalToggled(b != 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Option", "InternalToggled", ___e);
			}
		}

		/// <summary>
		/// Tools.StatusBar.InternalOnEvent( ... )
		/// </summary>
		// Token: 0x060011D6 RID: 4566 RVA: 0x000323B0 File Offset: 0x000305B0
		[UnmanagedCallersOnly]
		internal static void Tools_SttsBr_InternalOnEvent(uint self, long e)
		{
			try
			{
				StatusBar instance;
				if (InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					instance.InternalOnEvent((EventType)e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalOnEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.StatusBar.InternalMousePressEvent( ... )
		/// </summary>
		// Token: 0x060011D7 RID: 4567 RVA: 0x000323F8 File Offset: 0x000305F8
		[UnmanagedCallersOnly]
		internal static void Tools_SttsBr_InternalMousePressEvent(uint self, IntPtr e)
		{
			try
			{
				StatusBar instance;
				if (InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					instance.InternalMousePressEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalMousePressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.StatusBar.InternalMouseEnterEvent( ... )
		/// </summary>
		// Token: 0x060011D8 RID: 4568 RVA: 0x00032444 File Offset: 0x00030644
		[UnmanagedCallersOnly]
		internal static void Tools_SttsBr_InternalMouseEnterEvent(uint self, IntPtr e)
		{
			try
			{
				StatusBar instance;
				if (InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					instance.InternalMouseEnterEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalMouseEnterEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.StatusBar.InternalMouseLeaveEvent( ... )
		/// </summary>
		// Token: 0x060011D9 RID: 4569 RVA: 0x00032490 File Offset: 0x00030690
		[UnmanagedCallersOnly]
		internal static void Tools_SttsBr_InternalMouseLeaveEvent(uint self, IntPtr e)
		{
			try
			{
				StatusBar instance;
				if (InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					instance.InternalMouseLeaveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalMouseLeaveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.StatusBar.InternalMouseReleaseEvent( ... )
		/// </summary>
		// Token: 0x060011DA RID: 4570 RVA: 0x000324DC File Offset: 0x000306DC
		[UnmanagedCallersOnly]
		internal static void Tools_SttsBr_InternalMouseReleaseEvent(uint self, IntPtr e)
		{
			try
			{
				StatusBar instance;
				if (InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					instance.InternalMouseReleaseEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalMouseReleaseEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.StatusBar.InternalMouseMoveEvent( ... )
		/// </summary>
		// Token: 0x060011DB RID: 4571 RVA: 0x00032528 File Offset: 0x00030728
		[UnmanagedCallersOnly]
		internal static void Tools_SttsBr_InternalMouseMoveEvent(uint self, IntPtr e)
		{
			try
			{
				StatusBar instance;
				if (InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					instance.InternalMouseMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalMouseMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.StatusBar.InternalMouseDoubleClickEvent( ... )
		/// </summary>
		// Token: 0x060011DC RID: 4572 RVA: 0x00032574 File Offset: 0x00030774
		[UnmanagedCallersOnly]
		internal static void Tools_SttsBr_InternalMouseDoubleClickEvent(uint self, IntPtr e)
		{
			try
			{
				StatusBar instance;
				if (InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					instance.InternalMouseDoubleClickEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalMouseDoubleClickEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.StatusBar.InternalWheelEvent( ... )
		/// </summary>
		// Token: 0x060011DD RID: 4573 RVA: 0x000325C0 File Offset: 0x000307C0
		[UnmanagedCallersOnly]
		internal static void Tools_SttsBr_InternalWheelEvent(uint self, IntPtr e)
		{
			try
			{
				StatusBar instance;
				if (InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					instance.InternalWheelEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalWheelEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.StatusBar.InternalContextMenuEvent( ... )
		/// </summary>
		// Token: 0x060011DE RID: 4574 RVA: 0x0003260C File Offset: 0x0003080C
		[UnmanagedCallersOnly]
		internal static void Tools_SttsBr_InternalContextMenuEvent(uint self, IntPtr e)
		{
			try
			{
				StatusBar instance;
				if (InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					instance.InternalContextMenuEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalContextMenuEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.StatusBar.InternalKeyPressEvent( ... )
		/// </summary>
		// Token: 0x060011DF RID: 4575 RVA: 0x00032658 File Offset: 0x00030858
		[UnmanagedCallersOnly]
		internal static void Tools_SttsBr_InternalKeyPressEvent(uint self, IntPtr pEvent)
		{
			try
			{
				StatusBar instance;
				if (InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					instance.InternalKeyPressEvent(pEvent);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalKeyPressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.StatusBar.InternalFocusInEvent( ... )
		/// </summary>
		// Token: 0x060011E0 RID: 4576 RVA: 0x000326A4 File Offset: 0x000308A4
		[UnmanagedCallersOnly]
		internal static void Tools_SttsBr_InternalFocusInEvent(uint self, long reason)
		{
			try
			{
				StatusBar instance;
				if (InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					instance.InternalFocusInEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalFocusInEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.StatusBar.InternalFocusOutEvent( ... )
		/// </summary>
		// Token: 0x060011E1 RID: 4577 RVA: 0x000326EC File Offset: 0x000308EC
		[UnmanagedCallersOnly]
		internal static void Tools_SttsBr_InternalFocusOutEvent(uint self, long reason)
		{
			try
			{
				StatusBar instance;
				if (InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					instance.InternalFocusOutEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalFocusOutEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.StatusBar.InternalOnResizeEvent( ... )
		/// </summary>
		// Token: 0x060011E2 RID: 4578 RVA: 0x00032734 File Offset: 0x00030934
		[UnmanagedCallersOnly]
		internal static void Tools_SttsBr_InternalOnResizeEvent(uint self, IntPtr e)
		{
			try
			{
				StatusBar instance;
				if (InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					instance.InternalOnResizeEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalOnResizeEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.StatusBar.InternalOnMoveEvent( ... )
		/// </summary>
		// Token: 0x060011E3 RID: 4579 RVA: 0x00032780 File Offset: 0x00030980
		[UnmanagedCallersOnly]
		internal static void Tools_SttsBr_InternalOnMoveEvent(uint self, IntPtr e)
		{
			try
			{
				StatusBar instance;
				if (InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					instance.InternalOnMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalOnMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.StatusBar.InternalPaintEvent( ... )
		/// </summary>
		// Token: 0x060011E4 RID: 4580 RVA: 0x000327CC File Offset: 0x000309CC
		[UnmanagedCallersOnly]
		internal static int Tools_SttsBr_InternalPaintEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				StatusBar instance;
				if (!InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalPaintEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalPaintEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.StatusBar.InternalFocusNextPrevChild( ... )
		/// </summary>
		// Token: 0x060011E5 RID: 4581 RVA: 0x00032824 File Offset: 0x00030A24
		[UnmanagedCallersOnly]
		internal static int Tools_SttsBr_InternalFocusNextPrevChild(uint self, int next)
		{
			int result;
			try
			{
				StatusBar instance;
				if (!InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalFocusNextPrevChild(next != 0) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalFocusNextPrevChild", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.StatusBar.InternalDragEnterEvent( ... )
		/// </summary>
		// Token: 0x060011E6 RID: 4582 RVA: 0x00032878 File Offset: 0x00030A78
		[UnmanagedCallersOnly]
		internal static int Tools_SttsBr_InternalDragEnterEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				StatusBar instance;
				if (!InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragEnterEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalDragEnterEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.StatusBar.InternalDragMoveEvent( ... )
		/// </summary>
		// Token: 0x060011E7 RID: 4583 RVA: 0x000328D0 File Offset: 0x00030AD0
		[UnmanagedCallersOnly]
		internal static int Tools_SttsBr_InternalDragMoveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				StatusBar instance;
				if (!InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragMoveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalDragMoveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.StatusBar.InternalDragLeaveEvent( ... )
		/// </summary>
		// Token: 0x060011E8 RID: 4584 RVA: 0x00032928 File Offset: 0x00030B28
		[UnmanagedCallersOnly]
		internal static int Tools_SttsBr_InternalDragLeaveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				StatusBar instance;
				if (!InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragLeaveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalDragLeaveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.StatusBar.InternalDropEvent( ... )
		/// </summary>
		// Token: 0x060011E9 RID: 4585 RVA: 0x00032980 File Offset: 0x00030B80
		[UnmanagedCallersOnly]
		internal static int Tools_SttsBr_InternalDropEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				StatusBar instance;
				if (!InteropSystem.TryGetObject<StatusBar>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDropEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.StatusBar", "InternalDropEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.TextEdit.InternalOnEvent( ... )
		/// </summary>
		// Token: 0x060011EA RID: 4586 RVA: 0x000329D8 File Offset: 0x00030BD8
		[UnmanagedCallersOnly]
		internal static void Tools_TextEd_InternalOnEvent(uint self, long e)
		{
			try
			{
				TextEdit instance;
				if (InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					instance.InternalOnEvent((EventType)e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalOnEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TextEdit.InternalMousePressEvent( ... )
		/// </summary>
		// Token: 0x060011EB RID: 4587 RVA: 0x00032A20 File Offset: 0x00030C20
		[UnmanagedCallersOnly]
		internal static void Tools_TextEd_InternalMousePressEvent(uint self, IntPtr e)
		{
			try
			{
				TextEdit instance;
				if (InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					instance.InternalMousePressEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalMousePressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TextEdit.InternalMouseEnterEvent( ... )
		/// </summary>
		// Token: 0x060011EC RID: 4588 RVA: 0x00032A6C File Offset: 0x00030C6C
		[UnmanagedCallersOnly]
		internal static void Tools_TextEd_InternalMouseEnterEvent(uint self, IntPtr e)
		{
			try
			{
				TextEdit instance;
				if (InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					instance.InternalMouseEnterEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalMouseEnterEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TextEdit.InternalMouseLeaveEvent( ... )
		/// </summary>
		// Token: 0x060011ED RID: 4589 RVA: 0x00032AB8 File Offset: 0x00030CB8
		[UnmanagedCallersOnly]
		internal static void Tools_TextEd_InternalMouseLeaveEvent(uint self, IntPtr e)
		{
			try
			{
				TextEdit instance;
				if (InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					instance.InternalMouseLeaveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalMouseLeaveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TextEdit.InternalMouseReleaseEvent( ... )
		/// </summary>
		// Token: 0x060011EE RID: 4590 RVA: 0x00032B04 File Offset: 0x00030D04
		[UnmanagedCallersOnly]
		internal static void Tools_TextEd_InternalMouseReleaseEvent(uint self, IntPtr e)
		{
			try
			{
				TextEdit instance;
				if (InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					instance.InternalMouseReleaseEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalMouseReleaseEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TextEdit.InternalMouseMoveEvent( ... )
		/// </summary>
		// Token: 0x060011EF RID: 4591 RVA: 0x00032B50 File Offset: 0x00030D50
		[UnmanagedCallersOnly]
		internal static void Tools_TextEd_InternalMouseMoveEvent(uint self, IntPtr e)
		{
			try
			{
				TextEdit instance;
				if (InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					instance.InternalMouseMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalMouseMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TextEdit.InternalMouseDoubleClickEvent( ... )
		/// </summary>
		// Token: 0x060011F0 RID: 4592 RVA: 0x00032B9C File Offset: 0x00030D9C
		[UnmanagedCallersOnly]
		internal static void Tools_TextEd_InternalMouseDoubleClickEvent(uint self, IntPtr e)
		{
			try
			{
				TextEdit instance;
				if (InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					instance.InternalMouseDoubleClickEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalMouseDoubleClickEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TextEdit.InternalWheelEvent( ... )
		/// </summary>
		// Token: 0x060011F1 RID: 4593 RVA: 0x00032BE8 File Offset: 0x00030DE8
		[UnmanagedCallersOnly]
		internal static void Tools_TextEd_InternalWheelEvent(uint self, IntPtr e)
		{
			try
			{
				TextEdit instance;
				if (InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					instance.InternalWheelEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalWheelEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TextEdit.InternalContextMenuEvent( ... )
		/// </summary>
		// Token: 0x060011F2 RID: 4594 RVA: 0x00032C34 File Offset: 0x00030E34
		[UnmanagedCallersOnly]
		internal static void Tools_TextEd_InternalContextMenuEvent(uint self, IntPtr e)
		{
			try
			{
				TextEdit instance;
				if (InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					instance.InternalContextMenuEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalContextMenuEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TextEdit.InternalKeyPressEvent( ... )
		/// </summary>
		// Token: 0x060011F3 RID: 4595 RVA: 0x00032C80 File Offset: 0x00030E80
		[UnmanagedCallersOnly]
		internal static void Tools_TextEd_InternalKeyPressEvent(uint self, IntPtr pEvent)
		{
			try
			{
				TextEdit instance;
				if (InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					instance.InternalKeyPressEvent(pEvent);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalKeyPressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TextEdit.InternalFocusInEvent( ... )
		/// </summary>
		// Token: 0x060011F4 RID: 4596 RVA: 0x00032CCC File Offset: 0x00030ECC
		[UnmanagedCallersOnly]
		internal static void Tools_TextEd_InternalFocusInEvent(uint self, long reason)
		{
			try
			{
				TextEdit instance;
				if (InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					instance.InternalFocusInEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalFocusInEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TextEdit.InternalFocusOutEvent( ... )
		/// </summary>
		// Token: 0x060011F5 RID: 4597 RVA: 0x00032D14 File Offset: 0x00030F14
		[UnmanagedCallersOnly]
		internal static void Tools_TextEd_InternalFocusOutEvent(uint self, long reason)
		{
			try
			{
				TextEdit instance;
				if (InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					instance.InternalFocusOutEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalFocusOutEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TextEdit.InternalOnResizeEvent( ... )
		/// </summary>
		// Token: 0x060011F6 RID: 4598 RVA: 0x00032D5C File Offset: 0x00030F5C
		[UnmanagedCallersOnly]
		internal static void Tools_TextEd_InternalOnResizeEvent(uint self, IntPtr e)
		{
			try
			{
				TextEdit instance;
				if (InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					instance.InternalOnResizeEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalOnResizeEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TextEdit.InternalOnMoveEvent( ... )
		/// </summary>
		// Token: 0x060011F7 RID: 4599 RVA: 0x00032DA8 File Offset: 0x00030FA8
		[UnmanagedCallersOnly]
		internal static void Tools_TextEd_InternalOnMoveEvent(uint self, IntPtr e)
		{
			try
			{
				TextEdit instance;
				if (InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					instance.InternalOnMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalOnMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TextEdit.InternalPaintEvent( ... )
		/// </summary>
		// Token: 0x060011F8 RID: 4600 RVA: 0x00032DF4 File Offset: 0x00030FF4
		[UnmanagedCallersOnly]
		internal static int Tools_TextEd_InternalPaintEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				TextEdit instance;
				if (!InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalPaintEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalPaintEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.TextEdit.InternalFocusNextPrevChild( ... )
		/// </summary>
		// Token: 0x060011F9 RID: 4601 RVA: 0x00032E4C File Offset: 0x0003104C
		[UnmanagedCallersOnly]
		internal static int Tools_TextEd_InternalFocusNextPrevChild(uint self, int next)
		{
			int result;
			try
			{
				TextEdit instance;
				if (!InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalFocusNextPrevChild(next != 0) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalFocusNextPrevChild", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.TextEdit.InternalDragEnterEvent( ... )
		/// </summary>
		// Token: 0x060011FA RID: 4602 RVA: 0x00032EA0 File Offset: 0x000310A0
		[UnmanagedCallersOnly]
		internal static int Tools_TextEd_InternalDragEnterEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				TextEdit instance;
				if (!InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragEnterEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalDragEnterEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.TextEdit.InternalDragMoveEvent( ... )
		/// </summary>
		// Token: 0x060011FB RID: 4603 RVA: 0x00032EF8 File Offset: 0x000310F8
		[UnmanagedCallersOnly]
		internal static int Tools_TextEd_InternalDragMoveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				TextEdit instance;
				if (!InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragMoveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalDragMoveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.TextEdit.InternalDragLeaveEvent( ... )
		/// </summary>
		// Token: 0x060011FC RID: 4604 RVA: 0x00032F50 File Offset: 0x00031150
		[UnmanagedCallersOnly]
		internal static int Tools_TextEd_InternalDragLeaveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				TextEdit instance;
				if (!InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragLeaveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalDragLeaveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.TextEdit.InternalDropEvent( ... )
		/// </summary>
		// Token: 0x060011FD RID: 4605 RVA: 0x00032FA8 File Offset: 0x000311A8
		[UnmanagedCallersOnly]
		internal static int Tools_TextEd_InternalDropEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				TextEdit instance;
				if (!InteropSystem.TryGetObject<TextEdit>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDropEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TextEdit", "InternalDropEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ToolBar.InternalOnEvent( ... )
		/// </summary>
		// Token: 0x060011FE RID: 4606 RVA: 0x00033000 File Offset: 0x00031200
		[UnmanagedCallersOnly]
		internal static void Tools_ToolBa_InternalOnEvent(uint self, long e)
		{
			try
			{
				ToolBar instance;
				if (InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					instance.InternalOnEvent((EventType)e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalOnEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ToolBar.InternalMousePressEvent( ... )
		/// </summary>
		// Token: 0x060011FF RID: 4607 RVA: 0x00033048 File Offset: 0x00031248
		[UnmanagedCallersOnly]
		internal static void Tools_ToolBa_InternalMousePressEvent(uint self, IntPtr e)
		{
			try
			{
				ToolBar instance;
				if (InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					instance.InternalMousePressEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalMousePressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ToolBar.InternalMouseEnterEvent( ... )
		/// </summary>
		// Token: 0x06001200 RID: 4608 RVA: 0x00033094 File Offset: 0x00031294
		[UnmanagedCallersOnly]
		internal static void Tools_ToolBa_InternalMouseEnterEvent(uint self, IntPtr e)
		{
			try
			{
				ToolBar instance;
				if (InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					instance.InternalMouseEnterEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalMouseEnterEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ToolBar.InternalMouseLeaveEvent( ... )
		/// </summary>
		// Token: 0x06001201 RID: 4609 RVA: 0x000330E0 File Offset: 0x000312E0
		[UnmanagedCallersOnly]
		internal static void Tools_ToolBa_InternalMouseLeaveEvent(uint self, IntPtr e)
		{
			try
			{
				ToolBar instance;
				if (InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					instance.InternalMouseLeaveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalMouseLeaveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ToolBar.InternalMouseReleaseEvent( ... )
		/// </summary>
		// Token: 0x06001202 RID: 4610 RVA: 0x0003312C File Offset: 0x0003132C
		[UnmanagedCallersOnly]
		internal static void Tools_ToolBa_InternalMouseReleaseEvent(uint self, IntPtr e)
		{
			try
			{
				ToolBar instance;
				if (InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					instance.InternalMouseReleaseEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalMouseReleaseEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ToolBar.InternalMouseMoveEvent( ... )
		/// </summary>
		// Token: 0x06001203 RID: 4611 RVA: 0x00033178 File Offset: 0x00031378
		[UnmanagedCallersOnly]
		internal static void Tools_ToolBa_InternalMouseMoveEvent(uint self, IntPtr e)
		{
			try
			{
				ToolBar instance;
				if (InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					instance.InternalMouseMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalMouseMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ToolBar.InternalMouseDoubleClickEvent( ... )
		/// </summary>
		// Token: 0x06001204 RID: 4612 RVA: 0x000331C4 File Offset: 0x000313C4
		[UnmanagedCallersOnly]
		internal static void Tools_ToolBa_InternalMouseDoubleClickEvent(uint self, IntPtr e)
		{
			try
			{
				ToolBar instance;
				if (InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					instance.InternalMouseDoubleClickEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalMouseDoubleClickEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ToolBar.InternalWheelEvent( ... )
		/// </summary>
		// Token: 0x06001205 RID: 4613 RVA: 0x00033210 File Offset: 0x00031410
		[UnmanagedCallersOnly]
		internal static void Tools_ToolBa_InternalWheelEvent(uint self, IntPtr e)
		{
			try
			{
				ToolBar instance;
				if (InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					instance.InternalWheelEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalWheelEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ToolBar.InternalContextMenuEvent( ... )
		/// </summary>
		// Token: 0x06001206 RID: 4614 RVA: 0x0003325C File Offset: 0x0003145C
		[UnmanagedCallersOnly]
		internal static void Tools_ToolBa_InternalContextMenuEvent(uint self, IntPtr e)
		{
			try
			{
				ToolBar instance;
				if (InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					instance.InternalContextMenuEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalContextMenuEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ToolBar.InternalKeyPressEvent( ... )
		/// </summary>
		// Token: 0x06001207 RID: 4615 RVA: 0x000332A8 File Offset: 0x000314A8
		[UnmanagedCallersOnly]
		internal static void Tools_ToolBa_InternalKeyPressEvent(uint self, IntPtr pEvent)
		{
			try
			{
				ToolBar instance;
				if (InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					instance.InternalKeyPressEvent(pEvent);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalKeyPressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ToolBar.InternalFocusInEvent( ... )
		/// </summary>
		// Token: 0x06001208 RID: 4616 RVA: 0x000332F4 File Offset: 0x000314F4
		[UnmanagedCallersOnly]
		internal static void Tools_ToolBa_InternalFocusInEvent(uint self, long reason)
		{
			try
			{
				ToolBar instance;
				if (InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					instance.InternalFocusInEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalFocusInEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ToolBar.InternalFocusOutEvent( ... )
		/// </summary>
		// Token: 0x06001209 RID: 4617 RVA: 0x0003333C File Offset: 0x0003153C
		[UnmanagedCallersOnly]
		internal static void Tools_ToolBa_InternalFocusOutEvent(uint self, long reason)
		{
			try
			{
				ToolBar instance;
				if (InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					instance.InternalFocusOutEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalFocusOutEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ToolBar.InternalOnResizeEvent( ... )
		/// </summary>
		// Token: 0x0600120A RID: 4618 RVA: 0x00033384 File Offset: 0x00031584
		[UnmanagedCallersOnly]
		internal static void Tools_ToolBa_InternalOnResizeEvent(uint self, IntPtr e)
		{
			try
			{
				ToolBar instance;
				if (InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					instance.InternalOnResizeEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalOnResizeEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ToolBar.InternalOnMoveEvent( ... )
		/// </summary>
		// Token: 0x0600120B RID: 4619 RVA: 0x000333D0 File Offset: 0x000315D0
		[UnmanagedCallersOnly]
		internal static void Tools_ToolBa_InternalOnMoveEvent(uint self, IntPtr e)
		{
			try
			{
				ToolBar instance;
				if (InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					instance.InternalOnMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalOnMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.ToolBar.InternalPaintEvent( ... )
		/// </summary>
		// Token: 0x0600120C RID: 4620 RVA: 0x0003341C File Offset: 0x0003161C
		[UnmanagedCallersOnly]
		internal static int Tools_ToolBa_InternalPaintEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				ToolBar instance;
				if (!InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalPaintEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalPaintEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ToolBar.InternalFocusNextPrevChild( ... )
		/// </summary>
		// Token: 0x0600120D RID: 4621 RVA: 0x00033474 File Offset: 0x00031674
		[UnmanagedCallersOnly]
		internal static int Tools_ToolBa_InternalFocusNextPrevChild(uint self, int next)
		{
			int result;
			try
			{
				ToolBar instance;
				if (!InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalFocusNextPrevChild(next != 0) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalFocusNextPrevChild", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ToolBar.InternalDragEnterEvent( ... )
		/// </summary>
		// Token: 0x0600120E RID: 4622 RVA: 0x000334C8 File Offset: 0x000316C8
		[UnmanagedCallersOnly]
		internal static int Tools_ToolBa_InternalDragEnterEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				ToolBar instance;
				if (!InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragEnterEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalDragEnterEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ToolBar.InternalDragMoveEvent( ... )
		/// </summary>
		// Token: 0x0600120F RID: 4623 RVA: 0x00033520 File Offset: 0x00031720
		[UnmanagedCallersOnly]
		internal static int Tools_ToolBa_InternalDragMoveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				ToolBar instance;
				if (!InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragMoveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalDragMoveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ToolBar.InternalDragLeaveEvent( ... )
		/// </summary>
		// Token: 0x06001210 RID: 4624 RVA: 0x00033578 File Offset: 0x00031778
		[UnmanagedCallersOnly]
		internal static int Tools_ToolBa_InternalDragLeaveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				ToolBar instance;
				if (!InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragLeaveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalDragLeaveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.ToolBar.InternalDropEvent( ... )
		/// </summary>
		// Token: 0x06001211 RID: 4625 RVA: 0x000335D0 File Offset: 0x000317D0
		[UnmanagedCallersOnly]
		internal static int Tools_ToolBa_InternalDropEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				ToolBar instance;
				if (!InteropSystem.TryGetObject<ToolBar>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDropEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.ToolBar", "InternalDropEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.TrayIcon.InternalActivated( ... )
		/// </summary>
		// Token: 0x06001212 RID: 4626 RVA: 0x00033628 File Offset: 0x00031828
		[UnmanagedCallersOnly]
		internal static void Tools_TryIcn_InternalActivated(uint self)
		{
			try
			{
				TrayIcon instance;
				if (InteropSystem.TryGetObject<TrayIcon>(self, out instance))
				{
					instance.InternalActivated();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TrayIcon", "InternalActivated", ___e);
			}
		}

		/// <summary>
		/// Tools.TrayIcon.InternalMessageClicked( ... )
		/// </summary>
		// Token: 0x06001213 RID: 4627 RVA: 0x0003366C File Offset: 0x0003186C
		[UnmanagedCallersOnly]
		internal static void Tools_TryIcn_InternalMessageClicked(uint self)
		{
			try
			{
				TrayIcon instance;
				if (InteropSystem.TryGetObject<TrayIcon>(self, out instance))
				{
					instance.InternalMessageClicked();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TrayIcon", "InternalMessageClicked", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalItemPressed( ... )
		/// </summary>
		// Token: 0x06001214 RID: 4628 RVA: 0x000336B0 File Offset: 0x000318B0
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalItemPressed(uint self, ModelIndex index)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalItemPressed(index);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalItemPressed", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalItemClicked( ... )
		/// </summary>
		// Token: 0x06001215 RID: 4629 RVA: 0x000336F8 File Offset: 0x000318F8
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalItemClicked(uint self, ModelIndex index)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalItemClicked(index);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalItemClicked", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalItemDoubleClicked( ... )
		/// </summary>
		// Token: 0x06001216 RID: 4630 RVA: 0x00033740 File Offset: 0x00031940
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalItemDoubleClicked(uint self, ModelIndex index)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalItemDoubleClicked(index);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalItemDoubleClicked", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalItemExpanded( ... )
		/// </summary>
		// Token: 0x06001217 RID: 4631 RVA: 0x00033788 File Offset: 0x00031988
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalItemExpanded(uint self, ModelIndex index)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalItemExpanded(index);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalItemExpanded", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalItemCollapsed( ... )
		/// </summary>
		// Token: 0x06001218 RID: 4632 RVA: 0x000337D0 File Offset: 0x000319D0
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalItemCollapsed(uint self, ModelIndex index)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalItemCollapsed(index);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalItemCollapsed", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalCurrentChanged( ... )
		/// </summary>
		// Token: 0x06001219 RID: 4633 RVA: 0x00033818 File Offset: 0x00031A18
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalCurrentChanged(uint self, ModelIndex current, ModelIndex previous)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalCurrentChanged(current, previous);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalCurrentChanged", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalOnEvent( ... )
		/// </summary>
		// Token: 0x0600121A RID: 4634 RVA: 0x00033860 File Offset: 0x00031A60
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalOnEvent(uint self, long e)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalOnEvent((EventType)e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalOnEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalMousePressEvent( ... )
		/// </summary>
		// Token: 0x0600121B RID: 4635 RVA: 0x000338A8 File Offset: 0x00031AA8
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalMousePressEvent(uint self, IntPtr e)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalMousePressEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalMousePressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalMouseEnterEvent( ... )
		/// </summary>
		// Token: 0x0600121C RID: 4636 RVA: 0x000338F4 File Offset: 0x00031AF4
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalMouseEnterEvent(uint self, IntPtr e)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalMouseEnterEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalMouseEnterEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalMouseLeaveEvent( ... )
		/// </summary>
		// Token: 0x0600121D RID: 4637 RVA: 0x00033940 File Offset: 0x00031B40
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalMouseLeaveEvent(uint self, IntPtr e)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalMouseLeaveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalMouseLeaveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalMouseReleaseEvent( ... )
		/// </summary>
		// Token: 0x0600121E RID: 4638 RVA: 0x0003398C File Offset: 0x00031B8C
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalMouseReleaseEvent(uint self, IntPtr e)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalMouseReleaseEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalMouseReleaseEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalMouseMoveEvent( ... )
		/// </summary>
		// Token: 0x0600121F RID: 4639 RVA: 0x000339D8 File Offset: 0x00031BD8
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalMouseMoveEvent(uint self, IntPtr e)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalMouseMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalMouseMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalMouseDoubleClickEvent( ... )
		/// </summary>
		// Token: 0x06001220 RID: 4640 RVA: 0x00033A24 File Offset: 0x00031C24
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalMouseDoubleClickEvent(uint self, IntPtr e)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalMouseDoubleClickEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalMouseDoubleClickEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalWheelEvent( ... )
		/// </summary>
		// Token: 0x06001221 RID: 4641 RVA: 0x00033A70 File Offset: 0x00031C70
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalWheelEvent(uint self, IntPtr e)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalWheelEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalWheelEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalContextMenuEvent( ... )
		/// </summary>
		// Token: 0x06001222 RID: 4642 RVA: 0x00033ABC File Offset: 0x00031CBC
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalContextMenuEvent(uint self, IntPtr e)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalContextMenuEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalContextMenuEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalKeyPressEvent( ... )
		/// </summary>
		// Token: 0x06001223 RID: 4643 RVA: 0x00033B08 File Offset: 0x00031D08
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalKeyPressEvent(uint self, IntPtr pEvent)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalKeyPressEvent(pEvent);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalKeyPressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalFocusInEvent( ... )
		/// </summary>
		// Token: 0x06001224 RID: 4644 RVA: 0x00033B54 File Offset: 0x00031D54
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalFocusInEvent(uint self, long reason)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalFocusInEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalFocusInEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalFocusOutEvent( ... )
		/// </summary>
		// Token: 0x06001225 RID: 4645 RVA: 0x00033B9C File Offset: 0x00031D9C
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalFocusOutEvent(uint self, long reason)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalFocusOutEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalFocusOutEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalOnResizeEvent( ... )
		/// </summary>
		// Token: 0x06001226 RID: 4646 RVA: 0x00033BE4 File Offset: 0x00031DE4
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalOnResizeEvent(uint self, IntPtr e)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalOnResizeEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalOnResizeEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalOnMoveEvent( ... )
		/// </summary>
		// Token: 0x06001227 RID: 4647 RVA: 0x00033C30 File Offset: 0x00031E30
		[UnmanagedCallersOnly]
		internal static void Tools_TreeVe_InternalOnMoveEvent(uint self, IntPtr e)
		{
			try
			{
				TreeView instance;
				if (InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					instance.InternalOnMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalOnMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.TreeView.InternalPaintEvent( ... )
		/// </summary>
		// Token: 0x06001228 RID: 4648 RVA: 0x00033C7C File Offset: 0x00031E7C
		[UnmanagedCallersOnly]
		internal static int Tools_TreeVe_InternalPaintEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				TreeView instance;
				if (!InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalPaintEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalPaintEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.TreeView.InternalFocusNextPrevChild( ... )
		/// </summary>
		// Token: 0x06001229 RID: 4649 RVA: 0x00033CD4 File Offset: 0x00031ED4
		[UnmanagedCallersOnly]
		internal static int Tools_TreeVe_InternalFocusNextPrevChild(uint self, int next)
		{
			int result;
			try
			{
				TreeView instance;
				if (!InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalFocusNextPrevChild(next != 0) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalFocusNextPrevChild", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.TreeView.InternalDragEnterEvent( ... )
		/// </summary>
		// Token: 0x0600122A RID: 4650 RVA: 0x00033D28 File Offset: 0x00031F28
		[UnmanagedCallersOnly]
		internal static int Tools_TreeVe_InternalDragEnterEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				TreeView instance;
				if (!InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragEnterEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalDragEnterEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.TreeView.InternalDragMoveEvent( ... )
		/// </summary>
		// Token: 0x0600122B RID: 4651 RVA: 0x00033D80 File Offset: 0x00031F80
		[UnmanagedCallersOnly]
		internal static int Tools_TreeVe_InternalDragMoveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				TreeView instance;
				if (!InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragMoveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalDragMoveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.TreeView.InternalDragLeaveEvent( ... )
		/// </summary>
		// Token: 0x0600122C RID: 4652 RVA: 0x00033DD8 File Offset: 0x00031FD8
		[UnmanagedCallersOnly]
		internal static int Tools_TreeVe_InternalDragLeaveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				TreeView instance;
				if (!InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragLeaveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalDragLeaveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.TreeView.InternalDropEvent( ... )
		/// </summary>
		// Token: 0x0600122D RID: 4653 RVA: 0x00033E30 File Offset: 0x00032030
		[UnmanagedCallersOnly]
		internal static int Tools_TreeVe_InternalDropEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				TreeView instance;
				if (!InteropSystem.TryGetObject<TreeView>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDropEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.TreeView", "InternalDropEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Widget.InternalOnEvent( ... )
		/// </summary>
		// Token: 0x0600122E RID: 4654 RVA: 0x00033E88 File Offset: 0x00032088
		[UnmanagedCallersOnly]
		internal static void Tools_Widget_InternalOnEvent(uint self, long e)
		{
			try
			{
				Widget instance;
				if (InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					instance.InternalOnEvent((EventType)e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalOnEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Widget.InternalMousePressEvent( ... )
		/// </summary>
		// Token: 0x0600122F RID: 4655 RVA: 0x00033ED0 File Offset: 0x000320D0
		[UnmanagedCallersOnly]
		internal static void Tools_Widget_InternalMousePressEvent(uint self, IntPtr e)
		{
			try
			{
				Widget instance;
				if (InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					instance.InternalMousePressEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalMousePressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Widget.InternalMouseEnterEvent( ... )
		/// </summary>
		// Token: 0x06001230 RID: 4656 RVA: 0x00033F1C File Offset: 0x0003211C
		[UnmanagedCallersOnly]
		internal static void Tools_Widget_InternalMouseEnterEvent(uint self, IntPtr e)
		{
			try
			{
				Widget instance;
				if (InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					instance.InternalMouseEnterEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalMouseEnterEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Widget.InternalMouseLeaveEvent( ... )
		/// </summary>
		// Token: 0x06001231 RID: 4657 RVA: 0x00033F68 File Offset: 0x00032168
		[UnmanagedCallersOnly]
		internal static void Tools_Widget_InternalMouseLeaveEvent(uint self, IntPtr e)
		{
			try
			{
				Widget instance;
				if (InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					instance.InternalMouseLeaveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalMouseLeaveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Widget.InternalMouseReleaseEvent( ... )
		/// </summary>
		// Token: 0x06001232 RID: 4658 RVA: 0x00033FB4 File Offset: 0x000321B4
		[UnmanagedCallersOnly]
		internal static void Tools_Widget_InternalMouseReleaseEvent(uint self, IntPtr e)
		{
			try
			{
				Widget instance;
				if (InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					instance.InternalMouseReleaseEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalMouseReleaseEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Widget.InternalMouseMoveEvent( ... )
		/// </summary>
		// Token: 0x06001233 RID: 4659 RVA: 0x00034000 File Offset: 0x00032200
		[UnmanagedCallersOnly]
		internal static void Tools_Widget_InternalMouseMoveEvent(uint self, IntPtr e)
		{
			try
			{
				Widget instance;
				if (InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					instance.InternalMouseMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalMouseMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Widget.InternalMouseDoubleClickEvent( ... )
		/// </summary>
		// Token: 0x06001234 RID: 4660 RVA: 0x0003404C File Offset: 0x0003224C
		[UnmanagedCallersOnly]
		internal static void Tools_Widget_InternalMouseDoubleClickEvent(uint self, IntPtr e)
		{
			try
			{
				Widget instance;
				if (InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					instance.InternalMouseDoubleClickEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalMouseDoubleClickEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Widget.InternalWheelEvent( ... )
		/// </summary>
		// Token: 0x06001235 RID: 4661 RVA: 0x00034098 File Offset: 0x00032298
		[UnmanagedCallersOnly]
		internal static void Tools_Widget_InternalWheelEvent(uint self, IntPtr e)
		{
			try
			{
				Widget instance;
				if (InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					instance.InternalWheelEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalWheelEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Widget.InternalContextMenuEvent( ... )
		/// </summary>
		// Token: 0x06001236 RID: 4662 RVA: 0x000340E4 File Offset: 0x000322E4
		[UnmanagedCallersOnly]
		internal static void Tools_Widget_InternalContextMenuEvent(uint self, IntPtr e)
		{
			try
			{
				Widget instance;
				if (InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					instance.InternalContextMenuEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalContextMenuEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Widget.InternalKeyPressEvent( ... )
		/// </summary>
		// Token: 0x06001237 RID: 4663 RVA: 0x00034130 File Offset: 0x00032330
		[UnmanagedCallersOnly]
		internal static void Tools_Widget_InternalKeyPressEvent(uint self, IntPtr pEvent)
		{
			try
			{
				Widget instance;
				if (InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					instance.InternalKeyPressEvent(pEvent);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalKeyPressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Widget.InternalFocusInEvent( ... )
		/// </summary>
		// Token: 0x06001238 RID: 4664 RVA: 0x0003417C File Offset: 0x0003237C
		[UnmanagedCallersOnly]
		internal static void Tools_Widget_InternalFocusInEvent(uint self, long reason)
		{
			try
			{
				Widget instance;
				if (InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					instance.InternalFocusInEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalFocusInEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Widget.InternalFocusOutEvent( ... )
		/// </summary>
		// Token: 0x06001239 RID: 4665 RVA: 0x000341C4 File Offset: 0x000323C4
		[UnmanagedCallersOnly]
		internal static void Tools_Widget_InternalFocusOutEvent(uint self, long reason)
		{
			try
			{
				Widget instance;
				if (InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					instance.InternalFocusOutEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalFocusOutEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Widget.InternalOnResizeEvent( ... )
		/// </summary>
		// Token: 0x0600123A RID: 4666 RVA: 0x0003420C File Offset: 0x0003240C
		[UnmanagedCallersOnly]
		internal static void Tools_Widget_InternalOnResizeEvent(uint self, IntPtr e)
		{
			try
			{
				Widget instance;
				if (InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					instance.InternalOnResizeEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalOnResizeEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Widget.InternalOnMoveEvent( ... )
		/// </summary>
		// Token: 0x0600123B RID: 4667 RVA: 0x00034258 File Offset: 0x00032458
		[UnmanagedCallersOnly]
		internal static void Tools_Widget_InternalOnMoveEvent(uint self, IntPtr e)
		{
			try
			{
				Widget instance;
				if (InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					instance.InternalOnMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalOnMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Widget.InternalPaintEvent( ... )
		/// </summary>
		// Token: 0x0600123C RID: 4668 RVA: 0x000342A4 File Offset: 0x000324A4
		[UnmanagedCallersOnly]
		internal static int Tools_Widget_InternalPaintEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Widget instance;
				if (!InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalPaintEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalPaintEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Widget.InternalFocusNextPrevChild( ... )
		/// </summary>
		// Token: 0x0600123D RID: 4669 RVA: 0x000342FC File Offset: 0x000324FC
		[UnmanagedCallersOnly]
		internal static int Tools_Widget_InternalFocusNextPrevChild(uint self, int next)
		{
			int result;
			try
			{
				Widget instance;
				if (!InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalFocusNextPrevChild(next != 0) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalFocusNextPrevChild", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Widget.InternalDragEnterEvent( ... )
		/// </summary>
		// Token: 0x0600123E RID: 4670 RVA: 0x00034350 File Offset: 0x00032550
		[UnmanagedCallersOnly]
		internal static int Tools_Widget_InternalDragEnterEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Widget instance;
				if (!InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragEnterEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalDragEnterEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Widget.InternalDragMoveEvent( ... )
		/// </summary>
		// Token: 0x0600123F RID: 4671 RVA: 0x000343A8 File Offset: 0x000325A8
		[UnmanagedCallersOnly]
		internal static int Tools_Widget_InternalDragMoveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Widget instance;
				if (!InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragMoveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalDragMoveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Widget.InternalDragLeaveEvent( ... )
		/// </summary>
		// Token: 0x06001240 RID: 4672 RVA: 0x00034400 File Offset: 0x00032600
		[UnmanagedCallersOnly]
		internal static int Tools_Widget_InternalDragLeaveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Widget instance;
				if (!InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragLeaveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalDragLeaveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Widget.InternalDropEvent( ... )
		/// </summary>
		// Token: 0x06001241 RID: 4673 RVA: 0x00034458 File Offset: 0x00032658
		[UnmanagedCallersOnly]
		internal static int Tools_Widget_InternalDropEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Widget instance;
				if (!InteropSystem.TryGetObject<Widget>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDropEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Widget", "InternalDropEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Window.InternalCloseEvent( ... )
		/// </summary>
		// Token: 0x06001242 RID: 4674 RVA: 0x000344B0 File Offset: 0x000326B0
		[UnmanagedCallersOnly]
		internal static void Tools_Window_InternalCloseEvent(uint self, IntPtr close)
		{
			try
			{
				Window instance;
				if (InteropSystem.TryGetObject<Window>(self, out instance))
				{
					instance.InternalCloseEvent(close);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalCloseEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Window.InitFramelessWindow( ... )
		/// </summary>
		// Token: 0x06001243 RID: 4675 RVA: 0x000344F8 File Offset: 0x000326F8
		[UnmanagedCallersOnly]
		internal static void Tools_Window_InitFramelessWindow(IntPtr window)
		{
			try
			{
				Window.InitFramelessWindow(window);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InitFramelessWindow", ___e);
			}
		}

		/// <summary>
		/// Tools.Window.InternalOnEvent( ... )
		/// </summary>
		// Token: 0x06001244 RID: 4676 RVA: 0x00034538 File Offset: 0x00032738
		[UnmanagedCallersOnly]
		internal static void Tools_Window_InternalOnEvent(uint self, long e)
		{
			try
			{
				Window instance;
				if (InteropSystem.TryGetObject<Window>(self, out instance))
				{
					instance.InternalOnEvent((EventType)e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalOnEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Window.InternalMousePressEvent( ... )
		/// </summary>
		// Token: 0x06001245 RID: 4677 RVA: 0x00034580 File Offset: 0x00032780
		[UnmanagedCallersOnly]
		internal static void Tools_Window_InternalMousePressEvent(uint self, IntPtr e)
		{
			try
			{
				Window instance;
				if (InteropSystem.TryGetObject<Window>(self, out instance))
				{
					instance.InternalMousePressEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalMousePressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Window.InternalMouseEnterEvent( ... )
		/// </summary>
		// Token: 0x06001246 RID: 4678 RVA: 0x000345CC File Offset: 0x000327CC
		[UnmanagedCallersOnly]
		internal static void Tools_Window_InternalMouseEnterEvent(uint self, IntPtr e)
		{
			try
			{
				Window instance;
				if (InteropSystem.TryGetObject<Window>(self, out instance))
				{
					instance.InternalMouseEnterEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalMouseEnterEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Window.InternalMouseLeaveEvent( ... )
		/// </summary>
		// Token: 0x06001247 RID: 4679 RVA: 0x00034618 File Offset: 0x00032818
		[UnmanagedCallersOnly]
		internal static void Tools_Window_InternalMouseLeaveEvent(uint self, IntPtr e)
		{
			try
			{
				Window instance;
				if (InteropSystem.TryGetObject<Window>(self, out instance))
				{
					instance.InternalMouseLeaveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalMouseLeaveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Window.InternalMouseReleaseEvent( ... )
		/// </summary>
		// Token: 0x06001248 RID: 4680 RVA: 0x00034664 File Offset: 0x00032864
		[UnmanagedCallersOnly]
		internal static void Tools_Window_InternalMouseReleaseEvent(uint self, IntPtr e)
		{
			try
			{
				Window instance;
				if (InteropSystem.TryGetObject<Window>(self, out instance))
				{
					instance.InternalMouseReleaseEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalMouseReleaseEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Window.InternalMouseMoveEvent( ... )
		/// </summary>
		// Token: 0x06001249 RID: 4681 RVA: 0x000346B0 File Offset: 0x000328B0
		[UnmanagedCallersOnly]
		internal static void Tools_Window_InternalMouseMoveEvent(uint self, IntPtr e)
		{
			try
			{
				Window instance;
				if (InteropSystem.TryGetObject<Window>(self, out instance))
				{
					instance.InternalMouseMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalMouseMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Window.InternalMouseDoubleClickEvent( ... )
		/// </summary>
		// Token: 0x0600124A RID: 4682 RVA: 0x000346FC File Offset: 0x000328FC
		[UnmanagedCallersOnly]
		internal static void Tools_Window_InternalMouseDoubleClickEvent(uint self, IntPtr e)
		{
			try
			{
				Window instance;
				if (InteropSystem.TryGetObject<Window>(self, out instance))
				{
					instance.InternalMouseDoubleClickEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalMouseDoubleClickEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Window.InternalWheelEvent( ... )
		/// </summary>
		// Token: 0x0600124B RID: 4683 RVA: 0x00034748 File Offset: 0x00032948
		[UnmanagedCallersOnly]
		internal static void Tools_Window_InternalWheelEvent(uint self, IntPtr e)
		{
			try
			{
				Window instance;
				if (InteropSystem.TryGetObject<Window>(self, out instance))
				{
					instance.InternalWheelEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalWheelEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Window.InternalContextMenuEvent( ... )
		/// </summary>
		// Token: 0x0600124C RID: 4684 RVA: 0x00034794 File Offset: 0x00032994
		[UnmanagedCallersOnly]
		internal static void Tools_Window_InternalContextMenuEvent(uint self, IntPtr e)
		{
			try
			{
				Window instance;
				if (InteropSystem.TryGetObject<Window>(self, out instance))
				{
					instance.InternalContextMenuEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalContextMenuEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Window.InternalKeyPressEvent( ... )
		/// </summary>
		// Token: 0x0600124D RID: 4685 RVA: 0x000347E0 File Offset: 0x000329E0
		[UnmanagedCallersOnly]
		internal static void Tools_Window_InternalKeyPressEvent(uint self, IntPtr pEvent)
		{
			try
			{
				Window instance;
				if (InteropSystem.TryGetObject<Window>(self, out instance))
				{
					instance.InternalKeyPressEvent(pEvent);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalKeyPressEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Window.InternalFocusInEvent( ... )
		/// </summary>
		// Token: 0x0600124E RID: 4686 RVA: 0x0003482C File Offset: 0x00032A2C
		[UnmanagedCallersOnly]
		internal static void Tools_Window_InternalFocusInEvent(uint self, long reason)
		{
			try
			{
				Window instance;
				if (InteropSystem.TryGetObject<Window>(self, out instance))
				{
					instance.InternalFocusInEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalFocusInEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Window.InternalFocusOutEvent( ... )
		/// </summary>
		// Token: 0x0600124F RID: 4687 RVA: 0x00034874 File Offset: 0x00032A74
		[UnmanagedCallersOnly]
		internal static void Tools_Window_InternalFocusOutEvent(uint self, long reason)
		{
			try
			{
				Window instance;
				if (InteropSystem.TryGetObject<Window>(self, out instance))
				{
					instance.InternalFocusOutEvent((FocusChangeReason)reason);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalFocusOutEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Window.InternalOnResizeEvent( ... )
		/// </summary>
		// Token: 0x06001250 RID: 4688 RVA: 0x000348BC File Offset: 0x00032ABC
		[UnmanagedCallersOnly]
		internal static void Tools_Window_InternalOnResizeEvent(uint self, IntPtr e)
		{
			try
			{
				Window instance;
				if (InteropSystem.TryGetObject<Window>(self, out instance))
				{
					instance.InternalOnResizeEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalOnResizeEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Window.InternalOnMoveEvent( ... )
		/// </summary>
		// Token: 0x06001251 RID: 4689 RVA: 0x00034908 File Offset: 0x00032B08
		[UnmanagedCallersOnly]
		internal static void Tools_Window_InternalOnMoveEvent(uint self, IntPtr e)
		{
			try
			{
				Window instance;
				if (InteropSystem.TryGetObject<Window>(self, out instance))
				{
					instance.InternalOnMoveEvent(e);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalOnMoveEvent", ___e);
			}
		}

		/// <summary>
		/// Tools.Window.InternalPaintEvent( ... )
		/// </summary>
		// Token: 0x06001252 RID: 4690 RVA: 0x00034954 File Offset: 0x00032B54
		[UnmanagedCallersOnly]
		internal static int Tools_Window_InternalPaintEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Window instance;
				if (!InteropSystem.TryGetObject<Window>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalPaintEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalPaintEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Window.InternalFocusNextPrevChild( ... )
		/// </summary>
		// Token: 0x06001253 RID: 4691 RVA: 0x000349AC File Offset: 0x00032BAC
		[UnmanagedCallersOnly]
		internal static int Tools_Window_InternalFocusNextPrevChild(uint self, int next)
		{
			int result;
			try
			{
				Window instance;
				if (!InteropSystem.TryGetObject<Window>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalFocusNextPrevChild(next != 0) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalFocusNextPrevChild", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Window.InternalDragEnterEvent( ... )
		/// </summary>
		// Token: 0x06001254 RID: 4692 RVA: 0x00034A00 File Offset: 0x00032C00
		[UnmanagedCallersOnly]
		internal static int Tools_Window_InternalDragEnterEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Window instance;
				if (!InteropSystem.TryGetObject<Window>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragEnterEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalDragEnterEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Window.InternalDragMoveEvent( ... )
		/// </summary>
		// Token: 0x06001255 RID: 4693 RVA: 0x00034A58 File Offset: 0x00032C58
		[UnmanagedCallersOnly]
		internal static int Tools_Window_InternalDragMoveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Window instance;
				if (!InteropSystem.TryGetObject<Window>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragMoveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalDragMoveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Window.InternalDragLeaveEvent( ... )
		/// </summary>
		// Token: 0x06001256 RID: 4694 RVA: 0x00034AB0 File Offset: 0x00032CB0
		[UnmanagedCallersOnly]
		internal static int Tools_Window_InternalDragLeaveEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Window instance;
				if (!InteropSystem.TryGetObject<Window>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDragLeaveEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalDragLeaveEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Tools.Window.InternalDropEvent( ... )
		/// </summary>
		// Token: 0x06001257 RID: 4695 RVA: 0x00034B08 File Offset: 0x00032D08
		[UnmanagedCallersOnly]
		internal static int Tools_Window_InternalDropEvent(uint self, IntPtr e)
		{
			int result;
			try
			{
				Window instance;
				if (!InteropSystem.TryGetObject<Window>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.InternalDropEvent(e) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Tools.Window", "InternalDropEvent", ___e);
				result = 0;
			}
			return result;
		}
	}
}
