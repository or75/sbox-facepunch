
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sandbox.Internal;
using Sandbox.UI.Tests;

[UseTemplate, NavigatorTarget( "/avatar" )]
public class Avatar : Panel
{
	public ModelViewer ModelViewer { get; set; }
	public VirtualScrollPanel Options { get; set; }
	ModelViewer.Orbit OrbitCamera;

	public Clothing.Container Container = new();

	public List<AnimSceneObject> ClothingModels = new ();

	public string SectionTitle { get; set; }

	public Clothing.ClothingCategory ClothingCategory { get; set; }
	public Panel Categories { get; set; }
	Dictionary<Clothing.ClothingCategory, Button> CategoryButtons { get; set; }

	public Avatar()
	{
		SectionTitle = "No Section Selected";
	}

	protected override void PostTemplateApplied()
	{
		base.PostTemplateApplied();

		OrbitCamera = new ModelViewer.Orbit( Vector3.Up * 48.0f, Vector3.Backward + Vector3.Down * 0.2f, 100.0f );

		ModelViewer.SetModel( "models/citizen/citizen.vmdl" );
		ModelViewer.Camera = OrbitCamera;

		Options.OnCreateCell = CreateItemButton;
		Options.Data.AddRange( Clothing.All );

		CategoryButtons = new();
		AddCategoryButton( "Skin", Clothing.ClothingCategory.Skin );
		AddCategoryButton( "Hair", Clothing.ClothingCategory.Hair );
		AddCategoryButton( "Hat", Clothing.ClothingCategory.Hat );
		AddCategoryButton( "Foot Wear", Clothing.ClothingCategory.Footwear );
		AddCategoryButton( "Bottoms", Clothing.ClothingCategory.Bottoms );
		AddCategoryButton( "Tops", Clothing.ClothingCategory.Tops );

		ChangeCategory( Clothing.ClothingCategory.Skin );

		Load();
	}

	private void AddCategoryButton( string title, Clothing.ClothingCategory skin )
	{
		var b = Categories.Add.Button( title, () => ChangeCategory( skin ) );
		CategoryButtons[skin] = b;
	}

	public void ChangeCategory( Clothing.ClothingCategory category )
	{
		ClothingCategory = category;

		foreach ( var button in CategoryButtons )
		{
			button.Value.SetClass( "active", category == button.Key );
		}

		Options.Clear();
		Options.AddItems( Clothing.All.Where( x => x.Category == ClothingCategory ).ToArray() );
	}

	private void CreateItemButton( Panel cell, object clobj )
	{
		var clothing = (Clothing)clobj;

		var button = cell.Add.Button( clothing.Title );
		button.AddEventListener( "onclick", e => AddClothing( clothing ) );
	}

	private void AddClothing( Clothing clothing )
	{
		Container.Toggle( clothing );

		DressModel();
	}

	void DressModel()
	{
		ModelViewer.Model.SetMaterialGroup( "Skin01" );

		foreach ( var model in ClothingModels )
		{
			ModelViewer.RemoveModel( model );
		}
		ClothingModels.Clear();

		foreach ( var c in Container.Clothing )
		{
			if ( c.Model == "models/citizen/citizen.vmdl" )
			{
				ModelViewer.Model.SetMaterialGroup( c.MaterialGroup );
				continue;
			}

			var model = Model.Load( c.Model );

			var anim = ModelViewer.AddModel( model, ModelViewer.Model.Transform );

			if ( !string.IsNullOrEmpty( c.MaterialGroup ) )
				anim.SetMaterialGroup( c.MaterialGroup );

			ModelViewer.Model.AddChild( "clothing", anim );
			ClothingModels.Add( anim );

			anim.Update( 1.0f );
		}

		foreach( var group in Container.GetBodyGroups() )
		{
			ModelViewer.Model.SetBodyGroup( group.name, group.value );
		}
	}

	public override void Tick()
	{
		base.Tick();

		if ( ModelViewer.Model == null )
			return;

		Angles angles = new( 30, 200, 0 );
		Rotation rot = angles.ToRotation();
		Vector3 pos = Vector3.Up * 40 + angles.Direction * -100;

		OrbitCamera.Distance = 550.0f;
		OrbitCamera.Center = Vector3.Up * 40.0f;
		OrbitCamera.PitchLimit = new Vector2( -2, 85 );
		OrbitCamera.Offset = OrbitCamera.Angles.ToRotation().Left * 25.0f;

		//AvatarScene.World = AvatarWorld;
		ModelViewer.FieldOfView = 20;
		ModelViewer.ZNear = 200;
		ModelViewer.ZFar = 1000;
		ModelViewer.AmbientColor = Color.Gray * 0.2f;
		ModelViewer.ClearColor = Color.Black;

		var eyes = Vector3.Up * 64;

		ModelViewer.Model.SetAnimBool( "b_grounded", true );
		ModelViewer.Model.SetAnimVector( "aim_eyes", pos - eyes );
		ModelViewer.Model.SetAnimVector( "aim_head", pos - eyes );
		ModelViewer.Model.SetAnimVector( "aim_body", pos - eyes );
		ModelViewer.Model.SetAnimFloat( "aim_body_weight", 1.0f );
		ModelViewer.Model.SetAnimFloat( "aim_head_weight", 1.0f );
		ModelViewer.Model.SetAnimInt( "idle_states", 0 );
	}

	[ConVar.Menu( "avatar", Saved = true, ClientData = true )]
	public static string AvatarJson { get; set; }

	public void Load()
	{
		Container.Deserialize( AvatarJson );
		DressModel();
	}

	public void SaveChanges()
	{
		var str = Container.Serialize();
		AvatarJson = str;

		Event.Run( "avatar.changed" );
	}
}

