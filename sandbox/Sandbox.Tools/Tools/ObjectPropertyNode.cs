using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Sandbox;
using Sandbox.Internal;

namespace Tools
{
	// Token: 0x02000095 RID: 149
	internal class ObjectPropertyNode : ReflectionNode
	{
		// Token: 0x06001463 RID: 5219 RVA: 0x00055C94 File Offset: 0x00053E94
		public override DataNode.Flags GetFlags(int column)
		{
			if (column > 0 && this.Property.SetMethod == null)
			{
				return (DataNode.Flags)33;
			}
			return base.GetFlags(column);
		}

		// Token: 0x06001464 RID: 5220 RVA: 0x00055CB7 File Offset: 0x00053EB7
		public ObjectPropertyNode(object obj, PropertyInfo property)
			: base(null)
		{
			this.TargetObject = obj;
			this.Property = property;
			this.UpdateValue();
		}

		// Token: 0x06001465 RID: 5221 RVA: 0x00055CD4 File Offset: 0x00053ED4
		private void UpdateValue()
		{
			try
			{
				this.Value = this.Property.GetValue(this.TargetObject);
			}
			catch (Exception e)
			{
				GlobalToolsNamespace.Log.Warning(e, FormattableStringFactory.Create("{0} when reading {1}", new object[] { e.Message, this.Property }));
			}
			this.UpdateProperties();
		}

		// Token: 0x06001466 RID: 5222 RVA: 0x00055D40 File Offset: 0x00053F40
		public override void PaintItem(in Rect rect, int column)
		{
			if (column == 0)
			{
				DisplayInfo info = DisplayInfo.ForProperty(this.Property, true);
				Paint.SetDefaultFont(8f, 500, false, false);
				Paint.DrawText(rect, info.Name, (TextFlag)4129);
			}
			if (column == 1)
			{
				this.UpdateValue();
				Paint.SetDefaultFont(8f, 400, false, false);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<object>(this.Value);
				Paint.DrawText(rect, defaultInterpolatedStringHandler.ToStringAndClear(), (TextFlag)4129);
			}
		}

		// Token: 0x040001F7 RID: 503
		public object TargetObject;

		// Token: 0x040001F8 RID: 504
		public PropertyInfo Property;
	}
}
