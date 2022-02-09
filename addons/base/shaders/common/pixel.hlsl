#ifndef COMMON_PIXEL_H
#define COMMON_PIXEL_H

//Combos -------------------------------------------------------------------------------------------------------------------------------------------------
DynamicCombo( D_BAKED_LIGHTING_FROM_VERTEX_STREAM, 0..1, Sys( ALL ) );
DynamicCombo( D_BAKED_LIGHTING_FROM_PROBE, 0..1, Sys( ALL ) );
DynamicCombo( D_BAKED_LIGHTING_FROM_LIGHTMAP, 0..1, Sys( ALL ) );

StaticCombo( S_BAKED_SELF_ILLUM, F_BAKED_SELF_ILLUM, Sys( ALL ) );
StaticCombo( S_BAKED_EMISSIVE, F_BAKED_EMISSIVE, Sys( ALL ) );

BoolAttribute( SupportsMappingDimensions, true );

//Includes -----------------------------------------------------------------------------------------------------------------------------------------------
#include "common/pixel.config.hlsl"
#include "common/pixel.material.hlsl"

#include "sbox_pixel.fxc"

#if S_HIGH_QUALITY_REFLECTIONS
    #include "common/pixel.raytrace.sdf.hlsl"
#endif

#include "common/pixel.material.helpers.hlsl"


#endif // COMMON_PIXEL_H