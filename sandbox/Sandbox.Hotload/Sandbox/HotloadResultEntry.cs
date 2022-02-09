using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Sandbox
{
	/// <summary>
	/// Contains information for an individual hotload result message or error.
	/// </summary>
	// Token: 0x02000008 RID: 8
	public sealed class HotloadResultEntry : IEquatable<HotloadResultEntry>
	{
		/// <summary>
		/// Hotload result category.
		/// </summary>
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00003995 File Offset: 0x00001B95
		// (set) Token: 0x0600003A RID: 58 RVA: 0x0000399D File Offset: 0x00001B9D
		public HotloadEntryType Type { get; set; }

		/// <summary>
		/// Contains the main information of the result.
		/// </summary>
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000039A6 File Offset: 0x00001BA6
		// (set) Token: 0x0600003C RID: 60 RVA: 0x000039AE File Offset: 0x00001BAE
		public string Message { get; set; }

		/// <summary>
		/// If the result type is <see cref="F:Sandbox.HotloadEntryType.Error" />, contains the
		/// exception thrown.
		/// </summary>
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600003D RID: 61 RVA: 0x000039B7 File Offset: 0x00001BB7
		// (set) Token: 0x0600003E RID: 62 RVA: 0x000039BF File Offset: 0x00001BBF
		public Exception Exception { get; set; }

		/// <summary>
		/// When relevant, contains the member that this result relates to.
		/// </summary>
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600003F RID: 63 RVA: 0x000039C8 File Offset: 0x00001BC8
		// (set) Token: 0x06000040 RID: 64 RVA: 0x000039D0 File Offset: 0x00001BD0
		public MemberInfo Member { get; set; }

		// Token: 0x06000041 RID: 65 RVA: 0x000039D9 File Offset: 0x00001BD9
		public HotloadResultEntry()
		{
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000039E1 File Offset: 0x00001BE1
		internal HotloadResultEntry(Exception exception, string message = null, MemberInfo member = null)
			: this(HotloadEntryType.Error, message ?? exception.Message, member)
		{
			this.Exception = exception;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000039FD File Offset: 0x00001BFD
		internal HotloadResultEntry(HotloadEntryType type, string message, MemberInfo member = null)
		{
			this.Type = type;
			this.Message = message;
			this.Member = member;
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>
		/// A string that represents the current object.
		/// </returns>
		// Token: 0x06000044 RID: 68 RVA: 0x00003A1C File Offset: 0x00001C1C
		public override string ToString()
		{
			if (this.Member == null)
			{
				return this.Message;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 3);
			defaultInterpolatedStringHandler.AppendFormatted(this.Message);
			defaultInterpolatedStringHandler.AppendLiteral(" (");
			defaultInterpolatedStringHandler.AppendFormatted<Type>(this.Member.DeclaringType);
			defaultInterpolatedStringHandler.AppendLiteral(".");
			defaultInterpolatedStringHandler.AppendFormatted(this.Member.Name);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003AA3 File Offset: 0x00001CA3
		public override int GetHashCode()
		{
			if (this.Member == null && this.Message == null)
			{
				return 0;
			}
			if (!(this.Member == null))
			{
				return this.Member.GetHashCode();
			}
			return this.Message.GetHashCode();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003AE2 File Offset: 0x00001CE2
		public override bool Equals(object obj)
		{
			return obj is HotloadResultEntry && this.Equals((HotloadResultEntry)obj);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003AFA File Offset: 0x00001CFA
		public bool Equals(HotloadResultEntry other)
		{
			return other.Member == this.Member && other.Type == this.Type;
		}
	}
}
