using NativeEngine;
using System;
using Sandbox;

namespace Sandbox
{
	public partial class WaterSceneObject : CustomSceneObject
	{
		public BBox RenderBounds;
		public float WaterHeight;

		protected Material WaterMaterial;
		protected VertexBuffer vbWaterSurface;

		/// <summary>
		/// Controller used for planar reflections
		/// </summary>
		protected PlanarReflection WaterReflection;

		/// <summary>
		/// Controller used for water ripples using compute shaders
		/// </summary>
		protected RippleCompute WaterRipple;

		public WaterSceneObject( Water parent, Material material )
		{
			WaterMaterial = material;

			WaterReflection = new PlanarReflection();
			AddChild( "WaterReflection", WaterReflection );

			WaterRipple = new RippleCompute( this );
		}

		/// <summary>
		///	Updates that are carried outside render thread
		///	</summary>
		public virtual void Update()
		{
			float reflectionOffset = WaterHeight;
			WaterReflection?.Update( new Vector3(0,0, reflectionOffset) );
			WaterRipple?.Update();
		}
		/// <summary>
		///	Updates that are carried inside render thread
		///	</summary>
		public override void RenderSceneObject()
		{
			// Don't render if we are on the planar reflection's viewtarget itself
			if ( PlanarReflection.IsRenderingReflection() )
				return;

			//
			// Pass default parameters to the shader
			//
			Render.SetLighting( this );

			//
			// Update the needed stuff for both reflection and splash
			//
			WaterReflection?.OnRender();
			WaterRipple?.OnRender();

			//
			// Check if camera is inside or touching water
			//
			bool bViewIntersectingWater = ViewIntersetingBBox( RenderBounds );

			// Move these away so we don't generate the vb every frame
			int[] res = ApproximatePlaneResolution( RenderBounds );
			vbUnderwaterStencil = MakeCube( RenderBounds.Mins, RenderBounds.Maxs );
			vbWaterSurface = MakeTesselatedPlane( RenderBounds.Mins, RenderBounds.Maxs, res[0], res[1] );

			Sandbox.Render.CopyFrameBuffer( true );
			Sandbox.Render.CopyDepthBuffer();

			//
			// Water constants
			//
			Sandbox.Render.Set( "WaterHeight", WaterHeight );

			Sandbox.Render.SetCombo( "D_REFLECTION", WaterReflection is object );
			Sandbox.Render.SetCombo( "D_REFRACTION", true );
			Sandbox.Render.SetCombo( "D_RIPPLES", WaterRipple is object );

			//
			// Draw our underwater fog stencil before the main pass
			// And also only if our vision is intersecting the water
			//
			if ( bViewIntersectingWater )
			{
				Sandbox.Render.SetCombo( "D_UNDERWATER", true );
				vbUnderwaterStencil.Draw( WaterMaterial );
			}

			// If reflection is active, send reflection constants
			if ( WaterReflection is not null )
			{
				Sandbox.Render.Set( "ReflectionTexture", WaterReflection.ColorTarget );
			}

			//If splash is active, send constants
			Sandbox.Render.Set( "SplashTexture", WaterRipple.Texture );
			Sandbox.Render.Set( "SplashRadius", WaterRipple.SplashConstants.Radius );
			Sandbox.Render.Set( "SplashViewPosition", WaterRipple.SplashConstants.ViewPosition );

			Sandbox.Render.SetCombo( "D_UNDERWATER", false ); // Clear underwater flag when drawing main surface
			vbWaterSurface?.Draw( WaterMaterial );

			//DebugView();

			base.RenderSceneObject();
		}

		/// <summary>
		///	Checks if the view is intersecting the water bounding box
		/// Could probably be moved to a method inside BBox.cs to check if Vector3 is in bbox
		/// </summary>
		internal bool ViewIntersetingBBox( BBox bbox )
		{
			Vector3 viewPos = CurrentView.Position;
			float nearZ = 15;

			if ( viewPos.x < bbox.Mins.x - nearZ || viewPos.x > bbox.Maxs.x + nearZ
				|| viewPos.y < bbox.Mins.y - nearZ || viewPos.y > bbox.Maxs.y + nearZ
				|| viewPos.z < bbox.Mins.z - nearZ || viewPos.z > bbox.Maxs.z + nearZ )
				return false;

			return true;
		}

		internal void DebugView()
		{
			DebugOverlay.Box( RenderBounds.Mins, RenderBounds.Maxs, Color.Red, 0, false );
		}

		public int[] ApproximatePlaneResolution( BBox bounds )
		{
			Vector2 Bounds = new Vector2( bounds.Maxs.x - bounds.Mins.x, bounds.Maxs.y - bounds.Mins.y );

			int[] res = new int[] { (int)(Bounds.x / 512), (int)(Bounds.y / 512) };
			res = new int[] { Math.Clamp( res[0], 1, 256 ), Math.Clamp( res[1], 1, 256 ) };
			return res;
		}

		public VertexBuffer MakeTesselatedPlane( Vector3 from, Vector3 to, int xRes, int yRes )
		{
			var vb = new VertexBuffer();
			vb.Init( true );

			WaterHeight = Math.Max( from.z, to.z );

			for ( int x = 0; x <= xRes; x++ )
			{
				for ( int y = 0; y <= yRes; y++ )
				{
					float fX = MathX.LerpTo( from.x, to.x, x / (float)xRes );
					float fY = MathX.LerpTo( from.y, to.y, y / (float)yRes );

					Vector3 vPos = new Vector3(
						fX,
						fY,
						WaterHeight
					);

					vPos -= Transform.Position;

					var uv = new Vector2( x / (float)xRes, y / (float)yRes );

					vb.Add( new Vertex( vPos, Vector3.Down, Vector3.Right, uv ) );

				}
			}

			for ( int y = 0; y < yRes; y++ )
			{
				for ( int x = 0; x < xRes; x++ )
				{
					var i = y + (x * yRes) + x;

					vb.AddRawIndex( i + yRes + 1 );
					vb.AddRawIndex( i + 1 );
					vb.AddRawIndex( i );

					vb.AddRawIndex( i + 1 );
					vb.AddRawIndex( i + yRes + 1 );
					vb.AddRawIndex( i + yRes + 2 );

				}
			}
			return vb;
		}


	}
}
