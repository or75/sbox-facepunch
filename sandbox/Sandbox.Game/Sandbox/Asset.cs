using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Hammer;
using Sandbox.Internal;

namespace Sandbox
{
	/// <summary>
	/// Assets defined in C# and created through tools.
	/// You can define your own <a href="https://wiki.facepunch.com/sbox/Custom_Asset_Types">Custom Asset Types</a>.
	/// </summary>
	// Token: 0x02000067 RID: 103
	public abstract class Asset : IAsset
	{
		/// <summary>
		/// Unique id of the asset, derived from the path
		/// </summary>
		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000BDF RID: 3039 RVA: 0x0003DE6E File Offset: 0x0003C06E
		// (set) Token: 0x06000BE0 RID: 3040 RVA: 0x0003DE76 File Offset: 0x0003C076
		[Skip]
		public int Id { get; internal set; }

		/// <summary>
		/// Full path to the asset
		/// </summary>
		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000BE1 RID: 3041 RVA: 0x0003DE7F File Offset: 0x0003C07F
		// (set) Token: 0x06000BE2 RID: 3042 RVA: 0x0003DE87 File Offset: 0x0003C087
		[Skip]
		public string Path { get; internal set; }

		/// <summary>
		/// Name of the asset, usually comes from the filename
		/// </summary>
		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000BE3 RID: 3043 RVA: 0x0003DE90 File Offset: 0x0003C090
		// (set) Token: 0x06000BE4 RID: 3044 RVA: 0x0003DE98 File Offset: 0x0003C098
		[Skip]
		public string Name { get; internal set; }

		/// <summary>
		/// Called when the asset is first loaded from disk.
		/// </summary>
		// Token: 0x06000BE5 RID: 3045 RVA: 0x0003DEA1 File Offset: 0x0003C0A1
		protected virtual void PostLoad()
		{
		}

		// Token: 0x06000BE6 RID: 3046 RVA: 0x0003DEA4 File Offset: 0x0003C0A4
		internal bool PostLoadInternal()
		{
			if (!string.IsNullOrEmpty(this.Path))
			{
				this.Id = this.Path.NormalizeFilename(true).FastHash();
				Asset.AssetIndex[this.Id] = this;
			}
			bool result;
			try
			{
				this.PostLoad();
				result = true;
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Error(e);
				result = false;
			}
			return result;
		}

		/// <summary>
		/// Called when the asset is recompiled/reloaded from disk.
		/// </summary>
		// Token: 0x06000BE7 RID: 3047 RVA: 0x0003DF14 File Offset: 0x0003C114
		protected virtual void PostReload()
		{
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x0003DF18 File Offset: 0x0003C118
		internal bool PostReloadInternal()
		{
			bool result;
			try
			{
				this.PostReload();
				result = true;
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Error(e);
				result = false;
			}
			return result;
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000BE9 RID: 3049 RVA: 0x0003DF50 File Offset: 0x0003C150
		[Skip]
		[Obsolete]
		public int ResourceId
		{
			get
			{
				return this.Id;
			}
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x0003DF58 File Offset: 0x0003C158
		public static T FromId<T>(int resourceId) where T : Asset
		{
			Asset val;
			if (Asset.AssetIndex.TryGetValue(resourceId, out val))
			{
				T tVal = val as T;
				if (tVal != null)
				{
					return tVal;
				}
			}
			return default(T);
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x0003DF93 File Offset: 0x0003C193
		public static T FromPath<T>(string filename) where T : Asset
		{
			return Asset.FromId<T>(filename.NormalizeFilename(true).FastHash());
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x0003DFA8 File Offset: 0x0003C1A8
		internal static void LoadAll()
		{
			Stopwatch sw = Stopwatch.StartNew();
			Dictionary<string, LibraryAttribute> types = Library.GetAllAttributes<Asset>().ToDictionary((LibraryAttribute x) => "." + x.Name + "_c", (LibraryAttribute x) => x, StringComparer.OrdinalIgnoreCase);
			string[] array = FileSystem.Mounted.FindFile("/", "*.*", true).ToArray<string>();
			double findFilesTime = sw.Elapsed.TotalSeconds;
			Asset.Clear();
			foreach (string file in array)
			{
				string extension = System.IO.Path.GetExtension(file);
				LibraryAttribute type;
				if (types.TryGetValue(extension, out type))
				{
					Asset.Load(type, file);
				}
			}
			foreach (KeyValuePair<string, LibraryAttribute> type2 in types)
			{
				Asset.AddWatcherForType(type2.Value);
			}
			GlobalGameNamespace.Log.Info(FormattableStringFactory.Create("{0}: Assets.LoadAll took {1:0.00} seconds [{2:0.00}]", new object[]
			{
				Host.Name,
				sw.Elapsed.TotalSeconds,
				findFilesTime
			}));
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x0003E0FC File Offset: 0x0003C2FC
		private static void Load(LibraryAttribute type, string file)
		{
			string json = Asset.LoadString(file);
			if (string.IsNullOrEmpty(json))
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("\t\tSkipping {0} (json is null)", new object[] { file }));
				return;
			}
			Asset se = null;
			try
			{
				se = JsonSerializer.Deserialize(json, type.Class, Asset.JsonImportOptions) as Asset;
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("\t\tError when deserializing {0} ({1})", new object[] { file, e.Message }));
			}
			if (se == null)
			{
				return;
			}
			se.Path = file.Substring(0, file.Length - 2);
			se.Name = System.IO.Path.GetFileNameWithoutExtension(file);
			se.PostLoadInternal();
			Asset.AllByPath[file] = se;
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x0003E1C4 File Offset: 0x0003C3C4
		private static void AddWatcherForType(LibraryAttribute type)
		{
			FileWatch watcher;
			if (Asset.Watchers.TryGetValue(type.Name, out watcher))
			{
				watcher.Dispose();
			}
			watcher = FileSystem.Mounted.Watch("*." + type.Name + "_c");
			watcher.OnChanges += delegate(FileWatch w)
			{
				Asset.OnAssetFilesChanged(w, type);
			};
			Asset.Watchers[type.Name] = watcher;
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x0003E24C File Offset: 0x0003C44C
		private static void OnAssetFilesChanged(FileWatch watch, LibraryAttribute type)
		{
			foreach (string file in watch.Changes)
			{
				Asset.OnAssetFileChanged(file, type);
			}
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x0003E2A0 File Offset: 0x0003C4A0
		private static void OnAssetFileChanged(string file, LibraryAttribute type)
		{
			string json = Asset.LoadString(file);
			Asset asset;
			if (Asset.AllByPath.TryGetValue(file.Trim('/'), out asset))
			{
				GlobalGameNamespace.Log.Info(FormattableStringFactory.Create("Detected Asset File Changed {0}", new object[] { file }));
				Asset.PopulateObject(asset, json);
				asset.PostReloadInternal();
				return;
			}
			GlobalGameNamespace.Log.Info(FormattableStringFactory.Create("Detected Added File {0}", new object[] { file }));
			Asset.Load(type, file);
		}

		// Token: 0x06000BF1 RID: 3057 RVA: 0x0003E31C File Offset: 0x0003C51C
		private static void PopulateObject(Asset target, string source)
		{
			Type type = target.GetType();
			foreach (JsonProperty property in JsonDocument.Parse(source, default(JsonDocumentOptions)).RootElement.EnumerateObject())
			{
				Asset.OverwriteProperty(target, property, type);
			}
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x0003E394 File Offset: 0x0003C594
		private static void OverwriteProperty(Asset target, JsonProperty updatedProperty, Type type)
		{
			PropertyInfo propertyInfo = type.GetProperty(updatedProperty.Name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			if (propertyInfo == null)
			{
				return;
			}
			Type propertyType = propertyInfo.PropertyType;
			object parsedValue = JsonSerializer.Deserialize(updatedProperty.Value.GetRawText(), propertyType, Asset.JsonImportOptions);
			propertyInfo.SetValue(target, parsedValue);
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x0003E3E8 File Offset: 0x0003C5E8
		internal static void Clear()
		{
			Asset.AssetIndex.Clear();
			Asset.AllByPath.Clear();
			foreach (KeyValuePair<string, FileWatch> watcher in Asset.Watchers)
			{
				watcher.Value.Dispose();
			}
			Asset.Watchers.Clear();
		}

		// Token: 0x06000BF4 RID: 3060 RVA: 0x0003E460 File Offset: 0x0003C660
		internal static string LoadString(string filename)
		{
			if (!filename.EndsWith("_c"))
			{
				filename += "_c";
			}
			using (Stream r = FileSystem.Mounted.OpenRead(filename, FileMode.Open))
			{
				long length = r.Length;
				Asset.HeaderData header = r.ReadStructureFromStream<Asset.HeaderData>();
				int i = 0;
				while ((long)i < (long)((ulong)header.Count))
				{
					long position = r.Position;
					Asset.BlockData block = r.ReadStructureFromStream<Asset.BlockData>();
					if (block.Type == 1096040772U)
					{
						r.Seek(-8L, SeekOrigin.Current);
						r.Seek((long)block.Offset, SeekOrigin.Current);
						byte[] sharedBuffer = ArrayPool<byte>.Shared.Rent((int)block.Size);
						try
						{
							r.Read(sharedBuffer, 0, (int)block.Size);
							return Encoding.UTF8.GetString(sharedBuffer, 0, (int)(block.Size - 1U));
						}
						finally
						{
							ArrayPool<byte>.Shared.Return(sharedBuffer, false);
						}
					}
					i++;
				}
			}
			return null;
		}

		/// <summary>
		/// Internal map of ids to assets so we can network them.
		/// </summary>
		// Token: 0x04000173 RID: 371
		internal static Dictionary<int, Asset> AssetIndex = new Dictionary<int, Asset>();

		// Token: 0x04000174 RID: 372
		private static Dictionary<string, Asset> AllByPath = new Dictionary<string, Asset>(StringComparer.OrdinalIgnoreCase);

		// Token: 0x04000175 RID: 373
		[Hotload.SkipAttribute]
		private static JsonSerializerOptions JsonImportOptions = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true,
			NumberHandling = (JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.AllowNamedFloatingPointLiterals),
			Converters = 
			{
				new JsonStringEnumConverter(null, true)
			}
		};

		// Token: 0x04000176 RID: 374
		private static Dictionary<string, FileWatch> Watchers = new Dictionary<string, FileWatch>();

		// Token: 0x020001E5 RID: 485
		private struct HeaderData
		{
			// Token: 0x17000531 RID: 1329
			// (get) Token: 0x06001CFB RID: 7419 RVA: 0x00072742 File Offset: 0x00070942
			// (set) Token: 0x06001CFC RID: 7420 RVA: 0x0007274A File Offset: 0x0007094A
			public uint Size { readonly get; set; }

			// Token: 0x17000532 RID: 1330
			// (get) Token: 0x06001CFD RID: 7421 RVA: 0x00072753 File Offset: 0x00070953
			// (set) Token: 0x06001CFE RID: 7422 RVA: 0x0007275B File Offset: 0x0007095B
			public ushort HeaderVersion { readonly get; set; }

			// Token: 0x17000533 RID: 1331
			// (get) Token: 0x06001CFF RID: 7423 RVA: 0x00072764 File Offset: 0x00070964
			// (set) Token: 0x06001D00 RID: 7424 RVA: 0x0007276C File Offset: 0x0007096C
			public ushort ResourceVersion { readonly get; set; }

			// Token: 0x17000534 RID: 1332
			// (get) Token: 0x06001D01 RID: 7425 RVA: 0x00072775 File Offset: 0x00070975
			// (set) Token: 0x06001D02 RID: 7426 RVA: 0x0007277D File Offset: 0x0007097D
			public int Offset { readonly get; set; }

			// Token: 0x17000535 RID: 1333
			// (get) Token: 0x06001D03 RID: 7427 RVA: 0x00072786 File Offset: 0x00070986
			// (set) Token: 0x06001D04 RID: 7428 RVA: 0x0007278E File Offset: 0x0007098E
			public uint Count { readonly get; set; }
		}

		// Token: 0x020001E6 RID: 486
		private struct BlockData
		{
			// Token: 0x17000536 RID: 1334
			// (get) Token: 0x06001D05 RID: 7429 RVA: 0x00072797 File Offset: 0x00070997
			// (set) Token: 0x06001D06 RID: 7430 RVA: 0x0007279F File Offset: 0x0007099F
			public uint Type { readonly get; set; }

			// Token: 0x17000537 RID: 1335
			// (get) Token: 0x06001D07 RID: 7431 RVA: 0x000727A8 File Offset: 0x000709A8
			// (set) Token: 0x06001D08 RID: 7432 RVA: 0x000727B0 File Offset: 0x000709B0
			public int Offset { readonly get; set; }

			// Token: 0x17000538 RID: 1336
			// (get) Token: 0x06001D09 RID: 7433 RVA: 0x000727B9 File Offset: 0x000709B9
			// (set) Token: 0x06001D0A RID: 7434 RVA: 0x000727C1 File Offset: 0x000709C1
			public uint Size { readonly get; set; }
		}
	}
}
