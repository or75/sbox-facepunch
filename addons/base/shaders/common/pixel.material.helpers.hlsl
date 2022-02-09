#ifndef COMMON_PIXEL_MATERIAL_HELPERS_H
#define COMMON_PIXEL_MATERIAL_HELPERS_H


CreateTexture2D( g_tReflectionColor )          < Attribute( "ReflectionTextureColor" );      SrgbRead( true );   AddressU( CLAMP ); AddressV( CLAMP ); >;

//-----------------------------------------------------------------------------
//
// Easily extract the Material structure from the textures set by the user
//
//-----------------------------------------------------------------------------

Material GatherMaterial( const PS_INPUT i )
{
    float2 vUV = i.vTextureCoords.xy;
    Material material = ToMaterial( Tex2DS( g_tColor, TextureFiltering, vUV  ), 
                                    Tex2DS( g_tNormal, TextureFiltering, vUV  ), 
                                    Tex2DS( g_tRma, TextureFiltering, vUV  ), 
                                    g_flTintColor  );

    #if( S_BAKED_EMISSIVE )
        material.Emission = Tex2DS( g_tSelfIllum, TextureFiltering, vUV  ).rgb * g_flEmissionScale;
    #endif

    return material;
}


//-----------------------------------------------------------------------------
//
// Compose the final color with lighting from material parameters
//
//-----------------------------------------------------------------------------

PixelOutput FinalizePixelMaterial( PixelInput i, Material m )
{
    CombinerInput o = MaterialToCombinerInput( i, m );

    #if ( S_HIGH_QUALITY_REFLECTIONS )
        [branch]
        if( g_bAmbientOcclusionProxiesEnabled )
        {
            // Add 1px offset to the bottom edge of the UV to avoid artifacts
            float2 vUVOffset = 1.0 - ( ( 1 / g_vRenderTargetSize ) / g_vAoProxyDownres.x ); // Should be precalculated tbh

            float4 vReflect = Tex2D( g_tReflectionColor, ( i.vPositionSs / g_vRenderTargetSize ) * g_vAoProxyDownres.x * vUVOffset );
            return FinalizePixelReflection( o, vReflect );
        }
    #endif
    
    return FinalizePixel( o );
}

#endif //COMMON_PIXEL_MATERIAL_HELPERS_H