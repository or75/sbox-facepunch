using System;

namespace Sandbox
{
	// Token: 0x02000101 RID: 257
	public static class NullChecks
	{
		// Token: 0x060014FE RID: 5374 RVA: 0x00053B80 File Offset: 0x00051D80
		public static bool IsValid(this Client obj)
		{
			ClientEntity ent = obj as ClientEntity;
			return ent != null && ent.IsValid;
		}

		// Token: 0x060014FF RID: 5375 RVA: 0x00053B9F File Offset: 0x00051D9F
		public static bool IsValid(this PhysicsBody obj)
		{
			return obj != null && !obj.native.IsNull;
		}

		// Token: 0x06001500 RID: 5376 RVA: 0x00053BB4 File Offset: 0x00051DB4
		public static bool IsValid(this PhysicsShape obj)
		{
			return obj != null && !obj.native.IsNull;
		}

		// Token: 0x06001501 RID: 5377 RVA: 0x00053BC9 File Offset: 0x00051DC9
		public static bool IsValid(this PhysicsJoint obj)
		{
			return obj != null && !obj.native.IsNull;
		}

		// Token: 0x06001502 RID: 5378 RVA: 0x00053BDE File Offset: 0x00051DDE
		public static bool IsValid(this SceneObject obj)
		{
			return obj != null && !obj.native.IsNull;
		}
	}
}
