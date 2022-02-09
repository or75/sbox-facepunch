using System;
using System.Reflection;

namespace Sandbox.Upgraders
{
	// Token: 0x0200001B RID: 27
	[UpgraderGroup(typeof(ReflectionUpgraderGroup), GroupOrder.Default)]
	internal class AssemblyUpgrader : Hotload.InstanceUpgrader
	{
		// Token: 0x060000CC RID: 204 RVA: 0x00005E72 File Offset: 0x00004072
		public override bool ShouldProcessType(Type type)
		{
			return typeof(Assembly).IsAssignableFrom(type);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00005E84 File Offset: 0x00004084
		protected override bool OnTryCreateNewInstance(object oldInstance, object context, out object newInstance)
		{
			Assembly oldAsm = oldInstance as Assembly;
			if (oldAsm != null)
			{
				Assembly swapAsm;
				newInstance = (base.Swaps.TryGetValue(oldAsm, out swapAsm) ? swapAsm : oldAsm);
				return true;
			}
			newInstance = oldInstance;
			return true;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00005EB7 File Offset: 0x000040B7
		protected override bool OnTryUpgradeInstance(object oldInstance, object newInstance, bool createdElsewhere)
		{
			base.AddCachedInstance(oldInstance, newInstance);
			return true;
		}
	}
}
