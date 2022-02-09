using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Sandbox.Upgraders
{
	// Token: 0x02000012 RID: 18
	[UpgraderGroup(typeof(ReferenceTypeUpgraderGroup), GroupOrder.Default)]
	internal class ArrayUpgrader : Hotload.InstanceUpgrader
	{
		// Token: 0x0600008B RID: 139 RVA: 0x00004B1A File Offset: 0x00002D1A
		public override bool ShouldProcessType(Type type)
		{
			return type.IsArray;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00004B22 File Offset: 0x00002D22
		protected override void OnInitialize()
		{
			this.SkipUpgrader = base.GetUpgrader<SkipUpgrader>();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00004B30 File Offset: 0x00002D30
		protected override void OnClearCache()
		{
			foreach (KeyValuePair<Type, StructArrayConverter> pair in this.ConverterCache)
			{
				pair.Value.Dispose();
			}
			this.ConverterCache.Clear();
			this.BlittableStructsCache.Clear();
			this.ChangedStructsCache.Clear();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00004BAC File Offset: 0x00002DAC
		private static Array CreateNewInstance(Type newElemType, Array oldArray)
		{
			if (oldArray.Rank == 1)
			{
				return Array.CreateInstance(newElemType, oldArray.Length);
			}
			int[] lengths = Enumerable.Range(0, oldArray.Rank).Select(new Func<int, int>(oldArray.GetLength)).ToArray<int>();
			return Array.CreateInstance(newElemType, lengths);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00004BFC File Offset: 0x00002DFC
		protected override bool OnTryCreateNewInstance(object oldInstance, object context, out object newInstance)
		{
			Type oldElemType = oldInstance.GetType().GetElementType();
			Type newElemType = base.GetNewType(oldElemType);
			Array oldArray = (Array)oldInstance;
			newInstance = ((newElemType != oldElemType) ? ArrayUpgrader.CreateNewInstance(newElemType, oldArray) : oldArray);
			return true;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00004C3A File Offset: 0x00002E3A
		protected override bool OnTryUpgradeInstance(object oldInstance, object newInstance, bool createdElsewhere)
		{
			base.AddCachedInstance(oldInstance, newInstance);
			base.SuppressFinalize(oldInstance, newInstance);
			base.ScheduleProcessInstance(oldInstance, newInstance);
			return true;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004C58 File Offset: 0x00002E58
		protected override int OnProcessInstance(object oldInstance, object newInstance)
		{
			Type oldType = oldInstance.GetType();
			Type newType = newInstance.GetType();
			return this.ProcessArrayElements((Array)oldInstance, (Array)newInstance, oldType.GetElementType(), newType.GetElementType());
		}

		/// <returns>True if a deep copy was required.</returns>
		// Token: 0x06000092 RID: 146 RVA: 0x00004C94 File Offset: 0x00002E94
		private int ProcessArrayElements(Array oldInst, Array newInst, Type oldElemType, Type newElemType)
		{
			if (this.CanSkipType(oldElemType) && oldInst == newInst)
			{
				return 1;
			}
			for (int i = 0; i < oldInst.Rank; i++)
			{
				if (oldInst.GetLowerBound(i) != 0)
				{
					throw new NotImplementedException("Array with lower bound != 0 not supported.");
				}
				if (oldInst.GetLength(i) == 0)
				{
					return 1;
				}
			}
			TypeInfo oldElemTypeInfo = oldElemType.GetTypeInfo();
			if (oldElemTypeInfo.IsValueType && !oldElemTypeInfo.IsPrimitive && !this.HasStructChanged(oldElemType, newElemType ?? oldElemType))
			{
				if (newElemType == oldElemType && oldInst == newInst)
				{
					return 1;
				}
				if (oldInst.Rank == 1)
				{
					this.BlockCopyStructArray(oldInst, newInst, oldElemType, newElemType ?? oldElemType);
					return 1;
				}
			}
			if (oldInst.Rank == 1)
			{
				int length = Math.Min(oldInst.Length, newInst.Length);
				for (int j = 0; j < length; j++)
				{
					object oldValue = oldInst.GetValue(j);
					object newValue = base.GetNewInstance(oldValue);
					newInst.SetValue(newValue, j);
				}
			}
			else
			{
				if (oldInst.Rank != newInst.Rank)
				{
					throw new NotImplementedException("Rank change in in-place array upgrades not supported.");
				}
				int[] indices = new int[oldInst.Rank];
				do
				{
					object oldValue2 = oldInst.GetValue(indices);
					object newValue2 = base.GetNewInstance(oldValue2);
					newInst.SetValue(newValue2, indices);
				}
				while (ArrayUpgrader.IncrementIndices(oldInst, indices));
			}
			return newInst.Length;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00004DCC File Offset: 0x00002FCC
		private static bool IncrementIndices(Array array, int[] indices)
		{
			for (int i = 0; i < array.Rank; i++)
			{
				int length = array.GetLength(i);
				int num = i;
				int num2 = indices[num] + 1;
				indices[num] = num2;
				if (num2 < length)
				{
					return true;
				}
				indices[i] = 0;
			}
			return false;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00004E0C File Offset: 0x0000300C
		private bool HasStructChangedUncached(Type oldType, Type newType)
		{
			bool result;
			try
			{
				TypeInfo oldInfo = oldType.GetTypeInfo();
				TypeInfo newInfo = newType.GetTypeInfo();
				if (oldInfo.IsGenericType)
				{
					result = true;
				}
				else if (newInfo.IsGenericType)
				{
					result = true;
				}
				else if (oldInfo.IsEnum != newInfo.IsEnum)
				{
					result = true;
				}
				else if (oldInfo.IsEnum)
				{
					Type newUnderlyingType = Enum.GetUnderlyingType(newType);
					if (Enum.GetUnderlyingType(oldType) != newUnderlyingType)
					{
						result = true;
					}
					else
					{
						string[] oldNames = Enum.GetNames(oldType);
						string[] newNames = Enum.GetNames(newType);
						if (oldNames.Length != newNames.Length)
						{
							result = true;
						}
						else
						{
							for (int i = 0; i < oldNames.Length; i++)
							{
								if (oldNames[i] != newNames[i])
								{
									return true;
								}
								object obj = Convert.ChangeType(Enum.Parse(oldType, oldNames[i]), newUnderlyingType);
								object newValue = Convert.ChangeType(Enum.Parse(newType, newNames[i]), newUnderlyingType);
								if (!obj.Equals(newValue))
								{
									return true;
								}
							}
							result = false;
						}
					}
				}
				else if (Marshal.SizeOf(oldType) != Marshal.SizeOf(newType))
				{
					result = true;
				}
				else
				{
					FieldInfo[] oldFields = oldType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					FieldInfo[] newFields = newType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					if (oldFields.Length != newFields.Length)
					{
						result = true;
					}
					else
					{
						for (int j = 0; j < oldFields.Length; j++)
						{
							FieldInfo oldField = oldFields[j];
							FieldInfo newField = newFields[j];
							if (oldField.Name != newField.Name)
							{
								return true;
							}
							if (oldField.FieldType != newField.FieldType && base.GetNewType(oldField.FieldType) != newField.FieldType)
							{
								return true;
							}
							TypeInfo typeInfo = newField.FieldType.GetTypeInfo();
							if (typeInfo.IsByRef && !this.CanSkipType(newField.FieldType))
							{
								return true;
							}
							if (typeInfo.IsValueType && !typeInfo.IsPrimitive && this.HasStructChanged(oldField.FieldType, newField.FieldType))
							{
								return true;
							}
						}
						result = false;
					}
				}
			}
			catch (Exception e)
			{
				HotloadEntryType type = HotloadEntryType.Warning;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(39, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Exception while checking struct type ");
				defaultInterpolatedStringHandler.AppendFormatted(oldType.FullName);
				defaultInterpolatedStringHandler.AppendLiteral(": ");
				defaultInterpolatedStringHandler.AppendFormatted<Exception>(e);
				base.Log(type, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				result = true;
			}
			return result;
		}

		/// <summary>
		/// Determine if the size and field layout of a struct has changed. This should
		/// only return true if it is safe to bitwise copy from old instances of the struct
		/// to new instances. This will return true if the struct contains reference-type
		/// members.
		/// </summary>
		// Token: 0x06000095 RID: 149 RVA: 0x00005094 File Offset: 0x00003294
		private bool HasStructChanged(Type oldType, Type newType)
		{
			bool changed;
			if (this.ChangedStructsCache.TryGetValue(oldType, out changed))
			{
				return changed;
			}
			bool isBlittable;
			if (!this.BlittableStructsCache.TryGetValue(oldType, out isBlittable))
			{
				isBlittable = this.IsTypeBlittableUncached(oldType);
				this.BlittableStructsCache.Add(oldType, isBlittable);
			}
			if (!isBlittable)
			{
				return true;
			}
			changed = this.HasStructChangedUncached(oldType, newType);
			this.ChangedStructsCache.Add(oldType, changed);
			return changed;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000050F4 File Offset: 0x000032F4
		private bool IsTypeBlittableUncached(Type type)
		{
			if (type.IsEnum)
			{
				return false;
			}
			if (type.IsPrimitive)
			{
				return true;
			}
			if (type.IsClass || type.IsInterface)
			{
				return false;
			}
			bool result;
			try
			{
				GCHandle.Alloc(FormatterServices.GetUninitializedObject(type), GCHandleType.Pinned).Free();
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00005158 File Offset: 0x00003358
		private void BlockCopyStructArray(Array oldInst, Array newInst, Type oldElemType, Type newElemType)
		{
			if (oldElemType.IsEnum || newElemType.IsEnum)
			{
				throw new NotImplementedException("Block copying enum arrays isn't supported yet.");
			}
			StructArrayConverter converter;
			if (!this.ConverterCache.TryGetValue(oldElemType, out converter))
			{
				converter = StructArrayConverter.Create(oldElemType, newElemType);
				this.ConverterCache.Add(oldElemType, converter);
			}
			converter.BlockCopy(oldInst, newInst);
		}

		/// <summary>
		/// Return true if type is to be thought of as a primitive
		/// ie - a type that never changes, and can just be copied
		/// such as a bool, string, float, pointer.
		/// </summary>
		// Token: 0x06000098 RID: 152 RVA: 0x000051B0 File Offset: 0x000033B0
		private bool CanSkipType(Type t)
		{
			TypeInfo ti = t.GetTypeInfo();
			return ti.IsPrimitive || ti.IsPointer || t == typeof(string) || this.SkipUpgrader.ShouldProcessType(t);
		}

		// Token: 0x04000030 RID: 48
		private readonly Dictionary<Type, bool> BlittableStructsCache = new Dictionary<Type, bool>();

		// Token: 0x04000031 RID: 49
		private readonly Dictionary<Type, bool> ChangedStructsCache = new Dictionary<Type, bool>();

		// Token: 0x04000032 RID: 50
		private SkipUpgrader SkipUpgrader;

		// Token: 0x04000033 RID: 51
		private readonly Dictionary<Type, StructArrayConverter> ConverterCache = new Dictionary<Type, StructArrayConverter>();
	}
}
