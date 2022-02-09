﻿using Sandbox.UI.Construct;
using System;
using System.Linq;

namespace Sandbox.UI
{
	[Library( "checkbox" )]
	public class Checkbox : Panel
	{
		/// <summary>
		/// The checkmark icon. Although no guarentees it's an icon!
		/// </summary>
		public Panel CheckMark { get; protected set; }

		protected bool isChecked = false;

		/// <summary>
		/// Returns true if this checkbox is checked
		/// </summary>
		public bool Checked 
		{ 
			get => isChecked;
			set
			{
				if ( isChecked == value ) 
					return;

				isChecked = value;
				OnValueChanged();
			}
		}

		public Label Label { get; protected set; }

		public string LabelText
		{
			get => Label?.Text;
			set
			{
				if ( Label == null )
				{
					Label = Add.Label();
				}

				Label.Text = value;
			}
		}

		public Checkbox()
		{
			AddClass( "checkbox" );
			CheckMark = Add.Icon( "check", "checkmark" );
		}

		public override void SetProperty( string name, string value )
		{
			base.SetProperty( name, value );

			if ( name == "checked" || name == "value" )
			{
				Checked = value.ToBool();
			}

			if ( name == "text" )
			{
				LabelText = value;
			}
		}

		public override void SetContent( string value )
		{
			LabelText = value;
		}

		public virtual void OnValueChanged()
		{
			UpdateState();
			CreateEvent( "onchange", Checked );

			if ( Checked )
			{
				CreateEvent( "onchecked" );
			}
			else
			{
				CreateEvent( "onunchecked" );
			}
		}

		protected virtual void UpdateState()
		{
			SetClass( "checked", Checked );
		}

		protected override void OnClick( MousePanelEvent e )
		{
			base.OnClick( e );

			Checked = !Checked;
			CreateValueEvent( "checked", Checked );
			CreateValueEvent( "value", Checked );
			e.StopPropagation();
		}
	}
}
