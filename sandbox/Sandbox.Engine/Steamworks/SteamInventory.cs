using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Steamworks.Data;

namespace Steamworks
{
	/// <summary>
	/// Undocumented Parental Settings
	/// </summary>
	// Token: 0x0200009F RID: 159
	internal class SteamInventory : SteamSharedClass<SteamInventory>
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060005A1 RID: 1441 RVA: 0x00007920 File Offset: 0x00005B20
		internal static ISteamInventory Internal
		{
			get
			{
				return SteamSharedClass<SteamInventory>.Interface as ISteamInventory;
			}
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x0000792C File Offset: 0x00005B2C
		internal override void InitializeInterface(bool server)
		{
			this.SetInterface(server, new ISteamInventory(server));
			SteamInventory.InstallEvents(server);
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x00007944 File Offset: 0x00005B44
		internal static void InstallEvents(bool server)
		{
			if (!server)
			{
				Dispatch.Install<SteamInventoryFullUpdate_t>(delegate(SteamInventoryFullUpdate_t x)
				{
					SteamInventory.InventoryUpdated(x);
				}, false);
			}
			Dispatch.Install<SteamInventoryDefinitionUpdate_t>(delegate(SteamInventoryDefinitionUpdate_t x)
			{
				SteamInventory.LoadDefinitions();
			}, server);
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x000079A0 File Offset: 0x00005BA0
		private static void InventoryUpdated(SteamInventoryFullUpdate_t x)
		{
			InventoryResult r = new InventoryResult(x.Handle, false);
			SteamInventory.Items = r.GetItems(false);
			Action<InventoryResult> onInventoryUpdated = SteamInventory.OnInventoryUpdated;
			if (onInventoryUpdated == null)
			{
				return;
			}
			onInventoryUpdated(r);
		}

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060005A5 RID: 1445 RVA: 0x000079E0 File Offset: 0x00005BE0
		// (remove) Token: 0x060005A6 RID: 1446 RVA: 0x00007A14 File Offset: 0x00005C14
		public static event Action<InventoryResult> OnInventoryUpdated;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x060005A7 RID: 1447 RVA: 0x00007A48 File Offset: 0x00005C48
		// (remove) Token: 0x060005A8 RID: 1448 RVA: 0x00007A7C File Offset: 0x00005C7C
		public static event Action OnDefinitionsUpdated;

		// Token: 0x060005A9 RID: 1449 RVA: 0x00007AB0 File Offset: 0x00005CB0
		private static void LoadDefinitions()
		{
			SteamInventory.Definitions = SteamInventory.GetDefinitions();
			if (SteamInventory.Definitions == null)
			{
				return;
			}
			SteamInventory._defMap = new Dictionary<int, InventoryDef>();
			foreach (InventoryDef d in SteamInventory.Definitions)
			{
				SteamInventory._defMap[d.Id] = d;
			}
			Action onDefinitionsUpdated = SteamInventory.OnDefinitionsUpdated;
			if (onDefinitionsUpdated == null)
			{
				return;
			}
			onDefinitionsUpdated();
		}

		/// <summary>
		/// Call this if you're going to want to access definition information. You should be able to get 
		/// away with calling this once at the start if your game, assuming your items don't change all the time.
		/// This will trigger OnDefinitionsUpdated at which point Definitions should be set.
		/// </summary>
		// Token: 0x060005AA RID: 1450 RVA: 0x00007B11 File Offset: 0x00005D11
		public static void LoadItemDefinitions()
		{
			if (SteamInventory.Definitions == null)
			{
				SteamInventory.LoadDefinitions();
			}
			SteamInventory.Internal.LoadItemDefinitions();
		}

		/// <summary>
		/// Will call LoadItemDefinitions and wait until Definitions is not null
		/// </summary>
		// Token: 0x060005AB RID: 1451 RVA: 0x00007B2C File Offset: 0x00005D2C
		public static async Task<bool> WaitForDefinitions(float timeoutSeconds = 30f)
		{
			bool result;
			if (SteamInventory.Definitions != null)
			{
				result = true;
			}
			else
			{
				SteamInventory.LoadDefinitions();
				SteamInventory.LoadItemDefinitions();
				if (SteamInventory.Definitions != null)
				{
					result = true;
				}
				else
				{
					Stopwatch sw = Stopwatch.StartNew();
					while (SteamInventory.Definitions == null)
					{
						if (sw.Elapsed.TotalSeconds > (double)timeoutSeconds)
						{
							return false;
						}
						await Task.Delay(10);
					}
					result = true;
				}
			}
			return result;
		}

		/// <summary>
		/// Try to find the definition that matches this definition ID.
		/// Uses a dictionary so should be about as fast as possible.
		/// </summary>
		// Token: 0x060005AC RID: 1452 RVA: 0x00007B70 File Offset: 0x00005D70
		public static InventoryDef FindDefinition(InventoryDefId defId)
		{
			if (SteamInventory._defMap == null)
			{
				return null;
			}
			InventoryDef val;
			if (SteamInventory._defMap.TryGetValue(defId, out val))
			{
				return val;
			}
			return null;
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060005AD RID: 1453 RVA: 0x00007B9D File Offset: 0x00005D9D
		// (set) Token: 0x060005AE RID: 1454 RVA: 0x00007BA4 File Offset: 0x00005DA4
		public static string Currency { get; internal set; }

		// Token: 0x060005AF RID: 1455 RVA: 0x00007BAC File Offset: 0x00005DAC
		public static async Task<InventoryDef[]> GetDefinitionsWithPricesAsync()
		{
			SteamInventoryRequestPricesResult_t? priceRequest = await SteamInventory.Internal.RequestPrices();
			InventoryDef[] result;
			if (priceRequest == null || priceRequest.Value.Result != Result.OK)
			{
				result = null;
			}
			else
			{
				SteamInventory.Currency = ((priceRequest != null) ? priceRequest.GetValueOrDefault().CurrencyUTF8() : null);
				uint num = SteamInventory.Internal.GetNumItemsWithPrices();
				if (num <= 0U)
				{
					result = null;
				}
				else
				{
					InventoryDefId[] defs = new InventoryDefId[num];
					ulong[] currentPrices = new ulong[num];
					ulong[] baseprices = new ulong[num];
					if (!SteamInventory.Internal.GetItemsWithPrices(defs, currentPrices, baseprices, num))
					{
						result = null;
					}
					else
					{
						result = defs.Select((InventoryDefId x) => new InventoryDef(x)).ToArray<InventoryDef>();
					}
				}
			}
			return result;
		}

		/// <summary>
		/// We will try to keep this list of your items automatically up to date.
		/// </summary>
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x00007BE7 File Offset: 0x00005DE7
		// (set) Token: 0x060005B1 RID: 1457 RVA: 0x00007BEE File Offset: 0x00005DEE
		public static InventoryItem[] Items { get; internal set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060005B2 RID: 1458 RVA: 0x00007BF6 File Offset: 0x00005DF6
		// (set) Token: 0x060005B3 RID: 1459 RVA: 0x00007BFD File Offset: 0x00005DFD
		public static InventoryDef[] Definitions { get; internal set; }

		// Token: 0x060005B4 RID: 1460 RVA: 0x00007C08 File Offset: 0x00005E08
		internal static InventoryDef[] GetDefinitions()
		{
			uint num = 0U;
			if (!SteamInventory.Internal.GetItemDefinitionIDs(null, ref num))
			{
				return null;
			}
			InventoryDefId[] defs = new InventoryDefId[num];
			if (!SteamInventory.Internal.GetItemDefinitionIDs(defs, ref num))
			{
				return null;
			}
			return defs.Select((InventoryDefId x) => new InventoryDef(x)).ToArray<InventoryDef>();
		}

		/// <summary>
		/// Update the list of Items[]
		/// </summary>
		// Token: 0x060005B5 RID: 1461 RVA: 0x00007C6C File Offset: 0x00005E6C
		public static bool GetAllItems()
		{
			SteamInventoryResult_t sresult = Defines.k_SteamInventoryResultInvalid;
			return SteamInventory.Internal.GetAllItems(ref sresult);
		}

		/// <summary>
		/// Get all items and return the InventoryResult
		/// </summary>
		// Token: 0x060005B6 RID: 1462 RVA: 0x00007C8C File Offset: 0x00005E8C
		public static async Task<InventoryResult?> GetAllItemsAsync()
		{
			SteamInventoryResult_t sresult = Defines.k_SteamInventoryResultInvalid;
			InventoryResult? result;
			if (!SteamInventory.Internal.GetAllItems(ref sresult))
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
		/// This is used to grant a specific item to the user. This should 
		/// only be used for development prototyping, from a trusted server, 
		/// or if you don't care about hacked clients granting arbitrary items. 
		/// This call can be disabled by a setting on Steamworks.
		/// </summary>
		// Token: 0x060005B7 RID: 1463 RVA: 0x00007CC8 File Offset: 0x00005EC8
		public static async Task<InventoryResult?> GenerateItemAsync(InventoryDef target, int amount)
		{
			SteamInventoryResult_t sresult = Defines.k_SteamInventoryResultInvalid;
			InventoryDefId[] defs = new InventoryDefId[] { target.Id };
			uint[] cnts = new uint[] { (uint)amount };
			InventoryResult? result;
			if (!SteamInventory.Internal.GenerateItems(ref sresult, defs, cnts, 1U))
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
		/// Crafting! Uses the passed items to buy the target item.
		/// You need to have set up the appropriate exchange rules in your item
		/// definitions. This assumes all the items passed in aren't stacked.
		/// </summary>
		// Token: 0x060005B8 RID: 1464 RVA: 0x00007D14 File Offset: 0x00005F14
		public static async Task<InventoryResult?> CraftItemAsync(InventoryItem[] list, InventoryDef target)
		{
			SteamInventoryResult_t sresult = Defines.k_SteamInventoryResultInvalid;
			InventoryDefId[] give = new InventoryDefId[] { target.Id };
			uint[] givec = new uint[] { 1U };
			InventoryItemId[] sell = list.Select((InventoryItem x) => x.Id).ToArray<InventoryItemId>();
			uint[] sellc = list.Select((InventoryItem x) => 1U).ToArray<uint>();
			InventoryResult? result;
			if (!SteamInventory.Internal.ExchangeItems(ref sresult, give, givec, 1U, sell, sellc, (uint)sell.Length))
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
		/// Crafting! Uses the passed items to buy the target item.
		/// You need to have set up the appropriate exchange rules in your item
		/// definitions. This assumes all the items passed in aren't stacked.
		/// </summary>
		// Token: 0x060005B9 RID: 1465 RVA: 0x00007D60 File Offset: 0x00005F60
		public static async Task<InventoryResult?> CraftItemAsync(InventoryItem.Amount[] list, InventoryDef target)
		{
			SteamInventoryResult_t sresult = Defines.k_SteamInventoryResultInvalid;
			InventoryDefId[] give = new InventoryDefId[] { target.Id };
			uint[] givec = new uint[] { 1U };
			InventoryItemId[] sell = list.Select((InventoryItem.Amount x) => x.Item.Id).ToArray<InventoryItemId>();
			uint[] sellc = list.Select((InventoryItem.Amount x) => (uint)x.Quantity).ToArray<uint>();
			InventoryResult? result;
			if (!SteamInventory.Internal.ExchangeItems(ref sresult, give, givec, 1U, sell, sellc, (uint)sell.Length))
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
		/// Deserializes a result set and verifies the signature bytes.	
		/// This call has a potential soft-failure mode where the Result is expired, it will 
		/// still succeed in this mode.The "expired" 
		/// result could indicate that the data may be out of date - not just due to timed 
		/// expiration( one hour ), but also because one of the items in the result set may 
		/// have been traded or consumed since the result set was generated.You could compare 
		/// the timestamp from GetResultTimestamp to ISteamUtils::GetServerRealTime to determine
		/// how old the data is. You could simply ignore the "expired" result code and 
		/// continue as normal, or you could request the player with expired data to send 
		/// an updated result set.
		/// You should call CheckResultSteamID on the result handle when it completes to verify 
		/// that a remote player is not pretending to have a different user's inventory.
		/// </summary>
		// Token: 0x060005BA RID: 1466 RVA: 0x00007DAC File Offset: 0x00005FAC
		public static async Task<InventoryResult?> DeserializeAsync(byte[] data, int dataLength = -1)
		{
			if (data == null)
			{
				throw new ArgumentException("data should not be null");
			}
			if (dataLength == -1)
			{
				dataLength = data.Length;
			}
			IntPtr ptr = Marshal.AllocHGlobal(dataLength);
			InventoryResult? result;
			try
			{
				Marshal.Copy(data, 0, ptr, dataLength);
				SteamInventoryResult_t sresult = Defines.k_SteamInventoryResultInvalid;
				if (!SteamInventory.Internal.DeserializeResult(ref sresult, ptr, (uint)dataLength, false))
				{
					result = null;
				}
				else
				{
					result = await InventoryResult.GetAsync(sresult.Value);
				}
			}
			finally
			{
				Marshal.FreeHGlobal(ptr);
			}
			return result;
		}

		/// <summary>
		/// Grant all promotional items the user is eligible for
		/// </summary>
		// Token: 0x060005BB RID: 1467 RVA: 0x00007DF8 File Offset: 0x00005FF8
		public static async Task<InventoryResult?> GrantPromoItemsAsync()
		{
			SteamInventoryResult_t sresult = Defines.k_SteamInventoryResultInvalid;
			InventoryResult? result;
			if (!SteamInventory.Internal.GrantPromoItems(ref sresult))
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
		/// Trigger an item drop for this user. This is for timed drops.
		/// </summary>
		// Token: 0x060005BC RID: 1468 RVA: 0x00007E34 File Offset: 0x00006034
		public static async Task<InventoryResult?> TriggerItemDropAsync(InventoryDefId id)
		{
			SteamInventoryResult_t sresult = Defines.k_SteamInventoryResultInvalid;
			InventoryResult? result;
			if (!SteamInventory.Internal.TriggerItemDrop(ref sresult, id))
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
		/// Trigger a promo item drop. You can call this at startup, it won't
		/// give users multiple promo drops.
		/// </summary>
		// Token: 0x060005BD RID: 1469 RVA: 0x00007E78 File Offset: 0x00006078
		public static async Task<InventoryResult?> AddPromoItemAsync(InventoryDefId id)
		{
			SteamInventoryResult_t sresult = Defines.k_SteamInventoryResultInvalid;
			InventoryResult? result;
			if (!SteamInventory.Internal.AddPromoItem(ref sresult, id))
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
		/// Start buying a cart load of items. This will return a positive result is the purchase has
		/// begun. You should listen out for SteamUser.OnMicroTxnAuthorizationResponse for a success.
		/// </summary>
		// Token: 0x060005BE RID: 1470 RVA: 0x00007EBC File Offset: 0x000060BC
		public static async Task<InventoryPurchaseResult?> StartPurchaseAsync(InventoryDef[] items)
		{
			Dictionary<InventoryDefId, uint> dictionary = (from x in items
				group x by x._id).ToDictionary((IGrouping<InventoryDefId, InventoryDef> x) => x.Key, (IGrouping<InventoryDefId, InventoryDef> x) => (uint)x.Count<InventoryDef>());
			InventoryDefId[] item_i = dictionary.Keys.ToArray<InventoryDefId>();
			uint[] item_q = dictionary.Values.ToArray<uint>();
			SteamInventoryStartPurchaseResult_t? r = await SteamInventory.Internal.StartPurchase(item_i, item_q, (uint)item_i.Length);
			InventoryPurchaseResult? result;
			if (r == null)
			{
				result = null;
			}
			else
			{
				result = new InventoryPurchaseResult?(new InventoryPurchaseResult
				{
					Result = r.Value.Result,
					OrderID = r.Value.OrderID,
					TransID = r.Value.TransID
				});
			}
			return result;
		}

		// Token: 0x04000903 RID: 2307
		private static Dictionary<int, InventoryDef> _defMap;
	}
}
