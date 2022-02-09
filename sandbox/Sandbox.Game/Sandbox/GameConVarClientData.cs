using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x02000076 RID: 118
	internal class GameConVarClientData : GameConVar
	{
		// Token: 0x06000C95 RID: 3221 RVA: 0x00040AC8 File Offset: 0x0003ECC8
		public GameConVarClientData(Assembly assembly, MemberInfo member, ConVar.BaseAttribute attribute)
			: base(assembly, member, attribute)
		{
			DefaultValueAttribute defaultValue = member.GetCustomAttribute<DefaultValueAttribute>();
			if (defaultValue != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<object>(defaultValue.Value);
				this.StringValue = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			PropertyInfo prop = member as PropertyInfo;
			if (prop != null)
			{
				MethodInfo get = prop.GetGetMethod();
				if (get != null && get.IsStatic)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<object>(get.Invoke(null, null));
					this.StringValue = defaultInterpolatedStringHandler.ToStringAndClear();
				}
			}
		}

		// Token: 0x06000C96 RID: 3222 RVA: 0x00040B52 File Offset: 0x0003ED52
		public override object Run(string argstring, int client)
		{
			Host.AssertClient("Run");
			this.StringValue = argstring;
			ConsoleSystem.UpdateUserData(base.Name, argstring, false);
			return null;
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000C97 RID: 3223 RVA: 0x00040B73 File Offset: 0x0003ED73
		public override string Value
		{
			get
			{
				if (Host.IsServer)
				{
					return null;
				}
				return this.StringValue;
			}
		}

		// Token: 0x040001B1 RID: 433
		private string StringValue;
	}
}
