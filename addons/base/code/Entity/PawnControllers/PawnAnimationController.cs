
namespace Sandbox
{
	public abstract class PawnAnimator : PawnController
	{
		public AnimEntity AnimPawn => Pawn as AnimEntity;

		/// <summary>
		/// We'll convert Position to a local position to the players eyes and set
		/// the param on the animgraph.
		/// </summary>
		public virtual void SetLookAt( string name, Vector3 Position )
		{
			var localPos = (Position - Pawn.EyePos) * Rotation.Inverse;
			SetParam( name, localPos );
		}

		/// <summary>
		/// Sets the param on the animgraph
		/// </summary>
		public virtual void SetParam( string name, Vector3 val )
		{
			AnimPawn?.SetAnimVector( name, val );
		}

		/// <summary>
		/// Sets the param on the animgraph
		/// </summary>
		public virtual void SetParam( string name, float val )
		{
			AnimPawn?.SetAnimFloat( name, val );
		}

		/// <summary>
		/// Sets the param on the animgraph
		/// </summary>
		public virtual void SetParam( string name, bool val )
		{
			AnimPawn?.SetAnimBool( name, val );
		}

		/// <summary>
		/// Sets the param on the animgraph
		/// </summary>
		public virtual void SetParam( string name, int val )
		{
			AnimPawn?.SetAnimInt( name, val );
		}

		/// <summary>
		/// Calls SetParam( name, true ). It's expected that your animgraph
		/// has a "name" param with the auto reset property set.
		/// </summary>
		public virtual void Trigger( string name )
		{
			SetParam( name, true );
		}

		/// <summary>
		/// Resets all params to default values on the animgraph
		/// </summary>
		public virtual void ResetParams()
		{
			AnimPawn?.ResetAnimParams();
		}

	}
}
