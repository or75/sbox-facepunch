using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NativeEngine;
using Sandbox;
using Steamworks;

namespace Managed.SourceClient
{
	// Token: 0x02000010 RID: 16
	internal static class Exports
	{
		/// <summary>
		/// Sandbox.PhysicsBody.OnObjectCreated( ... )
		/// </summary>
		// Token: 0x060000B5 RID: 181 RVA: 0x00012090 File Offset: 0x00010290
		[UnmanagedCallersOnly]
		internal static int Sandboclient_Physcs_OnObjectCreated(IntPtr ptr, int ptype)
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
		// Token: 0x060000B6 RID: 182 RVA: 0x00012118 File Offset: 0x00010318
		[UnmanagedCallersOnly]
		internal static void Sandboclient_Physcs_OnObjectDestroyed(IntPtr ptr, int idx)
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
		// Token: 0x060000B7 RID: 183 RVA: 0x00012154 File Offset: 0x00010354
		[UnmanagedCallersOnly]
		internal static int Sandboclient_Physcs_f2(IntPtr ptr, int ptype)
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
		// Token: 0x060000B8 RID: 184 RVA: 0x000121DC File Offset: 0x000103DC
		[UnmanagedCallersOnly]
		internal static void Sandboclient_Physcs_f3(IntPtr ptr, int idx)
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
		// Token: 0x060000B9 RID: 185 RVA: 0x00012218 File Offset: 0x00010418
		[UnmanagedCallersOnly]
		internal static int Sandboclient_Physcs_f4(IntPtr ptr, int ptype)
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
		// Token: 0x060000BA RID: 186 RVA: 0x000122A0 File Offset: 0x000104A0
		[UnmanagedCallersOnly]
		internal static void Sandboclient_Physcs_f5(IntPtr ptr, int idx)
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
		// Token: 0x060000BB RID: 187 RVA: 0x000122DC File Offset: 0x000104DC
		[UnmanagedCallersOnly]
		internal static int Sandboclient_Physcs_f6(IntPtr ptr, int ptype)
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
		// Token: 0x060000BC RID: 188 RVA: 0x00012364 File Offset: 0x00010564
		[UnmanagedCallersOnly]
		internal static void Sandboclient_Physcs_f7(IntPtr ptr, int idx)
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
		// Token: 0x060000BD RID: 189 RVA: 0x000123A0 File Offset: 0x000105A0
		[UnmanagedCallersOnly]
		internal static int Sandboclient_SceneO_OnObjectCreated(IntPtr ptr, int ptype)
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
		// Token: 0x060000BE RID: 190 RVA: 0x00012594 File Offset: 0x00010794
		[UnmanagedCallersOnly]
		internal static void Sandboclient_SceneO_OnObjectDestroyed(IntPtr ptr, int idx)
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
		// Token: 0x060000BF RID: 191 RVA: 0x000125D0 File Offset: 0x000107D0
		[UnmanagedCallersOnly]
		internal static int Sandboclient_SceneW_OnObjectCreated(IntPtr ptr, int ptype)
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
		// Token: 0x060000C0 RID: 192 RVA: 0x00012658 File Offset: 0x00010858
		[UnmanagedCallersOnly]
		internal static void Sandboclient_SceneW_OnObjectDestroyed(IntPtr ptr, int idx)
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
		/// Sandbox.ClientEntity.OnNativeEntity( ... )
		/// </summary>
		// Token: 0x060000C1 RID: 193 RVA: 0x00012694 File Offset: 0x00010894
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
		// Token: 0x060000C2 RID: 194 RVA: 0x000126E0 File Offset: 0x000108E0
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
		// Token: 0x060000C3 RID: 195 RVA: 0x00012724 File Offset: 0x00010924
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
		// Token: 0x060000C4 RID: 196 RVA: 0x00012768 File Offset: 0x00010968
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
		// Token: 0x060000C5 RID: 197 RVA: 0x000127AC File Offset: 0x000109AC
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
		// Token: 0x060000C6 RID: 198 RVA: 0x000127F0 File Offset: 0x000109F0
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
		// Token: 0x060000C7 RID: 199 RVA: 0x00012834 File Offset: 0x00010A34
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
		// Token: 0x060000C8 RID: 200 RVA: 0x00012878 File Offset: 0x00010A78
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
		// Token: 0x060000C9 RID: 201 RVA: 0x000128C4 File Offset: 0x00010AC4
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
		// Token: 0x060000CA RID: 202 RVA: 0x00012928 File Offset: 0x00010B28
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
		// Token: 0x060000CB RID: 203 RVA: 0x0001296C File Offset: 0x00010B6C
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
		// Token: 0x060000CC RID: 204 RVA: 0x000129B8 File Offset: 0x00010BB8
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
		// Token: 0x060000CD RID: 205 RVA: 0x00012A04 File Offset: 0x00010C04
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
		// Token: 0x060000CE RID: 206 RVA: 0x00012A50 File Offset: 0x00010C50
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
		// Token: 0x060000CF RID: 207 RVA: 0x00012A9C File Offset: 0x00010C9C
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
		// Token: 0x060000D0 RID: 208 RVA: 0x00012AE0 File Offset: 0x00010CE0
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
		// Token: 0x060000D1 RID: 209 RVA: 0x00012B28 File Offset: 0x00010D28
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
		// Token: 0x060000D2 RID: 210 RVA: 0x00012B74 File Offset: 0x00010D74
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
		// Token: 0x060000D3 RID: 211 RVA: 0x00012BB8 File Offset: 0x00010DB8
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
		// Token: 0x060000D4 RID: 212 RVA: 0x00012C10 File Offset: 0x00010E10
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
		// Token: 0x060000D5 RID: 213 RVA: 0x00012C58 File Offset: 0x00010E58
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
		// Token: 0x060000D6 RID: 214 RVA: 0x00012C9C File Offset: 0x00010E9C
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
		// Token: 0x060000D7 RID: 215 RVA: 0x00012CE4 File Offset: 0x00010EE4
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
		// Token: 0x060000D8 RID: 216 RVA: 0x00012D28 File Offset: 0x00010F28
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
		// Token: 0x060000D9 RID: 217 RVA: 0x00012D78 File Offset: 0x00010F78
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
		// Token: 0x060000DA RID: 218 RVA: 0x00012DC8 File Offset: 0x00010FC8
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
		// Token: 0x060000DB RID: 219 RVA: 0x00012E10 File Offset: 0x00011010
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
		// Token: 0x060000DC RID: 220 RVA: 0x00012E54 File Offset: 0x00011054
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
		// Token: 0x060000DD RID: 221 RVA: 0x00012E9C File Offset: 0x0001109C
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
		// Token: 0x060000DE RID: 222 RVA: 0x00012EE0 File Offset: 0x000110E0
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
		// Token: 0x060000DF RID: 223 RVA: 0x00012F2C File Offset: 0x0001112C
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
		// Token: 0x060000E0 RID: 224 RVA: 0x00012F74 File Offset: 0x00011174
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
		// Token: 0x060000E1 RID: 225 RVA: 0x00012FCC File Offset: 0x000111CC
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
		// Token: 0x060000E2 RID: 226 RVA: 0x00013014 File Offset: 0x00011214
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
		// Token: 0x060000E3 RID: 227 RVA: 0x00013060 File Offset: 0x00011260
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
		// Token: 0x060000E4 RID: 228 RVA: 0x000130A4 File Offset: 0x000112A4
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
		// Token: 0x060000E5 RID: 229 RVA: 0x000130F0 File Offset: 0x000112F0
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
		// Token: 0x060000E6 RID: 230 RVA: 0x00013138 File Offset: 0x00011338
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
		// Token: 0x060000E7 RID: 231 RVA: 0x00013184 File Offset: 0x00011384
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
		// Token: 0x060000E8 RID: 232 RVA: 0x000131C8 File Offset: 0x000113C8
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
		// Token: 0x060000E9 RID: 233 RVA: 0x0001320C File Offset: 0x0001140C
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
		// Token: 0x060000EA RID: 234 RVA: 0x00013250 File Offset: 0x00011450
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
		// Token: 0x060000EB RID: 235 RVA: 0x00013294 File Offset: 0x00011494
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
		// Token: 0x060000EC RID: 236 RVA: 0x000132D8 File Offset: 0x000114D8
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
		// Token: 0x060000ED RID: 237 RVA: 0x0001331C File Offset: 0x0001151C
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
		// Token: 0x060000EE RID: 238 RVA: 0x00013368 File Offset: 0x00011568
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
		// Token: 0x060000EF RID: 239 RVA: 0x000133CC File Offset: 0x000115CC
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
		// Token: 0x060000F0 RID: 240 RVA: 0x00013410 File Offset: 0x00011610
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
		// Token: 0x060000F1 RID: 241 RVA: 0x0001345C File Offset: 0x0001165C
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
		// Token: 0x060000F2 RID: 242 RVA: 0x000134A8 File Offset: 0x000116A8
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
		// Token: 0x060000F3 RID: 243 RVA: 0x000134F4 File Offset: 0x000116F4
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
		// Token: 0x060000F4 RID: 244 RVA: 0x00013540 File Offset: 0x00011740
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
		// Token: 0x060000F5 RID: 245 RVA: 0x00013584 File Offset: 0x00011784
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
		// Token: 0x060000F6 RID: 246 RVA: 0x000135CC File Offset: 0x000117CC
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
		// Token: 0x060000F7 RID: 247 RVA: 0x00013618 File Offset: 0x00011818
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
		// Token: 0x060000F8 RID: 248 RVA: 0x0001365C File Offset: 0x0001185C
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
		// Token: 0x060000F9 RID: 249 RVA: 0x000136B4 File Offset: 0x000118B4
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
		// Token: 0x060000FA RID: 250 RVA: 0x000136FC File Offset: 0x000118FC
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
		// Token: 0x060000FB RID: 251 RVA: 0x00013740 File Offset: 0x00011940
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
		// Token: 0x060000FC RID: 252 RVA: 0x00013788 File Offset: 0x00011988
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
		// Token: 0x060000FD RID: 253 RVA: 0x000137CC File Offset: 0x000119CC
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
		// Token: 0x060000FE RID: 254 RVA: 0x0001381C File Offset: 0x00011A1C
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
		// Token: 0x060000FF RID: 255 RVA: 0x0001386C File Offset: 0x00011A6C
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
		// Token: 0x06000100 RID: 256 RVA: 0x000138B4 File Offset: 0x00011AB4
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
		// Token: 0x06000101 RID: 257 RVA: 0x000138F8 File Offset: 0x00011AF8
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
		// Token: 0x06000102 RID: 258 RVA: 0x00013940 File Offset: 0x00011B40
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
		// Token: 0x06000103 RID: 259 RVA: 0x00013984 File Offset: 0x00011B84
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
		// Token: 0x06000104 RID: 260 RVA: 0x000139D0 File Offset: 0x00011BD0
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
		// Token: 0x06000105 RID: 261 RVA: 0x00013A18 File Offset: 0x00011C18
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
		// Token: 0x06000106 RID: 262 RVA: 0x00013A70 File Offset: 0x00011C70
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
		// Token: 0x06000107 RID: 263 RVA: 0x00013AB8 File Offset: 0x00011CB8
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
		// Token: 0x06000108 RID: 264 RVA: 0x00013B04 File Offset: 0x00011D04
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
		// Token: 0x06000109 RID: 265 RVA: 0x00013B48 File Offset: 0x00011D48
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
		// Token: 0x0600010A RID: 266 RVA: 0x00013B94 File Offset: 0x00011D94
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
		// Token: 0x0600010B RID: 267 RVA: 0x00013BDC File Offset: 0x00011DDC
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
		// Token: 0x0600010C RID: 268 RVA: 0x00013C1C File Offset: 0x00011E1C
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
		// Token: 0x0600010D RID: 269 RVA: 0x00013C54 File Offset: 0x00011E54
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
		// Token: 0x0600010E RID: 270 RVA: 0x00013C8C File Offset: 0x00011E8C
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
		// Token: 0x0600010F RID: 271 RVA: 0x00013CC4 File Offset: 0x00011EC4
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
		// Token: 0x06000110 RID: 272 RVA: 0x00013CFC File Offset: 0x00011EFC
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
		// Token: 0x06000111 RID: 273 RVA: 0x00013D34 File Offset: 0x00011F34
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
		// Token: 0x06000112 RID: 274 RVA: 0x00013D78 File Offset: 0x00011F78
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
		// Token: 0x06000113 RID: 275 RVA: 0x00013DC0 File Offset: 0x00011FC0
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
		// Token: 0x06000114 RID: 276 RVA: 0x00013DF8 File Offset: 0x00011FF8
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
		// Token: 0x06000115 RID: 277 RVA: 0x00013E30 File Offset: 0x00012030
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
		// Token: 0x06000116 RID: 278 RVA: 0x00013E70 File Offset: 0x00012070
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
		// Token: 0x06000117 RID: 279 RVA: 0x00013EB4 File Offset: 0x000120B4
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
		// Token: 0x06000118 RID: 280 RVA: 0x00013EEC File Offset: 0x000120EC
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
		// Token: 0x06000119 RID: 281 RVA: 0x00013F30 File Offset: 0x00012130
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
		// Token: 0x0600011A RID: 282 RVA: 0x00013F68 File Offset: 0x00012168
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
		// Token: 0x0600011B RID: 283 RVA: 0x00013FA0 File Offset: 0x000121A0
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
		// Token: 0x0600011C RID: 284 RVA: 0x00013FD8 File Offset: 0x000121D8
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
		// Token: 0x0600011D RID: 285 RVA: 0x00014018 File Offset: 0x00012218
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
		// Token: 0x0600011E RID: 286 RVA: 0x00014058 File Offset: 0x00012258
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
		// Token: 0x0600011F RID: 287 RVA: 0x00014090 File Offset: 0x00012290
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
		// Token: 0x06000120 RID: 288 RVA: 0x000140C8 File Offset: 0x000122C8
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
		// Token: 0x06000121 RID: 289 RVA: 0x00014100 File Offset: 0x00012300
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
		// Token: 0x06000122 RID: 290 RVA: 0x00014138 File Offset: 0x00012338
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
		// Token: 0x06000123 RID: 291 RVA: 0x00014178 File Offset: 0x00012378
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
		// Token: 0x06000124 RID: 292 RVA: 0x000141B8 File Offset: 0x000123B8
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
		// Token: 0x06000125 RID: 293 RVA: 0x000141F0 File Offset: 0x000123F0
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
		// Token: 0x06000126 RID: 294 RVA: 0x00014228 File Offset: 0x00012428
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
		/// Sandbox.InputBuilder.Process( ... )
		/// </summary>
		// Token: 0x06000127 RID: 295 RVA: 0x00014268 File Offset: 0x00012468
		[UnmanagedCallersOnly]
		internal unsafe static void Sandbo_InptBl_Process(IntPtr data)
		{
			try
			{
				InputBuilder.Process(Unsafe.AsRef<InputData>((void*)data));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.InputBuilder", "Process", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Networking.OnNetMessage( ... )
		/// </summary>
		// Token: 0x06000128 RID: 296 RVA: 0x000142AC File Offset: 0x000124AC
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
		// Token: 0x06000129 RID: 297 RVA: 0x000142E8 File Offset: 0x000124E8
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
		// Token: 0x0600012A RID: 298 RVA: 0x00014330 File Offset: 0x00012530
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
		// Token: 0x0600012B RID: 299 RVA: 0x00014374 File Offset: 0x00012574
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
		/// Sandbox.Prediction.PreEntityPacketReceived( ... )
		/// </summary>
		// Token: 0x0600012C RID: 300 RVA: 0x000143BC File Offset: 0x000125BC
		[UnmanagedCallersOnly]
		internal static void Sandbo_Predct_PreEntityPacketReceived(int cmdnum, int ackccmds)
		{
			try
			{
				Prediction.PreEntityPacketReceived(cmdnum, ackccmds);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Prediction", "PreEntityPacketReceived", ___e);
			}
		}

		/// <summary>
		/// Sandbox.Prediction.PostEntityPacketReceived( ... )
		/// </summary>
		// Token: 0x0600012D RID: 301 RVA: 0x000143F8 File Offset: 0x000125F8
		[UnmanagedCallersOnly]
		internal static void Sandbo_Predct_PostEntityPacketReceived()
		{
			try
			{
				Prediction.PostEntityPacketReceived();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Prediction", "PostEntityPacketReceived", ___e);
			}
		}

		/// <summary>
		/// Sandbox.RealTime.Update( ... )
		/// </summary>
		// Token: 0x0600012E RID: 302 RVA: 0x00014430 File Offset: 0x00012630
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
		/// Sandbox.RenderingManager.RenderUI( ... )
		/// </summary>
		// Token: 0x0600012F RID: 303 RVA: 0x00014468 File Offset: 0x00012668
		[UnmanagedCallersOnly]
		internal static void Sandbo_Render_RenderUI()
		{
			try
			{
				RenderingManager.RenderUI();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.RenderingManager", "RenderUI", ___e);
			}
		}

		/// <summary>
		/// Sandbox.RenderingManager.RenderSceneObject( ... )
		/// </summary>
		// Token: 0x06000130 RID: 304 RVA: 0x000144A0 File Offset: 0x000126A0
		[UnmanagedCallersOnly]
		internal static void Sandbo_Render_RenderSceneObject(int objectId)
		{
			try
			{
				RenderingManager.RenderSceneObject(objectId);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.RenderingManager", "RenderSceneObject", ___e);
			}
		}

		/// <summary>
		/// Sandbox.RenderingManager.BlockStart( ... )
		/// </summary>
		// Token: 0x06000131 RID: 305 RVA: 0x000144D8 File Offset: 0x000126D8
		[UnmanagedCallersOnly]
		internal static void Sandbo_Render_BlockStart(IntPtr view, IntPtr context, IntPtr layer)
		{
			try
			{
				RenderingManager.BlockStart(view, context, layer);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.RenderingManager", "BlockStart", ___e);
			}
		}

		/// <summary>
		/// Sandbox.RenderingManager.BlockEnd( ... )
		/// </summary>
		// Token: 0x06000132 RID: 306 RVA: 0x00014524 File Offset: 0x00012724
		[UnmanagedCallersOnly]
		internal static void Sandbo_Render_BlockEnd()
		{
			try
			{
				RenderingManager.BlockEnd();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.RenderingManager", "BlockEnd", ___e);
			}
		}

		/// <summary>
		/// Sandbox.RenderingManager.PostProcess( ... )
		/// </summary>
		// Token: 0x06000133 RID: 307 RVA: 0x0001455C File Offset: 0x0001275C
		[UnmanagedCallersOnly]
		internal static void Sandbo_Render_PostProcess()
		{
			try
			{
				RenderingManager.PostProcess();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.RenderingManager", "PostProcess", ___e);
			}
		}

		/// <summary>
		/// Sandbox.StringTables.Init( ... )
		/// </summary>
		// Token: 0x06000134 RID: 308 RVA: 0x00014594 File Offset: 0x00012794
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
		// Token: 0x06000135 RID: 309 RVA: 0x000145CC File Offset: 0x000127CC
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
		// Token: 0x06000136 RID: 310 RVA: 0x00014604 File Offset: 0x00012804
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

		/// <summary>
		/// Steamworks.Dispatch.OnClientCallback( ... )
		/// </summary>
		// Token: 0x06000137 RID: 311 RVA: 0x00014640 File Offset: 0x00012840
		[UnmanagedCallersOnly]
		internal static void Stemwr_Dsptch_OnClientCallback(int type, IntPtr data, int datasize)
		{
			try
			{
				Dispatch.OnClientCallback(type, data, datasize);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Steamworks.Dispatch", "OnClientCallback", ___e);
			}
		}
	}
}
