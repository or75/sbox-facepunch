using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sandbox.UI.Dev
{
	public class DevLayer : RootPanel 
	{
		public static DevLayer Instance;

		ExceptionNotification ExceptionNotification; 

		public Panel NoticeContainer;

		public DevLayer()
		{
			Instance = this;

			StyleSheet.Load( "/styles/devui.scss" );
			
			AddChild<DeveloperMode>();

			AddChild<ConsoleOverlay>();

			AddChild<PerformanceWidget>();
			AddChild<PerformanceChartWidget>();

			NoticeContainer = Add.Panel( "notice-container" );
			ExceptionNotification = AddChild<ExceptionNotification>();

			MenuEngine.Tools.AddLogger( OnConsoleMessage );
		}

		public override void OnDeleted()
		{
			base.OnDeleted();

			MenuEngine.Tools.RemoveLogger( OnConsoleMessage );
		}

		[ConVar.Menu]
		public static float DevUI_Scale { get; set; } = 1.0f;


		protected override void UpdateScale( Rect screenSize )
		{
			Scale = DevUI_Scale;
		}

		private void OnConsoleMessage( LogEvent entry )
		{
			if ( !ThreadSafe.IsMainThread )
				return;
			
			if ( entry.Level == LogLevel.Error )
			{
				ExceptionNotification.OnException( entry );
			}
		}

		[MenuCmd( "dev_notice_add" )]  
		public static void DevNoticeAdd( string id, string clss, string icon, string message, float timeToLive, string information = null ) 
		{
			var notice = Instance.NoticeContainer.Children.Cast<DevNotice>()
													.Where( x => x != null )
													.Where( x => !x.IsDeleting )
													.Where( x => x.Id == id )
													.FirstOrDefault();

			if ( notice == null )
			{
				notice = new DevNotice();
				notice.Id = id;
			}

			var foundIcon = UI.Emoji.FindEmoji( icon );
			if ( foundIcon != null ) icon = foundIcon;

			notice.SetClass( "error", clss == "error" );
			notice.SetClass( "working", clss == "working" );
			notice.SetClass( "success", clss == "success" );

			notice.Icon.Text = icon;
			notice.Title.Text = message;

			if ( timeToLive < 0 ) timeToLive = 60;

			notice.TimeUntilDie = timeToLive;

			notice.Parent = Instance.NoticeContainer;
		}
	}
}
