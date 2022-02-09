using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000041 RID: 65
	internal static class EntitySystem
	{
		// Token: 0x0600094E RID: 2382 RVA: 0x00036B30 File Offset: 0x00034D30
		internal static CEntityClass FindClassByName(string name)
		{
			method gpEntt_FindClassByName = EntitySystem.__N.gpEntt_FindClassByName;
			return calli(System.IntPtr(System.IntPtr), Interop.GetPointer(name), gpEntt_FindClassByName);
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x00036B54 File Offset: 0x00034D54
		internal static CEntityClass FindClassByDesignName(string name)
		{
			method gpEntt_FindClassByDesignName = EntitySystem.__N.gpEntt_FindClassByDesignName;
			return calli(System.IntPtr(System.IntPtr), Interop.GetPointer(name), gpEntt_FindClassByDesignName);
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x00036B78 File Offset: 0x00034D78
		internal static CEntityInstance FindFirstEntityByName(string name)
		{
			method gpEntt_FindFirstEntityByName = EntitySystem.__N.gpEntt_FindFirstEntityByName;
			return calli(System.IntPtr(System.IntPtr), Interop.GetPointer(name), gpEntt_FindFirstEntityByName);
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x00036B9C File Offset: 0x00034D9C
		internal static CEntityInstance CreateFromManaged(string name, int forceEntityIndex, Entity entityObject)
		{
			method gpEntt_CreateFromManaged = EntitySystem.__N.gpEntt_CreateFromManaged;
			return calli(System.IntPtr(System.IntPtr,System.Int32,System.UInt32), Interop.GetPointer(name), forceEntityIndex, (entityObject == null) ? 0U : InteropSystem.GetAddress<Entity>(entityObject, true), gpEntt_CreateFromManaged);
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x00036BCE File Offset: 0x00034DCE
		internal static void ExecuteQueuedCreation()
		{
			calli(System.Void(), EntitySystem.__N.gpEntt_ExecuteQueuedCreation);
		}

		// Token: 0x020001C6 RID: 454
		internal static class __N
		{
			// Token: 0x04000E75 RID: 3701
			internal static method gpEntt_FindClassByName;

			// Token: 0x04000E76 RID: 3702
			internal static method gpEntt_FindClassByDesignName;

			// Token: 0x04000E77 RID: 3703
			internal static method gpEntt_FindFirstEntityByName;

			// Token: 0x04000E78 RID: 3704
			internal static method gpEntt_CreateFromManaged;

			// Token: 0x04000E79 RID: 3705
			internal static method gpEntt_ExecuteQueuedCreation;
		}
	}
}
