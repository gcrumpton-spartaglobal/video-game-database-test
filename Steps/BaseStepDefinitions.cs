using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameDatabaseTest.Resources.Config;

namespace VideoGameDatabaseTest.Steps
{
    public class BaseStepDefinitions
    {
        private static IRestClient _client;
        private RestRequest _request;
        private RestResponse _response;
        private RestClientOptions _clientOptions = new RestClientOptions("https://videogamedb.uk");
        //private static AppSettings _appSettings;


        public static IRestClient Client { get => _client; set => _client = value; }
        public RestRequest Request { get => _request; set => _request = value; }
        public RestResponse Response { get => _response; set => _response = value; }
        public RestClientOptions ClientOptions { get => _clientOptions;}

        public static void setupConfig()
        {
            //_appSettings = new AppSettings();
            string configSettingPath = System.IO.Directory.GetParent(@"../../").FullName
            + Path.DirectorySeparatorChar + "Resources/Config/appsettings.json";

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(configSettingPath);

            IConfiguration config = builder.Build();

            var username = config.GetSection("username");
            var password = config.GetSection("password");

            // Bind read-in sections to the variables in AppSettings for ease of use
            AppSettings myConfig = new AppSettings();
            username.Bind(myConfig);
            password.Bind(myConfig);
        }
    }
}
