using System.Net;

namespace CruiseControlToys.Lib
{
	public interface IWebClient
	{
		string DownloadString(string uriAsString);
	}

	public class CruiseWebClient : IWebClient
	{
		private WebClient _webClient;
		public string DownloadString(string uriString)
		{
			_webClient = new WebClient();
			return _webClient.DownloadString(uriString);
		}
	}
}
