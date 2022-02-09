using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sandbox.Internal
{
	// Token: 0x02000170 RID: 368
	public readonly struct EntityComponentAccessor
	{
		// Token: 0x06001B73 RID: 7027 RVA: 0x0006E7F9 File Offset: 0x0006C9F9
		internal EntityComponentAccessor(Entity entity)
		{
			this.Entity = entity;
		}

		/// <summary>
		/// Add a component to this entity
		/// </summary>
		// Token: 0x06001B74 RID: 7028 RVA: 0x0006E804 File Offset: 0x0006CA04
		public T Add<T>(T component) where T : EntityComponent
		{
			if (component == null)
			{
				throw new ArgumentException("component is null");
			}
			if (component.Entity == this.Entity)
			{
				return component;
			}
			if (component.Entity.IsValid())
			{
				component.Entity.Components.Remove(component);
			}
			if (!component.CanAddToEntity(this.Entity))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(46, 2);
				defaultInterpolatedStringHandler.AppendLiteral("CanAddToEntity: Component ");
				defaultInterpolatedStringHandler.AppendFormatted<Type>(typeof(T));
				defaultInterpolatedStringHandler.AppendLiteral(" cannot be added to ");
				defaultInterpolatedStringHandler.AppendFormatted<Entity>(this.Entity);
				throw new InvalidOperationException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			component.Entity = this.Entity;
			this.Entity.OnComponentAddedInternal(component);
			return component;
		}

		/// <summary>
		/// Remove a component to this entity
		/// </summary>
		// Token: 0x06001B75 RID: 7029 RVA: 0x0006E8EA File Offset: 0x0006CAEA
		public bool Remove(EntityComponent component)
		{
			if (component == null)
			{
				throw new ArgumentException("component is null");
			}
			if (component.Entity != this.Entity)
			{
				return false;
			}
			component.Entity = null;
			this.Entity.OnComponentRemovedInternal(component);
			return true;
		}

		/// <summary>
		/// Remove all components to this entity
		/// </summary>
		// Token: 0x06001B76 RID: 7030 RVA: 0x0006E920 File Offset: 0x0006CB20
		public void RemoveAll()
		{
			if (this.Entity._components == null)
			{
				return;
			}
			if (this.Entity._components.Count == 0)
			{
				return;
			}
			while (this.Entity._components.Count > 0)
			{
				this.Remove(this.Entity._components[0]);
			}
		}

		/// <summary>
		/// Get a component by type, if it exists
		/// </summary>
		// Token: 0x06001B77 RID: 7031 RVA: 0x0006E97C File Offset: 0x0006CB7C
		public T Get<T>(bool includeDisabled = false) where T : class
		{
			if (this.Entity._components == null)
			{
				return default(T);
			}
			int count = this.Entity._components.Count;
			if (count == 0)
			{
				return default(T);
			}
			for (int i = 0; i < count; i++)
			{
				EntityComponent c = this.Entity._components[i];
				T t = c as T;
				if (t != null && (includeDisabled || c.Enabled))
				{
					return t;
				}
			}
			return default(T);
		}

		/// <summary>
		/// Returns true if component was found, else false
		/// </summary>
		// Token: 0x06001B78 RID: 7032 RVA: 0x0006EA09 File Offset: 0x0006CC09
		public bool TryGet<T>(out T component, bool includeDisabled = false) where T : class
		{
			component = this.Get<T>(includeDisabled);
			return component != null;
		}

		/// <summary>
		/// Get all components by type, if any exist
		/// </summary>
		// Token: 0x06001B79 RID: 7033 RVA: 0x0006EA26 File Offset: 0x0006CC26
		public IEnumerable<T> GetAll<T>(bool includeDisabled = false)
		{
			if (this.Entity._components == null)
			{
				yield break;
			}
			if (this.Entity._components.Count == 0)
			{
				yield break;
			}
			int num;
			for (int i = 0; i < this.Entity._components.Count; i = num + 1)
			{
				EntityComponent c = this.Entity._components[i];
				if (c is T)
				{
					T t = c as T;
					if (includeDisabled || c.Enabled)
					{
						yield return t;
					}
				}
				num = i;
			}
			yield break;
		}

		/// <summary>
		/// Get the component, create if it doesn't exist. Will include disabled components in search.
		/// </summary>
		// Token: 0x06001B7A RID: 7034 RVA: 0x0006EA44 File Offset: 0x0006CC44
		public T GetOrCreate<T>(bool startEnabled = true) where T : EntityComponent, new()
		{
			T c = this.Get<T>(true);
			if (c != null)
			{
				return c;
			}
			return this.Create<T>(startEnabled);
		}

		/// <summary>
		/// Create the component
		/// </summary>
		// Token: 0x06001B7B RID: 7035 RVA: 0x0006EA6C File Offset: 0x0006CC6C
		public T Create<T>(bool startEnabled = true) where T : EntityComponent, new()
		{
			T c = new T();
			c.Enabled = startEnabled;
			return this.Add<T>(c);
		}

		/// <summary>
		/// Get component at a specific index
		/// </summary>
		// Token: 0x06001B7C RID: 7036 RVA: 0x0006EA92 File Offset: 0x0006CC92
		internal EntityComponent GetAt(int index)
		{
			if (this.Entity._components == null)
			{
				return null;
			}
			if (index >= this.Entity._components.Count)
			{
				return null;
			}
			return this.Entity._components[index];
		}

		/// <summary>
		/// Set component at a specific index
		/// </summary>
		// Token: 0x06001B7D RID: 7037 RVA: 0x0006EACC File Offset: 0x0006CCCC
		internal void SetAt(int index, EntityComponent target)
		{
			if (this.Entity._components == null || this.Entity._components.Count == index)
			{
				this.Add<EntityComponent>(target);
				return;
			}
			if (index > this.Entity._components.Count)
			{
				this.Entity._components.Capacity = index + 1;
			}
			this.Entity._components[index] = target;
		}

		// Token: 0x04000785 RID: 1925
		private readonly Entity Entity;
	}
}
