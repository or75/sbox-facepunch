
namespace Sandbox
{
	/// <summary>
	/// A basic node description for the <see cref="BasePathEntity{T}">BasePathEntity</see>.
	/// Please note that <see cref="BasePathNode">BasePathNodes</see> are NOT actual entities, therefore cannot support inputs and outputs. See <see cref="BasePathNodeEntity">BasePathNodeEntity</see>.
	/// </summary>
	[Library( "path_generic_node" )]
	[Hammer.PathNode]
	public partial class BasePathNode
	{
		/// <summary>
		/// Position of the node relative to the path entity.
		/// </summary>
		[Hammer.Skip]
		public Vector3 Position { set; get; } = Vector3.Zero;

		/// <summary>
		/// Position of the incoming tangent relative to the node's position. Includes rotation/scale of the node.
		/// </summary>
		[Hammer.Skip]
		public Vector3 TangentIn { set; get; } = Vector3.Zero;

		/// <summary>
		/// Position of the outgoing tangent relative to the node's position. Includes rotation/scale of the node.
		/// </summary>
		[Hammer.Skip]
		public Vector3 TangentOut { set; get; } = Vector3.Zero;

		/// <summary>
		/// The entity associated with this path node, if they were set to spawn via <see cref="Hammer.PathAttribute">[Hammer.Path]</see>
		/// This will be set as soon as the node entity spawns, which will be after Path entity's Spawn() function.
		/// </summary>
		[Hammer.Skip]
		public Entity Entity { set; get; }

		/// <summary>
		/// Used to set the Entity property. Couldn't find a way to hide it. Do not use.
		/// </summary>
		[Hammer.Skip]
		public string HammerUniqueId { set; get; }
	}

	/// <summary>
	/// A basic node entity for the <see cref="BasePathEntity{T}">BasePathEntity</see>.
	/// These can be used as alternatives to <see cref="BasePathNode">BasePathNode</see> data structures with <see cref="Hammer.PathAttribute">[Hammer.Path]'s</see> 2nd argument.
	/// </summary>
	[Hammer.PathNode]
	public partial class BasePathNodeEntity : Entity
	{
		/// <summary>
		/// Position of the incoming tangent relative to node's own position. Does not include node's rotation/scale.
		/// </summary>
		[Property( "tangent_in" ), Hammer.Skip]
		public Vector3 TangentIn { set; get; }

		/// <summary>
		/// Position of the outgoing tangent relative to node's own position. Does not include node's rotation/scale.
		/// </summary>
		[Property( "tangent_out" ), Hammer.Skip]
		public Vector3 TangentOut { set; get; }

		/// <summary>
		/// The Path entity this node belongs to.
		/// </summary>
		public Entity PathEntity { protected set; get; }

		[Property( "hammerUniqueIdPath" ), Hammer.Skip]
		internal string PathEntityID { set; get; }

		[Property( "hammerUniqueId" ), Hammer.Skip]
		internal string HammerUniqueId { set; get; }

		public override void Spawn()
		{
			base.Spawn();

			// This way we ensure the path entity gets the nodes ASAP
			// Nodes always spawn after the path itself
			PathEntity = BasePathEntity<BasePathNode>.FindPathEntity( PathEntityID );

			foreach ( var node in (PathEntity as BasePathEntity<BasePathNode>).PathNodes )
			{
				if ( node.HammerUniqueId == HammerUniqueId )
				{
					node.Entity = this;
				}
			}
		}
	}
}
