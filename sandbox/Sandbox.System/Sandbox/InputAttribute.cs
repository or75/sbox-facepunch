using System;
using System.Linq;
using System.Reflection;
using Sandbox.Internal;

namespace Sandbox
{
	/// <summary>
	/// Makes this method available as a Map Logic Input, for use in the Hammer Editor. This is only applicable to entities.
	/// </summary>
	// Token: 0x02000031 RID: 49
	[AttributeUsage(AttributeTargets.Method)]
	public class InputAttribute : Attribute
	{
		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600029A RID: 666 RVA: 0x0000B022 File Offset: 0x00009222
		// (set) Token: 0x0600029B RID: 667 RVA: 0x0000B02A File Offset: 0x0000922A
		public string Name { get; set; }

		/// <summary>
		/// Automatically provided using the comment for the method this is attached to.
		/// </summary>
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600029C RID: 668 RVA: 0x0000B033 File Offset: 0x00009233
		// (set) Token: 0x0600029D RID: 669 RVA: 0x0000B03B File Offset: 0x0000923B
		public string Help { get; internal set; }

		// Token: 0x0600029E RID: 670 RVA: 0x0000B044 File Offset: 0x00009244
		public InputAttribute()
		{
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000B04C File Offset: 0x0000924C
		[Obsolete("Provide help using a documentation comment instead of via the attribute")]
		public InputAttribute(string name, string help)
			: this(name)
		{
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000B055 File Offset: 0x00009255
		public InputAttribute(string name)
		{
			this.Name = name.Replace(" ", "").Replace("\t", "");
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000B084 File Offset: 0x00009284
		internal virtual void InitFromMember(MethodInfo prop, LibraryAttribute library)
		{
			this.Owner = library;
			this.MethodInfo = prop;
			if (string.IsNullOrEmpty(this.Name))
			{
				this.Name = prop.Name;
			}
			DescriptionAttribute desc = prop.GetCustomAttributes<DescriptionAttribute>().FirstOrDefault<DescriptionAttribute>();
			if (desc != null)
			{
				this.Help = desc.Value;
			}
		}

		// Token: 0x0400008A RID: 138
		internal MethodInfo MethodInfo;

		// Token: 0x0400008B RID: 139
		internal LibraryAttribute Owner;
	}
}
