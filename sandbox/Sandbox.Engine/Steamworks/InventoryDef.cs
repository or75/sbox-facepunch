using System;
using System.Collections.Generic;
using System.Linq;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x020000AE RID: 174
	internal class InventoryDef : IEquatable<InventoryDef>
	{
		// Token: 0x060006B6 RID: 1718 RVA: 0x0000A750 File Offset: 0x00008950
		internal InventoryDef(InventoryDefId defId)
		{
			this._id = defId;
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060006B7 RID: 1719 RVA: 0x0000A75F File Offset: 0x0000895F
		internal int Id
		{
			get
			{
				return this._id.Value;
			}
		}

		/// <summary>
		/// Shortcut to call GetProperty( "name" )
		/// </summary>
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060006B8 RID: 1720 RVA: 0x0000A76C File Offset: 0x0000896C
		internal string Name
		{
			get
			{
				return this.GetProperty("name");
			}
		}

		/// <summary>
		/// Shortcut to call GetProperty( "description" )
		/// </summary>
		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060006B9 RID: 1721 RVA: 0x0000A779 File Offset: 0x00008979
		internal string Description
		{
			get
			{
				return this.GetProperty("description");
			}
		}

		/// <summary>
		/// Shortcut to call GetProperty( "icon_url" )
		/// </summary>
		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060006BA RID: 1722 RVA: 0x0000A786 File Offset: 0x00008986
		internal string IconUrl
		{
			get
			{
				return this.GetProperty("icon_url");
			}
		}

		/// <summary>
		/// Shortcut to call GetProperty( "icon_url_large" )
		/// </summary>
		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060006BB RID: 1723 RVA: 0x0000A793 File Offset: 0x00008993
		internal string IconUrlLarge
		{
			get
			{
				return this.GetProperty("icon_url_large");
			}
		}

		/// <summary>
		/// Shortcut to call GetProperty( "price_category" )
		/// </summary>
		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060006BC RID: 1724 RVA: 0x0000A7A0 File Offset: 0x000089A0
		internal string PriceCategory
		{
			get
			{
				return this.GetProperty("price_category");
			}
		}

		/// <summary>
		/// Shortcut to call GetProperty( "type" )
		/// </summary>
		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060006BD RID: 1725 RVA: 0x0000A7AD File Offset: 0x000089AD
		internal string Type
		{
			get
			{
				return this.GetProperty("type");
			}
		}

		/// <summary>
		/// Returns true if this is an item that generates an item, rather 
		/// than something that is actual an item
		/// </summary>
		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060006BE RID: 1726 RVA: 0x0000A7BA File Offset: 0x000089BA
		internal bool IsGenerator
		{
			get
			{
				return this.Type == "generator";
			}
		}

		/// <summary>
		/// Shortcut to call GetProperty( "exchange" )
		/// </summary>
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060006BF RID: 1727 RVA: 0x0000A7CC File Offset: 0x000089CC
		internal string ExchangeSchema
		{
			get
			{
				return this.GetProperty("exchange");
			}
		}

		/// <summary>
		/// Get a list of exchanges that are available to make this item
		/// </summary>
		// Token: 0x060006C0 RID: 1728 RVA: 0x0000A7D9 File Offset: 0x000089D9
		internal InventoryRecipe[] GetRecipes()
		{
			if (string.IsNullOrEmpty(this.ExchangeSchema))
			{
				return null;
			}
			return (from x in this.ExchangeSchema.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
				select InventoryRecipe.FromString(x, this)).ToArray<InventoryRecipe>();
		}

		/// <summary>
		/// Shortcut to call GetBoolProperty( "marketable" )
		/// </summary>
		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060006C1 RID: 1729 RVA: 0x0000A817 File Offset: 0x00008A17
		internal bool Marketable
		{
			get
			{
				return this.GetBoolProperty("marketable");
			}
		}

		/// <summary>
		/// Shortcut to call GetBoolProperty( "tradable" )
		/// </summary>
		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060006C2 RID: 1730 RVA: 0x0000A824 File Offset: 0x00008A24
		internal bool Tradable
		{
			get
			{
				return this.GetBoolProperty("tradable");
			}
		}

		/// <summary>
		/// Gets the property timestamp
		/// </summary>
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060006C3 RID: 1731 RVA: 0x0000A831 File Offset: 0x00008A31
		internal DateTime Created
		{
			get
			{
				return this.GetProperty<DateTime>("timestamp");
			}
		}

		/// <summary>
		/// Gets the property modified
		/// </summary>
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060006C4 RID: 1732 RVA: 0x0000A83E File Offset: 0x00008A3E
		internal DateTime Modified
		{
			get
			{
				return this.GetProperty<DateTime>("modified");
			}
		}

		/// <summary>
		/// Get a specific property by name
		/// </summary>
		// Token: 0x060006C5 RID: 1733 RVA: 0x0000A84C File Offset: 0x00008A4C
		internal string GetProperty(string name)
		{
			string val;
			if (this._properties != null && this._properties.TryGetValue(name, out val))
			{
				return val;
			}
			uint _ = 32768U;
			string vl;
			if (!SteamInventory.Internal.GetItemDefinitionProperty(this.Id, name, out vl, ref _))
			{
				return null;
			}
			if (name == null)
			{
				return vl;
			}
			if (this._properties == null)
			{
				this._properties = new Dictionary<string, string>();
			}
			this._properties[name] = vl;
			return vl;
		}

		/// <summary>
		/// Read a raw property from the definition schema
		/// </summary>
		// Token: 0x060006C6 RID: 1734 RVA: 0x0000A8C0 File Offset: 0x00008AC0
		internal bool GetBoolProperty(string name)
		{
			string val = this.GetProperty(name);
			return val.Length != 0 && val[0] != '0' && val[0] != 'F' && val[0] != 'f';
		}

		/// <summary>
		/// Read a raw property from the definition schema
		/// </summary>
		// Token: 0x060006C7 RID: 1735 RVA: 0x0000A904 File Offset: 0x00008B04
		internal T GetProperty<T>(string name)
		{
			string val = this.GetProperty(name);
			T result;
			if (string.IsNullOrEmpty(val))
			{
				result = default(T);
				return result;
			}
			try
			{
				result = (T)((object)Convert.ChangeType(val, typeof(T)));
			}
			catch (Exception)
			{
				result = default(T);
			}
			return result;
		}

		/// <summary>
		/// Gets a list of all properties on this item
		/// </summary>
		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060006C8 RID: 1736 RVA: 0x0000A964 File Offset: 0x00008B64
		internal IEnumerable<KeyValuePair<string, string>> Properties
		{
			get
			{
				string[] keys = this.GetProperty(null).Split(',', StringSplitOptions.None);
				foreach (string key in keys)
				{
					yield return new KeyValuePair<string, string>(key, this.GetProperty(key));
				}
				string[] array = null;
				yield break;
			}
		}

		/// <summary>
		/// Returns the price of this item in the local currency (SteamInventory.Currency)
		/// </summary>
		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060006C9 RID: 1737 RVA: 0x0000A974 File Offset: 0x00008B74
		internal int LocalPrice
		{
			get
			{
				ulong curprice = 0UL;
				ulong baseprice = 0UL;
				if (!SteamInventory.Internal.GetItemPrice(this.Id, ref curprice, ref baseprice))
				{
					return 0;
				}
				return (int)curprice;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060006CA RID: 1738 RVA: 0x0000A9A6 File Offset: 0x00008BA6
		internal string LocalPriceFormatted
		{
			get
			{
				return Utility.FormatPrice(SteamInventory.Currency, (double)this.LocalPrice / 100.0);
			}
		}

		/// <summary>
		/// If the price has been discounted, LocalPrice will differ from LocalBasePrice
		/// (assumed, this isn't documented)
		/// </summary>
		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060006CB RID: 1739 RVA: 0x0000A9C4 File Offset: 0x00008BC4
		internal int LocalBasePrice
		{
			get
			{
				ulong curprice = 0UL;
				ulong baseprice = 0UL;
				if (!SteamInventory.Internal.GetItemPrice(this.Id, ref curprice, ref baseprice))
				{
					return 0;
				}
				return (int)baseprice;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060006CC RID: 1740 RVA: 0x0000A9F6 File Offset: 0x00008BF6
		internal string LocalBasePriceFormatted
		{
			get
			{
				return Utility.FormatPrice(SteamInventory.Currency, (double)this.LocalPrice / 100.0);
			}
		}

		/// <summary>
		/// Return a list of recepies that contain this item
		/// </summary>
		// Token: 0x060006CD RID: 1741 RVA: 0x0000AA14 File Offset: 0x00008C14
		internal InventoryRecipe[] GetRecipesContainingThis()
		{
			if (this._recContaining != null)
			{
				return this._recContaining;
			}
			IEnumerable<InventoryRecipe> allRec = (from x in SteamInventory.Definitions
				select x.GetRecipes() into x
				where x != null
				select x).SelectMany((InventoryRecipe[] x) => x);
			this._recContaining = allRec.Where((InventoryRecipe x) => x.ContainsIngredient(this)).ToArray<InventoryRecipe>();
			return this._recContaining;
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x0000AAC5 File Offset: 0x00008CC5
		public static bool operator ==(InventoryDef a, InventoryDef b)
		{
			if (a == null)
			{
				return b == null;
			}
			return a.Equals(b);
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x0000AAD6 File Offset: 0x00008CD6
		public static bool operator !=(InventoryDef a, InventoryDef b)
		{
			return !(a == b);
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x0000AAE2 File Offset: 0x00008CE2
		public override bool Equals(object p)
		{
			return this.Equals((InventoryDef)p);
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x0000AAF0 File Offset: 0x00008CF0
		public override int GetHashCode()
		{
			return this.Id.GetHashCode();
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x0000AB0B File Offset: 0x00008D0B
		public bool Equals(InventoryDef p)
		{
			return !(p == null) && p.Id == this.Id;
		}

		// Token: 0x04000942 RID: 2370
		internal InventoryDefId _id;

		// Token: 0x04000943 RID: 2371
		internal Dictionary<string, string> _properties;

		// Token: 0x04000944 RID: 2372
		private InventoryRecipe[] _recContaining;
	}
}
