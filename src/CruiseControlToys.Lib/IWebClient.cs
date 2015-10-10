using System.Net;

namespace CruiseControlToys.Lib
{
	public interface IWebClient
	{
		string DownloadString(string uriString, string user, string passsword);
	}

	public class CruiseWebClient : IWebClient
	{
		private WebClient _webClient;

		public string DownloadString(string uriString, string user, string passsword)
		{
			_webClient = new WebClient();

			if(!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(passsword))
				_webClient.Credentials = new NetworkCredential(user, passsword);

			return _webClient.DownloadString(uriString);
		}
	}
}
