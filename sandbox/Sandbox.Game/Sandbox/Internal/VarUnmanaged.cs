using System;
using System.Runtime.CompilerServices;

namespace Sandbox.Internal
{
	/// <summary>
	/// A fixed size Plain Old Data variable. Can be a built in type or a struct.
	/// </summary>
	// Token: 0x02000178 RID: 376
	public sealed class VarUnmanaged<[IsUnmanaged] T> : Var where T : struct, ValueType
	{
		// Token: 0x06001BA7 RID: 7079 RVA: 0x0006F1C7 File Offset: 0x0006D3C7
		public VarUnmanaged()
		{
		}

		// Token: 0x06001BA8 RID: 7080 RVA: 0x0006F1CF File Offset: 0x0006D3CF
		public VarUnmanaged(T defaultValue)
		{
			this.Value = defaultValue;
		}

		// Token: 0x06001BA9 RID: 7081 RVA: 0x0006F1E0 File Offset: 0x0006D3E0
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
			defaultInterpolatedStringHandler.AppendFormatted<Type>(typeof(T));
			defaultInterpolatedStringHandler.AppendLiteral("( ");
			defaultInterpolatedStringHandler.AppendFormatted<T>(this.Value);
			defaultInterpolatedStringHandler.AppendLiteral(" )");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06001BAA RID: 7082 RVA: 0x0006F233 File Offset: 0x0006D433
		internal override void Write()
		{
			base.NetWrite<T>(this.Value);
		}

		// Token: 0x06001BAB RID: 7083 RVA: 0x0006F244 File Offset: 0x0006D444
		internal override void Read(NetRead read)
		{
			T oldValue = this.Value;
			this.Value = read.TryRead<T>();
			base.CheckValueChanged(oldValue, this.Value);
		}

		// Token: 0x06001BAC RID: 7084 RVA: 0x0006F27C File Offset: 0x0006D47C
		public ref T GetValue()
		{
			return ref this.Value;
		}

		// Token: 0x06001BAD RID: 7085 RVA: 0x0006F284 File Offset: 0x0006D484
		public void SetValue(in T val)
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

		// Token: 0x04000793 RID: 1939
		public T Value;
	}
}
