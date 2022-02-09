#ifndef PP_FUNCTIONS_H
#define PP_FUNCTIONS_H

#include "postprocess/common.hlsl"

float3 FilmGrain( float3 vColor, float flSampledGrain, float flIntensity, float flResponse )
{
    // Remap grain to a -1 -> 1 range
    flSampledGrain = (flSampledGrain - 0.5f) * 2.0f;

    // Grab our luminence and rescale based on response
    float flLuminence = 1.0f - sqrt( GetLuminance( saturate( vColor.rgb ) ) );
    flLuminence = lerp( 1.0f, flLuminence, flResponse );

    // Intensify the grain in darker areas
    return vColor + vColor * flSampledGrain * flIntensity * flLuminence;
}

float3 Vignette( float3 vColor, float2 vTexCoords, float3 vVignetteColor, float2 vCenter, float flIntensity, float flSmoothness, float flRoundness )
{
    float2 vDistanceFromCenter = abs( vTexCoords - vCenter ) * flIntensity;
    vDistanceFromCenter.x *= flRoundness;

    float flVignette = pow( saturate( 1.0f - dot( vDistanceFromCenter, vDistanceFromCenter ) ), flSmoothness );    

    return vColor * lerp(vVignetteColor, (1.0f).xxx, flVignette);
}

float3 ChromaticAberration( Texture2D tColorBuffer, SamplerState sSampler, float2 vTexCoords, float3 vAmount )
{
    return float3(
        Tex2DS(tColorBuffer, sSampler, vTexCoords - vAmount.xx).r,
        Tex2DS(tColorBuffer, sSampler, vTexCoords - vAmount.yy).g,
        Tex2DS(tColorBuffer, sSampler, vTexCoords - vAmount.zz).b
    );
}

float3 Saturation( float3 vColor, float flSaturationAmount )
{
    float3x3 mSaturationMatrix = float3x3(
        (1.0f - flSaturationAmount) + flSaturationAmount, (1.0f - flSaturationAmount), (1.0f - flSaturationAmount),
        (1.0f - flSaturationAmount), (1.0f - flSaturationAmount) + flSaturationAmount, (1.0f - flSaturationAmount),
        (1.0f - flSaturationAmount), (1.0f - flSaturationAmount), (1.0f - flSaturationAmount) + flSaturationAmount
    );

    return saturate( mul(mSaturationMatrix, vColor) );
}

float2 BarrelDistortion( float2 vTexCoords, float flK1, float flK2 )
{
    vTexCoords = vTexCoords * 2.0 - 1.0;

    float flR2 = dot(vTexCoords, vTexCoords);
    vTexCoords *= 1.0f + flK1 * flR2 + flK2 * flR2 * flR2;

    float flZoom = lerp(1.0f, 0.5f, max(flK1, flK2));

    vTexCoords = 0.5 * (vTexCoords * flZoom + 1.0);

    return vTexCoords;
}

float2 PaniniProjection( float2 vTexCoords, float flDistance )
{
    float flViewDistance = 1.0f + flDistance;
    float flHypotenuse = vTexCoords.x * vTexCoords.x + flViewDistance * flViewDistance;

    float flIntersectionDistance = vTexCoords.x * flDistance;
    float flIntersectionDiscriminator = sqrt( flHypotenuse - flIntersectionDistance * flIntersectionDistance );

    float flCylindricalDistanceNoD = ( -flIntersectionDistance * vTexCoords.x + flViewDistance * flIntersectionDiscriminator ) / flHypotenuse;
    float flCylindricalDistance = flCylindricalDistanceNoD + flDistance;

    float2 vPosition = vTexCoords * (flCylindricalDistance / flViewDistance);
    return vPosition / flCylindricalDistanceNoD;
}

float2 InversePaniniProjection( float2 vTexCoords, float flDistance )
{
    float flViewDistance = 1.0f + flDistance;
    float flProjection = sqrt( vTexCoords.x * vTexCoords.x + 1.0f );
    float flCylindricalDistanceNoD = 1.0f / flProjection;
    float flCylindricalDistance = flCylindricalDistanceNoD + flDistance;

    float2 vPosition = vTexCoords * flCylindricalDistanceNoD;
    return vPosition * (flViewDistance / flCylindricalDistance);
}

float2 ViewExtents( float flFov )
{
    float flAspectRatio = g_vRenderTargetSize.x / g_vRenderTargetSize.y;
    float flExtentsY = tan( flFov * 0.5f );
    return float2( flAspectRatio * flExtentsY, flExtentsY );
}

float2 PaniniViewExtents( float flFov, float flDistance )
{
    float flViewDistance = 1.0f + flDistance;
    float2 vViewExtents = ViewExtents( flFov );
    float flProjection = sqrt( vViewExtents.x * vViewExtents.x + 1.0f );
    float flCylindricalDistanceNoD = 1.0f / flProjection;
    float flCylindricalDistance = flCylindricalDistanceNoD + flDistance;

    float2 vPosition = vViewExtents * flCylindricalDistanceNoD;
    return vPosition * (flViewDistance / flCylindricalDistance);
}

// https://developer.nvidia.com/gpugems/gpugems3/part-iv-image-effects/chapter-27-motion-blur-post-processing-effect
float2 GetVelocityVector( float2 vTexCoords, float flDepth, float flViewModelFarPlane )
{
    // Remap our depth to the viewport
    flDepth = RemapValClamped( flDepth, g_flViewportMinZ, g_flViewportMaxZ, 0.0, 1.0 );
    if( flDepth <= flViewModelFarPlane ) return float2(0,0);
    float2 vClip = ( vTexCoords - 0.5 ) * 2.0 * float2( 1.0, -1.0 );
    
    // Calculate the depth position based on the previous projection
    float4 vPreviousWsPos = mul( m_matPrevProjectionToWorld, float4( vClip.xy, flDepth, 1.0f ) );
    vPreviousWsPos += ( g_vWorldToCameraOffset * vPreviousWsPos.w  );

    // Calculate our change based on our current projection
    float2 vVelocityVector = ( mul( g_matWorldToProjection, vPreviousWsPos ).xy * float2( 0.5, -0.5 ) ) + 0.5f;
    vVelocityVector -= vTexCoords;

    return -vVelocityVector;
}

float3 MotionBlur( Texture2D tColorBuffer, SamplerState sSampler, float2 vTexCoords, float2 vVelocityVector, int sNumSamples )
{
    float3 vColor = Tex2DS(tColorBuffer, sSampler, vTexCoords).rgb;
    vTexCoords += vVelocityVector;
    for(int i = 1; i < sNumSamples; i++, vTexCoords += vVelocityVector)
    {
        vColor += Tex2DS(tColorBuffer, sSampler, vTexCoords).rgb;
    }
    return vColor / (float)sNumSamples;
}

float3 GaussianBlur( Texture2D tColorBuffer, SamplerState sSampler, float2 vTexCoords, float2 flSize )
{
    float fl2PI = 6.28318530718f;
    float flDirections = 16.0f;
    float flQuality = 4.0f;
    float flTaps = 1.0f;

    float3 vColor = Tex2DS(tColorBuffer, sSampler, vTexCoords).rgb;

    [unroll]
    for( float d=0.0; d<fl2PI; d+=fl2PI/flDirections)
    {
        [unroll]
        for(float j=1.0/flQuality; j<=1.0; j+=1.0/flQuality)
        {
            flTaps += 1;
            vColor += Tex2DS( tColorBuffer, sSampler, vTexCoords + float2( cos(d), sin(d) ) * flSize * j ).rgb;    
        }
    }
    return vColor / flTaps;
}

float CircleOfConfusion( float flDepth, float flFocalLength, float flFocalDistance, float flFocalRegion, float flAperture )
{   
    [flatten]
    if( flDepth > flFocalDistance )
    {
        flDepth = flFocalDistance + max( 0.0f, flDepth - flFocalDistance - flFocalRegion );
    }

    // to mm
    flDepth *= 0.0393701f;
    flFocalDistance *= 0.0393701f;

    float flCoC = flAperture * flFocalLength * ( flFocalDistance - flDepth ) / ( flDepth * ( flFocalDistance - flFocalLength ) );
    return saturate( abs( flCoC ) );
}

float3 Sharpen( Texture2D tColorBuffer, SamplerState sSampler, float3 vColor, float2 vTexCoords, float flStrength )
{
    float2 vSize = (1.0f / g_vRenderTargetSize);

    float3 vFinalColor = vColor * (1.0f + (4.0f * flStrength));
    vFinalColor += (Tex2DS(tColorBuffer, sSampler, vTexCoords + float2(vSize.x, 0.0f)).rgb * (-1.0f * flStrength));
    vFinalColor += (Tex2DS(tColorBuffer, sSampler, vTexCoords + float2(-vSize.x, 0.0f)).rgb * (-1.0f * flStrength));
    vFinalColor += (Tex2DS(tColorBuffer, sSampler, vTexCoords + float2(0.0f, vSize.y)).rgb * (-1.0f * flStrength));
    vFinalColor += (Tex2DS(tColorBuffer, sSampler, vTexCoords + float2(0.0f, -vSize.y)).rgb * (-1.0f * flStrength));

    return vFinalColor;
}

#endif