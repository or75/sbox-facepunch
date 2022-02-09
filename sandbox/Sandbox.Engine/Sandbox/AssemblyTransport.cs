using System;
using System.IO;
using System.Text;

namespace Sandbox
{
	/// <summary>
	///
	/// Assemblies need to be written to bytes to send to the client.
	/// This keeps that process in one place.
	///
	/// </summary>
	// Token: 0x0200028D RID: 653
	[Hotload.SkipAttribute]
	internal static class AssemblyTransport
	{
		// Token: 0x0600106C RID: 4204 RVA: 0x0001E408 File Offset: 0x0001C608
		internal static void Write(Stream output, Compiler compiler)
		{
			using (BinaryWriter bw = new BinaryWriter(output, Encoding.UTF8, true))
			{
				bw.Write(compiler.AsmBinary.Length);
				bw.Write(compiler.SymBinary.Length);
				bw.Write(compiler.AsmBinary);
				bw.Write(compiler.SymBinary);
			}
		}

		// Token: 0x0600106D RID: 4205 RVA: 0x0001E474 File Offset: 0x0001C674
		internal unsafe static void Read(byte* data, int length, out Stream assembly, out Stream symbols)
		{
			using (UnmanagedMemoryStream s = new UnmanagedMemoryStream(data, (long)length))
			{
				using (BinaryReader r = new BinaryReader(s))
				{
					int a = r.ReadInt32();
					int b = r.ReadInt32();
					assembly = new UnmanagedMemoryStream(data + 8, (long)a);
					symbols = new UnmanagedMemoryStream(data + a + 8, (long)b);
				}
			}
		}
	}
}
