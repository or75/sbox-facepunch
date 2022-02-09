#ifndef COMMON_PIXEL_CONFIG_H
#define COMMON_PIXEL_CONFIG_H
//--------------

#ifndef S_ALPHA_TEST
    #define S_ALPHA_TEST 0
#endif

#ifndef S_TRANSLUCENT
    #define S_TRANSLUCENT 0
#endif

// Override this if you want to do custom texture filtering
// I will think of a better way to do this
#ifndef CUSTOM_TEXTURE_FILTERING
    SamplerState TextureFiltering < Filter( ANISOTROPIC ); MaxAniso( 8 ); >;
#endif

#endif //COMMON_PIXEL_CONFIG_H