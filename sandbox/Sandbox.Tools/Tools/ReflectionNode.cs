using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Tools
{
	// Token: 0x02000094 RID: 148
	public class ReflectionNode : DataNode
	{
		// Token: 0x0600145A RID: 5210 RVA: 0x00055A39 File Offset: 0x00053C39
		public override DataNode.Flags GetFlags(int column)
		{
			return (DataNode.Flags)33;
		}

		// Token: 0x0600145B RID: 5211 RVA: 0x00055A3F File Offset: 0x00053C3F
		public ReflectionNode(object obj)
		{
			this.Value = obj;
			this.UpdateProperties();
		}

		// Token: 0x0600145C RID: 5212 RVA: 0x00055A5F File Offset: 0x00053C5F
		internal virtual void UpdateProperties()
		{
			if (this.Value == null)
			{
				this.Properties = null;
				return;
			}
			this.Properties = (from x in this.Value.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy)
				where this.IsPropertyAcceptable(x)
				select x).ToArray<PropertyInfo>();
		}

		// Token: 0x0600145D RID: 5213 RVA: 0x00055AA0 File Offset: 0x00053CA0
		private bool IsPropertyAcceptable(PropertyInfo x)
		{
			return !(x.GetMethod == null) && !x.GetMethod.IsStatic && x.CanRead && x.GetIndexParameters().Length == 0 && !x.PropertyType.IsByRefLike;
		}

		// Token: 0x0600145E RID: 5214 RVA: 0x00055AF4 File Offset: 0x00053CF4
		public override DataNode CreateChildNode(int row)
		{
			IEnumerable ienumerable = this.Value as IEnumerable;
			if (ienumerable != null)
			{
				int c = 0;
				foreach (object e in ienumerable)
				{
					if (row == c)
					{
						ReflectionNode reflectionNode = new ReflectionNode(e);
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
						defaultInterpolatedStringHandler.AppendLiteral("[");
						defaultInterpolatedStringHandler.AppendFormatted<int>(row);
						defaultInterpolatedStringHandler.AppendLiteral("]");
						reflectionNode.Title = defaultInterpolatedStringHandler.ToStringAndClear();
						return reflectionNode;
					}
					c++;
				}
			}
			return new ObjectPropertyNode(this.Value, this.Properties[row]);
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600145F RID: 5215 RVA: 0x00055BB0 File Offset: 0x00053DB0
		public override int Columns
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06001460 RID: 5216 RVA: 0x00055BB4 File Offset: 0x00053DB4
		public override int Rows
		{
			get
			{
				if (this.Value == null)
				{
					return 0;
				}
				if (this.Value is string)
				{
					return 0;
				}
				IEnumerable ienumerable = this.Value as IEnumerable;
				if (ienumerable != null)
				{
					int c = 0;
					foreach (object obj in ienumerable)
					{
						c++;
					}
					return c;
				}
				PropertyInfo[] properties = this.Properties;
				if (properties == null)
				{
					return 0;
				}
				return properties.Length;
			}
		}

		// Token: 0x06001461 RID: 5217 RVA: 0x00055C3C File Offset: 0x00053E3C
		public override void PaintItem(in Rect rect, int column)
		{
			if (column == 0)
			{
				Paint.DrawText(rect, this.Title, TextFlag.LeftCenter);
			}
			if (column == 1)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<object>(this.Value);
				Paint.DrawText(rect, defaultInterpolatedStringHandler.ToStringAndClear(), TextFlag.AlignCenter);
			}
		}

		// Token: 0x040001F3 RID: 499
		public string Title = "";

		// Token: 0x040001F4 RID: 500
		public object Value;

		// Token: 0x040001F5 RID: 501
		public bool hasEditor;

		// Token: 0x040001F6 RID: 502
		private PropertyInfo[] Properties;
	}
}
