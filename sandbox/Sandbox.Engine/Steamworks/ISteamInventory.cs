using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x0200002A RID: 42
	internal class ISteamInventory : SteamInterface
	{
		// Token: 0x060002CB RID: 715 RVA: 0x000051BA File Offset: 0x000033BA
		internal ISteamInventory(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x060002CC RID: 716
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamInventory_v003();

		// Token: 0x060002CD RID: 717 RVA: 0x000051C9 File Offset: 0x000033C9
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamInventory.SteamAPI_SteamInventory_v003();
		}

		// Token: 0x060002CE RID: 718
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamGameServerInventory_v003();

		// Token: 0x060002CF RID: 719 RVA: 0x000051D0 File Offset: 0x000033D0
		internal override IntPtr GetServerInterfacePointer()
		{
			return ISteamInventory.SteamAPI_SteamGameServerInventory_v003();
		}

		// Token: 0x060002D0 RID: 720
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_GetResultStatus")]
		private static extern Result _GetResultStatus(IntPtr self, SteamInventoryResult_t resultHandle);

		// Token: 0x060002D1 RID: 721 RVA: 0x000051D7 File Offset: 0x000033D7
		internal Result GetResultStatus(SteamInventoryResult_t resultHandle)
		{
			return ISteamInventory._GetResultStatus(this.Self, resultHandle);
		}

		// Token: 0x060002D2 RID: 722
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_GetResultItems")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetResultItems(IntPtr self, SteamInventoryResult_t resultHandle, [In] [Out] SteamItemDetails_t[] pOutItemsArray, ref uint punOutItemsArraySize);

		// Token: 0x060002D3 RID: 723 RVA: 0x000051E5 File Offset: 0x000033E5
		internal bool GetResultItems(SteamInventoryResult_t resultHandle, [In] [Out] SteamItemDetails_t[] pOutItemsArray, ref uint punOutItemsArraySize)
		{
			return ISteamInventory._GetResultItems(this.Self, resultHandle, pOutItemsArray, ref punOutItemsArraySize);
		}

		// Token: 0x060002D4 RID: 724
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_GetResultItemProperty")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetResultItemProperty(IntPtr self, SteamInventoryResult_t resultHandle, uint unItemIndex, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPropertyName, IntPtr pchValueBuffer, ref uint punValueBufferSizeOut);

		// Token: 0x060002D5 RID: 725 RVA: 0x000051F8 File Offset: 0x000033F8
		internal bool GetResultItemProperty(SteamInventoryResult_t resultHandle, uint unItemIndex, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPropertyName, out string pchValueBuffer, ref uint punValueBufferSizeOut)
		{
			Helpers.Memory mempchValueBuffer = Helpers.TakeMemory();
			bool result;
			try
			{
				bool flag = ISteamInventory._GetResultItemProperty(this.Self, resultHandle, unItemIndex, pchPropertyName, mempchValueBuffer, ref punValueBufferSizeOut);
				pchValueBuffer = Helpers.MemoryToString(mempchValueBuffer);
				result = flag;
			}
			finally
			{
				((IDisposable)mempchValueBuffer).Dispose();
			}
			return result;
		}

		// Token: 0x060002D6 RID: 726
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_GetResultTimestamp")]
		private static extern uint _GetResultTimestamp(IntPtr self, SteamInventoryResult_t resultHandle);

		// Token: 0x060002D7 RID: 727 RVA: 0x00005254 File Offset: 0x00003454
		internal uint GetResultTimestamp(SteamInventoryResult_t resultHandle)
		{
			return ISteamInventory._GetResultTimestamp(this.Self, resultHandle);
		}

		// Token: 0x060002D8 RID: 728
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_CheckResultSteamID")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _CheckResultSteamID(IntPtr self, SteamInventoryResult_t resultHandle, SteamId steamIDExpected);

		// Token: 0x060002D9 RID: 729 RVA: 0x00005262 File Offset: 0x00003462
		internal bool CheckResultSteamID(SteamInventoryResult_t resultHandle, SteamId steamIDExpected)
		{
			return ISteamInventory._CheckResultSteamID(this.Self, resultHandle, steamIDExpected);
		}

		// Token: 0x060002DA RID: 730
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_DestroyResult")]
		private static extern void _DestroyResult(IntPtr self, SteamInventoryResult_t resultHandle);

		// Token: 0x060002DB RID: 731 RVA: 0x00005271 File Offset: 0x00003471
		internal void DestroyResult(SteamInventoryResult_t resultHandle)
		{
			ISteamInventory._DestroyResult(this.Self, resultHandle);
		}

		// Token: 0x060002DC RID: 732
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_GetAllItems")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetAllItems(IntPtr self, ref SteamInventoryResult_t pResultHandle);

		// Token: 0x060002DD RID: 733 RVA: 0x0000527F File Offset: 0x0000347F
		internal bool GetAllItems(ref SteamInventoryResult_t pResultHandle)
		{
			return ISteamInventory._GetAllItems(this.Self, ref pResultHandle);
		}

		// Token: 0x060002DE RID: 734
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_GetItemsByID")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetItemsByID(IntPtr self, ref SteamInventoryResult_t pResultHandle, ref InventoryItemId pInstanceIDs, uint unCountInstanceIDs);

		// Token: 0x060002DF RID: 735 RVA: 0x0000528D File Offset: 0x0000348D
		internal bool GetItemsByID(ref SteamInventoryResult_t pResultHandle, ref InventoryItemId pInstanceIDs, uint unCountInstanceIDs)
		{
			return ISteamInventory._GetItemsByID(this.Self, ref pResultHandle, ref pInstanceIDs, unCountInstanceIDs);
		}

		// Token: 0x060002E0 RID: 736
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_SerializeResult")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SerializeResult(IntPtr self, SteamInventoryResult_t resultHandle, IntPtr pOutBuffer, ref uint punOutBufferSize);

		// Token: 0x060002E1 RID: 737 RVA: 0x0000529D File Offset: 0x0000349D
		internal bool SerializeResult(SteamInventoryResult_t resultHandle, IntPtr pOutBuffer, ref uint punOutBufferSize)
		{
			return ISteamInventory._SerializeResult(this.Self, resultHandle, pOutBuffer, ref punOutBufferSize);
		}

		// Token: 0x060002E2 RID: 738
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_DeserializeResult")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _DeserializeResult(IntPtr self, ref SteamInventoryResult_t pOutResultHandle, IntPtr pBuffer, uint unBufferSize, [MarshalAs(UnmanagedType.U1)] bool bRESERVED_MUST_BE_FALSE);

		// Token: 0x060002E3 RID: 739 RVA: 0x000052AD File Offset: 0x000034AD
		internal bool DeserializeResult(ref SteamInventoryResult_t pOutResultHandle, IntPtr pBuffer, uint unBufferSize, [MarshalAs(UnmanagedType.U1)] bool bRESERVED_MUST_BE_FALSE)
		{
			return ISteamInventory._DeserializeResult(this.Self, ref pOutResultHandle, pBuffer, unBufferSize, bRESERVED_MUST_BE_FALSE);
		}

		// Token: 0x060002E4 RID: 740
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_GenerateItems")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GenerateItems(IntPtr self, ref SteamInventoryResult_t pResultHandle, [In] [Out] InventoryDefId[] pArrayItemDefs, [In] [Out] uint[] punArrayQuantity, uint unArrayLength);

		// Token: 0x060002E5 RID: 741 RVA: 0x000052BF File Offset: 0x000034BF
		internal bool GenerateItems(ref SteamInventoryResult_t pResultHandle, [In] [Out] InventoryDefId[] pArrayItemDefs, [In] [Out] uint[] punArrayQuantity, uint unArrayLength)
		{
			return ISteamInventory._GenerateItems(this.Self, ref pResultHandle, pArrayItemDefs, punArrayQuantity, unArrayLength);
		}

		// Token: 0x060002E6 RID: 742
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_GrantPromoItems")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GrantPromoItems(IntPtr self, ref SteamInventoryResult_t pResultHandle);

		// Token: 0x060002E7 RID: 743 RVA: 0x000052D1 File Offset: 0x000034D1
		internal bool GrantPromoItems(ref SteamInventoryResult_t pResultHandle)
		{
			return ISteamInventory._GrantPromoItems(this.Self, ref pResultHandle);
		}

		// Token: 0x060002E8 RID: 744
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_AddPromoItem")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _AddPromoItem(IntPtr self, ref SteamInventoryResult_t pResultHandle, InventoryDefId itemDef);

		// Token: 0x060002E9 RID: 745 RVA: 0x000052DF File Offset: 0x000034DF
		internal bool AddPromoItem(ref SteamInventoryResult_t pResultHandle, InventoryDefId itemDef)
		{
			return ISteamInventory._AddPromoItem(this.Self, ref pResultHandle, itemDef);
		}

		// Token: 0x060002EA RID: 746
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_AddPromoItems")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _AddPromoItems(IntPtr self, ref SteamInventoryResult_t pResultHandle, [In] [Out] InventoryDefId[] pArrayItemDefs, uint unArrayLength);

		// Token: 0x060002EB RID: 747 RVA: 0x000052EE File Offset: 0x000034EE
		internal bool AddPromoItems(ref SteamInventoryResult_t pResultHandle, [In] [Out] InventoryDefId[] pArrayItemDefs, uint unArrayLength)
		{
			return ISteamInventory._AddPromoItems(this.Self, ref pResultHandle, pArrayItemDefs, unArrayLength);
		}

		// Token: 0x060002EC RID: 748
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_ConsumeItem")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _ConsumeItem(IntPtr self, ref SteamInventoryResult_t pResultHandle, InventoryItemId itemConsume, uint unQuantity);

		// Token: 0x060002ED RID: 749 RVA: 0x000052FE File Offset: 0x000034FE
		internal bool ConsumeItem(ref SteamInventoryResult_t pResultHandle, InventoryItemId itemConsume, uint unQuantity)
		{
			return ISteamInventory._ConsumeItem(this.Self, ref pResultHandle, itemConsume, unQuantity);
		}

		// Token: 0x060002EE RID: 750
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_ExchangeItems")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _ExchangeItems(IntPtr self, ref SteamInventoryResult_t pResultHandle, [In] [Out] InventoryDefId[] pArrayGenerate, [In] [Out] uint[] punArrayGenerateQuantity, uint unArrayGenerateLength, [In] [Out] InventoryItemId[] pArrayDestroy, [In] [Out] uint[] punArrayDestroyQuantity, uint unArrayDestroyLength);

		// Token: 0x060002EF RID: 751 RVA: 0x0000530E File Offset: 0x0000350E
		internal bool ExchangeItems(ref SteamInventoryResult_t pResultHandle, [In] [Out] InventoryDefId[] pArrayGenerate, [In] [Out] uint[] punArrayGenerateQuantity, uint unArrayGenerateLength, [In] [Out] InventoryItemId[] pArrayDestroy, [In] [Out] uint[] punArrayDestroyQuantity, uint unArrayDestroyLength)
		{
			return ISteamInventory._ExchangeItems(this.Self, ref pResultHandle, pArrayGenerate, punArrayGenerateQuantity, unArrayGenerateLength, pArrayDestroy, punArrayDestroyQuantity, unArrayDestroyLength);
		}

		// Token: 0x060002F0 RID: 752
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_TransferItemQuantity")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _TransferItemQuantity(IntPtr self, ref SteamInventoryResult_t pResultHandle, InventoryItemId itemIdSource, uint unQuantity, InventoryItemId itemIdDest);

		// Token: 0x060002F1 RID: 753 RVA: 0x00005326 File Offset: 0x00003526
		internal bool TransferItemQuantity(ref SteamInventoryResult_t pResultHandle, InventoryItemId itemIdSource, uint unQuantity, InventoryItemId itemIdDest)
		{
			return ISteamInventory._TransferItemQuantity(this.Self, ref pResultHandle, itemIdSource, unQuantity, itemIdDest);
		}

		// Token: 0x060002F2 RID: 754
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_SendItemDropHeartbeat")]
		private static extern void _SendItemDropHeartbeat(IntPtr self);

		// Token: 0x060002F3 RID: 755 RVA: 0x00005338 File Offset: 0x00003538
		internal void SendItemDropHeartbeat()
		{
			ISteamInventory._SendItemDropHeartbeat(this.Self);
		}

		// Token: 0x060002F4 RID: 756
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_TriggerItemDrop")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _TriggerItemDrop(IntPtr self, ref SteamInventoryResult_t pResultHandle, InventoryDefId dropListDefinition);

		// Token: 0x060002F5 RID: 757 RVA: 0x00005345 File Offset: 0x00003545
		internal bool TriggerItemDrop(ref SteamInventoryResult_t pResultHandle, InventoryDefId dropListDefinition)
		{
			return ISteamInventory._TriggerItemDrop(this.Self, ref pResultHandle, dropListDefinition);
		}

		// Token: 0x060002F6 RID: 758
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_TradeItems")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _TradeItems(IntPtr self, ref SteamInventoryResult_t pResultHandle, SteamId steamIDTradePartner, [In] [Out] InventoryItemId[] pArrayGive, [In] [Out] uint[] pArrayGiveQuantity, uint nArrayGiveLength, [In] [Out] InventoryItemId[] pArrayGet, [In] [Out] uint[] pArrayGetQuantity, uint nArrayGetLength);

		// Token: 0x060002F7 RID: 759 RVA: 0x00005354 File Offset: 0x00003554
		internal bool TradeItems(ref SteamInventoryResult_t pResultHandle, SteamId steamIDTradePartner, [In] [Out] InventoryItemId[] pArrayGive, [In] [Out] uint[] pArrayGiveQuantity, uint nArrayGiveLength, [In] [Out] InventoryItemId[] pArrayGet, [In] [Out] uint[] pArrayGetQuantity, uint nArrayGetLength)
		{
			return ISteamInventory._TradeItems(this.Self, ref pResultHandle, steamIDTradePartner, pArrayGive, pArrayGiveQuantity, nArrayGiveLength, pArrayGet, pArrayGetQuantity, nArrayGetLength);
		}

		// Token: 0x060002F8 RID: 760
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_LoadItemDefinitions")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _LoadItemDefinitions(IntPtr self);

		// Token: 0x060002F9 RID: 761 RVA: 0x00005379 File Offset: 0x00003579
		internal bool LoadItemDefinitions()
		{
			return ISteamInventory._LoadItemDefinitions(this.Self);
		}

		// Token: 0x060002FA RID: 762
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_GetItemDefinitionIDs")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetItemDefinitionIDs(IntPtr self, [In] [Out] InventoryDefId[] pItemDefIDs, ref uint punItemDefIDsArraySize);

		// Token: 0x060002FB RID: 763 RVA: 0x00005386 File Offset: 0x00003586
		internal bool GetItemDefinitionIDs([In] [Out] InventoryDefId[] pItemDefIDs, ref uint punItemDefIDsArraySize)
		{
			return ISteamInventory._GetItemDefinitionIDs(this.Self, pItemDefIDs, ref punItemDefIDsArraySize);
		}

		// Token: 0x060002FC RID: 764
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_GetItemDefinitionProperty")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetItemDefinitionProperty(IntPtr self, InventoryDefId iDefinition, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPropertyName, IntPtr pchValueBuffer, ref uint punValueBufferSizeOut);

		// Token: 0x060002FD RID: 765 RVA: 0x00005398 File Offset: 0x00003598
		internal bool GetItemDefinitionProperty(InventoryDefId iDefinition, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPropertyName, out string pchValueBuffer, ref uint punValueBufferSizeOut)
		{
			Helpers.Memory mempchValueBuffer = Helpers.TakeMemory();
			bool result;
			try
			{
				bool flag = ISteamInventory._GetItemDefinitionProperty(this.Self, iDefinition, pchPropertyName, mempchValueBuffer, ref punValueBufferSizeOut);
				pchValueBuffer = Helpers.MemoryToString(mempchValueBuffer);
				result = flag;
			}
			finally
			{
				((IDisposable)mempchValueBuffer).Dispose();
			}
			return result;
		}

		// Token: 0x060002FE RID: 766
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_RequestEligiblePromoItemDefinitionsIDs")]
		private static extern SteamAPICall_t _RequestEligiblePromoItemDefinitionsIDs(IntPtr self, SteamId steamID);

		// Token: 0x060002FF RID: 767 RVA: 0x000053F4 File Offset: 0x000035F4
		internal CallResult<SteamInventoryEligiblePromoItemDefIDs_t> RequestEligiblePromoItemDefinitionsIDs(SteamId steamID)
		{
			return new CallResult<SteamInventoryEligiblePromoItemDefIDs_t>(ISteamInventory._RequestEligiblePromoItemDefinitionsIDs(this.Self, steamID), base.IsServer);
		}

		// Token: 0x06000300 RID: 768
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_GetEligiblePromoItemDefinitionIDs")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetEligiblePromoItemDefinitionIDs(IntPtr self, SteamId steamID, [In] [Out] InventoryDefId[] pItemDefIDs, ref uint punItemDefIDsArraySize);

		// Token: 0x06000301 RID: 769 RVA: 0x0000540D File Offset: 0x0000360D
		internal bool GetEligiblePromoItemDefinitionIDs(SteamId steamID, [In] [Out] InventoryDefId[] pItemDefIDs, ref uint punItemDefIDsArraySize)
		{
			return ISteamInventory._GetEligiblePromoItemDefinitionIDs(this.Self, steamID, pItemDefIDs, ref punItemDefIDsArraySize);
		}

		// Token: 0x06000302 RID: 770
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_StartPurchase")]
		private static extern SteamAPICall_t _StartPurchase(IntPtr self, [In] [Out] InventoryDefId[] pArrayItemDefs, [In] [Out] uint[] punArrayQuantity, uint unArrayLength);

		// Token: 0x06000303 RID: 771 RVA: 0x0000541D File Offset: 0x0000361D
		internal CallResult<SteamInventoryStartPurchaseResult_t> StartPurchase([In] [Out] InventoryDefId[] pArrayItemDefs, [In] [Out] uint[] punArrayQuantity, uint unArrayLength)
		{
			return new CallResult<SteamInventoryStartPurchaseResult_t>(ISteamInventory._StartPurchase(this.Self, pArrayItemDefs, punArrayQuantity, unArrayLength), base.IsServer);
		}

		// Token: 0x06000304 RID: 772
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_RequestPrices")]
		private static extern SteamAPICall_t _RequestPrices(IntPtr self);

		// Token: 0x06000305 RID: 773 RVA: 0x00005438 File Offset: 0x00003638
		internal CallResult<SteamInventoryRequestPricesResult_t> RequestPrices()
		{
			return new CallResult<SteamInventoryRequestPricesResult_t>(ISteamInventory._RequestPrices(this.Self), base.IsServer);
		}

		// Token: 0x06000306 RID: 774
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_GetNumItemsWithPrices")]
		private static extern uint _GetNumItemsWithPrices(IntPtr self);

		// Token: 0x06000307 RID: 775 RVA: 0x00005450 File Offset: 0x00003650
		internal uint GetNumItemsWithPrices()
		{
			return ISteamInventory._GetNumItemsWithPrices(this.Self);
		}

		// Token: 0x06000308 RID: 776
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_GetItemsWithPrices")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetItemsWithPrices(IntPtr self, [In] [Out] InventoryDefId[] pArrayItemDefs, [In] [Out] ulong[] pCurrentPrices, [In] [Out] ulong[] pBasePrices, uint unArrayLength);

		// Token: 0x06000309 RID: 777 RVA: 0x0000545D File Offset: 0x0000365D
		internal bool GetItemsWithPrices([In] [Out] InventoryDefId[] pArrayItemDefs, [In] [Out] ulong[] pCurrentPrices, [In] [Out] ulong[] pBasePrices, uint unArrayLength)
		{
			return ISteamInventory._GetItemsWithPrices(this.Self, pArrayItemDefs, pCurrentPrices, pBasePrices, unArrayLength);
		}

		// Token: 0x0600030A RID: 778
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_GetItemPrice")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetItemPrice(IntPtr self, InventoryDefId iDefinition, ref ulong pCurrentPrice, ref ulong pBasePrice);

		// Token: 0x0600030B RID: 779 RVA: 0x0000546F File Offset: 0x0000366F
		internal bool GetItemPrice(InventoryDefId iDefinition, ref ulong pCurrentPrice, ref ulong pBasePrice)
		{
			return ISteamInventory._GetItemPrice(this.Self, iDefinition, ref pCurrentPrice, ref pBasePrice);
		}

		// Token: 0x0600030C RID: 780
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_StartUpdateProperties")]
		private static extern SteamInventoryUpdateHandle_t _StartUpdateProperties(IntPtr self);

		// Token: 0x0600030D RID: 781 RVA: 0x0000547F File Offset: 0x0000367F
		internal SteamInventoryUpdateHandle_t StartUpdateProperties()
		{
			return ISteamInventory._StartUpdateProperties(this.Self);
		}

		// Token: 0x0600030E RID: 782
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_RemoveProperty")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _RemoveProperty(IntPtr self, SteamInventoryUpdateHandle_t handle, InventoryItemId nItemID, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPropertyName);

		// Token: 0x0600030F RID: 783 RVA: 0x0000548C File Offset: 0x0000368C
		internal bool RemoveProperty(SteamInventoryUpdateHandle_t handle, InventoryItemId nItemID, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPropertyName)
		{
			return ISteamInventory._RemoveProperty(this.Self, handle, nItemID, pchPropertyName);
		}

		// Token: 0x06000310 RID: 784
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_SetPropertyString")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetProperty(IntPtr self, SteamInventoryUpdateHandle_t handle, InventoryItemId nItemID, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPropertyName, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPropertyValue);

		// Token: 0x06000311 RID: 785 RVA: 0x0000549C File Offset: 0x0000369C
		internal bool SetProperty(SteamInventoryUpdateHandle_t handle, InventoryItemId nItemID, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPropertyName, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPropertyValue)
		{
			return ISteamInventory._SetProperty(this.Self, handle, nItemID, pchPropertyName, pchPropertyValue);
		}

		// Token: 0x06000312 RID: 786
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_SetPropertyBool")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetProperty(IntPtr self, SteamInventoryUpdateHandle_t handle, InventoryItemId nItemID, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPropertyName, [MarshalAs(UnmanagedType.U1)] bool bValue);

		// Token: 0x06000313 RID: 787 RVA: 0x000054AE File Offset: 0x000036AE
		internal bool SetProperty(SteamInventoryUpdateHandle_t handle, InventoryItemId nItemID, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPropertyName, [MarshalAs(UnmanagedType.U1)] bool bValue)
		{
			return ISteamInventory._SetProperty(this.Self, handle, nItemID, pchPropertyName, bValue);
		}

		// Token: 0x06000314 RID: 788
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_SetPropertyInt64")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetProperty(IntPtr self, SteamInventoryUpdateHandle_t handle, InventoryItemId nItemID, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPropertyName, long nValue);

		// Token: 0x06000315 RID: 789 RVA: 0x000054C0 File Offset: 0x000036C0
		internal bool SetProperty(SteamInventoryUpdateHandle_t handle, InventoryItemId nItemID, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPropertyName, long nValue)
		{
			return ISteamInventory._SetProperty(this.Self, handle, nItemID, pchPropertyName, nValue);
		}

		// Token: 0x06000316 RID: 790
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_SetPropertyFloat")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetProperty(IntPtr self, SteamInventoryUpdateHandle_t handle, InventoryItemId nItemID, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPropertyName, float flValue);

		// Token: 0x06000317 RID: 791 RVA: 0x000054D2 File Offset: 0x000036D2
		internal bool SetProperty(SteamInventoryUpdateHandle_t handle, InventoryItemId nItemID, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPropertyName, float flValue)
		{
			return ISteamInventory._SetProperty(this.Self, handle, nItemID, pchPropertyName, flValue);
		}

		// Token: 0x06000318 RID: 792
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_SubmitUpdateProperties")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SubmitUpdateProperties(IntPtr self, SteamInventoryUpdateHandle_t handle, ref SteamInventoryResult_t pResultHandle);

		// Token: 0x06000319 RID: 793 RVA: 0x000054E4 File Offset: 0x000036E4
		internal bool SubmitUpdateProperties(SteamInventoryUpdateHandle_t handle, ref SteamInventoryResult_t pResultHandle)
		{
			return ISteamInventory._SubmitUpdateProperties(this.Self, handle, ref pResultHandle);
		}

		// Token: 0x0600031A RID: 794
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamInventory_InspectItem")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _InspectItem(IntPtr self, ref SteamInventoryResult_t pResultHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchItemToken);

		// Token: 0x0600031B RID: 795 RVA: 0x000054F3 File Offset: 0x000036F3
		internal bool InspectItem(ref SteamInventoryResult_t pResultHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchItemToken)
		{
			return ISteamInventory._InspectItem(this.Self, ref pResultHandle, pchItemToken);
		}
	}
}
