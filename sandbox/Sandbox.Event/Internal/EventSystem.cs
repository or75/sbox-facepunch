using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Sandbox.Internal
{
	// Token: 0x02000004 RID: 4
	internal class EventSystem : IDisposable
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00002129 File Offset: 0x00000329
		public EventSystem(Logger log)
		{
			this.log = log;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002154 File Offset: 0x00000354
		internal void AddType(Type t)
		{
			EventSystem.EventClass classEvent;
			this.Classes.TryGetValue(t, out classEvent);
			foreach (MethodInfo i in t.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy))
			{
				foreach (EventAttribute attr in i.GetCustomAttributes(true))
				{
					if (classEvent == null)
					{
						classEvent = new EventSystem.EventClass
						{
							Assembly = t.Assembly,
							Type = t
						};
						this.Classes[t] = classEvent;
					}
					this.GetGroup(attr.EventName, true);
					EventSystem.EventAction eventAction = new EventSystem.EventAction
					{
						Priority = attr.Priority,
						Class = classEvent,
						Group = this.GetGroup(attr.EventName.ToLower(), true),
						Delegate = this.BuildDelegate(i),
						IsStatic = i.IsStatic
					};
					classEvent.Events.Add(eventAction);
					eventAction.Group.Add(eventAction);
				}
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002278 File Offset: 0x00000478
		private EventSystem.EventDelegate BuildDelegate(MethodInfo info)
		{
			ParameterInfo[] parameters = info.GetParameters();
			object[] args = null;
			if (parameters.Length != 0)
			{
				args = new object[parameters.Length];
			}
			return delegate(object o, object[] p)
			{
				if (args != null)
				{
					if (p.Length != args.Length)
					{
						return;
					}
					for (int i = 0; i < args.Length; i++)
					{
						args[i] = p[i];
					}
				}
				else if (p != null && p.Length != 0)
				{
					return;
				}
				MethodInfo info2 = info;
				if (info2 == null)
				{
					return;
				}
				info2.Invoke(o, args);
			};
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000022C4 File Offset: 0x000004C4
		internal EventSystem.EventList GetGroup(string name, bool create)
		{
			name = name.ToLower();
			EventSystem.EventList group;
			if (this.Groups.TryGetValue(name, out group))
			{
				return group;
			}
			if (!create)
			{
				return null;
			}
			group = new EventSystem.EventList();
			this.Groups.Add(name, group);
			return group;
		}

		/// <summary>
		/// Register an assembly. If old assembly is valid, we try to remove all of the old event hooks
		/// from this assembly, while retaining a list of objects.
		/// </summary>
		// Token: 0x06000011 RID: 17 RVA: 0x00002304 File Offset: 0x00000504
		internal void RegisterAssembly(Assembly old, Assembly nw)
		{
			if (nw == null)
			{
				return;
			}
			Type[] newTypes = nw.GetTypes();
			if (old != null)
			{
				Type[] oldTypes = old.GetTypes();
				this.SwapTypes(oldTypes, newTypes);
			}
			foreach (Type type in newTypes)
			{
				this.AddType(type);
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002358 File Offset: 0x00000558
		private void SwapTypes(Type[] oldTypes, Type[] newTypes)
		{
			for (int i = 0; i < oldTypes.Length; i++)
			{
				Type t = oldTypes[i];
				EventSystem.EventClass classEvent;
				if (this.Classes.TryGetValue(t, out classEvent))
				{
					Assert.True(this.Classes.Remove(t));
					foreach (EventSystem.EventAction e in classEvent.Events)
					{
						e.Group.Remove(e);
					}
					classEvent.Events.Clear();
					Type swapTo = newTypes.FirstOrDefault((Type x) => x.FullName == t.FullName);
					if (!(swapTo == null))
					{
						this.Classes.Add(swapTo, classEvent);
						classEvent.Type = swapTo;
						classEvent.Assembly = swapTo.Assembly;
					}
				}
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002454 File Offset: 0x00000654
		internal void RemoveAssembly(Assembly assembly)
		{
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002458 File Offset: 0x00000658
		internal void Run(string v)
		{
			EventSystem.EventList g = this.GetGroup(v, false);
			if (g == null)
			{
				return;
			}
			for (int i = 0; i < g.Count; i++)
			{
				EventSystem.EventAction e = g[i];
				if (e.Exception == null)
				{
					try
					{
						if (e.IsStatic)
						{
							e.Delegate(null, null);
						}
						else
						{
							for (int j = 0; j < e.Class.Targets.Count; j++)
							{
								e.Delegate(e.Class.Targets[j], null);
							}
						}
					}
					catch (TargetInvocationException ex)
					{
						e.Exception = ex.InnerException;
						this.log.Error(ex.InnerException, FormattableStringFactory.Create("Error calling event '{0}'", new object[] { v }));
					}
					catch (Exception ex2)
					{
						e.Exception = ex2;
						this.log.Error(ex2, FormattableStringFactory.Create("Error calling event '{0}'", new object[] { v }));
					}
				}
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002570 File Offset: 0x00000770
		internal void Run(string v, params object[] list)
		{
			EventSystem.EventList g = this.GetGroup(v, false);
			if (g == null)
			{
				return;
			}
			foreach (EventSystem.EventAction e in g)
			{
				if (e.IsStatic)
				{
					e.Delegate(null, list);
				}
				else
				{
					foreach (object obj in e.Class.Targets)
					{
						e.Delegate(obj, list);
					}
				}
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000262C File Offset: 0x0000082C
		internal void Register(object obj)
		{
			EventSystem.EventClass type;
			if (!this.Classes.TryGetValue(obj.GetType(), out type))
			{
				return;
			}
			type.Targets.Add(obj);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000265C File Offset: 0x0000085C
		internal void Unregister(object obj)
		{
			EventSystem.EventClass type;
			if (!this.Classes.TryGetValue(obj.GetType(), out type))
			{
				return;
			}
			type.Targets.Remove(obj);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000268C File Offset: 0x0000088C
		public void Dispose()
		{
			this.Classes.Clear();
			this.Classes = null;
			this.Groups.Clear();
			this.Groups = null;
		}

		// Token: 0x04000004 RID: 4
		private Logger log;

		// Token: 0x04000005 RID: 5
		private Dictionary<Type, EventSystem.EventClass> Classes = new Dictionary<Type, EventSystem.EventClass>();

		// Token: 0x04000006 RID: 6
		private Dictionary<string, EventSystem.EventList> Groups = new Dictionary<string, EventSystem.EventList>(StringComparer.OrdinalIgnoreCase);

		/// <summary>
		/// A Type with events on it
		/// </summary>
		// Token: 0x02000010 RID: 16
		public class EventClass
		{
			// Token: 0x04000007 RID: 7
			public Assembly Assembly;

			// Token: 0x04000008 RID: 8
			public Type Type;

			// Token: 0x04000009 RID: 9
			public List<EventSystem.EventAction> Events = new List<EventSystem.EventAction>();

			// Token: 0x0400000A RID: 10
			public List<object> Targets = new List<object>();
		}

		/// <summary>
		/// A method on a type
		/// </summary>
		// Token: 0x02000011 RID: 17
		public class EventAction
		{
			// Token: 0x0400000B RID: 11
			public int Priority;

			// Token: 0x0400000C RID: 12
			public EventSystem.EventClass Class;

			// Token: 0x0400000D RID: 13
			public EventSystem.EventList Group;

			// Token: 0x0400000E RID: 14
			public EventSystem.EventDelegate Delegate;

			// Token: 0x0400000F RID: 15
			public bool IsStatic;

			// Token: 0x04000010 RID: 16
			public Exception Exception;
		}

		/// <summary>
		/// A list of events, usually indexed by the event name
		/// </summary>
		// Token: 0x02000012 RID: 18
		public class EventList : List<EventSystem.EventAction>
		{
		}

		// Token: 0x02000013 RID: 19
		// (Invoke) Token: 0x06000022 RID: 34
		public delegate void EventDelegate(object root, object[] parms);
	}
}
