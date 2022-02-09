using System;
using Sandbox;
using Sandbox.Engine;

// Token: 0x02000006 RID: 6
public static class AssemblyInitialize
{
	// Token: 0x06000006 RID: 6 RVA: 0x00002098 File Offset: 0x00000298
	public static void Initialize()
	{
		Host.Init("client");
		FileSystem.Mounted = new AggFileSystem();
		FileSystem.Mounted.CreateAndMount(EngineFileSystem.Addons, "/base/code/");
		FileSystem.Mounted.CreateAndMount(EngineFileSystem.Addons, "/base/");
		FileSystem.Mounted.CreateAndMount(EngineFileSystem.Addons, "/menu/code/");
		FileSystem.Mounted.CreateAndMount(EngineFileSystem.Addons, "/menu/");
		FileSystem.Mounted.CreateAndMount(EngineFileSystem.Root, "/core/");
		foreach (string folder in EngineFileSystem.Addons.FindDirectory("/", "*", false))
		{
			if (!folder.StartsWith(".") && !(folder == "base") && !(folder == "menu"))
			{
				FileSystem.Mounted.CreateAndMount(EngineFileSystem.Addons, folder);
			}
		}
		IClientDll.Current = new ClientDll();
	}
}
