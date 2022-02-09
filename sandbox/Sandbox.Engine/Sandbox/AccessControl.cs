using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;

namespace Sandbox
{
	// Token: 0x0200028C RID: 652
	[Hotload.SkipAttribute]
	internal class AccessControl : IAssemblyResolver, IDisposable
	{
		/// <summary>
		/// Clear the touches and fill them with everything this dll touches
		/// </summary>
		// Token: 0x06001051 RID: 4177 RVA: 0x0001D43C File Offset: 0x0001B63C
		public void InitTouches(Stream dll)
		{
			this.Touched.Clear();
			this.Assembly = AssemblyDefinition.ReadAssembly(dll, new ReaderParameters
			{
				InMemory = true,
				AssemblyResolver = this
			});
			this.Assemblies[this.Assembly.Name.Name] = this.Assembly;
			foreach (ModuleDefinition module in this.Assembly.Modules)
			{
				this.Location = module.ToString();
				this.TestModule(module);
			}
			this.RemoveLocalTouches();
		}

		/// <summary>
		/// If we're definitely never goinug to see this assembly again (because it's being unloaded for instance)
		/// We can totally get rid of it and free all that lovely memory.
		/// </summary>
		// Token: 0x06001052 RID: 4178 RVA: 0x0001D4F4 File Offset: 0x0001B6F4
		public void ForgetAssembly(string name)
		{
			this.RemoveSafeAssembly(name);
			AssemblyDefinition assembly;
			if (!this.Assemblies.Remove(name, out assembly))
			{
				return;
			}
			if (assembly != null)
			{
				assembly.Dispose();
			}
		}

		// Token: 0x06001053 RID: 4179 RVA: 0x0001D524 File Offset: 0x0001B724
		private void TestModule(ModuleDefinition module)
		{
			this.TestAttributes(module.CustomAttributes);
			foreach (TypeDefinition type in module.Types)
			{
				this.TestType(type);
			}
		}

		// Token: 0x06001054 RID: 4180 RVA: 0x0001D584 File Offset: 0x0001B784
		private bool TypeAllowedExplicitLayout(TypeDefinition type)
		{
			TypeDefinition declaringType = type.DeclaringType;
			return ((declaringType != null) ? declaringType.Name : null) == "<PrivateImplementationDetails>" && type.Name.StartsWith("__StaticArrayInitTypeSize=");
		}

		// Token: 0x06001055 RID: 4181 RVA: 0x0001D5BC File Offset: 0x0001B7BC
		private void TestType(TypeDefinition type)
		{
			this.Location = type.ToString();
			if ((type.Attributes & TypeAttributes.ExplicitLayout) != TypeAttributes.NotPublic && !this.TypeAllowedExplicitLayout(type))
			{
				this.Touch("System.Private.CoreLib/System.Runtime.InteropServices.StructLayout", "attribute");
			}
			this.TestAttributes(type.CustomAttributes);
			if (type.IsArray)
			{
				this.TestType(type.GetElementType().Resolve());
			}
			foreach (FieldDefinition member in type.Fields)
			{
				this.TestField(member);
				this.TestAttributes(member.CustomAttributes);
			}
			foreach (PropertyDefinition member2 in type.Properties)
			{
				this.TestProperty(member2);
				this.TestAttributes(member2.CustomAttributes);
			}
			foreach (MethodDefinition member3 in type.Methods)
			{
				this.TestMethod(member3);
				this.TestAttributes(member3.CustomAttributes);
			}
			foreach (TypeDefinition member4 in type.NestedTypes)
			{
				this.TestType(member4);
				this.TestAttributes(member4.CustomAttributes);
			}
		}

		// Token: 0x06001056 RID: 4182 RVA: 0x0001D764 File Offset: 0x0001B964
		private void TestProperty(PropertyDefinition member)
		{
			if (member.PropertyType.IsGenericParameter)
			{
				return;
			}
			this.Touch(member.PropertyType);
		}

		// Token: 0x06001057 RID: 4183 RVA: 0x0001D784 File Offset: 0x0001B984
		private void TestAttributes(Collection<CustomAttribute> attributes)
		{
			if (attributes == null)
			{
				return;
			}
			foreach (CustomAttribute attr in attributes)
			{
				this.TestAttribute(attr);
			}
		}

		// Token: 0x06001058 RID: 4184 RVA: 0x0001D7D8 File Offset: 0x0001B9D8
		private void TestField(FieldDefinition member)
		{
			if (member.ContainsGenericParameter)
			{
				return;
			}
			if (member.HasLayoutInfo)
			{
				this.Touch("System.Private.CoreLib/System.Runtime.InteropServices.FieldOffset", "attribute");
			}
			this.Touch(member.FieldType);
		}

		// Token: 0x06001059 RID: 4185 RVA: 0x0001D80C File Offset: 0x0001BA0C
		private void TestMethod(MethodDefinition member)
		{
			if (member.IsNative)
			{
				this.Touch("System.Private.CoreLib/System.Runtime.InteropServices.DllImportAttribute", "attribute");
			}
			if (member.IsPInvokeImpl)
			{
				this.Touch("System.Private.CoreLib/System.Runtime.InteropServices.DllImportAttribute", "attribute");
			}
			if (member.IsUnmanagedExport)
			{
				this.Touch("System.Private.CoreLib/System.Runtime.InteropServices.DllImportAttribute", "attribute");
			}
			if (member.DebugInformation.HasSequencePoints)
			{
				this.UpdateLocation(member.DebugInformation.SequencePoints.First<SequencePoint>());
			}
			else
			{
				this.Location = member.FullName;
			}
			this.Touch(member, null);
			if (this.ShouldSkipExploration(member.Module.Assembly))
			{
				return;
			}
			this.Touch(member.MethodReturnType.ReturnType);
			if (member.HasBody)
			{
				foreach (Instruction instruction in member.Body.Instructions)
				{
					string i = this.Location;
					this.UpdateLocation(member.DebugInformation.GetSequencePoint(instruction));
					this.TestInstruction(member, instruction);
					this.Location = i;
				}
			}
		}

		// Token: 0x0600105A RID: 4186 RVA: 0x0001D938 File Offset: 0x0001BB38
		private void TestAttribute(CustomAttribute attr)
		{
			this.Touch(attr.AttributeType);
		}

		// Token: 0x0600105B RID: 4187 RVA: 0x0001D948 File Offset: 0x0001BB48
		private void TestInstruction(MethodDefinition method, Instruction instruction)
		{
			if (instruction.Operand is string)
			{
				return;
			}
			if (instruction.Operand is float)
			{
				return;
			}
			if (instruction.Operand is double)
			{
				return;
			}
			if (instruction.Operand is int)
			{
				return;
			}
			if (instruction.Operand is sbyte)
			{
				return;
			}
			Instruction[] instructions = instruction.Operand as Instruction[];
			if (instructions != null)
			{
				foreach (Instruction i in instructions)
				{
					this.TestInstruction(method, i);
				}
				return;
			}
			MethodReference methodref = instruction.Operand as MethodReference;
			if (methodref != null)
			{
				if (methodref.DeclaringType.IsArray)
				{
					this.Touch(methodref.DeclaringType.Resolve());
				}
				else
				{
					this.Touch(methodref.Resolve(), methodref);
				}
				this.Touch(methodref.MethodReturnType.ReturnType);
				GenericInstanceType git = methodref.DeclaringType as GenericInstanceType;
				if (git != null)
				{
					foreach (TypeReference param in git.GenericArguments)
					{
						this.Touch(param);
					}
				}
				GenericInstanceMethod gim = instruction.Operand as GenericInstanceMethod;
				if (gim != null)
				{
					foreach (TypeReference j in gim.GenericArguments)
					{
						this.Touch(j);
					}
				}
				foreach (GenericParameter param2 in methodref.GenericParameters)
				{
					this.Touch(param2);
				}
				foreach (ParameterDefinition param3 in methodref.Parameters)
				{
					this.Touch(param3.ParameterType);
				}
				return;
			}
			VariableDefinition vardef = instruction.Operand as VariableDefinition;
			if (vardef != null)
			{
				this.Touch(vardef.VariableType);
				return;
			}
			FieldDefinition fielddef = instruction.Operand as FieldDefinition;
			if (fielddef != null)
			{
				this.Touch(fielddef.FieldType);
				return;
			}
			TypeReference typeRef = instruction.Operand as TypeReference;
			if (typeRef != null)
			{
				this.Touch(typeRef);
				return;
			}
			FieldReference fieldRef = instruction.Operand as FieldReference;
			if (fieldRef != null)
			{
				this.Touch(fieldRef.FieldType);
				return;
			}
			ParameterDefinition paramDef = instruction.Operand as ParameterDefinition;
			if (paramDef != null)
			{
				this.Touch(paramDef.ParameterType);
				return;
			}
			Instruction instrct = instruction.Operand as Instruction;
			if (instrct != null)
			{
				this.TestInstruction(method, instrct);
				return;
			}
			object operand = instruction.Operand;
		}

		// Token: 0x0600105C RID: 4188 RVA: 0x0001DC24 File Offset: 0x0001BE24
		public bool ShouldSkipExploration(AssemblyDefinition candidate)
		{
			return this.Assembly != candidate;
		}

		// Token: 0x0600105D RID: 4189 RVA: 0x0001DC32 File Offset: 0x0001BE32
		internal void AddSafeAssembly(string name)
		{
			this.SafeAssemblies.Add(name);
		}

		// Token: 0x0600105E RID: 4190 RVA: 0x0001DC40 File Offset: 0x0001BE40
		internal bool RemoveSafeAssembly(string name)
		{
			return this.SafeAssemblies.Remove(name);
		}

		/// <summary>
		/// Remove touches that are inside addon depends or this dll.
		/// </summary>
		// Token: 0x0600105F RID: 4191 RVA: 0x0001DC50 File Offset: 0x0001BE50
		private void RemoveLocalTouches()
		{
			string self = this.Assembly.Name.Name;
			List<string> whitelist = new List<string>();
			whitelist.AddRange(this.SafeAssemblies.Select((string x) => x + "/"));
			whitelist.Add(this.Assembly.Name.Name + "/");
				from x in this.Touched
				where whitelist.Any((string y) => x.Key.StartsWith(y))
				select x.Key;
			using (Dictionary<string, AccessControl.Access>.KeyCollection.Enumerator enumerator = this.Touched.Keys.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string key = enumerator.Current;
					if (key.StartsWith(self + "/"))
					{
						this.Touched.Remove(key);
					}
					else if (this.SafeAssemblies.Any((string x) => key.StartsWith(x + "/")))
					{
						this.Touched.Remove(key);
					}
				}
			}
		}

		// Token: 0x06001060 RID: 4192 RVA: 0x0001DDBC File Offset: 0x0001BFBC
		private void UpdateLocation(SequencePoint sequencePoint)
		{
			if (sequencePoint == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted(sequencePoint.Document.Url);
			defaultInterpolatedStringHandler.AppendLiteral(":");
			defaultInterpolatedStringHandler.AppendFormatted<int>(sequencePoint.StartLine);
			this.Location = defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06001061 RID: 4193 RVA: 0x0001DE10 File Offset: 0x0001C010
		public AssemblyDefinition Resolve(AssemblyNameReference name)
		{
			AssemblyDefinition v;
			if (this.Assemblies.TryGetValue(name.Name, out v))
			{
				return v;
			}
			string dllName = name.Name + ".dll";
			string testPath = Path.Combine(Path.GetDirectoryName(typeof(object).Assembly.Location), dllName);
			if (!File.Exists(testPath))
			{
				testPath = Path.Combine(Path.GetDirectoryName(base.GetType().Assembly.Location), dllName);
			}
			AssemblyDefinition ad = AssemblyDefinition.ReadAssembly(testPath, new ReaderParameters
			{
				AssemblyResolver = this
			});
			this.Assemblies[name.Name] = ad;
			return ad;
		}

		// Token: 0x06001062 RID: 4194 RVA: 0x0001DEAF File Offset: 0x0001C0AF
		public AssemblyDefinition Resolve(AssemblyNameReference name, ReaderParameters parameters)
		{
			return this.Resolve(name);
		}

		// Token: 0x06001063 RID: 4195 RVA: 0x0001DEB8 File Offset: 0x0001C0B8
		public void Dispose()
		{
		}

		// Token: 0x06001064 RID: 4196 RVA: 0x0001DEBC File Offset: 0x0001C0BC
		public void LoadFromConfig(BaseFileSystem fs, string filename)
		{
			string path = Path.GetDirectoryName(filename);
			foreach (string line in fs.ReadAllText(filename).Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
			{
				if (!string.IsNullOrWhiteSpace(line))
				{
					if (line.StartsWith('@'))
					{
						string path2 = path;
						string text = line;
						int length = text.Length;
						int num = 1;
						int length2 = length - num;
						this.LoadFromConfig(fs, Path.Combine(path2, text.Substring(num, length2)));
					}
					else
					{
						string wildcard = line.Trim();
						wildcard = Regex.Escape(wildcard).Replace("\\*", ".*");
						wildcard = "^" + wildcard + "$";
						Regex regex = new Regex(wildcard);
						this.Rules.Add(regex);
					}
				}
			}
		}

		// Token: 0x06001065 RID: 4197 RVA: 0x0001DF88 File Offset: 0x0001C188
		public bool CheckRules(bool whitelist, List<string> errors)
		{
			bool allow = true;
			using (Dictionary<string, AccessControl.Access>.Enumerator enumerator = this.Touched.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, AccessControl.Access> touch = enumerator.Current;
					if (!this.Rules.Any((Regex x) => x.IsMatch(touch.Key)))
					{
						string locations = string.Join("\n", touch.Value.Locations.Select((string x) => "\t" + x));
						if (errors != null)
						{
							errors.Add(touch.Key + "\n" + locations);
						}
						allow = false;
					}
				}
			}
			if (allow && whitelist)
			{
				this.AddSafeAssembly(this.Assembly.Name.Name);
			}
			return allow;
		}

		// Token: 0x06001066 RID: 4198 RVA: 0x0001E07C File Offset: 0x0001C27C
		private bool Touch(string name, string type)
		{
			bool alreadyTouched = true;
			AccessControl.Access access;
			if (!this.Touched.TryGetValue(name, out access))
			{
				alreadyTouched = false;
				this.Touched[name] = new AccessControl.Access
				{
					Name = name,
					Type = type
				};
			}
			this.Touched[name].Locations.Add(this.Location);
			return alreadyTouched;
		}

		// Token: 0x06001067 RID: 4199 RVA: 0x0001E0D9 File Offset: 0x0001C2D9
		private bool Touch(TypeDefinition typedef)
		{
			return this.Touch(typedef.Module.Assembly.Name.Name + "/" + typedef.FullName, "type");
		}

		// Token: 0x06001068 RID: 4200 RVA: 0x0001E10C File Offset: 0x0001C30C
		private bool Touch(TypeReference typeRef)
		{
			if (typeRef.IsGenericParameter)
			{
				return false;
			}
			IModifierType typeMod = typeRef as IModifierType;
			if (typeMod != null)
			{
				return this.Touch(typeMod.ModifierType) || this.Touch(typeMod.ElementType);
			}
			GenericInstanceType git = typeRef as GenericInstanceType;
			if (git != null)
			{
				foreach (TypeReference param in git.GenericArguments)
				{
					this.Touch(param);
				}
			}
			if (typeRef.IsArray || typeRef.IsByReference)
			{
				return this.Touch(typeRef.GetElementType());
			}
			TypeDefinition typeDef = typeRef.Resolve();
			if (typeDef == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(43, 1);
				defaultInterpolatedStringHandler.AppendLiteral("TypeDefinition was null - couldn't resolve ");
				defaultInterpolatedStringHandler.AppendFormatted<TypeReference>(typeRef);
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return this.Touch(typeDef);
		}

		// Token: 0x06001069 RID: 4201 RVA: 0x0001E1F8 File Offset: 0x0001C3F8
		private bool Touch(MethodDefinition typedef, MethodReference source = null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
			if (typedef == null)
			{
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 1);
				defaultInterpolatedStringHandler.AppendLiteral("MethodDefinition was null - couldn't resolve ");
				defaultInterpolatedStringHandler.AppendFormatted<MethodReference>(source);
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			string parms = string.Join(", ", typedef.Parameters.Select((ParameterDefinition x) => x.ParameterType.ToString()));
			if (!string.IsNullOrWhiteSpace(parms))
			{
				parms = " " + parms + " ";
			}
			string gparms = string.Join(",", typedef.GenericParameters.Select((GenericParameter x) => x.Name.ToString()));
			if (!string.IsNullOrWhiteSpace(gparms))
			{
				gparms = "<" + gparms + ">";
			}
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 5);
			defaultInterpolatedStringHandler.AppendFormatted(typedef.Module.Assembly.Name.Name);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(typedef.DeclaringType.FullName);
			defaultInterpolatedStringHandler.AppendLiteral(".");
			defaultInterpolatedStringHandler.AppendFormatted(typedef.Name);
			defaultInterpolatedStringHandler.AppendFormatted(gparms);
			defaultInterpolatedStringHandler.AppendLiteral("(");
			defaultInterpolatedStringHandler.AppendFormatted(parms);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			this.Touch(defaultInterpolatedStringHandler.ToStringAndClear(), "method");
			this.Touch(typedef.ReturnType);
			foreach (ParameterDefinition param in typedef.Parameters)
			{
				this.Touch(param.ParameterType);
			}
			return false;
		}

		// Token: 0x0400126C RID: 4716
		private static Logger log = Logging.GetLogger(null);

		// Token: 0x0400126D RID: 4717
		protected Dictionary<string, AssemblyDefinition> Assemblies = new Dictionary<string, AssemblyDefinition>();

		// Token: 0x0400126E RID: 4718
		protected AssemblyDefinition Assembly;

		// Token: 0x0400126F RID: 4719
		protected List<string> SafeAssemblies = new List<string>();

		// Token: 0x04001270 RID: 4720
		protected string Location;

		// Token: 0x04001271 RID: 4721
		public List<Regex> Rules = new List<Regex>();

		// Token: 0x04001272 RID: 4722
		public Dictionary<string, AccessControl.Access> Touched = new Dictionary<string, AccessControl.Access>();

		// Token: 0x020003E9 RID: 1001
		internal class Access
		{
			// Token: 0x1700048D RID: 1165
			// (get) Token: 0x06001772 RID: 6002 RVA: 0x00036117 File Offset: 0x00034317
			// (set) Token: 0x06001773 RID: 6003 RVA: 0x0003611F File Offset: 0x0003431F
			public string Name { get; set; }

			// Token: 0x1700048E RID: 1166
			// (get) Token: 0x06001774 RID: 6004 RVA: 0x00036128 File Offset: 0x00034328
			// (set) Token: 0x06001775 RID: 6005 RVA: 0x00036130 File Offset: 0x00034330
			public string Type { get; set; }

			// Token: 0x1700048F RID: 1167
			// (get) Token: 0x06001776 RID: 6006 RVA: 0x00036139 File Offset: 0x00034339
			// (set) Token: 0x06001777 RID: 6007 RVA: 0x00036141 File Offset: 0x00034341
			public List<string> Locations { get; set; } = new List<string>();
		}
	}
}
