using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NativeEngine;
using Sandbox;

namespace Managed.SourceServer
{
	// Token: 0x0200000E RID: 14
	internal static class Exports
	{
		/// <summary>
		/// Sandbox.ClientEntity.OnNativeEntity( ... )
		/// </summary>
		// Token: 0x06000039 RID: 57 RVA: 0x00002CCC File Offset: 0x00000ECC
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_OnNativeEntity(uint self, IntPtr entinst)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.OnNativeEntity(entinst);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "OnNativeEntity", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalDestruct( ... )
		/// </summary>
		// Token: 0x0600003A RID: 58 RVA: 0x00002D18 File Offset: 0x00000F18
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalDestruct(uint self)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalDestruct();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalDestruct", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalUpdateOnRemove( ... )
		/// </summary>
		// Token: 0x0600003B RID: 59 RVA: 0x00002D5C File Offset: 0x00000F5C
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalUpdateOnRemove(uint self)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalUpdateOnRemove();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalUpdateOnRemove", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.EnterPVSInternal( ... )
		/// </summary>
		// Token: 0x0600003C RID: 60 RVA: 0x00002DA0 File Offset: 0x00000FA0
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_EnterPVSInternal(uint self)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.EnterPVSInternal();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "EnterPVSInternal", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.LeavePVSInternal( ... )
		/// </summary>
		// Token: 0x0600003D RID: 61 RVA: 0x00002DE4 File Offset: 0x00000FE4
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_LeavePVSInternal(uint self)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.LeavePVSInternal();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "LeavePVSInternal", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalClientCreated( ... )
		/// </summary>
		// Token: 0x0600003E RID: 62 RVA: 0x00002E28 File Offset: 0x00001028
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalClientCreated(uint self)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalClientCreated();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalClientCreated", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalClientActivate( ... )
		/// </summary>
		// Token: 0x0600003F RID: 63 RVA: 0x00002E6C File Offset: 0x0000106C
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalClientActivate(uint self)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalClientActivate();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalClientActivate", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalEntityKeyValue( ... )
		/// </summary>
		// Token: 0x06000040 RID: 64 RVA: 0x00002EB0 File Offset: 0x000010B0
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalEntityKeyValue(uint self, uint nameToken, IntPtr value, int type)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalEntityKeyValue(nameToken, Interop.GetString(value), type);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalEntityKeyValue", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalEntityConnection( ... )
		/// </summary>
		// Token: 0x06000041 RID: 65 RVA: 0x00002EFC File Offset: 0x000010FC
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalEntityConnection(uint self, IntPtr OutputName, long targetType, IntPtr TargetName, IntPtr InputName, IntPtr OverrideParam, float Delay, int TimesToFire)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalEntityConnection(Interop.GetString(OutputName), (EntityIOTargetType)targetType, Interop.GetString(TargetName), Interop.GetString(InputName), Interop.GetString(OverrideParam), Delay, TimesToFire);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalEntityConnection", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalSpawn( ... )
		/// </summary>
		// Token: 0x06000042 RID: 66 RVA: 0x00002F60 File Offset: 0x00001160
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalSpawn(uint self)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalSpawn();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalSpawn", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalStartTouch( ... )
		/// </summary>
		// Token: 0x06000043 RID: 67 RVA: 0x00002FA4 File Offset: 0x000011A4
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalStartTouch(uint self, uint ent)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalStartTouch(InteropSystem.Get<Entity>(ent));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalStartTouch", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalOnTouch( ... )
		/// </summary>
		// Token: 0x06000044 RID: 68 RVA: 0x00002FF0 File Offset: 0x000011F0
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalOnTouch(uint self, uint ent)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalOnTouch(InteropSystem.Get<Entity>(ent));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalOnTouch", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalEndTouch( ... )
		/// </summary>
		// Token: 0x06000045 RID: 69 RVA: 0x0000303C File Offset: 0x0000123C
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalEndTouch(uint self, uint ent)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalEndTouch(InteropSystem.Get<Entity>(ent));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalEndTouch", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalOnParentChanged( ... )
		/// </summary>
		// Token: 0x06000046 RID: 70 RVA: 0x00003088 File Offset: 0x00001288
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalOnParentChanged(uint self, uint ent)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalOnParentChanged(InteropSystem.Get<Entity>(ent));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalOnParentChanged", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalPreDataUpdate( ... )
		/// </summary>
		// Token: 0x06000047 RID: 71 RVA: 0x000030D4 File Offset: 0x000012D4
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalPreDataUpdate(uint self)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalPreDataUpdate();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalPreDataUpdate", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalPostDataUpdate( ... )
		/// </summary>
		// Token: 0x06000048 RID: 72 RVA: 0x00003118 File Offset: 0x00001318
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalPostDataUpdate(uint self, int hash)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalPostDataUpdate(hash);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalPostDataUpdate", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalNetworkVariableChanged( ... )
		/// </summary>
		// Token: 0x06000049 RID: 73 RVA: 0x00003160 File Offset: 0x00001360
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalNetworkVariableChanged(uint self, int hash, int slot, IntPtr data, int dataSize)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalNetworkVariableChanged(hash, slot, data, dataSize);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalNetworkVariableChanged", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalOnNewModel( ... )
		/// </summary>
		// Token: 0x0600004A RID: 74 RVA: 0x000031AC File Offset: 0x000013AC
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalOnNewModel(uint self)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalOnNewModel();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalOnNewModel", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalAnimEvent( ... )
		/// </summary>
		// Token: 0x0600004B RID: 75 RVA: 0x000031F0 File Offset: 0x000013F0
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalAnimEvent(uint self, IntPtr name, int intData, float floatData, Vector3 vectorData, IntPtr stringData)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalAnimEvent(Interop.GetString(name), intData, floatData, vectorData, Interop.GetString(stringData));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalAnimEvent", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalAnimEventFootstep( ... )
		/// </summary>
		// Token: 0x0600004C RID: 76 RVA: 0x00003248 File Offset: 0x00001448
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalAnimEventFootstep(uint self, Vector3 pos, int foot, float volume)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalAnimEventFootstep(pos, foot, volume);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalAnimEventFootstep", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalPostClientActive( ... )
		/// </summary>
		// Token: 0x0600004D RID: 77 RVA: 0x00003290 File Offset: 0x00001490
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalPostClientActive(uint self)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalPostClientActive();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalPostClientActive", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalOnSequenceFinished( ... )
		/// </summary>
		// Token: 0x0600004E RID: 78 RVA: 0x000032D4 File Offset: 0x000014D4
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalOnSequenceFinished(uint self, int bLooped)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalOnSequenceFinished(bLooped != 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalOnSequenceFinished", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalOnNewSequence( ... )
		/// </summary>
		// Token: 0x0600004F RID: 79 RVA: 0x0000331C File Offset: 0x0000151C
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalOnNewSequence(uint self)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalOnNewSequence();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalOnNewSequence", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.PredictionStore( ... )
		/// </summary>
		// Token: 0x06000050 RID: 80 RVA: 0x00003360 File Offset: 0x00001560
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_PredictionStore(uint self, int slot, int command, int network, int notnetworked)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.PredictionStore(slot, command, network != 0, notnetworked != 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "PredictionStore", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.PredictionRestore( ... )
		/// </summary>
		// Token: 0x06000051 RID: 81 RVA: 0x000033B0 File Offset: 0x000015B0
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_PredictionRestore(uint self, int slot, int network, int notnetworked)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.PredictionRestore(slot, network != 0, notnetworked != 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "PredictionRestore", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.PredictionVerify( ... )
		/// </summary>
		// Token: 0x06000052 RID: 82 RVA: 0x00003400 File Offset: 0x00001600
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_PredictionVerify(uint self, int slot, int command)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.PredictionVerify(slot, command);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "PredictionVerify", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.PredictionDestroy( ... )
		/// </summary>
		// Token: 0x06000053 RID: 83 RVA: 0x00003448 File Offset: 0x00001648
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_PredictionDestroy(uint self)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.PredictionDestroy();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "PredictionDestroy", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.PredictionShift( ... )
		/// </summary>
		// Token: 0x06000054 RID: 84 RVA: 0x0000348C File Offset: 0x0000168C
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_PredictionShift(uint self, int slots)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.PredictionShift(slots);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "PredictionShift", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalMoveDone( ... )
		/// </summary>
		// Token: 0x06000055 RID: 85 RVA: 0x000034D4 File Offset: 0x000016D4
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalMoveDone(uint self)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalMoveDone();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalMoveDone", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalMoveBlocked( ... )
		/// </summary>
		// Token: 0x06000056 RID: 86 RVA: 0x00003518 File Offset: 0x00001718
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalMoveBlocked(uint self, uint ent)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalMoveBlocked(InteropSystem.Get<Entity>(ent));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalMoveBlocked", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalOnSetDormant( ... )
		/// </summary>
		// Token: 0x06000057 RID: 87 RVA: 0x00003564 File Offset: 0x00001764
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalOnSetDormant(uint self, int dormant)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalOnSetDormant(dormant != 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalOnSetDormant", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalPhysicsCollisionEvent( ... )
		/// </summary>
		// Token: 0x06000058 RID: 88 RVA: 0x000035AC File Offset: 0x000017AC
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalPhysicsCollisionEvent(uint self, uint hitEntity, Vector3 contactPoint, Vector3 contactSpeed, Vector3 surfaceNormal, Vector3 preVelocity, Vector3 postVelocity, Vector3 preAngularVelocity, float collisionSpeed)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalPhysicsCollisionEvent(InteropSystem.Get<Entity>(hitEntity), contactPoint, contactSpeed, surfaceNormal, preVelocity, postVelocity, preAngularVelocity, collisionSpeed);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalPhysicsCollisionEvent", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.PlayerSetupVisibility( ... )
		/// </summary>
		// Token: 0x06000059 RID: 89 RVA: 0x00003604 File Offset: 0x00001804
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_PlayerSetupVisibility(uint self, int spawngroup, IntPtr visInfo)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.PlayerSetupVisibility(spawngroup, visInfo);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "PlayerSetupVisibility", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalOnAnimGraphTag( ... )
		/// </summary>
		// Token: 0x0600005A RID: 90 RVA: 0x0000364C File Offset: 0x0000184C
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalOnAnimGraphTag(uint self, IntPtr tag, int fireType)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalOnAnimGraphTag(Interop.GetString(tag), fireType);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalOnAnimGraphTag", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalOnAnimGraphCreated( ... )
		/// </summary>
		// Token: 0x0600005B RID: 91 RVA: 0x00003698 File Offset: 0x00001898
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalOnAnimGraphCreated(uint self)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalOnAnimGraphCreated();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalOnAnimGraphCreated", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ClientEntity.InternalOnNameChanged( ... )
		/// </summary>
		// Token: 0x0600005C RID: 92 RVA: 0x000036DC File Offset: 0x000018DC
		[UnmanagedCallersOnly]
		internal static void Sandbo_ClentE_InternalOnNameChanged(uint self, IntPtr name)
		{
			try
			{
				ClientEntity instance;
				if (InteropSystem.TryGetObject<ClientEntity>(self, out instance))
				{
					instance.InternalOnNameChanged(Interop.GetString(name));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ClientEntity", "InternalOnNameChanged", ___e);
			}
		}

		/// <summary>
		/// Sandbox.ConsoleSystem.DispatchCommand( ... )
		/// </summary>
		// Token: 0x0600005D RID: 93 RVA: 0x00003728 File Offset: 0x00001928
		[UnmanagedCallersOnly]
		internal static void Sandbo_CnsleS_DispatchCommand(IntPtr name, IntPtr args, long flags, int client)
		{
			try
			{
				ConsoleSystem.DispatchCommand(Interop.GetString(name), Interop.GetString(args), flags, client);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.ConsoleSystem", "DispatchCommand", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.OnNativeEntity( ... )
		/// </summary>
		// Token: 0x0600005E RID: 94 RVA: 0x00003770 File Offset: 0x00001970
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_OnNativeEntity(uint self, IntPtr entinst)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.OnNativeEntity(entinst);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "OnNativeEntity", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalDestruct( ... )
		/// </summary>
		// Token: 0x0600005F RID: 95 RVA: 0x000037BC File Offset: 0x000019BC
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalDestruct(uint self)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalDestruct();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalDestruct", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalUpdateOnRemove( ... )
		/// </summary>
		// Token: 0x06000060 RID: 96 RVA: 0x00003800 File Offset: 0x00001A00
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalUpdateOnRemove(uint self)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalUpdateOnRemove();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalUpdateOnRemove", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.EnterPVSInternal( ... )
		/// </summary>
		// Token: 0x06000061 RID: 97 RVA: 0x00003844 File Offset: 0x00001A44
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_EnterPVSInternal(uint self)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.EnterPVSInternal();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "EnterPVSInternal", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.LeavePVSInternal( ... )
		/// </summary>
		// Token: 0x06000062 RID: 98 RVA: 0x00003888 File Offset: 0x00001A88
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_LeavePVSInternal(uint self)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.LeavePVSInternal();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "LeavePVSInternal", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalClientCreated( ... )
		/// </summary>
		// Token: 0x06000063 RID: 99 RVA: 0x000038CC File Offset: 0x00001ACC
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalClientCreated(uint self)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalClientCreated();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalClientCreated", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalClientActivate( ... )
		/// </summary>
		// Token: 0x06000064 RID: 100 RVA: 0x00003910 File Offset: 0x00001B10
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalClientActivate(uint self)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalClientActivate();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalClientActivate", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalEntityKeyValue( ... )
		/// </summary>
		// Token: 0x06000065 RID: 101 RVA: 0x00003954 File Offset: 0x00001B54
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalEntityKeyValue(uint self, uint nameToken, IntPtr value, int type)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalEntityKeyValue(nameToken, Interop.GetString(value), type);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalEntityKeyValue", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalEntityConnection( ... )
		/// </summary>
		// Token: 0x06000066 RID: 102 RVA: 0x000039A0 File Offset: 0x00001BA0
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalEntityConnection(uint self, IntPtr OutputName, long targetType, IntPtr TargetName, IntPtr InputName, IntPtr OverrideParam, float Delay, int TimesToFire)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalEntityConnection(Interop.GetString(OutputName), (EntityIOTargetType)targetType, Interop.GetString(TargetName), Interop.GetString(InputName), Interop.GetString(OverrideParam), Delay, TimesToFire);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalEntityConnection", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalSpawn( ... )
		/// </summary>
		// Token: 0x06000067 RID: 103 RVA: 0x00003A04 File Offset: 0x00001C04
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalSpawn(uint self)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalSpawn();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalSpawn", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalStartTouch( ... )
		/// </summary>
		// Token: 0x06000068 RID: 104 RVA: 0x00003A48 File Offset: 0x00001C48
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalStartTouch(uint self, uint ent)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalStartTouch(InteropSystem.Get<Entity>(ent));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalStartTouch", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalOnTouch( ... )
		/// </summary>
		// Token: 0x06000069 RID: 105 RVA: 0x00003A94 File Offset: 0x00001C94
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalOnTouch(uint self, uint ent)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalOnTouch(InteropSystem.Get<Entity>(ent));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalOnTouch", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalEndTouch( ... )
		/// </summary>
		// Token: 0x0600006A RID: 106 RVA: 0x00003AE0 File Offset: 0x00001CE0
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalEndTouch(uint self, uint ent)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalEndTouch(InteropSystem.Get<Entity>(ent));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalEndTouch", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalOnParentChanged( ... )
		/// </summary>
		// Token: 0x0600006B RID: 107 RVA: 0x00003B2C File Offset: 0x00001D2C
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalOnParentChanged(uint self, uint ent)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalOnParentChanged(InteropSystem.Get<Entity>(ent));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalOnParentChanged", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalPreDataUpdate( ... )
		/// </summary>
		// Token: 0x0600006C RID: 108 RVA: 0x00003B78 File Offset: 0x00001D78
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalPreDataUpdate(uint self)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalPreDataUpdate();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalPreDataUpdate", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalPostDataUpdate( ... )
		/// </summary>
		// Token: 0x0600006D RID: 109 RVA: 0x00003BBC File Offset: 0x00001DBC
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalPostDataUpdate(uint self, int hash)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalPostDataUpdate(hash);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalPostDataUpdate", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalNetworkVariableChanged( ... )
		/// </summary>
		// Token: 0x0600006E RID: 110 RVA: 0x00003C04 File Offset: 0x00001E04
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalNetworkVariableChanged(uint self, int hash, int slot, IntPtr data, int dataSize)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalNetworkVariableChanged(hash, slot, data, dataSize);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalNetworkVariableChanged", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalOnNewModel( ... )
		/// </summary>
		// Token: 0x0600006F RID: 111 RVA: 0x00003C50 File Offset: 0x00001E50
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalOnNewModel(uint self)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalOnNewModel();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalOnNewModel", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalAnimEvent( ... )
		/// </summary>
		// Token: 0x06000070 RID: 112 RVA: 0x00003C94 File Offset: 0x00001E94
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalAnimEvent(uint self, IntPtr name, int intData, float floatData, Vector3 vectorData, IntPtr stringData)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalAnimEvent(Interop.GetString(name), intData, floatData, vectorData, Interop.GetString(stringData));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalAnimEvent", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalAnimEventFootstep( ... )
		/// </summary>
		// Token: 0x06000071 RID: 113 RVA: 0x00003CEC File Offset: 0x00001EEC
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalAnimEventFootstep(uint self, Vector3 pos, int foot, float volume)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalAnimEventFootstep(pos, foot, volume);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalAnimEventFootstep", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalPostClientActive( ... )
		/// </summary>
		// Token: 0x06000072 RID: 114 RVA: 0x00003D34 File Offset: 0x00001F34
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalPostClientActive(uint self)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalPostClientActive();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalPostClientActive", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalOnSequenceFinished( ... )
		/// </summary>
		// Token: 0x06000073 RID: 115 RVA: 0x00003D78 File Offset: 0x00001F78
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalOnSequenceFinished(uint self, int bLooped)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalOnSequenceFinished(bLooped != 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalOnSequenceFinished", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalOnNewSequence( ... )
		/// </summary>
		// Token: 0x06000074 RID: 116 RVA: 0x00003DC0 File Offset: 0x00001FC0
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalOnNewSequence(uint self)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalOnNewSequence();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalOnNewSequence", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.PredictionStore( ... )
		/// </summary>
		// Token: 0x06000075 RID: 117 RVA: 0x00003E04 File Offset: 0x00002004
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_PredictionStore(uint self, int slot, int command, int network, int notnetworked)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.PredictionStore(slot, command, network != 0, notnetworked != 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "PredictionStore", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.PredictionRestore( ... )
		/// </summary>
		// Token: 0x06000076 RID: 118 RVA: 0x00003E54 File Offset: 0x00002054
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_PredictionRestore(uint self, int slot, int network, int notnetworked)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.PredictionRestore(slot, network != 0, notnetworked != 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "PredictionRestore", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.PredictionVerify( ... )
		/// </summary>
		// Token: 0x06000077 RID: 119 RVA: 0x00003EA4 File Offset: 0x000020A4
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_PredictionVerify(uint self, int slot, int command)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.PredictionVerify(slot, command);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "PredictionVerify", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.PredictionDestroy( ... )
		/// </summary>
		// Token: 0x06000078 RID: 120 RVA: 0x00003EEC File Offset: 0x000020EC
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_PredictionDestroy(uint self)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.PredictionDestroy();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "PredictionDestroy", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.PredictionShift( ... )
		/// </summary>
		// Token: 0x06000079 RID: 121 RVA: 0x00003F30 File Offset: 0x00002130
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_PredictionShift(uint self, int slots)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.PredictionShift(slots);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "PredictionShift", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalMoveDone( ... )
		/// </summary>
		// Token: 0x0600007A RID: 122 RVA: 0x00003F78 File Offset: 0x00002178
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalMoveDone(uint self)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalMoveDone();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalMoveDone", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalMoveBlocked( ... )
		/// </summary>
		// Token: 0x0600007B RID: 123 RVA: 0x00003FBC File Offset: 0x000021BC
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalMoveBlocked(uint self, uint ent)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalMoveBlocked(InteropSystem.Get<Entity>(ent));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalMoveBlocked", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalOnSetDormant( ... )
		/// </summary>
		// Token: 0x0600007C RID: 124 RVA: 0x00004008 File Offset: 0x00002208
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalOnSetDormant(uint self, int dormant)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalOnSetDormant(dormant != 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalOnSetDormant", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalPhysicsCollisionEvent( ... )
		/// </summary>
		// Token: 0x0600007D RID: 125 RVA: 0x00004050 File Offset: 0x00002250
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalPhysicsCollisionEvent(uint self, uint hitEntity, Vector3 contactPoint, Vector3 contactSpeed, Vector3 surfaceNormal, Vector3 preVelocity, Vector3 postVelocity, Vector3 preAngularVelocity, float collisionSpeed)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalPhysicsCollisionEvent(InteropSystem.Get<Entity>(hitEntity), contactPoint, contactSpeed, surfaceNormal, preVelocity, postVelocity, preAngularVelocity, collisionSpeed);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalPhysicsCollisionEvent", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.PlayerSetupVisibility( ... )
		/// </summary>
		// Token: 0x0600007E RID: 126 RVA: 0x000040A8 File Offset: 0x000022A8
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_PlayerSetupVisibility(uint self, int spawngroup, IntPtr visInfo)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.PlayerSetupVisibility(spawngroup, visInfo);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "PlayerSetupVisibility", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalOnAnimGraphTag( ... )
		/// </summary>
		// Token: 0x0600007F RID: 127 RVA: 0x000040F0 File Offset: 0x000022F0
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalOnAnimGraphTag(uint self, IntPtr tag, int fireType)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalOnAnimGraphTag(Interop.GetString(tag), fireType);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalOnAnimGraphTag", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalOnAnimGraphCreated( ... )
		/// </summary>
		// Token: 0x06000080 RID: 128 RVA: 0x0000413C File Offset: 0x0000233C
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalOnAnimGraphCreated(uint self)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalOnAnimGraphCreated();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalOnAnimGraphCreated", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Entity.InternalOnNameChanged( ... )
		/// </summary>
		// Token: 0x06000081 RID: 129 RVA: 0x00004180 File Offset: 0x00002380
		[UnmanagedCallersOnly]
		internal static void Sandbo_Entity_InternalOnNameChanged(uint self, IntPtr name)
		{
			try
			{
				Entity instance;
				if (InteropSystem.TryGetObject<Entity>(self, out instance))
				{
					instance.InternalOnNameChanged(Interop.GetString(name));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Entity", "InternalOnNameChanged", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EntityManager.CreateServerEntity( ... )
		/// </summary>
		// Token: 0x06000082 RID: 130 RVA: 0x000041CC File Offset: 0x000023CC
		[UnmanagedCallersOnly]
		internal static IntPtr Sandbo_EnttyM_CreateServerEntity(IntPtr name)
		{
			IntPtr result;
			try
			{
				result = EntityManager.CreateServerEntity(Interop.GetString(name));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EntityManager", "CreateServerEntity", ___e);
				result = (IntPtr)0;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.EntityManager.CreateClientsideOfNetworkedEntity( ... )
		/// </summary>
		// Token: 0x06000083 RID: 131 RVA: 0x00004214 File Offset: 0x00002414
		[UnmanagedCallersOnly]
		internal static void Sandbo_EnttyM_CreateClientsideOfNetworkedEntity(IntPtr instance, int managedClassIdent)
		{
			try
			{
				EntityManager.CreateClientsideOfNetworkedEntity(instance, managedClassIdent);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EntityManager", "CreateClientsideOfNetworkedEntity", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.Init( ... )
		/// </summary>
		// Token: 0x06000084 RID: 132 RVA: 0x00004254 File Offset: 0x00002454
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_Init()
		{
			try
			{
				GameLoop.Init();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "Init", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.PreOnActivate( ... )
		/// </summary>
		// Token: 0x06000085 RID: 133 RVA: 0x0000428C File Offset: 0x0000248C
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_PreOnActivate()
		{
			try
			{
				GameLoop.PreOnActivate();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "PreOnActivate", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.PostOnActivate( ... )
		/// </summary>
		// Token: 0x06000086 RID: 134 RVA: 0x000042C4 File Offset: 0x000024C4
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_PostOnActivate()
		{
			try
			{
				GameLoop.PostOnActivate();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "PostOnActivate", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.OnDeactivate( ... )
		/// </summary>
		// Token: 0x06000087 RID: 135 RVA: 0x000042FC File Offset: 0x000024FC
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_OnDeactivate()
		{
			try
			{
				GameLoop.OnDeactivate();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "OnDeactivate", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.LoopShutdown( ... )
		/// </summary>
		// Token: 0x06000088 RID: 136 RVA: 0x00004334 File Offset: 0x00002534
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_LoopShutdown()
		{
			try
			{
				GameLoop.LoopShutdown();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "LoopShutdown", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.ClientPutInServer( ... )
		/// </summary>
		// Token: 0x06000089 RID: 137 RVA: 0x0000436C File Offset: 0x0000256C
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_ClientPutInServer(int entityId, IntPtr name, int fakePlayer)
		{
			try
			{
				GameLoop.ClientPutInServer(entityId, Interop.GetString(name), fakePlayer != 0);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "ClientPutInServer", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.ClientDisconnected( ... )
		/// </summary>
		// Token: 0x0600008A RID: 138 RVA: 0x000043B0 File Offset: 0x000025B0
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_ClientDisconnected(int entityId, int reason, IntPtr pszName, ulong steamid, IntPtr pszNetworkId)
		{
			try
			{
				GameLoop.ClientDisconnected(entityId, reason, Interop.GetString(pszName), steamid, Interop.GetString(pszNetworkId));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "ClientDisconnected", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.OnClientPreOutput( ... )
		/// </summary>
		// Token: 0x0600008B RID: 139 RVA: 0x000043F8 File Offset: 0x000025F8
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_OnClientPreOutput()
		{
			try
			{
				GameLoop.OnClientPreOutput();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "OnClientPreOutput", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.OnClientPostOutput( ... )
		/// </summary>
		// Token: 0x0600008C RID: 140 RVA: 0x00004430 File Offset: 0x00002630
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_OnClientPostOutput()
		{
			try
			{
				GameLoop.OnClientPostOutput();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "OnClientPostOutput", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.NotifyDisconnect( ... )
		/// </summary>
		// Token: 0x0600008D RID: 141 RVA: 0x00004468 File Offset: 0x00002668
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_NotifyDisconnect(int reasonCode, IntPtr reasonStr)
		{
			try
			{
				GameLoop.NotifyDisconnect(reasonCode, Interop.GetString(reasonStr));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "NotifyDisconnect", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.GetView( ... )
		/// </summary>
		// Token: 0x0600008E RID: 142 RVA: 0x000044A8 File Offset: 0x000026A8
		[UnmanagedCallersOnly]
		internal unsafe static void Sandbo_GameLo_GetView(IntPtr viewDesc)
		{
			try
			{
				GameLoop.GetView(Unsafe.AsRef<ViewDesc>((void*)viewDesc));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "GetView", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.PreRender( ... )
		/// </summary>
		// Token: 0x0600008F RID: 143 RVA: 0x000044EC File Offset: 0x000026EC
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_PreRender()
		{
			try
			{
				GameLoop.PreRender();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "PreRender", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.UpdateAudioListener( ... )
		/// </summary>
		// Token: 0x06000090 RID: 144 RVA: 0x00004524 File Offset: 0x00002724
		[UnmanagedCallersOnly]
		internal unsafe static void Sandbo_GameLo_UpdateAudioListener(IntPtr tx)
		{
			try
			{
				GameLoop.UpdateAudioListener(Unsafe.AsRef<Transform>((void*)tx));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "UpdateAudioListener", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.PhysicsThink( ... )
		/// </summary>
		// Token: 0x06000091 RID: 145 RVA: 0x00004568 File Offset: 0x00002768
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_PhysicsThink()
		{
			try
			{
				GameLoop.PhysicsThink();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "PhysicsThink", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.PrePhysicsStep( ... )
		/// </summary>
		// Token: 0x06000092 RID: 146 RVA: 0x000045A0 File Offset: 0x000027A0
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_PrePhysicsStep(float dt)
		{
			try
			{
				GameLoop.PrePhysicsStep(dt);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "PrePhysicsStep", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.PostPhysicsStep( ... )
		/// </summary>
		// Token: 0x06000093 RID: 147 RVA: 0x000045D8 File Offset: 0x000027D8
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_PostPhysicsStep(float dt)
		{
			try
			{
				GameLoop.PostPhysicsStep(dt);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "PostPhysicsStep", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.PhysicsImpactSound( ... )
		/// </summary>
		// Token: 0x06000094 RID: 148 RVA: 0x00004610 File Offset: 0x00002810
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_PhysicsImpactSound(int entity, Vector3 pos, float volume, float speed, int surfaceToken, int surfaceHitToken)
		{
			try
			{
				GameLoop.PhysicsImpactSound(entity, pos, volume, speed, surfaceToken, surfaceHitToken);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "PhysicsImpactSound", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.OnPhysicsJointBreak( ... )
		/// </summary>
		// Token: 0x06000095 RID: 149 RVA: 0x00004650 File Offset: 0x00002850
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_OnPhysicsJointBreak(int joint)
		{
			try
			{
				GameLoop.OnPhysicsJointBreak(HandleIndex.Get<PhysicsJoint>(joint));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "OnPhysicsJointBreak", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.RunBotCommands( ... )
		/// </summary>
		// Token: 0x06000096 RID: 150 RVA: 0x00004690 File Offset: 0x00002890
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_RunBotCommands()
		{
			try
			{
				GameLoop.RunBotCommands();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "RunBotCommands", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.ServerFrame_Think( ... )
		/// </summary>
		// Token: 0x06000097 RID: 151 RVA: 0x000046C8 File Offset: 0x000028C8
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_ServerFrame_Think()
		{
			try
			{
				GameLoop.ServerFrame_Think();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "ServerFrame_Think", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.ClientFrame_Think( ... )
		/// </summary>
		// Token: 0x06000098 RID: 152 RVA: 0x00004700 File Offset: 0x00002900
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_ClientFrame_Think()
		{
			try
			{
				GameLoop.ClientFrame_Think();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "ClientFrame_Think", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.PostEntitySpawn( ... )
		/// </summary>
		// Token: 0x06000099 RID: 153 RVA: 0x00004738 File Offset: 0x00002938
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_PostEntitySpawn()
		{
			try
			{
				GameLoop.PostEntitySpawn();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "PostEntitySpawn", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.Server_GetTimeScale( ... )
		/// </summary>
		// Token: 0x0600009A RID: 154 RVA: 0x00004770 File Offset: 0x00002970
		[UnmanagedCallersOnly]
		internal static float Sandbo_GameLo_Server_GetTimeScale()
		{
			float result;
			try
			{
				result = GameLoop.Server_GetTimeScale();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "Server_GetTimeScale", ___e);
				result = 0f;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.GameLoop.Server_GetTickRate( ... )
		/// </summary>
		// Token: 0x0600009B RID: 155 RVA: 0x000047B0 File Offset: 0x000029B0
		[UnmanagedCallersOnly]
		internal static float Sandbo_GameLo_Server_GetTickRate()
		{
			float result;
			try
			{
				result = GameLoop.Server_GetTickRate();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "Server_GetTickRate", ___e);
				result = 0f;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.GameLoop.OnFrameSimulateStart( ... )
		/// </summary>
		// Token: 0x0600009C RID: 156 RVA: 0x000047F0 File Offset: 0x000029F0
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_OnFrameSimulateStart()
		{
			try
			{
				GameLoop.OnFrameSimulateStart();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "OnFrameSimulateStart", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.OnFrameSimulateEnd( ... )
		/// </summary>
		// Token: 0x0600009D RID: 157 RVA: 0x00004828 File Offset: 0x00002A28
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_OnFrameSimulateEnd()
		{
			try
			{
				GameLoop.OnFrameSimulateEnd();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "OnFrameSimulateEnd", ___e);
			}
		}

		/// <summary>
		/// Sandbox.GameLoop.OnModelReloaded( ... )
		/// </summary>
		// Token: 0x0600009E RID: 158 RVA: 0x00004860 File Offset: 0x00002A60
		[UnmanagedCallersOnly]
		internal static void Sandbo_GameLo_OnModelReloaded(IntPtr hModel)
		{
			try
			{
				GameLoop.OnModelReloaded(hModel);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.GameLoop", "OnModelReloaded", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Networking.OnNetMessage( ... )
		/// </summary>
		// Token: 0x0600009F RID: 159 RVA: 0x000048A0 File Offset: 0x00002AA0
		[UnmanagedCallersOnly]
		internal static void Sandbo_Netwrk_OnNetMessage(IntPtr data, int length, int playerEntity)
		{
			try
			{
				Networking.OnNetMessage(data, length, playerEntity);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Networking", "OnNetMessage", ___e);
			}
		}

		/// <summary>
		/// Sandbox.PlayerCommand.RunClient( ... )
		/// </summary>
		// Token: 0x060000A0 RID: 160 RVA: 0x000048DC File Offset: 0x00002ADC
		[UnmanagedCallersOnly]
		internal unsafe static void Sandbo_PlyerC_RunClient(uint player, IntPtr cmd)
		{
			try
			{
				PlayerCommand.RunClient(InteropSystem.Get<ClientEntity>(player), Unsafe.AsRef<CUserCmd>((void*)cmd));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.PlayerCommand", "RunClient", ___e);
			}
		}

		/// <summary>
		/// Sandbox.PlayerCommand.RunClientFrame( ... )
		/// </summary>
		// Token: 0x060000A1 RID: 161 RVA: 0x00004924 File Offset: 0x00002B24
		[UnmanagedCallersOnly]
		internal unsafe static void Sandbo_PlyerC_RunClientFrame(IntPtr cmd)
		{
			try
			{
				PlayerCommand.RunClientFrame(Unsafe.AsRef<CUserCmd>((void*)cmd));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.PlayerCommand", "RunClientFrame", ___e);
			}
		}

		/// <summary>
		/// Sandbox.PlayerCommand.RunServer( ... )
		/// </summary>
		// Token: 0x060000A2 RID: 162 RVA: 0x00004968 File Offset: 0x00002B68
		[UnmanagedCallersOnly]
		internal unsafe static void Sandbo_PlyerC_RunServer(uint player, IntPtr cmd)
		{
			try
			{
				PlayerCommand.RunServer(InteropSystem.Get<ClientEntity>(player), Unsafe.AsRef<CUserCmd>((void*)cmd));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.PlayerCommand", "RunServer", ___e);
			}
		}

		/// <summary>
		/// Sandbox.RealTime.Update( ... )
		/// </summary>
		// Token: 0x060000A3 RID: 163 RVA: 0x000049B0 File Offset: 0x00002BB0
		[UnmanagedCallersOnly]
		internal static void Sandbo_RelTme_Update(float time)
		{
			try
			{
				RealTime.Update(time);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.RealTime", "Update", ___e);
			}
		}

		/// <summary>
		/// Sandbox.PhysicsBody.OnObjectCreated( ... )
		/// </summary>
		// Token: 0x060000A4 RID: 164 RVA: 0x000049E8 File Offset: 0x00002BE8
		[UnmanagedCallersOnly]
		internal static int Sandboserver_Physcs_OnObjectCreated(IntPtr ptr, int ptype)
		{
			int result;
			try
			{
				if (ptype != 0)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(46, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Tried to create unknown PhysicsBody - type id ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(ptype);
					throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				result = HandleIndex.New<PhysicsBody>(ptr, (HandleCreationData x) => new PhysicsBody(x));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.PhysicsBody", "OnObjectCreated", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.PhysicsBody.OnObjectDestroyed( ... )
		/// </summary>
		// Token: 0x060000A5 RID: 165 RVA: 0x00004A70 File Offset: 0x00002C70
		[UnmanagedCallersOnly]
		internal static void Sandboserver_Physcs_OnObjectDestroyed(IntPtr ptr, int idx)
		{
			try
			{
				HandleIndex.Delete(ptr, idx);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.PhysicsBody", "OnObjectDestroyed", ___e);
			}
		}

		/// <summary>
		/// Sandbox.PhysicsGroup.OnObjectCreated( ... )
		/// </summary>
		// Token: 0x060000A6 RID: 166 RVA: 0x00004AAC File Offset: 0x00002CAC
		[UnmanagedCallersOnly]
		internal static int Sandboserver_Physcs_f2(IntPtr ptr, int ptype)
		{
			int result;
			try
			{
				if (ptype != 0)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(47, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Tried to create unknown PhysicsGroup - type id ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(ptype);
					throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				result = HandleIndex.New<PhysicsGroup>(ptr, (HandleCreationData x) => new PhysicsGroup(x));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.PhysicsGroup", "OnObjectCreated", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.PhysicsGroup.OnObjectDestroyed( ... )
		/// </summary>
		// Token: 0x060000A7 RID: 167 RVA: 0x00004B34 File Offset: 0x00002D34
		[UnmanagedCallersOnly]
		internal static void Sandboserver_Physcs_f3(IntPtr ptr, int idx)
		{
			try
			{
				HandleIndex.Delete(ptr, idx);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.PhysicsGroup", "OnObjectDestroyed", ___e);
			}
		}

		/// <summary>
		/// Sandbox.PhysicsJoint.OnObjectCreated( ... )
		/// </summary>
		// Token: 0x060000A8 RID: 168 RVA: 0x00004B70 File Offset: 0x00002D70
		[UnmanagedCallersOnly]
		internal static int Sandboserver_Physcs_f4(IntPtr ptr, int ptype)
		{
			int result;
			try
			{
				if (ptype != 0)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(47, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Tried to create unknown PhysicsJoint - type id ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(ptype);
					throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				result = HandleIndex.New<PhysicsJoint>(ptr, (HandleCreationData x) => new PhysicsJoint(x));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.PhysicsJoint", "OnObjectCreated", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.PhysicsJoint.OnObjectDestroyed( ... )
		/// </summary>
		// Token: 0x060000A9 RID: 169 RVA: 0x00004BF8 File Offset: 0x00002DF8
		[UnmanagedCallersOnly]
		internal static void Sandboserver_Physcs_f5(IntPtr ptr, int idx)
		{
			try
			{
				HandleIndex.Delete(ptr, idx);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.PhysicsJoint", "OnObjectDestroyed", ___e);
			}
		}

		/// <summary>
		/// Sandbox.PhysicsShape.OnObjectCreated( ... )
		/// </summary>
		// Token: 0x060000AA RID: 170 RVA: 0x00004C34 File Offset: 0x00002E34
		[UnmanagedCallersOnly]
		internal static int Sandboserver_Physcs_f6(IntPtr ptr, int ptype)
		{
			int result;
			try
			{
				if (ptype != 0)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(47, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Tried to create unknown PhysicsShape - type id ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(ptype);
					throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				result = HandleIndex.New<PhysicsShape>(ptr, (HandleCreationData x) => new PhysicsShape(x));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.PhysicsShape", "OnObjectCreated", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.PhysicsShape.OnObjectDestroyed( ... )
		/// </summary>
		// Token: 0x060000AB RID: 171 RVA: 0x00004CBC File Offset: 0x00002EBC
		[UnmanagedCallersOnly]
		internal static void Sandboserver_Physcs_f7(IntPtr ptr, int idx)
		{
			try
			{
				HandleIndex.Delete(ptr, idx);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.PhysicsShape", "OnObjectDestroyed", ___e);
			}
		}

		/// <summary>
		/// Sandbox.SceneObject.OnObjectCreated( ... )
		/// </summary>
		// Token: 0x060000AC RID: 172 RVA: 0x00004CF8 File Offset: 0x00002EF8
		[UnmanagedCallersOnly]
		internal static int Sandboserver_SceneO_OnObjectCreated(IntPtr ptr, int ptype)
		{
			int result;
			try
			{
				if (ptype <= 264582)
				{
					if (ptype == 0)
					{
						return HandleIndex.New<SceneObject>(ptr, (HandleCreationData x) => new SceneObject(x));
					}
					if (ptype == 234652)
					{
						return HandleIndex.New<AnimSceneObject>(ptr, (HandleCreationData x) => new AnimSceneObject(x));
					}
					if (ptype == 264582)
					{
						return HandleIndex.New<SceneParticleObject>(ptr, (HandleCreationData x) => new SceneParticleObject(x));
					}
				}
				else if (ptype <= 572329)
				{
					if (ptype == 523546)
					{
						return HandleIndex.New<SkyboxObject>(ptr, (HandleCreationData x) => new SkyboxObject(x));
					}
					if (ptype == 572329)
					{
						return HandleIndex.New<SceneMonitorObject>(ptr, (HandleCreationData x) => new SceneMonitorObject(x));
					}
				}
				else
				{
					if (ptype == 845676)
					{
						return HandleIndex.New<CustomSceneObject>(ptr, (HandleCreationData x) => new CustomSceneObject(x));
					}
					if (ptype == 846832)
					{
						return HandleIndex.New<Light>(ptr, (HandleCreationData x) => new Light(x));
					}
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(46, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Tried to create unknown SceneObject - type id ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(ptype);
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.SceneObject", "OnObjectCreated", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.SceneObject.OnObjectDestroyed( ... )
		/// </summary>
		// Token: 0x060000AD RID: 173 RVA: 0x00004EEC File Offset: 0x000030EC
		[UnmanagedCallersOnly]
		internal static void Sandboserver_SceneO_OnObjectDestroyed(IntPtr ptr, int idx)
		{
			try
			{
				HandleIndex.Delete(ptr, idx);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.SceneObject", "OnObjectDestroyed", ___e);
			}
		}

		/// <summary>
		/// Sandbox.SceneWorld.OnObjectCreated( ... )
		/// </summary>
		// Token: 0x060000AE RID: 174 RVA: 0x00004F28 File Offset: 0x00003128
		[UnmanagedCallersOnly]
		internal static int Sandboserver_SceneW_OnObjectCreated(IntPtr ptr, int ptype)
		{
			int result;
			try
			{
				if (ptype != 0)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Tried to create unknown SceneWorld - type id ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(ptype);
					throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				result = HandleIndex.New<SceneWorld>(ptr, (HandleCreationData x) => new SceneWorld(x));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.SceneWorld", "OnObjectCreated", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.SceneWorld.OnObjectDestroyed( ... )
		/// </summary>
		// Token: 0x060000AF RID: 175 RVA: 0x00004FB0 File Offset: 0x000031B0
		[UnmanagedCallersOnly]
		internal static void Sandboserver_SceneW_OnObjectDestroyed(IntPtr ptr, int idx)
		{
			try
			{
				HandleIndex.Delete(ptr, idx);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.SceneWorld", "OnObjectDestroyed", ___e);
			}
		}

		/// <summary>
		/// Sandbox.StringTables.Init( ... )
		/// </summary>
		// Token: 0x060000B0 RID: 176 RVA: 0x00004FEC File Offset: 0x000031EC
		[UnmanagedCallersOnly]
		internal static void Sandbo_StrngT_Init()
		{
			try
			{
				StringTables.Init();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.StringTables", "Init", ___e);
			}
		}

		/// <summary>
		/// Sandbox.StringTables.Shutdown( ... )
		/// </summary>
		// Token: 0x060000B1 RID: 177 RVA: 0x00005024 File Offset: 0x00003224
		[UnmanagedCallersOnly]
		internal static void Sandbo_StrngT_Shutdown()
		{
			try
			{
				StringTables.Shutdown();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.StringTables", "Shutdown", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Time.Update( ... )
		/// </summary>
		// Token: 0x060000B2 RID: 178 RVA: 0x0000505C File Offset: 0x0000325C
		[UnmanagedCallersOnly]
		internal static void Sandbo_Time_Update(float time, float framedelta, int tick)
		{
			try
			{
				Time.Update(time, framedelta, tick);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Time", "Update", ___e);
			}
		}
	}
}
