using Sandbox;
using Sandbox.UI;
using System.Collections.Generic;

public partial class Home
{
	public ScenePanel AvatarScene { get; set; }
	public SceneWorld AvatarWorld { get; set; }

	private AnimSceneObject CitizenModel;
	private readonly List<AnimSceneObject> clothingObjects = new();
	private SpotLight LightWarm;
	private SpotLight LightBlue;

	public Clothing.Container Container = new();

	void RefreshAvatar()
	{
		if ( AvatarWorld != null )
			return;

		clothingObjects.Clear();
		AvatarWorld = new SceneWorld();

		using ( SceneWorld.SetCurrent( AvatarWorld ) )
		{
			var model = Model.Load( "models/citizen/citizen.vmdl" );
			CitizenModel = new AnimSceneObject( model, Transform.Zero );

			DressModel();

			LightWarm = new SpotLight( Vector3.Up * 100.0f + Vector3.Forward * 100.0f + Vector3.Right * -200, new Color( 1.0f, 0.95f, 0.8f ) * 60.0f );
			LightWarm.Rotation = Rotation.LookAt( -LightWarm.Position );
			LightWarm.SpotCone = new SpotLightCone { Inner = 90, Outer = 90 };

			LightBlue = new SpotLight( Vector3.Up * 100.0f + Vector3.Forward * -100.0f + Vector3.Right * 100, new Color( 0.0f, 0.4f, 1f ) * 100.0f );
			LightBlue.Rotation = Rotation.LookAt( -LightBlue.Position );
			LightBlue.SpotCone = new SpotLightCone { Inner = 90, Outer = 90 };

			Angles angles = new( 25, 180, 0 );
			Vector3 pos = Vector3.Up * 40 + angles.Direction * -100;

			AvatarScene.World = AvatarWorld;
			AvatarScene.CameraPosition = pos;
			AvatarScene.CameraRotation = Rotation.From( angles );
			AvatarScene.FieldOfView = 28;
			AvatarScene.AmbientColor = Color.Gray * 0.2f;
		}
	}

	Vector3 lookPos;
	Vector3 headPos;
	Vector3 aimPos;

	void TickAvatar()
	{
		if ( CitizenModel == null )
			return;

		// Get mouse position
		var mousePosition = Mouse.Position;

		// subtract what we think is about the player's eye position
		mousePosition.x -= AvatarScene.Box.Rect.width * 0.5f;
		mousePosition.y -= AvatarScene.Box.Rect.height * 0.25f;
		mousePosition /= AvatarScene.ScaleToScreen;

		// convert it to an imaginary world position
		var worldpos = new Vector3( 200, mousePosition.x, -mousePosition.y );

		// convert that to local space for the model
		lookPos = CitizenModel.Transform.PointToLocal( worldpos );
		headPos = Vector3.Lerp( headPos, CitizenModel.Transform.PointToLocal( worldpos ), Time.Delta * 20.0f );
		aimPos = Vector3.Lerp( aimPos, CitizenModel.Transform.PointToLocal( worldpos ), Time.Delta * 5.0f );

		CitizenModel.SetAnimBool( "b_grounded", true );
		CitizenModel.SetAnimVector( "aim_eyes", lookPos );
		CitizenModel.SetAnimVector( "aim_head", headPos );
		CitizenModel.SetAnimVector( "aim_body", aimPos );
		CitizenModel.SetAnimFloat( "aim_body_weight", 1.0f );

		var quitButton = ( FindRootPanel() as MainMenuPanel ).QuitButton;
		if ( quitButton != null )
		{
			CitizenModel.SetAnimInt( "idle_states", quitButton.HasHovered ? 3 : 0 );
		}

		CitizenModel.Update( RealTime.Delta );

		Angles angles = new( 15, 180, 0 );
		Vector3 pos = Vector3.Up * 45 + angles.Direction * -80;

		AvatarScene.CameraPosition = pos;
		AvatarScene.CameraRotation = Rotation.From( angles );

		foreach ( var clothingObject in clothingObjects )
		{
			clothingObject.Update( RealTime.Delta );
		}
	}

	[Event( "avatar.changed" )]
	void DressModel()
	{
		Container.Deserialize( ConsoleSystem.GetValue( "avatar" ) );

		using ( SceneWorld.SetCurrent( AvatarWorld ) )
		{
			CitizenModel.SetMaterialGroup( "Skin01" );

			foreach ( var model in clothingObjects )
			{
				model?.Delete();
			}
			clothingObjects.Clear();

			foreach ( var c in Container.Clothing )
			{
				if ( c.Model == "models/citizen/citizen.vmdl" )
				{
					CitizenModel.SetMaterialGroup( c.MaterialGroup );
					continue;
				}

				var model = Model.Load( c.Model );

				var anim = new AnimSceneObject( model, CitizenModel.Transform );

				if ( !string.IsNullOrEmpty( c.MaterialGroup ) )
					anim.SetMaterialGroup( c.MaterialGroup );

				CitizenModel.AddChild( "clothing", anim );
				clothingObjects.Add( anim );

				anim.Update( 1.0f );
			}

			foreach ( var group in Container.GetBodyGroups() )
			{
				CitizenModel.SetBodyGroup( group.name, group.value );
			}
		}
	}
}

