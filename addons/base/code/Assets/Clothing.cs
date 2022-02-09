using NativeEngine;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Sandbox
{
	/// <summary>
	/// A piece of player model customization.
	/// </summary>
	[Library( "clothing" ), AutoGenerate]
	public partial class Clothing : Asset
	{
		public static IReadOnlyList<Clothing> All => _all;
		internal static List<Clothing> _all = new();

		/// <summary>
		/// Name of the clothing to show in UI.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// A subtitle for this clothing piece.
		/// </summary>
		public string Subtitle { get; set; }

		/// <summary>
		/// What kind of clothing this is?
		/// </summary>
		public ClothingCategory Category { get; set; }

		/// <summary>
		/// The model to bonemerge to the player when this clothing is equpped.
		/// </summary>
		[ResourceType( "vmdl" )]
		public string Model { get; set; }

		/// <summary>
		/// Which material group of the model to use.
		/// </summary>
		// can we make this so you select the material group from Model?
		public string MaterialGroup { get; set; }


		[BitFlags]
		public Slots SlotsUnder { get; set; }

		[BitFlags]
		public Slots SlotsOver { get; set; }

		/// <summary>
		/// Which bodyparts of the player model should not show when this clothing is equpped.
		/// </summary>
		[BitFlags]
		public BodyGroups HideBody { get; set; }

		protected override void PostLoad()
		{
			base.PostLoad();

			if ( !_all.Contains( this ) )
				_all.Add( this );
		}

		public enum ClothingCategory : int
		{
			None,
			Hat,
			Hair,
			Skin,
			Footwear,
			Bottoms,
			Tops
		}

		[Flags]
		public enum Slots : int
		{
			Skin			= 1 << 0,
			HeadTop			= 1 << 1,
			HeadBottom		= 1 << 2,
			Face			= 1 << 3,
			Chest			= 1 << 4,
			LeftArm			= 1 << 5,
			RightArm		= 1 << 6,
			LeftWrist		= 1 << 7,
			RightWrist		= 1 << 8,
			LeftHand		= 1 << 9,
			RightHand		= 1 << 10,
			Groin			= 1 << 11,
			LeftThigh		= 1 << 12,
			RightThigh		= 1 << 13,
			LeftKnee		= 1 << 14,
			RightKnee		= 1 << 15,
			LeftShin		= 1 << 16,
			RightShin		= 1 << 17,
			LeftFoot		= 1 << 18,
			RightFoot		= 1 << 19,
			Glasses			= 1 << 20,
			EyeBrows		= 1 << 21,
			Eyes			= 1 << 22,
			Ears			= 1 << 23,
			Lips			= 1 << 24,
			Chin			= 1 << 25,
			Philtrum		= 1 << 26,
			Teeth			= 1 << 27,
			Waist			= 1 << 28,
		}

		[Flags]
		public enum BodyGroups : int
		{
			Head			= 1 << 0,
			Chest			= 1 << 1,
			Legs			= 1 << 2,
			Hands			= 1 << 3,
			Feet			= 1 << 4,
		}

		/// <summary>
		/// Return true if this item of clothing can be worn with the target item, at the same time.
		/// </summary>
		public bool CanBeWornWith( Clothing target )
		{
			if ( target == this ) return false;

			if ( (target.SlotsOver & SlotsOver) != 0 ) return false;
			if ( (target.SlotsUnder & SlotsUnder) != 0 ) return false;

			return true;
		}

	}
}
