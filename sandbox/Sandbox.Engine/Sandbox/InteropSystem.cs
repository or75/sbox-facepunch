using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x020002B3 RID: 691
	internal static class InteropSystem
	{
		// Token: 0x0600118C RID: 4492 RVA: 0x0002387A File Offset: 0x00021A7A
		public static bool TryGetObject(uint addr, out object o)
		{
			return InteropSystem.Objects.TryGetValue(addr, out o);
		}

		// Token: 0x0600118D RID: 4493 RVA: 0x00023888 File Offset: 0x00021A88
		public static bool TryGetObject<T>(uint addr, out T o)
		{
			if (addr == 0U)
			{
				o = default(T);
				return true;
			}
			object obj;
			if (InteropSystem.TryGetObject(addr, out obj))
			{
				if (obj is T)
				{
					T tobj = (T)((object)obj);
					o = tobj;
					return true;
				}
				GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("InteropSystem: Tried to get {0} as {1} - but it is a {2} ({3})", new object[]
				{
					addr,
					typeof(T).FullName,
					obj.GetType().FullName,
					obj
				}));
			}
			o = default(T);
			return false;
		}

		// Token: 0x0600118E RID: 4494 RVA: 0x00023912 File Offset: 0x00021B12
		public static bool TryGetAddress<T>(T o, out uint addr)
		{
			return InteropSystem.Address.TryGetValue(o, out addr);
		}

		// Token: 0x0600118F RID: 4495 RVA: 0x00023928 File Offset: 0x00021B28
		public static T Get<T>(uint address)
		{
			T obj;
			if (InteropSystem.TryGetObject<T>(address, out obj))
			{
				return obj;
			}
			GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("InteropSystem: Tried to get {0} at {1} - but not found", new object[]
			{
				typeof(T),
				address
			}));
			return default(T);
		}

		// Token: 0x06001190 RID: 4496 RVA: 0x0002397C File Offset: 0x00021B7C
		public static uint GetAddress<T>(T obj, bool complain)
		{
			if (obj == null)
			{
				return 0U;
			}
			uint addr;
			if (InteropSystem.TryGetAddress<T>(obj, out addr))
			{
				return addr;
			}
			if (complain)
			{
				GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Tried to send address of object to native but it isn't allocated: {0} ({1})", new object[]
				{
					obj,
					obj.GetType()
				}));
			}
			return 0U;
		}

		// Token: 0x06001191 RID: 4497 RVA: 0x000239D6 File Offset: 0x00021BD6
		private static uint TakeIndex()
		{
			if (InteropSystem.LastIndex >= 4294967295U)
			{
				return InteropSystem.IndexPool.Dequeue();
			}
			return InteropSystem.LastIndex++;
		}

		// Token: 0x06001192 RID: 4498 RVA: 0x000239F8 File Offset: 0x00021BF8
		public static void Alloc<T>(T obj)
		{
			ThreadSafe.AssertIsMainThread("Alloc");
			uint idx = InteropSystem.TakeIndex();
			InteropSystem.Objects[idx] = obj;
			InteropSystem.Address[obj] = idx;
		}

		// Token: 0x06001193 RID: 4499 RVA: 0x00023A38 File Offset: 0x00021C38
		public static void Free<T>(T obj)
		{
			ThreadSafe.AssertIsMainThread("Free");
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			uint idx;
			if (!InteropSystem.TryGetAddress<T>(obj, out idx))
			{
				return;
			}
			InteropSystem.Objects.Remove(idx);
			InteropSystem.Address.Remove(obj);
			InteropSystem.IndexPool.Enqueue(idx);
		}

		// Token: 0x0400139B RID: 5019
		private static uint LastIndex = 1U;

		// Token: 0x0400139C RID: 5020
		private static Dictionary<uint, object> Objects = new Dictionary<uint, object>();

		// Token: 0x0400139D RID: 5021
		private static Dictionary<object, uint> Address = new Dictionary<object, uint>();

		// Token: 0x0400139E RID: 5022
		private static Queue<uint> IndexPool = new Queue<uint>();
	}
}
