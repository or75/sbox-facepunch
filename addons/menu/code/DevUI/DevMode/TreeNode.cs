using System;
using System.Collections.Generic;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace Sandbox.UI.Dev
{
	public abstract class TreeNode : Panel
	{
		protected Panel TitleBlock;
		protected Panel ChildrenBlock;
		protected Button Expander;

		bool _expanded;

		public bool IsExpanded 
		{
			get => _expanded;
			set
			{
				if ( _expanded == value ) return;
				_expanded = value;
				SetClass( "expanded", _expanded );

				if ( _expanded && ChildrenBlock == null && ContainsChildNodes )
				{
					BuildChildNodes();
				}
			}
		}

		public virtual bool ContainsChildNodes => false;

		public TreeNode()
		{
			AddClass( "treenode" );

			TitleBlock = Add.Panel( "node-title" );

			Expander = TitleBlock.Add.ButtonWithIcon( null, "expand_more", "expand", Toggle );
		}

		public override void Tick()
		{
			base.Tick();

			SetClass( "has-children", ContainsChildNodes );
		}

		public void Toggle()
		{
			IsExpanded = !IsExpanded;
		}

		public virtual void BuildChildNodes()
		{
			
		}

		internal void AddNode( TreeNode node )
		{
			ChildrenBlock ??= Add.Panel( "treenodechildren" );
			ChildrenBlock.AddChild( node );
		}

		public void Clear()
		{
			ChildrenBlock?.DeleteChildren( true );
		}
	}
}
