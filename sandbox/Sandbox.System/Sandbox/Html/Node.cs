using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sandbox.Html
{
	/// <summary>
	/// Represents an HTML node.
	/// </summary>
	// Token: 0x02000062 RID: 98
	[DebuggerDisplay("Name: {OriginalName}")]
	internal class Node : INode
	{
		// Token: 0x0600044E RID: 1102 RVA: 0x000204B1 File Offset: 0x0001E6B1
		public static Node Parse(string html)
		{
			Document document = new Document();
			document.LoadHtml(html);
			return document.DocumentNode;
		}

		/// <summary>
		/// Initializes HtmlNode, providing type, owner and where it exists in a collection
		/// </summary>
		/// <param name="type"></param>
		/// <param name="ownerdocument"></param>
		/// <param name="index"></param>
		// Token: 0x0600044F RID: 1103 RVA: 0x000204C4 File Offset: 0x0001E6C4
		internal Node(NodeType type, Document ownerdocument, int index)
		{
			this._nodetype = type;
			this._ownerdocument = ownerdocument;
			this._outerstartindex = index;
			switch (type)
			{
			case NodeType.Document:
				this._optimizedName = Node.HtmlNodeTypeNameDocument;
				this._endnode = this;
				break;
			case NodeType.Comment:
				this._endnode = this;
				break;
			case NodeType.Text:
				this._endnode = this;
				break;
			}
			if (this._ownerdocument.Openednodes != null && !this.Closed && -1 != index)
			{
				this._ownerdocument.Openednodes.Add(index, this);
			}
			if (-1 != index || type == NodeType.Comment || type == NodeType.Text)
			{
				return;
			}
			this.SetChanged();
		}

		/// <summary>
		/// Returns true if this is a html element (ie, not a comment or text)
		/// </summary>
		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000450 RID: 1104 RVA: 0x00020566 File Offset: 0x0001E766
		public bool IsElement
		{
			get
			{
				return this.NodeType == NodeType.Element;
			}
		}

		/// <summary>
		/// Returns true if this is a comment
		/// </summary>
		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000451 RID: 1105 RVA: 0x00020571 File Offset: 0x0001E771
		public bool IsComment
		{
			get
			{
				return this.NodeType == NodeType.Comment;
			}
		}

		/// <summary>
		/// Returns true if this is text
		/// </summary>
		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000452 RID: 1106 RVA: 0x0002057C File Offset: 0x0001E77C
		public bool IsText
		{
			get
			{
				return this.NodeType == NodeType.Text;
			}
		}

		/// <summary>
		/// Gets the collection of HTML attributes for this node. May not be null.
		/// </summary>
		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x00020587 File Offset: 0x0001E787
		public List<Attribute> Attributes
		{
			get
			{
				if (!this.HasAttributes)
				{
					this._attributes = new List<Attribute>();
				}
				return this._attributes;
			}
		}

		/// <summary>
		/// Gets all the children of the node.
		/// </summary>
		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000454 RID: 1108 RVA: 0x000205A4 File Offset: 0x0001E7A4
		public List<Node> ChildNodes
		{
			get
			{
				List<Node> result;
				if ((result = this._childnodes) == null)
				{
					result = (this._childnodes = new List<Node>());
				}
				return result;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000455 RID: 1109 RVA: 0x000205CC File Offset: 0x0001E7CC
		public IEnumerable<INode> Children
		{
			get
			{
				IEnumerable<INode> childnodes = this._childnodes;
				return childnodes ?? Enumerable.Empty<INode>();
			}
		}

		/// <summary>
		/// Gets a value indicating if this node has been closed or not.
		/// </summary>
		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000456 RID: 1110 RVA: 0x000205EA File Offset: 0x0001E7EA
		internal bool Closed
		{
			get
			{
				return this._endnode != null;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the current node has any attributes.
		/// </summary>
		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x000205F5 File Offset: 0x0001E7F5
		public bool HasAttributes
		{
			get
			{
				return this._attributes != null && this._attributes.Count > 0;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this node has any child nodes.
		/// </summary>
		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000458 RID: 1112 RVA: 0x0002060F File Offset: 0x0001E80F
		public bool HasChildNodes
		{
			get
			{
				return this._childnodes != null && this._childnodes.Count > 0;
			}
		}

		/// <summary>
		/// Gets or Sets the HTML between the start and end tags of the object.
		/// </summary>
		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000459 RID: 1113 RVA: 0x0002062C File Offset: 0x0001E82C
		public virtual string InnerHtml
		{
			get
			{
				string result;
				if ((result = this._innerhtml) == null)
				{
					result = (this._innerhtml = this._ownerdocument.Text.Substring(this._innerstartindex, this._innerlength));
				}
				return result;
			}
		}

		/// <summary>
		/// Gets the line number of this node in the document.
		/// </summary>
		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x0600045A RID: 1114 RVA: 0x00020668 File Offset: 0x0001E868
		internal int Line
		{
			get
			{
				return this._line;
			}
		}

		/// <summary>
		/// Gets the column number of this node in the document.
		/// </summary>
		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x0600045B RID: 1115 RVA: 0x00020670 File Offset: 0x0001E870
		public int LinePosition
		{
			get
			{
				return this._lineposition;
			}
		}

		/// <summary>
		/// Gets the stream position of the area between the opening and closing tag of the node, relative to the start of the document.
		/// </summary>
		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x0600045C RID: 1116 RVA: 0x00020678 File Offset: 0x0001E878
		public int InnerStartIndex
		{
			get
			{
				return this._innerstartindex;
			}
		}

		/// <summary>
		/// Gets or sets this node's name.
		/// </summary>
		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x0600045D RID: 1117 RVA: 0x00020680 File Offset: 0x0001E880
		public string Name
		{
			get
			{
				string result;
				if ((result = this._optimizedName) == null)
				{
					result = (this._optimizedName = this._ownerdocument.Text.Substring(this._namestartindex, this._namelength).ToLowerInvariant());
				}
				return result;
			}
		}

		/// <summary>
		/// Gets the type of this node.
		/// </summary>
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x0600045E RID: 1118 RVA: 0x000206C1 File Offset: 0x0001E8C1
		internal NodeType NodeType
		{
			get
			{
				return this._nodetype;
			}
		}

		/// <summary>
		/// Gets or Sets the object and its content in HTML.
		/// </summary>
		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x0600045F RID: 1119 RVA: 0x000206CC File Offset: 0x0001E8CC
		public virtual string OuterHtml
		{
			get
			{
				string result;
				if ((result = this._outerhtml) == null)
				{
					result = (this._outerhtml = this._ownerdocument.Text.Substring(this._outerstartindex, this._outerlength));
				}
				return result;
			}
		}

		/// <summary>
		/// Gets the <see cref="T:Sandbox.Html.Document" /> to which this node belongs.
		/// </summary>
		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000460 RID: 1120 RVA: 0x00020708 File Offset: 0x0001E908
		// (set) Token: 0x06000461 RID: 1121 RVA: 0x00020710 File Offset: 0x0001E910
		internal Document OwnerDocument
		{
			get
			{
				return this._ownerdocument;
			}
			set
			{
				this._ownerdocument = value;
			}
		}

		/// <summary>
		/// Gets the parent of this node (for nodes that can have parents).
		/// </summary>
		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000462 RID: 1122 RVA: 0x00020719 File Offset: 0x0001E919
		// (set) Token: 0x06000463 RID: 1123 RVA: 0x00020721 File Offset: 0x0001E921
		public Node ParentNode
		{
			get
			{
				return this._parentnode;
			}
			internal set
			{
				this._parentnode = value;
			}
		}

		/// <summary>
		/// Gets the node immediately preceding this node.
		/// </summary>
		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000464 RID: 1124 RVA: 0x0002072A File Offset: 0x0001E92A
		// (set) Token: 0x06000465 RID: 1125 RVA: 0x00020732 File Offset: 0x0001E932
		public Node PreviousSibling
		{
			get
			{
				return this._prevnode;
			}
			internal set
			{
				this._prevnode = value;
			}
		}

		/// <summary>
		/// The depth of the node relative to the opening root html element. This value is used to determine if a document has to many nested html nodes which can cause stack overflows
		/// </summary>
		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000466 RID: 1126 RVA: 0x0002073B File Offset: 0x0001E93B
		// (set) Token: 0x06000467 RID: 1127 RVA: 0x00020743 File Offset: 0x0001E943
		public int Depth { get; set; }

		/// <summary>
		/// Returns a collection of all ancestor nodes of this element.
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000468 RID: 1128 RVA: 0x0002074C File Offset: 0x0001E94C
		public IEnumerable<Node> Ancestors()
		{
			Node node = this.ParentNode;
			if (node != null)
			{
				yield return node;
				while (node.ParentNode != null)
				{
					yield return node.ParentNode;
					node = node.ParentNode;
				}
			}
			yield break;
		}

		/// <summary>
		/// Get Ancestors with matching name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		// Token: 0x06000469 RID: 1129 RVA: 0x0002075C File Offset: 0x0001E95C
		public IEnumerable<Node> Ancestors(string name)
		{
			Node i;
			for (i = this.ParentNode; i != null; i = i.ParentNode)
			{
				if (i.Name == name)
				{
					yield return i;
				}
			}
			i = null;
			yield break;
		}

		/// <summary>
		/// Returns a collection of all ancestor nodes of this element.
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600046A RID: 1130 RVA: 0x00020773 File Offset: 0x0001E973
		public IEnumerable<Node> AncestorsAndSelf()
		{
			Node i;
			for (i = this; i != null; i = i.ParentNode)
			{
				yield return i;
			}
			i = null;
			yield break;
		}

		/// <summary>
		/// Gets all anscestor nodes and the current node
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		// Token: 0x0600046B RID: 1131 RVA: 0x00020783 File Offset: 0x0001E983
		public IEnumerable<Node> AncestorsAndSelf(string name)
		{
			Node i;
			for (i = this; i != null; i = i.ParentNode)
			{
				if (i.Name == name)
				{
					yield return i;
				}
			}
			i = null;
			yield break;
		}

		/// <summary>
		/// Adds the specified node to the end of the list of children of this node.
		/// </summary>
		/// <param name="newChild">The node to add. May not be null.</param>
		/// <returns>The node added.</returns>
		// Token: 0x0600046C RID: 1132 RVA: 0x0002079C File Offset: 0x0001E99C
		public Node AppendChild(Node newChild)
		{
			if (newChild == null)
			{
				throw new ArgumentNullException("newChild");
			}
			this.ChildNodes.Add(newChild);
			newChild.SetParent(this);
			this._ownerdocument.SetIdForNode(newChild, newChild.GetId());
			this.SetChildNodesId(newChild);
			this.SetChanged();
			return newChild;
		}

		/// <summary>Sets child nodes identifier.</summary>
		/// <param name="chilNode">The chil node.</param>
		// Token: 0x0600046D RID: 1133 RVA: 0x000207EC File Offset: 0x0001E9EC
		public void SetChildNodesId(Node chilNode)
		{
			foreach (Node child in chilNode.ChildNodes)
			{
				this._ownerdocument.SetIdForNode(child, child.GetId());
				this.SetChildNodesId(child);
			}
		}

		/// <summary>
		/// Gets all Descendant nodes in enumerated list
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600046E RID: 1134 RVA: 0x00020854 File Offset: 0x0001EA54
		public IEnumerable<Node> Descendants()
		{
			return this.Descendants(0);
		}

		/// <summary>
		/// Gets all Descendant nodes in enumerated list
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600046F RID: 1135 RVA: 0x0002085D File Offset: 0x0001EA5D
		public IEnumerable<Node> Descendants(int level)
		{
			if (level > Document.MaxDepthLevel)
			{
				throw new ArgumentException("The document is too complex to parse");
			}
			foreach (Node node in this.ChildNodes)
			{
				yield return node;
				foreach (Node descendant in node.Descendants(level + 1))
				{
					yield return descendant;
				}
				IEnumerator<Node> enumerator2 = null;
				node = null;
			}
			List<Node>.Enumerator enumerator = default(List<Node>.Enumerator);
			yield break;
			yield break;
		}

		/// <summary>
		/// Get all descendant nodes with matching name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		// Token: 0x06000470 RID: 1136 RVA: 0x00020874 File Offset: 0x0001EA74
		public IEnumerable<Node> Descendants(string name)
		{
			foreach (Node node in this.Descendants())
			{
				if (string.Equals(node.Name, name, StringComparison.OrdinalIgnoreCase))
				{
					yield return node;
				}
			}
			IEnumerator<Node> enumerator = null;
			yield break;
			yield break;
		}

		/// <summary>
		/// Returns a collection of all descendant nodes of this element, in document order
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000471 RID: 1137 RVA: 0x0002088B File Offset: 0x0001EA8B
		public IEnumerable<Node> DescendantsAndSelf()
		{
			yield return this;
			foreach (Node el in this.Descendants())
			{
				if (el != null)
				{
					yield return el;
				}
			}
			IEnumerator<Node> enumerator = null;
			yield break;
			yield break;
		}

		/// <summary>
		/// Gets all descendant nodes including this node
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		// Token: 0x06000472 RID: 1138 RVA: 0x0002089B File Offset: 0x0001EA9B
		public IEnumerable<Node> DescendantsAndSelf(string name)
		{
			yield return this;
			foreach (Node node in this.Descendants())
			{
				if (node.Name == name)
				{
					yield return node;
				}
			}
			IEnumerator<Node> enumerator = null;
			yield break;
			yield break;
		}

		/// <summary>
		/// Gets first generation child node matching name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		// Token: 0x06000473 RID: 1139 RVA: 0x000208B4 File Offset: 0x0001EAB4
		public Node Element(string name)
		{
			foreach (Node node in this.ChildNodes)
			{
				if (node.Name == name)
				{
					return node;
				}
			}
			return null;
		}

		/// <summary>
		/// Gets matching first generation child nodes matching name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		// Token: 0x06000474 RID: 1140 RVA: 0x00020918 File Offset: 0x0001EB18
		public IEnumerable<Node> Elements(string name)
		{
			foreach (Node node in this.ChildNodes)
			{
				if (node.Name == name)
				{
					yield return node;
				}
			}
			List<Node>.Enumerator enumerator = default(List<Node>.Enumerator);
			yield break;
			yield break;
		}

		/// <summary>
		/// Helper method to get the value of an attribute of this node. If the attribute is not found, the default value will be returned.
		/// </summary>
		/// <param name="name">The name of the attribute to get. May not be <c>null</c>.</param>
		/// <param name="def">The default value to return if not found.</param>
		/// <returns>The value of the attribute if found, the default value if not found.</returns>
		// Token: 0x06000475 RID: 1141 RVA: 0x00020930 File Offset: 0x0001EB30
		public string GetAttribute(string name, string def = null)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (!this.HasAttributes)
			{
				return def;
			}
			Attribute att = this.Attributes.FirstOrDefault((Attribute x) => string.Compare(x.Name, name, true) == 0);
			if (att == null)
			{
				return def;
			}
			return att.Value;
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0002098C File Offset: 0x0001EB8C
		public T GetAttribute<T>(string name, T def = default(T))
		{
			string str = this.GetAttribute(name, null);
			if (string.IsNullOrEmpty(str))
			{
				return def;
			}
			object val;
			if (str.TryToType(typeof(T), out val))
			{
				return (T)((object)val);
			}
			return def;
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x000209C8 File Offset: 0x0001EBC8
		public int GetAttributeInt(string name, int def)
		{
			return this.GetAttribute(name, def.ToString()).ToInt(0);
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x000209DE File Offset: 0x0001EBDE
		public float GetAttributeFloat(string name, float def)
		{
			return this.GetAttribute(name, def.ToString()).ToFloat(0f);
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x000209F8 File Offset: 0x0001EBF8
		public bool GetAttributeBool(string name, bool def)
		{
			return this.GetAttribute(name, def ? "true" : "false").ToBool();
		}

		/// <summary>Removes all id for node described by node.</summary>
		/// <param name="node">The node.</param>
		// Token: 0x0600047A RID: 1146 RVA: 0x00020A18 File Offset: 0x0001EC18
		internal void RemoveAllIDforNode(Node node)
		{
			foreach (Node nodeChildNode in node.ChildNodes)
			{
				this._ownerdocument.SetIdForNode(null, nodeChildNode.GetId());
				this.RemoveAllIDforNode(nodeChildNode);
			}
		}

		/// <summary>
		/// Removes the specified child node.
		/// </summary>
		/// <param name="oldChild">The node being removed. May not be <c>null</c>.</param>
		/// <returns>The node removed.</returns>
		// Token: 0x0600047B RID: 1147 RVA: 0x00020A80 File Offset: 0x0001EC80
		internal Node RemoveChild(Node oldChild)
		{
			if (oldChild == null)
			{
				throw new ArgumentNullException("oldChild");
			}
			List<Node> childnodes = this._childnodes;
			if (childnodes != null)
			{
				childnodes.Remove(oldChild);
			}
			this._ownerdocument.SetIdForNode(null, oldChild.GetId());
			this.RemoveAllIDforNode(oldChild);
			this.SetChanged();
			return oldChild;
		}

		/// <summary>
		/// Sets the parent Html node and properly determines the current node's depth using the parent node's depth.
		/// </summary>
		// Token: 0x0600047C RID: 1148 RVA: 0x00020AD0 File Offset: 0x0001ECD0
		internal void SetParent(Node parent)
		{
			if (parent == null)
			{
				return;
			}
			this.ParentNode = parent;
			if (this.OwnerDocument.OptionMaxNestedChildNodes > 0)
			{
				this.Depth = parent.Depth + 1;
				if (this.Depth > this.OwnerDocument.OptionMaxNestedChildNodes)
				{
					throw new Exception(string.Format("Document has more than {0} nested tags. This is likely due to the page not closing tags properly.", this.OwnerDocument.OptionMaxNestedChildNodes));
				}
			}
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x00020B37 File Offset: 0x0001ED37
		internal void SetChanged()
		{
			if (this.ParentNode != null)
			{
				this.ParentNode.SetChanged();
			}
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x00020B4C File Offset: 0x0001ED4C
		internal void UpdateLastNode()
		{
			Node newLast = null;
			if (this._prevwithsamename == null || !this._prevwithsamename._starttag)
			{
				if (this._ownerdocument.Openednodes == null)
				{
					goto IL_EC;
				}
				using (Dictionary<int, Node>.Enumerator enumerator = this._ownerdocument.Openednodes.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<int, Node> openNode = enumerator.Current;
						if ((openNode.Key < this._outerstartindex || openNode.Key > this._outerstartindex + this._outerlength) && openNode.Value.Name == this.Name)
						{
							if (newLast == null && openNode.Value._starttag)
							{
								newLast = openNode.Value;
							}
							else if (newLast != null && newLast.InnerStartIndex < openNode.Key && openNode.Value._starttag)
							{
								newLast = openNode.Value;
							}
						}
					}
					goto IL_EC;
				}
			}
			newLast = this._prevwithsamename;
			IL_EC:
			if (newLast != null)
			{
				this._ownerdocument.Lastnodes[newLast.Name] = newLast;
			}
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00020C70 File Offset: 0x0001EE70
		internal void CloseNode(Node endnode, int level = 0)
		{
			if (level > Document.MaxDepthLevel)
			{
				throw new ArgumentException("The document is too complex to parse");
			}
			if (!this.Closed)
			{
				this._endnode = endnode;
				if (this._ownerdocument.Openednodes != null)
				{
					this._ownerdocument.Openednodes.Remove(this._outerstartindex);
				}
				if (this._ownerdocument.Lastnodes.GetValueOrDefault(this.Name, null) == this)
				{
					this._ownerdocument.Lastnodes.Remove(this.Name);
					this._ownerdocument.UpdateLastParentNode();
					if (this._starttag && !string.IsNullOrEmpty(this.Name))
					{
						this.UpdateLastNode();
					}
				}
				if (endnode == this)
				{
					return;
				}
				this._innerstartindex = this._outerstartindex + this._outerlength;
				this._innerlength = endnode._outerstartindex - this._innerstartindex;
				this._outerlength = endnode._outerstartindex + endnode._outerlength - this._outerstartindex;
			}
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00020D62 File Offset: 0x0001EF62
		internal string GetId()
		{
			return this.GetAttribute("id", string.Empty);
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00020D74 File Offset: 0x0001EF74
		private string GetRelativeXpath()
		{
			if (this.ParentNode == null)
			{
				return this.Name;
			}
			if (this.NodeType == NodeType.Document)
			{
				return string.Empty;
			}
			int i = 1;
			foreach (Node node in this.ParentNode.ChildNodes)
			{
				if (!(node.Name != this.Name))
				{
					if (node == this)
					{
						break;
					}
					i++;
				}
			}
			return this.Name + "[" + i.ToString() + "]";
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x00020E20 File Offset: 0x0001F020
		internal void FixSelfClosingTags()
		{
			if (!this.HasChildNodes)
			{
				return;
			}
			foreach (Node child in this.ChildNodes.ToArray())
			{
				child.FixSelfClosingTags();
				if (!child.Closed)
				{
					int index = this.ChildNodes.IndexOf(child);
					foreach (Node gchild in child.ChildNodes)
					{
						this.ChildNodes.Insert(++index, gchild);
					}
					child.ChildNodes.Clear();
				}
			}
		}

		// Token: 0x04000901 RID: 2305
		internal const string DepthLevelExceptionMessage = "The document is too complex to parse";

		// Token: 0x04000902 RID: 2306
		internal List<Attribute> _attributes;

		// Token: 0x04000903 RID: 2307
		internal List<Node> _childnodes;

		// Token: 0x04000904 RID: 2308
		internal Node _endnode;

		// Token: 0x04000905 RID: 2309
		internal string _innerhtml;

		// Token: 0x04000906 RID: 2310
		internal int _innerlength;

		// Token: 0x04000907 RID: 2311
		internal int _innerstartindex;

		// Token: 0x04000908 RID: 2312
		internal int _line;

		// Token: 0x04000909 RID: 2313
		internal int _lineposition;

		// Token: 0x0400090A RID: 2314
		internal int _namelength;

		// Token: 0x0400090B RID: 2315
		internal int _namestartindex;

		// Token: 0x0400090C RID: 2316
		internal NodeType _nodetype;

		// Token: 0x0400090D RID: 2317
		internal string _outerhtml;

		// Token: 0x0400090E RID: 2318
		internal int _outerlength;

		// Token: 0x0400090F RID: 2319
		internal int _outerstartindex;

		// Token: 0x04000910 RID: 2320
		private string _optimizedName;

		// Token: 0x04000911 RID: 2321
		internal Document _ownerdocument;

		// Token: 0x04000912 RID: 2322
		internal Node _parentnode;

		// Token: 0x04000913 RID: 2323
		internal Node _prevnode;

		// Token: 0x04000914 RID: 2324
		internal Node _prevwithsamename;

		// Token: 0x04000915 RID: 2325
		internal bool _starttag;

		// Token: 0x04000916 RID: 2326
		internal int _streamposition;

		// Token: 0x04000917 RID: 2327
		internal bool _isImplicitEnd;

		/// <summary>
		/// Gets the name of a comment node. It is actually defined as '#comment'.
		/// </summary>
		// Token: 0x04000918 RID: 2328
		internal static readonly string HtmlNodeTypeNameComment = "#comment";

		/// <summary>
		/// Gets the name of the document node. It is actually defined as '#document'.
		/// </summary>
		// Token: 0x04000919 RID: 2329
		internal static readonly string HtmlNodeTypeNameDocument = "#document";

		/// <summary>
		/// Gets the name of a text node. It is actually defined as '#text'.
		/// </summary>
		// Token: 0x0400091A RID: 2330
		internal static readonly string HtmlNodeTypeNameText = "#text";
	}
}
