using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace Sandbox
{
	// Token: 0x02000290 RID: 656
	[Hotload.SkipAttribute]
	internal static class CompilerSetup
	{
		// Token: 0x060010A6 RID: 4262 RVA: 0x0001EF09 File Offset: 0x0001D109
		public static void Initialize()
		{
			CompilerSetup.BuildSystemReferences();
		}

		// Token: 0x060010A7 RID: 4263 RVA: 0x0001EF10 File Offset: 0x0001D110
		private static void BuildSystemReferences()
		{
			string corePath = Path.GetDirectoryName(typeof(object).Assembly.Location);
			CompilerSetup.SystemReferences.Add(MetadataReference.CreateFromFile(typeof(object).Assembly.Location, default(MetadataReferenceProperties), null));
			foreach (string assembly in CompilerSetup.SystemAssemblies)
			{
				PortableExecutableReference meta = MetadataReference.CreateFromFile(Path.Combine(corePath, assembly), default(MetadataReferenceProperties), null);
				CompilerSetup.SystemReferences.Add(meta);
			}
		}

		// Token: 0x060010A8 RID: 4264 RVA: 0x0001EFA2 File Offset: 0x0001D1A2
		public static IEnumerable<PortableExecutableReference> GetCommonReferences(IEnumerable<string> references)
		{
			foreach (PortableExecutableReference r in CompilerSetup.SystemReferences)
			{
				yield return r;
			}
			List<PortableExecutableReference>.Enumerator enumerator = default(List<PortableExecutableReference>.Enumerator);
			foreach (string r2 in references)
			{
				yield return CompilerSetup.FindReference(r2);
			}
			IEnumerator<string> enumerator2 = null;
			yield break;
			yield break;
		}

		// Token: 0x060010A9 RID: 4265 RVA: 0x0001EFB4 File Offset: 0x0001D1B4
		private static Assembly FindLoadedAssembly(string name)
		{
			Assembly loadedAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault((Assembly assembly) => string.Compare(assembly.GetName().Name, name, StringComparison.OrdinalIgnoreCase) == 0);
			if (loadedAssembly != null)
			{
				return loadedAssembly;
			}
			Assembly result;
			try
			{
				result = Assembly.Load(name);
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060010AA RID: 4266 RVA: 0x0001F01C File Offset: 0x0001D21C
		public static PortableExecutableReference FindReference(string name)
		{
			Assembly assembly = CompilerSetup.FindLoadedAssembly(name);
			if (assembly == null)
			{
				throw new Exception("Couldn't find " + name + ".dll");
			}
			return MetadataReference.CreateFromFile(assembly.Location, default(MetadataReferenceProperties), null);
		}

		// Token: 0x0400128C RID: 4748
		private const string DllExt = ".dll";

		// Token: 0x0400128D RID: 4749
		private const string NiDllExt = ".ni.dll";

		// Token: 0x0400128E RID: 4750
		private const string DllSearch = "*.dll";

		// Token: 0x0400128F RID: 4751
		internal static List<PortableExecutableReference> SystemReferences = new List<PortableExecutableReference>();

		// Token: 0x04001290 RID: 4752
		private static string[] SystemAssemblies = new string[]
		{
			"System.Collections.Concurrent.dll", "System.Collections.Immutable.dll", "System.Collections.dll", "System.Console.dll", "System.Runtime.Extensions.dll", "System.Linq.dll", "System.Runtime.dll", "System.Xml.ReaderWriter.dll", "System.Private.Xml.dll", "System.Private.Uri.dll",
			"System.Numerics.Vectors.dll", "System.Text.RegularExpressions.dll", "System.Text.Json.dll", "System.Net.Http.dll", "System.Net.Http.Json.dll", "System.ObjectModel.dll", "System.IO.Compression.dll", "System.Threading.Channels.dll", "System.ComponentModel.Primitives.dll", "System.ComponentModel.Annotations.dll",
			"System.Web.HttpUtility.dll", "System.Collections.Specialized.dll"
		};
	}
}
