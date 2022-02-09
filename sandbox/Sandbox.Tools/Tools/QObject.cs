using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Native;
using Sandbox;
using Sandbox.Internal;

namespace Tools
{
	// Token: 0x020000C2 RID: 194
	public class QObject : IValid
	{
		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06001645 RID: 5701 RVA: 0x00059161 File Offset: 0x00057361
		bool IValid.IsValid
		{
			get
			{
				return this.IsValid;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06001646 RID: 5702 RVA: 0x00059169 File Offset: 0x00057369
		[Browsable(false)]
		public bool IsValid
		{
			get
			{
				return this._object.IsValid && !this.IsDestroyed;
			}
		}

		// Token: 0x06001647 RID: 5703 RVA: 0x00059184 File Offset: 0x00057384
		internal virtual void NativeInit(IntPtr ptr)
		{
			if (ptr == (IntPtr)0)
			{
				throw new Exception("QObject was null!");
			}
			this._object = ptr;
			QObject.AllObjects[this._object] = this;
			WidgetUtil.OnObject_Destroyed(ptr, this.Callback(new QObject.CallbackMethod(this.NativeShutdown)));
			Event.Register(this);
		}

		// Token: 0x06001648 RID: 5704 RVA: 0x000591E7 File Offset: 0x000573E7
		public virtual void OnDestroyed()
		{
		}

		// Token: 0x06001649 RID: 5705 RVA: 0x000591EC File Offset: 0x000573EC
		internal virtual void NativeShutdown()
		{
			Event.Unregister(this);
			InteropSystem.Free<QObject>(this);
			QObject.AllObjects.Remove(this._object);
			this._object = default(QObject);
			foreach (KeyValuePair<GCHandle, QObject.CallbackMethod> handle in this._handles)
			{
				handle.Key.Free();
			}
			this._handles.Clear();
			this.OnDestroyed();
		}

		// Token: 0x0600164A RID: 5706 RVA: 0x00059284 File Offset: 0x00057484
		internal IntPtr Callback(QObject.CallbackMethod cb)
		{
			QObject.CallbackMethod wrapped = delegate()
			{
				try
				{
					cb();
				}
				catch (Exception ex)
				{
					GlobalToolsNamespace.Log.Error(ex);
				}
			};
			this._handles.Add(GCHandle.Alloc(wrapped), wrapped);
			return Marshal.GetFunctionPointerForDelegate<QObject.CallbackMethod>(wrapped);
		}

		// Token: 0x0600164B RID: 5707 RVA: 0x000592C1 File Offset: 0x000574C1
		public void Destroy()
		{
			if (this.IsDestroyed)
			{
				return;
			}
			Event.Unregister(this);
			if (this._object.IsValid)
			{
				this._object.deleteLater();
			}
			this.IsDestroyed = true;
		}

		// Token: 0x0600164C RID: 5708 RVA: 0x000592F4 File Offset: 0x000574F4
		internal QObject[] GetChildren(out int c)
		{
			QObject[] list = new QObject[512];
			c = WidgetUtil.GetChildren(this._object, list, list.Length);
			return list;
		}

		// Token: 0x0600164D RID: 5709 RVA: 0x00059320 File Offset: 0x00057520
		internal static QObject FindOrCreate(QObject obj)
		{
			QObject handle;
			if (QObject.AllObjects.TryGetValue(obj, out handle))
			{
				return handle;
			}
			QPushButton ptr = (QPushButton)obj;
			if (ptr.IsValid)
			{
				return new Button(ptr);
			}
			QTabBar ptr2 = (QTabBar)obj;
			if (ptr2.IsValid)
			{
				return new TabBar(ptr2);
			}
			QMenuBar ptr3 = (QMenuBar)obj;
			if (ptr3.IsValid)
			{
				return new MenuBar(ptr3);
			}
			QWidget ptr4 = (QWidget)obj;
			if (ptr4.IsValid)
			{
				return new Widget(ptr4);
			}
			return null;
		}

		// Token: 0x0600164E RID: 5710 RVA: 0x000593A2 File Offset: 0x000575A2
		public void SetProperty(string name, bool value)
		{
			this._object.setProperty(name, value);
		}

		// Token: 0x0600164F RID: 5711 RVA: 0x000593B1 File Offset: 0x000575B1
		public void SetProperty(string name, float value)
		{
			this._object.setProperty(name, value);
		}

		// Token: 0x06001650 RID: 5712 RVA: 0x000593C0 File Offset: 0x000575C0
		public void SetProperty(string name, string value)
		{
			this._object.setProperty(name, value);
		}

		// Token: 0x04000491 RID: 1169
		internal static Dictionary<QObject, QObject> AllObjects = new Dictionary<QObject, QObject>();

		// Token: 0x04000492 RID: 1170
		internal QObject _object;

		// Token: 0x04000493 RID: 1171
		internal Dictionary<GCHandle, QObject.CallbackMethod> _handles = new Dictionary<GCHandle, QObject.CallbackMethod>();

		// Token: 0x04000494 RID: 1172
		private bool IsDestroyed;

		// Token: 0x02000157 RID: 343
		// (Invoke) Token: 0x0600183C RID: 6204
		internal delegate void CallbackMethod();
	}
}
