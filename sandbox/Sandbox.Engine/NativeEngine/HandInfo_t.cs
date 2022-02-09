using System;

namespace NativeEngine
{
	// Token: 0x0200027B RID: 635
	internal struct HandInfo_t
	{
		// Token: 0x040011E8 RID: 4584
		public Vector3 m_vPosition;

		// Token: 0x040011E9 RID: 4585
		public Angles m_Angles;

		// Token: 0x040011EA RID: 4586
		public Vector3 m_vVelocity;

		// Token: 0x040011EB RID: 4587
		public float m_flSampleTime;

		// Token: 0x040011EC RID: 4588
		public Vector3 m_vFilteredVelocity;

		// Token: 0x040011ED RID: 4589
		public Vector3 m_FilteredAngularVel;

		// Token: 0x040011EE RID: 4590
		public Vector3 m_vFilteredThrowVel;

		// Token: 0x040011EF RID: 4591
		public float m_flTriggerAnalogValue;

		// Token: 0x040011F0 RID: 4592
		public float m_flGripAnalogValue;

		// Token: 0x040011F1 RID: 4593
		public float m_flFinger0;

		// Token: 0x040011F2 RID: 4594
		public float m_flFinger1;

		// Token: 0x040011F3 RID: 4595
		public float m_flFinger2;

		// Token: 0x040011F4 RID: 4596
		public float m_flFinger3;

		// Token: 0x040011F5 RID: 4597
		public float m_flFinger4;

		// Token: 0x040011F6 RID: 4598
		public float m_flFingerSplay0;

		// Token: 0x040011F7 RID: 4599
		public float m_flFingerSplay1;

		// Token: 0x040011F8 RID: 4600
		public float m_flFingerSplay2;

		// Token: 0x040011F9 RID: 4601
		public float m_flFingerSplay3;

		// Token: 0x040011FA RID: 4602
		public float m_flTrackpadAnalogValueX;

		// Token: 0x040011FB RID: 4603
		public float m_flTrackpadAnalogValueY;

		// Token: 0x040011FC RID: 4604
		public float m_flJoystickAnalogValueX;

		// Token: 0x040011FD RID: 4605
		public float m_flJoystickAnalogValueY;
	}
}
