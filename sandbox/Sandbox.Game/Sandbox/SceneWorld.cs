using System;
using System.Collections.Generic;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020000F5 RID: 245
	public class SceneWorld : IHandle
	{
		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06001462 RID: 5218 RVA: 0x00052141 File Offset: 0x00050341
		// (set) Token: 0x06001463 RID: 5219 RVA: 0x00052149 File Offset: 0x00050349
		internal List<SceneObject> InternalSceneObjects { get; set; } = new List<SceneObject>();

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06001464 RID: 5220 RVA: 0x00052152 File Offset: 0x00050352
		public IReadOnlyList<SceneObject> SceneObjects
		{
			get
			{
				return this.InternalSceneObjects;
			}
		}

		// Token: 0x06001465 RID: 5221 RVA: 0x0005215A File Offset: 0x0005035A
		void IHandle.HandleInit(IntPtr ptr)
		{
			this.OnNativeInit(ptr);
		}

		// Token: 0x06001466 RID: 5222 RVA: 0x00052168 File Offset: 0x00050368
		void IHandle.HandleDestroy()
		{
			this.OnNativeDestroy();
		}

		// Token: 0x06001467 RID: 5223 RVA: 0x00052170 File Offset: 0x00050370
		bool IHandle.HandleValid()
		{
			return !this.native.IsNull;
		}

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x06001468 RID: 5224 RVA: 0x00052180 File Offset: 0x00050380
		public static SceneWorld Current
		{
			get
			{
				return SceneWorld.current ?? GameGlue.GetCurrentSceneWorld(Host.IsMenu);
			}
		}

		// Token: 0x06001469 RID: 5225 RVA: 0x00052195 File Offset: 0x00050395
		internal SceneWorld(HandleCreationData _)
		{
		}

		// Token: 0x0600146A RID: 5226 RVA: 0x000521A8 File Offset: 0x000503A8
		public SceneWorld()
		{
			this.CreateThisNative();
		}

		// Token: 0x0600146B RID: 5227 RVA: 0x000521C2 File Offset: 0x000503C2
		[Obsolete("use `new SceneWorld()` instead")]
		public static SceneWorld Create()
		{
			return new SceneWorld();
		}

		// Token: 0x0600146C RID: 5228 RVA: 0x000521CC File Offset: 0x000503CC
		private SceneWorld CreateThisNative()
		{
			Host.AssertClientOrMenu("CreateThisNative");
			SceneWorld result;
			try
			{
				HandleIndex.ForceNextObject(this);
				SceneWorld sceneWorld = GameGlue.CreateSceneWorld(Host.IsMenu);
				Assert.AreEqual<SceneWorld>(sceneWorld, this);
				sceneWorld.canDelete = true;
				result = sceneWorld;
			}
			finally
			{
				HandleIndex.UsedNextObject(this);
			}
			return result;
		}

		// Token: 0x0600146D RID: 5229 RVA: 0x0005221C File Offset: 0x0005041C
		public void Delete()
		{
			if (this.native.IsValid && this.canDelete)
			{
				GameGlue.DestroySceneWorld(this);
			}
		}

		// Token: 0x0600146E RID: 5230 RVA: 0x0005223C File Offset: 0x0005043C
		public static IDisposable SetCurrent(SceneWorld world)
		{
			if (world == null || world.native.IsNull)
			{
				return null;
			}
			SceneWorld previous = SceneWorld.current;
			SceneWorld.current = world;
			GameGlue.CurrentSceneWorldChanged(SceneWorld.current);
			return new SceneWorld.SceneWorldScope
			{
				previous = previous
			};
		}

		// Token: 0x0600146F RID: 5231 RVA: 0x00052287 File Offset: 0x00050487
		internal virtual void OnNativeInit(ISceneWorld ptr)
		{
			this.native = ptr;
		}

		// Token: 0x06001470 RID: 5232 RVA: 0x00052290 File Offset: 0x00050490
		internal virtual void OnNativeDestroy()
		{
			this.native = IntPtr.Zero;
		}

		// Token: 0x040004C1 RID: 1217
		internal ISceneWorld native;

		// Token: 0x040004C2 RID: 1218
		private static SceneWorld current;

		// Token: 0x040004C3 RID: 1219
		private bool canDelete;

		// Token: 0x02000267 RID: 615
		private struct SceneWorldScope : IDisposable
		{
			// Token: 0x06001EE2 RID: 7906 RVA: 0x00076F12 File Offset: 0x00075112
			public void Dispose()
			{
				SceneWorld.current = this.previous;
				GameGlue.CurrentSceneWorldChanged(SceneWorld.current);
			}

			// Token: 0x0400122D RID: 4653
			public SceneWorld previous;
		}
	}
}
