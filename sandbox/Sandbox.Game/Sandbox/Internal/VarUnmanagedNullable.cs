using System;
using System.Runtime.CompilerServices;

namespace Sandbox.Internal
{
	/// <summary>
	/// A fixed size Play Old Data variable. Can be a built in type or a struct.
	/// </summary>
	// Token: 0x02000179 RID: 377
	public sealed class VarUnmanagedNullable<[IsUnmanaged] T> : Var where T : struct, ValueType
	{
		// Token: 0x06001BAE RID: 7086 RVA: 0x0006F2C0 File Offset: 0x0006D4C0
		public VarUnmanagedNullable()
		{
		}

		// Token: 0x06001BAF RID: 7087 RVA: 0x0006F2C8 File Offset: 0x0006D4C8
		public VarUnmanagedNullable(T defaultValue = default(T))
		{
			this.Value = new T?(defaultValue);
		}

		// Token: 0x06001BB0 RID: 7088 RVA: 0x0006F2DC File Offset: 0x0006D4DC
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
			defaultInterpolatedStringHandler.AppendFormatted<Type>(typeof(T));
			defaultInterpolatedStringHandler.AppendLiteral("?(");
			defaultInterpolatedStringHandler.AppendFormatted<T?>(this.Value);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06001BB1 RID: 7089 RVA: 0x0006F32F File Offset: 0x0006D52F
		internal override void Write(NetWrite write)
		{
			write.Write<bool>(this.Value != null);
			if (this.Value != null)
			{
				write.Write<T>(this.Value.Value);
			}
		}

		// Token: 0x06001BB2 RID: 7090 RVA: 0x0006F360 File Offset: 0x0006D560
		internal override void Read(NetRead read)
		{
			T? oldValue = this.Value;
			if (!read.TryRead<bool>())
			{
				this.Value = null;
				base.CheckValueChanged(oldValue, this.Value);
				return;
			}
			this.Value = new T?(read.Read<T>());
			base.CheckValueChanged(oldValue, this.Value);
		}

		// Token: 0x06001BB3 RID: 7091 RVA: 0x0006F3CA File Offset: 0x0006D5CA
		public ref T? GetValue()
		{
			return ref this.Value;
		}

		// Token: 0x06001BB4 RID: 7092 RVA: 0x0006F3D2 File Offset: 0x0006D5D2
		public void SetValue(T? val)
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

		// Token: 0x04000794 RID: 1940
		public T? Value;
	}
}
