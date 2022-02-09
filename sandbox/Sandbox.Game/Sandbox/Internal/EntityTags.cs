using System;
using System.Collections.Generic;
using System.Linq;
using NativeEngine;

namespace Sandbox.Internal
{
	/// <summary>
	/// Entity Tags are strings you can set and check for on any entity. Internally
	/// these strings are tokenized and networked so they're also available clientside.
	/// </summary>
	// Token: 0x02000171 RID: 369
	public readonly struct EntityTags
	{
		// Token: 0x06001B7E RID: 7038 RVA: 0x0006EB3A File Offset: 0x0006CD3A
		internal EntityTags(Entity ent)
		{
			this.Entity = ent;
		}

		/// <summary>
		/// Returns all the tags this entity has. We can't let you modify the HashSet directly
		/// because we need to keep in sync with an engine version.
		/// </summary>
		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x06001B7F RID: 7039 RVA: 0x0006EB44 File Offset: 0x0006CD44
		public IReadOnlyCollection<string> List
		{
			get
			{
				IReadOnlySet<string> networkTags = this.Entity.networkTags;
				return networkTags ?? EntityTags.EmptyCollection;
			}
		}

		/// <summary>
		/// Returns true if this entity has given tag.
		/// </summary>
		// Token: 0x06001B80 RID: 7040 RVA: 0x0006EB67 File Offset: 0x0006CD67
		public bool Has(string tag)
		{
			tag = tag.ToLowerInvariant();
			return this.Entity.networkTags != null && this.Entity.networkTags.Contains(tag);
		}

		/// <summary>
		/// Returns true if this entity has one or more tags from given tag list.
		/// </summary>
		// Token: 0x06001B81 RID: 7041 RVA: 0x0006EB94 File Offset: 0x0006CD94
		public bool HasAny(HashSet<string> tagList)
		{
			return this.Entity.networkTags != null && this.Entity.networkTags.Any(new Func<string, bool>(tagList.Contains));
		}

		/// <summary>
		/// Try to add the tag to this entity.
		/// </summary>
		// Token: 0x06001B82 RID: 7042 RVA: 0x0006EBC4 File Offset: 0x0006CDC4
		public void Add(string tag)
		{
			if (this.Has(tag))
			{
				return;
			}
			if (this.Entity.IsAuthority)
			{
				tag = tag.ToLowerInvariant();
				if (Host.IsServer)
				{
					StringPool.GetIdent(tag);
				}
				if (this.Entity.networkTags == null)
				{
					this.Entity.networkTags = new HashSet<string>();
				}
				this.Entity.networkTags.Add(tag);
				this.Entity.dataTable.AddTag(StringToken.FindOrCreate(tag));
				this.Entity.OnTagAddedInternal(tag);
			}
		}

		/// <summary>
		/// Adds multiple tags. Calls <see cref="M:Sandbox.Internal.EntityTags.Add(System.String)">EntityTags.Add</see> for each tag.
		/// </summary>
		// Token: 0x06001B83 RID: 7043 RVA: 0x0006EC50 File Offset: 0x0006CE50
		public void Add(params string[] tags)
		{
			foreach (string tag in tags)
			{
				this.Add(tag);
			}
		}

		/// <summary>
		/// Try to remove the tag from this entity.
		/// </summary>
		// Token: 0x06001B84 RID: 7044 RVA: 0x0006EC78 File Offset: 0x0006CE78
		public void Remove(string tag)
		{
			if (!this.Has(tag))
			{
				return;
			}
			if (this.Entity.IsAuthority)
			{
				tag = tag.ToLowerInvariant();
				if (this.Entity.networkTags == null)
				{
					return;
				}
				this.Entity.networkTags.Remove(tag.ToLowerInvariant());
				this.Entity.dataTable.RemoveTag(StringToken.FindOrCreate(tag));
				this.Entity.OnTagRemovedInternal(tag);
			}
		}

		/// <summary>
		/// Removes or adds a tag based on the second argument.
		/// </summary>
		// Token: 0x06001B85 RID: 7045 RVA: 0x0006ECEB File Offset: 0x0006CEEB
		public void Set(string tag, bool on)
		{
			if (on)
			{
				this.Add(tag);
				return;
			}
			this.Remove(tag);
		}

		/// <summary>
		/// Removes a tag if it exists, adds it overwise.
		/// </summary>
		// Token: 0x06001B86 RID: 7046 RVA: 0x0006ECFF File Offset: 0x0006CEFF
		public void Toggle(string tag)
		{
			if (this.Has(tag))
			{
				this.Remove(tag);
				return;
			}
			this.Add(tag);
		}

		// Token: 0x04000786 RID: 1926
		public static readonly IReadOnlySet<string> EmptyCollection = new HashSet<string>();

		// Token: 0x04000787 RID: 1927
		private readonly Entity Entity;
	}
}
