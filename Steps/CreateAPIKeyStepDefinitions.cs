using System;
using NUnit.Framework;
using Reqnroll;
using RestSharp;

namespace VideoGameDatabaseTest.Steps
{
    [Binding]
    public class CreateAPIKeyStepDefinitions
    {
        private static IRestClient _client;
        private RestRequest _request;
        private RestResponse _response;

        //TODO: Add logic to all step defs

        [Given("I create a POST request with a given username and password")]
        public void GivenICreateAPOSTRequestWithAGivenUsernameAndPassword()
        {
            var options = new RestClientOptions("https://videogamedb.uk");

            _client = new RestClient(options);

            string username = "admin";
            string password = "admin";

            _request = new RestRequest("/api/authenticate")
                .AddJsonBody(new Dictionary<string, string> { 
                    {"username", username }, {"password", password } 
                });
        }

        [When("I send the POST request")]
        public void WhenISendThePOSTRequest()
        {
            _response = _client.Post(_request);
        }

        [Then("I receive a response with a {int} OK status code")]
        public void ThenIReceiveAResponseWithAOKStatusCode(int p0)
        {
            Assert.That((int)_response.StatusCode, Is.EqualTo(p0));
        }
    }
}
