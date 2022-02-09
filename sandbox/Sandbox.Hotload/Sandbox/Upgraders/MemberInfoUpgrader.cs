using System;
using System.Linq;
using System.Reflection;

namespace Sandbox.Upgraders
{
	// Token: 0x0200001C RID: 28
	[UpgraderGroup(typeof(ReflectionUpgraderGroup), GroupOrder.Default)]
	internal class MemberInfoUpgrader : Hotload.InstanceUpgrader
	{
		// Token: 0x060000D0 RID: 208 RVA: 0x00005ECA File Offset: 0x000040CA
		public override bool ShouldProcessType(Type type)
		{
			return typeof(MemberInfo).IsAssignableFrom(type);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00005EDC File Offset: 0x000040DC
		private bool IsMatchingMember(MemberInfo a, MemberInfo b)
		{
			if (a.Name != b.Name)
			{
				return false;
			}
			if (a.GetType() != b.GetType())
			{
				return false;
			}
			if (!(a is MethodBase))
			{
				return true;
			}
			MethodBase methodBase = (MethodBase)a;
			MethodBase bMethod = (MethodBase)b;
			ParameterInfo[] aParams = methodBase.GetParameters();
			ParameterInfo[] bParams = bMethod.GetParameters();
			if (aParams.Length != bParams.Length)
			{
				return false;
			}
			for (int i = 0; i < aParams.Length; i++)
			{
				if (!(aParams[i].ParameterType == bParams[i].ParameterType) && !(base.GetNewType(aParams[i].ParameterType) == bParams[i].ParameterType))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00005F88 File Offset: 0x00004188
		private MemberInfo GetMatchingMember(MemberInfo orig, Type newType)
		{
			return newType.GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).FirstOrDefault((MemberInfo x) => this.IsMatchingMember(orig, x));
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00005FC4 File Offset: 0x000041C4
		protected override bool OnTryCreateNewInstance(object oldInstance, object context, out object newInstance)
		{
			Type oldType = oldInstance as Type;
			if (oldType != null)
			{
				newInstance = base.GetNewType(oldType);
				return true;
			}
			newInstance = oldInstance;
			MemberInfo oldMember = (MemberInfo)oldInstance;
			if (oldMember.DeclaringType == null)
			{
				return true;
			}
			Type declaringType = base.GetNewType(oldMember.DeclaringType);
			if (declaringType == oldMember.DeclaringType)
			{
				return true;
			}
			newInstance = this.GetMatchingMember(oldMember, declaringType);
			return true;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00006028 File Offset: 0x00004228
		protected override bool OnTryUpgradeInstance(object oldInstance, object newInstance, bool createdElsewhere)
		{
			base.AddCachedInstance(oldInstance, newInstance);
			return true;
		}
	}
}
