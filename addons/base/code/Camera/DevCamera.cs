using System;
using Sandbox.UI;

namespace Sandbox
{
	public class DevCamera : Camera
	{
		Angles LookAngles;
		Vector3 MoveInput;

		Vector3 TargetPos;
		Rotation TargetRot;

		bool PivotEnabled;
		Vector3 PivotPos;
		float PivotDist;

		float MoveSpeed;
		float FovOverride = 0;

		float LerpMode = 0;


		// TODO - saved client convar
		public static bool Overlays = true;

		private static RootPanel devRoot = null;
		private static DevCamSettings dofSettings = null;

		/// <summary>
		/// On the camera becoming activated, snap to the current view position
		/// </summary>
		public override void Activated()
		{
			base.Activated();

			TargetPos = CurrentView.Position;
			TargetRot = CurrentView.Rotation;

			Position = TargetPos;
			Rotation = TargetRot;
			LookAngles = Rotation.Angles();
			FovOverride = 80;

			Overlays = Cookie.Get( "debugcam.overlays", Overlays );

			if ( Overlays )
			{
				var pos = new Vector3( 100, 100 );
				var duration = 4.0f;

				DebugOverlay.ScreenText( pos, 0, Color.White, "  .                        ", duration );
				DebugOverlay.ScreenText( pos, 1, Color.White, ",-| ,-. .  , ,-. ,-. ,-,-. ", duration );
				DebugOverlay.ScreenText( pos, 2, Color.White, "| | |-' | /  |   ,-| | | | ", duration );
				DebugOverlay.ScreenText( pos, 3, Color.White, "`-^ `-' `'   `-' `-^ ' ' ' ", duration );

				DebugOverlay.ScreenText( pos, 5, Color.White, "  Free:  WSAD, Run/Crouch for speed", duration );
				DebugOverlay.ScreenText( pos, 6, Color.White, " Pivot:  Hold Walk (Default Alt) - forward + back to zoom in/out", duration );
				DebugOverlay.ScreenText( pos, 7, Color.White, "   DOF:  Hold Tab", duration );
				DebugOverlay.ScreenText( pos, 9, Color.White, "Reload:  Toggle Overlays", duration );
			}

			//
			// Set the devcamera class on the HUD. It's up to the HUD what it does with it.
			//
			Local.Hud?.SetClass( "devcamera", true );

			// Only create if we're using the dev cam
			if ( devRoot == null )
			{
				devRoot = new();
				dofSettings = devRoot.AddChild<DevCamSettings>();
				devRoot.AddChild( new DevCamFocalSelector( dofSettings ) );
			}
		}

		public override void Deactivated()
		{
			base.Deactivated();

			Local.Hud?.SetClass( "devcamera", false );
			dofSettings?.Hide();
			dofSettings?.DisableDof();
		}

		public override void Update()
		{
			var player = Local.Client;
			if ( player == null ) return;

			var tr = Trace.Ray( Position, Position + Rotation.Forward * 4096 ).UseHitboxes().Run();

			// DebugOverlay.Box( tr.EndPos, Vector3.One * -1, Vector3.One, Color.Red );

			FieldOfView = FovOverride;

			Viewer = null;

			if ( PivotEnabled )
			{
				PivotMove();
			}
			else
			{
				FreeMove();
			}


			if ( Overlays )
			{
				var normalRot = Rotation.LookAt( tr.Normal );
				DebugOverlay.Axis( tr.EndPos, normalRot, 3.0f );

				if ( tr.Entity != null && !tr.Entity.IsWorld )
				{
					DebugOverlay.Text( tr.EndPos + Vector3.Up * 20, $"Entity: {tr.Entity} ({tr.Entity.EngineEntityName})\n" +
																	$" Index: {tr.Entity.NetworkIdent}\n" +
																	$"Health: {tr.Entity.Health}", Color.White );

					if ( tr.Entity is ModelEntity modelEnt )
					{
						var bbox = modelEnt.CollisionBounds;
						DebugOverlay.Box( 0, tr.Entity.Position, tr.Entity.Rotation, bbox.Mins, bbox.Maxs, Color.Green );

						for ( int i = 0; i < modelEnt.BoneCount; i++ )
						{
							var tx = modelEnt.GetBoneTransform( i );
							var name = modelEnt.GetBoneName( i );
							var parent = modelEnt.GetBoneParent( i );


							if ( parent > -1 )
							{
								var ptx = modelEnt.GetBoneTransform( parent );
								DebugOverlay.Line( tx.Position, ptx.Position, Color.White, depthTest: false );
							}
						}

					}
				}
			}
		}

		public override void BuildInput( InputBuilder input )
		{

			MoveInput = input.AnalogMove;

			MoveSpeed = 1;
			if ( input.Down( InputButton.Run ) ) MoveSpeed = 5;
			if ( input.Down( InputButton.Duck ) ) MoveSpeed = 0.2f;

			if ( input.Down( InputButton.Slot1 ) ) LerpMode = 0.0f;
			if ( input.Down( InputButton.Slot2 ) ) LerpMode = 0.5f;
			if ( input.Down( InputButton.Slot3 ) ) LerpMode = 0.9f;

			if ( input.Pressed( InputButton.Walk ) )
			{
				var tr = Trace.Ray( Position, Position + Rotation.Forward * 4096 ).Run();
				PivotPos = tr.EndPos;
				PivotDist = Vector3.DistanceBetween( tr.EndPos, Position );
			}

			if ( input.Down( InputButton.Attack2 ) )
			{
				FovOverride += input.AnalogLook.pitch * (FovOverride / 30.0f);
				FovOverride = FovOverride.Clamp( 5, 150 );
				input.AnalogLook = default;
			}

			if ( input.Pressed( InputButton.Score ) )
			{
				dofSettings?.Show();
			}

			if ( input.Released( InputButton.Score ) )
			{
				dofSettings?.Hide();
			}

			LookAngles += input.AnalogLook * (FovOverride / 80.0f);
			LookAngles.roll = 0;

			PivotEnabled = input.Down( InputButton.Walk );

			if ( input.Pressed( InputButton.Reload ) )
			{
				Overlays = !Overlays;
				Cookie.Set( "debugcam.overlays", Overlays );
			}

			input.Clear();
			input.StopProcessing = true;
		}

		void FreeMove()
		{
			var mv = MoveInput.Normal * 300 * RealTime.Delta * Rotation * MoveSpeed;

			TargetRot = Rotation.From( LookAngles );
			TargetPos += mv;

			Position = Vector3.Lerp( Position, TargetPos, 10 * RealTime.Delta * (1 - LerpMode) );
			Rotation = Rotation.Slerp( Rotation, TargetRot, 10 * RealTime.Delta * (1 - LerpMode) );
		}

		void PivotMove()
		{
			PivotDist -= MoveInput.x * RealTime.Delta * 100 * (PivotDist / 50);
			PivotDist = PivotDist.Clamp( 1, 1000 );

			TargetRot = Rotation.From( LookAngles );
			Rotation = Rotation.Slerp( Rotation, TargetRot, 10 * RealTime.Delta * (1 - LerpMode) );

			TargetPos = PivotPos + Rotation.Forward * -PivotDist;
			Position = TargetPos;

			if ( Overlays )
			{
				var scale = Vector3.One * (2 + MathF.Sin( RealTime.Now * 10 ) * 0.3f);
				DebugOverlay.Box( PivotPos, scale * -1, scale, Color.Green );
			}
		}
	}
}
