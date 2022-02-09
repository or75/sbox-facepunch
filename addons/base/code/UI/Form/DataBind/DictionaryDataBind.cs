using System;
using System.Collections.Generic;

namespace Sandbox.UI
{
	public class DictionaryDataBind : DataSource.BaseDataSource
	{
		Dictionary<string, string> dictionary;
		string key;
		string fallback;

		public DictionaryDataBind( string propertyName, Dictionary<string, string> dictionary, string key, string fallback = "" ) : base( propertyName )
		{
			this.dictionary = dictionary;
			this.key = key;
			this.fallback = fallback;
		}

		public override object Value
		{
			get
			{
				if ( dictionary.TryGetValue( key, out var val ) )
					return val;

				return fallback;
			}

			set
			{
				dictionary[key] = value.ToString();
			}
		}
	}
}
