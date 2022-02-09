using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000031 RID: 49
	internal struct CRenderAttributes
	{
		// Token: 0x06000709 RID: 1801 RVA: 0x00030FC1 File Offset: 0x0002F1C1
		public static implicit operator IntPtr(CRenderAttributes value)
		{
			return value.self;
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x00030FCC File Offset: 0x0002F1CC
		public static implicit operator CRenderAttributes(IntPtr value)
		{
			return new CRenderAttributes
			{
				self = value
			};
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00030FEA File Offset: 0x0002F1EA
		public static bool operator ==(CRenderAttributes c1, CRenderAttributes c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x00030FFD File Offset: 0x0002F1FD
		public static bool operator !=(CRenderAttributes c1, CRenderAttributes c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x00031010 File Offset: 0x0002F210
		public override bool Equals(object obj)
		{
			if (obj is CRenderAttributes)
			{
				CRenderAttributes c = (CRenderAttributes)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x0003103A File Offset: 0x0002F23A
		internal CRenderAttributes(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x00031044 File Offset: 0x0002F244
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CRenderAttributes ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000710 RID: 1808 RVA: 0x00031080 File Offset: 0x0002F280
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000711 RID: 1809 RVA: 0x00031092 File Offset: 0x0002F292
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x0003109D File Offset: 0x0002F29D
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x000310B0 File Offset: 0x0002F2B0
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CRenderAttributes was null when calling " + n);
			}
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x000310CB File Offset: 0x0002F2CB
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x000310D8 File Offset: 0x0002F2D8
		internal readonly void SetFloatValue(string nTokenID, float flValue)
		{
			this.NullCheck("SetFloatValue");
			method crende_SetFloatValue = CRenderAttributes.__N.CRende_SetFloatValue;
			calli(System.Void(System.IntPtr,System.UInt32,System.Single), this.self, StringToken.FindOrCreate(nTokenID), flValue, crende_SetFloatValue);
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x0003110C File Offset: 0x0002F30C
		internal readonly float GetFloatValue(string nTokenID, float flDefaultValue)
		{
			this.NullCheck("GetFloatValue");
			method crende_GetFloatValue = CRenderAttributes.__N.CRende_GetFloatValue;
			return calli(System.Single(System.IntPtr,System.UInt32,System.Single), this.self, StringToken.FindOrCreate(nTokenID), flDefaultValue, crende_GetFloatValue);
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x00031140 File Offset: 0x0002F340
		internal readonly void DeleteFloatValue(string nTokenID)
		{
			this.NullCheck("DeleteFloatValue");
			method crende_DeleteFloatValue = CRenderAttributes.__N.CRende_DeleteFloatValue;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nTokenID), crende_DeleteFloatValue);
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x00031170 File Offset: 0x0002F370
		internal unsafe readonly void SetVector2DValue(string nTokenID, Vector2 vValue)
		{
			this.NullCheck("SetVector2DValue");
			method crende_SetVector2DValue = CRenderAttributes.__N.CRende_SetVector2DValue;
			calli(System.Void(System.IntPtr,System.UInt32,Vector2*), this.self, StringToken.FindOrCreate(nTokenID), &vValue, crende_SetVector2DValue);
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x000311A4 File Offset: 0x0002F3A4
		internal unsafe readonly Vector2 GetVector2DValue(string nTokenID, Vector2 vDefaultValue)
		{
			this.NullCheck("GetVector2DValue");
			method crende_GetVector2DValue = CRenderAttributes.__N.CRende_GetVector2DValue;
			return calli(Vector2(System.IntPtr,System.UInt32,Vector2*), this.self, StringToken.FindOrCreate(nTokenID), &vDefaultValue, crende_GetVector2DValue);
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x000311D8 File Offset: 0x0002F3D8
		internal readonly void DeleteVector2DValue(string nTokenID)
		{
			this.NullCheck("DeleteVector2DValue");
			method crende_DeleteVector2DValue = CRenderAttributes.__N.CRende_DeleteVector2DValue;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nTokenID), crende_DeleteVector2DValue);
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x00031208 File Offset: 0x0002F408
		internal unsafe readonly void SetVectorValue(string nTokenID, Vector3 vValue)
		{
			this.NullCheck("SetVectorValue");
			method crende_SetVectorValue = CRenderAttributes.__N.CRende_SetVectorValue;
			calli(System.Void(System.IntPtr,System.UInt32,Vector3*), this.self, StringToken.FindOrCreate(nTokenID), &vValue, crende_SetVectorValue);
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x0003123C File Offset: 0x0002F43C
		internal unsafe readonly Vector3 GetVectorValue(string nTokenID, Vector3 vDefaultValue)
		{
			this.NullCheck("GetVectorValue");
			method crende_GetVectorValue = CRenderAttributes.__N.CRende_GetVectorValue;
			return calli(Vector3(System.IntPtr,System.UInt32,Vector3*), this.self, StringToken.FindOrCreate(nTokenID), &vDefaultValue, crende_GetVectorValue);
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x00031270 File Offset: 0x0002F470
		internal readonly void DeleteVectorValue(string nTokenID)
		{
			this.NullCheck("DeleteVectorValue");
			method crende_DeleteVectorValue = CRenderAttributes.__N.CRende_DeleteVectorValue;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nTokenID), crende_DeleteVectorValue);
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x000312A0 File Offset: 0x0002F4A0
		internal unsafe readonly void SetVector4DValue(string nTokenID, Vector4 vValue)
		{
			this.NullCheck("SetVector4DValue");
			method crende_SetVector4DValue = CRenderAttributes.__N.CRende_SetVector4DValue;
			calli(System.Void(System.IntPtr,System.UInt32,Vector4*), this.self, StringToken.FindOrCreate(nTokenID), &vValue, crende_SetVector4DValue);
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x000312D4 File Offset: 0x0002F4D4
		internal unsafe readonly Vector4 GetVector4DValue(string nTokenID, Vector4 vDefaultValue)
		{
			this.NullCheck("GetVector4DValue");
			method crende_GetVector4DValue = CRenderAttributes.__N.CRende_GetVector4DValue;
			return calli(Vector4(System.IntPtr,System.UInt32,Vector4*), this.self, StringToken.FindOrCreate(nTokenID), &vDefaultValue, crende_GetVector4DValue);
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x00031308 File Offset: 0x0002F508
		internal readonly void DeleteVector4DValue(string nTokenID)
		{
			this.NullCheck("DeleteVector4DValue");
			method crende_DeleteVector4DValue = CRenderAttributes.__N.CRende_DeleteVector4DValue;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nTokenID), crende_DeleteVector4DValue);
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x00031338 File Offset: 0x0002F538
		internal unsafe readonly void SetVMatrixValue(string nTokenID, Matrix value)
		{
			this.NullCheck("SetVMatrixValue");
			method crende_SetVMatrixValue = CRenderAttributes.__N.CRende_SetVMatrixValue;
			calli(System.Void(System.IntPtr,System.UInt32,Matrix*), this.self, StringToken.FindOrCreate(nTokenID), &value, crende_SetVMatrixValue);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x0003136C File Offset: 0x0002F56C
		internal unsafe readonly Matrix GetVMatrixValue(string nTokenID, Matrix vDefaultValue)
		{
			this.NullCheck("GetVMatrixValue");
			method crende_GetVMatrixValue = CRenderAttributes.__N.CRende_GetVMatrixValue;
			return calli(Matrix(System.IntPtr,System.UInt32,Matrix*), this.self, StringToken.FindOrCreate(nTokenID), &vDefaultValue, crende_GetVMatrixValue);
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x000313A0 File Offset: 0x0002F5A0
		internal readonly void DeleteVMatrixValue(string nTokenID)
		{
			this.NullCheck("DeleteVMatrixValue");
			method crende_DeleteVMatrixValue = CRenderAttributes.__N.CRende_DeleteVMatrixValue;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nTokenID), crende_DeleteVMatrixValue);
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x000313D0 File Offset: 0x0002F5D0
		internal readonly void SetStringValue(string nTokenID, string str)
		{
			this.NullCheck("SetStringValue");
			method crende_SetStringValue = CRenderAttributes.__N.CRende_SetStringValue;
			calli(System.Void(System.IntPtr,System.UInt32,System.IntPtr), this.self, StringToken.FindOrCreate(nTokenID), Interop.GetPointer(str), crende_SetStringValue);
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x00031408 File Offset: 0x0002F608
		internal readonly void DeleteStringValue(string nTokenID)
		{
			this.NullCheck("DeleteStringValue");
			method crende_DeleteStringValue = CRenderAttributes.__N.CRende_DeleteStringValue;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nTokenID), crende_DeleteStringValue);
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x00031438 File Offset: 0x0002F638
		internal readonly void SetIntValue(string nTokenID, int nValue)
		{
			this.NullCheck("SetIntValue");
			method crende_SetIntValue = CRenderAttributes.__N.CRende_SetIntValue;
			calli(System.Void(System.IntPtr,System.UInt32,System.Int32), this.self, StringToken.FindOrCreate(nTokenID), nValue, crende_SetIntValue);
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x0003146C File Offset: 0x0002F66C
		internal readonly int GetIntValue(string nTokenID, int nDefaultValue)
		{
			this.NullCheck("GetIntValue");
			method crende_GetIntValue = CRenderAttributes.__N.CRende_GetIntValue;
			return calli(System.Int32(System.IntPtr,System.UInt32,System.Int32), this.self, StringToken.FindOrCreate(nTokenID), nDefaultValue, crende_GetIntValue);
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x000314A0 File Offset: 0x0002F6A0
		internal readonly void DeleteIntValue(string nTokenID)
		{
			this.NullCheck("DeleteIntValue");
			method crende_DeleteIntValue = CRenderAttributes.__N.CRende_DeleteIntValue;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nTokenID), crende_DeleteIntValue);
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x000314D0 File Offset: 0x0002F6D0
		internal readonly void SetConstantBufferValue(string nTokenID, IntPtr cb, uint nView)
		{
			this.NullCheck("SetConstantBufferValue");
			method crende_SetConstantBufferValue = CRenderAttributes.__N.CRende_SetConstantBufferValue;
			calli(System.Void(System.IntPtr,System.UInt32,System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nTokenID), cb, nView, crende_SetConstantBufferValue);
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x00031504 File Offset: 0x0002F704
		internal readonly void DeleteConstantBufferValue(string nToken)
		{
			this.NullCheck("DeleteConstantBufferValue");
			method crende_DeleteConstantBufferValue = CRenderAttributes.__N.CRende_DeleteConstantBufferValue;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nToken), crende_DeleteConstantBufferValue);
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x00031534 File Offset: 0x0002F734
		internal readonly void SetComboValue(string nTokenID, byte nValue)
		{
			this.NullCheck("SetComboValue");
			method crende_SetComboValue = CRenderAttributes.__N.CRende_SetComboValue;
			calli(System.Void(System.IntPtr,System.UInt32,System.Byte), this.self, StringToken.FindOrCreate(nTokenID), nValue, crende_SetComboValue);
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x00031568 File Offset: 0x0002F768
		internal readonly byte GetComboValue(string nTokenID, byte nValue)
		{
			this.NullCheck("GetComboValue");
			method crende_GetComboValue = CRenderAttributes.__N.CRende_GetComboValue;
			return calli(System.Byte(System.IntPtr,System.UInt32,System.Byte), this.self, StringToken.FindOrCreate(nTokenID), nValue, crende_GetComboValue);
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x0003159C File Offset: 0x0002F79C
		internal readonly void DeleteComboValue(string nTokenID)
		{
			this.NullCheck("DeleteComboValue");
			method crende_DeleteComboValue = CRenderAttributes.__N.CRende_DeleteComboValue;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nTokenID), crende_DeleteComboValue);
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x000315CC File Offset: 0x0002F7CC
		internal readonly void SetBoolValue(string nTokenID, bool bValue)
		{
			this.NullCheck("SetBoolValue");
			method crende_SetBoolValue = CRenderAttributes.__N.CRende_SetBoolValue;
			calli(System.Void(System.IntPtr,System.UInt32,System.Int32), this.self, StringToken.FindOrCreate(nTokenID), bValue ? 1 : 0, crende_SetBoolValue);
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x00031604 File Offset: 0x0002F804
		internal readonly bool GetBoolValue(string nTokenID, bool bValue)
		{
			this.NullCheck("GetBoolValue");
			method crende_GetBoolValue = CRenderAttributes.__N.CRende_GetBoolValue;
			return calli(System.Int32(System.IntPtr,System.UInt32,System.Int32), this.self, StringToken.FindOrCreate(nTokenID), bValue ? 1 : 0, crende_GetBoolValue) > 0;
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x00031640 File Offset: 0x0002F840
		internal readonly void DeleteBoolValue(string nTokenID)
		{
			this.NullCheck("DeleteBoolValue");
			method crende_DeleteBoolValue = CRenderAttributes.__N.CRende_DeleteBoolValue;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nTokenID), crende_DeleteBoolValue);
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x00031670 File Offset: 0x0002F870
		internal readonly void SetTextureValue(string nTokenID, ITexture txtr, int nSingleMipLevelToBind)
		{
			this.NullCheck("SetTextureValue");
			method crende_SetTextureValue = CRenderAttributes.__N.CRende_SetTextureValue;
			calli(System.Void(System.IntPtr,System.UInt32,System.IntPtr,System.Int32), this.self, StringToken.FindOrCreate(nTokenID), txtr, nSingleMipLevelToBind, crende_SetTextureValue);
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x000316A8 File Offset: 0x0002F8A8
		internal readonly ITexture GetTextureValue(string nTokenID, ITexture defaultTxtr)
		{
			this.NullCheck("GetTextureValue");
			method crende_GetTextureValue = CRenderAttributes.__N.CRende_GetTextureValue;
			return calli(System.IntPtr(System.IntPtr,System.UInt32,System.IntPtr), this.self, StringToken.FindOrCreate(nTokenID), defaultTxtr, crende_GetTextureValue);
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x000316E4 File Offset: 0x0002F8E4
		internal readonly void DeleteTextureValue(string nTokenID)
		{
			this.NullCheck("DeleteTextureValue");
			method crende_DeleteTextureValue = CRenderAttributes.__N.CRende_DeleteTextureValue;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nTokenID), crende_DeleteTextureValue);
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x00031714 File Offset: 0x0002F914
		internal readonly void MergeToPtr(CRenderAttributes attrList)
		{
			this.NullCheck("MergeToPtr");
			method crende_MergeToPtr = CRenderAttributes.__N.CRende_MergeToPtr;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, attrList, crende_MergeToPtr);
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x00031744 File Offset: 0x0002F944
		internal readonly bool IsEmpty()
		{
			this.NullCheck("IsEmpty");
			method crende_IsEmpty = CRenderAttributes.__N.CRende_IsEmpty;
			return calli(System.Int32(System.IntPtr), this.self, crende_IsEmpty) > 0;
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x00031774 File Offset: 0x0002F974
		internal readonly void Clear(bool freeMemory, bool resetParent)
		{
			this.NullCheck("Clear");
			method crende_Clear = CRenderAttributes.__N.CRende_Clear;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32), this.self, freeMemory ? 1 : 0, resetParent ? 1 : 0, crende_Clear);
		}

		// Token: 0x040000AD RID: 173
		internal IntPtr self;

		// Token: 0x020001B6 RID: 438
		internal static class __N
		{
			// Token: 0x04000CC0 RID: 3264
			internal static method CRende_SetFloatValue;

			// Token: 0x04000CC1 RID: 3265
			internal static method CRende_GetFloatValue;

			// Token: 0x04000CC2 RID: 3266
			internal static method CRende_DeleteFloatValue;

			// Token: 0x04000CC3 RID: 3267
			internal static method CRende_SetVector2DValue;

			// Token: 0x04000CC4 RID: 3268
			internal static method CRende_GetVector2DValue;

			// Token: 0x04000CC5 RID: 3269
			internal static method CRende_DeleteVector2DValue;

			// Token: 0x04000CC6 RID: 3270
			internal static method CRende_SetVectorValue;

			// Token: 0x04000CC7 RID: 3271
			internal static method CRende_GetVectorValue;

			// Token: 0x04000CC8 RID: 3272
			internal static method CRende_DeleteVectorValue;

			// Token: 0x04000CC9 RID: 3273
			internal static method CRende_SetVector4DValue;

			// Token: 0x04000CCA RID: 3274
			internal static method CRende_GetVector4DValue;

			// Token: 0x04000CCB RID: 3275
			internal static method CRende_DeleteVector4DValue;

			// Token: 0x04000CCC RID: 3276
			internal static method CRende_SetVMatrixValue;

			// Token: 0x04000CCD RID: 3277
			internal static method CRende_GetVMatrixValue;

			// Token: 0x04000CCE RID: 3278
			internal static method CRende_DeleteVMatrixValue;

			// Token: 0x04000CCF RID: 3279
			internal static method CRende_SetStringValue;

			// Token: 0x04000CD0 RID: 3280
			internal static method CRende_DeleteStringValue;

			// Token: 0x04000CD1 RID: 3281
			internal static method CRende_SetIntValue;

			// Token: 0x04000CD2 RID: 3282
			internal static method CRende_GetIntValue;

			// Token: 0x04000CD3 RID: 3283
			internal static method CRende_DeleteIntValue;

			// Token: 0x04000CD4 RID: 3284
			internal static method CRende_SetConstantBufferValue;

			// Token: 0x04000CD5 RID: 3285
			internal static method CRende_DeleteConstantBufferValue;

			// Token: 0x04000CD6 RID: 3286
			internal static method CRende_SetComboValue;

			// Token: 0x04000CD7 RID: 3287
			internal static method CRende_GetComboValue;

			// Token: 0x04000CD8 RID: 3288
			internal static method CRende_DeleteComboValue;

			// Token: 0x04000CD9 RID: 3289
			internal static method CRende_SetBoolValue;

			// Token: 0x04000CDA RID: 3290
			internal static method CRende_GetBoolValue;

			// Token: 0x04000CDB RID: 3291
			internal static method CRende_DeleteBoolValue;

			// Token: 0x04000CDC RID: 3292
			internal static method CRende_SetTextureValue;

			// Token: 0x04000CDD RID: 3293
			internal static method CRende_GetTextureValue;

			// Token: 0x04000CDE RID: 3294
			internal static method CRende_DeleteTextureValue;

			// Token: 0x04000CDF RID: 3295
			internal static method CRende_MergeToPtr;

			// Token: 0x04000CE0 RID: 3296
			internal static method CRende_IsEmpty;

			// Token: 0x04000CE1 RID: 3297
			internal static method CRende_Clear;
		}
	}
}
