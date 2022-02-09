using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using NativeEngine;
using NativeGlue;
using Sandbox.Engine;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x02000072 RID: 114
	[Hotload.SkipAttribute]
	public static class ConsoleSystem
	{
		/// <summary>
		/// Returns the player who is calling the command. This will be null
		/// if the command is being called via rcon, or triggered directly
		/// on the server.
		/// </summary>
		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000C72 RID: 3186 RVA: 0x0003FFD9 File Offset: 0x0003E1D9
		// (set) Token: 0x06000C73 RID: 3187 RVA: 0x0003FFE0 File Offset: 0x0003E1E0
		public static Client Caller { get; internal set; }

		/// <summary>
		/// Does this player have permission to do run commands that need permission
		/// </summary>
		// Token: 0x06000C74 RID: 3188 RVA: 0x0003FFE8 File Offset: 0x0003E1E8
		internal static bool HasCallerGotPermission()
		{
			if (Host.IsServer && ConsoleSystem.Caller == null)
			{
				return true;
			}
			Client caller = ConsoleSystem.Caller;
			return caller != null && caller.HasPermission("server.runcommand");
		}

		/// <summary>
		/// Given a command and parameters, build a coherent command
		/// </summary>
		// Token: 0x06000C75 RID: 3189 RVA: 0x00040018 File Offset: 0x0003E218
		public static string Build(string command, params object[] parameters)
		{
			if (parameters == null)
			{
				return command;
			}
			return command + " " + string.Join(" ", parameters.Select(delegate(object x)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<object>(x);
				return defaultInterpolatedStringHandler.ToStringAndClear().QuoteSafe();
			}));
		}

		// Token: 0x06000C76 RID: 3190 RVA: 0x00040064 File Offset: 0x0003E264
		public static void UpdateUserData(string name, object value, bool create = false)
		{
			Host.AssertClient("UpdateUserData");
			if (ConsoleSystem.Find(name) == null)
			{
				return;
			}
			EngineGlue.SendClientUserInfo(name, ((value != null) ? value.ToString() : null) ?? "");
		}

		// Token: 0x06000C77 RID: 3191 RVA: 0x00040094 File Offset: 0x0003E294
		internal static void SendUserVars()
		{
			Host.AssertClient("SendUserVars");
			foreach (KeyValuePair<string, Command> cmd in ConsoleSystem.Members)
			{
				if (cmd.Value.attribute is ConVar.ClientDataAttribute)
				{
					string key = cmd.Key;
					string value = cmd.Value.Value;
					EngineGlue.SendClientUserInfo(key, ((value != null) ? value.ToString() : null) ?? "");
				}
			}
		}

		/// <summary>
		/// Find a managed convar value
		/// </summary>
		// Token: 0x06000C78 RID: 3192 RVA: 0x0004012C File Offset: 0x0003E32C
		internal static string FindManagedValue(string name, string defaultValue = null)
		{
			Command cmd = ConsoleSystem.Find(name);
			if (cmd == null)
			{
				return defaultValue;
			}
			return cmd.Value;
		}

		/// <summary>
		/// Used by [SetValue] etc
		/// </summary>
		// Token: 0x06000C79 RID: 3193 RVA: 0x0004014C File Offset: 0x0003E34C
		public static void SetValue(string name, object value)
		{
			GameConVar convar = ConsoleSystem.Find(name) as GameConVar;
			if (convar == null)
			{
				return;
			}
			if (!convar.attribute.IsAny(Host.IsServer, Host.IsClient, Host.IsMenu))
			{
				return;
			}
			EngineGlue.SetConvarValue(name, value.ToString());
			convar.Save();
		}

		/// <summary>
		/// Get a convar value as a string
		/// </summary>
		// Token: 0x06000C7A RID: 3194 RVA: 0x00040198 File Offset: 0x0003E398
		public static string GetValue(string name, string defaultValue = null)
		{
			string v = EngineGlue.GetConvarValue(name);
			if (v == null)
			{
				return defaultValue;
			}
			return v;
		}

		/// <summary>
		/// Add this assembly to the console library, which will scan it for console commands and make them available.
		/// </summary>
		// Token: 0x06000C7B RID: 3195 RVA: 0x000401B4 File Offset: 0x0003E3B4
		internal static void AddAssembly(Assembly assembly)
		{
			if (assembly == null)
			{
				return;
			}
			foreach (Type t in assembly.GetTypes())
			{
				foreach (MethodInfo member in t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
				{
					ConVar.BaseAttribute attribute = member.GetCustomAttribute<ConVar.BaseAttribute>();
					if (attribute != null && attribute.IsAny(Host.IsServer, Host.IsClient, Host.IsMenu))
					{
						ConsoleSystem.AddCommand(new GameCommand(assembly, member, attribute));
					}
				}
				foreach (PropertyInfo member2 in t.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
				{
					MethodInfo get = member2.GetGetMethod();
					MethodInfo set = member2.GetSetMethod();
					if (!(get == null) && !(set == null))
					{
						ConVar.BaseAttribute attribute2 = member2.GetCustomAttribute<ConVar.BaseAttribute>();
						if (attribute2 != null && attribute2.IsAny(Host.IsServer, Host.IsClient, Host.IsMenu))
						{
							if (attribute2 is ConVar.ClientDataAttribute)
							{
								ConsoleSystem.AddConVar(new GameConVarClientData(assembly, member2, attribute2));
							}
							else if (get.IsStatic)
							{
								ConsoleSystem.AddConVar(new GameConVar(assembly, member2, attribute2));
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Add this convar to the library. Any existing commands named the same will be over-written.
		/// </summary>
		// Token: 0x06000C7C RID: 3196 RVA: 0x000402E8 File Offset: 0x0003E4E8
		internal static void AddConVar(GameConVar command)
		{
			ConsoleSystem.Members[command.Name] = command;
			CommandFlags flags = ConsoleSystem.GetBaseFlags();
			if (command.attribute is ConVar.ReplicatedAttribute)
			{
				flags |= CommandFlags.FCVAR_REPLICATED;
			}
			if (!(command.attribute is ConVar.ClientDataAttribute))
			{
				ConVar.MenuAttribute ma = command.attribute as ConVar.MenuAttribute;
				if (ma == null || !ma.ClientData)
				{
					goto IL_64;
				}
			}
			Host.AssertClientOrMenu("AddConVar");
			flags |= CommandFlags.FCVAR_USERINFO;
			IL_64:
			string loadedValue;
			if (command.TryLoad(out loadedValue))
			{
				command.Run(loadedValue, 0);
			}
			string value = ConsoleSystem.GetRememberedValue(command.Name, command.Value);
			ConVar.AddConVar(command.Name, value, command.Help, (long)flags);
			if (command.attribute is ConVar.ClientDataAttribute)
			{
				ConsoleSystem.UpdateUserData(command.Name, value, false);
			}
		}

		// Token: 0x06000C7D RID: 3197 RVA: 0x000403AC File Offset: 0x0003E5AC
		internal static void AddAssembly(string assemblyName)
		{
			ConsoleSystem.AddAssembly(AppDomain.CurrentDomain.GetAssemblies().Single((Assembly assembly) => assembly.GetName().Name == assemblyName));
		}

		/// <summary>
		/// Remove this assembly and its console commands 
		/// </summary>
		// Token: 0x06000C7E RID: 3198 RVA: 0x000403E8 File Offset: 0x0003E5E8
		internal static void RemoveAssembly(Assembly assembly)
		{
			if (assembly == null)
			{
				return;
			}
			IEnumerable<KeyValuePair<string, Command>> members = ConsoleSystem.Members;
			Func<KeyValuePair<string, Command>, bool> <>9__0;
			Func<KeyValuePair<string, Command>, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				predicate = (<>9__0 = (KeyValuePair<string, Command> x) => x.Value.IsFromAssembly(assembly));
			}
			foreach (string member in (from x in members.Where(predicate)
				select x.Key).ToArray<string>())
			{
				ConsoleSystem.RememberValue(member);
				ConsoleSystem.Members.Remove(member);
				ConVar.RemoveConvar(member, (long)ConsoleSystem.GetBaseFlags());
			}
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x00040497 File Offset: 0x0003E697
		internal static CommandFlags GetBaseFlags()
		{
			if (Host.IsMenu)
			{
				return CommandFlags.FCVAR_CLIENTDLL | CommandFlags.FCVAR_MENU | CommandFlags.FCVAR_MANAGED;
			}
			if (Host.IsServer)
			{
				return CommandFlags.FCVAR_GAMEDLL | CommandFlags.FCVAR_MANAGED;
			}
			if (Host.IsClient)
			{
				return CommandFlags.FCVAR_CLIENTDLL | CommandFlags.FCVAR_MANAGED;
			}
			return CommandFlags.FCVAR_NONE;
		}

		/// <summary>
		/// Add this command to the library. Any existing commands named the same will be over-written.
		/// </summary>
		// Token: 0x06000C80 RID: 3200 RVA: 0x000404D0 File Offset: 0x0003E6D0
		internal static void AddCommand(Command command)
		{
			ConsoleSystem.Members[command.Name] = command;
			CommandFlags flags = ConsoleSystem.GetBaseFlags();
			if (command.CanExecuteFromClient)
			{
				flags |= CommandFlags.FCVAR_SERVER_CAN_EXECUTE;
			}
			if (command.Protected)
			{
				flags |= CommandFlags.FCVAR_CHEAT;
			}
			ConVar.AddConCommand(command.Name, command.Help, (long)flags);
		}

		// Token: 0x06000C81 RID: 3201 RVA: 0x00040528 File Offset: 0x0003E728
		internal static Command Find(string name)
		{
			Command val;
			if (ConsoleSystem.Members.TryGetValue(name, out val))
			{
				return val;
			}
			return null;
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x00040548 File Offset: 0x0003E748
		private static void RememberValue(string member)
		{
			Command var = ConsoleSystem.Find(member);
			if (var == null || !var.IsVariable)
			{
				return;
			}
			string value = ConsoleSystem.GetValue(member, null);
			if (value == null)
			{
				return;
			}
			ConsoleSystem.RememberedConvarValues[member] = value;
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x00040580 File Offset: 0x0003E780
		private static string GetRememberedValue(string member, string defaultValue)
		{
			string found;
			if (ConsoleSystem.RememberedConvarValues.TryGetValue(member, out found))
			{
				return found;
			}
			return defaultValue;
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x000405A0 File Offset: 0x0003E7A0
		public static void Run(string command)
		{
			if (!command.Contains(' '))
			{
				ConsoleSystem.RunInternal(new ConsoleCommand
				{
					Name = command
				});
				return;
			}
			string[] parts = command.SplitQuotesStrings();
			if (parts.Length == 0)
			{
				return;
			}
			if (parts.Length == 1)
			{
				ConsoleSystem.RunInternal(new ConsoleCommand
				{
					Name = command
				});
				return;
			}
			ConsoleSystem.RunInternal(new ConsoleCommand(parts[0], parts.Skip(1).ToArray<string>()));
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x00040610 File Offset: 0x0003E810
		public static void Run(string command, params object[] arguments)
		{
			if (arguments == null || arguments.Length == 0)
			{
				ConsoleSystem.Run(command);
				return;
			}
			ConsoleCommand command2 = default(ConsoleCommand);
			command2.Name = command;
			command2.Arguments = arguments.Select(delegate(object x)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<object>(x);
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}).ToArray<string>();
			ConsoleSystem.RunInternal(command2);
		}

		// Token: 0x06000C86 RID: 3206 RVA: 0x00040672 File Offset: 0x0003E872
		private static bool CanRunCommand(string name)
		{
			return Host.IsMenu || ConsoleSystem.Find(name) != null;
		}

		/// <summary>
		/// Actually do the business of trying to run a command. Will return (not throw) an exception
		/// object if an exception is thrown of command isn't found.
		/// </summary>
		// Token: 0x06000C87 RID: 3207 RVA: 0x00040688 File Offset: 0x0003E888
		private static void RunInternal(ConsoleCommand command)
		{
			if (!ConsoleSystem.CanRunCommand(command.Name))
			{
				if (Host.IsMenuOrClient)
				{
					ClientEngine.ServerCmd(InputCommandSource.ICS_SPLITSCREEN_PLAYER_0, command.ToStringCommand());
					return;
				}
				throw new Exception("Can't run '" + command.Name + "'");
			}
			else
			{
				string commandString = command.ToStringCommand();
				if (Host.IsServer)
				{
					InputService.InsertCommand(InputCommandSource.ICS_SERVER, commandString + "\n", 0, 1);
					return;
				}
				InputService.InsertCommand(InputCommandSource.ICS_SPLITSCREEN_PLAYER_0, commandString + "\n", 0, 1);
				return;
			}
		}

		/// <summary>
		/// A command has come from a key bind. Return false if we don't handle it.
		/// </summary>
		// Token: 0x06000C88 RID: 3208 RVA: 0x00040708 File Offset: 0x0003E908
		internal static void RunCommandFromInputBuffer(string command)
		{
			Host.AssertClientOrMenu("RunCommandFromInputBuffer");
			ConsoleSystem.Run(command);
		}

		// Token: 0x06000C89 RID: 3209 RVA: 0x0004071C File Offset: 0x0003E91C
		internal static void DispatchCommand(string name, string args, long flaglong, int client)
		{
			if (!((CommandFlags)flaglong).HasFlag(CommandFlags.FCVAR_MENU))
			{
				ConsoleSystem.RunCommand(name, args, (CommandFlags)flaglong, client);
				return;
			}
			Host.AssertClient("DispatchCommand");
			IMenuDll menuDll = IMenuDll.Current;
			if (menuDll == null)
			{
				return;
			}
			menuDll.DispatchCommand(name, args, flaglong, client);
		}

		// Token: 0x06000C8A RID: 3210 RVA: 0x00040770 File Offset: 0x0003E970
		internal static void RunCommand(string name, string args, CommandFlags flags, int client)
		{
			Command command = ConsoleSystem.Find(name);
			if (command == null)
			{
				return;
			}
			try
			{
				ConsoleSystem.Caller = null;
				if (client >= 0 && Host.IsServer && GlobalGameNamespace.Global.InGame)
				{
					ConsoleSystem.Caller = Entity.FindByIndex(client) as Client;
					if (ConsoleSystem.Caller == null)
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(50, 2);
						defaultInterpolatedStringHandler.AppendLiteral("RunCommand: unknown client ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(client);
						defaultInterpolatedStringHandler.AppendLiteral(" tried to run command ");
						defaultInterpolatedStringHandler.AppendFormatted(name);
						defaultInterpolatedStringHandler.AppendLiteral("!");
						throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
					}
				}
				command.Run(args, client);
			}
			finally
			{
				ConsoleSystem.Caller = null;
			}
		}

		// Token: 0x040001AD RID: 429
		internal static readonly Dictionary<string, Command> Members = new Dictionary<string, Command>(StringComparer.OrdinalIgnoreCase);

		// Token: 0x040001AE RID: 430
		private static Dictionary<string, string> RememberedConvarValues = new Dictionary<string, string>();
	}
}
