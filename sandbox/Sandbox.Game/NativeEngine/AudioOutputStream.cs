using System;
using System.Runtime.CompilerServices;

namespace NativeEngine
{
	// Token: 0x0200004B RID: 75
	internal struct AudioOutputStream
	{
		// Token: 0x06000A34 RID: 2612 RVA: 0x00039283 File Offset: 0x00037483
		public static implicit operator IntPtr(AudioOutputStream value)
		{
			return value.self;
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x0003928C File Offset: 0x0003748C
		public static implicit operator AudioOutputStream(IntPtr value)
		{
			return new AudioOutputStream
			{
				self = value
			};
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x000392AA File Offset: 0x000374AA
		public static bool operator ==(AudioOutputStream c1, AudioOutputStream c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x000392BD File Offset: 0x000374BD
		public static bool operator !=(AudioOutputStream c1, AudioOutputStream c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x000392D0 File Offset: 0x000374D0
		public override bool Equals(object obj)
		{
			if (obj is AudioOutputStream)
			{
				AudioOutputStream c = (AudioOutputStream)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x000392FA File Offset: 0x000374FA
		internal AudioOutputStream(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x00039304 File Offset: 0x00037504
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
			defaultInterpolatedStringHandler.AppendLiteral("AudioOutputStream ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000A3B RID: 2619 RVA: 0x00039340 File Offset: 0x00037540
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000A3C RID: 2620 RVA: 0x00039352 File Offset: 0x00037552
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x0003935D File Offset: 0x0003755D
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00039370 File Offset: 0x00037570
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("AudioOutputStream was null when calling " + n);
			}
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x0003938B File Offset: 0x0003758B
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x00039398 File Offset: 0x00037598
		internal readonly void WriteAudioData(IntPtr pData, uint nSampleCount, uint nChannels)
		{
			this.NullCheck("WriteAudioData");
			method iadOtp_WriteAudioData = AudioOutputStream.__N.IAdOtp_WriteAudioData;
			calli(System.Void(System.IntPtr,System.IntPtr,System.UInt32,System.UInt32), this.self, pData, nSampleCount, nChannels, iadOtp_WriteAudioData);
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x000393C8 File Offset: 0x000375C8
		internal readonly void SetVolume(float flVolume)
		{
			this.NullCheck("SetVolume");
			method iadOtp_SetVolume = AudioOutputStream.__N.IAdOtp_SetVolume;
			calli(System.Void(System.IntPtr,System.Single), this.self, flVolume, iadOtp_SetVolume);
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x000393F4 File Offset: 0x000375F4
		internal readonly uint QueuedSampleCount()
		{
			this.NullCheck("QueuedSampleCount");
			method iadOtp_QueuedSampleCount = AudioOutputStream.__N.IAdOtp_QueuedSampleCount;
			return calli(System.UInt32(System.IntPtr), this.self, iadOtp_QueuedSampleCount);
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x00039420 File Offset: 0x00037620
		internal readonly uint MaxWriteSampleCount()
		{
			this.NullCheck("MaxWriteSampleCount");
			method iadOtp_MaxWriteSampleCount = AudioOutputStream.__N.IAdOtp_MaxWriteSampleCount;
			return calli(System.UInt32(System.IntPtr), this.self, iadOtp_MaxWriteSampleCount);
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x0003944C File Offset: 0x0003764C
		internal readonly uint LatencySamplesCount()
		{
			this.NullCheck("LatencySamplesCount");
			method iadOtp_LatencySamplesCount = AudioOutputStream.__N.IAdOtp_LatencySamplesCount;
			return calli(System.UInt32(System.IntPtr), this.self, iadOtp_LatencySamplesCount);
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x00039478 File Offset: 0x00037678
		internal readonly void Pause()
		{
			this.NullCheck("Pause");
			method iadOtp_Pause = AudioOutputStream.__N.IAdOtp_Pause;
			calli(System.Void(System.IntPtr), this.self, iadOtp_Pause);
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x000394A4 File Offset: 0x000376A4
		internal readonly void Resume()
		{
			this.NullCheck("Resume");
			method iadOtp_Resume = AudioOutputStream.__N.IAdOtp_Resume;
			calli(System.Void(System.IntPtr), this.self, iadOtp_Resume);
		}

		// Token: 0x040000B9 RID: 185
		internal IntPtr self;

		// Token: 0x020001D0 RID: 464
		internal static class __N
		{
			// Token: 0x04000F5B RID: 3931
			internal static method IAdOtp_WriteAudioData;

			// Token: 0x04000F5C RID: 3932
			internal static method IAdOtp_SetVolume;

			// Token: 0x04000F5D RID: 3933
			internal static method IAdOtp_QueuedSampleCount;

			// Token: 0x04000F5E RID: 3934
			internal static method IAdOtp_MaxWriteSampleCount;

			// Token: 0x04000F5F RID: 3935
			internal static method IAdOtp_LatencySamplesCount;

			// Token: 0x04000F60 RID: 3936
			internal static method IAdOtp_Pause;

			// Token: 0x04000F61 RID: 3937
			internal static method IAdOtp_Resume;
		}
	}
}
