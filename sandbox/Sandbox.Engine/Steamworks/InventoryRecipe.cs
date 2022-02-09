using System;
using System.Linq;

namespace Steamworks
{
	/// <summary>
	/// A structured description of an item exchange
	/// </summary>
	// Token: 0x020000B0 RID: 176
	internal struct InventoryRecipe : IEquatable<InventoryRecipe>
	{
		// Token: 0x060006E9 RID: 1769 RVA: 0x0000AE98 File Offset: 0x00009098
		internal static InventoryRecipe FromString(string part, InventoryDef Result)
		{
			InventoryRecipe r = new InventoryRecipe
			{
				Result = Result,
				Source = part
			};
			string[] parts = part.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			r.Ingredients = (from x in parts
				select InventoryRecipe.Ingredient.FromString(x) into x
				where x.DefinitionId != 0
				select x).ToArray<InventoryRecipe.Ingredient>();
			return r;
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0000AF28 File Offset: 0x00009128
		internal bool ContainsIngredient(InventoryDef inventoryDef)
		{
			return this.Ingredients.Any((InventoryRecipe.Ingredient x) => x.DefinitionId == inventoryDef.Id);
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x0000AF59 File Offset: 0x00009159
		public static bool operator ==(InventoryRecipe a, InventoryRecipe b)
		{
			return a.GetHashCode() == b.GetHashCode();
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x0000AF77 File Offset: 0x00009177
		public static bool operator !=(InventoryRecipe a, InventoryRecipe b)
		{
			return a.GetHashCode() != b.GetHashCode();
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0000AF98 File Offset: 0x00009198
		public override bool Equals(object p)
		{
			return this.Equals((InventoryRecipe)p);
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x0000AFA6 File Offset: 0x000091A6
		public override int GetHashCode()
		{
			return this.Source.GetHashCode();
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x0000AFB3 File Offset: 0x000091B3
		public bool Equals(InventoryRecipe p)
		{
			return p.GetHashCode() == this.GetHashCode();
		}

		/// <summary>
		/// The item that this will create.
		/// </summary>
		// Token: 0x0400094A RID: 2378
		internal InventoryDef Result;

		/// <summary>
		/// The items, with quantity required to create this item.
		/// </summary>
		// Token: 0x0400094B RID: 2379
		internal InventoryRecipe.Ingredient[] Ingredients;

		// Token: 0x0400094C RID: 2380
		internal string Source;

		// Token: 0x02000360 RID: 864
		internal struct Ingredient
		{
			// Token: 0x06001641 RID: 5697 RVA: 0x000315C8 File Offset: 0x0002F7C8
			internal static InventoryRecipe.Ingredient FromString(string part)
			{
				InventoryRecipe.Ingredient i = default(InventoryRecipe.Ingredient);
				i.Count = 1;
				try
				{
					if (part.Contains("x"))
					{
						int idx = part.IndexOf('x');
						int count = 0;
						if (int.TryParse(part.Substring(idx + 1), out count))
						{
							i.Count = count;
						}
						part = part.Substring(0, idx);
					}
					i.DefinitionId = int.Parse(part);
					i.Definition = SteamInventory.FindDefinition(i.DefinitionId);
				}
				catch (Exception)
				{
					return i;
				}
				return i;
			}

			/// <summary>
			/// The definition ID of the ingredient.
			/// </summary>
			// Token: 0x04001714 RID: 5908
			internal int DefinitionId;

			/// <summary>
			/// If we don't know about this item definition this might be null.
			/// In which case, DefinitionId should still hold the correct id.
			/// </summary>
			// Token: 0x04001715 RID: 5909
			internal InventoryDef Definition;

			/// <summary>
			/// The amount of this item needed. Generally this will be 1.
			/// </summary>
			// Token: 0x04001716 RID: 5910
			internal int Count;
		}
	}
}
