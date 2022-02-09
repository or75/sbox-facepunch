using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Sandbox.Upgraders
{
	/// <summary>
	/// This upgrader will use reflection to go through each field of a new instance, and
	/// populate it with an equivalent value found from the old instance. For newly-added
	/// fields, it attempts to determine a default value from the constructor of the type.
	/// </summary>
	// Token: 0x02000014 RID: 20
	[UpgraderGroup(typeof(RootUpgraderGroup), GroupOrder.Last)]
	public class DefaultUpgrader : Hotload.InstanceUpgrader
	{
		// Token: 0x060000A1 RID: 161 RVA: 0x000052D7 File Offset: 0x000034D7
		protected override void OnInitialize()
		{
			this.SkipUpgrader = base.GetUpgrader<SkipUpgrader>();
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000052E5 File Offset: 0x000034E5
		public override bool ShouldProcessType(Type type)
		{
			return true;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000052E8 File Offset: 0x000034E8
		protected override void OnHotloadComplete()
		{
			foreach (CompletionTask task in this.CompletionTasks.Reverse<CompletionTask>())
			{
				try
				{
					task.OnComplete();
				}
				catch (Exception e)
				{
					base.Log(e, null, null);
				}
			}
			this.CompletionTasks.Clear();
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00005360 File Offset: 0x00003560
		protected override bool OnTryCreateNewInstance(object oldInstance, object context, out object newInstance)
		{
			return this.TryCreateNewInstance(oldInstance, null, out newInstance);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000536B File Offset: 0x0000356B
		protected override bool OnTryUpgradeInstance(object oldInstance, object newInstance, bool createdElsewhere)
		{
			base.SuppressFinalize(oldInstance, newInstance);
			if (createdElsewhere)
			{
				this.PostCreateInstance(oldInstance, newInstance, false);
			}
			return true;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00005384 File Offset: 0x00003584
		public bool TryCreateNewInstance(object oldInstance, Type forceReplacementType, out object newInstance)
		{
			Type oldType = oldInstance.GetType();
			Type newType = forceReplacementType ?? base.GetNewType(oldType);
			newInstance = ((newType != oldType) ? FormatterServices.GetUninitializedObject(newType) : oldInstance);
			this.PostCreateInstance(oldInstance, newInstance, forceReplacementType != null);
			return true;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000053CA File Offset: 0x000035CA
		private void PostCreateInstance(object oldInstance, object newInstance, bool forcedReplacementType)
		{
			if (oldInstance.GetType().IsValueType)
			{
				base.ProcessInstance(oldInstance, newInstance);
				return;
			}
			if (!forcedReplacementType)
			{
				base.AddCachedInstance(oldInstance, newInstance);
			}
			base.ScheduleProcessInstance(oldInstance, newInstance);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000053F8 File Offset: 0x000035F8
		protected override int OnProcessInstance(object oldInstance, object newInstance)
		{
			this.ProcessObjectFields(oldInstance, newInstance);
			Hotload.IBaseCallback newBaseCallback = newInstance as Hotload.IBaseCallback;
			if (newBaseCallback != null)
			{
				this.CompletionTasks.Add(new CompletionTask(newBaseCallback, oldInstance as Hotload.IBaseCallback));
			}
			if (oldInstance != newInstance)
			{
				Hotload.IBorn iBorn = newInstance as Hotload.IBorn;
				if (iBorn != null)
				{
					try
					{
						iBorn.HotloadBorn(oldInstance);
					}
					catch (Exception e)
					{
						base.Log(e, null, null);
					}
				}
			}
			return 1;
		}

		/// <summary>
		/// Get all fields on this type, and types it inherits from, that we should process.
		/// </summary>
		// Token: 0x060000A9 RID: 169 RVA: 0x00005464 File Offset: 0x00003664
		private IEnumerable<FieldInfo> GetFieldsToProcess(Type oldType, Type newType, BindingFlags flags, bool canSkip)
		{
			if (canSkip && oldType != null && this.SkipUpgrader.ShouldProcessType(oldType))
			{
				yield break;
			}
			if (newType.BaseType != null)
			{
				Type oldBaseType = ((oldType != null) ? oldType.BaseType : null);
				if (oldBaseType != null && base.GetNewType(oldBaseType) != newType.BaseType)
				{
					oldBaseType = null;
				}
				foreach (FieldInfo fieldInfo in this.GetFieldsToProcess(oldBaseType, newType.BaseType, flags, canSkip))
				{
					yield return fieldInfo;
				}
				IEnumerator<FieldInfo> enumerator = null;
			}
			foreach (FieldInfo fieldInfo2 in newType.GetFields(flags))
			{
				if (!(fieldInfo2.DeclaringType != newType) && !fieldInfo2.FieldType.IsPointer && fieldInfo2.GetCustomAttribute<Hotload.SkipAttribute>() == null)
				{
					yield return fieldInfo2;
				}
			}
			FieldInfo[] array = null;
			yield break;
			yield break;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00005491 File Offset: 0x00003691
		public void ProcessObjectFields(object instance)
		{
			this.ProcessObjectFields(instance, instance);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000549C File Offset: 0x0000369C
		public void ProcessObjectFields(object oldInst, object newInst)
		{
			Type oldType = oldInst.GetType();
			Type newType = newInst.GetType();
			foreach (FieldInfo dstField in this.GetFieldsToProcess(oldType, newType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, oldInst == newInst))
			{
				FieldInfo srcField = ((oldType == newType) ? dstField : base.GetOldField(oldType, dstField, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
				object newValue;
				if (srcField == null)
				{
					if (!base.TryGetDefaultValue(dstField, out newValue))
					{
						continue;
					}
				}
				else
				{
					newValue = this.ProcessFieldValue(oldInst, srcField);
				}
				try
				{
					dstField.SetValue(newInst, newValue);
				}
				catch (Exception e)
				{
					base.Log(e, null, dstField);
				}
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00005558 File Offset: 0x00003758
		private object ProcessFieldValue(object oldInst, FieldInfo srcField)
		{
			object value = srcField.GetValue(oldInst);
			return base.GetNewInstanceFromField(value, oldInst);
		}

		// Token: 0x04000035 RID: 53
		private readonly HashSet<CompletionTask> CompletionTasks = new HashSet<CompletionTask>();

		// Token: 0x04000036 RID: 54
		private SkipUpgrader SkipUpgrader;
	}
}
