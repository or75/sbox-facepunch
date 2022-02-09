
namespace Sandbox
{
	/// <summary>
	/// A movement path. Compiles each node as its own entity, allowing usage of inputs and outputs such as OnPassed.<br/>
	/// This entity can be used with entities like ent_path_platform.
	/// </summary>
	[Library( "movement_path" )]
	[Hammer.Path( "movement_path_node", true )]
	public partial class MovementPathEntity : GenericPathEntity
	{
	}

	/// <summary>
	/// A movement path node.
	/// </summary>
	[Library( "movement_path_node" )]
	public partial class MovementPathNodeEntity : BasePathNodeEntity
	{
		// TODO: UP Direction

		/// <summary>
		/// When passing this node, the moving entity will have its speed set to this value. 0 or less mean do not change.
		/// </summary>
		[Property]
		public float Speed { get; set; } = 0;

		/// <summary>
		/// Fired when an entity passes this node, depending on the entity implementation.
		/// </summary>
		public Output OnPassed { get; set; }
	}
}
