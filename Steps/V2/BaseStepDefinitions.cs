using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameDatabaseTest.Resources.Config;

namespace video_game_database_test.Steps.V2
{
    public class BaseStepDefinitions
    {
        private static IRestClient _client;
        private RestRequest _request;
        private RestResponse _response;
        private RestClientOptions _clientOptions = new RestClientOptions("https://videogamedb.uk:443");
        private static AppSettings _myConfig;

        // Stores read-in values from appsettings.config
        private static string _username;
        private static string _password;
        private static string _token;

        public static IRestClient Client { get => _client; set => _client = value; }
        public RestRequest Request { get => _request; set => _request = value; }
        public RestResponse Response { get => _response; set => _response = value; }
        public RestClientOptions ClientOptions { get => _clientOptions; }
        internal static AppSettings MyConfig { get => _myConfig; set => _myConfig = value; }

        // Getters and setters for read-in config values
        public static string Username { get => _username; set => _username = value; }
        public static string Password { get => _password; set => _password = value; }
        public static string Token { get => _token; set => _token = value; }

        public static void SetupConfig()
        {
            string configSettingPath = Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Resources/Config/appsettings.json";

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(configSettingPath);

            IConfiguration config = builder.Build();

            var section = config.GetSection("UserInfo");

            // Bind read-in sections to the variables in AppSettings for ease of use
            _myConfig = new AppSettings();
            section.Bind(_myConfig);

            // Set values for use in step definitions
            Username = MyConfig.Username;
            Password = MyConfig.Password;
            Token = MyConfig.Token;

        }
    }
}
