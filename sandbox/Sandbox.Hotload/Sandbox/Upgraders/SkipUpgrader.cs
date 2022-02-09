using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sandbox.Upgraders
{
	// Token: 0x0200001D RID: 29
	[UpgraderGroup(typeof(ReferenceTypeUpgraderGroup), GroupOrder.First)]
	[AttemptBefore(new Type[] { typeof(CachedUpgrader) })]
	internal class SkipUpgrader : Hotload.InstanceUpgrader
	{
		// Token: 0x060000D6 RID: 214 RVA: 0x0000603B File Offset: 0x0000423B
		private bool IsGenericArgumentSkippable(Type type)
		{
			return type.IsPrimitive || ((type.IsValueType || type.IsSealed) && this.ShouldProcessType(type));
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00006060 File Offset: 0x00004260
		public override bool ShouldProcessType(Type type)
		{
			if (SkipUpgrader.AdditionalSkipableTypes.Contains(type))
			{
				return true;
			}
			if (base.GetNewType(type) != type)
			{
				return false;
			}
			if (type.IsConstructedGenericType)
			{
				Type genericType = type.GetGenericTypeDefinition();
				return this.ShouldProcessType(genericType) && type.GetGenericArguments().All(new Func<Type, bool>(this.IsGenericArgumentSkippable));
			}
			return base.IsAssemblyIgnored(type.Assembly) || type.GetCustomAttribute<Hotload.SkipAttribute>() != null;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000060DA File Offset: 0x000042DA
		protected override bool OnTryCreateNewInstance(object oldInstance, object context, out object newInstance)
		{
			newInstance = oldInstance;
			return true;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000060E0 File Offset: 0x000042E0
		protected override bool OnTryUpgradeInstance(object oldInstance, object newInstance, bool createdElsewhere)
		{
			return true;
		}

		/// <summary>
		/// Types that we can safely skip, that we can't add a <see cref="T:Sandbox.Hotload.SkipAttribute" /> to.
		/// </summary>
		// Token: 0x0400003A RID: 58
		private static readonly HashSet<Type> AdditionalSkipableTypes = new HashSet<Type>
		{
			typeof(string),
			typeof(Guid),
			typeof(decimal),
			typeof(Dictionary<, >),
			typeof(List<>),
			typeof(Queue<>),
			typeof(HashSet<>)
		};
	}
}
