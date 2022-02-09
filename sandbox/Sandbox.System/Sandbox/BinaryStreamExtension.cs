using System;
using System.IO;

namespace Sandbox
{
	// Token: 0x0200003F RID: 63
	public static class BinaryStreamExtension
	{
		// Token: 0x06000304 RID: 772 RVA: 0x0000BC8D File Offset: 0x00009E8D
		public static void Write(this BinaryWriter writer, Vector3 v)
		{
			v.Write(writer);
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0000BC97 File Offset: 0x00009E97
		public static void Write(this BinaryWriter writer, Vector2 v)
		{
			v.Write(writer);
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0000BCA1 File Offset: 0x00009EA1
		public static void Write(this BinaryWriter writer, Angles v)
		{
			v.Write(writer);
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0000BCAB File Offset: 0x00009EAB
		public static void Write(this BinaryWriter writer, Rotation r)
		{
			r.Write(writer);
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0000BCB5 File Offset: 0x00009EB5
		public static void Write(this BinaryWriter writer, Color clr)
		{
			clr.Write(writer);
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000BCBF File Offset: 0x00009EBF
		public static Vector3 ReadVector3(this BinaryReader reader)
		{
			return Vector3.Read(reader);
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000BCC7 File Offset: 0x00009EC7
		public static Vector2 ReadVector2(this BinaryReader reader)
		{
			return Vector2.Read(reader);
		}

		// Token: 0x0600030B RID: 779 RVA: 0x0000BCCF File Offset: 0x00009ECF
		public static Angles ReadAngles(this BinaryReader reader)
		{
			return Angles.Read(reader);
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0000BCD7 File Offset: 0x00009ED7
		public static Rotation ReadRotation(this BinaryReader reader)
		{
			return Rotation.Read(reader);
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0000BCDF File Offset: 0x00009EDF
		public static Color ReadColor(this BinaryReader reader)
		{
			return Color.Read(reader);
		}
	}
}
