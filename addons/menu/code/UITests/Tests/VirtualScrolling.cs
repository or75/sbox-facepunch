﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.UI.Tests
{
	public class VirtualScrolling : Panel
	{
		public VirtualScrolling()
		{
			Style.FlexWrap = Wrap.Wrap;
			Style.JustifyContent = Justify.Center; 
			Style.AlignItems = Align.Center;
			Style.AlignContent = Align.Center;
			Style.Set( "font-size: 10px; width: 100%; overflow: hidden;" );
			StyleSheet.Parse( "label { flex-grow: 1; font-size: 10px; padding: 10px; border-radius: 2px; background-color: #aaa3; color: white; margin: 5px; margin-bottom: 0; } \n" +
				"button { label { margin: 0; padding: 0; background-color: transparent; } cursor: pointer; flex-grow: 1; font-size: 10px; padding: 10px; border-radius: 2px; color: white; margin: 2px; margin-bottom: 0; &:hover{ background-color: #4af;} }" );


			{
				var data = new List<string>();

				var date = DateTime.Now;
				for ( int i = 0; i < 10; i++ )
				{
					data.Add( $"{date.ToLongDateString()} is on a {date.DayOfWeek}" );
					date = date.AddDays( 1 );
				}

				var vs = AddChild<VirtualScrollPanel<Label>>();

				vs.Data.AddRange( data.Select( x => (object)x ) );
				vs.Style.Set( "width: 300px; border-radius: 4px; height: 400px; background-color: #222; overflow: scroll; padding: 10px; margin: 10px;" );
				vs.Layout.ItemHeight = 30;
			}

			{
				var data = new List<string>();

				var date = DateTime.Now;
				for ( int i = 0; i < 10000; i++ )
				{
					data.Add( $"{date.ToLongDateString()} is on a {date.DayOfWeek}" );
					date = date.AddDays( 1 );
				}

				var vs = AddChild<VirtualScrollPanel<Button>>();

				vs.Data.AddRange( data.Select( x => (object)x ) );
				vs.Style.Set( "width: 300px; border-radius: 4px; height: 400px; background-color: #222; overflow: scroll; padding: 0px; margin: 10px;" );
				vs.Layout.ItemHeight = 30;

			}

			{
				var data = new List<string>();

				var date = DateTime.Now;
				for ( int i = 0; i < 10000; i++ )
				{
					data.Add( $"{date.ToLongDateString()} is on a {date.DayOfWeek}" );
					date = date.AddDays( 1 );
				}

				var vs = AddChild<VirtualScrollPanel<Label>>();

				vs.Data.AddRange( data.Select( x => (object)x ) );
				vs.Style.Set( "width: 300px; border-radius: 4px; height: 390px; background-color: #222; overflow: scroll; padding: 10px; margin: 10px;" );

				vs.Layout.ItemWidth = 90;
				vs.Layout.ItemHeight = 60;
				vs.Layout.AutoColumns = true;
			}

			{
				var data = new List<string>();

				var date = DateTime.Now;
				for ( int i = 0; i < 10000; i++ )
				{
					data.Add( $"{date.ToLongDateString()} is on a {date.DayOfWeek}" );
					date = date.AddDays( 1 );
				}

				var vs = AddChild<VirtualScrollPanel<Label>>();

				vs.Data.AddRange( data.Select( x => (object)x ) );
				vs.Style.Set( "width: 300px; border-radius: 4px; height: 390px; background-color: #222; overflow: scroll; padding: 10px; margin: 10px; justify-content: space-between;" );
				vs.Layout.ItemWidth = 90;
				vs.Layout.ItemHeight = 60;
				vs.Layout.AutoColumns = true;
			}
		}
	}
}
