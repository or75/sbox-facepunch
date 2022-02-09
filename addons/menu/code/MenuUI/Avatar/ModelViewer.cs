
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sandbox.Internal;
using Sandbox.Html;

public class ModelViewer : ScenePanel
{
	public AnimSceneObject Model { get; set; }
	public List<AnimSceneObject> Models = new List<AnimSceneObject>();

	/// <summary>
	/// Scale the model's animation time by this amount
	/// </summary>
	public float TimeScale { get; set; } = 1.0f;


	public CameraMode Camera { get; set; }

	public ModelViewer()
	{
		World = new SceneWorld();
	}

	public override void OnDeleted()
	{
		base.OnDeleted();

		Model?.Delete();
		Model = null;

		World?.Delete();
		World = null;
	}

	public override void Tick()
	{
		base.Tick();

		if ( !IsVisible ) return;

		foreach ( var model in Models )
		{
			model.Update( Time.Delta * TimeScale );
		}

		Camera?.Update( this );
	}

	public override bool OnTemplateElement( INode element )
	{
		using ( SceneWorld.SetCurrent( World ) )
		{
			foreach ( var child in element.Children )
			{
				if ( child.Name.ToLower() == "light" )
				{
					var pos = child.GetAttribute<Vector3>( "position" );
					var radius = child.GetAttribute<float>( "radius", 200.0f );
					var color = child.GetAttribute<Color>( "color", Color.White );
					var light = new Light( pos, radius, color );
					light.Falloff = child.GetAttribute<float>( "falloff", 1.0f );
					//light.br = child.GetAttribute<float>( "brightness", 1.0f );
					//	light.DynamicShadows = child.GetAttribute<bool>( "shadows", false );
				}				
				
				if ( child.Name.ToLower() == "model" )
				{
					var modelName = child.GetAttribute<string>( "src" );
					var pos = child.GetAttribute<Vector3>( "position" );
					var model = new AnimSceneObject( Sandbox.Model.Load( modelName ), new Transform( pos ) );
				}
			}
		}

		return true;
	}

	public AnimSceneObject AddModel( Model model, Transform transform )
	{
		using ( SceneWorld.SetCurrent( World ) )
		{
			var o = new AnimSceneObject( model, transform );
			Models.Add( o );
			return o;
		}
	}	
	
	public void RemoveModel( AnimSceneObject model )
	{
		Models.Remove( model );
		model?.Delete();
	}

	internal void SetModel( string modelName )
	{
		using ( SceneWorld.SetCurrent( World ) )
		{
			if ( Model != null )
			{
				Models.Remove( Model );
				Model.Delete();
				Model = null;
			}

			var model = Sandbox.Model.Load( modelName );
			Model = new AnimSceneObject( model, Transform.Zero );

			Models.Add( Model );
			Model.Update( 0.1f );
		}
	}

	public class CameraMode
	{
		public virtual void Update ( ModelViewer mv )
		{

		}
	}

	public class Orbit : CameraMode
	{
		public Vector3 Center;
		public Vector3 Offset;
		public Angles Angles;
		public float Distance;

		public Vector2 PitchLimit = new Vector2( -90, 90 );
		public Vector2 YawLimit = new Vector2( -360, 360 );

		public Angles HomeAngles;
		public Vector3 SpinVelocity;

		public Orbit( Vector3 center, Vector3 normal, float distance )
		{
			Center = center;
			HomeAngles = Rotation.LookAt( normal.Normal ).Angles();
			Angles = HomeAngles;
			Distance = distance;
		}

		public override void Update( ModelViewer mv )
		{
			if ( mv.HasActive )
			{
				var move = Mouse.Delta;

				SpinVelocity.x = move.y * -1.0f;
				SpinVelocity.y = move.x * 3.0f;

				Angles.pitch += SpinVelocity.x * 0.1f;
				Angles.yaw += SpinVelocity.y * 0.1f;
			}
			else
			{
				SpinVelocity = SpinVelocity.LerpTo( 0, Time.Delta * 2.0f );
				Angles.pitch += SpinVelocity.x * Time.Delta;
				Angles.yaw += SpinVelocity.y * Time.Delta;
			}


			Angles.roll = 0;

			Angles = Angles.Normal;

			Angles.pitch = Angles.pitch.Clamp( PitchLimit.x, PitchLimit.y );
			Angles.yaw = Angles.yaw.Clamp( YawLimit.x, YawLimit.y );


			mv.CameraRotation = Rotation.From( Angles );
			mv.CameraPosition = Center + (mv.CameraRotation.Backward * Distance) + Offset;
		}
	}
}

