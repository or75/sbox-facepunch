using System;
using System.IO;

namespace Sandbox
{
	// Token: 0x02000085 RID: 133
	public static class EntityExtensions
	{
		// Token: 0x06000E2B RID: 3627 RVA: 0x00044E40 File Offset: 0x00043040
		public static Entity ReadEntity(this BinaryReader reader)
		{
			return Entity.Read(reader);
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x00044E48 File Offset: 0x00043048
		public static void Write(this BinaryWriter writer, Entity ent)
		{
			ent.Write(writer);
		}
	}
}
