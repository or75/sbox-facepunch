
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sandbox.UI
{
	[Library( "form" )]
	public class Form : Panel
	{
		protected Panel currentGroup;

		public Form()
		{
			AddClass( "form" );
		}

		public T AddCustom<T>( string entryTitle, DataSource.BaseDataSource dataSource ) where T: Panel, new()
		{
			var row = AddChild<Field>();

			var title = row.Add.Panel( "label" );
			title.Add.Label( entryTitle );

			var value = row.AddChild<FieldControl>();

			var control = value.AddChild<T>();
			control.Bind( dataSource );

			return control;
		}

		public void AddRow( string entryTitle, Panel control )
		{
			var row = AddChild<Field>();

			var title = row.Add.Panel( "label" );
			title.Add.Label( entryTitle );

			var value = row.AddChild<FieldControl>();
			control.Parent = value;
		}

		public void AddHeader( string title, string icon = "category" )
		{
			var row = (currentGroup ?? this).Add.Panel( "field-header" );

			row.Add.Icon( icon ); // todo - get icon from somewhere too
			row.Add.Label( title );
		}


		public bool IsReadOnly( PropertyInfo prop )
		{
			var readonlyAttr = prop.GetCustomAttribute<ReadOnlyAttribute>();

			if ( readonlyAttr != null && readonlyAttr.IsReadOnly )
				return true;

			if ( prop.GetSetMethod() == null )
				return true;

			return false;
		}

		public void AddRow( PropertyInfo member, object target, Panel control )
		{
			var entryTitle = member.Name;

			var displayAttr = member.GetCustomAttribute<DisplayAttribute>();
			if ( displayAttr != null && !string.IsNullOrWhiteSpace( displayAttr.Name ) )
			{
				entryTitle = displayAttr.Name;
			}

			var nameAttr = member.GetCustomAttribute<DisplayNameAttribute>();
			if ( nameAttr != null && !string.IsNullOrWhiteSpace( nameAttr.DisplayName ) )
			{
				entryTitle = nameAttr.DisplayName;
			}

			var row = (currentGroup ?? this).AddChild<Field>();

			var title = row.Add.Panel( "label" );
			title.Add.Label( entryTitle );

			var value = row.AddChild<FieldControl>();
			control.Parent = value;

			control.Bind( new DataSource.Property( "value", target, member ) );
			control.SetClass( "disabled", IsReadOnly( member ) );
		}

		public void Clear()
		{
			DeleteChildren( true );
		}

		protected override void OnEvent( PanelEvent e )
		{
			//
			// One of our child controls changed, fire a form specific event
			//
			if ( e.Name == "onchange" )
			{
				CreateEvent( "form.changed" );
				return;
			}

			base.OnEvent( e );
		}
	}
}
