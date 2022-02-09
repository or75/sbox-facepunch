using System;
using System.Collections.Generic;
using Sandbox;
using Sandbox.Internal;

namespace Tools
{
	// Token: 0x02000080 RID: 128
	[AttributeUsage(AttributeTargets.Class)]
	public class ToolAttribute : Attribute
	{
		// Token: 0x0600131E RID: 4894 RVA: 0x00052C2C File Offset: 0x00050E2C
		public static void RegisterType(Type t, ToolAttribute attr)
		{
			if (!t.IsAssignableTo(typeof(Window)))
			{
				return;
			}
			attr.Type = t;
			ToolAttribute.All.Add(attr);
			ToolAttribute.Dirty = true;
		}

		// Token: 0x0600131F RID: 4895 RVA: 0x00052C5C File Offset: 0x00050E5C
		public static void UnregisterType(Type t, ToolAttribute attr)
		{
			ToolAttribute.All.RemoveAll((ToolAttribute x) => x.Type == t);
			ToolAttribute.Dirty = true;
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06001320 RID: 4896 RVA: 0x00052C93 File Offset: 0x00050E93
		// (set) Token: 0x06001321 RID: 4897 RVA: 0x00052C9B File Offset: 0x00050E9B
		public string Title { get; set; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06001322 RID: 4898 RVA: 0x00052CA4 File Offset: 0x00050EA4
		// (set) Token: 0x06001323 RID: 4899 RVA: 0x00052CAC File Offset: 0x00050EAC
		public string Icon { get; set; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06001324 RID: 4900 RVA: 0x00052CB5 File Offset: 0x00050EB5
		// (set) Token: 0x06001325 RID: 4901 RVA: 0x00052CBD File Offset: 0x00050EBD
		public string Description { get; set; }

		// Token: 0x06001326 RID: 4902 RVA: 0x00052CC6 File Offset: 0x00050EC6
		public ToolAttribute(string title, string icon, string description)
		{
			this.Title = title;
			this.Icon = icon;
			this.Description = description;
		}

		// Token: 0x06001327 RID: 4903 RVA: 0x00052CE3 File Offset: 0x00050EE3
		public void Open()
		{
			GlobalToolsNamespace.Reflection.CreateType<Window>(this.Type, null).Show();
		}

		// Token: 0x06001328 RID: 4904 RVA: 0x00052CFB File Offset: 0x00050EFB
		[Event.FrameAttribute]
		public static void Frame()
		{
			if (!ToolAttribute.Dirty)
			{
				return;
			}
			ToolAttribute.Dirty = false;
			Event.Run("tools.refresh");
		}

		// Token: 0x040001AD RID: 429
		private static bool Dirty;

		// Token: 0x040001AE RID: 430
		internal static List<ToolAttribute> All = new List<ToolAttribute>();

		// Token: 0x040001B2 RID: 434
		internal Type Type;
	}
}
