using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using ModelDoc;
using NativeEngine;
using NativeGlue;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x020002C5 RID: 709
	public class Model : Resource
	{
		/// <summary>
		/// Total bounds of all the meshes
		/// </summary>
		// Token: 0x17000360 RID: 864
		// (get) Token: 0x060011F5 RID: 4597 RVA: 0x000252ED File Offset: 0x000234ED
		public BBox Bounds
		{
			get
			{
				return this.native.GetMeshBounds();
			}
		}

		/// <summary>
		/// Total bounds of all the physics shapes
		/// </summary>
		// Token: 0x17000361 RID: 865
		// (get) Token: 0x060011F6 RID: 4598 RVA: 0x000252FA File Offset: 0x000234FA
		public BBox PhysicsBounds
		{
			get
			{
				return this.native.GetPhysicsBounds();
			}
		}

		/// <summary>
		/// Render view bounds
		/// </summary>
		// Token: 0x17000362 RID: 866
		// (get) Token: 0x060011F7 RID: 4599 RVA: 0x00025307 File Offset: 0x00023507
		public BBox RenderBounds
		{
			get
			{
				return this.native.GetModelRenderBounds();
			}
		}

		// Token: 0x060011F8 RID: 4600 RVA: 0x00025314 File Offset: 0x00023514
		internal Model(IModel native, long instanceId)
		{
			if (native.IsNull)
			{
				throw new Exception("Model pointer cannot be null!");
			}
			this.native = native;
			this.instanceId = instanceId;
			this.Name = native.GetModelName();
			base.Register(this.Name);
		}

		// Token: 0x060011F9 RID: 4601 RVA: 0x00025394 File Offset: 0x00023594
		~Model()
		{
			this.native.DestroyStrongHandle();
			this.native = default(IModel);
		}

		// Token: 0x060011FA RID: 4602 RVA: 0x000253D4 File Offset: 0x000235D4
		public override string ToString()
		{
			return "Model{" + this.Name + "}";
		}

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x060011FB RID: 4603 RVA: 0x000253EB File Offset: 0x000235EB
		public bool IsError
		{
			get
			{
				return this.native.IsNull || !this.native.IsStrongHandleValid();
			}
		}

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x060011FC RID: 4604 RVA: 0x0002540A File Offset: 0x0002360A
		// (set) Token: 0x060011FD RID: 4605 RVA: 0x00025412 File Offset: 0x00023612
		public string Name { get; internal set; }

		// Token: 0x060011FE RID: 4606 RVA: 0x0002541C File Offset: 0x0002361C
		public Transform? GetAttachment(string name)
		{
			Transform tx;
			if (this.native.GetAttachmentTransform(name, out tx))
			{
				return new Transform?(tx);
			}
			return null;
		}

		// Token: 0x060011FF RID: 4607 RVA: 0x0002544C File Offset: 0x0002364C
		public Transform? GetAttachment(int index)
		{
			if (index < 0 || index >= this.AttachmentCount)
			{
				return null;
			}
			return this.GetAttachment(this.native.GetAttachmentNameFromIndex(index));
		}

		// Token: 0x06001200 RID: 4608 RVA: 0x00025482 File Offset: 0x00023682
		public string GetAttachmentName(int index)
		{
			if (index < 0 || index >= this.AttachmentCount)
			{
				throw new IndexOutOfRangeException();
			}
			return this.native.GetAttachmentNameFromIndex(index);
		}

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x06001201 RID: 4609 RVA: 0x000254A3 File Offset: 0x000236A3
		public int AttachmentCount
		{
			get
			{
				return this.native.GetNumAttachments();
			}
		}

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06001202 RID: 4610 RVA: 0x000254B0 File Offset: 0x000236B0
		public int BodyPartCount
		{
			get
			{
				return this.native.GetNumBodyParts();
			}
		}

		// Token: 0x06001203 RID: 4611 RVA: 0x000254BD File Offset: 0x000236BD
		public ulong GetBodyPartMask(string name)
		{
			return this.native.GetBodyPartMask(this.GetBodyPartForName(name));
		}

		// Token: 0x06001204 RID: 4612 RVA: 0x000254D1 File Offset: 0x000236D1
		public ulong GetBodyPartMask(int part)
		{
			return this.native.GetBodyPartMask(part);
		}

		// Token: 0x06001205 RID: 4613 RVA: 0x000254DF File Offset: 0x000236DF
		public ulong GetBodyPartMeshMask(int part, int mesh)
		{
			return this.native.GetBodyPartMeshMask(part, mesh);
		}

		// Token: 0x06001206 RID: 4614 RVA: 0x000254EE File Offset: 0x000236EE
		public int GetBodyPartForName(string name)
		{
			return this.native.GetBodyPartForName(name);
		}

		// Token: 0x06001207 RID: 4615 RVA: 0x000254FC File Offset: 0x000236FC
		public string GetBodyPartName(int part)
		{
			return this.native.GetBodyPartName(part);
		}

		// Token: 0x06001208 RID: 4616 RVA: 0x0002550A File Offset: 0x0002370A
		public int GetNumBodyPartMeshes(int part)
		{
			return this.native.GetNumBodyPartMeshes(part);
		}

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06001209 RID: 4617 RVA: 0x00025518 File Offset: 0x00023718
		public int MeshCount
		{
			get
			{
				return this.native.GetNumMeshes();
			}
		}

		// Token: 0x0600120A RID: 4618 RVA: 0x00025525 File Offset: 0x00023725
		internal void OnReloaded()
		{
			Dictionary<string, object> dataCache = this.DataCache;
			if (dataCache == null)
			{
				return;
			}
			dataCache.Clear();
		}

		// Token: 0x0600120B RID: 4619 RVA: 0x00025538 File Offset: 0x00023738
		internal string GetJson(string keyname)
		{
			if (string.IsNullOrEmpty(this.Name))
			{
				GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Warning: Trying to access Model Key Value '{0}' on an empty model!", new object[] { keyname }));
			}
			KeyValues3 key = this.native.FindModelSubKey(keyname);
			if (key.IsNull)
			{
				return null;
			}
			return EngineGlue.KeyValues3ToJson(key);
		}

		// Token: 0x0600120C RID: 4620 RVA: 0x00025590 File Offset: 0x00023790
		internal string DeduceKeyName(Type type)
		{
			Type dataType = type;
			if (dataType.IsArray)
			{
				dataType = dataType.GetElementType();
			}
			GameDataAttribute gdAttr = dataType.GetCustomAttribute<GameDataAttribute>();
			if (gdAttr == null)
			{
				throw new ArgumentException(type.Name + " does not have ModelDoc.GameDataAttribute");
			}
			if (!gdAttr.AllowMultiple && type.IsArray)
			{
				throw new ArgumentException(type.Name + " is not a list, but an array generic parameter was given");
			}
			if (gdAttr.AllowMultiple && !type.IsArray)
			{
				throw new ArgumentException(type.Name + " is a list, but non array generic parameter was given");
			}
			string keyname = gdAttr.Name;
			if (gdAttr.AllowMultiple)
			{
				keyname = gdAttr.ListName ?? (keyname + "_list");
			}
			return keyname;
		}

		/// <summary>
		/// Internal function used to get a list of break commands the model has.
		/// </summary>
		// Token: 0x0600120D RID: 4621 RVA: 0x00025644 File Offset: 0x00023844
		public Dictionary<string, string[]> GetBreakCommands()
		{
			object cacheValue;
			if (this.DataCache != null && this.DataCache.TryGetValue(this.Name, out cacheValue))
			{
				return (Dictionary<string, string[]>)cacheValue;
			}
			Dictionary<string, string[]> output = new Dictionary<string, string[]>();
			string jsonString = this.GetJson("break_command_list");
			if (jsonString == null)
			{
				return output;
			}
			using (JsonDocument document = JsonDocument.Parse(jsonString, default(JsonDocumentOptions)))
			{
				JsonElement root = document.RootElement;
				if (root.ValueKind != JsonValueKind.Array)
				{
					return output;
				}
				foreach (JsonElement commandData in root.EnumerateArray())
				{
					JsonElement command;
					if (commandData.TryGetProperty("break_command", out command))
					{
						string cmd = command.GetString();
						List<string> arr = (output.ContainsKey(cmd) ? output[cmd].Cast<string>().ToList<string>() : new List<string>());
						arr.Add(commandData.GetRawText());
						output[cmd] = arr.ToArray();
					}
				}
			}
			if (this.DataCache == null)
			{
				this.DataCache = new Dictionary<string, object>();
			}
			this.DataCache.Add(this.Name, output);
			return output;
		}

		/// <summary>
		/// Tries to extract data from model based on the given type's <see cref="T:ModelDoc.GameDataAttribute">ModelDoc.GameDataAttribute</see>.
		/// </summary>
		/// <param name="data">The extracted data, or default on failure.</param>
		/// <returns>true if data was extracted successfully, false otherwise.</returns>
		// Token: 0x0600120E RID: 4622 RVA: 0x00025798 File Offset: 0x00023998
		public bool TryGetData<T>(out T data)
		{
			object dat;
			bool result = this.TryGetData(typeof(T), out dat);
			data = (T)((object)dat);
			return result;
		}

		/// <summary>
		/// Tries to extract data from model based on the given type's <see cref="T:ModelDoc.GameDataAttribute">ModelDoc.GameDataAttribute</see>.
		/// </summary>
		/// <param name="data">The extracted data, or default on failure.</param>
		/// <param name="t">The class with <see cref="T:ModelDoc.GameDataAttribute">ModelDoc.GameDataAttribute</see>.</param>
		/// <returns>true if data was extracted successfully, false otherwise.</returns>
		// Token: 0x0600120F RID: 4623 RVA: 0x000257C4 File Offset: 0x000239C4
		public bool TryGetData(Type t, out object data)
		{
			string keyname = this.DeduceKeyName(t);
			string cacheKey = keyname + "~" + t.Name;
			object cacheValue;
			if (this.DataCache != null && this.DataCache.TryGetValue(cacheKey, out cacheValue))
			{
				data = Convert.ChangeType(cacheValue, t);
				return true;
			}
			string json = this.GetJson(keyname);
			if (string.IsNullOrWhiteSpace(json))
			{
				data = null;
				return false;
			}
			if (json == "null")
			{
				json = "{}";
			}
			try
			{
				object obj = JsonSerializer.Deserialize(json, t, this.jsonOptions);
				if (obj == null)
				{
					data = null;
					return false;
				}
				if (this.DataCache == null)
				{
					this.DataCache = new Dictionary<string, object>();
				}
				this.DataCache.Add(cacheKey, obj);
				data = obj;
				return true;
			}
			catch (Exception e)
			{
				GlobalSystemNamespace.Log.Warning(e, FormattableStringFactory.Create("Failed to deserialize '{0}' to {1}", new object[] { keyname, t.Name }));
			}
			data = null;
			return false;
		}

		/// <summary>
		/// Tests if this model has generic data based on given type's <see cref="T:ModelDoc.GameDataAttribute">ModelDoc.GameDataAttribute</see>.
		/// This will be faster than testing this via GetData<![CDATA[<>]]>()
		/// </summary>
		// Token: 0x06001210 RID: 4624 RVA: 0x000258C0 File Offset: 0x00023AC0
		public bool HasData<T>()
		{
			string keyname = this.DeduceKeyName(typeof(T));
			return this.native.FindModelSubKey(keyname).IsValid;
		}

		/// <summary>
		/// Extracts data from model based on the given type's <see cref="T:ModelDoc.GameDataAttribute">ModelDoc.GameDataAttribute</see>.
		/// </summary>
		// Token: 0x06001211 RID: 4625 RVA: 0x000258F4 File Offset: 0x00023AF4
		public T GetData<T>()
		{
			T data;
			if (this.TryGetData<T>(out data))
			{
				return data;
			}
			return default(T);
		}

		// Token: 0x06001212 RID: 4626 RVA: 0x00025918 File Offset: 0x00023B18
		[Obsolete("Use parameterless HasData<>() instead")]
		public bool HasData(string keyname)
		{
			return this.native.FindModelSubKey(keyname).IsValid;
		}

		// Token: 0x06001213 RID: 4627 RVA: 0x0002593C File Offset: 0x00023B3C
		[Obsolete("Use parameterless GetData<>() instead")]
		public T GetData<T>(string keyname)
		{
			if (string.IsNullOrEmpty(keyname))
			{
				keyname = this.DeduceKeyName(typeof(T));
			}
			string cacheKey = keyname + "~" + typeof(T).Name;
			object cacheValue;
			if (this.DataCache != null && this.DataCache.TryGetValue(cacheKey, out cacheValue))
			{
				return (T)((object)cacheValue);
			}
			string json = this.GetJson(keyname);
			if (string.IsNullOrWhiteSpace(json))
			{
				return default(T);
			}
			T t = JsonSerializer.Deserialize<T>(json, this.jsonOptions);
			if (this.DataCache == null)
			{
				this.DataCache = new Dictionary<string, object>();
			}
			this.DataCache.Add(cacheKey, t);
			return t;
		}

		// Token: 0x06001214 RID: 4628 RVA: 0x000259EB File Offset: 0x00023BEB
		public static Model Load(string filename)
		{
			return Model.Get(Resources.GetModel(filename));
		}

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06001215 RID: 4629 RVA: 0x000259F8 File Offset: 0x00023BF8
		public int BoneCount
		{
			get
			{
				return this.native.NumBones();
			}
		}

		// Token: 0x06001216 RID: 4630 RVA: 0x00025A05 File Offset: 0x00023C05
		public string GetBoneName(int boneIndex)
		{
			return this.native.boneName(boneIndex);
		}

		// Token: 0x06001217 RID: 4631 RVA: 0x00025A13 File Offset: 0x00023C13
		public int GetBoneParent(int boneIndex)
		{
			return this.native.boneParent(boneIndex);
		}

		// Token: 0x06001218 RID: 4632 RVA: 0x00025A21 File Offset: 0x00023C21
		internal static void Init()
		{
			Model.Loaded = new Dictionary<long, Model>();
		}

		/// <summary>
		/// Try to make it so only one Model class exists for each model
		/// </summary>
		// Token: 0x06001219 RID: 4633 RVA: 0x00025A30 File Offset: 0x00023C30
		internal static Model Get(IModel native)
		{
			long instanceId = native.GetBindingPtr().ToInt64();
			Model mdl;
			if (Model.Loaded.TryGetValue(instanceId, out mdl))
			{
				return mdl;
			}
			mdl = new Model(native, instanceId);
			Model.Loaded.Add(instanceId, mdl);
			return mdl;
		}

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x0600121A RID: 4634 RVA: 0x00025A73 File Offset: 0x00023C73
		public static ModelBuilder Builder
		{
			get
			{
				return new ModelBuilder();
			}
		}

		/// <summary>
		/// Experimental! Try to get all vertices from model (meshes need to be compiled with CPU access!)
		/// https://files.facepunch.com/layla/1b0611b1/sbox_K1HhsZO3yM.png
		/// </summary>
		// Token: 0x0600121B RID: 4635 RVA: 0x00025A7C File Offset: 0x00023C7C
		public unsafe Vertex[] GetVertices()
		{
			int numVertices = MeshGlue.GetModelNumVertices(this.native);
			if (numVertices == 0)
			{
				return null;
			}
			Vertex[] array = new Vertex[numVertices];
			fixed (Vertex* ptr = &array[0])
			{
				Vertex* vmem = ptr;
				MeshGlue.GetModelVertices(this.native, (IntPtr)((void*)vmem), (uint)numVertices);
			}
			return array;
		}

		/// <summary>
		/// Experimental! Try to get all indices from model (meshes need to be compiled with CPU access!)
		/// https://files.facepunch.com/layla/1b0611b1/sbox_K1HhsZO3yM.png
		/// </summary>
		// Token: 0x0600121C RID: 4636 RVA: 0x00025AC0 File Offset: 0x00023CC0
		public unsafe uint[] GetIndices()
		{
			int numIndices = MeshGlue.GetModelNumIndices(this.native);
			if (numIndices == 0)
			{
				return null;
			}
			uint[] array = new uint[numIndices];
			fixed (uint* ptr = &array[0])
			{
				uint* vmem = ptr;
				MeshGlue.GetModelIndices(this.native, (IntPtr)((void*)vmem), (uint)numIndices);
			}
			return array;
		}

		// Token: 0x04001450 RID: 5200
		internal IModel native;

		// Token: 0x04001451 RID: 5201
		internal long instanceId;

		// Token: 0x04001453 RID: 5203
		private Dictionary<string, object> DataCache;

		// Token: 0x04001454 RID: 5204
		private JsonSerializerOptions jsonOptions = new JsonSerializerOptions
		{
			ReadCommentHandling = JsonCommentHandling.Skip,
			PropertyNameCaseInsensitive = true,
			IncludeFields = true,
			Converters = 
			{
				new JsonStringEnumConverter()
			}
		};

		// Token: 0x04001455 RID: 5205
		internal static Dictionary<long, Model> Loaded = new Dictionary<long, Model>();
	}
}
