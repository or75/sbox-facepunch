// Includes -----------------------------------------------------------------------------------------------------------------------------------------------
#include "system.fxc"
#include "common.fxc"
#include "vr_common.fxc"
#include "vr_lighting.fxc"
#include "math_general.fxc"
#include "instancing.fxc"

#define EPSILON 0.000001

// Combos -------------------------------------------------------------------------------------------------------------------------------------------------
DynamicCombo( D_MULTIVIEW_INSTANCING, 0..1, Sys( PC ) );
DynamicComboRule( Allow0( D_SKINNING ) ); // Don't use skinning at all for UI shaders

// Constants ----------------------------------------------------------------------------------------------------------------------------------------------
float4 g_vViewport < Source( Viewport ); >;
float4x4 g_matTransform < Attribute( "TransformMat" ); >; 
float4x4 LayerMat < Attribute( "LayerMat" ); >; 
float4x4 g_matWorldPanel < Attribute( "WorldMat" ); >; 

BoolAttribute( ui, true );
BoolAttribute( ScreenSpaceVertices, true );

// Main ---------------------------------------------------------------------------------------------------------------------------------------------------
PS_INPUT MainVs( INSTANCED_SHADER_PARAMS( VS_INPUT i ) )
{
	PS_INPUT o;

	//
	// Multiview instancing
	// 
	uint nView = uint( 0 );
	uint nSubview = uint( 0 );
	float4 vViewport = g_vViewport;
	float3 vPositionSs = i.vPositionSs;
	
	#if ( D_MULTIVIEW_INSTANCING )
	{
		GetViewAndSubview( i.nInstanceID, nView, nSubview );
		vViewport.xz *= 0.5;
	}
	#endif
	
	#if !( D_WORLDPANEL )
	{
		vPositionSs.xy = mul( LayerMat, mul( g_matTransform, float4( vPositionSs.xy, 0, 1 ) )).xy;
		o.vPositionPs.xy = 2.0 * ( vPositionSs.xy - vViewport.xy ) / ( vViewport.zw ) - float2( 1.0, 1.0 );
		o.vPositionPs.y *= -1.0;
		o.vPositionPs.z = 1.0;
		o.vPositionPs.w = 1.0 + EPSILON;
		o.vTexCoord.zw = vPositionSs.xy / vViewport.zw;
	}
	#else
	{
		o.vPositionPs = float4( vPositionSs.xyz, 1 );
		o.vPositionPs.y *= -1.0;

		#if ( D_MULTIVIEW_INSTANCING )
			VS_INPUT inputCopy = i;
			// This needs to be done to adjust i.vTransformTextureUV before CalculateInstancingObjectToWorldMatrix() below.
			// This is inefficient but this combo is S_MODE_TOOLS_VIS only so should be a no-op in shipping builds.
			uint nView = uint( 0 );
			uint nSubview = uint( 0 );
			GetViewSubviewAndAdjustInstanceId( inputCopy, nView, nSubview );
			float3x4 matObjectToWorld = CalculateInstancingObjectToWorldMatrix( INSTANCING_PARAMS( inputCopy ) );
		#else
			float3x4 matObjectToWorld = CalculateInstancingObjectToWorldMatrix( INSTANCING_PARAMS( i ) );
		#endif

		matObjectToWorld = mul( matObjectToWorld, g_matWorldPanel );

		float3 vVertexPosWs = mul( matObjectToWorld, float4( o.vPositionPs.xyz, 1.0 ) );
		o.vPositionPs = Position3WsToPsMultiview( nView, vVertexPosWs.xyz );
	}
	#endif
	
	o.vPositionSs = o.vPositionPs;
	o.vPositionPanelSpace = float4( i.vPositionSs.xy, 0, 1 );
	o.vTexCoord.zw = vPositionSs.xy / vViewport.zw;

	o.vColor.rgb = SrgbGammaToLinear( i.vColor.rgb );
	o.vColor.a = i.vColor.a;

	o.vTexCoord.xy = i.vTexCoord.xy;

	//
	// Multiview instancing
	//
	#if ( D_MULTIVIEW_INSTANCING )
	{
		VrMultiviewInstancingSetPositionClipCullOutputs( nView, nSubview, o.vPositionPs, o.vClip0 );
	}
	#endif
	return o;
}