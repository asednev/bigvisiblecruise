using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace CruiseControlToys.Lib
{
    public class DashboardCommunicationException : Exception
    {

        private Uri _uri;

        public Uri Uri
        {
            get{ return _uri; }
        }

        public DashboardCommunicationException(Uri uri, Exception exception)
            : base("Unable to contact " + uri.ToString(), exception)
        {
            _uri = uri;
        }
    }
}
