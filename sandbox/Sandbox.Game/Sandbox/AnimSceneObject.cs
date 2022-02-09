using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020000EF RID: 239
	public class AnimSceneObject : SceneObject
	{
		// Token: 0x060013F2 RID: 5106 RVA: 0x000514D2 File Offset: 0x0004F6D2
		internal AnimSceneObject()
		{
		}

		// Token: 0x060013F3 RID: 5107 RVA: 0x000514DA File Offset: 0x0004F6DA
		internal AnimSceneObject(HandleCreationData _)
		{
		}

		// Token: 0x060013F4 RID: 5108 RVA: 0x000514E4 File Offset: 0x0004F6E4
		public AnimSceneObject(Model model, Transform transform)
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
				ESceneObjectTypeFlags typeFlags = ESceneObjectTypeFlags.IS_PROCEDURAL;
				SceneObject a = GameGlue.CreateAnimSceneObject(model.native, transform, flags, typeFlags, sceneWorld);
				if (!this.animNative.IsValid)
				{
					HandleIndex.ForceNextObject(null);
					throw new ArgumentException("Error creating AnimSceneObject - possible invalid model?");
				}
				Assert.AreEqual<SceneObject>(a, this);
			}
			finally
			{
				HandleIndex.UsedNextObject(this);
			}
		}

		// Token: 0x060013F5 RID: 5109 RVA: 0x00051584 File Offset: 0x0004F784
		internal override void OnNativeInit(CSceneObject ptr)
		{
			base.OnNativeInit(ptr);
			this.animNative = (CSceneAnimatableObject)ptr;
		}

		// Token: 0x060013F6 RID: 5110 RVA: 0x00051599 File Offset: 0x0004F799
		internal override void OnNativeDestroy()
		{
			base.OnNativeDestroy();
			this.animNative = default(CSceneAnimatableObject);
		}

		// Token: 0x060013F7 RID: 5111 RVA: 0x000515AD File Offset: 0x0004F7AD
		public void SetBoneWorldTransform(int boneIndex, Transform transform)
		{
			this.animNative.SetWorldSpaceRenderBoneTransform(boneIndex, transform);
		}

		// Token: 0x060013F8 RID: 5112 RVA: 0x000515BC File Offset: 0x0004F7BC
		public Transform GetBoneWorldTransform(int boneIndex)
		{
			return this.animNative.GetWorldSpaceRenderBoneTransform(boneIndex);
		}

		// Token: 0x060013F9 RID: 5113 RVA: 0x000515CA File Offset: 0x0004F7CA
		public Transform GetBoneWorldTransform(string boneName)
		{
			return this.animNative.GetWorldSpaceRenderBoneTransform(boneName);
		}

		/// <summary>
		/// The current animation time.
		/// </summary>
		// Token: 0x170002ED RID: 749
		// (get) Token: 0x060013FA RID: 5114 RVA: 0x000515D8 File Offset: 0x0004F7D8
		// (set) Token: 0x060013FB RID: 5115 RVA: 0x000515E0 File Offset: 0x0004F7E0
		internal float AnimationTime { get; set; }

		/// <summary>
		/// Update this animation. Delta is the time you want to advance, usually RealTime.Delta
		/// </summary>
		// Token: 0x060013FC RID: 5116 RVA: 0x000515E9 File Offset: 0x0004F7E9
		public void Update(float delta)
		{
			this.AnimationTime += delta;
			this.animNative.Update(this.AnimationTime);
		}

		// Token: 0x060013FD RID: 5117 RVA: 0x0005160A File Offset: 0x0004F80A
		public void SetAnimBool(string name, bool value)
		{
			this.animNative.SetGraphParameter(name, value);
		}

		// Token: 0x060013FE RID: 5118 RVA: 0x00051619 File Offset: 0x0004F819
		public void SetAnimFloat(string name, float value)
		{
			this.animNative.SetGraphParameter(name, value);
		}

		// Token: 0x060013FF RID: 5119 RVA: 0x00051628 File Offset: 0x0004F828
		public void SetAnimVector(string name, Vector3 value)
		{
			this.animNative.SetGraphParameter(name, value);
		}

		// Token: 0x06001400 RID: 5120 RVA: 0x00051637 File Offset: 0x0004F837
		public void SetAnimInt(string name, int value)
		{
			this.animNative.SetGraphParameter(name, value);
		}

		/// <summary>
		/// Set material group to replace materials of the model
		/// </summary>
		// Token: 0x06001401 RID: 5121 RVA: 0x00051646 File Offset: 0x0004F846
		public void SetMaterialGroup(string name)
		{
			this.animNative.SetMaterialGroup(name);
		}

		/// <summary>
		/// Set which body group to use
		/// </summary>
		// Token: 0x06001402 RID: 5122 RVA: 0x00051654 File Offset: 0x0004F854
		public void SetBodyGroup(string name, int value)
		{
			this.animNative.SetBodyGroup(name, value);
		}

		// Token: 0x040004AA RID: 1194
		private CSceneAnimatableObject animNative;
	}
}
