// Common Vertex Shader Attributes

//-------------------------------------------------------------------------------------------------------------------------------------------------------------
// Geometric
//-------------------------------------------------------------------------------------------------------------------------------------------------------------
float3 vPositionOs : POSITION < Semantic( PosXyz ); >;
float2 vTexCoord : TEXCOORD0 < Semantic( LowPrecisionUv ); >;	
float4 vNormalOs : NORMAL < Semantic( OptionallyCompressedTangentFrame ); >;	

#if ( S_UV2 || S_PRE_BAKED_VERTEX_ANIMATION )
	float2 vTexCoord2 : TEXCOORD1 < Semantic( LowPrecisionUv1 ); >;
#endif

#ifdef VS_INPUT_HAS_TANGENT_BASIS
	#if ( !D_COMPRESSED_NORMALS_AND_TANGENTS )
float4 vTangentUOs_flTangentVSign : TANGENT	< Semantic( TangentU_SignV ); >;
	#endif
#endif

//-------------------------------------------------------------------------------------------------------------------------------------------------------------
// Skinning
//-------------------------------------------------------------------------------------------------------------------------------------------------------------
#if ( D_BLEND_WEIGHT_COUNT >= 1 || D_SKINNING > 0 )
	uint4 vBlendIndices : BLENDINDICES < Semantic( BlendIndices ); >;	
#endif	
#if ( D_BLEND_WEIGHT_COUNT >= 2 || D_SKINNING > 0 )
	float4 vBlendWeight : BLENDWEIGHT < Semantic( BlendWeight ); >;
#endif	
	
//-------------------------------------------------------------------------------------------------------------------------------------------------------------
// SSS Curvature
//-------------------------------------------------------------------------------------------------------------------------------------------------------------
#if ( S_USE_PER_VERTEX_CURVATURE )
	float flSSSCurvature : TEXCOORD2 < Semantic( Curvature ); >;
#endif

//-------------------------------------------------------------------------------------------------------------------------------------------------------------
// Morph
//-------------------------------------------------------------------------------------------------------------------------------------------------------------
#if ( D_MORPH )
	float nVertexIndex : TEXCOORD14 < Semantic( MorphIndex ); >;
#endif

//-------------------------------------------------------------------------------------------------------------------------------------------------------------
// Instancing data
//-------------------------------------------------------------------------------------------------------------------------------------------------------------
#if ( !USE_BINDLESS_RUNTIME )
	float2 vTransformTextureUV : TEXCOORD13 < Semantic( InstanceTransformUv ); >;
#endif

//-------------------------------------------------------------------------------------------------------------------------------------------------------------
// Multi-View instancing (VR)
//-------------------------------------------------------------------------------------------------------------------------------------------------------------

#if ( D_MULTIVIEW_INSTANCING )
	uint nInstanceID : SV_InstanceID < Semantic( None ); >;
#endif

//-------------------------------------------------------------------------------------------------------------------------------------------------------------
// Baked lighting
//-------------------------------------------------------------------------------------------------------------------------------------------------------------
#if ( D_BAKED_LIGHTING_FROM_LIGHTMAP )	
	float2 vLightmapUV : TEXCOORD3 < Semantic( LightmapUV ); > ;
#endif	
	
#if ( D_BAKED_LIGHTING_FROM_VERTEX_STREAM )	 
	float4 vPerVertexLighting : COLOR1 < Semantic( PerVertexLighting ); > ;
#endif

//-------------------------------------------------------------------------------------------------------------------------------------------------------------

#ifndef COMMON_VS_INPUT_DEFINED
#define COMMON_VS_INPUT_DEFINED
#endif

#ifndef SHARED_STANDARD_VS_INPUT_DEFINED
#define SHARED_STANDARD_VS_INPUT_DEFINED
#endif