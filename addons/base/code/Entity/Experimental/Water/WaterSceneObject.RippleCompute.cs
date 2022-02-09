using NativeEngine;
using System;
using Sandbox;
using System.Collections.Generic;

namespace Sandbox
{
	public partial class WaterSceneObject
	{
		public class RippleCompute
		{
			internal WaterSceneObject Water;
			internal Render.Compute compute;


			public Texture Texture;
			internal Texture PrevTexture;

			/// <summary>
			/// How far is the simulation radius of the splash from camera view
			/// </summary>
			public float Radius = 512;

			public struct SplashInformation
			{
				public Vector3 Position;
				public float Radius;
				public float Strength;
			};
			public struct RippleConstants
			{
				public Vector2 ViewPosition;
				public Vector2 ViewPositionLast;
				public float Radius;
				public float TimeDelta;
				public List<SplashInformation> Splashes;
			};

			public RippleConstants SplashConstants;
			public RippleCompute( WaterSceneObject parent )
			{
				Water = parent;
				compute = Render.Compute.Using( "ripplecompute_cs" );

				ImageFormat format = ImageFormat.RG1616F;
				Texture = Texture.Create( 256, 256 ).WithUAVBinding().WithFormat( format ).Finish();
				PrevTexture = Texture.Create( 256, 256 ).WithUAVBinding().WithFormat( format ).Finish();

				SplashConstants = new RippleConstants();
				SplashConstants.ViewPosition = new Vector2( 0, 0 );
				SplashConstants.ViewPositionLast = new Vector2( 0, 0 );
				SplashConstants.Radius = 0.0f;
				SplashConstants.Splashes = new List<SplashInformation>();
			}

			internal float GetSmallestRadiusFromBBox( BBox box )
			{
				return Math.Min( box.Mins.x - box.Maxs.x, Math.Min( box.Mins.y - box.Maxs.y, box.Mins.z - box.Maxs.z ) );
			}

			/// <summary>
			/// Updates per frame data for the splash to render on the GPU next
			/// </summary>
			public void Update()
			{
				float fHeight = Math.Max( Water.RenderBounds.Mins.z, Water.RenderBounds.Maxs.z );

				Vector3 vPos = new Vector3( CurrentView.Position.x + (CurrentView.Rotation.Forward.x * Radius), CurrentView.Position.y + (CurrentView.Rotation.Forward.y * Radius), fHeight );

				//Clamp to AABB so we can better optimize the used space
				vPos.x = Math.Clamp( vPos.x, Water.RenderBounds.Mins.x - Radius, Water.RenderBounds.Maxs.x + Radius );
				vPos.y = Math.Clamp( vPos.y, Water.RenderBounds.Mins.y - Radius, Water.RenderBounds.Maxs.y + Radius );

				BBox box = new BBox( vPos + new Vector3( -Radius, -Radius, 8 ), vPos + new Vector3( Radius, Radius, -8 ) );

				SplashConstants.Splashes.Clear();

				foreach ( Entity ent in Physics.GetEntitiesInBox( box ) )
				{
					Vector3 debugPos = new Vector3( ent.Position.x, ent.Position.y, fHeight );
					Vector3 velocityDelta = new Vector3( ent.LocalVelocity * Time.Delta );

					float radius = GetSmallestRadiusFromBBox( ent.WorldSpaceBounds ) * 0.333f;

					if ( velocityDelta.IsNearZeroLength )
						continue;

					// Add splash to list
					SplashConstants.Splashes.Add( new SplashInformation()
					{
						Position = new Vector2( ent.Position.x, ent.Position.y ),
						Radius = radius,
						Strength = velocityDelta.Length
					}
						);

				}

				// Encode the data
				SplashConstants.ViewPositionLast = SplashConstants.ViewPosition;
				SplashConstants.ViewPosition = vPos;
				SplashConstants.Radius = Radius;
				SplashConstants.TimeDelta = 1.0f / 60.0f; //Math.Min( Time.Delta, 0.33f );

				// If debug view is on
				//DebugView( box, fHeight );
			}

			internal void DebugView( BBox box, float height )
			{
				//Splash texture bounds
				DebugOverlay.Box( box.Mins, box.Maxs, Color.Cyan, 0, false );

				foreach ( var splash in SplashConstants.Splashes )
				{
					DebugOverlay.Box(
						new Vector3( splash.Position, height ) + new Vector3( splash.Radius, splash.Radius, splash.Strength ),
						new Vector3( splash.Position, height ) + new Vector3( -splash.Radius, -splash.Radius, -splash.Strength ),
						Color.Red,
						0,
						false
						);
				}
			}

			/// <summary>
			/// Encodes the information of the splash into a float4
			/// </summary>
			public Vector4 EncodeSplash( SplashInformation splash )
			{
				return new Vector4( splash.Position.x, splash.Position.y, splash.Radius, splash.Strength );
			}

			/// <summary>
			/// Renders the splash texture on the compute shader on the GPU
			/// </summary>
			public void OnRender()
			{
				if ( !Texture.IsLoaded )
					return;

				// Swap textures
				Texture temp = Texture;
				Texture = PrevTexture;
				PrevTexture = temp;

				// Update the compute shader
				compute.ThreadCount( Texture.Width, Texture.Height, 1 );

				//Send the constants to the compute shader
				compute.WithAttribute( "ViewPosition", SplashConstants.ViewPosition );
				compute.WithAttribute( "ViewPositionLast", SplashConstants.ViewPositionLast );
				compute.WithAttribute( "Radius", SplashConstants.Radius * 2.0f );
				compute.WithAttribute( "TimeDelta", SplashConstants.TimeDelta );
				compute.WithAttribute( "Splashes", SplashConstants.Splashes.Count );

				if ( SplashConstants.Splashes.Count > 0 )
				{
					// TODO FIXME: We don't have compute buffers working properly, so we send the first one
					compute.WithAttribute( "SplashInformation0", EncodeSplash( SplashConstants.Splashes[0] ) );
				}

				// Send the textures
				compute.WithAttribute( "SplashTexture", Texture )
						.WithAttribute( "SplashTextureLast", PrevTexture )

						.WithAttribute( "SplashTextureSize", Texture.Width );
				compute.Dispatch();

			}

		};
	};

}
