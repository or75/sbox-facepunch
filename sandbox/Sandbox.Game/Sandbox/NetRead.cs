using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Sandbox
{
	// Token: 0x020000C7 RID: 199
	public ref struct NetRead
	{
		/// <summary>
		/// The amount of data (in bytes) remaining to be read
		/// </summary>
		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06001222 RID: 4642 RVA: 0x0004C9F0 File Offset: 0x0004ABF0
		public int Remaining
		{
			get
			{
				return this.Size;
			}
		}

		// Token: 0x06001223 RID: 4643 RVA: 0x0004C9F8 File Offset: 0x0004ABF8
		internal unsafe NetRead(byte* data, int size)
		{
			this.Data = data;
			this.Size = size;
		}

		/// <summary>
		/// Get whether or not a type can be read by NetRead.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06001224 RID: 4644 RVA: 0x0004CA08 File Offset: 0x0004AC08
		public static bool IsSupported(Type type)
		{
			if (type.IsValueType || type.IsEnum)
			{
				return true;
			}
			if (type == typeof(string))
			{
				return true;
			}
			if (type.IsClass)
			{
				if (type.IsAssignableTo(typeof(Entity)))
				{
					return true;
				}
				if (type.IsAssignableTo(typeof(Resource)))
				{
					return true;
				}
			}
			return type.IsArray && NetRead.IsSupported(type.GetElementType());
		}

		/// <summary>
		/// Get whether or not a value can be read by NetRead. This is a little
		/// trick because `GetType()` does not work with Span.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06001225 RID: 4645 RVA: 0x0004CA80 File Offset: 0x0004AC80
		public static bool IsSupported<[IsUnmanaged] T>(Span<T> _) where T : struct, ValueType
		{
			return true;
		}

		/// <summary>
		/// Get whether or not a value can be read by NetRead.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06001226 RID: 4646 RVA: 0x0004CA83 File Offset: 0x0004AC83
		public static bool IsSupported(object value)
		{
			return value == null || NetRead.IsSupported(value.GetType());
		}

		// Token: 0x06001227 RID: 4647 RVA: 0x0004CA98 File Offset: 0x0004AC98
		internal Entity ReadEntity()
		{
			int index = this.Read<int>();
			if (index < 0)
			{
				return null;
			}
			return Entity.FindByIndex(index);
		}

		// Token: 0x06001228 RID: 4648 RVA: 0x0004CAB8 File Offset: 0x0004ACB8
		internal Resource ReadResource()
		{
			int index = this.Read<int>();
			if (index == 0)
			{
				return null;
			}
			return Resource.FromId<Resource>(index);
		}

		// Token: 0x06001229 RID: 4649 RVA: 0x0004CAD8 File Offset: 0x0004ACD8
		internal Asset ReadAsset()
		{
			int index = this.Read<int>();
			if (index == 0)
			{
				return null;
			}
			return Asset.FromId<Asset>(index);
		}

		// Token: 0x0600122A RID: 4650 RVA: 0x0004CAF8 File Offset: 0x0004ACF8
		public T ReadClass<T>(T def = default(T)) where T : class
		{
			Type t = typeof(T);
			if (t == typeof(string))
			{
				return this.ReadString() as T;
			}
			if (t.IsAssignableTo(typeof(Resource)))
			{
				return this.ReadResource() as T;
			}
			if (t.IsAssignableTo(typeof(Asset)))
			{
				return this.ReadAsset() as T;
			}
			if (t.IsAssignableTo(typeof(Client)))
			{
				return this.ReadEntity() as T;
			}
			if (t.IsAssignableTo(typeof(Entity)))
			{
				return this.ReadEntity() as T;
			}
			return default(T);
		}

		/// <summary>
		/// A dedicated method for arrays of unmanaged types that is faster to allow processing
		/// of large arrays
		/// </summary>
		// Token: 0x0600122B RID: 4651 RVA: 0x0004CBC8 File Offset: 0x0004ADC8
		public unsafe T[] ReadUnmanagedArray<[IsUnmanaged] T>(T[] array) where T : struct, ValueType
		{
			int len = this.Read<int>();
			if (len == -1)
			{
				return null;
			}
			this.LengthAssert(len);
			if (array == null || array.Length != len)
			{
				array = new T[len];
			}
			int itemSize = Unsafe.SizeOf<T>();
			for (int i = 0; i < len; i++)
			{
				array[i] = Unsafe.Read<T>((void*)this.Data);
				this.Data += itemSize;
			}
			this.Size -= itemSize * len;
			return array;
		}

		// Token: 0x0600122C RID: 4652 RVA: 0x0004CC40 File Offset: 0x0004AE40
		public T[] ReadArray<[IsUnmanaged] T>(T[] val) where T : struct, ValueType
		{
			int len = this.Read<int>();
			if (len == -1)
			{
				return null;
			}
			if (len > 512)
			{
				throw new Exception("Network " + typeof(T).Name + " array cannot contain more than 512 elements!");
			}
			if (val == null || val.Length != len)
			{
				val = new T[len];
			}
			for (int i = 0; i < len; i++)
			{
				val[i] = this.Read<T>();
			}
			return val;
		}

		// Token: 0x0600122D RID: 4653 RVA: 0x0004CCB4 File Offset: 0x0004AEB4
		public T[] ReadArrayClass<T>(T[] val) where T : class
		{
			int len = this.Read<int>();
			if (len == -1)
			{
				return null;
			}
			if (len > 512)
			{
				throw new Exception("Network " + typeof(T).Name + " array cannot contain more than 512 elements!");
			}
			if (val == null || val.Length != len)
			{
				val = new T[len];
			}
			for (int i = 0; i < len; i++)
			{
				val[i] = this.ReadClass<T>(default(T));
			}
			return val;
		}

		// Token: 0x0600122E RID: 4654 RVA: 0x0004CD30 File Offset: 0x0004AF30
		public unsafe Span<T> ReadData<[IsUnmanaged] T>(Span<T> _) where T : struct, ValueType
		{
			int len = this.Read<int>();
			if (len == -1)
			{
				return null;
			}
			this.LengthAssert(len);
			T[] array = new T[len];
			int itemSize = Unsafe.SizeOf<T>();
			for (int i = 0; i < len; i++)
			{
				array[i] = Unsafe.Read<T>((void*)this.Data);
				this.Data += itemSize;
			}
			this.Size -= itemSize * len;
			return new Span<T>(array);
		}

		// Token: 0x0600122F RID: 4655 RVA: 0x0004CDA5 File Offset: 0x0004AFA5
		public T ReadData<[IsUnmanaged] T>(T _) where T : struct, ValueType
		{
			return this.Read<T>();
		}

		// Token: 0x06001230 RID: 4656 RVA: 0x0004CDB0 File Offset: 0x0004AFB0
		public unsafe T Read<[IsUnmanaged] T>() where T : struct, ValueType
		{
			int objSize = Unsafe.SizeOf<T>();
			this.LengthAssert(objSize);
			void* d = (void*)this.Data;
			this.Data += objSize;
			this.Size -= objSize;
			return Unsafe.Read<T>(d);
		}

		/// <summary>
		/// Like read, but will return default if not enough size left
		/// </summary>
		// Token: 0x06001231 RID: 4657 RVA: 0x0004CDF4 File Offset: 0x0004AFF4
		public unsafe T TryRead<[IsUnmanaged] T>() where T : struct, ValueType
		{
			int objSize = Unsafe.SizeOf<T>();
			if (objSize > this.Size)
			{
				return default(T);
			}
			void* d = (void*)this.Data;
			this.Data += objSize;
			this.Size -= objSize;
			return Unsafe.Read<T>(d);
		}

		// Token: 0x06001232 RID: 4658 RVA: 0x0004CE44 File Offset: 0x0004B044
		public void LengthAssert(int size)
		{
			if (this.Size < size)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Tried to read ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(size);
				defaultInterpolatedStringHandler.AppendLiteral(" but only have ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.Size);
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (this.Data == null)
			{
				throw new ObjectDisposedException("NetRead");
			}
		}

		// Token: 0x06001233 RID: 4659 RVA: 0x0004CEB4 File Offset: 0x0004B0B4
		public string ReadString()
		{
			int datasize = this.Read<int>();
			if (datasize == -1)
			{
				return null;
			}
			if (datasize == 0)
			{
				return string.Empty;
			}
			this.LengthAssert(datasize);
			string @string = Encoding.UTF8.GetString(this.Data, datasize);
			this.Data += datasize;
			this.Size -= datasize;
			return @string;
		}

		// Token: 0x06001234 RID: 4660 RVA: 0x0004CF0C File Offset: 0x0004B10C
		public object ReadObject()
		{
			SerializeObjectType type = (SerializeObjectType)this.Read<byte>();
			switch (type)
			{
			case SerializeObjectType.Null:
				return null;
			case SerializeObjectType.Int:
				return this.Read<int>();
			case SerializeObjectType.Float:
				return this.Read<float>();
			case SerializeObjectType.Vector3:
				return this.Read<Vector3>();
			case SerializeObjectType.String:
				return this.ReadString();
			case SerializeObjectType.Entity:
				return this.ReadEntity();
			case SerializeObjectType.Bool:
				return this.Read<bool>();
			case SerializeObjectType.UInt:
				return this.Read<uint>();
			default:
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Unhandled ReadObject type ");
				defaultInterpolatedStringHandler.AppendFormatted<SerializeObjectType>(type);
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			}
		}

		// Token: 0x040003C0 RID: 960
		private unsafe byte* Data;

		// Token: 0x040003C1 RID: 961
		private int Size;
	}
}
