using System;
using System.Reflection;

namespace Sandbox
{
	/// <summary>
	/// Allows you to mark a method to call 
	/// </summary>
	// Token: 0x02000033 RID: 51
	[AttributeUsage(AttributeTargets.Method)]
	public abstract class LibraryMethod : LibraryAttribute
	{
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060002CA RID: 714 RVA: 0x0000B5F8 File Offset: 0x000097F8
		// (set) Token: 0x060002CB RID: 715 RVA: 0x0000B600 File Offset: 0x00009800
		internal MethodInfo MethodInfo { get; private set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060002CC RID: 716 RVA: 0x0000B609 File Offset: 0x00009809
		public bool IsStaticMethod
		{
			get
			{
				return this.MethodInfo.IsStatic;
			}
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0000B616 File Offset: 0x00009816
		public LibraryMethod()
		{
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000B61E File Offset: 0x0000981E
		public LibraryMethod(string name)
		{
			base.Name = name;
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0000B630 File Offset: 0x00009830
		internal override void InitializeMember(MemberInfo info, Type type, Assembly assembly)
		{
			if (base.Class != null)
			{
				throw new Exception("InitializeMember called multiple times");
			}
			MethodInfo mi = info as MethodInfo;
			if (mi == null)
			{
				throw new Exception("LibraryMethod used on something that isn't a method!");
			}
			base.InitializeMember(info, type, assembly);
			this.MethodInfo = mi;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000B67B File Offset: 0x0000987B
		public object Invoke(object source)
		{
			if (this.IsStaticMethod)
			{
				throw new Exception("Trying to call static method with object!");
			}
			return this.MethodInfo.Invoke(source, null);
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000B69D File Offset: 0x0000989D
		public object Invoke<T>(object source, T param1)
		{
			if (this.IsStaticMethod)
			{
				throw new Exception("Trying to call static method with object!");
			}
			return this.MethodInfo.Invoke(source, new object[] { param1 });
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000B6CD File Offset: 0x000098CD
		public object Invoke<T, U>(object source, T param1, U param2)
		{
			if (this.IsStaticMethod)
			{
				throw new Exception("Trying to call static method with object!");
			}
			return this.MethodInfo.Invoke(source, new object[] { param1, param2 });
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000B706 File Offset: 0x00009906
		public object InvokeStatic()
		{
			if (!this.IsStaticMethod)
			{
				throw new Exception("Trying to call a non static method as a static!");
			}
			return this.MethodInfo.Invoke(null, null);
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000B728 File Offset: 0x00009928
		public object InvokeStatic<T>(T param1)
		{
			if (!this.IsStaticMethod)
			{
				throw new Exception("Trying to call a non static method as a static!");
			}
			return this.MethodInfo.Invoke(null, new object[] { param1 });
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0000B758 File Offset: 0x00009958
		public object InvokeStatic<T, U>(T param1, U param2)
		{
			if (!this.IsStaticMethod)
			{
				throw new Exception("Trying to call a non static method as a static!");
			}
			return this.MethodInfo.Invoke(null, new object[] { param1, param2 });
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000B794 File Offset: 0x00009994
		public object InvokeStatic<T, U, V>(T param1, U param2, V param3)
		{
			if (!this.IsStaticMethod)
			{
				throw new Exception("Trying to call a non static method as a static!");
			}
			return this.MethodInfo.Invoke(null, new object[] { param1, param2, param3 });
		}
	}
}
