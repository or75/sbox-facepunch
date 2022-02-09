namespace Sandbox.UI
{
	public class Option
	{
		public string Title;
		public string Icon;
		public string Subtitle;
		public string Tooltip;
		public object Value;

		public Option()
		{

		}

		public Option( string title, object value )
		{
			Title = title;
			Value = value;
		}
		public Option( string title, string icon, object value )
		{
			Title = title;
			Icon = icon;
			Value = value;
		}
	}
}
