using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x02000032 RID: 50
	public class LibraryAttribute : Attribute
	{
		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x0000B0D3 File Offset: 0x000092D3
		// (set) Token: 0x060002A3 RID: 675 RVA: 0x0000B0DB File Offset: 0x000092DB
		public Type Class { get; private set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x0000B0E4 File Offset: 0x000092E4
		// (set) Token: 0x060002A5 RID: 677 RVA: 0x0000B0EC File Offset: 0x000092EC
		internal Assembly Assembly { get; private set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060002A6 RID: 678 RVA: 0x0000B0F5 File Offset: 0x000092F5
		// (set) Token: 0x060002A7 RID: 679 RVA: 0x0000B0FD File Offset: 0x000092FD
		internal TypeInfo TypeInfo { get; private set; }

		/// <summary>
		/// This is the name that will be used to create this class.
		/// If you don't set it via the attribute constructor it will be set
		/// to the name of the class it's attached to
		/// </summary>
		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x0000B106 File Offset: 0x00009306
		// (set) Token: 0x060002A9 RID: 681 RVA: 0x0000B10E File Offset: 0x0000930E
		public string Name { get; internal set; }

		/// <summary>
		/// This is based on the full name of this type. Don't rely on it to be
		/// the same between saves - but it should be reliable over the network.
		/// </summary>
		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060002AA RID: 682 RVA: 0x0000B117 File Offset: 0x00009317
		// (set) Token: 0x060002AB RID: 683 RVA: 0x0000B11F File Offset: 0x0000931F
		public int Identifier { get; internal set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060002AC RID: 684 RVA: 0x0000B128 File Offset: 0x00009328
		// (set) Token: 0x060002AD RID: 685 RVA: 0x0000B130 File Offset: 0x00009330
		public string[] Alias { get; set; }

		/// <summary>
		/// The full class name
		/// </summary>
		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060002AE RID: 686 RVA: 0x0000B139 File Offset: 0x00009339
		// (set) Token: 0x060002AF RID: 687 RVA: 0x0000B141 File Offset: 0x00009341
		public string FullName { get; internal set; }

		/// <summary>
		/// A nice presentable name to show
		/// </summary>
		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x0000B14A File Offset: 0x0000934A
		// (set) Token: 0x060002B1 RID: 689 RVA: 0x0000B152 File Offset: 0x00009352
		public string Title { get; set; }

		/// <summary>
		/// We use this to provide a nice description in the editor
		/// </summary>
		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x0000B15B File Offset: 0x0000935B
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x0000B163 File Offset: 0x00009363
		public string Description { get; set; }

		/// <summary>
		/// We use this to provide an icon in the editor. Icon should be a string from here https://fonts.google.com/icons
		/// </summary>
		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x0000B16C File Offset: 0x0000936C
		// (set) Token: 0x060002B5 RID: 693 RVA: 0x0000B174 File Offset: 0x00009374
		public string Icon { get; set; }

		/// <summary>
		/// We use this to organise groups of entities in the editor
		/// </summary>
		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x0000B17D File Offset: 0x0000937D
		// (set) Token: 0x060002B7 RID: 695 RVA: 0x0000B185 File Offset: 0x00009385
		public string Group { get; set; }

		/// <summary>
		/// We use this to filter entities to show in the entity list in the editor
		/// </summary>
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x0000B18E File Offset: 0x0000938E
		// (set) Token: 0x060002B9 RID: 697 RVA: 0x0000B196 File Offset: 0x00009396
		public bool Editable { get; set; }

		/// <summary>
		/// We use this to filter entities that can be spawned in the editor.
		/// </summary>
		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060002BA RID: 698 RVA: 0x0000B19F File Offset: 0x0000939F
		// (set) Token: 0x060002BB RID: 699 RVA: 0x0000B1A7 File Offset: 0x000093A7
		public bool Spawnable { get; set; }

		/// <summary>
		/// A list of properties on this class
		/// </summary>
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060002BC RID: 700 RVA: 0x0000B1B0 File Offset: 0x000093B0
		// (set) Token: 0x060002BD RID: 701 RVA: 0x0000B1B8 File Offset: 0x000093B8
		internal Dictionary<string, PropertyAttribute> PropertiesInternal { get; set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060002BE RID: 702 RVA: 0x0000B1C1 File Offset: 0x000093C1
		// (set) Token: 0x060002BF RID: 703 RVA: 0x0000B1C9 File Offset: 0x000093C9
		internal List<PropertyAttribute> PropertiesList { get; set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x0000B1D2 File Offset: 0x000093D2
		public IReadOnlyList<PropertyAttribute> Properties
		{
			get
			{
				return this.PropertiesList;
			}
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0000B1DA File Offset: 0x000093DA
		public LibraryAttribute()
		{
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0000B1E2 File Offset: 0x000093E2
		public LibraryAttribute(string name)
		{
			this.Name = name;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000B1F4 File Offset: 0x000093F4
		internal virtual void InitializeMember(MemberInfo info, Type type, Assembly assembly)
		{
			if (this.Class != null)
			{
				throw new Exception("InitializeMember called multiple times");
			}
			this.Class = type;
			this.FullName = this.Class.FullName;
			this.Assembly = assembly;
			this.TypeInfo = this.Class.GetTypeInfo();
			if (string.IsNullOrEmpty(this.Name))
			{
				this.Name = info.Name;
			}
			this.BuildIdent();
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0000B26C File Offset: 0x0000946C
		internal virtual void InitializeClass(Type type, Assembly assembly)
		{
			if (this.Class != null)
			{
				throw new Exception("Initialize called multiple times");
			}
			this.Class = type;
			this.FullName = this.Class.FullName;
			this.Assembly = assembly;
			this.TypeInfo = this.Class.GetTypeInfo();
			if (string.IsNullOrEmpty(this.Name))
			{
				this.Name = this.Class.Name;
			}
			if (string.IsNullOrEmpty(this.Title))
			{
				this.Title = this.Name;
			}
			this.BuildIdent();
			this.BuildProperties();
			this.BuildInputs();
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0000B30C File Offset: 0x0000950C
		private void BuildIdent()
		{
			string hashValue = this.FullName + " / " + this.Name;
			this.Identifier = hashValue.FastHash();
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0000B33C File Offset: 0x0000953C
		private void BuildProperties()
		{
			this.PropertiesInternal = new Dictionary<string, PropertyAttribute>(StringComparer.OrdinalIgnoreCase);
			foreach (PropertyInfo prop in this.TypeInfo.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy))
			{
				PropertyAttribute attribute = prop.GetCustomAttribute(true);
				if (attribute != null)
				{
					attribute.InitFromMember(prop, this);
					this.PropertiesInternal[attribute.Name] = attribute;
				}
			}
			this.PropertiesList = this.PropertiesInternal.Select((KeyValuePair<string, PropertyAttribute> x) => x.Value).ToList<PropertyAttribute>();
		}

		/// <summary>
		/// Return true if this class matches this name, either with its primary name or any of its alt names.
		/// </summary>
		// Token: 0x060002C7 RID: 711 RVA: 0x0000B3D4 File Offset: 0x000095D4
		public bool IsNamed(string name)
		{
			return string.Equals(this.FullName, name, StringComparison.OrdinalIgnoreCase) || string.Equals(this.Name, name, StringComparison.OrdinalIgnoreCase) || (this.Alias != null && this.Alias.Any((string x) => string.Equals(x, name, StringComparison.OrdinalIgnoreCase)));
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0000B43C File Offset: 0x0000963C
		private void BuildInputs()
		{
			this.InputMethods = new Dictionary<string, InputAttribute>(StringComparer.OrdinalIgnoreCase);
			foreach (MethodInfo prop in this.TypeInfo.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy))
			{
				InputAttribute attribute = prop.GetCustomAttribute(true);
				if (attribute != null)
				{
					attribute.InitFromMember(prop, this);
					this.InputMethods[attribute.Name] = attribute;
				}
			}
		}

		/// <summary>
		/// Tries to create a type T from this attribute
		/// </summary>
		// Token: 0x060002C9 RID: 713 RVA: 0x0000B4A0 File Offset: 0x000096A0
		public T Create<T>()
		{
			if (this.TypeInfo == null)
			{
				throw new Exception("Couldn't create \"" + this.Name + "\" (not a type)");
			}
			T result;
			if (this.TypeInfo.AsType() != typeof(T) && !this.TypeInfo.IsSubclassOf(typeof(T)) && !typeof(T).IsAssignableFrom(this.TypeInfo))
			{
				GlobalSystemNamespace.Log.Error(FormattableStringFactory.Create("Tried to create {0} from stored class {1} named {2}", new object[]
				{
					typeof(T),
					this.Class,
					this.Name
				}));
				result = default(T);
				return result;
			}
			try
			{
				result = (T)((object)Activator.CreateInstance(this.Class));
			}
			catch (MissingMethodException e)
			{
				throw new Exception("Couldn't create \"" + this.Name + "\" (missing method)", e);
			}
			catch (TargetInvocationException e2)
			{
				throw new Exception(string.Concat(new string[]
				{
					"Couldn't create \"",
					this.Name,
					"\" [",
					e2.InnerException.Message,
					"]"
				}), e2.InnerException);
			}
			return result;
		}

		/// <summary>
		/// A list of input methods on this class
		/// </summary>
		// Token: 0x0400009B RID: 155
		internal Dictionary<string, InputAttribute> InputMethods;
	}
}
