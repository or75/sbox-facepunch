using System;
using System.Collections.Generic;
using System.Reflection;
using NativeEngine;
using Sandbox.Engine;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x02000078 RID: 120
	internal abstract class ContextInterface : IBaseDll
	{
		// Token: 0x06000C9E RID: 3230
		public abstract void Init();

		// Token: 0x06000C9F RID: 3231 RVA: 0x00040C7A File Offset: 0x0003EE7A
		public virtual void Tick()
		{
			Schedule.Run();
			Prediction.Tick();
			GlobalGameNamespace.Global.IsListenServer = EngineGlue.IsListenServer();
		}

		// Token: 0x06000CA0 RID: 3232 RVA: 0x00040C95 File Offset: 0x0003EE95
		internal void OnNewAssembly(Assembly newAssembly, Assembly oldAssembly)
		{
			if (oldAssembly != null)
			{
				ContextInterface.RemoveAssembly(oldAssembly);
			}
			if (newAssembly != null)
			{
				ContextInterface.AddAssembly(newAssembly);
			}
			Event.RegisterAssembly(oldAssembly, newAssembly);
		}

		/// <summary>
		/// The current game has shut down
		/// </summary>
		// Token: 0x06000CA1 RID: 3233 RVA: 0x00040CBC File Offset: 0x0003EEBC
		internal virtual void OnShutdown()
		{
		}

		/// <summary>
		/// Create the data folders and the basefilesystem's for the gamemode folder
		/// </summary>
		// Token: 0x06000CA2 RID: 3234 RVA: 0x00040CC0 File Offset: 0x0003EEC0
		public void InitGamemodeData(string name)
		{
			string[] parts = name.Split('.', 2, StringSplitOptions.None);
			if (parts.Length == 2)
			{
				EngineFileSystem.Data.CreateDirectory(parts[0]);
				FileSystem.OrganizationData = EngineFileSystem.Data.CreateSubSystem(parts[0]);
				FileSystem.OrganizationData.CreateDirectory(parts[1]);
				FileSystem.Data = FileSystem.OrganizationData.CreateSubSystem(parts[1]);
				return;
			}
			if (parts.Length == 1)
			{
				EngineFileSystem.Data.CreateDirectory(".local");
				FileSystem.OrganizationData = EngineFileSystem.Data.CreateSubSystem(".local");
				FileSystem.OrganizationData.CreateDirectory(parts[0]);
				FileSystem.Data = FileSystem.OrganizationData.CreateSubSystem(parts[0]);
			}
		}

		// Token: 0x06000CA3 RID: 3235 RVA: 0x00040D65 File Offset: 0x0003EF65
		public void RunEvent(string name)
		{
			Event.Run(name);
		}

		// Token: 0x06000CA4 RID: 3236 RVA: 0x00040D6D File Offset: 0x0003EF6D
		public void RunEvent(string name, object argument)
		{
			Event.Run<object>(name, argument);
		}

		// Token: 0x06000CA5 RID: 3237 RVA: 0x00040D76 File Offset: 0x0003EF76
		public void Exiting()
		{
			Event.Run("app.exit");
			CookieContainer cookie = GlobalGameNamespace.Cookie;
			if (cookie == null)
			{
				return;
			}
			cookie.Save();
		}

		// Token: 0x06000CA6 RID: 3238 RVA: 0x00040D94 File Offset: 0x0003EF94
		internal static void RemoveAssembly(Assembly oldAssembly)
		{
			foreach (AssemblyWrapper a in ContextInterface.LoadedAssemblies)
			{
				if (a.Assembly == oldAssembly)
				{
					ContextInterface.LoadedAssemblies.Remove(a);
					a.Dispose();
					break;
				}
			}
		}

		// Token: 0x06000CA7 RID: 3239 RVA: 0x00040E04 File Offset: 0x0003F004
		internal static void AddAssembly(Assembly newAssembly)
		{
			AssemblyWrapper a = new AssemblyWrapper(newAssembly);
			ContextInterface.LoadedAssemblies.Add(a);
		}

		// Token: 0x06000CA8 RID: 3240 RVA: 0x00040E24 File Offset: 0x0003F024
		internal void OnGlobalRPC(int identifier, NetRead read)
		{
			foreach (AssemblyWrapper assembly in ContextInterface.LoadedAssemblies)
			{
				if (assembly.OnRPC != null && assembly.OnRPC(identifier, read))
				{
					break;
				}
			}
		}

		// Token: 0x040001B7 RID: 439
		public static List<AssemblyWrapper> LoadedAssemblies = new List<AssemblyWrapper>();
	}
}
