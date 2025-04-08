using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace VideoGameDatabaseTest.Steps
{
    [Binding]
    public class GetAllVideoGamesSteps
    {
        private static IRestClient _client;
        private RestRequest _request;
        private RestResponse _response;

        [Given("I have the endpoint of '/api/v2/videogame'")]
        public void HasEndpoint()
        {
            var options = new RestClientOptions("https://videogamedb.uk");

            _client = new RestClient(options);
            _request = new RestRequest("/api/v2/videogame");
        }

        [When("I send a GET request to that endpoint")]
        public void GetEndpoint() 
        {
            _response = _client.Get(_request);
        }

        [Then("I receive a success code of 200 OK")]
        public void Receive200OK() 
        {
            Assert.That(_response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
