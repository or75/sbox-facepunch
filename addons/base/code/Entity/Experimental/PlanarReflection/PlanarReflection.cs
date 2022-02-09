using NativeEngine;
using System;
using Sandbox;

namespace Sandbox
{
	public class PlanarReflection : SceneMonitorObject
	{
		public PlanarReflection() : base( CreateBoundingMeshModel(), Transform.Zero, true )
		{

		}

		/// <summary>
		///	Updates the reflection information before the render
		/// </summary>
		public void Update( Vector3 reflectionOffset )
		{
			if ( !Parent.IsValid() )
			{
				Log.Warning( "PlanarReflection does not have a Parent" );
				return;
			}

			Vector3 reflectNormal = Parent.Rotation.Up;

			// Clip plane
			Plane p = new Plane( reflectionOffset, reflectNormal );
			SetClipPlane( p );

			// Reflect
			Matrix viewMatrix = Matrix.CreateWorld( CurrentView.Position, CurrentView.Rotation.Forward, CurrentView.Rotation.Up );
			Matrix reflectMatrix = ReflectMatrix( viewMatrix, p );
			
			// Apply Rotation
			Vector3 reflectionPosition = reflectMatrix.Transform( CurrentView.Position );
			Rotation reflectionRotation =  ReflectRotation( CurrentView.Rotation, reflectNormal);
			
			View.Position = reflectionPosition;
			View.Rotation = reflectionRotation;
		}

		/// <summary>
		///	Update on the render thread
		/// </summary>
		public void OnRender()
		{
			UpdateAspectRatio();

		}

		/// <summary>
		///	Updates the aspect ratio of the reflection to match the view
		/// </summary>
		public void UpdateAspectRatio()
		{
			View.Aspect = Render.Viewport.Size.x / Render.Viewport.Size.y;

			// See: PerformS1FovHack
			View.FieldOfView = MathF.Atan( MathF.Tan( CurrentView.FieldOfView.DegreeToRadian() * 0.5f ) * (View.Aspect * 0.75f) ).RadianToDegree() * 2.0f;
		}

		/// <summary>
		/// Creates a bounding mesh model for the water reflection.
		/// This way the water reflection scene will only be rendered when the water is visible in player view
		/// </summary>
		public static Model CreateBoundingMeshModel()
		{

			var material = Material.Load( "debug/debugempty.vmat" );

			var mesh = new Mesh( material );
			mesh.CreateVertexBuffer<SimpleVertex>( 1, SimpleVertex.Layout ); // TEMP
			//mesh.SetBounds( parent.Bounds.Maxs, parent.Bounds.Mins );
			mesh.SetBounds( new Vector3( -10000, -10000, -10000 ), new Vector3( 10000, 10000, 10000 ) ); //TEMP

			var model = Model.Builder
			.AddMesh( mesh )
			.Create();

			return model;
		}

		/// <summary>
		/// Returns true if the renderer is currently rendering the world using a reflection view
		/// </summary>
		public static bool IsRenderingReflection()
		{
			// We shouldn't ship this, can't find any other way to check for this currently, this is called before we can check for "VrMonitor"
			return Render.Viewport.Size.x == Render.Viewport.Size.y;
		}

		
		/// <summary>
		/// Returns a reflected matrix given a plane ( Reflection normal and distance )
		/// </summary>
		public Matrix ReflectMatrix( Matrix m, Plane plane )
		{
			// reflect matrix to be used for reflection model matrix

			m.Numerics.M11 = (1.0f - 2.0f * plane.Normal.x * plane.Normal.x);
			m.Numerics.M21 = (-2.0f * plane.Normal.x * plane.Normal.y);
			m.Numerics.M31 = (-2.0f * plane.Normal.x * plane.Normal.z);
			m.Numerics.M41 = (-2.0f * -plane.Distance * plane.Normal.x);

			m.Numerics.M12 = (-2.0f * plane.Normal.y * plane.Normal.x);
			m.Numerics.M22 = (1.0f - 2.0f * plane.Normal.y * plane.Normal.y);
			m.Numerics.M32 = (-2.0f * plane.Normal.y * plane.Normal.z);
			m.Numerics.M42 = (-2.0f * -plane.Distance * plane.Normal.y);

			m.Numerics.M13 = (-2.0f * plane.Normal.z * plane.Normal.x);
			m.Numerics.M23 = (-2.0f * plane.Normal.z * plane.Normal.y);
			m.Numerics.M33 = (1.0f - 2.0f * plane.Normal.z * plane.Normal.z);
			m.Numerics.M43 = (-2.0f * -plane.Distance * plane.Normal.z);

			m.Numerics.M14 = 0.0f;
			m.Numerics.M24 = 0.0f;
			m.Numerics.M34 = 0.0f;
			m.Numerics.M44 = 1.0f;

			return m;
		}

		/// <summary>
		/// Returns a reflected matrix given a reflection normal
		/// </summary>
		private Rotation ReflectRotation(Rotation source, Vector3 normal)
		{
			return Rotation.LookAt( Vector3.Reflect(source * Vector3.Forward, normal), Vector3.Reflect(source * Vector3.Up, normal));
		}

	};
}
