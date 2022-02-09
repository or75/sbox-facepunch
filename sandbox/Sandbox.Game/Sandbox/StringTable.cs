using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020000D1 RID: 209
	internal class StringTable
	{
		/// <summary>
		/// The name of this string table
		/// </summary>
		// Token: 0x17000276 RID: 630
		// (get) Token: 0x0600127D RID: 4733 RVA: 0x0004DE70 File Offset: 0x0004C070
		// (set) Token: 0x0600127E RID: 4734 RVA: 0x0004DE78 File Offset: 0x0004C078
		public string Name { get; set; }

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x0600127F RID: 4735 RVA: 0x0004DE81 File Offset: 0x0004C081
		// (set) Token: 0x06001280 RID: 4736 RVA: 0x0004DE89 File Offset: 0x0004C089
		private INetworkStringTable table { get; set; }

		/// <summary>
		/// Returns the number of strings in this table
		/// </summary>
		// Token: 0x06001281 RID: 4737 RVA: 0x0004DE94 File Offset: 0x0004C094
		public int Count()
		{
			if (!this.table.IsNull)
			{
				return this.table.GetNumStrings();
			}
			return 0;
		}

		// Token: 0x06001282 RID: 4738 RVA: 0x0004DEC1 File Offset: 0x0004C0C1
		public StringTable(string name)
		{
			this.Name = name;
		}

		// Token: 0x06001283 RID: 4739 RVA: 0x0004DED0 File Offset: 0x0004C0D0
		internal void Init()
		{
			if (Host.IsClient)
			{
				this.callback = new StringTableChangedCallback(this.OnChange);
				IntPtr fp = Marshal.GetFunctionPointerForDelegate<StringTableChangedCallback>(this.callback);
				this.table.SetStringChangedCallback(fp, true);
			}
		}

		// Token: 0x06001284 RID: 4740 RVA: 0x0004DF14 File Offset: 0x0004C114
		internal void RefreshPointers()
		{
			ref INetworkStringTable table = this.table;
			this.table = NetworkStringTableContainer.FindTable(this.Name);
			if (Host.IsServer && this.table.IsNull)
			{
				this.table = NetworkStringTableContainer.CreateStringTable(this.Name, 0, 0, NetworkStringtableFlags.CompressUserdata);
				if (this.table.IsNull)
				{
					throw new Exception("Tried to create string table (" + this.Name + ") but it's null");
				}
			}
			if (table.self != this.table.self)
			{
				if (this.table.IsNull)
				{
					this.Shutdown();
					return;
				}
				this.Init();
			}
		}

		// Token: 0x06001285 RID: 4741 RVA: 0x0004DFC4 File Offset: 0x0004C1C4
		internal int Set(string str)
		{
			return this.table.AddString(Host.IsServer, str, 0, IntPtr.Zero);
		}

		// Token: 0x06001286 RID: 4742 RVA: 0x0004DFEC File Offset: 0x0004C1EC
		internal unsafe int Set(string str, string value)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(value);
			byte[] array;
			byte* ptr;
			if ((array = bytes) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			return this.table.AddString(true, str, bytes.Length, (IntPtr)((void*)ptr));
		}

		// Token: 0x06001287 RID: 4743 RVA: 0x0004E038 File Offset: 0x0004C238
		private void OnChange(IntPtr ptr, int entryId, IntPtr str, IntPtr data)
		{
			try
			{
				Action<int> onStringAddedOrChanged = this.OnStringAddedOrChanged;
				if (onStringAddedOrChanged != null)
				{
					onStringAddedOrChanged(entryId);
				}
			}
			catch (Exception e)
			{
				StringTable.log.Error(e);
			}
		}

		// Token: 0x06001288 RID: 4744 RVA: 0x0004E078 File Offset: 0x0004C278
		public void Shutdown()
		{
			this.OnStringAddedOrChanged = null;
			this.table = IntPtr.Zero;
			this.callback = null;
		}

		// Token: 0x06001289 RID: 4745 RVA: 0x0004E098 File Offset: 0x0004C298
		internal unsafe void SetWithData<[IsUnmanaged] T>(string name, T type) where T : struct, ValueType
		{
			int size = Unsafe.SizeOf<T>();
			void* ptr = Unsafe.AsPointer<T>(ref type);
			this.table.AddString(Host.IsServer, name, size, (IntPtr)ptr);
		}

		// Token: 0x0600128A RID: 4746 RVA: 0x0004E0D0 File Offset: 0x0004C2D0
		internal unsafe void SetWithData(string name, void* ptr, int length)
		{
			if (this.table.IsNull)
			{
				throw new Exception("Tried to SetWithData on table (" + this.Name + ") but it's null");
			}
			this.table.AddString(Host.IsServer, name, length, (IntPtr)ptr);
		}

		// Token: 0x0600128B RID: 4747 RVA: 0x0004E124 File Offset: 0x0004C324
		internal unsafe void SetWithData(int slot, void* ptr, int length)
		{
			if (this.table.IsNull)
			{
				throw new Exception("Tried to SetWithData on table (" + this.Name + ") but it's null");
			}
			this.table.SetStringUserData(slot, length, (IntPtr)ptr, true);
		}

		// Token: 0x0600128C RID: 4748 RVA: 0x0004E174 File Offset: 0x0004C374
		internal unsafe void SetWithData(int slot, string data)
		{
			if (this.table.IsNull)
			{
				throw new Exception("Tried to SetWithData on table (" + this.Name + ") but it's null");
			}
			byte[] bytes = Encoding.UTF8.GetBytes(data);
			byte[] array;
			byte* ptr;
			if ((array = bytes) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			this.table.SetStringUserData(slot, bytes.Length, (IntPtr)((void*)ptr), false);
			array = null;
		}

		// Token: 0x0600128D RID: 4749 RVA: 0x0004E1EC File Offset: 0x0004C3EC
		internal string GetString(int entryId)
		{
			return this.table.GetString(entryId, true);
		}

		// Token: 0x0600128E RID: 4750 RVA: 0x0004E20C File Offset: 0x0004C40C
		internal IntPtr GetData(int entryId, out int datalen)
		{
			return this.table.GetStringUserData(entryId, out datalen);
		}

		// Token: 0x0600128F RID: 4751 RVA: 0x0004E22C File Offset: 0x0004C42C
		internal unsafe string GetData(int entryId)
		{
			int len;
			IntPtr data = this.GetData(entryId, out len);
			if (data == IntPtr.Zero)
			{
				return string.Empty;
			}
			return Encoding.UTF8.GetString((byte*)(void*)data, len);
		}

		// Token: 0x06001290 RID: 4752 RVA: 0x0004E268 File Offset: 0x0004C468
		internal unsafe T GetData<[IsUnmanaged] T>(int entryId) where T : struct, ValueType
		{
			int datalen;
			IntPtr data = this.GetData(entryId, out datalen);
			if (datalen != sizeof(T))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 3);
				defaultInterpolatedStringHandler.AppendLiteral("GetData: Size ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(datalen);
				defaultInterpolatedStringHandler.AppendLiteral(" doesn't match for type ");
				defaultInterpolatedStringHandler.AppendFormatted<Type>(typeof(T));
				defaultInterpolatedStringHandler.AppendLiteral(" (");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sizeof(T));
				defaultInterpolatedStringHandler.AppendLiteral(")");
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return Unsafe.Read<T>((void*)data);
		}

		// Token: 0x06001291 RID: 4753 RVA: 0x0004E300 File Offset: 0x0004C500
		public bool Contains(string name)
		{
			return this.table.FindStringIndex(name) != 65535;
		}

		// Token: 0x040003E4 RID: 996
		private static readonly Logger log = Logging.GetLogger(null);

		// Token: 0x040003E5 RID: 997
		public const int InvalidIndex = 65535;

		// Token: 0x040003E8 RID: 1000
		internal StringTableChangedCallback callback;

		/// <summary>
		/// Called clientside when a string is added or changed
		/// </summary>
		// Token: 0x040003E9 RID: 1001
		public Action<int> OnStringAddedOrChanged;
	}
}
