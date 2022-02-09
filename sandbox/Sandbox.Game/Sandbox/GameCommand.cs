using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x02000074 RID: 116
	internal class GameCommand : Command
	{
		// Token: 0x06000C8E RID: 3214 RVA: 0x000408B8 File Offset: 0x0003EAB8
		public GameCommand(Assembly assembly, MemberInfo member, ConVar.BaseAttribute attribute)
			: base(assembly, member, attribute)
		{
		}

		// Token: 0x06000C8F RID: 3215 RVA: 0x000408C4 File Offset: 0x0003EAC4
		public override object Run(string argstring, int client)
		{
			MethodInfo method = this.member as MethodInfo;
			if (method != null)
			{
				if (method == null)
				{
					throw new Exception("ConsoleCommand is not a Method");
				}
				object[] callargs = new object[this.parameters.Length];
				string[] args = argstring.SplitQuotesStrings();
				int argIndex = 0;
				for (int i = 0; i < this.parameters.Length; i++)
				{
					if (argIndex < ((args != null) ? args.Length : 0))
					{
						callargs[i] = args[argIndex].ToType(this.parameters[i].ParameterType);
						argIndex++;
					}
					else
					{
						if (!this.parameters[i].HasDefaultValue)
						{
							throw new Exception("Not enough arguments");
						}
						callargs[i] = this.parameters[i].DefaultValue;
					}
				}
				try
				{
					object val = method.Invoke(null, callargs);
					if (val == null)
					{
						val = true;
					}
					return val;
				}
				catch (Exception e)
				{
					GlobalGameNamespace.Log.Error(e.InnerException, FormattableStringFactory.Create("Exception when calling command \"{0}\"", new object[] { base.Name }));
					return e;
				}
			}
			return null;
		}
	}
}
