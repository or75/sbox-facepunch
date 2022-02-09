#include "system.fxc"
#include "vr_common.fxc" 

DynamicCombo( D_WORLDPANEL, 0..1, Sys( PC ) );

//-------------------------------------------------------------------------------------------------------------------------------------------------------------
struct VS_INPUT
{
	float4 vPositionSs			: POSITION < Semantic( PosXyz ); >;
	float4 vColor				: COLOR0 < Semantic( Color ); >;
	float2 vTexCoord			: TEXCOORD0 < Semantic( LowPrecisionUv ); >;

	// Skinning
	#if ( D_BLEND_WEIGHT_COUNT >= 1 ) || ( D_SKINNING > 0 )
		uint4 vBlendIndices : BLENDINDICES < Semantic( BlendIndices ); >;
	#endif
	#if ( D_BLEND_WEIGHT_COUNT >= 2 ) || ( D_SKINNING > 0 )
		float4 vBlendWeight : BLENDWEIGHT < Semantic( BlendWeight ); >;
	#endif

	float2 vTransformTextureUV				: TEXCOORD13	< Semantic( InstanceTransformUv ); >;
	#if ( D_MULTIVIEW_INSTANCING )
		uint nInstanceID					: SV_InstanceID < Semantic( None ); >;
	#endif
};

//-------------------------------------------------------------------------------------------------------------------------------------------------------------
struct PS_INPUT
{
	float4 vColor				: COLOR0;
	float4 vTexCoord			: TEXCOORD0;
	float4 vPositionSs			: TEXCOORD1;
	float4 vPositionPanelSpace	: TEXCOORD2;
	float4 vPositionPs			: SV_Position;


	#if ( D_MULTIVIEW_INSTANCING )
		float vClip0 : SV_ClipDistance0;
	#endif
};
  