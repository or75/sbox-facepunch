using System.Collections.Generic;
using System.Linq;

namespace Sandbox
{
	public partial class Prop
	{
		protected Prop weldParent;
		protected List<Prop> childrenProps = new List<Prop>();
		protected List<PhysicsShape> clonedShapes = new List<PhysicsShape>();

		public void Unweld( bool reweldChildren = false, Prop reweldProp = null )
		{
			if ( !weldParent.IsValid() )
			{
				// Unweld our group, reweld them to the first child or something else
				if ( childrenProps.Count > 0 )
				{
					// Create a copy of the child list so it doesn't get invalidated
					var chilrenPropsCopy = childrenProps.ToList();

					// Unweld all children
					foreach ( var childProp in chilrenPropsCopy )
					{
						childProp.Unweld();
					}

					if ( !reweldChildren )
					{
						return;
					}

					if ( !reweldProp.IsValid() )
					{
						// If no reweld prop has been specified, reweld everything to the first child
						// So that the child becomes the new weld parent
						reweldProp = chilrenPropsCopy.First();
					}

					// For whatever reason, we don't have a prop to reweld to, bail
					if ( !reweldProp.IsValid() )
					{
						return;
					}

					// Reweld all children to the new parent
					foreach ( var childProp in chilrenPropsCopy )
					{
						if ( childProp != reweldProp )
						{
							reweldProp.Weld( childProp );
						}
					}
				}

				return;
			}

			// Remove us from the weld parent
			weldParent.childrenProps.Remove( this );

			// If weld parent has no physics body, it's probably pending destroy
			if ( weldParent.PhysicsBody.IsValid() )
			{
				// Remove all of our cloned shapes from the weld parent
				foreach ( var shape in clonedShapes )
				{
					weldParent.PhysicsBody.RemoveShape( shape );
				}
			}

			clonedShapes.Clear();

			// If there's no physics body, we're probably pending destroy
			if ( PhysicsBody.IsValid() )
			{
				Parent = null;
				PhysicsBody.Parent = null;
				EnableSolidCollisions = true;
				PhysicsBody.RebuildMass();
			}

			weldParent = null;
		}

		public void Weld( Prop prop )
		{
			Host.AssertServer();

			if ( !prop.IsValid() )
			{
				return;
			}

			// Don't weld myself to myself, stupid
			if ( prop == this )
			{
				return;
			}

			// Don't weld myself twice, stupid
			if ( prop.weldParent == this || weldParent == prop )
			{
				return;
			}

			// Only allow welding of two root props
			if ( Parent != null || prop.Parent != null )
			{
				return;
			}

			// Only allow welding of props that have physics bodies
			if ( !PhysicsBody.IsValid() || !prop.PhysicsBody.IsValid() )
			{
				return;
			}

			// Only allow welding of props that have a single body
			if ( PhysicsGroup.BodyCount > 1 || prop.PhysicsGroup.BodyCount > 1 )
			{
				return;
			}

			if ( prop.childrenProps.Count > 0 )
			{
				// Reweld everything to this
				prop.Unweld( true, this );
			}

			var thisBody = PhysicsBody;
			var otherBody = prop.PhysicsBody;

			// We want traces to now think the other body is now this body
			otherBody.Parent = thisBody;

			// Disable solid collisions on other prop so things attached with constraints wont collide with it
			prop.EnableSolidCollisions = false;

			// Merge all other shapes from other body into this body
			for ( int shapeIndex = 0; shapeIndex < otherBody.ShapeCount; ++shapeIndex )
			{
				var clonedShape = thisBody.AddCloneShape( otherBody.GetShape( shapeIndex ) );

				// We don't want to be able to trace this cloned shape (but we want it to generate contacts)
				clonedShape.DisableTraceQuery();

				// Keep track of the cloned shape so they can be removed when unwelded
				prop.clonedShapes.Add( clonedShape );
			}

			// Visually parent other prop to this prop
			prop.Parent = this;
			prop.weldParent = this;

			// Keep track of welded children
			childrenProps.Add( prop );

			thisBody.RebuildMass();
		}
	}
}
