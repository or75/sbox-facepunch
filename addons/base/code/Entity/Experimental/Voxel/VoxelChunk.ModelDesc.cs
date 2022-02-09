
namespace Sandbox
{
	public partial class VoxelChunk
	{
		private class ModelDesc : BaseNetworkable, INetworkSerializer
		{
			public Vector2 Size;
			public Vector2 Offset;
			public int Width;
			public int Height;
			public float Thickness;
			public bool IsBroken;
			public byte[] Mask;
			public string Material;

			public void Read( ref NetRead read )
			{
				Size = read.Read<Vector2>();
				Offset = read.Read<Vector2>();
				Width = read.Read<int>();
				Height = read.Read<int>();
				Thickness = read.Read<float>();
				IsBroken = read.Read<bool>();
				Material = read.ReadString();

				if ( IsBroken )
				{
					Mask = read.ReadUnmanagedArray( Mask );
				}
			}

			public void Write( NetWrite write )
			{
				write.Write( Size );
				write.Write( Offset );
				write.Write( Width );
				write.Write( Height );
				write.Write( Thickness );
				write.Write( IsBroken );
				write.WriteUtf8( Material );

				if ( IsBroken )
				{
					write.WriteUnmanagedArray( Mask );
				}
			}
		}
	}
}
