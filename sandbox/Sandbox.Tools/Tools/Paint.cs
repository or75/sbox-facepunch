using System;
using System.Collections.Generic;
using Sandbox;

namespace Tools
{
	// Token: 0x020000B3 RID: 179
	public static class Paint
	{
		// Token: 0x17000134 RID: 308
		// (set) Token: 0x06001532 RID: 5426 RVA: 0x00057113 File Offset: 0x00055313
		public static bool Antialiasing
		{
			set
			{
				Paint.ptr.setRenderHint(RenderHints.Antialiasing, value);
			}
		}

		// Token: 0x17000135 RID: 309
		// (set) Token: 0x06001533 RID: 5427 RVA: 0x00057121 File Offset: 0x00055321
		public static bool TextAntialiasing
		{
			set
			{
				Paint.ptr.setRenderHint(RenderHints.TextAntialiasing, value);
			}
		}

		// Token: 0x17000136 RID: 310
		// (set) Token: 0x06001534 RID: 5428 RVA: 0x0005712F File Offset: 0x0005532F
		public static bool BilinearFiltering
		{
			set
			{
				Paint.ptr.setRenderHint(RenderHints.SmoothPixmapTransform, value);
			}
		}

		// Token: 0x17000137 RID: 311
		// (set) Token: 0x06001535 RID: 5429 RVA: 0x0005713D File Offset: 0x0005533D
		internal static Brush Brush
		{
			set
			{
				Paint.ptr.setBrush(value.ptr);
			}
		}

		// Token: 0x17000138 RID: 312
		// (set) Token: 0x06001536 RID: 5430 RVA: 0x0005714F File Offset: 0x0005534F
		internal static Pen Pen
		{
			set
			{
				Paint.ptr.setPen(value.ptr);
			}
		}

		// Token: 0x06001537 RID: 5431 RVA: 0x00057161 File Offset: 0x00055361
		public static void DrawRect(in Rect rect, float borderRadius)
		{
			if (borderRadius <= 0f)
			{
				Paint.DrawRect(rect);
				return;
			}
			Paint.ptr.drawRoundedRect(rect, borderRadius, borderRadius);
		}

		// Token: 0x06001538 RID: 5432 RVA: 0x00057189 File Offset: 0x00055389
		public static void DrawRect(in Rect rect)
		{
			Paint.ptr.drawRect(rect);
		}

		// Token: 0x06001539 RID: 5433 RVA: 0x000571A0 File Offset: 0x000553A0
		public static void DrawCircle(in Rect rect)
		{
			Paint.ptr.drawEllipse(rect);
		}

		// Token: 0x0600153A RID: 5434 RVA: 0x000571B8 File Offset: 0x000553B8
		public static Rect DrawText(in Vector2 position, string text)
		{
			Rect rect = new Rect(position, default(Vector2));
			rect.width = 1000f;
			rect.height = 1000f;
			return Paint.DrawText(rect, text, TextFlag.LeftTop);
		}

		// Token: 0x0600153B RID: 5435 RVA: 0x000571FD File Offset: 0x000553FD
		public static void DrawLine(in Vector2 from, in Vector2 to)
		{
			Paint.ptr.drawLine(from, to);
		}

		// Token: 0x0600153C RID: 5436 RVA: 0x00057220 File Offset: 0x00055420
		public static Rect DrawText(in Rect position, string text, TextFlag flags = TextFlag.AlignCenter)
		{
			QRectF rect;
			Paint.ptr.drawText(position, (int)flags, text, out rect);
			return rect.Rect;
		}

		// Token: 0x0600153D RID: 5437 RVA: 0x00057250 File Offset: 0x00055450
		public static Rect MeasureText(in Rect position, string text, TextFlag flags = TextFlag.AlignCenter)
		{
			return Paint.ptr.boundingRect(position, (int)flags, text).Rect;
		}

		// Token: 0x0600153E RID: 5438 RVA: 0x0005727C File Offset: 0x0005547C
		public static void SetFont(string name, float size = 8f, int weight = 400, bool italic = false, bool sizeInPixels = false)
		{
			WidgetUtil.PaintSetFont(Paint.ptr, name, (int)size, weight, italic, sizeInPixels);
		}

		// Token: 0x0600153F RID: 5439 RVA: 0x0005728F File Offset: 0x0005548F
		public static void SetDefaultFont(float size = 8f, int weight = 400, bool italic = false, bool sizeInPixels = false)
		{
			Paint.SetFont(null, size, weight, italic, sizeInPixels);
		}

		// Token: 0x06001540 RID: 5440 RVA: 0x0005729B File Offset: 0x0005549B
		public static void SetPenEmpty()
		{
			Paint.ClearPen();
		}

		// Token: 0x06001541 RID: 5441 RVA: 0x000572A2 File Offset: 0x000554A2
		public static void ClearPen()
		{
			Paint.Pen = new Pen(Color.Transparent, 0f);
		}

		// Token: 0x06001542 RID: 5442 RVA: 0x000572B8 File Offset: 0x000554B8
		public static void SetBrushEmpty()
		{
			Paint.ClearBrush();
		}

		// Token: 0x06001543 RID: 5443 RVA: 0x000572BF File Offset: 0x000554BF
		public static void ClearBrush()
		{
			Paint.Brush = new Brush(Color.Transparent);
		}

		// Token: 0x06001544 RID: 5444 RVA: 0x000572D0 File Offset: 0x000554D0
		public static void SetPen(Color color, float size = 0f)
		{
			Paint.Pen = new Pen(color, size);
		}

		// Token: 0x06001545 RID: 5445 RVA: 0x000572DE File Offset: 0x000554DE
		public static void SetBrush(Color color)
		{
			Paint.Brush = new Brush(color);
		}

		// Token: 0x06001546 RID: 5446 RVA: 0x000572EC File Offset: 0x000554EC
		private static Brush FindOrLoad(string filename)
		{
			Brush brush;
			if (Paint.Images.TryGetValue(filename, out brush))
			{
				return brush;
			}
			brush = new Brush(Pixmap.FromFile(filename));
			Paint.Images[filename] = brush;
			return brush;
		}

		// Token: 0x06001547 RID: 5447 RVA: 0x00057323 File Offset: 0x00055523
		public static void SetBrush(string image)
		{
			Paint.Brush = Paint.FindOrLoad(image);
		}

		// Token: 0x06001548 RID: 5448 RVA: 0x00057330 File Offset: 0x00055530
		public static void SetBrush(Pixmap pixmap)
		{
			Paint.Brush = new Brush(pixmap);
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06001549 RID: 5449 RVA: 0x0005733D File Offset: 0x0005553D
		public static bool HasSelected
		{
			get
			{
				return Paint.state.HasFlag(StateFlag.Selected);
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x0600154A RID: 5450 RVA: 0x00057358 File Offset: 0x00055558
		public static bool HasMouseOver
		{
			get
			{
				return Paint.state.HasFlag(StateFlag.MouseOver);
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x0600154B RID: 5451 RVA: 0x00057373 File Offset: 0x00055573
		public static bool HasEnabled
		{
			get
			{
				return Paint.state.HasFlag(StateFlag.Enabled);
			}
		}

		// Token: 0x0600154C RID: 5452 RVA: 0x0005738A File Offset: 0x0005558A
		internal static void Start(QPainter e, StateFlag flags = StateFlag.None)
		{
			Paint.ptr = e;
			Paint.state = flags;
		}

		// Token: 0x0600154D RID: 5453 RVA: 0x00057398 File Offset: 0x00055598
		internal static void Finished()
		{
			Paint.ptr = default(QPainter);
			Paint.state = StateFlag.None;
		}

		// Token: 0x0600154E RID: 5454 RVA: 0x000573AB File Offset: 0x000555AB
		public static Rect DrawMaterialIcon(Rect rect, string iconName, float pixelHeight, TextFlag alignment = TextFlag.AlignCenter)
		{
			Paint.SetFont("Material Icons", pixelHeight, 400, false, true);
			return Paint.DrawText(rect, iconName, alignment);
		}

		// Token: 0x0600154F RID: 5455 RVA: 0x000573C8 File Offset: 0x000555C8
		public static Rect DrawMaterialIcon(Rect rect, MaterialIcon icon, float pixelHeight, TextFlag alignment = TextFlag.AlignCenter)
		{
			Paint.SetFont("Material Icons", pixelHeight, 400, false, true);
			return Paint.DrawText(rect, MaterialIconUtility.Lookup(icon), alignment);
		}

		// Token: 0x06001550 RID: 5456 RVA: 0x000573EC File Offset: 0x000555EC
		public static void Draw(Rect r, Pixmap pixmap)
		{
			Rect src = new Rect(0f, 0f, pixmap.Width, pixmap.Height);
			Paint.ptr.drawPixmap(r, pixmap.ptr, src);
		}

		// Token: 0x04000436 RID: 1078
		internal static QPainter ptr;

		// Token: 0x04000437 RID: 1079
		internal static StateFlag state;

		// Token: 0x04000438 RID: 1080
		private static Dictionary<string, Brush> Images = new Dictionary<string, Brush>();
	}
}
