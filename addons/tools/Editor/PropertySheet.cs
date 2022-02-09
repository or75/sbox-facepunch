using Sandbox;
using Sandbox.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Tools;

public class PropertySheet : Widget
{
	object _target;
	public object Target
	{
		get => _target;
		set
		{
			if ( _target == value )
				return;

			_target = value;
			Rebuild();
		}
	}

	public bool IncludeHeader { get; set; } = true;
	public bool GroupByClass { get; set; } = true;

	BoxLayout layout;

	public PropertySheet( Widget parent ) : base( parent )
	{
		layout = MakeTopToBottom();
		SetSizeMode( SizeMode.Default, SizeMode.CanShrink );
	}

	void Rebuild()
	{
		if ( Target == null )
			return;

		foreach ( var child in Children )
			child.Destroy();

		if ( IncludeHeader )
			layout.Add( new SheetHeader( this ) );

		var properties = Target.GetType().GetProperties( BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.Public )
									.Where( x => IsPropertyAcceptable( x ) )
									.Select( x => ( property: x, info: DisplayInfo.ForProperty( x ) ) )
									.Where( x => x.info.Browsable ).ToArray();

		var grouped = properties.GroupBy( x => x.property.DeclaringType ).Reverse().ToArray();

		foreach ( var classGroup in grouped )
		{
			var sheet = new PropertySheet( this );

			if ( GroupByClass )
			{
				var expander = new ExpandGroup( this );
				var info = DisplayInfo.ForType( classGroup.Key, false );
				expander.Title = info.Name;
				expander.Icon = info.Icon ?? expander.Icon;
				layout.Add( expander );
				expander.SetWidget( sheet );
			}
			else
			{
				layout.Add( sheet );
			}

			foreach ( var group in classGroup.OrderBy( x => x.info.Order ).GroupBy( x => x.info.Group ) )
			{
				if ( !string.IsNullOrEmpty( group.Key  ) )
					sheet.AddSectionHeader( group.Key );

				foreach ( var prop in group.OrderBy( x => x.info.Order ).ThenBy( x => x.info.Name ) )
				{
					var addedRow = sheet.AddProperty( prop.property, Target );

					if ( !string.IsNullOrEmpty( prop.info.Description ) )
					{
						addedRow.StatusTip = prop.info.Description;
						addedRow.ToolTip = prop.info.Description;
					}
				}
			}
		}
	}

	internal void EnableRow( string v, bool visible )
	{
		if ( NamedRows.TryGetValue( v, out var w ) )
		{
			w.Visible = visible;
		}
	}

	Dictionary<string, Widget> NamedRows = new();

	internal void AddProperty( object target, string targetName )
	{
		var prop = target.GetType().GetProperties( BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.Public )
										.FirstOrDefault( x => x.Name == targetName );

		var info = DisplayInfo.ForProperty( prop );

		var addedRow = AddProperty( prop, target );

		if ( !string.IsNullOrEmpty( info.Description ) )
		{
			addedRow.StatusTip = info.Description;
			addedRow.ToolTip = info.Description;
		}
	}

	public void AddSectionHeader( string name )
	{
		AddRow( new Label( name, null, "PropertyHeader" ) );
	}

	public void AddRow( Widget row, string name = null )
	{
		layout.Add( row );
		row.SetSizeMode( SizeMode.Default, SizeMode.CanShrink );

		if ( name != null )
			NamedRows[name] = row;
	}

	Widget AddProperty( PropertyInfo prop, object target )
	{
		var w = CanEditAttribute.CreateEditorFor( prop );
		if ( w != null )
		{
			w.DataBinding = new PropertyBind( target, prop );

			if ( w is IPropertyInspector pi && pi.IsFullWidth )
			{
				AddRow( w, prop.Name );
				return w;
			}
			
			var row = new PropertyRow( this );
			row.SetLabel( prop );
			row.SetWidget( w );

			AddRow( row, prop.Name );
			return row;
		}

		// display only
		{
			var row = new PropertyRow( this );
			row.SetLabel( prop );

			if ( ObjectProperty.IsApplicable( prop.PropertyType ) )
			{
				//
				// Object drag and droppable field
				//
				var viewer = new ObjectProperty( row, prop.PropertyType );
				viewer.DataBinding = new PropertyBind( target, prop );
				row.SetWidget( viewer );
			}
			else
			{
				//
				// Generic display 
				//
				var viewer = new Label( row );
				viewer.WordWrap = true;
				viewer.DataBinding = new PropertyBind( target, prop );
				row.SetWidget( viewer );
			}

			AddRow( row, prop.Name );
			return row;
		}

	}

	public void AddStretch( int i )
	{
		layout.AddStretchCell( i );
	}

	private bool IsPropertyAcceptable( PropertyInfo x )
	{
		if ( x.GetMethod == null ) return false;
		if ( x.GetMethod.IsStatic ) return false;
		if ( !x.CanRead ) return false;

		if ( x.GetIndexParameters().Length > 0 ) return false;

		if ( x.PropertyType.IsByRefLike ) return false;
		if ( x.GetCustomAttribute<EditorBrowsableAttribute>()?.State == EditorBrowsableState.Never ) return false;
		if ( x.GetCustomAttribute<BrowsableAttribute>()?.Browsable == false ) return false;

		return true;
	}
}
