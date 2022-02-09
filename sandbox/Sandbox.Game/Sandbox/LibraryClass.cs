using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using Sandbox.Internal;

namespace Sandbox
{
	/// <summary>
	/// Every class that is derived from this is automatically added to the library. 
	/// If they have a [Library] attribute we use that, if not we create an empty one.
	/// </summary>
	// Token: 0x0200006B RID: 107
	public class LibraryClass
	{
		// Token: 0x06000C46 RID: 3142 RVA: 0x0003F613 File Offset: 0x0003D813
		public LibraryClass()
		{
			this.ClassInfo = Library.GetAttribute(base.GetType());
			LibraryAttribute classInfo = this.ClassInfo;
		}

		/// <summary>
		/// This is an int representing this class. It can be used with Library to
		/// get the class type. It's also networkable, so can represent the class
		/// type over the network.
		/// </summary>
		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000C47 RID: 3143 RVA: 0x0003F633 File Offset: 0x0003D833
		internal int LibraryClassIdentifier
		{
			get
			{
				if (this.ClassInfo != null)
				{
					return this.ClassInfo.Identifier;
				}
				return 0;
			}
		}

		/// <summary>
		/// We really shouldn't be using the attribute for this, it feels kind of dumb
		/// </summary>
		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000C48 RID: 3144 RVA: 0x0003F64A File Offset: 0x0003D84A
		// (set) Token: 0x06000C49 RID: 3145 RVA: 0x0003F652 File Offset: 0x0003D852
		[Browsable(false)]
		public LibraryAttribute ClassInfo { get; internal set; }

		/// <summary>
		/// Sets a property on this class. For a property to be settable you should have marked it with [Property] (or one of its children)
		/// </summary>
		// Token: 0x06000C4A RID: 3146 RVA: 0x0003F65C File Offset: 0x0003D85C
		public virtual void SetProperty(string name, string value)
		{
			PropertyInfo prop = base.GetType().GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			if (prop == null)
			{
				PropertyAttribute property;
				if (this.ClassInfo.PropertiesInternal == null || !this.ClassInfo.PropertiesInternal.TryGetValue(name, out property))
				{
					return;
				}
				prop = property.PropertyInfo;
			}
			try
			{
				object val = value.ToType(prop.PropertyType);
				prop.SetValue(this, val);
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Couldn't set property {0} to {1}:", new object[] { name, value }));
				GlobalGameNamespace.Log.Error(e);
			}
		}
	}
}
