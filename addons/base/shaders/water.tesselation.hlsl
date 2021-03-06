#if ( PROGRAM == VFX_PROGRAM_HS )
	int sMaxTesselation< UiGroup("Tessellation"); UiType(Slider); Default(10); Range(1, 50); >;
	#ifdef DISTANCE_BASED_TESS
		float fTesselationFalloff< UiGroup("Tessellation"); UiType(Slider); Default(1800); Range(1, 2048); >;
	#endif

	PatchSize( 3 );
	HullPatchConstants TessellationFunc(InputPatch<HullInput, 3> patch)
	{
		HullPatchConstants o;

        #if ( NO_TESSELATION == 1 )
            //Don't tesselate if we are underwater, unfortunately I don't think we can choose to just not execute the hull shader
            o.Edge[0] = 1.0f;
            o.Edge[1] = 1.0f;
            o.Edge[2] = 1.0f;
            
            o.Inside = 1.0f;
            return o;
        #endif
	
		#ifdef DISTANCE_BASED_TESS

			float fTessMax = 1.0f;
			float4 vTess = DistanceBasedTess( patch[0].vPositionWs, patch[1].vPositionWs, patch[2].vPositionWs, 1.0, fTesselationFalloff, sMaxTesselation);
			
			o.Edge[0] = vTess.x;
			o.Edge[1] = vTess.y;
			o.Edge[2] = vTess.z;
			
			o.Inside = vTess.w;
		#else
			[unroll] for ( int i = 0; i < 3; i++ )
			{
				o.Edge[i] = (float)sMaxTesselation;
			}
			o.Inside = (float)sMaxTesselation;
		#endif
		return o;
	}

	TessellationDomain( "tri" )
    TessellationOutputControlPoints( 3 )
    TessellationOutputTopology( "triangle_cw" )
    TessellationPartitioning( "fractional_odd" )
    TessellationPatchConstantFunc( "TessellationFunc" )
	HullOutput MainHs( InputPatch<HullInput, 3> patch, uint id : SV_OutputControlPointID )
	{
		HullInput i = patch[id];
		HullOutput o;
		o.vPositionPs = float4(0, 0, 0, 0);

		#if ( S_DETAIL_TEXTURE )
			o.vDetailTextureCoords = i.vDetailTextureCoords;
		#endif

		o.vPositionWs = i.vPositionWs;
		o.vNormalWs = i.vNormalWs;
		o.vTextureCoords = i.vTextureCoords;
		#if ( D_BAKED_LIGHTING_FROM_LIGHTMAP )
			o.vLightmapUV = i.vLightmapUV;
		#endif

		#if ( PixelInput_HAS_PER_VERTEX_LIGHTING )
			o.vPerVertexLighting = i.vPerVertexLighting;
		#endif

		o.vVertexColor = i.vVertexColor;
		#if ( S_SPECULAR )
			o.vCentroidNormalWs = i.vCentroidNormalWs;
		#endif

		#ifdef PixelInput_HAS_TANGENT_BASIS
			o.vTangentUWs = i.vTangentUWs;
			o.vTangentVWs = i.vTangentVWs;
		#endif

		#if ( S_USE_PER_VERTEX_CURVATURE )
			o.flSSSCurvature = i.flSSSCurvature;
		#endif
		
		#if ( D_MULTIVIEW_INSTANCING > 0 )
			o.vClip0 = i.vClip0;
		#endif

		#if ( D_ENABLE_USER_CLIP_PLANE )
			o.vClip1 = i.vClip1;
		#endif

		return o;
	}
#endif //( PROGRAM == VFX_PROGRAM_HS )



#if ( PROGRAM == VFX_PROGRAM_DS )
    TessellationDomain( "tri" )
    PixelInput MainDs(HullPatchConstants i, float3 barycentricCoordinates : SV_DomainLocation, const OutputPatch<DomainInput, 3> patch)
	{
		#define Baycentric3Interpolate(fieldName) o.fieldName = \
					patch[0].fieldName * barycentricCoordinates.x + \
					patch[1].fieldName * barycentricCoordinates.y + \
					patch[2].fieldName * barycentricCoordinates.z;

		PixelInput o;
		o.vPositionPs = float4(0, 0, 0, 0);

		#if ( S_DETAIL_TEXTURE )
			Baycentric3Interpolate(vDetailTextureCoords);
		#endif

		Baycentric3Interpolate(vPositionWs);

        #if ( NO_TESSELATION == 0 )
            o.vPositionWs.z += GetWaves( o.vPositionWs.xy ) * g_fAmplitude;
		#endif

        
        o.vPositionPs = Position3WsToPs( o.vPositionWs );

		Baycentric3Interpolate(vNormalWs);
		Baycentric3Interpolate(vTextureCoords);
		#if ( D_BAKED_LIGHTING_FROM_LIGHTMAP )
			Baycentric3Interpolate(vLightmapUV);
		#endif

		#if ( PixelInput_HAS_PER_VERTEX_LIGHTING )
			Baycentric3Interpolate(vPerVertexLighting);
		#endif

		Baycentric3Interpolate(vVertexColor);
		#if ( S_SPECULAR )
			Baycentric3Interpolate(vCentroidNormalWs);
		#endif

		#ifdef PixelInput_HAS_TANGENT_BASIS
			Baycentric3Interpolate(vTangentUWs);
			Baycentric3Interpolate(vTangentVWs);
		#endif

		#if ( S_USE_PER_VERTEX_CURVATURE )
			Baycentric3Interpolate(flSSSCurvature);
		#endif

		#if ( D_MULTIVIEW_INSTANCING > 0 )
			Baycentric3Interpolate(vClip0);
		#endif

		#if ( D_ENABLE_USER_CLIP_PLANE )
			Baycentric3Interpolate(vClip1);
		#endif

		return o;
	}
#endif //( PROGRAM == VFX_PROGRAM_DS )
