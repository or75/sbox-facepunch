// Common Vertex Shader Attributes

#if ( S_DETAIL_TEXTURE )
	float2 vDetailTextureCoords : TEXCOORD13;
#endif

#if ( PROGRAM == VFX_PROGRAM_PS )
	float3 vPositionWithOffsetWs : TEXCOORD0;
#else
	float3 vPositionWs : TEXCOORD0;
#endif
#if ( S_WRINKLE )
	float4 vNormalWs : TEXCOORD1;
#else
	float3 vNormalWs : TEXCOORD1;
#endif

#if ( S_UV2 )
	float4 vTextureCoords : TEXCOORD2;
#else
	float2 vTextureCoords : TEXCOORD2;
#endif

#if ( D_BAKED_LIGHTING_FROM_LIGHTMAP )
	centroid float2 vLightmapUV : TEXCOORD3;
#endif

#if ( PS_INPUT_HAS_PER_VERTEX_LIGHTING )
	float3 vPerVertexLighting : TEXCOORD8;
#endif

float4 vVertexColor : TEXCOORD4;

#if ( S_SPECULAR )
	centroid float3 vCentroidNormalWs : TEXCOORD5;
#endif

#ifdef PS_INPUT_HAS_TANGENT_BASIS
	float3 vTangentUWs : TEXCOORD6; 
	float3 vTangentVWs : TEXCOORD7; 
#endif

#if ( S_USE_PER_VERTEX_CURVATURE )
	float flSSSCurvature : TEXCOORD11;
#endif

#if ( D_MULTIVIEW_INSTANCING )
	nointerpolation uint nView : TEXCOORD12;
#endif

//-------------------------------------------------------------------------------------------------------------------------------------------------------------
// System interpolants
//-------------------------------------------------------------------------------------------------------------------------------------------------------------

#if ( PROGRAM != VFX_PROGRAM_PS ) // VS or GS only
	float4 vPositionPs : SV_Position;
	#if ( D_MULTIVIEW_INSTANCING == 1 )
		float vClip0 : SV_ClipDistance0;
	#elif ( D_MULTIVIEW_INSTANCING == 2 )
		float2 vClip0 : SV_ClipDistance0;
	#endif

	#if ( D_ENABLE_USER_CLIP_PLANE )
		float vClip1 : SV_ClipDistance1;
	#endif

#else // PS only
	float4 vPositionSs : SV_ScreenPosition;
	#if ( S_RENDER_BACKFACES )
		FrontFace_t face : SV_IsFrontFace;
	#endif
#endif

#ifndef COMMON_PS_INPUT_DEFINED
#define COMMON_PS_INPUT_DEFINED
#endif

#ifndef SHARED_STANDARD_PS_INPUT_DEFINED
#define SHARED_STANDARD_PS_INPUT_DEFINED
#endif