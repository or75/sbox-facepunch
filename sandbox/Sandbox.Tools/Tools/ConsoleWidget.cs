using System;
using System.Linq;
using System.Runtime.CompilerServices;
using NativeEngine;
using Sandbox;

namespace Tools
{
	// Token: 0x02000077 RID: 119
	internal class ConsoleWidget : Widget
	{
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060012C4 RID: 4804 RVA: 0x00051112 File Offset: 0x0004F312
		// (set) Token: 0x060012C5 RID: 4805 RVA: 0x0005111A File Offset: 0x0004F31A
		public LineEdit Input { get; set; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060012C6 RID: 4806 RVA: 0x00051123 File Offset: 0x0004F323
		// (set) Token: 0x060012C7 RID: 4807 RVA: 0x0005112B File Offset: 0x0004F32B
		private ConsoleOutput Output { get; set; }

		// Token: 0x060012C8 RID: 4808 RVA: 0x00051134 File Offset: 0x0004F334
		public ConsoleWidget(Widget parent)
			: base(parent)
		{
			base.Name = "ConsoleWidget";
			base.Size = new Vector2(500f, 500f);
			base.MinimumSize = new Vector2(100f, 100f);
			this.Input = new LineEdit(this);
			this.Input.MaxHistoryItems = 20;
			this.Input.HistoryCookie = "ConsoleInput";
			this.Output = new ConsoleOutput(this);
			BoxLayout boxLayout = base.MakeTopToBottom();
			boxLayout.SetContentMargins(4, 4, 4, 4);
			boxLayout.Add<ConsoleOutput>(this.Output, 1);
			Layout layout = boxLayout.MakeLeftToRight(0);
			layout.Spacing = 4;
			Button clear = new Button("", null)
			{
				Icon = "delete",
				Clicked = delegate()
				{
					this.Output.Clear();
				}
			};
			clear.SetProperty("type", "icon-large");
			Button bottom = new Button("", null)
			{
				Icon = "vertical_align_bottom",
				Clicked = delegate()
				{
					this.Output.ScrollToBottom();
				}
			};
			bottom.SetProperty("type", "icon-large");
			layout.Add<LineEdit>(this.Input, 1);
			layout.Add<Button>(clear, 0);
			layout.Add<Button>(bottom, 0);
			this.Input.PlaceholderText = "Enter Console Command..";
			this.Input.ReturnPressed += this.CommandInput;
			this.Input.SetAutoComplete(new Action<Menu, string>(this.BuildAutoCompleteOptions));
		}

		// Token: 0x060012C9 RID: 4809 RVA: 0x000512AC File Offset: 0x0004F4AC
		private void CommandInput()
		{
			string command = this.Input.Text.Trim();
			if (command.Length == 0)
			{
				return;
			}
			string textcolor = "#3f3";
			string message = "> " + command;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(140, 3);
			defaultInterpolatedStringHandler.AppendLiteral("<div><span style=\"color: rgb(75, 122, 75); background-color: rgb(34, 41, 34);\">&nbsp;");
			defaultInterpolatedStringHandler.AppendFormatted(DateTime.Now.ToString("hh:mm:ss"));
			defaultInterpolatedStringHandler.AppendLiteral("&nbsp;</span> <span style=\"color: ");
			defaultInterpolatedStringHandler.AppendFormatted(textcolor);
			defaultInterpolatedStringHandler.AppendLiteral("\">&nbsp;");
			defaultInterpolatedStringHandler.AppendFormatted(message);
			defaultInterpolatedStringHandler.AppendLiteral("</span></div>");
			string html = defaultInterpolatedStringHandler.ToStringAndClear();
			this.Output.AddEvent(html, default(LogEvent));
			this.Output.ScrollToBottom();
			this.Input.Clear();
			this.Input.AddHistory(command);
			Utility.RunCommand(command);
		}

		// Token: 0x060012CA RID: 4810 RVA: 0x00051394 File Offset: 0x0004F594
		private void BuildAutoCompleteOptions(Menu menu, string partial)
		{
			foreach (string option in (from x in Console.AutoComplete(partial).Split('\n', StringSplitOptions.RemoveEmptyEntries)
				orderby x
				select x).Take(20).ToArray<string>())
			{
				if (!string.Equals(option, partial, StringComparison.OrdinalIgnoreCase))
				{
					menu.AddOption(option, null, null, null);
				}
			}
		}
	}
}
