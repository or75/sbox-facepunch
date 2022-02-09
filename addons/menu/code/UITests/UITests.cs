using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

[Library]
[NavigatorTarget( "/test/ui" )]
public class UITests : Panel
{
	public Panel Inner { get; set; }
	public Panel PageList { get; set; }
	public Panel PageContainer { get; set; }

	Dictionary<string, Sandbox.UI.Button> Buttons;

	public UITests()
	{
		StyleSheet.Load( "/UITests/UITests.scss" );
		Buttons = new Dictionary<string, Sandbox.UI.Button>();

		//
		// Inner is the white inset square containing everything else
		// if we don't do accepts input you'll be able to click through, which
		// means that OnMouseDown will get called and we'll close.
		//
		Inner = Add.Panel( "inner" );
		

		PageList = Inner.Add.Panel( "pagelist" );
		PageContainer = Inner.Add.Panel( "pagecontainer" );

		//	LoadCss( "/ui/panoramatest/panoramatest.less" );

		//AddPage( "Buttons", () => PageContainer.Add.Panel().LoadLayout( "/ui/panoramatest/buttons.htm" ) );
		//	AddPage( "Performance", () => PageContainer.AddChild<PerformanceTest>() );
		//	AddPage( "Grid", () => PageContainer.AddChild<GridTest>() );

		AddPage( "content_cut", "scissoring", () => PageContainer.AddChild<Sandbox.UI.Tests.Scissoring>() );
		AddPage( "format_color_text", "text rendering", () => PageContainer.AddChild<Sandbox.UI.Tests.TextRendering>() );
		AddPage( "format_color_text", "text-shadow", () => PageContainer.AddChild<Sandbox.UI.Tests.TextShadow>() );
		AddPage( "widgets", "control zoo", () => PageContainer.AddChild<Sandbox.UI.Tests.Zoo>() );
		AddPage( "grain", "backdrop filter", () => PageContainer.AddChild<Sandbox.UI.Tests.BackdropFilter>() );
		AddPage( "screen_rotation", "transformed interact", () => PageContainer.AddChild<Sandbox.UI.Tests.TransformedInteract>() );
		AddPage( "escalator", "scrolling", () => PageContainer.AddChild<Sandbox.UI.Tests.Scrolling>() );
		AddPage( "insert_emoticon", "icons", () => PageContainer.AddChild<Sandbox.UI.Tests.IconTests>() );
		AddPage( "code", "templates", () => PageContainer.AddChild<Sandbox.UI.Tests.TemplateTest>() );
		AddPage( "opacity", "opacity", () => PageContainer.AddChild<Sandbox.UI.Tests.Opacity>() );
		AddPage( "rounded_corner", "border radius", () => PageContainer.AddChild<Sandbox.UI.Tests.BorderRadius>() );
		AddPage( "wallpaper", "background position", () => PageContainer.AddChild<Sandbox.UI.Tests.BackgroundPosition>() );
		AddPage( "help_center", "virtual scrolling", () => PageContainer.AddChild<Sandbox.UI.Tests.VirtualScrolling>() );
		AddPage( "mouse", "mouse capture", () => PageContainer.AddChild<Sandbox.UI.Tests.MouseCapture>() );
		AddPage( "transform", "transform", () => PageContainer.AddChild<Sandbox.UI.Tests.Transforms>() );
		AddPage( "rounded_corner", "borders", () => PageContainer.AddChild<Sandbox.UI.Tests.Borders>() );
		AddPage( "border_outer", "border images", () => PageContainer.AddChild<Sandbox.UI.Tests.BorderImages>() );
		AddPage( "blur_on", "effects", () => PageContainer.AddChild<Sandbox.UI.Tests.Effects>() );
		AddPage( "rtt", "text entry", () => PageContainer.AddChild<Sandbox.UI.Tests.TextEntryTest>() );
		AddPage( "format_align_center", "text align", () => PageContainer.AddChild<Sandbox.UI.Tests.TextAlign>() );
		AddPage( "wrap_text", "wrap - uniform size", () => PageContainer.AddChild<Sandbox.UI.Tests.WrapSimple>() );
		AddPage( "wrap_text", "wrap - random size", () => PageContainer.AddChild<Sandbox.UI.Tests.WrapRandom>() );
		AddPage( "wrap_text", "wrap - contain text", () => PageContainer.AddChild<Sandbox.UI.Tests.WrapText>() );
		AddPage( "check_box_outline_blank", "box-shadow", () => PageContainer.AddChild<Sandbox.UI.Tests.BoxShadow>() );
		AddPage( "format_size", "text color", () => PageContainer.AddChild<Sandbox.UI.Tests.TextColor>() );
		AddPage( "picture_in_picture", "position", () => PageContainer.AddChild<Sandbox.UI.Tests.Position>() );
		AddPage( "text_format", "font styles", () => PageContainer.AddChild<Sandbox.UI.Tests.TextStyles>() );
		AddPage( "view_in_ar", "render scene", () => PageContainer.AddChild<Sandbox.UI.Tests.RenderScene>() );
		AddPage( "photo_size_select_large", "image rendering", () => PageContainer.AddChild<Sandbox.UI.Tests.ImageRendering>() );
		
		Buttons.First().Value.CreateEvent( "onclick" );
	}

	void AddPage( string icon, string name, Func<Panel> act = null )
	{
		var button = PageList.Add.Button( name, () => { SwitchPage( name ); act?.Invoke().AddClass( "page" ); } );
		button.Icon = icon;

		Buttons[name] = button;
	}

	void SwitchPage( string name )
	{
		PageContainer.DeleteChildren();

		foreach( var button in Buttons )
		{
			button.Value.SetClass( "active", button.Key == name );
		}
	}

	public override void OnHotloaded()
	{
		base.OnHotloaded();

		var activePage = Buttons.Where( x => x.Value.HasClass( "active" ) ).FirstOrDefault();
		if ( activePage.Value != null )
		{
			activePage.Value.CreateEvent( "onclick" );
		}
	}

}
