using System.Linq;
using System.Collections.Generic;

namespace Sandbox
{
	public partial class VoxelChunk
	{
		private class SplitSearch
		{
			private class SearchData
			{
				public readonly List<BlockPosition> Positions = new();
				public HashSet<BlockPosition> PositionsToAdd = new();
				public HashSet<BlockPosition> PositionsToCheck = new();
				public HashSet<BlockPosition> PositionsChecked = new();

				public int PositionCount => Positions.Count;

				public SearchData( BlockPosition position )
				{
					PositionsToCheck.Add( position );
				}

				public void Merge( BlockPosition position, SearchData search )
				{
					if ( search != null )
					{
						Positions.AddRange( search.Positions );
						PositionsToAdd.UnionWith( search.PositionsToCheck );

						return;
					}

					if ( PositionsChecked.Contains( position ) )
						return;

					if ( PositionsToCheck.Contains( position ) )
						return;

					PositionsToAdd.Add( position );
				}

				public bool ContainsPosition( BlockPosition position )
				{
					return PositionsToCheck.Contains( position );
				}

				public void NewPositions()
				{
					PositionsChecked = PositionsToCheck;
					PositionsToCheck = PositionsToAdd;
					PositionsToAdd = new HashSet<BlockPosition>();
				}
			}

			private VoxelChunk Chunk;
			private SearchData CurrentSearch;
			private readonly List<SearchData> Searches = new();
			private readonly List<SearchData> SearchesRemoved = new();

			public SplitSearch( IEnumerable<BlockPosition> positions )
			{
				Searches.AddRange( positions.Select( x => new SearchData( x ) ) );
			}

			public void Search( VoxelChunk chunk )
			{
				if ( chunk == null )
					return;

				Chunk = chunk;

				while ( Searches.Count > 1 )
				{
					Search( Searches.First() );

					Searches.RemoveAll( SearchesRemoved.Contains );
					SearchesRemoved.Clear();
					Searches.Sort( ( x, y ) => (x.PositionCount < y.PositionCount) ? -1 : 1 );
				}
			}

			private void Search( SearchData search )
			{
				CurrentSearch = search;

				if ( search.PositionsToCheck.Count == 0 )
				{
					if ( Chunk.IsAuthority )
					{
						QueueSplit( search.Positions );
					}
					else
					{
						ClearPositions( search.Positions );
					}

					SearchesRemoved.Add( search );

					return;
				}

				foreach ( var position in search.PositionsToCheck )
				{
					if ( Chunk.IsBlockSolid( position.x, position.y ) )
					{
						search.Positions.Add( position );
					}

					TryMerge( position + BlockPosition.Forward );
					TryMerge( position + BlockPosition.Backward );
					TryMerge( position + BlockPosition.Left );
					TryMerge( position + BlockPosition.Right );
				}

				search.NewPositions();
			}

			private void TryMerge( BlockPosition position )
			{
				if ( !Chunk.IsBlockInBounds( position.x, position.y ) || Chunk.IsBlockEmpty( position.x, position.y ) )
					return;

				var search = Searches
					.Except( SearchesRemoved.Append( CurrentSearch ) )
					.FirstOrDefault( x => x.ContainsPosition( position ) );

				CurrentSearch.Merge( position, search );

				if ( search != null )
				{
					SearchesRemoved.Add( search );
				}
			}

			private void QueueSplit( List<BlockPosition> positions )
			{
				if ( positions.Count == 0 )
					return;

				var min = new BlockPosition( int.MaxValue, int.MaxValue );
				var max = new BlockPosition( int.MinValue, int.MinValue );

				bool solid = false;

				foreach ( var position in positions )
				{
					if ( Chunk.IsBlockSolid( position.x, position.y ) )
					{
						Chunk.SetBlockEmpty( position.x, position.y );

						min.x = (position.x < min.x) ? position.x : min.x;
						min.y = (position.y < min.y) ? position.y : min.y;
						max.x = (position.x > max.x) ? position.x : max.x;
						max.y = (position.y > max.y) ? position.y : max.y;

						solid = true;
					}
				}

				if ( solid )
				{
					Chunk.QueueSplit( positions.ToArray(), min.x, min.y, (max.x - min.x) + 1, (max.y - min.y) + 1 );
				}
			}

			private void ClearPositions( List<BlockPosition> positions )
			{
				if ( positions.Count == 0 )
					return;

				foreach ( var position in positions )
				{
					if ( Chunk.IsBlockSolid( position.x, position.y ) )
					{
						Chunk.SetBlockEmpty( position.x, position.y );
					}
				}
			}
		}
	}
}
