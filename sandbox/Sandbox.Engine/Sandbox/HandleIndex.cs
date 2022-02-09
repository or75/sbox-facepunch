using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Sandbox.Internal;

namespace Sandbox
{
	/// <summary>
	/// An index that can convert from a handle (int) to a class. This is 
	/// usually a static on your Handle object called HandleIndex.
	/// </summary>
	// Token: 0x020002B2 RID: 690
	internal static class HandleIndex
	{
		// Token: 0x06001186 RID: 4486 RVA: 0x00023678 File Offset: 0x00021878
		public static int New<T>(IntPtr ptr, Func<HandleCreationData, T> createFunction) where T : IHandle
		{
			List<IHandle> index = HandleIndex.Index;
			int result;
			lock (index)
			{
				T p = default(T);
				if (HandleIndex.nextObject != null)
				{
					p = (T)((object)HandleIndex.nextObject);
					HandleIndex.nextObject = null;
				}
				else
				{
					p = createFunction(default(HandleCreationData));
				}
				p.HandleInit(ptr);
				HandleIndex.Index.Add(p);
				result = HandleIndex.Index.Count - 1;
			}
			return result;
		}

		// Token: 0x06001187 RID: 4487 RVA: 0x00023714 File Offset: 0x00021914
		public static void Delete(IntPtr ptr, int handle)
		{
			List<IHandle> index = HandleIndex.Index;
			lock (index)
			{
				if (HandleIndex.Index.Count != 0)
				{
					HandleIndex.Index[handle].HandleDestroy();
					HandleIndex.Index[handle] = null;
				}
			}
		}

		// Token: 0x06001188 RID: 4488 RVA: 0x00023778 File Offset: 0x00021978
		public static T Get<T>(int index) where T : IHandle
		{
			List<IHandle> index2 = HandleIndex.Index;
			T t2;
			lock (index2)
			{
				if (index < 0)
				{
					t2 = default(T);
					t2 = t2;
				}
				else if (index >= HandleIndex.Index.Count)
				{
					t2 = default(T);
				}
				else
				{
					IHandle o = HandleIndex.Index[index];
					if (o is T)
					{
						T t = (T)((object)o);
						t2 = t;
					}
					else
					{
						GlobalSystemNamespace.Log.Info(FormattableStringFactory.Create("Couldn't find handle: {0} of {1}", new object[]
						{
							HandleIndex.Index.Count - 1,
							typeof(T)
						}));
						t2 = default(T);
					}
				}
			}
			return t2;
		}

		/// <summary>
		/// Force the next object created to be this object
		/// </summary>
		// Token: 0x06001189 RID: 4489 RVA: 0x0002384C File Offset: 0x00021A4C
		internal static void ForceNextObject(IHandle nextObj)
		{
			HandleIndex.nextObject = nextObj;
		}

		/// <summary>
		/// A safety measure so we know it's being used
		/// </summary>
		// Token: 0x0600118A RID: 4490 RVA: 0x00023854 File Offset: 0x00021A54
		internal static void UsedNextObject(IHandle nextObj)
		{
			if (HandleIndex.nextObject == nextObj)
			{
				throw new Exception("Something went wrong, the ForceNextObject object wasn't used!?");
			}
		}

		// Token: 0x04001399 RID: 5017
		private static List<IHandle> Index = new List<IHandle>(1024);

		// Token: 0x0400139A RID: 5018
		private static IHandle nextObject;
	}
}
