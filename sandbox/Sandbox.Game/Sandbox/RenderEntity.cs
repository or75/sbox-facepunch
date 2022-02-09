using System;
using Hammer;

namespace Sandbox
{
	// Token: 0x020000A0 RID: 160
	[Library("render_entity")]
	[Skip]
	public class RenderEntity : Entity
	{
		// Token: 0x0600107D RID: 4221 RVA: 0x0004871E File Offset: 0x0004691E
		public override void OnActive()
		{
			base.OnActive();
			if (base.IsClient)
			{
				this.CreateSceneObject();
			}
		}

		// Token: 0x0600107E RID: 4222 RVA: 0x00048734 File Offset: 0x00046934
		protected override void OnDestroy()
		{
			base.OnDestroy();
			CustomSceneObject customSceneObject = this.so;
			if (customSceneObject != null)
			{
				customSceneObject.Delete();
			}
			this.so = null;
		}

		// Token: 0x0600107F RID: 4223 RVA: 0x00048754 File Offset: 0x00046954
		internal override void ConstructClient()
		{
			base.ConstructClient();
			this.CreateSceneObject();
		}

		// Token: 0x06001080 RID: 4224 RVA: 0x00048762 File Offset: 0x00046962
		private void CreateSceneObject()
		{
			this.so = new CustomSceneObject
			{
				Transform = base.Transform,
				RenderOverride = new Action<SceneObject>(this.DoRender)
			};
		}

		// Token: 0x06001081 RID: 4225 RVA: 0x0004878E File Offset: 0x0004698E
		[Event.FrameAttribute]
		protected virtual void Think()
		{
			if (this.so == null)
			{
				return;
			}
			this.UpdateSceneObject(this.so);
		}

		/// <summary>
		/// Keep the scene object updated. By default this moves the transform to match this entity's transform
		/// and updates the bounds to the new position.
		/// </summary>
		// Token: 0x06001082 RID: 4226 RVA: 0x000487A5 File Offset: 0x000469A5
		public virtual void UpdateSceneObject(SceneObject obj)
		{
			this.so.Transform = base.Transform;
			this.so.Bounds = this.RenderBounds + this.Position;
		}

		/// <summary>
		/// Render this entity. Here's some warnings:
		/// 1. This is called in a thread. Don't create/delete/move entities in this loop
		/// 2. This can be called multiple times per frame for different scene layers. For example, once to
		/// 	draw the shadow caster, once to draw the opaque object, once to draw the transparent object.
		/// 	Obviously which of these get called depends on your object setup. Check Render.Layer to
		/// 	determine which layer is being rendered.
		/// </summary>
		// Token: 0x06001083 RID: 4227 RVA: 0x000487D4 File Offset: 0x000469D4
		public virtual void DoRender(SceneObject obj)
		{
		}

		// Token: 0x040002D0 RID: 720
		private CustomSceneObject so;

		// Token: 0x040002D1 RID: 721
		public BBox RenderBounds = new BBox(-10f, 10f);
	}
}
