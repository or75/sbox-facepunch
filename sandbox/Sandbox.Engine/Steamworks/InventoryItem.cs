using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x020000AF RID: 175
	internal struct InventoryItem : IEquatable<InventoryItem>
	{
		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060006D5 RID: 1749 RVA: 0x0000AB39 File Offset: 0x00008D39
		internal InventoryItemId Id
		{
			get
			{
				return this._id;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060006D6 RID: 1750 RVA: 0x0000AB41 File Offset: 0x00008D41
		internal InventoryDefId DefId
		{
			get
			{
				return this._def;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x0000AB49 File Offset: 0x00008D49
		internal int Quantity
		{
			get
			{
				return (int)this._quantity;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060006D8 RID: 1752 RVA: 0x0000AB51 File Offset: 0x00008D51
		internal InventoryDef Def
		{
			get
			{
				return SteamInventory.FindDefinition(this.DefId);
			}
		}

		/// <summary>
		/// Only available if the result set was created with the getproperties
		/// </summary>
		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060006D9 RID: 1753 RVA: 0x0000AB5E File Offset: 0x00008D5E
		internal Dictionary<string, string> Properties
		{
			get
			{
				return this._properties;
			}
		}

		/// <summary>
		/// This item is account-locked and cannot be traded or given away. 
		/// This is an item status flag which is permanently attached to specific item instances
		/// </summary>
		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060006DA RID: 1754 RVA: 0x0000AB66 File Offset: 0x00008D66
		internal bool IsNoTrade
		{
			get
			{
				return this._flags.HasFlag(SteamItemFlags.NoTrade);
			}
		}

		/// <summary>
		/// The item has been destroyed, traded away, expired, or otherwise invalidated. 
		/// This is an action confirmation flag which is only set one time, as part of a result set.
		/// </summary>
		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060006DB RID: 1755 RVA: 0x0000AB7E File Offset: 0x00008D7E
		internal bool IsRemoved
		{
			get
			{
				return this._flags.HasFlag(SteamItemFlags.Removed);
			}
		}

		/// <summary>
		/// The item quantity has been decreased by 1 via ConsumeItem API. 
		/// This is an action confirmation flag which is only set one time, as part of a result set.
		/// </summary>
		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060006DC RID: 1756 RVA: 0x0000AB9A File Offset: 0x00008D9A
		internal bool IsConsumed
		{
			get
			{
				return this._flags.HasFlag(SteamItemFlags.Consumed);
			}
		}

		/// <summary>
		/// Consumes items from a user's inventory. If the quantity of the given item goes to zero, it is permanently removed.
		/// Once an item is removed it cannot be recovered.This is not for the faint of heart - if your game implements item removal at all, 
		/// a high-friction UI confirmation process is highly recommended.ConsumeItem can be restricted to certain item definitions or fully
		/// blocked via the Steamworks website to minimize support/abuse issues such as the classic "my brother borrowed my laptop and deleted all of my rare items".
		/// </summary>
		// Token: 0x060006DD RID: 1757 RVA: 0x0000ABB8 File Offset: 0x00008DB8
		internal async Task<InventoryResult?> ConsumeAsync(int amount = 1)
		{
			SteamInventoryResult_t sresult = Defines.k_SteamInventoryResultInvalid;
			InventoryResult? result;
			if (!SteamInventory.Internal.ConsumeItem(ref sresult, this.Id, (uint)amount))
			{
				result = null;
			}
			else
			{
				result = await InventoryResult.GetAsync(sresult);
			}
			return result;
		}

		/// <summary>
		/// Split stack into two items
		/// </summary>
		// Token: 0x060006DE RID: 1758 RVA: 0x0000AC08 File Offset: 0x00008E08
		internal async Task<InventoryResult?> SplitStackAsync(int quantity = 1)
		{
			SteamInventoryResult_t sresult = Defines.k_SteamInventoryResultInvalid;
			InventoryResult? result;
			if (!SteamInventory.Internal.TransferItemQuantity(ref sresult, this.Id, (uint)quantity, 18446744073709551615UL))
			{
				result = null;
			}
			else
			{
				result = await InventoryResult.GetAsync(sresult);
			}
			return result;
		}

		/// <summary>
		/// Add x units of the target item to this item
		/// </summary>
		// Token: 0x060006DF RID: 1759 RVA: 0x0000AC58 File Offset: 0x00008E58
		internal async Task<InventoryResult?> AddAsync(InventoryItem add, int quantity = 1)
		{
			SteamInventoryResult_t sresult = Defines.k_SteamInventoryResultInvalid;
			InventoryResult? result;
			if (!SteamInventory.Internal.TransferItemQuantity(ref sresult, add.Id, (uint)quantity, this.Id))
			{
				result = null;
			}
			else
			{
				result = await InventoryResult.GetAsync(sresult);
			}
			return result;
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x0000ACB0 File Offset: 0x00008EB0
		internal static InventoryItem From(SteamItemDetails_t details)
		{
			return new InventoryItem
			{
				_id = details.ItemId,
				_def = details.Definition,
				_flags = (SteamItemFlags)details.Flags,
				_quantity = details.Quantity
			};
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x0000ACFC File Offset: 0x00008EFC
		internal static Dictionary<string, string> GetProperties(SteamInventoryResult_t result, int index)
		{
			uint strlen = 32768U;
			string propNames;
			if (!SteamInventory.Internal.GetResultItemProperty(result, (uint)index, null, out propNames, ref strlen))
			{
				return null;
			}
			Dictionary<string, string> props = new Dictionary<string, string>();
			foreach (string propertyName in propNames.Split(',', StringSplitOptions.None))
			{
				strlen = 32768U;
				string strVal;
				if (SteamInventory.Internal.GetResultItemProperty(result, (uint)index, propertyName, out strVal, ref strlen))
				{
					props.Add(propertyName, strVal);
				}
			}
			return props;
		}

		/// <summary>
		/// Will try to return the date that this item was aquired. You need to have for the items
		/// with their properties for this to work.
		/// </summary>
		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060006E2 RID: 1762 RVA: 0x0000AD74 File Offset: 0x00008F74
		internal DateTime Acquired
		{
			get
			{
				if (this.Properties == null)
				{
					return DateTime.UtcNow;
				}
				string str;
				if (this.Properties.TryGetValue("acquired", out str))
				{
					int year = int.Parse(str.Substring(0, 4));
					int i = int.Parse(str.Substring(4, 2));
					int d = int.Parse(str.Substring(6, 2));
					int h = int.Parse(str.Substring(9, 2));
					int mn = int.Parse(str.Substring(11, 2));
					int s = int.Parse(str.Substring(13, 2));
					return new DateTime(year, i, d, h, mn, s, DateTimeKind.Utc);
				}
				return DateTime.UtcNow;
			}
		}

		/// <summary>
		/// Tries to get the origin property. Need properties for this to work.
		/// Will return a string like "market"
		/// </summary>
		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060006E3 RID: 1763 RVA: 0x0000AE10 File Offset: 0x00009010
		internal string Origin
		{
			get
			{
				if (this.Properties == null)
				{
					return null;
				}
				string str;
				if (this.Properties.TryGetValue("origin", out str))
				{
					return str;
				}
				return null;
			}
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x0000AE3E File Offset: 0x0000903E
		public static bool operator ==(InventoryItem a, InventoryItem b)
		{
			return a._id == b._id;
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x0000AE51 File Offset: 0x00009051
		public static bool operator !=(InventoryItem a, InventoryItem b)
		{
			return a._id != b._id;
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x0000AE64 File Offset: 0x00009064
		public override bool Equals(object p)
		{
			return this.Equals((InventoryItem)p);
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x0000AE72 File Offset: 0x00009072
		public override int GetHashCode()
		{
			return this._id.GetHashCode();
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x0000AE85 File Offset: 0x00009085
		public bool Equals(InventoryItem p)
		{
			return p._id == this._id;
		}

		// Token: 0x04000945 RID: 2373
		internal InventoryItemId _id;

		// Token: 0x04000946 RID: 2374
		internal InventoryDefId _def;

		// Token: 0x04000947 RID: 2375
		internal SteamItemFlags _flags;

		// Token: 0x04000948 RID: 2376
		internal ushort _quantity;

		// Token: 0x04000949 RID: 2377
		internal Dictionary<string, string> _properties;

		/// <summary>
		/// Small utility class to describe an item with a quantity
		/// </summary>
		// Token: 0x0200035C RID: 860
		internal struct Amount
		{
			// Token: 0x04001702 RID: 5890
			internal InventoryItem Item;

			// Token: 0x04001703 RID: 5891
			internal int Quantity;
		}
	}
}
