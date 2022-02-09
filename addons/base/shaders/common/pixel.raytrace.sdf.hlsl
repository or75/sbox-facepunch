//
// High quality reflections
//

#include "common/pixel.raytrace.intersection.hlsl"

struct ShapeSettings_t
{
    int nInstancesCount;
    int nShapeCount; //Useful only on C++ side really
    int nUnused1;
    int nUnused2;
};

struct ShapeInstance_t
{
    int nStartEllipsoid;
    int nEndEllipsoid;
    int nEndBox;
    int nUnused;
};

struct ShapeBounds_t
{
    float3 vBoundingCenter;
    float fBoundingRadius;
};

struct ShapeProperties_t
{
    float4x3 matWorldToProxy;
    float3 vProxyScale;
    float fUnused;
};

cbuffer ShapeConstantBuffer_t
{
	#define SHAPE_MAX_INSTANCES 35
	#define SHAPE_MAX_SHAPES 110

	// Per-instance
	ShapeSettings_t shapeSettings;
	ShapeInstance_t shapeInstance[SHAPE_MAX_INSTANCES];
    ShapeBounds_t shapeBounds[SHAPE_MAX_INSTANCES];

	// Per-proxy
	ShapeProperties_t shapeProperties[SHAPE_MAX_SHAPES];
};

float sdBox( float3 p, float3 b )
{
    float3 q = abs(p) - b;
    return length(max(q,0.0)) + min(max(q.x,max(q.y,q.z)),0.0);
}

float sdSphere( float3 p, float s )
{
    return length(p)-s;
}

float map( float3 vPosWs, int instance = 0 )
{
    uint nEllipsesStart = shapeInstance[instance].nStartEllipsoid;
    uint nBoxesStart = shapeInstance[instance].nEndEllipsoid;
    uint nEnd = shapeInstance[instance].nEndBox;

    float res = 9999999.0f;

    //Ellipses first
    for ( uint i = nEllipsesStart; i < nBoxesStart; i++ )
    {
        const float fRadius = 1.25f;
        float3 p = mul( float4( vPosWs.xyz, 1.0 ), shapeProperties[i].matWorldToProxy ).xyz;
        res = min( res, sdSphere( p, fRadius ) );
    }
    // Then boxes
    for ( uint i = nBoxesStart; i < nEnd; i++ )
    {
        float3 p = mul( float4( vPosWs.xyz, 1.0 ), shapeProperties[i].matWorldToProxy ).xyz;
        res = min( res, sdBox( p, shapeProperties[i].vProxyScale.xyz ) );
    }

    return res;
}

// Based off http://iquilezles.org/www/articles/rmshadows/rmshadows.htm
float softshadow( in float3 ro, in float3 rd, float mint, float maxt, float roughness, PixelInput input, int instance = 0 )
{
    float res = 1.0;
    float ph = 1e20;

    roughness = pow(roughness, 2.0f);
    float r = 1 / ( max( roughness, 0.001f ) );

    float k = r;

    for( float t=mint; t<maxt; )
    {
        float h = map( ro + rd*t, instance );
        if( h<0.01f )
            return 0.0;
        float y = h*h/(2.0*ph);
        float d = sqrt(h*h-y*y);
        res = min( res, k*d/max(0.0,t-y) );
        h = max( h, 1.0f ); // Minimum travel distance for optimization
        ph = h;
        t += h;
    }
    return res;
}


float TraceSDF( Material m, PixelInput i )
{
    // Fetch header here
    
    float3 vViewRayWs = normalize( i.vPositionWithOffsetWs );
    float3 vPosWs = i.vPositionWithOffsetWs.xyz + g_vCameraPositionWs;

    CombinerInput o = MaterialToCombinerInput( i, m ); // Process normal maps

    float3 vReflectWs = reflect( vViewRayWs, o.vNormalWs );

    float fMaxDistance = max( lerp( 512.0f, 0.01f, m.Roughness * 2.0f ), 0.1f);

    float fReflection = 1.0f;

    for( int iInstance = 0; iInstance < shapeSettings.nInstancesCount; iInstance++ )
    {
        //Do a raytrace check to check for AABB intersection, only do reflection if within bounds
        bool bHit = IntersectSphere( vPosWs, 
                                     vReflectWs, 
                                     shapeBounds[iInstance].vBoundingCenter.xyz, 
                                     shapeBounds[iInstance].fBoundingRadius * 0.5 ).g > 0.0f;
        
        if( m.Roughness < 0.5 && bHit )
            fReflection = min( 
                softshadow( vPosWs , vReflectWs, 1.0f, fMaxDistance, m.Roughness, i, iInstance ), 
                fReflection 
                );

        // Skip the rest of the loop if we are dark enough
        if ( fReflection < 0.05f )
            break;

        // Debug visualization for AABB
        //if( bHit )
        //    fReflection -= 0.1;
    }
    

    return fReflection;
}

//
// For vReflection- RGB: Reflection Color, A: Reflection Mask
//
PixelOutput FinalizePixelReflection( CombinerInput i, float4 vReflection )
{
    LightingTerms_t lightingTerms = InitLightingTerms();

    PixelOutput o;

    const float fLerp = vReflection.a;

    o = PS_FinalCombinerDoLighting( i, lightingTerms );
    float3 vReflectionShadow = ( lightingTerms.vDiffuse.rgb + lightingTerms.vIndirectDiffuse.rgb ) * i.vDiffuseColor.rgb;

    vReflectionShadow += vReflection.rgb; // We add our reflection color here, TODO: multiply with BRDF

    o.vColor.rgb = lerp( o.vColor.rgb, vReflectionShadow, fLerp );

    o = PS_FinalCombinerDoPostProcessing( i, lightingTerms, o );

    return o;
}