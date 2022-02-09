﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Sandbox
{
	/// <summary>
	/// Extensions for Model
	/// </summary>
	public static partial class ModelExtensions
	{
		/// <summary>
		/// Get a list of break pieces for this model. These are stored in the "break_list" data key.
		/// </summary>
		public static ModelBreakPiece[] GetBreakPieces( this Model self )
		{
			return self.GetData<ModelBreakPiece[]>();
		}

		/// <summary>
		/// Get prop data for this model. This is stored in the "prop_data" data key.
		/// </summary>
		public static ModelPropData GetPropData( this Model self )
		{
			return self.GetData<ModelPropData>();
		}

		/// <summary>
		/// Check if prop data exists for this model. This is stored in the "prop_data" data key.
		/// </summary>
		public static bool HasPropData( this Model self )
		{
			return self.HasData<ModelPropData>();
		}

		/// <summary>
		/// Check if explosion behavior exists for this model. This is stored in the "explosion_behavior" data key.
		/// </summary>
		public static bool HasExplosionBehavior( this Model self )
		{
			return self.HasData<ModelExplosionBehavior>();
		}

		/// <summary>
		/// Get explosion behavior for this model. This is stored in the "explosion_behavior" data key.
		/// </summary>
		public static ModelExplosionBehavior GetExplosionBehavior( this Model self )
		{
			return self.GetData<ModelExplosionBehavior>();
		}

		/// <summary>
		/// Get a list of particles for this model. These are stored in the "particles_list" data key.
		/// </summary>
		public static ModelParticle[] GetParticles( this Model self )
		{
			return self.GetData<ModelParticle[]>();
		}

		/// <summary>
		/// Returns all game data nodes that derive from given class/interface, and are present on the model. Does NOT support data nodes that allow multiple entries.
		/// </summary>
		public static List<T> GetAllData<T>( this Model self )
		{
			List<T> list = new();

			var attrs = Library.GetAllAttributes<T>();
			foreach( var attr in attrs )
			{
				var att = attr as ModelDoc.GameDataAttribute;
				if ( att.AllowMultiple ) continue;

				object data;
				if ( self.TryGetData( att.Class, out data ) )
				{
					list.Add( (T)data );
				}
			}

			return list;
		}
	}

	/// <summary>
	/// Spawn a particle when the model is used on an entity. Support for this depends on the entity.
	/// </summary>
	[ModelDoc.GameData( "particle", AllowMultiple = true )]
	public class ModelParticle
	{
		[DisplayName( "Particle" ), ResourceType( "vpcf") ]
		public string Name { get; set; }

		[JsonPropertyName( "attachment_point" ), FGDType( "model_attachment" )]
		public string AttachmentPoint { get; set; }

		[JsonPropertyName( "attachment_type" )]
		public ParticleAttachment AttachmentType { get; set; } = ParticleAttachment.AttachmentFollow;

		[JsonPropertyName( "attachment_offset" )]
		public Vector3 AttachmentOffset { get; set; }
	}

	/// <summary>
	/// Defines a single breakable prop gib.
	/// </summary>
	// This type is automatically generated by ModelDoc, it does not exist in .fgd.
	[ModelDoc.GameData( "break_list_piece", AllowMultiple = true ), Hammer.Skip]
	public struct ModelBreakPiece
	{
		[JsonPropertyName( "piece_name" )]
		public string PieceName { get; set; }

		public string Model { get; set; }
		public string Ragdoll { get; set; }
		public Vector3 Offset { get; set; }
		public float FadeTime { get; set; }
		public float FadeMinDist { get; set; }
		public float FadeMaxDist { get; set; }

		[JsonPropertyName( "random_spawn_chance" )]
		public float RandomSpawnChance { get; set; }

		[JsonPropertyName( "is_essential_piece" )]
		public bool IsEssential { get; set; }

		[JsonPropertyName( "collision_group_override" )]
		public string CollisionGroupOverride { get; set; }

		public CollisionGroup GetCollisionGroup()
		{
			if ( CollisionGroupOverride == "debris" ) return CollisionGroup.Debris;
			if ( CollisionGroupOverride == "interactive" ) return CollisionGroup.Interactive;

			return CollisionGroup.Default;
		}

		public string PlacementBone { get; set; }
		public string PlacementAttachment { get; set; }
		public string NameMode { get; set; }
	}

	/// <summary>
	/// Generic prop settings. Support for this depends on the entity.
	/// </summary>
	[ModelDoc.GameData( "prop_data" )]
	public class ModelPropData
	{
		// Empty dropdown, I dont think we want this
		/*/// <summary>
		/// Base keys (entry from propdata.txt)
		/// </summary>
		[JsonPropertyName( "base" ), DisplayName( "Base Prop" ), FGDType( "propdataname" )]
		public string BasePropData { get; set; }*/

		/// <summary>
		/// TODO: Implement/Delete
		/// </summary>
		[DisplayName( "Allow As Static Prop" )]
		public bool AllowStatic { get; set; } = false;

		/// <summary>
		/// TODO: Implement/Delete
		/// </summary>
		[DisplayName( "Bake Lighting As Static Prop" )]
		public bool BakeLighting { get; set; } = true;

		/// <summary>
		/// TODO: Implement/Delete
		/// </summary>
		[JsonPropertyName( "spawn_motion_disabled" ), DisplayName( "Spawn as Motion-Disabled" )]
		public bool SpawnMotionDisabled { get; set; } = false;

		/// <summary>
		/// When this model is used as prop_physics, it's health will be set to this value.
		/// </summary>
		public float Health { get; set; } = -1;

		/// <summary>
		/// TODO: Implement/Delete
		/// </summary>
		[JsonPropertyName( "min_impact_damage_speed" ), DisplayName( "Minimum Impact Damage Speed" )]
		public float MinImpactDamageSpeed { get; set; } = -1;

		/// <summary>
		/// TODO: Implement/Delete
		/// </summary>
		[JsonPropertyName( "impact_damage" )]
		public float ImpactDamage { get; set; } = -1;

		/// <summary>
		/// TODO: Implement/Delete
		/// </summary>
		[JsonPropertyName( "parent_bodygroup_name" )]
		public string ParentBodygroupName { get; set; }

		/// <summary>
		/// TODO: Implement/Delete
		/// </summary>
		[JsonPropertyName( "parent_bodygroup_value" )]
		public int ParentBodygroupValue { get; set; }
	}

	/// <summary>
	/// Defines the model as explosive. Support for this depends on the entity.
	/// </summary>
	[ModelDoc.GameData( "explosion_behavior" )]
	[ModelDoc.Sphere( "explosive_radius" )]
	public class ModelExplosionBehavior
	{
		/// <summary>
		/// Sound override for when the prop explodes.
		/// </summary>
		[JsonPropertyName( "explosion_custom_sound" ), FGDType( "sound" )]
		public string Sound { get; set; }

		/// <summary>
		/// Particle effect override for when the problem explodes.
		/// </summary>
		[JsonPropertyName( "explosion_custom_effect" ), ResourceType( "vpcf" )]
		public string Effect { get; set; }

		/// <summary>
		/// Amount of damage to do at the center on the explosion. It will falloff over distance.
		/// </summary>
		[JsonPropertyName( "explosive_damage" )]
		public float Damage { get; set; } = -1;

		/// <summary>
		/// Range of explosion's damage.
		/// </summary>
		[JsonPropertyName( "explosive_radius" )]
		public float Radius { get; set; } = -1;

		/// <summary>
		/// Scale of the force applied to entities damaged by the explosion and the models break pieces.
		/// </summary>
		[JsonPropertyName( "explosive_force" ), DisplayName( "Force Scale" )]
		public float Force { get; set; } = -1;
	}
}
