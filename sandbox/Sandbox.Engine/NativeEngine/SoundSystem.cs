using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000238 RID: 568
	internal static class SoundSystem
	{
		// Token: 0x06000E7A RID: 3706 RVA: 0x000199D8 File Offset: 0x00017BD8
		internal static void AddVOIPData(ulong nTransmitter, int nEntityIndex, int nSampleRate, IntPtr pSampleBuffer, int nSampleCount, string pszSoundNameOverride)
		{
			method gpSndS_AddVOIPData = SoundSystem.__N.gpSndS_AddVOIPData;
			calli(System.Void(System.UInt64,System.Int32,System.Int32,System.IntPtr,System.Int32,System.IntPtr), nTransmitter, nEntityIndex, nSampleRate, pSampleBuffer, nSampleCount, Interop.GetPointer(pszSoundNameOverride), gpSndS_AddVOIPData);
		}

		// Token: 0x06000E7B RID: 3707 RVA: 0x000199FE File Offset: 0x00017BFE
		internal static bool IsVoiceEnabled()
		{
			return calli(System.Int32(), SoundSystem.__N.gpSndS_IsVoiceEnabled) > 0;
		}

		// Token: 0x06000E7C RID: 3708 RVA: 0x00019A0D File Offset: 0x00017C0D
		internal static bool IsVoiceLoopbackEnabled()
		{
			return calli(System.Int32(), SoundSystem.__N.gpSndS_IsVoiceLoopbackEnabled) > 0;
		}

		// Token: 0x0200039D RID: 925
		internal static class __N
		{
			// Token: 0x04001867 RID: 6247
			internal static method gpSndS_AddVOIPData;

			// Token: 0x04001868 RID: 6248
			internal static method gpSndS_IsVoiceEnabled;

			// Token: 0x04001869 RID: 6249
			internal static method gpSndS_IsVoiceLoopbackEnabled;
		}
	}
}
