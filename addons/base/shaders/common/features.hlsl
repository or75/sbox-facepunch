#include "vr_common_features.fxc"

//Feature( F_TEXTURE_FILTERING, 0..4 ( 0="Anisotropic", 1="Bilinear", 2="Trilinear", 3="Point Sample", 4="Nearest Neighbour" ), "Texture Filtering" );
Feature( F_BAKED_SELF_ILLUM, 0..1, "Self Illum" );
Feature( F_BAKED_EMISSIVE, 0..1, "Self Illum" );
FeatureRule( Requires1( F_BAKED_EMISSIVE, F_BAKED_SELF_ILLUM ), "Emissive must be used with baked self illumination" );