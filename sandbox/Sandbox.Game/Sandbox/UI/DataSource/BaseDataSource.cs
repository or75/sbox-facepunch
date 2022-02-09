using System;

namespace Sandbox.UI.DataSource
{
	// Token: 0x02000157 RID: 343
	public abstract class BaseDataSource
	{
		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x060019B3 RID: 6579 RVA: 0x0006BFA5 File Offset: 0x0006A1A5
		// (set) Token: 0x060019B4 RID: 6580 RVA: 0x0006BFAD File Offset: 0x0006A1AD
		public string DebugName { get; set; }

		/// <summary>
		/// Property on Panel to bind to.
		/// </summary>
		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x060019B5 RID: 6581 RVA: 0x0006BFB6 File Offset: 0x0006A1B6
		// (set) Token: 0x060019B6 RID: 6582 RVA: 0x0006BFBE File Offset: 0x0006A1BE
		public string PropertyName { get; set; }

		/// <summary>
		/// Implementable to get/set the value from the bound object
		/// </summary>
		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x060019B7 RID: 6583
		// (set) Token: 0x060019B8 RID: 6584
		public abstract object Value { get; set; }

		// Token: 0x060019B9 RID: 6585 RVA: 0x0006BFC7 File Offset: 0x0006A1C7
		public BaseDataSource(string propertyName)
		{
			this.PropertyName = propertyName;
			this.timeSinceUpdated = 1f;
			this.timeSinceChanged = 0f;
		}

		/// <summary>
		/// Returns true if the hash changed
		/// </summary>
		// Token: 0x060019BA RID: 6586 RVA: 0x0006C001 File Offset: 0x0006A201
		internal bool TryUpdateHash(int newHash)
		{
			if (newHash == this.Hash)
			{
				return false;
			}
			this.Hash = newHash;
			return true;
		}

		/// <summary>
		/// Set the panel property from whatever the value is
		/// </summary>
		// Token: 0x060019BB RID: 6587 RVA: 0x0006C018 File Offset: 0x0006A218
		internal void Tick(Panel source)
		{
			if (this.timeSinceChanged < 1f)
			{
				if (this.timeSinceUpdated < 0.033333335f)
				{
					return;
				}
			}
			else if (this.timeSinceChanged < 5f)
			{
				if (this.timeSinceUpdated < 0.1f)
				{
					return;
				}
			}
			else if (this.timeSinceUpdated < 0.2f)
			{
				return;
			}
			this.timeSinceUpdated = Rand.Float(-0.02f, 0.02f);
			object val = this.Value ?? int.MaxValue;
			if (!this.TryUpdateHash((val != null) ? val.GetHashCode() : 0))
			{
				return;
			}
			this.SetValue(source, val);
			this.timeSinceChanged = 0f;
		}

		// Token: 0x060019BC RID: 6588 RVA: 0x0006C0DE File Offset: 0x0006A2DE
		protected virtual void SetValue(Panel source, object val)
		{
			source.SetPropertyObject(this.PropertyName, val);
		}

		/// <summary>
		/// Hash to store the last value in, to avoid unnesssary updates
		/// </summary>
		// Token: 0x04000727 RID: 1831
		protected int Hash = int.MaxValue;

		// Token: 0x04000728 RID: 1832
		protected RealTimeSince timeSinceUpdated;

		// Token: 0x04000729 RID: 1833
		protected RealTimeSince timeSinceChanged;
	}
}
