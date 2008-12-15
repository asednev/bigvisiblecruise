using System;

namespace CruiseControlToys.Lib
{
	public class DashboardCommunicationException : Exception
	{
		private readonly Uri _uri;

		public DashboardCommunicationException(Uri uri, Exception exception)
			: base("Unable to contact " + uri, exception)
		{
			_uri = uri;
		}

		public DashboardCommunicationException(Uri uri)
			: base(string.Format("Invalid URI '{0}'", uri))
		{
			_uri = uri;
		}

		public Uri Uri
		{
			get { return _uri; }
		}
	}
}
