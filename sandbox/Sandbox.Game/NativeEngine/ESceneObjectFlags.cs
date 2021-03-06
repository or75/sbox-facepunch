using System;

namespace NativeEngine
{
	// Token: 0x02000016 RID: 22
	[Flags]
	internal enum ESceneObjectFlags : ulong
	{
		// Token: 0x0400002F RID: 47
		TYPE_MASK = 4095UL,
		// Token: 0x04000030 RID: 48
		IS_OPAQUE = 1UL,
		// Token: 0x04000031 RID: 49
		IS_TRANSLUCENT = 2UL,
		// Token: 0x04000032 RID: 50
		IS_LIGHT = 4UL,
		// Token: 0x04000033 RID: 51
		IS_SUN_LIGHT = 8UL,
		// Token: 0x04000034 RID: 52
		IS_LIGHT_VOLUME = 16UL,
		// Token: 0x04000035 RID: 53
		IS_DECAL = 32UL,
		// Token: 0x04000036 RID: 54
		IS_DYNAMIC_DECAL = 64UL,
		// Token: 0x04000037 RID: 55
		IS_ENV_MAP = 128UL,
		// Token: 0x04000038 RID: 56
		IS_DIRECT_LIGHT = 256UL,
		// Token: 0x04000039 RID: 57
		IS_INDIRECT_LIGHT = 512UL,
		// Token: 0x0400003A RID: 58
		GAME_LAYERS_MASK = 1044480UL,
		// Token: 0x0400003B RID: 59
		VIEWMODEL_LAYER = 4096UL,
		// Token: 0x0400003C RID: 60
		SKYBOX3D_LAYER = 8192UL,
		// Token: 0x0400003D RID: 61
		DISABLED_IN_LOW_QUALITY = 16384UL,
		// Token: 0x0400003E RID: 62
		IS_HAMMER_GEOMETRY = 32768UL,
		// Token: 0x0400003F RID: 63
		EFFECTS_BLOOM_LAYER = 65536UL,
		// Token: 0x04000040 RID: 64
		GAME_OVERLAY_LAYER = 131072UL,
		// Token: 0x04000041 RID: 65
		EXCLUDE_GAME_LAYER = 262144UL,
		// Token: 0x04000042 RID: 66
		TOOL_LAYERS_MASK = 267386880UL,
		// Token: 0x04000043 RID: 67
		TOOLS_UNLIT_LAYER = 1048576UL,
		// Token: 0x04000044 RID: 68
		TOOLSCENE_OVERLAY_LAYER = 2097152UL,
		// Token: 0x04000045 RID: 69
		HAMMER_PREFAB_STENCIL_LAYER = 4194304UL,
		// Token: 0x04000046 RID: 70
		HAMMER_SELECTION_STENCIL_LAYER = 8388608UL,
		// Token: 0x04000047 RID: 71
		HAMMER_ENABLED_STENCIL_LAYER = 16777216UL,
		// Token: 0x04000048 RID: 72
		TOOLS_RENDER_TO_CUBEMAP = 33554432UL,
		// Token: 0x04000049 RID: 73
		RENDER_PROPERTIES_MASK = 35184103653376UL,
		// Token: 0x0400004A RID: 74
		HAS_AO_PROXIES = 268435456UL,
		// Token: 0x0400004B RID: 75
		ALPHA_TEST_ZPREPASS = 536870912UL,
		// Token: 0x0400004C RID: 76
		ADDS_DEPENDENT_VIEW = 1073741824UL,
		// Token: 0x0400004D RID: 77
		NEEDS_DYNAMIC_REFLECTION_MAP = 2147483648UL,
		// Token: 0x0400004E RID: 78
		REFLECTS = 4294967296UL,
		// Token: 0x0400004F RID: 79
		CAST_SHADOWS_ENABLED = 8589934592UL,
		// Token: 0x04000050 RID: 80
		DOES_NOT_ACCEPT_DECALS = 17179869184UL,
		// Token: 0x04000051 RID: 81
		WANTS_FRAMEBUFFER_COPY_TEXTURE = 34359738368UL,
		// Token: 0x04000052 RID: 82
		ISSUES_QUERIES = 68719476736UL,
		// Token: 0x04000053 RID: 83
		STATIC_OBJECT = 137438953472UL,
		// Token: 0x04000054 RID: 84
		ENVIRONMENT_MAPPED = 274877906944UL,
		// Token: 0x04000055 RID: 85
		MATERIAL_SUPPORTS_SHADOWS = 549755813888UL,
		// Token: 0x04000056 RID: 86
		NO_Z_PREPASS = 1099511627776UL,
		// Token: 0x04000057 RID: 87
		FORWARD_LAYER_ONLY = 2199023255552UL,
		// Token: 0x04000058 RID: 88
		NO_OCCLUSION_CULLING = 4398046511104UL,
		// Token: 0x04000059 RID: 89
		NO_PVS_CULLING = 8796093022208UL,
		// Token: 0x0400005A RID: 90
		CAST_SHADOWS = 558345748480UL,
		// Token: 0x0400005B RID: 91
		TRACK_LAST_DRAW_FRAME = 35184372088832UL,
		// Token: 0x0400005C RID: 92
		NEEDS_LIGHT_PROBE = 70368744177664UL,
		// Token: 0x0400005D RID: 93
		CANNOT_BE_REFRACTED = 140737488355328UL,
		// Token: 0x0400005E RID: 94
		PARENTED_TO_HMD = 281474976710656UL,
		// Token: 0x0400005F RID: 95
		GENERIC_PARTICLE_SYSTEM = 2251799813685248UL,
		// Token: 0x04000060 RID: 96
		PIPELINE_SPECIFIC_MASK = 571957152676052992UL,
		// Token: 0x04000061 RID: 97
		PIPELINE_SPECIFIC_0 = 4503599627370496UL,
		// Token: 0x04000062 RID: 98
		PIPELINE_SPECIFIC_1 = 9007199254740992UL,
		// Token: 0x04000063 RID: 99
		PIPELINE_SPECIFIC_2 = 18014398509481984UL,
		// Token: 0x04000064 RID: 100
		PIPELINE_SPECIFIC_3 = 36028797018963968UL,
		// Token: 0x04000065 RID: 101
		VR_NO_WIPE = 4503599627370496UL,
		// Token: 0x04000066 RID: 102
		VR_SUPPORTS_ENV_INTERACTION = 9007199254740992UL,
		// Token: 0x04000067 RID: 103
		VR_HIDEINFIRSTPERSON = 18014398509481984UL,
		// Token: 0x04000068 RID: 104
		VR_DRAW_OVER_DEPTH = 36028797018963968UL,
		// Token: 0x04000069 RID: 105
		DCG_GENERIC_ENTITY = 4503599627370496UL,
		// Token: 0x0400006A RID: 106
		DCG_CARD_IN_HAND = 9007199254740992UL,
		// Token: 0x0400006B RID: 107
		DCG_CARD_ATTACHMENT = 18014398509481984UL,
		// Token: 0x0400006C RID: 108
		CSGO_ALPHA_IMMUNITY = 4503599627370496UL,
		// Token: 0x0400006D RID: 109
		CSGO_PLAYER = 9007199254740992UL,
		// Token: 0x0400006E RID: 110
		SLIMDEFERRED_EXPENSIVE = 4503599627370496UL,
		// Token: 0x0400006F RID: 111
		SLIMDEFERRED_EMISSIVE = 9007199254740992UL,
		// Token: 0x04000070 RID: 112
		INTERNAL_MASK = 17870283321406128128UL,
		// Token: 0x04000071 RID: 113
		NEEDS_DIRTY_UPDATE = 576460752303423488UL,
		// Token: 0x04000072 RID: 114
		IS_DISABLED = 1152921504606846976UL,
		// Token: 0x04000073 RID: 115
		IS_LOADED = 2305843009213693952UL,
		// Token: 0x04000074 RID: 116
		DELETED = 4611686018427387904UL,
		// Token: 0x04000075 RID: 117
		DEBUG_BREAK = 9223372036854775808UL,
		// Token: 0x04000076 RID: 118
		NONE = 0UL,
		// Token: 0x04000077 RID: 119
		ALL = 18446744073709551615UL,
		// Token: 0x04000078 RID: 120
		DRAW_ALL_SCENE_OBJECTS = 18446744073709551615UL
	}
}
