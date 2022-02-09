using System;
using System.Reflection;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x02000002 RID: 2
	public static class Event
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		internal static void Init(Logger log)
		{
			EventSystem eventSystem = Event.eventManager;
			if (eventSystem != null)
			{
				eventSystem.Dispose();
			}
			Event.eventManager = new EventSystem(log);
		}

		/// <summary>
		/// Register an assembly. If old assembly is valid, we try to remove all of the old event hooks
		/// from this assembly, while retaining a list of objects.
		/// </summary>
		// Token: 0x06000002 RID: 2 RVA: 0x0000206D File Offset: 0x0000026D
		internal static void RegisterAssembly(Assembly aold, Assembly anew)
		{
			if (anew == null)
			{
				Event.eventManager.RemoveAssembly(aold);
				return;
			}
			Event.eventManager.RegisterAssembly(aold, anew);
		}

		/// <summary>
		/// Register an object to start recieving events
		/// </summary>
		// Token: 0x06000003 RID: 3 RVA: 0x00002090 File Offset: 0x00000290
		public static void Register(object obj)
		{
			Event.eventManager.Register(obj);
		}

		/// <summary>
		/// Unregister an object, stop reciving events
		/// </summary>
		// Token: 0x06000004 RID: 4 RVA: 0x0000209D File Offset: 0x0000029D
		public static void Unregister(object obj)
		{
			Event.eventManager.Unregister(obj);
		}

		/// <summary>
		/// Run an event
		/// </summary>
		// Token: 0x06000005 RID: 5 RVA: 0x000020AA File Offset: 0x000002AA
		public static void Run(string name)
		{
			Event.eventManager.Run(name);
		}

		/// <summary>
		/// Run an event
		/// </summary>
		// Token: 0x06000006 RID: 6 RVA: 0x000020B7 File Offset: 0x000002B7
		public static void Run<T>(string name, T arg0)
		{
			Event.eventManager.Run(name, new object[] { arg0 });
		}

		/// <summary>
		/// Run an event
		/// </summary>
		// Token: 0x06000007 RID: 7 RVA: 0x000020D3 File Offset: 0x000002D3
		public static void Run<T, U>(string name, T arg0, U arg1)
		{
			Event.eventManager.Run(name, new object[] { arg0, arg1 });
		}

		// Token: 0x04000001 RID: 1
		private static EventSystem eventManager;

		/// <summary>
		/// Called every tick on both client and server
		/// </summary>
		// Token: 0x02000005 RID: 5
		public class TickAttribute : EventAttribute
		{
			// Token: 0x06000019 RID: 25 RVA: 0x000026B2 File Offset: 0x000008B2
			public TickAttribute()
				: base("tick")
			{
			}
		}

		// Token: 0x02000006 RID: 6
		public static class Tick
		{
			/// <summary>
			/// Called every tick on the server.
			/// </summary>
			// Token: 0x02000016 RID: 22
			public class ServerAttribute : EventAttribute
			{
				// Token: 0x06000029 RID: 41 RVA: 0x000027AF File Offset: 0x000009AF
				public ServerAttribute()
					: base("server.tick")
				{
				}
			}

			/// <summary>
			/// Called every server tick on the client. You want to do game logic here, not in <see cref="T:Sandbox.Event.FrameAttribute" />
			/// </summary>
			// Token: 0x02000017 RID: 23
			public class ClientAttribute : EventAttribute
			{
				// Token: 0x0600002A RID: 42 RVA: 0x000027BC File Offset: 0x000009BC
				public ClientAttribute()
					: base("client.tick")
				{
				}
			}
		}

		/// <summary>
		/// Called every render frame on client. You can still move entities during this period. 
		/// </summary>
		// Token: 0x02000007 RID: 7
		public class FrameAttribute : EventAttribute
		{
			// Token: 0x0600001A RID: 26 RVA: 0x000026BF File Offset: 0x000008BF
			public FrameAttribute()
				: base("frame")
			{
			}
		}

		/// <summary>
		/// Called right before rendering. All entities are in the position they're going to be rendered in. Moving entities
		/// here will have no effect until the next frame. Moving SceneObjects is possible here and they will be rendered in their
		/// new positions.
		/// </summary>
		// Token: 0x02000008 RID: 8
		public class PreRenderAttribute : EventAttribute
		{
			// Token: 0x0600001B RID: 27 RVA: 0x000026CC File Offset: 0x000008CC
			public PreRenderAttribute()
				: base("prerender")
			{
			}
		}

		/// <summary>
		/// Called when the class this method belongs to is hotloaded
		/// </summary>
		// Token: 0x02000009 RID: 9
		public class HotloadAttribute : EventAttribute
		{
			// Token: 0x0600001C RID: 28 RVA: 0x000026D9 File Offset: 0x000008D9
			public HotloadAttribute()
				: base("hotloaded")
			{
			}
		}

		/// <summary>
		/// TODO: Document me
		/// </summary>
		// Token: 0x0200000A RID: 10
		public class BuildInputAttribute : EventAttribute
		{
			// Token: 0x0600001D RID: 29 RVA: 0x000026E6 File Offset: 0x000008E6
			public BuildInputAttribute()
				: base("buildinput")
			{
			}
		}

		// Token: 0x0200000B RID: 11
		public static class Physics
		{
			/// <summary>
			/// Called just before executing a physics frame.
			/// </summary>
			// Token: 0x02000018 RID: 24
			public class PreStepAttribute : EventAttribute
			{
				// Token: 0x0600002B RID: 43 RVA: 0x000027C9 File Offset: 0x000009C9
				public PreStepAttribute()
					: base("physics.prestep")
				{
				}
			}

			/// <summary>
			/// Called just after executing a physics frame.
			/// </summary>
			// Token: 0x02000019 RID: 25
			public class PostStepAttribute : EventAttribute
			{
				// Token: 0x0600002C RID: 44 RVA: 0x000027D6 File Offset: 0x000009D6
				public PostStepAttribute()
					: base("physics.poststep")
				{
				}
			}
		}

		// Token: 0x0200000C RID: 12
		public static class Entity
		{
			/// <summary>
			/// Called after all map entities have spawned in, including after map cleanups.
			/// </summary>
			// Token: 0x0200001A RID: 26
			public class PostSpawnAttribute : EventAttribute
			{
				// Token: 0x0600002D RID: 45 RVA: 0x000027E3 File Offset: 0x000009E3
				public PostSpawnAttribute()
					: base("entity.postspawn")
				{
				}
			}
		}

		// Token: 0x0200000D RID: 13
		public static class Screen
		{
			/// <summary>
			/// Called after the users window size has changed
			/// </summary>
			// Token: 0x0200001B RID: 27
			public class SizeChangedAttribute : EventAttribute
			{
				// Token: 0x0600002E RID: 46 RVA: 0x000027F0 File Offset: 0x000009F0
				public SizeChangedAttribute()
					: base("screen.size.changed")
				{
				}
			}
		}

		// Token: 0x0200000E RID: 14
		public static class Controller
		{
			/// <summary>
			/// Called when a controller has been connected.
			/// </summary>
			// Token: 0x0200001C RID: 28
			public class ConnectedAttribute : EventAttribute
			{
				// Token: 0x0600002F RID: 47 RVA: 0x000027FD File Offset: 0x000009FD
				public ConnectedAttribute()
					: base("controller.connected")
				{
				}
			}

			/// <summary>
			/// Called when a controller has been disconnected.
			/// </summary>
			// Token: 0x0200001D RID: 29
			public class DisconnectedAttribute : EventAttribute
			{
				// Token: 0x06000030 RID: 48 RVA: 0x0000280A File Offset: 0x00000A0A
				public DisconnectedAttribute()
					: base("controller.disconnected")
				{
				}
			}
		}

		// Token: 0x0200000F RID: 15
		public static class Streamer
		{
			/// <summary>
			/// Event called when joined a chat
			/// </summary>
			// Token: 0x0200001E RID: 30
			public class JoinChatAttribute : EventAttribute
			{
				// Token: 0x06000031 RID: 49 RVA: 0x00002817 File Offset: 0x00000A17
				public JoinChatAttribute()
					: base("stream.join")
				{
				}
			}

			/// <summary>
			/// Event called when left a chat
			/// </summary>
			// Token: 0x0200001F RID: 31
			public class LeaveChatAttribute : EventAttribute
			{
				// Token: 0x06000032 RID: 50 RVA: 0x00002824 File Offset: 0x00000A24
				public LeaveChatAttribute()
					: base("stream.leave")
				{
				}
			}

			/// <summary>
			/// Event called when chat message comes in
			/// </summary>
			// Token: 0x02000020 RID: 32
			public class ChatMessageAttribute : EventAttribute
			{
				// Token: 0x06000033 RID: 51 RVA: 0x00002831 File Offset: 0x00000A31
				public ChatMessageAttribute()
					: base("stream.message")
				{
				}
			}
		}
	}
}
