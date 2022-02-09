using System;
using System.Collections.Generic;
using Hammer;

namespace Sandbox
{
	/// <summary>
	/// A resource loaded in the engine, such as a <see cref="T:Sandbox.Model" /> or <see cref="T:Sandbox.Material" />.
	/// </summary>
	// Token: 0x020002C7 RID: 711
	public class Resource
	{
		// Token: 0x1700036A RID: 874
		// (get) Token: 0x0600122F RID: 4655 RVA: 0x00026335 File Offset: 0x00024535
		// (set) Token: 0x06001230 RID: 4656 RVA: 0x0002633D File Offset: 0x0002453D
		[Skip]
		public int ResourceId { get; protected set; }

		// Token: 0x06001231 RID: 4657 RVA: 0x00026346 File Offset: 0x00024546
		protected void Register(int resourceId)
		{
			this.ResourceId = resourceId;
			Resource.ResourceIndex[resourceId] = this;
		}

		// Token: 0x06001232 RID: 4658 RVA: 0x0002635B File Offset: 0x0002455B
		protected void Register(string filename)
		{
			if (string.IsNullOrEmpty(filename))
			{
				return;
			}
			this.Register(filename.NormalizeFilename(true).FastHash());
		}

		// Token: 0x06001233 RID: 4659 RVA: 0x00026378 File Offset: 0x00024578
		public static T FromId<T>(int resourceId) where T : Resource
		{
			Resource val;
			if (Resource.ResourceIndex.TryGetValue(resourceId, out val))
			{
				T tVal = val as T;
				if (tVal != null)
				{
					return tVal;
				}
			}
			return default(T);
		}

		// Token: 0x06001234 RID: 4660 RVA: 0x000263B3 File Offset: 0x000245B3
		public static T FromPath<T>(string filename) where T : Resource
		{
			return Resource.FromId<T>(filename.NormalizeFilename(true).FastHash());
		}

		// Token: 0x04001467 RID: 5223
		internal static Dictionary<int, Resource> ResourceIndex = new Dictionary<int, Resource>();
	}
}
