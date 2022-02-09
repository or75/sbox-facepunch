using System;
using System.Linq;
using System.Collections.Generic;

namespace Sandbox
{
	public partial class VoxelChunk
	{
		private Vector2 Planar( Vector3 pos, Vector3 right, Vector3 up, float scale = 64 )
		{
			pos.x += Desc.Offset.x;
			pos.y += Desc.Offset.y;

			return new Vector2( Vector3.Dot( right, pos ), Vector3.Dot( up, pos ) ) * (1.0f / scale);
		}

		private static readonly Vector3[] SideNormals = new[]
		{
			Vector3.Right,
			Vector3.Left,
			Vector3.Backward,
			Vector3.Forward,
		};

		private void Build( ModelBuilder builder, Mesh mesh )
		{
			if ( Desc == null )
				return;

			var numTilesX = Desc.Width;
			var numTilesY = Desc.Height;
			var tileWidth = (Desc.Size.x / numTilesX);
			var tileHeight = (Desc.Size.y / numTilesY);
			var halfTileWidth = tileWidth * 0.5f;
			var halfTileHeight = tileHeight * 0.5f;
			var halfThickness = Desc.Thickness * 0.5f;

			var vertices = new List<SimpleVertex>();
			var indices = new List<int>();

			var maskIndex = 0;
			var vertexCount = 0;

			var mask = new bool[numTilesX * numTilesY];
			for ( var i = 0; i < (numTilesX * numTilesY); i++ )
			{
				mask[i] = Desc.Mask[i] != 0;
			}

			if ( PhysicsBody.IsValid() )
			{
				var shapes = PhysicsBody.Shapes.ToList();
				foreach ( var shape in shapes )
				{
					PhysicsBody.RemoveShape( shape, false );
				}
			}

			for ( var y = 0; y < numTilesY; y++ )
			{
				for ( var x = 0; x < numTilesX; )
				{
					if ( mask[maskIndex] )
					{
						x++;
						maskIndex++;

						continue;
					}

					int faceWidth;
					int faceHeight;

					for ( faceWidth = 1;
						 x + faceWidth < numTilesX &&
						 !mask[maskIndex + faceWidth] &&
						 mask[maskIndex + faceWidth] == mask[maskIndex];
						 faceWidth++ ) ;

					bool faceHeightCalculated = false;

					for ( faceHeight = 1; y + faceHeight < numTilesY; faceHeight++ )
					{
						for ( uint k = 0; k < faceWidth; k++ )
						{
							bool faceCulled = mask[maskIndex + k + faceHeight * numTilesX];
							if ( faceCulled || faceCulled != mask[maskIndex] )
							{
								faceHeightCalculated = true;

								break;
							}
						}

						if ( faceHeightCalculated )
						{
							break;
						}
					}

					var extents = new Vector3( faceWidth * halfTileWidth, faceHeight * halfTileHeight, halfThickness );
					var origin = new Vector3( x - faceWidth * -0.5f, y - faceHeight * -0.5f, 0 ) * new Vector3( tileWidth, tileHeight, 0 );
					origin -= new Vector3( Desc.Size ) * 0.5f;

					if ( builder != null )
					{
						builder.AddCollisionBox( extents, origin );
					}
					else
					{
						if ( PhysicsBody.IsValid() )
						{
							PhysicsBody.AddBoxShape( origin, Rotation.Identity, extents, false );
						}
					}

					if ( mesh != null )
					{
						var offset = new Vector3( Desc.Size * 0.5f, 0 );
						var scale = new Vector3( tileWidth, tileHeight, 0 );

						{
							var v0 = new Vector3( x, y, 0 ) * scale - offset;
							var v1 = new Vector3( x + faceWidth, y, 0 ) * scale - offset;
							var v2 = new Vector3( x + faceWidth, y + faceHeight, 0 ) * scale - offset;
							var v3 = new Vector3( x, y + faceHeight, 0 ) * scale - offset;

							v0 = v0.WithZ( -halfThickness );
							v1 = v1.WithZ( -halfThickness );
							v2 = v2.WithZ( -halfThickness );
							v3 = v3.WithZ( -halfThickness );

							vertices.Add( new SimpleVertex( v0, Vector3.Down, Vector3.Forward, Planar( v0, Vector3.Forward, Vector3.Left ) ) );
							vertices.Add( new SimpleVertex( v1, Vector3.Down, Vector3.Forward, Planar( v1, Vector3.Forward, Vector3.Left ) ) );
							vertices.Add( new SimpleVertex( v2, Vector3.Down, Vector3.Forward, Planar( v2, Vector3.Forward, Vector3.Left ) ) );
							vertices.Add( new SimpleVertex( v3, Vector3.Down, Vector3.Forward, Planar( v3, Vector3.Forward, Vector3.Left ) ) );

							indices.Add( vertexCount + 0 );
							indices.Add( vertexCount + 3 );
							indices.Add( vertexCount + 2 );
							indices.Add( vertexCount + 2 );
							indices.Add( vertexCount + 1 );
							indices.Add( vertexCount + 0 );

							vertexCount = vertices.Count;

							v0 = v0.WithZ( halfThickness );
							v1 = v1.WithZ( halfThickness );
							v2 = v2.WithZ( halfThickness );
							v3 = v3.WithZ( halfThickness );

							vertices.Add( new SimpleVertex( v0, Vector3.Up, Vector3.Backward, Planar( v0, Vector3.Backward, Vector3.Left ) ) );
							vertices.Add( new SimpleVertex( v1, Vector3.Up, Vector3.Backward, Planar( v1, Vector3.Backward, Vector3.Left ) ) );
							vertices.Add( new SimpleVertex( v2, Vector3.Up, Vector3.Backward, Planar( v2, Vector3.Backward, Vector3.Left ) ) );
							vertices.Add( new SimpleVertex( v3, Vector3.Up, Vector3.Backward, Planar( v3, Vector3.Backward, Vector3.Left ) ) );

							indices.Add( vertexCount + 0 );
							indices.Add( vertexCount + 1 );
							indices.Add( vertexCount + 2 );
							indices.Add( vertexCount + 2 );
							indices.Add( vertexCount + 3 );
							indices.Add( vertexCount + 0 );

							vertexCount = vertices.Count;
						}

						var yOffsets = new int[] { -1, faceHeight, 0, 0 };
						var xOffsets = new int[] { 0, 0, -1, faceWidth };
						var sideWidths = new int[]
						{
							y == 0 ? faceWidth : 0,
							y + faceHeight == numTilesY ? faceWidth : 0,
							x == 0 ? faceHeight : 0,
							x + faceWidth == numTilesX ? faceHeight : 0,
						};

						var maxWidths = new int[]
						{
							faceWidth,
							faceWidth,
							faceHeight,
							faceHeight,
						};

						for ( int sideIndex = 0; sideIndex < 4; sideIndex++ )
						{
							int sideWidth = sideWidths[sideIndex];
							var maxWidth = maxWidths[sideIndex];

							for ( int sideMaskIndex = 0; sideMaskIndex < maxWidth; )
							{
								for ( int i = sideMaskIndex + sideWidth; i < maxWidth; ++i )
								{
									int xPos = (xOffsets[sideIndex] == 0 ? i : 0) + x + xOffsets[sideIndex];
									int yPos = (yOffsets[sideIndex] == 0 ? i : 0) + y + yOffsets[sideIndex];

									if ( Desc.Mask[xPos + (yPos * numTilesX)] == 0 )
									{
										break;
									}
									else
									{
										sideWidth++;
									}
								}

								if ( sideWidth == 0 )
								{
									sideMaskIndex++;

									continue;
								}

								{
									Vector3 v0 = Vector3.Zero;
									Vector3 v1 = Vector3.Zero;

									if ( sideIndex == 0 )
									{
										v0 = new Vector3( x + sideMaskIndex, y, 0 ) * scale - offset;
										v1 = new Vector3( x + sideMaskIndex + sideWidth, y, 0 ) * scale - offset;
									}
									else if ( sideIndex == 1 )
									{
										v1 = new Vector3( x + sideMaskIndex, y + faceHeight, 0 ) * scale - offset;
										v0 = new Vector3( x + sideMaskIndex + sideWidth, y + faceHeight, 0 ) * scale - offset;
									}
									else if ( sideIndex == 2 )
									{
										v1 = new Vector3( x, y + sideMaskIndex, 0 ) * scale - offset;
										v0 = new Vector3( x, y + sideMaskIndex + sideWidth, 0 ) * scale - offset;
									}
									else if ( sideIndex == 3 )
									{
										v0 = new Vector3( x + faceWidth, y + sideMaskIndex, 0 ) * scale - offset;
										v1 = new Vector3( x + faceWidth, y + sideMaskIndex + sideWidth, 0 ) * scale - offset;
									}

									v0 = v0.WithZ( -halfThickness );
									v1 = v1.WithZ( -halfThickness );

									var v2 = v0.WithZ( halfThickness );
									var v3 = v1.WithZ( halfThickness );

									var normal = SideNormals[sideIndex];
									var tangent = (v1 - v0).Normal;
									var binormal = normal.Cross( tangent );

									vertices.Add( new SimpleVertex( v2, normal, tangent, Planar( v2.WithZ( halfThickness * 2 ), tangent, binormal ) ) );
									vertices.Add( new SimpleVertex( v3, normal, tangent, Planar( v3.WithZ( halfThickness * 2 ), tangent, binormal ) ) );
									vertices.Add( new SimpleVertex( v1, normal, tangent, Planar( v1.WithZ( 0 ), tangent, binormal ) ) );
									vertices.Add( new SimpleVertex( v0, normal, tangent, Planar( v0.WithZ( 0 ), tangent, binormal ) ) );

									indices.Add( vertexCount + 0 );
									indices.Add( vertexCount + 3 );
									indices.Add( vertexCount + 2 );
									indices.Add( vertexCount + 2 );
									indices.Add( vertexCount + 1 );
									indices.Add( vertexCount + 0 );
								}

								vertexCount = vertices.Count;

								sideMaskIndex += sideWidth;
								sideWidth = 0;
							}
						}
					}

					for ( uint h = 0; h < faceHeight; ++h )
					{
						for ( uint w = 0; w < faceWidth; ++w )
						{
							mask[maskIndex + w + h * numTilesX] = true;
						}
					}

					x += faceWidth;
					maskIndex += faceWidth;
				}
			}

			if ( mesh != null )
			{
				if ( mesh.HasVertexBuffer )
				{
					if ( vertices.Count > 0 )
					{
						mesh.SetVertexBufferSize( vertices.Count );
						mesh.SetVertexBufferData( vertices );
					}

					mesh.SetVertexRange( 0, vertices.Count );
				}
				else
				{
					mesh.CreateVertexBuffer( Math.Max( 1, vertices.Count ), SimpleVertex.Layout, vertices );
				}

				if ( mesh.HasIndexBuffer )
				{
					if ( indices.Count > 0 )
					{
						mesh.SetIndexBufferSize( indices.Count );
						mesh.SetIndexBufferData( indices );
					}

					mesh.SetIndexRange( 0, indices.Count );
				}
				else
				{
					mesh.CreateIndexBuffer( Math.Max( 1, indices.Count ), indices );
				}
			}

			var mass = CalculateMass();

			if ( PhysicsBody.IsValid() )
			{
				PhysicsBody.Mass = mass;
				PhysicsBody.SetSurface( "wood" );
				PhysicsBody.Wake();
			}

			if ( builder != null )
			{
				builder.WithMass( mass );
				builder.WithSurface( "wood" );

				if ( Mesh != null )
				{
					builder.AddMesh( Mesh );
				}
			}
		}
	}
}
