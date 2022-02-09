using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200023D RID: 573
	internal struct IAsyncResourceDataRequest
	{
		// Token: 0x06000E93 RID: 3731 RVA: 0x00019C81 File Offset: 0x00017E81
		public static implicit operator IntPtr(IAsyncResourceDataRequest value)
		{
			return value.self;
		}

		// Token: 0x06000E94 RID: 3732 RVA: 0x00019C8C File Offset: 0x00017E8C
		public static implicit operator IAsyncResourceDataRequest(IntPtr value)
		{
			return new IAsyncResourceDataRequest
			{
				self = value
			};
		}

		// Token: 0x06000E95 RID: 3733 RVA: 0x00019CAA File Offset: 0x00017EAA
		public static bool operator ==(IAsyncResourceDataRequest c1, IAsyncResourceDataRequest c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000E96 RID: 3734 RVA: 0x00019CBD File Offset: 0x00017EBD
		public static bool operator !=(IAsyncResourceDataRequest c1, IAsyncResourceDataRequest c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000E97 RID: 3735 RVA: 0x00019CD0 File Offset: 0x00017ED0
		public override bool Equals(object obj)
		{
			if (obj is IAsyncResourceDataRequest)
			{
				IAsyncResourceDataRequest c = (IAsyncResourceDataRequest)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000E98 RID: 3736 RVA: 0x00019CFA File Offset: 0x00017EFA
		internal IAsyncResourceDataRequest(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000E99 RID: 3737 RVA: 0x00019D04 File Offset: 0x00017F04
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 1);
			defaultInterpolatedStringHandler.AppendLiteral("IAsyncResourceDataRequest ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x06000E9A RID: 3738 RVA: 0x00019D40 File Offset: 0x00017F40
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x06000E9B RID: 3739 RVA: 0x00019D52 File Offset: 0x00017F52
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000E9C RID: 3740 RVA: 0x00019D5D File Offset: 0x00017F5D
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000E9D RID: 3741 RVA: 0x00019D70 File Offset: 0x00017F70
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("IAsyncResourceDataRequest was null when calling " + n);
			}
		}

		// Token: 0x06000E9E RID: 3742 RVA: 0x00019D8B File Offset: 0x00017F8B
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000E9F RID: 3743 RVA: 0x00019D98 File Offset: 0x00017F98
		internal readonly string GetFileName()
		{
			this.NullCheck("GetFileName");
			method iasync_GetFileName = IAsyncResourceDataRequest.__N.IAsync_GetFileName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, iasync_GetFileName));
		}

		// Token: 0x06000EA0 RID: 3744 RVA: 0x00019DC8 File Offset: 0x00017FC8
		internal readonly IntPtr GetResultBuffer()
		{
			this.NullCheck("GetResultBuffer");
			method iasync_GetResultBuffer = IAsyncResourceDataRequest.__N.IAsync_GetResultBuffer;
			return calli(System.IntPtr(System.IntPtr), this.self, iasync_GetResultBuffer);
		}

		// Token: 0x06000EA1 RID: 3745 RVA: 0x00019DF4 File Offset: 0x00017FF4
		internal readonly long GetResultBufferSize()
		{
			this.NullCheck("GetResultBufferSize");
			method iasync_GetResultBufferSize = IAsyncResourceDataRequest.__N.IAsync_GetResultBufferSize;
			return calli(System.Int64(System.IntPtr), this.self, iasync_GetResultBufferSize);
		}

		// Token: 0x04000E44 RID: 3652
		internal IntPtr self;

		// Token: 0x020003A2 RID: 930
		internal static class __N
		{
			// Token: 0x04001880 RID: 6272
			internal static method IAsync_GetFileName;

			// Token: 0x04001881 RID: 6273
			internal static method IAsync_GetResultBuffer;

			// Token: 0x04001882 RID: 6274
			internal static method IAsync_GetResultBufferSize;
		}
	}
}
