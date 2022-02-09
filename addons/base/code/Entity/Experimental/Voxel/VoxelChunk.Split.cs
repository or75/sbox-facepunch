using System.Collections.Generic;

namespace Sandbox
{
	public partial class VoxelChunk
	{
		private struct SplitData
		{
			public BlockPosition[] Positions;
			public int X;
			public int Y;
			public int Width;
			public int Height;
		}

		private readonly Queue<SplitData> SplitsQueued = new();

		public void QueueSplit( BlockPosition[] positions, int x, int y, int width, int height )
		{
			if ( !IsAuthority )
				return;

			if ( positions == null )
				return;

			SplitsQueued.Enqueue( new SplitData
			{
				Positions = positions,
				X = x,
				Y = y,
				Width = width,
				Height = height,
			} );
		}

		private void TryAddSplitCheck( BlockPosition position, HashSet<BlockPosition> positions )
		{
			if ( IsBlockOutOfBounds( position.x, position.y ) )
				return;

			if ( IsBlockEmpty( position.x, position.y ) )
				return;

			positions.Add( position );
		}

		private void TrySplit( HashSet<BlockPosition> positions )
		{
			var spitSearch = new SplitSearch( positions );
			spitSearch.Search( this );
		}

		private VoxelChunk CreateSplitChunk( SplitData splitData )
		{
			if ( splitData.Positions.Length == 0 )
				return null;

			float tileWidth = (Desc.Size.x / Desc.Width);
			float tileHeight = (Desc.Size.y / Desc.Height);

			var size = new Vector2( tileWidth * splitData.Width, tileHeight * splitData.Height );
			var localPosition = new Vector2( Desc.Size.x * -0.5f, Desc.Size.y * -0.5f );
			localPosition += new Vector2( splitData.X * tileWidth, splitData.Y * tileHeight );
			localPosition += new Vector2( size.x * 0.5f, size.y * 0.5f );

			var newChunk = ParentSurface.CreateNewChunk();
			newChunk.Transform = Transform.WithPosition( Transform.PointToWorld( localPosition ) );

			var newData = new byte[splitData.Width * splitData.Height];
			for ( int i = 0; i < newData.Length; ++i )
			{
				newData[i] = 1;
			}

			int newBlockCount = 0;
			for ( int i = 0; i < splitData.Positions.Length; ++i )
			{
				var blockPosition = splitData.Positions[i];
				var blockIndex = (blockPosition.x - splitData.X) + (blockPosition.y - splitData.Y) * splitData.Width;

				if ( newData[blockIndex] != 0 )
				{
					newData[blockIndex] = 0;
					newBlockCount++;
				}
			}

			if ( newBlockCount == 0 )
				return null;

			newChunk.CreateModel(
				size,
				Desc.Offset + localPosition,
				splitData.Width, splitData.Height, ParentSurface.Thickness,
				newBlockCount,
				ParentSurface.Material,
				false,
				newData );

			newChunk.DamagePosition = DamagePosition;
			newChunk.DamageForce = DamageForce;
			newChunk.ApplyDamageForce();

			return newChunk;
		}

		private void CreateSplitChunks()
		{
			while ( SplitsQueued.Count > 0 )
			{
				CreateSplitChunk( SplitsQueued.Dequeue() );
			}
		}
	}
}
