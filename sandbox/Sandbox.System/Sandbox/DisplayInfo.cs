using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Sandbox
{
	// Token: 0x02000056 RID: 86
	public struct DisplayInfo
	{
		// Token: 0x060003C3 RID: 963 RVA: 0x0001DB37 File Offset: 0x0001BD37
		public static DisplayInfo ForType(Type t, bool inherit = true)
		{
			return DisplayInfo.ForMember(t, inherit);
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0001DB40 File Offset: 0x0001BD40
		public static DisplayInfo For(object t, bool inherit = true)
		{
			return DisplayInfo.ForType((t != null) ? t.GetType() : null, inherit);
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x0001DB54 File Offset: 0x0001BD54
		public static DisplayInfo ForProperty(PropertyInfo t, bool inherit = true)
		{
			return DisplayInfo.ForMember(t, inherit);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0001DB60 File Offset: 0x0001BD60
		public static DisplayInfo ForMember(MemberInfo t, bool inherit = true)
		{
			if (t == null)
			{
				return default(DisplayInfo);
			}
			DisplayInfo info = default(DisplayInfo);
			info.Name = t.Name;
			info.Browsable = true;
			DisplayAttribute display = t.GetCustomAttribute(inherit);
			if (display != null)
			{
				info.Name = display.Name ?? t.Name;
				info.Group = display.GroupName ?? info.Group;
				info.Description = display.Description ?? info.Description;
				info.Order = display.GetOrder() ?? info.Order;
			}
			IconAttribute icon = t.GetCustomAttribute(inherit);
			if (icon != null)
			{
				info.Icon = icon.Value ?? info.Icon;
			}
			TitleAttribute title = t.GetCustomAttribute(inherit);
			if (title != null)
			{
				info.Name = title.Value ?? info.Name;
			}
			DescriptionAttribute desc = t.GetCustomAttribute(inherit);
			if (desc != null)
			{
				info.Description = desc.Value ?? info.Description;
			}
			PlaceholderAttribute placeholder = t.GetCustomAttribute(inherit);
			if (placeholder != null)
			{
				info.Placeholder = placeholder.Value ?? info.Placeholder;
			}
			BrowsableAttribute browsable = t.GetCustomAttribute(inherit);
			if (browsable != null)
			{
				info.Browsable = browsable.Browsable;
			}
			return info;
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0001DCC0 File Offset: 0x0001BEC0
		public static DisplayInfo[] ForEnumValues(Type t)
		{
			return (from x in t.GetEnumNames()
				select DisplayInfo.ForMember(t.GetMember(x).First<MemberInfo>(), true)).ToArray<DisplayInfo>();
		}

		// Token: 0x040008C2 RID: 2242
		public string Name;

		// Token: 0x040008C3 RID: 2243
		public string Description;

		// Token: 0x040008C4 RID: 2244
		public string Group;

		// Token: 0x040008C5 RID: 2245
		public string Icon;

		// Token: 0x040008C6 RID: 2246
		public int Order;

		// Token: 0x040008C7 RID: 2247
		public bool Browsable;

		// Token: 0x040008C8 RID: 2248
		public string Placeholder;
	}
}
