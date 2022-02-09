using System;
using System.Reflection;

namespace Sandbox
{
	// Token: 0x02000293 RID: 659
	internal abstract class Command
	{
		// Token: 0x060010AF RID: 4271 RVA: 0x0001F14C File Offset: 0x0001D34C
		public Command(Assembly assembly, MemberInfo member, ConVar.BaseAttribute attribute)
		{
			this.attribute = attribute;
			this.assembly = assembly;
			this.member = member;
			MethodInfo method = member as MethodInfo;
			if (method != null)
			{
				this.parameters = method.GetParameters();
			}
			ClientCmdAttribute cc = attribute as ClientCmdAttribute;
			if (cc != null)
			{
				this.CanExecuteFromServer = cc.CanBeCalledFromServer;
			}
			this.Protected = attribute.Protected;
			this.Name = attribute.Name;
			this.Help = attribute.Help;
			if (string.IsNullOrWhiteSpace(this.Name))
			{
				this.Name = member.Name;
			}
		}

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x060010B0 RID: 4272 RVA: 0x0001F1E4 File Offset: 0x0001D3E4
		internal bool IsVariable
		{
			get
			{
				return this.member is PropertyInfo;
			}
		}

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x060010B1 RID: 4273 RVA: 0x0001F1F4 File Offset: 0x0001D3F4
		// (set) Token: 0x060010B2 RID: 4274 RVA: 0x0001F1FC File Offset: 0x0001D3FC
		public string Name { get; set; }

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x060010B3 RID: 4275 RVA: 0x0001F205 File Offset: 0x0001D405
		// (set) Token: 0x060010B4 RID: 4276 RVA: 0x0001F20D File Offset: 0x0001D40D
		public string Help { get; set; }

		// Token: 0x060010B5 RID: 4277
		public abstract object Run(string args, int client);

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x060010B6 RID: 4278 RVA: 0x0001F218 File Offset: 0x0001D418
		public virtual string Value
		{
			get
			{
				PropertyInfo propertyInfo = this.member as PropertyInfo;
				if (propertyInfo == null)
				{
					return null;
				}
				object value = propertyInfo.GetValue(null);
				if (value == null)
				{
					return null;
				}
				return value.ToString();
			}
		}

		// Token: 0x060010B7 RID: 4279 RVA: 0x0001F248 File Offset: 0x0001D448
		public bool IsFromAssembly(Assembly assembly)
		{
			return assembly == this.assembly;
		}

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x060010B8 RID: 4280 RVA: 0x0001F256 File Offset: 0x0001D456
		// (set) Token: 0x060010B9 RID: 4281 RVA: 0x0001F25E File Offset: 0x0001D45E
		public virtual bool CanExecuteFromServer { get; set; }

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x060010BA RID: 4282 RVA: 0x0001F267 File Offset: 0x0001D467
		// (set) Token: 0x060010BB RID: 4283 RVA: 0x0001F26F File Offset: 0x0001D46F
		public virtual bool CanExecuteFromClient { get; set; } = true;

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x060010BC RID: 4284 RVA: 0x0001F278 File Offset: 0x0001D478
		// (set) Token: 0x060010BD RID: 4285 RVA: 0x0001F280 File Offset: 0x0001D480
		public virtual bool Protected { get; set; }

		/// <summary>
		/// Todo: Add support for managed commands to return shit here
		/// Todo: We could maybe do this in a cool way, using parameters?
		///       So that for example, we could list players if it's a player etc
		/// </summary>
		// Token: 0x060010BE RID: 4286 RVA: 0x0001F289 File Offset: 0x0001D489
		public virtual string[] GetAutoComplete(string v)
		{
			return null;
		}

		// Token: 0x04001291 RID: 4753
		internal ConVar.BaseAttribute attribute;

		// Token: 0x04001292 RID: 4754
		internal MemberInfo member;

		// Token: 0x04001293 RID: 4755
		internal Assembly assembly;

		// Token: 0x04001294 RID: 4756
		internal ParameterInfo[] parameters;
	}
}
