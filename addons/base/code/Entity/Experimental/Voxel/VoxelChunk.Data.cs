
namespace Sandbox
{
	public partial class VoxelChunk
	{
		public struct BlockPosition
		{
			public int x;
			public int y;

			public BlockPosition( int x, int y )
			{
				this.x = x;
				this.y = y;
			}

			public static BlockPosition operator +( BlockPosition a, BlockPosition b ) => new( a.x + b.x, a.y + b.y );

			public static BlockPosition Forward => new( 1, 0 );
			public static BlockPosition Backward => new( -1, 0 );
			public static BlockPosition Left => new( 0, 1 );
			public static BlockPosition Right => new( 0, -1 );

			public static readonly BlockPosition[] Directions = new[]
			{
				new BlockPosition( 1, 0 ),
				new BlockPosition( -1, 0 ),
				new BlockPosition( 0, 1 ),
				new BlockPosition( 0, -1 ),
				new BlockPosition( 1, 1 ),
				new BlockPosition( -1, 1 ),
				new BlockPosition( 1, -1 ),
				new BlockPosition( -1, -1 ),
			};

			public static readonly BlockPosition[] Neighbours = new[]
{
				new BlockPosition( 1, 0 ),
				new BlockPosition( -1, 0 ),
				new BlockPosition( 0, 1 ),
				new BlockPosition( 0, -1 ),
			};
		}

		private int BlockCount;

		public bool IsBlockOutOfBounds( int x, int y )
		{
			if ( x < 0 || x >= Desc.Width )
				return true;

			if ( y < 0 || y >= Desc.Height )
				return true;

			return false;
		}

		public bool IsBlockInBounds( int x, int y )
		{
			if ( x < 0 || x >= Desc.Width )
				return false;

			if ( y < 0 || y >= Desc.Height )
				return false;

			return true;
		}

		private int GetBlockIndex( int x, int y )
		{
			return x + y * Desc.Width;
		}

		public bool IsBlockSolid( int x, int y )
		{
			return Desc.Mask[GetBlockIndex( x, y )] == 0;
		}

		public bool IsBlockEmpty( int x, int y )
		{
			return Desc.Mask[GetBlockIndex( x, y )] != 0;
		}

		public void SetBlockEmpty( int x, int y )
		{
			SetBlockMask( GetBlockIndex( x, y ), 1 );
		}

		public void SetBlockSolid( int x, int y )
		{
			SetBlockMask( GetBlockIndex( x, y ), 0 );
		}

		private void SetBlockMask( int index, byte mask )
		{
			if ( Desc.Mask[index] == mask )
				return;

			Desc.Mask[index] = mask;

			BlockCount += (mask == 0) ? 1 : -1;
		}
	}
}
