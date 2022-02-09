using System;
using System.Threading.Tasks;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x020000B1 RID: 177
	internal struct InventoryResult : IDisposable
	{
		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060006F0 RID: 1776 RVA: 0x0000AFD0 File Offset: 0x000091D0
		// (set) Token: 0x060006F1 RID: 1777 RVA: 0x0000AFD8 File Offset: 0x000091D8
		internal bool Expired { readonly get; set; }

		// Token: 0x060006F2 RID: 1778 RVA: 0x0000AFE1 File Offset: 0x000091E1
		internal InventoryResult(SteamInventoryResult_t id, bool expired)
		{
			this._id = id;
			this.Expired = expired;
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060006F3 RID: 1779 RVA: 0x0000AFF4 File Offset: 0x000091F4
		internal int ItemCount
		{
			get
			{
				uint cnt = 0U;
				if (!SteamInventory.Internal.GetResultItems(this._id, null, ref cnt))
				{
					return 0;
				}
				return (int)cnt;
			}
		}

		/// <summary>
		/// Checks whether an inventory result handle belongs to the specified Steam ID.
		/// This is important when using Deserialize, to verify that a remote player is not pretending to have a different user's inventory
		/// </summary>
		// Token: 0x060006F4 RID: 1780 RVA: 0x0000B01B File Offset: 0x0000921B
		internal bool BelongsTo(SteamId steamId)
		{
			return SteamInventory.Internal.CheckResultSteamID(this._id, steamId);
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x0000B030 File Offset: 0x00009230
		internal InventoryItem[] GetItems(bool includeProperties = false)
		{
			uint cnt = (uint)this.ItemCount;
			if (cnt <= 0U)
			{
				return null;
			}
			SteamItemDetails_t[] pOutItemsArray = new SteamItemDetails_t[cnt];
			if (!SteamInventory.Internal.GetResultItems(this._id, pOutItemsArray, ref cnt))
			{
				return null;
			}
			InventoryItem[] items = new InventoryItem[cnt];
			int i = 0;
			while ((long)i < (long)((ulong)cnt))
			{
				InventoryItem item = InventoryItem.From(pOutItemsArray[i]);
				if (includeProperties)
				{
					item._properties = InventoryItem.GetProperties(this._id, i);
				}
				items[i] = item;
				i++;
			}
			return items;
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x0000B0AB File Offset: 0x000092AB
		public void Dispose()
		{
			if (this._id.Value == -1)
			{
				return;
			}
			SteamInventory.Internal.DestroyResult(this._id);
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x0000B0CC File Offset: 0x000092CC
		internal static async Task<InventoryResult?> GetAsync(SteamInventoryResult_t sresult)
		{
			Result _result = Result.Pending;
			while (_result == Result.Pending)
			{
				_result = SteamInventory.Internal.GetResultStatus(sresult);
				await Task.Delay(10);
			}
			InventoryResult? result;
			if (_result != Result.OK && _result != Result.Expired)
			{
				result = null;
			}
			else
			{
				result = new InventoryResult?(new InventoryResult(sresult, _result == Result.Expired));
			}
			return result;
		}

		/// <summary>
		/// Serialized result sets contain a short signature which can't be forged or replayed across different game sessions.
		/// A result set can be serialized on the local client, transmitted to other players via your game networking, and 
		/// deserialized by the remote players.This is a secure way of preventing hackers from lying about posessing 
		/// rare/high-value items. Serializes a result set with signature bytes to an output buffer.The size of a serialized 
		/// result depends on the number items which are being serialized.When securely transmitting items to other players, 
		/// it is recommended to use GetItemsByID first to create a minimal result set.
		/// Results have a built-in timestamp which will be considered "expired" after an hour has elapsed.See DeserializeResult
		/// for expiration handling.
		/// </summary>
		// Token: 0x060006F8 RID: 1784 RVA: 0x0000B110 File Offset: 0x00009310
		internal unsafe byte[] Serialize()
		{
			uint size = 0U;
			if (!SteamInventory.Internal.SerializeResult(this._id, IntPtr.Zero, ref size))
			{
				return null;
			}
			byte[] data = new byte[size];
			byte[] array;
			byte* ptr;
			if ((array = data) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			if (!SteamInventory.Internal.SerializeResult(this._id, (IntPtr)((void*)ptr), ref size))
			{
				return null;
			}
			array = null;
			return data;
		}

		// Token: 0x0400094D RID: 2381
		internal SteamInventoryResult_t _id;
	}
}
