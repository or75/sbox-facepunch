using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace Sandbox.Engine
{
	/// <summary>
	/// A LoadContext holds a bunch of instanced assemblies. These assemblies and the types within
	/// are seperate from each other. This means we can load two Sandbox.Event dlls and the globals
	/// will be different in both. This is good for different realms of addons where we want them to
	/// all be separate.
	/// </summary>
	// Token: 0x020002FB RID: 763
	internal class SandboxedLoadContext : AssemblyLoadContext
	{
		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x06001447 RID: 5191 RVA: 0x0002B262 File Offset: 0x00029462
		// (set) Token: 0x06001448 RID: 5192 RVA: 0x0002B26A File Offset: 0x0002946A
		protected string EnginePath { get; set; }

		// Token: 0x06001449 RID: 5193 RVA: 0x0002B274 File Offset: 0x00029474
		public SandboxedLoadContext(string assemblyName)
		{
			this.EnginePath = Path.GetDirectoryName(typeof(SandboxedLoadContext).Assembly.Location);
			this.AddAssembly("Sandbox.Event");
			this.AddAssembly("Sandbox.Reflection");
			this.AddAssembly("Sandbox.Game");
			this.AddAssembly(assemblyName);
			this.Get(assemblyName).GetType("AssemblyInitialize").GetMethod("Initialize")
				.Invoke(null, null);
		}

		// Token: 0x0600144A RID: 5194 RVA: 0x0002B2FC File Offset: 0x000294FC
		protected void AddAssembly(string v)
		{
			this.Lookup[v] = base.LoadFromAssemblyPath(this.EnginePath + "\\" + v + ".dll");
		}

		// Token: 0x0600144B RID: 5195 RVA: 0x0002B328 File Offset: 0x00029528
		public Assembly Get(string name)
		{
			Assembly assembly;
			if (this.Lookup.TryGetValue(name, out assembly))
			{
				return assembly;
			}
			return null;
		}

		// Token: 0x0600144C RID: 5196 RVA: 0x0002B348 File Offset: 0x00029548
		protected override Assembly Load(AssemblyName assemblyName)
		{
			return this.Get(assemblyName.Name);
		}

		// Token: 0x0400153E RID: 5438
		public Dictionary<string, Assembly> Lookup = new Dictionary<string, Assembly>();
	}
}
