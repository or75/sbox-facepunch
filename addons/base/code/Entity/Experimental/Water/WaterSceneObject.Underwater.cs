using NativeEngine;
using System;
using Sandbox;

namespace Sandbox
{
	public partial class WaterSceneObject : CustomSceneObject
    {
        protected VertexBuffer vbUnderwaterStencil;

        /// <summary>
        /// Makes a vertex buffer cube for fog with the given bounds
		/// </summary>
        public VertexBuffer MakeCube( Vector3 mins, Vector3 maxs )
		{
            var vb = new VertexBuffer();
			vb.Init( true );
            Vector3 center = ( (mins + maxs) / 2 ) - Transform.Position;
            Vector3 size = maxs - mins;

			VertexBufferExtenison.AddCube( vb, center, -size, new Rotation() );

            return vb;
        }
    }
}