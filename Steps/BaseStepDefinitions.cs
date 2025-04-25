using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
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
        private static RestRequest _request;
        private static RestResponse _response;
        private static RestClientOptions _clientOptions;

        // Stores read-in values from appsettings.config
        private static string _username;
        private static string _password;
        private static string _token;

        public static IRestClient Client { get => _client; set => _client = value; }
        public static RestRequest Request { get => _request; set => _request = value; }
        public static RestResponse Response { get => _response; set => _response = value; }
        public static RestClientOptions ClientOptions { get => _clientOptions; set => _clientOptions = value; }

        // Getters and setters for read-in config values
        public static string Username { get => _username; set => _username = value; }
        public static string Password { get => _password; set => _password = value; }
        public static string Token { get => _token; set => _token = value; }

        public static void SetupConfig()
        {
            Username = "admin";
            Password = "admin";

            SetToken(); // Set the token using the SetToken method

            ClientOptions = new RestClientOptions("https://videogamedb.uk:443")
            {
                Authenticator = new JwtAuthenticator(Token)
            };
        }

        public static void SetToken()
        {
            ClientOptions = new RestClientOptions("https://videogamedb.uk:443");

            Client = new RestClient(ClientOptions);

            Request = new RestRequest("/api/authenticate")
                .AddJsonBody(new Dictionary<string, string> {
                    {"username", Username }, {"password", Password }
                });

            Response = Client.ExecutePost(Request);

            if (Response.IsSuccessful)
            {
                var responseContent = JToken.Parse(Response.Content);
                Token = responseContent["token"].ToString();
            }
            else
            {
                throw new Exception("Failed to retrieve token");
            }
        }
    }
}
