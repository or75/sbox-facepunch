DynamicCombo( D_SCISSOR, 0..1, Sys( PC ) );
float4 ScissorRect < Default4( 0.0, 0.0, 0.0, 0.0 ); Attribute( "ScissorRect" ); >;

float2 GetPixelPosition( float2 screenPos )
{
    float2 screenPosNormalized = ( float2(screenPos + 1.0 ) * 0.5 );
    return ( float2( screenPosNormalized.x, 1.0 - screenPosNormalized.y ) ) * g_vViewportSize;
}

float2 GetWorldPixelPosition( PS_INPUT i )
{
    float2 vPos = ( BoxSize ) * ( i.vTexCoord.xy );
    vPos += BoxPosition;

    return vPos;
}

bool SoftwareScissoring( PS_INPUT i )
{
    #if D_WORLDPANEL
        // Todo
        float4 vScissor = ScissorRect;
        float2 pixelPos = GetWorldPixelPosition( i );
    #else
        //Todo: Rotation support
        float4 vScissor = ScissorRect;
        float2 pixelPos = i.vPositionPanelSpace.xy;
    #endif

    bool bShouldClip = pixelPos.x < vScissor.x || pixelPos.x > vScissor.z || pixelPos.y > vScissor.w || pixelPos.y < vScissor.y;

    // TODO - support corners rounding!

    clip( bShouldClip ? -1 : 1 );

    return bShouldClip;
}