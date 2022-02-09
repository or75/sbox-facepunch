using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Sandbox.Internal;

namespace Sandbox
{
	/// <summary>
	/// Each entity has a network table
	/// </summary>
	// Token: 0x020000C4 RID: 196
	public sealed class NetworkTable : IValid
	{
		// Token: 0x06001200 RID: 4608 RVA: 0x0004BECB File Offset: 0x0004A0CB
		public NetworkTable(Entity entity)
		{
			this.Entity = entity;
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06001201 RID: 4609 RVA: 0x0004BEE5 File Offset: 0x0004A0E5
		public bool IsValid
		{
			get
			{
				return this.Entity.IsValid();
			}
		}

		/// <summary>
		/// Can write under specific conditions
		/// </summary>
		// Token: 0x06001202 RID: 4610 RVA: 0x0004BEF2 File Offset: 0x0004A0F2
		public bool CanWrite(bool predicted)
		{
			return this.IsValid && (Host.IsServer || this.Entity.IsClientOnly || predicted);
		}

		/// <summary>
		/// Erase everything from the network tables
		/// </summary>
		// Token: 0x06001203 RID: 4611 RVA: 0x0004BF1C File Offset: 0x0004A11C
		public void Clear()
		{
			Var[] array = this.Table.Values.ToArray<Var>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Release();
			}
			this.Table.Clear();
		}

		/// <summary>
		/// Add a variable to this entity
		/// </summary>
		// Token: 0x06001204 RID: 4612 RVA: 0x0004BF5C File Offset: 0x0004A15C
		internal void AddVariable(Var var, int? location = null)
		{
			if (location == null)
			{
				location = new int?(this.FindEmptySlot());
			}
			if (location.Value < 0)
			{
				GlobalGameNamespace.Log.Info(FormattableStringFactory.Create("Invalid index ({0}) {1}", new object[] { location.Value, var }));
				return;
			}
			if (this.Table.ContainsKey(location.Value))
			{
				GlobalGameNamespace.Log.Info(FormattableStringFactory.Create("Forcing location but there's something already there!? ({0}) {1}", new object[]
				{
					location.Value,
					this.Table[location.Value]
				}));
			}
			this.Table[location.Value] = var;
			var.SetLocation(this, location.Value);
		}

		// Token: 0x06001205 RID: 4613 RVA: 0x0004C02C File Offset: 0x0004A22C
		private int FindEmptySlot()
		{
			for (int i = 0; i < 2147483647; i++)
			{
				if (!this.Table.ContainsKey(i))
				{
					return i;
				}
			}
			throw new Exception("Couldn't find an empty slot");
		}

		/// <summary>
		/// Try to get variable in slot
		/// </summary>
		// Token: 0x06001206 RID: 4614 RVA: 0x0004C064 File Offset: 0x0004A264
		internal Var GetAt(int index)
		{
			Var netVar;
			this.Table.TryGetValue(index, out netVar);
			return netVar;
		}

		/// <summary>
		///  Remove this variable from the data table, freeing up the slot
		/// </summary>
		// Token: 0x06001207 RID: 4615 RVA: 0x0004C084 File Offset: 0x0004A284
		internal void Release(Var var)
		{
			if (!this.Table.Remove(var.Index))
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Tried to remove var {0} - but key {1} wasn't found!", new object[] { var, var.Index }));
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06001208 RID: 4616 RVA: 0x0004C0D0 File Offset: 0x0004A2D0
		// (set) Token: 0x06001209 RID: 4617 RVA: 0x0004C0D8 File Offset: 0x0004A2D8
		internal Entity.PredictionDataStore LastPredictionFrame { get; set; }

		// Token: 0x0600120A RID: 4618 RVA: 0x0004C0E4 File Offset: 0x0004A2E4
		internal unsafe void Read(int slot, IntPtr data, int dataSize)
		{
			Var var;
			if (this.Table.TryGetValue(slot, out var))
			{
				NetRead read = new NetRead((byte*)(void*)data, dataSize);
				var.Read(read);
			}
		}

		// Token: 0x0600120B RID: 4619 RVA: 0x0004C118 File Offset: 0x0004A318
		internal void ReadAll(Entity.PredictionDataStore prediction)
		{
			this.LastPredictionFrame = prediction;
			foreach (Var entry in this.Table.Values.ToArray<Var>())
			{
				if (entry.Index >= 0)
				{
					entry.Read();
				}
			}
			this.LastPredictionFrame = null;
		}

		// Token: 0x0600120C RID: 4620 RVA: 0x0004C168 File Offset: 0x0004A368
		internal void ServerInitialize()
		{
			foreach (Var entry in this.Table.Values.ToArray<Var>())
			{
				if (entry.Index >= 0)
				{
					entry.Build();
				}
			}
			Var.WriteAll();
		}

		// Token: 0x0600120D RID: 4621 RVA: 0x0004C1AC File Offset: 0x0004A3AC
		internal void Write(Var e, IntPtr intPtr, int v)
		{
			if (this.Entity.serverEnt.IsValid)
			{
				this.Entity.serverEnt.SetData(e.Index, e.IsLocal, intPtr, v);
			}
		}

		// Token: 0x0600120E RID: 4622 RVA: 0x0004C1DE File Offset: 0x0004A3DE
		internal void Write(Var e, NetWrite writer)
		{
			this.Write(e, writer.DataPtr, writer.WrittenSize);
		}

		// Token: 0x0600120F RID: 4623 RVA: 0x0004C1F3 File Offset: 0x0004A3F3
		internal IntPtr Read(Var e, out int len)
		{
			len = 0;
			if (this.Entity.clientEnt.IsValid)
			{
				return this.Entity.clientEnt.GetData(e.Index, e.IsLocal, out len);
			}
			return IntPtr.Zero;
		}

		// Token: 0x06001210 RID: 4624 RVA: 0x0004C230 File Offset: 0x0004A430
		internal unsafe NetRead Read(Var e)
		{
			int len;
			return new NetRead((byte*)(void*)this.Read(e, out len), len);
		}

		// Token: 0x06001211 RID: 4625 RVA: 0x0004C254 File Offset: 0x0004A454
		public List<Var> CollectVariables(INetworkTable source, bool deterministic)
		{
			if (this.Variables != null)
			{
				throw new Exception("Started collecting during collection");
			}
			if (source == null)
			{
				return null;
			}
			source.BuildNetworkTable(this);
			if (this.Variables == null)
			{
				return null;
			}
			List<Var> variables = this.Variables;
			this.Variables = null;
			if (Host.IsServer || deterministic)
			{
				foreach (Var v in variables)
				{
					this.AddVariable(v, null);
				}
				foreach (Var var in variables)
				{
					var.Build();
				}
			}
			return variables;
		}

		// Token: 0x06001212 RID: 4626 RVA: 0x0004C328 File Offset: 0x0004A528
		public void Register<T>(ref T var, string name, bool predicted, bool local) where T : Var, new()
		{
			if (this.Variables == null)
			{
				this.Variables = new List<Var>();
			}
			if (var == null)
			{
				var = new T();
			}
			var.OnRegister(this, name, predicted, local);
			this.Variables.Add(var);
		}

		// Token: 0x040003B7 RID: 951
		internal Entity Entity;

		// Token: 0x040003B8 RID: 952
		internal Dictionary<int, Var> Table = new Dictionary<int, Var>();

		// Token: 0x040003BA RID: 954
		internal List<Var> Variables;
	}
}
