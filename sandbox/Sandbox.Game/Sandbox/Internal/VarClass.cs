using System;
using System.Runtime.CompilerServices;

namespace Sandbox.Internal
{
	// Token: 0x0200017A RID: 378
	public class VarClass<T> : VarContainer where T : LibraryClass, INetworkTable
	{
		// Token: 0x06001BB5 RID: 7093 RVA: 0x0006F404 File Offset: 0x0006D604
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 2);
			defaultInterpolatedStringHandler.AppendLiteral("VarClass<");
			defaultInterpolatedStringHandler.AppendFormatted<Type>(typeof(T));
			defaultInterpolatedStringHandler.AppendLiteral(">(");
			defaultInterpolatedStringHandler.AppendFormatted<T>(this.Value);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06001BB6 RID: 7094 RVA: 0x0006F464 File Offset: 0x0006D664
		public VarClass()
		{
		}

		// Token: 0x06001BB7 RID: 7095 RVA: 0x0006F46C File Offset: 0x0006D66C
		public VarClass(T defaultValue = default(T))
		{
			this.Value = defaultValue;
		}

		// Token: 0x06001BB8 RID: 7096 RVA: 0x0006F47C File Offset: 0x0006D67C
		public T GetValue()
		{
			T value;
			if ((value = this.Value) == null)
			{
				VarClass<T> proxyVar = this.ProxyVar;
				if (proxyVar == null)
				{
					return default(T);
				}
				value = proxyVar.Value;
			}
			return value;
		}

		// Token: 0x06001BB9 RID: 7097 RVA: 0x0006F4B4 File Offset: 0x0006D6B4
		public void SetValue(T val)
		{
			this.ProxyVar = null;
			if (this.Value == val)
			{
				return;
			}
			if (!base.CanChangeValue())
			{
				return;
			}
			if (val is Entity)
			{
				throw new Exception("Trying to send entity as a INetworkTable");
			}
			BaseNetworkable oldBase = this.Value as BaseNetworkable;
			if (oldBase != null)
			{
				oldBase.NetworkVariable = null;
			}
			this.Value = val;
			this.Instance += 1;
			if (Host.IsServer)
			{
				BaseNetworkable newBase = this.Value as BaseNetworkable;
				if (newBase != null)
				{
					VarClass<T> oldNetVar = newBase.NetworkVariable as VarClass<T>;
					if (oldNetVar != null && oldNetVar != this)
					{
						oldNetVar.ReleaseVariables();
						oldNetVar.Value = default(T);
						oldNetVar.ProxyVar = this;
						oldNetVar.SetDirty(false);
					}
					newBase.NetworkVariable = this;
				}
				this.Build();
				this.SetDirty(false);
			}
		}

		// Token: 0x06001BBA RID: 7098 RVA: 0x0006F590 File Offset: 0x0006D790
		internal override void Build()
		{
			if (Host.IsClient)
			{
				return;
			}
			if (this.NetworkTable == null)
			{
				return;
			}
			base.Build();
			if (this.Value is INetworkSerializer)
			{
				return;
			}
			base.ReleaseVariables();
			this.Variables = this.NetworkTable.CollectVariables(this.Value, false);
		}

		// Token: 0x06001BBB RID: 7099 RVA: 0x0006F5EC File Offset: 0x0006D7EC
		internal override void Write(NetWrite writer)
		{
			if (Host.IsClient)
			{
				return;
			}
			if (this.Value == null)
			{
				if (this.ProxyVar != null)
				{
					writer.Write<int>(-1);
					writer.Write<int>(this.ProxyVar.Index);
					return;
				}
				writer.Write<int>(0);
				writer.Write<short>(0);
				return;
			}
			else
			{
				writer.Write<int>(this.Value.LibraryClassIdentifier);
				writer.Write<short>(this.Instance);
				INetworkSerializer serializer = this.Value as INetworkSerializer;
				if (serializer != null)
				{
					serializer.Write(writer);
					return;
				}
				if (this.Variables == null || this.Variables.Count == 0)
				{
					writer.Write<short>(0);
					return;
				}
				writer.Write<short>((short)this.Variables.Count);
				foreach (Var var in this.Variables)
				{
					writer.Write<short>((short)var.Index);
				}
				return;
			}
		}

		// Token: 0x06001BBC RID: 7100 RVA: 0x0006F6F8 File Offset: 0x0006D8F8
		internal override void Read(NetRead reader)
		{
			if (!Host.IsClient)
			{
				return;
			}
			if (reader.Remaining == 0)
			{
				return;
			}
			T oldValue = this.Value;
			try
			{
				int identifier = reader.Read<int>();
				if (identifier == -1)
				{
					int index = reader.Read<int>();
					if (!this.NetworkTable.Table.ContainsKey(index))
					{
						GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Could not proxy var {0} as it does not exist in the network table", new object[] { index }));
					}
					else
					{
						this.ProxyVar = this.NetworkTable.Table[index] as VarClass<T>;
					}
				}
				else
				{
					this.ProxyVar = null;
					short instance = reader.Read<short>();
					int num = identifier;
					T t = this.Value;
					if (num != ((t != null) ? t.LibraryClassIdentifier : 0) || instance != this.Instance)
					{
						this.FindOrCreateClass(identifier, instance);
					}
					this.NeedsRebuild = this.NeedsRebuild || this.Value != oldValue;
					INetworkSerializer serializer = this.Value as INetworkSerializer;
					if (serializer != null)
					{
						serializer.Read(ref reader);
					}
					else if (this.NeedsRebuild)
					{
						this.NeedsRebuild = false;
						base.ReleaseVariables();
						this.Variables = this.NetworkTable.CollectVariables(this.Value, false);
						if (this.Value != null)
						{
							int numVariables = (int)reader.Read<short>();
							if (numVariables != base.VariableCount)
							{
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 2);
								defaultInterpolatedStringHandler.AppendLiteral("Variable count different ");
								defaultInterpolatedStringHandler.AppendFormatted<int>(numVariables);
								defaultInterpolatedStringHandler.AppendLiteral(" != ");
								defaultInterpolatedStringHandler.AppendFormatted<int>(base.VariableCount);
								throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
							}
							for (int i = 0; i < numVariables; i++)
							{
								this.NetworkTable.AddVariable(this.Variables[i], new int?((int)reader.Read<short>()));
							}
							for (int j = 0; j < numVariables; j++)
							{
								this.Variables[j].Read();
							}
						}
					}
				}
			}
			finally
			{
				base.CheckValueChanged(oldValue, this.Value);
			}
		}

		// Token: 0x06001BBD RID: 7101 RVA: 0x0006F944 File Offset: 0x0006DB44
		public void FindOrCreateClass(int identifier, short instance)
		{
			if (identifier == 0)
			{
				this.Value = default(T);
				return;
			}
			if (identifier == -1)
			{
				if (this.Value == null)
				{
					this.Value = Activator.CreateInstance(typeof(T)) as T;
				}
				return;
			}
			if (this.Value == null || this.Value.LibraryClassIdentifier != identifier || instance != this.Instance)
			{
				Entity.PredictionDataStore predictionData = this.NetworkTable.LastPredictionFrame;
				object objectVal;
				if (predictionData != null && this.Name != null && predictionData.TryGetValue(this.Name, out objectVal))
				{
					this.Value = objectVal as T;
				}
				if (this.Value == null || this.Value.LibraryClassIdentifier != identifier || instance != this.Instance)
				{
					this.Value = Library.TryCreate<T>(identifier);
				}
			}
			this.Instance = instance;
		}

		// Token: 0x04000795 RID: 1941
		private T Value;

		// Token: 0x04000796 RID: 1942
		private short Instance;

		// Token: 0x04000797 RID: 1943
		private VarClass<T> ProxyVar;
	}
}
