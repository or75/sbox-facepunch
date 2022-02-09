using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000237 RID: 567
	internal static class SoundEventManager
	{
		// Token: 0x06000E76 RID: 3702 RVA: 0x00019944 File Offset: 0x00017B44
		internal static bool IsValidSoundEventName(string name)
		{
			method gpSndO_IsValidSoundEventName = SoundEventManager.__N.gpSndO_IsValidSoundEventName;
			return calli(System.Int32(System.IntPtr), Interop.GetPointer(name), gpSndO_IsValidSoundEventName) > 0;
		}

		// Token: 0x06000E77 RID: 3703 RVA: 0x00019968 File Offset: 0x00017B68
		internal static bool IsSoundEventInLibrary(string name)
		{
			method gpSndO_IsSoundEventInLibrary = SoundEventManager.__N.gpSndO_IsSoundEventInLibrary;
			return calli(System.Int32(System.IntPtr), Interop.GetPointer(name), gpSndO_IsSoundEventInLibrary) > 0;
		}

		// Token: 0x06000E78 RID: 3704 RVA: 0x0001998C File Offset: 0x00017B8C
		internal static bool AddSoundEvent(string pName, KeyValues3 pSoundEventKV3)
		{
			method gpSndO_AddSoundEvent = SoundEventManager.__N.gpSndO_AddSoundEvent;
			return calli(System.Int32(System.IntPtr,System.IntPtr), Interop.GetPointer(pName), pSoundEventKV3, gpSndO_AddSoundEvent) > 0;
		}

		// Token: 0x06000E79 RID: 3705 RVA: 0x000199B4 File Offset: 0x00017BB4
		internal static bool AddSoundEvents(KeyValues3 pSoundEventKV3)
		{
			method gpSndO_AddSoundEvents = SoundEventManager.__N.gpSndO_AddSoundEvents;
			return calli(System.Int32(System.IntPtr), pSoundEventKV3, gpSndO_AddSoundEvents) > 0;
		}

		// Token: 0x0200039C RID: 924
		internal static class __N
		{
			// Token: 0x04001863 RID: 6243
			internal static method gpSndO_IsValidSoundEventName;

			// Token: 0x04001864 RID: 6244
			internal static method gpSndO_IsSoundEventInLibrary;

			// Token: 0x04001865 RID: 6245
			internal static method gpSndO_AddSoundEvent;

			// Token: 0x04001866 RID: 6246
			internal static method gpSndO_AddSoundEvents;
		}
	}
}
