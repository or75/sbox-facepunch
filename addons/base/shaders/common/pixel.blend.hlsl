#ifndef COMMON_PIXEL_BLEND_H
#define COMMON_PIXEL_BLEND_H

#include "common/pixel.hlsl"
#include "texture_blending.fxc"

Material MaterialParametersMultiblend( Material a, Material b, float fBlendValue, float fSoftness = 0.5 )
{
    Material o;
    float fBlendfactor = ComputeBlendWeight( fBlendValue, fSoftness, b.BlendMask );
    o = lerp( a, b, fBlendfactor ); 
    return o;
}

#if S_MULTIBLEND >= 0
    //
    // Material A
    //
    CreateInputTexture2D( TextureColorA,            Srgb,   8, "",                 "_color",  "Material A,10/10", Default3( 1.0, 1.0, 1.0 ) );
    CreateInputTexture2D( TextureNormalA,           Linear, 8, "NormalizeNormals", "_normal", "Material A,10/20", Default3( 0.5, 0.5, 1.0 ) );
    CreateInputTexture2D( TextureRoughnessA,        Linear, 8, "",                 "_rough",  "Material A,10/30", Default( 0.5 ) );
    CreateInputTexture2D( TextureMetalnessA,        Linear, 8, "",                 "_metal",  "Material A,10/40", Default( 1.0 ) );
    CreateInputTexture2D( TextureAmbientOcclusionA, Linear, 8, "",                 "_ao",     "Material A,10/50", Default( 1.0 ) );
    CreateInputTexture2D( TextureBlendMaskA,        Linear, 8, "",                 "_blend",  "Material A,10/60", Default( 1.0 ) );
    CreateInputTexture2D( TextureTintMaskA,         Linear, 8, "",                 "_tint",   "Material A,10/70", Default( 1.0 ) );
    float3 g_flTintColorA < UiType( Color ); Default3( 1.0, 1.0, 1.0 ); UiGroup( "Material A,10/80" ); >;
    float g_flBlendSoftnessA < Default( 0.5 ); Range( 0.1, 1.0 ); UiGroup( "Material A,90" ); >;

    CreateTexture2DWithoutSampler( g_tColorA )  < Channel( RGB,  Box( TextureColorA ), Srgb ); Channel( A, Box( TextureTintMaskA ), Linear ); OutputFormat( BC7 ); SrgbRead( true ); >;
    CreateTexture2DWithoutSampler( g_tNormalA ) < Channel( RGBA, Box( TextureNormalA ), Linear ); OutputFormat( BC7 ); SrgbRead( false ); >;
    CreateTexture2DWithoutSampler( g_tRmaA )    < Channel( R,    Box( TextureRoughnessA ), Linear ); Channel( G, Box( TextureMetalnessA ), Linear ); Channel( B, Box( TextureAmbientOcclusionA ), Linear );  Channel( A, Box( TextureBlendMaskA ), Linear ); OutputFormat( BC7 ); SrgbRead( false ); >;

#if S_MULTIBLEND >= 1
    //
    // Material B
    //
    CreateInputTexture2D( TextureColorB,            Srgb,   8, "",                 "_color",  "Material B,10/10", Default3( 1.0, 1.0, 1.0 ) );
    CreateInputTexture2D( TextureNormalB,           Linear, 8, "NormalizeNormals", "_normal", "Material B,10/20", Default3( 0.5, 0.5, 1.0 ) );
    CreateInputTexture2D( TextureRoughnessB,        Linear, 8, "",                 "_rough",  "Material B,10/30", Default( 0.5 ) );
    CreateInputTexture2D( TextureMetalnessB,        Linear, 8, "",                 "_metal",  "Material B,10/40", Default( 1.0 ) );
    CreateInputTexture2D( TextureAmbientOcclusionB, Linear, 8, "",                 "_ao",     "Material B,10/50", Default( 1.0 ) );
    CreateInputTexture2D( TextureBlendMaskB,        Linear, 8, "",                 "_blend",  "Material B,10/60", Default( 1.0 ) );
    CreateInputTexture2D( TextureTintMaskB,         Linear, 8, "",                 "_tint",   "Material B,10/70", Default( 1.0 ) );
    float3 g_flTintColorB < UiType( Color ); Default3( 1.0, 1.0, 1.0 ); UiGroup( "Material B,10/80" ); >;
    float g_flBlendSoftnessB < Default( 0.5 ); Range( 0.1, 1.0 ); UiGroup( "Material B,90" ); >;
    float2 g_vTexCoordScale2 < Default2( 1.0, 1.0 ); Range2( 0.0, 0.0, 100.0, 100.0 ); UiGroup( "Material B,100" ); >;

    CreateTexture2DWithoutSampler( g_tColorB )  < Channel( RGB,  Box( TextureColorB ), Srgb ); Channel( A, Box( TextureTintMaskB ), Linear ); OutputFormat( BC7 ); SrgbRead( true ); >;
    CreateTexture2DWithoutSampler( g_tNormalB ) < Channel( RGBA, Box( TextureNormalB ), Linear ); OutputFormat( BC7 ); SrgbRead( false ); >;
    CreateTexture2DWithoutSampler( g_tRmaB )    < Channel( R,    Box( TextureRoughnessB ), Linear ); Channel( G, Box( TextureMetalnessB ), Linear ); Channel( B, Box( TextureAmbientOcclusionB ), Linear );  Channel( A, Box( TextureBlendMaskB ), Linear ); OutputFormat( BC7 ); SrgbRead( false ); >;

#if S_MULTIBLEND >= 2
    //
    // Material C
    //
    CreateInputTexture2D( TextureColorC,            Srgb,   8, "",                 "_color",  "Material C,10/10", Default3( 1.0, 1.0, 1.0 ) );
    CreateInputTexture2D( TextureNormalC,           Linear, 8, "NormalizeNormals", "_normal", "Material C,10/20", Default3( 0.5, 0.5, 1.0 ) );
    CreateInputTexture2D( TextureRoughnessC,        Linear, 8, "",                 "_rough",  "Material C,10/30", Default( 0.5 ) );
    CreateInputTexture2D( TextureMetalnessC,        Linear, 8, "",                 "_metal",  "Material C,10/40", Default( 1.0 ) );
    CreateInputTexture2D( TextureAmbientOcclusionC, Linear, 8, "",                 "_ao",     "Material C,10/50", Default( 1.0 ) );
    CreateInputTexture2D( TextureBlendMaskC,        Linear, 8, "",                 "_blend",  "Material C,10/60", Default( 1.0 ) );
    CreateInputTexture2D( TextureTintMaskC,         Linear, 8, "",                 "_tint",   "Material C,10/70", Default( 1.0 ) );
    float3 g_flTintColorC < UiType( Color ); Default3( 1.0, 1.0, 1.0 ); UiGroup( "Material C,10/80" ); >;
    float g_flBlendSoftnessC < Default( 0.5 ); Range( 0.1, 1.0 ); UiGroup( "Material C,90" ); >;
    float2 g_vTexCoordScale3 < Default2( 1.0, 1.0 ); Range2( 0.0, 0.0, 100.0, 100.0 ); UiGroup( "Material C,100" ); >;

    CreateTexture2DWithoutSampler( g_tColorC )  < Channel( RGB,  Box( TextureColorC ), Srgb ); Channel( A, Box( TextureTintMaskC ), Linear ); OutputFormat( BC7 ); SrgbRead( true ); >;
    CreateTexture2DWithoutSampler( g_tNormalC ) < Channel( RGBA, Box( TextureNormalC ), Linear ); OutputFormat( BC7 ); SrgbRead( false ); >;
    CreateTexture2DWithoutSampler( g_tRmaC )    < Channel( R,    Box( TextureRoughnessC ), Linear ); Channel( G, Box( TextureMetalnessC ), Linear ); Channel( B, Box( TextureAmbientOcclusionC ), Linear );  Channel( A, Box( TextureBlendMaskC ), Linear ); OutputFormat( BC7 ); SrgbRead( false ); >;


#if S_MULTIBLEND >= 3
    //
    // Material D
    //
    CreateInputTexture2D( TextureColorD,            Srgb,   8, "",                 "_color",  "Material D,10/10", Default3( 1.0, 1.0, 1.0 ) );
    CreateInputTexture2D( TextureNormalD,           Linear, 8, "NormalizeNormals", "_normal", "Material D,10/20", Default3( 0.5, 0.5, 1.0 ) );
    CreateInputTexture2D( TextureRoughnessD,        Linear, 8, "",                 "_rough",  "Material D,10/30", Default( 0.5 ) );
    CreateInputTexture2D( TextureMetalnessD,        Linear, 8, "",                 "_metal",  "Material D,10/40", Default( 1.0 ) );
    CreateInputTexture2D( TextureAmbientOcclusionD, Linear, 8, "",                 "_ao",     "Material D,10/50", Default( 1.0 ) );
    CreateInputTexture2D( TextureBlendMaskD,        Linear, 8, "",                 "_blend",  "Material D,10/60", Default( 1.0 ) );
    CreateInputTexture2D( TextureTintMaskD,         Linear, 8, "",                 "_tint",   "Material D,10/70", Default( 1.0 ) );
    float3 g_flTintColorD < UiType( Color ); Default3( 1.0, 1.0, 1.0 ); UiGroup( "Material D,10/80" ); >;
    float g_flBlendSoftnessD < Default( 0.5 ); Range( 0.1, 1.0 ); UiGroup( "Material D,90" ); >;
    float2 g_vTexCoordScale4 < Default2( 1.0, 1.0 ); Range2( 0.0, 0.0, 100.0, 100.0 ); UiGroup( "Material D,100" ); >;

    CreateTexture2DWithoutSampler( g_tColorD )  < Channel( RGB,  Box( TextureColorD ), Srgb ); Channel( A, Box( TextureTintMaskD ), Linear ); OutputFormat( BC7 ); SrgbRead( true ); >;
    CreateTexture2DWithoutSampler( g_tNormalD ) < Channel( RGBA, Box( TextureNormalD ), Linear ); OutputFormat( BC7 ); SrgbRead( false ); >;
    CreateTexture2DWithoutSampler( g_tRmaD )    < Channel( R,    Box( TextureRoughnessD ), Linear ); Channel( G, Box( TextureMetalnessD ), Linear ); Channel( B, Box( TextureAmbientOcclusionD ), Linear );  Channel( A, Box( TextureBlendMaskD ), Linear ); OutputFormat( BC7 ); SrgbRead( false ); >;
#if S_MULTIBLEND >= 4
    //
    // Material E
    //
    CreateInputTexture2D( TextureColorE,            Srgb,   8, "",                 "_color",  "Material E,10/10", Default3( 1.0, 1.0, 1.0 ) );
    CreateInputTexture2D( TextureNormalE,           Linear, 8, "NormalizeNormals", "_normal", "Material E,10/20", Default3( 0.5, 0.5, 1.0 ) );
    CreateInputTexture2D( TextureRoughnessE,        Linear, 8, "",                 "_rough",  "Material E,10/30", Default( 0.5 ) );
    CreateInputTexture2D( TextureMetalnessE,        Linear, 8, "",                 "_metal",  "Material E,10/40", Default( 1.0 ) );
    CreateInputTexture2D( TextureAmbientOcclusionE, Linear, 8, "",                 "_ao",     "Material E,10/50", Default( 1.0 ) );
    CreateInputTexture2D( TextureBlendMaskE,        Linear, 8, "",                 "_blend",  "Material E,10/60", Default( 1.0 ) );
    CreateInputTexture2D( TextureTintMaskE,         Linear, 8, "",                 "_tint",   "Material E,10/70", Default( 1.0 ) );
    float3 g_flTintColorE < UiType( Color ); Default3( 1.0, 1.0, 1.0 ); UiGroup( "Material E,10/80" ); >;
    float g_flBlendSoftnessE < Default( 0.5 ); Range( 0.1, 1.0 ); UiGroup( "Material E,90" ); >;
    float2 g_vTexCoordScale5 < Default2( 1.0, 1.0 ); Range2( 0.0, 0.0, 100.0, 100.0 ); UiGroup( "Material E,100" ); >;

    CreateTexture2DWithoutSampler( g_tColorE )  < Channel( RGB,  Box( TextureColorE ), Srgb ); Channel( A, Box( TextureTintMaskE ), Linear ); OutputFormat( BC7 ); SrgbRead( true ); >;
    CreateTexture2DWithoutSampler( g_tNormalE ) < Channel( RGBA, Box( TextureNormalE ), Linear ); OutputFormat( BC7 ); SrgbRead( false ); >;
    CreateTexture2DWithoutSampler( g_tRmaE )    < Channel( R,    Box( TextureRoughnessE ), Linear ); Channel( G, Box( TextureMetalnessE ), Linear ); Channel( B, Box( TextureAmbientOcclusionE ), Linear );  Channel( A, Box( TextureBlendMaskE ), Linear ); OutputFormat( BC7 ); SrgbRead( false ); >;

#endif // 4
#endif // 3
#endif // 2
#endif // 1
#endif // 0


//-----------------------------------------------------------------------------
//
// ToMaterial but for multiple material channels
//
//-----------------------------------------------------------------------------
Material ToMaterialMultiblend( float2 vUV, PixelInput i )
{
    #if S_MULTIBLEND >= 0
        Material material = ToMaterial(  
                Tex2DS( g_tColorA, TextureFiltering, vUV ), 
                Tex2DS( g_tNormalA, TextureFiltering, vUV ), 
                Tex2DS( g_tRmaA, TextureFiltering, vUV ), 
                g_flTintColorA
            );
    #if S_MULTIBLEND >= 1
        Material materialB = ToMaterial( 
            Tex2DS( g_tColorB, TextureFiltering, vUV * g_vTexCoordScale2.xy ), 
            Tex2DS( g_tNormalB, TextureFiltering, vUV * g_vTexCoordScale2.xy ), 
            Tex2DS( g_tRmaB, TextureFiltering, vUV * g_vTexCoordScale2.xy ), 
            g_flTintColorB
        );
        material = MaterialParametersMultiblend( material, materialB, i.vBlendValues.r, g_flBlendSoftnessB );
    #if S_MULTIBLEND >= 2
        Material materialC = ToMaterial( 
            Tex2DS( g_tColorC, TextureFiltering, vUV * g_vTexCoordScale3.xy ), 
            Tex2DS( g_tNormalC, TextureFiltering, vUV * g_vTexCoordScale3.xy ), 
            Tex2DS( g_tRmaC, TextureFiltering, vUV * g_vTexCoordScale3.xy ), 
            g_flTintColorC
        );
        material = MaterialParametersMultiblend( material, materialC, i.vBlendValues.g, g_flBlendSoftnessC );
    #if S_MULTIBLEND >= 3
        Material materialD = ToMaterial( 
            Tex2DS( g_tColorD, TextureFiltering, vUV * g_vTexCoordScale4.xy ), 
            Tex2DS( g_tNormalD, TextureFiltering, vUV * g_vTexCoordScale4.xy ), 
            Tex2DS( g_tRmaD, TextureFiltering, vUV * g_vTexCoordScale4.xy ), 
            g_flTintColorD
        );
        material = MaterialParametersMultiblend( material, materialD, i.vBlendValues.b, g_flBlendSoftnessD );
    #if S_MULTIBLEND >= 4
        Material materialE = ToMaterial( 
            Tex2DS( g_tColorE, TextureFiltering, vUV * g_vTexCoordScale5.xy ), 
            Tex2DS( g_tNormalE, TextureFiltering, vUV * g_vTexCoordScale5.xy ), 
            Tex2DS( g_tRmaE, TextureFiltering, vUV * g_vTexCoordScale5.xy ), 
            g_flTintColorE
        );
        material = MaterialParametersMultiblend( material, materialE, i.vBlendValues.a, g_flBlendSoftnessE );
    #endif // 4
    #endif // 3
    #endif // 2
    #endif // 1
    #endif // 0

    return material;
}

#if S_MULTIBLEND
    TextureAttribute( LightSim_DiffuseAlbedoTexture, g_tColorA );
    TextureAttribute( RepresentativeTexture, g_tColorA );
#endif

#endif //COMMON_PIXEL_BLEND_H