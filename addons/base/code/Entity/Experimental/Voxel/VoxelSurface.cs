using System.Linq;
using System.Collections.Generic;

namespace Sandbox
{
	/// <summary>
	/// A procedurally breakable voxel surface.
	/// </summary>
	[Library( "func_voxelsurface" )]
	[Hammer.Solid]
	[Hammer.PhysicsTypeOverrideMesh]
	public partial class VoxelSurface : ModelEntity
	{
		public Vector2 Size { get; private set; }
		private Transform LocalTransform;

		private readonly List<VoxelChunk> Chunks = new();
		public int NumChunks => Chunks.Count;

		/// <summary>
		/// How many voxels on the width (Limited to 64)
		/// </summary>
		[Property( "Width" )]
		public int Width { get; private set; } = 32;

		/// <summary>
		/// How many voxels on the height (Limited to 64)
		/// </summary>
		[Property( "Height" )]
		public int Height { get; private set; } = 32;

		/// <summary>
		/// How thick is the surface (Limited to 64)
		/// </summary>
		[Property( "Thickness" )]
		public float Thickness { get; private set; } = 1;

		/// <summary>
		/// Material to use for the surface
		/// </summary>
		[Property( "Material" ), ResourceType( "vmat" )]
		public string Material { get; set; } = "materials/dev/black_grid_8.vmat";

		/// <summary>
		/// Is the panel frozen
		/// </summary>
		[Property( "Frozen" )]
		public bool IsFrozen { get; private set; } = true;

		[Property( "quad_left" ), Hammer.Skip]
		public Vector3 QuadLeft { get; set; }

		[Property( "quad_up" ), Hammer.Skip]
		public Vector3 QuadUp { get; set; }

		[AdminCmd( "voxel_reset" )]
		public static void ResetGlassCommand()
		{
			var ents = All.OfType<VoxelSurface>().ToList();
			foreach ( var ent in ents )
			{
				ent.Reset();
			}
		}

		public override void Spawn()
		{
			base.Spawn();

			var left = QuadLeft;
			var up = QuadUp;

			Size = new Vector2( left.Length, up.Length );

			var forward = left.Cross( up );
			var rotation = Rotation.LookAt( left.Normal, forward.Normal );

			LocalTransform = Transform.ToLocal( new Transform( CollisionWorldSpaceCenter, rotation ) );

			SetModel( "" );

			Reset();
		}

		public void Reset()
		{
			if ( !IsAuthority )
				return;

			foreach ( var chunk in Chunks )
			{
				chunk.MarkForDeletion();
			}

			Chunks.Clear();

			Width = Width.Clamp( 1, 64 );
			Height = Height.Clamp( 1, 64 );
			Thickness = Thickness.Clamp( 0.1f, 64.0f );

			if ( Size.x > 0 && Size.y > 0 )
			{
				var newChunk = CreateNewChunk();
				newChunk.CreateModel( Size, Vector2.Zero, Width, Height, Thickness, Width * Height, Material, IsFrozen );
			}
		}

		public VoxelChunk CreateNewChunk()
		{
			var newChunk = new VoxelChunk
			{
				ParentSurface = this,
				Transform = GetPanelTransform()
			};

			Chunks.Insert( 0, newChunk );
			return newChunk;
		}

		public void RemoveChunk( VoxelChunk chunk )
		{
			Chunks.Remove( chunk );
		}

		public Transform GetPanelTransform()
		{
			return Transform.ToWorld( LocalTransform );
		}
	}
}
