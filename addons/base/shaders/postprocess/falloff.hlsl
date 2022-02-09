#ifndef POSTPROCESS_FALLOFF_H
#define POSTPROCESS_FALLOFF_H

DynamicCombo( D_FALLOFF, 0..1, Sys( PC ) );

float flFalloffStart< Attribute("standard.falloff.start"); Default(0.0f); >;
float flFalloffEnd< Attribute("standard.falloff.end"); Default(0.0f); >;
float flFalloffExponent< Attribute("standard.falloff.exponent"); Default(0.0f); >;


float ReconstructWorldDepth( float flProjectedDepth )
{
    flProjectedDepth = RemapValClamped( flProjectedDepth, g_flViewportMinZ, g_flViewportMaxZ, 0.0, 1.0 );
    float flZScale = g_vInvProjRow3.z;
    float flZTran = g_vInvProjRow3.w;   
    float flDepthRelativeToRayLength = 1.0 / ( ( flProjectedDepth * flZScale + flZTran ) ); 
    return flDepthRelativeToRayLength;
}

#if D_FALLOFF == 0
#define MapFalloff(modifier, current, begin, end) (end)
#else

#define MapFalloff(modifier, current, begin, end) (lerp( (begin), (end), min( DistanceFalloff( (current), flFalloffStart, flFalloffEnd, flFalloffExponent ) + (modifier), 1.0f ) ))
#endif

#endif