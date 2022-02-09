using System;
using System.Reflection;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x02000075 RID: 117
	internal class GameConVar : Command
	{
		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000C90 RID: 3216 RVA: 0x000409E4 File Offset: 0x0003EBE4
		public bool IsSaved
		{
			get
			{
				if (Host.IsMenuOrClient)
				{
					ConsoleVariableAttribute cv = this.attribute as ConsoleVariableAttribute;
					if (cv != null)
					{
						return cv.Saved;
					}
				}
				return false;
			}
		}

		// Token: 0x06000C91 RID: 3217 RVA: 0x00040A0F File Offset: 0x0003EC0F
		public GameConVar(Assembly assembly, MemberInfo member, ConVar.BaseAttribute attribute)
			: base(assembly, member, attribute)
		{
		}

		// Token: 0x06000C92 RID: 3218 RVA: 0x00040A1C File Offset: 0x0003EC1C
		public override object Run(string argstring, int client)
		{
			PropertyInfo propertyInfo = this.member as PropertyInfo;
			if (propertyInfo == null)
			{
				return null;
			}
			if (argstring == null || argstring.Length == 0)
			{
				return this.Value;
			}
			propertyInfo.SetValue(null, argstring.ToType(propertyInfo.PropertyType));
			if (this.IsSaved)
			{
				this.Save();
			}
			return this.Value;
		}

		// Token: 0x06000C93 RID: 3219 RVA: 0x00040A73 File Offset: 0x0003EC73
		public bool TryLoad(out string loaded)
		{
			loaded = null;
			return this.IsSaved && GlobalGameNamespace.Cookie.TryGetString("convar." + base.Name, out loaded);
		}

		// Token: 0x06000C94 RID: 3220 RVA: 0x00040A9D File Offset: 0x0003EC9D
		public void Save()
		{
			if (!this.IsSaved)
			{
				return;
			}
			GlobalGameNamespace.Cookie.SetString("convar." + base.Name, this.Value);
		}
	}
}
