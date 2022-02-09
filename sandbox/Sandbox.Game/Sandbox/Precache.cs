using System;
using System.Collections.Generic;
using NativeGlue;

namespace Sandbox
{
	// Token: 0x020000CE RID: 206
	public static class Precache
	{
		// Token: 0x0600126F RID: 4719 RVA: 0x0004DB74 File Offset: 0x0004BD74
		internal static void Init()
		{
			Precache.ClearCache();
		}

		// Token: 0x06001270 RID: 4720 RVA: 0x0004DB7C File Offset: 0x0004BD7C
		internal static void ClientConnected()
		{
			Host.AssertClient("ClientConnected");
			StringTables.Precache.OnStringAddedOrChanged = new Action<int>(Precache.OnStringAddedOrChanged);
			for (int i = 0; i < StringTables.Precache.Count(); i++)
			{
				Precache.OnStringAddedOrChanged(i);
			}
		}

		// Token: 0x06001271 RID: 4721 RVA: 0x0004DBC4 File Offset: 0x0004BDC4
		internal static void ClearCache()
		{
			Precache.Active.Clear();
			Resources.ReleaseCached();
		}

		/// <summary>
		/// Add a resource that the client should load. This is called 
		/// automatically when doing things such as setting a model and for
		/// the most part you should never have to call this.
		/// </summary>
		// Token: 0x06001272 RID: 4722 RVA: 0x0004DBD8 File Offset: 0x0004BDD8
		public static void Add(string resourceName)
		{
			if (!Host.IsServer)
			{
				return;
			}
			if (string.IsNullOrWhiteSpace(resourceName))
			{
				return;
			}
			int hash = resourceName.GetHashCode();
			string text;
			if (Precache.Active.TryGetValue(hash, out text))
			{
				return;
			}
			Precache.Active[hash] = resourceName;
			StringTables.Precache.Set(resourceName);
		}

		/// <summary>
		/// Player info has changed
		/// </summary>
		// Token: 0x06001273 RID: 4723 RVA: 0x0004DC28 File Offset: 0x0004BE28
		internal static void OnStringAddedOrChanged(int entryId)
		{
			Host.AssertClient("OnStringAddedOrChanged");
			string str = StringTables.Precache.GetString(entryId);
			if (!Resources.LoadResource(str))
			{
				return;
			}
			if (str.EndsWith(".vmat"))
			{
				Material.Load(str);
			}
			if (str.EndsWith(".vmdl"))
			{
				Model.Load(str);
			}
			if (str.EndsWith(".vtex"))
			{
				Texture.Load(FileSystem.Mounted, str, true);
			}
		}

		// Token: 0x040003DC RID: 988
		private static readonly Dictionary<int, string> Active = new Dictionary<int, string>();
	}
}
