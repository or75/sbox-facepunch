using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Sandbox.InternalTests
{
	public static class CmdTest
	{
		[ClientVar]
		public static string test_clientvar { get; set; } = "Client Value";

		[ConVar.ClientData]
		public static string test_uservar { get; set; } = "Client User Var";

		[ServerVar]
		public static string test_servervar { get; set; } = "Server Value";

		[ConVar.Replicated]
		public static string test_replicatedvar { get; set; } = "Hairy Ball Bag";

		[ClientCmd]
		public static void test_clientcmd()
		{
			Log.Info( "Client Command Success" );
			Log.Info( $"	test_clientvar: {test_clientvar}" );
			Log.Info( $"	test_servervar: {test_servervar}" );
			Log.Info( $"	test_uservar: {Local.Client.GetClientData( "test_uservar" )}" );
		}

		[ServerCmd]
		public static void test_servercmd()
		{
			Log.Info( "Server Command Success" );
			Log.Info( $"Caller is {ConsoleSystem.Caller}" );
			Log.Info( $"	test_clientvar: {test_clientvar}" );
			Log.Info( $"	test_servervar: {test_servervar}" );
			Log.Info( $"	test_uservar: {ConsoleSystem.Caller.GetClientData( "test_uservar" )}" );
		}

		[AdminCmd]
		public static void test_admincmd()
		{
			Log.Info( "Admin Command Success" );
			Log.Info( $"Caller is {ConsoleSystem.Caller}" );
			Log.Info( $"	test_clientvar: {test_clientvar}" );
			Log.Info( $"	test_servervar: {test_servervar}" );
		}
	}
}
