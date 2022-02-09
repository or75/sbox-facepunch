using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using NativeEngine;
using Sandbox.Html;
using Sandbox.Internal;
using Sandbox.Internal.UI;
using Sandbox.UI.Construct;
using Sandbox.UI.DataSource;

namespace Sandbox.UI
{
	// Token: 0x02000122 RID: 290
	[Library("panel", Alias = new string[] { "div", "span" })]
	[Display(Name = "Panel")]
	[Icon("view_quilt")]
	public class Panel : LibraryClass, IPanel
	{
		// Token: 0x1700035B RID: 859
		// (get) Token: 0x06001620 RID: 5664 RVA: 0x00058D90 File Offset: 0x00056F90
		[Browsable(false)]
		public PanelCreator Add
		{
			get
			{
				return new PanelCreator(this);
			}
		}

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x06001621 RID: 5665 RVA: 0x00058D98 File Offset: 0x00056F98
		[Browsable(false)]
		public IEnumerable<Panel> Children
		{
			get
			{
				if (this._children != null)
				{
					return this._children;
				}
				return Enumerable.Empty<Panel>();
			}
		}

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x06001622 RID: 5666 RVA: 0x00058DBB File Offset: 0x00056FBB
		[Browsable(false)]
		public bool HasChildren
		{
			get
			{
				return this._children != null && this._children.Count > 0;
			}
		}

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x06001623 RID: 5667 RVA: 0x00058DD5 File Offset: 0x00056FD5
		// (set) Token: 0x06001624 RID: 5668 RVA: 0x00058DE0 File Offset: 0x00056FE0
		[Browsable(false)]
		public Panel Parent
		{
			get
			{
				return this._parent;
			}
			set
			{
				if (this is RootPanel && value != null)
				{
					throw new Exception("Can't parent a RootPanel");
				}
				if (value == this)
				{
					throw new Exception("Can't parent a panel to itself");
				}
				if (this._parent == value)
				{
					return;
				}
				Panel oldParent = this._parent;
				this._parent = null;
				if (oldParent != null)
				{
					oldParent.RemoveChild(this);
				}
				this._parent = value;
				if (this._parent != null)
				{
					if (this.YogaNode == null)
					{
						this.YogaNode = new YogaWrapper();
					}
					this._parent.InternalAddChild(this);
					if (oldParent == null)
					{
						this.AddToLists();
					}
				}
				this.ParentHasChanged = true;
			}
		}

		/// <summary>
		/// Called internally when a child is removed, to remove from our Children list
		/// </summary>
		// Token: 0x06001625 RID: 5669 RVA: 0x00058E74 File Offset: 0x00057074
		private void RemoveChild(Panel p)
		{
			if (this._children == null)
			{
				throw new Exception("RemoveChild but no children!");
			}
			if (this._childrenHash.Remove(p))
			{
				this._children.Remove(p);
				this._renderChildren.Remove(p);
				if (p.YogaNode != null)
				{
					YogaWrapper yogaNode = this.YogaNode;
					if (yogaNode != null)
					{
						yogaNode.RemoveChild(p.YogaNode);
					}
				}
				this.OnChildRemoved(p);
				this.IndexesDirty = true;
				return;
			}
			throw new Exception("Removed Child but didn't have child!");
		}

		/// <summary>
		/// A child panel has been removed from this panel
		/// </summary>
		// Token: 0x06001626 RID: 5670 RVA: 0x00058EF4 File Offset: 0x000570F4
		protected virtual void OnChildRemoved(Panel child)
		{
		}

		// Token: 0x06001627 RID: 5671 RVA: 0x00058EF8 File Offset: 0x000570F8
		public void DeleteChildren(bool immediate = false)
		{
			Panel[] array = this.Children.ToArray<Panel>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Delete(immediate);
			}
		}

		/// <summary>
		/// Add a child to this panel
		/// </summary>
		// Token: 0x06001628 RID: 5672 RVA: 0x00058F28 File Offset: 0x00057128
		public void AddChild(Panel p)
		{
			p.Parent = this;
		}

		/// <summary>
		/// Called internally when a child is added, to add to our Children list
		/// </summary>
		// Token: 0x06001629 RID: 5673 RVA: 0x00058F34 File Offset: 0x00057134
		private void InternalAddChild(Panel p)
		{
			YogaWrapper yogaNode = this.YogaNode;
			if (yogaNode != null && yogaNode.IsMeasureDefined)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
				defaultInterpolatedStringHandler.AppendFormatted<Panel>(this);
				defaultInterpolatedStringHandler.AppendLiteral(" can not have children.");
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (this._children == null)
			{
				this._children = new List<Panel>();
			}
			if (this._renderChildren == null)
			{
				this._renderChildren = new List<Panel>();
			}
			if (this._childrenHash == null)
			{
				this._childrenHash = new HashSet<Panel>();
			}
			if (this._childrenHash.Contains(p))
			{
				throw new Exception("AddChild but already have child!");
			}
			this._childrenHash.Add(p);
			this._children.Add(p);
			this._renderChildren.Add(p);
			YogaWrapper yogaNode2 = this.YogaNode;
			if (yogaNode2 != null)
			{
				yogaNode2.AddChild(p.YogaNode);
			}
			this.OnChildAdded(p);
			this.IndexesDirty = true;
		}

		/// <summary>
		/// A child panel has been added to this panel
		/// </summary>
		// Token: 0x0600162A RID: 5674 RVA: 0x0005901C File Offset: 0x0005721C
		protected virtual void OnChildAdded(Panel child)
		{
		}

		/// <summary>
		/// Sort the children using this comparison function
		/// </summary>
		// Token: 0x0600162B RID: 5675 RVA: 0x00059020 File Offset: 0x00057220
		public void SortChildren(Comparison<Panel> sorter)
		{
			if (this._children == null || this._children.Count <= 0)
			{
				return;
			}
			this._children.Sort(sorter);
			int i = 0;
			foreach (Panel child in this._children)
			{
				child.UpdateSiblingIndex(i++, this._children.Count);
				this.YogaNode.RemoveChild(child.YogaNode);
				this.YogaNode.AddChild(child.YogaNode);
			}
			this.IndexesDirty = true;
		}

		// Token: 0x0600162C RID: 5676 RVA: 0x000590D0 File Offset: 0x000572D0
		private void UpdateChildrenIndexes()
		{
			this.IndexesDirty = false;
			List<Panel> children = this._children;
			int count = ((children != null) ? children.Count : 0);
			this.Switch(PseudoClass.Empty, count > 0);
			if (count == 0)
			{
				return;
			}
			for (int i = 0; i < count; i++)
			{
				this._children[i].UpdateSiblingIndex(i, count);
			}
		}

		// Token: 0x0600162D RID: 5677 RVA: 0x0005912C File Offset: 0x0005732C
		internal void UpdateSiblingIndex(int index, int siblings)
		{
			this.Switch(PseudoClass.FirstChild, index == 0);
			this.Switch(PseudoClass.LastChild, index == siblings - 1);
			this.Switch(PseudoClass.OnlyChild, index == 0 && siblings == 1);
			this.SiblingIndex = index + 1;
		}

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x0600162E RID: 5678 RVA: 0x0005917A File Offset: 0x0005737A
		// (set) Token: 0x0600162F RID: 5679 RVA: 0x00059182 File Offset: 0x00057382
		[Browsable(false)]
		public int SiblingIndex { get; internal set; }

		/// <summary>
		/// Sort the children using this comparison function
		/// </summary>
		// Token: 0x06001630 RID: 5680 RVA: 0x0005918C File Offset: 0x0005738C
		public void SortChildren<TargetType>(Func<TargetType, int> sorter)
		{
			if (this._children == null || this._children.Count <= 0)
			{
				return;
			}
			Panel[] sorted = this._children.OrderBy(delegate(Panel x)
			{
				if (x is TargetType)
				{
					TargetType tt = x as TargetType;
					return sorter(tt);
				}
				return 0;
			}).ToArray<Panel>();
			this._children.Clear();
			this._children.AddRange(sorted);
			foreach (Panel child in this._children)
			{
				this.YogaNode.RemoveChild(child.YogaNode);
				this.YogaNode.AddChild(child.YogaNode);
			}
			this.IndexesDirty = true;
		}

		/// <summary>
		/// Sort the children using this comparison function
		/// </summary>
		// Token: 0x06001631 RID: 5681 RVA: 0x0005925C File Offset: 0x0005745C
		public void SortChildren(Func<Panel, int> sorter)
		{
			this.SortChildren<Panel>(sorter);
		}

		// Token: 0x06001632 RID: 5682 RVA: 0x00059268 File Offset: 0x00057468
		public T AddChild<T>(string classnames = null) where T : Panel, new()
		{
			T t = new T();
			t.Parent = this;
			if (classnames != null)
			{
				t.AddClass(classnames);
			}
			return t;
		}

		// Token: 0x06001633 RID: 5683 RVA: 0x00059298 File Offset: 0x00057498
		public bool AddChild<T>(out T outPanel, string classnames = null) where T : Panel, new()
		{
			T t = new T();
			t.Parent = this;
			if (classnames != null)
			{
				t.AddClass(classnames);
			}
			outPanel = t;
			return true;
		}

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x06001634 RID: 5684 RVA: 0x000592CE File Offset: 0x000574CE
		[Browsable(false)]
		public IEnumerable<Panel> AncestorsAndSelf
		{
			get
			{
				for (Panel p = this; p != null; p = p.Parent)
				{
					yield return p;
				}
				yield break;
			}
		}

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06001635 RID: 5685 RVA: 0x000592DE File Offset: 0x000574DE
		[Browsable(false)]
		public IEnumerable<Panel> Ancestors
		{
			get
			{
				for (Panel p = this.Parent; p != null; p = p.Parent)
				{
					yield return p;
				}
				yield break;
			}
		}

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06001636 RID: 5686 RVA: 0x000592EE File Offset: 0x000574EE
		[Browsable(false)]
		public IEnumerable<Panel> Descendants
		{
			get
			{
				foreach (Panel child in this.Children)
				{
					yield return child;
					foreach (Panel descendant in child.Descendants)
					{
						yield return descendant;
					}
					IEnumerator<Panel> enumerator2 = null;
					child = null;
				}
				IEnumerator<Panel> enumerator = null;
				yield break;
				yield break;
			}
		}

		/// <summary>
		/// Is the passed panel a parent, grandparent etc
		/// </summary>
		// Token: 0x06001637 RID: 5687 RVA: 0x000592FE File Offset: 0x000574FE
		public bool IsAncestor(Panel panel)
		{
			return panel == this || (this.Parent != null && this.Parent.IsAncestor(panel));
		}

		// Token: 0x06001638 RID: 5688 RVA: 0x0005931C File Offset: 0x0005751C
		public RootPanel FindRootPanel()
		{
			RootPanel rp = this as RootPanel;
			if (rp != null)
			{
				return rp;
			}
			Panel parent = this.Parent;
			if (parent == null)
			{
				return null;
			}
			return parent.FindRootPanel();
		}

		// Token: 0x06001639 RID: 5689 RVA: 0x00059346 File Offset: 0x00057546
		public virtual Panel FindPopupPanel()
		{
			if (this.Parent == null)
			{
				return this;
			}
			Panel parent = this.Parent;
			if (parent == null)
			{
				return null;
			}
			return parent.FindPopupPanel();
		}

		// Token: 0x0600163A RID: 5690 RVA: 0x00059363 File Offset: 0x00057563
		public int GetChildIndex(Panel panel)
		{
			if (panel == null || panel.Parent != this)
			{
				return -1;
			}
			if (this._children == null || this._children.Count == 0)
			{
				return -1;
			}
			return this._children.IndexOf(panel);
		}

		// Token: 0x0600163B RID: 5691 RVA: 0x00059398 File Offset: 0x00057598
		public Panel GetChild(int index, bool loop = false)
		{
			if (this._children == null || this._children.Count == 0)
			{
				return null;
			}
			if (loop)
			{
				index = index.UnsignedMod(this.Children.Count<Panel>());
			}
			else
			{
				if (index < 0)
				{
					return null;
				}
				if (index >= this._children.Count)
				{
					return null;
				}
			}
			return this._children[index];
		}

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x0600163C RID: 5692 RVA: 0x000593F6 File Offset: 0x000575F6
		[Browsable(false)]
		[Obsolete]
		public int ChildCount
		{
			get
			{
				return this.ChildrenCount;
			}
		}

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x0600163D RID: 5693 RVA: 0x000593FE File Offset: 0x000575FE
		[Browsable(false)]
		public int ChildrenCount
		{
			get
			{
				List<Panel> children = this._children;
				if (children == null)
				{
					return 0;
				}
				return children.Count;
			}
		}

		// Token: 0x0600163E RID: 5694 RVA: 0x00059411 File Offset: 0x00057611
		public IEnumerable<T> ChildrenOfType<T>() where T : Panel
		{
			if (this._children == null || this._children.Count == 0)
			{
				yield break;
			}
			int c = this._children.Count;
			int num;
			for (int i = c - 1; i >= 0; i = num - 1)
			{
				T t = this._children[i] as T;
				if (t != null)
				{
					yield return t;
				}
				num = i;
			}
			yield break;
		}

		/// <summary>
		/// A list of classes applied to this panel
		/// </summary>
		// Token: 0x17000365 RID: 869
		// (get) Token: 0x0600163F RID: 5695 RVA: 0x00059424 File Offset: 0x00057624
		[Browsable(false)]
		public IEnumerable<string> Class
		{
			get
			{
				IEnumerable<string> @class = this._class;
				return @class ?? Enumerable.Empty<string>();
			}
		}

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06001640 RID: 5696 RVA: 0x00059442 File Offset: 0x00057642
		// (set) Token: 0x06001641 RID: 5697 RVA: 0x00059468 File Offset: 0x00057668
		[Property]
		public string Classes
		{
			get
			{
				if (this._classes == null)
				{
					this._classes = string.Join(" ", this.Class);
				}
				return this._classes;
			}
			set
			{
				HashSet<string> @class = this._class;
				if (@class != null)
				{
					@class.Clear();
				}
				this.AddClass(value);
			}
		}

		/// <summary>
		///
		/// </summary>
		// Token: 0x06001642 RID: 5698 RVA: 0x00059484 File Offset: 0x00057684
		public void AddClass(string c)
		{
			if (string.IsNullOrWhiteSpace(c))
			{
				return;
			}
			if (c.Contains(' '))
			{
				this.AddClasses(c);
				return;
			}
			c = c.ToLower();
			if (this._class == null)
			{
				this._class = new HashSet<string>();
			}
			if (this._class.Contains(c))
			{
				return;
			}
			this._class.Add(c);
			this._classes = null;
			this.DirtyStylesRecursive();
		}

		// Token: 0x06001643 RID: 5699 RVA: 0x000594F0 File Offset: 0x000576F0
		public void SetClass(string c, bool b)
		{
			if (string.IsNullOrWhiteSpace(c))
			{
				return;
			}
			if (b)
			{
				this.AddClass(c);
				return;
			}
			this.RemoveClass(c);
		}

		// Token: 0x06001644 RID: 5700 RVA: 0x00059510 File Offset: 0x00057710
		private void AddClasses(string c)
		{
			if (string.IsNullOrWhiteSpace(c))
			{
				return;
			}
			foreach (string cname in c.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
			{
				this.AddClass(cname);
			}
		}

		/// <summary>
		///
		/// </summary>
		// Token: 0x06001645 RID: 5701 RVA: 0x00059552 File Offset: 0x00057752
		public void RemoveClass(string c)
		{
			if (this._class == null)
			{
				return;
			}
			if (string.IsNullOrWhiteSpace(c))
			{
				return;
			}
			c = c.ToLowerInvariant();
			if (this._class.Remove(c))
			{
				this.DirtyStylesRecursive();
				this._classes = null;
			}
		}

		/// <summary>
		/// Returns true if we have this class
		/// </summary>
		// Token: 0x06001646 RID: 5702 RVA: 0x00059589 File Offset: 0x00057789
		public bool HasClass(string c)
		{
			if (this._class == null)
			{
				return false;
			}
			if (string.IsNullOrWhiteSpace(c))
			{
				return false;
			}
			c = c.ToLowerInvariant();
			return this._class.Contains(c);
		}

		/// <summary>
		/// Returns true if we have all these classes
		/// </summary>
		// Token: 0x06001647 RID: 5703 RVA: 0x000595B8 File Offset: 0x000577B8
		public bool HasClasses(HashSet<string> c)
		{
			return this._class != null && c.IsSubsetOf(this._class);
		}

		/// <summary>
		/// Dirty the styles of this class and its children recursively.
		/// </summary>
		// Token: 0x06001648 RID: 5704 RVA: 0x000595D8 File Offset: 0x000577D8
		internal void DirtyStylesRecursive()
		{
			this.Style.Dirty();
			foreach (Panel panel in this.Children)
			{
				panel.DirtyStylesRecursive();
			}
		}

		/// <summary>
		/// Switch the class on or off depending on the value of the bool
		/// </summary>
		// Token: 0x06001649 RID: 5705 RVA: 0x00059630 File Offset: 0x00057830
		public void BindClass(string propertyName, Func<bool> func)
		{
			this.AddBind(new BindClassMethod(propertyName, func));
		}

		/// <summary>
		/// The element name. If you've created this Panel via a template this will be whatever the element
		/// name is on there. If not then it'll be the name of the class (ie Panel, Button)
		/// </summary>
		// Token: 0x17000367 RID: 871
		// (get) Token: 0x0600164A RID: 5706 RVA: 0x0005963F File Offset: 0x0005783F
		// (set) Token: 0x0600164B RID: 5707 RVA: 0x00059647 File Offset: 0x00057847
		[Property]
		public string ElementName { get; set; }

		/// <summary>
		/// Special flags used by the styling system for hover, active etc..
		/// </summary>
		// Token: 0x17000368 RID: 872
		// (get) Token: 0x0600164C RID: 5708 RVA: 0x00059650 File Offset: 0x00057850
		// (set) Token: 0x0600164D RID: 5709 RVA: 0x00059658 File Offset: 0x00057858
		[Property]
		public PseudoClass PseudoClass
		{
			get
			{
				return this._pseudoClass;
			}
			set
			{
				if (this._pseudoClass == value)
				{
					return;
				}
				this._pseudoClass = value;
				this.Style.Dirty();
			}
		}

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x0600164E RID: 5710 RVA: 0x00059676 File Offset: 0x00057876
		[Browsable(false)]
		public bool HasFocus
		{
			get
			{
				return (this.PseudoClass & PseudoClass.Focus) > PseudoClass.None;
			}
		}

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x0600164F RID: 5711 RVA: 0x00059684 File Offset: 0x00057884
		[Browsable(false)]
		public bool HasActive
		{
			get
			{
				return (this.PseudoClass & PseudoClass.Active) > PseudoClass.None;
			}
		}

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06001650 RID: 5712 RVA: 0x00059691 File Offset: 0x00057891
		[Browsable(false)]
		public bool HasHovered
		{
			get
			{
				return (this.PseudoClass & PseudoClass.Hover) > PseudoClass.None;
			}
		}

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x06001651 RID: 5713 RVA: 0x0005969E File Offset: 0x0005789E
		[Browsable(false)]
		public bool HasIntro
		{
			get
			{
				return (this.PseudoClass & PseudoClass.Intro) > PseudoClass.None;
			}
		}

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x06001652 RID: 5714 RVA: 0x000596AC File Offset: 0x000578AC
		[Browsable(false)]
		public bool HasOutro
		{
			get
			{
				return (this.PseudoClass & PseudoClass.Outro) > PseudoClass.None;
			}
		}

		// Token: 0x06001653 RID: 5715 RVA: 0x000596BC File Offset: 0x000578BC
		public Panel()
		{
			Host.AssertClientOrMenu(".ctor");
			this.InitializeEvents();
			this.YogaNode = new YogaWrapper();
			this.Style = new PanelStyle(this);
			this.StyleSheet = new StyleSheetCollection(this);
			this.Transitions = new Transitions(this);
			this.ElementName = base.GetType().Name.ToLower();
			this.Switch(PseudoClass.Empty, true);
			this.LoadTemplate();
		}

		// Token: 0x06001654 RID: 5716 RVA: 0x0005977A File Offset: 0x0005797A
		public Panel(Panel parent)
			: this()
		{
			if (parent != null)
			{
				this.Parent = parent;
			}
		}

		// Token: 0x06001655 RID: 5717 RVA: 0x0005978C File Offset: 0x0005798C
		public Panel(Panel parent, string classnames)
			: this(parent)
		{
			if (classnames != null)
			{
				this.AddClass(classnames);
			}
		}

		// Token: 0x06001656 RID: 5718 RVA: 0x0005979F File Offset: 0x0005799F
		internal virtual void AddToLists()
		{
			Event.Register(this);
		}

		// Token: 0x06001657 RID: 5719 RVA: 0x000597A7 File Offset: 0x000579A7
		internal virtual void RemoveFromLists()
		{
			Event.Unregister(this);
			PanelLayer panelLayer = this.PanelLayer;
			if (panelLayer != null)
			{
				panelLayer.Dispose();
			}
			this.PanelLayer = null;
		}

		// Token: 0x06001658 RID: 5720 RVA: 0x000597C8 File Offset: 0x000579C8
		public virtual void OnHotloaded()
		{
			this.LoadTemplate();
			this.InitializeEvents();
			foreach (Panel child in this.Children)
			{
				try
				{
					child.OnHotloaded();
				}
				catch (Exception e)
				{
					GlobalGameNamespace.Log.Error(e);
				}
			}
		}

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x06001659 RID: 5721 RVA: 0x0005983C File Offset: 0x00057A3C
		[Browsable(false)]
		public IEnumerable<StyleSheet> AllStyleSheets
		{
			get
			{
				foreach (Panel p in this.AncestorsAndSelf)
				{
					if (p.StyleSheet.List != null)
					{
						foreach (StyleSheet sheet in p.StyleSheet.List)
						{
							yield return sheet;
						}
						List<StyleSheet>.Enumerator enumerator2 = default(List<StyleSheet>.Enumerator);
					}
				}
				IEnumerator<Panel> enumerator = null;
				yield break;
				yield break;
			}
		}

		/// <summary>
		/// Switch a pseudo class on or off
		/// </summary>
		// Token: 0x0600165A RID: 5722 RVA: 0x0005984C File Offset: 0x00057A4C
		public bool Switch(PseudoClass c, bool state)
		{
			if (state == (this.PseudoClass & c) > PseudoClass.None)
			{
				return false;
			}
			if (state)
			{
				this.PseudoClass |= c;
			}
			else
			{
				this.PseudoClass &= ~c;
			}
			return true;
		}

		// Token: 0x0600165B RID: 5723 RVA: 0x00059884 File Offset: 0x00057A84
		internal static void Switch(PseudoClass c, bool state, Panel panel, Panel unlessAncestorOf = null)
		{
			if (panel == null)
			{
				return;
			}
			foreach (Panel target in panel.AncestorsAndSelf)
			{
				if (unlessAncestorOf == null || !unlessAncestorOf.IsAncestor(target))
				{
					target.Switch(c, state);
				}
			}
		}

		/// <summary>
		/// Return true if this panel isn't hidden by opacity or displaymode
		/// </summary>
		// Token: 0x1700036F RID: 879
		// (get) Token: 0x0600165C RID: 5724 RVA: 0x000598E4 File Offset: 0x00057AE4
		// (set) Token: 0x0600165D RID: 5725 RVA: 0x000598EC File Offset: 0x00057AEC
		[Browsable(false)]
		public bool IsVisible { get; internal set; } = true;

		/// <summary>
		/// Return true if this panel isn't hidden by opacity or displaymode
		/// </summary>
		// Token: 0x17000370 RID: 880
		// (get) Token: 0x0600165E RID: 5726 RVA: 0x000598F5 File Offset: 0x00057AF5
		// (set) Token: 0x0600165F RID: 5727 RVA: 0x000598FD File Offset: 0x00057AFD
		[Browsable(false)]
		public bool IsVisibleSelf { get; internal set; } = true;

		// Token: 0x06001660 RID: 5728 RVA: 0x00059906 File Offset: 0x00057B06
		public virtual void Tick()
		{
		}

		/// <summary>
		/// Called after the parent has changed
		/// </summary>
		// Token: 0x06001661 RID: 5729 RVA: 0x00059908 File Offset: 0x00057B08
		public virtual void OnParentChanged()
		{
		}

		// Token: 0x06001662 RID: 5730 RVA: 0x0005990C File Offset: 0x00057B0C
		internal void TickInternal()
		{
			if (this.IsDeleting)
			{
				return;
			}
			try
			{
				if (this.ParentHasChanged)
				{
					this.ParentHasChanged = false;
					this.OnParentChanged();
				}
				this.RunPendingEvents();
				this.UpdateBinds();
				this.Tick();
				this.RunPendingEvents();
				if (this.IsVisible)
				{
					int i = 0;
					for (;;)
					{
						int num = i;
						List<Panel> children = this._children;
						if (num >= ((children != null) ? children.Count<Panel>() : 0))
						{
							break;
						}
						this._children[i].TickInternal();
						i++;
					}
				}
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Error(e);
			}
		}

		// Token: 0x06001663 RID: 5731 RVA: 0x000599A8 File Offset: 0x00057BA8
		internal int GetRenderOrderIndex()
		{
			Styles computedStyle = this.ComputedStyle;
			return ((computedStyle != null) ? computedStyle.ZIndex : null).GetValueOrDefault();
		}

		/// <summary>
		/// Convert a point from the screen to a point representing a delta on this panel where
		/// the top left is [0,0] and the bottom right is [1,1]
		/// </summary>
		// Token: 0x06001664 RID: 5732 RVA: 0x000599D8 File Offset: 0x00057BD8
		public Vector2 ScreenPositionToPanelDelta(Vector2 pos)
		{
			pos = this.ScreenPositionToPanelPosition(pos);
			float x = pos.x.LerpInverse(0f, this.Box.Rect.width, false);
			float y = pos.y.LerpInverse(0f, this.Box.Rect.height, false);
			return new Vector2(x, y);
		}

		/// <summary>
		/// Convert a point from the screen to a position relative to the top left of this panel
		/// </summary>
		// Token: 0x06001665 RID: 5733 RVA: 0x00059A3C File Offset: 0x00057C3C
		public Vector2 ScreenPositionToPanelPosition(Vector2 pos)
		{
			if (this.GlobalMatrix != null)
			{
				pos = this.GlobalMatrix.Value.Transform(pos);
			}
			float x = pos.x - this.Box.Rect.left;
			float y = pos.y - this.Box.Rect.top;
			return new Vector2(x, y);
		}

		/// <summary>
		/// Convert a point from local space to screen space
		/// </summary>
		// Token: 0x06001666 RID: 5734 RVA: 0x00059AB4 File Offset: 0x00057CB4
		public Vector2 PanelPositionToScreenPosition(Vector2 pos)
		{
			Vector3 screenPos = new Vector3(pos.x + this.Box.Rect.left, pos.y + this.Box.Rect.top);
			if (this.GlobalMatrix != null)
			{
				screenPos = this.GlobalMatrix.Value.Inverted.Transform(screenPos);
			}
			return screenPos;
		}

		// Token: 0x06001667 RID: 5735 RVA: 0x00059B2E File Offset: 0x00057D2E
		public IEnumerable<Panel> FindInRect(Rect box, bool fullyInside)
		{
			if (!this.IsVisible)
			{
				yield break;
			}
			if (!this.IsInside(box, fullyInside))
			{
				yield break;
			}
			yield return this;
			if (!this.HasChildren)
			{
				yield break;
			}
			foreach (Panel child in this.Children)
			{
				foreach (Panel found in child.FindInRect(box, fullyInside))
				{
					yield return found;
				}
				IEnumerator<Panel> enumerator2 = null;
			}
			IEnumerator<Panel> enumerator = null;
			yield break;
			yield break;
		}

		/// <summary>
		/// Allow selecting child text
		/// </summary>
		// Token: 0x17000371 RID: 881
		// (get) Token: 0x06001668 RID: 5736 RVA: 0x00059B4C File Offset: 0x00057D4C
		// (set) Token: 0x06001669 RID: 5737 RVA: 0x00059B54 File Offset: 0x00057D54
		[Category("Selection")]
		public bool AllowChildSelection { get; set; }

		// Token: 0x0600166A RID: 5738 RVA: 0x00059B60 File Offset: 0x00057D60
		private string CollectSelectedChildrenText(Panel p)
		{
			if (!p.IsVisible)
			{
				return null;
			}
			TextPanel label = p as TextPanel;
			if (label != null)
			{
				return label.GetSelectedText();
			}
			string selection = null;
			FlexDirection? flexDirection = p.ComputedStyle.FlexDirection;
			FlexDirection flexDirection2 = FlexDirection.Column;
			bool lines = (flexDirection.GetValueOrDefault() == flexDirection2) & (flexDirection != null);
			foreach (Panel child in p.Children)
			{
				string sel = this.CollectSelectedChildrenText(child);
				if (!string.IsNullOrEmpty(sel))
				{
					if (selection == null)
					{
						selection = sel;
					}
					else
					{
						selection = selection + (lines ? "\n" : " ") + sel;
					}
				}
			}
			return selection;
		}

		// Token: 0x0600166B RID: 5739 RVA: 0x00059C20 File Offset: 0x00057E20
		protected virtual void OnDragSelect(SelectionEvent e)
		{
			if (this.AllowChildSelection)
			{
				e.StopPropagation();
				foreach (Panel child in this.Children)
				{
					this.UpdateSelection(child, e);
				}
			}
		}

		// Token: 0x0600166C RID: 5740 RVA: 0x00059C7C File Offset: 0x00057E7C
		private void UpdateSelection(Panel p, SelectionEvent e)
		{
			Rect rect = e.SelectionRect;
			if (p.Box.Rect.bottom < rect.top || p.Box.Rect.top > rect.bottom)
			{
				this.Unselect(p);
				return;
			}
			TextPanel label = p as TextPanel;
			if (label == null)
			{
				foreach (Panel child in p.Children)
				{
					this.UpdateSelection(child, e);
				}
				return;
			}
			label.ShouldDrawSelection = true;
			if (e.StartPoint.y > e.EndPoint.y)
			{
				Vector2 s = e.StartPoint;
				e.StartPoint = e.EndPoint;
				e.EndPoint = s;
			}
			bool start = p.Box.Rect.top < rect.top;
			bool end = p.Box.Rect.bottom > e.EndPoint.y;
			if (start && end)
			{
				label.SelectionStart = label.GetLetterAtScreenPosition(new Vector2(rect.left, rect.top));
				label.SelectionEnd = label.GetLetterAtScreenPosition(new Vector2(rect.right, rect.bottom));
				return;
			}
			if (start)
			{
				label.SelectionStart = label.GetLetterAtScreenPosition(new Vector2(rect.left, rect.top));
				label.SelectionEnd = int.MaxValue;
				return;
			}
			if (end)
			{
				label.SelectionStart = 0;
				label.SelectionEnd = label.GetLetterAtScreenPosition(new Vector2(rect.right, rect.bottom));
				return;
			}
			label.SelectionStart = 0;
			label.SelectionEnd = int.MaxValue;
		}

		// Token: 0x0600166D RID: 5741 RVA: 0x00059E38 File Offset: 0x00058038
		private void Unselect(Panel p)
		{
			TextPanel label = p as TextPanel;
			if (label != null)
			{
				label.ShouldDrawSelection = false;
				return;
			}
			foreach (Panel child in p.Children)
			{
				this.Unselect(child);
			}
		}

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x0600166E RID: 5742 RVA: 0x00059E98 File Offset: 0x00058098
		// (set) Token: 0x0600166F RID: 5743 RVA: 0x00059EA0 File Offset: 0x000580A0
		public virtual string StringValue { get; set; }

		// Token: 0x06001670 RID: 5744 RVA: 0x00059EA9 File Offset: 0x000580A9
		internal virtual void AddBind(BaseDataSource bind)
		{
			if (this.Binds == null)
			{
				this.Binds = new List<BaseDataSource>();
			}
			this.Binds.Add(bind);
		}

		// Token: 0x06001671 RID: 5745 RVA: 0x00059ECA File Offset: 0x000580CA
		internal virtual void ClearBinds()
		{
			List<BaseDataSource> binds = this.Binds;
			if (binds != null)
			{
				binds.Clear();
			}
			this.Binds = null;
		}

		// Token: 0x06001672 RID: 5746 RVA: 0x00059EE4 File Offset: 0x000580E4
		internal virtual void BindRemove(string property)
		{
			if (this.Binds == null)
			{
				return;
			}
			this.Binds.RemoveAll((BaseDataSource x) => x.PropertyName == property);
			if (this.Binds.Count == 0)
			{
				this.Binds = null;
			}
		}

		/// <summary>
		/// Call this when the value has changed due to user input etc. This updates any
		/// bindings, backwards. Also triggers $"{name}.changed" event, with value being the Value on the event.
		/// </summary>
		// Token: 0x06001673 RID: 5747 RVA: 0x00059F34 File Offset: 0x00058134
		protected void CreateValueEvent(string name, object value)
		{
			if (this.Binds != null)
			{
				foreach (BaseDataSource b in this.Binds)
				{
					if (!(b.PropertyName != name))
					{
						b.Value = value;
					}
				}
			}
			this.CreateEvent(name + ".changed", value, null);
		}

		// Token: 0x06001674 RID: 5748 RVA: 0x00059FB8 File Offset: 0x000581B8
		internal virtual void UpdateBinds()
		{
			if (this.Binds == null)
			{
				return;
			}
			using (Performance.Scope("Panel.UpdateBinds"))
			{
				int c = this.Binds.Count;
				for (int i = 0; i < c; i++)
				{
					this.Binds[i].Tick(this);
				}
			}
		}

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x06001675 RID: 5749 RVA: 0x0005A020 File Offset: 0x00058220
		// (set) Token: 0x06001676 RID: 5750 RVA: 0x0005A028 File Offset: 0x00058228
		[Browsable(false)]
		public bool IsDeleting { get; internal set; }

		/// <summary>
		/// Deletes the panel. If immediate is set, will skip any outros.
		/// </summary>
		// Token: 0x06001677 RID: 5751 RVA: 0x0005A031 File Offset: 0x00058231
		public virtual void Delete(bool immediate = false)
		{
			if (immediate)
			{
				this.Parent = null;
				this.OnDeleteRecursive();
				return;
			}
			if (this.IsDeleting)
			{
				return;
			}
			this.IsDeleting = true;
			this.Switch(PseudoClass.Outro, true);
			UISystem.AddDeferredDeletion(this);
		}

		// Token: 0x06001678 RID: 5752 RVA: 0x0005A064 File Offset: 0x00058264
		public virtual void OnDeleted()
		{
		}

		/// <summary>
		/// Called on delete
		/// </summary>
		// Token: 0x06001679 RID: 5753 RVA: 0x0005A068 File Offset: 0x00058268
		internal void OnDeleteRecursive()
		{
			try
			{
				this.RemoveFromLists();
				this.Task.Expire();
				foreach (Panel panel in this.Children)
				{
					panel.OnDeleteRecursive();
				}
				this.OnDeleted();
				if (InputFocus.Current == this)
				{
					InputFocus.Clear(this);
				}
				YogaWrapper yogaNode = this.YogaNode;
				if (yogaNode != null)
				{
					yogaNode.Dispose();
				}
				this.YogaNode = null;
				this.ClearBinds();
				this._renderChildren = null;
				this._childrenHash = null;
				this._children = null;
				this._parent = null;
				Template currentTemplate = this.CurrentTemplate;
				if (currentTemplate != null)
				{
					currentTemplate.Forget(this);
				}
				this.CurrentTemplate = null;
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Error(e);
			}
		}

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x0600167A RID: 5754 RVA: 0x0005A148 File Offset: 0x00058348
		// (set) Token: 0x0600167B RID: 5755 RVA: 0x0005A150 File Offset: 0x00058350
		internal List<Panel.EventCallback> EventListeners { get; set; }

		// Token: 0x0600167C RID: 5756 RVA: 0x0005A15C File Offset: 0x0005835C
		protected virtual void InitializeEvents()
		{
			List<Panel.EventCallback> eventListeners = this.EventListeners;
			if (eventListeners != null)
			{
				eventListeners.RemoveAll((Panel.EventCallback x) => x.Automatic);
			}
			MethodInfo[] allMethods = ReflectionCache.Get(base.GetType()).AllMethods;
			for (int i = 0; i < allMethods.Length; i++)
			{
				MethodInfo method = allMethods[i];
				if (!method.IsStatic)
				{
					string event_name = method.Name.ToLower();
					PanelEventAttribute pea = method.GetCustomAttribute<PanelEventAttribute>();
					if (pea != null)
					{
						ParameterInfo[] args = method.GetParameters();
						ParameterInfo returnParameter = method.ReturnParameter;
						if (event_name.EndsWith("event"))
						{
							string text = event_name;
							int length = text.Length - 5 - 0;
							event_name = text.Substring(0, length);
						}
						if (pea != null && pea.Name != null)
						{
							event_name = pea.Name.ToLower();
						}
						if (args.Length == 1)
						{
							Type argType = args[0].ParameterType;
							object[] argcache = new object[1];
							if (argType == typeof(PanelEvent))
							{
								this.AddAutomaticEventListener(event_name, delegate(PanelEvent x)
								{
									argcache[0] = x;
									method.Invoke(this, argcache);
								});
							}
							else
							{
								this.AddAutomaticEventListener(event_name, delegate(PanelEvent x)
								{
									argcache[0] = Convert.ChangeType(x.Value, argType);
									object response = method.Invoke(this, argcache);
									if (response != null && response is bool)
									{
										bool bReturnedValue = (bool)response;
										x.Propagate = x.Propagate && bReturnedValue;
									}
								});
							}
						}
						else if (args.Length == 0)
						{
							this.AddAutomaticEventListener(event_name, delegate(PanelEvent x)
							{
								object response = method.Invoke(this, null);
								if (response != null && response is bool)
								{
									bool bReturnedValue = (bool)response;
									x.Propagate = x.Propagate && bReturnedValue;
								}
							});
						}
						else
						{
							GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("PanelEvent {0} - couldn't set up (too many arguments)", new object[] { method }));
						}
					}
				}
			}
		}

		// Token: 0x0600167D RID: 5757 RVA: 0x0005A314 File Offset: 0x00058514
		internal void AddAutomaticEventListener(string name, Action<PanelEvent> e)
		{
			if (this.EventListeners == null)
			{
				this.EventListeners = new List<Panel.EventCallback>();
			}
			Panel.EventCallback ev = new Panel.EventCallback
			{
				EventName = name,
				Action = e,
				Automatic = true
			};
			this.EventListeners.Add(ev);
		}

		// Token: 0x0600167E RID: 5758 RVA: 0x0005A364 File Offset: 0x00058564
		public void AddEventListener(string eventName, Action<PanelEvent> e)
		{
			this.AddEventListener(new Panel.EventCallback
			{
				EventName = eventName,
				Action = e
			});
		}

		// Token: 0x0600167F RID: 5759 RVA: 0x0005A390 File Offset: 0x00058590
		public void AddEventListener(string eventName, Action action)
		{
			this.AddEventListener(new Panel.EventCallback
			{
				EventName = eventName,
				BaseAction = action
			});
		}

		// Token: 0x06001680 RID: 5760 RVA: 0x0005A3BC File Offset: 0x000585BC
		internal void AddEventListener(Panel.EventCallback eventCallback)
		{
			if (this.EventListeners == null)
			{
				this.EventListeners = new List<Panel.EventCallback>();
			}
			this.EventListeners.Add(eventCallback);
		}

		// Token: 0x06001681 RID: 5761 RVA: 0x0005A3EC File Offset: 0x000585EC
		internal void RunPendingEvents()
		{
			if (this.PendingEvents == null)
			{
				return;
			}
			for (int i = 0; i < this.PendingEvents.Count; i++)
			{
				PanelEvent e = this.PendingEvents[i];
				if (e.Time <= RealTime.Now)
				{
					this.PendingEvents.RemoveAt(i);
					i--;
					try
					{
						this.OnEvent(e);
					}
					catch (Exception ex)
					{
						GlobalGameNamespace.Log.Error(ex);
					}
				}
			}
		}

		// Token: 0x06001682 RID: 5762 RVA: 0x0005A46C File Offset: 0x0005866C
		public virtual void CreateEvent(string name, object value = null, float? debounce = null)
		{
			List<PanelEvent> pendingEvents = this.PendingEvents;
			PanelEvent e = ((pendingEvents != null) ? pendingEvents.FirstOrDefault((PanelEvent x) => x.Name == name) : null);
			if (e == null)
			{
				e = new PanelEvent(name, this);
				this.CreateEvent(e);
			}
			e.Value = value;
			if (debounce != null)
			{
				e.Time = RealTime.Now + debounce.Value;
			}
		}

		// Token: 0x06001683 RID: 5763 RVA: 0x0005A4DF File Offset: 0x000586DF
		public virtual void CreateEvent(PanelEvent evnt)
		{
			if (this.PendingEvents == null)
			{
				this.PendingEvents = new List<PanelEvent>();
			}
			this.PendingEvents.Add(evnt);
		}

		// Token: 0x06001684 RID: 5764 RVA: 0x0005A500 File Offset: 0x00058700
		protected virtual void OnEvent(PanelEvent e)
		{
			MousePanelEvent mpe = e as MousePanelEvent;
			if (mpe != null)
			{
				if (e.Is("onclick"))
				{
					this.OnClick(mpe);
				}
				if (e.Is("onmiddleclick"))
				{
					this.OnMiddleClick(mpe);
				}
				if (e.Is("onrightclick"))
				{
					this.OnRightClick(mpe);
				}
				if (e.Is("onmousedown"))
				{
					this.OnMouseDown(mpe);
				}
				if (e.Is("onmouseup"))
				{
					this.OnMouseUp(mpe);
				}
				if (e.Is("ondoubleclick"))
				{
					this.OnDoubleClick(mpe);
				}
				if (e.Is("onmousemove"))
				{
					this.OnMouseMove(mpe);
				}
				if (e.Is("onmouseover"))
				{
					this.OnMouseOver(mpe);
				}
				if (e.Is("onmouseout"))
				{
					this.OnMouseOut(mpe);
				}
			}
			if (e.Is("onfocus"))
			{
				this.OnFocus(e);
			}
			if (e.Is("onblur"))
			{
				this.OnBlur(e);
			}
			if (e.Is("onback"))
			{
				this.OnBack(e);
			}
			if (e.Is("onforward"))
			{
				this.OnForward(e);
			}
			SelectionEvent se = e as SelectionEvent;
			if (se != null && e.Is("ondragselect"))
			{
				this.OnDragSelect(se);
			}
			if (!e.Propagate)
			{
				return;
			}
			if (this.EventListeners != null)
			{
				foreach (Panel.EventCallback listener in this.EventListeners)
				{
					if (e.Is(listener.EventName))
					{
						Action<Panel.EventCallback, PanelEvent> @event = listener.Event;
						if (@event != null)
						{
							@event(listener, e);
						}
						Action<PanelEvent> action = listener.Action;
						if (action != null)
						{
							action(e);
						}
						Action baseAction = listener.BaseAction;
						if (baseAction != null)
						{
							baseAction();
						}
					}
				}
			}
			if (!e.Propagate)
			{
				return;
			}
			Panel parent = this.Parent;
			if (parent == null)
			{
				return;
			}
			parent.OnEvent(e);
		}

		// Token: 0x06001685 RID: 5765 RVA: 0x0005A6EC File Offset: 0x000588EC
		protected virtual void OnClick(MousePanelEvent e)
		{
		}

		// Token: 0x06001686 RID: 5766 RVA: 0x0005A6EE File Offset: 0x000588EE
		protected virtual void OnMiddleClick(MousePanelEvent e)
		{
		}

		// Token: 0x06001687 RID: 5767 RVA: 0x0005A6F0 File Offset: 0x000588F0
		protected virtual void OnRightClick(MousePanelEvent e)
		{
		}

		// Token: 0x06001688 RID: 5768 RVA: 0x0005A6F2 File Offset: 0x000588F2
		protected virtual void OnMouseDown(MousePanelEvent e)
		{
		}

		// Token: 0x06001689 RID: 5769 RVA: 0x0005A6F4 File Offset: 0x000588F4
		protected virtual void OnMouseUp(MousePanelEvent e)
		{
		}

		// Token: 0x0600168A RID: 5770 RVA: 0x0005A6F6 File Offset: 0x000588F6
		protected virtual void OnMouseMove(MousePanelEvent e)
		{
		}

		// Token: 0x0600168B RID: 5771 RVA: 0x0005A6F8 File Offset: 0x000588F8
		protected virtual void OnDoubleClick(MousePanelEvent e)
		{
		}

		// Token: 0x0600168C RID: 5772 RVA: 0x0005A6FA File Offset: 0x000588FA
		protected virtual void OnMouseOver(MousePanelEvent e)
		{
		}

		// Token: 0x0600168D RID: 5773 RVA: 0x0005A6FC File Offset: 0x000588FC
		protected virtual void OnMouseOut(MousePanelEvent e)
		{
		}

		// Token: 0x0600168E RID: 5774 RVA: 0x0005A6FE File Offset: 0x000588FE
		protected virtual void OnBack(PanelEvent e)
		{
		}

		// Token: 0x0600168F RID: 5775 RVA: 0x0005A700 File Offset: 0x00058900
		protected virtual void OnForward(PanelEvent e)
		{
		}

		// Token: 0x06001690 RID: 5776 RVA: 0x0005A702 File Offset: 0x00058902
		protected virtual void OnFocus(PanelEvent e)
		{
		}

		// Token: 0x06001691 RID: 5777 RVA: 0x0005A704 File Offset: 0x00058904
		protected virtual void OnBlur(PanelEvent e)
		{
		}

		/// <summary>
		/// Current mouse position local to this panel
		/// </summary>
		// Token: 0x17000375 RID: 885
		// (get) Token: 0x06001692 RID: 5778 RVA: 0x0005A708 File Offset: 0x00058908
		[Browsable(false)]
		public Vector2 MousePosition
		{
			get
			{
				Vector2 mp = Mouse.Position;
				if (this.GlobalMatrix != null)
				{
					mp = this.GlobalMatrix.Value.Transform(Mouse.Position);
				}
				return mp - this.Box.Rect.Position;
			}
		}

		// Token: 0x06001693 RID: 5779 RVA: 0x0005A768 File Offset: 0x00058968
		public bool IsInside(Vector2 pos)
		{
			Rect rect = this.Box.Rect;
			if (pos.x < rect.left || pos.x > rect.right)
			{
				return false;
			}
			if (pos.y < rect.top || pos.y > rect.bottom)
			{
				return false;
			}
			Styles s = this.ComputedStyle;
			if (s == null)
			{
				return false;
			}
			pos.x -= rect.left;
			pos.y -= rect.top;
			if (s.BorderTopLeftRadius != null && s.BorderTopLeftRadius.Value.Unit > LengthUnit.Auto)
			{
				float r = s.BorderTopLeftRadius.Value.GetPixels((rect.width + rect.height) * 0.5f);
				r = MathF.Min(MathF.Min(r, rect.width / 2f), rect.height / 2f);
				Vector2 c = new Vector2(r, r);
				if (pos.x < c.x && pos.y < c.y && Vector2.Distance(pos, c) > r)
				{
					return false;
				}
			}
			if (s.BorderTopRightRadius != null && s.BorderTopRightRadius.Value.Unit > LengthUnit.Auto)
			{
				float r2 = s.BorderTopRightRadius.Value.GetPixels((rect.width + rect.height) * 0.5f);
				r2 = MathF.Min(MathF.Min(r2, rect.width / 2f), rect.height / 2f);
				Vector2 c2 = new Vector2(rect.width - r2, r2);
				if (pos.x > c2.x && pos.y < c2.y && Vector2.Distance(pos, c2) > r2)
				{
					return false;
				}
			}
			if (s.BorderBottomRightRadius != null && s.BorderBottomRightRadius.Value.Unit > LengthUnit.Auto)
			{
				float r3 = s.BorderBottomRightRadius.Value.GetPixels((rect.width + rect.height) * 0.5f);
				r3 = MathF.Min(MathF.Min(r3, rect.width / 2f), rect.height / 2f);
				Vector2 c3 = new Vector2(rect.width - r3, rect.height - r3);
				if (pos.x > c3.x && pos.y > c3.y && Vector2.Distance(pos, c3) > r3)
				{
					return false;
				}
			}
			if (s.BorderBottomLeftRadius != null && s.BorderBottomLeftRadius.Value.Unit > LengthUnit.Auto)
			{
				float r4 = s.BorderBottomLeftRadius.Value.GetPixels((rect.width + rect.height) * 0.5f);
				r4 = MathF.Min(MathF.Min(r4, rect.width / 2f), rect.height / 2f);
				Vector2 c4 = new Vector2(r4, rect.height - r4);
				if (pos.x < c4.x && pos.y > c4.y && Vector2.Distance(pos, c4) > r4)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06001694 RID: 5780 RVA: 0x0005AB00 File Offset: 0x00058D00
		public bool IsInside(Rect rect, bool fullyInside)
		{
			return rect.IsInside(this.Box.Rect, fullyInside);
		}

		/// <summary>
		/// False by default, can this element accept focus. If an element accepts
		/// focus it'll be able to recieve keyboard input.
		/// </summary>
		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06001695 RID: 5781 RVA: 0x0005AB15 File Offset: 0x00058D15
		// (set) Token: 0x06001696 RID: 5782 RVA: 0x0005AB1D File Offset: 0x00058D1D
		[Property]
		public bool AcceptsFocus { get; set; }

		/// <summary>
		/// False by default. Anything that is capable of accepting IME input should return true. Which is probably just a TextEntry.
		/// </summary>
		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06001697 RID: 5783 RVA: 0x0005AB26 File Offset: 0x00058D26
		public virtual bool AcceptsImeInput
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06001698 RID: 5784 RVA: 0x0005AB29 File Offset: 0x00058D29
		public bool Focus()
		{
			return InputFocus.Set(this);
		}

		/// <summary>
		/// Stop being the focus
		/// </summary>
		// Token: 0x06001699 RID: 5785 RVA: 0x0005AB31 File Offset: 0x00058D31
		public bool Blur()
		{
			return InputFocus.Clear(this);
		}

		// Token: 0x0600169A RID: 5786 RVA: 0x0005AB39 File Offset: 0x00058D39
		public virtual void OnButtonEvent(ButtonEvent e)
		{
			Panel parent = this.Parent;
			if (parent == null)
			{
				return;
			}
			parent.OnButtonEvent(e);
		}

		// Token: 0x0600169B RID: 5787 RVA: 0x0005AB4C File Offset: 0x00058D4C
		public virtual void OnKeyTyped(char k)
		{
			Panel parent = this.Parent;
			if (parent == null)
			{
				return;
			}
			parent.OnKeyTyped(k);
		}

		// Token: 0x0600169C RID: 5788 RVA: 0x0005AB60 File Offset: 0x00058D60
		public virtual void OnButtonTyped(string button, KeyModifiers km)
		{
			if (button == "v" && km.Ctrl && ClientGlobal.SDL_HasClipboardText())
			{
				string text = ClientGlobal.SDL_GetClipboardText();
				this.OnPaste(text);
			}
			if ((button == "c" || button == "x") && km.Ctrl)
			{
				string text2 = this.GetClipboardValue(button == "x");
				if (text2 != null)
				{
					ClientGlobal.SDL_SetClipboardText(text2);
				}
			}
			Panel parent = this.Parent;
			if (parent == null)
			{
				return;
			}
			parent.OnButtonTyped(button, km);
		}

		// Token: 0x0600169D RID: 5789 RVA: 0x0005ABE6 File Offset: 0x00058DE6
		public virtual void OnPaste(string text)
		{
			Panel parent = this.Parent;
			if (parent == null)
			{
				return;
			}
			parent.OnPaste(text);
		}

		/// <summary>
		/// If we have a value that can be copied to the clipboard, return it here.
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600169E RID: 5790 RVA: 0x0005ABF9 File Offset: 0x00058DF9
		public virtual string GetClipboardValue(bool cut)
		{
			if (this.AllowChildSelection)
			{
				return this.CollectSelectedChildrenText(this);
			}
			if (this.Parent != null)
			{
				return this.Parent.GetClipboardValue(cut);
			}
			return null;
		}

		// Token: 0x0600169F RID: 5791 RVA: 0x0005AC21 File Offset: 0x00058E21
		public virtual void OnMouseWheel(float value)
		{
			if (this.TryScroll(value))
			{
				return;
			}
			Panel parent = this.Parent;
			if (parent == null)
			{
				return;
			}
			parent.OnMouseWheel(value);
		}

		// Token: 0x060016A0 RID: 5792 RVA: 0x0005AC40 File Offset: 0x00058E40
		public bool TryScroll(float value)
		{
			if (this.ComputedStyle == null)
			{
				return false;
			}
			if (this.ComputedStyle.Overflow == null)
			{
				return false;
			}
			Styles computedStyle = this.ComputedStyle;
			bool flag;
			if (computedStyle == null)
			{
				flag = true;
			}
			else
			{
				OverflowMode? overflow = computedStyle.Overflow;
				OverflowMode overflowMode = OverflowMode.Scroll;
				flag = !((overflow.GetValueOrDefault() == overflowMode) & (overflow != null));
			}
			if (flag)
			{
				return false;
			}
			this.ScrollVelocity += new Vector2(0f, value * 20f) * (1f + this.ScrollVelocity.Length / 100f);
			return true;
		}

		// Token: 0x060016A1 RID: 5793 RVA: 0x0005ACDC File Offset: 0x00058EDC
		public bool TryScrollToBottom()
		{
			if (this.ComputedStyle == null)
			{
				return false;
			}
			if (this.ComputedStyle.Overflow == null)
			{
				return false;
			}
			Styles computedStyle = this.ComputedStyle;
			bool flag;
			if (computedStyle == null)
			{
				flag = true;
			}
			else
			{
				OverflowMode? overflow = computedStyle.Overflow;
				OverflowMode overflowMode = OverflowMode.Scroll;
				flag = !((overflow.GetValueOrDefault() == overflowMode) & (overflow != null));
			}
			if (flag)
			{
				return false;
			}
			this.ScrollOffset = new Vector2(0f, this.ScrollSize.y);
			this.IsScrollAtBottom = true;
			this.ScrollVelocity = new Vector2(0f, 0f);
			return true;
		}

		// Token: 0x060016A2 RID: 5794 RVA: 0x0005AD73 File Offset: 0x00058F73
		public void SetMouseCapture(bool b)
		{
			if (b)
			{
				Panel.MouseCapture = this;
				return;
			}
			if (Panel.MouseCapture == this)
			{
				Panel.MouseCapture = null;
				return;
			}
		}

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x060016A3 RID: 5795 RVA: 0x0005AD8E File Offset: 0x00058F8E
		public bool HasMouseCapture
		{
			get
			{
				return Panel.MouseCapture == this;
			}
		}

		// Token: 0x060016A4 RID: 5796 RVA: 0x0005AD98 File Offset: 0x00058F98
		public virtual bool RayToLocalPosition(Ray ray, out Vector2 position, out float distance)
		{
			position = default(Vector2);
			distance = 0f;
			return false;
		}

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x060016A5 RID: 5797 RVA: 0x0005ADA9 File Offset: 0x00058FA9
		IPanel IPanel.Parent
		{
			get
			{
				return this.Parent;
			}
		}

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x060016A6 RID: 5798 RVA: 0x0005ADB1 File Offset: 0x00058FB1
		IEnumerable<IPanel> IPanel.Children
		{
			get
			{
				return this.Children;
			}
		}

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x060016A7 RID: 5799 RVA: 0x0005ADB9 File Offset: 0x00058FB9
		int IPanel.ChildrenCount
		{
			get
			{
				return this.ChildrenCount;
			}
		}

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x060016A8 RID: 5800 RVA: 0x0005ADC1 File Offset: 0x00058FC1
		string IPanel.ElementName
		{
			get
			{
				return this.ElementName;
			}
		}

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x060016A9 RID: 5801 RVA: 0x0005ADC9 File Offset: 0x00058FC9
		bool IPanel.IsMainMenu
		{
			get
			{
				return Host.IsMenu;
			}
		}

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x060016AA RID: 5802 RVA: 0x0005ADD0 File Offset: 0x00058FD0
		bool IPanel.IsGame
		{
			get
			{
				return !Host.IsMenu;
			}
		}

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x060016AB RID: 5803 RVA: 0x0005ADDA File Offset: 0x00058FDA
		bool IPanel.IsVisible
		{
			get
			{
				return this.IsVisible;
			}
		}

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x060016AC RID: 5804 RVA: 0x0005ADE2 File Offset: 0x00058FE2
		bool IPanel.IsVisibleSelf
		{
			get
			{
				return this.IsVisibleSelf;
			}
		}

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x060016AD RID: 5805 RVA: 0x0005ADEA File Offset: 0x00058FEA
		string IPanel.Classes
		{
			get
			{
				return this.Classes;
			}
		}

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x060016AE RID: 5806 RVA: 0x0005ADF2 File Offset: 0x00058FF2
		Rect IPanel.Rect
		{
			get
			{
				return this.Box.Rect;
			}
		}

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x060016AF RID: 5807 RVA: 0x0005ADFF File Offset: 0x00058FFF
		Rect IPanel.OuterRect
		{
			get
			{
				return this.Box.RectOuter;
			}
		}

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x060016B0 RID: 5808 RVA: 0x0005AE0C File Offset: 0x0005900C
		Rect IPanel.InnerRect
		{
			get
			{
				return this.Box.RectInner;
			}
		}

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x060016B1 RID: 5809 RVA: 0x0005AE19 File Offset: 0x00059019
		Matrix? IPanel.GlobalMatrix
		{
			get
			{
				return this.GlobalMatrix;
			}
		}

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x060016B2 RID: 5810 RVA: 0x0005AE21 File Offset: 0x00059021
		bool IPanel.IsCreatedByTemplate
		{
			get
			{
				return this.CreatedByTemplate != null;
			}
		}

		// Token: 0x060016B3 RID: 5811 RVA: 0x0005AE2C File Offset: 0x0005902C
		IPanel IPanel.GetPanelAt(Vector2 point, bool visibleOnly)
		{
			return this.GetPanelAt(point, visibleOnly);
		}

		// Token: 0x060016B4 RID: 5812 RVA: 0x0005AE36 File Offset: 0x00059036
		bool IPanel.IsAncestor(IPanel panel)
		{
			return this.IsAncestor(panel as Panel);
		}

		// Token: 0x060016B5 RID: 5813 RVA: 0x0005AE44 File Offset: 0x00059044
		private Panel GetPanelAt(Vector2 point, bool visibleOnly)
		{
			if (visibleOnly && !this.IsVisible)
			{
				return null;
			}
			Matrix? matrix;
			point = ((this.LocalMatrix != null) ? matrix.GetValueOrDefault().Transform(point) : point);
			if (!this.IsInside(point))
			{
				return null;
			}
			Panel bestSelection = this;
			foreach (Panel panel in this.Children)
			{
				Panel p = panel.GetPanelAt(point, visibleOnly);
				if (p != null && (p.Depth > bestSelection.Depth || !bestSelection.IsVisible))
				{
					bestSelection = p;
				}
			}
			return bestSelection;
		}

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x060016B6 RID: 5814 RVA: 0x0005AF00 File Offset: 0x00059100
		private int Depth
		{
			get
			{
				Panel parent = this.Parent;
				return (1 + ((parent != null) ? new int?(parent.Depth) : null)).GetValueOrDefault();
			}
		}

		// Token: 0x060016B7 RID: 5815 RVA: 0x0005AF58 File Offset: 0x00059158
		private bool NeedsLayer(Styles styles)
		{
			return styles.FilterBlur != null || styles.FilterSaturate != null || styles.FilterSepia != null || styles.FilterBrightness != null || styles.FilterContrast != null || styles.FilterHueRotate != null || styles.FilterInvert != null || styles.FilterTint != null;
		}

		// Token: 0x060016B8 RID: 5816 RVA: 0x0005AFF8 File Offset: 0x000591F8
		private void UpdateLayer(Styles styles)
		{
			if (!this.NeedsLayer(styles))
			{
				PanelLayer panelLayer = this.PanelLayer;
				if (panelLayer != null)
				{
					panelLayer.Dispose();
				}
				this.PanelLayer = null;
				return;
			}
			Vector2 size = this.Box.RectOuter.Size;
			if (size.x <= 1f)
			{
				return;
			}
			if (size.y <= 1f)
			{
				return;
			}
			if (this.PanelLayer != null && this.PanelLayer.Size == size)
			{
				return;
			}
			PanelLayer panelLayer2 = this.PanelLayer;
			if (panelLayer2 != null)
			{
				panelLayer2.Dispose();
			}
			this.PanelLayer = null;
			this.PanelLayer = new PanelLayer(size);
		}

		/// <summary>
		/// Called before rendering this panel
		/// </summary>
		// Token: 0x060016B9 RID: 5817 RVA: 0x0005B098 File Offset: 0x00059298
		internal void PushLayer(PanelRenderer render)
		{
			if (this.PanelLayer == null)
			{
				return;
			}
			if (this.ComputedStyle == null)
			{
				return;
			}
			if (!this.IsVisible)
			{
				return;
			}
			Matrix mat = render.Matrix.Inverted;
			mat *= Matrix.CreateTranslation(this.Box.Rect.Position * -1f);
			render.PushLayer(this.PanelLayer.Texture, mat);
		}

		/// <summary>
		/// called after rendering this panel
		/// </summary>
		// Token: 0x060016BA RID: 5818 RVA: 0x0005B10C File Offset: 0x0005930C
		internal void PopLayer(PanelRenderer render)
		{
			if (this.PanelLayer == null)
			{
				return;
			}
			if (this.ComputedStyle == null)
			{
				return;
			}
			if (!this.IsVisible)
			{
				return;
			}
			render.PopLayer();
			string name = "Texture";
			Texture texture = this.PanelLayer.Texture;
			int num = -1;
			Render.Set(name, texture, num);
			Length? length = this.ComputedStyle.FilterBlur;
			float blurSize = ((length != null) ? length.GetValueOrDefault().GetPixels(1f) : 0f);
			Render.Set("FilterBlur", blurSize);
			string name2 = "FilterSaturate";
			length = this.ComputedStyle.FilterSaturate;
			float num2 = ((length != null) ? length.GetValueOrDefault().GetFraction(1f) : 1f);
			Render.Set(name2, num2);
			string name3 = "FilterSepia";
			length = this.ComputedStyle.FilterSepia;
			num2 = ((length != null) ? length.GetValueOrDefault().GetFraction(1f) : 0f);
			Render.Set(name3, num2);
			string name4 = "FilterBrightness";
			length = this.ComputedStyle.FilterBrightness;
			num2 = ((length != null) ? length.GetValueOrDefault().GetPixels(1f) : 1f);
			Render.Set(name4, num2);
			string name5 = "FilterContrast";
			length = this.ComputedStyle.FilterContrast;
			num2 = ((length != null) ? length.GetValueOrDefault().GetPixels(1f) : 1f);
			Render.Set(name5, num2);
			string name6 = "FilterInvert";
			length = this.ComputedStyle.FilterInvert;
			num2 = ((length != null) ? length.GetValueOrDefault().GetPixels(1f) : 0f);
			Render.Set(name6, num2);
			string name7 = "FilterHueRotate";
			length = this.ComputedStyle.FilterHueRotate;
			num2 = ((length != null) ? length.GetValueOrDefault().GetPixels(1f) : 0f);
			Render.Set(name7, num2);
			string name8 = "FilterTint";
			Color color = this.ComputedStyle.FilterTint ?? Vector4.One;
			Vector4 vector = color;
			Render.Set(name8, vector);
			Render.Material = Materials.Filter;
			Render.Color = Color.White;
			Render.DrawQuad(this.Box.Rect, new Margin(blurSize));
		}

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x060016BB RID: 5819 RVA: 0x0005B36E File Offset: 0x0005956E
		// (set) Token: 0x060016BC RID: 5820 RVA: 0x0005B376 File Offset: 0x00059576
		[Browsable(false)]
		public Box Box { get; set; } = new Box();

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x060016BD RID: 5821 RVA: 0x0005B37F File Offset: 0x0005957F
		[Browsable(false)]
		public virtual bool HasContent
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x060016BE RID: 5822 RVA: 0x0005B382 File Offset: 0x00059582
		// (set) Token: 0x060016BF RID: 5823 RVA: 0x0005B38A File Offset: 0x0005958A
		[Browsable(false)]
		public Vector2 ScrollOffset { get; set; }

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x060016C0 RID: 5824 RVA: 0x0005B393 File Offset: 0x00059593
		// (set) Token: 0x060016C1 RID: 5825 RVA: 0x0005B39B File Offset: 0x0005959B
		[Browsable(false)]
		public float ScaleToScreen { get; internal set; } = 1f;

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x060016C2 RID: 5826 RVA: 0x0005B3A4 File Offset: 0x000595A4
		[Browsable(false)]
		public float ScaleFromScreen
		{
			get
			{
				return 1f / this.ScaleToScreen;
			}
		}

		/// <summary>
		/// If this panel has transforms, they'll be reflected here
		/// </summary>
		// Token: 0x1700038D RID: 909
		// (get) Token: 0x060016C3 RID: 5827 RVA: 0x0005B3B2 File Offset: 0x000595B2
		// (set) Token: 0x060016C4 RID: 5828 RVA: 0x0005B3BA File Offset: 0x000595BA
		[Browsable(false)]
		public Matrix? LocalMatrix { get; internal set; }

		/// <summary>
		/// If this panel or its parents have transforms, they'll be compounded here.
		/// </summary>
		// Token: 0x1700038E RID: 910
		// (get) Token: 0x060016C5 RID: 5829 RVA: 0x0005B3C3 File Offset: 0x000595C3
		// (set) Token: 0x060016C6 RID: 5830 RVA: 0x0005B3CB File Offset: 0x000595CB
		[Browsable(false)]
		public Matrix? GlobalMatrix { get; internal set; }

		// Token: 0x060016C7 RID: 5831 RVA: 0x0005B3D4 File Offset: 0x000595D4
		internal void UpdateVisibility()
		{
			bool isVisible = this.IsVisible;
			Styles computedStyle = this.ComputedStyle;
			this.IsVisibleSelf = computedStyle != null && computedStyle.CalcVisible();
			bool isVisible2;
			if (this.IsVisibleSelf)
			{
				Panel parent = this.Parent;
				isVisible2 = parent == null || parent.IsVisible;
			}
			else
			{
				isVisible2 = false;
			}
			this.IsVisible = isVisible2;
			if (isVisible != this.IsVisible && this.Parent != null)
			{
				this.Parent.IndexesDirty = true;
			}
		}

		// Token: 0x060016C8 RID: 5832 RVA: 0x0005B440 File Offset: 0x00059640
		internal void UpdateVisibilityRecursive()
		{
			this.UpdateVisibility();
			List<Panel> children = this._children;
			int c = ((children != null) ? children.Count : 0);
			for (int i = 0; i < c; i++)
			{
				this._children[i].UpdateVisibilityRecursive();
			}
		}

		// Token: 0x060016C9 RID: 5833 RVA: 0x0005B484 File Offset: 0x00059684
		internal virtual void PreLayout(LayoutCascade cascade)
		{
			if (this.YogaNode == null)
			{
				return;
			}
			if (this.IndexesDirty)
			{
				this.UpdateChildrenIndexes();
			}
			bool changed;
			this.ComputedStyle = this.Style.BuildFinal(ref cascade, out changed);
			this.ScaleToScreen = cascade.Scale.x;
			this.UpdateVisibility();
			if (changed || !this.YogaNode.Initialized)
			{
				this.UpdateYoga();
			}
			if (changed)
			{
				this.UpdateLayer(this.ComputedStyle);
			}
			this.UpdateOrder();
			if (this.LayoutCount > 0 && !this.IsVisibleSelf)
			{
				this.UpdateVisibilityRecursive();
				return;
			}
			if (this.ComputedStyle.PointerEvents != null && this.ComputedStyle.PointerEvents != "none" && this.ComputedStyle.PointerEvents != "auto")
			{
				cascade.Root.WantsMouseInput = this;
			}
			List<Panel> children = this._children;
			int c = ((children != null) ? children.Count : 0);
			for (int i = 0; i < c; i++)
			{
				this._children[i].PreLayout(cascade);
			}
			this.SortChildrenOrder();
		}

		// Token: 0x060016CA RID: 5834 RVA: 0x0005B598 File Offset: 0x00059798
		internal void UpdateYoga()
		{
			if (this.ComputedStyle == null)
			{
				return;
			}
			this.YogaNode.Width = this.ComputedStyle.Width;
			this.YogaNode.Height = this.ComputedStyle.Height;
			this.YogaNode.MaxWidth = this.ComputedStyle.MaxWidth;
			this.YogaNode.MaxHeight = this.ComputedStyle.MaxHeight;
			this.YogaNode.MinWidth = this.ComputedStyle.MinWidth;
			this.YogaNode.MinHeight = this.ComputedStyle.MinHeight;
			this.YogaNode.Display = this.ComputedStyle.Display;
			this.YogaNode.Left = this.ComputedStyle.Left;
			this.YogaNode.Right = this.ComputedStyle.Right;
			this.YogaNode.Top = this.ComputedStyle.Top;
			this.YogaNode.Bottom = this.ComputedStyle.Bottom;
			this.YogaNode.MarginLeft = this.ComputedStyle.MarginLeft;
			this.YogaNode.MarginRight = this.ComputedStyle.MarginRight;
			this.YogaNode.MarginTop = this.ComputedStyle.MarginTop;
			this.YogaNode.MarginBottom = this.ComputedStyle.MarginBottom;
			this.YogaNode.PaddingLeft = this.ComputedStyle.PaddingLeft;
			this.YogaNode.PaddingRight = this.ComputedStyle.PaddingRight;
			this.YogaNode.PaddingTop = this.ComputedStyle.PaddingTop;
			this.YogaNode.PaddingBottom = this.ComputedStyle.PaddingBottom;
			this.YogaNode.BorderLeftWidth = this.ComputedStyle.BorderLeftWidth;
			this.YogaNode.BorderTopWidth = this.ComputedStyle.BorderTopWidth;
			this.YogaNode.BorderRightWidth = this.ComputedStyle.BorderRightWidth;
			this.YogaNode.BorderBottomWidth = this.ComputedStyle.BorderBottomWidth;
			this.YogaNode.PositionType = this.ComputedStyle.Position;
			this.YogaNode.AspectRatio = this.ComputedStyle.AspectRatio;
			this.YogaNode.FlexGrow = this.ComputedStyle.FlexGrow;
			this.YogaNode.FlexShrink = this.ComputedStyle.FlexShrink;
			this.YogaNode.Wrap = this.ComputedStyle.FlexWrap;
			this.YogaNode.AlignContent = this.ComputedStyle.AlignContent;
			this.YogaNode.AlignItems = this.ComputedStyle.AlignItems;
			this.YogaNode.AlignSelf = this.ComputedStyle.AlignSelf;
			this.YogaNode.FlexDirection = this.ComputedStyle.FlexDirection;
			this.YogaNode.JustifyContent = this.ComputedStyle.JustifyContent;
			this.YogaNode.Overflow = this.ComputedStyle.Overflow;
			this.YogaNode.Initialized = true;
		}

		/// <summary>
		/// This panel has just been layed out. You can modify its position now and it will affect its children.
		/// This is a useful place to restrict shit to the the screen etc.
		/// </summary>
		// Token: 0x060016CB RID: 5835 RVA: 0x0005B8A6 File Offset: 0x00059AA6
		public virtual void OnLayout(ref Rect layoutRect)
		{
		}

		/// <summary>
		/// Takes a LayoutCascade and returns an outer rect
		/// </summary>
		// Token: 0x060016CC RID: 5836 RVA: 0x0005B8A8 File Offset: 0x00059AA8
		public virtual void FinalLayout()
		{
			if (this.ComputedStyle == null)
			{
				return;
			}
			this.Box.Rect = this.YogaNode.YogaRect;
			if (this.Parent != null)
			{
				Box box = this.Box;
				box.Rect.Position = box.Rect.Position + this.Parent.Box.Rect.Position;
				Box box2 = this.Box;
				box2.Rect.Position = box2.Rect.Position - this.Parent.ScrollOffset.SnapToGrid(1f, true, true);
			}
			this.OnLayout(ref this.Box.Rect);
			this.Box.RectOuter = this.Box.Rect.Grow(this.YogaNode.Margin.left, this.YogaNode.Margin.top, this.YogaNode.Margin.right, this.YogaNode.Margin.bottom);
			this.Box.RectInner = this.Box.Rect.Shrink(this.YogaNode.Padding.left, this.YogaNode.Padding.top, this.YogaNode.Padding.right, this.YogaNode.Padding.bottom);
			this.Box.ClipRect = this.Box.Rect.Shrink(this.YogaNode.Border.left, this.YogaNode.Border.top, this.YogaNode.Border.right, this.YogaNode.Border.bottom);
			this.UpdateLayer(this.ComputedStyle);
			if (this.ComputedStyle.Transform != null)
			{
				PanelTransform t = this.ComputedStyle.Transform.Value;
				t.BuildTransform(this.Box.Rect.width, this.Box.Rect.height);
				this.ComputedStyle.Transform = new PanelTransform?(t);
			}
			if (this.HasIntro)
			{
				this.Switch(PseudoClass.Intro, false);
			}
			DisplayMode? display = this.ComputedStyle.Display;
			DisplayMode displayMode = DisplayMode.None;
			if ((display.GetValueOrDefault() == displayMode) & (display != null))
			{
				return;
			}
			if (this.LayoutCount > 0 && (this.ComputedStyle.Opacity ?? 1f) <= 0f)
			{
				return;
			}
			if (this.LayoutCount == 0 && this.PreferScrollToBottom)
			{
				this.IsScrollAtBottom = true;
			}
			bool wasScrollatBottom = this.IsScrollAtBottom;
			this.FinalLayoutChildren();
			this.UpdateScrollPin(wasScrollatBottom);
			this.LayoutCount++;
		}

		/// <summary>
		/// If true, we'll try to stay scrolled to the bottom when the panel changes size
		/// </summary>
		// Token: 0x1700038F RID: 911
		// (get) Token: 0x060016CD RID: 5837 RVA: 0x0005BB76 File Offset: 0x00059D76
		// (set) Token: 0x060016CE RID: 5838 RVA: 0x0005BB7E File Offset: 0x00059D7E
		[Browsable(false)]
		public bool PreferScrollToBottom { get; set; }

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x060016CF RID: 5839 RVA: 0x0005BB87 File Offset: 0x00059D87
		// (set) Token: 0x060016D0 RID: 5840 RVA: 0x0005BB8F File Offset: 0x00059D8F
		[Browsable(false)]
		public bool IsScrollAtBottom { get; private set; }

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x060016D1 RID: 5841 RVA: 0x0005BB98 File Offset: 0x00059D98
		// (set) Token: 0x060016D2 RID: 5842 RVA: 0x0005BBA0 File Offset: 0x00059DA0
		[Browsable(false)]
		public Vector2 ScrollSize { get; private set; }

		// Token: 0x060016D3 RID: 5843 RVA: 0x0005BBAC File Offset: 0x00059DAC
		protected virtual void FinalLayoutChildren()
		{
			if (!this.HasChildren)
			{
				return;
			}
			for (int i = 0; i < this._children.Count; i++)
			{
				this._children[i].FinalLayout();
			}
			if (this.ComputedStyle.Overflow != null && this.ComputedStyle.Overflow.Value != OverflowMode.Visible)
			{
				Rect rect = this.Box.Rect;
				rect.Position -= this.ScrollOffset;
				for (int j = 0; j < this._children.Count; j++)
				{
					Panel child = this._children[j];
					if (child.IsVisible)
					{
						rect.Add(child.Box.RectOuter);
					}
				}
				this.ConstrainScrolling(rect.Size);
				return;
			}
			this.ScrollOffset = 0.0;
		}

		// Token: 0x060016D4 RID: 5844 RVA: 0x0005BC9C File Offset: 0x00059E9C
		private void UpdateScrollPin(bool wasAtBottom)
		{
			if (wasAtBottom && this.PreferScrollToBottom && !this.IsScrollAtBottom && this.ScrollVelocity.y.AlmostEqual(0f, 0.1f))
			{
				this.ScrollOffset = new Vector2(this.ScrollOffset.x, this.ScrollSize.y);
				this.IsScrollAtBottom = true;
				this.ScrollVelocity.y = 0f;
			}
		}

		// Token: 0x060016D5 RID: 5845 RVA: 0x0005BD18 File Offset: 0x00059F18
		protected virtual void ConstrainScrolling(Vector2 size)
		{
			size -= this.Box.Rect.Size;
			Length? length;
			size.y += ((this.ComputedStyle.PaddingBottom != null) ? length.GetValueOrDefault().GetPixels(this.Box.Rect.Size.y) : 0f);
			float heightChange = size.y - this.ScrollSize.y;
			this.ScrollSize = size;
			if (this.ScrollVelocity.y != 0f)
			{
				this.ScrollOffset += this.ScrollVelocity * RealTime.Delta * 60f;
				this.ScrollVelocity = Vector3.Lerp(this.ScrollVelocity, Vector3.Zero, RealTime.Delta * 10f, true);
				if (this.ScrollVelocity.y.AlmostEqual(0f, 0.1f))
				{
					this.ScrollVelocity.y = 0f;
				}
				if (this.ScrollVelocity.x.AlmostEqual(0f, 0.1f))
				{
					this.ScrollVelocity.x = 0f;
				}
			}
			OverflowMode overflow = this.ComputedStyle.Overflow.GetValueOrDefault();
			if (overflow == OverflowMode.Visible || overflow == OverflowMode.Hidden)
			{
				this.ScrollOffset = 0.0;
				return;
			}
			this.IsScrollAtBottom = this.ScrollOffset.y + this.ScrollVelocity.y >= size.y;
			Vector2 so = this.ScrollOffset;
			if (this.ScrollOffset.y < 0f)
			{
				so.y = this.ScrollOffset.y.LerpTo(0f, RealTime.Delta * 20f, true);
			}
			if (this.ScrollOffset.x < 0f)
			{
				so.x = this.ScrollOffset.y.LerpTo(0f, RealTime.Delta * 20f, true);
			}
			if (this.ScrollOffset.y > size.y)
			{
				so.y = this.ScrollOffset.y.LerpTo(size.y, RealTime.Delta * 20f, true);
			}
			if (this.ScrollOffset.x > size.x)
			{
				so.x = this.ScrollOffset.y.LerpTo(size.x, RealTime.Delta * 20f, true);
			}
			if (this.ScrollVelocity.y > 0f && this.IsScrollAtBottom)
			{
				so.y += heightChange;
			}
			this.ScrollOffset = so;
		}

		// Token: 0x060016D6 RID: 5846 RVA: 0x0005C018 File Offset: 0x0005A218
		public void PlaySound(string sound)
		{
			if (string.IsNullOrEmpty(sound))
			{
				return;
			}
			Sound.FromScreen(sound, 0.5f, 0.5f).SetVolume(0.5f);
		}

		// Token: 0x060016D7 RID: 5847 RVA: 0x0005C04C File Offset: 0x0005A24C
		internal void UpdateOrder()
		{
			int? order = this.ComputedStyle.Order;
			int? lastOrder = this.LastOrder;
			if ((order.GetValueOrDefault() == lastOrder.GetValueOrDefault()) & (order != null == (lastOrder != null)))
			{
				return;
			}
			this.LastOrder = this.ComputedStyle.Order;
			Panel parent = this.Parent;
			if (parent == null)
			{
				return;
			}
			parent.DirtyChildrenOrder();
		}

		// Token: 0x060016D8 RID: 5848 RVA: 0x0005C0B1 File Offset: 0x0005A2B1
		internal void DirtyChildrenOrder()
		{
			this.NeedsOrderSort = true;
		}

		// Token: 0x060016D9 RID: 5849 RVA: 0x0005C0BC File Offset: 0x0005A2BC
		internal void SortChildrenOrder()
		{
			if (!this.NeedsOrderSort)
			{
				return;
			}
			this.NeedsOrderSort = false;
			if (this._children == null)
			{
				return;
			}
			foreach (Panel child in from x in this._children
				orderby x.LastOrder.GetValueOrDefault(), x.SiblingIndex
				select x)
			{
				this.YogaNode.RemoveChild(child.YogaNode);
				this.YogaNode.AddChild(child.YogaNode);
			}
		}

		// Token: 0x060016DA RID: 5850 RVA: 0x0005C188 File Offset: 0x0005A388
		public virtual void SetPropertyObject(string name, object value)
		{
			PropertyAttribute prop;
			if (base.ClassInfo.PropertiesInternal.TryGetValue(name, out prop))
			{
				prop.SetValue(this, value);
				return;
			}
			this.SetProperty(name, Convert.ToString(value));
		}

		// Token: 0x060016DB RID: 5851 RVA: 0x0005C1C0 File Offset: 0x0005A3C0
		public override void SetProperty(string name, string value)
		{
			if (name == "value")
			{
				this.StringValue = value;
				return;
			}
			if (name == "class")
			{
				this.AddClass(value);
				return;
			}
			if (name == "style")
			{
				this.Style.Set(value);
				return;
			}
			base.SetProperty(name, value);
		}

		/// <summary>
		/// Binds that are generated via @ attributes in the templating system
		/// </summary>
		// Token: 0x060016DC RID: 5852 RVA: 0x0005C21A File Offset: 0x0005A41A
		internal void SetBindProperty(Panel context, string name, string value)
		{
			if (name == "ref" || name.StartsWith("ref."))
			{
				this.SetRefProperty(context, name, value);
				return;
			}
			this.AddBind(new ObjectProperty(name, context, value));
		}

		/// <summary>
		/// Bind to the target object's property
		/// </summary>
		// Token: 0x060016DD RID: 5853 RVA: 0x0005C250 File Offset: 0x0005A450
		public void Bind(string propertyName, object targetObject, string targetPropertyName)
		{
			ObjectProperty bind = new ObjectProperty(propertyName, targetObject, targetPropertyName);
			this.AddBind(bind);
		}

		/// <summary>
		/// Bind to the data source
		/// </summary>
		// Token: 0x060016DE RID: 5854 RVA: 0x0005C26D File Offset: 0x0005A46D
		public void Bind(BaseDataSource binding)
		{
			this.AddBind(binding);
		}

		/// <summary>
		/// Bind to the data source
		/// </summary>
		// Token: 0x060016DF RID: 5855 RVA: 0x0005C276 File Offset: 0x0005A476
		public void Bind(string propertyName, Func<object> func)
		{
			this.AddBind(new BindMethod(propertyName, func));
		}

		/// <summary>
		/// Sets the field on context
		/// </summary>
		// Token: 0x060016E0 RID: 5856 RVA: 0x0005C288 File Offset: 0x0005A488
		private void SetRefProperty(Panel context, string name, string value)
		{
			Type t = context.GetType();
			if (t == null)
			{
				return;
			}
			PropertyInfo prop = t.GetProperty(value, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
			if (prop == null)
			{
				if (name.Contains("optional"))
				{
					return;
				}
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Couldn't find property {0}.{1}", new object[] { context, value }));
				return;
			}
			else
			{
				if (!base.GetType().IsAssignableTo(prop.PropertyType))
				{
					GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Property {0} is {1} - we can't set that to {2}", new object[]
					{
						prop,
						prop.PropertyType,
						base.GetType()
					}));
					return;
				}
				prop.SetValue(context, this);
				return;
			}
		}

		/// <summary>
		/// Called by the templating system when an element has content between its tags.
		/// </summary>
		// Token: 0x060016E1 RID: 5857 RVA: 0x0005C336 File Offset: 0x0005A536
		public virtual void SetContent(string value)
		{
		}

		/// <summary>
		/// If you return true to this call the children from this element won't be created
		/// because we'll assume you're doing it youself in your control code
		/// </summary>
		// Token: 0x060016E2 RID: 5858 RVA: 0x0005C338 File Offset: 0x0005A538
		public virtual bool OnTemplateElement(INode element)
		{
			return false;
		}

		// Token: 0x060016E3 RID: 5859 RVA: 0x0005C33C File Offset: 0x0005A53C
		internal virtual void DeleteTemplateChildren(Template t)
		{
			if (this._children == null || this._children.Count == 0)
			{
				return;
			}
			for (int i = this._children.Count - 1; i >= 0; i--)
			{
				if (this._children[i].CreatedByTemplate == t)
				{
					this._children[i].Delete(true);
				}
			}
		}

		/// <summary>
		/// Set the panel's template. Ideally you won't be using this, you'll be 
		/// using the [UseTemplate] attribute instead.
		/// </summary>
		// Token: 0x060016E4 RID: 5860 RVA: 0x0005C3A0 File Offset: 0x0005A5A0
		public void SetTemplate(string filename)
		{
			Template template = ((filename != null) ? Template.Get(filename) : null);
			if (this.CurrentTemplate == template)
			{
				return;
			}
			Template currentTemplate = this.CurrentTemplate;
			if (currentTemplate != null)
			{
				currentTemplate.UnapplyAll();
			}
			this.CurrentTemplate = template;
			Template currentTemplate2 = this.CurrentTemplate;
			if (currentTemplate2 == null)
			{
				return;
			}
			currentTemplate2.Apply(this);
		}

		// Token: 0x060016E5 RID: 5861 RVA: 0x0005C3ED File Offset: 0x0005A5ED
		internal virtual void DrawBackground(PanelRenderer renderer, ref RenderState state)
		{
			renderer.DrawBackground(this, state);
			this.DrawBackground(ref state);
		}

		// Token: 0x060016E6 RID: 5862 RVA: 0x0005C3FE File Offset: 0x0005A5FE
		internal virtual void DrawContent(PanelRenderer renderer, ref RenderState state)
		{
			this.DrawContent(ref state);
		}

		// Token: 0x060016E7 RID: 5863 RVA: 0x0005C407 File Offset: 0x0005A607
		public virtual void DrawContent(ref RenderState state)
		{
		}

		// Token: 0x060016E8 RID: 5864 RVA: 0x0005C409 File Offset: 0x0005A609
		public virtual void DrawBackground(ref RenderState state)
		{
		}

		/// <summary>
		/// This is the style that we computed last. If you're looking to see which
		/// styles are set on this panel then this is what you're looking for.
		/// </summary>
		// Token: 0x17000392 RID: 914
		// (get) Token: 0x060016E9 RID: 5865 RVA: 0x0005C40B File Offset: 0x0005A60B
		// (set) Token: 0x060016EA RID: 5866 RVA: 0x0005C413 File Offset: 0x0005A613
		[Browsable(false)]
		public Styles ComputedStyle { get; internal set; }

		/// <summary>
		/// Allows you to set styles specifically on this panel. Setting the style will
		/// only affect this panel and no others and will override any other styles.
		/// </summary>
		// Token: 0x17000393 RID: 915
		// (get) Token: 0x060016EB RID: 5867 RVA: 0x0005C41C File Offset: 0x0005A61C
		// (set) Token: 0x060016EC RID: 5868 RVA: 0x0005C424 File Offset: 0x0005A624
		[Browsable(false)]
		public PanelStyle Style { get; private set; }

		// Token: 0x060016ED RID: 5869 RVA: 0x0005C430 File Offset: 0x0005A630
		private void LoadTemplate()
		{
			UseTemplateAttribute temp = base.GetType().GetCustomAttribute<UseTemplateAttribute>();
			if (temp == null)
			{
				if (this.CurrentTemplateAttribute != null)
				{
					this.CurrentTemplateAttribute = null;
					this.SetTemplate(null);
				}
				return;
			}
			this.CurrentTemplateAttribute = temp;
			this.SetTemplate(temp.Name);
		}

		// Token: 0x060016EE RID: 5870 RVA: 0x0005C476 File Offset: 0x0005A676
		internal virtual void InternalPreTemplateApplied()
		{
			this.PreTemplateApplied();
		}

		// Token: 0x060016EF RID: 5871 RVA: 0x0005C47E File Offset: 0x0005A67E
		internal virtual void InternalPostTemplateApplied()
		{
			this.PostTemplateApplied();
		}

		/// <summary>
		/// Called right before the template is applied.
		/// </summary>
		// Token: 0x060016F0 RID: 5872 RVA: 0x0005C486 File Offset: 0x0005A686
		protected virtual void PreTemplateApplied()
		{
		}

		/// <summary>
		/// Called right after the template is applied
		/// </summary>
		// Token: 0x060016F1 RID: 5873 RVA: 0x0005C488 File Offset: 0x0005A688
		protected virtual void PostTemplateApplied()
		{
		}

		/// <summary>
		/// An element with a slot assigned has been created. This is assigned in the template 
		/// with the attribute slot="name". This is useful if you create panels programatically
		/// in your parent control and want to parent according to slots.
		/// </summary>
		// Token: 0x060016F2 RID: 5874 RVA: 0x0005C48A File Offset: 0x0005A68A
		public virtual void OnTemplateSlot(INode element, string slotName, Panel panel)
		{
			Panel parent = this.Parent;
			if (parent == null)
			{
				return;
			}
			parent.OnTemplateSlot(element, slotName, panel);
		}

		/// <summary>
		/// Handles the storage, progression and application of style transitions
		/// </summary>
		// Token: 0x17000394 RID: 916
		// (get) Token: 0x060016F3 RID: 5875 RVA: 0x0005C49F File Offset: 0x0005A69F
		// (set) Token: 0x060016F4 RID: 5876 RVA: 0x0005C4A7 File Offset: 0x0005A6A7
		[Browsable(false)]
		public Transitions Transitions { get; private set; }

		/// <summary>
		/// Return true if this panel has any active transitions
		/// </summary>
		// Token: 0x17000395 RID: 917
		// (get) Token: 0x060016F5 RID: 5877 RVA: 0x0005C4B0 File Offset: 0x0005A6B0
		[Browsable(false)]
		public bool HasActiveTransitions
		{
			get
			{
				return this.Transitions.HasAny;
			}
		}

		/// <summary>
		/// Any traisitons running, or about to run, will jump straight to the end
		/// </summary>
		// Token: 0x060016F6 RID: 5878 RVA: 0x0005C4BD File Offset: 0x0005A6BD
		public void SkipTransitions()
		{
			this.Style.skipTransitions = true;
		}

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x060016F7 RID: 5879 RVA: 0x0005C4CB File Offset: 0x0005A6CB
		[Browsable(false)]
		public float Now
		{
			get
			{
				return Time.Now;
			}
		}

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x060016F8 RID: 5880 RVA: 0x0005C4D2 File Offset: 0x0005A6D2
		// (set) Token: 0x060016F9 RID: 5881 RVA: 0x0005C4DA File Offset: 0x0005A6DA
		public object UserData { get; set; }

		// Token: 0x0400058D RID: 1421
		protected List<Panel> _children;

		// Token: 0x0400058E RID: 1422
		internal List<Panel> _renderChildren;

		// Token: 0x0400058F RID: 1423
		protected HashSet<Panel> _childrenHash;

		// Token: 0x04000590 RID: 1424
		protected Panel _parent;

		// Token: 0x04000591 RID: 1425
		private bool ParentHasChanged;

		// Token: 0x04000592 RID: 1426
		private bool IndexesDirty;

		// Token: 0x04000594 RID: 1428
		protected HashSet<string> _class;

		// Token: 0x04000595 RID: 1429
		internal string _classes;

		// Token: 0x04000597 RID: 1431
		public TaskSource Task = new TaskSource(1);

		// Token: 0x04000598 RID: 1432
		public StyleSheetCollection StyleSheet;

		// Token: 0x04000599 RID: 1433
		private PseudoClass _pseudoClass = PseudoClass.Intro;

		// Token: 0x0400059E RID: 1438
		internal List<BaseDataSource> Binds;

		// Token: 0x040005A1 RID: 1441
		private List<PanelEvent> PendingEvents;

		// Token: 0x040005A3 RID: 1443
		internal static Panel MouseCapture;

		// Token: 0x040005A4 RID: 1444
		internal Vector2 WorldCursor;

		// Token: 0x040005A5 RID: 1445
		internal float WorldDistance = float.MaxValue;

		// Token: 0x040005A6 RID: 1446
		private PanelLayer PanelLayer;

		// Token: 0x040005A7 RID: 1447
		internal YogaWrapper YogaNode;

		// Token: 0x040005A9 RID: 1449
		public Vector2 ScrollVelocity;

		// Token: 0x040005AC RID: 1452
		private int LayoutCount;

		// Token: 0x040005B2 RID: 1458
		private int? LastOrder;

		// Token: 0x040005B3 RID: 1459
		private bool NeedsOrderSort;

		// Token: 0x040005B4 RID: 1460
		internal Template CreatedByTemplate;

		// Token: 0x040005B5 RID: 1461
		private Template CurrentTemplate;

		// Token: 0x040005B8 RID: 1464
		private UseTemplateAttribute CurrentTemplateAttribute;

		// Token: 0x0200027D RID: 637
		internal struct EventCallback
		{
			// Token: 0x04001280 RID: 4736
			public string EventName;

			// Token: 0x04001281 RID: 4737
			public Action BaseAction;

			// Token: 0x04001282 RID: 4738
			public Action<PanelEvent> Action;

			// Token: 0x04001283 RID: 4739
			public bool Automatic;

			// Token: 0x04001284 RID: 4740
			public Action<Panel.EventCallback, PanelEvent> Event;

			// Token: 0x04001285 RID: 4741
			public Panel Panel;

			// Token: 0x04001286 RID: 4742
			public Panel Context;
		}
	}
}
