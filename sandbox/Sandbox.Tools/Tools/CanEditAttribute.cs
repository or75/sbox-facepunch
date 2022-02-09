using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using Sandbox.Internal;

namespace Tools
{
	// Token: 0x02000082 RID: 130
	public class CanEditAttribute : Attribute
	{
		// Token: 0x0600132D RID: 4909 RVA: 0x00052EAA File Offset: 0x000510AA
		public static void RegisterType(Type t, CanEditAttribute attr)
		{
			CanEditAttribute.All.Add(new ValueTuple<Type, CanEditAttribute>(t, attr));
		}

		// Token: 0x0600132E RID: 4910 RVA: 0x00052EC0 File Offset: 0x000510C0
		public static void UnregisterType(Type t, CanEditAttribute attr)
		{
			CanEditAttribute.All.RemoveAll(([TupleElementNames(new string[] { "type", "attr" })] ValueTuple<Type, CanEditAttribute> x) => x.Item1 == t);
		}

		// Token: 0x0600132F RID: 4911 RVA: 0x00052EF1 File Offset: 0x000510F1
		public static Widget CreateEditorFor(PropertyInfo property)
		{
			return CanEditAttribute.CreateEditorFor(property.PropertyType, property.GetCustomAttributes<EditorAttribute>());
		}

		// Token: 0x06001330 RID: 4912 RVA: 0x00052F04 File Offset: 0x00051104
		public static Widget CreateEditorFor(Type t, IEnumerable<EditorAttribute> attributes = null)
		{
			if (attributes != null)
			{
				foreach (ValueTuple<Type, CanEditAttribute> entry in CanEditAttribute.All)
				{
					if (entry.Item2.CanEdit(null, attributes))
					{
						return GlobalToolsNamespace.Reflection.CreateType<Widget>(entry.Item1, new object[1]);
					}
				}
			}
			IEnumerable<EditorAttribute> editors = t.GetCustomAttributes<EditorAttribute>();
			foreach (ValueTuple<Type, CanEditAttribute> entry2 in CanEditAttribute.All)
			{
				if (entry2.Item2.CanEdit(t, editors))
				{
					return GlobalToolsNamespace.Reflection.CreateType<Widget>(entry2.Item1, new object[1]);
				}
			}
			if (t.IsEnum)
			{
				return new EnumBox(null, t);
			}
			if (t == typeof(bool))
			{
				return new CheckBox(null);
			}
			return null;
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06001331 RID: 4913 RVA: 0x00053018 File Offset: 0x00051218
		// (set) Token: 0x06001332 RID: 4914 RVA: 0x00053020 File Offset: 0x00051220
		public Type Type { get; set; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06001333 RID: 4915 RVA: 0x00053029 File Offset: 0x00051229
		// (set) Token: 0x06001334 RID: 4916 RVA: 0x00053031 File Offset: 0x00051231
		public string TypeName { get; set; }

		// Token: 0x06001335 RID: 4917 RVA: 0x0005303A File Offset: 0x0005123A
		public CanEditAttribute(Type type, string typeName = null)
		{
			this.Type = type;
			this.TypeName = typeName;
		}

		// Token: 0x06001336 RID: 4918 RVA: 0x00053050 File Offset: 0x00051250
		public CanEditAttribute(string typeName)
			: this(null, typeName)
		{
		}

		// Token: 0x06001337 RID: 4919 RVA: 0x0005305C File Offset: 0x0005125C
		private bool CanEdit(Type t, IEnumerable<EditorAttribute> editors)
		{
			if (this.Type != null && this.Type == t)
			{
				return true;
			}
			using (IEnumerator<EditorAttribute> enumerator = editors.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.EditorTypeName == this.TypeName)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x040001B4 RID: 436
		[TupleElementNames(new string[] { "type", "attr" })]
		private static List<ValueTuple<Type, CanEditAttribute>> All = new List<ValueTuple<Type, CanEditAttribute>>();
	}
}
