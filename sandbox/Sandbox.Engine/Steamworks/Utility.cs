using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks
{
	// Token: 0x020000C0 RID: 192
	internal static class Utility
	{
		// Token: 0x06000731 RID: 1841 RVA: 0x0000B8C0 File Offset: 0x00009AC0
		internal static T ToType<T>(this IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				return default(T);
			}
			return (T)((object)Marshal.PtrToStructure(ptr, typeof(T)));
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x0000B8F9 File Offset: 0x00009AF9
		internal static object ToType(this IntPtr ptr, Type t)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			return Marshal.PtrToStructure(ptr, t);
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x0000B911 File Offset: 0x00009B11
		internal static uint Swap(uint x)
		{
			return ((x & 255U) << 24) + ((x & 65280U) << 8) + ((x & 16711680U) >> 8) + ((x & 4278190080U) >> 24);
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x0000B93C File Offset: 0x00009B3C
		internal static uint IpToInt32(this IPAddress ipAddress)
		{
			return Utility.Swap((uint)ipAddress.Address);
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x0000B94A File Offset: 0x00009B4A
		internal static IPAddress Int32ToIp(uint ipAddress)
		{
			return new IPAddress((long)((ulong)Utility.Swap(ipAddress)));
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x0000B958 File Offset: 0x00009B58
		internal static string FormatPrice(string currency, double price)
		{
			string decimaled = price.ToString("0.00");
			uint num = <PrivateImplementationDetails>.ComputeStringHash(currency);
			if (num <= 2221184599U)
			{
				if (num <= 1097334389U)
				{
					if (num <= 385263313U)
					{
						if (num <= 203100298U)
						{
							if (num != 44711862U)
							{
								if (num == 203100298U)
								{
									if (currency == "MXN")
									{
										return "Mex$" + decimaled;
									}
								}
							}
							else if (currency == "IDR")
							{
								return "Rp" + decimaled;
							}
						}
						else if (num != 303913107U)
						{
							if (num != 331211313U)
							{
								if (num == 385263313U)
								{
									if (currency == "SAR")
									{
										return "SR " + decimaled;
									}
								}
							}
							else if (currency == "ILS")
							{
								return "₪" + decimaled;
							}
						}
						else if (currency == "MYR")
						{
							return "RM " + decimaled;
						}
					}
					else if (num <= 871170383U)
					{
						if (num != 533790082U)
						{
							if (num == 871170383U)
							{
								if (currency == "QAR")
								{
									return "QR " + decimaled;
								}
							}
						}
						else if (currency == "ZAR")
						{
							return "R " + decimaled;
						}
					}
					else if (num != 961436151U)
					{
						if (num != 962568984U)
						{
							if (num == 1097334389U)
							{
								if (currency == "COP")
								{
									return "COL$ " + decimaled;
								}
							}
						}
						else if (currency == "CHF")
						{
							return "Fr. " + decimaled;
						}
					}
					else if (currency == "CAD")
					{
						return "C$" + decimaled;
					}
				}
				else if (num <= 1713324697U)
				{
					if (num <= 1174502954U)
					{
						if (num != 1163896872U)
						{
							if (num == 1174502954U)
							{
								if (currency == "SEK")
								{
									return decimaled + "kr";
								}
							}
						}
						else if (currency == "TWD")
						{
							return "NT$ " + decimaled;
						}
					}
					else if (num != 1198147198U)
					{
						if (num != 1568567338U)
						{
							if (num == 1713324697U)
							{
								if (currency == "CRC")
								{
									return "₡" + decimaled;
								}
							}
						}
						else if (currency == "JPY")
						{
							return "¥" + decimaled;
						}
					}
					else if (currency == "CLP")
					{
						return "$" + decimaled + " CLP";
					}
				}
				else if (num <= 1828432737U)
				{
					if (num != 1774092687U)
					{
						if (num == 1828432737U)
						{
							if (currency == "SGD")
							{
								return "S$" + decimaled;
							}
						}
					}
					else if (currency == "NZD")
					{
						return "$" + decimaled + " NZD";
					}
				}
				else if (num != 2175213072U)
				{
					if (num != 2208215117U)
					{
						if (num == 2221184599U)
						{
							if (currency == "CNY")
							{
								return decimaled + "元";
							}
						}
					}
					else if (currency == "AUD")
					{
						return "A$" + decimaled;
					}
				}
				else if (currency == "HKD")
				{
					return "HK$" + decimaled;
				}
			}
			else if (num <= 3277126311U)
			{
				if (num <= 2742539069U)
				{
					if (num <= 2607537575U)
					{
						if (num != 2390414266U)
						{
							if (num == 2607537575U)
							{
								if (currency == "USD")
								{
									return "$" + decimaled;
								}
							}
						}
						else if (currency == "UYU")
						{
							return "$U " + decimaled;
						}
					}
					else if (num != 2683950351U)
					{
						if (num != 2712123334U)
						{
							if (num == 2742539069U)
							{
								if (currency == "AED")
								{
									return decimaled + "د.إ";
								}
							}
						}
						else if (currency == "RUB")
						{
							return decimaled + "₽";
						}
					}
					else if (currency == "PHP")
					{
						return "₱" + decimaled;
					}
				}
				else if (num <= 2934852707U)
				{
					if (num != 2896936139U)
					{
						if (num == 2934852707U)
						{
							if (currency == "NOK")
							{
								return decimaled + " kr";
							}
						}
					}
					else if (currency == "ARS")
					{
						return "$" + decimaled + " ARS";
					}
				}
				else if (num != 3001173901U)
				{
					if (num != 3012466097U)
					{
						if (num == 3277126311U)
						{
							if (currency == "EUR")
							{
								return "€" + decimaled;
							}
						}
					}
					else if (currency == "UAH")
					{
						return "₴" + decimaled;
					}
				}
				else if (currency == "KRW")
				{
					return "₩" + decimaled;
				}
			}
			else if (num <= 3998770030U)
			{
				if (num <= 3639174388U)
				{
					if (num != 3589126041U)
					{
						if (num == 3639174388U)
						{
							if (currency == "GBP")
							{
								return "£" + decimaled;
							}
						}
					}
					else if (currency == "KWD")
					{
						return "KD " + decimaled;
					}
				}
				else if (num != 3670251684U)
				{
					if (num != 3754783660U)
					{
						if (num == 3998770030U)
						{
							if (currency == "TRY")
							{
								return "₺" + decimaled;
							}
						}
					}
					else if (currency == "KZT")
					{
						return decimaled + "₸";
					}
				}
				else if (currency == "INR")
				{
					return "₹" + decimaled;
				}
			}
			else if (num <= 4093711632U)
			{
				if (num != 4043176179U)
				{
					if (num == 4093711632U)
					{
						if (currency == "PEN")
						{
							return "S/. " + decimaled;
						}
					}
				}
				else if (currency == "VND")
				{
					return "₫" + decimaled;
				}
			}
			else if (num != 4115227625U)
			{
				if (num != 4126134037U)
				{
					if (num == 4288438971U)
					{
						if (currency == "BRL")
						{
							return "R$" + decimaled;
						}
					}
				}
				else if (currency == "PLN")
				{
					return decimaled + "zł";
				}
			}
			else if (currency == "THB")
			{
				return "฿" + decimaled;
			}
			return decimaled + " " + currency;
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x0000C144 File Offset: 0x0000A344
		internal static string ReadNullTerminatedUTF8String(this BinaryReader br)
		{
			byte[] obj = Utility.readBuffer;
			string @string;
			lock (obj)
			{
				int i = 0;
				byte chr;
				while ((chr = br.ReadByte()) != 0 && i < Utility.readBuffer.Length)
				{
					Utility.readBuffer[i] = chr;
					i++;
				}
				@string = Encoding.UTF8.GetString(Utility.readBuffer, 0, i);
			}
			return @string;
		}

		// Token: 0x0400096D RID: 2413
		private static readonly byte[] readBuffer = new byte[8192];
	}
}
