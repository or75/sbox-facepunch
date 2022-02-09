using System;

namespace Sandbox.UI.Construct
{
	// Token: 0x02000154 RID: 340
	public static class SceneConstructor
	{
		// Token: 0x060019AA RID: 6570 RVA: 0x0006BDD8 File Offset: 0x00069FD8
		[Obsolete("Use ScenePanel instead")]
		public static ScenePanel Scene(this PanelCreator self, SceneWorld world, Vector3 position, Angles angles, float fieldOfView, string classname = null)
		{
			ScenePanel control = self.panel.AddChild<ScenePanel>(null);
			control.World = world;
			control.Position = position;
			control.Angles = angles;
			control.FieldOfView = fieldOfView;
			control.Ortho = false;
			if (classname != null)
			{
				control.AddClass(classname);
			}
			return control;
		}

		// Token: 0x060019AB RID: 6571 RVA: 0x0006BE24 File Offset: 0x0006A024
		public static ScenePanel ScenePanel(this PanelCreator self, SceneWorld world, Vector3 position, Rotation rotation, float fieldOfView, string classname = null)
		{
			ScenePanel control = self.panel.AddChild<ScenePanel>(null);
			control.World = world;
			control.CameraPosition = position;
			control.CameraRotation = rotation;
			control.FieldOfView = fieldOfView;
			control.Ortho = false;
			if (classname != null)
			{
				control.AddClass(classname);
			}
			return control;
		}

		// Token: 0x060019AC RID: 6572 RVA: 0x0006BE70 File Offset: 0x0006A070
		public static ScenePanel ScenePanel(this PanelCreator self, SceneWorld world, Vector3 position, Rotation rotation, float fieldOfView, bool bOrtho, string classname = null)
		{
			ScenePanel control = self.panel.AddChild<ScenePanel>(null);
			control.World = world;
			control.CameraPosition = position;
			control.CameraRotation = rotation;
			control.FieldOfView = fieldOfView;
			control.Ortho = bOrtho;
			if (classname != null)
			{
				control.AddClass(classname);
			}
			return control;
		}
	}
}
