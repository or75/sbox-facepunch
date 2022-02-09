using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using NativeEngine;
using NativeGlue;
using Sandbox.Internal.JsonConvert;

namespace Sandbox
{
	// Token: 0x020002BE RID: 702
	[JsonConverter(typeof(MaterialConverter))]
	public class Material : Resource
	{
		// Token: 0x17000357 RID: 855
		// (get) Token: 0x060011C2 RID: 4546 RVA: 0x00023FF2 File Offset: 0x000221F2
		// (set) Token: 0x060011C3 RID: 4547 RVA: 0x00023FFA File Offset: 0x000221FA
		public string Name { get; internal set; }

		// Token: 0x060011C4 RID: 4548 RVA: 0x00024003 File Offset: 0x00022203
		public static Material Create(string materialName, string shader)
		{
			return new Material(MaterialSystem2.CreateRawMaterial(materialName, shader));
		}

		// Token: 0x060011C5 RID: 4549 RVA: 0x00024011 File Offset: 0x00022211
		internal Material(IMaterial native)
		{
			if (native.IsNull)
			{
				throw new Exception("Material pointer cannot be null!");
			}
			this.native = native;
			this.Name = native.GetName();
		}

		// Token: 0x060011C6 RID: 4550 RVA: 0x00024044 File Offset: 0x00022244
		~Material()
		{
			this.native.DestroyStrongHandle();
			this.native = default(IMaterial);
		}

		/// <summary>
		/// Create a copy of this material
		/// </summary>
		// Token: 0x060011C7 RID: 4551 RVA: 0x00024084 File Offset: 0x00022284
		public Material CreateCopy()
		{
			return new Material(MaterialSystem2.CreateProceduralMaterialCopy(this.native, 0, true));
		}

		/// <summary>
		/// Override texture parameter (Color, Normal, etc)
		/// </summary>
		// Token: 0x060011C8 RID: 4552 RVA: 0x00024098 File Offset: 0x00022298
		public bool OverrideTexture(string param, Texture texture)
		{
			if (texture == null || texture.native.IsNull)
			{
				return false;
			}
			if (!param.StartsWith("g_t"))
			{
				param = "g_t" + param;
			}
			return this.native.OverrideTextureParamWithScopeGuard(param, texture.native);
		}

		// Token: 0x060011C9 RID: 4553 RVA: 0x000240D8 File Offset: 0x000222D8
		public static Material Load(string filename)
		{
			ThreadSafe.AssertIsMainThread("Material.Load");
			Material mat;
			if (Material.Loaded.TryGetValue(filename, out mat))
			{
				return mat;
			}
			mat = new Material(Resources.GetMaterial(filename));
			Material.Loaded[filename] = mat;
			mat.Register(filename);
			return mat;
		}

		// Token: 0x060011CA RID: 4554 RVA: 0x00024120 File Offset: 0x00022320
		[Obsolete("Use Material.Name")]
		public string GetName()
		{
			return this.Name;
		}

		// Token: 0x04001423 RID: 5155
		internal IMaterial native;

		// Token: 0x04001425 RID: 5157
		internal static Dictionary<string, Material> Loaded = new Dictionary<string, Material>();
	}
}
