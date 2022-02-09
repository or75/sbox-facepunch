using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020002BC RID: 700
	public static class Performance
	{
		/// <summary>
		/// Creates a profile scope in SuperLuminal
		/// </summary>
		// Token: 0x060011C0 RID: 4544 RVA: 0x00023EA8 File Offset: 0x000220A8
		public unsafe static IDisposable Scope(string name)
		{
			if (!Performance.profiling)
			{
				return null;
			}
			void* value;
			if (name == null)
			{
				value = null;
			}
			else
			{
				fixed (char* ptr = name.GetPinnableReference())
				{
					value = (void*)ptr;
				}
			}
			Color32 c = Performance.Colors[Math.Abs(name.GetHashCode() % Performance.Colors.Length)];
			EngineGlobal.SPROF_ENTER_SCOPE((IntPtr)value, (int)c.r, (int)c.g, (int)c.b);
			char* ptr = null;
			return Performance.ProfileScopeCloser.Singleton;
		}

		// Token: 0x04001414 RID: 5140
		private static bool profiling = true;

		// Token: 0x04001415 RID: 5141
		private static Color32[] Colors = new Color32[]
		{
			new Color32(200, 246, 155, byte.MaxValue),
			new Color32(byte.MaxValue, 238, 165, byte.MaxValue),
			new Color32(byte.MaxValue, 203, 165, byte.MaxValue),
			new Color32(byte.MaxValue, 177, 175, byte.MaxValue),
			new Color32(214, 212, byte.MaxValue, byte.MaxValue),
			new Color32(179, 238, byte.MaxValue, byte.MaxValue)
		};

		// Token: 0x0200040E RID: 1038
		internal class ProfileScopeCloser : IDisposable
		{
			// Token: 0x06001800 RID: 6144 RVA: 0x0003829A File Offset: 0x0003649A
			public void Dispose()
			{
				EngineGlobal.SPROF_EXIT_SCOPE();
			}

			// Token: 0x04001A3F RID: 6719
			public static Performance.ProfileScopeCloser Singleton = new Performance.ProfileScopeCloser();
		}
	}
}
