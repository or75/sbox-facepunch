using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Sandbox
{
	// Token: 0x020000C9 RID: 201
	public class NetWrite : IDisposable
	{
		// Token: 0x0600123C RID: 4668 RVA: 0x0004D104 File Offset: 0x0004B304
		internal unsafe NetWrite()
		{
			this.AllocatedSize = 1048576;
			this.DataPtr = Marshal.AllocHGlobal(this.AllocatedSize);
			this.WrittenSize = 0;
			this.CurPtr = (byte*)(void*)this.DataPtr;
		}

		// Token: 0x0600123D RID: 4669 RVA: 0x0004D140 File Offset: 0x0004B340
		public static NetWrite StartRpc(int ident, Entity ent)
		{
			NetWrite nw = new NetWrite();
			Prediction.Write(nw);
			if (ent != null)
			{
				ent.RpcWriteIdent(nw);
			}
			nw.Write<int>(0);
			nw.Write<int>(ident);
			return nw;
		}

		// Token: 0x0600123E RID: 4670 RVA: 0x0004D172 File Offset: 0x0004B372
		public void SendRpcToServer(Entity from)
		{
			Host.AssertClient("SendRpcToServer");
			if (from != null)
			{
				Networking.BroadcastPVS(this.DataPtr, this.WrittenSize, from);
				return;
			}
			Networking.Broadcast(this.DataPtr, this.WrittenSize);
		}

		// Token: 0x0600123F RID: 4671 RVA: 0x0004D1A8 File Offset: 0x0004B3A8
		public void SendRpc(To? target, Entity from)
		{
			Host.AssertServer("SendRpc");
			if (target != null)
			{
				foreach (Client client in target.Value)
				{
					Networking.Send(this.DataPtr, this.WrittenSize, client);
				}
				return;
			}
			if (from != null)
			{
				Networking.BroadcastPVS(this.DataPtr, this.WrittenSize, from);
				return;
			}
			Networking.Broadcast(this.DataPtr, this.WrittenSize);
		}

		// Token: 0x06001240 RID: 4672 RVA: 0x0004D240 File Offset: 0x0004B440
		public unsafe void Dispose()
		{
			if (this.DataPtr != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.DataPtr);
				this.DataPtr = 0;
			}
			this.AllocatedSize = 0;
			this.WrittenSize = 0;
			this.CurPtr = default(byte*);
		}

		/// <summary>
		/// A dedicated method for writing an array of unmanaged types
		/// </summary>
		// Token: 0x06001241 RID: 4673 RVA: 0x0004D290 File Offset: 0x0004B490
		public unsafe void WriteUnmanagedArray<[IsUnmanaged] T>(T[] arr) where T : struct, ValueType
		{
			if (arr == null)
			{
				this.Write<int>(-1);
				return;
			}
			int size = Unsafe.SizeOf<T>();
			this.Write<int>(arr.Length);
			for (int i = 0; i < arr.Length; i++)
			{
				this.WrittenSize += size;
				Unsafe.Write<T>((void*)this.CurPtr, arr[i]);
				this.CurPtr += size;
			}
		}

		// Token: 0x06001242 RID: 4674 RVA: 0x0004D2F4 File Offset: 0x0004B4F4
		public void Write<T>(T[] val)
		{
			if (val == null)
			{
				this.Write<int>(-1);
				return;
			}
			int size = val.Length;
			if (size > 512)
			{
				throw new Exception("Network " + typeof(T).Name + " array cannot contain more than 512 elements!");
			}
			this.Write<int>(size);
			for (int i = 0; i < size; i++)
			{
				this.Write<T>(val[i]);
			}
		}

		// Token: 0x06001243 RID: 4675 RVA: 0x0004D35C File Offset: 0x0004B55C
		public unsafe void Write<T>(Span<T> val)
		{
			if (val == null)
			{
				this.Write<int>(-1);
				return;
			}
			this.Write<int>(val.Length);
			int objSize = Unsafe.SizeOf<T>();
			for (int i = 0; i < val.Length; i++)
			{
				this.WrittenSize += objSize;
				Unsafe.Write<T>((void*)this.CurPtr, *val[i]);
				this.CurPtr += objSize;
			}
		}

		// Token: 0x06001244 RID: 4676 RVA: 0x0004D3D8 File Offset: 0x0004B5D8
		public unsafe void Write<T>(T val)
		{
			Type t = typeof(T);
			if (t == typeof(string))
			{
				this.WriteUtf8(val as string);
				return;
			}
			if (t.IsAssignableTo(typeof(Resource)))
			{
				Resource ni = val as Resource;
				if (ni != null)
				{
					this.Write<int>(ni.ResourceId);
					return;
				}
				this.Write<int>(0);
				return;
			}
			else if (t.IsAssignableTo(typeof(Asset)))
			{
				Asset ni2 = val as Asset;
				if (ni2 != null)
				{
					this.Write<int>(ni2.Id);
					return;
				}
				this.Write<int>(0);
				return;
			}
			else
			{
				Client clientEnt = val as Client;
				if (clientEnt != null)
				{
					if (!clientEnt.IsValid())
					{
						this.Write<int>(-1);
						return;
					}
					this.Write<int>(clientEnt.NetworkIdent);
					return;
				}
				else
				{
					Entity ent = val as Entity;
					if (ent != null)
					{
						if (!ent.IsValid())
						{
							this.Write<int>(-1);
							return;
						}
						this.Write<int>(ent.NetworkIdent);
						return;
					}
					else
					{
						if (val == null)
						{
							this.Write<int>(0);
							return;
						}
						if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
						{
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(59, 1);
							defaultInterpolatedStringHandler.AppendLiteral("Can not NetWrite type ");
							defaultInterpolatedStringHandler.AppendFormatted<Type>(t);
							defaultInterpolatedStringHandler.AppendLiteral(" as it is or contains reference types");
							throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
						}
						int size = Unsafe.SizeOf<T>();
						this.LengthAssert(size);
						this.WrittenSize += size;
						Unsafe.Write<T>((void*)this.CurPtr, val);
						this.CurPtr += size;
						return;
					}
				}
			}
		}

		// Token: 0x06001245 RID: 4677 RVA: 0x0004D564 File Offset: 0x0004B764
		public unsafe void WriteUtf8(string str)
		{
			if (str == null)
			{
				this.Write<int>(-1);
				return;
			}
			if (str.Length == 0)
			{
				this.Write<int>(0);
				return;
			}
			int dataLen = Encoding.UTF8.GetByteCount(str);
			this.LengthAssert(dataLen);
			this.Write<int>(dataLen);
			char* ptr;
			if (str == null)
			{
				ptr = null;
			}
			else
			{
				fixed (char* ptr2 = str.GetPinnableReference())
				{
					ptr = ptr2;
				}
			}
			char* p = ptr;
			dataLen = Encoding.UTF8.GetBytes(p, str.Length, this.CurPtr, dataLen);
			char* ptr2 = null;
			this.WrittenSize += dataLen;
			this.CurPtr += dataLen;
		}

		// Token: 0x06001246 RID: 4678 RVA: 0x0004D5F0 File Offset: 0x0004B7F0
		public void LengthAssert(int size)
		{
			if (this.WrittenSize + size >= this.AllocatedSize)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(37, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Tried to write ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.WrittenSize + size);
				defaultInterpolatedStringHandler.AppendLiteral(" but only have ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.AllocatedSize);
				defaultInterpolatedStringHandler.AppendLiteral(" buffer");
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
		}

		// Token: 0x06001247 RID: 4679 RVA: 0x0004D664 File Offset: 0x0004B864
		public void WriteObject(object obj)
		{
			if (obj == null)
			{
				this.Write<byte>(0);
				return;
			}
			if (obj is int)
			{
				int i = (int)obj;
				this.Write<byte>(1);
				this.Write<int>(i);
				return;
			}
			if (obj is uint)
			{
				uint ui = (uint)obj;
				this.Write<byte>(7);
				this.Write<uint>(ui);
				return;
			}
			if (obj is bool)
			{
				bool b = (bool)obj;
				this.Write<byte>(6);
				this.Write<bool>(b);
				return;
			}
			if (obj is float)
			{
				float f = (float)obj;
				this.Write<byte>(2);
				this.Write<float>(f);
				return;
			}
			if (obj is Vector3)
			{
				Vector3 v = (Vector3)obj;
				this.Write<byte>(3);
				this.Write<Vector3>(v);
				return;
			}
			string str = obj as string;
			if (str != null)
			{
				this.Write<byte>(4);
				this.Write<string>(str);
				return;
			}
			Entity e = obj as Entity;
			if (e != null)
			{
				this.Write<byte>(5);
				this.Write<Entity>(e);
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Unhandled network serialization of type ");
			defaultInterpolatedStringHandler.AppendFormatted<Type>(obj.GetType());
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x040003C3 RID: 963
		internal IntPtr DataPtr;

		// Token: 0x040003C4 RID: 964
		internal int WrittenSize;

		// Token: 0x040003C5 RID: 965
		internal int AllocatedSize;

		// Token: 0x040003C6 RID: 966
		internal unsafe byte* CurPtr;

		// Token: 0x040003C7 RID: 967
		internal static NetWrite Shared;
	}
}
