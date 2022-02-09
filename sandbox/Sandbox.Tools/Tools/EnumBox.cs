using System;
using System.Collections.Generic;
using Sandbox;

namespace Tools
{
	// Token: 0x020000D7 RID: 215
	public class EnumBox : ComboBox
	{
		// Token: 0x060017C8 RID: 6088 RVA: 0x0005BA38 File Offset: 0x00059C38
		public EnumBox(Widget parent, Type type)
			: base(parent)
		{
			this.Type = type;
			if (type.IsEnum)
			{
				Array Values = type.GetEnumValues();
				DisplayInfo[] Info = DisplayInfo.ForEnumValues(type);
				for (int i = 0; i < Values.Length; i++)
				{
					this.NameToEnum[Info[i].Name] = Values.GetValue(i);
					this.EnumToName[Values.GetValue(i)] = Info[i].Name;
					base.AddItem(Info[i].Name, Info[i].Icon, null);
				}
				return;
			}
		}

		// Token: 0x060017C9 RID: 6089 RVA: 0x0005BAEC File Offset: 0x00059CEC
		protected override void DataValueChanged(object obj)
		{
			if (obj == null)
			{
				return;
			}
			string str = obj as string;
			long i;
			if (str != null && long.TryParse(str, out i))
			{
				obj = Enum.ToObject(this.Type, i);
			}
			string foundName;
			if (this.EnumToName.TryGetValue(obj, out foundName))
			{
				base.TrySelectNamed(foundName);
				return;
			}
		}

		// Token: 0x060017CA RID: 6090 RVA: 0x0005BB38 File Offset: 0x00059D38
		public override void PushToBinding()
		{
			if (base.DataBinding == null)
			{
				return;
			}
			object val;
			if (this.NameToEnum.TryGetValue(base.CurrentText, out val))
			{
				base.DataBinding.SetValue(val);
			}
		}

		// Token: 0x040004E2 RID: 1250
		public Dictionary<string, object> NameToEnum = new Dictionary<string, object>();

		// Token: 0x040004E3 RID: 1251
		public Dictionary<object, string> EnumToName = new Dictionary<object, string>();

		// Token: 0x040004E4 RID: 1252
		public Type Type;
	}
}
