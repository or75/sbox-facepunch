using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Sandbox;

namespace Tools
{
	// Token: 0x02000078 RID: 120
	internal class ConsoleOutput : TextEdit
	{
		// Token: 0x060012CD RID: 4813 RVA: 0x00051424 File Offset: 0x0004F624
		public ConsoleOutput(Widget parent)
			: base(parent)
		{
			base.Name = "Output";
			base.ReadOnly = true;
			base.MaximumBlockCount = 1000;
			base.MouseTracking = true;
			base.Editable = false;
			base.LinksClickable = true;
			base.TextSelectable = true;
			Logging.OnMessage += this.OnConsoleMessage;
		}

		// Token: 0x060012CE RID: 4814 RVA: 0x0005148D File Offset: 0x0004F68D
		public override void OnDestroyed()
		{
			Logging.OnMessage -= this.OnConsoleMessage;
		}

		// Token: 0x060012CF RID: 4815 RVA: 0x000514A0 File Offset: 0x0004F6A0
		public void AddEvent(string html, LogEvent e)
		{
			this.Events.Add(e);
			base.AppendHtml(html);
			if (this.Events.Count > base.MaximumBlockCount)
			{
				this.Events.RemoveAt(0);
			}
		}

		// Token: 0x060012D0 RID: 4816 RVA: 0x000514D4 File Offset: 0x0004F6D4
		public override void Clear()
		{
			this.Events.Clear();
			this.LastCursor = null;
			base.Clear();
		}

		// Token: 0x060012D1 RID: 4817 RVA: 0x000514F0 File Offset: 0x0004F6F0
		private void OnConsoleMessage(LogEvent e)
		{
			LogEvent lastEvent = this.Events.LastOrDefault<LogEvent>();
			if (lastEvent.Message == e.Message)
			{
				e.Repeats = lastEvent.Repeats + 1;
				TextCursor cursorAtBlock = base.GetCursorAtBlock(this.Events.Count<LogEvent>() - 1);
				cursorAtBlock.SelectBlockUnderCursor();
				cursorAtBlock.RemoveSelectedText();
				cursorAtBlock.deleteChar();
				this.Events.RemoveAt(this.Events.Count<LogEvent>() - 1);
			}
			string textcolor = "#ccc";
			if (e.Level == LogLevel.Warn)
			{
				textcolor = "#ff9770";
			}
			if (e.Level == LogLevel.Trace)
			{
				textcolor = "#aaaaaa";
			}
			if (e.Level == LogLevel.Error)
			{
				textcolor = "#ff686b";
			}
			string message = e.HtmlMessage;
			message = message.Replace("\t", "&nbsp;&nbsp;&nbsp;");
			message = message.Replace("  ", "&nbsp;&nbsp;");
			string repeatText = "";
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
			if (e.Repeats > 0)
			{
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(90, 1);
				defaultInterpolatedStringHandler.AppendLiteral("&nbsp; <span style=\"color: rgb(75, 122, 75); background-color: rgb(34, 41, 34);\">[");
				defaultInterpolatedStringHandler.AppendFormatted<int>(e.Repeats, "n0");
				defaultInterpolatedStringHandler.AppendLiteral("]</span>");
				repeatText = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(140, 4);
			defaultInterpolatedStringHandler.AppendLiteral("<div><span style=\"color: rgb(75, 122, 75); background-color: rgb(34, 41, 34);\">&nbsp;");
			defaultInterpolatedStringHandler.AppendFormatted(e.Time.ToString("hh:mm:ss"));
			defaultInterpolatedStringHandler.AppendLiteral("&nbsp;</span>");
			defaultInterpolatedStringHandler.AppendFormatted(repeatText);
			defaultInterpolatedStringHandler.AppendLiteral(" <span style=\"color: ");
			defaultInterpolatedStringHandler.AppendFormatted(textcolor);
			defaultInterpolatedStringHandler.AppendLiteral("\">&nbsp;");
			defaultInterpolatedStringHandler.AppendFormatted(message);
			defaultInterpolatedStringHandler.AppendLiteral("</span></div>");
			string html = defaultInterpolatedStringHandler.ToStringAndClear();
			this.AddEvent(html, e);
		}

		// Token: 0x060012D2 RID: 4818 RVA: 0x000516A8 File Offset: 0x0004F8A8
		protected override void OnMouseClick(MouseEvent e)
		{
			if (this.OpenAnchor(e.LocalPosition))
			{
				e.Accepted = true;
				return;
			}
			this.LastCursor = base.GetCursorAtPosition(e.LocalPosition);
			this.Update();
			if (this.LastCursor.BlockNumber >= this.Events.Count)
			{
				return;
			}
			Utility.Inspect(this.Events[this.LastCursor.BlockNumber]);
			e.Accepted = true;
		}

		// Token: 0x060012D3 RID: 4819 RVA: 0x00051728 File Offset: 0x0004F928
		private bool OpenAnchor(Vector2 localPosition)
		{
			string anchor = base.GetAnchorAt(localPosition);
			if (string.IsNullOrEmpty(anchor))
			{
				return false;
			}
			TextCursor cursor = base.GetCursorAtPosition(localPosition);
			if (cursor.BlockNumber >= this.Events.Count)
			{
				return false;
			}
			LogEvent ev = this.Events[cursor.BlockNumber];
			if (anchor.StartsWith("arg:"))
			{
				string text = anchor;
				int length = text.Length;
				int num = 4;
				int length2 = length - num;
				int i = text.Substring(num, length2).ToInt(0);
				Utility.Inspect(ev.Arguments[i]);
			}
			return true;
		}

		// Token: 0x060012D4 RID: 4820 RVA: 0x000517B4 File Offset: 0x0004F9B4
		protected override void OnMouseMove(MouseEvent e)
		{
			this.Cursor = ((!string.IsNullOrEmpty(base.GetAnchorAt(e.LocalPosition))) ? CursorShape.Finger : CursorShape.None);
			TextCursor newHover = base.GetCursorAtPosition(e.LocalPosition);
			if (this.LastHover != null && newHover.BlockNumber == this.LastHover.BlockNumber)
			{
				return;
			}
			this.LastHover = newHover;
			this.Update();
		}

		// Token: 0x060012D5 RID: 4821 RVA: 0x0005181D File Offset: 0x0004FA1D
		protected override void OnMouseLeave()
		{
			this.LastHover = null;
			this.Update();
		}

		// Token: 0x060012D6 RID: 4822 RVA: 0x0005182C File Offset: 0x0004FA2C
		protected override void OnPaint()
		{
			if (this.LastCursor != null)
			{
				Paint.SetPenEmpty();
				Paint.SetBrush(new Color(0.5f, 0.5f, 0.5f, 0.1f));
				Rect rect = base.GetCursorRect(this.LastCursor);
				Rect rect3 = new Rect(0f, rect.top - 2f, base.Size.x, rect.height + 4f);
				Paint.DrawRect(rect3);
			}
			if (this.LastHover != null)
			{
				Paint.SetPenEmpty();
				Paint.SetBrush(new Color(0.4f, 0.5f, 0.4f, 0.1f));
				Rect rect2 = base.GetCursorRect(this.LastHover);
				Rect rect3 = new Rect(0f, rect2.top, base.Size.x, rect2.height);
				Paint.DrawRect(rect3);
			}
			base.OnPaint();
		}

		// Token: 0x060012D7 RID: 4823 RVA: 0x00051915 File Offset: 0x0004FB15
		protected override void OnResize()
		{
			base.OnResize();
			base.ScrollToBottom();
		}

		// Token: 0x0400017D RID: 381
		private List<LogEvent> Events = new List<LogEvent>();

		// Token: 0x0400017E RID: 382
		private TextCursor LastCursor;

		// Token: 0x0400017F RID: 383
		private TextCursor LastHover;
	}
}
