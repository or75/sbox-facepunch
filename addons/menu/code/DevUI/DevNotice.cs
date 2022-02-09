using Sandbox.UI.Construct;
using System.Threading;

namespace Sandbox.UI.Dev
{
	public class DevNotice : Panel
	{
		internal IconPanel Icon;
		internal Label Title;

		internal RealTimeUntil TimeUntilDie;
		internal string Id { get; set; }  

		public DevNotice()
		{
			StyleSheet.Load( "/devui/DevNotice.scss" );  

			Icon = Add.Icon( "‍️⚡" ); 
			Title = Add.Label( "...", "title" ); 
			
			TimeUntilDie = 60;   
		}

		public override void Tick()
		{
			base.Tick();

			if ( TimeUntilDie < 0 )
			{
				Delete();
			}
		}
	}
}
