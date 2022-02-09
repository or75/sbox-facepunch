using System;
using System.Collections.Generic;
using Sandbox.UI;

namespace Sandbox.UI.Dev
{
	public class TreeControl : Panel
	{
		public TreeControl()
		{
			AddClass( "treecontrol" );
		}

		public virtual void Clear()
		{
			DeleteChildren( true );
		}

		internal void AddNode( TreeNode node )
		{
			node.Parent = this;
		}
	}
}
