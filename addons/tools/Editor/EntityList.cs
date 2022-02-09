using Sandbox;
using Sandbox.Internal;
using System.Collections.Generic;
using System.Linq;
using Tools;

[Dock( "Editor", "Entity List", "emoji_objects" )]
public class EntityList : Widget
{
	TreeView TreeView;
	EntityNode RootNode;

	List<EntityEntry> AddList = new();
	List<EntityEntry> RemoveList = new();

	public bool HideWorldEntities = true;

	public bool ShowClientOnlyEntities = false;
	public bool ShowServerOnlyEntities = false;
	public bool ShowLocallyOwnedEntitiesOnly = false;

	public string FilterText;

	public EntityList( Widget parent ) : base( parent )
	{
		var layout = MakeTopToBottom();
		layout.SetContentMargins( 4, 4, 4, 4 );
		layout.Spacing = 4;

		var toolbar = layout.Add( new ToolBar( this ) );

		toolbar.AddOption( new Option( toolbar ) 
		{ 
			Tooltip = "Hide Map Entities", 
			Checkable = true,
			Checked = HideWorldEntities,
			Icon = "public_off", 
			Toggled = ( b ) => { HideWorldEntities = b; RootNode.MarkChanged(); } 
		} );
				
		
		toolbar.AddOption( new Option( toolbar ) 
		{ 
			Tooltip = "Show Client Only Entities", 
			Checkable = true,
			Checked = ShowClientOnlyEntities,
			Icon = "computer", 
			Toggled = ( b ) => { ShowClientOnlyEntities = b; RootNode.MarkChanged(); } 
		} );

		toolbar.AddOption( new Option( toolbar ) 
		{ 
			Tooltip = "Show Server Only Entities", 
			Checkable = true,
			Checked = ShowServerOnlyEntities,
			Icon = "dns", 
			Toggled = ( b ) => { ShowServerOnlyEntities = b; RootNode.MarkChanged(); } 
		} );

		toolbar.AddOption( new Option( toolbar ) 
		{ 
			Tooltip = "Show Only Locally Owned Entities", 
			Checkable = true,
			Checked = ShowLocallyOwnedEntitiesOnly,
			Icon = "hail", 
			Toggled = ( b ) => { ShowLocallyOwnedEntitiesOnly = b; RootNode.MarkChanged(); } 
		} );

		toolbar.AddSeparator();

		var filter = new LineEdit( toolbar );
		filter.PlaceholderText = "Filter Entities..";
		filter.TextChanged += OnFilterTextChanged;

		toolbar.AddWidget( filter );
		toolbar.SetIconSize( 18 );

		TreeView = new TreeView( this );
		TreeView.ShowHeader = false;
		TreeView.UniformRowHeights = true;
		layout.Add( TreeView, 1 );

		SetupModel();

		foreach( var entity in Sandbox.Internal.EntityEntry.All )
		{
			OnEntityAdded( entity );
		}
	}


	private void OnFilterTextChanged( string obj )
	{
		FilterText = obj;

		if ( string.IsNullOrEmpty( FilterText ) )
			FilterText = null;

		RootNode.MarkChanged();
	}

	[Event( "entity.added" )]
	public void OnEntityAdded( Sandbox.Internal.EntityEntry e )
	{
		RootNode.AddChild( e.FindParent(), e );
	}

	[Event( "entity.removed" )]
	public void OnEntityRemoved( Sandbox.Internal.EntityEntry e )
	{
		RootNode.FindAndRemove( e );
	}

	[Event( "entity.changed" )]
	public void OnEntityChanged( Sandbox.Internal.EntityEntry e )
	{
		var found = RootNode.FindNodeWithValue<EntityNode>( e );
		if ( found == null ) return;

		found.DataChanged();		
	}

	[Event( "entity.parentchanged" )]
	public void OnEntityParentChanged( Sandbox.Internal.EntityEntry e )
	{
		var found = RootNode.FindNodeWithValue<EntityNode>( e );
		if ( found == null ) return;

		var childEntities = found.ChildNodes.OfType<EntityNode>().Select( x => x.Value ).Where( x => x != null ).ToArray();

		RootNode.FindAndRemove( e );
		RootNode.AddChild( e.FindParent(), e );

		foreach( var child in childEntities )
		{
			OnEntityAdded( child );
		}
	}

	[Event.Frame]
	public void Frame()
	{
		if ( AddList.Count == 0 && RemoveList.Count == 0 )
			return;

		foreach( var add in AddList )
		{
			var parent = add.FindParent();
			RootNode.AddChild( parent, add );
		}

		AddList.Clear();

		foreach ( var remove in RemoveList )
		{
			RootNode.FindAndRemove( remove );
		}

		RemoveList.Clear();
	}

	void SetupModel()
	{
		TreeView.Clear();

		RootNode = new ( null );
		RootNode.SortBy = ( o ) => o.FirstSeen;
		RootNode.ShouldShowItem = ShouldShowItem;

		TreeView.SetModel( RootNode );
	}

	private bool ShouldShowItem( EntityEntry value )
	{
		// Don't filter child entities
		if ( value.AnyEntity?.Parent != null ) return true;

		if ( HideWorldEntities && (value.AnyEntity?.IsFromMap ?? false) ) return false;
		if ( ShowClientOnlyEntities && value.Server != null ) return false;
		if ( ShowServerOnlyEntities && value.Client != null ) return false;
		if ( ShowLocallyOwnedEntitiesOnly && !(value.AnyEntity?.IsOwnedByLocalClient ?? false) ) return false;

		if ( FilterText != null )
		{
			if ( !value.AnyEntity.ToString().Contains( FilterText, System.StringComparison.OrdinalIgnoreCase ) )
				return false;
		}

		return true;
	}

}


public class EntityNode : DataValueNode<Sandbox.Internal.EntityEntry>
{
	public EntityNode( Sandbox.Internal.EntityEntry obj ) : base( obj )
	{
		
	}

	public void AddChild( Sandbox.Internal.EntityEntry value )
	{
		AddChild( new EntityNode( value ) );
	}

	public void AddChild( EntityEntry parent, EntityEntry child )
	{
		if ( parent != null )
		{
			var targetNode = FindNodeWithValue<EntityNode>( parent );
			if ( targetNode != null )
			{
				targetNode.AddChild( child );
				return;
			}
		}

		AddChild( child );
	}

	public override void PaintItem( in Rect rect, int column )
	{
		var entity = Value?.Client ?? Value?.Server ?? null;
		var info = DisplayInfo.For( entity );
		var color = Theme.Green;
		bool isDormant = entity?.IsDormant ?? true;
		var alpha = isDormant ? 0.5f : 1.0f;
		if ( Value?.Client != null && Value?.Server == null ) color = Theme.Yellow;
		if ( Value?.Client == null && Value?.Server != null ) color = Theme.Blue;

		var name = "Unknown";
		if ( entity != null )
		{
			name = entity.ToString();
		}

		Paint.Antialiasing = true;

		var iconRect = rect;
		iconRect.width = iconRect.height;

		Paint.SetPenEmpty();
		Paint.SetBrush( color.Saturate( -0.4f ).Darken( 0.4f ).WithAlpha( alpha * 0.5f ) );
		Paint.DrawRect( iconRect.Expand( -1 ), 2.0f );

		var r = rect;
		Paint.SetPen( color.Lighten( 0.2f ).WithAlpha( alpha ) );
		Paint.DrawMaterialIcon( iconRect, info.Icon ?? "help_outline", 11, TextFlag.AlignCenter );
		r.left = iconRect.right + 5;

		Paint.SetDefaultFont( 8 );
		Paint.SetPen( color.WithAlpha( alpha ) );
		var nameRect = Paint.DrawText( r, name, TextFlag.LeftCenter );

		r.left += nameRect.width + 5;

		if ( isDormant )
		{
			Paint.SetPen( color.WithAlpha( alpha * 0.5f ) );
			Paint.DrawText( r, "[dormant]", TextFlag.LeftCenter );
		}

		if ( entity?.Client != null )
		{
			Paint.SetPen( color.WithAlpha( alpha * 0.3f ) );
			Paint.DrawText( r, $"{entity?.Client} ", TextFlag.Right | TextFlag.VCenter );
		}
	}

	protected override void OnNodeSelected()
	{
		base.OnNodeSelected();

		Utility.Inspect( Value?.Server ?? Value?.Client );
	}
}
