using Sandbox.UI;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandbox
{
	/// <summary>
	/// A common base we can use for weapons so we don't have to implement the logic over and over
	/// again.
	/// </summary>
	[Display( Name = "ViewModel" ), Icon( "pan_tool" )]
	public class BaseViewModel : AnimEntity
	{
		public static List<BaseViewModel> AllViewModels = new List<BaseViewModel>();

		public float FieldOfView { get; set; } = 65.0f;

		public BaseViewModel()
		{
			AllViewModels.Add( this );
		}

		public override void Spawn()
		{
			base.Spawn();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			AllViewModels.Remove( this );
		}

		public override void OnNewModel( Model model )
		{
			base.OnNewModel( model );

			//
			// TODO - read FOV from model data?
			//

		}


		public override void PostCameraSetup( ref CameraSetup camSetup )
		{
			Position = camSetup.Position;
			Rotation = camSetup.Rotation;

			camSetup.ViewModel.FieldOfView = FieldOfView;
		}

		public static void UpdateAllPostCamera( ref CameraSetup camSetup )
		{
			foreach( var vm in AllViewModels )
			{
				vm.PostCameraSetup( ref camSetup );
			}
		}
	}
}
