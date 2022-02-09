using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020000F3 RID: 243
	public class SceneObject : IHandle
	{
		// Token: 0x0600142B RID: 5163 RVA: 0x00051C1B File Offset: 0x0004FE1B
		void IHandle.HandleInit(IntPtr ptr)
		{
			this.OnNativeInit(ptr);
		}

		// Token: 0x0600142C RID: 5164 RVA: 0x00051C29 File Offset: 0x0004FE29
		void IHandle.HandleDestroy()
		{
			this.OnNativeDestroy();
		}

		// Token: 0x0600142D RID: 5165 RVA: 0x00051C31 File Offset: 0x0004FE31
		bool IHandle.HandleValid()
		{
			return !this.native.IsNull;
		}

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x0600142E RID: 5166 RVA: 0x00051C41 File Offset: 0x0004FE41
		public SceneWorld World
		{
			get
			{
				return this._world;
			}
		}

		// Token: 0x0600142F RID: 5167 RVA: 0x00051C49 File Offset: 0x0004FE49
		internal SceneObject()
		{
			this.Flags = new SceneObject.SceneObjectFlagAccessor(this);
		}

		// Token: 0x06001430 RID: 5168 RVA: 0x00051C5D File Offset: 0x0004FE5D
		internal SceneObject(HandleCreationData _)
			: this()
		{
		}

		// Token: 0x06001431 RID: 5169 RVA: 0x00051C68 File Offset: 0x0004FE68
		public SceneObject(Model model, Transform transform)
			: this()
		{
			Host.AssertClientOrMenu(".ctor");
			SceneWorld sceneWorld = SceneWorld.Current;
			if (sceneWorld == null || sceneWorld.native.IsNull)
			{
				throw new Exception("SceneWorld is NULL");
			}
			try
			{
				HandleIndex.ForceNextObject(this);
				ESceneObjectFlags flags = ESceneObjectFlags.IS_OPAQUE | ESceneObjectFlags.CAST_SHADOWS_ENABLED | ESceneObjectFlags.MATERIAL_SUPPORTS_SHADOWS | ESceneObjectFlags.IS_LOADED;
				ESceneObjectTypeFlags typeFlags = ESceneObjectTypeFlags.NONE;
				Assert.AreEqual<SceneObject>(MeshSystem.CreateSceneObject(model.native, transform, null, flags, typeFlags, sceneWorld), this);
			}
			finally
			{
				HandleIndex.UsedNextObject(this);
			}
		}

		// Token: 0x06001432 RID: 5170 RVA: 0x00051CE8 File Offset: 0x0004FEE8
		public void Delete()
		{
			if (this.native.IsValid)
			{
				CSceneSystem.DeleteSceneObjectAtFrameEnd(this);
				this.native = IntPtr.Zero;
			}
		}

		// Token: 0x06001433 RID: 5171 RVA: 0x00051D0D File Offset: 0x0004FF0D
		public static SceneObject CreateModel(string name, Transform transform = default(Transform))
		{
			return new SceneObject(Model.Load(name), transform);
		}

		// Token: 0x06001434 RID: 5172 RVA: 0x00051D1B File Offset: 0x0004FF1B
		public static SceneObject CreateModel(Model model, Transform transform = default(Transform))
		{
			return new SceneObject(model, transform);
		}

		// Token: 0x06001435 RID: 5173 RVA: 0x00051D24 File Offset: 0x0004FF24
		internal virtual void OnNativeInit(CSceneObject ptr)
		{
			this.native = ptr;
			this._world = this.native.GetWorld();
			this._world.InternalSceneObjects.Add(this);
		}

		// Token: 0x06001436 RID: 5174 RVA: 0x00051D4F File Offset: 0x0004FF4F
		internal virtual void OnNativeDestroy()
		{
			this._world.InternalSceneObjects.Remove(this);
			this.native = IntPtr.Zero;
		}

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x06001437 RID: 5175 RVA: 0x00051D73 File Offset: 0x0004FF73
		// (set) Token: 0x06001438 RID: 5176 RVA: 0x00051D80 File Offset: 0x0004FF80
		public Transform Transform
		{
			get
			{
				return this.native.GetCTransform();
			}
			set
			{
				this.native.SetTransform(value);
				this.OnTransformChanged(value);
			}
		}

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06001439 RID: 5177 RVA: 0x00051D95 File Offset: 0x0004FF95
		// (set) Token: 0x0600143A RID: 5178 RVA: 0x00051DA4 File Offset: 0x0004FFA4
		public Rotation Rotation
		{
			get
			{
				return this.Transform.Rotation;
			}
			set
			{
				this.Transform = this.Transform.WithRotation(value);
			}
		}

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x0600143B RID: 5179 RVA: 0x00051DC6 File Offset: 0x0004FFC6
		// (set) Token: 0x0600143C RID: 5180 RVA: 0x00051DD4 File Offset: 0x0004FFD4
		public Vector3 Position
		{
			get
			{
				return this.Transform.Position;
			}
			set
			{
				this.Transform = this.Transform.WithPosition(value);
			}
		}

		// Token: 0x170002F9 RID: 761
		// (set) Token: 0x0600143D RID: 5181 RVA: 0x00051DF6 File Offset: 0x0004FFF6
		public BBox Bounds
		{
			set
			{
				this.native.SetBounds(value.Mins, value.Maxs);
			}
		}

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x0600143E RID: 5182 RVA: 0x00051E0F File Offset: 0x0005000F
		// (set) Token: 0x0600143F RID: 5183 RVA: 0x00051E1C File Offset: 0x0005001C
		public bool RenderingEnabled
		{
			get
			{
				return this.native.IsRenderingEnabled();
			}
			set
			{
				this.native.SetRenderingEnabled(value);
			}
		}

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06001440 RID: 5184 RVA: 0x00051E2A File Offset: 0x0005002A
		// (set) Token: 0x06001441 RID: 5185 RVA: 0x00051E3C File Offset: 0x0005003C
		public Color ColorTint
		{
			get
			{
				return this.native.GetTintRGBA();
			}
			set
			{
				this.native.SetTintRGBA(value);
			}
		}

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06001442 RID: 5186 RVA: 0x00051E50 File Offset: 0x00050050
		public SceneObject Parent
		{
			get
			{
				return this.native.GetParent();
			}
		}

		// Token: 0x06001443 RID: 5187 RVA: 0x00051E5D File Offset: 0x0005005D
		public void AddChild(string name, SceneObject child)
		{
			this.native.AddChildObject(name, child, 2U);
		}

		// Token: 0x06001444 RID: 5188 RVA: 0x00051E6D File Offset: 0x0005006D
		public void RemoveChild(SceneObject child)
		{
			this.native.RemoveChild(child);
		}

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06001445 RID: 5189 RVA: 0x00051E7B File Offset: 0x0005007B
		public Model Model
		{
			get
			{
				return Model.Get(this.native.GetModelHandle());
			}
		}

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06001446 RID: 5190 RVA: 0x00051E8D File Offset: 0x0005008D
		// (set) Token: 0x06001447 RID: 5191 RVA: 0x00051E9A File Offset: 0x0005009A
		public ulong MeshGroupMask
		{
			get
			{
				return this.native.GetCurrentMeshGroupMask();
			}
			set
			{
				this.native.ResetMeshGroups(value);
			}
		}

		// Token: 0x06001448 RID: 5192 RVA: 0x00051EA8 File Offset: 0x000500A8
		public void SetMaterialOverride(Material material)
		{
			if (material != null && material.native.IsValid)
			{
				this.native.SetMaterialOverride(material.native);
				return;
			}
			this.native.ClearMaterialOverrideList();
		}

		// Token: 0x06001449 RID: 5193 RVA: 0x00051ED7 File Offset: 0x000500D7
		internal virtual void OnTransformChanged(Transform tx)
		{
		}

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x0600144A RID: 5194 RVA: 0x00051ED9 File Offset: 0x000500D9
		// (set) Token: 0x0600144B RID: 5195 RVA: 0x00051EE1 File Offset: 0x000500E1
		public SceneObject.SceneObjectFlagAccessor Flags { get; internal set; }

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x0600144C RID: 5196 RVA: 0x00051EEA File Offset: 0x000500EA
		internal CRenderAttributes Attributes
		{
			get
			{
				return this.native.GetAttributesPtrForModify();
			}
		}

		// Token: 0x0600144D RID: 5197 RVA: 0x00051EF8 File Offset: 0x000500F8
		public void ClearRenderAttributes()
		{
			this.Attributes.Clear(true, true);
		}

		// Token: 0x0600144E RID: 5198 RVA: 0x00051F18 File Offset: 0x00050118
		public void SetValue(string name, in int value)
		{
			this.Attributes.SetIntValue(name, value);
		}

		// Token: 0x0600144F RID: 5199 RVA: 0x00051F38 File Offset: 0x00050138
		public void SetValue(string name, in bool value)
		{
			this.Attributes.SetBoolValue(name, value);
		}

		// Token: 0x06001450 RID: 5200 RVA: 0x00051F58 File Offset: 0x00050158
		public void SetValue(string name, in string value)
		{
			this.Attributes.SetStringValue(name, value);
		}

		// Token: 0x06001451 RID: 5201 RVA: 0x00051F78 File Offset: 0x00050178
		public void SetValue(string name, in float value)
		{
			this.Attributes.SetFloatValue(name, value);
		}

		// Token: 0x06001452 RID: 5202 RVA: 0x00051F98 File Offset: 0x00050198
		public void SetValue(string name, Texture value, in int mipLevel = -1)
		{
			this.Attributes.SetTextureValue(name, value.native, mipLevel);
		}

		// Token: 0x06001453 RID: 5203 RVA: 0x00051FBC File Offset: 0x000501BC
		public void SetValue(string name, in Vector2 value)
		{
			this.Attributes.SetVector2DValue(name, value);
		}

		// Token: 0x06001454 RID: 5204 RVA: 0x00051FE0 File Offset: 0x000501E0
		public void SetValue(string name, in Vector3 value)
		{
			this.Attributes.SetVectorValue(name, value);
		}

		// Token: 0x06001455 RID: 5205 RVA: 0x00052004 File Offset: 0x00050204
		public void SetValue(string name, in Vector4 value)
		{
			this.Attributes.SetVector4DValue(name, value);
		}

		// Token: 0x06001456 RID: 5206 RVA: 0x00052028 File Offset: 0x00050228
		public void SetValue(string name, in Matrix value)
		{
			this.Attributes.SetVMatrixValue(name, value);
		}

		// Token: 0x06001457 RID: 5207 RVA: 0x0005204C File Offset: 0x0005024C
		public bool GetBoolValue(string name, bool defaultValue = false)
		{
			return this.Attributes.GetBoolValue(name, defaultValue);
		}

		// Token: 0x06001458 RID: 5208 RVA: 0x0005206C File Offset: 0x0005026C
		public Vector3 GetVectorValue(string name, Vector3 defaultValue = default(Vector3))
		{
			return this.Attributes.GetVectorValue(name, defaultValue);
		}

		// Token: 0x040004BC RID: 1212
		internal CSceneObject native;

		// Token: 0x040004BD RID: 1213
		private SceneWorld _world;

		// Token: 0x02000266 RID: 614
		public class SceneObjectFlagAccessor
		{
			// Token: 0x06001EC9 RID: 7881 RVA: 0x00076D9A File Offset: 0x00074F9A
			internal SceneObjectFlagAccessor(SceneObject obj)
			{
				this.Object = obj;
			}

			// Token: 0x06001ECA RID: 7882 RVA: 0x00076DA9 File Offset: 0x00074FA9
			private bool HasFlag(ESceneObjectFlags f)
			{
				return this.Object.native.HasFlags(f);
			}

			// Token: 0x06001ECB RID: 7883 RVA: 0x00076DBC File Offset: 0x00074FBC
			private void SetFlag(ESceneObjectFlags f, bool val)
			{
				this.Object.native.ChangeFlags(val ? f : ESceneObjectFlags.NONE, f);
			}

			// Token: 0x170005B7 RID: 1463
			// (get) Token: 0x06001ECC RID: 7884 RVA: 0x00076DD7 File Offset: 0x00074FD7
			// (set) Token: 0x06001ECD RID: 7885 RVA: 0x00076DE8 File Offset: 0x00074FE8
			public bool CastShadows
			{
				get
				{
					return this.HasFlag(ESceneObjectFlags.CAST_SHADOWS);
				}
				set
				{
					this.SetFlag(ESceneObjectFlags.CAST_SHADOWS, value);
				}
			}

			// Token: 0x170005B8 RID: 1464
			// (get) Token: 0x06001ECE RID: 7886 RVA: 0x00076DFA File Offset: 0x00074FFA
			// (set) Token: 0x06001ECF RID: 7887 RVA: 0x00076E04 File Offset: 0x00075004
			public bool IsOpaque
			{
				get
				{
					return this.HasFlag(ESceneObjectFlags.IS_OPAQUE);
				}
				set
				{
					this.SetFlag(ESceneObjectFlags.IS_OPAQUE, value);
				}
			}

			// Token: 0x170005B9 RID: 1465
			// (get) Token: 0x06001ED0 RID: 7888 RVA: 0x00076E0F File Offset: 0x0007500F
			// (set) Token: 0x06001ED1 RID: 7889 RVA: 0x00076E19 File Offset: 0x00075019
			public bool IsTranslucent
			{
				get
				{
					return this.HasFlag(ESceneObjectFlags.IS_TRANSLUCENT);
				}
				set
				{
					this.SetFlag(ESceneObjectFlags.IS_TRANSLUCENT, value);
				}
			}

			// Token: 0x170005BA RID: 1466
			// (get) Token: 0x06001ED2 RID: 7890 RVA: 0x00076E24 File Offset: 0x00075024
			// (set) Token: 0x06001ED3 RID: 7891 RVA: 0x00076E2F File Offset: 0x0007502F
			public bool IsDecal
			{
				get
				{
					return this.HasFlag(ESceneObjectFlags.IS_DECAL);
				}
				set
				{
					this.SetFlag(ESceneObjectFlags.IS_DECAL, value);
				}
			}

			// Token: 0x170005BB RID: 1467
			// (get) Token: 0x06001ED4 RID: 7892 RVA: 0x00076E3B File Offset: 0x0007503B
			// (set) Token: 0x06001ED5 RID: 7893 RVA: 0x00076E49 File Offset: 0x00075049
			public bool OverlayLayer
			{
				get
				{
					return this.HasFlag(ESceneObjectFlags.GAME_OVERLAY_LAYER);
				}
				set
				{
					this.SetFlag(ESceneObjectFlags.GAME_OVERLAY_LAYER, value);
				}
			}

			// Token: 0x170005BC RID: 1468
			// (get) Token: 0x06001ED6 RID: 7894 RVA: 0x00076E58 File Offset: 0x00075058
			// (set) Token: 0x06001ED7 RID: 7895 RVA: 0x00076E66 File Offset: 0x00075066
			public bool BloomLayer
			{
				get
				{
					return this.HasFlag(ESceneObjectFlags.EFFECTS_BLOOM_LAYER);
				}
				set
				{
					this.SetFlag(ESceneObjectFlags.EFFECTS_BLOOM_LAYER, value);
				}
			}

			/// <summary>
			/// Don't render in the opaque/translucent game passes. This is useful when you
			/// want to only render in the Bloom layer, rather than additionally to it.
			/// </summary>
			// Token: 0x170005BD RID: 1469
			// (get) Token: 0x06001ED8 RID: 7896 RVA: 0x00076E75 File Offset: 0x00075075
			// (set) Token: 0x06001ED9 RID: 7897 RVA: 0x00076E83 File Offset: 0x00075083
			public bool ExcludeGameLayer
			{
				get
				{
					return this.HasFlag(ESceneObjectFlags.EXCLUDE_GAME_LAYER);
				}
				set
				{
					this.SetFlag(ESceneObjectFlags.EXCLUDE_GAME_LAYER, value);
				}
			}

			// Token: 0x170005BE RID: 1470
			// (get) Token: 0x06001EDA RID: 7898 RVA: 0x00076E92 File Offset: 0x00075092
			// (set) Token: 0x06001EDB RID: 7899 RVA: 0x00076EA0 File Offset: 0x000750A0
			public bool ViewModelLayer
			{
				get
				{
					return this.HasFlag(ESceneObjectFlags.VIEWMODEL_LAYER);
				}
				set
				{
					this.SetFlag(ESceneObjectFlags.VIEWMODEL_LAYER, value);
				}
			}

			// Token: 0x170005BF RID: 1471
			// (get) Token: 0x06001EDC RID: 7900 RVA: 0x00076EAF File Offset: 0x000750AF
			// (set) Token: 0x06001EDD RID: 7901 RVA: 0x00076EBD File Offset: 0x000750BD
			public bool SkyBoxLayer
			{
				get
				{
					return this.HasFlag(ESceneObjectFlags.SKYBOX3D_LAYER);
				}
				set
				{
					this.SetFlag(ESceneObjectFlags.SKYBOX3D_LAYER, value);
				}
			}

			// Token: 0x170005C0 RID: 1472
			// (get) Token: 0x06001EDE RID: 7902 RVA: 0x00076ECC File Offset: 0x000750CC
			// (set) Token: 0x06001EDF RID: 7903 RVA: 0x00076EDD File Offset: 0x000750DD
			public bool NeedsLightProbe
			{
				get
				{
					return this.HasFlag(ESceneObjectFlags.NEEDS_LIGHT_PROBE);
				}
				set
				{
					this.SetFlag(ESceneObjectFlags.NEEDS_LIGHT_PROBE, value);
				}
			}

			/// <summary>
			/// Automatically sets the "FrameBufferCopyTexture" attribute within the material.
			/// This does the same thing as Render.CopyFrameBuffer(); except automatically if
			/// the pass allows for it.
			/// </summary>
			// Token: 0x170005C1 RID: 1473
			// (get) Token: 0x06001EE0 RID: 7904 RVA: 0x00076EEF File Offset: 0x000750EF
			// (set) Token: 0x06001EE1 RID: 7905 RVA: 0x00076F00 File Offset: 0x00075100
			public bool WantsFrameBufferCopy
			{
				get
				{
					return this.HasFlag(ESceneObjectFlags.WANTS_FRAMEBUFFER_COPY_TEXTURE);
				}
				set
				{
					this.SetFlag(ESceneObjectFlags.WANTS_FRAMEBUFFER_COPY_TEXTURE, value);
				}
			}

			// Token: 0x0400122C RID: 4652
			private SceneObject Object;
		}
	}
}
