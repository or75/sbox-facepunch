using System;
using System.Runtime.CompilerServices;

namespace Sandbox.Internal
{
	/// <summary>
	/// A class, or a string. Anything that NetRead/NetWrite can deal with.
	/// </summary>
	// Token: 0x02000177 RID: 375
	public sealed class VarGeneric<T> : Var where T : class
	{
		// Token: 0x06001BA0 RID: 7072 RVA: 0x0006F0B0 File Offset: 0x0006D2B0
		public VarGeneric()
		{
		}

		// Token: 0x06001BA1 RID: 7073 RVA: 0x0006F0B8 File Offset: 0x0006D2B8
		public VarGeneric(T defaultValue)
		{
			this.Value = defaultValue;
		}

		// Token: 0x06001BA2 RID: 7074 RVA: 0x0006F0C8 File Offset: 0x0006D2C8
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 2);
			defaultInterpolatedStringHandler.AppendFormatted<Type>(typeof(T));
			defaultInterpolatedStringHandler.AppendLiteral("(");
			defaultInterpolatedStringHandler.AppendFormatted<T>(this.Value);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06001BA3 RID: 7075 RVA: 0x0006F11B File Offset: 0x0006D31B
		internal override void Write(NetWrite write)
		{
			write.Write<T>(this.Value);
		}

		// Token: 0x06001BA4 RID: 7076 RVA: 0x0006F12C File Offset: 0x0006D32C
		internal override void Read(NetRead read)
		{
			Host.AssertClient("Read");
			if (read.Remaining == 0)
			{
				this.Value = default(T);
				return;
			}
			T oldValue = this.Value;
			this.Value = read.ReadClass<T>(default(T));
			base.CheckValueChanged(oldValue, this.Value);
		}

		// Token: 0x06001BA5 RID: 7077 RVA: 0x0006F18D File Offset: 0x0006D38D
		public T GetValue()
		{
			return this.Value;
		}

		// Token: 0x06001BA6 RID: 7078 RVA: 0x0006F195 File Offset: 0x0006D395
		public void SetValue(T val)
		{
			if (object.Equals(val, this.Value))
			{
				return;
			}
			if (!base.CanChangeValue())
			{
				return;
			}
			this.Value = val;
			this.SetDirty(false);
		}

		// Token: 0x04000792 RID: 1938
		private T Value;
	}
}
