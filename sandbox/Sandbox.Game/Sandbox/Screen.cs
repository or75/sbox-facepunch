using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x02000103 RID: 259
	public static class Screen
	{
		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06001509 RID: 5385 RVA: 0x00053CFE File Offset: 0x00051EFE
		// (set) Token: 0x0600150A RID: 5386 RVA: 0x00053D05 File Offset: 0x00051F05
		public static Vector2 Size { get; internal set; }

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x0600150B RID: 5387 RVA: 0x00053D10 File Offset: 0x00051F10
		public static float Width
		{
			get
			{
				return Screen.Size.x;
			}
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x0600150C RID: 5388 RVA: 0x00053D2C File Offset: 0x00051F2C
		public static float Height
		{
			get
			{
				return Screen.Size.y;
			}
		}

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x0600150D RID: 5389 RVA: 0x00053D46 File Offset: 0x00051F46
		public static float Aspect
		{
			get
			{
				return Screen.Width / Screen.Height;
			}
		}

		// Token: 0x0600150E RID: 5390 RVA: 0x00053D54 File Offset: 0x00051F54
		internal static void UpdateFromEngine()
		{
			int width = 1024;
			int height = 1024;
			if (!Host.IsUnitTest)
			{
				EngineServiceMgr.GetEngineSwapChainSize(out width, out height);
			}
			Screen.Size = new Vector2((float)width, (float)height);
		}

		// Token: 0x0600150F RID: 5391 RVA: 0x00053D8C File Offset: 0x00051F8C
		public static Ray GetOrthoRay(Vector2 position)
		{
			Vector2 screenSize = Screen.Size;
			float orthoLeft = 0f;
			float orthoSize = CurrentView.OrthoSize;
			float orthoTop = -(screenSize.y * orthoSize);
			float num = screenSize.x * orthoSize;
			float orthoBottom = 0f;
			float orthoWidth = num - orthoLeft;
			float orthoHeight = orthoBottom - orthoTop;
			Vector3 cameraDirection = CurrentView.Rotation.Forward;
			Vector3 cameraPosition = CurrentView.Position;
			float x = (2f * position.x / screenSize.x - 1f) * (orthoWidth / 2f);
			float y = -(2f * position.y / screenSize.y - 1f) * (orthoHeight / 2f);
			Vector3 cameraRight = CurrentView.Rotation.Right;
			Vector3 cameraUp = CurrentView.Rotation.Up;
			return new Ray
			{
				Origin = cameraPosition + cameraRight * x + cameraUp * y,
				Direction = cameraDirection
			};
		}

		/// <summary>
		/// Gives a direction vector based on the position of the point on the screen
		/// </summary>
		// Token: 0x06001510 RID: 5392 RVA: 0x00053E8C File Offset: 0x0005208C
		public static Vector3 GetDirection(Vector2 pos)
		{
			Host.AssertClientOrMenu("GetDirection");
			return Screen.GetDirection(pos, CurrentView.FieldOfView, CurrentView.Rotation, Screen.Size);
		}

		/// <summary>
		/// Gives a direction vector based on the position of the point on the screen
		/// </summary>
		// Token: 0x06001511 RID: 5393 RVA: 0x00053EAD File Offset: 0x000520AD
		public static Vector3 GetDirection(Vector2 pos, float fov)
		{
			Host.AssertClientOrMenu("GetDirection");
			return Screen.GetDirection(pos, fov, CurrentView.Rotation, Screen.Size);
		}

		/// <summary>
		/// Gives a direction vector based on the position of the point on the screen
		/// </summary>
		// Token: 0x06001512 RID: 5394 RVA: 0x00053ECA File Offset: 0x000520CA
		public static Vector3 GetDirection(Vector2 pos, float fov, Rotation lookAngle)
		{
			Host.AssertClientOrMenu("GetDirection");
			return Screen.GetDirection(pos, fov, lookAngle, Screen.Size);
		}

		/// <summary>
		/// Gives a direction vector based on the position of the point on the screen.
		/// </summary>
		// Token: 0x06001513 RID: 5395 RVA: 0x00053EE4 File Offset: 0x000520E4
		public static Vector3 GetDirection(Vector2 pos, float fov, Rotation lookAngle, Vector2 screenSize)
		{
			float aspect = screenSize.x / screenSize.y;
			float num = MathF.Atan(MathF.Tan(fov.DegreeToRadian() * 0.5f) * (aspect * 0.75f)).RadianToDegree() * 2f;
			Vector2 posNormalized = new Vector2(2f * pos.x / screenSize.x - 1f, 2f * pos.y / screenSize.y - 1f) * -1f;
			float halfWidth = MathF.Tan(num * 3.1415927f / 360f);
			float halfHeight = halfWidth / aspect;
			return (new Vector3(1f, posNormalized.x / (1f / halfWidth), posNormalized.y / (1f / halfHeight)) * lookAngle).Normal;
		}
	}
}
