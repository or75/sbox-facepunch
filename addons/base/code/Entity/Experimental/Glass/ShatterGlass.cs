using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandbox
{
	/// <summary>
	/// A procedurally shattering glass panel.
	/// </summary>
	[Library( "func_shatterglass" )]
	[Hammer.Solid]
	[Hammer.PhysicsTypeOverrideMesh]
	[Display( Name = "Shatter Glass" ), Icon( "wine_bar" )]
	public partial class ShatterGlass : ModelEntity
	{
		public Vector2 PanelSize { get; private set; }
		[Net] public bool IsBroken { get; set; }
		private Transform PanelTransform;

		private readonly List<GlassShard> Shards = new();
		public int NumShards => Shards.Count;

		/// <summary>
		/// Thickness of the glass
		/// </summary>
		[Property( "glass_thickness" ), Display( Name = "Glass Thickness" )]
		public float Thickness { get; private set; } = 1.0f;
		public float HalfThickness => Thickness * 0.5f;

		/// <summary>
		/// Material to use for the glass
		/// </summary>
		[Property( "glass_material" ), Display( Name = "Glass Material" ), ResourceType( "vmat" )]
		[Internal.DefaultValue( "materials/glass/sbox_glass.vmat" )]
		[Net] public string Material { get; set; }

		/// <summary>
		/// Material to use for the glass when it is broken. If not set, the material will not change on break.
		/// </summary>
		[Property, Display( Name = "Glass Material When Broken" ), ResourceType( "vmat" )]
		[Net] public string BrokenMaterial { get; set; }

		[Property( "quad_left" ), Hammer.Skip]
		public Vector3 QuadLeft { get; set; }

		[Property( "quad_up" ), Hammer.Skip]
		public Vector3 QuadUp { get; set; }

		public enum ShatterGlassConstraint
		{
			StaticEdges,
			Physics,
			PhysicsButAsleep
		}

		/// <summary>
		/// Glass constraint.<br/>
		/// <b>Glass with static edges</b> will not be affected by gravity (glass pieces will) and will shatter piece by piece.<br/>
		/// <b>Physics glass</b> is affected by gravity and will shatter all at the same time.<br/>
		/// <b>Physics but asleep</b> is same as physics but will not move on spawn.
		/// </summary>
		[Property]
		public ShatterGlassConstraint Constraint { get; private set; } = ShatterGlassConstraint.StaticEdges;

		[AdminCmd( "glass_reset" )]
		public static void ResetGlassCommand()
		{
			var ents = All.OfType<ShatterGlass>().ToList();
			foreach ( var ent in ents )
			{
				if ( ent.IsBroken )
				{
					ent.Reset();
				}
			}
		}

		/// <summary>
		/// Fired when the panel initially breaks.
		/// </summary>
		public Output OnBreak { get; set; }

		public override void Spawn()
		{
			base.Spawn();

			Thickness = Thickness.Clamp( 0.2f, 20.0f );

			var left = QuadLeft;
			var up = QuadUp;

			PanelSize = new Vector2( left.Length, up.Length );

			var forward = left.Cross( up );
			var rotation = Rotation.LookAt( left.Normal, forward.Normal );

			PanelTransform = Transform.ToLocal( new Transform( CollisionWorldSpaceCenter, rotation ) );

			SetModel( "" );

			Reset();
		}

		public void Reset()
		{
			if ( !IsAuthority )
				return;

			IsBroken = false;

			foreach ( var shard in Shards )
			{
				shard.MarkForDeletion();
			}

			Shards.Clear();

			if ( PanelSize.x > 0 && PanelSize.y > 0 )
			{
				var primaryShard = CreateNewShard( null );
				primaryShard.AddVertex( new Vector2( -PanelSize.x * 0.5f, -PanelSize.y * 0.5f ) );
				primaryShard.AddVertex( new Vector2( -PanelSize.x * 0.5f, PanelSize.y * 0.5f ) );
				primaryShard.AddVertex( new Vector2( PanelSize.x * 0.5f, PanelSize.y * 0.5f ) );
				primaryShard.AddVertex( new Vector2( PanelSize.x * 0.5f, -PanelSize.y * 0.5f ) );
				primaryShard.GenerateShardModel();

				if ( Constraint == ShatterGlassConstraint.StaticEdges )
				{
					primaryShard.Freeze();
				}
				else if ( Constraint == ShatterGlassConstraint.PhysicsButAsleep )
				{
					primaryShard.PhysicsBody.Sleep();
				}

				primaryShard.Parent = Parent;
			}
		}

		public GlassShard CreateNewShard( GlassShard parentShard )
		{
			var newShard = new GlassShard
			{
				ParentPanel = this,
				ParentShard = parentShard
			};

			if ( parentShard != null )
			{
				newShard.StressPosition = parentShard.StressPosition;
			}

			Shards.Insert( 0, newShard );
			return newShard;
		}

		public void RemoveShard( GlassShard shard )
		{
			Shards.Remove( shard );
		}

		public Transform GetPanelTransform()
		{
			return Transform.ToWorld( PanelTransform );
		}

		/// <summary>
		/// Breaks the glass at its center.
		/// </summary>
		[Input]
		public void Break()
		{
			if ( !IsAuthority )
				return;

			if ( IsBroken )
				return;

			Shards.FirstOrDefault()?.ShatterLocalSpace( Vector2.Zero );
		}
	}
}
