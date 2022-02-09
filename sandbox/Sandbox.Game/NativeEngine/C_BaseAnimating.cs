using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200001A RID: 26
	internal struct C_BaseAnimating
	{
		// Token: 0x06000190 RID: 400 RVA: 0x00022FFE File Offset: 0x000211FE
		public static implicit operator IntPtr(C_BaseAnimating value)
		{
			return value.self;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00023008 File Offset: 0x00021208
		public static implicit operator C_BaseAnimating(IntPtr value)
		{
			return new C_BaseAnimating
			{
				self = value
			};
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00023026 File Offset: 0x00021226
		public static bool operator ==(C_BaseAnimating c1, C_BaseAnimating c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00023039 File Offset: 0x00021239
		public static bool operator !=(C_BaseAnimating c1, C_BaseAnimating c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0002304C File Offset: 0x0002124C
		public override bool Equals(object obj)
		{
			if (obj is C_BaseAnimating)
			{
				C_BaseAnimating c = (C_BaseAnimating)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00023076 File Offset: 0x00021276
		internal C_BaseAnimating(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00023080 File Offset: 0x00021280
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
			defaultInterpolatedStringHandler.AppendLiteral("C_BaseAnimating ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000197 RID: 407 RVA: 0x000230BC File Offset: 0x000212BC
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000198 RID: 408 RVA: 0x000230CE File Offset: 0x000212CE
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x000230D9 File Offset: 0x000212D9
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000230EC File Offset: 0x000212EC
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("C_BaseAnimating was null when calling " + n);
			}
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00023107 File Offset: 0x00021307
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00023114 File Offset: 0x00021314
		public static implicit operator C_BaseModelEntity(C_BaseAnimating value)
		{
			method to_C_BaseModelEntity_From_C_BaseAnimating = C_BaseAnimating.__N.To_C_BaseModelEntity_From_C_BaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, to_C_BaseModelEntity_From_C_BaseAnimating);
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00023138 File Offset: 0x00021338
		public static explicit operator C_BaseAnimating(C_BaseModelEntity value)
		{
			method from_C_BaseModelEntity_To_C_BaseAnimating = C_BaseAnimating.__N.From_C_BaseModelEntity_To_C_BaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, from_C_BaseModelEntity_To_C_BaseAnimating);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0002315C File Offset: 0x0002135C
		public static implicit operator C_BaseEntity(C_BaseAnimating value)
		{
			method to_C_BaseEntity_From_C_BaseAnimating = C_BaseAnimating.__N.To_C_BaseEntity_From_C_BaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, to_C_BaseEntity_From_C_BaseAnimating);
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00023180 File Offset: 0x00021380
		public static explicit operator C_BaseAnimating(C_BaseEntity value)
		{
			method from_C_BaseEntity_To_C_BaseAnimating = C_BaseAnimating.__N.From_C_BaseEntity_To_C_BaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, from_C_BaseEntity_To_C_BaseAnimating);
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x000231A4 File Offset: 0x000213A4
		public static implicit operator CGameEntity(C_BaseAnimating value)
		{
			method to_CGameEntity_From_C_BaseAnimating = C_BaseAnimating.__N.To_CGameEntity_From_C_BaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, to_CGameEntity_From_C_BaseAnimating);
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x000231C8 File Offset: 0x000213C8
		public static explicit operator C_BaseAnimating(CGameEntity value)
		{
			method from_CGameEntity_To_C_BaseAnimating = C_BaseAnimating.__N.From_CGameEntity_To_C_BaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, from_CGameEntity_To_C_BaseAnimating);
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x000231EC File Offset: 0x000213EC
		public static implicit operator CEntityInstance(C_BaseAnimating value)
		{
			method to_CEntityInstance_From_C_BaseAnimating = C_BaseAnimating.__N.To_CEntityInstance_From_C_BaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, to_CEntityInstance_From_C_BaseAnimating);
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00023210 File Offset: 0x00021410
		public static explicit operator C_BaseAnimating(CEntityInstance value)
		{
			method from_CEntityInstance_To_C_BaseAnimating = C_BaseAnimating.__N.From_CEntityInstance_To_C_BaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, from_CEntityInstance_To_C_BaseAnimating);
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00023234 File Offset: 0x00021434
		public static implicit operator IHandleEntity(C_BaseAnimating value)
		{
			method to_IHandleEntity_From_C_BaseAnimating = C_BaseAnimating.__N.To_IHandleEntity_From_C_BaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, to_IHandleEntity_From_C_BaseAnimating);
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00023258 File Offset: 0x00021458
		public static explicit operator C_BaseAnimating(IHandleEntity value)
		{
			method from_IHandleEntity_To_C_BaseAnimating = C_BaseAnimating.__N.From_IHandleEntity_To_C_BaseAnimating;
			return calli(System.IntPtr(System.IntPtr), value, from_IHandleEntity_To_C_BaseAnimating);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0002327C File Offset: 0x0002147C
		internal readonly float GetPlaybackRate()
		{
			this.NullCheck("GetPlaybackRate");
			method cbseAn_GetPlaybackRate = C_BaseAnimating.__N.CBseAn_GetPlaybackRate;
			return calli(System.Single(System.IntPtr), this.self, cbseAn_GetPlaybackRate);
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x000232A8 File Offset: 0x000214A8
		internal readonly void SetPlaybackRate(float rate)
		{
			this.NullCheck("SetPlaybackRate");
			method cbseAn_SetPlaybackRate = C_BaseAnimating.__N.CBseAn_SetPlaybackRate;
			calli(System.Void(System.IntPtr,System.Single), this.self, rate, cbseAn_SetPlaybackRate);
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x000232D4 File Offset: 0x000214D4
		internal readonly float GetCycle()
		{
			this.NullCheck("GetCycle");
			method cbseAn_GetCycle = C_BaseAnimating.__N.CBseAn_GetCycle;
			return calli(System.Single(System.IntPtr), this.self, cbseAn_GetCycle);
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00023300 File Offset: 0x00021500
		internal readonly void SetCycle(float time)
		{
			this.NullCheck("SetCycle");
			method cbseAn_SetCycle = C_BaseAnimating.__N.CBseAn_SetCycle;
			calli(System.Void(System.IntPtr,System.Single), this.self, time, cbseAn_SetCycle);
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0002332C File Offset: 0x0002152C
		internal readonly void Script_SetSequence(string pSequenceName)
		{
			this.NullCheck("Script_SetSequence");
			method cbseAn_Script_SetSequence = C_BaseAnimating.__N.CBseAn_Script_SetSequence;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pSequenceName), cbseAn_Script_SetSequence);
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0002335C File Offset: 0x0002155C
		internal readonly void Script_ResetSequence(string pSequenceName)
		{
			this.NullCheck("Script_ResetSequence");
			method cbseAn_Script_ResetSequence = C_BaseAnimating.__N.CBseAn_Script_ResetSequence;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pSequenceName), cbseAn_Script_ResetSequence);
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0002338C File Offset: 0x0002158C
		internal readonly string Script_GetSequence()
		{
			this.NullCheck("Script_GetSequence");
			method cbseAn_Script_GetSequence = C_BaseAnimating.__N.CBseAn_Script_GetSequence;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbseAn_Script_GetSequence));
		}

		// Token: 0x060001AD RID: 429 RVA: 0x000233BC File Offset: 0x000215BC
		internal readonly bool IsValidSequence(string pSequenceName)
		{
			this.NullCheck("IsValidSequence");
			method cbseAn_IsValidSequence = C_BaseAnimating.__N.CBseAn_IsValidSequence;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pSequenceName), cbseAn_IsValidSequence) > 0;
		}

		// Token: 0x060001AE RID: 430 RVA: 0x000233F0 File Offset: 0x000215F0
		internal readonly bool IsSequenceFinished()
		{
			this.NullCheck("IsSequenceFinished");
			method cbseAn_IsSequenceFinished = C_BaseAnimating.__N.CBseAn_IsSequenceFinished;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_IsSequenceFinished) > 0;
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00023420 File Offset: 0x00021620
		internal readonly float SequenceDuration()
		{
			this.NullCheck("SequenceDuration");
			method cbseAn_SequenceDuration = C_BaseAnimating.__N.CBseAn_SequenceDuration;
			return calli(System.Single(System.IntPtr), this.self, cbseAn_SequenceDuration);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0002344C File Offset: 0x0002164C
		internal readonly float Script_SequenceDuration(string pSequenceName)
		{
			this.NullCheck("Script_SequenceDuration");
			method cbseAn_Script_SequenceDuration = C_BaseAnimating.__N.CBseAn_Script_SequenceDuration;
			return calli(System.Single(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pSequenceName), cbseAn_Script_SequenceDuration);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0002347C File Offset: 0x0002167C
		internal readonly void SetShouldUseAnimGraph(bool should)
		{
			this.NullCheck("SetShouldUseAnimGraph");
			method cbseAn_SetShouldUseAnimGraph = C_BaseAnimating.__N.CBseAn_SetShouldUseAnimGraph;
			calli(System.Void(System.IntPtr,System.Int32), this.self, should ? 1 : 0, cbseAn_SetShouldUseAnimGraph);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x000234B0 File Offset: 0x000216B0
		internal readonly bool GetShouldUseAnimGraph()
		{
			this.NullCheck("GetShouldUseAnimGraph");
			method cbseAn_GetShouldUseAnimGraph = C_BaseAnimating.__N.CBseAn_GetShouldUseAnimGraph;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_GetShouldUseAnimGraph) > 0;
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x000234E0 File Offset: 0x000216E0
		internal readonly void SetOverrideGraphName(string graphName)
		{
			this.NullCheck("SetOverrideGraphName");
			method cbseAn_SetOverrideGraphName = C_BaseAnimating.__N.CBseAn_SetOverrideGraphName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(graphName), cbseAn_SetOverrideGraphName);
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00023510 File Offset: 0x00021710
		internal readonly string GetOverrideGraphName()
		{
			this.NullCheck("GetOverrideGraphName");
			method cbseAn_GetOverrideGraphName = C_BaseAnimating.__N.CBseAn_GetOverrideGraphName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbseAn_GetOverrideGraphName));
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00023540 File Offset: 0x00021740
		internal readonly bool UseAnimGraph()
		{
			this.NullCheck("UseAnimGraph");
			method cbseAn_UseAnimGraph = C_BaseAnimating.__N.CBseAn_UseAnimGraph;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_UseAnimGraph) > 0;
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00023570 File Offset: 0x00021770
		internal readonly bool HasAnimGraph()
		{
			this.NullCheck("HasAnimGraph");
			method cbseAn_HasAnimGraph = C_BaseAnimating.__N.CBseAn_HasAnimGraph;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_HasAnimGraph) > 0;
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x000235A0 File Offset: 0x000217A0
		internal readonly bool GetBoolGraphParameter(string name)
		{
			this.NullCheck("GetBoolGraphParameter");
			method cbseAn_GetBoolGraphParameter = C_BaseAnimating.__N.CBseAn_GetBoolGraphParameter;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseAn_GetBoolGraphParameter) > 0;
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000235D4 File Offset: 0x000217D4
		internal readonly float GetFloatGraphParameter(string name)
		{
			this.NullCheck("GetFloatGraphParameter");
			method cbseAn_GetFloatGraphParameter = C_BaseAnimating.__N.CBseAn_GetFloatGraphParameter;
			return calli(System.Single(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseAn_GetFloatGraphParameter);
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00023604 File Offset: 0x00021804
		internal readonly Vector3 GetVectorGraphParameter(string name)
		{
			this.NullCheck("GetVectorGraphParameter");
			method cbseAn_GetVectorGraphParameter = C_BaseAnimating.__N.CBseAn_GetVectorGraphParameter;
			return calli(Vector3(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseAn_GetVectorGraphParameter);
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00023634 File Offset: 0x00021834
		internal readonly int GetIntGraphParameter(string name)
		{
			this.NullCheck("GetIntGraphParameter");
			method cbseAn_GetIntGraphParameter = C_BaseAnimating.__N.CBseAn_GetIntGraphParameter;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseAn_GetIntGraphParameter);
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00023664 File Offset: 0x00021864
		internal readonly void SetGraphParameter(string name, bool val)
		{
			this.NullCheck("SetGraphParameter");
			method cbseAn_SetGraphParameter = C_BaseAnimating.__N.CBseAn_SetGraphParameter;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(name), val ? 1 : 0, cbseAn_SetGraphParameter);
		}

		// Token: 0x060001BC RID: 444 RVA: 0x0002369C File Offset: 0x0002189C
		internal readonly void SetGraphParameter(string name, int val)
		{
			this.NullCheck("SetGraphParameter");
			method cbseAn_f = C_BaseAnimating.__N.CBseAn_f2;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(name), val, cbseAn_f);
		}

		// Token: 0x060001BD RID: 445 RVA: 0x000236D0 File Offset: 0x000218D0
		internal readonly void SetGraphParameter(string name, float val)
		{
			this.NullCheck("SetGraphParameter");
			method cbseAn_f = C_BaseAnimating.__N.CBseAn_f3;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Single), this.self, Interop.GetPointer(name), val, cbseAn_f);
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00023704 File Offset: 0x00021904
		internal unsafe readonly void SetGraphParameter(string name, Vector3 val)
		{
			this.NullCheck("SetGraphParameter");
			method cbseAn_f = C_BaseAnimating.__N.CBseAn_f4;
			calli(System.Void(System.IntPtr,System.IntPtr,Vector3*), this.self, Interop.GetPointer(name), &val, cbseAn_f);
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00023738 File Offset: 0x00021938
		internal unsafe readonly void SetGraphParameter(string name, Rotation val)
		{
			this.NullCheck("SetGraphParameter");
			method cbseAn_f = C_BaseAnimating.__N.CBseAn_f5;
			calli(System.Void(System.IntPtr,System.IntPtr,Rotation*), this.self, Interop.GetPointer(name), &val, cbseAn_f);
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0002376C File Offset: 0x0002196C
		internal readonly bool SetGraphParameterFromString(string val)
		{
			this.NullCheck("SetGraphParameterFromString");
			method cbseAn_SetGraphParameterFromString = C_BaseAnimating.__N.CBseAn_SetGraphParameterFromString;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(val), cbseAn_SetGraphParameterFromString) > 0;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x000237A0 File Offset: 0x000219A0
		internal readonly void SetMasterBlendAmountEasing(float fGoal)
		{
			this.NullCheck("SetMasterBlendAmountEasing");
			method cbseAn_SetMasterBlendAmountEasing = C_BaseAnimating.__N.CBseAn_SetMasterBlendAmountEasing;
			calli(System.Void(System.IntPtr,System.Single), this.self, fGoal, cbseAn_SetMasterBlendAmountEasing);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x000237CC File Offset: 0x000219CC
		internal readonly float GetMasterBlendAmountEasing()
		{
			this.NullCheck("GetMasterBlendAmountEasing");
			method cbseAn_GetMasterBlendAmountEasing = C_BaseAnimating.__N.CBseAn_GetMasterBlendAmountEasing;
			return calli(System.Single(System.IntPtr), this.self, cbseAn_GetMasterBlendAmountEasing);
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x000237F8 File Offset: 0x000219F8
		internal readonly bool IsAnimGraphUpdateEnabled()
		{
			this.NullCheck("IsAnimGraphUpdateEnabled");
			method cbseAn_IsAnimGraphUpdateEnabled = C_BaseAnimating.__N.CBseAn_IsAnimGraphUpdateEnabled;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_IsAnimGraphUpdateEnabled) > 0;
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00023828 File Offset: 0x00021A28
		internal readonly void SetAnimGraphUpdateEnabled(bool up)
		{
			this.NullCheck("SetAnimGraphUpdateEnabled");
			method cbseAn_SetAnimGraphUpdateEnabled = C_BaseAnimating.__N.CBseAn_SetAnimGraphUpdateEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, up ? 1 : 0, cbseAn_SetAnimGraphUpdateEnabled);
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0002385C File Offset: 0x00021A5C
		internal readonly void ResetGraphParameters()
		{
			this.NullCheck("ResetGraphParameters");
			method cbseAn_ResetGraphParameters = C_BaseAnimating.__N.CBseAn_ResetGraphParameters;
			calli(System.Void(System.IntPtr), this.self, cbseAn_ResetGraphParameters);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00023888 File Offset: 0x00021A88
		internal readonly void EnableIK(bool b)
		{
			this.NullCheck("EnableIK");
			method cbseAn_EnableIK = C_BaseAnimating.__N.CBseAn_EnableIK;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, cbseAn_EnableIK);
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x000238BC File Offset: 0x00021ABC
		internal readonly Vector3 GetRootMotion()
		{
			this.NullCheck("GetRootMotion");
			method cbseAn_GetRootMotion = C_BaseAnimating.__N.CBseAn_GetRootMotion;
			return calli(Vector3(System.IntPtr), this.self, cbseAn_GetRootMotion);
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x000238E8 File Offset: 0x00021AE8
		internal readonly float GetRootMotionAngle()
		{
			this.NullCheck("GetRootMotionAngle");
			method cbseAn_GetRootMotionAngle = C_BaseAnimating.__N.CBseAn_GetRootMotionAngle;
			return calli(System.Single(System.IntPtr), this.self, cbseAn_GetRootMotionAngle);
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00023914 File Offset: 0x00021B14
		internal readonly CSkeletonInstance GetSkeletonInstance()
		{
			this.NullCheck("GetSkeletonInstance");
			method cbseAn_GetSkeletonInstance = C_BaseAnimating.__N.CBseAn_GetSkeletonInstance;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseAn_GetSkeletonInstance);
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00023944 File Offset: 0x00021B44
		internal readonly void SetModelScale(float scale)
		{
			this.NullCheck("SetModelScale");
			method cbseAn_SetModelScale = C_BaseAnimating.__N.CBseAn_SetModelScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, scale, cbseAn_SetModelScale);
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00023970 File Offset: 0x00021B70
		internal readonly float GetModelScale()
		{
			this.NullCheck("GetModelScale");
			method cbseAn_GetModelScale = C_BaseAnimating.__N.CBseAn_GetModelScale;
			return calli(System.Single(System.IntPtr), this.self, cbseAn_GetModelScale);
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0002399C File Offset: 0x00021B9C
		internal readonly int GetNumBones()
		{
			this.NullCheck("GetNumBones");
			method cbseAn_GetNumBones = C_BaseAnimating.__N.CBseAn_GetNumBones;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_GetNumBones);
		}

		// Token: 0x060001CD RID: 461 RVA: 0x000239C8 File Offset: 0x00021BC8
		internal readonly int LookupBone(string szName)
		{
			this.NullCheck("LookupBone");
			method cbseAn_LookupBone = C_BaseAnimating.__N.CBseAn_LookupBone;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(szName), cbseAn_LookupBone);
		}

		// Token: 0x060001CE RID: 462 RVA: 0x000239F8 File Offset: 0x00021BF8
		internal readonly int GetAttachmentCount()
		{
			this.NullCheck("GetAttachmentCount");
			method cbseAn_GetAttachmentCount = C_BaseAnimating.__N.CBseAn_GetAttachmentCount;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_GetAttachmentCount);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00023A24 File Offset: 0x00021C24
		internal readonly float GetMinFadeDist()
		{
			this.NullCheck("GetMinFadeDist");
			method cbseAn_GetMinFadeDist = C_BaseAnimating.__N.CBseAn_GetMinFadeDist;
			return calli(System.Single(System.IntPtr), this.self, cbseAn_GetMinFadeDist);
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00023A50 File Offset: 0x00021C50
		internal readonly float GetMaxFadeDist()
		{
			this.NullCheck("GetMaxFadeDist");
			method cbseAn_GetMaxFadeDist = C_BaseAnimating.__N.CBseAn_GetMaxFadeDist;
			return calli(System.Single(System.IntPtr), this.self, cbseAn_GetMaxFadeDist);
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00023A7C File Offset: 0x00021C7C
		internal readonly void SetModel(string name)
		{
			this.NullCheck("SetModel");
			method cbseAn_SetModel = C_BaseAnimating.__N.CBseAn_SetModel;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseAn_SetModel);
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00023AAC File Offset: 0x00021CAC
		internal readonly void SetModelAsync(string name)
		{
			this.NullCheck("SetModelAsync");
			method cbseAn_SetModelAsync = C_BaseAnimating.__N.CBseAn_SetModelAsync;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseAn_SetModelAsync);
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00023ADC File Offset: 0x00021CDC
		internal readonly IModel GetModel()
		{
			this.NullCheck("GetModel");
			method cbseAn_GetModel = C_BaseAnimating.__N.CBseAn_GetModel;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseAn_GetModel);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00023B0C File Offset: 0x00021D0C
		internal readonly void SetModel(IModel model)
		{
			this.NullCheck("SetModel");
			method cbseAn_f = C_BaseAnimating.__N.CBseAn_f6;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, model, cbseAn_f);
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00023B3C File Offset: 0x00021D3C
		internal readonly void SetBodygroup(int iGroup, int iValue)
		{
			this.NullCheck("SetBodygroup");
			method cbseAn_SetBodygroup = C_BaseAnimating.__N.CBseAn_SetBodygroup;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32), this.self, iGroup, iValue, cbseAn_SetBodygroup);
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00023B68 File Offset: 0x00021D68
		internal readonly void SetBodygroupByName(string pName, int iValue)
		{
			this.NullCheck("SetBodygroupByName");
			method cbseAn_SetBodygroupByName = C_BaseAnimating.__N.CBseAn_SetBodygroupByName;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(pName), iValue, cbseAn_SetBodygroupByName);
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00023B9C File Offset: 0x00021D9C
		internal readonly ulong GetRawMeshGroupMask()
		{
			this.NullCheck("GetRawMeshGroupMask");
			method cbseAn_GetRawMeshGroupMask = C_BaseAnimating.__N.CBseAn_GetRawMeshGroupMask;
			return calli(System.UInt64(System.IntPtr), this.self, cbseAn_GetRawMeshGroupMask);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00023BC8 File Offset: 0x00021DC8
		internal readonly void SetRawMeshGroupMask_LegacyDoNotUse(ulong nBody)
		{
			this.NullCheck("SetRawMeshGroupMask_LegacyDoNotUse");
			method cbseAn_SetRawMeshGroupMask_LegacyDoNotUse = C_BaseAnimating.__N.CBseAn_SetRawMeshGroupMask_LegacyDoNotUse;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBody, cbseAn_SetRawMeshGroupMask_LegacyDoNotUse);
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00023BF4 File Offset: 0x00021DF4
		internal readonly int GetSkinCount()
		{
			this.NullCheck("GetSkinCount");
			method cbseAn_GetSkinCount = C_BaseAnimating.__N.CBseAn_GetSkinCount;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_GetSkinCount);
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00023C20 File Offset: 0x00021E20
		internal readonly void SetSkin(int iSkin)
		{
			this.NullCheck("SetSkin");
			method cbseAn_SetSkin = C_BaseAnimating.__N.CBseAn_SetSkin;
			calli(System.Void(System.IntPtr,System.Int32), this.self, iSkin, cbseAn_SetSkin);
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00023C4C File Offset: 0x00021E4C
		internal readonly void SetSkin(string skinName)
		{
			this.NullCheck("SetSkin");
			method cbseAn_f = C_BaseAnimating.__N.CBseAn_f7;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(skinName), cbseAn_f);
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00023C7C File Offset: 0x00021E7C
		internal readonly int GetS1Skin()
		{
			this.NullCheck("GetS1Skin");
			method cbseAn_GetS1Skin = C_BaseAnimating.__N.CBseAn_GetS1Skin;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_GetS1Skin);
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00023CA8 File Offset: 0x00021EA8
		internal readonly CollisionProperty CollisionProp()
		{
			this.NullCheck("CollisionProp");
			method cbseAn_CollisionProp = C_BaseAnimating.__N.CBseAn_CollisionProp;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseAn_CollisionProp);
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00023CD8 File Offset: 0x00021ED8
		internal readonly void SetRenderAlpha(byte alpha)
		{
			this.NullCheck("SetRenderAlpha");
			method cbseAn_SetRenderAlpha = C_BaseAnimating.__N.CBseAn_SetRenderAlpha;
			calli(System.Void(System.IntPtr,System.Byte), this.self, alpha, cbseAn_SetRenderAlpha);
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00023D04 File Offset: 0x00021F04
		internal readonly byte GetRenderAlpha()
		{
			this.NullCheck("GetRenderAlpha");
			method cbseAn_GetRenderAlpha = C_BaseAnimating.__N.CBseAn_GetRenderAlpha;
			return calli(System.Byte(System.IntPtr), this.self, cbseAn_GetRenderAlpha);
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00023D30 File Offset: 0x00021F30
		internal readonly void SetRenderColor(byte r, byte g, byte b)
		{
			this.NullCheck("SetRenderColor");
			method cbseAn_SetRenderColor = C_BaseAnimating.__N.CBseAn_SetRenderColor;
			calli(System.Void(System.IntPtr,System.Byte,System.Byte,System.Byte), this.self, r, g, b, cbseAn_SetRenderColor);
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00023D60 File Offset: 0x00021F60
		internal readonly void SetRenderColorAndAlpha(Color32 color)
		{
			this.NullCheck("SetRenderColorAndAlpha");
			method cbseAn_SetRenderColorAndAlpha = C_BaseAnimating.__N.CBseAn_SetRenderColorAndAlpha;
			calli(System.Void(System.IntPtr,Color32), this.self, color, cbseAn_SetRenderColorAndAlpha);
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00023D8C File Offset: 0x00021F8C
		internal readonly Color24 GetRenderColor()
		{
			this.NullCheck("GetRenderColor");
			method cbseAn_GetRenderColor = C_BaseAnimating.__N.CBseAn_GetRenderColor;
			return calli(Color24(System.IntPtr), this.self, cbseAn_GetRenderColor);
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00023DB8 File Offset: 0x00021FB8
		internal readonly CGlowProperty GlowProp()
		{
			this.NullCheck("GlowProp");
			method cbseAn_GlowProp = C_BaseAnimating.__N.CBseAn_GlowProp;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseAn_GlowProp);
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00023DE8 File Offset: 0x00021FE8
		internal readonly void SetSceneLayerID(string id)
		{
			this.NullCheck("SetSceneLayerID");
			method cbseAn_SetSceneLayerID = C_BaseAnimating.__N.CBseAn_SetSceneLayerID;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(id), cbseAn_SetSceneLayerID);
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00023E18 File Offset: 0x00022018
		internal readonly int GetSceneObjectCount()
		{
			this.NullCheck("GetSceneObjectCount");
			method cbseAn_GetSceneObjectCount = C_BaseAnimating.__N.CBseAn_GetSceneObjectCount;
			return calli(System.Int32(System.IntPtr), this.self, cbseAn_GetSceneObjectCount);
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00023E44 File Offset: 0x00022044
		internal readonly SceneObject GetSceneObject(int none)
		{
			this.NullCheck("GetSceneObject");
			method cbseAn_GetSceneObject = C_BaseAnimating.__N.CBseAn_GetSceneObject;
			return HandleIndex.Get<SceneObject>(calli(System.Int32(System.IntPtr,System.Int32), this.self, none, cbseAn_GetSceneObject));
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00023E74 File Offset: 0x00022074
		internal readonly Transform GetBoneTransform(int bone)
		{
			this.NullCheck("GetBoneTransform");
			method cbseAn_GetBoneTransform = C_BaseAnimating.__N.CBseAn_GetBoneTransform;
			return calli(Transform(System.IntPtr,System.Int32), this.self, bone, cbseAn_GetBoneTransform);
		}

		// Token: 0x0400009C RID: 156
		internal IntPtr self;

		// Token: 0x0200019F RID: 415
		internal static class __N
		{
			// Token: 0x04000813 RID: 2067
			internal static method From_C_BaseModelEntity_To_C_BaseAnimating;

			// Token: 0x04000814 RID: 2068
			internal static method To_C_BaseModelEntity_From_C_BaseAnimating;

			// Token: 0x04000815 RID: 2069
			internal static method From_C_BaseEntity_To_C_BaseAnimating;

			// Token: 0x04000816 RID: 2070
			internal static method To_C_BaseEntity_From_C_BaseAnimating;

			// Token: 0x04000817 RID: 2071
			internal static method From_CGameEntity_To_C_BaseAnimating;

			// Token: 0x04000818 RID: 2072
			internal static method To_CGameEntity_From_C_BaseAnimating;

			// Token: 0x04000819 RID: 2073
			internal static method From_CEntityInstance_To_C_BaseAnimating;

			// Token: 0x0400081A RID: 2074
			internal static method To_CEntityInstance_From_C_BaseAnimating;

			// Token: 0x0400081B RID: 2075
			internal static method From_IHandleEntity_To_C_BaseAnimating;

			// Token: 0x0400081C RID: 2076
			internal static method To_IHandleEntity_From_C_BaseAnimating;

			// Token: 0x0400081D RID: 2077
			internal static method CBseAn_GetPlaybackRate;

			// Token: 0x0400081E RID: 2078
			internal static method CBseAn_SetPlaybackRate;

			// Token: 0x0400081F RID: 2079
			internal static method CBseAn_GetCycle;

			// Token: 0x04000820 RID: 2080
			internal static method CBseAn_SetCycle;

			// Token: 0x04000821 RID: 2081
			internal static method CBseAn_Script_SetSequence;

			// Token: 0x04000822 RID: 2082
			internal static method CBseAn_Script_ResetSequence;

			// Token: 0x04000823 RID: 2083
			internal static method CBseAn_Script_GetSequence;

			// Token: 0x04000824 RID: 2084
			internal static method CBseAn_IsValidSequence;

			// Token: 0x04000825 RID: 2085
			internal static method CBseAn_IsSequenceFinished;

			// Token: 0x04000826 RID: 2086
			internal static method CBseAn_SequenceDuration;

			// Token: 0x04000827 RID: 2087
			internal static method CBseAn_Script_SequenceDuration;

			// Token: 0x04000828 RID: 2088
			internal static method CBseAn_SetShouldUseAnimGraph;

			// Token: 0x04000829 RID: 2089
			internal static method CBseAn_GetShouldUseAnimGraph;

			// Token: 0x0400082A RID: 2090
			internal static method CBseAn_SetOverrideGraphName;

			// Token: 0x0400082B RID: 2091
			internal static method CBseAn_GetOverrideGraphName;

			// Token: 0x0400082C RID: 2092
			internal static method CBseAn_UseAnimGraph;

			// Token: 0x0400082D RID: 2093
			internal static method CBseAn_HasAnimGraph;

			// Token: 0x0400082E RID: 2094
			internal static method CBseAn_GetBoolGraphParameter;

			// Token: 0x0400082F RID: 2095
			internal static method CBseAn_GetFloatGraphParameter;

			// Token: 0x04000830 RID: 2096
			internal static method CBseAn_GetVectorGraphParameter;

			// Token: 0x04000831 RID: 2097
			internal static method CBseAn_GetIntGraphParameter;

			// Token: 0x04000832 RID: 2098
			internal static method CBseAn_SetGraphParameter;

			// Token: 0x04000833 RID: 2099
			internal static method CBseAn_f2;

			// Token: 0x04000834 RID: 2100
			internal static method CBseAn_f3;

			// Token: 0x04000835 RID: 2101
			internal static method CBseAn_f4;

			// Token: 0x04000836 RID: 2102
			internal static method CBseAn_f5;

			// Token: 0x04000837 RID: 2103
			internal static method CBseAn_SetGraphParameterFromString;

			// Token: 0x04000838 RID: 2104
			internal static method CBseAn_SetMasterBlendAmountEasing;

			// Token: 0x04000839 RID: 2105
			internal static method CBseAn_GetMasterBlendAmountEasing;

			// Token: 0x0400083A RID: 2106
			internal static method CBseAn_IsAnimGraphUpdateEnabled;

			// Token: 0x0400083B RID: 2107
			internal static method CBseAn_SetAnimGraphUpdateEnabled;

			// Token: 0x0400083C RID: 2108
			internal static method CBseAn_ResetGraphParameters;

			// Token: 0x0400083D RID: 2109
			internal static method CBseAn_EnableIK;

			// Token: 0x0400083E RID: 2110
			internal static method CBseAn_GetRootMotion;

			// Token: 0x0400083F RID: 2111
			internal static method CBseAn_GetRootMotionAngle;

			// Token: 0x04000840 RID: 2112
			internal static method CBseAn_GetSkeletonInstance;

			// Token: 0x04000841 RID: 2113
			internal static method CBseAn_SetModelScale;

			// Token: 0x04000842 RID: 2114
			internal static method CBseAn_GetModelScale;

			// Token: 0x04000843 RID: 2115
			internal static method CBseAn_GetNumBones;

			// Token: 0x04000844 RID: 2116
			internal static method CBseAn_LookupBone;

			// Token: 0x04000845 RID: 2117
			internal static method CBseAn_GetAttachmentCount;

			// Token: 0x04000846 RID: 2118
			internal static method CBseAn_GetMinFadeDist;

			// Token: 0x04000847 RID: 2119
			internal static method CBseAn_GetMaxFadeDist;

			// Token: 0x04000848 RID: 2120
			internal static method CBseAn_SetModel;

			// Token: 0x04000849 RID: 2121
			internal static method CBseAn_SetModelAsync;

			// Token: 0x0400084A RID: 2122
			internal static method CBseAn_GetModel;

			// Token: 0x0400084B RID: 2123
			internal static method CBseAn_f6;

			// Token: 0x0400084C RID: 2124
			internal static method CBseAn_SetBodygroup;

			// Token: 0x0400084D RID: 2125
			internal static method CBseAn_SetBodygroupByName;

			// Token: 0x0400084E RID: 2126
			internal static method CBseAn_GetRawMeshGroupMask;

			// Token: 0x0400084F RID: 2127
			internal static method CBseAn_SetRawMeshGroupMask_LegacyDoNotUse;

			// Token: 0x04000850 RID: 2128
			internal static method CBseAn_GetSkinCount;

			// Token: 0x04000851 RID: 2129
			internal static method CBseAn_SetSkin;

			// Token: 0x04000852 RID: 2130
			internal static method CBseAn_f7;

			// Token: 0x04000853 RID: 2131
			internal static method CBseAn_GetS1Skin;

			// Token: 0x04000854 RID: 2132
			internal static method CBseAn_CollisionProp;

			// Token: 0x04000855 RID: 2133
			internal static method CBseAn_SetRenderAlpha;

			// Token: 0x04000856 RID: 2134
			internal static method CBseAn_GetRenderAlpha;

			// Token: 0x04000857 RID: 2135
			internal static method CBseAn_SetRenderColor;

			// Token: 0x04000858 RID: 2136
			internal static method CBseAn_SetRenderColorAndAlpha;

			// Token: 0x04000859 RID: 2137
			internal static method CBseAn_GetRenderColor;

			// Token: 0x0400085A RID: 2138
			internal static method CBseAn_GlowProp;

			// Token: 0x0400085B RID: 2139
			internal static method CBseAn_SetSceneLayerID;

			// Token: 0x0400085C RID: 2140
			internal static method CBseAn_GetSceneObjectCount;

			// Token: 0x0400085D RID: 2141
			internal static method CBseAn_GetSceneObject;

			// Token: 0x0400085E RID: 2142
			internal static method CBseAn_GetBoneTransform;
		}
	}
}
