using System;
using NativeEngine;
using Sandbox;

namespace NativeGlue
{
	// Token: 0x0200000D RID: 13
	internal static class GameSoundManager
	{
		// Token: 0x0600002C RID: 44 RVA: 0x00002B68 File Offset: 0x00000D68
		internal static ulong StartSoundEvent(int hostIndex, string sound, IntPtr pEntity)
		{
			method sbxSnd_StartSoundEvent = GameSoundManager.__N.SBxSnd_StartSoundEvent;
			return calli(System.UInt64(System.Int32,System.IntPtr,System.IntPtr), hostIndex, Interop.GetPointer(sound), pEntity, sbxSnd_StartSoundEvent);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002B8C File Offset: 0x00000D8C
		internal unsafe static ulong StartSoundEvent(int hostIndex, string sound, Vector3 pos)
		{
			method sbxSnd_f = GameSoundManager.__N.SBxSnd_f2;
			return calli(System.UInt64(System.Int32,System.IntPtr,Vector3*), hostIndex, Interop.GetPointer(sound), &pos, sbxSnd_f);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002BB0 File Offset: 0x00000DB0
		internal static void StopSoundEvent(ulong guid)
		{
			method sbxSnd_StopSoundEvent = GameSoundManager.__N.SBxSnd_StopSoundEvent;
			calli(System.Void(System.UInt64), guid, sbxSnd_StopSoundEvent);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002BCC File Offset: 0x00000DCC
		internal static void SetVolume(ulong guid, float f)
		{
			method sbxSnd_SetVolume = GameSoundManager.__N.SBxSnd_SetVolume;
			calli(System.Void(System.UInt64,System.Single), guid, f, sbxSnd_SetVolume);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002BE8 File Offset: 0x00000DE8
		internal static void SetPitch(ulong guid, float f)
		{
			method sbxSnd_SetPitch = GameSoundManager.__N.SBxSnd_SetPitch;
			calli(System.Void(System.UInt64,System.Single), guid, f, sbxSnd_SetPitch);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002C04 File Offset: 0x00000E04
		internal static void SetRandomPitch(ulong guid, float f, float f2)
		{
			method sbxSnd_SetRandomPitch = GameSoundManager.__N.SBxSnd_SetRandomPitch;
			calli(System.Void(System.UInt64,System.Single,System.Single), guid, f, f2, sbxSnd_SetRandomPitch);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002C20 File Offset: 0x00000E20
		internal unsafe static void SetPosition(ulong guid, Vector3 f)
		{
			method sbxSnd_SetPosition = GameSoundManager.__N.SBxSnd_SetPosition;
			calli(System.Void(System.UInt64,Vector3*), guid, &f, sbxSnd_SetPosition);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002C40 File Offset: 0x00000E40
		internal static float GetElaspedTime(uint id)
		{
			method sbxSnd_GetElaspedTime = GameSoundManager.__N.SBxSnd_GetElaspedTime;
			return calli(System.Single(System.UInt32), id, sbxSnd_GetElaspedTime);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002C5A File Offset: 0x00000E5A
		internal static double AudioStateHostTime()
		{
			return calli(System.Double(), GameSoundManager.__N.SBxSnd_AudioStateHostTime);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002C66 File Offset: 0x00000E66
		internal static double AudioStateFrameTime()
		{
			return calli(System.Double(), GameSoundManager.__N.SBxSnd_AudioStateFrameTime);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002C72 File Offset: 0x00000E72
		internal static double AudioStatePlatformTime()
		{
			return calli(System.Double(), GameSoundManager.__N.SBxSnd_AudioStatePlatformTime);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002C80 File Offset: 0x00000E80
		internal static AudioOutputStream CreateAttachedOutputStream(ulong nSoundEvent, string pSoundFileParam, uint nSampleRate, uint nChannels, uint nBits)
		{
			method sbxSnd_CreateAttachedOutputStream = GameSoundManager.__N.SBxSnd_CreateAttachedOutputStream;
			return calli(System.IntPtr(System.UInt64,System.IntPtr,System.UInt32,System.UInt32,System.UInt32), nSoundEvent, Interop.GetPointer(pSoundFileParam), nSampleRate, nChannels, nBits, sbxSnd_CreateAttachedOutputStream);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002CAC File Offset: 0x00000EAC
		internal static void DestroyOutputStream(AudioOutputStream pOutputStream)
		{
			method sbxSnd_DestroyOutputStream = GameSoundManager.__N.SBxSnd_DestroyOutputStream;
			calli(System.Void(System.IntPtr), pOutputStream, sbxSnd_DestroyOutputStream);
		}

		// Token: 0x02000198 RID: 408
		internal static class __N
		{
			// Token: 0x040007D2 RID: 2002
			internal static method SBxSnd_StartSoundEvent;

			// Token: 0x040007D3 RID: 2003
			internal static method SBxSnd_f2;

			// Token: 0x040007D4 RID: 2004
			internal static method SBxSnd_StopSoundEvent;

			// Token: 0x040007D5 RID: 2005
			internal static method SBxSnd_SetVolume;

			// Token: 0x040007D6 RID: 2006
			internal static method SBxSnd_SetPitch;

			// Token: 0x040007D7 RID: 2007
			internal static method SBxSnd_SetRandomPitch;

			// Token: 0x040007D8 RID: 2008
			internal static method SBxSnd_SetPosition;

			// Token: 0x040007D9 RID: 2009
			internal static method SBxSnd_GetElaspedTime;

			// Token: 0x040007DA RID: 2010
			internal static method SBxSnd_AudioStateHostTime;

			// Token: 0x040007DB RID: 2011
			internal static method SBxSnd_AudioStateFrameTime;

			// Token: 0x040007DC RID: 2012
			internal static method SBxSnd_AudioStatePlatformTime;

			// Token: 0x040007DD RID: 2013
			internal static method SBxSnd_CreateAttachedOutputStream;

			// Token: 0x040007DE RID: 2014
			internal static method SBxSnd_DestroyOutputStream;
		}
	}
}
