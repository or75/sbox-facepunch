using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Managed.SourceMenu
{
	// Token: 0x0200000A RID: 10
	internal static class NativeInterop
	{
		// Token: 0x0600001D RID: 29 RVA: 0x00002910 File Offset: 0x00000B10
		private unsafe static void CheckStructSizes(int* struct_sizes)
		{
			string errors = "";
			int i = 0;
			if (234 != struct_sizes[i++])
			{
				errors += "Struct size header not found\n";
			}
			if (struct_sizes[i++] != 0)
			{
				errors += "Struct size footer not found\n";
			}
			if (!string.IsNullOrEmpty(errors))
			{
				throw new Exception("Data structure size doesn't match:\n\n" + errors.Trim());
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000297C File Offset: 0x00000B7C
		internal unsafe static void Initialize(int hash, IntPtr* exported, int* struct_sizes, IntPtr* imported)
		{
			int i = 0;
			NativeInterop._ErrorFunction onError = Marshal.GetDelegateForFunctionPointer<NativeInterop._ErrorFunction>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
			try
			{
				if (hash != 60938)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Hash doesn't match ( ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(hash);
					defaultInterpolatedStringHandler.AppendLiteral(" != 60938 )");
					throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				NativeInterop.CheckStructSizes(struct_sizes);
				i = 0;
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbomenu_SceneO_OnObjectCreated);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbomenu_SceneO_OnObjectDestroyed);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbomenu_SceneW_OnObjectCreated);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbomenu_SceneW_OnObjectDestroyed);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_MenDll_RenderUI);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_MenDll_BlockStart);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Sandbo_MenDll_BlockEnd);
			}
			catch (Exception ___e)
			{
				onError(___e.Message + "\n\n" + ___e.StackTrace);
			}
		}

		// Token: 0x02000017 RID: 23
		// (Invoke) Token: 0x06000078 RID: 120
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void _ErrorFunction(string message);
	}
}
