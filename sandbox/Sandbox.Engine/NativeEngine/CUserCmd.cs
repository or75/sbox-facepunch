using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NativeEngine
{
	// Token: 0x02000273 RID: 627
	internal struct CUserCmd
	{
		// Token: 0x06000F5F RID: 3935 RVA: 0x0001B520 File Offset: 0x00019720
		internal TrackedObjects GetTrackedObject(int i)
		{
			switch (i)
			{
			case 0:
				return this.trackedObject1;
			case 1:
				return this.trackedObject2;
			case 2:
				return this.trackedObject3;
			case 3:
				return this.trackedObject4;
			case 4:
				return this.trackedObject5;
			case 5:
				return this.trackedObject6;
			case 6:
				return this.trackedObject7;
			case 7:
				return this.trackedObject8;
			case 8:
				return this.trackedObject9;
			case 9:
				return this.trackedObject10;
			default:
				return default(TrackedObjects);
			}
		}

		// Token: 0x04001197 RID: 4503
		public int command_number;

		// Token: 0x04001198 RID: 4504
		public int tick_count;

		// Token: 0x04001199 RID: 4505
		public Angles viewangles;

		// Token: 0x0400119A RID: 4506
		public Vector3 move;

		// Token: 0x0400119B RID: 4507
		public ulong buttons;

		// Token: 0x0400119C RID: 4508
		public ulong lastbuttons;

		// Token: 0x0400119D RID: 4509
		public int random_seed;

		// Token: 0x0400119E RID: 4510
		public short mousedx;

		// Token: 0x0400119F RID: 4511
		public short mousedy;

		// Token: 0x040011A0 RID: 4512
		public short mousewheel;

		// Token: 0x040011A1 RID: 4513
		public int SelectionIndex;

		// Token: 0x040011A2 RID: 4514
		public int SelectionSubIndex;

		// Token: 0x040011A3 RID: 4515
		public byte hasbeenpredicted;

		// Token: 0x040011A4 RID: 4516
		public Vector3 cursor_origin;

		// Token: 0x040011A5 RID: 4517
		public Vector3 cursor_aim;

		// Token: 0x040011A6 RID: 4518
		public Vector3 viewpos;

		// Token: 0x040011A7 RID: 4519
		public byte usingcontroller;

		// Token: 0x040011A8 RID: 4520
		public Vector2 analog_action_move;

		// Token: 0x040011A9 RID: 4521
		public Vector2 analog_action_look;

		// Token: 0x040011AA RID: 4522
		public Vector2 analog_action_trigger;

		// Token: 0x040011AB RID: 4523
		public byte hmd_active;

		// Token: 0x040011AC RID: 4524
		public byte hmd_targeting_mode;

		// Token: 0x040011AD RID: 4525
		public byte hmd_controller_type;

		// Token: 0x040011AE RID: 4526
		[FixedBuffer(typeof(byte), 2)]
		public CUserCmd.<hmd_controllers_active>e__FixedBuffer hmd_controllers_active;

		// Token: 0x040011AF RID: 4527
		public HandInfo_t LeftHandInfo;

		// Token: 0x040011B0 RID: 4528
		public HandInfo_t RightHandInfo;

		// Token: 0x040011B1 RID: 4529
		[FixedBuffer(typeof(byte), 2)]
		public CUserCmd.<hmd_controller_supports_skeleton>e__FixedBuffer hmd_controller_supports_skeleton;

		// Token: 0x040011B2 RID: 4530
		public Vector3 hmd_middle_eye_local;

		// Token: 0x040011B3 RID: 4531
		public Angles hmd_viewangles_local;

		// Token: 0x040011B4 RID: 4532
		public VrInputDigitalActions_t digital_action_data_left;

		// Token: 0x040011B5 RID: 4533
		public VrInputDigitalActions_t digital_action_data_right;

		// Token: 0x040011B6 RID: 4534
		public VrInputDigitalActions_t digital_action_data_gamepad;

		// Token: 0x040011B7 RID: 4535
		public VrInputAnalogActions_t analog_action_data_left;

		// Token: 0x040011B8 RID: 4536
		public VrInputAnalogActions_t analog_action_data_right;

		// Token: 0x040011B9 RID: 4537
		public VrInputAnalogActions_t analog_action_data_gamepad;

		// Token: 0x040011BA RID: 4538
		public VrInputSkeletalActionData_t skeletal_action_data_left;

		// Token: 0x040011BB RID: 4539
		public VrInputSkeletalActionData_t skeletal_action_data_right;

		// Token: 0x040011BC RID: 4540
		public VrSkeletalSummaryData_t skeletal_summary_data_left;

		// Token: 0x040011BD RID: 4541
		public VrSkeletalSummaryData_t skeletal_summary_data_right;

		// Token: 0x040011BE RID: 4542
		public uint vr_bone_count_left;

		// Token: 0x040011BF RID: 4543
		public uint vr_bone_count_right;

		// Token: 0x040011C0 RID: 4544
		public byte vr_bone_source_left;

		// Token: 0x040011C1 RID: 4545
		public byte vr_bone_source_right;

		// Token: 0x040011C2 RID: 4546
		public uint vr_compressed_bone_transforms_size_left;

		// Token: 0x040011C3 RID: 4547
		public uint vr_compressed_bone_transforms_size_right;

		// Token: 0x040011C4 RID: 4548
		[FixedBuffer(typeof(byte), 64)]
		public CUserCmd.<vr_compressed_bone_transforms_left>e__FixedBuffer vr_compressed_bone_transforms_left;

		// Token: 0x040011C5 RID: 4549
		[FixedBuffer(typeof(byte), 64)]
		public CUserCmd.<vr_compressed_bone_transforms_right>e__FixedBuffer vr_compressed_bone_transforms_right;

		// Token: 0x040011C6 RID: 4550
		public byte numTrackedObjects;

		// Token: 0x040011C7 RID: 4551
		public TrackedObjects trackedObject1;

		// Token: 0x040011C8 RID: 4552
		public TrackedObjects trackedObject2;

		// Token: 0x040011C9 RID: 4553
		public TrackedObjects trackedObject3;

		// Token: 0x040011CA RID: 4554
		public TrackedObjects trackedObject4;

		// Token: 0x040011CB RID: 4555
		public TrackedObjects trackedObject5;

		// Token: 0x040011CC RID: 4556
		public TrackedObjects trackedObject6;

		// Token: 0x040011CD RID: 4557
		public TrackedObjects trackedObject7;

		// Token: 0x040011CE RID: 4558
		public TrackedObjects trackedObject8;

		// Token: 0x040011CF RID: 4559
		public TrackedObjects trackedObject9;

		// Token: 0x040011D0 RID: 4560
		public TrackedObjects trackedObject10;

		// Token: 0x020003AF RID: 943
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 2)]
		public struct <hmd_controller_supports_skeleton>e__FixedBuffer
		{
			// Token: 0x040018D5 RID: 6357
			public byte FixedElementField;
		}

		// Token: 0x020003B0 RID: 944
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 2)]
		public struct <hmd_controllers_active>e__FixedBuffer
		{
			// Token: 0x040018D6 RID: 6358
			public byte FixedElementField;
		}

		// Token: 0x020003B1 RID: 945
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 64)]
		public struct <vr_compressed_bone_transforms_left>e__FixedBuffer
		{
			// Token: 0x040018D7 RID: 6359
			public byte FixedElementField;
		}

		// Token: 0x020003B2 RID: 946
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 64)]
		public struct <vr_compressed_bone_transforms_right>e__FixedBuffer
		{
			// Token: 0x040018D8 RID: 6360
			public byte FixedElementField;
		}
	}
}
