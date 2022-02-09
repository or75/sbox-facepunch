namespace Sandbox
{

	public abstract class Camera : ICamera
	{
		internal CameraSetup setup;

		public Vector3 Position
		{
			get => setup.Position;
			set => setup.Position = value;
		}

		public Rotation Rotation
		{
			get => setup.Rotation;
			set => setup.Rotation = value;
		}

		[System.Obsolete( "Use Position instead" )]
		public Vector3 Pos { get => Position; set => Position = value; }

		[System.Obsolete( "Use Rotation instead" )]
		public Rotation Rot { get => Rotation; set => Rotation = value; }

		public float FieldOfView
		{
			get => setup.FieldOfView;
			set => setup.FieldOfView = value;
		}

		/// <summary>
		/// If this is set, we won't draw the third person model for this entity
		/// </summary>
		public Entity Viewer
		{
			get => setup.Viewer;
			set => setup.Viewer = value;
		}

		/// <summary>
		/// Length until the Depth of Field focus point
		/// </summary>
		public float DoFPoint { get; set; }

		/// <summary>
		/// How big is the DoF aperture, in pixels
		/// </summary>
		public float DoFBlurSize { get; set; }

		/// <summary>
		/// Viewmodel specific setup
		/// </summary>
		public float ViewModelFieldOfView { get; set; } = 80;

		/// <summary>
		/// The viewmodel near Z clip plane
		/// </summary>
		public float ViewModelZNear
		{
			get => setup.ViewModel.ZNear;
			set => setup.ViewModel.ZNear = value;
		}

		/// <summary>
		/// The viewmodel far Z clip plane
		/// </summary>
		public float ViewModelZFar
		{
			get => setup.ViewModel.ZFar;
			set => setup.ViewModel.ZFar = value;
		}

		/// <summary>
		/// The near Z clip plane
		/// </summary>
		public float ZNear
		{
			get => setup.ZNear;
			set => setup.ZNear = value;
		}

		/// <summary>
		/// The far Z clip plane
		/// </summary>
		public float ZFar
		{
			get => setup.ZFar;
			set => setup.ZFar = value;
		}

		/// <summary>
		/// Use orthographic projection
		/// </summary>
		public bool Ortho
		{
			get => setup.Ortho;
			set => setup.Ortho = value;
		}

		/// <summary>
		/// Acts as a zoom when ortho is enabled
		/// </summary>
		public float OrthoSize
		{
			get => setup.OrthoSize;
			set => setup.OrthoSize = value;
		}

		public abstract void Update();

		public override void Build( ref CameraSetup camSetup )
		{
			// if we do this we'll stomp the embedded camSetup, so don't
			//setup = camSetup;

			// not needed if we do stomp the camSetup though
			var defaultFieldOfView = camSetup.FieldOfView;

			Update();

			camSetup = setup;

			if ( camSetup.FieldOfView == 0 ) camSetup.FieldOfView = defaultFieldOfView;
			camSetup.ViewModel.FieldOfView = camSetup.FieldOfView;

			if ( camSetup.ViewModel.ZNear == 0 ) camSetup.ViewModel.ZNear = 0.1f;
			if ( camSetup.ViewModel.ZFar == 0 ) camSetup.ViewModel.ZFar = 2000f;

			if ( camSetup.ZNear == 0 ) camSetup.ZNear = 10;
			if ( camSetup.ZFar == 0 ) camSetup.ZFar = 80000;

			//if ( camSetup.Aspect == 0 )  camSetup.Aspect = 1;
		}

		/// <summary>
		/// This builds the default behaviour for our input
		/// </summary>
		public override void BuildInput( InputBuilder input )
		{
			//
			// If we're using the mouse then
			// increase pitch sensitivity
			//
			if ( input.UsingController )
			{
				input.AnalogLook.pitch *= 1.5f;
			}

			// add the view move, clamp pitch
			input.ViewAngles += input.AnalogLook;
			input.ViewAngles.pitch = input.ViewAngles.pitch.Clamp( -89, 89 );
			input.ViewAngles.roll = 0;

			// Just copy input as is
			input.InputDirection = input.AnalogMove;
		}

		/// <summary>
		/// Camera has become the active camera. You can use this as an opportunity
		/// to snap the positions if you're lerping etc.
		/// </summary>
		public virtual void Activated()
		{

		}


		/// <summary>
		/// Camera has stopped being the active camera.
		/// </summary>
		public virtual void Deactivated()
		{

		}

	}
}
