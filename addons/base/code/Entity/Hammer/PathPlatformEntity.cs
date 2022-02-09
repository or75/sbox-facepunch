using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Sandbox
{
	/// <summary>
	/// A platform that moves between nodes on a predefined path. See path_generic in the Path Tool.
	/// </summary>
	[Library( "ent_path_platform" )]
	[Hammer.SupportsSolid]
	[Hammer.Model]
	[Hammer.RenderFields]
	[Hammer.DrawAngles( "movedir" )]
	[Hammer.VisGroup( Hammer.VisGroup.Dynamic )]
	public partial class PathPlatformEntity : KeyframeEntity
	{
		/// <summary>
		/// The speed to move/rotate with.
		/// </summary>
		[Property]
		protected float Speed { get; set; } = 64.0f;

		/// <summary>
		/// This represents imaginary "distance to wheels" length from the center of the platform in either direction and is used to calculate correct angles when turning.<br/>
		/// Higher values will make turns smoother. This value should not exceed half of the platform's length in the direction of movement.
		/// </summary>
		[Property]
		protected float Length { get; set; } = 32.0f;
		
		/// <summary>
		/// The path_generic entity that defines path nodes for this platform.
		/// </summary>
		[Property( "path_entity" ), FGDType( "target_destination" )]
		public string PathEntity { get; set; }

		/// <summary>
		/// If set, will automatically start moving forwards from first node on spawn.
		/// </summary>
		[Property( "starts_moving", Title = "Starts Moving on Spawn" ), Category( "Automatic Movement" )]
		public bool StartsMoving { get; set; }

		/// <summary>
		/// If set, the entity will automatically rotate to face the direction of movement. Moving backwards will NOT flip the rotation 180 degrees.
		/// </summary>
		[Property( "rotate_along_path" ), Category( "Automatic Rotation" )]
		public bool RotateAlongsidePath { get; set; }

		/// <summary>
		/// Specifies the direction to move in when the platform is used, or axis of rotation for rotating platforms.
		/// </summary>
		[Property( "movedir", Title = "Forward Direction" ), Category( "Automatic Rotation" )]
		public Angles MoveDir { get; set; } = new Angles( 0, 0, 0 );

		public enum OnEndAction
		{
			Stop,
			WarpToStart,
			ReverseDirection
		}

		/// <summary>
		/// What to do when reaching the end of the path when movement was initiated by the "StartMoving" input or "Starts Moving" flag. This also applies when moving backwards.
		/// </summary>
		[Property( "end_action" ), Category( "Automatic Movement" )]
		public OnEndAction EndAction { get; set; } = OnEndAction.Stop;

		/// <summary>
		/// Sound to play when starting to move.
		/// </summary>
		[Property( "start_move_sound" ), Category( "Sounds" ), FGDType( "sound" )]
		public string StartMoveSound { get; set; }

		/// <summary>
		/// Sound to play when we stopped moving.
		/// </summary>
		[Property( "stop_move_sound" ), Category( "Sounds" ), FGDType( "sound" )]
		public string StopMoveSound { get; set; }

		/// <summary>
		/// Sound to play while platform is moving.
		/// </summary>
		[Property( "moving_sound" ), Category( "Sounds" ), FGDType( "sound" )]
		public string MovingSound { get; set; }




		public bool IsMoving { get; protected set; }
		public bool IsMovingForwards { get; protected set; }

		// Internal: Dictates whether we should move to the next node when reaching target node
		bool AutomaticMovement = false;

		public override void Spawn()
		{
			base.Spawn();

			SetupPhysicsFromModel( PhysicsMotionType.Keyframed );

			IsMoving = false;
			IsMovingForwards = true;
		}

		[Event.Entity.PostSpawn]
		void PostMapSpawn()
		{
			// Since we are relying on other named entities to function, we have to wait until all entities have spawned to try to find the one we need.
			if ( StartsMoving && IsServer )
			{
				StartMoving();
			}
		}

		public GenericPathEntity GetPathEntity()
		{
			return (GenericPathEntity)Entity.FindByName( PathEntity );
		}

		List<Vector3> pathPoints = new List<Vector3>();
		void GeneratePoints( BasePathNode start, BasePathNode end, int segments, bool reverse )
		{
			pathPoints.Clear();

			GenericPathEntity pathEnt = GetPathEntity();
			if ( pathEnt == null ) return;

			for ( int i = 0; i <= segments; i++ )
			{
				var lerpPos = pathEnt.GetPointBetweenNodes( start, end, (float)i / segments, reverse );
				pathPoints.Add( pathEnt.Transform.PointToLocal( lerpPos ) );
			}
		}

		/// <summary>
		/// Necessary for constant speed on beizer curve
		/// </summary>
		Vector3 GetPointOnNodePath( float targetDist )
		{
			GenericPathEntity pathEnt = GetPathEntity();
			if ( pathEnt == null || pathPoints.Count < 1 ) return Vector3.Zero;

			float dist = 0;
			Vector3 prevPos = pathPoints[ 0 ];
			foreach ( var point in pathPoints )
			{
				var distLocal = point.Distance( prevPos );
				if ( dist + distLocal >= targetDist )
				{
					var output = prevPos.LerpTo( point, ( targetDist - dist ) / distLocal );
					return pathEnt.Transform.PointToWorld( output );
				}
				dist += distLocal;
				prevPos = point;
			}

			// We failed, return the last point
			var output_l = pathPoints[ pathPoints.Count - 1 ];
			return pathEnt.Transform.PointToWorld( output_l );
		}

		float lengthToGo = 0;
		float lengthGone = 0;
		void GoToNextNode( bool generateOnly = false )
		{
			lengthGone = 0;
			lengthToGo = 0;

			GenericPathEntity pathEnt = GetPathEntity();
			if ( pathEnt == null ) return;

			if ( !generateOnly )
			{
				m_nextNode = m_currentNode + 1;
				if ( m_targetNode < m_currentNode ) m_nextNode = m_currentNode - 1;

				// We can't move any further.
				if ( m_nextNode < 0 || m_nextNode > pathEnt.PathNodes.Count - 1 ) { m_nextNode = -1; Log.Warning( $"{this} Can't move to node {m_nextNode}" ); return; }

				// Generate length to the next node
				lengthToGo = pathEnt.GetCurveLength( pathEnt.PathNodes[ m_currentNode ], pathEnt.PathNodes[ m_nextNode ], 128, m_nextNode < m_currentNode );

				// If the path dictates it, set the target speed to given value
				if ( pathEnt.PathNodes[ m_currentNode ].Entity is MovementPathNodeEntity moveNode && moveNode.Speed > 0 )
				{
					Speed = moveNode.Speed;
				}
			}

			// Generate segments for our current path
			GeneratePoints( pathEnt.PathNodes[ m_currentNode ], pathEnt.PathNodes[ m_nextNode ], 128, m_nextNode < m_currentNode );
		}

		void HandleDirectionChange( bool wantsForward )
		{
			IsMovingForwards = wantsForward;

			// Not moving, nothing to do
			if ( m_nextNode == -1 || lengthToGo <= 0 ) return;

			// No direction change, nothing to do
			bool wasMovingForward = (m_nextNode > m_currentNode);
			if ( wasMovingForward == wantsForward ) return;

			// Flip the next/current direction
			var current = m_currentNode;
			var next = m_nextNode;
			m_currentNode = next;
			m_nextNode = current;

			var gone = lengthGone;
			var length = lengthToGo;

			// Generate the points backwards now
			GoToNextNode( true );

			// Correct the length
			lengthToGo = length;
			lengthGone = length - gone;

			// Changed direction, play the start moving sound
			if ( IsMoving ) PlaySound( StartMoveSound );
		}

		/// <summary>
		/// Fired when the platform starts to move.
		/// </summary>
		protected Output OnMovementStart { get; set; }

		/// <summary>
		/// Fired when the platform stops moving. Sends current point number as parameter.
		/// </summary>
		protected Output<int> OnMovementEnd { get; set; }

		/// <summary>
		/// Fired when the platform is already at given node number, when using inputs to move it. Carries the current node number as parameter.
		/// </summary>
		protected Output<int> OnAlreadyThere { get; set; }

		int movement = 0;
		int m_currentNode = 0;
		int m_nextNode = -1;
		int m_targetNode = -1;
		Sound? MoveSoundInstance = null;
		async Task DoMove()
		{
			// No path - no moving
			GenericPathEntity pathEnt = GetPathEntity();
			if ( pathEnt == null ) return;

			if ( !MoveSoundInstance.HasValue && !string.IsNullOrEmpty( MovingSound ) )
			{
				PlaySound( StartMoveSound );
				MoveSoundInstance = PlaySound( MovingSound );
			}

			if ( !IsMoving )
			{
				_ = OnMovementStart.Fire( this );
			}

			IsMoving = true;
			var moveId = ++movement;

			// If we were not already moving, generate path to next node
			if ( lengthToGo <= 0 || pathPoints.Count <= 0 || m_nextNode == -1 )
			{
				GoToNextNode();
			}

			while ( lengthToGo > 0 )
			{
				await Task.NextPhysicsFrame();

				if ( moveId != movement || !this.IsValid() ) return;

				if ( lengthToGo > 0 )
				{
					lengthGone += Speed * Time.Delta;

					if ( RotateAlongsidePath )
					{
						var nextPos = GetPointOnNodePath( lengthGone + (Length <= 0 ? 32.0f : Length) );
						var lastPos = GetPointOnNodePath( lengthGone - (Length <= 0 ? 32.0f : Length) );

						if ( IsMovingForwards )
						{
							Rotation = Rotation.LookAt( (nextPos - lastPos).Normal, pathEnt.Parent != null ? pathEnt.Parent.Rotation.Up : Vector3.Up ) * Rotation.From( MoveDir ).Inverse;
						}
						else
						{
							Rotation = Rotation.LookAt( (lastPos - nextPos).Normal, pathEnt.Parent != null ? pathEnt.Parent.Rotation.Up : Vector3.Up ) * Rotation.From( MoveDir ).Inverse;
						}
					}

					Position = GetPointOnNodePath( lengthGone );
				}

				// We have reached the next node
				if ( lengthGone >= lengthToGo )
				{
					m_currentNode = m_nextNode;
					m_nextNode = -1;

					//_ = FireOutput( $"OnPassedNode{ m_currentNode + 1 }", this );
					if ( pathEnt.PathNodes[ m_currentNode ].Entity is MovementPathNodeEntity moveNode )
					{
						_ = moveNode.OnPassed.Fire( this );
					}

					if ( m_currentNode == m_targetNode && AutomaticMovement )
					{
						switch ( EndAction )
						{
							case OnEndAction.WarpToStart:
							{
								m_currentNode = IsMovingForwards ? 0 : pathEnt.PathNodes.Count - 1;
								Position = pathEnt.Transform.PointToWorld( pathEnt.PathNodes[ m_currentNode ].Position );

								if ( pathEnt.PathNodes[ m_currentNode ].Entity is MovementPathNodeEntity movementNode )
								{
									_ = movementNode.OnPassed.Fire( this );
								}

								break;
							}

							case OnEndAction.ReverseDirection:
								PlaySound( StartMoveSound );
								ReverseDirection();
								break;
						}
					}

					if ( m_currentNode == m_targetNode )
					{
						IsMoving = false;
						m_targetNode = -1;
						lengthToGo = 0;
						lengthGone = 0;
					}
					else
					{
						GoToNextNode();
					}
				}
			}

			if ( moveId != movement || !this.IsValid() ) return;

			_ = OnMovementEnd.Fire( this, m_currentNode + 1 );

			if ( MoveSoundInstance.HasValue )
			{
				MoveSoundInstance.Value.Stop();
				MoveSoundInstance = null;
			}

			PlaySound( StopMoveSound );
		}

		/// <summary>
		/// Start moving through our nodes in whatever direction we were moving before until we reach either end of the path.
		/// </summary>
		[Input]
		public void StartMoving()
		{
			GenericPathEntity pathEnt = GetPathEntity();
			if ( pathEnt == null ) return;

			m_targetNode = IsMovingForwards ? pathEnt.PathNodes.Count - 1 : 0;
			if ( m_targetNode == m_currentNode && lengthToGo < 1 ) { OnAlreadyThere.Fire( this, m_currentNode + 1 ); return; }

			AutomaticMovement = true;
			_ = DoMove();
		}

		/// <summary>
		/// Start moving forward through our nodes until we reach end of the path.
		/// </summary>
		[Input]
		public void StartForward()
		{
			HandleDirectionChange( true );
			StartMoving();
		}

		/// <summary>
		/// Start moving backwards through our nodes until we reach start of the path.
		/// </summary>
		[Input]
		public void StartBackwards()
		{
			HandleDirectionChange( false );
			StartMoving();
		}

		/// <summary>
		/// Reverse current movement direction, regardless whether we are currently moving or not.
		/// </summary>
		[Input]
		public void ReverseDirection()
		{
			bool wasMoving = IsMoving;

			HandleDirectionChange( !IsMovingForwards );

			if ( wasMoving )
			{
				StartMoving();
			}
		}

		/// <summary>
		/// Stop moving.
		/// </summary>
		[Input]
		public void StopMoving()
		{
			movement++;

			if ( IsMoving )
			{
				if ( MoveSoundInstance.HasValue )
				{
					MoveSoundInstance.Value.Stop();
					MoveSoundInstance = null;
				}

				PlaySound( StopMoveSound );

				_ = OnMovementEnd.Fire( this, m_currentNode + 1 );
			}

			IsMoving = false;
			AutomaticMovement = false;
		}

		/// <summary>
		/// Go to specific node (Starting with 1) set by the parameter and stop there.
		/// </summary>
		[Input]
		public void GoToPoint( int targetNode )
		{
			GenericPathEntity pathEnt = GetPathEntity();
			if ( pathEnt == null ) return;

			m_targetNode = Math.Clamp( targetNode - 1, 0, pathEnt.PathNodes.Count - 1 );
			if ( m_targetNode == m_currentNode && lengthToGo < 1 ) { OnAlreadyThere.Fire( this, m_currentNode + 1 ); return; }

			bool wantsForward = m_currentNode < m_targetNode;
			if ( m_currentNode == m_targetNode && m_nextNode != -1 ) wantsForward = m_nextNode < m_targetNode;
			HandleDirectionChange( wantsForward );

			AutomaticMovement = false;
			_ = DoMove();
		}

		/// <summary>
		/// Go to the next node on the path and stop there.
		/// </summary>
		[Input]
		public void GoToNextPoint()
		{
			GenericPathEntity pathEnt = GetPathEntity();
			if ( pathEnt == null ) return;

			HandleDirectionChange( true );
			m_targetNode = Math.Min( m_currentNode + 1, pathEnt.PathNodes.Count - 1 );

			if ( m_targetNode == m_currentNode && lengthToGo < 1 ) { OnAlreadyThere.Fire( this, m_currentNode + 1 ); return; }

			AutomaticMovement = false;
			_ = DoMove();
		}

		/// <summary>
		/// Go to the previous node on the path and stop there.
		/// </summary>
		[Input]
		public void GoToPrevPoint()
		{
			GenericPathEntity pathEnt = GetPathEntity();
			if ( pathEnt == null ) return;

			HandleDirectionChange( false );
			m_targetNode = Math.Max( m_currentNode - 1, 0 );

			if ( m_targetNode == m_currentNode && lengthToGo < 1 ) { OnAlreadyThere.Fire( this, m_currentNode + 1 ); return; }

			AutomaticMovement = false;
			_ = DoMove();
		}

		/// <summary>
		/// Teleport to a given node (Starting with 1). Does not stop or start movement.
		/// </summary>
		[Input]
		public void WarpToPoint( int targetNode )
		{
			GenericPathEntity pathEnt = GetPathEntity();
			if ( pathEnt == null ) return;

			targetNode = Math.Clamp( targetNode - 1, 0, pathEnt.PathNodes.Count - 1 );
			
			m_currentNode = targetNode;
			m_nextNode = -1;
			lengthToGo = -1;

			Position = pathEnt.Transform.PointToWorld( pathEnt.PathNodes[ targetNode ].Position );

			if ( pathEnt.PathNodes[ m_currentNode ].Entity is MovementPathNodeEntity moveNode )
			{
				_ = moveNode.OnPassed.Fire( this );
			}
			
			if ( IsMoving )
			{
				_ = DoMove();
			}
			else
			{
				if ( m_currentNode >= pathEnt.PathNodes.Count - 1 )
				{
					GeneratePoints( pathEnt.PathNodes[ m_currentNode - 1 ], pathEnt.PathNodes[ m_currentNode ], 128, false );
				}
				else
				{
					GeneratePoints( pathEnt.PathNodes[ m_currentNode ], pathEnt.PathNodes[ m_currentNode + 1 ], 128, false );
				}

				var nextPos = GetPointOnNodePath( lengthGone + (Length <= 0 ? 32.0f : Length) );
				var lastPos = GetPointOnNodePath( lengthGone - (Length <= 0 ? 32.0f : Length) );

				Rotation = Rotation.LookAt( (nextPos - lastPos).Normal, pathEnt.Parent != null ? pathEnt.Parent.Rotation.Up : Vector3.Up ) * Rotation.From( MoveDir ).Inverse;
			}
		}
	}
}
