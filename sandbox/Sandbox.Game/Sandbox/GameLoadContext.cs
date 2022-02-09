using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;
using Sandbox.Internal;

namespace Sandbox
{
	/// <summary>
	/// This context is used to load the assemblies that are compiled as addons.
	/// We use this because it inherits from this sandbox.game context - so any dlls
	/// that are referenced will be passed down as the right instance.
	/// </summary>
	// Token: 0x02000066 RID: 102
	internal class GameLoadContext : AssemblyLoadContext
	{
		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000BDA RID: 3034 RVA: 0x0003DE0B File Offset: 0x0003C00B
		// (set) Token: 0x06000BDB RID: 3035 RVA: 0x0003DE13 File Offset: 0x0003C013
		private AssemblyLoadContext Parent { get; set; }

		// Token: 0x06000BDC RID: 3036 RVA: 0x0003DE1C File Offset: 0x0003C01C
		public GameLoadContext(string name)
			: base(name, true)
		{
			this.Parent = AssemblyLoadContext.GetLoadContext(GlobalGameNamespace.Global.Assembly);
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x0003DE3B File Offset: 0x0003C03B
		protected override Assembly Load(AssemblyName assemblyName)
		{
			return this.Parent.LoadFromAssemblyName(assemblyName);
		}

		// Token: 0x06000BDE RID: 3038 RVA: 0x0003DE49 File Offset: 0x0003C049
		protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
		{
			GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("LoadUnmanagedDll {0}", new object[] { unmanagedDllName }));
			return IntPtr.Zero;
		}
	}
}
