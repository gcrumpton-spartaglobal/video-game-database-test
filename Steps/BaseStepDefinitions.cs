using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameDatabaseTest.Steps
{
    public class BaseStepDefinitions
    {
        private static IRestClient _client;
        private RestRequest _request;
        private RestResponse _response;
        private RestClientOptions _clientOptions = new RestClientOptions("https://videogamedb.uk");

        public static IRestClient Client { get => _client; set => _client = value; }
        public RestRequest Request { get => _request; set => _request = value; }
        public RestResponse Response { get => _response; set => _response = value; }
        public RestClientOptions ClientOptions { get => _clientOptions;}
    }
}
