using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sandbox
{
	/// <summary>
	/// Handle breaking a prop into bits
	/// </summary>
	public static class Breakables
	{
		// TODO - Debris collision group

		// TODO - Probably not ideal to use List here
		static internal List<Entity> CurrentGibs = new();

		[ServerVar( "gibs_max" )]
		static public int MaxGibs { get; set; } = 256;

		public static void Break( Entity ent, Result result = null )
		{
			if ( ent is ModelEntity modelEnt )
			{
				if ( result != null )
				{
					result.Source = ent;
				}

				Break( modelEnt.Model, modelEnt.Position, modelEnt.Rotation, modelEnt.Scale, modelEnt.RenderColor, result, modelEnt.PhysicsBody );
				if ( result != null ) ApplyBreakCommands( result );
			}
		}

		static string[] genericGibs = {
			"models/sbox_props/bin/rubbish_can.vmdl",
			"models/rust_props/small_junk/apple.vmdl",
			"models/rust_props/small_junk/can.vmdl",
			"models/rust_props/small_junk/beer_bottle.vmdl",
			"models/rust_props/small_junk/cola_bottle.vmdl",
			"models/rust_props/small_junk/cola_can.vmdl",
			"models/rust_props/small_junk/peanut_butter_jar.vmdl",
			"models/citizen_props/sodacan01.vmdl"
		};

		public static void Break( Model model, Vector3 pos, Rotation rot, float scale, Color color, Result result = null, PhysicsBody sourcePhysics = null )
		{
			if ( model == null || model.IsError )
				return;

			var genericGibsSpawned = false;
			var breakList = model.GetBreakPieces();
			if ( breakList == null || breakList.Length <= 0 )
			{
				genericGibsSpawned = true;

				// TODO: Try to get some gibs based on the material of the model or smth
				List<ModelBreakPiece> pieces = new();

				//int num = ( model.Bounds.Volume / 20000.0f ).CeilToInt();
				int num = ( model.Bounds.Size.x * model.Bounds.Size.y + model.Bounds.Size.y * model.Bounds.Size.z + model.Bounds.Size.z * model.Bounds.Size.x ).CeilToInt() / ( 432 * 2 );
				
				//DebugOverlay.Box( 10, pos, rot, model.Bounds.Mins, model.Bounds.Maxs, Color.Green );
				for ( int i = 0; i < num; i++ )
                {
					ModelBreakPiece piece = new();
					piece.Model = Rand.FromArray( genericGibs );
					piece.Offset = model.Bounds.RandomPointInside;
					piece.CollisionGroupOverride = "debris";
					piece.FadeTime = 3.0f;
					pieces.Add( piece );

					//DebugOverlay.Axis( pos + rot * piece.Offset, Rotation.Identity, 10, 10 );
                }

				breakList = pieces.ToArray();
			}

			if ( breakList == null || breakList.Length <= 0 ) return;

			// Remove all invalid gibs
			CurrentGibs.RemoveAll( x => !x.IsValid() );

			// Remove enough old gibs to fit the new ones...
			if ( MaxGibs > 0 && CurrentGibs.Count + breakList.Length >= MaxGibs )
			{
				int toRemove = (CurrentGibs.Count + breakList.Length) - MaxGibs;
				toRemove = Math.Min( toRemove, CurrentGibs.Count );
				for ( int i = 0; i < toRemove; i++ )
				{
					CurrentGibs[ i ].Delete();
					// Not fading out because that still causes too much lag with large amounts of gibs
					//_ = FadeAsync( CurrentGibs[ i ] as Prop, 0.1f );
				}
				CurrentGibs.RemoveRange( 0, toRemove );
			}

			foreach ( var piece in breakList )
			{
				if ( MaxGibs >= 0 && CurrentGibs.Count >= MaxGibs ) return;

				var mdl = Model.Load( piece.Model );
				var offset = mdl.GetAttachment( "placementOrigin" ) ?? Transform.Zero;

				var gib = new PropGib
				{
					Position = pos + rot * ((piece.Offset - offset.Position) * scale),
					Rotation = rot,
					Scale = scale,
					RenderColor = color,
					CollisionGroup = piece.GetCollisionGroup(),
					Invulnerable = 0.2f,
					BreakpieceName = piece.PieceName
				};

				gib.Model = mdl;

				if ( piece.CollisionGroupOverride == "debris" )
				{
					gib.SetInteractsAs( CollisionLayer.Debris );
				}

				var phys = gib.PhysicsBody;
				if ( phys != null )
				{
					// Apply the velocity at the parent object's position
					if ( sourcePhysics != null )
					{
						phys.Velocity = sourcePhysics.GetVelocityAtPoint( phys.Position );
						phys.AngularVelocity = sourcePhysics.AngularVelocity;
					}
				}

				if ( piece.FadeTime > 0 )
				{
					_ = FadeAsync( gib, piece.FadeTime );
				}

				result?.AddProp( gib );

				if ( MaxGibs > 0 ) CurrentGibs.Add( gib );
			}

			// Give some randomness to generic gibs
			if ( genericGibsSpawned && result != null )
			{
				foreach ( var gib in result.Props )
				{
					gib.AngularVelocity = Angles.Random * 256;
					gib.Velocity = Vector3.Random * 100;
					gib.Rotation = Rotation.Random;
				}
			}
		}

		static async Task FadeAsync( Prop gib, float fadeTime )
		{
			fadeTime += Rand.Float( -1, 1 );

			if ( fadeTime < 0.5f )
				fadeTime = 0.5f;

			await gib.Task.DelaySeconds( fadeTime );

			var fadePerFrame = 5 / 255.0f;

			while ( gib.RenderColor.a > 0 )
			{
				var c = gib.RenderColor;
				c.a -= fadePerFrame;
				gib.RenderColor = c;
				await gib.Task.Delay( 20 );
			}

			gib.Delete();
		}

		public class Result
		{
			public struct BreakableParams
			{
				public Vector3 DamagePositon;
				// TODO: Move more data here?
			}

			/// <summary>
			/// The entity that is breaking.
			/// </summary>
			public Entity Source;

			/// <summary>
			/// Various break piece related parameters
			/// </summary>
			public BreakableParams Params;

			/// <summary>
			/// List of gibs generated. Amount of gibs may not match model's break piece count depending on value of <see cref="Breakables.MaxGibs"/>.
			/// </summary>
			public List<ModelEntity> Props = new List<ModelEntity>();

			public void AddProp( ModelEntity prop )
			{
				Props.Add( prop );
			}

			public void CopyParamsFrom( DamageInfo dmgInfo )
			{
				Params.DamagePositon = dmgInfo.Position;
			}
		}

		static JsonSerializerOptions jsonOptions = new JsonSerializerOptions
		{
			ReadCommentHandling = JsonCommentHandling.Skip,
			PropertyNameCaseInsensitive = true,
			IncludeFields = true,
			Converters =
			{
				new JsonStringEnumConverter()
			}
		};

		public static void ApplyBreakCommands( Result result )
		{
			var ent = result.Source as ModelEntity;
			if ( ent == null || ent.Model == null ) return;

			var data = ent.Model.GetBreakCommands();
			foreach ( var kv in data )
			{
				var cmd = kv.Key;
				var cmds = kv.Value;
				foreach( var c in cmds )
				{
					var type = Library.GetType( cmd );
					if ( type == null ) continue;

					try
					{
						Random random = new Random();
						object instance = JsonSerializer.Deserialize( c.PadRight( c.Length + random.Int( 100 ) ), type, jsonOptions );
						if ( !(instance is IModelBreakCommand bcInst) ) continue;

						bcInst.OnBreak( result );
					}
					catch( Exception e )
					{
						Log.Error( e );
					}
				}
			}
		}
	}

	/// <summary>
	/// A model break command, defined in ModelDoc and ran after spawning model gibs. The inheriting class must have a LibraryAttribute.
	/// </summary>
	public interface IModelBreakCommand
	{
		/// <summary>
		/// This will be called after an entity with this model breaks via <see cref="Breakables">Breakables</see> class.
		/// </summary>
		/// <param name="result">This class contains the break event data, including the source entity and the list of gibs.</param>
		public abstract void OnBreak( Sandbox.Breakables.Result result );
	}

	/// <summary>
	/// Spawn a particle system when this model breaks.
	/// </summary>
	[Library( "break_create_particle" )]
	public class ModelBreakParticle : IModelBreakCommand
	{
		// This is used for antlion death or smth
		/*[JsonPropertyName( "part_name" )]
		public string Name { get; set; }*/

		/// <summary>
		/// The particle to spawn when the model breaks.
		/// </summary>
		[JsonPropertyName( "name" ), ResourceType( "vpcf" )]
		public string Particle { get; set; }

		/// <summary>
		/// (Optional) Set the particle control point #0 to the specified model.
		/// </summary>
		[JsonPropertyName( "cp0_model" ), ResourceType( "vmdl" )]
		public string Model { get; set; }

		/// <summary>
		/// (Optional) Set the particle control point #0 to the specified snapshot.
		/// </summary>
		[JsonPropertyName( "cp0_snapshot" ), ResourceType( "vsnap" )]
		public string Snapshot { get; set; }

		/// <summary>
		/// (Optional) Set this control point to the position of the break damage.
		/// </summary>
		[JsonPropertyName( "damage_position_cp" ), Internal.DefaultValue( -1 )]
		public int? DamagePositionCP { get; set; }

		/// <summary>
		/// (Optional) Set this control point to the direction of the break damage.
		/// </summary>
		[JsonPropertyName( "damage_direction_cp" ), Internal.DefaultValue( -1 )]
		public int? DamageDirectionCP { get; set; }

		/// <summary>
		/// (Optional) Set this control point to the velocity of the original prop.
		/// </summary>
		[JsonPropertyName( "velocity_cp" ), Internal.DefaultValue( -1 )]
		public int? VelocityCP { get; set; }

		/// <summary>
		/// (Optional) Set this control point to the angular velocity of the original prop.
		/// </summary>
		[JsonPropertyName( "angular_velocity_cp" ), Internal.DefaultValue( -1 )]
		public int? AngularVelocityCP { get; set; }

		/// <summary>
		/// (Optional) Set this control point to global world gravity at the moment the model broke.
		/// </summary>
		[JsonPropertyName( "local_gravity_cp" ), Internal.DefaultValue( -1 )]
		public int? LocalGravityCP { get; set; }

		/// <summary>
		/// (Optional) Set this control point to the tint color of the original prop as a vector with values 0 to 1.
		/// </summary>
		[JsonPropertyName( "tint_cp" ), Internal.DefaultValue( -1 )]
		public int? TintCP { get; set; }

		// I think this is a Source 1 thing
		/*/// <summary>
		/// (Optional) Set this control point to the parent model's active materialgroup name.
		/// </summary>
		[JsonPropertyName( "skin_cp" ), Internal.DefaultValue( -1 )]
		public int? SkinCP { get; set; }*/

		public void OnBreak( Sandbox.Breakables.Result res )
		{
			if ( !(res.Source is ModelEntity ent) ) return;

			var part = Particles.Create( Particle, ent.Position );
			part.SetOrientation( 0, ent.Rotation );
			if ( !string.IsNullOrEmpty( Model ) ) part.SetModel( 0, Sandbox.Model.Load( Model ) );
			if ( !string.IsNullOrEmpty( Snapshot ) ) part.SetSnapshot( 0, Snapshot );

			if ( DamagePositionCP.HasValue )
			{
				part.SetPosition( DamagePositionCP.Value, res.Params.DamagePositon );
			}
			if ( DamageDirectionCP.HasValue )
			{
				part.SetForward( DamageDirectionCP.Value, (res.Params.DamagePositon - ent.Position).Normal );
			}
			if ( AngularVelocityCP.HasValue )
			{
				part.SetOrientation( AngularVelocityCP.Value, ent.AngularVelocity );
			}
			if ( LocalGravityCP.HasValue )
			{
				part.SetPosition( LocalGravityCP.Value, PhysicsWorld.Gravity );
				part.SetForward( LocalGravityCP.Value, PhysicsWorld.Gravity.Normal );
			}
			if ( VelocityCP.HasValue )
			{
				part.SetPosition( VelocityCP.Value, ent.Velocity );
				part.SetForward( VelocityCP.Value, ent.Velocity.Normal );
			}
			if ( TintCP.HasValue )
			{
				var clr = ent.RenderColor.ToColor32();
				part.SetPosition( TintCP.Value, new Vector3( clr.r, clr.g, clr.b ) );
			}
		}
	}

	/// <summary>
	/// Creates a revolute (hinge) joint between two spawned breakpieces.
	/// </summary>
	[Library( "break_create_joint_revolute" )]
	[ModelDoc.Axis( Origin = "anchor_position", Angles = "anchor_angles" )]
	[ModelDoc.HingeJoint( Origin = "anchor_position", Angles = "anchor_angles", EnableLimit = "enable_limit", MinAngle = "min_angle", MaxAngle = "max_angle" )]
	public class ModelBreakPieceRevoluteJoint : IModelBreakCommand
	{
		[JsonPropertyName( "parent_piece" ), FGDType( "model_breakpiece" )]
		public string ParentPiece { get; set; }

		[JsonPropertyName( "child_piece" ), FGDType( "model_breakpiece" )]
		public string ChildPiece { get; set; }

		[JsonPropertyName( "anchor_position" ), Display( Name = "Anchor Position (relative to model)" )]
		public Vector3 Position { get; set; }

		/// <summary>
		/// Axis around which the revolute/hinge joint rotates.
		/// </summary>
		[JsonPropertyName( "anchor_angles" ), Display( Name = "Anchor Axis (relative to model)" )]
		public Angles Angles { get; set; }

		/// <summary>
		/// Hinge friction.
		/// </summary>
		public float Friction { get; set; }

		/// <summary>
		/// Whether the angle limit should be enabled or not.
		/// </summary>
		[JsonPropertyName( "enable_limit" )]
		public bool LimitAngles { get; set; }

		[JsonPropertyName( "min_angle" ), Hammer.MinMax( -179, 179 )]
		public float MinimumAngle { get; set; }

		[JsonPropertyName( "max_angle" ), Hammer.MinMax( -179, 179 )]
		public float MaximumAngle { get; set; }

		public void OnBreak( Sandbox.Breakables.Result res )
		{
			var ParentEnt = res.Props.Find( prop => prop is PropGib gib && gib.BreakpieceName == ParentPiece );
			var ChildEnt = res.Props.Find( prop => prop is PropGib gib && gib.BreakpieceName == ChildPiece );
			if ( ParentEnt == null || ChildPiece == null ) return;

			var WorldPos = res.Source.Transform.PointToWorld( Position );
			var WorldAngle = res.Source.Transform.RotationToWorld( Rotation.From( Angles ) );

			var hinge = PhysicsJoint.Revolute
				.From( ParentEnt.PhysicsBody )
				.To( ChildEnt.PhysicsBody )
				.WithPivot( WorldPos )
				.WithBasis( WorldAngle )
				.WithFriction( Friction );

			if ( LimitAngles )
			{
				hinge = hinge.WithLimitEnabled( MinimumAngle, MaximumAngle );
			}

			hinge.Create();
		}
	}
}
