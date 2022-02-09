using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using NativeEngine;

namespace Sandbox.UI
{
	// Token: 0x0200011D RID: 285
	public class ButtonEvent : IEquatable<ButtonEvent>
	{
		// Token: 0x17000355 RID: 853
		// (get) Token: 0x060015EF RID: 5615 RVA: 0x000582C0 File Offset: 0x000564C0
		[Nullable(1)]
		protected virtual Type EqualityContract
		{
			[NullableContext(1)]
			[CompilerGenerated]
			get
			{
				return typeof(ButtonEvent);
			}
		}

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x060015F0 RID: 5616 RVA: 0x000582CC File Offset: 0x000564CC
		public string Button { get; }

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x060015F1 RID: 5617 RVA: 0x000582D4 File Offset: 0x000564D4
		public bool Pressed { get; }

		// Token: 0x060015F2 RID: 5618 RVA: 0x000582DC File Offset: 0x000564DC
		internal ButtonEvent(string button, bool pressed)
		{
			this.Button = button;
			this.Pressed = pressed;
		}

		// Token: 0x060015F3 RID: 5619 RVA: 0x00058301 File Offset: 0x00056501
		public override string ToString()
		{
			return this.Button + " " + (this.Pressed ? "pressed" : "released");
		}

		// Token: 0x060015F4 RID: 5620 RVA: 0x00058328 File Offset: 0x00056528
		internal ButtonEvent(ButtonCode button, bool pressed)
		{
			string text = InputEventQueue.NormalizeButtonName(button.ToString());
			this.Button = text;
			this.Pressed = pressed;
		}

		// Token: 0x060015F5 RID: 5621 RVA: 0x00058360 File Offset: 0x00056560
		[NullableContext(1)]
		protected virtual bool PrintMembers(StringBuilder builder)
		{
			RuntimeHelpers.EnsureSufficientExecutionStack();
			builder.Append("Button = ");
			builder.Append(this.Button);
			builder.Append(", Pressed = ");
			builder.Append(this.Pressed.ToString());
			return true;
		}

		// Token: 0x060015F6 RID: 5622 RVA: 0x000583B3 File Offset: 0x000565B3
		[NullableContext(2)]
		public static bool operator !=(ButtonEvent left, ButtonEvent right)
		{
			return !(left == right);
		}

		// Token: 0x060015F7 RID: 5623 RVA: 0x000583BF File Offset: 0x000565BF
		[NullableContext(2)]
		public static bool operator ==(ButtonEvent left, ButtonEvent right)
		{
			return left == right || (left != null && left.Equals(right));
		}

		// Token: 0x060015F8 RID: 5624 RVA: 0x000583D3 File Offset: 0x000565D3
		public override int GetHashCode()
		{
			return (EqualityComparer<Type>.Default.GetHashCode(this.EqualityContract) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.<Button>k__BackingField)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(this.<Pressed>k__BackingField);
		}

		// Token: 0x060015F9 RID: 5625 RVA: 0x00058413 File Offset: 0x00056613
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			return this.Equals(obj as ButtonEvent);
		}

		// Token: 0x060015FA RID: 5626 RVA: 0x00058424 File Offset: 0x00056624
		[NullableContext(2)]
		public virtual bool Equals(ButtonEvent other)
		{
			return this == other || (other != null && this.EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(this.<Button>k__BackingField, other.<Button>k__BackingField) && EqualityComparer<bool>.Default.Equals(this.<Pressed>k__BackingField, other.<Pressed>k__BackingField));
		}

		// Token: 0x060015FB RID: 5627 RVA: 0x0005847D File Offset: 0x0005667D
		[NullableContext(1)]
		public virtual ButtonEvent <Clone>$()
		{
			return new ButtonEvent(this);
		}

		// Token: 0x060015FC RID: 5628 RVA: 0x00058485 File Offset: 0x00056685
		protected ButtonEvent([Nullable(1)] ButtonEvent original)
		{
			this.Button = original.<Button>k__BackingField;
			this.Pressed = original.<Pressed>k__BackingField;
		}
	}
}
