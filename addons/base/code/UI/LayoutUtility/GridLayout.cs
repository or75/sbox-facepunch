﻿using System;

namespace Sandbox.UI.Tests
{
	public class GridLayout
	{
		/// <summary>
		/// The fixed size of each item. If x is lower than 0 then we'll stretch to fill the size.
		/// </summary>
		public Length ItemWidth { get; set; }
		public Length ItemHeight { get; set; }


		[Obsolete( "Use ItemWidth and ItemHeight instead" )]
		public Vector2 ItemSize 
		{ 
			get => default;
			set
			{
				ItemWidth = value.x;
				ItemHeight = value.y;
			}
		}

		/// <summary>
		/// Should we update Columns automatically?
		/// </summary>
		public bool AutoColumns { get; set; }

		/// <summary>
		/// How many columns should we have?
		/// </summary>
		public int Columns { get; set; }

		/// <summary>
		/// The Rect of this layout. Set via Update.
		/// </summary>
		public Rect Rect { get; protected set; }

		/// <summary>
		/// Where the top of the visible space is
		/// </summary>
		public float ScrollOffset { get; protected set; }

		/// <summary>
		/// How columns should be justified
		/// </summary>
		public Justify Justify { get; protected set; }

		private int updateHash;

		private Vector2 Padding;

		public GridLayout()
		{
			ItemWidth = 0.0f;
			ItemHeight = 100.0f;

			Columns = 1;
			AutoColumns = false;
		}

		Vector2 cellSize;

		/// <summary>
		/// Update specifics of this layout. Returns true if we're dirty.
		/// </summary>
		public bool Update( Box box, float scaleFromScreen, float scrollOffset, Justify justify )
		{
			// Guard to see whether we actually need to update
			var hash = HashCode.Combine( box.RectInner, scaleFromScreen, scrollOffset, AutoColumns, Columns, ItemWidth, ItemHeight, justify );
			if ( hash == updateHash ) return false;
			updateHash = hash;

			cellSize.x = ItemWidth.GetPixels( box.Rect.width * scaleFromScreen );
			cellSize.y = ItemHeight.GetPixels( box.Rect.height * scaleFromScreen );

			if ( cellSize.y < 1 ) cellSize.y = 1;
			if ( cellSize.x < 0 ) cellSize.x = 0;

			var r = box.RectInner;
			r.Position = (box.RectInner.Position - box.Rect.Position);

			Padding = (box.Rect.Size - box.RectInner.Size) * scaleFromScreen;

			Rect = r * scaleFromScreen;
			
			ScrollOffset = scrollOffset;
			Justify = justify;

			if ( AutoColumns )
			{
				Columns = (Rect.width / cellSize.x ).FloorToInt();
				if ( Columns <= 0 ) Columns = 1;
			}

			return true;
		}

		/// <summary>
		/// Get the range of cells that are visible
		/// </summary>
		public void GetVisibleRange( out int firstIndex, out int lastIndex )
		{
			var itemHeight = cellSize.y;

			var topItem = (ScrollOffset / itemHeight).FloorToInt();
			var inRange = (Rect.height / itemHeight).CeilToInt() + 1;

			firstIndex = topItem * Columns;
			lastIndex = firstIndex + inRange * Columns;
		}

		/// <summary>
		/// Get the position of this cell
		/// </summary>
		public Rect GetPosition( int index )
		{
			float x = index.UnsignedMod( Columns );
			float y = (index / Columns);
			var width = cellSize.x > 0 ? cellSize.x : Rect.width;

			if ( Justify == Justify.SpaceBetween )
			{
				var spareSpace = Rect.width - (Columns * cellSize.x);
				spareSpace /= (Columns - 1);

				x *= (cellSize.x + spareSpace);
				y *= cellSize.y;
			}
			// TODO - OTHERS
			else
			{
				x *= cellSize.x;
				y *= cellSize.y;
			}

			return new Rect
			(
				x + Rect.left,
				y + Rect.top,
				width,
				cellSize.y
			);
		}

		/// <summary>
		/// Move this panel into the position. This will set the Left/Top/Width/Height on the panel
		/// </summary>
		public void Position( int index, Panel panel )
		{
			var rect = GetPosition( index );

			panel.Style.Left = rect.left;
			panel.Style.Top = rect.top;
			panel.Style.Width = rect.width;
			panel.Style.Height = rect.height;

			panel.Style.Dirty();
		}

		/// <summary>
		/// Get the full height if we have this many items
		/// </summary>
		public float GetHeight( int count )
		{
			return MathF.Ceiling( (count / (float)Columns) ) * (cellSize.y) + Padding.y;
		}
	}
}
