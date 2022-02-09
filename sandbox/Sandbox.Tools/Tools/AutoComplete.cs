using System;
using Sandbox;

namespace Tools
{
	// Token: 0x02000089 RID: 137
	public class AutoComplete : Menu
	{
		// Token: 0x0600139B RID: 5019 RVA: 0x000540B8 File Offset: 0x000522B8
		public AutoComplete(Widget parent)
			: base(parent)
		{
			base.FocusMode = FocusMode.None;
			base.IsTooltip = true;
			base.ShowWithoutActivating = true;
			base.Name = "AutoCompleteMenu";
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600139C RID: 5020 RVA: 0x00054108 File Offset: 0x00052308
		// (set) Token: 0x0600139D RID: 5021 RVA: 0x00054110 File Offset: 0x00052310
		public bool HasAutocompleteOptions { get; protected set; }

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600139E RID: 5022 RVA: 0x00054119 File Offset: 0x00052319
		// (set) Token: 0x0600139F RID: 5023 RVA: 0x00054121 File Offset: 0x00052321
		public int MinimumLength { get; set; } = 2;

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060013A0 RID: 5024 RVA: 0x0005412A File Offset: 0x0005232A
		// (set) Token: 0x060013A1 RID: 5025 RVA: 0x00054132 File Offset: 0x00052332
		public Vector2 OpenOffset { get; set; } = new Vector2(0f, -5f);

		// Token: 0x060013A2 RID: 5026 RVA: 0x0005413C File Offset: 0x0005233C
		public void OnAutoComplete(string newPrefix, Vector2 screenPosition)
		{
			this.HasAutocompleteOptions = false;
			base.Clear();
			using (new SuspendUpdates(this))
			{
				if (newPrefix == null || newPrefix.Length >= this.MinimumLength)
				{
					Action<Menu, string> onBuildOptions = this.OnBuildOptions;
					if (onBuildOptions != null)
					{
						onBuildOptions(this, newPrefix);
					}
				}
				if (!this.HasAutocompleteOptions)
				{
					base.Visible = false;
				}
				else
				{
					this.OpenAbove(screenPosition + this.OpenOffset);
				}
			}
		}

		/// <summary>
		/// Add an option for this autocomplete
		/// </summary>
		// Token: 0x060013A3 RID: 5027 RVA: 0x000541C8 File Offset: 0x000523C8
		public override Option AddOption(string name, string icon = null, Action action = null, string shortcut = null)
		{
			this.HasAutocompleteOptions = true;
			Action act = delegate()
			{
				Action<string> onOptionSelected = this.OnOptionSelected;
				if (onOptionSelected != null)
				{
					onOptionSelected(name);
				}
				Action action2 = action;
				if (action2 == null)
				{
					return;
				}
				action2();
			};
			return base.AddOption(name, icon, act, shortcut);
		}

		/// <summary>
		/// Open above this position
		/// </summary>
		// Token: 0x060013A4 RID: 5028 RVA: 0x00054214 File Offset: 0x00052414
		public void OpenAbove(Vector2 position)
		{
			base.Visible = true;
			base.MaximumSize = new Vector2(1000f, position.y - 10f);
			base.Position = position - new Vector2(0f, base.Size.y);
		}

		/// <summary>
		/// You should call this from the parent when a key is pressed. Will forward
		/// the appropriate keys to us and accept the event.
		/// </summary>
		// Token: 0x060013A5 RID: 5029 RVA: 0x0005426C File Offset: 0x0005246C
		public void OnParentKeyPress(KeyEvent e)
		{
			if (!base.Visible)
			{
				return;
			}
			bool flag = e.Key == KeyCode.Up || e.Key == KeyCode.Down;
			bool isSelect = e.Key == KeyCode.Enter || e.Key == KeyCode.Return;
			bool isTakeAndCarryOn = e.Key == KeyCode.Space;
			if (flag)
			{
				e.Accepted = true;
				base.PostKeyEvent(e.Key);
			}
			if (base.SelectedOption != null && isSelect)
			{
				e.Accepted = true;
				base.PostKeyEvent(e.Key);
			}
			if (base.SelectedOption != null && isTakeAndCarryOn)
			{
				Action<string> onOptionSelected = this.OnOptionSelected;
				if (onOptionSelected == null)
				{
					return;
				}
				onOptionSelected(base.SelectedOption.Text);
			}
		}

		/// <summary>
		/// Call this when the widget that spawns this blurs, so we can hide ourself
		/// </summary>
		// Token: 0x060013A6 RID: 5030 RVA: 0x0005432E File Offset: 0x0005252E
		public void OnParentBlur()
		{
			if (base.IsActiveWindow)
			{
				return;
			}
			base.Visible = false;
		}

		/// <summary>
		/// Called when the mouse is pressed. Will hide this window if we clicked on anything
		/// except ourselves or our parent control.
		/// </summary>
		// Token: 0x060013A7 RID: 5031 RVA: 0x00054340 File Offset: 0x00052540
		[Event("qt.mousepressed")]
		public void OnGlobalMousePressed()
		{
			if (base.IsUnderMouse)
			{
				return;
			}
			if (base.Parent.IsValid() && base.Parent.IsUnderMouse)
			{
				return;
			}
			base.Visible = false;
		}

		/// <summary>
		/// The text has changed - fill in the options
		/// </summary>
		// Token: 0x040001BE RID: 446
		public Action<Menu, string> OnBuildOptions;

		/// <summary>
		/// You should hook this up to change the text on your control
		/// </summary>
		// Token: 0x040001BF RID: 447
		public Action<string> OnOptionSelected;
	}
}
