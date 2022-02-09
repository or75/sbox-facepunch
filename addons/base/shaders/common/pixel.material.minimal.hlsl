#ifndef COMMON_PIXEL_MATERIAL_MINIMAL_H
#define COMMON_PIXEL_MATERIAL_MINIMAL_H

//-----------------------------------------------------------------------------
//
//-----------------------------------------------------------------------------
struct Material
{
    float3  Albedo;
    float3  Normal;
    float3  Emission;
    float   Roughness;
    float   Metalness;
    float   AmbientOcclusion;
    float   BlendMask;
    float   TintMask;
    float   Opacity;
};

//-----------------------------------------------------------------------------
//
// Transform texture input to the Material structure
//
//-----------------------------------------------------------------------------
Material ToMaterial( float4 vColor, float4 vNormal, float4 vRMA, float3 vTintColor = float3( 1.0f, 1.0f, 1.0f ), float3 vEmission = float3( 0.0f, 0.0f, 0.0f ) )
{
    Material p;
    p.Albedo = vColor.rgb;
    p.Normal = vNormal.rgb;
    p.Roughness = vRMA.r;
    p.Metalness = vRMA.g;
    p.AmbientOcclusion = vRMA.b;
    p.BlendMask = vRMA.a;
    p.TintMask = ( S_ALPHA_TEST || S_TRANSLUCENT ) ? 0.0f : vColor.a;
    p.Opacity = ( S_ALPHA_TEST || S_TRANSLUCENT ) ? vColor.a : 0.0f;
    p.Emission = vEmission.rgb;
    
    // Do tint
    p.Albedo = lerp( p.Albedo.rgb, p.Albedo.rgb * vTintColor, p.TintMask );
    
    return p;
}

//-----------------------------------------------------------------------------
//
// Lerp function for Material
//
//-----------------------------------------------------------------------------
Material lerp( Material a, Material b, float amount )
{
    Material o;
    o.Albedo =           lerp( a.Albedo, b.Albedo, amount );
    o.Normal =           lerp( a.Normal, b.Normal, amount );
    o.Roughness =        lerp( a.Roughness, b.Roughness, amount );
    o.Metalness =        lerp( a.Metalness, b.Metalness, amount );
    o.AmbientOcclusion = lerp( a.AmbientOcclusion, b.AmbientOcclusion, amount );
    o.BlendMask =        lerp( a.BlendMask, b.BlendMask, amount );
    o.TintMask  =        lerp( a.TintMask, b.TintMask, amount );
    o.Opacity   =        lerp( a.Opacity, b.Opacity, amount );
    o.Emission =         lerp( a.Emission, b.Emission, amount );
    return o;
}

#endif //COMMON_PIXEL_MATERIAL_H