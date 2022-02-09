using System;
using Sandbox;
using Sandbox.Engine;

// Token: 0x02000007 RID: 7
public static class AssemblyInitialize
{
	// Token: 0x06000014 RID: 20 RVA: 0x00002408 File Offset: 0x00000608
	public static void Initialize()
	{
		Host.Init("menu");
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
		GameAssemblyManager.AccessConfig = "/config/accessgroups/menu.txt";
		IMenuDll.Current = new MenuDll();
	}
}
