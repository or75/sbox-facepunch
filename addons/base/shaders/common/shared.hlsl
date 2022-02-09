#ifndef COMMON_SHARED_H
#define COMMON_SHARED_H

#include "system.fxc" // This should always be the first include in COMMON
#include "sbox_shared.fxc"

// Todo: remove these
#define S_SPECULAR 1
#define S_SPECULAR_CUBE_MAP 1
#define VS_INPUT_HAS_TANGENT_BASIS 1
#define PS_INPUT_HAS_TANGENT_BASIS 1


// Helper methods
#define GSMaxVertexCount( arg ) [maxvertexcount(##arg)]
#define CreateSampler( texName ) SamplerState texName##_sampler

// Common attributes
#define AsTransformTexture Attribute("TransformTexture")
#define AsSceneDepth Attribute("SceneDepth")
#define AsFramebuffer Attribute("FrameBufferCopyTexture")
#define AsBlueNoise Attribute("BlueNoise")
#define AsBRDFLookup Attribute("BRDFLookup")
#define AsDynamicAmbientOcclusion Attribute("DynamicAmbientOcclusion")
#define AsDynamicAmbientOcclusionDepth Attribute("DynamicAmbientOcclusionDepth")
#define AsShadowDepthMapAtlas Attribute("ShadowDepthMapAtlas")
#define AsVrShadowDepthBuffer Attribute("VrShadowDepthBuffer")
#define AsPositionKeyFrames Attribute("$PositionKeyFrames")
#define AsRotationKeyFrames Attribute("$RotationKeyFrames")
#define AsSheetTexture Attribute("SheetTexture")

#endif