using System;
using System.Reflection;

namespace Sandbox
{
	// Token: 0x02000046 RID: 70
	public static class ReflectionExtensions
	{
		/// <summary>
		/// Returns true if this member has this attribute
		/// </summary>
		// Token: 0x06000341 RID: 833 RVA: 0x0000C7C4 File Offset: 0x0000A9C4
		internal static bool HasAttribute(this MemberInfo method, Type attribute)
		{
			return method != null && method.IsDefined(attribute, true);
		}

		/// <summary>
		/// Returns true if this type derives from a type named name
		/// </summary>
		// Token: 0x06000342 RID: 834 RVA: 0x0000C7D3 File Offset: 0x0000A9D3
		internal static bool HasBaseType(this Type type, string name)
		{
			return !(type.BaseType == null) && (type.BaseType.FullName == name || type.BaseType.HasBaseType(name));
		}
	}
}
