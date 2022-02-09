using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000025 RID: 37
	internal struct CBaseAnimating
	{
		// Token: 0x060003B9 RID: 953 RVA: 0x0002865E File Offset: 0x0002685E
		public static implicit operator IntPtr(CBaseAnimating value)
		{
			return value.self;
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00028668 File Offset: 0x00026868
		public static implicit operator CBaseAnimating(IntPtr value)
		{
			return new CBaseAnimating
			{
				self = value
			};
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00028686 File Offset: 0x00026886
		public static bool operator ==(CBaseAnimating c1, CBaseAnimating c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00028699 File Offset: 0x00026899
		public static bool operator !=(CBaseAnimating c1, CBaseAnimating c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x060003BD RID: 957 RVA: 0x000286AC File Offset: 0x000268AC
		public override bool Equals(object obj)
		{
			if (obj is CBaseAnimating)
			{
				CBaseAnimating c = (CBaseAnimating)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x060003BE RID: 958 RVA: 0x000286D6 File Offset: 0x000268D6
		internal CBaseAnimating(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x060003BF RID: 959 RVA: 0x000286E0 File Offset: 0x000268E0
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CBaseAnimating ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x0002871C File Offset: 0x0002691C
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x0002872E File Offset: 0x0002692E
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00028739 File Offset: 0x00026939
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x0002874C File Offset: 0x0002694C
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CBaseAnimating was null when calling " + n);
			}
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00028767 File Offset: 0x00026967
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00028774 File Offset: 0x00026974
		public static implicit operator CBaseModelEntity(CBaseAnimating value)
		{
			method to_CBaseModelEntity_From_CBaseAnimating = CBaseAnimating.__N.To_CBaseModelEntity_From_CBaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, to_CBaseModelEntity_From_CBaseAnimating);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00028798 File Offset: 0x00026998
		public static explicit operator CBaseAnimating(CBaseModelEntity value)
		{
			method from_CBaseModelEntity_To_CBaseAnimating = CBaseAnimating.__N.From_CBaseModelEntity_To_CBaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, from_CBaseModelEntity_To_CBaseAnimating);
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x000287BC File Offset: 0x000269BC
		public static implicit operator CBaseEntity(CBaseAnimating value)
		{
			method to_CBaseEntity_From_CBaseAnimating = CBaseAnimating.__N.To_CBaseEntity_From_CBaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, to_CBaseEntity_From_CBaseAnimating);
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x000287E0 File Offset: 0x000269E0
		public static explicit operator CBaseAnimating(CBaseEntity value)
		{
			method from_CBaseEntity_To_CBaseAnimating = CBaseAnimating.__N.From_CBaseEntity_To_CBaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, from_CBaseEntity_To_CBaseAnimating);
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00028804 File Offset: 0x00026A04
		public static implicit operator CGameEntity(CBaseAnimating value)
		{
			method to_CGameEntity_From_CBaseAnimating = CBaseAnimating.__N.To_CGameEntity_From_CBaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, to_CGameEntity_From_CBaseAnimating);
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00028828 File Offset: 0x00026A28
		public static explicit operator CBaseAnimating(CGameEntity value)
		{
			method from_CGameEntity_To_CBaseAnimating = CBaseAnimating.__N.From_CGameEntity_To_CBaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, from_CGameEntity_To_CBaseAnimating);
		}

		// Token: 0x060003CB RID: 971 RVA: 0x0002884C File Offset: 0x00026A4C
		public static implicit operator CEntityInstance(CBaseAnimating value)
		{
			method to_CEntityInstance_From_CBaseAnimating = CBaseAnimating.__N.To_CEntityInstance_From_CBaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, to_CEntityInstance_From_CBaseAnimating);
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00028870 File Offset: 0x00026A70
		public static explicit operator CBaseAnimating(CEntityInstance value)
		{
			method from_CEntityInstance_To_CBaseAnimating = CBaseAnimating.__N.From_CEntityInstance_To_CBaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, from_CEntityInstance_To_CBaseAnimating);
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00028894 File Offset: 0x00026A94
		public static implicit operator IHandleEntity(CBaseAnimating value)
		{
			method to_IHandleEntity_From_CBaseAnimating = CBaseAnimating.__N.To_IHandleEntity_From_CBaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, to_IHandleEntity_From_CBaseAnimating);
		}

		// Token: 0x060003CE RID: 974 RVA: 0x000288B8 File Offset: 0x00026AB8
		public static explicit operator CBaseAnimating(IHandleEntity value)
		{
			method from_IHandleEntity_To_CBaseAnimating = CBaseAnimating.__N.From_IHandleEntity_To_CBaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, from_IHandleEntity_To_CBaseAnimating);
		}

		// Token: 0x060003CF RID: 975 RVA: 0x000288DC File Offset: 0x00026ADC
		internal readonly float GetPlaybackRate()
		{
			this.NullCheck("GetPlaybackRate");
			method cbseAn_GetPlaybackRate = CBaseAnimating.__N.CBseAn_GetPlaybackRate;
			return calli(System.Single(System.IntPtr), this.self, cbseAn_GetPlaybackRate);
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x00028908 File Offset: 0x00026B08
		internal readonly void SetPlaybackRate(float rate)
		{
			this.NullCheck("SetPlaybackRate");
			method cbseAn_SetPlaybackRate = CBaseAnimating.__N.CBseAn_SetPlaybackRate;
			calli(System.Void(System.IntPtr,System.Single), this.self, rate, cbseAn_SetPlaybackRate);
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x00028934 File Offset: 0x00026B34
		internal readonly float GetCycle()
		{
			this.NullCheck("GetCycle");
			method cbseAn_GetCycle = CBaseAnimating.__N.CBseAn_GetCycle;
			return calli(System.Single(System.IntPtr), this.self, cbseAn_GetCycle);
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00028960 File Offset: 0x00026B60
		internal readonly void SetCycle(float time)
		{
			this.NullCheck("SetCycle");
			method cbseAn_SetCycle = CBaseAnimating.__N.CBseAn_SetCycle;
			calli(System.Void(System.IntPtr,System.Single), this.self, time, cbseAn_SetCycle);
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0002898C File Offset: 0x00026B8C
		internal readonly void Script_SetSequence(string pSequenceName)
		{
			this.NullCheck("Script_SetSequence");
			method cbseAn_Script_SetSequence = CBaseAnimating.__N.CBseAn_Script_SetSequence;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pSequenceName), cbseAn_Script_SetSequence);
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x000289BC File Offset: 0x00026BBC
		internal readonly void Script_ResetSequence(string pSequenceName)
		{
			this.NullCheck("Script_ResetSequence");
			method cbseAn_Script_ResetSequence = CBaseAnimating.__N.CBseAn_Script_ResetSequence;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pSequenceName), cbseAn_Script_ResetSequence);
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x000289EC File Offset: 0x00026BEC
		internal readonly string Script_GetSequence()
		{
			this.NullCheck("Script_GetSequence");
			method cbseAn_Script_GetSequence = CBaseAnimating.__N.CBseAn_Script_GetSequence;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbseAn_Script_GetSequence));
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x00028A1C File Offset: 0x00026C1C
		internal readonly bool IsValidSequence(string pSequenceName)
		{
			this.NullCheck("IsValidSequence");
			method cbseAn_IsValidSequence = CBaseAnimating.__N.CBseAn_IsValidSequence;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pSequenceName), cbseAn_IsValidSequence) > 0;
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00028A50 File Offset: 0x00026C50
		internal readonly bool IsSequenceFinished()
		{
			this.NullCheck("IsSequenceFinished");
			method cbseAn_IsSequenceFinished = CBaseAnimating.__N.CBseAn_IsSequenceFinished;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_IsSequenceFinished) > 0;
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00028A80 File Offset: 0x00026C80
		internal readonly float SequenceDuration()
		{
			this.NullCheck("SequenceDuration");
			method cbseAn_SequenceDuration = CBaseAnimating.__N.CBseAn_SequenceDuration;
			return calli(System.Single(System.IntPtr), this.self, cbseAn_SequenceDuration);
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x00028AAC File Offset: 0x00026CAC
		internal readonly float Script_SequenceDuration(string pSequenceName)
		{
			this.NullCheck("Script_SequenceDuration");
			method cbseAn_Script_SequenceDuration = CBaseAnimating.__N.CBseAn_Script_SequenceDuration;
			return calli(System.Single(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pSequenceName), cbseAn_Script_SequenceDuration);
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00028ADC File Offset: 0x00026CDC
		internal readonly void SetShouldUseAnimGraph(bool should)
		{
			this.NullCheck("SetShouldUseAnimGraph");
			method cbseAn_SetShouldUseAnimGraph = CBaseAnimating.__N.CBseAn_SetShouldUseAnimGraph;
			calli(System.Void(System.IntPtr,System.Int32), this.self, should ? 1 : 0, cbseAn_SetShouldUseAnimGraph);
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00028B10 File Offset: 0x00026D10
		internal readonly bool GetShouldUseAnimGraph()
		{
			this.NullCheck("GetShouldUseAnimGraph");
			method cbseAn_GetShouldUseAnimGraph = CBaseAnimating.__N.CBseAn_GetShouldUseAnimGraph;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_GetShouldUseAnimGraph) > 0;
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00028B40 File Offset: 0x00026D40
		internal readonly void SetOverrideGraphName(string graphName)
		{
			this.NullCheck("SetOverrideGraphName");
			method cbseAn_SetOverrideGraphName = CBaseAnimating.__N.CBseAn_SetOverrideGraphName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(graphName), cbseAn_SetOverrideGraphName);
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00028B70 File Offset: 0x00026D70
		internal readonly string GetOverrideGraphName()
		{
			this.NullCheck("GetOverrideGraphName");
			method cbseAn_GetOverrideGraphName = CBaseAnimating.__N.CBseAn_GetOverrideGraphName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbseAn_GetOverrideGraphName));
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00028BA0 File Offset: 0x00026DA0
		internal readonly bool UseAnimGraph()
		{
			this.NullCheck("UseAnimGraph");
			method cbseAn_UseAnimGraph = CBaseAnimating.__N.CBseAn_UseAnimGraph;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_UseAnimGraph) > 0;
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00028BD0 File Offset: 0x00026DD0
		internal readonly bool HasAnimGraph()
		{
			this.NullCheck("HasAnimGraph");
			method cbseAn_HasAnimGraph = CBaseAnimating.__N.CBseAn_HasAnimGraph;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_HasAnimGraph) > 0;
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00028C00 File Offset: 0x00026E00
		internal readonly bool GetBoolGraphParameter(string name)
		{
			this.NullCheck("GetBoolGraphParameter");
			method cbseAn_GetBoolGraphParameter = CBaseAnimating.__N.CBseAn_GetBoolGraphParameter;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseAn_GetBoolGraphParameter) > 0;
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00028C34 File Offset: 0x00026E34
		internal readonly float GetFloatGraphParameter(string name)
		{
			this.NullCheck("GetFloatGraphParameter");
			method cbseAn_GetFloatGraphParameter = CBaseAnimating.__N.CBseAn_GetFloatGraphParameter;
			return calli(System.Single(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseAn_GetFloatGraphParameter);
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00028C64 File Offset: 0x00026E64
		internal readonly Vector3 GetVectorGraphParameter(string name)
		{
			this.NullCheck("GetVectorGraphParameter");
			method cbseAn_GetVectorGraphParameter = CBaseAnimating.__N.CBseAn_GetVectorGraphParameter;
			return calli(Vector3(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseAn_GetVectorGraphParameter);
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00028C94 File Offset: 0x00026E94
		internal readonly int GetIntGraphParameter(string name)
		{
			this.NullCheck("GetIntGraphParameter");
			method cbseAn_GetIntGraphParameter = CBaseAnimating.__N.CBseAn_GetIntGraphParameter;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseAn_GetIntGraphParameter);
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00028CC4 File Offset: 0x00026EC4
		internal readonly void SetGraphParameter(string name, bool val)
		{
			this.NullCheck("SetGraphParameter");
			method cbseAn_SetGraphParameter = CBaseAnimating.__N.CBseAn_SetGraphParameter;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(name), val ? 1 : 0, cbseAn_SetGraphParameter);
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00028CFC File Offset: 0x00026EFC
		internal readonly void SetGraphParameter(string name, int val)
		{
			this.NullCheck("SetGraphParameter");
			method cbseAn_f = CBaseAnimating.__N.CBseAn_f2;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(name), val, cbseAn_f);
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00028D30 File Offset: 0x00026F30
		internal readonly void SetGraphParameter(string name, float val)
		{
			this.NullCheck("SetGraphParameter");
			method cbseAn_f = CBaseAnimating.__N.CBseAn_f3;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Single), this.self, Interop.GetPointer(name), val, cbseAn_f);
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00028D64 File Offset: 0x00026F64
		internal unsafe readonly void SetGraphParameter(string name, Vector3 val)
		{
			this.NullCheck("SetGraphParameter");
			method cbseAn_f = CBaseAnimating.__N.CBseAn_f4;
			calli(System.Void(System.IntPtr,System.IntPtr,Vector3*), this.self, Interop.GetPointer(name), &val, cbseAn_f);
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x00028D98 File Offset: 0x00026F98
		internal unsafe readonly void SetGraphParameter(string name, Rotation val)
		{
			this.NullCheck("SetGraphParameter");
			method cbseAn_f = CBaseAnimating.__N.CBseAn_f5;
			calli(System.Void(System.IntPtr,System.IntPtr,Rotation*), this.self, Interop.GetPointer(name), &val, cbseAn_f);
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00028DCC File Offset: 0x00026FCC
		internal readonly bool SetGraphParameterFromString(string val)
		{
			this.NullCheck("SetGraphParameterFromString");
			method cbseAn_SetGraphParameterFromString = CBaseAnimating.__N.CBseAn_SetGraphParameterFromString;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(val), cbseAn_SetGraphParameterFromString) > 0;
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00028E00 File Offset: 0x00027000
		internal readonly void SetMasterBlendAmountEasing(float fGoal)
		{
			this.NullCheck("SetMasterBlendAmountEasing");
			method cbseAn_SetMasterBlendAmountEasing = CBaseAnimating.__N.CBseAn_SetMasterBlendAmountEasing;
			calli(System.Void(System.IntPtr,System.Single), this.self, fGoal, cbseAn_SetMasterBlendAmountEasing);
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00028E2C File Offset: 0x0002702C
		internal readonly float GetMasterBlendAmountEasing()
		{
			this.NullCheck("GetMasterBlendAmountEasing");
			method cbseAn_GetMasterBlendAmountEasing = CBaseAnimating.__N.CBseAn_GetMasterBlendAmountEasing;
			return calli(System.Single(System.IntPtr), this.self, cbseAn_GetMasterBlendAmountEasing);
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00028E58 File Offset: 0x00027058
		internal readonly bool IsAnimGraphUpdateEnabled()
		{
			this.NullCheck("IsAnimGraphUpdateEnabled");
			method cbseAn_IsAnimGraphUpdateEnabled = CBaseAnimating.__N.CBseAn_IsAnimGraphUpdateEnabled;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_IsAnimGraphUpdateEnabled) > 0;
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00028E88 File Offset: 0x00027088
		internal readonly void SetAnimGraphUpdateEnabled(bool up)
		{
			this.NullCheck("SetAnimGraphUpdateEnabled");
			method cbseAn_SetAnimGraphUpdateEnabled = CBaseAnimating.__N.CBseAn_SetAnimGraphUpdateEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, up ? 1 : 0, cbseAn_SetAnimGraphUpdateEnabled);
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00028EBC File Offset: 0x000270BC
		internal readonly void ResetGraphParameters()
		{
			this.NullCheck("ResetGraphParameters");
			method cbseAn_ResetGraphParameters = CBaseAnimating.__N.CBseAn_ResetGraphParameters;
			calli(System.Void(System.IntPtr), this.self, cbseAn_ResetGraphParameters);
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00028EE8 File Offset: 0x000270E8
		internal readonly void EnableIK(bool b)
		{
			this.NullCheck("EnableIK");
			method cbseAn_EnableIK = CBaseAnimating.__N.CBseAn_EnableIK;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, cbseAn_EnableIK);
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00028F1C File Offset: 0x0002711C
		internal readonly Vector3 GetRootMotion()
		{
			this.NullCheck("GetRootMotion");
			method cbseAn_GetRootMotion = CBaseAnimating.__N.CBseAn_GetRootMotion;
			return calli(Vector3(System.IntPtr), this.self, cbseAn_GetRootMotion);
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x00028F48 File Offset: 0x00027148
		internal readonly float GetRootMotionAngle()
		{
			this.NullCheck("GetRootMotionAngle");
			method cbseAn_GetRootMotionAngle = CBaseAnimating.__N.CBseAn_GetRootMotionAngle;
			return calli(System.Single(System.IntPtr), this.self, cbseAn_GetRootMotionAngle);
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00028F74 File Offset: 0x00027174
		internal readonly CSkeletonInstance GetSkeletonInstance()
		{
			this.NullCheck("GetSkeletonInstance");
			method cbseAn_GetSkeletonInstance = CBaseAnimating.__N.CBseAn_GetSkeletonInstance;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseAn_GetSkeletonInstance);
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00028FA4 File Offset: 0x000271A4
		internal readonly void SetModelScale(float scale)
		{
			this.NullCheck("SetModelScale");
			method cbseAn_SetModelScale = CBaseAnimating.__N.CBseAn_SetModelScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, scale, cbseAn_SetModelScale);
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00028FD0 File Offset: 0x000271D0
		internal readonly float GetModelScale()
		{
			this.NullCheck("GetModelScale");
			method cbseAn_GetModelScale = CBaseAnimating.__N.CBseAn_GetModelScale;
			return calli(System.Single(System.IntPtr), this.self, cbseAn_GetModelScale);
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00028FFC File Offset: 0x000271FC
		internal readonly int GetNumBones()
		{
			this.NullCheck("GetNumBones");
			method cbseAn_GetNumBones = CBaseAnimating.__N.CBseAn_GetNumBones;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_GetNumBones);
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00029028 File Offset: 0x00027228
		internal readonly int LookupBone(string szName)
		{
			this.NullCheck("LookupBone");
			method cbseAn_LookupBone = CBaseAnimating.__N.CBseAn_LookupBone;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(szName), cbseAn_LookupBone);
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00029058 File Offset: 0x00027258
		internal readonly int GetAttachmentCount()
		{
			this.NullCheck("GetAttachmentCount");
			method cbseAn_GetAttachmentCount = CBaseAnimating.__N.CBseAn_GetAttachmentCount;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_GetAttachmentCount);
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00029084 File Offset: 0x00027284
		internal readonly float GetMinFadeDist()
		{
			this.NullCheck("GetMinFadeDist");
			method cbseAn_GetMinFadeDist = CBaseAnimating.__N.CBseAn_GetMinFadeDist;
			return calli(System.Single(System.IntPtr), this.self, cbseAn_GetMinFadeDist);
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x000290B0 File Offset: 0x000272B0
		internal readonly float GetMaxFadeDist()
		{
			this.NullCheck("GetMaxFadeDist");
			method cbseAn_GetMaxFadeDist = CBaseAnimating.__N.CBseAn_GetMaxFadeDist;
			return calli(System.Single(System.IntPtr), this.self, cbseAn_GetMaxFadeDist);
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x000290DC File Offset: 0x000272DC
		internal readonly void SetModel(string name)
		{
			this.NullCheck("SetModel");
			method cbseAn_SetModel = CBaseAnimating.__N.CBseAn_SetModel;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseAn_SetModel);
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0002910C File Offset: 0x0002730C
		internal readonly IModel GetModel()
		{
			this.NullCheck("GetModel");
			method cbseAn_GetModel = CBaseAnimating.__N.CBseAn_GetModel;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseAn_GetModel);
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0002913C File Offset: 0x0002733C
		internal readonly void SetModel(IModel model)
		{
			this.NullCheck("SetModel");
			method cbseAn_f = CBaseAnimating.__N.CBseAn_f6;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, model, cbseAn_f);
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x0002916C File Offset: 0x0002736C
		internal readonly void SetModelAsync(string name)
		{
			this.NullCheck("SetModelAsync");
			method cbseAn_SetModelAsync = CBaseAnimating.__N.CBseAn_SetModelAsync;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseAn_SetModelAsync);
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0002919C File Offset: 0x0002739C
		internal readonly void SetBodygroup(int iGroup, int iValue)
		{
			this.NullCheck("SetBodygroup");
			method cbseAn_SetBodygroup = CBaseAnimating.__N.CBseAn_SetBodygroup;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32), this.self, iGroup, iValue, cbseAn_SetBodygroup);
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x000291C8 File Offset: 0x000273C8
		internal readonly void SetBodygroupByName(string pName, int iValue)
		{
			this.NullCheck("SetBodygroupByName");
			method cbseAn_SetBodygroupByName = CBaseAnimating.__N.CBseAn_SetBodygroupByName;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(pName), iValue, cbseAn_SetBodygroupByName);
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x000291FC File Offset: 0x000273FC
		internal readonly ulong GetRawMeshGroupMask()
		{
			this.NullCheck("GetRawMeshGroupMask");
			method cbseAn_GetRawMeshGroupMask = CBaseAnimating.__N.CBseAn_GetRawMeshGroupMask;
			return calli(System.UInt64(System.IntPtr), this.self, cbseAn_GetRawMeshGroupMask);
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x00029228 File Offset: 0x00027428
		internal readonly void SetRawMeshGroupMask_LegacyDoNotUse(ulong nBody)
		{
			this.NullCheck("SetRawMeshGroupMask_LegacyDoNotUse");
			method cbseAn_SetRawMeshGroupMask_LegacyDoNotUse = CBaseAnimating.__N.CBseAn_SetRawMeshGroupMask_LegacyDoNotUse;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBody, cbseAn_SetRawMeshGroupMask_LegacyDoNotUse);
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00029254 File Offset: 0x00027454
		internal readonly int GetSkinCount()
		{
			this.NullCheck("GetSkinCount");
			method cbseAn_GetSkinCount = CBaseAnimating.__N.CBseAn_GetSkinCount;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_GetSkinCount);
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x00029280 File Offset: 0x00027480
		internal readonly void SetSkin(int iSkin)
		{
			this.NullCheck("SetSkin");
			method cbseAn_SetSkin = CBaseAnimating.__N.CBseAn_SetSkin;
			calli(System.Void(System.IntPtr,System.Int32), this.self, iSkin, cbseAn_SetSkin);
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x000292AC File Offset: 0x000274AC
		internal readonly void SetSkin(string name)
		{
			this.NullCheck("SetSkin");
			method cbseAn_f = CBaseAnimating.__N.CBseAn_f7;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(name), cbseAn_f);
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x000292DC File Offset: 0x000274DC
		internal readonly int GetS1Skin()
		{
			this.NullCheck("GetS1Skin");
			method cbseAn_GetS1Skin = CBaseAnimating.__N.CBseAn_GetS1Skin;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_GetS1Skin);
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x00029308 File Offset: 0x00027508
		internal readonly CollisionProperty CollisionProp()
		{
			this.NullCheck("CollisionProp");
			method cbseAn_CollisionProp = CBaseAnimating.__N.CBseAn_CollisionProp;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseAn_CollisionProp);
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00029338 File Offset: 0x00027538
		internal readonly void SetRenderAlpha(byte alpha)
		{
			this.NullCheck("SetRenderAlpha");
			method cbseAn_SetRenderAlpha = CBaseAnimating.__N.CBseAn_SetRenderAlpha;
			calli(System.Void(System.IntPtr,System.Byte), this.self, alpha, cbseAn_SetRenderAlpha);
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x00029364 File Offset: 0x00027564
		internal readonly byte GetRenderAlpha()
		{
			this.NullCheck("GetRenderAlpha");
			method cbseAn_GetRenderAlpha = CBaseAnimating.__N.CBseAn_GetRenderAlpha;
			return calli(System.Byte(System.IntPtr), this.self, cbseAn_GetRenderAlpha);
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x00029390 File Offset: 0x00027590
		internal readonly void SetRenderColor(byte r, byte g, byte b)
		{
			this.NullCheck("SetRenderColor");
			method cbseAn_SetRenderColor = CBaseAnimating.__N.CBseAn_SetRenderColor;
			calli(System.Void(System.IntPtr,System.Byte,System.Byte,System.Byte), this.self, r, g, b, cbseAn_SetRenderColor);
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x000293C0 File Offset: 0x000275C0
		internal readonly void SetRenderColorAndAlpha(Color32 color)
		{
			this.NullCheck("SetRenderColorAndAlpha");
			method cbseAn_SetRenderColorAndAlpha = CBaseAnimating.__N.CBseAn_SetRenderColorAndAlpha;
			calli(System.Void(System.IntPtr,Color32), this.self, color, cbseAn_SetRenderColorAndAlpha);
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x000293EC File Offset: 0x000275EC
		internal readonly Color24 GetRenderColor()
		{
			this.NullCheck("GetRenderColor");
			method cbseAn_GetRenderColor = CBaseAnimating.__N.CBseAn_GetRenderColor;
			return calli(Color24(System.IntPtr), this.self, cbseAn_GetRenderColor);
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x00029418 File Offset: 0x00027618
		internal readonly CGlowProperty GlowProp()
		{
			this.NullCheck("GlowProp");
			method cbseAn_GlowProp = CBaseAnimating.__N.CBseAn_GlowProp;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseAn_GlowProp);
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00029448 File Offset: 0x00027648
		internal readonly Transform GetBoneTransform(int bone)
		{
			this.NullCheck("GetBoneTransform");
			method cbseAn_GetBoneTransform = CBaseAnimating.__N.CBseAn_GetBoneTransform;
			return calli(Transform(System.IntPtr,System.Int32), this.self, bone, cbseAn_GetBoneTransform);
		}

		// Token: 0x040000A1 RID: 161
		internal IntPtr self;

		// Token: 0x020001AA RID: 426
		internal static class __N
		{
			// Token: 0x04000A00 RID: 2560
			internal static method From_CBaseModelEntity_To_CBaseAnimating;

			// Token: 0x04000A01 RID: 2561
			internal static method To_CBaseModelEntity_From_CBaseAnimating;

			// Token: 0x04000A02 RID: 2562
			internal static method From_CBaseEntity_To_CBaseAnimating;

			// Token: 0x04000A03 RID: 2563
			internal static method To_CBaseEntity_From_CBaseAnimating;

			// Token: 0x04000A04 RID: 2564
			internal static method From_CGameEntity_To_CBaseAnimating;

			// Token: 0x04000A05 RID: 2565
			internal static method To_CGameEntity_From_CBaseAnimating;

			// Token: 0x04000A06 RID: 2566
			internal static method From_CEntityInstance_To_CBaseAnimating;

			// Token: 0x04000A07 RID: 2567
			internal static method To_CEntityInstance_From_CBaseAnimating;

			// Token: 0x04000A08 RID: 2568
			internal static method From_IHandleEntity_To_CBaseAnimating;

			// Token: 0x04000A09 RID: 2569
			internal static method To_IHandleEntity_From_CBaseAnimating;

			// Token: 0x04000A0A RID: 2570
			internal static method CBseAn_GetPlaybackRate;

			// Token: 0x04000A0B RID: 2571
			internal static method CBseAn_SetPlaybackRate;

			// Token: 0x04000A0C RID: 2572
			internal static method CBseAn_GetCycle;

			// Token: 0x04000A0D RID: 2573
			internal static method CBseAn_SetCycle;

			// Token: 0x04000A0E RID: 2574
			internal static method CBseAn_Script_SetSequence;

			// Token: 0x04000A0F RID: 2575
			internal static method CBseAn_Script_ResetSequence;

			// Token: 0x04000A10 RID: 2576
			internal static method CBseAn_Script_GetSequence;

			// Token: 0x04000A11 RID: 2577
			internal static method CBseAn_IsValidSequence;

			// Token: 0x04000A12 RID: 2578
			internal static method CBseAn_IsSequenceFinished;

			// Token: 0x04000A13 RID: 2579
			internal static method CBseAn_SequenceDuration;

			// Token: 0x04000A14 RID: 2580
			internal static method CBseAn_Script_SequenceDuration;

			// Token: 0x04000A15 RID: 2581
			internal static method CBseAn_SetShouldUseAnimGraph;

			// Token: 0x04000A16 RID: 2582
			internal static method CBseAn_GetShouldUseAnimGraph;

			// Token: 0x04000A17 RID: 2583
			internal static method CBseAn_SetOverrideGraphName;

			// Token: 0x04000A18 RID: 2584
			internal static method CBseAn_GetOverrideGraphName;

			// Token: 0x04000A19 RID: 2585
			internal static method CBseAn_UseAnimGraph;

			// Token: 0x04000A1A RID: 2586
			internal static method CBseAn_HasAnimGraph;

			// Token: 0x04000A1B RID: 2587
			internal static method CBseAn_GetBoolGraphParameter;

			// Token: 0x04000A1C RID: 2588
			internal static method CBseAn_GetFloatGraphParameter;

			// Token: 0x04000A1D RID: 2589
			internal static method CBseAn_GetVectorGraphParameter;

			// Token: 0x04000A1E RID: 2590
			internal static method CBseAn_GetIntGraphParameter;

			// Token: 0x04000A1F RID: 2591
			internal static method CBseAn_SetGraphParameter;

			// Token: 0x04000A20 RID: 2592
			internal static method CBseAn_f2;

			// Token: 0x04000A21 RID: 2593
			internal static method CBseAn_f3;

			// Token: 0x04000A22 RID: 2594
			internal static method CBseAn_f4;

			// Token: 0x04000A23 RID: 2595
			internal static method CBseAn_f5;

			// Token: 0x04000A24 RID: 2596
			internal static method CBseAn_SetGraphParameterFromString;

			// Token: 0x04000A25 RID: 2597
			internal static method CBseAn_SetMasterBlendAmountEasing;

			// Token: 0x04000A26 RID: 2598
			internal static method CBseAn_GetMasterBlendAmountEasing;

			// Token: 0x04000A27 RID: 2599
			internal static method CBseAn_IsAnimGraphUpdateEnabled;

			// Token: 0x04000A28 RID: 2600
			internal static method CBseAn_SetAnimGraphUpdateEnabled;

			// Token: 0x04000A29 RID: 2601
			internal static method CBseAn_ResetGraphParameters;

			// Token: 0x04000A2A RID: 2602
			internal static method CBseAn_EnableIK;

			// Token: 0x04000A2B RID: 2603
			internal static method CBseAn_GetRootMotion;

			// Token: 0x04000A2C RID: 2604
			internal static method CBseAn_GetRootMotionAngle;

			// Token: 0x04000A2D RID: 2605
			internal static method CBseAn_GetSkeletonInstance;

			// Token: 0x04000A2E RID: 2606
			internal static method CBseAn_SetModelScale;

			// Token: 0x04000A2F RID: 2607
			internal static method CBseAn_GetModelScale;

			// Token: 0x04000A30 RID: 2608
			internal static method CBseAn_GetNumBones;

			// Token: 0x04000A31 RID: 2609
			internal static method CBseAn_LookupBone;

			// Token: 0x04000A32 RID: 2610
			internal static method CBseAn_GetAttachmentCount;

			// Token: 0x04000A33 RID: 2611
			internal static method CBseAn_GetMinFadeDist;

			// Token: 0x04000A34 RID: 2612
			internal static method CBseAn_GetMaxFadeDist;

			// Token: 0x04000A35 RID: 2613
			internal static method CBseAn_SetModel;

			// Token: 0x04000A36 RID: 2614
			internal static method CBseAn_GetModel;

			// Token: 0x04000A37 RID: 2615
			internal static method CBseAn_f6;

			// Token: 0x04000A38 RID: 2616
			internal static method CBseAn_SetModelAsync;

			// Token: 0x04000A39 RID: 2617
			internal static method CBseAn_SetBodygroup;

			// Token: 0x04000A3A RID: 2618
			internal static method CBseAn_SetBodygroupByName;

			// Token: 0x04000A3B RID: 2619
			internal static method CBseAn_GetRawMeshGroupMask;

			// Token: 0x04000A3C RID: 2620
			internal static method CBseAn_SetRawMeshGroupMask_LegacyDoNotUse;

			// Token: 0x04000A3D RID: 2621
			internal static method CBseAn_GetSkinCount;

			// Token: 0x04000A3E RID: 2622
			internal static method CBseAn_SetSkin;

			// Token: 0x04000A3F RID: 2623
			internal static method CBseAn_f7;

			// Token: 0x04000A40 RID: 2624
			internal static method CBseAn_GetS1Skin;

			// Token: 0x04000A41 RID: 2625
			internal static method CBseAn_CollisionProp;

			// Token: 0x04000A42 RID: 2626
			internal static method CBseAn_SetRenderAlpha;

			// Token: 0x04000A43 RID: 2627
			internal static method CBseAn_GetRenderAlpha;

			// Token: 0x04000A44 RID: 2628
			internal static method CBseAn_SetRenderColor;

			// Token: 0x04000A45 RID: 2629
			internal static method CBseAn_SetRenderColorAndAlpha;

			// Token: 0x04000A46 RID: 2630
			internal static method CBseAn_GetRenderColor;

			// Token: 0x04000A47 RID: 2631
			internal static method CBseAn_GlowProp;

			// Token: 0x04000A48 RID: 2632
			internal static method CBseAn_GetBoneTransform;
		}
	}
}
