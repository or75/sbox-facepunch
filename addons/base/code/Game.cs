using Sandbox.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
	/// <summary>
	/// This is the main base game
	/// </summary>
	[Display( Name = "Game" ), Icon( "sports_esports" )]
	public abstract partial class Game : GameBase
	{
		public static Game Current { get; protected set; }

		public Game()
		{
			Transmit = TransmitType.Always;
			Current = this;
		}

		/// <summary>
		/// Called when the game is shutting down
		/// </summary>
		public override void Shutdown()
		{
			if ( Current == this )
				Current = null;
		}

		/// <summary>
		/// Client has joined the server. Create their puppets.
		/// </summary>
		public override void ClientJoined( Client cl )
		{
			Log.Info( $"\"{cl.Name}\" has joined the game" );
			ChatBox.AddInformation( To.Everyone, $"{cl.Name} has joined", $"avatar:{cl.PlayerId}" );
		}

		/// <summary>
		/// Client has disconnected from the server. Remove their entities etc.
		/// </summary>
		public override void ClientDisconnect( Client cl, NetworkDisconnectionReason reason )
		{
			Log.Info( $"\"{cl.Name}\" has left the game ({reason})" );
			ChatBox.AddInformation( To.Everyone, $"{cl.Name} has left ({reason})", $"avatar:{cl.PlayerId}" );

			if ( cl.Pawn.IsValid() )
			{
				cl.Pawn.Delete();
				cl.Pawn = null;
			}

		}

		/// <summary>
		/// Called each tick.
		/// Serverside: Called for each client every tick
		/// Clientside: Called for each tick for local client. Can be called multiple times per tick.
		/// </summary>
		public override void Simulate( Client cl )
		{
			if ( !cl.Pawn.IsValid() ) return;

			// Block Simulate from running clientside
			// if we're not predictable.
			if ( !cl.Pawn.IsAuthority ) return; 

			cl.Pawn.Simulate( cl );
		}

		/// <summary>
		/// Called each frame on the client only to simulate things that need to be updated every frame. An example
		/// of this would be updating their local pawn's look rotation so it updates smoothly instead of at tick rate.
		/// </summary>
		public override void FrameSimulate( Client cl )
		{
			Host.AssertClient();

			if ( !cl.Pawn.IsValid() ) return;

			// Block Simulate from running clientside
			// if we're not predictable.
			if ( !cl.Pawn.IsAuthority ) return;

			cl.Pawn?.FrameSimulate( cl );
		}

		/// <summary>
		/// Should we send voice data to this player
		/// </summary>
		public override bool CanHearPlayerVoice( Client source, Client dest )
		{
			Host.AssertServer();

			var sp = source.Pawn;
			var dp = dest.Pawn;

			if ( sp == null || dp == null ) return false;
			if ( sp.Position.Distance( dp.Position ) > 1000 ) return false;

			return true;
		}

		/// <summary>
		/// Which camera should we be rendering from?
		/// </summary>
		public virtual ICamera FindActiveCamera()
		{
			if ( Local.Client.DevCamera != null ) return Local.Client.DevCamera;
			if ( Local.Client.Camera != null ) return Local.Client.Camera;
			if ( Local.Pawn != null  ) return Local.Pawn.Camera;

			return null;
		}

		/// <summary>
		/// Player typed kill in the console. Override if you don't want players
		/// to be allowed to kill themselves.
		/// </summary>
		public virtual void DoPlayerSuicide( Client cl )
		{
			if ( cl.Pawn == null ) return;

			cl.Pawn.TakeDamage( DamageInfo.Generic( 1000 ) );
		}

		/// <summary>
		/// Player typed noclip in the console.
		/// </summary>
		public virtual void DoPlayerNoclip( Client player )
		{
			if ( !player.HasPermission( "noclip" ) )
				return;

			if ( player.Pawn is Player basePlayer )
			{
				if ( basePlayer.DevController is NoclipController )
				{
					Log.Info( "Noclip Mode Off" );
					basePlayer.DevController = null;
				}
				else
				{
					Log.Info( "Noclip Mode On" );
					basePlayer.DevController = new NoclipController();
				}
			}
		}

		/// <summary>
		/// The player wants to enable the devcam. Probably shouldn't allow this
		/// unless you're in a sandbox mode or they're a dev.
		/// </summary>
		public virtual void DoPlayerDevCam( Client player )
		{
			Host.AssertServer();

			if ( !player.HasPermission( "devcam" ) )
				return;

			player.DevCamera = player.DevCamera == null ? new DevCamera() : null;
		}

		[Predicted]
		public Camera LastCamera { get; set; }

		/// <summary>
		/// Called to set the camera up, clientside only.
		/// </summary>
		public override CameraSetup BuildCamera( CameraSetup camSetup )
		{
			var cam = FindActiveCamera();

			if ( LastCamera != cam )
			{
				LastCamera?.Deactivated();
				LastCamera = cam as Camera;
				LastCamera?.Activated();
			}

			cam?.Build( ref camSetup );

			// if we have no cam, lets use the pawn's eyes directly
			if ( cam == null && Local.Pawn != null )
			{
				camSetup.Rotation = Local.Pawn.EyeRot;
				camSetup.Position = Local.Pawn.EyePos;
			}

			PostCameraSetup( ref camSetup );

			return camSetup;
		}

		/// <summary>
		/// Clientside only. Called every frame to process the input.
		/// The results of this input are encoded\ into a user command and
		/// passed to the PlayerController both clientside and serverside.
		/// This routine is mainly responsible for taking input from mouse/controller
		/// and building look angles and move direction.
		/// </summary>
		public override void BuildInput( InputBuilder input )
		{
			Event.Run( "buildinput", input );

			// the camera is the primary method here
			LastCamera?.BuildInput( input );

			Local.Pawn?.BuildInput( input );
		}

		/// <summary>
		/// Called after the camera setup logic has run. Allow the gamemode to 
		/// do stuff to the camera, or using the camera. Such as positioning entities 
		/// relative to it, like viewmodels etc.
		/// </summary>
		public override void PostCameraSetup( ref CameraSetup camSetup )
		{
			if ( Local.Pawn != null )
			{
				// VR anchor default is at the pawn's location
				VR.Anchor = Local.Pawn.Transform;

				Local.Pawn.PostCameraSetup( ref camSetup );
			}

			//
			// Position any viewmodels
			//
			BaseViewModel.UpdateAllPostCamera( ref camSetup );

			CameraModifier.Apply( ref camSetup );
		}

		/// <summary>
		/// Called right after the level is loaded and all entities are spawned.
		/// </summary>
		public override void PostLevelLoaded()
		{

		}

		/// <summary>
		/// Someone is speaking via voice chat. This might be someone in your game, 
		/// or in your party, or in your lobby.
		/// </summary>
		public override void OnVoicePlayed( long playerId, float level )
		{
			var client = Client.All.Where( x => x.PlayerId == playerId ).FirstOrDefault();
			if ( client.IsValid() )
			{
				client.VoiceLevel = level;
				client.TimeSinceLastVoice = 0;
			}

			VoiceList.Current?.OnVoicePlayed( playerId, level );
		}
	}
}
