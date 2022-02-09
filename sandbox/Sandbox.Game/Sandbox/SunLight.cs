using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020000BB RID: 187
	[Library]
	public class SunLight : Light
	{
		// Token: 0x060011AA RID: 4522 RVA: 0x0004B03C File Offset: 0x0004923C
		public SunLight()
		{
			Host.AssertClientOrMenu(".ctor");
			this.ConnectOrCreateThisNative();
		}

		// Token: 0x060011AB RID: 4523 RVA: 0x0004B054 File Offset: 0x00049254
		public SunLight(Vector3 position, Color color)
		{
			Host.AssertClientOrMenu(".ctor");
			this.ConnectOrCreateThisNative();
		}

		/// <summary>
		/// Fetch the current sunlight from the world if such exists, if not, create a new sunlight
		/// </summary>
		// Token: 0x060011AC RID: 4524 RVA: 0x0004B06C File Offset: 0x0004926C
		internal void ConnectOrCreateThisNative()
		{
			CSceneLightObject sunLightObjNative = SceneWorld.Current.native.GetFirstVisibleSunLight().lightNative;
			if (sunLightObjNative.IsNull)
			{
				this.CreateThisNative(default(Vector3), default(Color), 0f);
				return;
			}
			this.lightNative = sunLightObjNative;
		}

		// Token: 0x060011AD RID: 4525 RVA: 0x0004B0BC File Offset: 0x000492BC
		internal override void CreateThisNative(Vector3 pos, Color color, float radius)
		{
			try
			{
				HandleIndex.ForceNextObject(this);
				CSceneSystem.CreateLight(this.lightDesc, SceneWorld.Current, false);
			}
			finally
			{
				HandleIndex.UsedNextObject(this);
			}
		}
	}
}
