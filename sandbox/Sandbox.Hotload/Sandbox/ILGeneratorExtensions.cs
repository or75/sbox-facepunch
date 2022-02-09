using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Sandbox
{
	// Token: 0x0200000C RID: 12
	internal static class ILGeneratorExtensions
	{
		// Token: 0x0600006B RID: 107 RVA: 0x00003D3C File Offset: 0x00001F3C
		static ILGeneratorExtensions()
		{
			List<OpCode> emitOpCodes = new List<OpCode>();
			int max = 0;
			FieldInfo[] fields = typeof(OpCodes).GetFields(BindingFlags.Static | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			{
				OpCode value = (OpCode)fields[i].GetValue(null);
				emitOpCodes.Add(value);
				max = Math.Max(max, (int)(value.Value + 1));
			}
			ILGeneratorExtensions.ConversionTable = new OpCode[max];
			foreach (OpCode emitOpCode in emitOpCodes)
			{
				if (emitOpCode.Value >= 0)
				{
					ILGeneratorExtensions.ConversionTable[(int)emitOpCode.Value] = emitOpCode;
				}
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003E00 File Offset: 0x00002000
		private static OpCode Convert(this OpCode code)
		{
			return ILGeneratorExtensions.ConversionTable[(int)code.Value];
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003E14 File Offset: 0x00002014
		private static void MarkLabel(this ILGenerator il, Dictionary<Instruction, Label> labelDict, Instruction inst)
		{
			Label label;
			if (!labelDict.TryGetValue(inst, out label))
			{
				return;
			}
			il.MarkLabel(label);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003E34 File Offset: 0x00002034
		private static Label DefineLabel(this ILGenerator il, Dictionary<Instruction, Label> labelDict, Instruction inst)
		{
			Label label;
			if (labelDict.TryGetValue(inst, out label))
			{
				return label;
			}
			label = il.DefineLabel();
			labelDict.Add(inst, label);
			return label;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003E60 File Offset: 0x00002060
		private static LocalBuilder DeclareLocal(this ILGenerator il, Module context, Dictionary<VariableDefinition, LocalBuilder> localDict, VariableDefinition variable)
		{
			LocalBuilder local;
			if (localDict.TryGetValue(variable, out local))
			{
				return local;
			}
			Type type = context.ResolveType(variable.VariableType);
			local = il.DeclareLocal(type, variable.IsPinned);
			localDict.Add(variable, local);
			return local;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003EA0 File Offset: 0x000020A0
		public static void Emit(this ILGenerator il, Module context, Instruction first, Instruction until)
		{
			List<Instruction> list = new List<Instruction>();
			Dictionary<Instruction, Label> labelDict = new Dictionary<Instruction, Label>();
			Dictionary<VariableDefinition, LocalBuilder> localDict = new Dictionary<VariableDefinition, LocalBuilder>();
			do
			{
				list.Add(first);
			}
			while ((first = first.Next) != until);
			foreach (Instruction inst in list)
			{
				if (inst.Operand is Instruction)
				{
					Instruction label = (Instruction)inst.Operand;
					inst.Operand = il.DefineLabel(labelDict, label);
				}
				else if (inst.Operand is Instruction[])
				{
					Instruction[] labels = (Instruction[])inst.Operand;
					Label[] defined = new Label[labels.Length];
					for (int i = 0; i < labels.Length; i++)
					{
						defined[i] = il.DefineLabel(labelDict, labels[i]);
					}
					inst.Operand = defined;
				}
				else if (inst.Operand is VariableDefinition)
				{
					VariableDefinition vari = (VariableDefinition)inst.Operand;
					inst.Operand = il.DeclareLocal(context, localDict, vari);
				}
				else if (inst.Operand is TypeReference)
				{
					TypeReference tr = (TypeReference)inst.Operand;
					inst.Operand = context.ResolveType(tr);
				}
				else if (inst.Operand is FieldReference)
				{
					FieldReference fr = (FieldReference)inst.Operand;
					inst.Operand = context.ResolveField(fr);
				}
				else if (inst.Operand is MethodReference)
				{
					MethodReference mr = (MethodReference)inst.Operand;
					inst.Operand = context.ResolveMethod(mr);
				}
			}
			foreach (Instruction inst2 in list)
			{
				il.MarkLabel(labelDict, inst2);
				il.Emit(inst2);
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000040C0 File Offset: 0x000022C0
		private static void Emit(this ILGenerator il, Instruction inst)
		{
			OpCode opCode = inst.OpCode.Convert();
			if (inst.Operand == null)
			{
				il.Emit(opCode);
				return;
			}
			if (inst.Operand is string)
			{
				il.Emit(opCode, (string)inst.Operand);
				return;
			}
			if (inst.Operand is Label)
			{
				il.Emit(opCode, (Label)inst.Operand);
				return;
			}
			if (inst.Operand is Label[])
			{
				il.Emit(opCode, (Label[])inst.Operand);
				return;
			}
			if (inst.Operand is Type)
			{
				il.Emit(opCode, (Type)inst.Operand);
				return;
			}
			if (inst.Operand is FieldInfo)
			{
				il.Emit(opCode, (FieldInfo)inst.Operand);
				return;
			}
			if (inst.Operand is MethodInfo)
			{
				il.Emit(opCode, (MethodInfo)inst.Operand);
				return;
			}
			if (inst.Operand is ConstructorInfo)
			{
				il.Emit(opCode, (ConstructorInfo)inst.Operand);
				return;
			}
			if (inst.Operand is LocalBuilder)
			{
				il.Emit(opCode, (LocalBuilder)inst.Operand);
				return;
			}
			if (inst.Operand is sbyte)
			{
				il.Emit(opCode, (sbyte)inst.Operand);
				return;
			}
			if (inst.Operand is byte)
			{
				il.Emit(opCode, (byte)inst.Operand);
				return;
			}
			if (inst.Operand is short)
			{
				il.Emit(opCode, (short)inst.Operand);
				return;
			}
			if (inst.Operand is int)
			{
				il.Emit(opCode, (int)inst.Operand);
				return;
			}
			if (inst.Operand is long)
			{
				il.Emit(opCode, (long)inst.Operand);
				return;
			}
			if (inst.Operand is float)
			{
				il.Emit(opCode, (float)inst.Operand);
				return;
			}
			if (inst.Operand is double)
			{
				il.Emit(opCode, (double)inst.Operand);
				return;
			}
			throw new NotImplementedException(inst.Operand.GetType().FullName);
		}

		// Token: 0x04000027 RID: 39
		private static readonly OpCode[] ConversionTable;
	}
}
