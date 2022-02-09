using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020000F1 RID: 241
	public class SceneMonitorObject : SceneObject
	{
		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06001409 RID: 5129 RVA: 0x00051757 File Offset: 0x0004F957
		internal new CRenderAttributes Attributes
		{
			get
			{
				return this.monitorNative.GetMonitorAttributesPtrForModify();
			}
		}

		// Token: 0x0600140A RID: 5130 RVA: 0x00051764 File Offset: 0x0004F964
		public SceneMonitorObject WithAttribute(string name, int value)
		{
			this.Attributes.SetIntValue(name, value);
			return this;
		}

		// Token: 0x0600140B RID: 5131 RVA: 0x00051784 File Offset: 0x0004F984
		public SceneMonitorObject WithAttribute(string name, bool value)
		{
			this.Attributes.SetBoolValue(name, value);
			return this;
		}

		// Token: 0x0600140C RID: 5132 RVA: 0x000517A4 File Offset: 0x0004F9A4
		public SceneMonitorObject WithAttribute(string name, string value)
		{
			this.Attributes.SetStringValue(name, value);
			return this;
		}

		// Token: 0x0600140D RID: 5133 RVA: 0x000517C4 File Offset: 0x0004F9C4
		public SceneMonitorObject WithAttribute(string name, float value)
		{
			this.Attributes.SetFloatValue(name, value);
			return this;
		}

		// Token: 0x0600140E RID: 5134 RVA: 0x000517E4 File Offset: 0x0004F9E4
		public SceneMonitorObject WithAttribute(string name, Texture value, int mipLevel = -1)
		{
			this.Attributes.SetTextureValue(name, value.native, mipLevel);
			return this;
		}

		// Token: 0x0600140F RID: 5135 RVA: 0x00051808 File Offset: 0x0004FA08
		public SceneMonitorObject WithAttribute(string name, Vector2 value)
		{
			this.Attributes.SetVector2DValue(name, value);
			return this;
		}

		// Token: 0x06001410 RID: 5136 RVA: 0x00051828 File Offset: 0x0004FA28
		public SceneMonitorObject WithAttribute(string name, Vector3 value)
		{
			this.Attributes.SetVectorValue(name, value);
			return this;
		}

		// Token: 0x06001411 RID: 5137 RVA: 0x00051848 File Offset: 0x0004FA48
		public SceneMonitorObject WithAttribute(string name, Vector4 value)
		{
			this.Attributes.SetVector4DValue(name, value);
			return this;
		}

		// Token: 0x06001412 RID: 5138 RVA: 0x00051868 File Offset: 0x0004FA68
		public SceneMonitorObject WithAttribute(string name, Matrix value)
		{
			this.Attributes.SetVMatrixValue(name, value);
			return this;
		}

		// Token: 0x06001413 RID: 5139 RVA: 0x00051888 File Offset: 0x0004FA88
		public SceneMonitorObject WithAttribute(string name, ConstantBuffer value, uint view = 0U)
		{
			this.Attributes.SetConstantBufferValue(name, value.bufferHandle, view);
			return this;
		}

		// Token: 0x06001414 RID: 5140 RVA: 0x000518AC File Offset: 0x0004FAAC
		public SceneMonitorObject WithCombo(string name, byte value)
		{
			this.Attributes.SetComboValue(name, value);
			return this;
		}

		// Token: 0x06001415 RID: 5141 RVA: 0x000518CC File Offset: 0x0004FACC
		public void ClearAttributes()
		{
			this.Attributes.Clear(true, true);
		}

		// Token: 0x06001416 RID: 5142 RVA: 0x000518E9 File Offset: 0x0004FAE9
		internal SceneMonitorObject()
		{
		}

		// Token: 0x06001417 RID: 5143 RVA: 0x000518F1 File Offset: 0x0004FAF1
		internal SceneMonitorObject(HandleCreationData _)
		{
		}

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06001418 RID: 5144 RVA: 0x000518F9 File Offset: 0x0004FAF9
		public bool IsValid
		{
			get
			{
				return this.monitorNative.IsValid;
			}
		}

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06001419 RID: 5145 RVA: 0x00051906 File Offset: 0x0004FB06
		// (set) Token: 0x0600141A RID: 5146 RVA: 0x0005190E File Offset: 0x0004FB0E
		public SceneMonitorObject.ViewAccessor View { get; internal set; }

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x0600141B RID: 5147 RVA: 0x00051917 File Offset: 0x0004FB17
		// (set) Token: 0x0600141C RID: 5148 RVA: 0x0005191F File Offset: 0x0004FB1F
		public Texture ColorTarget { get; internal set; }

		// Token: 0x170002F2 RID: 754
		// (set) Token: 0x0600141D RID: 5149 RVA: 0x00051928 File Offset: 0x0004FB28
		public Color ClearColor
		{
			set
			{
				if (this.monitorNative.IsValid)
				{
					GameGlue.SetSceneMonitorObjectClearColor(this, value);
				}
			}
		}

		// Token: 0x0600141E RID: 5150 RVA: 0x00051944 File Offset: 0x0004FB44
		public SceneMonitorObject(Model model, Transform transform, bool useHDRBuffer = false)
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
				ESceneObjectTypeFlags typeFlags = ESceneObjectTypeFlags.NOT_BATCHABLE;
				SceneObject a = MeshSystem.CreateSceneObject(model.native, transform, "MonitorSceneObjectDesc", flags, typeFlags, sceneWorld);
				if (!this.monitorNative.IsValid)
				{
					HandleIndex.ForceNextObject(null);
					throw new ArgumentException("Error creating MonitorSceneObject - possible invalid model?");
				}
				Assert.AreEqual<SceneObject>(a, this);
			}
			finally
			{
				HandleIndex.UsedNextObject(this);
				TextureBuilder textureBuilder = Texture.CreateRenderTarget();
				textureBuilder = textureBuilder.WithSize(512.0);
				textureBuilder = textureBuilder.WithFormat(useHDRBuffer ? ImageFormat.RGBA16161616F : ImageFormat.RGBA8888);
				this.ColorTarget = textureBuilder.Create(null, true, default(ReadOnlySpan<byte>), 0);
				GameGlue.SetSceneMonitorObjectRenderTargets(this, this.ColorTarget.native, IntPtr.Zero);
				this.View = new SceneMonitorObject.ViewAccessor(this);
				this.position = Vector3.Zero;
				this.rotation = Rotation.Identity;
				this.fov = 80f;
				this.aspect = 1f;
				this.zNear = 1f;
				this.zFar = 5000f;
				this.UpdateTransform();
				this.UpdateFrustum();
				this.UpdateRenderShadows();
			}
		}

		// Token: 0x0600141F RID: 5151 RVA: 0x00051AAC File Offset: 0x0004FCAC
		internal override void OnNativeInit(CSceneObject ptr)
		{
			base.OnNativeInit(ptr);
			this.monitorNative = (CSceneMonitorObject)ptr;
		}

		// Token: 0x06001420 RID: 5152 RVA: 0x00051AC1 File Offset: 0x0004FCC1
		internal override void OnNativeDestroy()
		{
			base.OnNativeDestroy();
			this.monitorNative = default(CSceneMonitorObject);
		}

		// Token: 0x06001421 RID: 5153 RVA: 0x00051AD5 File Offset: 0x0004FCD5
		internal void UpdateFrustum()
		{
			if (this.monitorNative.IsValid)
			{
				GameGlue.SetSceneMonitorObjectFrustum(this, this.transform, this.zNear, this.zFar, this.aspect);
			}
		}

		// Token: 0x06001422 RID: 5154 RVA: 0x00051B02 File Offset: 0x0004FD02
		internal void UpdateTransform()
		{
			this.transform = new Transform(this.position, this.rotation, this.fov);
		}

		// Token: 0x06001423 RID: 5155 RVA: 0x00051B21 File Offset: 0x0004FD21
		internal void UpdateRenderShadows()
		{
			if (this.monitorNative.IsValid)
			{
				GameGlue.SetSceneMonitorObjectRenderShadows(this, this.renderShadows);
			}
		}

		// Token: 0x06001424 RID: 5156 RVA: 0x00051B3C File Offset: 0x0004FD3C
		public void SetClipPlane(Plane clipPlane)
		{
			this.WithAttribute("EnableClipPlane", true);
			this.WithAttribute("ClipPlane0", new Vector4(clipPlane.Normal, clipPlane.Distance));
		}

		// Token: 0x040004AE RID: 1198
		private CSceneMonitorObject monitorNative;

		// Token: 0x040004B0 RID: 1200
		internal Vector3 position;

		// Token: 0x040004B1 RID: 1201
		internal Rotation rotation;

		// Token: 0x040004B2 RID: 1202
		internal float fov;

		// Token: 0x040004B3 RID: 1203
		internal Transform transform;

		// Token: 0x040004B4 RID: 1204
		internal float zNear;

		// Token: 0x040004B5 RID: 1205
		internal float zFar;

		// Token: 0x040004B6 RID: 1206
		internal float aspect;

		// Token: 0x040004B7 RID: 1207
		internal bool renderShadows;

		// Token: 0x02000265 RID: 613
		public class ViewAccessor
		{
			// Token: 0x06001EB7 RID: 7863 RVA: 0x00076C5C File Offset: 0x00074E5C
			internal ViewAccessor(SceneMonitorObject owner)
			{
				this.owner = owner;
			}

			// Token: 0x06001EB8 RID: 7864 RVA: 0x00076C6B File Offset: 0x00074E6B
			internal void UpdateTransform()
			{
				SceneMonitorObject sceneMonitorObject = this.owner;
				if (sceneMonitorObject == null)
				{
					return;
				}
				sceneMonitorObject.UpdateTransform();
			}

			// Token: 0x06001EB9 RID: 7865 RVA: 0x00076C7D File Offset: 0x00074E7D
			internal void UpdateFrustum()
			{
				SceneMonitorObject sceneMonitorObject = this.owner;
				if (sceneMonitorObject == null)
				{
					return;
				}
				sceneMonitorObject.UpdateFrustum();
			}

			// Token: 0x06001EBA RID: 7866 RVA: 0x00076C8F File Offset: 0x00074E8F
			internal void UpdateRenderShadows()
			{
				SceneMonitorObject sceneMonitorObject = this.owner;
				if (sceneMonitorObject == null)
				{
					return;
				}
				sceneMonitorObject.UpdateRenderShadows();
			}

			// Token: 0x170005B0 RID: 1456
			// (get) Token: 0x06001EBB RID: 7867 RVA: 0x00076CA1 File Offset: 0x00074EA1
			// (set) Token: 0x06001EBC RID: 7868 RVA: 0x00076CAE File Offset: 0x00074EAE
			public Vector3 Position
			{
				get
				{
					return this.owner.position;
				}
				set
				{
					this.owner.position = value;
					this.UpdateTransform();
					this.UpdateFrustum();
				}
			}

			// Token: 0x170005B1 RID: 1457
			// (get) Token: 0x06001EBD RID: 7869 RVA: 0x00076CC8 File Offset: 0x00074EC8
			// (set) Token: 0x06001EBE RID: 7870 RVA: 0x00076CD5 File Offset: 0x00074ED5
			public Rotation Rotation
			{
				get
				{
					return this.owner.rotation;
				}
				set
				{
					this.owner.rotation = value;
					this.UpdateTransform();
					this.UpdateFrustum();
				}
			}

			// Token: 0x170005B2 RID: 1458
			// (get) Token: 0x06001EBF RID: 7871 RVA: 0x00076CEF File Offset: 0x00074EEF
			// (set) Token: 0x06001EC0 RID: 7872 RVA: 0x00076CFC File Offset: 0x00074EFC
			public float FieldOfView
			{
				get
				{
					return this.owner.fov;
				}
				set
				{
					this.owner.fov = value;
					this.UpdateTransform();
					this.UpdateFrustum();
				}
			}

			// Token: 0x170005B3 RID: 1459
			// (get) Token: 0x06001EC1 RID: 7873 RVA: 0x00076D16 File Offset: 0x00074F16
			// (set) Token: 0x06001EC2 RID: 7874 RVA: 0x00076D23 File Offset: 0x00074F23
			public float ZNear
			{
				get
				{
					return this.owner.zNear;
				}
				set
				{
					this.owner.zNear = value;
					this.UpdateFrustum();
				}
			}

			// Token: 0x170005B4 RID: 1460
			// (get) Token: 0x06001EC3 RID: 7875 RVA: 0x00076D37 File Offset: 0x00074F37
			// (set) Token: 0x06001EC4 RID: 7876 RVA: 0x00076D44 File Offset: 0x00074F44
			public float ZFar
			{
				get
				{
					return this.owner.zFar;
				}
				set
				{
					this.owner.zFar = value;
					this.UpdateFrustum();
				}
			}

			// Token: 0x170005B5 RID: 1461
			// (get) Token: 0x06001EC5 RID: 7877 RVA: 0x00076D58 File Offset: 0x00074F58
			// (set) Token: 0x06001EC6 RID: 7878 RVA: 0x00076D65 File Offset: 0x00074F65
			public float Aspect
			{
				get
				{
					return this.owner.aspect;
				}
				set
				{
					this.owner.aspect = value;
					this.UpdateFrustum();
				}
			}

			// Token: 0x170005B6 RID: 1462
			// (get) Token: 0x06001EC7 RID: 7879 RVA: 0x00076D79 File Offset: 0x00074F79
			// (set) Token: 0x06001EC8 RID: 7880 RVA: 0x00076D86 File Offset: 0x00074F86
			public bool ShadowsEnabled
			{
				get
				{
					return this.owner.renderShadows;
				}
				set
				{
					this.owner.renderShadows = value;
					this.UpdateRenderShadows();
				}
			}

			// Token: 0x0400122B RID: 4651
			internal SceneMonitorObject owner;
		}
	}
}
