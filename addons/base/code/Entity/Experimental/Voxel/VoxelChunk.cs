using System;
using System.Collections.Generic;

namespace Sandbox
{
	public partial class VoxelChunk : ModelEntity
	{
		public VoxelSurface ParentSurface { get; set; }

		[Net] private ModelDesc Desc { get; set; }

		private Mesh Mesh;
		private bool IsModelCreated;
		private bool IsMarkedForDeletion;
		private bool HasBroken;
		private Vector3 DamagePosition;
		private Vector3 DamageForce;
		private int DamageRadius;
		private TimeSince TimeSinceDamageSound;
		private static float DamageSoundCooldown => 0.4f;
		private static string DamageSound => "break_wood_plank";
		private readonly Queue<DamageInfo> DamageQueued = new();

		public override void ClientSpawn()
		{
			base.ClientSpawn();

			TryCreateModel();
		}

		[Event.Tick.Client]
		protected void OnClientTick()
		{
			TryCreateModel();
		}

		[Event.Tick.Server]
		protected void OnServerTick()
		{
			if ( !this.IsValid() )
				return;

			if ( IsMarkedForDeletion )
			{
				ParentSurface?.RemoveChunk( this );

				PhysicsBody?.Wake();
				Delete();

				IsMarkedForDeletion = false;
			}
			else
			{
				while ( DamageQueued.Count > 0 )
				{
					var info = DamageQueued.Dequeue();

					DamagePosition = info.Position;
					DamageForce = info.Force;
					DamageRadius = 5;

					if ( info.Flags.HasFlag( DamageFlags.PhysicsImpact ) )
					{
						DamageRadius = 6;
					}

					BreakWorldSpace( info.Position );
				}

				if ( HasBroken )
				{
					HasBroken = false;

					if ( TimeSinceDamageSound > DamageSoundCooldown )
					{
						Sound.FromWorld( DamageSound, DamagePosition );
						TimeSinceDamageSound = 0;
					}
				}
			}
		}

		public void MarkForDeletion()
		{
			if ( IsMarkedForDeletion )
				return;

			PhysicsEnabled = false;
			EnableAllCollisions = false;
			EnableDrawing = false;
			IsMarkedForDeletion = true;
		}

		private void TryCreateModel()
		{
			if ( IsModelCreated )
				return;

			var model = CreateModel();

			if ( model != null )
			{
				Model = model;
			}

			IsModelCreated = true;
		}

		private Model CreateModel()
		{
			if ( Desc == null )
				return null;

			var modelBuilder = new ModelBuilder();

			if ( IsClient )
			{
				var boundsMin = new Vector3( Desc.Size * -0.5f, Desc.Thickness * -0.5f );
				var boundsMax = new Vector3( Desc.Size * 0.5f, Desc.Thickness * 0.5f );
				var bounds = new BBox( boundsMin, boundsMax );

				Mesh = new Mesh( Material.Load( Desc.Material ) )
				{
					Bounds = bounds
				};
			}

			Build( modelBuilder, Mesh );

			return modelBuilder.Create();
		}

		public void CreateModel( Vector2 size, Vector2 offset, int width, int height, float thickness, int blockCount, string material, bool frozen, byte[] data = null )
		{
			if ( !IsAuthority )
				return;

			if ( IsMarkedForDeletion )
				return;

			if ( blockCount == 0 )
			{
				MarkForDeletion();

				return;
			}

			BlockCount = blockCount;

			Desc = new ModelDesc()
			{
				Size = size,
				Offset = offset,
				Width = width,
				Height = height,
				Thickness = thickness,
				IsBroken = true,
				Material = material,
				Mask = data ?? (new byte[width * height])
			};

			Desc.WriteNetworkData();

			Model = CreateModel();
			SetupPhysicsFromModel( frozen ? PhysicsMotionType.Static : PhysicsMotionType.Dynamic );
		}

		private float CalculateMass()
		{
			return MathX.LerpTo( 10.0f, 100.0f, BlockCount / 1000.0f );
		}

		protected override void OnPhysicsCollision( CollisionEventData eventData )
		{
			base.OnPhysicsCollision( eventData );
		}

		public override void TakeDamage( DamageInfo info )
		{
			base.TakeDamage( info );

			if ( !IsAuthority )
				return;

			if ( IsMarkedForDeletion )
				return;

			if ( !info.Flags.HasFlag( DamageFlags.Bullet ) &&
				 !info.Flags.HasFlag( DamageFlags.PhysicsImpact ) )
			{
				return;
			}

			DamageQueued.Enqueue( info );
		}

		private void Unfreeze()
		{
			PhysicsEnabled = true;
			PhysicsBody?.Wake();
		}

		public void BreakWorldSpace( Vector3 position )
		{
			if ( !IsAuthority )
				return;

			if ( IsMarkedForDeletion )
				return;

			Vector2 localPosition = Transform.PointToLocal( position );
			localPosition += Desc.Size * 0.5f;
			localPosition /= Desc.Size;
			localPosition *= new Vector2( Desc.Width, Desc.Height );

			var x = (int)MathF.Floor( localPosition.x );
			var y = (int)MathF.Floor( localPosition.y );

			if ( IsBlockOutOfBounds( x, y ) )
				return;

			BreakLocalSpace( x, y, DamageRadius );
		}

		public void BreakLocalSpace( int x, int y )
		{
			if ( !IsAuthority )
				return;

			if ( IsMarkedForDeletion )
				return;

			if ( IsBlockOutOfBounds( x, y ) )
				return;

			if ( IsBlockEmpty( x, y ) )
				return;

			BreakLocalSpace( new List<BlockPosition> { new BlockPosition( x, y ) } );
		}

		public void BreakLocalSpace( int localX, int localY, int radius )
		{
			if ( !IsAuthority )
				return;

			if ( IsMarkedForDeletion )
				return;

			if ( radius == 0 )
			{
				BreakLocalSpace( localX, localY );

				return;
			}

			if ( IsBlockOutOfBounds( localX, localY ) )
				return;

			if ( IsBlockEmpty( localX, localY ) )
				return;

			var positions = new List<BlockPosition>();
			var position = new Vector2( localX, localY );

			int xMinRadius = 0;
			int xMaxRadius = 0;
			int yMinRadius = 0;
			int yMaxRadius = 0;

			for ( var i = 0; i < radius; i++ )
			{
				int x = (localX + 1) + i;

				if ( IsBlockInBounds( x, localY ) && IsBlockEmpty( x, localY ) )
					break;

				xMaxRadius++;
			}

			for ( var i = 0; i < radius; i++ )
			{
				int x = (localX - 1) - i;

				if ( IsBlockInBounds( x, localY ) && IsBlockEmpty( x, localY ) )
					break;

				xMinRadius++;
			}

			for ( var i = 0; i < radius; i++ )
			{
				int y = (localY + 1) + i;

				if ( IsBlockInBounds( localX, y ) && IsBlockEmpty( localX, y ) )
					break;

				yMaxRadius++;
			}

			for ( var i = 0; i < radius; i++ )
			{
				int y = (localY - 1) - i;

				if ( IsBlockInBounds( localX, y ) && IsBlockEmpty( localX, y ) )
					break;

				yMinRadius++;
			}

			var xMin = localX - xMinRadius;
			var yMin = localY - yMinRadius;
			var xMax = localX + xMaxRadius;
			var yMax = localY + yMaxRadius;

			for ( var x = xMin; x <= xMax; x++ )
			{
				for ( var y = yMin; y <= yMax; y++ )
				{
					if ( IsBlockOutOfBounds( x, y ) )
						continue;

					if ( IsBlockEmpty( x, y ) )
						continue;

					var blockPosition = new BlockPosition( x, y );

					var distance = position.Distance( new Vector2( x, y ) );
					if ( distance >= radius )
						continue;

					positions.Add( blockPosition );
				}
			}

			if ( positions.Count == 0 )
				return;

			if ( Math.Max( xMinRadius, xMaxRadius ) > 2 && Math.Max( yMinRadius, yMaxRadius ) > 2 )
			{
				// Add a bit of randomness to the edge of the radius
				positions.RemoveAll( x =>
				{
					bool isOnEdge = false;

					foreach ( var neighbour in BlockPosition.Neighbours )
					{
						var position = x + neighbour;

						if ( IsBlockOutOfBounds( position.x, position.y ) )
							return false;

						if ( IsBlockEmpty( position.x, position.y ) )
							continue;

						if ( !positions.Contains( position ) )
						{
							isOnEdge = true;

							break;
						}
					}

					return isOnEdge && Rand.Int( 5 ) == 0;
				} );

				if ( positions.Count == 0 )
					return;
			}

			var holePositions = new List<BlockPosition>( positions );

			foreach ( var direction in BlockPosition.Directions )
			{
				holePositions.RemoveAll( x =>
				{
					var position = x + direction;

					if ( positions.Contains( position ) )
						return false;

					return IsBlockInBounds( position.x, position.y ) && IsBlockSolid( position.x, position.y );
				} );
			}

			BreakLocalSpace( positions );

			if ( IsMarkedForDeletion )
				return;

			if ( holePositions.Count == 0 || BlockCount == 0 )
				return;

			CreateSplitChunk( new SplitData
			{
				X = xMin,
				Y = yMin,
				Width = (xMax - xMin) + 1,
				Height = (yMax - yMin) + 1,
				Positions = holePositions.ToArray()
			} );
		}

		private void BreakLocalSpace( List<BlockPosition> positions )
		{
			if ( !IsAuthority )
				return;

			if ( IsMarkedForDeletion )
				return;

			var blockCount = BlockCount;

			foreach ( var position in positions )
			{
				SetBlockEmpty( position.x, position.y );
			}

			if ( BlockCount == 0 )
			{
				HasBroken = true;

				MarkForDeletion();

				return;
			}

			if ( BlockCount == blockCount )
				return;

			var checkPositions = new HashSet<BlockPosition>();

			foreach ( var position in positions )
			{
				TryAddSplitCheck( position + BlockPosition.Forward, checkPositions );
				TryAddSplitCheck( position + BlockPosition.Backward, checkPositions );
				TryAddSplitCheck( position + BlockPosition.Left, checkPositions );
				TryAddSplitCheck( position + BlockPosition.Right, checkPositions );
			}

			TrySplit( checkPositions );

			if ( ParentSurface.IsFrozen && !IsTouchingBounds() )
			{
				Unfreeze();
			}

			Desc.WriteNetworkData();

			CreateSplitChunks();

			Build( null, null );
			OnBreakLocalSpace( BlockCount );

			ApplyDamageForce();

			HasBroken = true;
		}

		private void ApplyDamageForce()
		{
			if ( PhysicsBody.IsValid() )
			{
				PhysicsBody.ApplyImpulseAt( DamagePosition, DamageForce * 10 );
			}
		}

		private bool IsTouchingBounds()
		{
			for ( int i = 0; i < Desc.Width; i++ )
			{
				if ( IsBlockSolid( i, 0 ) )
					return true;

				if ( IsBlockSolid( i, Desc.Height - 1 ) )
					return true;
			}

			for ( int i = 0; i < Desc.Height; i++ )
			{
				if ( IsBlockSolid( 0, i ) )
					return true;

				if ( IsBlockSolid( Desc.Width - 1, i ) )
					return true;
			}

			return false;
		}

		[ClientRpc]
		private void OnBreakLocalSpace( int blockCount )
		{
			Host.AssertClient();

			BlockCount = blockCount;

			Build( null, Mesh );
		}
	}
}
