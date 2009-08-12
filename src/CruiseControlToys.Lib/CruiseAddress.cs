using System;

namespace CruiseControlToys.Lib
{
	public class CruiseAddress
	{
		public Uri Uri { get; set; }

        kfss

		public bool IsValid
		{
			get
            { 
                return Uri != null && Uri.Scheme.StartsWith("http"); 
            }
		}
	}
}
