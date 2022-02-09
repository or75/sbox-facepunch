using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Sandbox;

namespace Managed.SourceMenu
{
	// Token: 0x02000009 RID: 9
	internal static class Exports
	{
		/// <summary>
		/// Sandbox.SceneObject.OnObjectCreated( ... )
		/// </summary>
		// Token: 0x06000016 RID: 22 RVA: 0x00002560 File Offset: 0x00000760
		[UnmanagedCallersOnly]
		internal static int Sandbomenu_SceneO_OnObjectCreated(IntPtr ptr, int ptype)
		{
			int result;
			try
			{
				if (ptype <= 264582)
				{
					if (ptype == 0)
					{
						return HandleIndex.New<SceneObject>(ptr, (HandleCreationData x) => new SceneObject(x));
					}
					if (ptype == 234652)
					{
						return HandleIndex.New<AnimSceneObject>(ptr, (HandleCreationData x) => new AnimSceneObject(x));
					}
					if (ptype == 264582)
					{
						return HandleIndex.New<SceneParticleObject>(ptr, (HandleCreationData x) => new SceneParticleObject(x));
					}
				}
				else if (ptype <= 572329)
				{
					if (ptype == 523546)
					{
						return HandleIndex.New<SkyboxObject>(ptr, (HandleCreationData x) => new SkyboxObject(x));
					}
					if (ptype == 572329)
					{
						return HandleIndex.New<SceneMonitorObject>(ptr, (HandleCreationData x) => new SceneMonitorObject(x));
					}
				}
				else
				{
					if (ptype == 845676)
					{
						return HandleIndex.New<CustomSceneObject>(ptr, (HandleCreationData x) => new CustomSceneObject(x));
					}
					if (ptype == 846832)
					{
						return HandleIndex.New<Light>(ptr, (HandleCreationData x) => new Light(x));
					}
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(46, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Tried to create unknown SceneObject - type id ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(ptype);
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.SceneObject", "OnObjectCreated", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.SceneObject.OnObjectDestroyed( ... )
		/// </summary>
		// Token: 0x06000017 RID: 23 RVA: 0x00002754 File Offset: 0x00000954
		[UnmanagedCallersOnly]
		internal static void Sandbomenu_SceneO_OnObjectDestroyed(IntPtr ptr, int idx)
		{
			try
			{
				HandleIndex.Delete(ptr, idx);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.SceneObject", "OnObjectDestroyed", ___e);
			}
		}

		/// <summary>
		/// Sandbox.SceneWorld.OnObjectCreated( ... )
		/// </summary>
		// Token: 0x06000018 RID: 24 RVA: 0x00002790 File Offset: 0x00000990
		[UnmanagedCallersOnly]
		internal static int Sandbomenu_SceneW_OnObjectCreated(IntPtr ptr, int ptype)
		{
			int result;
			try
			{
				if (ptype != 0)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Tried to create unknown SceneWorld - type id ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(ptype);
					throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				result = HandleIndex.New<SceneWorld>(ptr, (HandleCreationData x) => new SceneWorld(x));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.SceneWorld", "OnObjectCreated", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.SceneWorld.OnObjectDestroyed( ... )
		/// </summary>
		// Token: 0x06000019 RID: 25 RVA: 0x00002818 File Offset: 0x00000A18
		[UnmanagedCallersOnly]
		internal static void Sandbomenu_SceneW_OnObjectDestroyed(IntPtr ptr, int idx)
		{
			try
			{
				HandleIndex.Delete(ptr, idx);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.SceneWorld", "OnObjectDestroyed", ___e);
			}
		}

		/// <summary>
		/// Sandbox.MenuDll.RenderUI( ... )
		/// </summary>
		// Token: 0x0600001A RID: 26 RVA: 0x00002854 File Offset: 0x00000A54
		[UnmanagedCallersOnly]
		internal static void Sandbo_MenDll_RenderUI()
		{
			try
			{
				MenuDll.RenderUI();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.MenuDll", "RenderUI", ___e);
			}
		}

		/// <summary>
		/// Sandbox.MenuDll.BlockStart( ... )
		/// </summary>
		// Token: 0x0600001B RID: 27 RVA: 0x0000288C File Offset: 0x00000A8C
		[UnmanagedCallersOnly]
		internal static void Sandbo_MenDll_BlockStart(IntPtr view, IntPtr context, IntPtr layer)
		{
			try
			{
				MenuDll.BlockStart(view, context, layer);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.MenuDll", "BlockStart", ___e);
			}
		}

		/// <summary>
		/// Sandbox.MenuDll.BlockEnd( ... )
		/// </summary>
		// Token: 0x0600001C RID: 28 RVA: 0x000028D8 File Offset: 0x00000AD8
		[UnmanagedCallersOnly]
		internal static void Sandbo_MenDll_BlockEnd()
		{
			try
			{
				MenuDll.BlockEnd();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.MenuDll", "BlockEnd", ___e);
			}
		}
	}
}
