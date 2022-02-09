
// Splash constants ------------------------------------------------------------------------------------------------------------------------------------
CreateTexture2D( g_tSplashTex )          	 < Attribute( "SplashTexture" );      SrgbRead( true );   AddressU( CLAMP ); AddressV( CLAMP ); >;
float g_flSplashRadius < Attribute( "SplashRadius" ); Default( 512.0f ); >;
float2 g_vSplashViewPosition < Attribute( "SplashViewPosition" );  >;

// Shared constants ------------------------------------------------------------------------------------------------------------------------------------

float g_fWaterHeight < Attribute( "WaterHeight" ); >;

#define DRAG_MULT 0.048
#define ITERATIONS_NORMAL 30

//-------------------------------------------------------------------------------------------------------------------------------------------------------------

// returns float2 with wave height in X and its derivative in Y
float2 WaveDerivates(float2 position, float2 direction, float speed, float frequency, float timeshift)
{
	direction = normalize(direction);
    float x = dot(direction, position) * frequency + timeshift * speed;
    float wave = exp(sin(x) - 1.0);
    float dx = wave * cos(x);
    return float2(wave, -dx);
}

float2 GetWaterFlow()
{
    //Todo: flowmaps
    return 0.0f;
}

float2 SampleSplash( float2 vPos )
{
    float2 vTexCoordSplash = ( ( vPos - g_vSplashViewPosition ) / g_flSplashRadius ) * 0.5f + 0.5f;
    
    // If PS sample a higher quality, bicubic one, else do a bilinear fetch
    #if ( PROGRAM == VFX_PROGRAM_PS )
        float2 vSplashColor = Tex2DBicubic( PassToArgTexture2D( g_tSplashTex ), vTexCoordSplash, TextureDimensions2D( g_tSplashTex, 0 ) ).rg;
    #else
        float2 vSplashColor = Tex2DLevel( g_tSplashTex, vTexCoordSplash, 0 ).rg;
    #endif

    return 1.0 - vSplashColor;
}



float GetWaves(float2 position, int iterations = ITERATIONS_NORMAL, float flTimeShift = 0.0f )
{
    //
    // Sample the splash water flow
    //
    #if ( D_RIPPLES == 1 )
        float fSplash = ( SampleSplash( position ).x * 20.0f ) - 20.0f;
    #else
        float fSplash = 0.0f;
    #endif

    position *= 0.01;
	position += GetWaterFlow();
	float iter = 0.0;

    float phase = g_fPhase;
    float speed = g_fSpeed;
    float weight = g_fWeight;

    float w = 0.0;
    float ws = 0.0;
    [unroll]
    for( int i=0; i<iterations; i++ ) {
        float2 p = float2(sin(iter), cos(iter));
        float2 res = WaveDerivates(position, p, speed, phase, ( g_flTime + flTimeShift ) % 100);
        position += normalize(p) * res.y * weight * DRAG_MULT;
        w += res.x * weight;
        iter += 12.0;
        ws += weight;
        weight = lerp(weight, 0.0, 0.2);
        phase *= 1.18;
        speed *= 1.07;
    }

    return ( (w / ws) * g_fScale ) + fSplash;
}

float3 WaterNormal(float2 pos, float epsilon, float depth, int iIterations = ITERATIONS_NORMAL, float flTimeShift = 0.0f )
{
    float H = 0;
    float2 ex = float2(epsilon, 0);
    H = GetWaves(pos.xy, iIterations, flTimeShift) * depth;
    float3 a = float3(pos.x, H, pos.y);
    float3 n = normalize(cross(normalize(a-float3(pos.x - epsilon, GetWaves(pos.xy - ex.xy, iIterations, flTimeShift) * depth, pos.y)), 
                           normalize(a-float3(pos.x, GetWaves(pos.xy + ex.yx, iIterations, flTimeShift) * depth, pos.y + epsilon))));

    return float3(n.x,n.z,n.y);
}

// Debug Visualization functions -----------------------------------------------------------------------------------------------------------------------------

float2 DebugSplashUV( float2 vPos )
{
    float2 vTexCoordSplash = ( ( vPos - g_vSplashViewPosition ) / g_flSplashRadius ) * 0.5f + 0.5f;
    float2 vSplashColor = SampleSplash( vPos );
    if( vTexCoordSplash.x > 0 && vTexCoordSplash.x < 1 && vTexCoordSplash.y > 0 && vTexCoordSplash.y < 1 )
        return float4( vSplashColor, 0, 1 );
    else
        return 0;
}