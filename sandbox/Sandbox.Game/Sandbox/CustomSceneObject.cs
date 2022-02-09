using System;
using NativeEngine;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x020000F0 RID: 240
	public class CustomSceneObject : SceneObject
	{
		// Token: 0x06001403 RID: 5123 RVA: 0x00051663 File Offset: 0x0004F863
		internal CustomSceneObject(HandleCreationData _)
		{
		}

		// Token: 0x06001404 RID: 5124 RVA: 0x0005166C File Offset: 0x0004F86C
		public CustomSceneObject()
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
				Assert.AreEqual<CustomSceneObject>(CManagedSceneObject.Create(sceneWorld), this);
			}
			finally
			{
				HandleIndex.UsedNextObject(this);
			}
		}

		// Token: 0x06001405 RID: 5125 RVA: 0x000516D8 File Offset: 0x0004F8D8
		internal override void OnNativeInit(CSceneObject ptr)
		{
			base.OnNativeInit(ptr);
			this.managedNative = (CManagedSceneObject)ptr;
		}

		// Token: 0x06001406 RID: 5126 RVA: 0x000516ED File Offset: 0x0004F8ED
		internal override void OnNativeDestroy()
		{
			base.OnNativeDestroy();
			this.managedNative = default(CManagedSceneObject);
		}

		// Token: 0x06001407 RID: 5127 RVA: 0x00051704 File Offset: 0x0004F904
		internal void RenderInternal()
		{
			if (!this.IsValid())
			{
				return;
			}
			try
			{
				this.RenderSceneObject();
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Error(e);
			}
		}

		// Token: 0x06001408 RID: 5128 RVA: 0x00051744 File Offset: 0x0004F944
		public virtual void RenderSceneObject()
		{
			Action<SceneObject> renderOverride = this.RenderOverride;
			if (renderOverride == null)
			{
				return;
			}
			renderOverride(this);
		}

		// Token: 0x040004AC RID: 1196
		private CManagedSceneObject managedNative;

		// Token: 0x040004AD RID: 1197
		public Action<SceneObject> RenderOverride;
	}
}
